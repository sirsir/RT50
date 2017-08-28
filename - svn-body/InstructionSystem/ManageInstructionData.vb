Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.SqlTypes
Imports Common


Public Class ManageInstructionData

    Dim dsDataSet1 As New DataSet1
    Dim taT_Production_DAT As New DataSet1TableAdapters.T_Production_DATTableAdapter
    Dim taT_Instruction_DAT As New DataSet1TableAdapters.T_Instruction_DATTableAdapter
    Dim taT_Line_MST As New DataSet1TableAdapters.T_Line_MSTTableAdapter
    Dim logger As New Logger
    Dim m_arrInstRow() As DataSet1.T_Instruction_DATRow
    Dim m_dtAllLine As New DataSet1.T_Line_MSTDataTable
    Dim dtIns As New DataSet1.T_Instruction_DATDataTable



    '******** Use for Addition Insert ************
    Public Function InsertProductionRowToInstruction(ByVal primaryKeyValueList As ArrayList) As Integer
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "InsertProductionRowToInstruction", "Start", "")
        Try
            taT_Production_DAT.FillByPrimaryKey(dsDataSet1.T_Production_DAT, primaryKeyValueList(0).ToString(), _
                                                                  primaryKeyValueList(1).ToString(), _
                                                                    primaryKeyValueList(2).ToString(), _
                                                                    primaryKeyValueList(3).ToString())

            Dim drProd As DataSet1.T_Production_DATRow = dsDataSet1.T_Production_DAT.Rows(0)

            Dim lineIndex As Integer = 0
            Dim strProd As String
            Dim strInst As String
            Dim strLine As String

            GetLineMasterByType(drProd.YChassisFlag)

            For Each drLine As DataSet1.T_Line_MSTRow In dsDataSet1.T_Line_MST

                strProd = "MODEL"
                strProd += Format(drLine.LineCode, "0#")
                Dim drInst As DataSet1.T_Instruction_DATRow = dsDataSet1.T_Instruction_DAT.NewRow
                drInst.SeqNo = drProd.SeqNo
                drInst.ModelYear = drProd.ModelYear
                drInst.SuffixCode = drProd.SuffixCode
                drInst.LotID = drProd.LotID
                drInst.LotNo = drProd.LotNo
                drInst.Unit = drProd.Unit
                drInst.BlockModel = drProd.BlockModel
                drInst.BlockSeq = drProd.BlockSeq
                drInst.MARK = drProd.MARK
                drInst.ProductionDate = drProd.ProductionDate
                drInst.ProductionTime = drProd.ProductionTime
                drInst.ImportCode = drProd.ImportCode
                drInst.YChassisFlag = drProd.YChassisFlag
                drInst.GAShop = drProd.GAShop
                drInst.HanmmerYears = drProd.HanmmerYears

                For partIndex As Integer = 1 To 5
                    strInst = "ASM"
                    strInst += Format(partIndex, "0#")
                    strLine = "Part"
                    strLine += partIndex.ToString
                    If drLine(strLine) <> Nothing Then
                        If CBool(drLine(strLine)) Then
                            drInst(strInst) = drProd(strProd + strInst).ToString
                        Else
                            drInst(strInst) = ""
                        End If
                    Else
                        drInst(strInst) = ""
                    End If
                Next

                drInst.XchgFlag = drProd.XchgFlag
                drInst.Line_No = drLine.LineCode

                If Not drProd.IsSubSeqNull() Then
                    drInst.SubSeq = drProd.SubSeq
                End If

                drInst.InsPassFlag = False
                drInst.CarrPassFlag = False



                dsDataSet1.T_Instruction_DAT.Rows.Add(drInst)
            Next

            Dim intResult As Integer = taT_Instruction_DAT.Update(dsDataSet1.T_Instruction_DAT)
            logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "InsertProductionRowToInstruction", "Success", "")
            Return intResult
        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "InsertProductionRowToInstruction", ex.Message, "")
            'Return 0
            Throw ex
        End Try
    End Function


    '********************* Use for Edit, Skip *******************
    Public Function UpdateProductionRowToInstruction(ByVal modelYear As String, ByVal suffixCode As String, _
                                                         ByVal lotNo As String, ByVal Unit As String) As Integer
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "UpdateProductionRowToInstruction", "Start", "")
        Try

            taT_Production_DAT.FillByPrimaryKey(dsDataSet1.T_Production_DAT, modelYear, suffixCode, lotNo, Unit)

            Dim drProd As DataSet1.T_Production_DATRow = dsDataSet1.T_Production_DAT.Rows(0)

            GetLineMasterByType(dsDataSet1.T_Production_DAT(0).YChassisFlag)

            Dim lineIndex As Integer = 0
            Dim strProd As String
            Dim strInst As String
            Dim strLine As String

            taT_Instruction_DAT.FillByModelYearSuffixCodeLotNoUnit(dsDataSet1.T_Instruction_DAT, _
                                                                   modelYear, suffixCode, lotNo, Unit)

            For Each drLine As DataSet1.T_Line_MSTRow In dsDataSet1.T_Line_MST

                strProd = "MODEL"
                strProd += Format(drLine.LineCode, "0#")
                Dim drInst As DataSet1.T_Instruction_DATRow = dsDataSet1.T_Instruction_DAT.FindByModelYearSuffixCodeLotNoUnitLine_No _
                                                        (modelYear, suffixCode, lotNo, Unit, drLine.LineCode)
                drInst.SeqNo = drProd.SeqNo
                drInst.ModelYear = drProd.ModelYear
                drInst.SuffixCode = drProd.SuffixCode
                drInst.LotID = drProd.LotID
                drInst.LotNo = drProd.LotNo
                drInst.Unit = drProd.Unit
                drInst.BlockModel = drProd.BlockModel
                drInst.BlockSeq = drProd.BlockSeq
                drInst.MARK = drProd.MARK
                drInst.ProductionDate = drProd.ProductionDate
                drInst.ProductionTime = drProd.ProductionTime
                drInst.ImportCode = drProd.ImportCode
                drInst.YChassisFlag = drProd.YChassisFlag
                drInst.GAShop = drProd.GAShop
                drInst.HanmmerYears = drProd.HanmmerYears

                For partIndex As Integer = 1 To 5
                    strInst = "ASM"
                    strInst += Format(partIndex, "0#")
                    strLine = "Part"
                    strLine += partIndex.ToString
                    If drLine(strLine) <> Nothing Then
                        If CBool(drLine(strLine)) Then
                            drInst(strInst) = drProd(strProd + strInst).ToString
                        Else
                            drInst(strInst) = ""
                        End If
                    Else
                        drInst(strInst) = ""
                    End If
                Next

                If Not drProd.IsSubSeqNull() Then
                    drInst.SubSeq = drProd.SubSeq
                End If

                drInst.XchgFlag = drProd.XchgFlag
                drInst.Line_No = drLine.LineCode

            Next

            Dim intResult As Integer = taT_Instruction_DAT.Update(dsDataSet1.T_Instruction_DAT)
            logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "UpdateProductionRowToInstruction", "Success", "")
            Return intResult
        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "UpdateProductionRowToInstruction", ex.Message, "")
            'Return 0
            Throw ex
        End Try
    End Function


    '********************* Use for InspOut *******************
    Public Function UpdateProductionRowToInstructionForInspOut(ByVal drProd As DataSet1.T_Production_DATRow) As Integer
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "UpdateProductionRowToInstruction", "Start", "")
        Try

            'Only MainLine
            GetMainLineByType(drProd.YChassisFlag)

            Dim lineIndex As Integer = 0
            Dim strProd As String
            Dim strInst As String
            Dim strLine As String

            taT_Instruction_DAT.FillByModelYearSuffixCodeLotNoUnit(dsDataSet1.T_Instruction_DAT, _
                                                                   drProd.ModelYear, drProd.SuffixCode, drProd.LotNo, drProd.Unit)

            For Each drLine As DataSet1.T_Line_MSTRow In dsDataSet1.T_Line_MST

                strProd = "MODEL"
                strProd += Format(drLine.LineCode, "0#")
                Dim drInst As DataSet1.T_Instruction_DATRow = dsDataSet1.T_Instruction_DAT.FindByModelYearSuffixCodeLotNoUnitLine_No _
                                                        (drProd.ModelYear, drProd.SuffixCode, drProd.LotNo, drProd.Unit, drLine.LineCode)
                drInst.SeqNo = drProd.SeqNo
                drInst.ModelYear = drProd.ModelYear
                drInst.SuffixCode = drProd.SuffixCode
                drInst.LotID = drProd.LotID
                drInst.LotNo = drProd.LotNo
                drInst.Unit = drProd.Unit
                drInst.BlockModel = drProd.BlockModel
                drInst.BlockSeq = drProd.BlockSeq
                drInst.MARK = drProd.MARK
                drInst.ProductionDate = drProd.ProductionDate
                drInst.ProductionTime = drProd.ProductionTime
                drInst.ImportCode = drProd.ImportCode
                drInst.YChassisFlag = drProd.YChassisFlag
                drInst.GAShop = drProd.GAShop
                drInst.HanmmerYears = drProd.HanmmerYears

                For partIndex As Integer = 1 To 5
                    strInst = "ASM"
                    strInst += Format(partIndex, "0#")
                    strLine = "Part"
                    strLine += partIndex.ToString
                    If drLine(strLine) <> Nothing Then
                        If CBool(drLine(strLine)) Then
                            drInst(strInst) = drProd(strProd + strInst).ToString
                        Else
                            drInst(strInst) = ""
                        End If
                    Else
                        drInst(strInst) = ""
                    End If
                Next

                If Not drProd.IsSubSeqNull() Then
                    drInst.SubSeq = drProd.SubSeq
                End If

                drInst.XchgFlag = drProd.XchgFlag
                drInst.Line_No = drLine.LineCode

            Next

            Dim intResult As Integer = taT_Instruction_DAT.Update(dsDataSet1.T_Instruction_DAT)
            logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "UpdateProductionRowToInstruction", "Success", "")
            Return intResult
        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "UpdateProductionRowToInstruction", ex.Message, "")
            Return 0
        End Try
    End Function


    '************** Use for Insert *********************
    Public Function UpdateProductionRowToInstructionForInsert(ByVal drProd As DataSet1.T_Production_DATRow) As Integer
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "UpdateProductionRowToInstructionForInsert", "Start", "")
        Try
            
            '----------------Assuming already call by DESC SK method---------------
            taT_Instruction_DAT.FillAllByModelYearSuffixCodeLotNoUnit(dtIns, drProd.ModelYear, drProd.SuffixCode, _
                                                                   drProd.LotNo, drProd.Unit)
            For Each drInst As DataSet1.T_Instruction_DATRow In dtIns
                drInst.ProductionDate = drProd.ProductionDate
                drInst.ProductionTime = drProd.ProductionTime
                drInst.SeqNo = drProd.SeqNo
                drInst.SubSeq = drProd.SubSeq
                'drInst.XchgFlag = drProd.XchgFlag.Substring(0, 2)
                CopySubString(drInst.XchgFlag, 0, drProd.XchgFlag, 0, 2)
            Next

            '-----------End of Assuming already call by DESC SK method-------------
            '----------------------------------------------------------------------


            Dim intResult As Integer = taT_Instruction_DAT.Update(dtIns)

            logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "UpdateProductionRowToInstructionForInsert", "Success", "")
            Return intResult
        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "UpdateProductionRowToInstructionForInsert", ex.Message, "")
            Throw ex
            'Return 0
        End Try
    End Function

    Public Function UpdateSkFromProductionRowToInstruction(ByVal drProd As DataSet1.T_Production_DATRow) As Integer
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "UpdateSkFromProductionRowToInstruction", "Start", "")
        Try
            'Dim originalDT As New DataSet1.T_Instruction_DATDataTable
            'Dim insDta As New DataSet1TableAdapters.T_Instruction_DATTableAdapter

            '----------------Assuming already call by DESC SK method---------------
            'Dim dtIns As New DataSet1.T_Instruction_DATDataTable
            taT_Instruction_DAT.FillAllByModelYearSuffixCodeLotNoUnit(dtIns, drProd.ModelYear, drProd.SuffixCode, _
                                                                   drProd.LotNo, drProd.Unit)
            For Each drInst As DataSet1.T_Instruction_DATRow In dtIns
                drInst.ProductionDate = drProd.ProductionDate
                drInst.ProductionTime = drProd.ProductionTime
                drInst.SeqNo = drProd.SeqNo
                drInst.SubSeq = drProd.SubSeq
            Next
            '-----------End of Assuming already call by DESC SK method-------------
            '----------------------------------------------------------------------


            Dim intResult As Integer = taT_Instruction_DAT.Update(dtIns)

            logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "UpdateSkFromProductionRowToInstruction", "Success", "")
            Return intResult
        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "UpdateSkFromProductionRowToInstruction", ex.Message, "")
            Return 0
        End Try
    End Function

    Private Sub CopySubString(ByRef into As String, ByVal intoPos As Integer, ByVal copyFrom As String, ByVal fromPos As Integer, ByVal length As Integer)
        Dim strTemp1 As String = ""
        Dim strTemp2 As String = ""
        Dim strTemp3 As String = ""


        If (intoPos + length <= into.Length) And (fromPos + length <= copyFrom.Length) Then
            strTemp1 = into.Substring(0, intoPos)
            strTemp2 = copyFrom.Substring(fromPos, length)
            strTemp3 = into.Substring(intoPos + length)
            into = strTemp1 & strTemp2 & strTemp3
        Else
            MessageBox.Show("Invalid input for function CopySubString, please check length of input string")
        End If

    End Sub
    


    '********************* Use for InspIn *******************
    Public Function UpdateProductionRowToInstructionForInspIN(ByVal modelYear As String, ByVal suffixCode As String, _
                                                         ByVal lotNo As String, ByVal Unit As String, ByVal newDetail As String()) As Integer
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "UpdateProductionRowToInstructionForInspIN", "Start", "")
        Try
            taT_Production_DAT.FillByPrimaryKey(dsDataSet1.T_Production_DAT, modelYear, suffixCode, lotNo, Unit)

            Dim drProd As DataSet1.T_Production_DATRow = dsDataSet1.T_Production_DAT.Rows(0)

            '*********************************************
            'Get All Line for Reorder SubSeq
            GetLineMaster()
            For Each drLine As DataSet1.T_Line_MSTRow In m_dtAllLine
                'Reorder subSeq in Instruction on each line
                Dim originalDT As New DataSet1.T_Instruction_DATDataTable
                Dim insDta As New DataSet1TableAdapters.T_Instruction_DATTableAdapter
                insDta.FillByLineNoSeqNoProdDate(originalDT, drLine.LineCode, drProd.SeqNo, drProd.ProductionDate)

                For i As Integer = originalDT.Count - 1 To 0 Step -1

                    If originalDT(i).SubSeq >= drProd.SubSeq Then
                        originalDT(i).SubSeq += 1

                        insDta.Update(originalDT(i))
                    End If
                Next
            Next
            '*********************************************

            'Get Only MainLine
            GetMainLineByType(drProd.YChassisFlag)

            taT_Instruction_DAT.FillByModelYearSuffixCodeLotNoUnit(dsDataSet1.T_Instruction_DAT, _
                                                                   modelYear, suffixCode, lotNo, Unit)

            For Each drLine As DataSet1.T_Line_MSTRow In dsDataSet1.T_Line_MST

                'strProd = "MODEL"
                'strProd += Format(drLine.LineCode, "0#")
                Dim drInst As DataSet1.T_Instruction_DATRow = dsDataSet1.T_Instruction_DAT.FindByModelYearSuffixCodeLotNoUnitLine_No _
                                                        (modelYear, suffixCode, lotNo, Unit, drLine.LineCode)
                'drInst.SeqNo = drProd.SeqNo
                'drInst.ModelYear = drProd.ModelYear
                'drInst.SuffixCode = drProd.SuffixCode
                'drInst.LotID = drProd.LotID
                'drInst.LotNo = drProd.LotNo
                'drInst.Unit = drProd.Unit
                'drInst.BlockModel = drProd.BlockModel
                'drInst.BlockSeq = drProd.BlockSeq
                'drInst.MARK = drProd.MARK
                'drInst.ProductionDate = drProd.ProductionDate
                'drInst.ProductionTime = drProd.ProductionTime
                'drInst.ImportCode = drProd.ImportCode
                'drInst.YChassisFlag = drProd.YChassisFlag
                'drInst.GAShop = drProd.GAShop
                'drInst.HanmmerYears = drProd.HanmmerYears

                'For partIndex As Integer = 1 To 5
                '    strInst = "ASM"
                '    strInst += Format(partIndex, "0#")
                '    strLine = "Part"
                '    strLine += partIndex.ToString
                '    If drLine(strLine) <> Nothing Then
                '        If CBool(drLine(strLine)) Then
                '            drInst(strInst) = drProd(strProd + strInst).ToString
                '        Else
                '            drInst(strInst) = ""
                '        End If
                '    Else
                '        drInst(strInst) = ""
                '    End If
                'Next

                'drInst.XchgFlag = drProd.XchgFlag
                'drInst.Line_No = drLine.LineCode

                'If Not drProd.IsSubSeqNull() Then
                '    drInst.SubSeq = drProd.SubSeq
                'End If

                '''''''''''''''''''''''''''''''''''''''''

                'reOrderSubseq(lineIndex, newDetail(0), newDetail(1))
                drInst.SeqNo = newDetail(0)
                drInst.SubSeq = newDetail(1)
                drInst.ProductionDate = newDetail(2)
                drInst.ProductionTime = newDetail(3)
                drInst.XchgFlag = "0002"
                drInst.InsResult = SqlDateTime.Null
                drInst.CarrResult = SqlDateTime.Null

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Next

            Dim intResult As Integer = taT_Instruction_DAT.Update(dsDataSet1.T_Instruction_DAT)

            logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "UpdateProductionRowToInstructionForInspIN", "Success", "")
            Return intResult
        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "UpdateProductionRowToInstructionForInspIN", ex.Message, "")
            Return 0
        End Try
    End Function


    '*********** use for get all online Line from ychassisFlag ************
    Private Sub GetLineMasterByType(ByVal yChassisFlag As String)

        If yChassisFlag = "" Or yChassisFlag = "0" Then 'ALL
            taT_Line_MST.FillAllByOnline(dsDataSet1.T_Line_MST)
        ElseIf yChassisFlag = "1" Or yChassisFlag = "2" Then 'CAB
            taT_Line_MST.FillAllByType(dsDataSet1.T_Line_MST, 1)
        ElseIf yChassisFlag = "3" Then 'PUBX
            taT_Line_MST.FillAllByType(dsDataSet1.T_Line_MST, 2)
            'Else
            '    taT_Line_MST.FillAllByOnline(dsDataSet1.T_Line_MST)
        End If

    End Sub

    '*********** use for get only MainLine from ychassisFlag ************
    Private Sub GetMainLineByType(ByVal yChassisFlag As String)

        If yChassisFlag = "" Or yChassisFlag = "0" Then 'ALL
            taT_Line_MST.FillAllMainLineByOnLine(dsDataSet1.T_Line_MST)
        ElseIf yChassisFlag = "1" Or yChassisFlag = "2" Then 'CAB
            taT_Line_MST.FillMainLineByType(dsDataSet1.T_Line_MST, 1)
        ElseIf yChassisFlag = "3" Then 'PUBX
            taT_Line_MST.FillMainLineByType(dsDataSet1.T_Line_MST, 2)
            'Else
            '    taT_Line_MST.FillAllMainLineByOnLine(dsDataSet1.T_Line_MST)
        End If

    End Sub

    '*********** use for get all online Line from ychassisFlag ************
    Private Sub GetLineMaster()

        taT_Line_MST.FillAllByOnline(m_dtAllLine)

    End Sub


End Class
