Imports Common

Public Class CarryOutSch

#Region "PRIVATE MEMBER"

    Private m_clsGetRuntime As clsGetRuntime = clsGetRuntime.GetInstance()
    Private m_taProd As New DataSet1TableAdapters.T_Production_DATTableAdapter
    Private m_taInst As New DataSet1TableAdapters.T_Instruction_DATTableAdapter
    Private m_taLog As New DataSet1TableAdapters.T_LOG_DATTableAdapter
    Private m_taLine As New DataSet1TableAdapters.T_Line_MSTTableAdapter

    Private m_dtProd As New DataSet1.T_Production_DATDataTable
    Private m_dtInst As New DataSet1.T_Instruction_DATDataTable
    Private m_dtLog As New DataSet1.T_LOG_DATDataTable
    Private m_dtLine As New DataSet1.T_Line_MSTDataTable

    Private m_dtTempInst As New DataSet1.T_Instruction_DATDataTable

    Dim logger As Logger = New Logger()
#End Region

#Region "PUBLIC MEMBER"

    Public m_firstOpen As Boolean = False
    Public m_iLineNo As Integer
    Public m_strLineName As String = ""
    Public m_iMaxRowCount As Integer = ModConstant.CARRYOUT_DATA_SIZE_PER_PAGE
    'Public T_Line_MST_Dt As DataSet1.T_Line_MSTDataTable = DataSet1.T_Line_MST
    Private Const SCREEN_NAME As String = "CARRYOUT_SCHEDULE"

#End Region

    Dim tempButton As System.Windows.Forms.Button

#Region "20LINE BUTTON CLICK"

    Private Sub btnLine1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLine1.Click
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnLine1_Click", "Click Line1 Button", "")
        m_iLineNo = 1
        setColorSelectedButton(sender)
        GetDataByLine(m_iLineNo)
    End Sub

    Private Sub btnLine2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLine2.Click
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnLine2_Click", "Click Line2 Button", "")
        m_iLineNo = 2
        setColorSelectedButton(sender)
        GetDataByLine(m_iLineNo)
    End Sub

    Private Sub btnLine3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLine3.Click
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnLine3_Click", "Click Line3 Button", "")
        m_iLineNo = 3
        setColorSelectedButton(sender)
        GetDataByLine(m_iLineNo)
    End Sub

    Private Sub btnLine4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLine4.Click
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnLine4_Click", "Click Line4 Button", "")
        m_iLineNo = 4
        setColorSelectedButton(sender)
        GetDataByLine(m_iLineNo)
    End Sub

    Private Sub btnLine5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLine5.Click
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnLine5_Click", "Click Line5 Button", "")
        m_iLineNo = 5
        setColorSelectedButton(sender)
        GetDataByLine(m_iLineNo)
    End Sub

    Private Sub btnLine6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLine6.Click
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnLine6_Click", "Click Line6 Button", "")
        m_iLineNo = 6
        setColorSelectedButton(sender)
        GetDataByLine(m_iLineNo)
    End Sub

    Private Sub btnLine7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLine7.Click
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnLine7_Click", "Click Line7 Button", "")
        m_iLineNo = 7
        setColorSelectedButton(sender)
        GetDataByLine(m_iLineNo)
    End Sub

    Private Sub btnLine8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLine8.Click
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnLine8_Click", "Click Line8 Button", "")
        m_iLineNo = 8
        setColorSelectedButton(sender)
        GetDataByLine(m_iLineNo)
    End Sub

    Private Sub btnLine9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLine9.Click
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnLine9_Click", "Click Line9 Button", "")
        m_iLineNo = 9
        setColorSelectedButton(sender)
        GetDataByLine(m_iLineNo)
    End Sub

    Private Sub btnLine10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLine10.Click
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnLine10_Click", "Click Line10 Button", "")
        m_iLineNo = 10
        setColorSelectedButton(sender)
        GetDataByLine(m_iLineNo)
    End Sub

    Private Sub btnLine11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLine11.Click
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnLine11_Click", "Click Line11 Button", "")
        m_iLineNo = 11
        setColorSelectedButton(sender)
        GetDataByLine(m_iLineNo)
    End Sub

    Private Sub btnLine12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLine12.Click
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnLine12_Click", "Click Line12 Button", "")
        m_iLineNo = 12
        setColorSelectedButton(sender)
        GetDataByLine(m_iLineNo)
    End Sub

    Private Sub btnLine13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLine13.Click
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnLine13_Click", "Click Line13 Button", "")
        m_iLineNo = 13
        setColorSelectedButton(sender)
        GetDataByLine(m_iLineNo)
    End Sub

    Private Sub btnLine14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLine14.Click
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnLine14_Click", "Click Line14 Button", "")
        m_iLineNo = 14
        setColorSelectedButton(sender)
        GetDataByLine(m_iLineNo)
    End Sub

    Private Sub btnLine15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLine15.Click
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnLine15_Click", "Click Line15 Button", "")
        m_iLineNo = 15
        setColorSelectedButton(sender)
        GetDataByLine(m_iLineNo)
    End Sub

    Private Sub btnLine16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLine16.Click
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnLine16_Click", "Click Line16 Button", "")
        m_iLineNo = 16
        setColorSelectedButton(sender)
        GetDataByLine(m_iLineNo)
    End Sub

    Private Sub btnLine17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLine17.Click
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnLine17_Click", "Click Line17 Button", "")
        m_iLineNo = 17
        setColorSelectedButton(sender)
        GetDataByLine(m_iLineNo)
    End Sub

    Private Sub btnLine18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLine18.Click
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnLine18_Click", "Click Line18 Button", "")
        m_iLineNo = 18
        setColorSelectedButton(sender)
        GetDataByLine(m_iLineNo)
    End Sub

    Private Sub btnLine19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLine19.Click
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnLine19_Click", "Click Line19 Button", "")
        m_iLineNo = 19
        setColorSelectedButton(sender)
        GetDataByLine(m_iLineNo)
    End Sub

    Private Sub btnLine20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLine20.Click
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnLine20_Click", "Click Line20 Button", "")
        m_iLineNo = 20
        setColorSelectedButton(sender)
        GetDataByLine(m_iLineNo)
    End Sub

#End Region

    Private Sub btnF12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click


        Me.Close()

    End Sub

    Private Sub setColorSelectedButton(ByVal selectedButton As System.Windows.Forms.Button)

        'clear color other button
        If tempButton IsNot Nothing Then
            tempButton.BackColor = Color.MistyRose
        End If


        tempButton = selectedButton
        tempButton.BackColor = Color.Yellow

    End Sub

    Private Sub GetDataByLine(ByVal lineNo As Integer)
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "GetDataByLine", "Get Data By Line Start", "")

        Dim dt As DataSet1.T_Instruction_DATDataTable = Me.m_dtInst
        Dim taInstruction As DataSet1TableAdapters.T_Instruction_DATTableAdapter = Me.m_taInst
        Dim tmpDtIns As New DataSet1.T_Instruction_DATDataTable
        Dim tmpDrIns As DataSet1.T_Instruction_DATRow
        Dim prodDate As String = ""
        Dim prodTime As String = ""
        Dim seqNo As String = ""
        Dim subSeq As Integer = 0

        Try
            m_strLineName = m_taLine.GetLineName(lineNo)
            tmpDtIns = taInstruction.GetDataByCurrentCarryOutRow(lineNo)
            If tmpDtIns.Rows.Count > 0 Then     'If orange exist
                tmpDrIns = tmpDtIns.Rows(0)

                prodDate = tmpDrIns.ProductionDate
                prodTime = tmpDrIns.ProductionTime
                seqNo = tmpDrIns.SeqNo
                subSeq = tmpDrIns.SubSeq
                tmpDtIns = taInstruction.GetDataByPreviousBtn(CInt(m_iMaxRowCount / 2), prodDate, prodTime, seqNo, subSeq, m_iLineNo)
                If tmpDtIns.Count > 0 Then
                    'Half page before orange exist
                    tmpDrIns = tmpDtIns.Rows(0)
                    If IsFirstRecord(tmpDrIns) Then
                        prodDate = ""
                        prodTime = ""
                        seqNo = ""
                        subSeq = 0

                        dt = GetData(m_iLineNo, prodDate, prodTime, seqNo, subSeq)
                        DataGridCdata.DataSource = dt
                    Else
                        dt = GetData(m_iLineNo, tmpDrIns.ProductionDate, tmpDrIns.ProductionTime, tmpDrIns.SeqNo, tmpDrIns.SubSeq)
                        DataGridCdata.DataSource = dt
                    End If
                Else
                    'Half Page before orange don't exist
                    prodDate = ""
                    prodTime = ""
                    seqNo = ""
                    subSeq = 0

                    dt = GetData(m_iLineNo, prodDate, prodTime, seqNo, subSeq)
                    DataGridCdata.DataSource = dt
                End If
            Else
                'Orange don't exist
                tmpDtIns = taInstruction.GetDataByLastRecord(lineNo)
                If tmpDtIns.Rows.Count > 0 Then     'If last record exist
                    tmpDrIns = tmpDtIns.Rows(0)

                    prodDate = tmpDrIns.ProductionDate
                    prodTime = tmpDrIns.ProductionTime
                    seqNo = tmpDrIns.SeqNo
                    subSeq = tmpDrIns.SubSeq
                    tmpDtIns = taInstruction.GetDataByPreviousBtn(m_iMaxRowCount - 1, prodDate, prodTime, seqNo, subSeq, m_iLineNo)
                    If tmpDtIns.Count > 0 Then
                        'Page before last record exist
                        tmpDrIns = tmpDtIns.Rows(0)
                        If IsFirstRecord(tmpDrIns) Then
                            prodDate = ""
                            prodTime = ""
                            seqNo = ""
                            subSeq = 0

                            dt = GetData(m_iLineNo, prodDate, prodTime, seqNo, subSeq)
                            DataGridCdata.DataSource = dt
                        Else
                            dt = GetData(m_iLineNo, tmpDrIns.ProductionDate, tmpDrIns.ProductionTime, tmpDrIns.SeqNo, tmpDrIns.SubSeq)
                            DataGridCdata.DataSource = dt
                        End If
                    Else
                        'Page before last record don't exist
                        prodDate = ""
                        prodTime = ""
                        seqNo = ""
                        subSeq = 0

                        dt = GetData(m_iLineNo, prodDate, prodTime, seqNo, subSeq)
                        DataGridCdata.DataSource = dt
                    End If
                Else
                    'Last record don't exist
                    DataGridCdata.DataSource = Nothing
                    MessageBox.Show("No Carry Out Schedule")
                End If
                'tmpDtIns = taInstruction.GetDataByPreviousBtn(CInt(m_iMaxRowCount / 2), prodDate, prodTime, seqNo, subSeq, m_iLineNo)
            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "btnF7_Click", ex.Message, "")
        End Try

        Me.DataGridCdata.Focus()

    End Sub

    Public Function GetData(ByVal lineNo As Integer, ByVal prodDate As String, ByVal prodTime As String, ByVal seqNo As String, ByVal subSeq As Integer) As DataTable
        Try
            Dim ta As DataSet1TableAdapters.T_Instruction_DATTableAdapter = Me.m_taInst
            Dim offsetBase As Integer
            Dim dt As New DataSet1.T_Instruction_DATDataTable

            offsetBase = ta.GetOffsetBase(prodDate, prodTime, seqNo, subSeq, lineNo)
            dt = ta.GetDataByNextBtn(m_iMaxRowCount, prodDate, prodTime, seqNo, subSeq, lineNo)

            For Each dr As DataSet1.T_Instruction_DATRow In dt
                offsetBase += 1
                dr.indexNo = offsetBase
            Next

            Return dt
            '-----------------------------------

        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "GetData", ex.Message, "")
            Return Nothing
        End Try

    End Function

    'Public Function GetRowsCount(ByVal lineNo As Integer) As Integer
    '    Try
    '        Dim ta As DataSet1TableAdapters.T_Instruction_DATTableAdapter = Me.m_taInst
    '        Dim rowsCount As Integer

    '        rowsCount = ta.GetRowsCount(lineNo)

    '        Return rowsCount
    '    Catch ex As Exception
    '        logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "GetRowsCount", ex.Message, "")
    '    End Try
    'End Function

    Private Sub btnLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeft.Click
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnLeft_Click", "Click Left Button", "")
        btnLine1.Visible = True
        btnLine2.Visible = True
        btnLine3.Visible = True
        btnLine4.Visible = True
        btnLine5.Visible = True
        btnLine6.Visible = True
        btnLine7.Visible = True
        btnLine8.Visible = True
        btnLine9.Visible = True
        btnLine10.Visible = True

        btnLeft.Enabled = False

        btnLine11.Visible = False
        btnLine12.Visible = False
        btnLine13.Visible = False
        btnLine14.Visible = False
        btnLine15.Visible = False
        btnLine16.Visible = False
        btnLine17.Visible = False
        btnLine18.Visible = False
        btnLine19.Visible = False
        btnLine20.Visible = False

        btnRight.Enabled = True

        m_iLineNo = 1
        setColorSelectedButton(btnLine1)
        GetDataByLine(m_iLineNo)
    End Sub

    Private Sub btnRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRight.Click
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnRight_Click", "Click Right Button", "")
        btnLine11.Visible = True
        btnLine12.Visible = True
        btnLine13.Visible = True
        btnLine14.Visible = True
        btnLine15.Visible = True
        btnLine16.Visible = True
        btnLine17.Visible = True
        btnLine18.Visible = True
        btnLine19.Visible = True
        btnLine20.Visible = True

        btnRight.Enabled = False

        btnLine1.Visible = False
        btnLine2.Visible = False
        btnLine3.Visible = False
        btnLine4.Visible = False
        btnLine5.Visible = False
        btnLine6.Visible = False
        btnLine7.Visible = False
        btnLine8.Visible = False
        btnLine9.Visible = False
        btnLine10.Visible = False

        btnLeft.Enabled = True

        m_iLineNo = 11
        setColorSelectedButton(btnLine11)
        GetDataByLine(m_iLineNo)
    End Sub

    Private Sub btnF10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF10.Click
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnF10_Click", "Click Search Button", "")
        Search.ShowDialog(sender)
        Me.DataGridCdata.Focus()
    End Sub


#Region "RELOAD BUTTON"

    'Reload button
    Private Sub btnF9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF9.Click
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnF9_Click", "Click Reload Button", "")
        If DataGridCdata.RowCount > 0 Then
            Dim taInstruction As DataSet1TableAdapters.T_Instruction_DATTableAdapter = Me.m_taInst
            Dim dt As DataSet1.T_Instruction_DATDataTable = Me.m_dtInst
            Dim tmpDtInst As DataSet1.T_Instruction_DATDataTable = Me.m_dtTempInst
            Dim tmpDrInst As DataSet1.T_Instruction_DATRow

            Dim prodDate As String = ""
            Dim prodTime As String = ""
            Dim seqNo As String = ""
            Dim subSeq As Integer = 0

            prodDate = DataGridCdata.Item(11, 0).Value
            prodTime = DataGridCdata.Item(12, 0).Value
            seqNo = DataGridCdata.Item(1, 0).Value
            subSeq = DataGridCdata.Item(2, 0).Value
            Try
                tmpDtInst = taInstruction.GetDataByPreviousBtn(0, prodDate, prodTime, seqNo, subSeq, m_iLineNo)

                If tmpDtInst.Count > 0 Then
                    tmpDrInst = tmpDtInst.Rows(0)

                    dt = GetData(m_iLineNo, tmpDrInst.ProductionDate, tmpDrInst.ProductionTime, tmpDrInst.SeqNo, tmpDrInst.SubSeq)
                Else
                    'get first page
                    prodDate = ""
                    prodTime = ""
                    seqNo = ""
                    subSeq = 0

                    dt = GetData(m_iLineNo, prodDate, prodTime, seqNo, subSeq)
                End If

                If dt.Rows.Count > 0 Then
                    Me.DataGridCdata.DataSource = dt
                End If
            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnF9_Click", ex.Message, "")
            End Try
        End If

        Me.DataGridCdata.Focus()

    End Sub

    Public Sub ReloadData(ByVal prodDate As String, ByVal prodTime As String, ByVal seqNo As String, ByVal subSeq As Integer)

        Dim taInstruction As DataSet1TableAdapters.T_Instruction_DATTableAdapter = Me.m_taInst
        Dim dt As DataSet1.T_Instruction_DATDataTable = Me.m_dtInst
        Dim tmpDtInst As New DataSet1.T_Instruction_DATDataTable
        Dim tmpDrInst As DataSet1.T_Instruction_DATRow

        Try
            tmpDtInst = taInstruction.GetDataByPreviousBtn(0, prodDate, prodTime, seqNo, subSeq, m_iLineNo)

            If tmpDtInst.Count > 0 Then
                tmpDrInst = tmpDtInst.Rows(0)

                dt = GetData(m_iLineNo, tmpDrInst.ProductionDate, tmpDrInst.ProductionTime, tmpDrInst.SeqNo, tmpDrInst.SubSeq)
            Else
                'get first page
                prodDate = ""
                prodTime = ""
                seqNo = ""
                subSeq = 0

                dt = GetData(m_iLineNo, prodDate, prodTime, seqNo, subSeq)
            End If

            If dt.Rows.Count > 0 Then
                Me.DataGridCdata.DataSource = dt
            End If
        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "ReloadData", ex.Message, "")
        End Try
    End Sub

#End Region

#Region "NEXT BUTTON"
    'Next button
    Private Sub btnF8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF8.Click
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnF8_Click", "Click Next Button", "")

        Dim dt As DataSet1.T_Instruction_DATDataTable = Me.m_dtInst
        'Dim rowsCount As Integer = GetRowsCount(m_iLineNo)

        Dim prodDate As String = ""
        Dim prodTime As String = ""
        Dim seqNo As String = ""
        Dim subSeq As Integer = 0


        Try
            If DataGridCdata.Rows.Count = m_iMaxRowCount Then
                prodDate = DataGridCdata.Item(11, m_iMaxRowCount - 1).Value
                prodTime = DataGridCdata.Item(12, m_iMaxRowCount - 1).Value
                seqNo = DataGridCdata.Item(1, m_iMaxRowCount - 1).Value
                subSeq = DataGridCdata.Item(2, m_iMaxRowCount - 1).Value

                dt = GetData(m_iLineNo, prodDate, prodTime, seqNo, subSeq)
                If dt.Rows.Count > 0 Then
                    Me.DataGridCdata.DataSource = dt
                End If
            End If

        Catch ex As Exception
            'indexNo = 0
            'MessageBox.Show("End of data!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "btnF8_Click", ex.Message, "")
        End Try

        Me.DataGridCdata.Focus()

    End Sub

#End Region

#Region "PREVIOUS BUTTON"
    'Previous button
    Private Sub btnF7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF7.Click
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnF7_Click", "Click Previous Button", "")
        If DataGridCdata.RowCount > 0 Then
            Dim dt As DataSet1.T_Instruction_DATDataTable = Me.m_dtInst
            Dim taInstruction As DataSet1TableAdapters.T_Instruction_DATTableAdapter = Me.m_taInst
            Dim tmpDtProd As New DataSet1.T_Instruction_DATDataTable
            Dim tmpDrProd As DataSet1.T_Instruction_DATRow
            Dim prodDate As String = ""
            Dim prodTime As String = ""
            Dim seqNo As String = ""
            Dim subSeq As Integer = 0

            prodDate = DataGridCdata.Item(11, 0).Value
            prodTime = DataGridCdata.Item(12, 0).Value
            seqNo = DataGridCdata.Item(1, 0).Value
            subSeq = DataGridCdata.Item(2, 0).Value
            Try

                tmpDtProd = taInstruction.GetDataByPreviousBtn(m_iMaxRowCount, prodDate, prodTime, seqNo, subSeq, m_iLineNo)
                If tmpDtProd.Count > 0 Then

                    tmpDrProd = tmpDtProd.Rows(0)

                    If IsFirstRecord(tmpDrProd) Then
                        prodDate = ""
                        prodTime = ""
                        seqNo = ""
                        subSeq = 0

                        dt = GetData(m_iLineNo, prodDate, prodTime, seqNo, subSeq)
                    Else
                        dt = GetData(m_iLineNo, tmpDrProd.ProductionDate, tmpDrProd.ProductionTime, tmpDrProd.SeqNo, tmpDrProd.SubSeq)
                    End If
                    DataGridCdata.DataSource = dt
                End If


            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "btnF7_Click", ex.Message, "")
            End Try
        End If

        Me.DataGridCdata.Focus()

    End Sub

    Public Function IsFirstRecord(ByVal dr As DataSet1.T_Instruction_DATRow) As Boolean

        'get first record
        Dim ta As DataSet1TableAdapters.T_Instruction_DATTableAdapter = Me.m_taInst
        Dim dtFirst As New DataSet1.T_Instruction_DATDataTable
        Dim drFirst As DataSet1.T_Instruction_DATRow
        Dim prodDate As String = ""
        Dim prodTime As String = ""
        Dim seqNo As String = ""
        Dim subSeq As Integer = 0

        dtFirst = ta.GetDataByNextBtn(1, prodDate, prodTime, seqNo, subSeq, m_iLineNo)
        drFirst = dtFirst(0)

        If (drFirst.ProductionDate = dr.ProductionDate) And (drFirst.ProductionTime = dr.ProductionTime) _
            And (drFirst.SeqNo = dr.SeqNo) And (drFirst.SubSeq = dr.SubSeq) Then
            Return True
        Else
            Return False
        End If

    End Function
#End Region

    Private Sub CarryOutSch_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnF12_Click", "Click Close Carry Out Screen Button", "")
        Dim colObj As clsColumnSetup = New clsColumnSetup()
        'colObj.writeInsColum(DataGridCdata, SCREEN_NAME)
        colObj.setColumnIni(DataGridCdata, SCREEN_NAME)

        Main_Menu.Show()
        Me.Dispose()
    End Sub


    Private Sub CarryOutSch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyData
            Case Keys.F1
                btnF1_Click(sender, e)
            Case Keys.F7
                btnF7_Click(sender, e)
            Case Keys.F8
                btnF8_Click(sender, e)
            Case Keys.F9
                btnF9_Click(sender, e)
            Case Keys.F10
                btnF10_Click(sender, e)
            Case Keys.F12
                btnF12_Click(sender, e)
            Case Keys.Up
                If Me.DataGridCdata.CurrentRow.Index = 0 Then
                    'btnF7_Click(sender, e)
                    If DataGridCdata.RowCount > 0 Then
                        Dim dt As DataSet1.T_Instruction_DATDataTable = Me.m_dtInst
                        Dim taInstruction As DataSet1TableAdapters.T_Instruction_DATTableAdapter = Me.m_taInst
                        Dim tmpDtProd As New DataSet1.T_Instruction_DATDataTable
                        Dim tmpDrProd As DataSet1.T_Instruction_DATRow
                        Dim prodDate As String = ""
                        Dim prodTime As String = ""
                        Dim seqNo As String = ""
                        Dim subSeq As Integer = 0

                        prodDate = DataGridCdata.Item(11, 0).Value
                        prodTime = DataGridCdata.Item(12, 0).Value
                        seqNo = DataGridCdata.Item(1, 0).Value
                        subSeq = DataGridCdata.Item(2, 0).Value
                        Try

                            tmpDtProd = taInstruction.GetDataByPreviousBtn(1, prodDate, prodTime, seqNo, subSeq, m_iLineNo)
                            If tmpDtProd.Count > 0 Then

                                tmpDrProd = tmpDtProd.Rows(0)

                                If IsFirstRecord(tmpDrProd) Then
                                    prodDate = ""
                                    prodTime = ""
                                    seqNo = ""
                                    subSeq = 0

                                    dt = GetData(m_iLineNo, prodDate, prodTime, seqNo, subSeq)
                                Else
                                    dt = GetData(m_iLineNo, tmpDrProd.ProductionDate, tmpDrProd.ProductionTime, tmpDrProd.SeqNo, tmpDrProd.SubSeq)
                                End If
                                DataGridCdata.DataSource = dt
                            End If


                        Catch ex As Exception

                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "CarryOutSch_KeyDown", ex.Message, "")
                        End Try
                    End If
                End If

            Case Keys.Down
                If Me.DataGridCdata.CurrentRow.Index = Me.DataGridCdata.RowCount - 1 Then

                    Dim dt As DataSet1.T_Instruction_DATDataTable = Me.m_dtInst
                    'Dim rowsCount As Integer = GetRowsCount(m_iLineNo)

                    Dim prodDate As String = ""
                    Dim prodTime As String = ""
                    Dim seqNo As String = ""
                    Dim subSeq As Integer = 0


                    Try
                        If DataGridCdata.Rows.Count = m_iMaxRowCount Then
                            prodDate = DataGridCdata.Item(11, 0).Value
                            prodTime = DataGridCdata.Item(12, 0).Value
                            seqNo = DataGridCdata.Item(1, 0).Value
                            subSeq = DataGridCdata.Item(2, 0).Value

                            dt = GetData(m_iLineNo, prodDate, prodTime, seqNo, subSeq)
                            If dt.Rows.Count > 0 Then
                                Me.DataGridCdata.DataSource = dt

                            End If
                        End If

                        Me.DataGridCdata.Rows(Me.DataGridCdata.RowCount - 1).Cells(0).Selected = True

                    Catch ex As Exception
                        'indexNo = 0
                        'MessageBox.Show("End of data!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "CarryOutSch_KeyDown", ex.Message, "")
                    End Try
                End If

        End Select
    End Sub


    Private Sub CarryOutSch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "CarryOutSch_Load", "Load CarryOut Screen", "")
        Try
            Dim taLine As DataSet1TableAdapters.T_Line_MSTTableAdapter = Me.m_taLine
            Dim dtLine As DataSet1.T_Line_MSTDataTable = Me.m_dtLine

            dtLine = taLine.GetData()

            'Dim taInst As DataSet1TableAdapters.T_Instruction_DATTableAdapter = Me.m_taInst
            'Dim iCount As Integer
            'Dim arrName(20) As Object
            'Dim rCount As Integer

            ''set label to line button
            'For i As Integer = 0 To dtLine.Count - 1

            '    iCount = taInst.GetCountByLineNo(dtLine(i).LineCode)
            '    If iCount > 0 Then
            '        arrName(i) = dtLine(i).LineName
            '    Else
            '        rCount += 1
            '        arrName(i) = "Reserve" & rCount.ToString
            '    End If

            'Next

            'Me.btnLine1.Text = arrName(0).ToString
            'Me.btnLine2.Text = arrName(1).ToString
            'Me.btnLine3.Text = arrName(2).ToString
            'Me.btnLine4.Text = arrName(3).ToString
            'Me.btnLine5.Text = arrName(4).ToString
            'Me.btnLine6.Text = arrName(5).ToString
            'Me.btnLine7.Text = arrName(6).ToString
            'Me.btnLine8.Text = arrName(7).ToString
            'Me.btnLine9.Text = arrName(8).ToString
            'Me.btnLine10.Text = arrName(9).ToString
            'Me.btnLine11.Text = arrName(10).ToString
            'Me.btnLine12.Text = arrName(11).ToString
            'Me.btnLine13.Text = arrName(12).ToString
            'Me.btnLine14.Text = arrName(13).ToString
            'Me.btnLine15.Text = arrName(14).ToString
            'Me.btnLine16.Text = arrName(15).ToString
            'Me.btnLine17.Text = arrName(16).ToString
            'Me.btnLine18.Text = arrName(17).ToString
            'Me.btnLine19.Text = arrName(18).ToString
            'Me.btnLine20.Text = arrName(19).ToString

            'set label to line button
            Me.btnLine1.Text = dtLine(0).LineName
            Me.btnLine2.Text = dtLine(1).LineName
            Me.btnLine3.Text = dtLine(2).LineName
            Me.btnLine4.Text = dtLine(3).LineName
            Me.btnLine5.Text = dtLine(4).LineName
            Me.btnLine6.Text = dtLine(5).LineName
            Me.btnLine7.Text = dtLine(6).LineName
            Me.btnLine8.Text = dtLine(7).LineName
            Me.btnLine9.Text = dtLine(8).LineName
            Me.btnLine10.Text = dtLine(9).LineName
            Me.btnLine11.Text = dtLine(10).LineName
            Me.btnLine12.Text = dtLine(11).LineName
            Me.btnLine13.Text = dtLine(12).LineName
            Me.btnLine14.Text = dtLine(13).LineName
            Me.btnLine15.Text = dtLine(14).LineName
            Me.btnLine16.Text = dtLine(15).LineName
            Me.btnLine17.Text = dtLine(16).LineName
            Me.btnLine18.Text = dtLine(17).LineName
            Me.btnLine19.Text = dtLine(18).LineName
            Me.btnLine20.Text = dtLine(19).LineName

            'set default line select data
            m_iLineNo = 1
            setColorSelectedButton(Me.btnLine1)
            GetDataByLine(m_iLineNo)

            Main_Menu.Hide()

            Timer1.Start()
            Timer2.Start()

            Dim colObj As clsColumnSetup = New clsColumnSetup()
            setDatagridColWidthIni(colObj.getColumnIni(DataGridCdata.Columns.Count, SCREEN_NAME))

            calCol()
        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "CarryOutSch_Load", ex.Message, "")
            MessageBox.Show(ex.Message)
            Me.Close()
        End Try
    End Sub

    Private Sub setDatagridColWidthIni(ByVal arr As String())
        Dim i As Integer
        Dim array() As String
        array = arr
        For i = 0 To array.Length - 1
            DataGridCdata.Columns(i).Width = Integer.Parse(array(i))
        Next
    End Sub

    Private Sub setDatagridColor()
        Try
            Dim ta As DataSet1TableAdapters.T_Instruction_DATTableAdapter = Me.m_taInst
            Dim row As Integer = 0

            Me.m_dtTempInst = ta.GetDataByCurrentCarryOutRow(m_iLineNo)
            Dim drCurrCarry As DataSet1.T_Instruction_DATRow

            If m_dtTempInst.Count > 0 Then
                drCurrCarry = Me.m_dtTempInst.Rows(0)
            Else
                drCurrCarry = Nothing
            End If

            Dim drDatagrid As DataSet1.T_Instruction_DATRow

            Me.m_dtInst = Me.DataGridCdata.DataSource

            Do While row < Me.DataGridCdata.RowCount
                drDatagrid = Me.m_dtInst.Rows(row)
                
                If Not IsNothing(drCurrCarry) AndAlso (drCurrCarry.ModelYear = drDatagrid.ModelYear _
                    And drCurrCarry.SuffixCode = drDatagrid.SuffixCode _
                    And drCurrCarry.LotNo = drDatagrid.LotNo _
                    And drCurrCarry.Unit = drDatagrid.Unit) Then

                    Me.DataGridCdata.Rows(row).DefaultCellStyle.BackColor = Color.Orange
                Else

                    If drDatagrid.IsCarrResultNull Then 'No Result

                        If drDatagrid.XchgFlag.Substring(0, 1) = "2" Then
                            Me.DataGridCdata.Rows(row).DefaultCellStyle.BackColor = Color.Yellow
                        End If

                        If drDatagrid.XchgFlag.Substring(0, 1) = "4" Then

                            If drDatagrid.YChassisFlag = "0" Or drDatagrid.YChassisFlag = "" Then
                                Me.DataGridCdata.Rows(row).DefaultCellStyle.BackColor = Color.ForestGreen
                            End If

                            If drDatagrid.YChassisFlag = "1" Or drDatagrid.YChassisFlag = "2" Then
                                Me.DataGridCdata.Rows(row).DefaultCellStyle.BackColor = Color.LimeGreen
                            End If

                            If drDatagrid.YChassisFlag = "3" Then
                                Me.DataGridCdata.Rows(row).DefaultCellStyle.BackColor = Color.LightGreen
                            End If

                        End If

                        If drDatagrid.XchgFlag.Substring(2, 2) = "01" Then
                            Me.DataGridCdata.Rows(row).DefaultCellStyle.BackColor = Color.Aqua
                        End If

                        If drDatagrid.XchgFlag.Substring(2, 2) = "02" Then
                            Me.DataGridCdata.Rows(row).DefaultCellStyle.BackColor = Color.Magenta
                        End If

                    Else 'have Result

                        If drDatagrid.XchgFlag = "0000" Then
                            Me.DataGridCdata.Rows(row).DefaultCellStyle.BackColor = Color.Gray
                        End If

                        If drDatagrid.XchgFlag.Substring(0, 1) = "2" Then
                            Me.DataGridCdata.Rows(row).DefaultCellStyle.BackColor = Color.Yellow
                        End If

                        If drDatagrid.XchgFlag.Substring(0, 1) = "4" Then

                            If drDatagrid.YChassisFlag = "0" Or drDatagrid.YChassisFlag = "" Then
                                Me.DataGridCdata.Rows(row).DefaultCellStyle.BackColor = Color.ForestGreen
                            End If

                            If drDatagrid.YChassisFlag = "1" Or drDatagrid.YChassisFlag = "2" Then
                                Me.DataGridCdata.Rows(row).DefaultCellStyle.BackColor = Color.LimeGreen
                            End If

                            If drDatagrid.YChassisFlag = "3" Then
                                Me.DataGridCdata.Rows(row).DefaultCellStyle.BackColor = Color.LightGreen
                            End If
                        End If

                        If drDatagrid.XchgFlag.Substring(2, 2) = "01" Then
                            Me.DataGridCdata.Rows(row).DefaultCellStyle.BackColor = Color.Aqua
                        End If

                        If drDatagrid.XchgFlag.Substring(2, 2) = "02" Then
                            Me.DataGridCdata.Rows(row).DefaultCellStyle.BackColor = Color.Magenta
                        End If

                    End If

                End If

                row += 1
            Loop
        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "setDatagridColor", ex.Message, "")
        End Try
    End Sub

    Private Sub DataGridCdata_DataSourceChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridCdata.DataSourceChanged

        If Me.m_firstOpen = True Then
            setDatagridColor()
        Else
            Me.m_firstOpen = True
        End If

    End Sub


    Private Sub CarrOutSch_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        setDatagridColor()
    End Sub

    Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click

        If MessageBox.Show("Do you want to change it?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.OK Then

            Try
                logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnF1_Click", "Click Change Button", "")
                If DataGridCdata.RowCount > 0 Then
                    Dim lineNo As String = m_iLineNo.ToString()
                    Dim alogger As New TLogDat


                    Dim SelectedIndexFull As Integer
                    SelectedIndexFull = DataGridCdata.CurrentRow.Cells(0).Value

                    '----Very New Algorithm
                    Dim OprodDate As String = ""
                    Dim OprodTime As String = ""
                    Dim OseqNo As String = ""
                    Dim OsubSeq As Integer = 0

                    'Dim SelprodDate As String = DataGridCdata.CurrentRow.Cells(11).Value
                    'Dim SelprodTime As String = DataGridCdata.CurrentRow.Cells(12).Value
                    'Dim SelseqNo As String = DataGridCdata.CurrentRow.Cells(1).Value
                    'Dim SelsubSeq As Integer = DataGridCdata.CurrentRow.Cells(2).Value
                    'Dim Selindex As Integer = DataGridCdata.CurrentRow.Cells(0).Value

                    Dim ta As DataSet1TableAdapters.T_Instruction_DATTableAdapter = Me.m_taInst
                    'Dim offsetBase As Integer
                    Dim dt As New DataSet1.T_Instruction_DATDataTable

                    Dim taProd As DataSet1TableAdapters.T_Production_DATTableAdapter = Me.m_taProd
                    Dim dtUpdateProd As New DataSet1.T_Production_DATDataTable

                    Dim drCurrentRow As DataSet1.T_Instruction_DATRow

                    Dim dtSelected As DataSet1.T_Instruction_DATDataTable = DataGridCdata.DataSource
                    Dim drSelectedRow As DataSet1.T_Instruction_DATRow = dtSelected.Rows(DataGridCdata.CurrentRow.Index)
                    Dim drFirstRow As DataSet1.T_Instruction_DATRow = dtSelected.Rows(0)

                    Dim prodDate As String
                    Dim prodTime As String
                    Dim seqNo As String
                    Dim subSeq As Integer
                    prodDate = drFirstRow.ProductionDate
                    prodTime = drFirstRow.ProductionTime
                    seqNo = drFirstRow.SeqNo
                    subSeq = drFirstRow.SubSeq


                    Me.m_dtTempInst = ta.GetDataByCurrentCarryOutRow(m_iLineNo)
                    If (m_dtTempInst.Rows.Count > 0) Then
                        drCurrentRow = m_dtTempInst.Rows(0)
                    Else
                        'No remaining schedule
                        drCurrentRow = m_dtTempInst.NewT_Instruction_DATRow()
                        drCurrentRow.ProductionDate = "99999999"
                        drCurrentRow.ProductionTime = "9999"
                        drCurrentRow.SeqNo = "99999"
                        drCurrentRow.SubSeq = 9999999
                    End If

                    Dim curModelYear As String
                    Dim curSuffixCode As String
                    Dim curLotNo As String
                    Dim curUnit As String
                    curModelYear = drCurrentRow.ModelYear
                    curSuffixCode = drCurrentRow.SuffixCode
                    curLotNo = drCurrentRow.LotNo
                    curUnit = drCurrentRow.Unit

                    Dim compareRow As Integer = compareProdDatTimeSeqSubSeq(drSelectedRow, drCurrentRow)

                    Dim logMSG As String
                    If compareRow > 0 Then
                        'Change FWD
                        dt = ta.GetDataByChangeRecords(drCurrentRow.ProductionDate, _
                                                       drCurrentRow.ProductionTime, _
                                                       drCurrentRow.SeqNo, _
                                                       drCurrentRow.SubSeq, _
                                                       drSelectedRow.ProductionDate, _
                                                       drSelectedRow.ProductionTime, _
                                                       drSelectedRow.SeqNo, _
                                                       drSelectedRow.SubSeq, _
                                                       m_iLineNo)
                        Dim dateNow As Date = Now
                        For Each dr As DataSet1.T_Instruction_DATRow In dt
                            dr.CarrResult = dateNow
                            dr.CarrPassFlag = True
                        Next
                        ta.Update(dt)

                        For Each drIns As DataSet1.T_Instruction_DATRow In dt
                            'Dim drUpdateProd As DataSet1.T_Production_DATRow = dtUpdateProd.NewT_Production_DATRow
                            updateProduction(drIns, taProd)
                        Next
                        'taProd.Update(dtUpdateProd)

                        logMSG = "Carry Out changed from ModelCode = " & curModelYear & curSuffixCode
                        logMSG += ", Lot = " & curLotNo & ", Unit = " & curUnit
                        logMSG += ", to ModelCode = " & drSelectedRow.ModelYear & drSelectedRow.SuffixCode
                        logMSG += ", Lot = " & drSelectedRow.LotNo & ", Unit = " & drSelectedRow.Unit
                        alogger.InsertNewLog(TLogDat.LOG_TYPE_OPERATION, TLogDat.LogLevel.NormalLog, My.Computer.Name, Now, logMSG, m_strLineName)

                    ElseIf compareRow < 0 Then
                        'Change BKW
                        dt = ta.GetDataByChangeRecords(drSelectedRow.ProductionDate, _
                                                       drSelectedRow.ProductionTime, _
                                                       drSelectedRow.SeqNo, _
                                                       drSelectedRow.SubSeq, _
                                                       drCurrentRow.ProductionDate, _
                                                       drCurrentRow.ProductionTime, _
                                                       drCurrentRow.SeqNo, _
                                                       drCurrentRow.SubSeq, _
                                                       m_iLineNo)
                        For Each dr As DataSet1.T_Instruction_DATRow In dt
                            dr.SetCarrResultNull()
                            dr.CarrPassFlag = False
                        Next
                        ta.Update(dt)

                        For Each drIns As DataSet1.T_Instruction_DATRow In dt
                            'Dim drUpdateProd As DataSet1.T_Production_DATRow = dtUpdateProd.NewT_Production_DATRow
                            updateProduction(drIns, taProd)
                        Next
                        'taProd.Update(dtUpdateProd)

                        logMSG = "Carry Out changed from ModelCode = " & curModelYear & curSuffixCode
                        logMSG += ", Lot = " & curLotNo & ", Unit = " & curUnit
                        logMSG += ", to ModelCode = " & drSelectedRow.ModelYear & drSelectedRow.SuffixCode
                        logMSG += ", Lot = " & drSelectedRow.LotNo & ", Unit = " & drSelectedRow.Unit
                        alogger.InsertNewLog(TLogDat.LOG_TYPE_OPERATION, TLogDat.LogLevel.NormalLog, My.Computer.Name, Now, logMSG, m_strLineName)

                    Else
                        'Not Change
                    End If

                    'Reload Table
                    ReloadData(prodDate, prodTime, seqNo, subSeq)
                End If
            Catch ex As Exception
                logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "btnF1_Click", ex.Message, "")
            End Try

        End If

        Me.DataGridCdata.Focus()

    End Sub

    Private Function compareProdDatTimeSeqSubSeq(ByVal dr1 As DataSet1.T_Instruction_DATRow, _
                                                 ByVal dr2 As DataSet1.T_Instruction_DATRow) As Integer
        Dim result As Integer = 0
        Dim str1 As String = ""
        Dim str2 As String = ""

        str1 = dr1.ProductionDate & dr1.ProductionTime & dr1.SeqNo & dr1.SubSeq.ToString("D7")
        str2 = dr2.ProductionDate & dr2.ProductionTime & dr2.SeqNo & dr2.SubSeq.ToString("D7")
        result = String.Compare(str1, str2)

        Return result
    End Function

    Private Sub updateProduction(ByVal drInst As DataSet1.T_Instruction_DATRow, _
                                 ByRef taProd As DataSet1TableAdapters.T_Production_DATTableAdapter)
        Try
            Dim res As Boolean

            If drInst.YChassisFlag = "" Or drInst.YChassisFlag = "0" Or drInst.IsYChassisFlagNull Then
                'check 2 line
                res = checkProductCarrResult_NOXchange(drInst.ModelYear, drInst.SuffixCode, drInst.LotNo, drInst.Unit, 1)
                res = res And checkProductCarrResult_NOXchange(drInst.ModelYear, drInst.SuffixCode, drInst.LotNo, drInst.Unit, 2)

            ElseIf drInst.YChassisFlag = "1" Or drInst.YChassisFlag = "2" Then
                'check line 1 only
                res = checkProductCarrResult_NOXchange(drInst.ModelYear, drInst.SuffixCode, drInst.LotNo, drInst.Unit, 1)

            ElseIf drInst.YChassisFlag = "3" Then
                'check line 2 only
                res = checkProductCarrResult_NOXchange(drInst.ModelYear, drInst.SuffixCode, drInst.LotNo, drInst.Unit, 2)
            End If

            'Dim pDt As New DataSet1.T_Production_DATDataTable
            'T_Production_DATTableAdapter.FillByModelYearSuffixCodeLotNoUnit(pDt, modelYear, suffixCode, lotNo, unit)
            'Dim drUpdateProd As DataSet1.T_Production_DATRow = pDt.Rows(0)

            Dim intResult As Integer = 0
            If res Then
                'drUpdateProd("InstructFlag") = 2
                intResult = taProd.UpdateInstructFlagByPK(2, drInst.ModelYear, drInst.SuffixCode, drInst.LotNo, drInst.Unit)
                logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "updateProduction", intResult & " rows of InstructFlag updated.", "")
            Else
                Dim dt As DataSet1.T_Instruction_DATDataTable = Me.m_dtTempInst
                Me.m_taInst.FillByModelYearSuffixCodeLotNoUnit(dt, drInst.ModelYear, drInst.SuffixCode, drInst.LotNo, drInst.Unit)

                Dim flag As Boolean = True

                For Each dr As DataSet1.T_Instruction_DATRow In dt
                    'If dt.Rows(i)("InsResult") IsNot DBNull.Value Then
                    If Not dr.IsInsResultNull Then
                        flag = False 'have some value
                        Exit For
                    End If
                Next

                If flag Then
                    'drUpdateProd("InstructFlag") = 0
                    intResult = taProd.UpdateInstructFlagByPK(0, drInst.ModelYear, drInst.SuffixCode, drInst.LotNo, drInst.Unit)
                    logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "updateProduction", intResult & " rows of InstructFlag updated.", "")
                Else
                    'drUpdateProd("InstructFlag") = 1
                    intResult = taProd.UpdateInstructFlagByPK(1, drInst.ModelYear, drInst.SuffixCode, drInst.LotNo, drInst.Unit)
                    logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "updateProduction", intResult & " rows of InstructFlag updated.", "")
                End If

            End If


            'Dim chk As Integer = T_Production_DATTableAdapter.Update(pDt)
        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "UpdateProdution", ex.Message, "")
        End Try
    End Sub

    'Private Function checkProductCarrResult(ByVal modelYear As String, ByVal suffixCode As String, ByVal lotNo As String, ByVal unit As String, ByVal lineType As Integer) As Boolean
    '    Try
    '        Dim MainlineCode As String = T_Line_MSTTableAdapter.GetMainLineCodeByLineType(lineType)

    '        Dim dt As DataSet1.T_Instruction_DATDataTable = Me.m_dtTempInst
    '        Me.m_taInst.FillByModelYearSuffixLotUnitLineNo(dt, modelYear, suffixCode, lotNo, unit, MainlineCode)

    '        If dt.Rows(0)("CarrResult") Is DBNull.Value Then
    '            Return False
    '        Else
    '            Return True
    '        End If
    '    Catch ex As Exception
    '        logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "checkProductionCarrResult", "Unable to connect the database.", "")
    '    End Try
    'End Function

    Private Function checkProductCarrResult_NOXchange(ByVal modelYear As String, ByVal suffixCode As String, ByVal lotNo As String, ByVal unit As String, ByVal lineType As Integer) As Boolean
        Try
            Dim MainlineCode As String = T_Line_MSTTableAdapter.GetMainLineCodeByLineType(lineType)

            Dim dt As DataSet1.T_Instruction_DATDataTable = Me.m_dtTempInst
            Me.m_taInst.FillByModelYearSuffixCodeLotNoUnit_NoXChange(dt, modelYear, suffixCode, lotNo, unit, MainlineCode)

            If dt.Rows(0)("CarrResult") Is DBNull.Value Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "checkProductionCarrResult_NOXchange", ex.Message, "")
        End Try
    End Function

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
        Me.DataGridCdata.Focus()
    End Sub

    Private Sub cmboxLogInfo_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmboxLogInfo.DropDown
        Timer1.Stop()
    End Sub

    Private Sub cmboxLogInfo_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmboxLogInfo.DropDownClosed
        Timer1.Start()
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        lblTime.Text = Now.ToString("dd MMM yyyy  HH:mm:ss")
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
        'btnLeft.Enabled = False
        'btnRight.Enabled = False
        btnLine1.Enabled = False
        btnLine2.Enabled = False
        btnLine3.Enabled = False
        btnLine4.Enabled = False
        btnLine5.Enabled = False
        btnLine6.Enabled = False
        btnLine7.Enabled = False
        btnLine8.Enabled = False
        btnLine9.Enabled = False
        btnLine10.Enabled = False
        btnLine11.Enabled = False
        btnLine12.Enabled = False
        btnLine13.Enabled = False
        btnLine14.Enabled = False
        btnLine15.Enabled = False
        btnLine16.Enabled = False
        btnLine17.Enabled = False
        btnLine18.Enabled = False
        btnLine19.Enabled = False
        btnLine20.Enabled = False
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
        'btnLeft.Enabled = True
        'btnRight.Enabled = True
        btnLine1.Enabled = True
        btnLine2.Enabled = True
        btnLine3.Enabled = True
        btnLine4.Enabled = True
        btnLine5.Enabled = True
        btnLine6.Enabled = True
        btnLine7.Enabled = True
        btnLine8.Enabled = True
        btnLine9.Enabled = True
        btnLine10.Enabled = True
        btnLine11.Enabled = True
        btnLine12.Enabled = True
        btnLine13.Enabled = True
        btnLine14.Enabled = True
        btnLine15.Enabled = True
        btnLine16.Enabled = True
        btnLine17.Enabled = True
        btnLine18.Enabled = True
        btnLine19.Enabled = True
        btnLine20.Enabled = True
    End Sub

    Private Sub calCol()
        DataGridView1.Columns(0).Width = DataGridCdata.Columns(0).Width
        DataGridView1.Columns(1).Width = DataGridCdata.Columns(1).Width + DataGridCdata.Columns(2).Width
        DataGridView1.Columns(2).Width = DataGridCdata.Columns(3).Width + DataGridCdata.Columns(4).Width
        DataGridView1.Columns(3).Width = DataGridCdata.Columns(5).Width + DataGridCdata.Columns(6).Width + DataGridCdata.Columns(7).Width

        Dim tt As Integer = 0
        Dim i As Integer

        For i = 9 To DataGridCdata.Columns.Count - 1
            tt += DataGridCdata.Columns(i).Width
        Next

        DataGridView1.Columns(4).Width = tt

        DataGridView1.HorizontalScrollingOffset = DataGridCdata.HorizontalScrollingOffset
    End Sub

    'Sync datagridview scroll offset
    Private Sub DataGridCdata_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles DataGridCdata.Scroll
        DataGridView1.HorizontalScrollingOffset = DataGridCdata.HorizontalScrollingOffset
    End Sub

    Private Sub DataGridCdata_ColumnHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridCdata.ColumnHeaderMouseClick
        'DataGridView1.HorizontalScrollingOffset = datagridPdata.HorizontalScrollingOffset
        calCol()
    End Sub

    Private Sub datagridCdata_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridCdata.MouseUp
        'DataGridView1.HorizontalScrollingOffset = datagridPdata.HorizontalScrollingOffset
        calCol()
    End Sub

    Private Sub DataGridCdata_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridCdata.CellMouseClick

        If e.Button = MouseButtons.Right Then
            If Me.DataGridCdata.CurrentRow.Cells(0).Value = Me.DataGridCdata.Item(0, e.RowIndex).Value Then

                Dim taInstruction As DataSet1TableAdapters.T_Instruction_DATTableAdapter = Me.m_taInst
                Dim tmpDtInst As DataSet1.T_Instruction_DATDataTable = DataGridCdata.DataSource
                Dim tmpDrInst As DataSet1.T_Instruction_DATRow
                Dim dt As DataSet1.T_Instruction_DATDataTable = Me.m_dtInst

                'Dim index As Integer = Me.DataGridCdata.Item(0, e.RowIndex).Value
                'dt = GetData(m_iLineNo, index - 1)
                'Me.DataGridCdata.DataSource = dt

                Dim prodDate As String = ""
                Dim prodTime As String = ""
                Dim seqNo As String = ""
                Dim subSeq As Integer = 0
                Dim dr As DataSet1.T_Instruction_DATRow = dt.Rows(e.RowIndex)
                prodDate = dr.ProductionDate
                prodTime = dr.ProductionTime
                seqNo = dr.SeqNo
                subSeq = dr.SubSeq
                Try
                    tmpDtInst = taInstruction.GetDataByPreviousBtn(0, prodDate, prodTime, seqNo, subSeq, m_iLineNo)

                    If tmpDtInst.Count > 0 Then
                        tmpDrInst = tmpDtInst.Rows(0)

                        dt = GetData(m_iLineNo, tmpDrInst.ProductionDate, tmpDrInst.ProductionTime, tmpDrInst.SeqNo, tmpDrInst.SubSeq)
                    Else
                        'get first page
                        prodDate = ""
                        prodTime = ""
                        seqNo = ""
                        subSeq = 0

                        dt = GetData(m_iLineNo, prodDate, prodTime, seqNo, subSeq)
                    End If

                    If dt.Rows.Count > 0 Then
                        Me.DataGridCdata.DataSource = dt
                    End If
                Catch ex As Exception

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnF9_Click", ex.Message, "")
                End Try
            End If
        End If

    End Sub

    
    Private Sub DataGridCdata_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridCdata.KeyDown
        If e.Control And e.KeyCode = Keys.T Then
            'If Me.DataGridIdata.CurrentRow.Cells(0).Value = Me.DataGridIdata.Item(0, e.RowIndex).Value Then

            Dim taInstruction As DataSet1TableAdapters.T_Instruction_DATTableAdapter = Me.m_taInst
            Dim tmpDtInst As DataSet1.T_Instruction_DATDataTable = Me.m_dtTempInst
            Dim tmpDrInst As DataSet1.T_Instruction_DATRow
            Dim dt As DataSet1.T_Instruction_DATDataTable = DataGridCdata.DataSource
            Dim iCurrRow As Integer = DataGridCdata.CurrentRow.Index

            Dim dr As DataSet1.T_Instruction_DATRow = dt.Rows(iCurrRow)

            Dim prodDate As String = ""
            Dim prodTime As String = ""
            Dim seqNo As String = ""
            Dim subSeq As Integer = 0

            prodDate = dr.ProductionDate
            prodTime = dr.ProductionTime
            seqNo = dr.SeqNo
            subSeq = dr.SubSeq
            Try
                tmpDtInst = taInstruction.GetDataByPreviousBtn(0, prodDate, prodTime, seqNo, subSeq, m_iLineNo)

                If tmpDtInst.Count > 0 Then
                    tmpDrInst = tmpDtInst.Rows(0)

                    dt = GetData(m_iLineNo, tmpDrInst.ProductionDate, tmpDrInst.ProductionTime, tmpDrInst.SeqNo, tmpDrInst.SubSeq)
                Else
                    'get first page
                    prodDate = ""
                    prodTime = ""
                    seqNo = ""
                    subSeq = 0

                    dt = GetData(m_iLineNo, prodDate, prodTime, seqNo, subSeq)
                End If

                If dt.Rows.Count > 0 Then
                    Me.DataGridCdata.DataSource = dt
                End If
            Catch ex As Exception

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnF9_Click", ex.Message, "")
            End Try
        End If
    End Sub

    Private Sub btnF2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF2.Click
        Me.DataGridCdata.Focus()
    End Sub

    Private Sub btnF3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF3.Click
        Me.DataGridCdata.Focus()
    End Sub

    Private Sub btnF4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF4.Click
        Me.DataGridCdata.Focus()
    End Sub

    Private Sub btnF5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF5.Click
        Me.DataGridCdata.Focus()
    End Sub

    Private Sub btnF6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF6.Click
        Me.DataGridCdata.Focus()
    End Sub

    Private Sub btnF11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF11.Click
        Me.DataGridCdata.Focus()
    End Sub
End Class