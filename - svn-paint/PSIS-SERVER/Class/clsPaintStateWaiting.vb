Public Class clsPaintStateWaiting
    Inherits clsStateBase

#Region "Attribute"
    Private m_clsPlcCommunication As clsPlcCommunication
    Private m_intSkitNo As Integer
    Private m_clsLog As New clsLogger
    Private m_clsDbLog As New clsDBLogger
    Private m_converter As System.Text.UTF8Encoding
#End Region

#Region "Constructor"

    Public Sub New(ByVal stageCode As Integer, ByVal currentStateCode As Integer, ByVal processNo As Integer, ByVal processName As String, ByVal memoryType As Byte, ByVal net As Integer, _
                       ByVal node As Integer, ByVal unit As Integer, ByVal readDataAddress As Integer, ByVal writeDataAddress As Integer, _
                       ByVal writeDMStatusAddress As Integer, ByVal entranceFlag As Boolean, ByVal writeDataLength As Integer, _
                       ByRef plcCommunicationThread As clsPlcCommunication, Optional ByVal sleepTimeInSec As Integer = 1)
        MyBase.New(stageCode, currentStateCode, processNo, processName, memoryType, net, node, unit, readDataAddress, writeDataAddress, writeDMStatusAddress, entranceFlag, writeDataLength)
        Me.m_clsPlcCommunication = plcCommunicationThread
        Me.m_intSkitNo = -1
        Me.m_converter = New System.Text.UTF8Encoding
    End Sub

#End Region

#Region "Method"

    Public Overrides Sub Process()
        m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "Process", "Start Function", "")

        If Not Me.m_blnWorkDone Then
            Me.ReplyZeroToPLC()
        Else
            m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "Process", "m_blnWorkDone = True", "")
            Dim intReadPlcStatus = Me.ReadPlcStatus()
            If intReadPlcStatus = PLC_READ_STATUS_REQUEST Then
                m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "ReadPlcStatus", "Read Request status", "")
                Me.m_clsPlcCommunication.m_clsStateProcessing.Initial(Me.m_intSkitNo)
                Me.m_clsPlcCommunication.SetState(Me.m_clsPlcCommunication.m_clsStateProcessing)
                m_blnWorkDone = True
            ElseIf intReadPlcStatus = PLC_READ_STATUS_SAME_STATUS Then
                'DO NOTHING
            ElseIf intReadPlcStatus = PLC_READ_STATUS_WAITING Then
                'DO NOTHING
            ElseIf intReadPlcStatus = PLC_READ_STATUS_READ_FAILED Then
                'DO NOTHING
            ElseIf intReadPlcStatus = PLC_READ_STATUS_INVALID_STAGE_CODE Then
                m_clsDbLog.Log(DB_LOG_CODE_E_PLC_PNTI_INVALID_STAGE_CODE, Me.m_intProcessNo)
                m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "Process", "Read PLC Status : Invalid stage code, Go to error state", "")
                Dim initialParam As New ArrayList
                initialParam.Add(0)     'SkidNo.
                initialParam.Add(PLC_WRITE_STATUS_ERROR_PREFIX_STAGE_CODE_INVALID)
                Me.m_clsPlcCommunication.m_clsStateError.Initial(initialParam)
                Me.m_clsPlcCommunication.SetState(Me.m_clsPlcCommunication.m_clsStateError)
                Me.m_clsPlcCommunication.ForceToProcessCurrentState()
            Else
                m_clsDbLog.Log(DB_LOG_CODE_E_PLC_PNTI_INVALID_REQ_STATUS, Me.m_intProcessNo)
                m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "Process", "Read PLC Status : Other, Go to error state", "")
                Dim initialParam As New ArrayList
                initialParam.Add(0)     'SkidNo.
                initialParam.Add(PLC_WRITE_STATUS_ERROR_PREFIX_STATUS_CODE_INVALID)
                Me.m_clsPlcCommunication.m_clsStateError.Initial(initialParam)
                Me.m_clsPlcCommunication.SetState(Me.m_clsPlcCommunication.m_clsStateError)
                Me.m_clsPlcCommunication.ForceToProcessCurrentState()
            End If
        End If

        m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "Process", "End Function", "")
    End Sub

    Public Overrides Sub Initial(Optional ByVal inObj As Object = Nothing)
        Me.m_intSkitNo = -1
    End Sub

    Private Function ReadPlcStatus() As Integer
        Dim blnResult As Boolean
        Dim intReadStatus As Integer
        Dim intReadStageCode As Integer
        Dim intReadSkitNo As Integer
        Dim bytReadMessage((PLC_READ_STATUS_LENGTH + PLC_READ_SKIT_NO_LENGTH) * 2 - 1) As Byte

        m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "ReadPlcStatus", "Start Function", "")

        Try
            blnResult = ReadFromPlc(PLC_READ_STATUS_LENGTH + PLC_READ_SKIT_NO_LENGTH, bytReadMessage)
            If blnResult Then
                intReadStageCode = OMRON.FinsGateway.PLCDataConverter.PLC2ByteAsBCDToSystemInteger(bytReadMessage, 0, 1)(0)
                intReadStatus = OMRON.FinsGateway.PLCDataConverter.PLC2ByteAsBCDToSystemInteger(bytReadMessage, 2, 1)(0)
                intReadSkitNo = OMRON.FinsGateway.PLCDataConverter.PLC2ByteAsBCDToSystemInteger(bytReadMessage, 4, 1)(0)

                If intReadStageCode <> Me.m_intStageCode Then
                    Return PLC_READ_STATUS_INVALID_STAGE_CODE
                End If

                Me.m_intSkitNo = intReadSkitNo
            Else
                Me.m_clsPlcCommunication.ReportProgress(0)
                Return PLC_READ_STATUS_READ_FAILED
            End If
        Catch ex As Exception
            m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "ReadPlcStatus", "Exception", ex.Message.ToString)
            Return PROCESS_STATUS_ID_ERROR
        End Try

        If Not IsNewPlcMessage(intReadStatus, intReadStageCode) Then
            Return PLC_READ_STATUS_SAME_STATUS
        End If

        m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "ReadPlcStatus", "End Function", "")
        Return intReadStatus
    End Function

    Private Sub ReplyZeroToPLC()
        m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "ReplyZeroToPLC", "Start Function", "")

        Dim bytSendData((PLC_WRITE_STATUS_LENGTH * 2) - 1) As Byte
        Dim bytClearData(((Me.m_intWriteDataLength - PLC_WRITE_STATUS_LENGTH) * 2) - 1) As Byte
        'Dim blnResult As Boolean

        bytSendData = OMRON.FinsGateway.PLCDataConverter.SystemIntegerToPLC2ByteAsBCD(Me.StageCode)
        ConcatByte(bytSendData, OMRON.FinsGateway.PLCDataConverter.SystemIntegerToPLC2ByteAsBCD(PLC_WRITE_STATUS_WAITING))
        'ConcatByte(bytSendData, bytClearData)
        ConcatByte(bytSendData, OMRON.FinsGateway.PLCDataConverter.SystemIntegerToPLC2ByteAsBCD(0))
        ConcatByte(bytSendData, OMRON.FinsGateway.PLCDataConverter.SystemIntegerToPLC2ByteAsBCD(0))
        ConcatByte(bytSendData, Me.m_converter.GetBytes(" ".PadRight((Me.m_intWriteDataLength _
                        - PLC_WRITE_STATUS_LENGTH - PLC_WRITE_SKIT_NO_LENGTH - PLC_WRITE_LANE_NO_LENGTH) * 2)))

        While Not WriteToPlc(Me.m_intWriteDataLength, bytSendData)
            Me.m_clsPlcCommunication.ReportProgress(0)
            Threading.Thread.Sleep(TimeSpan.FromSeconds(1))
        End While

        Me.m_blnWorkDone = True

        'blnResult = WriteToPlc(Me.m_intWriteDataLength, bytSendData)
        'If blnResult Then
        '    Me.m_blnWorkDone = True
        'Else
        '    Me.m_clsPlcCommunication.ReportProgress(0)
        'End If

        m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "ReplyZeroToPLC", "End Function", "")
    End Sub

#End Region

End Class
