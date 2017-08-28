Public Class frmProductionTracking_AddEdit
#Region "Enumerator"
    Public Enum enuFormMode
        Add
        Edit
    End Enum
#End Region

#Region "Attribute"
    Private m_enuFormMode As enuFormMode

    Private m_intSkitNo As Integer
    Private m_intLaneNo As Integer
    Private m_intSeqNo As Integer
    Private m_strProcessName As String
    Private m_strModelYear As String
    Private m_strSuffixCode As String
    Private m_strLotNo As String
    Private m_strUnit As String

    Private m_objClsLogger As New clsLogger
#End Region

#Region "Property"
    Public ReadOnly Property SkitNo() As String
        Get
            Return cmbSkitNo.Text
        End Get
    End Property

    Public WriteOnly Property FormMode() As enuFormMode
        Set(ByVal value As enuFormMode)
            m_enuFormMode = value

            RefreshForm()
        End Set
    End Property

    Public Property ProductionDate() As String
        Get
            Return txtProductionDate.Text
        End Get
        Set(ByVal value As String)
            txtProductionDate.Text = value
        End Set
    End Property

    Public Property OnTime() As String
        Get
            Return txtOnTime.Text
        End Get
        Set(ByVal value As String)
            txtOnTime.Text = value
        End Set
    End Property

    Public Property ModelYear() As String
        Get
            Return txtModelYear.Text
        End Get
        Set(ByVal value As String)
            txtModelYear.Text = value
        End Set
    End Property

    Public Property SuffixCode() As String
        Get
            Return txtSuffixCode.Text
        End Get
        Set(ByVal value As String)
            txtSuffixCode.Text = value
        End Set
    End Property

    Public Property LotNo() As String
        Get
            Return txtLotNo.Text
        End Get
        Set(ByVal value As String)
            txtLotNo.Text = value
        End Set
    End Property

    Public Property Unit() As String
        Get
            Return txtUnit.Text
        End Get
        Set(ByVal value As String)
            txtUnit.Text = value
        End Set
    End Property

    Public ReadOnly Property CurrentProcess() As String
        Get
            Return cmbProcessNo.Text
        End Get
    End Property

    Public ReadOnly Property LaneNo() As String
        Get
            Return cmbLaneNo.Text
        End Get
    End Property
#End Region

#Region "Method"
    Private Sub RefreshForm()
        btnExecute.Visible = (m_enuFormMode = enuFormMode.Edit)

        Select Case m_enuFormMode
            Case enuFormMode.Add
                Me.Visible = True
        End Select
    End Sub

    Private Function UpdateSkitNo(ByRef ds As dsPAINT) As Boolean
        UpdateSkitNo = True

        If m_intSkitNo <> Val(cmbSkitNo.Text) Or Not cmbSkitNo.Enabled Then
            Dim drSKIT_MST As dsPAINT.dtSKIT_MSTRow
            If Not cmbSkitNo.Enabled Then
                taSKIT_MST.FillByItem(ds.dtSKIT_MST, ModelYear, SuffixCode, LotNo, Unit)
                If ds.dtSKIT_MST.Count > 0 Then
                    drSKIT_MST = ds.dtSKIT_MST(0)
                    With drSKIT_MST
                        .MODEL_YEAR = Nothing
                        .SUFFIX_CODE = Nothing
                        .LOT_NO = Nothing
                        .UNIT = Nothing
                    End With
                End If
            Else
                If m_intSkitNo > 0 Then
                    drSKIT_MST = ds.dtSKIT_MST.FindBySKIT_NO(m_intSkitNo)

                    With drSKIT_MST
                        .MODEL_YEAR = Nothing
                        .SUFFIX_CODE = Nothing
                        .LOT_NO = Nothing
                        .UNIT = Nothing
                    End With

                    If m_intLaneNo > 0 Then
                        Dim drWBS_ON As dsPAINT.dtWBS_ONRow = ds.dtWBS_ON.FirstOrDefault(Function(dr) drSKIT_MST.SKIT_NO = m_intSkitNo)
                        If drWBS_ON IsNot Nothing Then
                            drWBS_ON.Delete()
                        End If
                    End If
                End If

                If Val(cmbSkitNo.Text) > 0 Then
                    drSKIT_MST = ds.dtSKIT_MST.FindBySKIT_NO(cmbSkitNo.Text)

                    If drSKIT_MST Is Nothing Then
                        drSKIT_MST = ds.dtSKIT_MST.NewdtSKIT_MSTRow
                        drSKIT_MST.SKIT_NO = cmbSkitNo.Text
                        ds.dtSKIT_MST.AdddtSKIT_MSTRow(drSKIT_MST)
                    End If

                    With drSKIT_MST
                        If .MODEL_YEAR Is Nothing _
                                AndAlso .SUFFIX_CODE Is Nothing _
                                AndAlso .LOT_NO Is Nothing _
                                AndAlso .UNIT Is Nothing Then
                            .BeginEdit()

                            .MODEL_YEAR = txtModelYear.Text
                            .SUFFIX_CODE = txtSuffixCode.Text
                            .LOT_NO = txtLotNo.Text
                            .UNIT = txtUnit.Text

                            .EndEdit()
                        Else
                            lblSkitNo.BackColor = Color.Red
                            lblMsg.Text = "Error: Skit in use"
                            UpdateSkitNo = False
                        End If
                    End With
                End If
            End If
        End If
    End Function

    Private Function UpdateCurrentProcess(ByRef ds As dsPAINT) As Boolean
        UpdateCurrentProcess = True

        If m_strProcessName <> cmbProcessNo.Text Then
            Dim arrFollowingProcessNos As List(Of Integer) = GetFollowingProcessNos(ds)
            Dim drPAINT_CELL As dsPAINT.dtPAINT_CELLRow

            For Each drPAINT_CELL In ds.dtPAINT_CELL.Rows
                If arrFollowingProcessNos.Contains(drPAINT_CELL.PROCESS_NO) Then
                    drPAINT_CELL.Delete()
                End If
            Next drPAINT_CELL

            drPAINT_CELL = ds.dtPAINT_CELL.NewdtPAINT_CELLRow

            With drPAINT_CELL
                .BeginEdit()

                .MODEL_YEAR = txtModelYear.Text
                .SUFFIX_CODE = txtSuffixCode.Text
                .LOT_NO = txtLotNo.Text
                .UNIT = txtUnit.Text
                .PROCESS_NO = cmbProcessNo.SelectedValue
                .PROCESS_RESULT_DATE = Now

                .EndEdit()

            End With

            ds.dtPAINT_CELL.AdddtPAINT_CELLRow(drPAINT_CELL)
        End If
    End Function

    Private Function UpdateWBSLane(ByRef ds As dsPAINT) As Boolean
        UpdateWBSLane = True

        If cmbLaneNo.Enabled Then
            'If cmbSkitNo.Text = String.Empty Then
            '    lblSkitNo.BackColor = Color.Red
            '    lblMsg.Text = "Error: Skit No. Required"
            '    UpdateWBSLane = False
            'ElseIf m_intLaneNo <> cmbLaneNo.Text Then
            If m_intLaneNo <> cmbLaneNo.Text Then
                Dim drWBS_ON As dsPAINT.dtWBS_ONRow
                'If m_intLaneNo > 0 Then
                drWBS_ON = ds.dtWBS_ON.FirstOrDefault(Function(dr) dr.RowState <> DataRowState.Deleted AndAlso _
                                                          dr.MODEL_YEAR = m_strModelYear AndAlso _
                                                          dr.SUFFIX_CODE = m_strSuffixCode AndAlso _
                                                          dr.LOT_NO = m_strLotNo AndAlso _
                                                          dr.UNIT = m_strUnit)
                If drWBS_ON IsNot Nothing Then
                    drWBS_ON.Delete()
                End If
                'End If

                drWBS_ON = ds.dtWBS_ON.NewdtWBS_ONRow

                With drWBS_ON
                    .BeginEdit()

                    .LANE_NO = cmbLaneNo.Text
                    .SEQUENCE = 99
                    .MODEL_YEAR = txtModelYear.Text
                    .SUFFIX_CODE = txtSuffixCode.Text
                    .LOT_NO = txtLotNo.Text
                    .UNIT = txtUnit.Text

                    .EndEdit()
                End With

                ds.dtWBS_ON.AdddtWBS_ONRow(drWBS_ON)
            End If
        Else
            taWBS_ON.DeleteByModelYearSuffixCodeLotNoUnit(ModelYear, SuffixCode, LotNo, Unit)
        End If
    End Function

    Private Function GetFollowingProcessNos(ByRef ds As dsPAINT) As List(Of Integer)

        GetFollowingProcessNos = New List(Of Integer)

        Dim taPROCESS_LINKAGE As New taPROCESS_LINKAGE
        taPROCESS_LINKAGE.Fill(ds.dtPROCESS_LINKAGE)
        taPROCESS_MST.Fill(ds.dtPROCESS_MST)

        Dim dr As dsPAINT.dtPROCESS_MSTRow = ds.dtPROCESS_MST.FindByPROCESS_NO(cmbProcessNo.SelectedValue)

        GetProcessList(dr, GetFollowingProcessNos)

        Dim obj As DataRowView = cmbProcessNo.Items(0)
        Dim drFirst As dsPAINT.dtPROCESS_MSTRow = obj.Row
        dr = ds.dtPROCESS_MST.FindByPROCESS_NO(drFirst.PROCESS_NO)

        Dim lst As New List(Of Integer)
        Dim arrAllReservedProcessNos As List(Of List(Of Integer)) = GetReservedProcessList(dr, lst)

        Dim shortest_length As Integer = arrAllReservedProcessNos.Min(Of Integer)(Function(l) l.Count)
        Dim arrReservedProcessNos As IEnumerable(Of List(Of Integer)) = arrAllReservedProcessNos.Where(Function(l) l.Count = shortest_length)
        For Each lst In arrReservedProcessNos
            For Each i As Integer In lst
                GetFollowingProcessNos.Remove(i)
            Next i
        Next lst
    End Function

    Private Sub GetProcessList(ByRef dr As dsPAINT.dtPROCESS_MSTRow, ByRef lst As List(Of Integer))
        If Not lst.Contains(dr.PROCESS_NO) Then
            lst.Add(dr.PROCESS_NO)

            Dim drLnks As dsPAINT.dtPROCESS_LINKAGERow() = dr.GetdtPROCESS_LINKAGERowsByFK_T_PROCESS_LINKAGE_FROM_PROCESS_NO

            For Each drLnk As dsPAINT.dtPROCESS_LINKAGERow In drLnks
                GetProcessList(drLnk.dtPROCESS_MSTRowByFK_T_PROCESS_LINKAGE_TO_PROCESS_NO, lst)
            Next drLnk
        End If
    End Sub

    Private Function GetReservedProcessList(ByRef dr As dsPAINT.dtPROCESS_MSTRow, ByRef lst As List(Of Integer)) As List(Of List(Of Integer))
        GetReservedProcessList = New List(Of List(Of Integer))

        If Not lst.Contains(dr.PROCESS_NO) AndAlso (dr.PROCESS_NO <> cmbProcessNo.SelectedValue) Then
            lst.Add(dr.PROCESS_NO)

            Dim lsts As List(Of List(Of Integer))
            Dim drLnks As dsPAINT.dtPROCESS_LINKAGERow() = dr.GetdtPROCESS_LINKAGERowsByFK_T_PROCESS_LINKAGE_FROM_PROCESS_NO

            If drLnks.Count > 0 Then
                For Each drLnk As dsPAINT.dtPROCESS_LINKAGERow In drLnks
                    Dim l As List(Of Integer) = lst.GetRange(0, lst.Count)
                    lsts = GetReservedProcessList(drLnk.dtPROCESS_MSTRowByFK_T_PROCESS_LINKAGE_TO_PROCESS_NO, l)

                    GetReservedProcessList.AddRange(lsts)
                Next drLnk
            Else
                GetReservedProcessList.Add(lst)
            End If
        Else
            GetReservedProcessList.Add(lst)
        End If
    End Function

    Private Sub DbgPrint(ByRef lst As List(Of Integer), Optional ByVal x As String = "")
        Dim str As String = String.Empty
        For Each i As Integer In lst
            str &= " --> " & i
        Next i
        Debug.Print(str & String.Format(" [{0}]", x))
    End Sub

#End Region

#Region "Event"
    Private Sub btnAccept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
     btnExecute.Click
        Try
            Select Case m_enuFormMode
                Case enuFormMode.Edit
                    Dim bResult As Boolean = True
                    Dim ds As New dsPAINT

                    lblMsg.Text = String.Empty
                    lblSkitNo.BackColor = SystemColors.Control

                    Try
                        Me.taSKIT_MST.Fill(ds.dtSKIT_MST)
                        Me.taWBS_ON.Fill(ds.dtWBS_ON)
                        Me.taPAINT_CELL.FillByProdDat(ds.dtPAINT_CELL, _
                                                      txtModelYear.Text, txtSuffixCode.Text, _
                                                      txtLotNo.Text, txtUnit.Text)

                        If bResult Then bResult = UpdateSkitNo(ds)
                        If bResult Then bResult = UpdateCurrentProcess(ds)
                        If bResult Then bResult = UpdateWBSLane(ds)

                    Catch ex As Exception
                        m_objClsLogger.LogException(Me.GetType.Name, "btnAccept_Click", ex, True)

                        bResult = False
                        lblMsg.Text = "Error: " & ex.Message
                    End Try

                    If bResult Then

                        Me.taSKIT_MST.Update(ds.dtSKIT_MST)
                        Me.taWBS_ON.Update(ds.dtWBS_ON)
                        Me.taPAINT_CELL.Update(ds.dtPAINT_CELL)

                        ds.AcceptChanges()

                        Me.taWBS_ON.ReorderSeq()

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()
                    Else
                        ds.RejectChanges()
                    End If
            End Select
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "btnAccept_Click", ex, True)
        End Try
    End Sub

    Private Sub frmProductionTracking_AddEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.taPROCESS_MST.FillByNextGroup(dsPAINT1.dtPROCESS_MST, 1000, 0, 0, 0)
            Me.taLANE_MST.Fill(dsPAINT1.dtLANE_MST)

            lblMsg.Text = String.Empty

            Dim taWBS_ON As New taWBS_ON

            Dim taPRODUCTION_DAT As New taPRODUCTION_DAT
            taPRODUCTION_DAT.Fill(dsPAINT1.dtPRODUCTION_DAT)

            taWBS_ON.Fill(dsPAINT1.dtWBS_ON)
            'Me.taSKIT_MST.FillByItem(dsPAINT1.dtSKIT_MST, _
            '                         txtModelYear.Text, txtSuffixCode.Text, _
            '                         txtLotNo.Text, txtUnit.Text)
            m_strModelYear = txtModelYear.Text
            m_strSuffixCode = txtSuffixCode.Text
            m_strLotNo = txtLotNo.Text
            m_strUnit = txtUnit.Text

            Dim drProd As dsPAINT.dtPRODUCTION_DATRow = dsPAINT1.dtPRODUCTION_DAT.FindByMODEL_YEARSUFFIX_CODELOT_NOUNIT( _
                                                                             txtModelYear.Text, txtSuffixCode.Text, _
                                                                             txtLotNo.Text, txtUnit.Text)

            If drProd.GetdtWBS_ONRows.Count > 0 Then
                m_intLaneNo = drProd.GetdtWBS_ONRows(0).LANE_NO
                m_intSeqNo = drProd.GetdtWBS_ONRows(0).SEQUENCE

                cmbLaneNo.Text = m_intLaneNo
            End If
            'For Each dr As dsPAINT.dtSKIT_MSTRow In dsPAINT1.dtSKIT_MST
            '    If dr.dtPRODUCTION_DATRowParent.GetdtWBS_ONRows.Count > 0 Then
            '        'If dr.GetdtWBS_ONRows.Count > 0 Then
            '        m_intLaneNo = dr.dtPRODUCTION_DATRowParent.GetdtWBS_ONRows(0).LANE_NO
            '        m_intSeqNo = dr.dtPRODUCTION_DATRowParent.GetdtWBS_ONRows(0).SEQUENCE

            '        cmbLaneNo.Text = m_intLaneNo
            '    End If

            '    Exit For
            'Next dr

            Dim taPntCll As New taPAINT_CELL
            taPntCll.FillByProdDat(dsPAINT1.dtPAINT_CELL, txtModelYear.Text, txtSuffixCode.Text, _
                                     txtLotNo.Text, txtUnit.Text)

            'TODO: This line of code loads data into the 'dsPAINT.dtPROCESS_MST' table. You can move, or remove it, as needed.
            'Me.taSKIT_MST.FillEmpty(dsPAINT1.dtSKIT_MST)
            Me.taSKIT_MST.FillByItem(dsPAINT1.dtSKIT_MST, m_strModelYear, m_strSuffixCode, m_strLotNo, m_strUnit)
            If (dsPAINT1.dtSKIT_MST.Count > 0) Then
                m_intSkitNo = dsPAINT1.dtSKIT_MST(0).SKIT_NO
            Else
                m_intSkitNo = 0
            End If

            Me.taSKIT_MST.FillByAvailableSkid(dsPAINT1.dtSKIT_MST, m_intSkitNo)

            If m_intSkitNo > 0 Then cmbSkitNo.Text = m_intSkitNo

            If dsPAINT1.dtPAINT_CELL.Rows.Count > 0 Then
                Dim drPntCll As dsPAINT.dtPAINT_CELLRow
                drPntCll = dsPAINT1.dtPAINT_CELL.Select("max(process_result_date) = process_result_date")(0)

                cmbProcessNo.SelectedValue = drPntCll.PROCESS_NO
                m_strProcessName = cmbProcessNo.Text
            End If
            EnableLane()
            EnableSkit()
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "frmProductionTracking_AddEdit_Load", ex, True)
        End Try
    End Sub

    Private Sub cmbProcessNo_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProcessNo.SelectedValueChanged
        Try
            EnableLane()
            EnableSkit()
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "cmbProcessNo_SelectedValueChanged", ex, True)
        End Try
    End Sub

    Private Sub EnableSkit()
        Try
            Dim p As DataRowView = cmbProcessNo.SelectedItem
            If p IsNot Nothing Then
                Dim r As dsPAINT.dtPROCESS_MSTRow = p.Row
                Dim taProcLnk As New taPROCESS_LINKAGE

                taProcLnk.Fill(dsPAINT1.dtPROCESS_LINKAGE)

                If (dsPAINT1.dtPROCESS_LINKAGE.Select("from_process_no = " + r.PROCESS_NO.ToString).Length = 0 AndAlso (r.PROCESS_TYPE = 2 Or r.PROCESS_TYPE = 3)) Or r.PROCESS_TYPE = 1 Then
                    cmbSkitNo.SelectedItem = Nothing
                    cmbSkitNo.Enabled = False
                Else
                    cmbSkitNo.Enabled = True
                End If

            End If
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "EnableSkit", ex, True)
        End Try
    End Sub

    Private Sub EnableLane()
        Try
            Dim p As DataRowView = cmbProcessNo.SelectedItem
            If p IsNot Nothing Then
                Dim r As dsPAINT.dtPROCESS_MSTRow = p.Row
                cmbLaneNo.Enabled = (r.PROCESS_TYPE = dsPAINT.dtPROCESS_MSTDataTable.enuProcessType.WBS)
            Else
                cmbLaneNo.Enabled = False
            End If
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "EnableLane", ex, True)
        End Try
    End Sub
#End Region
End Class