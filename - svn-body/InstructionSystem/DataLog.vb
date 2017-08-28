Imports Common
Imports System.IO.StreamWriter
Imports System.IO.StringWriter

Public Class DataLog

#Region "PUBLIC MEMBER"
    Private Const SCREEN_NAME_AS400 As String = "AS400_LOG_SCHEDULE"
    Private Const SCREEN_NAME_PLC As String = "PLC_LOG_SCHEDULE"
    Private Const SCREEN_NAME_OPE As String = "OPERATION_LOG_SCHEDULE"
    Dim logger As Logger = New Logger()
#End Region

    Private Sub DataLog_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnCancle_Click", "Close DataLog Screen", "")

        Dim colObj As clsColumnSetup = New clsColumnSetup()
        colObj.setColumnIni(dataGridAs400Log, SCREEN_NAME_AS400)

        colObj.setColumnIni(datagridPlcLog, SCREEN_NAME_PLC)

        colObj.setColumnIni(datagridOperationLog, SCREEN_NAME_OPE)

        Main_Menu.Show()
        Me.Dispose()

    End Sub

    Private Sub DataLog_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyData
            Case Keys.F1
                btnExport_Click(sender, e)
            Case Keys.F9
                btnOk_Click(sender, e)
            Case Keys.F12
                btnCancel_Click(sender, e)

        End Select
    End Sub

    Private Sub DataLog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "DataLog_Load", "Load DataLog Screen", "")
        'TODO: This line of code loads data into the 'DataSet1.T_LOG_DAT' table. You can move, or remove it, as needed.

        Try

            LoadDataLog()

            Dim colObj As clsColumnSetup = New clsColumnSetup()

            setDatagridColWidth(colObj.getColumnIni(dataGridAs400Log.Columns.Count, SCREEN_NAME_AS400), colObj.getColumnIni(datagridPlcLog.Columns.Count, SCREEN_NAME_PLC), colObj.getColumnIni(datagridOperationLog.Columns.Count, SCREEN_NAME_OPE))
            Timer1.Start()
            Main_Menu.Hide()
        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "DataLog_Load", "Unable to connect the database.", "")
            MessageBox.Show(ex.Message)
            Me.Close()
        End Try

    End Sub

    Private Sub setDatagridColWidth(ByVal arr1 As String(), ByVal arr2 As String(), ByVal arr3 As String())

        Dim i As Integer
        Dim array() As String
        Dim colSum As Integer = 0
        array = arr1
        For i = 0 To array.Count - 1
            dataGridAs400Log.Columns(i).Width = Integer.Parse(array(i))
            colSum += dataGridAs400Log.Columns(i).Width
        Next
        If colSum < dataGridAs400Log.Width Then
            dataGridAs400Log.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
        End If

        array = arr2
        colSum = 0
        For i = 0 To array.Count - 1
            datagridPlcLog.Columns(i).Width = Integer.Parse(array(i))
            colSum += datagridPlcLog.Columns(i).Width
        Next
        If colSum < datagridPlcLog.Width Then
            datagridPlcLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
        End If

        array = arr3
        colSum = 0
        For i = 0 To array.Count - 1
            datagridOperationLog.Columns(i).Width = Integer.Parse(array(i))
            colSum += datagridOperationLog.Columns(i).Width
        Next
        If colSum < datagridOperationLog.Width Then
            datagridOperationLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
        End If

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnOK_Click", "Load DataLog", "")
        LoadDataLog()

    End Sub

    'Private Function CreateSqlSearchString(ByVal logType As Integer) As String

    '    Dim strQuery As String = Nothing

    '    strQuery = "SELECT * "

    '    strQuery += " FROM T_LOG_DAT "

    '    strQuery += " WHERE LogType = " + logType.ToString

    '    strQuery += " ORDER BY OccDate"

    '    Return strQuery

    'End Function

    Private Sub LoadDataLog()

        'm_singletonSqlDb.Connect()
        'Dim strQuery As String
        'strQuery = CreateSqlSearchString(Me.TabControl1.SelectedIndex)

        Me.TabControl1.SelectedTab.Show()

        Dim dt As DataSet1.T_LOG_DATDataTable = New DataSet1.T_LOG_DATDataTable

        If Me.TabControl1.SelectedIndex = 0 Then
            logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "LoadDataLog", "Load AS400 DataLog", "")
            T_LOG_DATTableAdapter.FillByLogType(dt, 0)
            Dim aDR As DataRow
            Dim rowCount As Integer = 1
            For Each aDR In dt.Rows
                aDR("indexNo") = rowCount
                rowCount = rowCount + 1
            Next
            Me.dataGridAs400Log.DataSource = dt

        ElseIf Me.TabControl1.SelectedIndex = 1 Then
            logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "LoadDataLog", "Load PLC DataLog", "")
            T_LOG_DATTableAdapter.FillByLogType(dt, 1)
            Dim aDR As DataRow
            Dim rowCount As Integer = 1
            For Each aDR In dt.Rows
                aDR("indexNo") = rowCount
                rowCount = rowCount + 1
            Next
            Me.datagridPlcLog.DataSource = dt

        ElseIf Me.TabControl1.SelectedIndex = 2 Then
            logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "LoadDataLog", "Load OperationLog DataLog", "")
            T_LOG_DATTableAdapter.FillByLogType(dt, 2)
            Dim aDR As DataRow
            Dim rowCount As Integer = 1
            For Each aDR In dt.Rows
                aDR("indexNo") = rowCount
                rowCount = rowCount + 1
            Next
            Me.datagridOperationLog.DataSource = dt

        End If

        setDatagridColor()

    End Sub



    Private Sub setDatagridColor()

        If Me.TabControl1.SelectedIndex = 0 Then

            Dim row As Integer = 0
            Do While row < dataGridAs400Log.RowCount

                Dim logLevel As Object = dataGridAs400Log.Rows(row).Cells("LogLevel0").Value
                If CInt(logLevel) = 0 Then
                    dataGridAs400Log.Rows(row).DefaultCellStyle.BackColor = Color.White
                ElseIf CInt(logLevel) = 1 Then
                    dataGridAs400Log.Rows(row).DefaultCellStyle.BackColor = Color.Yellow
                ElseIf CInt(logLevel) = 2 Then
                    dataGridAs400Log.Rows(row).DefaultCellStyle.BackColor = Color.Red
                End If

                row += 1
            Loop

        ElseIf Me.TabControl1.SelectedIndex = 1 Then

            Dim row As Integer = 0
            Do While row < datagridPlcLog.RowCount

                Dim logLevel As Object = datagridPlcLog.Rows(row).Cells("LogLevel1").Value
                If CInt(logLevel) = 0 Then
                    datagridPlcLog.Rows(row).DefaultCellStyle.BackColor = Color.White
                ElseIf CInt(logLevel) = 1 Then
                    datagridPlcLog.Rows(row).DefaultCellStyle.BackColor = Color.Yellow
                ElseIf CInt(logLevel) = 2 Then
                    datagridPlcLog.Rows(row).DefaultCellStyle.BackColor = Color.Red
                End If

                row += 1
            Loop

        ElseIf Me.TabControl1.SelectedIndex = 2 Then

            Dim row As Integer = 0
            Do While row < datagridOperationLog.RowCount

                Dim logLevel As Object = datagridOperationLog.Rows(row).Cells("LogLevel2").Value
                If CInt(logLevel) = 0 Then
                    datagridOperationLog.Rows(row).DefaultCellStyle.BackColor = Color.White
                ElseIf CInt(logLevel) = 1 Then
                    datagridOperationLog.Rows(row).DefaultCellStyle.BackColor = Color.Yellow
                ElseIf CInt(logLevel) = 2 Then
                    datagridOperationLog.Rows(row).DefaultCellStyle.BackColor = Color.Red
                End If

                row += 1
            Loop

        End If

    End Sub



    Private Sub TabControl1_Selected(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles TabControl1.Selected

        LoadDataLog()

    End Sub

    Private Sub FillByToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Me.T_LOG_DATTableAdapter.FillBy(Me.DataSet1.T_LOG_DAT)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label1.Text = Now.ToString("dd MMM yyyy  HH:mm:ss")

    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click

        Dim tabName As String = ""


        If TabControl1.SelectedIndex = 0 Then
            tabName = "AS400"
        ElseIf TabControl1.SelectedIndex = 1 Then
            tabName = "PLC"
        ElseIf TabControl1.SelectedIndex = 2 Then
            tabName = "Operation"
        End If


        SaveFileDialog.FileName = Date.Now.ToString("yyyyMMdd") & "_" & tabName
        SaveFileDialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*"
        'SaveFileDialog.InitialDirectory = Application.StartupPath

        SaveFileDialog.ShowDialog()

    End Sub

    Private Sub SaveFileDialog_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveFileDialog.Disposed

        SaveFileDialog.InitialDirectory = My.Application.Info.DirectoryPath
        SaveFileDialog.RestoreDirectory = True

    End Sub

    Private Sub SaveFileDialog_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog.FileOk


        Dim tabName As String = ""
        'TextBox1.Text = TabControl1.SelectedIndex
        Dim dt As DataSet1.T_LOG_DATDataTable = New DataSet1.T_LOG_DATDataTable


        If TabControl1.SelectedIndex = 0 Then
            T_LOG_DATTableAdapter.FillByLogType(dt, 0)
            tabName = "AS400"
        ElseIf TabControl1.SelectedIndex = 1 Then
            T_LOG_DATTableAdapter.FillByLogType(dt, 1)
            tabName = "PLC"
        ElseIf TabControl1.SelectedIndex = 2 Then
            T_LOG_DATTableAdapter.FillByLogType(dt, 2)
            tabName = "Operation"
        End If


        Dim myStream As IO.Stream
        Dim sw As IO.StringWriter = New IO.StringWriter



        myStream = SaveFileDialog.OpenFile()
        If (myStream IsNot Nothing) Then
            ' Code to write the stream goes here.
            myStream.Close()
        End If


        sw.WriteLine("indexNo,Date,Time,LineName,Message,PcName,LogType,LogLevel") ',OccDate,logDetail")
        Dim col As String
        For i As Integer = 0 To dt.Rows.Count - 1
            dt.Rows(i)("indexNo") = i + 1
            col = dt.Rows(i)("indexNo").ToString() & "," & dt.Rows(i)("Date").ToString() & "," & _
                    dt.Rows(i)("Time").ToString() & "," & dt.Rows(i)("LineName").ToString() & "," & _
                    dt.Rows(i)("Message").ToString().Replace(",", "|") & "," & dt.Rows(i)("PcName").ToString() & "," & _
                    tabName & ","

            If dt(i).LogLevel = 0 Then
                col += "Normal Log"
            ElseIf dt(i).LogLevel = 1 Then
                col += "Warning Log"
            Else
                col += "Error Log"
            End If

            'dt.Rows(i)("LogType").ToString() ' & "," & dt.Rows(i)("OccDate").ToString() & "," & _
            'dt.Rows(i)("logDetail").ToString().Replace(",", "|")

            sw.WriteLine(col)
        Next

        System.IO.File.WriteAllText(SaveFileDialog.FileName, sw.ToString())

    End Sub

    'Private Sub dataGridAs400Log_DataSourceChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dataGridAs400Log.DataSourceChanged
    '    setDatagridColor()
    'End Sub

    'Private Sub datagridPlcLog_DataSourceChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles datagridPlcLog.DataSourceChanged
    '    setDatagridColor()
    'End Sub

    'Private Sub datagridOperationLog_DataSourceChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles datagridOperationLog.DataSourceChanged
    '    setDatagridColor()
    'End Sub


    'Private Sub DataLog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
    '    setDatagridColor()
    'End Sub

    
End Class