Public Class ctrlOptionList
#Region "Constant"
    Private Const CIRCLE_WIDTH As Integer = 10
    Private Const CIRCLE_HEIGHT As Integer = 10
#End Region

#Region "Enumerator"

#End Region

#Region "Attribute"
    Private m_objList As clsModelBase
    Private m_lsvItemSelected As ListViewItem
    Private m_strF6TextBase As String
    Private m_objClsLogger As New clsLogger
    Private m_objClsDBLogger As New clsDBLogger
#End Region

#Region "Constructor"

#End Region

#Region "Property"

#End Region

#Region "Method"

    Private Sub LoadHeaderName()
        lblHeader1.Text = ParseColumnName(ScreenName.ToString)
    End Sub

    Public Sub LoadData()
        Dim columns() As ColumnHeader = Nothing
        Dim rows() As ListViewItem = Nothing

        Select Case ScreenName
            Case enuScreenName.Model_Option_Setting
                m_objList = New clsModelOptionSetting
            Case enuScreenName.Process_Option_Setting
                m_objList = New clsProcessOptionSetting
        End Select

        lsvData.Clear()
        If m_objList IsNot Nothing Then
            m_objList.LoadData("", "", clsModelBase.enuFillBy.NextGroup)

            lsvData.Columns.AddRange(m_objList.Columns)
            lsvData.Items.AddRange(m_objList.ColumnDetails)
            lsvData.Items.AddRange(m_objList.Rows)
        End If
    End Sub

    Private Sub Add()
        Dim dlg As New frmModelOptionSetting_AddEdit
        dlg.FormMode = frmModelOptionSetting_AddEdit.enuFormMode.Add

        If dlg.ShowDialog = DialogResult.OK Then
            If m_objList.IsNotNewModelCode Then
                NavigateTo(m_objList, dlg.ModelYearPattern, dlg.SuffixCodePattern, lsvData)
                m_objClsDBLogger.Log(DB_LOG_CODE_N_ADD_MODEL_OPTION_ROW, Nothing, dlg.ModelCode)
            Else
                NavigateCurrent(ScreenName, lsvData, m_objList)
            End If
        Else
            If m_lsvItemSelected IsNot Nothing Then m_lsvItemSelected.Selected = True : lsvData.Focus()
        End If

        m_lsvItemSelected = Nothing
    End Sub

    Private Sub Edit()
        If m_lsvItemSelected IsNot Nothing Then
            Dim dlg As Object = Nothing
            Dim blnDialogResult As Boolean = True
            Dim objFirstRow As ListViewItem = m_lsvItemSelected

            Select Case ScreenName
                Case enuScreenName.Model_Option_Setting
                    dlg = New frmModelOptionSetting_AddEdit
                    dlg.FormMode = frmModelOptionSetting_AddEdit.enuFormMode.Edit
                    dlg.ModelCode = objFirstRow.SubItems(0).Text
                    dlg.ModelOptionRowId = Convert.ToInt32(objFirstRow.SubItems(objFirstRow.SubItems.Count - 1).Text)

                    blnDialogResult = (dlg.ShowDialog = DialogResult.OK)
                Case enuScreenName.Process_Option_Setting
                    dlg = New frmProcessOptionSetting_Edit
                    dlg.FormMode = frmModelOptionSetting_AddEdit.enuFormMode.Edit
                    dlg.ProcessNo = Convert.ToInt32(objFirstRow.SubItems(objFirstRow.SubItems.Count - 1).Text)
                    dlg.ProcessName = objFirstRow.SubItems(1).Text
                    dlg.ProcessType = Convert.ToInt32(objFirstRow.SubItems(objFirstRow.SubItems.Count - 2).Text)

                    blnDialogResult = (dlg.ShowDialog = DialogResult.OK)
            End Select

            If blnDialogResult Then
                Dim strParam1 As String = String.Empty
                Dim strParam2 As String = String.Empty

                Select Case ScreenName
                    Case enuScreenName.Model_Option_Setting
                        strParam1 = dlg.ModelYearPattern
                        strParam2 = dlg.SuffixCodePattern

                        m_objClsDBLogger.Log(DB_LOG_CODE_N_EDIT_MODEL_OPTION_ROW, Nothing, dlg.ModelCode)
                    Case enuScreenName.Process_Option_Setting
                        strParam1 = dlg.ProcessType
                        strParam2 = dlg.ProcessCode

                        m_objClsDBLogger.Log(DB_LOG_CODE_N_EDIT_PROCESS_OPTION_ROW, Nothing, dlg.ProcessCode, dlg.ProcessName)
                End Select

                NavigateTo(m_objList, strParam1, strParam2, lsvData)
            Else
                m_lsvItemSelected.Selected = True
                lsvData.Focus()
            End If

            m_lsvItemSelected = Nothing
        Else
            Dim strMsg As String = "Please select {0} for edit " + ParseColumnName(ScreenName.ToString).ToLower
            Select Case ScreenName
                Case enuScreenName.Model_Option_Setting
                    strMsg = String.Format(strMsg, "model code")
                Case enuScreenName.Process_Option_Setting
                    strMsg = String.Format(strMsg, "process name")
            End Select

            MsgBox(strMsg, MsgBoxStyle.Exclamation, "Warning")
        End If
    End Sub

    Private Sub Delete()
        If m_lsvItemSelected IsNot Nothing Then
            If MsgBox("Are you sure?", MsgBoxStyle.YesNo, "Delete Confirmation") = MsgBoxResult.Yes Then
                Dim objFirstRow As ListViewItem = m_lsvItemSelected
                Dim intParameterRowId As Integer = Convert.ToInt32(objFirstRow.SubItems(objFirstRow.SubItems.Count - 1).Text)
                Dim strModelYearPattern As String = objFirstRow.SubItems(0).Text.Substring(0, 3)
                Dim strSuffixCodePattern As String = objFirstRow.SubItems(0).Text.Substring(3, 5)
                Dim ta As New taMODEL_OPTION_ROW

                ta.Delete(intParameterRowId, strModelYearPattern, strSuffixCodePattern)
                m_objClsDBLogger.Log(DB_LOG_CODE_N_DELETE_MODEL_OPTION_ROW, Nothing, objFirstRow.SubItems(0).Text)

                NavigateCurrent(ScreenName, lsvData, m_objList)
            Else
                m_lsvItemSelected.Selected = True
                lsvData.Focus()
            End If

            m_lsvItemSelected = Nothing
        Else
            MsgBox("Please select model code for delete model option setting", MsgBoxStyle.Exclamation, "Warning")
        End If
    End Sub

    Private Sub NavigateSearch()
        Dim dlg As Object = Nothing
        Dim blnDialogResult As Boolean = True

        Dim objFirstRow As ListViewItem = Nothing
        If m_lsvItemSelected IsNot Nothing Then objFirstRow = m_lsvItemSelected

        Select Case ScreenName
            Case enuScreenName.Model_Option_Setting
                dlg = New frmModelOptionSetting_Search

                If objFirstRow IsNot Nothing Then
                    dlg.ModelCode = objFirstRow.SubItems(0).Text
                End If

                blnDialogResult = (dlg.ShowDialog = DialogResult.OK)
            Case enuScreenName.Process_Option_Setting
                dlg = New frmProcessSearch

                If objFirstRow IsNot Nothing Then
                    dlg.ProcessName = objFirstRow.SubItems(1).Text
                End If

                blnDialogResult = (dlg.ShowDialog = DialogResult.OK)
        End Select

        If blnDialogResult Then
            Dim strParam1 As String = String.Empty
            Dim strParam2 As String = String.Empty

            Select Case ScreenName
                Case enuScreenName.Model_Option_Setting
                    strParam1 = dlg.ModelYearPattern
                    strParam2 = dlg.SuffixCodePattern
                Case enuScreenName.Process_Option_Setting
                    strParam1 = dlg.ProcessType
                    strParam2 = dlg.ProcessCode
            End Select

            NavigateTo(m_objList, strParam1, strParam2, lsvData)
        Else
            If m_lsvItemSelected IsNot Nothing Then m_lsvItemSelected.Selected = True
            lsvData.Focus()
        End If

        m_lsvItemSelected = Nothing
    End Sub

    Private Sub ResetBtnsOperator()
        ctrlBtnsOperator1.F1 = False
        ctrlBtnsOperator1.F2 = False
        ctrlBtnsOperator1.F3 = False
        ctrlBtnsOperator1.F4 = False
        ctrlBtnsOperator1.F5 = False
        ctrlBtnsOperator1.F6 = False
        ctrlBtnsOperator1.F7 = True
        ctrlBtnsOperator1.F8 = True
        ctrlBtnsOperator1.F9 = True
        ctrlBtnsOperator1.F10 = True
        ctrlBtnsOperator1.F11 = False
        ctrlBtnsOperator1.F12 = True
    End Sub

    Private Sub SetBtnsOperator()
        ResetBtnsOperator()

        Select Case ScreenName
            Case enuScreenName.Model_Option_Setting
                ctrlBtnsOperator1.F1 = True
                ctrlBtnsOperator1.F2 = True
                ctrlBtnsOperator1.F3 = True
                ctrlBtnsOperator1.F6 = True
                m_strF6TextBase = ctrlBtnsOperator1.btnF6.Text
                ctrlBtnsOperator1.btnF6.Text = String.Format(ctrlBtnsOperator1.btnF6.Text, String.Empty)
            Case enuScreenName.Process_Option_Setting
                ctrlBtnsOperator1.F2 = True
        End Select
    End Sub
#End Region

#Region "Event"
    Public Event OnOperatorClick(ByVal sender As Object, ByVal e As EventArgs)

    Private Sub ctrlOptionList_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        Try
            If Me.Visible Then
                SetBtnsOperator()
                LoadHeaderName()
                LoadData()
                LoadColumnWidth(ScreenName, Me, lsvData)
            End If
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "ctrlOptionList_VisibleChanged", ex, True)
        End Try
    End Sub

    Private Sub lsvData_DrawColumnHeader(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawListViewColumnHeaderEventArgs) Handles lsvData.DrawColumnHeader
        Dim sf As New StringFormat()

        Try
            If e.Header.Width > 0 Then
                ' Store the column text alignment, letting it default
                ' to Left if it has not been set to Center or Right.
                Select Case e.Header.TextAlign
                    Case HorizontalAlignment.Center
                        sf.Alignment = StringAlignment.Center
                    Case HorizontalAlignment.Right
                        sf.Alignment = StringAlignment.Far
                End Select

                ' Force First column to alignment is center
                If e.Header.Index = 0 Then sf.Alignment = StringAlignment.Center

                ' Draw the standard header background.
                e.DrawBackground()

                ' Draw the header text.
                Dim headerFont As New Font("Courier New", 9.75)
                Try
                    e.Graphics.DrawString(e.Header.Text, headerFont, Brushes.Black, e.Bounds, sf)
                Finally
                    headerFont.Dispose()
                End Try
            End If
        Finally
            sf.Dispose()
        End Try
    End Sub

    Private Sub lsvData_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawListViewItemEventArgs) Handles lsvData.DrawItem
        Try
            If Not (e.State And ListViewItemStates.Selected) = 0 Then
                ' Draw the background for a selected item.
                Dim brush As New SolidBrush(Color.FromArgb(108, 153, 198))
                e.Graphics.FillRectangle(brush, e.Bounds)
            End If

            ' Draw the item text for views other than the Details view.
            If Not lsvData.View = View.Details Then
                e.DrawText()
            End If
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "lsvData_DrawItem", ex, True)
        End Try
    End Sub

    Private Sub lsvData_DrawSubItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawListViewSubItemEventArgs) Handles lsvData.DrawSubItem
        Dim sf As New StringFormat()
        'm_objClsLogger.Log(clsLogger.MessageType.NormalLog, Me.GetType.Name, "lsvData_DrawSubItem", "start", Nothing)
        Try
            Select Case e.ItemIndex
                Case Is < 3

                    'm_objClsLogger.Log(clsLogger.MessageType.NormalLog, Me.GetType.Name, "lsvData_DrawSubItem", "e.ItemIndex < 3", Nothing)
                    Dim ch As New ColumnHeader
                    ch.Text = e.SubItem.Text
                    ch.TextAlign = HorizontalAlignment.Left

                    Dim ch_e As DrawListViewColumnHeaderEventArgs
                    'm_objClsLogger.Log(clsLogger.MessageType.NormalLog, Me.GetType.Name, "lsvData_DrawSubItem", "DrawListViewColumnHeaderEventArgs", Nothing)

                    ch_e = New DrawListViewColumnHeaderEventArgs(e.Graphics, _
                                                                 e.Bounds, _
                                                                 e.ColumnIndex, _
                                                                 ch, _
                                                                 ListViewItemStates.Default, _
                                                                 lsvData.ForeColor, _
                                                                 lsvData.BackColor, _
                                                                 New Font("Courier New", 9.75))
                    'm_objClsLogger.Log(clsLogger.MessageType.NormalLog, Me.GetType.Name, "lsvData_DrawSubItem", "lsvData_DrawColumnHeader", Nothing)

                    lsvData_DrawColumnHeader(sender, ch_e)
                Case Else
                    'm_objClsLogger.Log(clsLogger.MessageType.NormalLog, Me.GetType.Name, "lsvData_DrawSubItem", "Not e.ItemIndex < 3", Nothing)

                    ' Store the column text alignment, letting it default
                    ' to Left if it has not been set to Center or Right.
                    sf.Alignment = StringAlignment.Near

                    Dim intX As Integer = (e.Bounds.X + Convert.ToInt32(e.Bounds.Width / 2)) - (CIRCLE_WIDTH / 2)
                    'm_objClsLogger.Log(clsLogger.MessageType.NormalLog, Me.GetType.Name, "lsvData_DrawSubItem", "Convert.ToInt32", Nothing)
                    Dim intY As Integer = e.Bounds.Y + (CIRCLE_HEIGHT / 5)
                    Dim p As Pen
                    Dim clr As Color
                    clr = IIf(e.Item.Selected, Color.White, Color.Black)
                    p = New Pen(clr)
                    p.Brush = New SolidBrush(clr)
                    'm_objClsLogger.Log(clsLogger.MessageType.NormalLog, Me.GetType.Name, "lsvData_DrawSubItem", "SolidBrush", Nothing)

                    ' Unless the item is selected, draw the standard 
                    ' background to make it stand out from the gradient.
                    'If (e.ItemState And ListViewItemStates.Selected) = 0 Then e.DrawBackground()

                    Select Case e.ColumnIndex
                        Case Is <= 1
                            ' Draw the subitem text in red to highlight it. 
                            'm_objClsLogger.Log(clsLogger.MessageType.NormalLog, Me.GetType.Name, "lsvData_DrawSubItem", "e.Graphics.DrawString Start", Nothing)
                            e.Graphics.DrawString(e.SubItem.Text, _
                                                  lsvData.Font, _
                                                  p.Brush, _
                                                  e.Bounds, _
                                                  sf)
                            'm_objClsLogger.Log(clsLogger.MessageType.NormalLog, Me.GetType.Name, "lsvData_DrawSubItem", "e.Graphics.DrawString End", Nothing)

                        Case Else
                            'm_objClsLogger.Log(clsLogger.MessageType.NormalLog, Me.GetType.Name, "lsvData_DrawSubItem", "If ellipse start", Nothing)
                            'm_objClsLogger.Log(clsLogger.MessageType.NormalLog, Me.GetType.Name, "lsvData_DrawSubItem", "e.SubItem.Text = " & e.SubItem.Text, Nothing)
                            If e.Header.Width > CIRCLE_WIDTH AndAlso e.SubItem.Text <> "" AndAlso Convert.ToInt32(e.SubItem.Text) > 0 Then

                                'm_objClsLogger.Log(clsLogger.MessageType.NormalLog, Me.GetType.Name, "lsvData_DrawSubItem", "e.Graphics.DrawEllipse Start", Nothing)
                                e.Graphics.DrawEllipse(p, _
                                                       intX, _
                                                       intY, _
                                                       CIRCLE_WIDTH, _
                                                       CIRCLE_HEIGHT)
                                'm_objClsLogger.Log(clsLogger.MessageType.NormalLog, Me.GetType.Name, "lsvData_DrawSubItem", "e.Graphics.DrawEllipse End", Nothing)

                            End If
                            'm_objClsLogger.Log(clsLogger.MessageType.NormalLog, Me.GetType.Name, "lsvData_DrawSubItem", "If ellipse end", Nothing)
                    End Select
            End Select
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "lsvData_DrawSubItem", ex, True)
        Finally
            sf.Dispose()
        End Try
    End Sub

    Private Sub lsvData_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lsvData.KeyDown
        Try
            If lsvData.Items.Count > 0 AndAlso lsvData.SelectedItems.Count > 0 Then
                If lsvData.Items(3).Selected AndAlso e.KeyCode = Keys.Up Then
                    lsvData.Cursor = Cursors.AppStarting
                ElseIf lsvData.Items(lsvData.Items.Count - 1).Selected AndAlso e.KeyCode = Keys.Down Then
                    lsvData.Cursor = Cursors.AppStarting
                End If
            End If
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "lsvData_KeyDown", ex, True)
        End Try
    End Sub

    Private Sub lsvData_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lsvData.KeyUp
        Try
            lsvData.Cursor = Cursors.Default
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "lsvData_KeyUp", ex, True)
        End Try
    End Sub

    Private Sub lsvData_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lsvData.LostFocus
        Try
            If lsvData.SelectedItems.Count > 0 Then
                m_lsvItemSelected = lsvData.SelectedItems(0)
                lsvData.SelectedItems.Clear()
            End If
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "lsvData_LostFocus", ex, True)
        End Try
    End Sub

    Private Sub lsvData_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lsvData.MouseClick
        Try
            Select Case e.Button
                Case Windows.Forms.MouseButtons.Right
                    If lsvData.Items.IndexOf(lsvData.SelectedItems(0)) > 2 Then
                        NavigateSelected(ScreenName, lsvData, m_objList)
                    Else
                        If m_lsvItemSelected IsNot Nothing Then m_lsvItemSelected.Selected = True
                    End If
                Case Else
                    If m_lsvItemSelected IsNot Nothing AndAlso lsvData.Items.IndexOf(lsvData.SelectedItems(0)) <= 2 Then
                        m_lsvItemSelected.Selected = True
                    End If

                    m_lsvItemSelected = lsvData.SelectedItems(0)
            End Select
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "lsvData_MouseClick", ex, True)
        End Try
    End Sub

    Private Sub ctrlBtnsOperator1_OnOperatorClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ctrlBtnsOperator1.OnOperatorClick
        Try
            Dim btn As Button = DirectCast(sender, Button)

            Select Case btn.Tag
                Case "F1" : Add()
                Case "F2" : lsvData_LostFocus(lsvData, e) : Edit()
                Case "F3" : Delete()
                Case "F6"
                    Select Case ScreenName
                        Case enuScreenName.Model_Option_Setting
                            btn.Text = String.Format(m_strF6TextBase, _
                                                     IIf(m_objList.IsNotNewModelCode, "REMOVE ", String.Empty))
                            m_objList.IsNotNewModelCode = Not m_objList.IsNotNewModelCode

                            If m_objList.IsNotNewModelCode Then
                                LoadData()
                                LoadColumnWidth(ScreenName, Me, lsvData)
                            Else
                                NavigateCurrent(ScreenName, lsvData, m_objList)
                            End If
                    End Select
                Case "F7" : NavigatePrevious(ScreenName, lsvData, m_objList)
                Case "F8" : NavigateNext(ScreenName, lsvData, m_objList)
                Case "F9" : NavigateCurrent(ScreenName, lsvData, m_objList)
                Case "F10" : lsvData_LostFocus(lsvData, e) : NavigateSearch()
                Case "F11", "F12" : StoreColumnWidth(ScreenName, Me, lsvData) : m_lsvItemSelected = Nothing
                Case "Ctrl+T"
                    If lsvData.SelectedItems.Count > 0 AndAlso lsvData.Items.IndexOf(lsvData.SelectedItems(0)) > 2 Then
                        NavigateSelected(ScreenName, lsvData, m_objList)
                    End If
                Case "Up" : NavigateUp(ScreenName, lsvData, m_objList)
                Case "Down" : NavigateDown(ScreenName, lsvData, m_objList)
            End Select

            RaiseEvent OnOperatorClick(btn, e)
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "ctrlBtnsOperator1_OnOperatorClick", ex, True)
        End Try
    End Sub

#End Region

End Class
