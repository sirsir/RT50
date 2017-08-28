Public Class clsPlcCommunication
    Inherits System.ComponentModel.BackgroundWorker

#Region "Attribute"
    Private m_blnIsConnected As Boolean

    Private m_clsCurrentState As clsStateBase
    Public m_clsStateWaiting As clsStateBase
    Public m_clsStateProcessing As clsStateBase
    Public m_clsStateComplete As clsStateBase
    Public m_clsStateNoData As clsStateBase
    Public m_clsStateError As clsStateBase

    Private m_clsLog As New clsLogger
    Private m_intSleepTime As Integer
#End Region

#Region "Constructor"

    Public Sub New(ByVal drPlcMaster As dsPAINT.dtPLC_MSTRow, ByVal intSleepTimeInSec As Integer)

        Dim intStageCode As Integer = drPlcMaster.STAGE_CODE
        Dim intProcessNo As Integer = drPlcMaster.dtPROCESS_MSTRow.PROCESS_NO
        Dim strProcessName As String = drPlcMaster.dtPROCESS_MSTRow.PROCESS_NAME
        Dim bytMemType As Byte = ModConstant.PLC_MEMORY_TYPE
        Dim intNet As Integer = drPlcMaster.PLC_NET
        Dim intNode As Integer = drPlcMaster.PLC_NODE
        Dim intUnit As Integer = drPlcMaster.PLC_UNIT
        Dim intReadDataAddress As Integer = drPlcMaster.READ_DM
        Dim intWriteDataAddress As Integer = drPlcMaster.WRITE_DATA_DM
        Dim intWriteStatusAddress As Integer = drPlcMaster.WRITE_STATUS_DM
        Dim blnEntranceFlag As Boolean = drPlcMaster.dtPROCESS_MSTRow.ENTRANCE_FLAG
        Dim m_intSleepTime As Integer = intSleepTimeInSec

        m_blnIsConnected = False

        Select Case (drPlcMaster.dtPROCESS_MSTRow.PROCESS_TYPE)
            Case PROCESS_TYPE_FINISHING
                Me.m_clsStateWaiting = New clsFinishingStateWaiting(intStageCode, PROCESS_STATUS_ID_WAITING, intProcessNo, strProcessName, bytMemType, intNet, intNode _
                                                                    , intUnit, intReadDataAddress, intWriteDataAddress, _
                                                                    intWriteStatusAddress, blnEntranceFlag, PLC_WRITE_FINISHING_DATA_LENGTH, Me)
                Me.m_clsStateProcessing = New clsFinishingStateProcessing(intStageCode, PROCESS_STATUS_ID_PROCESSING, intProcessNo, strProcessName, bytMemType, intNet, intNode _
                                                                        , intUnit, intReadDataAddress, intWriteDataAddress, _
                                                                        intWriteStatusAddress, blnEntranceFlag, PLC_WRITE_FINISHING_DATA_LENGTH, Me)
                Me.m_clsStateComplete = New clsFinishingStateComplete(intStageCode, PROCESS_STATUS_ID_COMPLETE, intProcessNo, strProcessName, bytMemType, intNet, intNode _
                                                                    , intUnit, intReadDataAddress, intWriteDataAddress, _
                                                                    intWriteStatusAddress, blnEntranceFlag, PLC_WRITE_FINISHING_DATA_LENGTH, Me)

                Me.m_clsStateNoData = New clsStateNoData(intStageCode, PROCESS_STATUS_ID_NO_DATA, intProcessNo, strProcessName, bytMemType, intNet, intNode _
                                                        , intUnit, intReadDataAddress, intWriteDataAddress, _
                                                        intWriteStatusAddress, blnEntranceFlag, PLC_WRITE_FINISHING_DATA_LENGTH, Me)
                Me.m_clsStateError = New clsStateError(intStageCode, PROCESS_STATUS_ID_ERROR, intProcessNo, strProcessName, bytMemType, intNet, intNode _
                                                        , intUnit, intReadDataAddress, intWriteDataAddress, _
                                                        intWriteStatusAddress, blnEntranceFlag, PLC_WRITE_FINISHING_DATA_LENGTH, Me)

            Case PROCESS_TYPE_WBS_ON
                Me.m_clsStateWaiting = New clsWBSOnStateWaiting(intStageCode, PROCESS_STATUS_ID_WAITING, intProcessNo, strProcessName, bytMemType, intNet, intNode _
                                                                    , intUnit, intReadDataAddress, intWriteDataAddress, _
                                                                    intWriteStatusAddress, blnEntranceFlag, PLC_WRITE_WBS_DATA_LENGTH, Me)
                Me.m_clsStateProcessing = New clsWBSOnStateProcessing(intStageCode, PROCESS_STATUS_ID_PROCESSING, intProcessNo, strProcessName, bytMemType, intNet, intNode _
                                                                    , intUnit, intReadDataAddress, intWriteDataAddress, _
                                                                    intWriteStatusAddress, blnEntranceFlag, PLC_WRITE_WBS_DATA_LENGTH, Me)
                Me.m_clsStateComplete = New clsWBSOnStateComplete(intStageCode, PROCESS_STATUS_ID_COMPLETE, intProcessNo, strProcessName, bytMemType, intNet, intNode _
                                                                    , intUnit, intReadDataAddress, intWriteDataAddress, _
                                                                    intWriteStatusAddress, blnEntranceFlag, PLC_WRITE_WBS_DATA_LENGTH, Me)

                Me.m_clsStateNoData = New clsStateNoData(intStageCode, PROCESS_STATUS_ID_NO_DATA, intProcessNo, strProcessName, bytMemType, intNet, intNode _
                                                        , intUnit, intReadDataAddress, intWriteDataAddress, _
                                                        intWriteStatusAddress, blnEntranceFlag, PLC_WRITE_WBS_DATA_LENGTH, Me)
                Me.m_clsStateError = New clsStateError(intStageCode, PROCESS_STATUS_ID_ERROR, intProcessNo, strProcessName, bytMemType, intNet, intNode _
                                                        , intUnit, intReadDataAddress, intWriteDataAddress, _
                                                        intWriteStatusAddress, blnEntranceFlag, PLC_WRITE_WBS_DATA_LENGTH, Me)

            Case PROCESS_TYPE_PAINT
                Me.m_clsStateWaiting = New clsPaintStateWaiting(intStageCode, PROCESS_STATUS_ID_WAITING, intProcessNo, strProcessName, bytMemType, intNet, intNode _
                                                                    , intUnit, intReadDataAddress, intWriteDataAddress, _
                                                                    intWriteStatusAddress, blnEntranceFlag, PLC_WRITE_PAINT_DATA_LENGTH, Me)
                Me.m_clsStateProcessing = New clsPaintStateProcessing(intStageCode, PROCESS_STATUS_ID_PROCESSING, intProcessNo, strProcessName, bytMemType, intNet, intNode _
                                                                    , intUnit, intReadDataAddress, intWriteDataAddress, _
                                                                    intWriteStatusAddress, blnEntranceFlag, PLC_WRITE_PAINT_DATA_LENGTH, Me)
                Me.m_clsStateComplete = New clsPaintStateComplete(intStageCode, PROCESS_STATUS_ID_COMPLETE, intProcessNo, strProcessName, bytMemType, intNet, intNode _
                                                                    , intUnit, intReadDataAddress, intWriteDataAddress, _
                                                                    intWriteStatusAddress, blnEntranceFlag, PLC_WRITE_PAINT_DATA_LENGTH, Me)

                Me.m_clsStateNoData = New clsStateNoData(intStageCode, PROCESS_STATUS_ID_NO_DATA, intProcessNo, strProcessName, bytMemType, intNet, intNode _
                                                        , intUnit, intReadDataAddress, intWriteDataAddress, _
                                                        intWriteStatusAddress, blnEntranceFlag, PLC_WRITE_PAINT_DATA_LENGTH, Me)
                Me.m_clsStateError = New clsStateError(intStageCode, PROCESS_STATUS_ID_ERROR, intProcessNo, strProcessName, bytMemType, intNet, intNode _
                                                        , intUnit, intReadDataAddress, intWriteDataAddress, _
                                                        intWriteStatusAddress, blnEntranceFlag, PLC_WRITE_PAINT_DATA_LENGTH, Me)
            Case PROCESS_TYPE_PBR
                Me.m_clsStateWaiting = New clsPBRStateWaiting(intStageCode, PROCESS_STATUS_ID_WAITING, intProcessNo, strProcessName, bytMemType, intNet, intNode _
                                                                    , intUnit, intReadDataAddress, intWriteDataAddress, _
                                                                    intWriteStatusAddress, blnEntranceFlag, PLC_WRITE_PBR_DATA_LENGTH, Me)
                Me.m_clsStateProcessing = New clsPBRStateProcessing(intStageCode, PROCESS_STATUS_ID_PROCESSING, intProcessNo, strProcessName, bytMemType, intNet, intNode _
                                                                    , intUnit, intReadDataAddress, intWriteDataAddress, _
                                                                    intWriteStatusAddress, blnEntranceFlag, PLC_WRITE_PBR_DATA_LENGTH, Me)
                Me.m_clsStateComplete = New clsPBRStateComplete(intStageCode, PROCESS_STATUS_ID_COMPLETE, intProcessNo, strProcessName, bytMemType, intNet, intNode _
                                                                    , intUnit, intReadDataAddress, intWriteDataAddress, _
                                                                    intWriteStatusAddress, blnEntranceFlag, PLC_WRITE_PBR_DATA_LENGTH, Me)

                Me.m_clsStateNoData = New clsStateNoData(intStageCode, PROCESS_STATUS_ID_NO_DATA, intProcessNo, strProcessName, bytMemType, intNet, intNode _
                                                        , intUnit, intReadDataAddress, intWriteDataAddress, _
                                                        intWriteStatusAddress, blnEntranceFlag, PLC_WRITE_PBR_DATA_LENGTH, Me)
                Me.m_clsStateError = New clsStateError(intStageCode, PROCESS_STATUS_ID_ERROR, intProcessNo, strProcessName, bytMemType, intNet, intNode _
                                                        , intUnit, intReadDataAddress, intWriteDataAddress, _
                                                        intWriteStatusAddress, blnEntranceFlag, PLC_WRITE_PBR_DATA_LENGTH, Me)
            Case PROCESS_TYPE_WBS_PROGRESS

                Me.m_intSleepTime = drPlcMaster.dtPROCESS_MSTRow.PROCESS_TIME
                Me.m_clsStateWaiting = New clsWBSProgressStateProcessing(intStageCode, PROCESS_STATUS_ID_WAITING, intProcessNo, strProcessName, bytMemType, intNet, intNode _
                                                                    , intUnit, intReadDataAddress, intWriteDataAddress, _
                                                                    intWriteStatusAddress, blnEntranceFlag, PLC_WRITE_WBS_PROGRESS_DATA_LENGTH, Me)
        End Select

        Me.SetState(Me.m_clsStateWaiting)
    End Sub

#End Region

#Region "Property"

    Public ReadOnly Property StageCode() As Integer
        Get
            Return m_clsCurrentState.StageCode
        End Get
    End Property

    Public ReadOnly Property EntranceFlag() As Boolean
        Get
            Return m_clsCurrentState.EntranceFlag
        End Get
    End Property

    Public ReadOnly Property ProcessNo() As Integer
        Get
            Return m_clsCurrentState.ProcessNo
        End Get
    End Property

    Public ReadOnly Property IsConnected() As Boolean
        Get
            Return m_blnIsConnected
        End Get
    End Property

    Public ReadOnly Property ErrorMessage() As String
        Get
            Return m_clsCurrentState.GetErrorMessage
        End Get
    End Property

    Public ReadOnly Property ReadAddress() As UInteger
        Get
            Return m_clsCurrentState.ReadAddress
        End Get
    End Property

    Public ReadOnly Property WriteAddress() As UInteger
        Get
            Return m_clsCurrentState.WriteAddress
        End Get
    End Property

#End Region

#Region "Event"

    Private Sub clsPlcCommunication_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Me.DoWork
        Dim dat As New Date()
        While Not CancellationPending
            Try
                If m_clsCurrentState.IsPlcConnect() Then
                    m_blnIsConnected = True
                    'm_clsLog.LogByLine(Me.m_clsCurrentState.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "DoWork", "PLC Connect OK", "")

                    If m_clsCurrentState.SendKeepAlive() Then
                        'm_clsLog.LogByLine(Me.m_clsCurrentState.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "DoWork", "Send KPAL OK", "")
                        Me.ReportProgress(100)
                        m_clsCurrentState.Process()
                    Else
                        m_blnIsConnected = False
                        m_clsLog.LogByLine(Me.m_clsCurrentState.StageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "DoWork", "Send KPAL Failed", "")
                        Me.ReportProgress(0)
                    End If
                Else
                    m_blnIsConnected = False
                    m_clsLog.LogByLine(Me.m_clsCurrentState.StageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "DoWork", "PLC Connect Failed", "")
                    Me.ReportProgress(0)
                End If
            Catch ex As Exception
                Me.m_blnIsConnected = False
                Me.m_clsCurrentState.SetErrorMessage = "Process is terminated Because exception happen"
                Me.ReportProgress(0)
                m_clsLog.LogByLine(Me.m_clsCurrentState.StageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "DoWork", "Exception", ex.Message.ToString)
            End Try
            Threading.Thread.Sleep(System.TimeSpan.FromSeconds(m_intSleepTime))
        End While
    End Sub

#End Region

#Region "Method"

    Public Sub SetState(ByRef state As clsStateBase)
        If Me.m_clsCurrentState Is Nothing Then
            m_clsLog.LogByLine(state.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "SetState", "Change State To :" & state.GetType.Name, "")
            state.PreviousStateCode = -1
            state.PreviousPlcStatusCode = -1
            state.PreviousPlcStageCode = -1
        Else
            state.SetErrorMessage = Me.m_clsCurrentState.GetErrorMessage
            m_clsLog.LogByLine(Me.m_clsCurrentState.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "SetState", "Change State From :" & m_clsCurrentState.GetType.Name & " To " & state.GetType.Name, "")
            state.PreviousStateCode = Me.m_clsCurrentState.CurrentStateCode
            state.PreviousPlcStatusCode = Me.m_clsCurrentState.PreviousPlcStatusCode
            state.PreviousPlcStageCode = Me.m_clsCurrentState.PreviousPlcStageCode
        End If
        Me.m_clsCurrentState = state
        Me.m_clsCurrentState.WorkDone = False
    End Sub

    Public Sub ForceToProcessCurrentState()
        If Me.m_clsCurrentState IsNot Nothing Then
            m_clsLog.LogByLine(Me.m_clsCurrentState.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "ForceToProcessCurrentState", "Current Process is forced to start", "")
            m_clsCurrentState.Process()
        End If
    End Sub

#End Region

End Class
