Imports Common

Public Class AdditionInsert

#Region "PRIVATE MEMBER"

    'Private m_singletonSqlDb As SingletonSqlDB = SingletonSqlDB.GetInstance()
    'Private Const m_strTableName As String = "T_Production_DAT"

    Protected m_primaryKeyValueList As ArrayList

#End Region


#Region "Private Method"
    Public Overloads Sub Initialize(ByVal primaryKeyValueList As ArrayList)
        m_primaryKeyValueList = primaryKeyValueList
    End Sub
#End Region

    Public m_iMaxRowCount As Integer = ModConstant.PRODUCTION_DATA_SIZE_PER_PAGE
    Dim logger As Logger = New Logger()


    Private Sub AdditionInsert_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyData
            Case Keys.F1
                btnF1_Click(sender, e)
            Case Keys.F2
                btnF2_Click(sender, e)
            Case Keys.F4
                btnF4_Click(sender, e)
            Case Keys.F7
                btnF7_Click(sender, e)
            Case Keys.F8
                btnF8_Click(sender, e)
            Case Keys.F9
                btnF9_Click(sender, e)
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

    Private Sub ProductionData_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "ProductionData_Load", "Load Production Screen", "")
        Main_Menu.Hide()
        'DetailedDataEdit.Hide()
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
            Me.SetTopLevel(True)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "ProductionData_Load", ex.Message, "")
        End Try

    End Sub

    Private Sub datagridPdata_DataSourceChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles datagridPdata.DataSourceChanged

        setDatagridColor()

    End Sub

    Private Sub ProductionData_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        setDatagridColor()
    End Sub

    'Public Function GetData(ByVal indexNo As Integer) As DataTable
    '    Try
    '        Dim ta As New DataSet1TableAdapters.T_Production_DATTableAdapter
    '        Dim dt As New DataTable

    '        dt = ta.GetDataByIndexNo(indexNo)

    '        Return dt
    '    Catch ex As Exception
    '        logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "GetData", "Unable to connect the database.", "")
    '        Return Nothing
    '    End Try
    'End Function

    Public Function GetData(ByVal prodDate As String, ByVal prodTime As String, _
                            ByVal seqNo As String, ByVal subSeq As Integer) As DataTable
        Try

            Dim ta As New DataSet1TableAdapters.T_Production_DATTableAdapter
            Dim offsetBase As New Integer
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

    'SEARCH button
    Private Sub btnF4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF4.Click
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnF4_Click", "Click Search Button", "")
        Search.ShowDialog(sender)
    End Sub

    'Reload button
    Private Sub btnF9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF9.Click
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnF9_Click", "Click Reload Button", "")
        'Dim indexNo As Integer
        'indexNo = datagridPdata.Item(0, 0).Value
        'ReloadData(indexNo)

        Dim taProduction As New DataSet1TableAdapters.T_Production_DATTableAdapter
        Dim tmpDtProd As New DataSet1.T_Production_DATDataTable
        Dim tmpDrProd As DataSet1.T_Production_DATRow

        Dim prodDate As String = ""
        Dim prodTime As String = ""
        Dim seqNo As String = ""
        Dim subSeq As Integer = 0
        Dim dt As New DataTable

        prodDate = datagridPdata.Item(12, 0).Value
        prodTime = datagridPdata.Item(13, 0).Value
        seqNo = datagridPdata.Item(1, 0).Value
        subSeq = datagridPdata.Item(2, 0).Value

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

        Me.datagridPdata.DataSource = dt

    End Sub

    'Public Sub ReloadData(ByVal inDexNo As String)

    '    Dim dt As New DataTable

    '    dt = GetData(inDexNo - 1)

    '    Me.datagridPdata.DataSource = dt

    'End Sub

    Public Sub ReloadData(ByVal prodDate As String, ByVal prodTime As String, _
                          ByVal seqNo As String, ByVal subSeq As Integer)
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "ReloadData", "Start", "")
        Try
            Dim taProduction As New DataSet1TableAdapters.T_Production_DATTableAdapter
            Dim tmpDtProd As New DataSet1.T_Production_DATDataTable
            Dim tmpDrProd As DataSet1.T_Production_DATRow
            Dim dt As New DataTable

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

            Me.datagridPdata.DataSource = dt
            logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "ReloadData", "End", "")
        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "ReloadData", ex.StackTrace, "")
        End Try

    End Sub

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

            MessageBox.Show("End of data!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End Try

    End Sub

    'PREVIOUS button
    Private Sub btnF7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF7.Click
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnF7_Click", "Click Previous Button", "")
        Try
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

            tmpDtProd = taProduction.GetDataByPreviousBtn(m_iMaxRowCount, prodDate, prodTime, seqNo, subSeq)

            If tmpDtProd.Count > 0 Then

                tmpDrProd = tmpDtProd.Rows(0)

                If ProductionData.IsFirstRecord(tmpDrProd) Then
                    prodDate = ""
                    prodTime = ""
                    seqNo = ""
                    subSeq = 0

                    dt = GetData(prodDate, prodTime, seqNo, subSeq)
                Else
                    dt = GetData(tmpDrProd.ProductionDate, tmpDrProd.ProductionTime, tmpDrProd.SeqNo, tmpDrProd.SubSeq)
                End If

                Me.datagridPdata.DataSource = dt
            End If
            logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnF7_Click", "End", "")
        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "btnF7_Click", ex.StackTrace, "")
        End Try

    End Sub


    'INSERT button
    Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnF1_Click", "Click Insert Button", "")
        Try
            Dim taProd As New DataSet1TableAdapters.T_Production_DATTableAdapter
            Dim activeRowIndex As Integer = Me.datagridPdata.CurrentCell.RowIndex
            Dim indexNo As Integer
            indexNo = Me.datagridPdata.Item(0, activeRowIndex).Value

            If Me.datagridPdata.Item(121, activeRowIndex).Value > 0 Then 'check instruct flag

                MessageBox.Show("Cannot addition at instructed area.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Else 'can Addition Insert

                Dim selectedProdDate As String = Me.datagridPdata.Item(12, activeRowIndex).Value.ToString()
                Dim selectedProdTime As String = Me.datagridPdata.Item(13, activeRowIndex).Value.ToString()
                Dim selectedSeqNo As String = Me.datagridPdata.Item(1, activeRowIndex).Value.ToString()
                Dim selectedSub As String = Me.datagridPdata.Item(2, activeRowIndex).Value.ToString()

                Try
                    Using ts As New TransactionScope
                        If activeRowIndex <> 0 Then

                            Dim baseSeqNo As String = Me.datagridPdata.Item(1, activeRowIndex - 1).Value.ToString()
                            Dim baseSub As String = Me.datagridPdata.Item(2, activeRowIndex - 1).Value.ToString()
                            Dim baseProdDate As String = Me.datagridPdata.Item(12, activeRowIndex - 1).Value.ToString()
                            Dim baseProdTime As String = Me.datagridPdata.Item(13, activeRowIndex - 1).Value.ToString()

                            'If baseSeqNo = selectedSeqNo Then 'insert between same seq
                            InsertSeqAndSub.ReorderSubSeq(baseSeqNo, baseSub, baseProdDate, baseProdTime) 'accumulate sub seq then have space for new insert
                            'End If

                            InsertData(baseSeqNo, baseSub + 1, baseProdDate, baseProdTime)

                        Else

                            If indexNo = 1 Then 'First record
                                Dim curProdDate As String = Me.datagridPdata.Item(12, activeRowIndex).Value 'Prod Date
                                Dim curProdTime As String = Me.datagridPdata.Item(13, activeRowIndex).Value 'Prod Time
                                Dim curSeqNo As String = "00000"
                                Dim curSub As Integer = 0

                                InsertSeqAndSub.ReorderSubSeq(curSeqNo, curSub, curProdDate, curProdTime) 'accumulate sub seq then have space for new insert

                                InsertData(curSeqNo, 1, curProdDate, curProdTime)


                            Else 'first row but not first record

                                Dim pDt As New DataSet1.T_Production_DATDataTable

                                'pDt = taProd.GetDataBySeqNo_ProductionDate(selectedProdDate, selectedSeqNo)
                                pDt = taProd.GetDataBySeqNoProductionDateTime(selectedSeqNo, selectedProdDate, selectedProdTime)

                                Dim qDt As New DataSet1.T_Production_DATDataTable
                                qDt = taProd.GetDataByPreviousBtn(0, selectedProdDate, selectedProdTime, selectedSeqNo, selectedSub)

                                Dim baseSeqNo As String = qDt.Rows(0)("SeqNo").ToString()
                                Dim baseSub As String = qDt.Rows(0)("SubSeq").ToString()
                                Dim baseProdDate As String = qDt.Rows(0)("productionDate").ToString()
                                Dim baseProdTime As String = qDt.Rows(0)("productionTime").ToString()

                                If pDt.Rows.Count > 1 Then
                                    InsertSeqAndSub.ReorderSubSeq(baseSeqNo, baseSub, baseProdDate, baseProdTime) 'accumulate sub seq then have space for new insert
                                End If

                                InsertData(baseSeqNo, baseSub + 1, baseProdDate, baseProdTime)

                            End If

                        End If

                        'Insert Instruction Data
                        Dim manageInstructData As New ManageInstructionData
                        manageInstructData.InsertProductionRowToInstruction(m_primaryKeyValueList)
                        ts.Complete()
                    End Using

                Catch ex As Exception
                    logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "btnF1_Click", ex.StackTrace, "")
                    MessageBox.Show("Insert Fail", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Throw New Exception("Exception Occurred")
                End Try
                'Reload Production Data
                Dim prodDate As String = ""
                Dim prodTime As String = ""
                Dim seqNo As String = ""
                Dim subSeq As Integer = 0

                If activeRowIndex > 0 Then

                    prodDate = datagridPdata.Item(12, activeRowIndex - 1).Value
                    prodTime = datagridPdata.Item(13, activeRowIndex - 1).Value
                    seqNo = datagridPdata.Item(1, activeRowIndex - 1).Value
                    subSeq = datagridPdata.Item(2, activeRowIndex - 1).Value

                Else

                    Dim qDt As New DataSet1.T_Production_DATDataTable
                    qDt = taProd.GetDataByPreviousBtn(0, selectedProdDate, selectedProdTime, selectedSeqNo, selectedSub)
                    If qDt.Count > 0 Then
                        prodDate = qDt(0).ProductionDate
                        prodTime = qDt(0).ProductionTime
                        seqNo = qDt(0).SeqNo
                        subSeq = qDt(0).SubSeq
                    Else
                        prodDate = ""
                        prodTime = ""
                        seqNo = ""
                        subSeq = 0
                    End If

                End If

                ProductionData.Show()
                ProductionData.ReloadData(prodDate, prodTime, seqNo, subSeq)
                logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnF1_Click", "End", "")

                DetailedDataEdit.Dispose()
                Me.Dispose()

            End If
        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "btnF1_Click", ex.StackTrace, "")
        End Try

    End Sub

    Private Sub InsertData(ByVal seqNo As String, ByVal subSeq As Integer, ByVal prodDate As String, ByVal prodTime As String)
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "InsertData", "Start", "")
        Try
            Dim ta As New DataSet1TableAdapters.T_Production_DATTableAdapter
            Dim pDt As New DataSet1.T_Production_DATDataTable
            Dim dr As DataRow

            dr = pDt.NewRow

            dr.Item("SeqNo") = seqNo
            dr.Item("ModelYear") = m_primaryKeyValueList(0).ToString()
            dr.Item("SuffixCode") = m_primaryKeyValueList(1).ToString()
            dr.Item("LotId") = m_primaryKeyValueList(4).ToString()
            dr.Item("LotNo") = m_primaryKeyValueList(2).ToString()
            dr.Item("Unit") = m_primaryKeyValueList(3).ToString()
            dr.Item("BlockModel") = m_primaryKeyValueList(5).ToString()
            dr.Item("BlockSeq") = DetailedDataEdit.txtBlockSeq.Text
            dr.Item("ProductionDate") = prodDate
            dr.Item("ProductionTime") = prodTime
            dr.Item("ImportCode") = m_primaryKeyValueList(7).ToString()
            dr.Item("Mark") = m_primaryKeyValueList(8).ToString()

            Dim yChassis As String = m_primaryKeyValueList(9).ToString()
            If yChassis = "" Then
                dr.Item("YChassisFlag") = "0"
            ElseIf yChassis = "1" Then
                dr.Item("YChassisFlag") = "2"
            Else
                dr.Item("YChassisFlag") = yChassis
            End If

            dr.Item("GaShop") = m_primaryKeyValueList(10).ToString()
            dr.Item("HanmmerYears") = m_primaryKeyValueList(11).ToString()



            Dim dt As New DataTable
            dt = DetailedDataEdit.datagirdEdit.DataSource
            For Each aDR In dt.Rows

                If (aDR("LineCode").ToString = "1") Then

                    dr.Item("Model01Asm01") = aDR(newColumnName1).ToString
                    dr.Item("Model01Asm02") = aDR(newColumnName2).ToString
                    dr.Item("Model01Asm03") = aDR(newColumnName3).ToString
                    dr.Item("Model01Asm04") = aDR(newColumnName4).ToString
                    dr.Item("Model01Asm05") = aDR(newColumnName5).ToString
                End If

                If (aDR("LineCode").ToString = "2") Then

                    dr.Item("Model02Asm01") = aDR(newColumnName1).ToString
                    dr.Item("Model02Asm02") = aDR(newColumnName2).ToString
                    dr.Item("Model02Asm03") = aDR(newColumnName3).ToString
                    dr.Item("Model02Asm04") = aDR(newColumnName4).ToString
                    dr.Item("Model02Asm05") = aDR(newColumnName5).ToString
                End If

                If (aDR("LineCode").ToString = "3") Then

                    dr.Item("Model03Asm01") = aDR(newColumnName1).ToString
                    dr.Item("Model03Asm02") = aDR(newColumnName2).ToString
                    dr.Item("Model03Asm03") = aDR(newColumnName3).ToString
                    dr.Item("Model03Asm04") = aDR(newColumnName4).ToString
                    dr.Item("Model03Asm05") = aDR(newColumnName5).ToString
                End If

                If (aDR("LineCode").ToString = "4") Then

                    dr.Item("Model04Asm01") = aDR(newColumnName1).ToString
                    dr.Item("Model04Asm02") = aDR(newColumnName2).ToString
                    dr.Item("Model04Asm03") = aDR(newColumnName3).ToString
                    dr.Item("Model04Asm04") = aDR(newColumnName4).ToString
                    dr.Item("Model04Asm05") = aDR(newColumnName5).ToString
                End If

                If (aDR("LineCode").ToString = "5") Then

                    dr.Item("Model05Asm01") = aDR(newColumnName1).ToString
                    dr.Item("Model05Asm02") = aDR(newColumnName2).ToString
                    dr.Item("Model05Asm03") = aDR(newColumnName3).ToString
                    dr.Item("Model05Asm04") = aDR(newColumnName4).ToString
                    dr.Item("Model05Asm05") = aDR(newColumnName5).ToString
                End If

                If (aDR("LineCode").ToString = "6") Then

                    dr.Item("Model06Asm01") = aDR(newColumnName1).ToString
                    dr.Item("Model06Asm02") = aDR(newColumnName2).ToString
                    dr.Item("Model06Asm03") = aDR(newColumnName3).ToString
                    dr.Item("Model06Asm04") = aDR(newColumnName4).ToString
                    dr.Item("Model06Asm05") = aDR(newColumnName5).ToString
                End If

                If (aDR("LineCode").ToString = "7") Then

                    dr.Item("Model07Asm01") = aDR(newColumnName1).ToString
                    dr.Item("Model07Asm02") = aDR(newColumnName2).ToString
                    dr.Item("Model07Asm03") = aDR(newColumnName3).ToString
                    dr.Item("Model07Asm04") = aDR(newColumnName4).ToString
                    dr.Item("Model07Asm05") = aDR(newColumnName5).ToString
                End If

                If (aDR("LineCode").ToString = "8") Then

                    dr.Item("Model08Asm01") = aDR(newColumnName1).ToString
                    dr.Item("Model08Asm02") = aDR(newColumnName2).ToString
                    dr.Item("Model08Asm03") = aDR(newColumnName3).ToString
                    dr.Item("Model08Asm04") = aDR(newColumnName4).ToString
                    dr.Item("Model08Asm05") = aDR(newColumnName5).ToString
                End If

                If (aDR("LineCode").ToString = "9") Then

                    dr.Item("Model09Asm01") = aDR(newColumnName1).ToString
                    dr.Item("Model09Asm02") = aDR(newColumnName2).ToString
                    dr.Item("Model09Asm03") = aDR(newColumnName3).ToString
                    dr.Item("Model09Asm04") = aDR(newColumnName4).ToString
                    dr.Item("Model09Asm05") = aDR(newColumnName5).ToString
                End If

                If (aDR("LineCode").ToString = "10") Then

                    dr.Item("Model10Asm01") = aDR(newColumnName1).ToString
                    dr.Item("Model10Asm02") = aDR(newColumnName2).ToString
                    dr.Item("Model10Asm03") = aDR(newColumnName3).ToString
                    dr.Item("Model10Asm04") = aDR(newColumnName4).ToString
                    dr.Item("Model10Asm05") = aDR(newColumnName5).ToString
                End If

                If (aDR("LineCode").ToString = "11") Then

                    dr.Item("Model11Asm01") = aDR(newColumnName1).ToString
                    dr.Item("Model11Asm02") = aDR(newColumnName2).ToString
                    dr.Item("Model11Asm03") = aDR(newColumnName3).ToString
                    dr.Item("Model11Asm04") = aDR(newColumnName4).ToString
                    dr.Item("Model11Asm05") = aDR(newColumnName5).ToString
                End If

                If (aDR("LineCode").ToString = "12") Then

                    dr.Item("Model12Asm01") = aDR(newColumnName1).ToString
                    dr.Item("Model12Asm02") = aDR(newColumnName2).ToString
                    dr.Item("Model12Asm03") = aDR(newColumnName3).ToString
                    dr.Item("Model12Asm04") = aDR(newColumnName4).ToString
                    dr.Item("Model12Asm05") = aDR(newColumnName5).ToString
                End If

                If (aDR("LineCode").ToString = "13") Then

                    dr.Item("Model13Asm01") = aDR(newColumnName1).ToString
                    dr.Item("Model13Asm02") = aDR(newColumnName2).ToString
                    dr.Item("Model13Asm03") = aDR(newColumnName3).ToString
                    dr.Item("Model13Asm04") = aDR(newColumnName4).ToString
                    dr.Item("Model13Asm05") = aDR(newColumnName5).ToString
                End If

                If (aDR("LineCode").ToString = "14") Then

                    dr.Item("Model14Asm01") = aDR(newColumnName1).ToString
                    dr.Item("Model14Asm02") = aDR(newColumnName2).ToString
                    dr.Item("Model14Asm03") = aDR(newColumnName3).ToString
                    dr.Item("Model14Asm04") = aDR(newColumnName4).ToString
                    dr.Item("Model14Asm05") = aDR(newColumnName5).ToString
                End If

                If (aDR("LineCode").ToString = "15") Then

                    dr.Item("Model15Asm01") = aDR(newColumnName1).ToString
                    dr.Item("Model15Asm02") = aDR(newColumnName2).ToString
                    dr.Item("Model15Asm03") = aDR(newColumnName3).ToString
                    dr.Item("Model15Asm04") = aDR(newColumnName4).ToString
                    dr.Item("Model15Asm05") = aDR(newColumnName5).ToString
                End If

                If (aDR("LineCode").ToString = "16") Then

                    dr.Item("Model16Asm01") = aDR(newColumnName1).ToString
                    dr.Item("Model16Asm02") = aDR(newColumnName2).ToString
                    dr.Item("Model16Asm03") = aDR(newColumnName3).ToString
                    dr.Item("Model16Asm04") = aDR(newColumnName4).ToString
                    dr.Item("Model16Asm05") = aDR(newColumnName5).ToString
                End If

                If (aDR("LineCode").ToString = "17") Then

                    dr.Item("Model17Asm01") = aDR(newColumnName1).ToString
                    dr.Item("Model17Asm02") = aDR(newColumnName2).ToString
                    dr.Item("Model17Asm03") = aDR(newColumnName3).ToString
                    dr.Item("Model17Asm04") = aDR(newColumnName4).ToString
                    dr.Item("Model17Asm05") = aDR(newColumnName5).ToString
                End If

                If (aDR("LineCode").ToString = "18") Then

                    dr.Item("Model18Asm01") = aDR(newColumnName1).ToString
                    dr.Item("Model18Asm02") = aDR(newColumnName2).ToString
                    dr.Item("Model18Asm03") = aDR(newColumnName3).ToString
                    dr.Item("Model18Asm04") = aDR(newColumnName4).ToString
                    dr.Item("Model18Asm05") = aDR(newColumnName5).ToString
                End If

                If (aDR("LineCode").ToString = "19") Then

                    dr.Item("Model19Asm01") = aDR(newColumnName1).ToString
                    dr.Item("Model19Asm02") = aDR(newColumnName2).ToString
                    dr.Item("Model19Asm03") = aDR(newColumnName3).ToString
                    dr.Item("Model19Asm04") = aDR(newColumnName4).ToString
                    dr.Item("Model19Asm05") = aDR(newColumnName5).ToString
                End If

                If (aDR("LineCode").ToString = "20") Then

                    dr.Item("Model20Asm01") = aDR(newColumnName1).ToString
                    dr.Item("Model20Asm02") = aDR(newColumnName2).ToString
                    dr.Item("Model20Asm03") = aDR(newColumnName3).ToString
                    dr.Item("Model20Asm04") = aDR(newColumnName4).ToString
                    dr.Item("Model20Asm05") = aDR(newColumnName5).ToString
                End If

            Next
            'dr.Item("Reserve01") = ""
            'dr.Item("Reserve02") = ""
            dr.Item("SubSeq") = subSeq
            dr.Item("XchgFlag") = "4000" 'Flag for Added record
            dr.Item("InstructFlag") = 0
            'dr.Item("FileName") = ""

            pDt.Rows.Add(dr)

            Dim result As Integer

            result = ta.Update(pDt)

            Dim logMSG As String
            logMSG = "Production data SeqNo " & seqNo & "-" & subSeq & " inserted."

            'Write Log
            Dim logger As TLogDat
            logger = New TLogDat
            logger.InsertNewLog(TLogDat.LOG_TYPE_OPERATION, TLogDat.LogLevel.NormalLog, My.Computer.Name, Now, logMSG, Nothing)
        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "InsertData", ex.StackTrace, "")
        End Try
    End Sub

    'CANCEL button
    Private Sub btnF2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF2.Click
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnF2_Click", "Click Cancel Button", "")
        ProductionData.Show()
        DetailedDataEdit.Dispose()
        Me.Dispose()
        'Dim prodDate As String = ""
        'Dim prodTime As String = ""
        'Dim seqNo As String = ""
        'Dim subSeq As Integer = 0
        'ProductionData.ReloadData(prodDate, prodTime, seqNo, subSeq)
    End Sub


    Private Sub AdditionInsert_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        DetailedDataEdit.Dispose()

        Dim prodDate As String = ""
        Dim prodTime As String = ""
        Dim seqNo As String = ""
        Dim subSeq As Integer = 0
        ProductionData.Show()
        'ProductionData.ReloadData(prodDate, prodTime, seqNo, subSeq)
    End Sub

    Private Sub setDatagridColor()
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "setDatagridColor", "Start", "")
        Try
            Dim row As Integer = 0
            Do While row < Me.datagridPdata.RowCount

                Dim instructFlagValue As Object = Me.datagridPdata(121, row).Value ' Get InstructFlag
                If instructFlagValue Is DBNull.Value Then
                    instructFlagValue = 0
                End If

                If CInt(instructFlagValue) = 2 Then
                    Me.datagridPdata.Rows(row).DefaultCellStyle.BackColor = Color.DimGray
                End If

                'If CInt(instructFlagValue) = 1 Then

                '    Dim xChgFlagValue As String = Me.datagridPdata(120, row).Value ' Get XchgFlag

                '    Me.datagridPdata.Rows(row).DefaultCellStyle.BackColor = Color.DarkGray

                '    If xChgFlagValue.ToString = "0001" Then
                '        Me.datagridPdata.Rows(row).DefaultCellStyle.BackColor = Color.Aqua
                '    Else
                '        Me.datagridPdata.Rows(row).DefaultCellStyle.BackColor = Color.DarkGray 'Instructed
                '    End If

                '    If xChgFlagValue.ToString = "0002" Then
                '        Me.datagridPdata.Rows(row).DefaultCellStyle.BackColor = Color.Magenta
                '    End If

                '    If xChgFlagValue.ToString = "2000" Then
                '        Me.datagridPdata.Rows(row).DefaultCellStyle.BackColor = Color.Yellow
                '    End If

                '    If xChgFlagValue.ToString = "4000" Then


                '        Dim yChassisFlagValue As String = Me.datagridPdata(15, row).Value ' Get YChassisFlag

                '        If yChassisFlagValue = "0" Or yChassisFlagValue = "" Then
                '            Me.datagridPdata.Rows(row).DefaultCellStyle.BackColor = Color.LimeGreen
                '        End If

                '        If yChassisFlagValue = "1" Or yChassisFlagValue = "2" Then
                '            Me.datagridPdata.Rows(row).DefaultCellStyle.BackColor = Color.LightGreen
                '        End If

                '        If yChassisFlagValue = "3" Then
                '            Me.datagridPdata.Rows(row).DefaultCellStyle.BackColor = Color.PaleGreen
                '        End If

                '    End If

                'End If
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

                'If CInt(instructFlagValue) = 0 Then

                '    Dim xChgFlagValue As Object = Me.datagridPdata(120, row).Value ' Get XchgFlag

                '    If xChgFlagValue.ToString = "0001" Then
                '        Me.datagridPdata.Rows(row).DefaultCellStyle.BackColor = Color.Aqua
                '    End If

                '    If xChgFlagValue.ToString = "0002" Then
                '        Me.datagridPdata.Rows(row).DefaultCellStyle.BackColor = Color.Magenta
                '    End If

                '    If xChgFlagValue.ToString = "2000" Then
                '        Me.datagridPdata.Rows(row).DefaultCellStyle.BackColor = Color.Yellow
                '    End If

                '    If xChgFlagValue.ToString = "4000" Then

                '        Dim yChassisFlagValue As Object = Me.datagridPdata(15, row).Value ' Get YChassisFlag

                '        If yChassisFlagValue = "0" Or yChassisFlagValue = "" Then
                '            Me.datagridPdata.Rows(row).DefaultCellStyle.BackColor = Color.LimeGreen
                '        End If

                '        If yChassisFlagValue = "1" Or yChassisFlagValue = "2" Then
                '            Me.datagridPdata.Rows(row).DefaultCellStyle.BackColor = Color.LightGreen
                '        End If

                '        If yChassisFlagValue = "3" Then
                '            Me.datagridPdata.Rows(row).DefaultCellStyle.BackColor = Color.PaleGreen
                '        End If

                '    End If

                'End If
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
            logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "setDatagridColor", "End", "")
        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "setDatagridColor", ex.StackTrace, "")
        End Try
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