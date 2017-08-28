Public Class ctrlPlcMessage
    Protected dr As Common.dsPAINT.dtPLC_MSTRow
    Private m_converter As New System.Text.UTF8Encoding
    Private m_bkw As System.ComponentModel.BackgroundWorker
    Private m_strEx As String

    Public Sub BackgroundStart()
        If Not m_bkw.IsBusy Then
            m_bkw.RunWorkerAsync()
        End If
    End Sub

    Public Sub BackgroundStop()
        m_bkw.CancelAsync()
    End Sub

    Private Sub OnRun()
        While Not m_bkw.CancellationPending
            Try
                m_bkw.ReportProgress(100)
                Me.WriteMessageToPlc()
            Catch ex As Exception
                m_strEx = ex.Message
                m_bkw.ReportProgress(0)
            End Try
            Threading.Thread.Sleep(500)
        End While
    End Sub

    Private Sub BackgroundWorker_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs)
        If e.ProgressPercentage = 100 Then
            'Me.'lblError.Text = ""
        Else
            'Me.'lblError.Text = m_strEx
            Console.WriteLine(m_strEx)
        End If

    End Sub

    Public Sub New(ByVal drPlc As Common.dsPAINT.dtPLC_MSTRow)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        dr = drPlc
        smcPlc.NetworkAddress = CShort(dr.PLC_NET)
        smcPlc.NodeAddress = CShort(dr.PLC_NODE)
        smcPlc.UnitAddress = CShort(dr.PLC_UNIT)
        smcPlc.Active() = True
        smcPlc.Update()
        'lblError.Text = ""
        lblProcess.Text = dr.ProcessName & " : Stage Code " & dr.STAGE_CODE
        m_bkw = New System.ComponentModel.BackgroundWorker
        m_bkw.WorkerReportsProgress = True
        m_bkw.WorkerSupportsCancellation = True

        txtSkitNo.Text = 2
        txtStatus.Text = 4
        txtLane.Text = 5
        txtMessage.Text = "TEST"
        AddHandler m_bkw.DoWork, AddressOf OnRun
        AddHandler m_bkw.ProgressChanged, AddressOf BackgroundWorker_ProgressChanged
    End Sub

    Public Sub WriteMessageToPlc()

        Dim intStatus As Integer
        Dim intLane As Integer
        Dim intSkit As Integer
        'lblError.Text = ""
        Try
            Try
                intStatus = CInt(Me.txtStatus.Text)
                If intStatus < 0 Then
                    Throw New Exception()
                End If
            Catch iex As Exception
                'lblError.Text = "Status must be not negative integer"
                Console.WriteLine(iex.Message)
                Return
            End Try

            Try
                intSkit = CInt(Me.txtSkitNo.Text)
                If intSkit < 0 Then
                    Throw New Exception()
                End If
            Catch iex As Exception
                'lblError.Text = "Skit must be not negative integer"
                Console.WriteLine(iex.Message)
                Return
            End Try

            If Me.txtLane.Text.Length = 0 Then
                intLane = 0
            Else
                Try
                    intLane = CInt(Me.txtLane.Text)
                    If intLane < 0 Then
                        Throw New Exception()
                    End If
                Catch iex As Exception
                    'lblError.Text = "Lane must be not negative integer"
                    Console.WriteLine(iex.Message)
                    Return
                End Try
            End If
            'SyncLock smcPlc.NetworkAddress & "." & smcPlc.NodeAddress & "." & smcPlc.UnitAddress
            Dim mt As Threading.Mutex
            mt = New Threading.Mutex(False, smcPlc.NetworkAddress & "." & smcPlc.NodeAddress & "." & smcPlc.UnitAddress)
            mt.WaitOne()
            smcPlc.WriteMemoryWordInteger(OMRON.Compolet.SYSMAC.SysmacCSBase.MemoryTypes.DM, CLng(dr.READ_DM), dr.STAGE_CODE, OMRON.Compolet.SYSMAC.SysmacPlc.DataTypes.BCD)
            smcPlc.WriteMemoryWordInteger(OMRON.Compolet.SYSMAC.SysmacCSBase.MemoryTypes.DM, CLng(dr.READ_DM + 1), intStatus, OMRON.Compolet.SYSMAC.SysmacPlc.DataTypes.BCD)
            smcPlc.WriteMemoryWordInteger(OMRON.Compolet.SYSMAC.SysmacCSBase.MemoryTypes.DM, CLng(dr.READ_DM + 2), intSkit, OMRON.Compolet.SYSMAC.SysmacPlc.DataTypes.BCD)
            smcPlc.WriteMemoryWordInteger(OMRON.Compolet.SYSMAC.SysmacCSBase.MemoryTypes.DM, CLng(dr.READ_DM + 3), intLane, OMRON.Compolet.SYSMAC.SysmacPlc.DataTypes.BCD)
            smcPlc.WriteMemoryString(OMRON.Compolet.SYSMAC.SysmacCSBase.MemoryTypes.DM, CLng(dr.READ_DM + 4), Me.txtMessage.Text)
            'End SyncLock
            Console.WriteLine(Now.ToString & ", " & dr.STAGE_CODE)
            mt.ReleaseMutex()
        Catch ex As Exception
            'lblError.Text = ex.Message
            Console.WriteLine(ex.Message)
            Return
        End Try
    End Sub

    Protected Sub ConcatByte(ByRef arrByte1() As Byte, ByVal arrByte2() As Byte)
        'Concat arrByte2 into arrByte1
        Dim tempByte1(arrByte1.Count + arrByte2.Count - 1) As Byte

        For index As Integer = 0 To arrByte1.Count - 1
            tempByte1(index) = arrByte1(index)
        Next

        For index As Integer = 0 To arrByte2.Count - 1
            tempByte1(index + arrByte1.Count) = arrByte2(index)
        Next

        arrByte1 = tempByte1
    End Sub

    Private Sub btnExecute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExecute.Click
        Me.WriteMessageToPlc()
        Dim plcWrap As New PLCWrapper

        plcWrap.ReadMemoryWordInteger(OMRON.Compolet.SYSMAC.SysmacCSBase.MemoryTypes.DM, 2300, 10, OMRON.Compolet.SYSMAC.SysmacPlc.DataTypes.BIN)
    End Sub

    Public Sub SetStatus(ByVal status As String)
        Me.txtStatus.Text = status
    End Sub

    Private Sub ctrlPlcMessage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class

Class PLCWrapper
    Inherits OMRON.Compolet.SYSMAC.SysmacCS

#Region "Attributes"
    Private m_Mutex As Threading.Mutex
    Private m_strMutexName As String
#End Region

#Region "Properties"

#End Region

#Region "Constructor"
    Public Sub New()
        MyBase.New()
    End Sub
#End Region

#Region "Method"
    Public Sub InitializeAndConnect(ByVal net As Integer, ByVal node As Integer, ByVal unit As Integer, Optional ByVal mutexName As String = "")
        Me.NetworkAddress = CShort(net)
        Me.NodeAddress = CShort(node)
        Me.UnitAddress = CShort(unit)
        Me.Active() = True
        Me.Update()

        m_strMutexName = IIf(mutexName = String.Empty, "OMRON.Compolet.SYSMAC.SysmacCS", mutexName)
        m_Mutex = New Threading.Mutex(False, m_strMutexName)
    End Sub
#End Region

    Public Shadows Function ReadMemoryWordInteger(ByVal memoryType As OMRON.Compolet.SYSMAC.SysmacCS.MemoryTypes, ByVal offset As Long, ByVal count As Long, ByVal dataType As OMRON.Compolet.SYSMAC.SysmacPlc.DataTypes) As Integer()
        Me.GetLock()
        ReadMemoryWordInteger = MyBase.ReadMemoryWordInteger(memoryType, offset, count, dataType)
        Me.ReleaseLock()
    End Function

    Private Sub GetLock()
        m_Mutex.WaitOne()
    End Sub

    Private Sub ReleaseLock()
        m_Mutex.ReleaseMutex()
    End Sub
End Class