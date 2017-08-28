Public Class frmPaintServer

#Region "Constant"

#End Region

#Region "Attribute"
    Private m_clsLog As New clsLogger
    Private m_clsDBLog As New clsDBLogger
    Private m_blnShutdown As Boolean = False

    Private m_strLockFilePath As String

    Private m_RowIndexDict As New Dictionary(Of Integer, Integer)

    Private m_clsManualImportFileThred As clsImportFile

    Private m_listPLCThreads As New List(Of clsPlcCommunication)

    Private WithEvents m_clsDBStatus As clsDBStatus
#End Region

#Region "Constructor"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

#End Region

#Region "Properties"
    Public WriteOnly Property ShutDownFlag() As Boolean
        Set(ByVal value As Boolean)
            m_blnShutdown = value
        End Set
    End Property
#End Region

#Region "Event"

    Private Sub frmPaintServer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Start Check DB status
        m_clsDBStatus = New clsDBStatus()
        m_clsDBStatus.WorkerReportsProgress = True
        m_clsDBStatus.RunWorkerAsync()

        'Load AS400 log
        m_clsDBLog.Log(DB_LOG_CODE_N_DATA_COLLECT_START, Nothing)
        If ctrlDBStatus.LastConnectionStatus Then
            modLoadData.LoadAS400Log(modIni.DisplayRows, modIni.AppStartTime)
            Me.bsTLogDat.DataSource = modLoadData.LogData
        End If

        'Start Timer For Lock File
        Me.TimerLockFile.Enabled = True
        Me.TimerLockFile.Interval = 5000
        Me.TimerLockFile.Start()

        'Start Timer For Reload AS400 log
        Me.TimerReloadAS400Log.Enabled = True
        Me.TimerReloadAS400Log.Interval = 1000
        Me.TimerReloadAS400Log.Start()

        'Start Timer For Send Export File to PLC
        Me.TimerCallExpSend.Enabled = True
        Me.TimerCallExpSend.Interval = modIni.ExportSleepTime
        Me.TimerCallExpSend.Start()

        'Set Process master
        For ind As Integer = 0 To modLoadData.PlcStatusDataTable.Count - 1
            'For ind As Integer = 0 To 0
            Dim drLine As dsPAINT.dtPlcStatusRow = modLoadData.PlcStatusDataTable(ind)
            m_RowIndexDict.Add(drLine.STAGE_CODE, ind)
        Next

        Me.bsTProcessMst.DataSource = modLoadData.PlcStatusDataTable

        StartProcessMonitor()
        StartManualImportFile()
    End Sub

    Private Sub frmPaintServer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'For Each clsPlcComm As clsPlcCommunication In m_listPLCThreads
        For i As Integer = m_listPLCThreads.Count - 1 To 0 Step -1
            Dim clsPlcComm As clsPlcCommunication = m_listPLCThreads(i)
            clsPlcComm.CancelAsync()
            HMI_LIB.FinsGW.uEndFGW(clsPlcComm.StageCode)
            clsPlcComm.Dispose()
        Next
    End Sub

    Private Sub m_objDBStatus_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles m_clsDBStatus.ProgressChanged
        Me.ctrlDBStatus.FillColor(m_clsDBStatus.SuccessColor, m_clsDBStatus.FailColor)
        Me.ctrlDBStatus.LastConnectionStatus = m_clsDBStatus.LastConnectionStatus
    End Sub

    Private Sub TimerReloadAS400Log_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimerReloadAS400Log.Tick
        Me.TimerReloadAS400Log.Stop()
        Try
            If ctrlDBStatus.LastConnectionStatus Then
                modLoadData.LoadAS400Log(modIni.DisplayRows, modIni.AppStartTime)
                Me.bsTLogDat.DataSource = modLoadData.LogData
            End If
        Catch ex As Exception
            Me.m_clsLog.Log(clsLogger.MessageType.ErrorLog, Me.GetType.Name, "TimerReloadAS400Log_Tick", ex.Message, "")
        End Try
        Me.TimerReloadAS400Log.Start()
    End Sub

    Private Sub dgv_logData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_logData.Click
        Me.TimerReloadAS400Log.Start()
    End Sub

    Private Sub dgv_logData_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles dgv_logData.Scroll
        Me.TimerReloadAS400Log.Stop()
    End Sub

    Private Sub TimerCallExpSend_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimerCallExpSend.Tick
        Try
            MergeExportFile(modIni.ExportFileFullPath, modIni.ExportFilePath)
            MergeErrorExportFile(modIni.ExportFileFullPath, modIni.ExportFilePath, modIni.ErrorExportFile)
            If File.Exists(modIni.ExportFileFullPath) Then
                Shell(My.Application.Info.DirectoryPath & "/expsend.bat", AppWinStyle.Hide, False)
            Else
                'Me.m_clsLog.Log(clsLogger.MessageType.NormalLog, Me.GetType.Name, "TimerCallExpSend_Tick", "No export file", "")
            End If
        Catch ex As Exception
            Me.m_clsLog.Log(clsLogger.MessageType.ErrorLog, Me.GetType.Name, "TimerCallExpSend_Tick", ex.Message, "")
        End Try
    End Sub

    Private Sub BackgroundWorker_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs)
        Try
            Dim objPLCCommTester As clsPlcCommunication = DirectCast(sender, clsPlcCommunication)

            With objPLCCommTester
                Dim dr As dsPAINT.dtPLC_MSTRow = modLoadData.GetPLCMasterByStageCode(.StageCode)
                Dim drPlcStatus As dsPAINT.dtPlcStatusRow = modLoadData.GetPLCStatusByStageCode(.StageCode)
                Debug.Assert(dr IsNot Nothing)

                'drPlcStatus.CUR_STATUS = IIf(.IsConnected, "Normal", "Error")
                drPlcStatus.CUR_STATUS = IIf(e.ProgressPercentage = 100, "Normal", "Error")
                drPlcStatus.LASTEST_MSG = .ErrorMessage
                Dim intLine As Integer = m_RowIndexDict(dr.STAGE_CODE)
                If .IsConnected Then
                    'Normal
                    Me.dgv_lineMonitorView.Rows(intLine).DefaultCellStyle.BackColor = Color.White
                    Me.dgv_lineMonitorView.Rows(intLine).DefaultCellStyle.SelectionBackColor = Color.White
                    Me.dgv_lineMonitorView.Rows(intLine).DefaultCellStyle.ForeColor = Color.Black
                    Me.dgv_lineMonitorView.Rows(intLine).DefaultCellStyle.SelectionForeColor = Color.Black
                Else
                    'Error
                    Me.dgv_lineMonitorView.Rows(intLine).DefaultCellStyle.BackColor = Color.Red
                    Me.dgv_lineMonitorView.Rows(intLine).DefaultCellStyle.SelectionBackColor = Color.Red
                End If
            End With
        Catch ex As Exception
            Me.m_clsLog.Log(clsLogger.MessageType.ErrorLog, Me.GetType.Name, "BackgroundWorker_ProgressChanged", ex.Message, "")
        End Try
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        If MsgBox("Do you want to exit?", MessageBoxButtons.YesNo) = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

#End Region

#Region "Method"

    Private Sub StartProcessMonitor()
        Dim dt As dsPAINT.dtPLC_MSTDataTable = modLoadData.PlcMasterDataTable

        For i As Integer = 0 To modLoadData.PlcStatusDataTable.Count - 1
            'For i As Integer = 0 To 0
            Dim drPlcStatus As dsPAINT.dtPlcStatusRow = modLoadData.PlcStatusDataTable(i)

            Dim drPlcMst() As dsPAINT.dtPLC_MSTRow = dt.Select("STAGE_CODE = " & drPlcStatus.STAGE_CODE)

            HMI_LIB.FinsGW.uInitFGW(dt(i).STAGE_CODE, drPlcMst(0).ProcessName)
            Dim trdPLC As clsPlcCommunication = New clsPlcCommunication(drPlcMst(0), 1)

            With trdPLC
                .WorkerReportsProgress = True
                .WorkerSupportsCancellation = True

                AddHandler .ProgressChanged, AddressOf BackgroundWorker_ProgressChanged

                .RunWorkerAsync()
            End With

            m_listPLCThreads.Add(trdPLC)

        Next
    End Sub

    Private Sub StartManualImportFile()
        m_clsManualImportFileThred = New clsImportFile(modIni.WatchPath, modIni.BackupWatchPath)
        With m_clsManualImportFileThred
            .WorkerReportsProgress = True
            .WorkerSupportsCancellation = True

            .RunWorkerAsync()
        End With
    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        StartManualImportFile()
    End Sub
End Class