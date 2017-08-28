Imports Common

Public Class InspIn
    Dim logger As Logger = New Logger()

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        
        Me.Close()
        
    End Sub

    Private Sub InspIn_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

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
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnCancel_Click", "Close InspIn screen", "")
        Me.Dispose()

    End Sub

    Private Sub InspIn_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "InspIn_Load", "Load InspIn Screen", "")
            'TODO: This line of code loads data into the 'DataSet1.T_Production_DAT' table. You can move, or remove it, as needed.
            'Me.T_Production_DATTableAdapter.Fill(Me.DataSet1.T_Production_DAT)

            'Dim dr As New DataRow
            Dim dt As New DataSet1.T_Production_DATDataTable
            Dim i As Integer

            Dim modelYear As String
            Dim suffixCode As String
            Dim lotNo As String
            Dim unit As String
            Dim yChass As String

            'Get InspOut data (xchgFlag = "xx01") with InstrucFlag > 0
            T_Production_DATTableAdapter.FillByXchngFlagInsFlagMoreThanZero(dt)

            Me.DataGridInspInData.DataSource = dt

            'Filter out by instructed mainline 
            For i = 0 To dt.Rows.Count - 1
                Dim res As Boolean

                modelYear = dt.Rows(i)("ModelYear").ToString()
                suffixCode = dt.Rows(i)("SuffixCode").ToString()
                lotNo = dt.Rows(i)("LotNo").ToString()
                unit = dt.Rows(i)("Unit").ToString()
                yChass = dt.Rows(i)("YChassisFlag").ToString()


                If yChass = "" Or yChass = "0" Then
                    'check 2 line 
                    res = checkProductCarrResult_NOXChange(modelYear, suffixCode, lotNo, unit, 1)
                    res = res And checkProductCarrResult_NOXChange(modelYear, suffixCode, lotNo, unit, 2)
                ElseIf yChass = "1" Or yChass = "2" Then
                    'check line 1 only
                    res = checkProductCarrResult_NOXChange(modelYear, suffixCode, lotNo, unit, 1)
                ElseIf yChass = "3" Then
                    'check line 2 only
                    res = checkProductCarrResult_NOXChange(modelYear, suffixCode, lotNo, unit, 2)
                End If

                If res = False Then 'No result
                    'DataGridInspInData.Rows(i).DefaultCellStyle.BackColor = Color.Crimson
                    dt.Rows(i).Delete()
                End If
                If res = True Then
                    'DataGridInspInData.Rows(i).DefaultCellStyle.BackColor = Color.DeepSkyBlue
                End If

            Next

            'TODO
            'Dim offsetBase As Integer = 0
            'For Each dr As DataSet1.T_Production_DATRow In dt
            '    offsetBase += 1
            '    dr.indexNo = offsetBase
            'Next

            Me.DataGridInspInData.DataSource = dt


            Dim activeRowIndex As Integer
            If Me.DataGridInspInData.RowCount > 0 Then
                activeRowIndex = 0

                Me.lblLabel.Text = "ModelCode"
                Me.lblValue.Text = Me.DataGridInspInData.Item(4, activeRowIndex).Value.ToString + Me.DataGridInspInData.Item(5, activeRowIndex).Value.ToString
                Me.lblLabel2.Text = "Lot No. "
                Me.lblValue2.Text = Me.DataGridInspInData.Item(7, activeRowIndex).Value.ToString
                Me.lblValue2.Text = Me.lblValue2.Text & "  UNIT "
                Me.lblValue2.Text = Me.lblValue2.Text & Me.DataGridInspInData.Item(8, activeRowIndex).Value.ToString

                Me.btnOk.Enabled = True
                Me.btnDelete.Enabled = True
            Else
                ClearLabelAndDisableButton()
            End If
        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "InspIn_Load", ex.Message, "")
        End Try
    End Sub

    Private Sub ClearLabelAndDisableButton()
        Me.lblValue.Text = ""
        Me.lblValue2.Text = ""

        Me.btnOk.Enabled = False
        Me.btnDelete.Enabled = False
    End Sub


    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnDelete_Click", "Click Delete Button", "")
            'Dim index As String = Me.DataGridInspInData.CurrentRow.Cells(0).Value

            If MessageBox.Show("Do want to delete it?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.OK Then

                Dim result As Integer
                Dim activeRowIndex As Integer = Me.DataGridInspInData.CurrentCell.RowIndex
                Dim taProd As New DataSet1TableAdapters.T_Production_DATTableAdapter
                Dim taIns As New DataSet1TableAdapters.T_Instruction_DATTableAdapter

                'Dim instructFlag As Integer
                'instructFlag = Me.DataGridInspInData.Item(121, activeRowIndex).Value

                Dim modelYear As String
                Dim suffixCode As String
                Dim lotNo As String
                Dim unit As String
                modelYear = Me.DataGridInspInData.Item(4, activeRowIndex).Value 'model year
                suffixCode = Me.DataGridInspInData.Item(5, activeRowIndex).Value 'suffix code
                lotNo = Me.DataGridInspInData.Item(7, activeRowIndex).Value 'lot no
                unit = Me.DataGridInspInData.Item(8, activeRowIndex).Value 'unit

                Dim seqNo = Me.DataGridInspInData.Item(1, activeRowIndex).Value 'seq no
                Dim subSeq = Me.DataGridInspInData.Item(2, activeRowIndex).Value 'subSeq

                result = taProd.DeleteByPrimaryKey(modelYear, suffixCode, lotNo, unit)

                If result > 0 Then
                    result = 0
                    result = DeleteInstructionData(modelYear, suffixCode, lotNo, unit)
                End If

                If result > 0 Then 'successful deleted then RELOAD data

                    Dim logMSG As String
                    logMSG = "Production data SeqNo " & seqNo & "-" & subSeq & " deleted."

                    'Write Log
                    Dim logger As TLogDat
                    logger = New TLogDat
                    logger.InsertNewLog(TLogDat.LOG_TYPE_OPERATION, TLogDat.LogLevel.NormalLog, My.Computer.Name, Now, logMSG, Nothing)

                    InspIn_Load(sender, e)

                End If
            End If

        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "btnDelete_Click", ex.Message, "")
        End Try
    End Sub

    Private Function DeleteInstructionData(ByVal modelYear As String, ByVal suffixCode As String, ByVal lotNo As String, ByVal unit As String) As Integer

        Try
            Dim taIns As New DataSet1TableAdapters.T_Instruction_DATTableAdapter
            Dim result As Integer

            result = taIns.DeleteByPrimaryKey(modelYear, suffixCode, lotNo, unit)

            Return result
        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "DeleteInstructionData", ex.Message, "")
        End Try
    End Function

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnOk_Click", "Click OK Button", "")

        Dim activeRowIndex As Integer = ProductionData.datagridPdata.CurrentCell.RowIndex
        Dim activeRowInsert As Integer = Me.DataGridInspInData.CurrentCell.RowIndex

        Dim pkList(3) As Object
        Dim prList(3) As Object

        'Production Screen
        prList(0) = ProductionData.datagridPdata.Item(4, activeRowIndex).Value 'ModelYear
        prList(1) = ProductionData.datagridPdata.Item(5, activeRowIndex).Value 'suffixCode
        prList(2) = ProductionData.datagridPdata.Item(7, activeRowIndex).Value 'lotNo
        prList(3) = ProductionData.datagridPdata.Item(8, activeRowIndex).Value 'unit
        Dim prYchass As String
        prYchass = ProductionData.datagridPdata.Item(15, activeRowIndex).Value.ToString() 'YChassisFlag

        Dim selectedProdDate As String = ProductionData.datagridPdata.Item(12, activeRowIndex).Value.ToString()
        Dim selectedProdTime As String = ProductionData.datagridPdata.Item(13, activeRowIndex).Value.ToString()
        Dim selectedSeqNo As String = ProductionData.datagridPdata.Item(1, activeRowIndex).Value.ToString()
        Dim selectedSub As String = ProductionData.datagridPdata.Item(2, activeRowIndex).Value.ToString()


        'Insp-In Screen
        pkList(0) = Me.DataGridInspInData.Item(4, activeRowInsert).Value 'ModelYear
        pkList(1) = Me.DataGridInspInData.Item(5, activeRowInsert).Value 'suffixCode
        pkList(2) = Me.DataGridInspInData.Item(7, activeRowInsert).Value 'lotNo
        pkList(3) = Me.DataGridInspInData.Item(8, activeRowInsert).Value 'unit
        Dim ychassInsert As String
        ychassInsert = Me.DataGridInspInData.Item(15, activeRowInsert).Value.ToString() 'YChassisFlag
        Dim pkInsFlag = Me.DataGridInspInData.Item(121, activeRowInsert).Value.ToString()


        'Check Procduction MainLine InsResult
        Dim res As Boolean

        If prYchass = "" Or prYchass = "0" Then
            'check 2 line
            res = checkProductInsResult_NOXChange(prList(0).ToString(), prList(1).ToString(), prList(2).ToString(), prList(3).ToString(), 1)
            res = res Or checkProductInsResult_NOXChange(prList(0).ToString(), prList(1).ToString(), prList(2).ToString(), prList(3).ToString(), 2)
        ElseIf prYchass = "1" Or prYchass = "2" Then
            'check line 1 only
            res = checkProductInsResult_NOXChange(prList(0).ToString(), prList(1).ToString(), prList(2).ToString(), prList(3).ToString(), 1)
        ElseIf prYchass = "3" Then
            'check line 2 only
            res = checkProductInsResult_NOXChange(prList(0).ToString(), prList(1).ToString(), prList(2).ToString(), prList(3).ToString(), 2)
        End If

        If res Then
            'Instructed
            MessageBox.Show("Selected production row mainline was instructed." & vbCrLf, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Else 'Not instructed

            'check InspIN carry out
            If pkInsFlag = "2" Then 'Selected INSP-In row carry out already
                Try
                    Using ts As New TransactionScope
                        Dim manageInstructData As New ManageInstructionData

                        Dim newDetail(3) As String  'Seq,SubSeq,proDate-Time Data
                        newDetail = Me.ManageDataToInsert(pkList)  'ReOrder SubSeq in production

                        'add Ins
                        manageInstructData.UpdateProductionRowToInstructionForInspIN(pkList(0), pkList(1), _
                                                                            pkList(2), pkList(3), newDetail)

                        'Clear InspIN MainLine InsResult and CarrResult
                        If ychassInsert = "" Or ychassInsert = "0" Then
                            'clear 2 line
                            clearProductInsCarrResult_NOXChange(pkList(0).ToString(), pkList(1).ToString(), pkList(2).ToString(), pkList(3).ToString(), 1)
                            clearProductInsCarrResult_NOXChange(pkList(0).ToString(), pkList(1).ToString(), pkList(2).ToString(), pkList(3).ToString(), 2)
                        ElseIf ychassInsert = "1" Or ychassInsert = "2" Then
                            'clear line 1 only
                            clearProductInsCarrResult_NOXChange(pkList(0).ToString(), pkList(1).ToString(), pkList(2).ToString(), pkList(3).ToString(), 1)
                        ElseIf ychassInsert = "3" Then
                            'clear line 2 only
                            clearProductInsCarrResult_NOXChange(pkList(0).ToString(), pkList(1).ToString(), prList(2).ToString(), pkList(3).ToString(), 2)
                        End If
                        ts.Complete()
                    End Using
                Catch ex As Exception
                    logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "btnOk_Click", ex.StackTrace, "")
                    MessageBox.Show("Inspection In Fail", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Else 'Not carry out yet

                MessageBox.Show("Selected INSP-In row not carry out yet." & vbCrLf, "Confirmation")
            End If

        End If

        Dim prodDate As String = ""
        Dim prodTime As String = ""
        Dim seqNo As String = ""
        Dim subSeq As Integer = 0

        'Reload Production Data
        If activeRowIndex > 0 Then

            prodDate = ProductionData.datagridPdata.Item(12, activeRowIndex - 1).Value
            prodTime = ProductionData.datagridPdata.Item(13, activeRowIndex - 1).Value
            seqNo = ProductionData.datagridPdata.Item(1, activeRowIndex - 1).Value
            subSeq = ProductionData.datagridPdata.Item(2, activeRowIndex - 1).Value

        Else
            Dim taProd As New DataSet1TableAdapters.T_Production_DATTableAdapter
            Dim qDt As New DataSet1.T_Production_DATDataTable
            qDt = taProd.GetDataByPreviousBtn(0, selectedProdDate, selectedProdTime, selectedSeqNo, selectedSub)

            prodDate = qDt(0).ProductionDate
            prodTime = qDt(0).ProductionTime
            seqNo = qDt(0).SeqNo
            subSeq = qDt(0).SubSeq

        End If

        ProductionData.Show()
        ProductionData.ReloadData(prodDate, prodTime, seqNo, subSeq)

        Me.Dispose()

    End Sub

    'Private Function checkProductInsResult(ByVal modelYear As String, ByVal suffixCode As String, ByVal lotNo As String, ByVal unit As String, ByVal lineType As Integer) As Boolean
    '    Try
    '        Dim M_ta As New DataSet1TableAdapters.T_Line_MSTTableAdapter
    '        Dim I_ta As New DataSet1TableAdapters.T_Instruction_DATTableAdapter

    '        Dim MainlineCode As String = M_ta.GetMainLineCodeByLineType(lineType)

    '        Dim dt As New DataSet1.T_Instruction_DATDataTable
    '        I_ta.FillByModelYearSuffixLotUnitLineNo(dt, modelYear, suffixCode, lotNo, unit, MainlineCode)

    '        If dt.Rows(0)("InsResult") Is DBNull.Value Then
    '            Return False
    '        Else
    '            Return True
    '        End If
    '    Catch ex As Exception
    '        logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "checkProductionInsResult", ex.Message, "")
    '    End Try

    'End Function


    Private Function checkProductInsResult_NOXChange(ByVal modelYear As String, ByVal suffixCode As String, ByVal lotNo As String, ByVal unit As String, ByVal lineType As Integer) As Boolean
        Try
            Dim M_ta As New DataSet1TableAdapters.T_Line_MSTTableAdapter
            Dim I_ta As New DataSet1TableAdapters.T_Instruction_DATTableAdapter

            Dim MainlineCode As String = M_ta.GetMainLineCodeByLineType(lineType)

            Dim dt As New DataSet1.T_Instruction_DATDataTable
            I_ta.FillByModelYearSuffixCodeLotNoUnit_NoXChange(dt, modelYear, suffixCode, lotNo, unit, MainlineCode)

            If dt.Rows(0)("InsResult") Is DBNull.Value Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "checkProductInsResult_NOXChange", ex.Message, "")
        End Try

    End Function

    Private Function checkProductCarrResult_NOXChange(ByVal modelYear As String, ByVal suffixCode As String, ByVal lotNo As String, ByVal unit As String, ByVal lineType As Integer) As Boolean
        Try
            Dim M_ta As New DataSet1TableAdapters.T_Line_MSTTableAdapter
            Dim I_ta As New DataSet1TableAdapters.T_Instruction_DATTableAdapter

            Dim MainlineCode As String = M_ta.GetMainLineCodeByLineType(lineType)

            Dim dt As New DataSet1.T_Instruction_DATDataTable
            I_ta.FillByModelYearSuffixCodeLotNoUnit_NoXChange(dt, modelYear, suffixCode, lotNo, unit, MainlineCode)

            If dt.Rows(0)("CarrResult") Is DBNull.Value Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "checkProductCarrResult_NOXChange", ex.Message, "")
        End Try

    End Function

    Private Function clearProductInsCarrResult_NOXChange(ByVal modelYear As String, ByVal suffixCode As String, ByVal lotNo As String, ByVal unit As String, ByVal lineType As Integer) As Boolean
        Try
            Dim M_ta As New DataSet1TableAdapters.T_Line_MSTTableAdapter
            Dim I_ta As New DataSet1TableAdapters.T_Instruction_DATTableAdapter

            Dim MainlineCode As String = M_ta.GetMainLineCodeByLineType(lineType)

            Dim dt As New DataSet1.T_Instruction_DATDataTable
            I_ta.FillByModelYearSuffixCodeLotNoUnit_NoXChange(dt, modelYear, suffixCode, lotNo, unit, MainlineCode)

            dt.Rows(0)("InsResult") = DBNull.Value
            dt.Rows(0)("CarrResult") = DBNull.Value

            Dim chk As Integer = T_Instruction_DATTableAdapter.Update(dt)
        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "clearProductInsCarrResult_NOXChange", ex.Message, "")
        End Try
    End Function

    Private Function ManageDataToInsert(ByVal pkList As Object) As String()

        Try
            Dim activeRowIndex As Integer = ProductionData.datagridPdata.CurrentCell.RowIndex
            Dim indexNo As Integer = ProductionData.datagridPdata.Item(0, activeRowIndex).Value.ToString()

            Dim selectedProdDate As String = ProductionData.datagridPdata.Item(12, activeRowIndex).Value.ToString()
            Dim selectedProdTime As String = ProductionData.datagridPdata.Item(13, activeRowIndex).Value.ToString()
            Dim selectedSeqNo As String = ProductionData.datagridPdata.Item(1, activeRowIndex).Value.ToString()
            Dim selectedSub As String = ProductionData.datagridPdata.Item(2, activeRowIndex).Value.ToString()
            Dim newDetail(3) As String

            If activeRowIndex <> 0 Then

                Dim baseSeqNo As String = ProductionData.datagridPdata.Item(1, activeRowIndex - 1).Value.ToString()
                Dim baseSub As String = ProductionData.datagridPdata.Item(2, activeRowIndex - 1).Value.ToString()
                Dim baseProdDate As String = ProductionData.datagridPdata.Item(12, activeRowIndex - 1).Value.ToString()
                Dim baseProdTime As String = ProductionData.datagridPdata.Item(13, activeRowIndex - 1).Value.ToString()

                If baseSeqNo = selectedSeqNo Then 'insert between same seq

                    'newDetail(0) = baseSeqNo    'seqNo
                    'newDetail(1) = 0           'subSeq
                    'newDetail(2) = baseProdDate 'proDate
                    'newDetail(3) = baseProdTime 'proTime

                    InsertSeqAndSub.ReorderSubSeqForInspIn(baseSeqNo, baseSub, baseProdDate, baseProdTime) 'accumulate sub seq then have space for new insert

                End If

                newDetail(0) = baseSeqNo    'seqNo
                newDetail(1) = baseSub + 1 'subSeq
                newDetail(2) = baseProdDate 'proDate
                newDetail(3) = baseProdTime 'proTime

                UpdateData(pkList, baseSeqNo, baseSub + 1, baseProdDate, baseProdTime)

            Else

                If indexNo = 1 Then 'First record
                    Dim curProdDate As String = ProductionData.datagridPdata.Item(12, activeRowIndex).Value 'Prod Date
                    Dim curProdTime As String = ProductionData.datagridPdata.Item(13, activeRowIndex).Value 'Prod Time

                    Dim i As Integer = 0
                    Dim dt As New DataSet1.T_Production_DATDataTable
                    Me.T_Production_DATTableAdapter.FillBySeqNoIsZero(dt)

                    For i = 0 To dt.Rows.Count - 1
                        dt.Rows(i)("SubSeq") = dt.Rows(i)("SubSeq") + 1
                    Next

                    Dim ta As New DataSet1TableAdapters.T_Production_DATTableAdapter
                    ta.Update(dt)

                    newDetail(0) = "00000"   'seqNo
                    newDetail(1) = 0 'subSeq
                    newDetail(2) = curProdDate 'proDate
                    newDetail(3) = curProdTime 'proTime

                    UpdateData(pkList, "00000", 0, curProdDate, curProdTime)

                Else 'first row but not first record

                    Dim taProd As New DataSet1TableAdapters.T_Production_DATTableAdapter
                    Dim pDt As New DataSet1.T_Production_DATDataTable

                    pDt = taProd.GetDataBySeqNoProductionDateTime(selectedSeqNo, selectedProdDate, selectedProdTime)

                    Dim qDt As New DataSet1.T_Production_DATDataTable
                    qDt = taProd.GetDataByPreviousBtn(0, selectedProdDate, selectedProdTime, selectedSeqNo, selectedSub)

                    Dim baseSeqNo As String = qDt.Rows(0)("SeqNo").ToString()
                    Dim baseSub As String = qDt.Rows(0)("SubSeq").ToString()
                    Dim baseProdDate As String = qDt.Rows(0)("productionDate").ToString()
                    Dim baseProdTime As String = qDt.Rows(0)("productionTime").ToString()

                    If pDt.Rows.Count > 1 Then
                        InsertSeqAndSub.ReorderSubSeqForInspIn(baseSeqNo, baseSub, baseProdDate, baseProdTime) 'accumulate sub seq then have space for new insert
                    End If

                    newDetail(0) = baseSeqNo    'seqNo
                    newDetail(1) = baseSub + 1 'subSeq
                    newDetail(2) = baseProdDate 'proDate
                    newDetail(3) = baseProdTime 'proTime

                    UpdateData(pkList, baseSeqNo, baseSub + 1, baseProdDate, baseProdTime)

                End If


            End If

            '------------------------------------------------

            Return newDetail

        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "ManageDataToInsert", ex.Message, "")
            Throw ex
        End Try
    End Function

    Private Sub UpdateData(ByVal pkList As Object, ByVal seqNo As String, ByVal subSeq As Integer, _
                           ByVal prodDate As String, ByVal prodTime As String)

        Try
            Dim taProd As New DataSet1TableAdapters.T_Production_DATTableAdapter

            Dim result As Integer
            Try
                result = taProd.UpdateDataForInspIn(prodDate, prodTime, seqNo, subSeq, "02", 0, _
                                                         pkList(0), pkList(1), pkList(2), pkList(3))
            Catch ex As Exception
                MessageBox.Show("Insert Error.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Throw ex
            End Try

            Dim logMSG As String
            logMSG = "Production data " & Me.lblLabel.Text & " " & Me.lblValue.Text & " " & Me.lblLabel2.Text & Me.lblValue2.Text & " Inspection In."

            'Write Log
            Dim logger As TLogDat
            logger = New TLogDat
            logger.InsertNewLog(TLogDat.LOG_TYPE_OPERATION, TLogDat.LogLevel.NormalLog, My.Computer.Name, Now, logMSG, Nothing)
        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "UpdateData", ex.Message, "")
            Throw ex
        End Try
    End Sub

    Private Sub DataGridInspInData_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridInspInData.SelectionChanged

        If Me.DataGridInspInData.Rows.Count > 0 Then
            Dim activeRowIndex As Integer = Me.DataGridInspInData.CurrentCell.RowIndex
            Me.lblLabel.Text = "ModelCode"
            Me.lblValue.Text = Me.DataGridInspInData.Item(4, activeRowIndex).Value.ToString + Me.DataGridInspInData.Item(5, activeRowIndex).Value.ToString
            Me.lblLabel2.Text = "Lot No. "
            Me.lblValue2.Text = Me.DataGridInspInData.Item(7, activeRowIndex).Value.ToString
            Me.lblValue2.Text = Me.lblValue2.Text & "  UNIT "
            Me.lblValue2.Text = Me.lblValue2.Text & Me.DataGridInspInData.Item(8, activeRowIndex).Value.ToString
        Else
            ClearLabelAndDisableButton()
        End If

    End Sub

    'Public Sub ReOrderSubSeqForInstructionTbl(ByVal detail As String(), ByVal pkList As Object)

    '    '''''''''''''''''''Modify  seqNo'''''''''''''''''''''''''''
    '    Dim taT_Line_MST As New DataSet1TableAdapters.T_Line_MSTTableAdapter
    '    Dim Line_MST As New DataSet1.T_Line_MSTDataTable
    '    taT_Line_MST.Fill(Line_MST)

    '    For lineIndex = 0 To Line_MST.Rows.Count - 1

    '        Dim drLine As DataSet1.T_Line_MSTRow = Line_MST.Rows(lineIndex)
    '        Dim drInst As DataSet1.T_Instruction_DATRow = DataSet1.T_Instruction_DAT.FindByModelYearSuffixCodeLotNoUnitLine_No _
    '                                                (pkList(0), pkList(1), pkList(2), pkList(3), drLine.LineCode)
    '        Dim yChass As String = drInst.YChassisFlag
    '        Dim MainlineCode As String

    '        Dim originalDT As New DataSet1.T_Instruction_DATDataTable
    '        Dim insDta As New DataSet1TableAdapters.T_Instruction_DATTableAdapter
    '        insDta.FillByLineNoSeqNo(originalDT, lineIndex, detail(0))

    '        If yChass = "" Or yChass = "0" Then
    '            'update line type 1 and 2
    '            MainlineCode = taT_Line_MST.GetMainLineCodeByLineType(1)
    '            If lineIndex = MainlineCode - 1 Then
    '                'Reorder subSeq in Instruction on each line


    '                For Each OriInsDr As DataSet1.T_Instruction_DATRow In originalDT
    '                    If OriInsDr.SubSeq >= Convert.ToInt32(detail(1)) Then
    '                        OriInsDr.SubSeq += 1
    '                    End If
    '                    insDta.Update(OriInsDr)
    '                Next
    '            End If
    '            MainlineCode = taT_Line_MST.GetMainLineCodeByLineType(2)
    '            If lineIndex = MainlineCode - 1 Then
    '                'Reorder subSeq in Instruction on each line

    '                For Each OriInsDr As DataSet1.T_Instruction_DATRow In originalDT
    '                    If OriInsDr.SubSeq >= Convert.ToInt32(detail(1)) Then
    '                        OriInsDr.SubSeq += 1
    '                    End If
    '                    insDta.Update(OriInsDr)
    '                Next
    '            End If
    '        End If

    '        If yChass = "1" Or yChass = "2" Then
    '            'update line type 1 
    '            MainlineCode = taT_Line_MST.GetMainLineCodeByLineType(1)
    '            If lineIndex = MainlineCode - 1 Then
    '                'Reorder subSeq in Instruction on each line


    '                For Each OriInsDr As DataSet1.T_Instruction_DATRow In originalDT
    '                    If OriInsDr.SubSeq >= Convert.ToInt32(detail(1)) Then
    '                        OriInsDr.SubSeq += 1
    '                    End If
    '                    insDta.Update(OriInsDr)
    '                Next
    '            End If
    '        End If
    '        If yChass = "3" Then
    '            'update line type 2 
    '            MainlineCode = taT_Line_MST.GetMainLineCodeByLineType(2)
    '            If lineIndex = MainlineCode - 1 Then
    '                'Reorder subSeq in Instruction on each line


    '                For Each OriInsDr As DataSet1.T_Instruction_DATRow In originalDT
    '                    If OriInsDr.SubSeq >= Convert.ToInt32(detail(1)) Then
    '                        OriInsDr.SubSeq += 1
    '                    End If
    '                    insDta.Update(OriInsDr)
    '                Next
    '            End If
    '        End If
    '        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '    Next

    'End Sub


    Private Sub InspIn_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyData
            Case Keys.F1
                btnOk_Click(sender, e)
            Case Keys.F3
                btnDelete_Click(sender, e)
            Case Keys.F12
                btnCancel_Click(sender, e)
        End Select
    End Sub
End Class