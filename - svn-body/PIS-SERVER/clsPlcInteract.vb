Public Class clsPlcInteract

#Region "MEMBER"

    Private plcConvert As New OMRON.FinsGateway.PLCDataConverter
    Private converter As New System.Text.UTF8Encoding

#End Region

#Region "METHOD"
    Public Function WriteInstruction(ByVal dr As ServerDataset.T_Instruction_DATRow) As Byte()

        Dim instructionWord(3) As Byte
        Dim logg As New Common.Logger

        'set iLineNo
        Dim iLineNo(0) As Integer
        iLineNo(0) = dr.Line_No
        OMRON.FinsGateway.PLCDataConverter.SystemIntegerToPLC2ByteAsBCD(iLineNo, instructionWord, 0)

        'set status
        instructionWord(2) = "&H1"
        instructionWord(3) = "&H1"

        Dim seqNo() As Byte = converter.GetBytes(String.Format("{0:000000}", CInt(dr.SeqNo)))

        Dim productionStyle(1) As Byte
        Dim prodStyle(0) As Integer
        If dr.YChassisFlag = "" Or dr.YChassisFlag = "0" Then
            prodStyle(0) = String.Format("{0:00}", 0)
        ElseIf dr.YChassisFlag = "1" Or dr.YChassisFlag = "2" Then
            prodStyle(0) = String.Format("{0:00}", 2)
        ElseIf dr.YChassisFlag = "3" Then
            prodStyle(0) = String.Format("{0:00}", 3)
        End If
        OMRON.FinsGateway.PLCDataConverter.SystemIntegerToPLC2ByteAsBCD(prodStyle, productionStyle, 0)

        Dim inspectionFlag(1) As Byte
        Dim inspectFlag(0) As Integer
        inspectFlag(0) = dr.XchgFlag.Substring(2, 2)
        OMRON.FinsGateway.PLCDataConverter.SystemIntegerToPLC2ByteAsBCD(inspectFlag, inspectionFlag, 0)

        Dim modelCode() As Byte = converter.GetBytes(dr.ModelYear & dr.SuffixCode)
        Dim lotNoUnit() As Byte = converter.GetBytes(dr.LotNo)
        Dim spaceByte() As Byte = converter.GetBytes(" ")
        ConcatByte(lotNoUnit, spaceByte)
        ConcatByte(lotNoUnit, converter.GetBytes(dr.Unit.Substring(1)))
        Dim blockModel() As Byte = CheckLengthFillNull(dr.BlockModel, 8)
        Dim blockSeq() As Byte = CheckLengthFillNull(dr.BlockSeq, 3)
        ConcatByte(blockSeq, spaceByte)

        Dim productionDate() As Byte = converter.GetBytes(dr.ProductionDate)
        Dim hanmmerYear() As Byte = CheckLengthFillNull(dr.HanmmerYears, 2)

        'concat byte
        ConcatByte(instructionWord, seqNo)
        ConcatByte(instructionWord, productionStyle)
        ConcatByte(instructionWord, inspectionFlag)
        ConcatByte(instructionWord, modelCode)
        ConcatByte(instructionWord, lotNoUnit)
        ConcatByte(instructionWord, blockModel)
        ConcatByte(instructionWord, blockSeq)
        ConcatByte(instructionWord, productionDate)
        ConcatByte(instructionWord, hanmmerYear)


        Dim asm01() As Byte = CheckLengthFillNull(dr.ASM01, 10)
        Dim asm02() As Byte = CheckLengthFillNull(dr.ASM02, 10)
        Dim asm03() As Byte = CheckLengthFillNull(dr.ASM03, 10)
        Dim asm04() As Byte = CheckLengthFillNull(dr.ASM04, 10)
        Dim asm05() As Byte = CheckLengthFillNull(dr.ASM05, 10)

        FillSpacePrefix(asm01, 10)
        FillSpacePrefix(asm02, 10)
        FillSpacePrefix(asm03, 10)
        FillSpacePrefix(asm04, 10)
        FillSpacePrefix(asm05, 10)

        'concat byte
        ConcatByte(instructionWord, asm01)
        ConcatByte(instructionWord, asm02)
        ConcatByte(instructionWord, asm03)
        ConcatByte(instructionWord, asm04)
        ConcatByte(instructionWord, asm05)

        ''concat reserve byte
        'Dim reserve(99) As Byte
        'ConcatByte(instructionWord, reserve)

        logg.LogByLine(dr.Line_No, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "WriteInstruction", _
                       "LineCode = " & BitConverter.ToString(GetSubBytes(instructionWord, 0, 2)), "")
        logg.LogByLine(dr.Line_No, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "WriteInstruction", _
                       "DataType = " & BitConverter.ToString(GetSubBytes(instructionWord, 2, 1)), "")
        logg.LogByLine(dr.Line_No, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "WriteInstruction", _
                       "Status = " & BitConverter.ToString(GetSubBytes(instructionWord, 3, 1)), "")
        logg.LogByLine(dr.Line_No, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "WriteInstruction", _
                       "SeqNo = " & BitConverter.ToString(GetSubBytes(instructionWord, 4, 6)), "")
        logg.LogByLine(dr.Line_No, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "WriteInstruction", _
                       "ProductionStyle = " & BitConverter.ToString(GetSubBytes(instructionWord, 10, 2)), "")
        logg.LogByLine(dr.Line_No, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "WriteInstruction", _
                       "InspectionFlag = " & BitConverter.ToString(GetSubBytes(instructionWord, 12, 2)), "")
        logg.LogByLine(dr.Line_No, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "WriteInstruction", _
                       "ModelCode = " & BitConverter.ToString(GetSubBytes(instructionWord, 14, 8)), "")
        logg.LogByLine(dr.Line_No, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "WriteInstruction", _
                       "LotUnit = " & BitConverter.ToString(GetSubBytes(instructionWord, 22, 6)), "")
        logg.LogByLine(dr.Line_No, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "WriteInstruction", _
                       "BlockModel = " & BitConverter.ToString(GetSubBytes(instructionWord, 28, 8)), "")
        logg.LogByLine(dr.Line_No, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "WriteInstruction", _
                       "BlockSeq = " & BitConverter.ToString(GetSubBytes(instructionWord, 36, 4)), "")
        logg.LogByLine(dr.Line_No, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "WriteInstruction", _
                       "ProductionDate = " & BitConverter.ToString(GetSubBytes(instructionWord, 40, 8)), "")
        logg.LogByLine(dr.Line_No, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "WriteInstruction", _
                       "HANMMER YEARS = " & BitConverter.ToString(GetSubBytes(instructionWord, 48, 2)), "")
        logg.LogByLine(dr.Line_No, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "WriteInstruction", _
                       "ASMPart1 = " & BitConverter.ToString(GetSubBytes(instructionWord, 50, 10)), "")
        logg.LogByLine(dr.Line_No, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "WriteInstruction", _
                       "ASMPart2 = " & BitConverter.ToString(GetSubBytes(instructionWord, 60, 10)), "")
        logg.LogByLine(dr.Line_No, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "WriteInstruction", _
                       "ASMPart3 = " & BitConverter.ToString(GetSubBytes(instructionWord, 70, 10)), "")
        logg.LogByLine(dr.Line_No, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "WriteInstruction", _
                       "ASMPart4 = " & BitConverter.ToString(GetSubBytes(instructionWord, 80, 10)), "")
        logg.LogByLine(dr.Line_No, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "WriteInstruction", _
                       "ASMPart5 = " & BitConverter.ToString(GetSubBytes(instructionWord, 90, 10)), "")

        Return instructionWord
    End Function

    Public Function WriteInstructionPartNotMatch(ByVal dr As ServerDataset.T_Instruction_DATRow) As Byte()

        Dim instructionWord(3) As Byte
        Dim logg As New Common.Logger

        'set iLineNo
        Dim iLineNo(0) As Integer
        iLineNo(0) = dr.Line_No
        OMRON.FinsGateway.PLCDataConverter.SystemIntegerToPLC2ByteAsBCD(iLineNo, instructionWord, 0)

        'set status
        instructionWord(2) = "&H1"
        instructionWord(3) = "&H2"

        Dim seqNo() As Byte = converter.GetBytes(String.Format("{0:000000}", CInt(dr.SeqNo)))

        Dim productionStyle(1) As Byte
        Dim prodStyle(0) As Integer
        If dr.YChassisFlag = "" Or dr.YChassisFlag = "0" Then
            prodStyle(0) = String.Format("{0:00}", 0)
        ElseIf dr.YChassisFlag = "1" Or dr.YChassisFlag = "2" Then
            prodStyle(0) = String.Format("{0:00}", 2)
        ElseIf dr.YChassisFlag = "3" Then
            prodStyle(0) = String.Format("{0:00}", 3)
        End If
        OMRON.FinsGateway.PLCDataConverter.SystemIntegerToPLC2ByteAsBCD(prodStyle, productionStyle, 0)

        Dim inspectionFlag(1) As Byte
        Dim inspectFlag(0) As Integer
        inspectFlag(0) = dr.XchgFlag.Substring(2, 2)
        OMRON.FinsGateway.PLCDataConverter.SystemIntegerToPLC2ByteAsBCD(inspectFlag, inspectionFlag, 0)

        Dim modelCode() As Byte = converter.GetBytes(dr.ModelYear & dr.SuffixCode)
        Dim lotNoUnit() As Byte = converter.GetBytes(dr.LotNo)
        Dim spaceByte() As Byte = converter.GetBytes(" ")
        ConcatByte(lotNoUnit, spaceByte)
        ConcatByte(lotNoUnit, converter.GetBytes(dr.Unit.Substring(1)))
        Dim blockModel() As Byte = CheckLengthFillNull(dr.BlockModel, 8)
        Dim blockSeq() As Byte = CheckLengthFillNull(dr.BlockSeq, 3)
        ConcatByte(blockSeq, spaceByte)

        Dim productionDate() As Byte = converter.GetBytes(dr.ProductionDate)
        Dim hanmmerYear() As Byte = CheckLengthFillNull(dr.HanmmerYears, 2)

        'concat byte
        ConcatByte(instructionWord, seqNo)
        ConcatByte(instructionWord, productionStyle)
        ConcatByte(instructionWord, inspectionFlag)
        ConcatByte(instructionWord, modelCode)
        ConcatByte(instructionWord, lotNoUnit)
        ConcatByte(instructionWord, blockModel)
        ConcatByte(instructionWord, blockSeq)
        ConcatByte(instructionWord, productionDate)
        ConcatByte(instructionWord, hanmmerYear)


        Dim asm01() As Byte = CheckLengthFillNull(dr.ASM01, 10)
        Dim asm02() As Byte = CheckLengthFillNull(dr.ASM02, 10)
        Dim asm03() As Byte = CheckLengthFillNull(dr.ASM03, 10)
        Dim asm04() As Byte = CheckLengthFillNull(dr.ASM04, 10)
        Dim asm05() As Byte = CheckLengthFillNull(dr.ASM05, 10)

        FillSpacePrefix(asm01, 10)
        FillSpacePrefix(asm02, 10)
        FillSpacePrefix(asm03, 10)
        FillSpacePrefix(asm04, 10)
        FillSpacePrefix(asm05, 10)

        'concat byte
        ConcatByte(instructionWord, asm01)
        ConcatByte(instructionWord, asm02)
        ConcatByte(instructionWord, asm03)
        ConcatByte(instructionWord, asm04)
        ConcatByte(instructionWord, asm05)

        ''concat reserve byte
        'Dim reserve(99) As Byte
        'ConcatByte(instructionWord, reserve)

        logg.LogByLine(dr.Line_No, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "WriteInstruction", _
                       "LineCode = " & BitConverter.ToString(GetSubBytes(instructionWord, 0, 2)), "")
        logg.LogByLine(dr.Line_No, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "WriteInstruction", _
                       "DataType = " & BitConverter.ToString(GetSubBytes(instructionWord, 2, 1)), "")
        logg.LogByLine(dr.Line_No, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "WriteInstruction", _
                       "Status = " & BitConverter.ToString(GetSubBytes(instructionWord, 3, 1)), "")
        logg.LogByLine(dr.Line_No, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "WriteInstruction", _
                       "SeqNo = " & BitConverter.ToString(GetSubBytes(instructionWord, 4, 6)), "")
        logg.LogByLine(dr.Line_No, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "WriteInstruction", _
                       "ProductionStyle = " & BitConverter.ToString(GetSubBytes(instructionWord, 10, 2)), "")
        logg.LogByLine(dr.Line_No, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "WriteInstruction", _
                       "InspectionFlag = " & BitConverter.ToString(GetSubBytes(instructionWord, 12, 2)), "")
        logg.LogByLine(dr.Line_No, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "WriteInstruction", _
                       "ModelCode = " & BitConverter.ToString(GetSubBytes(instructionWord, 14, 8)), "")
        logg.LogByLine(dr.Line_No, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "WriteInstruction", _
                       "LotUnit = " & BitConverter.ToString(GetSubBytes(instructionWord, 22, 6)), "")
        logg.LogByLine(dr.Line_No, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "WriteInstruction", _
                       "BlockModel = " & BitConverter.ToString(GetSubBytes(instructionWord, 28, 8)), "")
        logg.LogByLine(dr.Line_No, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "WriteInstruction", _
                       "BlockSeq = " & BitConverter.ToString(GetSubBytes(instructionWord, 36, 4)), "")
        logg.LogByLine(dr.Line_No, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "WriteInstruction", _
                       "ProductionDate = " & BitConverter.ToString(GetSubBytes(instructionWord, 40, 8)), "")
        logg.LogByLine(dr.Line_No, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "WriteInstruction", _
                       "HANMMER YEARS = " & BitConverter.ToString(GetSubBytes(instructionWord, 48, 2)), "")
        logg.LogByLine(dr.Line_No, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "WriteInstruction", _
                       "ASMPart1 = " & BitConverter.ToString(GetSubBytes(instructionWord, 50, 10)), "")
        logg.LogByLine(dr.Line_No, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "WriteInstruction", _
                       "ASMPart2 = " & BitConverter.ToString(GetSubBytes(instructionWord, 60, 10)), "")
        logg.LogByLine(dr.Line_No, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "WriteInstruction", _
                       "ASMPart3 = " & BitConverter.ToString(GetSubBytes(instructionWord, 70, 10)), "")
        logg.LogByLine(dr.Line_No, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "WriteInstruction", _
                       "ASMPart4 = " & BitConverter.ToString(GetSubBytes(instructionWord, 80, 10)), "")
        logg.LogByLine(dr.Line_No, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "WriteInstruction", _
                       "ASMPart5 = " & BitConverter.ToString(GetSubBytes(instructionWord, 90, 10)), "")

        Return instructionWord
    End Function

    Public Function WriteNoInstruction(ByVal lineNo As Integer) As Byte()

        Dim instructionWord(3) As Byte
        Dim arrInt(0) As Integer
        Dim logg As New Common.Logger
        arrInt(0) = lineNo
        OMRON.FinsGateway.PLCDataConverter.SystemIntegerToPLC2ByteAsBCD(arrInt, instructionWord, 0)
        'set status
        instructionWord(2) = "&H1"
        instructionWord(3) = "&H4"

        'Clear Instruction Data
        Dim arrByte(96 - 1) As Byte
        ConcatByte(instructionWord, arrByte)

        logg.LogByLine(lineNo, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "WriteStatusFault", _
                       "LineNo = " & BitConverter.ToString(GetSubBytes(instructionWord, 0, 2)), "")
        logg.LogByLine(lineNo, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "WriteStatusFault", _
                       "DataType = " & BitConverter.ToString(GetSubBytes(instructionWord, 2, 1)), "")
        logg.LogByLine(lineNo, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "WriteStatusFault", _
                       "Status = " & BitConverter.ToString(GetSubBytes(instructionWord, 3, 1)), "")
        logg.LogByLine(lineNo, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "WriteStatusFault", _
                       "Clear Data = " & BitConverter.ToString(GetSubBytes(instructionWord, 4, 96)), "")
        Return instructionWord
    End Function

    Public Function WriteCompleteInstruction(ByVal lineNo As Integer) As Byte()

        Dim instructionWord(3) As Byte
        Dim arrInt(0) As Integer
        Dim logg As New Common.Logger
        arrInt(0) = lineNo
        OMRON.FinsGateway.PLCDataConverter.SystemIntegerToPLC2ByteAsBCD(arrInt, instructionWord, 0)
        'set status
        instructionWord(2) = "&H1"
        instructionWord(3) = "&H0"

        'Clear Instruction Data
        Dim arrByte(96 - 1) As Byte
        ConcatByte(instructionWord, arrByte)

        logg.LogByLine(lineNo, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "WriteCompleteInstruction", _
                       "LineNo = " & BitConverter.ToString(GetSubBytes(instructionWord, 0, 2)), "")
        logg.LogByLine(lineNo, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "WriteCompleteInstruction", _
                       "DataType = " & BitConverter.ToString(GetSubBytes(instructionWord, 2, 1)), "")
        logg.LogByLine(lineNo, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "WriteCompleteInstruction", _
                       "Status = " & BitConverter.ToString(GetSubBytes(instructionWord, 3, 1)), "")
        logg.LogByLine(lineNo, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "WriteCompleteInstruction", _
                       "Clear Data = " & BitConverter.ToString(GetSubBytes(instructionWord, 4, 96)), "")
        Return instructionWord
    End Function

    Public Function ReadModelDataRequestStatus(ByVal word As Byte()) As Integer

        Dim status As Integer = word(3)
        Return status ' return status

    End Function

    Public Function ReadModelDataRequestDataType(ByVal word As Byte()) As Integer

        Dim status As Integer = word(2)
        Return status ' return status

    End Function

    Public Function ReadModelDataRequestLine(ByVal word As Byte()) As Integer

        Dim status As Integer = OMRON.FinsGateway.PLCDataConverter.PLC2ByteAsBCDToSystemInteger(word, 0, 2)(0)
        Return status ' return status

    End Function

    Public Function ReadCarryOutRequestStatus(ByVal word As Byte()) As Integer

        Dim status As Integer = word(3)
        Return status ' return status

    End Function

    Public Function ReadCarryOutRequestDataType(ByVal word As Byte()) As Integer

        Dim status As Integer = word(2)
        Return status ' return status

    End Function

    Public Function ReadCarryOutRequestLine(ByVal word As Byte()) As Integer

        Dim status As Integer = OMRON.FinsGateway.PLCDataConverter.PLC2ByteAsBCDToSystemInteger(word, 0, 2)(0)
        Return status ' return status

    End Function

    Public Function ReadCarryOutLot(ByVal word As Byte()) As String

        Dim arrBytes() As Byte
        arrBytes = GetSubBytes(word, 4, 3)
        Dim strLot = Me.converter.GetString(arrBytes)
        Return strLot ' return lot
    End Function

    Public Function ReadCarryOutUnit(ByVal word As Byte()) As String

        Dim arrBytes() As Byte
        arrBytes = converter.GetBytes("0")
        ConcatByte(arrBytes, GetSubBytes(word, 8, 2))
        Dim strUnit = Me.converter.GetString(arrBytes)
        Return strUnit ' return lot
    End Function

    Public Function WriteCarryOutStatus(ByVal line As Integer, ByVal status As Integer) As Byte()

        Dim CarryOutStatusWord(3) As Byte
        Dim logg As New Common.Logger

        'set iLineNo
        Dim iLineNo(0) As Integer
        iLineNo(0) = line
        OMRON.FinsGateway.PLCDataConverter.SystemIntegerToPLC2ByteAsBCD(iLineNo, CarryOutStatusWord, 0)

        'set status
        Dim iStatus(0) As Integer
        iStatus(0) = status
        OMRON.FinsGateway.PLCDataConverter.SystemIntegerToPLC2ByteAsBCD(iStatus, CarryOutStatusWord, 2)
        'CarryOutStatusWord(0) = CByte(line)
        'CarryOutStatusWord(1) = CByte(status)

        logg.LogByLine(line, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "WriteCarryOutStatus", _
                       "LineCode = " & BitConverter.ToString(GetSubBytes(CarryOutStatusWord, 0, 2)), "")
        logg.LogByLine(line, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "WriteCarryOutStatus", _
                       "Status = " & BitConverter.ToString(GetSubBytes(CarryOutStatusWord, 2, 2)), "")
        Return CarryOutStatusWord
    End Function

    Public Function WriteServerStatus(ByVal status As Integer) As Byte()

        Dim ServerStatusWord(1) As Byte
        Dim logg As New Common.Logger

        'set status
        Dim iStatus(0) As Integer
        iStatus(0) = status
        OMRON.FinsGateway.PLCDataConverter.SystemIntegerToPLC2ByteAsBCD(iStatus, ServerStatusWord, 0)

        'logg.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "WriteServerStatus", _
        '               "ServerStatus = " & BitConverter.ToString(GetSubBytes(ServerStatusWord, 1, 1)), "")

        Return ServerStatusWord

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
            Dim spaceByte() As Byte = converter.GetBytes(" ")
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
            Dim spaceByte() As Byte = converter.GetBytes(" ")
            For index As Integer = tempByte1.Count To length - 1
                ConcatByte(tempByte1, spaceByte)
            Next
            arrByte1 = tempByte1
        End If
    End Sub

    Public Function CheckLengthFillNull(ByVal input As String, ByVal length As Integer) As Byte()
        If input IsNot Nothing Then
            If input.Length > 0 Then
                Dim arrByte() As Byte = converter.GetBytes(input)
                FillZeroPrefix(arrByte, length - input.Length)
                Return arrByte
            Else
                Dim arrByte(length - 1) As Byte
                Return arrByte
            End If
        Else
            Dim arrByte(length - 1) As Byte
            Return arrByte
        End If
    End Function
#End Region

End Class
