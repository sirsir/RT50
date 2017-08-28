Public MustInherit Class clsStateBase

#Region "Constant"
    Private BYTE_LENGTH_STATE As Integer = 4
    Private BYTE_LENGTH_REQ_STATUS As Integer = 4
    Private BYTE_LENGTH_SKIT As Integer = 4
    Private BYTE_LENGTH_LANE As Integer = 4
#End Region

#Region "Attribute"
    Private m_intProcessType As Integer
    Private Shared m_dictLatestSendLogMsg As Dictionary(Of Integer, String)
    Private Shared m_dictLatestRecvLogMsg As Dictionary(Of Integer, String)
    
    Protected m_intStageCode As Integer
    Protected m_intPreviousStateCode As Integer
    Protected m_intCurrentStateCode As Integer
    Protected m_intPreviousPlcStatusCode As Integer
    Protected m_intPreviousPlcStageCode As Integer
    Protected m_intProcessNo As Integer
    Protected m_intReadDataAddress As UInteger
    Protected m_intWriteDataAddress As UInteger
    Protected m_intWriteDMStatusAddress As UInteger
    Protected m_intSleepTimeInSec As Integer
    Protected m_strProcessName As String
    Protected m_strErrorMessage As String
    Protected m_intWriteDataLength As Integer
    Protected m_intErrorPrefix As Integer

    Protected m_bytMemoryType As Byte
    Protected m_bytNet(1) As Byte
    Protected m_bytNode(1) As Byte
    Protected m_bytUnit(1) As Byte

    Protected m_uintErrorType(0) As UInteger
    Protected m_uintErrorCode(0) As UInteger

    Protected m_bytReadData() As Byte

    Protected m_blnEntranceFlag As Boolean
    Protected m_blnWorkDone As Boolean

    Protected m_clsLogger As clsLogger
    Protected m_iniFile As New clsIniFile
#End Region

#Region "Constructor"

    Public Sub New(ByVal stageCode As Integer, ByVal currentStateCode As Integer, ByVal processNo As Integer, ByVal processName As String, ByVal memoryType As Byte, ByVal net As Integer, _
                       ByVal node As Integer, ByVal unit As Integer, ByVal readDataAddress As Integer, ByVal writeDataAddress As Integer, _
                       ByVal writeDMStatusAddress As Integer, ByVal entranceFlag As Boolean, ByVal writeDataLength As Integer, Optional ByVal sleepTimeInSec As Integer = 1)
        Dim intNet(0) As Integer
        Dim intNode(0) As Integer
        Dim intUnit(0) As Integer
        Dim taProcessMst As New dsPAINTTableAdapters.taPROCESS_MST

        Me.m_intStageCode = stageCode
        Me.m_intCurrentStateCode = currentStateCode
        Me.m_intPreviousStateCode = -1
        Me.m_intPreviousPlcStatusCode = -1
        Me.m_intPreviousPlcStageCode = -1
        Me.m_intProcessNo = processNo
        Me.m_intProcessType = taProcessMst.GetProcessTypeByProcessNo(Me.m_intProcessNo)
        Me.m_strProcessName = processName
        Me.m_bytMemoryType = memoryType
        Me.m_intReadDataAddress = readDataAddress
        Me.m_intWriteDataAddress = writeDataAddress
        Me.m_intWriteDMStatusAddress = writeDMStatusAddress
        Me.m_intSleepTimeInSec = sleepTimeInSec
        Me.m_blnEntranceFlag = entranceFlag
        Me.m_blnWorkDone = False
        Me.m_intWriteDataLength = writeDataLength
        Me.m_intErrorPrefix = 0

        If IsNothing(m_dictLatestSendLogMsg) Then
            m_dictLatestSendLogMsg = New Dictionary(Of Integer, String)
        End If

        If Not m_dictLatestSendLogMsg.ContainsKey(Me.m_intStageCode) Then
            m_dictLatestSendLogMsg.Add(Me.m_intStageCode, String.Empty)
        End If

        If IsNothing(m_dictLatestRecvLogMsg) Then
            m_dictLatestRecvLogMsg = New Dictionary(Of Integer, String)
        End If

        If Not m_dictLatestRecvLogMsg.ContainsKey(Me.m_intStageCode) Then
            m_dictLatestRecvLogMsg.Add(Me.m_intStageCode, String.Empty)
        End If
        
        intNet(0) = net
        intNode(0) = node
        intUnit(0) = unit

        OMRON.FinsGateway.PLCDataConverter.SystemIntegerToPLC2ByteAsBIN(intNet, Me.m_bytNet, 0)
        OMRON.FinsGateway.PLCDataConverter.SystemIntegerToPLC2ByteAsBIN(intNode, Me.m_bytNode, 0)
        OMRON.FinsGateway.PLCDataConverter.SystemIntegerToPLC2ByteAsBIN(intUnit, Me.m_bytUnit, 0)

        Me.m_clsLogger = New Common.clsLogger

    End Sub

#End Region

#Region "Property"

    Public ReadOnly Property StageCode() As Integer
        Get
            Return m_intStageCode
        End Get
    End Property

    Public ReadOnly Property EntranceFlag() As Boolean
        Get
            Return m_blnEntranceFlag
        End Get
    End Property

    Public ReadOnly Property ProcessNo() As Integer
        Get
            Return m_intProcessNo
        End Get
    End Property

    Public ReadOnly Property GetErrorType()
        Get
            Return Me.m_uintErrorType
        End Get
    End Property

    Public ReadOnly Property GetErrorCode()
        Get
            Return Me.m_uintErrorCode
        End Get
    End Property

    Public ReadOnly Property GetErrorMessage() As String
        Get
            Return m_strErrorMessage
        End Get
    End Property

    Public WriteOnly Property SetErrorMessage()
        Set(ByVal value)
            m_strErrorMessage = value
        End Set
    End Property

    Public ReadOnly Property GetReadData()
        Get
            Return Me.m_bytReadData
        End Get
    End Property

    Public ReadOnly Property ReadAddress() As UInteger
        Get
            Return m_intReadDataAddress
        End Get
    End Property

    Public ReadOnly Property WriteAddress() As UInteger
        Get
            Return m_intWriteDataAddress
        End Get
    End Property

    Public Property WorkDone() As Boolean
        Get
            Return m_blnWorkDone
        End Get
        Set(ByVal value As Boolean)
            m_blnWorkDone = value
        End Set
    End Property

    Public ReadOnly Property CurrentStateCode() As Integer
        Get
            Return m_intCurrentStateCode
        End Get
    End Property

    Public Property PreviousStateCode() As Integer
        Get
            Return m_intPreviousStateCode
        End Get
        Set(ByVal value As Integer)
            m_intPreviousStateCode = value
        End Set
    End Property

    Public Property PreviousPlcStatusCode() As Integer
        Get
            Return m_intPreviousPlcStatusCode
        End Get
        Set(ByVal value As Integer)
            m_intPreviousPlcStatusCode = value
        End Set
    End Property

    Public Property PreviousPlcStageCode() As Integer
        Get
            Return m_intPreviousPlcStageCode
        End Get
        Set(ByVal value As Integer)
            m_intPreviousPlcStageCode = value
        End Set
    End Property

#End Region

#Region "Method"

    Public MustOverride Sub Process()

    Public MustOverride Sub Initial(Optional ByVal inObj As Object = Nothing)

    Public Function IsPlcConnect() As Boolean
        Dim length As UShort = 2

        Dim bTestConnectionOk As Boolean
        Dim blnIsConnected As Boolean
        Dim readMessage(1) As Byte

        Try
            'Read for test plc connection
            bTestConnectionOk = ReadFromPlc(length, readMessage)

            If bTestConnectionOk Then
                blnIsConnected = True
                m_strErrorMessage = "PLC With Stage No : " & m_intStageCode & " Connected"
            Else
                blnIsConnected = False
                m_strErrorMessage = OMRON.FinsGateway.Messaging.FINS.MemoryAreaWriteResponse.GetResponseMessage(m_uintErrorCode(0))

                If m_strErrorMessage = "" Then
                    m_strErrorMessage = "Connection time out"
                End If
            End If

        Catch ex As Exception
            blnIsConnected = False
            m_strErrorMessage = ex.Message
        End Try

        Return blnIsConnected

    End Function

    Public Function SendKeepAlive() As Boolean
        Dim blnWriteOk As Boolean
        Dim strFunctionName As String = "SendKeepAlive"
        Dim length As UShort = 1
        Dim inttestData(0) As Integer
        Dim byttestData(1) As Byte

        inttestData(0) = 1
        OMRON.FinsGateway.PLCDataConverter.SystemIntegerToPLC2ByteAsBCD(inttestData, byttestData, 0)
        blnWriteOk = WriteToPlc(length, byttestData, Me.m_intWriteDMStatusAddress)

        Return blnWriteOk
    End Function

    Protected Function WriteToPlc(ByVal writeWordLength As UShort, ByVal writeMessage As Byte(), _
                                  Optional ByVal writeAddress As UInteger = 0, _
                                  Optional ByVal splitWriteWordLength As Integer = -1) As Boolean
        Dim blnWriteProdOk As Boolean
        Dim strFunctionName As String = "WriteToPlc"
        Dim strSendData As String

        If writeAddress = 0 Then
            writeAddress = Me.m_intWriteDataAddress
        End If

        If splitWriteWordLength < 0 Then
            blnWriteProdOk = HMI_LIB.FinsGW.uWrite_MEM_Data_WithErrcode(m_intStageCode, m_bytMemoryType, m_bytNet(1), m_bytNode(1), _
                                                              m_bytUnit(1), writeAddress, writeWordLength, _
                                                              writeMessage, m_uintErrorType, m_uintErrorCode)
            If Not blnWriteProdOk Then
                Me.m_clsLogger.LogByLine(m_intStageCode, Common.clsLogger.MessageType.ErrorLog, Me.GetType.Name, strFunctionName, _
                                     Me.GetFailMessage(), "")
                m_strErrorMessage = OMRON.FinsGateway.Messaging.FINS.MemoryAreaWriteResponse.GetResponseMessage(m_uintErrorCode(0))

                Me.m_clsLogger.LogByLine(m_intStageCode, Common.clsLogger.MessageType.ErrorLog, Me.GetType.Name, strFunctionName, _
                                         m_strErrorMessage, "")
                Return False
            End If
        Else

            Dim intCurrentDmPosition As Integer = 0
            Dim intLength As Integer = 0
            Dim intCurrentBytePosition As Integer = 0
            While intCurrentDmPosition < writeWordLength - 1
                If writeWordLength - intCurrentDmPosition > splitWriteWordLength Then
                    intLength = splitWriteWordLength
                Else
                    intLength = writeWordLength - intCurrentDmPosition
                End If
                blnWriteProdOk = HMI_LIB.FinsGW.uWrite_MEM_Data_WithErrcode(m_intStageCode, m_bytMemoryType, m_bytNet(1), m_bytNode(1), _
                                                              m_bytUnit(1), writeAddress + intCurrentDmPosition, intLength, _
                                                              GetSubBytes(writeMessage, intCurrentBytePosition, intLength * 2), _
                                                              m_uintErrorType, m_uintErrorCode)
                If Not blnWriteProdOk Then
                    Me.m_clsLogger.LogByLine(m_intStageCode, Common.clsLogger.MessageType.ErrorLog, Me.GetType.Name, strFunctionName, _
                                         Me.GetFailMessage(), "")
                    m_strErrorMessage = OMRON.FinsGateway.Messaging.FINS.MemoryAreaWriteResponse.GetResponseMessage(m_uintErrorCode(0))

                    If m_strErrorMessage = "" Then
                        m_strErrorMessage = "Connection time out"
                    End If

                    Me.m_clsLogger.LogByLine(m_intStageCode, Common.clsLogger.MessageType.ErrorLog, Me.GetType.Name, strFunctionName, _
                                             m_strErrorMessage, "")
                    Return False
                End If
                intCurrentDmPosition += intLength
                intCurrentBytePosition += intLength * 2
            End While

        End If

        'Me.m_clsLogger.LogByLine(m_intStageCode, Common.clsLogger.MessageType.NormalLog, Me.GetType.Name, strFunctionName, _
        '                         Me.GetSuccessMessage(), "")

        strSendData = GenLogMessageFromSendByteByProcessType(Me.m_intProcessType, writeMessage)
        If strSendData <> String.Empty Then
            m_clsLogger.LogByLine(Me.m_intStageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, strFunctionName, _
                                  strSendData, "")
        End If

        Return True

    End Function

    Protected Function ReadFromPlc(ByVal readWordLength As UShort, ByRef readMessage As Byte(), Optional ByVal readAddress As UInteger = 0) As Boolean
        Dim blnReadProdOk As Boolean
        Dim strFunctionName As String = "ReadFromPlc"
        Dim strRecvData As String

        ReDim Me.m_bytReadData(2 * readWordLength - 1)  'Byte length = word length * 2

        If readAddress = 0 Then
            readAddress = Me.m_intReadDataAddress
        End If
        blnReadProdOk = HMI_LIB.FinsGW.uRead_MEM_Data_WithErrcode(m_intStageCode, m_bytMemoryType, m_bytNet(1), m_bytNode(1), _
                                                          m_bytUnit(1), readAddress, readWordLength, _
                                                          readMessage, m_uintErrorType, m_uintErrorCode)
        If blnReadProdOk Then
            'Me.m_clsLogger.LogByLine(m_intStageCode, Common.clsLogger.MessageType.NormalLog, Me.GetType.Name, strFunctionName, _
            '                         Me.GetSuccessMessage(), "")
            strRecvData = GenLogMessageFromRecvByteByProcessType(Me.m_intProcessType, readMessage)
            If strRecvData <> String.Empty Then
                m_clsLogger.LogByLine(Me.m_intStageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, strFunctionName, _
                                      strRecvData, "")
            End If
            Return True
        Else
            Me.m_clsLogger.LogByLine(m_intStageCode, Common.clsLogger.MessageType.ErrorLog, Me.GetType.Name, strFunctionName, _
                                     Me.GetFailMessage(), "")
            m_strErrorMessage = OMRON.FinsGateway.Messaging.FINS.MemoryAreaWriteResponse.GetResponseMessage(m_uintErrorCode(0))
            
            If m_strErrorMessage = "" Then
                m_strErrorMessage = "Connection time out"
            End If
            Me.m_clsLogger.LogByLine(m_intStageCode, Common.clsLogger.MessageType.ErrorLog, Me.GetType.Name, strFunctionName, _
                                     m_strErrorMessage, "")
            Return False
        End If

        Return True
    End Function

    Protected Function GetSubBytes(ByVal arrBytes As Byte(), ByVal startIndex As UInteger, ByVal length As UInteger) As Byte()
        If startIndex + length <= arrBytes.Length Then
            Dim tempByte(length - 1) As Byte

            For index As Integer = 0 To length - 1
                tempByte(index) = arrBytes(startIndex + index)
            Next
            Return tempByte
        Else
            Return Nothing
        End If
    End Function

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

    Protected Function IsNewPlcMessage(ByVal readPlcStatus As Integer, ByVal readPlcStage As Integer) As Boolean
        If readPlcStatus <> Me.m_intPreviousPlcStatusCode OrElse readPlcStage <> Me.m_intPreviousPlcStageCode Then
            Me.m_intPreviousPlcStatusCode = readPlcStatus
            Me.m_intPreviousPlcStageCode = readPlcStage
            Return True
        Else
            Return False
        End If
    End Function

    Private Function GenLogMessageFromRecvByteByProcessType(ByVal processType As Integer, ByVal readData() As Byte) As String

        If readData.Length <= 0 Then
            Return String.Empty
        End If

        Dim strMessage As String = String.Empty

        Try
            Dim strReadData As String = OMRON.FinsGateway.PLCDataConverter.ByteArrayToString(readData)

            'Don't write log about connection checking
            If strReadData.Length <= 4 Then Return String.Empty

            Select Case processType
                Case PROCESS_TYPE_FINISHING
                    Select Case strReadData.Length
                        Case BYTE_LENGTH_STATE + BYTE_LENGTH_REQ_STATUS
                            strMessage = "State Code=[" & strReadData.Substring(0, BYTE_LENGTH_STATE) & "], Req Status=[" & strReadData.Substring(BYTE_LENGTH_STATE, BYTE_LENGTH_REQ_STATUS) & "]"

                        Case BYTE_LENGTH_STATE + BYTE_LENGTH_REQ_STATUS + BYTE_LENGTH_SKIT
                            strMessage = "State Code=[" & strReadData.Substring(0, BYTE_LENGTH_STATE) & "], Req Status=[" & strReadData.Substring(BYTE_LENGTH_STATE, BYTE_LENGTH_REQ_STATUS) & "], Skit No=[" & strReadData.Substring(BYTE_LENGTH_STATE + BYTE_LENGTH_REQ_STATUS, BYTE_LENGTH_SKIT) & "]"

                        Case (LENGTH_OF_MODEL_YEAR + LENGTH_OF_SUFFIX_CODE + LENGTH_OF_LOT_NO + LENGTH_OF_UNIT + LENGTH_OF_BLOCK + LENGTH_OF_BLOCK_SEQ) * 4
                            Dim converter As New System.Text.UTF8Encoding
                            Dim bytTempArr As Byte()
                            Dim strTempData As String

                            bytTempArr = Me.GetSubBytes(readData, 0, LENGTH_OF_MODEL_YEAR + LENGTH_OF_SUFFIX_CODE)
                            strTempData = converter.GetString(bytTempArr)
                            strMessage = "Model Year=[" & strTempData.Substring(0, LENGTH_OF_MODEL_YEAR) & "]" _
                                         & ",Suffix Code=[" & strTempData.Substring(LENGTH_OF_MODEL_YEAR, LENGTH_OF_SUFFIX_CODE) & "]"

                            bytTempArr = Me.GetSubBytes(readData, LENGTH_OF_MODEL_YEAR + LENGTH_OF_SUFFIX_CODE, (LENGTH_OF_LOT_NO + LENGTH_OF_UNIT))
                            strTempData = converter.GetString(bytTempArr)
                            strMessage &= ",Lot No=[" & strTempData.Substring(0, LENGTH_OF_LOT_NO) & "]" _
                                          & "Unit=[" & strTempData.Substring(LENGTH_OF_LOT_NO, LENGTH_OF_UNIT) & "]"
                            
                            bytTempArr = Me.GetSubBytes(readData, (LENGTH_OF_MODEL_YEAR + LENGTH_OF_SUFFIX_CODE + LENGTH_OF_LOT_NO + LENGTH_OF_UNIT), LENGTH_OF_BLOCK)
                            strMessage &= ",Block=[" & converter.GetString(bytTempArr) & "]"

                            bytTempArr = Me.GetSubBytes(readData, (LENGTH_OF_MODEL_YEAR + LENGTH_OF_SUFFIX_CODE + LENGTH_OF_LOT_NO + LENGTH_OF_UNIT + LENGTH_OF_BLOCK), LENGTH_OF_BLOCK_SEQ)
                            strMessage &= ",Block Seq=[" & converter.GetString(bytTempArr) & "]"
                        Case Else
                            strMessage = "Recv data=[" & strReadData & "]"
                    End Select

                Case PROCESS_TYPE_WBS_ON
                    Select Case strReadData.Length
                        Case BYTE_LENGTH_STATE + BYTE_LENGTH_REQ_STATUS
                            strMessage = "State Code=[" & strReadData.Substring(0, BYTE_LENGTH_STATE) & "], Req Status=[" & strReadData.Substring(BYTE_LENGTH_STATE, BYTE_LENGTH_REQ_STATUS) & "]"

                        Case BYTE_LENGTH_STATE + BYTE_LENGTH_REQ_STATUS + BYTE_LENGTH_SKIT + BYTE_LENGTH_LANE
                            strMessage = "State Code=[" & strReadData.Substring(0, BYTE_LENGTH_STATE) & "], Req Status=[" & strReadData.Substring(BYTE_LENGTH_STATE, BYTE_LENGTH_REQ_STATUS) & "], " _
                                         & "Skit No=[" & strReadData.Substring(BYTE_LENGTH_STATE + BYTE_LENGTH_REQ_STATUS, BYTE_LENGTH_SKIT) & "], Lane No=[" & strReadData.Substring(BYTE_LENGTH_STATE + BYTE_LENGTH_REQ_STATUS + BYTE_LENGTH_SKIT, BYTE_LENGTH_LANE)
                        Case Else
                            strMessage = "Recv data=[" & strReadData & "]"
                    End Select

                Case PROCESS_TYPE_PAINT
                    Select Case strReadData.Length
                        Case BYTE_LENGTH_STATE + BYTE_LENGTH_REQ_STATUS
                            strMessage = "State Code=[" & strReadData.Substring(0, BYTE_LENGTH_STATE) & "], Req Status=[" & strReadData.Substring(BYTE_LENGTH_STATE, BYTE_LENGTH_REQ_STATUS) & "]"

                        Case BYTE_LENGTH_STATE + BYTE_LENGTH_REQ_STATUS + BYTE_LENGTH_SKIT
                            strMessage = "State Code=[" & strReadData.Substring(0, BYTE_LENGTH_STATE) & "], Req Status=[" & strReadData.Substring(BYTE_LENGTH_STATE, BYTE_LENGTH_REQ_STATUS) & "], Skit No=[" & strReadData.Substring(BYTE_LENGTH_STATE + BYTE_LENGTH_REQ_STATUS, BYTE_LENGTH_SKIT) & "]"
                        Case Else
                            strMessage = "Recv data=[" & strReadData & "]"
                    End Select

                Case PROCESS_TYPE_PBR
                    Select Case strReadData.Length
                        Case BYTE_LENGTH_STATE + BYTE_LENGTH_REQ_STATUS
                            strMessage = "State Code=[" & strReadData.Substring(0, BYTE_LENGTH_STATE) & "], Req Status=[" & strReadData.Substring(BYTE_LENGTH_STATE, BYTE_LENGTH_REQ_STATUS) & "]"

                        Case BYTE_LENGTH_STATE + BYTE_LENGTH_REQ_STATUS + BYTE_LENGTH_SKIT
                            strMessage = "State Code=[" & strReadData.Substring(0, BYTE_LENGTH_STATE) & "], Req Status=[" & strReadData.Substring(BYTE_LENGTH_STATE, BYTE_LENGTH_REQ_STATUS) & "], Skit No=[" & strReadData.Substring(BYTE_LENGTH_STATE + BYTE_LENGTH_REQ_STATUS, BYTE_LENGTH_SKIT) & "]"
                        Case Else
                            strMessage = "Recv data=[" & strReadData & "]"
                    End Select

                Case PROCESS_TYPE_WBS_PROGRESS
                    strMessage = String.Empty
            End Select
        Catch ex As Exception
            strMessage = String.Empty
            m_clsLogger.LogByLine(m_intStageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "GenLogMessageFromRecvByteByStageCode", ex.Message, ex.StackTrace)
        End Try

        If m_dictLatestRecvLogMsg.ContainsKey(Me.m_intStageCode) Then
            If strMessage <> String.Empty AndAlso strMessage <> m_dictLatestRecvLogMsg(Me.m_intStageCode) Then
                m_dictLatestRecvLogMsg(Me.m_intStageCode) = strMessage
            Else
                strMessage = String.Empty
            End If
        Else
            m_dictLatestRecvLogMsg.Add(Me.m_intStageCode, String.Empty)
        End If

        Return strMessage
    End Function

    Private Function GenLogMessageFromSendByteByProcessType(ByVal processType As Integer, ByVal sendData As Byte()) As String
        If sendData.Length <= 0 Then
            Return String.Empty
        End If

        Dim strMessage As String = String.Empty

        Try
            Dim strSendData As String = OMRON.FinsGateway.PLCDataConverter.ByteArrayToString(sendData)

            'Don't write log about connection checking
            If strSendData.Length <= 4 Then Return String.Empty

            Select Case processType
                Case PROCESS_TYPE_FINISHING
                    strMessage = "State Code=[" & strSendData.Substring(0, BYTE_LENGTH_STATE) & "], Req Status=[" & strSendData.Substring(BYTE_LENGTH_STATE, BYTE_LENGTH_REQ_STATUS) & "]"

                Case PROCESS_TYPE_WBS_ON
                    Dim converter As New System.Text.UTF8Encoding
                    Dim bytTempArr As Byte()
                    Dim strTempData As String

                    strMessage = "State Code=[" & strSendData.Substring(0, BYTE_LENGTH_STATE) & "], Req Status=[" & strSendData.Substring(BYTE_LENGTH_STATE, BYTE_LENGTH_REQ_STATUS) & "]"
                    strMessage &= ",Skit No(BCD)=[" & strSendData.Substring(BYTE_LENGTH_STATE + BYTE_LENGTH_REQ_STATUS, BYTE_LENGTH_SKIT) & "]"
                    strMessage &= ",Lane No=[" & strSendData.Substring(BYTE_LENGTH_STATE + BYTE_LENGTH_REQ_STATUS + BYTE_LENGTH_SKIT, BYTE_LENGTH_LANE) & "]"

                    Dim intAsciiLengthOfStageCodeSkitNoAndLaneNo As Integer = ((BYTE_LENGTH_STATE + BYTE_LENGTH_REQ_STATUS + BYTE_LENGTH_SKIT + BYTE_LENGTH_LANE) / 2)

                    bytTempArr = Me.GetSubBytes(sendData, intAsciiLengthOfStageCodeSkitNoAndLaneNo, PLC_WRITE_ASCII_SKIT_NO_LENGTH)
                    strTempData = converter.GetString(bytTempArr)
                    strMessage &= ",Skit No(ASCII)=[" & strTempData & "]"

                    bytTempArr = Me.GetSubBytes(sendData, intAsciiLengthOfStageCodeSkitNoAndLaneNo + PLC_WRITE_ASCII_SKIT_NO_LENGTH, PLC_WRITE_ASCII_SEQ_NO_LENGTH)
                    strTempData = converter.GetString(bytTempArr)
                    strMessage &= ",Seq No=[" & strTempData & "]"

                    bytTempArr = Me.GetSubBytes(sendData, intAsciiLengthOfStageCodeSkitNoAndLaneNo + PLC_WRITE_ASCII_SKIT_NO_LENGTH + PLC_WRITE_ASCII_SEQ_NO_LENGTH, PLC_WRITE_ASCII_MODEL_YEAR_LENGTH + PLC_WRITE_ASCII_SUFFIX_CODE_LENGTH)
                    strTempData = converter.GetString(bytTempArr)
                    strMessage &= ",Model Year=[" & strTempData.Substring(0, PLC_WRITE_ASCII_MODEL_YEAR_LENGTH) & "]"
                    strMessage &= ",Suffix Code=[" & strTempData.Substring(PLC_WRITE_ASCII_MODEL_YEAR_LENGTH, PLC_WRITE_ASCII_SUFFIX_CODE_LENGTH) & "]"

                    bytTempArr = Me.GetSubBytes(sendData, intAsciiLengthOfStageCodeSkitNoAndLaneNo + PLC_WRITE_ASCII_SKIT_NO_LENGTH + PLC_WRITE_ASCII_SEQ_NO_LENGTH + PLC_WRITE_ASCII_MODEL_YEAR_LENGTH + PLC_WRITE_ASCII_SUFFIX_CODE_LENGTH, PLC_WRITE_ASCII_LOT_NO_LENGTH)
                    strTempData = converter.GetString(bytTempArr)
                    strMessage &= ",Lot No=[" & strTempData & "]"

                    bytTempArr = Me.GetSubBytes(sendData, intAsciiLengthOfStageCodeSkitNoAndLaneNo + PLC_WRITE_ASCII_SKIT_NO_LENGTH + PLC_WRITE_ASCII_SEQ_NO_LENGTH + PLC_WRITE_ASCII_MODEL_YEAR_LENGTH + PLC_WRITE_ASCII_SUFFIX_CODE_LENGTH + PLC_WRITE_ASCII_LOT_NO_LENGTH, PLC_WRITE_ASCII_UNIT_LENGTH)
                    strTempData = converter.GetString(bytTempArr)
                    strMessage &= ",Unit=[" & strTempData & "]"

                    bytTempArr = Me.GetSubBytes(sendData, intAsciiLengthOfStageCodeSkitNoAndLaneNo + PLC_WRITE_ASCII_SKIT_NO_LENGTH + PLC_WRITE_ASCII_SEQ_NO_LENGTH + PLC_WRITE_ASCII_MODEL_YEAR_LENGTH + PLC_WRITE_ASCII_SUFFIX_CODE_LENGTH + PLC_WRITE_ASCII_LOT_NO_LENGTH + PLC_WRITE_ASCII_UNIT_LENGTH, PLC_WRITE_ASCII_BLOCK_LENGTH)
                    strTempData = converter.GetString(bytTempArr)
                    strMessage &= ",Block Model=[" & strTempData & "]"

                    bytTempArr = Me.GetSubBytes(sendData, intAsciiLengthOfStageCodeSkitNoAndLaneNo + PLC_WRITE_ASCII_SKIT_NO_LENGTH + PLC_WRITE_ASCII_SEQ_NO_LENGTH + PLC_WRITE_ASCII_MODEL_YEAR_LENGTH + PLC_WRITE_ASCII_SUFFIX_CODE_LENGTH + PLC_WRITE_ASCII_LOT_NO_LENGTH + PLC_WRITE_ASCII_UNIT_LENGTH + PLC_WRITE_ASCII_BLOCK_LENGTH, PLC_WRITE_ASCII_BLOCK_SEQ_LENGTH)
                    strTempData = converter.GetString(bytTempArr)
                    strMessage &= ",Block Seq=[" & strTempData & "]"

                    bytTempArr = Me.GetSubBytes(sendData, intAsciiLengthOfStageCodeSkitNoAndLaneNo + PLC_WRITE_ASCII_SKIT_NO_LENGTH + PLC_WRITE_ASCII_SEQ_NO_LENGTH + PLC_WRITE_ASCII_MODEL_YEAR_LENGTH + PLC_WRITE_ASCII_SUFFIX_CODE_LENGTH + PLC_WRITE_ASCII_LOT_NO_LENGTH + PLC_WRITE_ASCII_UNIT_LENGTH + PLC_WRITE_ASCII_BLOCK_LENGTH + PLC_WRITE_ASCII_BLOCK_SEQ_LENGTH, PLC_WRITE_ASCII_HANDLE_TYPE_LENGTH)
                    strTempData = converter.GetString(bytTempArr)
                    strMessage &= ",Handle Type=[" & strTempData & "]"

                    bytTempArr = Me.GetSubBytes(sendData, intAsciiLengthOfStageCodeSkitNoAndLaneNo + PLC_WRITE_ASCII_SKIT_NO_LENGTH + PLC_WRITE_ASCII_SEQ_NO_LENGTH + PLC_WRITE_ASCII_MODEL_YEAR_LENGTH + PLC_WRITE_ASCII_SUFFIX_CODE_LENGTH + PLC_WRITE_ASCII_LOT_NO_LENGTH + PLC_WRITE_ASCII_UNIT_LENGTH + PLC_WRITE_ASCII_BLOCK_LENGTH + PLC_WRITE_ASCII_BLOCK_SEQ_LENGTH + PLC_WRITE_ASCII_HANDLE_TYPE_LENGTH, PLC_WRITE_ASCII_BODY_COLOR_OPT_LENGTH)
                    strTempData = converter.GetString(bytTempArr)
                    strMessage &= ",Body Color Option=[" & strTempData & "]"

                    bytTempArr = Me.GetSubBytes(sendData, intAsciiLengthOfStageCodeSkitNoAndLaneNo + PLC_WRITE_ASCII_SKIT_NO_LENGTH + PLC_WRITE_ASCII_SEQ_NO_LENGTH + PLC_WRITE_ASCII_MODEL_YEAR_LENGTH + PLC_WRITE_ASCII_SUFFIX_CODE_LENGTH + PLC_WRITE_ASCII_LOT_NO_LENGTH + PLC_WRITE_ASCII_UNIT_LENGTH + PLC_WRITE_ASCII_BLOCK_LENGTH + PLC_WRITE_ASCII_BLOCK_SEQ_LENGTH + PLC_WRITE_ASCII_HANDLE_TYPE_LENGTH + PLC_WRITE_ASCII_BODY_COLOR_OPT_LENGTH, PLC_OPTION_DATA_LENGTH)
                    strTempData = converter.GetString(bytTempArr)
                    strMessage &= ",Option=[" & strTempData & "]"

                Case PROCESS_TYPE_PAINT, PROCESS_TYPE_PBR
                    Dim converter As New System.Text.UTF8Encoding
                    Dim bytTempArr As Byte()
                    Dim strTempData As String

                    strMessage = "State Code=[" & strSendData.Substring(0, BYTE_LENGTH_STATE) & "], Req Status=[" & strSendData.Substring(BYTE_LENGTH_STATE, BYTE_LENGTH_REQ_STATUS) & "]"
                    strMessage &= ",Skit No(BCD)=[" & strSendData.Substring(BYTE_LENGTH_STATE + BYTE_LENGTH_REQ_STATUS, BYTE_LENGTH_SKIT) & "]"
                    strMessage &= ",Reserve=[" & strSendData.Substring(BYTE_LENGTH_STATE + BYTE_LENGTH_REQ_STATUS + BYTE_LENGTH_SKIT, BYTE_LENGTH_LANE) & "]"

                    Dim intAsciiLengthOfStageCodeSkitNoAndLaneNo As Integer = ((BYTE_LENGTH_STATE + BYTE_LENGTH_REQ_STATUS + BYTE_LENGTH_SKIT + BYTE_LENGTH_LANE) / 2)

                    bytTempArr = Me.GetSubBytes(sendData, intAsciiLengthOfStageCodeSkitNoAndLaneNo, PLC_WRITE_ASCII_SKIT_NO_LENGTH)
                    strTempData = converter.GetString(bytTempArr)
                    strMessage &= ",Skit No(ASCII)=[" & strTempData & "]"

                    bytTempArr = Me.GetSubBytes(sendData, intAsciiLengthOfStageCodeSkitNoAndLaneNo + PLC_WRITE_ASCII_SKIT_NO_LENGTH, PLC_WRITE_ASCII_SEQ_NO_LENGTH)
                    strTempData = converter.GetString(bytTempArr)
                    strMessage &= ",Seq No=[" & strTempData & "]"

                    bytTempArr = Me.GetSubBytes(sendData, intAsciiLengthOfStageCodeSkitNoAndLaneNo + PLC_WRITE_ASCII_SKIT_NO_LENGTH + PLC_WRITE_ASCII_SEQ_NO_LENGTH, PLC_WRITE_ASCII_MODEL_YEAR_LENGTH + PLC_WRITE_ASCII_SUFFIX_CODE_LENGTH)
                    strTempData = converter.GetString(bytTempArr)
                    strMessage &= ",Model Year=[" & strTempData.Substring(0, PLC_WRITE_ASCII_MODEL_YEAR_LENGTH) & "]"
                    strMessage &= ",Suffix Code=[" & strTempData.Substring(PLC_WRITE_ASCII_MODEL_YEAR_LENGTH, PLC_WRITE_ASCII_SUFFIX_CODE_LENGTH) & "]"

                    bytTempArr = Me.GetSubBytes(sendData, intAsciiLengthOfStageCodeSkitNoAndLaneNo + PLC_WRITE_ASCII_SKIT_NO_LENGTH + PLC_WRITE_ASCII_SEQ_NO_LENGTH + PLC_WRITE_ASCII_MODEL_YEAR_LENGTH + PLC_WRITE_ASCII_SUFFIX_CODE_LENGTH, PLC_WRITE_ASCII_LOT_NO_LENGTH)
                    strTempData = converter.GetString(bytTempArr)
                    strMessage &= ",Lot No=[" & strTempData & "]"

                    bytTempArr = Me.GetSubBytes(sendData, intAsciiLengthOfStageCodeSkitNoAndLaneNo + PLC_WRITE_ASCII_SKIT_NO_LENGTH + PLC_WRITE_ASCII_SEQ_NO_LENGTH + PLC_WRITE_ASCII_MODEL_YEAR_LENGTH + PLC_WRITE_ASCII_SUFFIX_CODE_LENGTH + PLC_WRITE_ASCII_LOT_NO_LENGTH, PLC_WRITE_ASCII_UNIT_LENGTH)
                    strTempData = converter.GetString(bytTempArr)
                    strMessage &= ",Unit=[" & strTempData & "]"

                    bytTempArr = Me.GetSubBytes(sendData, intAsciiLengthOfStageCodeSkitNoAndLaneNo + PLC_WRITE_ASCII_SKIT_NO_LENGTH + PLC_WRITE_ASCII_SEQ_NO_LENGTH + PLC_WRITE_ASCII_MODEL_YEAR_LENGTH + PLC_WRITE_ASCII_SUFFIX_CODE_LENGTH + PLC_WRITE_ASCII_LOT_NO_LENGTH + PLC_WRITE_ASCII_UNIT_LENGTH, PLC_WRITE_ASCII_BLOCK_LENGTH)
                    strTempData = converter.GetString(bytTempArr)
                    strMessage &= ",Block Model=[" & strTempData & "]"

                    bytTempArr = Me.GetSubBytes(sendData, intAsciiLengthOfStageCodeSkitNoAndLaneNo + PLC_WRITE_ASCII_SKIT_NO_LENGTH + PLC_WRITE_ASCII_SEQ_NO_LENGTH + PLC_WRITE_ASCII_MODEL_YEAR_LENGTH + PLC_WRITE_ASCII_SUFFIX_CODE_LENGTH + PLC_WRITE_ASCII_LOT_NO_LENGTH + PLC_WRITE_ASCII_UNIT_LENGTH + PLC_WRITE_ASCII_BLOCK_LENGTH, PLC_WRITE_ASCII_BLOCK_SEQ_LENGTH)
                    strTempData = converter.GetString(bytTempArr)
                    strMessage &= ",Block Seq=[" & strTempData & "]"

                    bytTempArr = Me.GetSubBytes(sendData, intAsciiLengthOfStageCodeSkitNoAndLaneNo + PLC_WRITE_ASCII_SKIT_NO_LENGTH + PLC_WRITE_ASCII_SEQ_NO_LENGTH + PLC_WRITE_ASCII_MODEL_YEAR_LENGTH + PLC_WRITE_ASCII_SUFFIX_CODE_LENGTH + PLC_WRITE_ASCII_LOT_NO_LENGTH + PLC_WRITE_ASCII_UNIT_LENGTH + PLC_WRITE_ASCII_BLOCK_LENGTH + PLC_WRITE_ASCII_BLOCK_SEQ_LENGTH, PLC_WRITE_ASCII_HANDLE_TYPE_LENGTH)
                    strTempData = converter.GetString(bytTempArr)
                    strMessage &= ",Handle Type=[" & strTempData & "]"

                    bytTempArr = Me.GetSubBytes(sendData, intAsciiLengthOfStageCodeSkitNoAndLaneNo + PLC_WRITE_ASCII_SKIT_NO_LENGTH + PLC_WRITE_ASCII_SEQ_NO_LENGTH + PLC_WRITE_ASCII_MODEL_YEAR_LENGTH + PLC_WRITE_ASCII_SUFFIX_CODE_LENGTH + PLC_WRITE_ASCII_LOT_NO_LENGTH + PLC_WRITE_ASCII_UNIT_LENGTH + PLC_WRITE_ASCII_BLOCK_LENGTH + PLC_WRITE_ASCII_BLOCK_SEQ_LENGTH + PLC_WRITE_ASCII_HANDLE_TYPE_LENGTH, PLC_WRITE_ASCII_BODY_COLOR_OPT_LENGTH)
                    strTempData = converter.GetString(bytTempArr)
                    strMessage &= ",Body Color Option=[" & strTempData & "]"

                    bytTempArr = Me.GetSubBytes(sendData, intAsciiLengthOfStageCodeSkitNoAndLaneNo + PLC_WRITE_ASCII_SKIT_NO_LENGTH + PLC_WRITE_ASCII_SEQ_NO_LENGTH + PLC_WRITE_ASCII_MODEL_YEAR_LENGTH + PLC_WRITE_ASCII_SUFFIX_CODE_LENGTH + PLC_WRITE_ASCII_LOT_NO_LENGTH + PLC_WRITE_ASCII_UNIT_LENGTH + PLC_WRITE_ASCII_BLOCK_LENGTH + PLC_WRITE_ASCII_BLOCK_SEQ_LENGTH + PLC_WRITE_ASCII_HANDLE_TYPE_LENGTH + PLC_WRITE_ASCII_BODY_COLOR_OPT_LENGTH, PLC_OPTION_DATA_LENGTH)
                    strTempData = converter.GetString(bytTempArr)
                    strMessage &= ",Option=[" & strTempData & "]"

                Case PROCESS_TYPE_WBS_PROGRESS
                    strMessage = String.Empty

            End Select
        Catch ex As Exception
            strMessage = String.Empty
            m_clsLogger.LogByLine(m_intStageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "GenLogMessageFromSendByteByProcessType", ex.Message, ex.StackTrace)
        End Try

        If m_dictLatestSendLogMsg.ContainsKey(Me.m_intStageCode) Then
            If strMessage <> String.Empty AndAlso strMessage <> m_dictLatestSendLogMsg(Me.m_intStageCode) Then
                m_dictLatestSendLogMsg(Me.m_intStageCode) = strMessage
            Else
                strMessage = String.Empty
            End If
        Else
            m_dictLatestSendLogMsg.Add(Me.m_intStageCode, String.Empty)
        End If

        Return strMessage
    End Function

    Private Function GetSuccessMessage() As String
        Return Me.m_strProcessName & " - SUCCESS"
    End Function

    Private Function GetFailMessage() As String
        Return Me.m_strProcessName & " - FAIL"
    End Function

#End Region

End Class
