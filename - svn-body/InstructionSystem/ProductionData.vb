Imports Common

Public Class ProductionData

#Region "PRIVATE MEMBER"

    Private m_clsGetRuntime As clsGetRuntime = clsGetRuntime.GetInstance()
    Dim logger As Logger = New Logger()

    Private Const SCREEN_NAME As String = "PRODUCTION_DATA"
#End Region

    Public m_iMaxRowCount As Integer = ModConstant.PRODUCTION_DATA_SIZE_PER_PAGE

    Private Sub ProductionData_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnF12_Click", "Close Production Screen", "")

        Dim colObj As clsColumnSetup = New clsColumnSetup()
        colObj.setColumnIni(Me.datagridPdata, SCREEN_NAME)

        Main_Menu.Show()
        Me.Dispose()

    End Sub

    Private Sub ProductionData_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyData
            Case Keys.F1
                btnF1_Click(sender, e)
            Case Keys.F2
                btnF2_Click(sender, e)
            Case Keys.F3
                btnF3_Click(sender, e)
            Case Keys.F4
                btnF4_Click(sender, e)
            Case Keys.F5
                btnF5_Click(sender, e)
            Case Keys.F6
                btnF6_Click(sender, e)
            Case Keys.F7
                btnF7_Click(sender, e)
            Case Keys.F8
                btnF8_Click(sender, e)
            Case Keys.F9
                btnF9_Click(sender, e)
            Case Keys.F10
                btnF10_Click(sender, e)
            Case Keys.F11
                btnF11_Click(sender, e)
            Case Keys.F12
                btnF12_Click(sender, e)

            Case Keys.Up
                If Me.datagridPdata.CurrentRow.Index = 0 Then
                    'btnF7_Click(sender, e)
                    If datagridPdata.RowCount > 0 Then
                        Dim dt As New DataTable
                        Dim taProduction As New DataSet1TableAdapters.T_Production_DATTableAdapter
                        Dim tmpDtProd As New DataSet1.T_Production_DATDataTable
                        Dim tmpDrProd As DataSet1.T_Production_DATRow
                        Dim prodDate As String = ""
                        Dim prodTime As String = ""
                        Dim seqNo As String = ""
                        Dim subSeq As Integer = 0

                        prodDate = datagridPdata.Item(12, 0).Value
                        prodTime = datagridPdata.Item(13, 0).Value
                        seqNo = datagridPdata.Item(1, 0).Value
                        subSeq = datagridPdata.Item(2, 0).Value
                        Try

                            tmpDtProd = taProduction.GetDataByPreviousBtn(1, prodDate, prodTime, seqNo, subSeq)
                            If tmpDtProd.Count > 0 Then

                                tmpDrProd = tmpDtProd.Rows(0)

                                If IsFirstRecord(tmpDrProd) Then
                                    prodDate = ""
                                    prodTime = ""
                                    seqNo = ""
                                    subSeq = 0

                                    dt = GetData(prodDate, prodTime, seqNo, subSeq)
                                Else
                                    dt = GetData(tmpDrProd.ProductionDate, tmpDrProd.ProductionTime, tmpDrProd.SeqNo, tmpDrProd.SubSeq)
                                End If
                                datagridPdata.DataSource = dt
                            End If


                        Catch ex As Exception

                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "btnF7_Click", ex.Message, "")
                        End Try
                    End If
                End If

            Case Keys.Down
                If Me.datagridPdata.CurrentRow.Index = Me.datagridPdata.RowCount - 1 Then

                    Dim dt As New DataTable
                    'Dim rowsCount As Integer = GetRowsCount(m_iLineNo)

                    Dim prodDate As String = ""
                    Dim prodTime As String = ""
                    Dim seqNo As String = ""
                    Dim subSeq As Integer = 0


                    Try
                        If datagridPdata.Rows.Count = m_iMaxRowCount Then
                            prodDate = datagridPdata.Item(12, 0).Value
                            prodTime = datagridPdata.Item(13, 0).Value
                            seqNo = datagridPdata.Item(1, 0).Value
                            subSeq = datagridPdata.Item(2, 0).Value

                            dt = GetData(prodDate, prodTime, seqNo, subSeq)
                            If dt.Rows.Count > 0 Then
                                Me.datagridPdata.DataSource = dt

                            End If
                        End If

                        Me.datagridPdata.Rows(Me.datagridPdata.RowCount - 1).Cells(0).Selected = True

                    Catch ex As Exception
                        'indexNo = 0
                        'MessageBox.Show("End of data!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "btnF8_Click", ex.Message, "")
                    End Try
                End If


            Case Keys.ControlKey And Keys.T
                Dim dt As New DataTable
                Dim index As Integer = Me.datagridPdata.CurrentRow.Cells(0).Value

                Dim prodDate As String = ""
                Dim prodTime As String = ""
                Dim seqNo As String = ""
                Dim subSeq As Integer = 0

                prodDate = Me.datagridPdata.CurrentRow.Cells(12).Value
                prodTime = Me.datagridPdata.CurrentRow.Cells(13).Value
                seqNo = Me.datagridPdata.CurrentRow.Cells(1).Value
                subSeq = Me.datagridPdata.CurrentRow.Cells(2).Value

                ReloadData(prodDate, prodTime, seqNo, subSeq)

        End Select
    End Sub


    Private Sub ProductionData_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "ProductionData_Load", "Load Production Screen", "")
        
        Dim taProduction As New DataSet1TableAdapters.T_Production_DATTableAdapter
        Dim tmpDtProd As New DataSet1.T_Production_DATDataTable
        Dim tmpDrProd As DataSet1.T_Production_DATRow
        Dim dt As New DataTable

        Dim prodDate As String = ""
        Dim prodTime As String = ""
        Dim seqNo As String = ""
        Dim subSeq As Integer = 0

        Try
            'get up 1 record for Reload
            tmpDtProd = taProduction.GetDataByFirstInstructFlagLessThan2()
            If tmpDtProd.Rows.Count > 0 Then
                tmpDrProd = tmpDtProd.Rows(0)
                prodDate = tmpDrProd.ProductionDate
                prodTime = tmpDrProd.ProductionTime
                seqNo = tmpDrProd.SeqNo
                subSeq = tmpDrProd.SubSeq

                tmpDtProd = taProduction.GetDataByPreviousBtn(0, prodDate, prodTime, seqNo, subSeq)
                If tmpDtProd.Count > 0 Then
                    tmpDrProd = tmpDtProd.Rows(0)

                    dt = GetData(tmpDrProd.ProductionDate, tmpDrProd.ProductionTime, tmpDrProd.SeqNo, tmpDrProd.SubSeq)
                Else
                    'get first page
                    prodDate = ""
                    prodTime = ""
                    seqNo = ""
                    subSeq = 0

                    dt = GetData(prodDate, prodTime, seqNo, subSeq)
                End If
            Else
                'Current Record not Exist -> Show Last page
                tmpDtProd = taProduction.GetDataByLastProduction()
                If tmpDtProd.Rows.Count > 0 Then
                    tmpDrProd = tmpDtProd.Rows(0)
                    prodDate = tmpDrProd.ProductionDate
                    prodTime = tmpDrProd.ProductionTime
                    seqNo = tmpDrProd.SeqNo
                    subSeq = tmpDrProd.SubSeq

                    tmpDtProd = taProduction.GetDataByPreviousBtn(m_iMaxRowCount - 1, prodDate, prodTime, seqNo, subSeq)
                    If tmpDtProd.Count > 0 Then
                        tmpDrProd = tmpDtProd.Rows(0)

                        dt = GetData(tmpDrProd.ProductionDate, tmpDrProd.ProductionTime, tmpDrProd.SeqNo, tmpDrProd.SubSeq)
                    Else
                        'get first page
                        prodDate = ""
                        prodTime = ""
                        seqNo = ""
                        subSeq = 0

                        dt = GetData(prodDate, prodTime, seqNo, subSeq)
                    End If
                Else
                    'Last Not Exist -> No data
                    prodDate = ""
                    prodTime = ""
                    seqNo = ""
                    subSeq = 0

                    dt = GetData(prodDate, prodTime, seqNo, subSeq)
                End If
            End If
            If dt.Rows.Count > 0 Then
                Me.datagridPdata.DataSource = dt
            End If

            Dim colObj As clsColumnSetup = New clsColumnSetup()
            setDatagridColWidthIni(colObj.getColumnIni(datagridPdata.Columns.Count, SCREEN_NAME))

            calCol()

            Timer2.Start()
            Timer1.Start()
            Main_Menu.Hide()
        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "ProductionData_Load", ex.Message, "")
        End Try


    End Sub

    Private Sub btnF12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        
        Me.Close()

    End Sub

    'Edit button
    Private Sub btnF1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnF1.Click
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnF1_Click", "Click Edit Button", "")

        Dim activeRowIndex As Integer = Me.datagridPdata.CurrentCell.RowIndex
        Dim primaryKeyValueList As New ArrayList

        'Dim instructFlag As Integer
        'instructFlag = Me.datagridPdata.Item(121, activeRowIndex).Value

        'If instructFlag > 0 Then
        '    MessageBox.Show("Already Instructed it." & vbCrLf & "Cannot update data.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'Else
        Dim dtProd As DataSet1.T_Production_DATDataTable = Me.datagridPdata.DataSource
        Dim drProd As DataSet1.T_Production_DATRow = dtProd.Rows(activeRowIndex)
        primaryKeyValueList.Add(drProd.ModelYear) 'ModelYear
        primaryKeyValueList.Add(drProd.SuffixCode) 'SuffixCode
        primaryKeyValueList.Add(drProd.LotNo) 'LotNo
        primaryKeyValueList.Add(drProd.Unit) 'Unit
        'primaryKeyValueList.Add(drProd.YChassisFlag) 'Unit

        'primaryKeyValueList.Add(Me.datagridPdata.Item(4, activeRowIndex).Value) 'ModelYear
        'primaryKeyValueList.Add(Me.datagridPdata.Item(5, activeRowIndex).Value) 'SuffixCode
        'primaryKeyValueList.Add(Me.datagridPdata.Item(7, activeRowIndex).Value) 'LotNo
        'primaryKeyValueList.Add(Me.datagridPdata.Item(8, activeRowIndex).Value) 'Unit

        Me.Hide()
        DetailedDataEdit.Initialize(DetailedDataEdit.Mode.UPDATE, primaryKeyValueList)
        DetailedDataEdit.ShowDialog()
        'End If

        Me.datagridPdata.Focus()

    End Sub

    'ADDITION button
    Private Sub btnF2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF2.Click
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnF2_Click", "Click Addition Button", "")

        Dim activeRowIndex As Integer = Me.datagridPdata.CurrentCell.RowIndex
        Dim primaryKeyValueList As New ArrayList

        primaryKeyValueList.Add(Me.datagridPdata.Item(4, activeRowIndex).Value) 'ModelYear
        primaryKeyValueList.Add(Me.datagridPdata.Item(5, activeRowIndex).Value) 'SuffixCode
        primaryKeyValueList.Add(Me.datagridPdata.Item(7, activeRowIndex).Value) 'LotNo
        primaryKeyValueList.Add(Me.datagridPdata.Item(8, activeRowIndex).Value) 'Unit

        Me.Hide()
        DetailedDataEdit.Initialize(DetailedDataEdit.Mode.ADD, primaryKeyValueList)
        DetailedDataEdit.ShowDialog()

        Me.datagridPdata.Focus()

    End Sub

    'DELETE button
    Private Sub btnF3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF3.Click
        Try
            logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnF3_Click", "Click Delete Button", "")

            Dim activeRowIndex As Integer = Me.datagridPdata.CurrentCell.RowIndex
            Dim instructFlag As Integer = Me.datagridPdata.Item(121, activeRowIndex).Value
            Dim xChange As String = Me.datagridPdata.Item(120, activeRowIndex).Value

            Dim taProd As New DataSet1TableAdapters.T_Production_DATTableAdapter
            Dim modelYear As String = Me.datagridPdata.Item(4, activeRowIndex).Value 'model year
            Dim suffixCode As String = Me.datagridPdata.Item(5, activeRowIndex).Value 'suffix code
            Dim lotNo As String = Me.datagridPdata.Item(7, activeRowIndex).Value 'lot no
            Dim unit As String = Me.datagridPdata.Item(8, activeRowIndex).Value 'unit

            Dim prodDate As String = Me.datagridPdata.Item(12, activeRowIndex).Value 'productionDate
            Dim prodTime As String = Me.datagridPdata.Item(13, activeRowIndex).Value 'productionTime
            Dim seqNo As String = Me.datagridPdata.Item(1, activeRowIndex).Value 'seqNo
            Dim subSeq As Integer = Me.datagridPdata.Item(2, activeRowIndex).Value 'subSeq

            Dim result As Integer

            'If xChange = "0002" Then 'case selected record is InspIn
            '    MessageBox.Show("Already inspection in." & vbCrLf & "cannot delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error)

            '    Exit Sub
            'End If


            If instructFlag = 0 Then
                'delete
                If MessageBox.Show("Do want to delete it?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.OK Then
                    result = taProd.DeleteByPrimaryKey(modelYear, suffixCode, lotNo, unit)
                Else
                    Exit Sub
                End If
            Else
                If MessageBox.Show("Already Instructed it." & vbCrLf & "Do you want to delete it?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.OK Then
                    'delete
                    result = taProd.DeleteByPrimaryKey(modelYear, suffixCode, lotNo, unit)
                End If
            End If

            If result > 0 Then

                result = 0
                result = UpdateBelowDeleteFlag(prodDate, prodTime, seqNo, subSeq)

                result = 0
                result = DeleteInstructionData(modelYear, suffixCode, lotNo, unit)


            End If

            If result > 0 Then 'successful deleted then RELOAD data

                'Dim prodDate As String = ""
                'Dim prodTime As String = ""
                'Dim seqNo As String = ""
                'Dim subSeq As Integer = 0

                prodDate = datagridPdata.Item(12, 0).Value
                prodTime = datagridPdata.Item(13, 0).Value
                seqNo = datagridPdata.Item(1, 0).Value
                subSeq = datagridPdata.Item(2, 0).Value

                ReloadData(prodDate, prodTime, seqNo, subSeq)

                Dim logMSG As String
                logMSG = "Production data SeqNo " & seqNo & "-" & subSeq & " deleted."

                'Write Log
                Dim logger As TLogDat
                logger = New TLogDat
                logger.InsertNewLog(TLogDat.LOG_TYPE_OPERATION, TLogDat.LogLevel.NormalLog, My.Computer.Name, Now, logMSG, Nothing)
            End If

        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "btnF3_Click", ex.Message, "")
        End Try

        Me.datagridPdata.Focus()

    End Sub

    Private Function UpdateBelowDeleteFlag(ByVal prodDate As String, ByVal prodTime As String, ByVal seqNo As String, ByVal subSeq As Integer) As Integer
        Try
            Dim taInst As New DataSet1TableAdapters.T_Instruction_DATTableAdapter
            Dim result As Integer

            Dim dtInstDel As New DataSet1.T_Instruction_DATDataTable
            Dim dtInstUpper As New DataSet1.T_Instruction_DATDataTable

            dtInstDel = taInst.GetDataByProdDateTimeSeqSub(prodDate, prodTime, seqNo, subSeq)

            For Each dr As DataSet1.T_Instruction_DATRow In dtInstDel

                dtInstUpper = taInst.GetDataByPreviousBtn(0, prodDate, prodTime, seqNo, subSeq, dr.Line_No)

                dtInstUpper(0).BelowDelFlag = True
                result = taInst.Update(dtInstUpper)

            Next

            Return result
        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "UpdateBelowDeleteFlag", ex.Message, "")
        End Try
    End Function

    Private Function DeleteInstructionData(ByVal modelYear As String, ByVal suffixCode As String, ByVal lotNo As String, ByVal unit As String) As Integer
        Try
            Dim taInst As New DataSet1TableAdapters.T_Instruction_DATTableAdapter
            Dim result As Integer

            result = taInst.DeleteByPrimaryKey(modelYear, suffixCode, lotNo, unit)
            Return result
        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "DeleteInstructionData", ex.Message, "")
        End Try
    End Function

    'SEARCH button
    Private Sub btnF4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF4.Click
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnF4_Click", "Click Search Button", "")
        Search.ShowDialog(sender)

        Me.datagridPdata.Focus()

    End Sub

    'SKIP button
    Private Sub btnF5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF5.Click
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnF5_Click", "Click Skip Button", "")
        Dim activeRowIndex As Integer = Me.datagridPdata.CurrentCell.RowIndex

        Dim modelYear As String
        Dim suffixCode As String
        Dim lotNo As String
        Dim unit As String
        modelYear = Me.datagridPdata.Item(4, activeRowIndex).Value
        suffixCode = Me.datagridPdata.Item(5, activeRowIndex).Value
        lotNo = Me.datagridPdata.Item(7, activeRowIndex).Value
        unit = Me.datagridPdata.Item(8, activeRowIndex).Value

        Dim dt As New DataSet1.T_Production_DATDataTable
        Dim ta As New DataSet1TableAdapters.T_Production_DATTableAdapter
        ta.FillByPrimaryKey(dt, modelYear, suffixCode, lotNo, unit)

        If dt(0).InstructFlag > 0 Then

            MessageBox.Show("Already Instructed." & vbCrLf & "Cannot skip.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error)

        ElseIf dt(0).XchgFlag.Substring(2, 2) = "02" Then

            MessageBox.Show("Already inspection in." & vbCrLf & "cannot skip.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Else

            Skip.ShowDialog()

        End If

        Me.datagridPdata.Focus()

    End Sub
    'INSERT button
    Private Sub btnF6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF6.Click
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnF6_Click", "Click Insert Button", "")
        Me.Hide()
        Insert.ShowDialog()
        Me.datagridPdata.Focus()
    End Sub
    'INSP-OUT button
    Private Sub btnF10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF10.Click
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnF10_Click", "Click INSP-OUT Button", "")
        Dim activeRowIndex As Integer = Me.datagridPdata.CurrentCell.RowIndex
        Dim xChange As String
        xChange = Me.datagridPdata.Item(120, activeRowIndex).Value

        If xChange.Substring(2, 2) = "01" Then
            MessageBox.Show("Already inspection out." & vbCrLf & "Cannot inspection out again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If xChange.Substring(2, 2) = "02" Then
            MessageBox.Show("Already inspection in." & vbCrLf & "Cannot inspection out again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim instructFlag As Integer
        instructFlag = Me.datagridPdata.Item(121, activeRowIndex).Value

        'If instructFlag = 2 Then
        '    MessageBox.Show("Already Carry Out." & vbCrLf & "Cannot inspection out.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error)

        'Else
        InspOut.ShowDialog()
        'End If

        Me.datagridPdata.Focus()

    End Sub
    'INSP-INS button
    Private Sub btnF11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF11.Click
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnF11_Click", "Click INSP-IN Button", "")
        'Me.Hide()

        Dim activeRowIndex As Integer = Me.datagridPdata.CurrentCell.RowIndex

        Dim modelYear As String
        Dim suffixCode As String
        Dim lotNo As String
        Dim unit As String
        modelYear = Me.datagridPdata.Item(4, activeRowIndex).Value
        suffixCode = Me.datagridPdata.Item(5, activeRowIndex).Value
        lotNo = Me.datagridPdata.Item(7, activeRowIndex).Value
        unit = Me.datagridPdata.Item(8, activeRowIndex).Value

        Dim dt As New DataSet1.T_Production_DATDataTable
        Dim taProd As New DataSet1TableAdapters.T_Production_DATTableAdapter
        taProd.FillByPrimaryKey(dt, modelYear, suffixCode, lotNo, unit)

        'If dt(0).InstructFlag > 0 Then
        Dim res As Boolean
        Dim prYchass As String = dt(0).YChassisFlag

        If prYchass = "" Or prYchass = "0" Then
            'check 2 line
            res = checkProductInsResult_NOXChange(modelYear, suffixCode, lotNo, unit, 1)
            res = res Or checkProductInsResult_NOXChange(modelYear, suffixCode, lotNo, unit, 2)
        ElseIf prYchass = "1" Or prYchass = "2" Then
            'check line 1 only
            res = checkProductInsResult_NOXChange(modelYear, suffixCode, lotNo, unit, 1)
        ElseIf prYchass = "3" Then
            'check line 2 only
            res = checkProductInsResult_NOXChange(modelYear, suffixCode, lotNo, unit, 2)
        End If

        If res Then
            MessageBox.Show("Main Line Already Instructed." & vbCrLf & "Cannot Inspection In at Main Line Instructed Area.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error)

        ElseIf dt(0).XchgFlag.Substring(2, 2) = "02" Then

            MessageBox.Show("This record already inspection in." & vbCrLf & "Cannot Inspection Insert 2 records consecutively.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Else

            'check previous record
            Dim dtPrevious As New DataSet1.T_Production_DATDataTable
            dtPrevious = taProd.GetDataByPreviousBtn(0, dt(0).ProductionDate, dt(0).ProductionTime, _
                                                     dt(0).SeqNo, dt(0).SubSeq)

            If dtPrevious.Count > 0 AndAlso dtPrevious(0).XchgFlag.Substring(2, 2) = "02" Then
                MessageBox.Show("Above record already inspection in." & vbCrLf & "Cannot Inspection Insert 2 records consecutively.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Else
                InspIn.ShowDialog()

            End If

        End If

        Me.datagridPdata.Focus()

    End Sub

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

    Public Function GetData(ByVal prodDate As String, ByVal prodTime As String, _
                            ByVal seqNo As String, ByVal subSeq As Integer) As DataTable
        Try

            Dim ta As New DataSet1TableAdapters.T_Production_DATTableAdapter
            Dim offsetBase As Integer
            Dim dt As New DataSet1.T_Production_DATDataTable

            offsetBase = ta.GetOffsetBase(prodDate, prodTime, seqNo, subSeq)
            dt = ta.GetDataByNextBtn(m_iMaxRowCount, prodDate, prodTime, seqNo, subSeq)

            For Each dr As DataSet1.T_Production_DATRow In dt
                offsetBase += 1
                dr.indexNo = offsetBase
            Next

            Return dt

        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "GetData", ex.Message, "")
            MessageBox.Show(ex.Message)
            Me.Close()
            Return Nothing
        End Try

    End Function


    'Public Function GetRowsCount() As Integer

    '    Dim ta As New DataSet1TableAdapters.T_Production_DATTableAdapter
    '    Dim rowsCount As Integer

    '    rowsCount = ta.GetRowsCount

    '    Return rowsCount

    'End Function

#Region "RELOAD BUTTON"

    'Reload button
    Private Sub btnF9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF9.Click
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnF9_Click", "Click Reload Button", "")

        Dim taProduction As New DataSet1TableAdapters.T_Production_DATTableAdapter
        Dim tmpDtProd As New DataSet1.T_Production_DATDataTable
        Dim tmpDrProd As DataSet1.T_Production_DATRow
        Dim dt As New DataTable

        Dim prodDate As String = ""
        Dim prodTime As String = ""
        Dim seqNo As String = ""
        Dim subSeq As Integer = 0

        prodDate = datagridPdata.Item(12, 0).Value
        prodTime = datagridPdata.Item(13, 0).Value
        seqNo = datagridPdata.Item(1, 0).Value
        subSeq = datagridPdata.Item(2, 0).Value
        Try
            'get up 1 record for Reload
            tmpDtProd = taProduction.GetDataByPreviousBtn(0, prodDate, prodTime, seqNo, subSeq)

            If tmpDtProd.Count > 0 Then
                tmpDrProd = tmpDtProd.Rows(0)

                dt = GetData(tmpDrProd.ProductionDate, tmpDrProd.ProductionTime, tmpDrProd.SeqNo, tmpDrProd.SubSeq)
            Else
                'get first page
                prodDate = ""
                prodTime = ""
                seqNo = ""
                subSeq = 0

                dt = GetData(prodDate, prodTime, seqNo, subSeq)
            End If
            If dt.Rows.Count > 0 Then
                Me.datagridPdata.DataSource = dt
            End If
        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "btnF9_Click", ex.Message, "")
        End Try

        Me.datagridPdata.Focus()

    End Sub

#End Region

    Public Sub ReloadData(ByVal prodDate As String, ByVal prodTime As String, _
                          ByVal seqNo As String, ByVal subSeq As Integer)

        Dim taProduction As New DataSet1TableAdapters.T_Production_DATTableAdapter
        Dim tmpDtProd As New DataSet1.T_Production_DATDataTable
        Dim tmpDrProd As DataSet1.T_Production_DATRow
        Dim dt As New DataTable

        Try
            'get up 1 record for Reload
            tmpDtProd = taProduction.GetDataByPreviousBtn(0, prodDate, prodTime, seqNo, subSeq)

            If tmpDtProd.Count > 0 Then
                tmpDrProd = tmpDtProd.Rows(0)

                dt = GetData(tmpDrProd.ProductionDate, tmpDrProd.ProductionTime, tmpDrProd.SeqNo, tmpDrProd.SubSeq)
            Else
                'get first page
                prodDate = ""
                prodTime = ""
                seqNo = ""
                subSeq = 0

                dt = GetData(prodDate, prodTime, seqNo, subSeq)
            End If

            If dt.Rows.Count > 0 Then
                Me.datagridPdata.DataSource = dt
            End If
        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "ReloadData", ex.Message, "")
        End Try
    End Sub

#Region "NEXT BUTTON"
    'Next button
    Private Sub btnF8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF8.Click

        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnF8_Click", "Click Next Button", "")

        Dim prodDate As String = ""
        Dim prodTime As String = ""
        Dim seqNo As String = ""
        Dim subSeq As Integer = 0
        Dim dt As New DataTable

        Try
            If datagridPdata.Rows.Count = m_iMaxRowCount Then
                prodDate = datagridPdata.Item(12, m_iMaxRowCount - 1).Value
                prodTime = datagridPdata.Item(13, m_iMaxRowCount - 1).Value
                seqNo = datagridPdata.Item(1, m_iMaxRowCount - 1).Value
                subSeq = datagridPdata.Item(2, m_iMaxRowCount - 1).Value

                dt = GetData(prodDate, prodTime, seqNo, subSeq)

                If dt.Rows.Count > 0 Then
                    Me.datagridPdata.DataSource = dt
                End If
            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "btnF8_Click", ex.Message, "")
        End Try

        Me.datagridPdata.Focus()

    End Sub

#End Region

#Region "PERVIOUS BUTTON"
    'Previous button
    Private Sub btnF7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF7.Click

        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnF7_Click", "Click Previous Button", "")

        Dim dt As New DataTable
        Dim taProduction As New DataSet1TableAdapters.T_Production_DATTableAdapter
        Dim tmpDtProd As New DataSet1.T_Production_DATDataTable
        Dim tmpDrProd As DataSet1.T_Production_DATRow
        Dim prodDate As String = ""
        Dim prodTime As String = ""
        Dim seqNo As String = ""
        Dim subSeq As Integer = 0

        prodDate = datagridPdata.Item(12, 0).Value
        prodTime = datagridPdata.Item(13, 0).Value
        seqNo = datagridPdata.Item(1, 0).Value
        subSeq = datagridPdata.Item(2, 0).Value
        Try
            tmpDtProd = taProduction.GetDataByPreviousBtn(m_iMaxRowCount, prodDate, prodTime, seqNo, subSeq)

            If tmpDtProd.Count > 0 Then

                tmpDrProd = tmpDtProd.Rows(0)

                If IsFirstRecord(tmpDrProd) Then
                    prodDate = ""
                    prodTime = ""
                    seqNo = ""
                    subSeq = 0

                    dt = GetData(prodDate, prodTime, seqNo, subSeq)
                Else
                    dt = GetData(tmpDrProd.ProductionDate, tmpDrProd.ProductionTime, tmpDrProd.SeqNo, tmpDrProd.SubSeq)
                End If

                If dt.Rows.Count > 0 Then
                    Me.datagridPdata.DataSource = dt
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "btnF7_Click", ex.Message, "")
        End Try

        Me.datagridPdata.Focus()

    End Sub

#End Region

    Public Function IsFirstRecord(ByVal dr As DataSet1.T_Production_DATRow) As Boolean

        'get first record
        Dim ta As New DataSet1TableAdapters.T_Production_DATTableAdapter
        Dim dtFirst As New DataSet1.T_Production_DATDataTable
        Dim drFirst As DataSet1.T_Production_DATRow
        Dim prodDate As String = ""
        Dim prodTime As String = ""
        Dim seqNo As String = ""
        Dim subSeq As Integer = 0

        dtFirst = ta.GetDataByNextBtn(1, prodDate, prodTime, seqNo, subSeq)
        drFirst = dtFirst(0)

        If (drFirst.ProductionDate = dr.ProductionDate) And (drFirst.ProductionTime = dr.ProductionTime) _
            And (drFirst.SeqNo = dr.SeqNo) And (drFirst.SubSeq = dr.SubSeq) Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub setDatagridColor()

        Dim row As Integer = 0
        Do While row < Me.datagridPdata.RowCount

            Dim instructFlagValue As String = Me.datagridPdata(121, row).Value ' Get InstructFlag
            If instructFlagValue Is DBNull.Value Then
                instructFlagValue = 0
            End If

            If CInt(instructFlagValue) = 2 Then
                Me.datagridPdata.Rows(row).DefaultCellStyle.BackColor = Color.DimGray 'Carry Out
            End If

            If CInt(instructFlagValue) = 1 Then
                Dim xChgFlagValue As String = Me.datagridPdata(120, row).Value ' Get XchgFlag

                Me.datagridPdata.Rows(row).DefaultCellStyle.BackColor = Color.DarkGray

                If xChgFlagValue.ToString.Substring(0, 1) = "2" Then
                    Me.datagridPdata.Rows(row).DefaultCellStyle.BackColor = Color.Yellow
                End If

                If xChgFlagValue.ToString.Substring(0, 1) = "4" Then


                    Dim yChassisFlagValue As String = Me.datagridPdata(15, row).Value ' Get YChassisFlag

                    If yChassisFlagValue = "0" Or yChassisFlagValue = "" Then
                        Me.datagridPdata.Rows(row).DefaultCellStyle.BackColor = Color.ForestGreen
                    End If

                    If yChassisFlagValue = "1" Or yChassisFlagValue = "2" Then
                        Me.datagridPdata.Rows(row).DefaultCellStyle.BackColor = Color.LimeGreen
                    End If

                    If yChassisFlagValue = "3" Then
                        Me.datagridPdata.Rows(row).DefaultCellStyle.BackColor = Color.LightGreen
                    End If

                End If

                If xChgFlagValue.ToString.Substring(2, 2) = "01" Then 'InspOut
                    Me.datagridPdata.Rows(row).DefaultCellStyle.BackColor = Color.Aqua
                Else
                    Me.datagridPdata.Rows(row).DefaultCellStyle.BackColor = Color.DarkGray 'Instructed
                End If

                If xChgFlagValue.ToString.Substring(2, 2) = "02" Then 'InspIn
                    Me.datagridPdata.Rows(row).DefaultCellStyle.BackColor = Color.Magenta
                End If

            End If

            If CInt(instructFlagValue) = 0 Then

                Dim xChgFlagValue As String = Me.datagridPdata(120, row).Value ' Get XchgFlag

                If xChgFlagValue.ToString.Substring(0, 1) = "2" Then 'Insert
                    Me.datagridPdata.Rows(row).DefaultCellStyle.BackColor = Color.Yellow
                End If

                If xChgFlagValue.ToString.Substring(0, 1) = "4" Then 'Addition


                    Dim yChassisFlagValue As String = Me.datagridPdata(15, row).Value ' Get YChassisFlag

                    If yChassisFlagValue = "0" Or yChassisFlagValue = "" Then
                        Me.datagridPdata.Rows(row).DefaultCellStyle.BackColor = Color.ForestGreen 'Line Type = All
                    End If

                    If yChassisFlagValue = "1" Or yChassisFlagValue = "2" Then
                        Me.datagridPdata.Rows(row).DefaultCellStyle.BackColor = Color.LimeGreen 'Line Type = CAB
                    End If

                    If yChassisFlagValue = "3" Then
                        Me.datagridPdata.Rows(row).DefaultCellStyle.BackColor = Color.LightGreen 'Line Type = PUBX
                    End If

                End If

                If xChgFlagValue.ToString.Substring(2, 2) = "01" Then 'InspOut
                    Me.datagridPdata.Rows(row).DefaultCellStyle.BackColor = Color.Aqua
                End If

                If xChgFlagValue.ToString.Substring(2, 2) = "02" Then 'InspIn
                    Me.datagridPdata.Rows(row).DefaultCellStyle.BackColor = Color.Magenta
                End If

            End If

            row += 1
        Loop

    End Sub

    Private Sub setDatagridColWidthIni(ByVal arr As String())
        Dim i As Integer
        Dim array() As String
        array = arr
        For i = 0 To array.Length - 1
            Me.datagridPdata.Columns(i).Width = Integer.Parse(array(i))
        Next
    End Sub

    Private Sub datagridPdata_DataSourceChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles datagridPdata.DataSourceChanged

        setDatagridColor()

    End Sub

    Private Sub ProductionData_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        setDatagridColor()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            Dim aDate As Date = m_clsGetRuntime.getRunTime()
            Dim dt As DataSet1.T_LOG_DATDataTable = DataSet1.T_LOG_DAT
            T_LOG_DATTableAdapter.FillByTop30LogType0_1(dt, aDate)
            'cmboxLogInfo.DataSource = dt
            'cmboxLogInfo.DisplayMember = "logDetail"
            enableAllBtn()
        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "Timer1_Tick", ex.Message, "")
            disableAllBtn()
        End Try
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnClear_Click", "Click Clear Button", "")
        m_clsGetRuntime.setRunTime()
        Me.datagridPdata.Focus()
    End Sub

    Private Sub cmboxLogInfo_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmboxLogInfo.DropDown
        Timer1.Stop()
    End Sub

    Private Sub cmboxLogInfo_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmboxLogInfo.DropDownClosed
        Timer1.Start()
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Label1.Text = Now.ToString("dd MMM yyyy  HH:mm:ss")
    End Sub


    Private Sub calCol()
        DataGridView1.Columns(0).Width = datagridPdata.Columns(0).Width
        DataGridView1.Columns(1).Width = datagridPdata.Columns(1).Width + datagridPdata.Columns(2).Width
        DataGridView1.Columns(2).Width = datagridPdata.Columns(4).Width + datagridPdata.Columns(5).Width
        DataGridView1.Columns(3).Width = datagridPdata.Columns(6).Width + datagridPdata.Columns(7).Width + datagridPdata.Columns(8).Width

        Dim tt As Integer = 0
        Dim i As Integer

        For i = 9 To datagridPdata.Columns.Count - 1
            tt += datagridPdata.Columns(i).Width
        Next

        DataGridView1.Columns(4).Width = tt

        DataGridView1.HorizontalScrollingOffset = datagridPdata.HorizontalScrollingOffset
    End Sub

    'Sync datagridview scroll offset
    Private Sub datagridPdata_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles datagridPdata.Scroll
        DataGridView1.HorizontalScrollingOffset = datagridPdata.HorizontalScrollingOffset
    End Sub

    Private Sub datagridPdata_ColumnHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles datagridPdata.ColumnHeaderMouseClick
        'DataGridView1.HorizontalScrollingOffset = datagridPdata.HorizontalScrollingOffset
        calCol()
    End Sub

    Private Sub datagridPdata_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles datagridPdata.MouseUp
        'DataGridView1.HorizontalScrollingOffset = datagridPdata.HorizontalScrollingOffset
        calCol()
    End Sub

    Private Sub disableAllBtn()
        btnF1.Enabled = False
        btnF2.Enabled = False
        btnF3.Enabled = False
        btnF4.Enabled = False
        btnF5.Enabled = False
        btnF6.Enabled = False
        btnF7.Enabled = False
        btnF8.Enabled = False
        btnF9.Enabled = False
        btnF10.Enabled = False
        btnF11.Enabled = False
        btnF12.Enabled = False
    End Sub

    Private Sub enableAllBtn()
        btnF1.Enabled = True
        btnF2.Enabled = True
        btnF3.Enabled = True
        btnF4.Enabled = True
        btnF5.Enabled = True
        btnF6.Enabled = True
        btnF7.Enabled = True
        btnF8.Enabled = True
        btnF9.Enabled = True
        btnF10.Enabled = True
        btnF11.Enabled = True
        btnF12.Enabled = True
    End Sub


    Private Sub datagridPdata_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles datagridPdata.CellMouseClick

        If e.Button = MouseButtons.Right Then

            If Me.datagridPdata.CurrentRow.Cells(0).Value = Me.datagridPdata.Item(0, e.RowIndex).Value Then

                Dim prodDate As String = ""
                Dim prodTime As String = ""
                Dim seqNo As String = ""
                Dim subSeq As Integer = 0

                prodDate = Me.datagridPdata.Item(12, e.RowIndex).Value
                prodTime = Me.datagridPdata.Item(13, e.RowIndex).Value
                seqNo = Me.datagridPdata.Item(1, e.RowIndex).Value
                subSeq = Me.datagridPdata.Item(2, e.RowIndex).Value

                ReloadData(prodDate, prodTime, seqNo, subSeq)
            End If
        End If

    End Sub


    'Private Sub datagridPdata_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles datagridPdata.KeyDown


    'End Sub

    Private Sub datagridPdata_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles datagridPdata.KeyDown
        If e.Control And e.KeyCode = Keys.T Then
            'If Me.DataGridIdata.CurrentRow.Cells(0).Value = Me.DataGridIdata.Item(0, e.RowIndex).Value Then

            Dim taProduction As New DataSet1TableAdapters.T_Production_DATTableAdapter
            Dim tmpDtProd As New DataSet1.T_Production_DATDataTable
            Dim tmpDrProd As DataSet1.T_Production_DATRow
            Dim dt As New DataTable
            Dim iCurrRow As Integer = datagridPdata.CurrentRow.Index

            'Dim index As Integer = Me.DataGridCdata.Item(0, e.RowIndex).Value
            'dt = GetData(m_iLineNo, index - 1)
            'Me.DataGridCdata.DataSource = dt

            Dim prodDate As String = ""
            Dim prodTime As String = ""
            Dim seqNo As String = ""
            Dim subSeq As Integer = 0
            tmpDtProd = datagridPdata.DataSource
            tmpDrProd = tmpDtProd.Rows(iCurrRow)

            prodDate = tmpDrProd.ProductionDate
            prodTime = tmpDrProd.ProductionTime
            seqNo = tmpDrProd.SeqNo
            subSeq = tmpDrProd.SubSeq
            Try
                tmpDtProd = taProduction.GetDataByPreviousBtn(0, prodDate, prodTime, seqNo, subSeq)

                If tmpDtProd.Count > 0 Then
                    tmpDrProd = tmpDtProd.Rows(0)

                    dt = GetData(tmpDrProd.ProductionDate, tmpDrProd.ProductionTime, tmpDrProd.SeqNo, tmpDrProd.SubSeq)
                Else
                    'get first page
                    prodDate = ""
                    prodTime = ""
                    seqNo = ""
                    subSeq = 0

                    dt = GetData(prodDate, prodTime, seqNo, subSeq)
                End If

                If dt.Rows.Count > 0 Then
                    Me.datagridPdata.DataSource = dt
                End If
            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "datagridPdata_KeyDown", ex.Message, "")
            End Try
        End If
    End Sub
End Class
