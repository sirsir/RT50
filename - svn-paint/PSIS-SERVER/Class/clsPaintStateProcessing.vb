Public Class clsPaintStateProcessing
    Inherits clsStateBase

#Region "Constant"
    Private Const LENGTH_OF_WRITE_LANE_NO As Integer = 1
    Private Const LENGTH_OF_READ_LANE_NO As Integer = 1
#End Region

#Region "Attribute"
    Private m_clsPlcCommunication As clsPlcCommunication
    Private m_drProductionDat As dsPAINT.dtPRODUCTION_DATRow
    Private m_drSkitMst As dsPAINT.dtSKIT_MSTRow
    Private m_intSkitNo As Integer
    Private m_intLaneNo As Integer
    Private m_strOption As String
    Private m_converter As System.Text.UTF8Encoding
    Private m_clsLog As New clsLogger
    Private m_clsDbLog As New clsDBLogger
#End Region

#Region "Constructor"

    Public Sub New(ByVal stageCode As Integer, ByVal currentStateCode As Integer, ByVal processNo As Integer, ByVal processName As String, ByVal memoryType As Byte, ByVal net As Integer, _
                       ByVal node As Integer, ByVal unit As Integer, ByVal readDataAddress As Integer, ByVal writeDataAddress As Integer, _
                       ByVal writeDMStatusAddress As Integer, ByVal entranceFlag As Boolean, ByVal writeDataLength As Integer, _
                       ByRef plcCommunicationThread As clsPlcCommunication, Optional ByVal sleepTimeInSec As Integer = 1)
        MyBase.New(stageCode, currentStateCode, processNo, processName, memoryType, net, node, unit, readDataAddress, writeDataAddress, writeDMStatusAddress, entranceFlag, writeDataLength)
        Me.m_clsPlcCommunication = plcCommunicationThread
        Me.m_drProductionDat = Nothing
        Me.m_drSkitMst = Nothing
        Me.m_converter = New System.Text.UTF8Encoding
        Me.m_intSkitNo = -1
        Me.m_intLaneNo = -1
        Me.m_strOption = String.Empty
    End Sub

#End Region

#Region "Method"

    Public Overrides Sub Process()
        Dim intNextState As Integer
        m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "Process", "Start Function", "")
        If Not m_blnWorkDone Then
            m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "Process", "m_blnWorkDone = False", "")
            If Me.m_clsPlcCommunication.EntranceFlag Then
                If ReadSkitLaneFromPLC() Then
                    intNextState = Me.GetNextStateByCheckDataForPaintOn()
                    Select Case intNextState
                        Case PROCESS_STATUS_ID_PROCESSING
                            m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "Process", "Check Data OK", "")
                            SendOneAndInstructionToPLC()
                            'Me.m_blnWorkDone = True
                            Exit Select
                        Case PROCESS_STATUS_ID_NO_DATA
                            m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "Process", "No Data", "")
                            Dim initialParam As New ArrayList
                            initialParam.Add(0)     'SkidNo.
                            initialParam.Add(Me.m_intErrorPrefix)
                            Me.m_clsPlcCommunication.m_clsStateNoData.Initial(initialParam)
                            Me.m_clsPlcCommunication.SetState(Me.m_clsPlcCommunication.m_clsStateNoData)
                            Me.m_clsPlcCommunication.ForceToProcessCurrentState()
                            Exit Select
                        Case Else
                            m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "Process", "Check Data Error", "")
                            Dim initialParam As New ArrayList
                            initialParam.Add(0)     'SkidNo.
                            initialParam.Add(Me.m_intErrorPrefix)
                            Me.m_clsPlcCommunication.m_clsStateError.Initial(initialParam)
                            Me.m_clsPlcCommunication.SetState(Me.m_clsPlcCommunication.m_clsStateError)
                            Me.m_clsPlcCommunication.ForceToProcessCurrentState()
                            Exit Select
                    End Select
                Else
                    m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "Process", "Read Lane Error", "")
                    Dim initialParam As New ArrayList
                    initialParam.Add(0)     'SkidNo.
                    initialParam.Add(PLC_WRITE_STATUS_ERROR_PREFIX_ERROR)
                    Me.m_clsPlcCommunication.m_clsStateError.Initial(initialParam)
                    Me.m_clsPlcCommunication.SetState(Me.m_clsPlcCommunication.m_clsStateError)
                    Me.m_clsPlcCommunication.ForceToProcessCurrentState()
                End If
            Else
                intNextState = Me.GetNextStateByCheckData()
                Select Case intNextState
                    Case PROCESS_STATUS_ID_PROCESSING
                        m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "Process", "Check Data OK", "")
                        SendOneAndInstructionToPLC()
                        Me.m_blnWorkDone = True
                        Exit Select
                    Case PROCESS_STATUS_ID_NO_DATA
                        m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "Process", "No Data", "")
                        Dim initialParam As New ArrayList
                        initialParam.Add(0)     'SkidNo.
                        initialParam.Add(Me.m_intErrorPrefix)
                        Me.m_clsPlcCommunication.m_clsStateNoData.Initial(initialParam)
                        Me.m_clsPlcCommunication.SetState(Me.m_clsPlcCommunication.m_clsStateNoData)
                        Me.m_clsPlcCommunication.ForceToProcessCurrentState()
                        Exit Select
                    Case Else
                        m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "Process", "Check Data Error", "")
                        Dim initialParam As New ArrayList
                        initialParam.Add(0)     'SkidNo.
                        initialParam.Add(Me.m_intErrorPrefix)
                        Me.m_clsPlcCommunication.m_clsStateError.Initial(initialParam)
                        Me.m_clsPlcCommunication.SetState(Me.m_clsPlcCommunication.m_clsStateError)
                        Me.m_clsPlcCommunication.ForceToProcessCurrentState()
                        Exit Select
                End Select
            End If
        Else
            m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "Process", "m_blnWorkDone = True", "")
            Dim intReadPlcStatus = Me.ReadPlcStatus()
            If intReadPlcStatus = PLC_READ_STATUS_COMPLETE Then
                m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "Process", "Read PLC Status : Complete, Go to complete state", "")

                'Me.m_clsPlcCommunication.m_clsStateComplete.Initial(Me.m_drSkitMst)
                Dim initialParam As New ArrayList
                initialParam.Add(Me.m_drSkitMst)
                initialParam.Add(Me.m_drProductionDat)
                Me.m_clsPlcCommunication.m_clsStateComplete.Initial(initialParam)

                Me.m_clsPlcCommunication.SetState(Me.m_clsPlcCommunication.m_clsStateComplete)
                Me.m_clsPlcCommunication.ForceToProcessCurrentState()
            ElseIf intReadPlcStatus = PLC_READ_STATUS_SAME_STATUS Then
                'DO NOTHING
            ElseIf intReadPlcStatus = PLC_READ_STATUS_READ_FAILED Then
                'DO NOTHING
            ElseIf (intReadPlcStatus = PLC_READ_STATUS_OFF_INFO) Then
                m_clsDbLog.Log(DB_LOG_CODE_W_PLC_PNTI_USER_CANCEL, Me.m_intProcessNo, Me.m_intSkitNo)
                m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.WarningLog, Me.GetType.Name, "Process", "Read PLC Status : Off Info, Go to complete state", "")
                Me.m_clsPlcCommunication.m_clsStateComplete.Initial()
                Me.m_clsPlcCommunication.SetState(Me.m_clsPlcCommunication.m_clsStateComplete)
                Me.m_clsPlcCommunication.ForceToProcessCurrentState()
            ElseIf (intReadPlcStatus = PLC_READ_STATUS_ERROR) Then
                m_clsDbLog.Log(DB_LOG_CODE_E_PLC_PNTI_ERROR_REQ_STATUS, Me.m_intProcessNo)
                m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "Process", "Read PLC Status : Error, Go to complete state", "")
                Me.m_clsPlcCommunication.m_clsStateComplete.Initial()
                Me.m_clsPlcCommunication.SetState(Me.m_clsPlcCommunication.m_clsStateComplete)
                Me.m_clsPlcCommunication.ForceToProcessCurrentState()
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
        If inObj IsNot Nothing Then
            Me.m_intSkitNo = CInt(inObj)
        Else
            Me.m_intSkitNo = -1
        End If
        Me.m_strOption = String.Empty
        Me.m_drProductionDat = Nothing
        Me.m_drSkitMst = Nothing
        Me.m_intLaneNo = -1
    End Sub

    Private Sub SendOneAndInstructionToPLC()
        m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "Send1AndInstructionToPLC", "Start Function", "")

        Dim intSendDataLength As Integer = PLC_WRITE_PAINT_DATA_LENGTH
        Dim bytSendData((intSendDataLength * 2) - 1) As Byte

        'Add Stage code, Request status and skit no to byteSendData
        bytSendData = OMRON.FinsGateway.PLCDataConverter.SystemIntegerToPLC2ByteAsBCD(Me.StageCode)
        ConcatByte(bytSendData, OMRON.FinsGateway.PLCDataConverter.SystemIntegerToPLC2ByteAsBCD(PLC_WRITE_STATUS_INSTRUCTION))
        ConcatByte(bytSendData, OMRON.FinsGateway.PLCDataConverter.SystemIntegerToPLC2ByteAsBCD(Me.m_intSkitNo))
        If Me.m_intLaneNo > 0 Then
            ConcatByte(bytSendData, OMRON.FinsGateway.PLCDataConverter.SystemIntegerToPLC2ByteAsBCD(Me.m_intLaneNo))
        Else
            ConcatByte(bytSendData, OMRON.FinsGateway.PLCDataConverter.SystemIntegerToPLC2ByteAsBCD(0))
        End If

        'Add Production Data to byteSendData
        ConcatByte(bytSendData, Me.m_converter.GetBytes(Me.m_intSkitNo.ToString(PLC_WRITE_ASCII_SKIT_NO_FORMAT).PadRight(PLC_WRITE_ASCII_SKIT_NO_LENGTH)))
        ConcatByte(bytSendData, Me.m_converter.GetBytes(Me.m_drProductionDat.SEQ_NO.PadRight(PLC_WRITE_ASCII_SEQ_NO_LENGTH)))
        ConcatByte(bytSendData, Me.m_converter.GetBytes(Me.m_drProductionDat.MODEL_YEAR.PadRight(PLC_WRITE_ASCII_MODEL_YEAR_LENGTH)))
        ConcatByte(bytSendData, Me.m_converter.GetBytes(Me.m_drProductionDat.SUFFIX_CODE.PadRight(PLC_WRITE_ASCII_SUFFIX_CODE_LENGTH)))
        ConcatByte(bytSendData, Me.m_converter.GetBytes(Me.m_drProductionDat.LOT_NO.PadRight(PLC_WRITE_ASCII_LOT_NO_LENGTH)))
        ConcatByte(bytSendData, Me.m_converter.GetBytes(Me.m_drProductionDat.UNIT.PadRight(PLC_WRITE_ASCII_UNIT_LENGTH)))
        ConcatByte(bytSendData, Me.m_converter.GetBytes(Me.m_drProductionDat.BLOCK_MODEL.PadRight(PLC_WRITE_ASCII_BLOCK_LENGTH)))
        ConcatByte(bytSendData, Me.m_converter.GetBytes(Me.m_drProductionDat.BLOCK_SEQ.PadRight(PLC_WRITE_ASCII_BLOCK_SEQ_LENGTH)))
        ConcatByte(bytSendData, Me.m_converter.GetBytes(Me.m_drProductionDat.HANDLE_TYPE.PadRight(PLC_WRITE_ASCII_HANDLE_TYPE_LENGTH)))
        ConcatByte(bytSendData, Me.m_converter.GetBytes(Me.m_drProductionDat.BODY_COLOR_OPT.PadRight(PLC_WRITE_ASCII_BODY_COLOR_OPT_LENGTH)))

        'Add Paint Parameter to bytSendData
        ConcatByte(bytSendData, Me.m_converter.GetBytes(Me.m_strOption))

        'If Not WriteToPlc(intSendDataLength, bytSendData) Then
        '    Me.m_clsPlcCommunication.ReportProgress(0)
        'End If

        While Not WriteToPlc(intSendDataLength, bytSendData)
            Me.m_clsPlcCommunication.ReportProgress(0)
            Threading.Thread.Sleep(TimeSpan.FromSeconds(1))
        End While

        Me.m_blnWorkDone = True
        m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "Send1AndInstructionToPLC", "End Function", "")
    End Sub

    Private Function ReadSkitLaneFromPLC() As Boolean
        Dim blnResult As Boolean
        Dim intReadStatusSkitAndLaneLength As Integer = PLC_READ_STATUS_LENGTH _
                                        + PLC_READ_SKIT_NO_LENGTH _
                                        + LENGTH_OF_READ_LANE_NO

        Dim bytReadStatusSkitAndLane((intReadStatusSkitAndLaneLength * 2) - 1) As Byte

        m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "ReadSkitLaneFromPLC", "Start Function", "")
        Try
            blnResult = ReadFromPlc(intReadStatusSkitAndLaneLength, bytReadStatusSkitAndLane)
            If blnResult Then
                Me.m_intSkitNo = OMRON.FinsGateway.PLCDataConverter.PLC2ByteAsBCDToSystemInteger(bytReadStatusSkitAndLane, 4, 1)(0)
                Me.m_intLaneNo = OMRON.FinsGateway.PLCDataConverter.PLC2ByteAsBCDToSystemInteger(bytReadStatusSkitAndLane, 6, 1)(0)
            Else
                Me.m_clsPlcCommunication.ReportProgress(0)
            End If
        Catch ex As Exception
            blnResult = False
            m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "ReadSkitLaneFromPLC", "Exception", ex.Message.ToString)
        End Try

        m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "ReadSkitLaneFromPLC", "End Function", "")
        Return blnResult
    End Function

    Private Function GetNextStateByCheckData() As Integer
        Dim taT_Production_Dat As New dsPAINTTableAdapters.taPRODUCTION_DAT
        Dim taT_Paint_Cell As New dsPAINTTableAdapters.taPAINT_CELL
        Dim dtProd As New dsPAINT.dtPRODUCTION_DATDataTable

        Dim dtOptionMst As New dsPAINT.dtOPTION_MSTDataTable
        Dim taT_Option_Mst As New dsPAINTTableAdapters.taOPTION_MST

        m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "GetNextStateByCheckData", "Start Function", "")
        Try
            If m_intSkitNo > modIni.MaxSkitNo OrElse m_intSkitNo <= 0 Then
                m_clsDbLog.Log(DB_LOG_CODE_E_PLC_PNTI_SKIT_NO_EXCEEDS_MAX, Me.m_intProcessNo, Me.m_intSkitNo, modIni.MaxSkitNo)
                m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "GetNextStateByCheckData", "SKIT NO exceeds maximum SKIT NO", "")
                Me.m_intErrorPrefix = PLC_WRITE_STATUS_ERROR_PREFIX_SKID_EXCEEDS_MAX
                Return PROCESS_STATUS_ID_ERROR
            End If

            dtProd = taT_Production_Dat.GetDataBySkitNo(Me.m_intSkitNo)
            If dtProd.Count() <= 0 Then
                m_clsDbLog.Log(DB_LOG_CODE_E_PLC_PNTI_PROD_OF_SKIT_NOT_EXIST, Me.m_intProcessNo, Me.m_intSkitNo)
                m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "GetNextStateByCheckData", "Select production data by skit no : Not found", "")
                Me.m_intErrorPrefix = PLC_WRITE_STATUS_NO_DATA_PREFIX_DATA_NOT_FOUND
                Return PROCESS_STATUS_ID_NO_DATA
            End If

            If dtProd.Count() > 1 Then
                m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "GetNextStateByCheckData", "Select production data by skit no : Found more than 1", "")
                Me.m_intErrorPrefix = PLC_WRITE_STATUS_ERROR_PREFIX_ERROR
                Return PROCESS_STATUS_ID_ERROR
            End If

            Me.m_drProductionDat = dtProd(0)
            Me.m_drSkitMst = (New dsPAINT.dtSKIT_MSTDataTable).NewdtSKIT_MSTRow
            Me.m_drSkitMst.SKIT_NO = Me.m_intSkitNo
            Me.m_drSkitMst.MODEL_YEAR = Me.m_drProductionDat.MODEL_YEAR
            Me.m_drSkitMst.SUFFIX_CODE = Me.m_drProductionDat.SUFFIX_CODE
            Me.m_drSkitMst.LOT_NO = Me.m_drProductionDat.LOT_NO
            Me.m_drSkitMst.UNIT = Me.m_drProductionDat.UNIT

            'If taT_Paint_Cell.GetCountProcessResultDateByProcessTypeModelAndBlock(PROCESS_TYPE_WBS_ON _
            '                                                                      , True _
            '                                                                      , Me.m_drProductionDat.MODEL_YEAR _
            '                                                                      , Me.m_drProductionDat.SUFFIX_CODE _
            '                                                                      , Me.m_drProductionDat.LOT_NO _
            '                                                                      , Me.m_drProductionDat.UNIT _
            '                                                                      , Me.m_drProductionDat.BLOCK_MODEL _
            '                                                                      , Me.m_drProductionDat.BLOCK_SEQ) _
            '                                                                      <= 0 _
            'Then
            '    m_clsDbLog.Log(DB_LOG_CODE_E_PLC_PNTI_PROD_OF_SKIT_NO_WBS_RESULT, Me.m_intProcessNo, Me.m_drProductionDat.MODEL_YEAR _
            '                                                                                       , Me.m_drProductionDat.SUFFIX_CODE _
            '                                                                                       , Me.m_drProductionDat.LOT_NO _
            '                                                                                       , Me.m_drProductionDat.UNIT _
            '                                                                                       , Me.m_intSkitNo)
            '    m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "GetNextStateByCheckData", "No WBS Result Date", "")
            '    Return PROCESS_STATUS_ID_NO_DATA
            'End If

            If taT_Paint_Cell.GetCountProcessResultDateByProcessTypeModelAndBlock(PROCESS_TYPE_PBR _
                                                                                  , True _
                                                                                  , Me.m_drProductionDat.MODEL_YEAR _
                                                                                  , Me.m_drProductionDat.SUFFIX_CODE _
                                                                                  , Me.m_drProductionDat.LOT_NO _
                                                                                  , Me.m_drProductionDat.UNIT _
                                                                                  , Me.m_drProductionDat.BLOCK_MODEL _
                                                                                  , Me.m_drProductionDat.BLOCK_SEQ) _
                                                                                  > 0 _
            Then
                m_clsDbLog.Log(DB_LOG_CODE_E_PLC_PNTI_PROD_OF_SKIT_HAD_PBR_ON_RESULT, Me.m_intProcessNo, Me.m_drProductionDat.MODEL_YEAR _
                                                                                                       , Me.m_drProductionDat.SUFFIX_CODE _
                                                                                                       , Me.m_drProductionDat.LOT_NO _
                                                                                                       , Me.m_drProductionDat.UNIT _
                                                                                                       , Me.m_intSkitNo)
                m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "GetNextStateByCheckData", "Already PBR On", "")
                Me.m_intErrorPrefix = PLC_WRITE_STATUS_ERROR_PREFIX_SKID_ALREADY_PBR_ON
                Return PROCESS_STATUS_ID_ERROR
            End If

            'If taT_Paint_Cell.GetPreviousProcessResultCountByProcessNo(Me.m_drProductionDat.MODEL_YEAR _
            '                                                                                , Me.m_drProductionDat.SUFFIX_CODE _
            '                                                                                , Me.m_drProductionDat.LOT_NO _
            '                                                                                , Me.m_drProductionDat.UNIT _
            '                                                                                , Me.m_intProcessNo) _
            '                                                                                <= 0 _
            'Then
            '    m_clsDbLog.Log(DB_LOG_CODE_E_PLC_PNTI_PROD_OF_SKIT_NO_PREV_PROCESS_RESULT, Me.m_intProcessNo, Me.m_drProductionDat.MODEL_YEAR _
            '                                                                                                , Me.m_drProductionDat.SUFFIX_CODE _
            '                                                                                                , Me.m_drProductionDat.LOT_NO _
            '                                                                                                , Me.m_drProductionDat.UNIT _
            '                                                                                                , Me.m_intSkitNo)
            '    m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "GetNextStateByCheckData", "No Result Date of previous process", "")
            '    Me.m_intErrorPrefix = PLC_WRITE_STATUS_NO_DATA_PREFIX_DATA_NOT_FOUND
            '    Return PROCESS_STATUS_ID_NO_DATA
            'End If

            Dim dtPaintCellLastResultPrevious As dsPAINT.dtPAINT_CELLDataTable
            dtPaintCellLastResultPrevious = taT_Paint_Cell.GetDataByLastResultAndCheckWithPreviousProcess(Me.m_drProductionDat.MODEL_YEAR _
                                                                                            , Me.m_drProductionDat.SUFFIX_CODE _
                                                                                            , Me.m_drProductionDat.LOT_NO _
                                                                                            , Me.m_drProductionDat.UNIT _
                                                                                            , Me.m_intProcessNo)
            If dtPaintCellLastResultPrevious Is Nothing OrElse dtPaintCellLastResultPrevious.Count < 1 Then
                Dim dtResultAtCurrentProcess As dsPAINT.dtPAINT_CELLDataTable
                dtResultAtCurrentProcess = taT_Paint_Cell.GetDataByPK(Me.m_drProductionDat.MODEL_YEAR _
                                                                                            , Me.m_drProductionDat.SUFFIX_CODE _
                                                                                            , Me.m_drProductionDat.LOT_NO _
                                                                                            , Me.m_drProductionDat.UNIT _
                                                                                            , Me.m_intProcessNo)
                If dtResultAtCurrentProcess Is Nothing OrElse dtResultAtCurrentProcess.Count < 1 Then
                    Me.m_intErrorPrefix = PLC_WRITE_STATUS_NO_DATA_PREFIX_DATA_NOT_FOUND
                Else
                    Me.m_intErrorPrefix = PLC_WRITE_STATUS_NO_DATA_PREFIX_DATA_REPEAT
                End If
                'Me.m_intErrorPrefix = PLC_WRITE_STATUS_NO_DATA_PREFIX_DATA_NOT_FOUND
                m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "GetNextStateByCheckData", "No Result Date of previous process", "")
                Return PROCESS_STATUS_ID_NO_DATA
            End If

            If taT_Option_Mst.FillByOptionOfModelAndProcess(dtOptionMst, dtProd(0).MODEL_YEAR _
                                                                      , dtProd(0).SUFFIX_CODE _
                                                                      , Me.m_intProcessNo) <= 0 Then
                m_clsDbLog.Log(DB_LOG_CODE_E_PLC_PNTI_MODEL_OPT_NOT_EXIST, Me.m_intProcessNo, dtProd(0).MODEL_YEAR, dtProd(0).SUFFIX_CODE)
                m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "GetNextStateByCheckData", "Not found model option", "")
                Me.m_intErrorPrefix = PLC_WRITE_STATUS_NO_DATA_PREFIX_MODEL_OPTION_NOT_FOUND
                Return PROCESS_STATUS_ID_NO_DATA
            End If

            Me.m_strOption = Me.OptionDataFormatter(dtOptionMst)

        Catch ex As Exception
            m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "GetNextStateByCheckData", "Exception", ex.Message.ToString)
            Me.m_intErrorPrefix = PLC_WRITE_STATUS_ERROR_PREFIX_ERROR
            Return PROCESS_STATUS_ID_ERROR
        End Try

        m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "GetNextStateByCheckData", "End Function", "")
        Return PROCESS_STATUS_ID_PROCESSING
    End Function

    Private Function GetNextStateByCheckDataForPaintOn() As Integer
        Dim taSkitMst As New dsPAINTTableAdapters.taSKIT_MST
        Dim dtSkit As New dsPAINT.dtSKIT_MSTDataTable

        Dim taProdDat As New dsPAINTTableAdapters.taPRODUCTION_DAT
        Dim dtProd As New dsPAINT.dtPRODUCTION_DATDataTable

        Dim taWbsOn As New dsPAINTTableAdapters.taWBS_ON
        Dim dtWbsOn As New dsPAINT.dtWBS_ONDataTable

        Dim dtOptionMst As New dsPAINT.dtOPTION_MSTDataTable
        Dim taT_Option_Mst As New dsPAINTTableAdapters.taOPTION_MST
        Dim taT_Paint_Cell As New dsPAINTTableAdapters.taPAINT_CELL

        m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "GetNextStateByCheckDataForPaintOn", "Start Function", "")
        Try
            If m_intSkitNo > modIni.MaxSkitNo OrElse m_intSkitNo <= 0 Then
                m_clsDbLog.Log(DB_LOG_CODE_E_PLC_PNTI_SKIT_NO_EXCEEDS_MAX, Me.m_intProcessNo, Me.m_intSkitNo, modIni.MaxSkitNo)
                m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "GetNextStateByCheckData", "SKIT NO exceeds maximum SKIT NO", "")
                Me.m_intErrorPrefix = PLC_WRITE_STATUS_ERROR_PREFIX_SKID_EXCEEDS_MAX
                Return PROCESS_STATUS_ID_ERROR
            End If

            dtWbsOn = taWbsOn.GetDataByLaneNo(Me.m_intLaneNo)
            If dtWbsOn Is Nothing OrElse dtWbsOn.Count <= 0 Then
                m_clsDbLog.Log(DB_LOG_CODE_E_PLC_PNTI_NO_MODEL_ON_SELECTED_LANE, Me.m_intProcessNo, Me.m_intLaneNo)
                m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "GetNextStateByCheckDataForPaintOn", "No production data on lane no : " & Me.m_intLaneNo, "")
                Me.m_intErrorPrefix = PLC_WRITE_STATUS_NO_DATA_PREFIX_NO_DATA_ON_LANE
                Return PROCESS_STATUS_ID_NO_DATA
            End If

            With dtWbsOn(0)
                dtProd = taProdDat.GetDataByPk(.MODEL_YEAR, .SUFFIX_CODE, .LOT_NO, .UNIT)
            End With

            'If dtProd Is Nothing OrElse dtProd.Count <= 0 Then
            '    m_clsDbLog.Log(DB_LOG_CODE_E_PLC_PNTI_PROD_OF_SKIT_NOT_EXIST, Me.m_intProcessNo, Me.m_intSkitNo)
            '    m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "GetNextStateByCheckDataForPaintOn", "No production data of skit no : " & Me.m_intSkitNo, "")
            '    Me.m_intErrorPrefix = PLC_WRITE_STATUS_NO_DATA_PREFIX_DATA_NOT_FOUND
            '    Return PROCESS_STATUS_ID_NO_DATA
            'End If

            'If dtProd.Count > 1 Then
            '    m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "GetNextStateByCheckDataForPaintOn", "Found production data more than 1", "")
            '    Me.m_intErrorPrefix = PLC_WRITE_STATUS_ERROR_PREFIX_ERROR
            '    Return PROCESS_STATUS_ID_ERROR
            'End If

            Me.m_drProductionDat = dtProd(0)

            '-------Check Skit In Use--------
            dtSkit = taSkitMst.GetDataBySkitNo(Me.m_intSkitNo)
            If dtSkit.Count > 0 Then
                If dtSkit(0).IsMODEL_YEARNull _
                    AndAlso dtSkit(0).IsSUFFIX_CODENull _
                    AndAlso dtSkit(0).IsLOT_NONull _
                    AndAlso dtSkit(0).IsUNITNull _
                Then
                    m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "GetNextStateByCheckData", "Found skit no with other data is null", "")
                    Me.m_drSkitMst = dtSkit(0)
                    Me.m_drSkitMst.MODEL_YEAR = Me.m_drProductionDat.MODEL_YEAR
                    Me.m_drSkitMst.SUFFIX_CODE = Me.m_drProductionDat.SUFFIX_CODE
                    Me.m_drSkitMst.LOT_NO = Me.m_drProductionDat.LOT_NO
                    Me.m_drSkitMst.UNIT = Me.m_drProductionDat.UNIT
                Else
                    m_clsDbLog.Log(DB_LOG_CODE_E_PLC_FINI_SKIT_IN_USED, Me.m_intProcessNo, Me.m_intSkitNo)
                    m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "GetNextStateByCheckData", "Skit No is being used", "")
                    Me.m_intErrorPrefix = PLC_WRITE_STATUS_ERROR_PREFIX_SKID_IN_USE_BY_OTHER_MODEL
                    Return PROCESS_STATUS_ID_ERROR
                End If
            Else
                m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "GetNextStateByCheckData", "Not Found skit no in master", "")
                Me.m_drSkitMst = dtSkit.NewdtSKIT_MSTRow
                Me.m_drSkitMst.SKIT_NO = Me.m_intSkitNo
                Me.m_drSkitMst.MODEL_YEAR = Me.m_drProductionDat.MODEL_YEAR
                Me.m_drSkitMst.SUFFIX_CODE = Me.m_drProductionDat.SUFFIX_CODE
                Me.m_drSkitMst.LOT_NO = Me.m_drProductionDat.LOT_NO
                Me.m_drSkitMst.UNIT = Me.m_drProductionDat.UNIT
            End If
            '--------------------------------

            'If taSkitMstDat.GetCountFirstSeqOfEachLaneBySkitNoAndModel(Me.m_intSkitNo _
            '                                                           , Me.m_drProductionDat.MODEL_YEAR _
            '                                                           , Me.m_drProductionDat.SUFFIX_CODE _
            '                                                           , Me.m_drProductionDat.LOT_NO _
            '                                                           , Me.m_drProductionDat.UNIT) _
            '                                                           <= 0 _
            'Then
            '    m_clsDbLog.Log(DB_LOG_CODE_E_PLC_PNTI_SKIT_NOT_FIRST_SEQ, Me.m_intProcessNo, Me.m_intSkitNo)
            '    m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "GetNextStateByCheckDataForPaintOn", "Not Found data at first seq of each lane", "")
            '    Me.m_intErrorPrefix = PLC_WRITE_STATUS_NO_DATA_PREFIX_SKID_NOT_FIRST_OF_LANE
            '    Return PROCESS_STATUS_ID_NO_DATA
            'End If

            If taT_Paint_Cell.GetCountProcessResultDateByRangeOfProcessTypeModelAndBlock(dtProd(0).MODEL_YEAR _
                                                                                      , dtProd(0).SUFFIX_CODE _
                                                                                      , dtProd(0).LOT_NO _
                                                                                      , dtProd(0).UNIT _
                                                                                      , dtProd(0).BLOCK_MODEL _
                                                                                      , dtProd(0).BLOCK_SEQ _
                                                                                      , PROCESS_TYPE_PAINT _
                                                                                      , PROCESS_TYPE_PBR) _
                                                                                      > 0 _
            Then
                m_clsDbLog.Log(DB_LOG_CODE_E_PLC_PNTI_PROD_OF_SKIT_HAD_NEXT_PROC_RESULT, Me.m_intProcessNo, dtProd(0).MODEL_YEAR _
                                                                                                          , dtProd(0).SUFFIX_CODE _
                                                                                                          , dtProd(0).LOT_NO _
                                                                                                          , dtProd(0).UNIT _
                                                                                                          , Me.m_intSkitNo)
                m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "GetNextStateByCheckData", "There is Process result date already", "")
                Me.m_intErrorPrefix = PLC_WRITE_STATUS_ERROR_PREFIX_ERROR
                Return PROCESS_STATUS_ID_ERROR
            End If

            If taT_Option_Mst.FillByOptionOfModelAndProcess(dtOptionMst, dtProd(0).MODEL_YEAR _
                                                                      , dtProd(0).SUFFIX_CODE _
                                                                      , Me.m_intProcessNo) <= 0 Then
                m_clsDbLog.Log(DB_LOG_CODE_E_PLC_PNTI_MODEL_OPT_NOT_EXIST, Me.m_intProcessNo, dtProd(0).MODEL_YEAR, dtProd(0).SUFFIX_CODE)
                m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "GetNextStateByCheckData", "Not found model option", "")
                Me.m_intErrorPrefix = PLC_WRITE_STATUS_NO_DATA_PREFIX_MODEL_OPTION_NOT_FOUND
                Return PROCESS_STATUS_ID_NO_DATA
            End If

            Me.m_strOption = Me.OptionDataFormatter(dtOptionMst)

        Catch ex As Exception
            m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "GetNextStateByCheckDataForPaintOn", "Exception", ex.Message.ToString)
            Me.m_intErrorPrefix = PLC_WRITE_STATUS_ERROR_PREFIX_ERROR
            Return PROCESS_STATUS_ID_ERROR
        End Try

        m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "GetNextStateByCheckDataForPaintOn", "End Function", "")
        Return PROCESS_STATUS_ID_PROCESSING
    End Function

    Private Function OptionDataFormatter(ByVal dtOptionMst As dsPAINT.dtOPTION_MSTDataTable) As String
        Dim strOption As String = ""
        For Each dr As dsPAINT.dtOPTION_MSTRow In dtOptionMst
            strOption &= dr.OPTION_DISPLAY.PadRight(PLC_OPTION_DATA_LENGTH, PLC_OPTION_DATA_PADDER)
        Next

        If strOption.Length < PLC_OPTION_DATA_TOTAL_LENGTH Then
            strOption = strOption.PadRight(PLC_OPTION_DATA_TOTAL_LENGTH, PLC_OPTION_DATA_PADDER)
        ElseIf strOption.Length > PLC_OPTION_DATA_TOTAL_LENGTH Then
            strOption = strOption.Remove(PLC_OPTION_DATA_TOTAL_LENGTH)
        End If

        Return strOption
    End Function

    Private Function ReadPlcStatus() As Integer
        Dim blnResult As Boolean
        Dim intReadStatus As Integer
        Dim intReadStageCode As Integer
        Dim intSkitNo As Integer
        Dim bytReadMessage(((PLC_READ_STATUS_LENGTH + PLC_READ_SKIT_NO_LENGTH) * 2) - 1) As Byte

        m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "ReadPlcStatus", "Start Function", "")

        Try
            blnResult = ReadFromPlc(PLC_READ_STATUS_LENGTH + PLC_READ_SKIT_NO_LENGTH, bytReadMessage)
            If blnResult Then
                intReadStageCode = OMRON.FinsGateway.PLCDataConverter.PLC2ByteAsBCDToSystemInteger(bytReadMessage, 0, 1)(0)
                intReadStatus = OMRON.FinsGateway.PLCDataConverter.PLC2ByteAsBCDToSystemInteger(bytReadMessage, 2, 1)(0)
                intSkitNo = OMRON.FinsGateway.PLCDataConverter.PLC2ByteAsBCDToSystemInteger(bytReadMessage, 4, 1)(0)

                If intReadStageCode <> Me.m_intStageCode Then
                    Return PLC_READ_STATUS_INVALID_STAGE_CODE
                End If

                Me.m_intSkitNo = intSkitNo
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

#End Region

End Class
