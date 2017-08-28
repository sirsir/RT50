Public Class frmModelOptionSetting_AddEdit
#Region "Constant"

#End Region

#Region "Enumerator"
    Public Enum enuFormMode
        Add
        Edit
    End Enum
#End Region

#Region "Attribute"
    Private m_regexpModelCode As New Regex("^([0-9 ]{3}[0-9A-Za-z ]{1,3}[*][0-9A-Za-z ])$")

    Private m_strModelCode As String
    Private m_intModelOptionRowId As Integer

    Private m_enuFormMode As enuFormMode
    Private m_enuLastFormMode As enuFormMode

    Private m_row As dsPAINT.dtMODEL_OPTION_ROWRow
    Private m_intOptDestId As Integer

    Private m_objClsLogger As New clsLogger
#End Region

#Region "Constructor"

#End Region

#Region "Property"
    Public WriteOnly Property FormMode() As enuFormMode
        Set(ByVal value As enuFormMode)
            m_enuFormMode = value

            RefreshForm()
        End Set
    End Property

    Private ReadOnly Property dtModelOptionRow() As dsPAINT.dtMODEL_OPTION_ROWDataTable
        Get
            Return dsPAINT1.dtMODEL_OPTION_ROW
        End Get
    End Property

    Private ReadOnly Property dtOptionMst() As dsPAINT.dtOPTION_MSTDataTable
        Get
            Return dsPAINT1.dtOPTION_MST
        End Get
    End Property

    Private ReadOnly Property dtModelOptionCell() As dsPAINT.dtMODEL_OPTION_CELLDataTable
        Get
            Return dsPAINT1.dtMODEL_OPTION_CELL
        End Get
    End Property

    Private ReadOnly Property OptionType() As dsPAINT.dtOPTION_MSTDataTable.enuOptionType
        Get
            Return dsPAINT.dtOPTION_MSTDataTable.enuOptionType.OptionTable
        End Get
    End Property

    Public Property ModelCode() As String
        Get
            Return m_strModelCode
        End Get
        Set(ByVal value As String)
            m_strModelCode = value

            mtbModelCode.Text = m_strModelCode
        End Set
    End Property

    Public ReadOnly Property ModelYearPattern() As String
        Get
            Return m_strModelCode.Substring(0, 3)
        End Get
    End Property

    Public ReadOnly Property SuffixCodePattern() As String
        Get
            Return m_strModelCode.Substring(3, 5)
        End Get
    End Property

    Public WriteOnly Property ModelOptionRowId() As Integer
        Set(ByVal value As Integer)
            m_intModelOptionRowId = value
        End Set
    End Property
#End Region

#Region "Method"
    Private Sub RefreshForm()
        dgvData.Visible = (m_enuFormMode = enuFormMode.Edit)
        btnNext.Visible = (m_enuFormMode = enuFormMode.Add)
        btnExecute.Visible = (m_enuFormMode = enuFormMode.Edit)

        lblDestination.Visible = (m_enuFormMode = enuFormMode.Edit)
        cboDestination.Visible = (m_enuFormMode = enuFormMode.Edit)

        Select Case m_enuFormMode
            Case enuFormMode.Add
                AddHandlers(mtbModelCode)
            Case enuFormMode.Edit
                RemoveHandlers(mtbModelCode)
        End Select
    End Sub

    Private Function IsNotValidate() As Boolean
        Dim blnNotValid As Boolean = True
        Dim clrIsvalid As Color = SystemColors.Control
        Dim strMsg As String = String.Empty

        Dim strModelCode As String = mtbModelCode.Text.ToUpper

        If Not m_regexpModelCode.IsMatch(strModelCode) Then
            If Char.IsPunctuation(strModelCode.Last) Then strModelCode = strModelCode + " "
            strMsg = String.Format("Error: {0} is invalid.", strModelCode.Replace(" ", "_"))

            clrIsvalid = Color.Red
            blnNotValid = False
        Else
            Dim strFilterExpression As String = "MODEL_CODE = '" + strModelCode + "'"
            Dim drs() As dsPAINT.dtMODEL_OPTION_ROWRow = dtModelOptionRow.Select(strFilterExpression)

            If drs.Length > 0 AndAlso m_strModelCode <> strModelCode AndAlso m_enuFormMode = enuFormMode.Add Then
                strMsg = String.Format("Error: {0} is duplicated.", strModelCode)

                clrIsvalid = Color.Red
                blnNotValid = False
            End If
        End If

        lblModelCode.BackColor = clrIsvalid
        lblMsg.Text = strMsg

        m_strModelCode = strModelCode

        Return blnNotValid Or m_enuFormMode = enuFormMode.Edit
    End Function

    Private Function InsertRow() As dsPAINT.dtMODEL_OPTION_ROWRow
        Dim dr As dsPAINT.dtMODEL_OPTION_ROWRow = Nothing

        Try
            dr = dtModelOptionRow.NewdtMODEL_OPTION_ROWRow

            With dr
                .BeginEdit()
                .MODEL_YEAR_PATTERN = m_strModelCode.Substring(0, 3)
                .SUFFIX_CODE_PATTERN = m_strModelCode.Substring(3, 5)
                .EndEdit()
            End With

            dtModelOptionRow.AdddtMODEL_OPTION_ROWRow(dr)

            taMODEL_OPTION_ROW1.Update(dtModelOptionRow)
            dtModelOptionRow.AcceptChanges()

        Catch ex As Exception
            dtModelOptionRow.RejectChanges()
            m_objClsLogger.LogException(Me.GetType.Name, "InsertRow", ex, True)
        End Try

        Return dr
    End Function

    Private Sub UpdateRow()
        Try
            With m_row
                .BeginEdit()
                .MODEL_YEAR_PATTERN = m_strModelCode.Substring(0, 3)
                .SUFFIX_CODE_PATTERN = m_strModelCode.Substring(3, 5)
                .EndEdit()
            End With

            taMODEL_OPTION_ROW1.Update(dtModelOptionRow)
            dtModelOptionRow.AcceptChanges()

        Catch ex As Exception
            dtModelOptionRow.RejectChanges()
            m_objClsLogger.LogException(Me.GetType.Name, "UpdateRow", ex, True)
        End Try
    End Sub

    Private Sub DeleteRow()
        Try
            With m_row
                taMODEL_OPTION_ROW1.Delete(.MODEL_OPTION_ROW_ID, .MODEL_YEAR_PATTERN, .SUFFIX_CODE_PATTERN)
            End With

            dtModelOptionRow.RemovedtMODEL_OPTION_ROWRow(m_row)
            taMODEL_OPTION_ROW1.Update(dtModelOptionRow)
            dtModelOptionRow.AcceptChanges()
        Catch ex As Exception
            dtModelOptionRow.RejectChanges()
            m_objClsLogger.LogException(Me.GetType.Name, "DeleteRow", ex, True)
        End Try
    End Sub


    Private Sub DeleteRowToOverwrite()
        Try
            Dim strExpression As String = String.Empty
            strExpression &= "MODEL_YEAR_PATTERN = '" & ModelYearPattern & "'"
            strExpression &= " AND SUFFIX_CODE_PATTERN = '" & SuffixCodePattern & "'"

            Dim dr() As dsPAINT.dtMODEL_OPTION_ROWRow = dsPAINT1.dtMODEL_OPTION_ROW.Select(strExpression)
            If dr.Length > 0 Then
                With dr(0)
                    taMODEL_OPTION_ROW1.Delete(.MODEL_OPTION_ROW_ID, .MODEL_YEAR_PATTERN, .SUFFIX_CODE_PATTERN)
                End With
                dtModelOptionRow.RemovedtMODEL_OPTION_ROWRow(dr(0))
                taMODEL_OPTION_ROW1.Update(dtModelOptionRow)
                dtModelOptionRow.AcceptChanges()
            End If
        Catch ex As Exception
            dtModelOptionRow.RejectChanges()
            m_objClsLogger.LogException(Me.GetType.Name, "DeleteRow", ex, True)
        End Try
    End Sub

    Private Sub LoadCells(ByVal nFormMode As enuFormMode)
        Try
            Select Case nFormMode
                Case enuFormMode.Add
                    For Each col As dsPAINT.dtOPTION_MSTRow In dtOptionMst.Rows
                        If col.OPTION_TYPE = OptionType() Then
                            InsertCells(col)
                        End If
                    Next
                Case enuFormMode.Edit
                    For Each col As dsPAINT.dtOPTION_MSTRow In dtOptionMst.Rows
                        Dim dr As dsPAINT.dtMODEL_OPTION_CELLRow = _
                            dtModelOptionCell.FindByMODEL_OPTION_ROW_IDOPTION_ID(m_row.MODEL_OPTION_ROW_ID, _
                                                                                 col.OPTION_ID)
                        If col.OPTION_TYPE = OptionType() Then
                            If dr Is Nothing Then InsertCells(col)
                        Else
                            If dr IsNot Nothing Then
                                cboDestination.SelectedValue = col.OPTION_ID
                                m_intOptDestId = col.OPTION_ID
                            End If
                        End If
                    Next
            End Select

            dtModelOptionCell.AcceptChanges()
        Catch ex As Exception
            dtModelOptionCell.RejectChanges()
            m_objClsLogger.LogException(Me.GetType.Name, "LoadCells", ex, True)
        End Try

        ShowCells()
    End Sub

    Private Sub InsertCells(ByVal col As dsPAINT.dtOPTION_MSTRow)
        Dim dr As dsPAINT.dtMODEL_OPTION_CELLRow = dtModelOptionCell.NewdtMODEL_OPTION_CELLRow

        With dr
            .BeginEdit()
            .MODEL_OPTION_ROW_ID = m_row.MODEL_OPTION_ROW_ID
            .OPTION_ID = col.OPTION_ID
            .IS_USED = IIf(col.OPTION_TYPE = OptionType(), False, True)
            .EndEdit()
        End With

        dtModelOptionCell.AdddtMODEL_OPTION_CELLRow(dr)

        taMODEL_OPTION_CELL1.Update(dtModelOptionCell)
    End Sub

    Private Sub InsertCopyCells(ByVal drRow As dsPAINT.dtMODEL_OPTION_ROWRow)
        Dim dr As dsPAINT.dtMODEL_OPTION_CELLRow

        Try
            ' ''Insert Option Table Cell
            For i As Integer = 0 To bsMODELOPTIONCELL.Count - 1
                dr = dtModelOptionCell.NewdtMODEL_OPTION_CELLRow

                With dr
                    .BeginEdit()
                    .MODEL_OPTION_ROW_ID = drRow.MODEL_OPTION_ROW_ID
                    .OPTION_ID = bsMODELOPTIONCELL.Item(i).Row.OPTION_ID
                    .IS_USED = bsMODELOPTIONCELL.Item(i).Row.IS_USED
                    .EndEdit()
                End With

                dtModelOptionCell.AdddtMODEL_OPTION_CELLRow(dr)
            Next

            taMODEL_OPTION_CELL1.Update(dtModelOptionCell)
            dtModelOptionCell.AcceptChanges()
        Catch ex As Exception
            dtModelOptionCell.RejectChanges()
            m_objClsLogger.LogException(Me.GetType.Name, "InsertCopyCells", ex, True)
        End Try

        Try
            ' ''Insert Option Destination Cell
            taMODEL_OPTION_CELL1.Fill(dsPAINT1.dtMODEL_OPTION_CELL)
            dr = dtModelOptionCell.NewdtMODEL_OPTION_CELLRow

            With dr
                .BeginEdit()
                .MODEL_OPTION_ROW_ID = drRow.MODEL_OPTION_ROW_ID
                .OPTION_ID = cboDestination.SelectedValue
                .IS_USED = True
                .EndEdit()
            End With

            dtModelOptionCell.AdddtMODEL_OPTION_CELLRow(dr)
            taMODEL_OPTION_CELL1.Update(dtModelOptionCell)
            dtModelOptionCell.AcceptChanges()
        Catch ex As Exception
            dtModelOptionCell.RejectChanges()
            m_objClsLogger.LogException(Me.GetType.Name, "InsertCopyCells", ex, True)
        End Try
    End Sub

    Private Sub UpdateCells()
        Try
            Dim dr As dsPAINT.dtMODEL_OPTION_CELLRow

            ' ''Update Option Table Cell
            For i As Integer = 0 To bsMODELOPTIONCELL.Count - 1
                dr = bsMODELOPTIONCELL.Item(i).Row

                With dr
                    .BeginEdit()
                    .IS_USED = .IS_USED
                    .EndEdit()
                End With
            Next

            taMODEL_OPTION_CELL1.Update(dtModelOptionCell)
            dtModelOptionCell.AcceptChanges()

            taMODEL_OPTION_CELL1.Fill(dsPAINT1.dtMODEL_OPTION_CELL)
            dr = dtModelOptionCell.FindByMODEL_OPTION_ROW_IDOPTION_ID(m_row.MODEL_OPTION_ROW_ID, _
                                                                      m_intOptDestId)
            ' ''Insert/Update Option Destination Cell
            If dr Is Nothing Then
                InsertCells(dtOptionMst.FindByOPTION_ID(cboDestination.SelectedValue))
            Else
                With dr
                    .BeginEdit()
                    .OPTION_ID = cboDestination.SelectedValue
                    .EndEdit()
                End With
            End If

            taMODEL_OPTION_CELL1.Update(dtModelOptionCell)
            dtModelOptionCell.AcceptChanges()
        Catch ex As Exception
            dtModelOptionCell.RejectChanges()
            m_objClsLogger.LogException(Me.GetType.Name, "UpdateCells", ex, True)
        End Try
    End Sub

    Private Sub UpdateExistsCells(ByVal drRow As dsPAINT.dtMODEL_OPTION_ROWRow)
        Try
            Dim drCell As dsPAINT.dtMODEL_OPTION_CELLRow

            ' ''Update Option Table Cell
            For i As Integer = 0 To bsMODELOPTIONCELL.Count - 1
                drCell = dtModelOptionCell.FindByMODEL_OPTION_ROW_IDOPTION_ID(drRow.MODEL_OPTION_ROW_ID, _
                                                                              bsMODELOPTIONCELL.Item(i).Row.OPTION_ID)
                With drCell
                    .BeginEdit()
                    .IS_USED = bsMODELOPTIONCELL.Item(i).Row.IS_USED
                    .EndEdit()
                End With
            Next

            taMODEL_OPTION_CELL1.Update(dtModelOptionCell)
            dtModelOptionCell.AcceptChanges()

            taMODEL_OPTION_CELL1.Fill(dsPAINT1.dtMODEL_OPTION_CELL)
            drCell = dtModelOptionCell.FindByMODEL_OPTION_ROW_IDOPTION_ID(drRow.MODEL_OPTION_ROW_ID, _
                                                                          m_intOptDestId)
            ' ''Insert/Update Option Destination Cell
            If drCell Is Nothing Then
                InsertCells(dtOptionMst.FindByOPTION_ID(cboDestination.SelectedValue))
            Else
                With drCell
                    .BeginEdit()
                    .OPTION_ID = cboDestination.SelectedValue
                    .EndEdit()
                End With
            End If

            taMODEL_OPTION_CELL1.Update(dtModelOptionCell)
            dtModelOptionCell.AcceptChanges()
        Catch ex As Exception
            dtModelOptionCell.RejectChanges()
            m_objClsLogger.LogException(Me.GetType.Name, "UpdateExistsCells", ex, True)
        End Try
    End Sub

    Private Sub ShowCells()
        taMODEL_OPTION_CELL1.FillByOptType(dsPAINT1.dtMODEL_OPTION_CELL, OptionType)
        bsMODELOPTIONCELL.Filter = "MODEL_OPTION_ROW_ID = " + m_row.MODEL_OPTION_ROW_ID.ToString
    End Sub
#End Region

#Region "Event"

    Private Sub AddHandlers(ByRef mtb As MaskedTextBox)
        AddHandler mtb.KeyDown, AddressOf mtbModelCode_KeyDown
    End Sub

    Private Sub RemoveHandlers(ByRef mtb As MaskedTextBox)
        RemoveHandler mtb.KeyDown, AddressOf mtbModelCode_KeyDown
    End Sub

    Private Sub frmModelOptionSetting_AddEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Text = String.Format(Me.Text, m_enuFormMode.ToString.ToUpper)
            m_enuLastFormMode = m_enuFormMode

            taMODEL_OPTION_ROW1.Fill(dsPAINT1.dtMODEL_OPTION_ROW)
            taOPTION_MST1.Fill(dsPAINT1.dtOPTION_MST)
            taMODEL_OPTION_CELL1.Fill(dsPAINT1.dtMODEL_OPTION_CELL)

            lblMsg.Text = String.Empty

            If m_enuFormMode = enuFormMode.Edit Then
                m_row = dtModelOptionRow.FindByMODEL_OPTION_ROW_ID(m_intModelOptionRowId)
                LoadCells(enuFormMode.Edit)
            End If
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "frmModelOptionSetting_AddEdit_Load", ex, True)
        End Try
    End Sub

    Private Sub btnAccept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
        btnNext.Click, btnExecute.Click

        Try
            If m_enuFormMode = enuFormMode.Add Then m_strModelCode = String.Empty
            lblModelCode.BackColor = SystemColors.Control
            lblMsg.Text = String.Empty

            If IsNotValidate() Then
                Select Case m_enuFormMode
                    Case enuFormMode.Add
                        m_row = InsertRow()
                        LoadCells(enuFormMode.Add)

                        m_enuFormMode = enuFormMode.Edit
                        RefreshForm()
                    Case enuFormMode.Edit
                        If m_row.MODEL_CODE <> mtbModelCode.Text Then
                            Dim strFilterExp As String = String.Empty
                            strFilterExp &= "MODEL_YEAR_PATTERN = '" + ModelYearPattern + "'"
                            strFilterExp &= "AND SUFFIX_CODE_PATTERN = '" + SuffixCodePattern + "'"

                            Dim dr() As dsPAINT.dtMODEL_OPTION_ROWRow = dsPAINT1.dtMODEL_OPTION_ROW.Select(strFilterExp)
                            Dim strMsg As String = String.Empty

                            If dr.Length > 0 Then
                                strMsg = String.Format("{0} already exists, " + _
                                                       "Are you sure you want to overwrite this {0}?", _
                                                       dr.First.MODEL_CODE)

                                If MsgBox(strMsg, MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                                    'UpdateExistsCells(dr.First)

                                    'Fix Overwrite Bug Start'
                                    DeleteRowToOverwrite()

                                    Dim drNew As dsPAINT.dtMODEL_OPTION_ROWRow = InsertRow()
                                    InsertCopyCells(drNew)

                                    m_intModelOptionRowId = drNew.MODEL_OPTION_ROW_ID
                                    'Fix Overwrite Bug End'

                                    Me.DialogResult = Windows.Forms.DialogResult.OK
                                End If
                            Else
                                strMsg = String.Format("{0} does not already exists, " + _
                                                       "Are you sure you want to add new {0}?", _
                                                       mtbModelCode.Text)

                                If MsgBox(strMsg, MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                                    Dim drNew As dsPAINT.dtMODEL_OPTION_ROWRow = InsertRow()
                                    InsertCopyCells(drNew)

                                    m_intModelOptionRowId = drNew.MODEL_OPTION_ROW_ID

                                    Me.DialogResult = Windows.Forms.DialogResult.OK
                                End If
                            End If
                        Else
                            UpdateCells()

                            Me.DialogResult = Windows.Forms.DialogResult.OK

                            m_strModelCode = m_row.MODEL_CODE
                        End If
                End Select
            End If
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "btnAccept_Click", ex, True)
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Try
            If m_enuLastFormMode <> m_enuFormMode AndAlso m_enuLastFormMode = enuFormMode.Add Then DeleteRow()
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "btnCancel_Click", ex, True)
        End Try
    End Sub

    Private Sub mtbModelCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            If e.KeyCode = Keys.Enter Then btnAccept_Click(Nothing, e)
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "mtbModelCode_KeyDown", ex, True)
        End Try
    End Sub

#End Region
End Class