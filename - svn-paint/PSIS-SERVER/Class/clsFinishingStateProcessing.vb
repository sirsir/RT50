Public Class clsFinishingStateProcessing
    Inherits clsStateBase

#Region "Attribute"
    Private m_clsPlcCommunication As clsPlcCommunication
    Private m_drSkitMst As dsPAINT.dtSKIT_MSTRow
    Private m_intSkitNo As Integer
    Private m_strModelYear As String
    Private m_strSuffixCode As String
    Private m_strLotNo As String
    Private m_strUnit As String
    Private m_strBlock As String
    Private m_strBlockSeq As String
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
        Me.m_drSkitMst = Nothing
        Me.m_converter = New System.Text.UTF8Encoding
        Me.m_intSkitNo = -1
        Me.m_strModelYear = String.Empty
        Me.m_strSuffixCode = String.Empty
        Me.m_strLotNo = String.Empty
        Me.m_strUnit = String.Empty
        Me.m_strBlock = String.Empty
        Me.m_strBlockSeq = String.Empty
    End Sub

#End Region

#Region "Method"

    Public Overrides Sub Process()
        Dim intNextState As Integer
        m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "Process", "Start Function", "")
        If Not m_blnWorkDone Then
            m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "Process", "m_blnWorkDone = False", "")
            If Me.ReadInstructionDataFromPLC() Then
                m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "Process", "Read Instruction OK", "")
                intNextState = Me.GetNextStateByCheckData()

                Select Case intNextState
                    Case PROCESS_STATUS_ID_PROCESSING
                        m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "Process", "Check Data OK", "")
                        ReplyOneToPLC()
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

            Else
                m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "Process", "Read Instruction Error", "")
                Dim initialParam As New ArrayList
                initialParam.Add(0)     'SkidNo.
                initialParam.Add(PLC_WRITE_STATUS_ERROR_PREFIX_ERROR)
                Me.m_clsPlcCommunication.m_clsStateError.Initial(initialParam)
                Me.m_clsPlcCommunication.SetState(Me.m_clsPlcCommunication.m_clsStateError)
                Me.m_clsPlcCommunication.ForceToProcessCurrentState()
            End If
        Else
            m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "Process", "m_blnWorkDone = True", "")
            Dim intReadPlcStatus = Me.ReadPlcStatus()
            If intReadPlcStatus = PLC_READ_STATUS_COMPLETE Then
                m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "Process", "Read PLC Status : Complete, Go to complete state", "")
                Me.m_clsPlcCommunication.m_clsStateComplete.Initial(Me.m_drSkitMst)
                Me.m_clsPlcCommunication.SetState(Me.m_clsPlcCommunication.m_clsStateComplete)
                Me.m_clsPlcCommunication.ForceToProcessCurrentState()
            ElseIf intReadPlcStatus = PLC_READ_STATUS_SAME_STATUS Then
                'DO NOTHING
            ElseIf intReadPlcStatus = PLC_READ_STATUS_READ_FAILED Then
                'DO NOTHING
            ElseIf intReadPlcStatus = PLC_READ_STATUS_OFF_INFO Then
                m_clsDbLog.Log(DB_LOG_CODE_W_PLC_FINI_USER_CANCEL, Me.m_intProcessNo, Me.m_strModelYear, Me.m_strSuffixCode, Me.m_strLotNo, Me.m_strUnit)
                m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.WarningLog, Me.GetType.Name, "Process", "Read PLC Status : Off Info , Go to complete state", "")
                Me.m_clsPlcCommunication.m_clsStateComplete.Initial()
                Me.m_clsPlcCommunication.SetState(Me.m_clsPlcCommunication.m_clsStateComplete)
                Me.m_clsPlcCommunication.ForceToProcessCurrentState()
            ElseIf (intReadPlcStatus = PLC_READ_STATUS_ERROR) Then
                m_clsDbLog.Log(DB_LOG_CODE_E_PLC_FINI_ERROR_REQ_STATUS, Me.m_intProcessNo)
                m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "Process", "Read PLC Status : Error, Go to complete state", "")
                Me.m_clsPlcCommunication.m_clsStateComplete.Initial()
                Me.m_clsPlcCommunication.SetState(Me.m_clsPlcCommunication.m_clsStateComplete)
                Me.m_clsPlcCommunication.ForceToProcessCurrentState()
            ElseIf intReadPlcStatus = PLC_READ_STATUS_INVALID_STAGE_CODE Then
                m_clsDbLog.Log(DB_LOG_CODE_E_PLC_FINI_INVALID_STAGE_CODE, Me.m_intProcessNo)
                m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "Process", "Read PLC Status : Invalid stage code, Go to error state", "")
                Dim initialParam As New ArrayList
                initialParam.Add(0)     'SkidNo.
                initialParam.Add(PLC_WRITE_STATUS_ERROR_PREFIX_STAGE_CODE_INVALID)
                Me.m_clsPlcCommunication.m_clsStateError.Initial(initialParam)
                Me.m_clsPlcCommunication.SetState(Me.m_clsPlcCommunication.m_clsStateError)
                Me.m_clsPlcCommunication.ForceToProcessCurrentState()
            Else
                m_clsDbLog.Log(DB_LOG_CODE_E_PLC_FINI_INVALID_REQ_STATUS, Me.m_intProcessNo)
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
        Me.m_drSkitMst = Nothing
        Me.m_strModelYear = String.Empty
        Me.m_strSuffixCode = String.Empty
        Me.m_strLotNo = String.Empty
        Me.m_strUnit = String.Empty
        Me.m_strBlock = String.Empty
        Me.m_strBlockSeq = String.Empty
    End Sub

    Private Sub ReplyOneToPLC()
        m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "ReplyOneToPLC", "Start Function", "")
        Dim bytSendData(((PLC_WRITE_STATUS_LENGTH + PLC_WRITE_SKIT_NO_LENGTH) * 2) - 1) As Byte

        bytSendData = OMRON.FinsGateway.PLCDataConverter.SystemIntegerToPLC2ByteAsBCD(Me.StageCode)
        ConcatByte(bytSendData, OMRON.FinsGateway.PLCDataConverter.SystemIntegerToPLC2ByteAsBCD(PLC_WRITE_STATUS_INSTRUCTION))
        ConcatByte(bytSendData, OMRON.FinsGateway.PLCDataConverter.SystemIntegerToPLC2ByteAsBCD(Me.m_intSkitNo))

        Dim strTemp As String = Me.m_strModelYear & Me.m_strSuffixCode & Me.m_strLotNo & Me.m_strUnit
        strTemp &= Me.m_strBlock & " " & Me.m_strBlockSeq
        Me.m_converter.GetBytes(strTemp)
        ConcatByte(bytSendData, Me.m_converter.GetBytes(strTemp))

        '13 is WORD length of MODELCODE,LOT,UNIT,BLOCKMODEL,BLOCKSEQ
        'If Not WriteToPlc(PLC_WRITE_STATUS_LENGTH + PLC_WRITE_SKIT_NO_LENGTH + 13, bytSendData) Then
        '    Me.m_clsPlcCommunication.ReportProgress(0)
        'End If

        While Not WriteToPlc(PLC_WRITE_STATUS_LENGTH + PLC_WRITE_SKIT_NO_LENGTH + 13, bytSendData)
            Me.m_clsPlcCommunication.ReportProgress(0)
            Threading.Thread.Sleep(TimeSpan.FromSeconds(1))
        End While

        m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "ReplyOneToPLC", "End Function", "")
    End Sub

    Private Sub SetBytesToStringAttributes(ByVal ReadData() As Byte)
        Dim bytTempArr As Byte()
        Dim strTempData As String

        If ReadData.Count > 0 Then
            bytTempArr = Me.GetSubBytes(ReadData, 0, LENGTH_OF_MODEL_YEAR + LENGTH_OF_SUFFIX_CODE)
            strTempData = Me.m_converter.GetString(bytTempArr)
            Me.m_strModelYear = strTempData.Substring(0, LENGTH_OF_MODEL_YEAR)
            Me.m_strSuffixCode = strTempData.Substring(LENGTH_OF_MODEL_YEAR, LENGTH_OF_SUFFIX_CODE)

            bytTempArr = Me.GetSubBytes(ReadData, LENGTH_OF_MODEL_YEAR + LENGTH_OF_SUFFIX_CODE, (LENGTH_OF_LOT_NO + LENGTH_OF_UNIT))
            strTempData = Me.m_converter.GetString(bytTempArr)
            Me.m_strLotNo = strTempData.Substring(0, LENGTH_OF_LOT_NO)
            Me.m_strUnit = strTempData.Substring(LENGTH_OF_LOT_NO, LENGTH_OF_UNIT)

            bytTempArr = Me.GetSubBytes(ReadData, (LENGTH_OF_MODEL_YEAR + LENGTH_OF_SUFFIX_CODE + LENGTH_OF_LOT_NO + LENGTH_OF_UNIT), LENGTH_OF_BLOCK)
            Me.m_strBlock = Me.m_converter.GetString(bytTempArr)

            bytTempArr = Me.GetSubBytes(ReadData, (LENGTH_OF_MODEL_YEAR + LENGTH_OF_SUFFIX_CODE + LENGTH_OF_LOT_NO + LENGTH_OF_UNIT + LENGTH_OF_BLOCK) + 1, LENGTH_OF_BLOCK_SEQ) '+1 is for space bar
            Me.m_strBlockSeq = Me.m_converter.GetString(bytTempArr)
        End If
    End Sub

    Private Function ReadInstructionDataFromPLC() As Boolean
        Dim blnResult As Boolean
        Dim intReadStatusAndSkitLength As UInteger = PLC_READ_STATUS_LENGTH + PLC_READ_SKIT_NO_LENGTH
        Dim intReadDataLength As UInteger = LENGTH_OF_MODEL_YEAR + LENGTH_OF_SUFFIX_CODE + LENGTH_OF_LOT_NO + LENGTH_OF_UNIT + LENGTH_OF_BLOCK + LENGTH_OF_BLOCK_SEQ
        Dim bytReadStatusAndSkit((intReadStatusAndSkitLength * 2) - 1) As Byte
        Dim bytReadData((intReadDataLength * 2) - 1) As Byte

        m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "ReadInstructionDataFromPLC", "Start Function", "")
        Try
            blnResult = ReadFromPlc(intReadStatusAndSkitLength, bytReadStatusAndSkit)
            If blnResult Then
                Me.m_intSkitNo = OMRON.FinsGateway.PLCDataConverter.PLC2ByteAsBCDToSystemInteger(bytReadStatusAndSkit, 4, 1)(0)

                'Read Data From PLC
                blnResult = ReadFromPlc(intReadDataLength, bytReadData, Me.m_clsPlcCommunication.ReadAddress + intReadStatusAndSkitLength)

                If blnResult Then
                    Me.SetBytesToStringAttributes(bytReadData)
                Else
                    Me.m_clsPlcCommunication.ReportProgress(0)
                End If
            Else
                Me.m_clsPlcCommunication.ReportProgress(0)
            End If

        Catch ex As Exception
            blnResult = False
            m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "ReadInstructionDataFromPLC", "Exception", ex.Message.ToString)
        End Try

        m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "ReadInstructionDataFromPLC", "End Function", "")
        Return blnResult
    End Function

    Private Function GetNextStateByCheckData() As Integer
        Dim taT_Production_Dat As New dsPAINTTableAdapters.taPRODUCTION_DAT
        Dim taT_Paint_Cell As New dsPAINTTableAdapters.taPAINT_CELL
        Dim taT_Skit_Mst As New dsPAINTTableAdapters.taSKIT_MST
        Dim dtProd As New dsPAINT.dtPRODUCTION_DATDataTable
        Dim dtSkitMst As New dsPAINT.dtSKIT_MSTDataTable

        m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "GetNextStateByCheckData", "Start Function", "")

        Try
            If m_intSkitNo > modIni.MaxSkitNo Then
                m_clsDbLog.Log(DB_LOG_CODE_E_PLC_FINI_SKIT_NO_EXCEEDS_MAX, Me.m_intProcessNo, m_intSkitNo, modIni.MaxSkitNo)
                m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "GetNextStateByCheckData", "SKIT NO exceeds maximum SKIT NO", "")
                Me.m_intErrorPrefix = PLC_WRITE_STATUS_ERROR_PREFIX_SKID_EXCEEDS_MAX
                Return PROCESS_STATUS_ID_ERROR
            End If

            dtProd = taT_Production_Dat.GetDataByPKAndBlock(Me.m_strModelYear _
                                                            , Me.m_strSuffixCode _
                                                            , Me.m_strLotNo _
                                                            , Me.m_strUnit _
                                                            , Me.m_strBlock _
                                                            , Me.m_strBlockSeq)
            If dtProd.Count <= 0 Then
                m_clsDbLog.Log(DB_LOG_CODE_E_PLC_FINI_NO_PROD_DATA_EXIST, Me.m_intProcessNo, Me.m_strModelYear, Me.m_strSuffixCode, Me.m_strLotNo, Me.m_strUnit)
                m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "GetNextStateByCheckData", "No Data", "")
                Me.m_intErrorPrefix = PLC_WRITE_STATUS_NO_DATA_PREFIX_DATA_NOT_FOUND
                Return PROCESS_STATUS_ID_NO_DATA
            End If

            If dtProd.Count > 1 Then
                m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "GetNextStateByCheckData", "Found more than 1 record", "")
                Me.m_intErrorPrefix = PLC_WRITE_STATUS_ERROR_PREFIX_ERROR
                Return PROCESS_STATUS_ID_ERROR
            End If

            dtSkitMst = taT_Skit_Mst.GetDataBySkitNo(Me.m_intSkitNo)
            If dtSkitMst.Count > 0 Then
                If dtSkitMst(0).IsMODEL_YEARNull _
                    AndAlso dtSkitMst(0).IsSUFFIX_CODENull _
                    AndAlso dtSkitMst(0).IsLOT_NONull _
                    AndAlso dtSkitMst(0).IsUNITNull _
                Then
                    m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "GetNextStateByCheckData", "Found skit no with other data is null", "")
                    Me.m_drSkitMst = dtSkitMst(0)
                    Me.m_drSkitMst.MODEL_YEAR = Me.m_strModelYear
                    Me.m_drSkitMst.SUFFIX_CODE = Me.m_strSuffixCode
                    Me.m_drSkitMst.LOT_NO = Me.m_strLotNo
                    Me.m_drSkitMst.UNIT = Me.m_strUnit
                Else
                    m_clsDbLog.Log(DB_LOG_CODE_E_PLC_FINI_SKIT_IN_USED, Me.m_intProcessNo, Me.m_intSkitNo)
                    m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "GetNextStateByCheckData", "Skit No is being used", "")
                    Me.m_intErrorPrefix = PLC_WRITE_STATUS_ERROR_PREFIX_SKID_IN_USE_BY_OTHER_MODEL
                    Return PROCESS_STATUS_ID_ERROR
                End If
            Else
                m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "GetNextStateByCheckData", "Not Found skit no in master", "")
                Me.m_drSkitMst = dtSkitMst.NewdtSKIT_MSTRow
                Me.m_drSkitMst.SKIT_NO = Me.m_intSkitNo
                Me.m_drSkitMst.MODEL_YEAR = Me.m_strModelYear
                Me.m_drSkitMst.SUFFIX_CODE = Me.m_strSuffixCode
                Me.m_drSkitMst.LOT_NO = Me.m_strLotNo
                Me.m_drSkitMst.UNIT = Me.m_strUnit
            End If

            If (taT_Paint_Cell.GetCountProcessResultDateByProcessTypeModelAndBlock(PROCESS_TYPE_FINISHING _
                                                                                   , False _
                                                                                   , Me.m_strModelYear _
                                                                                   , Me.m_strSuffixCode _
                                                                                   , Me.m_strLotNo _
                                                                                   , Me.m_strUnit _
                                                                                   , Me.m_strBlock _
                                                                                   , Me.m_strBlockSeq) _
                                                                                   > 0) _
            Then
                m_clsDbLog.Log(DB_LOG_CODE_E_PLC_FINI_HAD_FINI_RESULT_DATE, Me.m_intProcessNo, Me.m_strModelYear, Me.m_strSuffixCode, Me.m_strLotNo, Me.m_strUnit)
                m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "GetNextStateByCheckData", "Found data already has finishing result date", "")
                Me.m_intErrorPrefix = PLC_WRITE_STATUS_ERROR_PREFIX_MODEL_ALREADY_FINISHING_IN
                Return PROCESS_STATUS_ID_ERROR
            End If
        Catch ex As Exception
            m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "GetNextStateByCheckData", "Execption", ex.Message.ToString)
            Me.m_intErrorPrefix = PLC_WRITE_STATUS_ERROR_PREFIX_ERROR
            Return PROCESS_STATUS_ID_ERROR
        End Try

        m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "GetNextStateByCheckData", "End Function", "")
        Return PROCESS_STATUS_ID_PROCESSING
    End Function

    Private Function ReadPlcStatus() As Integer
        Dim blnResult As Boolean
        Dim intReadStatus As Integer
        Dim intReadStageCode As Integer
        Dim bytReadMessage((PLC_READ_STATUS_LENGTH * 2) - 1) As Byte

        m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "ReadPlcStatus", "Start Function", "")

        Try
            blnResult = ReadFromPlc(PLC_READ_STATUS_LENGTH, bytReadMessage)
            If blnResult Then
                intReadStageCode = OMRON.FinsGateway.PLCDataConverter.PLC2ByteAsBCDToSystemInteger(bytReadMessage, 0, 1)(0)
                intReadStatus = OMRON.FinsGateway.PLCDataConverter.PLC2ByteAsBCDToSystemInteger(bytReadMessage, 2, 1)(0)

                If intReadStageCode <> Me.m_intStageCode Then
                    Me.m_intErrorPrefix = PLC_WRITE_STATUS_ERROR_PREFIX_STAGE_CODE_INVALID
                    Return PLC_READ_STATUS_INVALID_STAGE_CODE
                End If
            Else
                Me.m_clsPlcCommunication.ReportProgress(0)
                Return PLC_READ_STATUS_READ_FAILED
            End If
        Catch ex As Exception
            m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "ReadPlcStatus", "Exception", ex.Message.ToString)
            Me.m_intErrorPrefix = PLC_WRITE_STATUS_ERROR
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
