Imports Common

Public Class Insert
    Dim logger As Logger = New Logger()
    Dim m_taProd As New DataSet1TableAdapters.T_Production_DATTableAdapter
    'Dim m_arrProdRow() As DataSet1.T_Production_DATRow
    Dim manageInstructData As New ManageInstructionData
    Dim taProd As New DataSet1TableAdapters.T_Production_DATTableAdapter


    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.Close()
    End Sub

    Private Sub Insert_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnCancel_Click", "Close Insert Screen", "")
        Try
            Dim prodDate As String = ""
            Dim prodTime As String = ""
            Dim seqNo As String = ""
            Dim subSeq As Integer = 0

            prodDate = ProductionData.datagridPdata.Item(12, 0).Value
            prodTime = ProductionData.datagridPdata.Item(13, 0).Value
            seqNo = ProductionData.datagridPdata.Item(1, 0).Value
            subSeq = ProductionData.datagridPdata.Item(2, 0).Value

            ProductionData.ReloadData(prodDate, prodTime, seqNo, subSeq)
            ProductionData.Show()
            Me.Dispose()
        Catch ex As Exception
            ProductionData.Show()
            Me.Dispose()
        End Try

    End Sub

    Private Sub Insert_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "Insert_Load", "Load Insert Screen", "")
        'TODO: This line of code loads data into the 'DataSet1.T_Production_DAT' table. You can move, or remove it, as needed.
        Try

            Dim taProd As New DataSet1TableAdapters.T_Production_DATTableAdapter
            Dim dt As New DataSet1.T_Production_DATDataTable
            Dim offsetBase As Integer = 0

            'Get all skip data to Insert holding area
            dt = taProd.GetAllSkipData

            For Each dr As DataSet1.T_Production_DATRow In dt
                offsetBase += 1
                dr.indexNo = offsetBase
            Next

            Me.DataGridInsertData.DataSource = dt

            If dt.Rows.Count > 0 Then
                Me.btnOk.Enabled = True
                Me.btnDelete.Enabled = True
            Else
                ClearLabelAndDisableButton()
            End If
        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "Insert_Load", ex.Message, "")
        End Try

    End Sub

    Private Sub ClearLabelAndDisableButton()
        Me.lblValue.Text = ""

        Me.btnOk.Enabled = False
        Me.btnDelete.Enabled = False
    End Sub

    Private Sub ShowLabel(ByVal activeRowIndex As Integer)
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "ShowLabel", "Start", "")
        Try
            If Me.rdbLotBlock.Checked Then
                logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "ShowLabel", "Radio By Lot Block Checked", "")
                If Me.DataGridInsertData.Item(9, activeRowIndex).Value.ToString = "" Then

                    logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "ShowLabel", "Set Label By Model and Lot", "")
                    Me.lblLabel.Text = "ModelCode"
                    Me.lblValue.Text = Me.DataGridInsertData.Item(4, activeRowIndex).Value.ToString + Me.DataGridInsertData.Item(5, activeRowIndex).Value.ToString
                    Me.lblLabel2.Text = "Lot No."
                    Me.lblValue2.Text = Me.DataGridInsertData.Item(7, activeRowIndex).Value.ToString
                Else

                    logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "ShowLabel", "Set Label By Block", "")
                    Me.lblLabel.Text = "BLOCK"
                    Me.lblValue.Text = Me.DataGridInsertData.Item(9, activeRowIndex).Value.ToString
                    Me.lblLabel2.Text = ""
                    Me.lblValue2.Text = ""
                End If

            End If

            If Me.rdbSelectedPart.Checked Then
                logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "ShowLabel", "Radio By Part Checked", "")
                Me.lblLabel.Text = "ModelCode"
                Me.lblValue.Text = Me.DataGridInsertData.Item(4, activeRowIndex).Value.ToString + Me.DataGridInsertData.Item(5, activeRowIndex).Value.ToString
                Me.lblLabel2.Text = "Lot No. "
                Me.lblValue2.Text = Me.DataGridInsertData.Item(7, activeRowIndex).Value.ToString
                Me.lblValue2.Text = Me.lblValue2.Text & "  UNIT "
                Me.lblValue2.Text = Me.lblValue2.Text & Me.DataGridInsertData.Item(8, activeRowIndex).Value.ToString
            End If

        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "ShowLabel", ex.StackTrace, "")
        End Try

        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "ShowLabel", "End", "")
    End Sub


    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnDelete_Click", "Click Delete Button", "")
        Try
            Dim ind As String = Me.DataGridInsertData.CurrentRow.Cells(0).Value

            If MessageBox.Show("Do want to delete it?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.OK Then

                Dim result As Integer
                Dim activeRowIndex As Integer = Me.DataGridInsertData.CurrentCell.RowIndex
                Dim ta As New DataSet1TableAdapters.T_Production_DATTableAdapter
                Dim taIns As New DataSet1TableAdapters.T_Instruction_DATTableAdapter
                Dim seqNo As String = ""

                If rdbLotBlock.Checked = True Then

                    Dim strModelYear As String
                    Dim strSuffixCode As String
                    Dim strBlock As String
                    Dim strLotNo As String

                    strModelYear = Me.DataGridInsertData.Item(4, activeRowIndex).Value.ToString  'modelYear
                    strSuffixCode = Me.DataGridInsertData.Item(5, activeRowIndex).Value.ToString  'suffixCode
                    strBlock = Me.DataGridInsertData.Item(9, activeRowIndex).Value.ToString  'block
                    strLotNo = Me.DataGridInsertData.Item(7, activeRowIndex).Value.ToString  'lot no

                    If strBlock <> "" Then
                        result = ta.DeleteBySkipBlockModel(strBlock)
                        If result > 0 Then
                            result = 0
                            result = taIns.DeleteBySkipBlockModel(strBlock)
                        End If

                    Else
                        result = ta.DeleteBySkipModelYearSuffixLotNo(strModelYear, strSuffixCode, strLotNo)
                        If result > 0 Then
                            result = 0
                            result = taIns.DeleteBySkipModelYearSuffixLotNo(strModelYear, strSuffixCode, strLotNo)
                        End If
                    End If

                End If

                If rdbSelectedPart.Checked = True Then

                    Dim modelYear As String
                    Dim suffixCode As String
                    Dim lotNo As String
                    Dim unit As String

                    modelYear = Me.DataGridInsertData.Item(4, activeRowIndex).Value 'model year
                    suffixCode = Me.DataGridInsertData.Item(5, activeRowIndex).Value 'suffix code
                    lotNo = Me.DataGridInsertData.Item(7, activeRowIndex).Value 'lot no
                    unit = Me.DataGridInsertData.Item(8, activeRowIndex).Value 'unit

                    result = ta.DeleteByPrimaryKey(modelYear, suffixCode, lotNo, unit)

                    If result > 0 Then
                        result = 0
                        result = taIns.DeleteByPrimaryKey(modelYear, suffixCode, lotNo, unit)
                    End If

                End If

                If result > 0 Then 'successful deleted then RELOAD data

                    Dim logMSG As String
                    logMSG = "Production data " & Me.lblLabel.Text & " " & Me.lblValue.Text & " " & Me.lblLabel2.Text & Me.lblValue2.Text & " deleted."

                    'Write Log
                    Dim logger As TLogDat
                    logger = New TLogDat
                    logger.InsertNewLog(TLogDat.LOG_TYPE_OPERATION, TLogDat.LogLevel.NormalLog, My.Computer.Name, Now, logMSG, Nothing)

                    Insert_Load(sender, e)

                End If

                logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnOK_Click", "Delete Success", "")
            End If
        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "btnDelete_Click", ex.StackTrace, "")
        End Try
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnOK_Click", "End", "")
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnOK_Click", "Click OK Button", "")
        Try
            Dim activeRowProd As Integer = 0

            Dim dtDgP As DataSet1.T_Production_DATDataTable = ProductionData.datagridPdata.DataSource
            Dim dtDgI As DataSet1.T_Production_DATDataTable = DataGridInsertData.DataSource

            Dim pDt As New DataSet1.T_Production_DATDataTable
            Dim manageInstructData As New ManageInstructionData

            Dim prodDate As String = ""
            Dim prodTime As String = ""
            Dim seqNo As String = ""
            Dim subSeq As Integer = 0

            If dtDgI.Count > 0 Then 'Have row for select to Insert

                Dim activeRowInsert As Integer = Me.DataGridInsertData.CurrentCell.RowIndex
                Dim drDgI As DataSet1.T_Production_DATRow = dtDgI.Rows(activeRowInsert)
                Dim strModelYear As String = drDgI.ModelYear
                Dim strSuffixCode As String = drDgI.SuffixCode
                Dim strBlock As String = drDgI.BlockModel
                Dim strLotNo As String = drDgI.LotNo
                Dim strUnit As String = drDgI.Unit

                If dtDgP.Rows.Count = 0 Then
                    'case no row in production tbl, just change the xchange flag to Inserted
                    Try
                        Using ts As New TransactionScope
                            If rdbLotBlock.Checked = True Then

                                If strBlock <> "" Then
                                    pDt = taProd.GetSkipDataByBlockModel(strBlock)
                                Else
                                    pDt = taProd.GetSkipDataByModelYearSuffixLotNo(strModelYear, strSuffixCode, strLotNo)
                                End If

                                For Each aDR As DataSet1.T_Production_DATRow In pDt
                                    aDR.XchgFlag = "2" + aDR.XchgFlag.Substring(1, 3)
                                Next

                                taProd.Update(pDt)

                                For Each aDR As DataSet1.T_Production_DATRow In pDt.Rows
                                    manageInstructData.UpdateProductionRowToInstructionForInsert(aDR)
                                Next

                            ElseIf rdbSelectedPart.Checked = True Then

                                drDgI = dtDgI.Rows(activeRowInsert)
                                drDgI.XchgFlag = "2" + drDgI.XchgFlag.Substring(1, 3)

                                'TODO check update again ??????
                                manageInstructData.UpdateProductionRowToInstructionForInsert(drDgI)

                            End If
                            ts.Complete()
                        End Using
                    Catch ex As Exception
                        logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "btnOK_Click", ex.Message, "")
                        MessageBox.Show("Insert Fail", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                Else
                    'case productiondata row > 0

                    Try
                        Using ts As New TransactionScope
                            activeRowProd = ProductionData.datagridPdata.CurrentCell.RowIndex
                            Dim indexNo As Integer = 0
                            indexNo = ProductionData.datagridPdata.Item(0, activeRowProd).Value

                            Dim dtProd As DataSet1.T_Production_DATDataTable = ProductionData.datagridPdata.DataSource
                            'Selected Row
                            Dim drProd As DataSet1.T_Production_DATRow = dtProd.Rows(activeRowProd)
                            prodDate = drProd.ProductionDate
                            prodTime = drProd.ProductionTime
                            seqNo = drProd.SeqNo
                            subSeq = drProd.SubSeq

                            activeRowInsert = Me.DataGridInsertData.CurrentCell.RowIndex

                            If ProductionData.datagridPdata.Item(121, activeRowProd).Value > 0 Then 'check instruct flag
                                MessageBox.Show("Cannot insert at instructed area.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Else

                                If activeRowProd <> 0 Then

                                    'Base row
                                    Dim drBaseProd As DataSet1.T_Production_DATRow = dtProd.Rows(activeRowProd - 1)

                                    If rdbLotBlock.Checked = True Then
                                        If strBlock <> "" Then
                                            pDt = taProd.GetSkipDataByBlockModel(strBlock)
                                            InsertAndRenumberByBlock(drBaseProd, pDt)
                                        Else
                                            pDt = taProd.GetSkipDataByModelYearSuffixLotNo(strModelYear, strSuffixCode, strLotNo)
                                            InsertAndRenumberByLot(drBaseProd, pDt)
                                        End If


                                    ElseIf rdbSelectedPart.Checked = True Then
                                        pDt = DataGridInsertData.DataSource
                                        Dim iDr As DataSet1.T_Production_DATRow = pDt.Rows(activeRowInsert)

                                        InsertAndRenumber(drBaseProd, iDr)

                                    End If

                                Else 'insert at first row of page

                                    If indexNo = 1 Then 'First record
                                        drProd.SeqNo = "00000"
                                        drProd.SubSeq = 0
                                        'Dim dtTempP As New DataSet1.T_Production_DATDataTable
                                        'Dim drNew As DataSet1.T_Production_DATRow = dtTempP.NewRow
                                        'For id As Integer = 0 To drProd.ItemArray.Length - 1
                                        '    drNew.Item(id) = drProd.Item(id)
                                        'Next
                                        'drNew.SeqNo = "00000"
                                        'drNew.SubSeq = -1
                                        'drNew.ProductionDate = drProd.ProductionDate
                                        'drNew.ProductionTime = drProd.ProductionTime
                                        'taProd.Update(drNew)

                                        If rdbLotBlock.Checked = True Then
                                            If strBlock <> "" Then
                                                pDt = taProd.GetSkipDataByBlockModel(strBlock)
                                                InsertAndRenumberByBlock(drProd, pDt)
                                            Else
                                                pDt = taProd.GetSkipDataByModelYearSuffixLotNo(strModelYear, strSuffixCode, strLotNo)
                                                InsertAndRenumberByLot(drProd, pDt)
                                            End If

                                        ElseIf rdbSelectedPart.Checked = True Then
                                            pDt = DataGridInsertData.DataSource
                                            Dim iDr As DataSet1.T_Production_DATRow = pDt.Rows(activeRowInsert)

                                            InsertAndRenumber(drProd, iDr)

                                        End If
                                        'dtTempP.RemoveT_Production_DATRow(drNew)
                                        'taProd.Update(drNew)
                                    Else 'first row but not first record

                                        'Get Previous record (Base)
                                        dtProd = taProd.GetDataByPreviousBtn(0, prodDate, prodTime, seqNo, subSeq)
                                        Dim drBaseProd As DataSet1.T_Production_DATRow = dtProd.Rows(0)

                                        If rdbLotBlock.Checked = True Then
                                            If strBlock <> "" Then
                                                pDt = taProd.GetSkipDataByBlockModel(strBlock)
                                                InsertAndRenumberByBlock(drProd, pDt)
                                            Else
                                                pDt = taProd.GetSkipDataByModelYearSuffixLotNo(strModelYear, strSuffixCode, strLotNo)
                                                InsertAndRenumberByLot(drProd, pDt)
                                            End If

                                        ElseIf rdbSelectedPart.Checked = True Then
                                            pDt = DataGridInsertData.DataSource
                                            Dim iDr As DataSet1.T_Production_DATRow = pDt.Rows(activeRowInsert)

                                            InsertAndRenumber(drBaseProd, iDr)

                                        End If

                                    End If

                                End If
                                '--------------------------------------------------------------

                            End If
                            ts.Complete()
                        End Using
                    Catch ex As Exception
                        logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "btnOK_Click", ex.Message, "")
                        MessageBox.Show("Insert Fail", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try

                    'Reload Production Data
                    If activeRowProd > 0 Then
                        prodDate = ProductionData.datagridPdata.Item(12, activeRowProd - 1).Value
                        prodTime = ProductionData.datagridPdata.Item(13, activeRowProd - 1).Value
                        seqNo = ProductionData.datagridPdata.Item(1, activeRowProd - 1).Value
                        subSeq = ProductionData.datagridPdata.Item(2, activeRowProd - 1).Value
                    Else

                        Dim qDt As New DataSet1.T_Production_DATDataTable
                        qDt = taProd.GetDataByPreviousBtn(0, prodDate, prodTime, seqNo, subSeq)
                        If qDt.Count > 0 Then
                            prodDate = qDt(0).ProductionDate
                            prodTime = qDt(0).ProductionTime
                            seqNo = qDt(0).SeqNo
                            subSeq = qDt(0).SubSeq
                            ProductionData.Show()
                            ProductionData.ReloadData(prodDate, prodTime, seqNo, subSeq)
                        Else
                            ProductionData.Show()
                            ProductionData.ReloadData(prodDate, prodTime, seqNo, subSeq)
                        End If
                    End If

                    'ProductionData.Show()
                    'ProductionData.ReloadData(prodDate, prodTime, seqNo, subSeq)

                    Me.Dispose()

                End If

                logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnOK_Click", "End", "")
                ProductionData.Show()
                Me.Close()
            End If
        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "btnOK_Click", ex.StackTrace, "")
        End Try

    End Sub

    'Private Sub InsertAndRenumberByLotBlock(ByVal drActive As DataSet1.T_Production_DATRow, _
    '                              ByVal dtInsert As DataSet1.T_Production_DATDataTable)
    '    logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "InsertAndRenumberByLotBlock", "Start", "")
    '    Try
    '        Dim insertedRow As New DataSet1.T_Production_DATDataTable
    '        Dim arrDr() As DataSet1.T_Production_DATRow
    '        taProd.FillBySeqNoProductionDateTime(insertedRow, drActive.SeqNo, drActive.ProductionDate, drActive.ProductionTime)

    '        For i = insertedRow.Count - 1 To 0 Step -1
    '            If insertedRow(i).SubSeq > drActive.SubSeq Then
    '                insertedRow(i).SubSeq += dtInsert.Rows.Count

    '            End If
    '        Next
    '        taProd.Update(insertedRow)
    '        'arrDr = insertedRow.Select("", "ProductionDate DESC, ProductionTime DESC, SeqNo DESC, SubSeq DESC")
    '        'taProd.Update(arrDr)

    '        Dim intCount As Integer = dtInsert.Count
    '        Dim aDR As DataSet1.T_Production_DATRow

    '        For i = dtInsert.Count - 1 To 0 Step -1
    '            aDR = dtInsert.Rows(i)
    '            aDR.ProductionDate = drActive.ProductionDate
    '            aDR.ProductionTime = drActive.ProductionTime
    '            aDR.SeqNo = drActive.SeqNo
    '            aDR.XchgFlag = "2" + aDR.XchgFlag.Substring(1, 3)
    '            aDR.SubSeq = drActive.SubSeq + intCount
    '            intCount -= 1

    '        Next
    '        'm_arrProdRow = dtInsert.Select("", "ProductionDate DESC, ProductionTime DESC, SeqNo DESC, SubSeq DESC")
    '        taProd.Update(dtInsert)

    '        For i = 0 To dtInsert.Count - 1
    '            aDR = dtInsert.Rows(i)
    '            manageInstructData.UpdateProductionRowToInstructionForInsert(aDR)
    '        Next
    '        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "InsertAndRenumberByLotBlock", "Success", "")
    '    Catch ex As Exception
    '        logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "InsertAndRenumberByLotBlock", ex.StackTrace, "")
    '    End Try
    '    logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "InsertAndRenumberByLotBlock", "End", "")
    'End Sub

    Private Sub InsertAndRenumberByBlock(ByVal drActive As DataSet1.T_Production_DATRow, _
                                  ByVal dtInsert As DataSet1.T_Production_DATDataTable)
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "InsertAndRenumberByBlock", "Start", "")
        Try
            Dim insertedRow As New DataSet1.T_Production_DATDataTable
            Dim arrDr() As DataSet1.T_Production_DATRow
            Dim strBlockModel As String

            Dim dr As DataSet1.T_Production_DATRow = dtInsert.Rows(0)
            strBlockModel = dr.BlockModel

            taProd.FillBySeqNoProductionDateTime(insertedRow, drActive.SeqNo, drActive.ProductionDate, drActive.ProductionTime)

            For i = insertedRow.Count - 1 To 0 Step -1
                If insertedRow(i).SubSeq > drActive.SubSeq Then
                    insertedRow(i).SubSeq += dtInsert.Rows.Count
                    manageInstructData.UpdateSkFromProductionRowToInstruction(insertedRow(i))
                End If
            Next
            'taProd.Update(insertedRow)
            arrDr = insertedRow.Select("", "ProductionDate DESC, ProductionTime DESC, SeqNo DESC, SubSeq DESC")
            taProd.Update(arrDr)

            '---------Add to fix concurrency problem--------
            dtInsert = taProd.GetSkipDataByBlockModel(strBlockModel)

            Dim intCount As Integer = dtInsert.Count
            Dim aDR As DataSet1.T_Production_DATRow

            For i = dtInsert.Count - 1 To 0 Step -1
                aDR = dtInsert.Rows(i)
                aDR.ProductionDate = drActive.ProductionDate
                aDR.ProductionTime = drActive.ProductionTime
                aDR.SeqNo = drActive.SeqNo
                aDR.XchgFlag = "2" + aDR.XchgFlag.Substring(1, 3)
                aDR.SubSeq = drActive.SubSeq + intCount
                intCount -= 1
                manageInstructData.UpdateProductionRowToInstructionForInsert(aDR)
            Next
            arrDr = dtInsert.Select("", "ProductionDate DESC, ProductionTime DESC, SeqNo DESC, SubSeq DESC")
            taProd.Update(arrDr)

            'For i = dtInsert.Count - 1 To 0 Step -1
            '    aDR = dtInsert.Rows(i)
            '    manageInstructData.UpdateProductionRowToInstructionForInsert(aDR)
            'Next
            logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "InsertAndRenumberByBlock", "Success", "")
        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "InsertAndRenumberByBlock", ex.StackTrace, "")
            Throw ex
        End Try
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "InsertAndRenumberByBlock", "End", "")
    End Sub

    Private Sub InsertAndRenumberByLot(ByVal drActive As DataSet1.T_Production_DATRow, _
                                  ByVal dtInsert As DataSet1.T_Production_DATDataTable)
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "InsertAndRenumberByLot", "Start", "")
        Try
            Dim insertedRow As New DataSet1.T_Production_DATDataTable
            Dim arrDr() As DataSet1.T_Production_DATRow
            Dim strModelYear As String
            Dim strSuffixCode As String
            Dim strLotNo As String

            Dim dr As DataSet1.T_Production_DATRow = dtInsert.Rows(0)
            strModelYear = dr.ModelYear
            strSuffixCode = dr.SuffixCode
            strLotNo = dr.LotNo

            taProd.FillBySeqNoProductionDateTime(insertedRow, drActive.SeqNo, drActive.ProductionDate, drActive.ProductionTime)

            For i = insertedRow.Count - 1 To 0 Step -1
                If insertedRow(i).SubSeq > drActive.SubSeq Then
                    insertedRow(i).SubSeq += dtInsert.Rows.Count
                    manageInstructData.UpdateSkFromProductionRowToInstruction(insertedRow(i))
                End If
            Next
            'taProd.Update(insertedRow)
            arrDr = insertedRow.Select("", "ProductionDate DESC, ProductionTime DESC, SeqNo DESC, SubSeq DESC")
            taProd.Update(arrDr)

            '---------Add to fix concurrency problem--------
            dtInsert = taProd.GetSkipDataByModelYearSuffixLotNo(strModelYear, strSuffixCode, strLotNo)

            Dim intCount As Integer = dtInsert.Count
            Dim aDR As DataSet1.T_Production_DATRow

            For i = dtInsert.Count - 1 To 0 Step -1
                aDR = dtInsert.Rows(i)
                aDR.ProductionDate = drActive.ProductionDate
                aDR.ProductionTime = drActive.ProductionTime
                aDR.SeqNo = drActive.SeqNo
                aDR.XchgFlag = "2" + aDR.XchgFlag.Substring(1, 3)
                aDR.SubSeq = drActive.SubSeq + intCount
                intCount -= 1
                manageInstructData.UpdateProductionRowToInstructionForInsert(aDR)
            Next
            arrDr = dtInsert.Select("", "ProductionDate DESC, ProductionTime DESC, SeqNo DESC, SubSeq DESC")
            taProd.Update(arrDr)
            'taProd.Update(dtInsert)

            'For i = dtInsert.Count - 1 To 0 Step -1
            '    aDR = dtInsert.Rows(i)
            '    manageInstructData.UpdateProductionRowToInstructionForInsert(aDR)
            'Next
            logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "InsertAndRenumberByLot", "Success", "")
        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "InsertAndRenumberByLot", ex.StackTrace, "")
            Throw ex
        End Try
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "InsertAndRenumberByLot", "End", "")
    End Sub

    Private Sub InsertAndRenumber(ByVal drActive As DataSet1.T_Production_DATRow, _
                                  ByVal drInsert As DataSet1.T_Production_DATRow)

        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "InsertAndRenumber", "Start", "")
        Try
            Dim insertedRow As New DataSet1.T_Production_DATDataTable
            Dim arrDr() As DataSet1.T_Production_DATRow
            Dim strModelYear As String = drInsert.ModelYear
            Dim strSuffixCode As String = drInsert.SuffixCode
            Dim strLotNo As String = drInsert.LotNo
            Dim strUnit As String = drInsert.Unit

            taProd.FillBySeqNoProductionDateTime(insertedRow, drActive.SeqNo, drActive.ProductionDate, drActive.ProductionTime)

            For i = insertedRow.Count - 1 To 0 Step -1
                If insertedRow(i).SubSeq > drActive.SubSeq Then
                    insertedRow(i).SubSeq += 1
                    manageInstructData.UpdateSkFromProductionRowToInstruction(insertedRow(i))
                    'taProd.Update(insertedRow)
                End If
            Next
            arrDr = insertedRow.Select("", "ProductionDate DESC, ProductionTime DESC, SeqNo DESC, SubSeq DESC")
            taProd.Update(arrDr)

            Dim dt As DataSet1.T_Production_DATDataTable
            dt = taProd.GetDataByModelYearSuffixCodeLotNoUnitAllXchg(strModelYear, strSuffixCode, strLotNo, strUnit)
            drInsert = dt.Rows(0)

            drInsert.ProductionDate = drActive.ProductionDate
            drInsert.ProductionTime = drActive.ProductionTime
            drInsert.SeqNo = drActive.SeqNo
            drInsert.XchgFlag = "2" + drInsert.XchgFlag.Substring(1, 3)
            drInsert.SubSeq = drActive.SubSeq + 1
            manageInstructData.UpdateProductionRowToInstructionForInsert(drInsert)
            taProd.Update(drInsert)
            logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "InsertAndRenumber", "Production Update End", "")
            'manageInstructData.UpdateProductionRowToInstructionForInsert(drInsert)
            'logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "InsertAndRenumber", "Instruction Update End", "")
        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "InsertAndRenumber", ex.StackTrace, "")
            Throw ex
        End Try
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "InsertAndRenumber", "End", "")

    End Sub

    'Private Sub ManageDataToInsert(ByVal pkList As Object)

    '    Dim activeRowIndex As Integer = ProductionData.datagridPdata.CurrentCell.RowIndex

    '    Dim selectedSeqNo As String = ProductionData.datagridPdata.Item(1, activeRowIndex).Value.ToString()
    '    Dim selectedSub As String = ProductionData.datagridPdata.Item(2, activeRowIndex).Value.ToString()

    '    Dim indexNo As Integer = ProductionData.datagridPdata.Item(0, activeRowIndex).Value 'index No

    '    Dim prodDate As String = ProductionData.datagridPdata.Item(12, activeRowIndex).Value
    '    Dim prodTime As String = ProductionData.datagridPdata.Item(13, activeRowIndex).Value
    '    Dim seqNo As String = ProductionData.datagridPdata.Item(1, activeRowIndex).Value
    '    Dim subSeq As String = ProductionData.datagridPdata.Item(2, activeRowIndex).Value

    '    'MessageBox.Show(indexNo)

    '    Dim ta As New DataSet1TableAdapters.T_Production_DATTableAdapter
    '    Dim pDt As New DataSet1.T_Production_DATDataTable


    '    If activeRowIndex <> 0 Then
    '        'not the first record
    '        'pDt = ta.GetDataByAIndexNo(indexNo - 1)

    '        Dim baseSeqNo As String = ProductionData.datagridPdata.Item(1, activeRowIndex - 1).Value.ToString()
    '        Dim baseSub As String = ProductionData.datagridPdata.Item(2, activeRowIndex - 1).Value.ToString()
    '        Dim baseProdDate As String = ProductionData.datagridPdata.Item(12, activeRowIndex - 1).Value.ToString()
    '        Dim baseProdTime As String = ProductionData.datagridPdata.Item(13, activeRowIndex - 1).Value.ToString()

    '        'If baseSeqNo = selectedSeqNo Then 'insert between same seq

    '        InsertSeqAndSub.ReorderSubSeq(baseSeqNo, baseSub, baseProdDate) 'accumulate sub seq then have space for new insert

    '        'End If

    '        UpdateData(pkList, baseSeqNo, baseSub + 1, baseProdDate, baseProdTime)

    '    Else

    '        If indexNo = 1 Then 'First record
    '            Dim curProdDate As String = ProductionData.datagridPdata.Item(12, activeRowIndex).Value 'Prod Date
    '            Dim curProdTime As String = ProductionData.datagridPdata.Item(13, activeRowIndex).Value 'Prod Time

    '            Dim i As Integer = 0
    '            Dim dt As New DataSet1.T_Production_DATDataTable
    '            Me.T_Production_DATTableAdapter.FillBySeqNoIsZero(dt)

    '            For i = 0 To dt.Rows.Count - 1
    '                dt.Rows(i)("SubSeq") = dt.Rows(i)("SubSeq") + 1
    '            Next

    '            ta = New DataSet1TableAdapters.T_Production_DATTableAdapter()
    '            ta.Update(dt)

    '            UpdateData(pkList, "00000", 0, curProdDate, curProdTime)

    '        Else 'first row but not first record

    '            ta = New DataSet1TableAdapters.T_Production_DATTableAdapter
    '            pDt = New DataSet1.T_Production_DATDataTable

    '            pDt = ta.GetDataBySeqNo(selectedSeqNo)

    '            'MessageBox.Show(indexNo)
    '            'MessageBox.Show(pDt.Rows.Count)

    '            If pDt.Rows.Count > 1 Then

    '                'have 2 cases 
    '                Dim qDt As New DataSet1.T_Production_DATDataTable
    '                'qDt = ta.GetDataByAIndexNo(indexNo - 1)
    '                qDt = ta.GetDataByPrevSEQ_DESC(prodDate + prodTime + seqNo + subSeq)
    '                '(1)selected row is the first sub of seq group
    '                Dim baseSeqNo As String = qDt.Rows(0)("SeqNo").ToString()
    '                Dim baseSub As String = qDt.Rows(0)("SubSeq").ToString()
    '                Dim baseProdDate As String = qDt.Rows(0)("productionDate").ToString()
    '                Dim baseProdTime As String = qDt.Rows(0)("productionTime").ToString()


    '                InsertSeqAndSub.ReorderSubSeq(baseSeqNo, baseSub, baseProdDate) 'accumulate sub seq then have space for new insert
    '                UpdateData(pkList, baseSeqNo, baseSub + 1, baseProdDate, baseProdTime)


    '                '(2)selected row is in the middle of seq group
    '                'Dim baseProdDate As String
    '                'Dim baseProdTime As String
    '                'For Each aDR In pDt.Rows

    '                '    If aDR("subSeq") = (selectedSub - 1) Then '??????
    '                '        baseProdDate = aDR("prodDate")
    '                '        baseProdTime = aDR("prodTime")
    '                '    End If

    '                'Next


    '            Else
    '                '(3)
    '                Dim qDt As New DataSet1.T_Production_DATDataTable
    '                'qDt = ta.GetDataByAIndexNo(indexNo - 1)
    '                qDt = ta.GetDataByPrevSEQ_DESC(prodDate + prodTime + seqNo + subSeq)

    '                Dim baseSeqNo As String = qDt.Rows(0)("SeqNo").ToString()
    '                Dim baseSub As String = qDt.Rows(0)("SubSeq").ToString()
    '                Dim baseProdDate As String = qDt.Rows(0)("productionDate").ToString()
    '                Dim baseProdTime As String = qDt.Rows(0)("productionTime").ToString()


    '                InsertSeqAndSub.ReorderSubSeq(baseSeqNo, baseSub, baseProdDate) 'accumulate sub seq then have space for new insert
    '                UpdateData(pkList, baseSeqNo, baseSub + 1, baseProdDate, baseProdTime)


    '                'pDt = ta.GetDataBySeqNo(selectedSeqNo - 1)
    '                'UpdateData(pkList, selectedSeqNo, selectedSub, baseProdDate, baseProdTime)

    '            End If

    '        End If

    '    End If

    'End Sub


    'Private Sub UpdateData(ByVal pkList As Object, ByVal seqNo As String, ByVal subSeq As Integer, _
    '                       ByVal prodDate As String, ByVal prodTime As String)

    '    Try
    '        Dim ta As New DataSet1TableAdapters.T_Production_DATTableAdapter

    '        'pDt = ta.GetDataByPrimaryKey(pkList(0), pkList(1), pkList(2), pkList(3))
    '        'dr = pDt.Rows(0)

    '        'dr.Item("SeqNo") = seqNo
    '        'dr.Item("ProductionDate") = prodDate
    '        'dr.Item("ProductionTime") = prodTime
    '        'dr.Item("SubSeq") = subSeq
    '        'dr.Item("XchgFlag") = "2000" 'Flag for Insert record

    '        Dim result As Integer
    '        Try
    '            result = ta.UpdateDataForInsert(prodDate, prodTime, seqNo, subSeq, "2000", _
    '                                                     pkList(0), pkList(1), pkList(2), pkList(3))
    '        Catch ex As Exception
    '            MessageBox.Show("Insert Error.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        End Try

    '        Dim logMSG As String
    '        logMSG = "Production data " & Me.lblLabel.Text & " " & Me.lblValue.Text & " " & Me.lblLabel2.Text & Me.lblValue2.Text & " inserted."

    '        'Write Log
    '        Dim logger As TLogDat
    '        logger = New TLogDat
    '        logger.InsertNewLog(TLogDat.LOG_TYPE_OPERATION, TLogDat.LogLevel.NormalLog, My.Computer.Name, Now, logMSG, Nothing)
    '    Catch ex As Exception
    '        logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "UpdateData", ex.Message, "")
    '    End Try

    'End Sub

    Private Sub rdbLotBlock_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbLotBlock.CheckedChanged

        If Me.DataGridInsertData.RowCount > 0 Then
            Dim activeRowIndex As Integer = Me.DataGridInsertData.CurrentCell.RowIndex
            ShowLabel(activeRowIndex)
        Else
            ClearLabelAndDisableButton()
        End If

    End Sub

    Private Sub rdbSelectedPart_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbSelectedPart.CheckedChanged
        If Me.DataGridInsertData.RowCount > 0 Then
            Dim activeRowIndex As Integer = Me.DataGridInsertData.CurrentCell.RowIndex
            ShowLabel(activeRowIndex)
        Else
            ClearLabelAndDisableButton()
        End If

    End Sub


    Private Sub DataGridInsertData_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridInsertData.SelectionChanged
        If Me.DataGridInsertData.Rows.Count > 0 Then
            Dim activeRowIndex As Integer = Me.DataGridInsertData.CurrentCell.RowIndex
            ShowLabel(activeRowIndex)
        Else
            ClearLabelAndDisableButton()
        End If
    End Sub

    Private Sub Insert_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyData
            Case Keys.F1
                btnOk_Click(sender, e)
            Case Keys.F3
                btnDelete_Click(sender, e)
            Case Keys.F12
                btnCancel_Click(sender, e)
        End Select
    End Sub

    'Private Sub ManageDataToInsertForNewConcept(ByVal pkList As Object)

    '    Dim activeRowIndex As Integer = ProductionData.datagridPdata.CurrentCell.RowIndex

    '    Dim selectedSeqNo As String = ProductionData.datagridPdata.Item(1, activeRowIndex).Value.ToString()
    '    Dim selectedSub As String = ProductionData.datagridPdata.Item(2, activeRowIndex).Value.ToString()

    '    Dim indexNo As Integer = ProductionData.datagridPdata.Item(0, activeRowIndex).Value 'index No

    '    Dim prodDate As String = ProductionData.datagridPdata.Item(12, activeRowIndex).Value
    '    Dim prodTime As String = ProductionData.datagridPdata.Item(13, activeRowIndex).Value
    '    Dim seqNo As String = ProductionData.datagridPdata.Item(1, activeRowIndex).Value
    '    Dim subSeq As String = ProductionData.datagridPdata.Item(2, activeRowIndex).Value

    '    'MessageBox.Show(indexNo)

    '    Dim ta As New DataSet1TableAdapters.T_Production_DATTableAdapter
    '    Dim pDt As New DataSet1.T_Production_DATDataTable


    '    If activeRowIndex <> 0 Then
    '        'not the first record
    '        'pDt = ta.GetDataByAIndexNo(indexNo - 1)

    '        Dim baseSeqNo As String = ProductionData.datagridPdata.Item(1, activeRowIndex - 1).Value.ToString()
    '        Dim baseSub As String = ProductionData.datagridPdata.Item(2, activeRowIndex - 1).Value.ToString()
    '        Dim baseProdDate As String = ProductionData.datagridPdata.Item(12, activeRowIndex - 1).Value.ToString()
    '        Dim baseProdTime As String = ProductionData.datagridPdata.Item(13, activeRowIndex - 1).Value.ToString()

    '        'If baseSeqNo = selectedSeqNo Then 'insert between same seq

    '        'InsertSeqAndSub.ReorderSubSeq(baseSeqNo, baseSub, baseProdDate) 'accumulate sub seq then have space for new insert

    '        'End If

    '        UpdateData(pkList, baseSeqNo, baseSub + 1, baseProdDate, baseProdTime)

    '    Else

    '        If indexNo = 1 Then 'First record
    '            Dim curProdDate As String = ProductionData.datagridPdata.Item(12, activeRowIndex).Value 'Prod Date
    '            Dim curProdTime As String = ProductionData.datagridPdata.Item(13, activeRowIndex).Value 'Prod Time

    '            Dim i As Integer = 0
    '            Dim dt As New DataSet1.T_Production_DATDataTable
    '            Me.T_Production_DATTableAdapter.FillBySeqNoIsZero(dt)

    '            For i = 0 To dt.Rows.Count - 1
    '                dt.Rows(i)("SubSeq") = dt.Rows(i)("SubSeq") + 1
    '            Next

    '            ta = New DataSet1TableAdapters.T_Production_DATTableAdapter()
    '            ta.Update(dt)

    '            UpdateData(pkList, "00000", 0, curProdDate, curProdTime)

    '        Else 'first row but not first record

    '            ta = New DataSet1TableAdapters.T_Production_DATTableAdapter
    '            pDt = New DataSet1.T_Production_DATDataTable

    '            pDt = ta.GetDataBySeqNo(selectedSeqNo)

    '            'MessageBox.Show(indexNo)
    '            'MessageBox.Show(pDt.Rows.Count)

    '            If pDt.Rows.Count > 1 Then

    '                'have 2 cases 
    '                Dim qDt As New DataSet1.T_Production_DATDataTable
    '                'qDt = ta.GetDataByAIndexNo(indexNo - 1)
    '                qDt = ta.GetDataByPrevSEQ_DESC(prodDate + prodTime + seqNo + subSeq)
    '                '(1)selected row is the first sub of seq group
    '                Dim baseSeqNo As String = qDt.Rows(0)("SeqNo").ToString()
    '                Dim baseSub As String = qDt.Rows(0)("SubSeq").ToString()
    '                Dim baseProdDate As String = qDt.Rows(0)("productionDate").ToString()
    '                Dim baseProdTime As String = qDt.Rows(0)("productionTime").ToString()


    '                '       InsertSeqAndSub.ReorderSubSeq(baseSeqNo, baseSub, baseProdDate) 'accumulate sub seq then have space for new insert
    '                UpdateData(pkList, baseSeqNo, baseSub + 1, baseProdDate, baseProdTime)


    '                '(2)selected row is in the middle of seq group
    '                'Dim baseProdDate As String
    '                'Dim baseProdTime As String
    '                'For Each aDR In pDt.Rows

    '                '    If aDR("subSeq") = (selectedSub - 1) Then '??????
    '                '        baseProdDate = aDR("prodDate")
    '                '        baseProdTime = aDR("prodTime")
    '                '    End If

    '                'Next


    '            Else
    '                '(3)
    '                Dim qDt As New DataSet1.T_Production_DATDataTable
    '                'qDt = ta.GetDataByAIndexNo(indexNo - 1)
    '                qDt = ta.GetDataByPrevSEQ_DESC(prodDate + prodTime + seqNo + subSeq)

    '                Dim baseSeqNo As String = qDt.Rows(0)("SeqNo").ToString()
    '                Dim baseSub As String = qDt.Rows(0)("SubSeq").ToString()
    '                Dim baseProdDate As String = qDt.Rows(0)("productionDate").ToString()
    '                Dim baseProdTime As String = qDt.Rows(0)("productionTime").ToString()


    '                '      InsertSeqAndSub.ReorderSubSeq(baseSeqNo, baseSub, baseProdDate) 'accumulate sub seq then have space for new insert
    '                UpdateData(pkList, baseSeqNo, baseSub + 1, baseProdDate, baseProdTime)


    '                'pDt = ta.GetDataBySeqNo(selectedSeqNo - 1)
    '                'UpdateData(pkList, selectedSeqNo, selectedSub, baseProdDate, baseProdTime)

    '            End If

    '        End If

    '    End If

    'End Sub

End Class
