Imports Common
Imports InstructionSystem.DataSet1
Imports System.Text.RegularExpressions


Public Class DetailedDataEdit

#Region "ENUM"
    Public Enum Mode
        ADD
        UPDATE
    End Enum

#End Region


#Region "PROTECTED MEMBER"
    Protected m_mode As Mode
    Protected m_primaryKeyValueList As ArrayList
#End Region

#Region "PRIVATE MEMBER"

    'Private m_singletonSqlDb As SingletonSqlDB = SingletonSqlDB.GetInstance()
    Private Const m_strTableName As String = "T_Production_DAT"

    Private newColumnName1 As String = "ASMPARTSNo1"
    Private newColumnName2 As String = "ASMPARTSNo2"
    Private newColumnName3 As String = "ASMPARTSNo3"
    Private newColumnName4 As String = "ASMPARTSNo4"
    Private newColumnName5 As String = "ASMPARTSNo5"
    Private errCol As String = "Format mismatch at :"
    Private errMsg As String = ""
    Private errFlag As Boolean = True

#End Region
    Dim logger As Logger = New Logger()
#Region "PUBLIC METHOD"
    Public Overloads Sub Initialize(ByVal mode As Mode, ByVal primaryKeyValueList As ArrayList)
        m_mode = mode
        m_primaryKeyValueList = primaryKeyValueList
    End Sub
#End Region

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnUpdate_Click", "Click Update Button", "")

        'updateSpace()

        errFlag = True
        Dim isOnlineInput As Boolean
        Dim isOverLine As Boolean
        Dim isAllPartTxt As Boolean

        'check length of each data
        errFlag = CheckInput()

        'check input part format
        isAllPartTxt = CheckAllPartTxt()
        errFlag = errFlag And isAllPartTxt

        If isAllPartTxt = False Then
            errMsg = errMsg & vbCrLf & errCol
            errCol = ""
        End If

        'check online line input
        isOnlineInput = CheckPartOnlineInput(txtYChassisFlag.Text.ToString)
        errFlag = errFlag And isOnlineInput

        If errFlag Then

            isOverLine = CheckInputOverLinePart()

            Select Case m_mode
                Case Mode.ADD

                    Dim chkPass As Boolean = False

                    If Not isOverLine Then
                        chkPass = True
                    Else
                        If MessageBox.Show("Parts data not match with line master." & vbCrLf & "Do you insert it?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.OK Then
                            chkPass = True
                        End If
                    End If

                    If chkPass Then

                        If Not IsDuplicate() Then
                            m_primaryKeyValueList(0) = txtModelYear.Text
                            m_primaryKeyValueList(1) = txtSuffixc.Text
                            m_primaryKeyValueList(2) = txtLotNo.Text
                            m_primaryKeyValueList(3) = txtUnit.Text

                            m_primaryKeyValueList.Add(txtLotID.Text)

                            m_primaryKeyValueList.Add(txtBlockModel.Text)
                            m_primaryKeyValueList.Add(txtBlockSeq.Text)

                            m_primaryKeyValueList.Add(txtImportCode.Text)
                            m_primaryKeyValueList.Add(txtMark.Text)
                            m_primaryKeyValueList.Add(txtYChassisFlag.Text)
                            m_primaryKeyValueList.Add(txtGAShop.Text)
                            m_primaryKeyValueList.Add(txtHanmmerYear.Text)

                            'ProductionData.Close()
                            AdditionInsert.Initialize(m_primaryKeyValueList)
                            AdditionInsert.ShowDialog()
                            'show addition insert screen
                            'Me.Hide()
                        Else
                            MessageBox.Show("Duplicate data.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If

                Case Mode.UPDATE

                    Dim chkPass As Boolean = False

                    If Not isOverLine Then
                        chkPass = True
                    Else
                        If isOverLine And MessageBox.Show("Parts data not match with line master." & vbCrLf & "Do you update it?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.OK Then
                            chkPass = True
                        End If
                    End If

                    If chkPass Then
                        Try
                            Using ts As New TransactionScope
                                UpdateData(Me.txtModelYear.Text, Me.txtSuffixc.Text, Me.txtLotNo.Text, Me.txtUnit.Text, isOverLine)

                                Dim primaryKeyValueList As New ArrayList
                                primaryKeyValueList.Add(Me.txtModelYear.Text)
                                primaryKeyValueList.Add(Me.txtSuffixc.Text)
                                primaryKeyValueList.Add(Me.txtLotNo.Text)
                                primaryKeyValueList.Add(Me.txtUnit.Text)

                                Dim manageInstructData As New ManageInstructionData()
                                manageInstructData.UpdateProductionRowToInstruction(Me.txtModelYear.Text, Me.txtSuffixc.Text, _
                                                                                    Me.txtLotNo.Text, Me.txtUnit.Text)
                                ts.Complete()
                            End Using

                            Dim activeRowIndex As Integer = ProductionData.datagridPdata.CurrentCell.RowIndex
                            Dim prodDate As String = ""
                            Dim prodTime As String = ""
                            Dim seqNo As String = ""
                            Dim subSeq As Integer = 0

                            prodDate = ProductionData.datagridPdata.Item(12, activeRowIndex).Value
                            prodTime = ProductionData.datagridPdata.Item(13, activeRowIndex).Value
                            seqNo = ProductionData.datagridPdata.Item(1, activeRowIndex).Value
                            subSeq = ProductionData.datagridPdata.Item(2, activeRowIndex).Value

                            ProductionData.ReloadData(prodDate, prodTime, seqNo, subSeq)
                            'Reload Production Data
                            ProductionData.Show()
                            Me.Dispose()
                        Catch ex As Exception
                            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "btnUpdate_Click", ex.StackTrace, "")
                            MessageBox.Show("Update Fail", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End If

            End Select

        Else
            If Not errMsg = "" Then
                MessageBox.Show(errMsg)
                errMsg = ""
            End If

        End If
    End Sub

    Private Sub UpdateData(ByVal modelYear As String, ByVal suffixCode As String, _
                            ByVal lotNo As String, ByVal unit As String, ByVal overLine As Boolean)

        Try
            Dim ta As New DataSet1TableAdapters.T_Production_DATTableAdapter
            Dim pDt As New DataSet1.T_Production_DATDataTable
            Dim dr As DataSet1.T_Production_DATRow

            pDt = ta.GetDataByPrimaryKey(modelYear, suffixCode, lotNo, unit)

            'Dim pkList(3) As Object
            'pkList(0) = modelYear
            'pkList(1) = suffixCode
            'pkList(2) = lotNo
            'pkList(3) = unit

            dr = pDt.Rows(0) 'pDt.Rows.Find(pkList)

            'dr.Item("SeqNo") = Me.txtSEQmain.Text.Split("-")(0)
            'dr.Item("ModelYear") = Me.txtModelYear.Text.Substring(1, 3)
            'dr.Item("SuffixCode") = Me.txtSuffixc.Text
            dr.Item("LotId") = Me.txtLotID.Text
            'dr.Item("LotNo") = Me.txtLotNo.Text
            'dr.Item("Unit") = Me.txtUnit.Text
            dr.Item("BlockModel") = Me.txtBlockModel.Text
            dr.Item("BlockSeq") = Me.txtBlockSeq.Text
            'dr.Item("ProductionDate") = Me.txtDate.Text
            'dr.Item("ProductionTime") = Me.txtTime.Text
            dr.Item("ImportCode") = Me.txtImportCode.Text
            dr.Item("Mark") = Me.txtMark.Text
            dr.Item("YChassisFlag") = Me.txtYChassisFlag.Text
            dr.Item("GaShop") = Me.txtGAShop.Text
            dr.Item("HanmmerYears") = Me.txtHanmmerYear.Text

            Dim dt As New DataTable
            dt = Me.datagirdEdit.DataSource
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
            'dr.Item("SubSeq") = Me.txtSEQmain.Text.Split("-")(1)
            'dr.Item("XchgFlag") = "0000"
            'dr.Item("InstructFlag") = 1
            'dr.Item("FileName") = ""
            'dr.Item("SEQ_DESC") = ""
            'dr.Item("indexNo") = ""

            Dim result As Integer

            result = ta.Update(dr)

            Dim logMSG As String
            logMSG = "Production data SeqNo " & dr.Item("SeqNo")
            If Not IsDBNull(dr.Item("SubSeq")) Then
                logMSG = logMSG & "-" & dr.Item("SubSeq")
            End If

            If overLine Then
                logMSG = logMSG & " with not matched data updated."
            Else
                logMSG = logMSG & " with matched data updated."
            End If


            'Write Log
            Dim logger As TLogDat
            logger = New TLogDat
            logger.InsertNewLog(TLogDat.LOG_TYPE_OPERATION, TLogDat.LogLevel.NormalLog, My.Computer.Name, Now, logMSG, Nothing)
        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "UpdateData", ex.Message, "")
        End Try
    End Sub


    Private Sub btnCancel_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnCancel.MouseDown
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnCancel_MouseDown", "Cancel MouseDown Button", "")
        Timer1.Interval = 2000 '2 sec
        Timer1.Start()
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        
        'Me.Close()
        'ProductionData.Show()

        'Timer1.Stop()
        'Timer1.Enabled = False
    End Sub


    Private Sub btnCancel_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        'logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnCancel_MouseUp", "Cancel MouseUp Button", "")

        'Timer1.Stop()
        'Timer1.Enabled = False
    End Sub

    Private Sub DetailedDataEdit_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'Me.Dispose()
    End Sub


    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnCancel_Click", "Click Cancel Button", "")


        ProductionData.Show()
        Me.Dispose()
    End Sub


    Private Sub DetailedDataEdit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "DetailDataEdit)Load", "Load DetailDataEdit Screen", "")

        Select Case m_mode

            Case Mode.ADD
                Me.btnUpdate.Text = "F1:ADDITION"

                Me.txtSEQmain.Enabled = False
                Me.txtDate.Enabled = False
                Me.txtTime.Enabled = False
                Me.txtYChassisFlag.Enabled = True
                Me.txtModelYear.Enabled = True
                Me.txtSuffixc.Enabled = True
                Me.txtLotNo.Enabled = True
                Me.txtUnit.Enabled = True
                Me.txtImportCode.Enabled = True
                Me.txtMark.Enabled = True
                Me.txtYChassisFlag.Enabled = True
                Me.txtGAShop.Enabled = True
                Me.txtHanmmerYear.Enabled = True
                Me.txtLotID.Enabled = True
                Me.txtBlockModel.Enabled = True
                Me.txtBlockSeq.Enabled = True


                Me.rdbAll.Enabled = True
                Me.rdbCab.Enabled = True
                Me.rdbPubx.Enabled = True

            Case Mode.UPDATE
                Me.btnUpdate.Text = "F1:UPDATE"

                Me.txtSEQmain.ReadOnly = True
                Me.txtSEQmain.ForeColor = Color.Crimson
                Me.txtSEQmain.BackColor = Color.LightGray

                Me.txtDate.ReadOnly = True
                Me.txtDate.ForeColor = Color.Crimson
                Me.txtDate.BackColor = Color.LightGray

                Me.txtTime.ReadOnly = True
                Me.txtTime.ForeColor = Color.Crimson
                Me.txtTime.BackColor = Color.LightGray

                Me.txtModelYear.ReadOnly = True
                Me.txtModelYear.ForeColor = Color.Crimson
                Me.txtModelYear.BackColor = Color.LightGray

                Me.txtSuffixc.ReadOnly = True
                Me.txtSuffixc.ForeColor = Color.Crimson
                Me.txtSuffixc.BackColor = Color.LightGray

                Me.txtLotNo.ReadOnly = True
                Me.txtLotNo.ForeColor = Color.Crimson
                Me.txtLotNo.BackColor = Color.LightGray

                Me.txtUnit.ReadOnly = True
                Me.txtUnit.ForeColor = Color.Crimson
                Me.txtUnit.BackColor = Color.LightGray

                Me.txtImportCode.ReadOnly = True
                Me.txtImportCode.ForeColor = Color.Crimson
                Me.txtImportCode.BackColor = Color.LightGray

                Me.txtMark.ReadOnly = True
                Me.txtMark.ForeColor = Color.Crimson
                Me.txtMark.BackColor = Color.LightGray

                Me.txtYChassisFlag.ReadOnly = True
                Me.txtYChassisFlag.ForeColor = Color.Crimson
                Me.txtYChassisFlag.BackColor = Color.LightGray

                Me.txtGAShop.ReadOnly = True
                Me.txtGAShop.ForeColor = Color.Crimson
                Me.txtGAShop.BackColor = Color.LightGray

                Me.txtHanmmerYear.ReadOnly = True
                Me.txtHanmmerYear.ForeColor = Color.Crimson
                Me.txtHanmmerYear.BackColor = Color.LightGray

                Me.txtLotID.ReadOnly = True
                Me.txtLotID.ForeColor = Color.Crimson
                Me.txtLotID.BackColor = Color.LightGray

                Me.txtBlockModel.ReadOnly = True
                Me.txtBlockModel.ForeColor = Color.Crimson
                Me.txtBlockModel.BackColor = Color.LightGray

                Me.txtBlockSeq.ReadOnly = True
                Me.txtBlockSeq.ForeColor = Color.Crimson
                Me.txtBlockSeq.BackColor = Color.LightGray

                Me.rdbAll.Enabled = False
                Me.rdbCab.Enabled = False
                Me.rdbPubx.Enabled = False
        End Select

        Try
            Dim ta As New DataSet1TableAdapters.T_Production_DATTableAdapter
            Dim dt As New DataSet1.T_Production_DATDataTable

            dt = ta.GetDataByPrimaryKey(m_primaryKeyValueList(0), m_primaryKeyValueList(1), _
                                         m_primaryKeyValueList(2), m_primaryKeyValueList(3))

            If (IsNothing(dt)) Then
                MessageBox.Show("Error while loading data from T_production_DAT table in database.")
                Dispose()
                Return
            End If


            ShowTProductionDatOnScreen(dt)

            ShowLineDetailOnScreen(dt)

            'set datagrid columns size
            For i As Integer = 0 To Me.datagirdEdit.Columns.Count - 1
                Me.datagirdEdit.Columns(i).Width = 135
            Next

            'set Not Sortable column
            Me.datagirdEdit.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
            Me.datagirdEdit.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
            Me.datagirdEdit.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
            Me.datagirdEdit.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
            Me.datagirdEdit.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
            Me.datagirdEdit.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
            Me.datagirdEdit.Columns(6).SortMode = DataGridViewColumnSortMode.NotSortable

        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "DetailedDataEdit", ex.Message, "")
        End Try


    End Sub

    Private Sub ShowTProductionDatOnScreen(ByVal dt As DataSet1.T_Production_DATDataTable)

        Dim dr As DataSet1.T_Production_DATRow
        dr = dt.Rows(0)

        If m_mode = Mode.UPDATE Then
            Me.txtSEQmain.Text = dr.SeqNo
            If Not IsDBNull(dr.SubSeq) Then
                Me.txtSEQmain.Text += "-" + dr.SubSeq.ToString("D3")
            End If

            Me.txtDate.Text = dr.ProductionDate
            Me.txtTime.Text = dr.ProductionTime

        End If

        Me.txtModelYear.Text = dr.ModelYear
        Me.txtSuffixc.Text = dr.SuffixCode
        Me.txtLotID.Text = dr.LotID
        Me.txtLotNo.Text = dr.LotNo
        Me.txtUnit.Text = dr.Unit
        Me.txtBlockModel.Text = dr.BlockModel
        Me.txtBlockSeq.Text = dr.BlockSeq
        Me.txtImportCode.Text = dr.ImportCode
        Me.txtMark.Text = dr.MARK
        Me.txtGAShop.Text = dr.GAShop
        Me.txtHanmmerYear.Text = dr.HanmmerYears

        rdbAll.Checked = False
        rdbCab.Checked = False
        rdbPubx.Checked = False

        If dr.YChassisFlag = "0" Or dr.YChassisFlag = "" Then
            rdbAll.Checked = True
            Me.rdbAll.Select()
        ElseIf dr.YChassisFlag = "1" Then
            rdbCab.Checked = True
            Me.rdbCab.Select()
        ElseIf dr.YChassisFlag = "2" Then
            rdbCab.Checked = True
            Me.rdbCab.Select()
        ElseIf dr.YChassisFlag = "3" Then
            rdbPubx.Checked = True
            Me.rdbPubx.Select()
        End If

        Me.txtYChassisFlag.Text = dr.YChassisFlag

    End Sub

    Private Sub ShowLineDetailOnScreen(ByVal dt As DataSet1.T_Production_DATDataTable)
        Try
            Dim dr As DataSet1.T_Production_DATRow
            dr = dt.Rows(0)

            Dim taT_Line_MST As New DataSet1TableAdapters.T_Line_MSTTableAdapter
            Dim lDt As New DataSet1.T_Line_MSTDataTable

            lDt = taT_Line_MST.GetDataByOnline

            lDt.Columns.Remove(lDt.LineTypeColumn)
            lDt.Columns.Remove(lDt.MainLineFlagColumn)
            lDt.Columns.Remove(lDt.OnlineFlagColumn)
            lDt.Columns.Remove(lDt.IpAddressColumn)
            lDt.Columns.Remove(lDt.NetAddressColumn)
            lDt.Columns.Remove(lDt.NodeAddressColumn)
            lDt.Columns.Remove(lDt.UnitAddressColumn)
            lDt.Columns.Remove(lDt.ReadReqAddressColumn)
            lDt.Columns.Remove(lDt.WriteProductionAddressColumn)
            lDt.Columns.Remove(lDt.WriteCarryOutAddressColumn)
            lDt.Columns.Remove(lDt.Part1Column)
            lDt.Columns.Remove(lDt.Part2Column)
            lDt.Columns.Remove(lDt.Part3Column)
            lDt.Columns.Remove(lDt.Part4Column)
            lDt.Columns.Remove(lDt.Part5Column)

            Dim adc1 As DataColumn
            Dim adc2 As DataColumn
            Dim adc3 As DataColumn
            Dim adc4 As DataColumn
            Dim adc5 As DataColumn

            adc1 = New DataColumn(newColumnName1, System.Type.GetType("System.String"))
            adc2 = New DataColumn(newColumnName2, System.Type.GetType("System.String"))
            adc3 = New DataColumn(newColumnName3, System.Type.GetType("System.String"))
            adc4 = New DataColumn(newColumnName4, System.Type.GetType("System.String"))
            adc5 = New DataColumn(newColumnName5, System.Type.GetType("System.String"))

            lDt.Columns.Add(adc1)
            lDt.Columns.Add(adc2)
            lDt.Columns.Add(adc3)
            lDt.Columns.Add(adc4)
            lDt.Columns.Add(adc5)

            Dim aDR As DataSet1.T_Line_MSTRow

            For Each aDR In lDt.Rows

                If (aDR.LineCode.ToString = "1") Then
                    aDR(newColumnName1) = dr.Item("Model01Asm01")
                    aDR(newColumnName2) = dr.Item("Model01Asm02")
                    aDR(newColumnName3) = dr.Item("Model01Asm03")
                    aDR(newColumnName4) = dr.Item("Model01Asm04")
                    aDR(newColumnName5) = dr.Item("Model01Asm05")
                End If

                If (aDR.LineCode.ToString = "2") Then
                    aDR(newColumnName1) = dr.Item("Model02Asm01")
                    aDR(newColumnName2) = dr.Item("Model02Asm02")
                    aDR(newColumnName3) = dr.Item("Model02Asm03")
                    aDR(newColumnName4) = dr.Item("Model02Asm04")
                    aDR(newColumnName5) = dr.Item("Model02Asm05")
                End If

                If (aDR.LineCode.ToString = "3") Then
                    aDR(newColumnName1) = dr.Item("Model03Asm01")
                    aDR(newColumnName2) = dr.Item("Model03Asm02")
                    aDR(newColumnName3) = dr.Item("Model03Asm03")
                    aDR(newColumnName4) = dr.Item("Model03Asm04")
                    aDR(newColumnName5) = dr.Item("Model03Asm05")
                End If

                If (aDR.LineCode.ToString = "4") Then
                    aDR(newColumnName1) = dr.Item("Model04Asm01")
                    aDR(newColumnName2) = dr.Item("Model04Asm02")
                    aDR(newColumnName3) = dr.Item("Model04Asm03")
                    aDR(newColumnName4) = dr.Item("Model04Asm04")
                    aDR(newColumnName5) = dr.Item("Model04Asm05")
                End If

                If (aDR.LineCode.ToString = "5") Then
                    aDR(newColumnName1) = dr.Item("Model05Asm01")
                    aDR(newColumnName2) = dr.Item("Model05Asm02")
                    aDR(newColumnName3) = dr.Item("Model05Asm03")
                    aDR(newColumnName4) = dr.Item("Model05Asm04")
                    aDR(newColumnName5) = dr.Item("Model05Asm05")
                End If

                If (aDR.LineCode.ToString = "6") Then
                    aDR(newColumnName1) = dr.Item("Model06Asm01")
                    aDR(newColumnName2) = dr.Item("Model06Asm02")
                    aDR(newColumnName3) = dr.Item("Model06Asm03")
                    aDR(newColumnName4) = dr.Item("Model06Asm04")
                    aDR(newColumnName5) = dr.Item("Model06Asm05")
                End If

                If (aDR.LineCode.ToString = "7") Then
                    aDR(newColumnName1) = dr.Item("Model07Asm01")
                    aDR(newColumnName2) = dr.Item("Model07Asm02")
                    aDR(newColumnName3) = dr.Item("Model07Asm03")
                    aDR(newColumnName4) = dr.Item("Model07Asm04")
                    aDR(newColumnName5) = dr.Item("Model07Asm05")
                End If

                If (aDR.LineCode.ToString = "8") Then
                    aDR(newColumnName1) = dr.Item("Model08Asm01")
                    aDR(newColumnName2) = dr.Item("Model08Asm02")
                    aDR(newColumnName3) = dr.Item("Model08Asm03")
                    aDR(newColumnName4) = dr.Item("Model08Asm04")
                    aDR(newColumnName5) = dr.Item("Model08Asm05")
                End If

                If (aDR.LineCode.ToString = "9") Then
                    aDR(newColumnName1) = dr.Item("Model09Asm01")
                    aDR(newColumnName2) = dr.Item("Model09Asm02")
                    aDR(newColumnName3) = dr.Item("Model09Asm03")
                    aDR(newColumnName4) = dr.Item("Model09Asm04")
                    aDR(newColumnName5) = dr.Item("Model09Asm05")
                End If

                If (aDR.LineCode.ToString = "10") Then
                    aDR(newColumnName1) = dr.Item("Model10Asm01")
                    aDR(newColumnName2) = dr.Item("Model10Asm02")
                    aDR(newColumnName3) = dr.Item("Model10Asm03")
                    aDR(newColumnName4) = dr.Item("Model10Asm04")
                    aDR(newColumnName5) = dr.Item("Model10Asm05")
                End If

                If (aDR.LineCode.ToString = "11") Then
                    aDR(newColumnName1) = dr.Item("Model11Asm01")
                    aDR(newColumnName2) = dr.Item("Model11Asm02")
                    aDR(newColumnName3) = dr.Item("Model11Asm03")
                    aDR(newColumnName4) = dr.Item("Model11Asm04")
                    aDR(newColumnName5) = dr.Item("Model11Asm05")
                End If

                If (aDR.LineCode.ToString = "12") Then
                    aDR(newColumnName1) = dr.Item("Model12Asm01")
                    aDR(newColumnName2) = dr.Item("Model12Asm02")
                    aDR(newColumnName3) = dr.Item("Model12Asm03")
                    aDR(newColumnName4) = dr.Item("Model12Asm04")
                    aDR(newColumnName5) = dr.Item("Model12Asm05")
                End If

                If (aDR.LineCode.ToString = "13") Then
                    aDR(newColumnName1) = dr.Item("Model13Asm01")
                    aDR(newColumnName2) = dr.Item("Model13Asm02")
                    aDR(newColumnName3) = dr.Item("Model13Asm03")
                    aDR(newColumnName4) = dr.Item("Model13Asm04")
                    aDR(newColumnName5) = dr.Item("Model13Asm05")
                End If

                If (aDR.LineCode.ToString = "14") Then
                    aDR(newColumnName1) = dr.Item("Model14Asm01")
                    aDR(newColumnName2) = dr.Item("Model14Asm02")
                    aDR(newColumnName3) = dr.Item("Model14Asm03")
                    aDR(newColumnName4) = dr.Item("Model14Asm04")
                    aDR(newColumnName5) = dr.Item("Model14Asm05")
                End If

                If (aDR.LineCode.ToString = "15") Then
                    aDR(newColumnName1) = dr.Item("Model15Asm01")
                    aDR(newColumnName2) = dr.Item("Model15Asm02")
                    aDR(newColumnName3) = dr.Item("Model15Asm03")
                    aDR(newColumnName4) = dr.Item("Model15Asm04")
                    aDR(newColumnName5) = dr.Item("Model15Asm05")
                End If

                If (aDR.LineCode.ToString = "16") Then
                    aDR(newColumnName1) = dr.Item("Model16Asm01")
                    aDR(newColumnName2) = dr.Item("Model16Asm02")
                    aDR(newColumnName3) = dr.Item("Model16Asm03")
                    aDR(newColumnName4) = dr.Item("Model16Asm04")
                    aDR(newColumnName5) = dr.Item("Model16Asm05")
                End If

                If (aDR.LineCode.ToString = "17") Then
                    aDR(newColumnName1) = dr.Item("Model17Asm01")
                    aDR(newColumnName2) = dr.Item("Model17Asm02")
                    aDR(newColumnName3) = dr.Item("Model17Asm03")
                    aDR(newColumnName4) = dr.Item("Model17Asm04")
                    aDR(newColumnName5) = dr.Item("Model17Asm05")
                End If

                If (aDR.LineCode.ToString = "18") Then
                    aDR(newColumnName1) = dr.Item("Model18Asm01")
                    aDR(newColumnName2) = dr.Item("Model18Asm02")
                    aDR(newColumnName3) = dr.Item("Model18Asm03")
                    aDR(newColumnName4) = dr.Item("Model18Asm04")
                    aDR(newColumnName5) = dr.Item("Model18Asm05")
                End If

                If (aDR.LineCode.ToString = "19") Then
                    aDR(newColumnName1) = dr.Item("Model19Asm01")
                    aDR(newColumnName2) = dr.Item("Model19Asm02")
                    aDR(newColumnName3) = dr.Item("Model19Asm03")
                    aDR(newColumnName4) = dr.Item("Model19Asm04")
                    aDR(newColumnName5) = dr.Item("Model19Asm05")
                End If

                If (aDR.LineCode.ToString = "20") Then
                    aDR(newColumnName1) = dr.Item("Model20Asm01")
                    aDR(newColumnName2) = dr.Item("Model20Asm02")
                    aDR(newColumnName3) = dr.Item("Model20Asm03")
                    aDR(newColumnName4) = dr.Item("Model20Asm04")
                    aDR(newColumnName5) = dr.Item("Model20Asm05")
                End If

            Next

            Me.datagirdEdit.DataSource = lDt
            'Me.datagirdEdit.Columns(newColumnName1).
            'Me.datagirdEdit.Columns("LineCode").ReadOnly = True
            'Me.datagirdEdit.Columns("LineName").ReadOnly = True
        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "ShowLineDetailOnScreen", ex.Message, "")
        End Try

    End Sub

    Private Sub rdbAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbAll.CheckedChanged
        If rdbAll.Checked = True Then
            Me.txtYChassisFlag.Text = "0"
        End If
    End Sub

    Private Sub rdbCab_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbCab.CheckedChanged
        If rdbCab.Checked = True Then
            Me.txtYChassisFlag.Text = "2"
        End If
    End Sub

    Private Sub rdbPubx_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbPubx.CheckedChanged
        If rdbPubx.Checked = True Then
            Me.txtYChassisFlag.Text = "3"
        End If
    End Sub

    Private Function CheckInput() As Boolean

        Dim regexSeqNo As String
        Dim regexModelYear As String
        Dim regexSuffixCode As String
        Dim regexLotId As String
        Dim regexLotNo As String
        Dim regexUnit As String
        Dim regexBlockModel As String
        Dim regexBlockSeq As String
        Dim regexMark As String
        Dim regexprodDate As String
        Dim regexProdTime As String
        Dim regexImportCode As String
        Dim regexGaShop As String
        Dim regexHanmmerYear As String

        Dim bl As Boolean = True

        regexSeqNo = "^[0-9]{5}$"
        regexModelYear = "^[0-9]{3}$"
        regexSuffixCode = "^[A-Za-z0-9 ]{5}$"
        regexLotId = "^[0-9]{3}$"
        regexLotNo = "^[0-9]{3}$"
        regexUnit = "^[0-9]{3}$"
        regexBlockModel = "^[A-Za-z0-9 ]{8}$"
        regexBlockSeq = "^[0-9 ]{3}$"
        regexMark = "^[A-Za-z0-9 ]{3}$"
        regexprodDate = "^[0-9]{8}$"
        regexProdTime = "^[0-9]{4}$"
        regexImportCode = "^[A-Za-z0-9 -]{10}$"
        regexGaShop = "^[A-Za-z0-9 ]{2}$"
        regexHanmmerYear = "^[A-Za-z0-9 ]{2}$"

        Dim reg_exp As New Regex("")

        If m_mode = Mode.UPDATE Then
            'check Seqno
            reg_exp = New Regex(regexSeqNo)
            Dim seqNo As String = Me.txtSEQmain.Text.ToString.Split("-")(0)
            bl = reg_exp.IsMatch(seqNo)
            If bl = False Then
                'MessageBox.Show("Please check Seq No." & vbCrLf & "Only 5 numbers(0-9) are excepted.")

                errMsg = errMsg & vbCrLf & "Please check Seq No." & vbCrLf & "Only 5 numbers(0-9) are accepted." & vbCrLf & "-----------------------"
                errFlag = False
            End If
        End If


        'check Modelyear
        reg_exp = New Regex(regexModelYear)
        Dim modelYear As String = Me.txtModelYear.Text.ToString
        bl = reg_exp.IsMatch(modelYear)
        If bl = False Then
            'MessageBox.Show("Please check ModelYear" & vbCrLf & "Only 3 numbers(0-9) are excepted.")

            errMsg = errMsg & vbCrLf & "Please check ModelYear" & vbCrLf & "Only 3 numbers(0-9) are accepted." & vbCrLf & "-----------------------"
            errFlag = False
        End If



        'check SuffixCode
        reg_exp = New Regex(regexSuffixCode)
        Dim suffixCode As String = Me.txtSuffixc.Text.ToString
        bl = reg_exp.IsMatch(suffixCode)
        If bl = False Then
            'MessageBox.Show("Please check Sufix Code" & vbCrLf & "Only 5 numbers(0-9) or characters(A-Z for both upper and lower case) are excepted.")

            errMsg = errMsg & vbCrLf & "Please check Suffix Code" & vbCrLf & "Only 5 numbers(0-9) or characters(A-Z for both upper and lower case) are accepted." & vbCrLf & "-----------------------"
            errFlag = False
        End If


        'check LotId
        reg_exp = New Regex(regexLotId)
        Dim lotId As String = Me.txtLotID.Text.ToString
        bl = reg_exp.IsMatch(lotId)
        If bl = False Or lotId = "000" Then
            'MessageBox.Show("Please check lot ID" & vbCrLf & "Only 3 numbers(0-9) are excepted.")

            errMsg = errMsg & vbCrLf & "Please check lot ID" & vbCrLf & "Only 3 numbers(0-9) are accepted And lot ID cannot be all zero." & vbCrLf & "-----------------------"
            errFlag = False
        End If


        'check LotNo
        reg_exp = New Regex(regexLotNo)
        Dim lotNo As String = Me.txtLotNo.Text.ToString
        bl = reg_exp.IsMatch(lotNo)
        If bl = False Or lotNo = "000" Then
            'MessageBox.Show("Please check Lot No." & vbCrLf & "Only 3 numbers(0-9) are excepted.")

            errMsg = errMsg & vbCrLf & "Please check Lot No." & vbCrLf & "Only 3 numbers(0-9) are accepted And Lot No cannot be all zero." & vbCrLf & "-----------------------"
            errFlag = False
        End If



        'check Unit
        reg_exp = New Regex(regexUnit)
        Dim unit As String = Me.txtUnit.Text.ToString
        bl = reg_exp.IsMatch(unit)
        If bl = False Or unit = "000" Then
            'MessageBox.Show("Please check Unit" & vbCrLf & "Only 3 numbers(0-9) are excepted.")

            errMsg = errMsg & vbCrLf & "Please check Unit" & vbCrLf & "Only 3 numbers(0-9) are accepted And Unit cannot be all zero." & vbCrLf & "-----------------------"
            errFlag = False
        End If

        'check blockModel
        reg_exp = New Regex(regexBlockModel)
        Dim blockModel As String = Me.txtBlockModel.Text.ToString
        bl = reg_exp.IsMatch(blockModel)
        If (bl = False And blockModel <> "") Or blockModel = "00000000" Then
            'MessageBox.Show("Please check Block Model" & vbCrLf & "Only 8 numbers(0-9) or characters(A-Z for both upper and lower case) are excepted.")

            errMsg = errMsg & vbCrLf & "Please check Block Model" & vbCrLf & "Only 8 numbers(0-9) or characters(A-Z for both upper and lower case) are accepted And Block Model cannot be all zero." & vbCrLf & "-----------------------"
            errFlag = False
        End If

        'check blockSeq
        reg_exp = New Regex(regexBlockSeq)
        Dim blockSeq As String = Me.txtBlockSeq.Text.ToString
        bl = reg_exp.IsMatch(blockSeq)
        If (bl = False And blockSeq <> "") Or blockSeq = "000" Then
            'MessageBox.Show("Please check Block Seq" & vbCrLf & "Only 3 numbers(0-9) are excepted.")

            errMsg = errMsg & vbCrLf & "Please check Block Seq" & vbCrLf & "Only 3 numbers(0-9) are accepted And Block Seq cannot be all zero." & vbCrLf & "-----------------------"
            errFlag = False
        End If

        If m_mode = Mode.ADD Then

            If (blockModel <> "" And blockSeq = "") Or (blockModel = "" And blockSeq <> "") Then
                errMsg = errMsg & vbCrLf & "Please check Block Model and Block Seq" & vbCrLf & "This 2 fields must also exist Or must also don't exist" & vbCrLf & "-----------------------"
                errFlag = False
            End If

        End If


        'check mark
        reg_exp = New Regex(regexMark)
        Dim mark As String = Me.txtMark.Text.ToString
        bl = reg_exp.IsMatch(mark)
        If bl = False And mark <> "" Then
            'MessageBox.Show("Please check Mark" & vbCrLf & "Only 3 numbers(0-9) or characters(A-Z for both upper and lower case)are excepted.")

            errMsg = errMsg & vbCrLf & "Please check Mark" & vbCrLf & "Only 3 numbers(0-9) or characters(A-Z for both upper and lower case)are accepted." & vbCrLf & "-----------------------"
            errFlag = False
        End If



        If m_mode = Mode.UPDATE Then
            'check prodDate
            reg_exp = New Regex(regexprodDate)
            Dim prodDate As String = Me.txtDate.Text.ToString
            bl = reg_exp.IsMatch(prodDate)
            If bl = False Then
                'MessageBox.Show("Please check Production Date" & vbCrLf & "Only 8 numbers(0-9) are excepted with format ddMMyyyy.")

                errMsg = errMsg & vbCrLf & "Please check Production Date" & vbCrLf & "Only 8 numbers(0-9) are accepted with format ddMMyyyy." & vbCrLf & "-----------------------"
                errFlag = False
            End If
        End If

        If m_mode = Mode.UPDATE Then
            'check prodTime
            reg_exp = New Regex(regexProdTime)
            Dim prodTime As String = Me.txtTime.Text.ToString
            bl = reg_exp.IsMatch(prodTime)
            If bl = False Then
                'MessageBox.Show("Please check Production Time" & vbCrLf & "Only 8 numbers(0-9) are excepted with format HHMM.")

                errMsg = errMsg & vbCrLf & "Please check Production Time" & vbCrLf & "Only 4 numbers(0-9) are accepted with format HHMM." & vbCrLf & "-----------------------"
                errFlag = False
            End If
        End If


        'check importCode
        reg_exp = New Regex(regexImportCode)
        Dim importCode As String = Me.txtImportCode.Text.ToString
        bl = reg_exp.IsMatch(importCode)
        If bl = False Then
            'MessageBox.Show("Please check Import Code" & vbCrLf & "Only 10 numbers(0-9) or characters(A-Z with both upper and lower case)are excepted.")

            errMsg = errMsg & vbCrLf & "Please check Import Code" & vbCrLf & "Only 10 numbers(0-9) or characters(A-Z with both upper and lower case)are accepted." & vbCrLf & "-----------------------"
            errFlag = False
        End If

        'check GAShop
        reg_exp = New Regex(regexGaShop)
        Dim gaShop As String = Me.txtGAShop.Text.ToString
        bl = reg_exp.IsMatch(gaShop)
        If bl = False Then
            'MessageBox.Show("Please check GA Shop" & vbCrLf & "Only 2 numbers(0-9) or characters(A-Z with both upper and lower case) are excepted.")

            errMsg = errMsg & vbCrLf & "Please check GA Shop" & vbCrLf & "Only 2 numbers(0-9) or characters(A-Z with both upper and lower case) are accepted." & vbCrLf & "-----------------------"
            errFlag = False
        End If

        'check HannmerYear
        reg_exp = New Regex(regexHanmmerYear)
        Dim hannmeryear As String = Me.txtHanmmerYear.Text.ToString
        bl = reg_exp.IsMatch(hannmeryear)
        If bl = False And hannmeryear <> "" Then
            'MessageBox.Show("Please check Hannmer Year" & vbCrLf & "Only 2 numbers(0-9) or characters(A-Z with both upper and lower case) are excepted.")

            errMsg = errMsg & vbCrLf & "Please check Hannmer Year" & vbCrLf & "Only 2 numbers(0-9) or characters(A-Z with both upper and lower case) are accepted." & vbCrLf & "-----------------------"
            errFlag = False
        End If


        Return errFlag

    End Function

    Private Function CheckPartOnlineInput(ByVal yChassisFlag As String) As Boolean
        Try

            Dim taLine As New DataSet1TableAdapters.T_Line_MSTTableAdapter
            Dim lDt As New DataSet1.T_Line_MSTDataTable

            If yChassisFlag = "" Or yChassisFlag = "0" Then 'ALL
                lDt = taLine.GetAllDataByOnline
            ElseIf yChassisFlag = "1" Or yChassisFlag = "2" Then 'CAB
                lDt = taLine.GetAllDataByType(1)
            ElseIf yChassisFlag = "3" Then 'PUBX
                lDt = taLine.GetAllDataByType(2)
            Else
                lDt = taLine.GetAllDataByOnline
            End If



            Dim isOnlineInput As Boolean = True

            For Each aDR As DataSet1.T_Line_MSTRow In lDt.Rows

                Dim lineCode As Integer ' = aDR.LineCode

                For intRow As Integer = 0 To Me.datagirdEdit.Rows.Count - 1
                    If CInt(Me.datagirdEdit.Item(0, intRow).Value) = aDR.LineCode Then
                        lineCode = intRow
                    End If
                Next

                If aDR.Part1 = True Then

                    If Me.datagirdEdit.Item(2, lineCode).Value.ToString = "" Then

                        errMsg = errMsg & vbCrLf & "check part 1 for line code : " & aDR.LineCode & vbCrLf & "-----------------------"
                        isOnlineInput = False
                        Exit For
                    End If

                End If


                If aDR.Part2 = True Then

                    If Me.datagirdEdit.Item(3, lineCode).Value.ToString = "" Then

                        errMsg = errMsg & vbCrLf & "check part 2 for line code : " & aDR.LineCode & vbCrLf & "-----------------------"
                        isOnlineInput = False
                        Exit For
                    End If

                End If
                If aDR.Part3 = True Then

                    If Me.datagirdEdit.Item(4, lineCode).Value.ToString = "" Then

                        errMsg = errMsg & vbCrLf & "check part 3 for line code : " & aDR.LineCode & vbCrLf & "-----------------------"
                        isOnlineInput = False
                        Exit For
                    End If

                End If
                If aDR.Part4 = True Then

                    If Me.datagirdEdit.Item(5, lineCode).Value.ToString = "" Then

                        errMsg = errMsg & vbCrLf & "check part 4 for line code : " & aDR.LineCode & vbCrLf & "-----------------------"
                        isOnlineInput = False
                        Exit For
                    End If

                End If
                If aDR.Part5 = True Then

                    If Me.datagirdEdit.Item(6, lineCode).Value.ToString = "" Then

                        errMsg = errMsg & vbCrLf & "check part 5 for line code : " & aDR.LineCode & vbCrLf & "-----------------------"
                        isOnlineInput = False
                        Exit For
                    End If

                End If

            Next

            Return isOnlineInput
        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "CheckPartOnlineInput", ex.Message, "")
        End Try
    End Function

    Private Function CheckAllPartTxt() As Boolean
        Try
            Dim i As Integer
            Dim chk As Boolean = True

            For i = 0 To Me.datagirdEdit.Rows.Count - 1
                chk = chk And checkTxt(Me.datagirdEdit.Rows(i).Cells(2).Value.ToString(), i, 2, "ASMPartNo1")
                chk = chk And checkTxt(Me.datagirdEdit.Rows(i).Cells(3).Value.ToString(), i, 3, "ASMPartNo2")
                chk = chk And checkTxt(Me.datagirdEdit.Rows(i).Cells(4).Value.ToString(), i, 4, "ASMPartNo3")
                chk = chk And checkTxt(Me.datagirdEdit.Rows(i).Cells(5).Value.ToString(), i, 5, "ASMPartNo4")
                chk = chk And checkTxt(Me.datagirdEdit.Rows(i).Cells(6).Value.ToString(), i, 6, "ASMPartNo5")
            Next

            Return chk
        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "CheckAllPartTxt", ex.Message, "")
        End Try
    End Function

    Private Function checkTxt(ByVal txt As String, ByVal row As Integer, ByVal cell As Integer, ByVal cellName As String) As Boolean
        Try
            Dim i As Integer
            Dim txtType As String = ""    's -> space  , n-> number
            Dim chk As Boolean = True

            If txt = "" Then
                txtType = "s"
                chk = chk And True
            Else
                Integer.Parse(txt(0))
                txtType = "n"
                chk = chk And True
            End If

            For i = 1 To txt.Length - 1
                If txtType = "n" Then   'case number
                    Integer.Parse(txt(i))
                    chk = chk And True
                End If
            Next

            If txtType = "n" And txt.Length <> 10 Then
                errCol = errCol & vbCrLf & "(line " & (row + 1) & "," & cellName & ")"
                Return False
            End If

            Return chk
        Catch ex As Exception
            errCol = errCol & vbCrLf & "(line " & (row + 1) & "," & cellName & ")"
            Return False
        End Try

    End Function

    Private Function CheckInputOverLinePart() As Boolean
        Try
            Dim taLine As New DataSet1TableAdapters.T_Line_MSTTableAdapter
            Dim lDt As New DataSet1.T_Line_MSTDataTable

            lDt = taLine.GetAllDataByOnline

            Dim isOverLine As Boolean = False

            For Each aDR As DataSet1.T_Line_MSTRow In lDt.Rows

                Dim lineCode As Integer ' = aDR.LineCode

                For intRow As Integer = 0 To Me.datagirdEdit.Rows.Count - 1
                    If CInt(Me.datagirdEdit.Item(0, intRow).Value) = aDR.LineCode Then
                        lineCode = intRow
                    End If
                Next
                If aDR.Part1 = False And Me.datagirdEdit.Item(2, lineCode).Value.ToString <> "" Then

                    isOverLine = True
                    Exit For
                End If

                If aDR.Part2 = False And Me.datagirdEdit.Item(3, lineCode).Value.ToString <> "" Then

                    isOverLine = True
                    Exit For
                End If

                If aDR.Part3 = False And Me.datagirdEdit.Item(4, lineCode).Value.ToString <> "" Then

                    isOverLine = True
                    Exit For
                End If

                If aDR.Part4 = False And Me.datagirdEdit.Item(5, lineCode).Value.ToString <> "" Then

                    isOverLine = True
                    Exit For
                End If

                If aDR.Part5 = False And Me.datagirdEdit.Item(6, lineCode).Value.ToString <> "" Then

                    isOverLine = True
                    Exit For
                End If

            Next

            Return isOverLine
        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "CheckInputOverLinePart", ex.Message, "")
        End Try

    End Function

    Private Function IsDuplicate() As Boolean
        Try
            Dim ta As New DataSet1TableAdapters.T_Production_DATTableAdapter
            Dim dt As New DataSet1.T_Production_DATDataTable

            dt = ta.GetDataByPrimaryKey(Me.txtModelYear.Text.ToString(), Me.txtSuffixc.Text.ToString(), _
                                         Me.txtLotNo.Text.ToString(), Me.txtUnit.Text.ToString())

            If dt.Rows.Count = 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "IsDuplicate", ex.Message, "")
        End Try
    End Function


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub DetailedDataEdit_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyData
            Case Keys.F1
                btnUpdate_Click(sender, e)
            Case Keys.F12
                btnCancel_Click(sender, e)
        End Select
    End Sub

    'Private Sub txtSEQmain_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtSEQmain.MouseClick
    '    If txtSEQmain.Text.Contains(" ") Then
    '        txtSEQmain.Text = ""
    '    End If
    'End Sub

    'Private Sub txtModelYear_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtModelYear.MouseClick
    '    If txtModelYear.Text.Contains(" ") Then
    '        txtModelYear.Text = ""
    '    End If
    'End Sub

    'Private Sub txtSuffixc_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtSuffixc.MouseClick
    '    If txtSuffixc.Text.Contains(" ") Then
    '        txtSuffixc.Text = ""
    '    End If
    'End Sub

    'Private Sub txtLotID_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtLotID.MouseClick
    '    If txtLotID.Text.Contains(" ") Then
    '        txtLotID.Text = ""
    '    End If '
    'End Sub

    'Private Sub txtLotNo_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtLotNo.MouseClick
    '    If txtLotNo.Text.Contains(" ") Then
    '        txtLotNo.Text = ""
    '    End If '
    'End Sub

    'Private Sub txtUnit_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtUnit.MouseClick
    '    If txtUnit.Text.Contains(" ") Then
    '        txtUnit.Text = ""
    '    End If '
    'End Sub

    'Private Sub txtBlockModel_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtBlockModel.MouseClick
    '    If txtBlockModel.Text.Contains(" ") Then
    '        txtBlockModel.Text = ""
    '    End If '
    'End Sub

    'Private Sub txtBlockSeq_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtBlockSeq.MouseClick
    '    If txtBlockSeq.Text.Contains(" ") Then
    '        txtBlockSeq.Text = ""
    '    End If '
    'End Sub

    'Private Sub txtDate_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtDate.MouseClick
    '    If txtDate.Text.Contains(" ") Then
    '        txtDate.Text = ""
    '    End If '
    'End Sub

    'Private Sub txtTime_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtTime.MouseClick
    '    If txtTime.Text.Contains(" ") Then
    '        txtTime.Text = ""
    '    End If '
    'End Sub

    'Private Sub txtImportCode_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtImportCode.MouseClick
    '    If txtImportCode.Text.Contains(" ") Then
    '        txtImportCode.Text = ""
    '    End If '
    'End Sub

    'Private Sub txtMark_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtMark.MouseClick
    '    If txtMark.Text.Contains(" ") Then
    '        txtMark.Text = ""
    '    End If '
    'End Sub

    'Private Sub txtYChassisFlag_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtYChassisFlag.MouseClick
    '    If txtYChassisFlag.Text.Contains(" ") Then
    '        txtYChassisFlag.Text = ""
    '    End If '
    'End Sub

    'Private Sub txtGAShop_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtGAShop.MouseClick
    '    If txtGAShop.Text.Contains(" ") Then
    '        txtGAShop.Text = ""
    '    End If '
    'End Sub

    'Private Sub txtHanmmerYear_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtHanmmerYear.MouseClick
    '    If txtHanmmerYear.Text.Contains(" ") Then
    '        txtHanmmerYear.Text = ""
    '    End If
    'End Sub

    'Public Sub updateSpace()

    '    If txtSEQmain.Text = "" Then
    '        txtSEQmain.Text = "     "
    '    End If

    '    If txtModelYear.Text = "" Then
    '        txtModelYear.Text = "   "
    '    End If

    '    If txtSuffixc.Text = "" Then
    '        txtSuffixc.Text = "     "
    '    End If

    '    If txtLotID.Text = "" Then
    '        txtLotID.Text = "   "
    '    End If

    '    If txtLotNo.Text = "" Then
    '        txtLotNo.Text = "   "
    '    End If

    '    If txtUnit.Text = "" Then
    '        txtUnit.Text = "   "
    '    End If

    '    If txtBlockModel.Text = "" Then
    '        txtBlockModel.Text = "        "
    '    End If

    '    If txtBlockSeq.Text = "" Then
    '        txtBlockSeq.Text = "   "
    '    End If

    '    If txtDate.Text = "" Then
    '        txtDate.Text = "        "
    '    End If

    '    If txtTime.Text = "" Then
    '        txtTime.Text = "    "
    '    End If

    '    If txtImportCode.Text = "" Then
    '        txtImportCode.Text = "          "
    '    End If

    '    If txtMark.Text = "" Then
    '        txtMark.Text = "   "
    '    End If

    '    If txtGAShop.Text = "" Then
    '        txtGAShop.Text = "  "
    '    End If

    '    If txtHanmmerYear.Text = "" Then
    '        txtHanmmerYear.Text = "  "
    '    End If
    'End Sub

End Class