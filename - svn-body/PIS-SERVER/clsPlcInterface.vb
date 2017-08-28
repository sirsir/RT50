Public Class clsPlcInterface
#Region "MEMBER"

    'Read
    'Private m_intModelReqLineNo As Integer
    'Private m_intModelReqDataType As Integer
    'Private m_intModelReqStatus As Integer

    'Private m_intCarryReqLineNo As Integer
    'Private m_intCarryReqDataType As Integer
    'Private m_intCarryReqStatus As Integer
    'Private m_strCarryReqLot As String
    'Private m_strCarryReqUnit As String
    Private enc As New System.Text.UTF8Encoding
    Private m_responseCommandCode() As Byte

    Private m_readResult As Boolean
    Private m_readResponseMessage As String
    Private m_readResponseData() As Byte

    Private m_writeResult As Boolean
    Private m_writeResponseMessage As String


    'Write
    'Private Const DATA_TYPE_VEHICLE As Integer = 1

    'Private Const PLC_MODEL_REQUEST_STATUS_REQUEST As Integer = 1
    'Private Const PLC_MODEL_REQUEST_STATUS_COMPLETE As Integer = 2
    'Private Const PLC_MODEL_REQUEST_STATUS_FAULT As Integer = 4

    'Private Const PLC_CARRY_OUT_REQUEST_REQUEST_STATUS_CARRYING_OUT As Integer = 1

    'Private Const SERVER_CARRY_OUT_STATUS_OK As Integer = 1
    'Private Const SERVER_CARRY_OUT_STATUS_NG As Integer = 2

    'Private Const SERVER_SERVER_STATUS_OFF As Integer = 0
    'Private Const SERVER_SERVER_STATUS_ON As Integer = 1
    'Private Const SERVER_SERVER_STATUS_FAULT As Integer = 2

    'Private Const FINS_MSG_MEMORY_AREA_READ As String = "0101"
    'Private Const FINS_MSG_MEMORY_AREA_WRITE As String = "0102"
    'Private Const FINS_MSG_MEMORY_AREA_FILL As String = "0103"
    'Private Const FINS_MSG_MULTIPLE_MEMORY_AREA_READ As String = "0104"
    'Private Const FINS_MSG_MEMORY_AREA_TRANSFER As String = "0105"

    Private Const FINS_MSG_DM_MEMORY_AREA_READ As String = "010182"
    Private Const FINS_MSG_DM_MEMORY_AREA_WRITE As String = "010282"

    Private FINS_READ() As Byte = {&H1, &H1}
    Private FINS_WRITE() As Byte = {&H1, &H2}
    Private FINS_DM As Byte = &H82

#End Region

#Region "GET AND SET METHOD"
    Public Property ReadResult() As Boolean
        Get
            Return m_readResult
        End Get
        Set(ByVal value As Boolean)
            m_readResult = value
        End Set
    End Property

    Public Property ReadResponseMessage() As String
        Get
            Return m_readResponseMessage
        End Get
        Set(ByVal value As String)
            m_readResponseMessage = value
        End Set
    End Property

    Public Property ReadResponseData() As Byte()
        Get
            Return m_readResponseData
        End Get
        Set(ByVal value() As Byte)
            m_readResponseData = value
        End Set
    End Property

    Public Property WriteResult() As Boolean
        Get
            Return m_writeResult
        End Get
        Set(ByVal value As Boolean)
            m_writeResult = value
        End Set
    End Property

    Public Property WriteResponseMessage() As String
        Get
            Return m_writeResponseMessage
        End Get
        Set(ByVal value As String)
            m_writeResponseMessage = value
        End Set
    End Property
#End Region


#Region "METHOD"
    Public Sub TestReadWriteToPlc()
        Dim plcConnect As New OMRON.Compolet.FinsGateway.FinsMsg
        Dim plcConvert As New OMRON.FinsGateway.PLCDataConverter
        Dim strFins As String
        Dim strRece As String
        Dim arrByte() As Byte = {&HA, &HB, &HC, &HD, &HE, &HF}

        plcConnect.NetworkAddress = 1
        plcConnect.NodeAddress = 101
        plcConnect.UnitAddress = 0

        Me.WritePlcDm(plcConnect, 30, arrByte)

        'Console.Write("WrResponse = " & m_writeResponseMessage & ",   WrStatus = ")
        'Console.WriteLine(m_writeResult.ToString)

        Me.ReadPlcDm(plcConnect, 30, 4)

        'Console.Write("ReResponse = " & m_readResponseMessage & ",   ReStatus = ")
        'Console.WriteLine(m_readResult.ToString)

        'strFins = FinsMsgWriteDmString(23000, "ffff")
        'plcConnect.SendFinsCommand(strFins)
        'strRece = plcConnect.ReceiveMessageString()
        'Dim fMsg As OMRON.FinsGateway.Messaging.FINS.MemoryAreaReadResponse
        'Dim fAdd As OMRON.FinsGateway.Messaging.FinsAddress

        'Dim bteConcat() As Byte = FINS_READ
        'ConcatByte(bteConcat, FINS_DM)

        'strFins = FinsMsgReadDmString(23000, 1)
        'plcConnect.SendFinsCommand(strFins)
        'Dim bteArr() As Byte = plcConnect.ReceiveMessage()
        'Dim msg As String = enc.GetString(bteArr, 5, 2)

        'strFins = FinsMsgWriteDmString(23000, "12340000")
        'plcConnect.SendFinsCommand(strFins)
        'strRece = plcConnect.ReceiveMessageString()


        'strFins = FinsMsgReadDmString(23000, 2)
        'plcConnect.SendFinsCommand(strFins)
        'strRece = plcConnect.ReceiveMessageString()

    End Sub

#Region "STRING METHOD"
    Public Function FinsMsgReadDmString(ByVal intReadAddress As Integer, ByVal length As Integer) As String
        'return string is a hexadecimal string
        Dim strFinsMessage As String
        strFinsMessage = FINS_MSG_DM_MEMORY_AREA_READ & FinsMsgDmAddressString(intReadAddress) & FinsMsgLengthString(length)
        Return strFinsMessage
    End Function

    Public Function FinsMsgWriteDmString(ByVal intWriteAddress As Integer, ByVal strMsg As String) As String
        'strMsg is an ASCII string, return string is a hexadecimal string
        Dim strFinsMessage As String
        Dim bteMsg() As Byte
        bteMsg = enc.GetBytes(strMsg)
        Dim strHexMsg As String = ""
        For i As Integer = 0 To bteMsg.Length - 1
            strHexMsg += CInt(bteMsg(i)).ToString("X")
        Next
        Dim intFinLength As Integer = Math.Ceiling(strMsg.Length / 2.0)
        strFinsMessage = FINS_MSG_DM_MEMORY_AREA_WRITE & FinsMsgDmAddressString(intWriteAddress) & FinsMsgLengthString(intFinLength) & strHexMsg
        Return strFinsMessage
    End Function

    Private Function FinsMsgDmAddressString(ByVal intAddress As Integer) As String
        'return string is a hexadecimal string
        Dim strAddress As String
        strAddress = intAddress.ToString("X4")
        Return strAddress
    End Function

    Private Function FinsMsgLengthString(ByVal intLength As Integer) As String
        'return string is a hexadecimal string
        Dim strLength As String
        strLength = intLength.ToString("X6")
        Return strLength
    End Function

    Private Function GetResponseCodeFromReceivedMessage(ByVal message As String) As Short
        'message string is a hexadecimal string
        Dim strResponse As String
        strResponse = System.Convert.ToInt16(message.Substring(4, 4), 16)   'TODO
        Return strResponse
    End Function
#End Region

#Region "BYTE METHOD"
    Public Sub WritePlcDm(ByVal finMsg As OMRON.Compolet.FinsGateway.FinsMsg, _
                                 ByVal writeAddress As UInteger, ByVal message() As Byte)
        Try
            finMsg.SendFinsCommand(Me.FinsMsgWriteDmByte(writeAddress, message))
            Dim receiveMsg() As Byte
            receiveMsg = finMsg.ReceiveMessage()
            If (OMRON.FinsGateway.PLCDataConverter.PLC2ByteAsBINToSystemInteger(receiveMsg, 0) = _
                OMRON.FinsGateway.PLCDataConverter.PLC2ByteAsBINToSystemInteger(FINS_WRITE, 0)) Then
                Dim intResCode As Integer = Me.FinsResponseCode(receiveMsg)
                If intResCode <> 0 Then
                    m_writeResult = False
                    m_writeResponseMessage = OMRON.FinsGateway.Messaging.FINS.MemoryAreaWriteResponse.GetResponseMessage(intResCode)
                Else
                    m_writeResult = True
                    m_writeResponseMessage = ""
                End If
            Else
                m_writeResult = False
                m_writeResponseMessage = "Invalid command code received"
            End If
        Catch ex As Exception
            m_writeResult = False
            m_writeResponseMessage = ex.Message
        End Try
    End Sub

    Public Sub ReadPlcDm(ByVal finMsg As OMRON.Compolet.FinsGateway.FinsMsg, ByVal readAddress As UInteger, ByVal length As Integer)

        Try
            finMsg.SendFinsCommand(Me.FinsMsgReadDmByte(readAddress, length))
            Dim receiveMsg() As Byte
            receiveMsg = finMsg.ReceiveMessage()
            If (OMRON.FinsGateway.PLCDataConverter.PLC2ByteAsBINToSystemInteger(receiveMsg, 0) = _
                OMRON.FinsGateway.PLCDataConverter.PLC2ByteAsBINToSystemInteger(FINS_READ, 0)) Then
                Dim intResCode As Integer = Me.FinsResponseCode(receiveMsg)
                If intResCode <> 0 Then
                    m_readResult = False
                    m_readResponseMessage = OMRON.FinsGateway.Messaging.FINS.MemoryAreaReadResponse.GetResponseMessage(intResCode)
                    m_readResponseData = Nothing
                Else
                    m_readResult = True
                    m_readResponseMessage = ""
                    m_readResponseData = Me.GetSubBytes(receiveMsg, 4, length * 2)
                End If
            Else
                m_readResult = False
                m_readResponseMessage = "Invalid command code received"
                m_readResponseData = Nothing
            End If
        Catch ex As Exception
            m_readResult = False
            m_readResponseMessage = ex.Message
            m_readResponseData = Nothing
        End Try
    End Sub

    Public Function FinsMsgReadDmByte(ByVal intReadAddress As UInteger, ByVal length As Integer) As Byte()
        Dim tempMsg() As Byte
        tempMsg = FINS_READ
        ConcatByte(tempMsg, FINS_DM)
        ConcatByte(tempMsg, FinsMsgDmAddressByte(intReadAddress))
        ConcatByte(tempMsg, FinsMsgLengthByte(length))
        Return tempMsg
    End Function

    Public Function FinsMsgWriteDmByte(ByVal intWriteAddress As UInteger, ByVal byteMsg() As Byte) As Byte()
        Dim tempMsg() As Byte
        tempMsg = FINS_WRITE
        ConcatByte(tempMsg, FINS_DM)
        ConcatByte(tempMsg, FinsMsgDmAddressByte(intWriteAddress))
        Dim intFinLength As Integer = Math.Ceiling(byteMsg.Count / 2.0)
        ConcatByte(tempMsg, FinsMsgLengthByte(intFinLength))
        ConcatByte(tempMsg, byteMsg)
        Return tempMsg
    End Function

    Private Function FinsResponseCode(ByVal byteResponse() As Byte) As UInteger
        'byteResponse is full received response byte()
        Dim intResponseCode As Integer
        intResponseCode = OMRON.FinsGateway.PLCDataConverter.PLC2ByteAsBINToSystemInteger(byteResponse, 2)
        Return intResponseCode
    End Function

    Private Function FinsMsgDmAddressByte(ByVal intAddress As UInteger) As Byte()
        Dim byteAddress As Byte() = OMRON.FinsGateway.PLCDataConverter.SystemIntegerToPLC2ByteAsBIN(intAddress)
        Dim byte0() As Byte = {CByte(0)}
        ConcatByte(byteAddress, byte0)
        Return byteAddress
    End Function

    Private Function FinsMsgLengthByte(ByVal intLength As Integer) As Byte()
        Dim byteLength() As Byte
        byteLength = OMRON.FinsGateway.PLCDataConverter.SystemIntegerToPLC2ByteAsBIN(intLength)
        Return byteLength
    End Function

    Public Function GetSubBytes(ByVal arrBytes As Byte(), ByVal startIndex As UInteger, ByVal length As UInteger) As Byte()
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

    Public Function GetSubBytes(ByVal arrBytes As Byte(), ByVal startIndex As UInteger) As Byte()
        If startIndex < arrBytes.Length Then
            Dim tempByte(arrBytes.Length - startIndex - 1) As Byte

            For index As Integer = 0 To tempByte.length - 1
                tempByte(index) = arrBytes(startIndex + index)
            Next
            Return tempByte
        Else
            Return Nothing
        End If
    End Function

    Public Sub ConcatByte(ByRef arrByte1() As Byte, ByVal arrByte2() As Byte)
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

    Public Sub ConcatByte(ByRef arrByte1() As Byte, ByVal byte2 As Byte)
        'Concat byte2 into arrByte1
        Dim tempByte1(arrByte1.Count) As Byte

        For index As Integer = 0 To arrByte1.Count - 1
            tempByte1(index) = arrByte1(index)
        Next

        tempByte1(arrByte1.Count) = byte2
        arrByte1 = tempByte1
    End Sub

    Public Sub FillZeroPrefix(ByRef arrByte1() As Byte, ByVal length As Integer)
        If length > arrByte1.Length Then
            Dim tempByte1(length - arrByte1.Length - 1) As Byte
            For index As Integer = 0 To tempByte1.Count - 1
                tempByte1(index) = &H0
            Next
            ConcatByte(tempByte1, arrByte1)
            arrByte1 = tempByte1
        End If
    End Sub

    Public Sub FillZeroSuffix(ByRef arrByte1() As Byte, ByVal length As Integer)
        If length > arrByte1.Length Then
            Dim tempByte1() As Byte = arrByte1
            Dim zeroByte As Byte = &H0
            For index As Integer = tempByte1.Count To length - 1
                ConcatByte(tempByte1, zeroByte)
            Next
            arrByte1 = tempByte1
        End If
    End Sub

    Public Sub FillSpacePrefix(ByRef arrByte1() As Byte, ByVal length As Integer)
        If length > arrByte1.Length Then
            Dim tempByte1(length - arrByte1.Length - 1) As Byte
            Dim spaceByte() As Byte = enc.GetBytes(" ")
            For index As Integer = 0 To tempByte1.Count - 1
                tempByte1(index) = spaceByte(0)
            Next
            ConcatByte(tempByte1, arrByte1)
            arrByte1 = tempByte1
        End If
    End Sub

    Public Sub FillSpaceSuffix(ByRef arrByte1() As Byte, ByVal length As Integer)
        If length > arrByte1.Length Then
            Dim tempByte1() As Byte = arrByte1
            Dim spaceByte() As Byte = enc.GetBytes(" ")
            For index As Integer = tempByte1.Count To length - 1
                ConcatByte(tempByte1, spaceByte)
            Next
            arrByte1 = tempByte1
        End If
    End Sub
#End Region
#End Region
End Class
