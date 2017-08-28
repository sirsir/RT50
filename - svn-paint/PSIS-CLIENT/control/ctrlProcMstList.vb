Public Class ctrlProcMstList
#Region "Constant"
    Private Const CIRCLE_WIDTH As Integer = 10
    Private Const CIRCLE_HEIGHT As Integer = 10
#End Region

#Region "Enumerator"

#End Region

#Region "Attribute"
    Private m_objList As clsModelBase
    Private m_lsvItemSelected As ListViewItem

    Private m_rowCurr As dsPAINT.dtPROCESS_MSTRow
    Private m_rowPrevs() As dsPAINT.dtPROCESS_LINKAGERow
    Private m_rowNexts() As dsPAINT.dtPROCESS_LINKAGERow

    Private m_strMsg As String

    Private m_frmMsg As New frmMsg
    Private m_objClsLogger As New clsLogger
    Private m_objClsDBLogger As New clsDBLogger
#End Region

#Region "Constructor"

#End Region

#Region "Property"
    Private ReadOnly Property dtProcessMst() As dsPAINT.dtPROCESS_MSTDataTable
        Get
            Return dsPAINT1.dtPROCESS_MST
        End Get
    End Property
#End Region

#Region "Method"

    Private Sub LoadHeaderName()
        lblHeader1.Text = ParseColumnName(ScreenName.ToString)
    End Sub

    Public Sub LoadData()
        Dim columns() As ColumnHeader = Nothing
        Dim rows() As ListViewItem = Nothing

        Select Case ScreenName
            Case enuScreenName.Process_Master
                m_objList = New clsProcessMaster
        End Select

        lsvData.Clear()
        If m_objList IsNot Nothing Then
            m_objList.LoadData("", "", clsModelBase.enuFillBy.NextGroup)

            lsvData.Columns.AddRange(m_objList.Columns)
            lsvData.Items.AddRange(m_objList.Rows)
        End If
    End Sub

    Private Sub Add()
        Dim dlg As New frmProcessMaster_AddEdit
        dlg.FormMode = frmProcessMaster_AddEdit.enuFormMode.Add

        If dlg.ShowDialog = DialogResult.OK Then
            FetchData() : NavigateTo(m_objList, dlg.ProcessType, dlg.ProcessCode, lsvData)
            m_objClsDBLogger.Log(DB_LOG_CODE_N_ADD_PROCESS_MASTER_ROW, Nothing, dlg.ProcessName)
        Else
            If m_lsvItemSelected IsNot Nothing Then m_lsvItemSelected.Selected = True : lsvData.Focus()
        End If

        m_lsvItemSelected = Nothing
    End Sub

    Private Sub Edit()
        If m_lsvItemSelected IsNot Nothing Then
            Dim dlg As New frmProcessMaster_AddEdit
            Dim objFirstRow As ListViewItem = m_lsvItemSelected

            dlg.FormMode = frmProcessMaster_AddEdit.enuFormMode.Edit
            dlg.ProcessCode = objFirstRow.SubItems(0).Text
            dlg.ProcessName = objFirstRow.SubItems(1).Text
            dlg.ProcessTime = objFirstRow.SubItems(4).Text
            dlg.ProcessGroup = Convert.ToInt32(objFirstRow.SubItems(objFirstRow.SubItems.Count - 3).Text)
            dlg.ProcessType = Convert.ToInt32(objFirstRow.SubItems(objFirstRow.SubItems.Count - 2).Text)
            dlg.ProcessNo = Convert.ToInt32(objFirstRow.SubItems(objFirstRow.SubItems.Count - 1).Text)

            If dlg.ShowDialog = DialogResult.OK Then
                NavigateTo(m_objList, dlg.ProcessType, dlg.ProcessCode, lsvData)
                m_objClsDBLogger.Log(DB_LOG_CODE_N_EDIT_PROCESS_MASTER_ROW, Nothing, dlg.ProcessName)
            Else
                m_lsvItemSelected.Selected = True
                lsvData.Focus()
            End If

            m_lsvItemSelected = Nothing
        Else
            MsgBox("Please select process name for edit process master", MsgBoxStyle.Exclamation, "Warning")
        End If
    End Sub

    Private Sub Delete()
        If m_lsvItemSelected IsNot Nothing Then
            If MsgBox("Are you sure?", MsgBoxStyle.YesNo, "Delete Confirmation") = MsgBoxResult.Yes Then
                Dim objFirstRow As ListViewItem = m_lsvItemSelected
                Dim intProcNo As Integer = Convert.ToInt32(objFirstRow.SubItems(objFirstRow.SubItems.Count - 1).Text)

                If m_rowPrevs.Length = 0 AndAlso m_rowNexts.Length = 0 Then
                    taPROCESS_MST1.Delete(intProcNo)
                    m_objClsDBLogger.Log(DB_LOG_CODE_N_DELETE_PROCESS_MASTER_ROW, Nothing, objFirstRow.SubItems(1).Text)

                    NavigateCurrent(ScreenName, lsvData, m_objList)
                Else
                    m_frmMsg.MsgType = frmMsg.enuMsgType.warning
                    m_frmMsg.SupportsCancellation = True
                    m_frmMsg.Message = DeleteMessage()

                    m_frmMsg.ShowDialog()

                    m_lsvItemSelected.Selected = True
                    lsvData.Focus()
                End If
            Else
                m_lsvItemSelected.Selected = True
                lsvData.Focus()
            End If

            m_lsvItemSelected = Nothing
        Else
            MsgBox("Please select process name for delete process master", MsgBoxStyle.Exclamation, "Warning")
        End If
    End Sub

    Private Sub EditLink()
        If m_lsvItemSelected IsNot Nothing Then
            Dim dlg As New frmProcessMaster_EditLink
            Dim objFirstRow As ListViewItem = m_lsvItemSelected

            dlg.FormMode = frmProcessMaster_EditLink.enuFormMode.Edit
            dlg.ProcessCode = objFirstRow.SubItems(0).Text
            dlg.ProcessName = objFirstRow.SubItems(1).Text
            dlg.ProcessType = Convert.ToInt32(objFirstRow.SubItems(objFirstRow.SubItems.Count - 2).Text)
            dlg.ProcessNo = Convert.ToInt32(objFirstRow.SubItems(objFirstRow.SubItems.Count - 1).Text)

            If dlg.ShowDialog = DialogResult.OK Then
                FetchData() : NavigateTo(m_objList, dlg.ProcessType, dlg.ProcessCode, lsvData)
            Else
                m_lsvItemSelected.Selected = True
                lsvData.Focus()
            End If

            m_lsvItemSelected = Nothing
        Else
            MsgBox("Please select process name for edit link process master", MsgBoxStyle.Exclamation, "Warning")
        End If
    End Sub

    Private Sub NavigateSearch()
        Dim dlg As frmProcessSearch = New frmProcessSearch

        Dim objFirstRow As ListViewItem = Nothing
        If m_lsvItemSelected IsNot Nothing Then objFirstRow = m_lsvItemSelected

        dlg.ProcessType = 0
        If objFirstRow IsNot Nothing Then dlg.ProcessName = objFirstRow.SubItems(1).Text

        If dlg.ShowDialog = DialogResult.OK Then
            NavigateTo(m_objList, dlg.ProcessType, dlg.ProcessCode, lsvData)
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
            Case enuScreenName.Process_Master
                ctrlBtnsOperator1.F1 = True
                ctrlBtnsOperator1.F2 = True
                ctrlBtnsOperator1.F3 = True
                ctrlBtnsOperator1.F4 = True
        End Select
    End Sub

    Private Function ValidateMessage() As String
        Dim strMsg As String = String.Empty
        Dim strMsgType As String = "    * '{0}' type is missing."
        Dim strMsgLink As String = "    * '{0}' does not has previous process."
        Dim strMsgPBR As String = "    * PBR type does not has 'PBR {0}' process"

        Dim blnIsPBROn As Boolean = False
        Dim blnIsPBROff As Boolean = False

        FetchData()

        ' '' Check Process Type
        For Each nProcType As dsPAINT.dtPROCESS_MSTDataTable.enuProcessType In ProcTypes
            If nProcType <> dsPAINT.dtPROCESS_MSTDataTable.enuProcessType.All _
                AndAlso nProcType <> dsPAINT.dtPROCESS_MSTDataTable.enuProcessType.Finishing Then   '<- Add to not check finishing
                Dim drs() As dsPAINT.dtPROCESS_MSTRow = dtProcessMst.Select("PROCESS_TYPE = " + Convert.ToInt32(nProcType).ToString)

                If drs.Length = 0 Then strMsg &= String.Format(strMsgType, nProcType.ToString.ToUpper) + vbCrLf
            End If
        Next

        ' '' Check All Process Link
        For Each row As dsPAINT.dtPROCESS_MSTRow In dtProcessMst.Rows
            Dim rowPrevs() As dsPAINT.dtPROCESS_LINKAGERow = _
                row.GetdtPROCESS_LINKAGERowsByFK_T_PROCESS_LINKAGE_TO_PROCESS_NO

            'If rowPrevs.Length = 0 AndAlso ProcTypes.Contains(row.PROCESS_TYPE) AndAlso _
            '    row.PROCESS_TYPE <> dsPAINT.dtPROCESS_MSTDataTable.enuProcessType.Finishing Then
            '    strMsg &= String.Format(strMsgLink, row.PROCESS_NAME) + vbCrLf
            'End If

            If rowPrevs.Length = 0 AndAlso ProcTypes.Contains(row.PROCESS_TYPE) AndAlso _
                row.PROCESS_TYPE <> dsPAINT.dtPROCESS_MSTDataTable.enuProcessType.WBS Then
                strMsg &= String.Format(strMsgLink, row.PROCESS_NAME) + vbCrLf
            End If

            ' '' Check PBR ON & OFF Status
            If Not blnIsPBROn AndAlso row.PROCESS_TYPE = dsPAINT.dtPROCESS_MSTDataTable.enuProcessType.PBR Then
                blnIsPBROn = row.ENTRANCE_FLAG
            End If

            If Not blnIsPBROff AndAlso row.PROCESS_TYPE = dsPAINT.dtPROCESS_MSTDataTable.enuProcessType.PBR Then
                For Each rowPrev As dsPAINT.dtPROCESS_LINKAGERow In rowPrevs
                    blnIsPBROff = rowPrev.dtPROCESS_MSTRowByFK_T_PROCESS_LINKAGE_FROM_PROCESS_NO.ENTRANCE_FLAG

                    If blnIsPBROff Then Exit For
                Next
            End If

            ' '' Update Entrance Flag is true 
            '' '' if childs had different type with parent but parent is false value
            For Each rowPrev As dsPAINT.dtPROCESS_LINKAGERow In rowPrevs
                Dim intPrevProcType As Integer = _
                    rowPrev.dtPROCESS_MSTRowByFK_T_PROCESS_LINKAGE_FROM_PROCESS_NO.PROCESS_TYPE

                If intPrevProcType <> row.PROCESS_TYPE Then
                    row.ENTRANCE_FLAG = True
                    taPROCESS_MST1.Update(row)

                    Exit For
                End If
            Next
        Next

        If Not blnIsPBROn Then strMsg &= String.Format(strMsgPBR, "ON") + vbCrLf
        If Not blnIsPBROff Then strMsg &= String.Format(strMsgPBR, "OFF")

        Return vbCrLf & strMsg
    End Function

    Private Sub FetchData()
        taPROCESS_MST1.Fill(dsPAINT1.dtPROCESS_MST)
        taPROCESS_LINKAGE1.Fill(dsPAINT1.dtPROCESS_LINKAGE)
    End Sub

    Private Function DeleteMessage() As String
        Dim strTextBase As String = "    * {0}" + vbCrLf

        Dim strPrevProc As String = String.Empty
        For Each rowPrev As dsPAINT.dtPROCESS_LINKAGERow In m_rowPrevs
            strPrevProc &= String.Format(strTextBase, _
                                         rowPrev.dtPROCESS_MSTRowByFK_T_PROCESS_LINKAGE_FROM_PROCESS_NO.PROCESS_NAME)
        Next

        Dim strNextProc As String = String.Empty
        For Each rowNext As dsPAINT.dtPROCESS_LINKAGERow In m_rowNexts
            strNextProc &= String.Format(strTextBase, _
                                         rowNext.dtPROCESS_MSTRowByFK_T_PROCESS_LINKAGE_TO_PROCESS_NO.PROCESS_NAME)
        Next

        Return "'" & m_rowCurr.PROCESS_NAME & "'" & " is in used by..." & vbCrLf & _
               IIf(strPrevProc.Trim.Length > 0, strPrevProc, String.Empty) & _
               IIf(strNextProc.Trim.Length > 0, strNextProc, String.Empty)
    End Function
#End Region

#Region "Event"
    Public Event OnOperatorClick(ByVal sender As Object, ByVal e As EventArgs)

    Private Sub ctrlProcMstList_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        Try
            If Me.Visible Then
                SetBtnsOperator()
                LoadHeaderName()
                LoadData()
                LoadColumnWidth(ScreenName, Me, lsvData)

                FetchData()
            End If
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "ctrlProcMstList_VisibleChanged", ex, True)
        End Try
    End Sub

    Private Sub lsvData_DrawColumnHeader(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawListViewColumnHeaderEventArgs) Handles lsvData.DrawColumnHeader
        Dim sf As New StringFormat()

        Try
            If e.Header.Width > 0 Then
                sf.Alignment = StringAlignment.Center

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

        Try
            ' Store the column text alignment, letting it default
            ' to Left if it has not been set to Center or Right.
            sf.Alignment = StringAlignment.Near

            Dim intX As Integer = (e.Bounds.X + Convert.ToInt32(e.Bounds.Width / 2)) - (CIRCLE_WIDTH / 2)
            Dim intY As Integer = e.Bounds.Y + (CIRCLE_HEIGHT / 5)
            Dim p As Pen
            Dim clr As Color
            clr = IIf(e.Item.Selected, Color.White, Color.Black)
            p = New Pen(clr)
            p.Brush = New SolidBrush(clr)

            ' Unless the item is selected, draw the standard 
            ' background to make it stand out from the gradient.
            'If (e.ItemState And ListViewItemStates.Selected) = 0 Then e.DrawBackground()

            Select Case e.ColumnIndex
                Case Is = lsvData.Columns.Count - 1
                    If e.Header.Width > CIRCLE_WIDTH AndAlso Convert.ToInt32(e.SubItem.Text) > 0 Then
                        e.Graphics.DrawEllipse(p, _
                                               intX, _
                                               intY, _
                                               CIRCLE_WIDTH, _
                                               CIRCLE_HEIGHT)
                    End If
                Case Else
                    ' Draw the subitem text in red to highlight it. 
                    e.Graphics.DrawString(e.SubItem.Text, _
                                          lsvData.Font, _
                                          p.Brush, _
                                          e.Bounds, _
                                          sf)
            End Select
        Finally
            sf.Dispose()
        End Try
    End Sub

    Private Sub lsvData_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles lsvData.ItemSelectionChanged
        Try
            Dim intProcNo As Integer = Convert.ToInt32(e.Item.SubItems(e.Item.SubItems.Count - 1).Text)

            m_rowCurr = dtProcessMst.FindByPROCESS_NO(intProcNo)
            m_rowPrevs = m_rowCurr.GetdtPROCESS_LINKAGERowsByFK_T_PROCESS_LINKAGE_TO_PROCESS_NO

            Dim strTextBase As String = "{0}{1}" + vbCrLf
            Dim strPrevProc As String = String.Empty

            For Each rowPrev As dsPAINT.dtPROCESS_LINKAGERow In m_rowPrevs
                strPrevProc &= String.Format(strTextBase, _
                                             "{0}", _
                                             rowPrev.dtPROCESS_MSTRowByFK_T_PROCESS_LINKAGE_FROM_PROCESS_NO.PROCESS_NAME)
            Next

            m_rowNexts = m_rowCurr.GetdtPROCESS_LINKAGERowsByFK_T_PROCESS_LINKAGE_FROM_PROCESS_NO

            txtPrevProc.Text = String.Format(strPrevProc, String.Empty)
            txtCurrProc.Text = m_rowCurr.PROCESS_NAME

            ' ''Diable Show Next Process
            '' ''txtNextProc.Text = strNextProc
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "lsvData_ItemSelectionChanged", ex, True)
        End Try
    End Sub

    Private Sub lsvData_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lsvData.KeyDown
        Try
            If lsvData.Items.Count > 0 AndAlso lsvData.SelectedItems.Count > 0 Then
                If lsvData.Items(0).Selected AndAlso e.KeyCode = Keys.Up Then
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
                Case Windows.Forms.MouseButtons.Right : NavigateSelected(ScreenName, lsvData, m_objList)
            End Select
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "lsvData_MouseClick", ex, True)
        End Try
    End Sub

    Private Sub ctrlBtnsOperator1_OnOperatorClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ctrlBtnsOperator1.OnOperatorClick
        Try
            Dim btn As Button = DirectCast(sender, Button)

            Dim nResult As DialogResult = DialogResult.Yes
            Select Case btn.Tag
                Case "F1" : Add()
                Case "F2" : lsvData_LostFocus(lsvData, e) : Edit()
                Case "F3" : Delete()
                Case "F4" : EditLink()
                Case "F7" : NavigatePrevious(ScreenName, lsvData, m_objList)
                Case "F8" : NavigateNext(ScreenName, lsvData, m_objList)
                Case "F9" : NavigateCurrent(ScreenName, lsvData, m_objList)
                Case "F10" : lsvData_LostFocus(lsvData, e) : NavigateSearch()
                Case "F11", "F12"
                    Dim strValidMsg As String = ValidateMessage()

                    If strValidMsg.Trim.Length > 0 Then
                        m_frmMsg.MsgType = frmMsg.enuMsgType.warning
                        m_frmMsg.SupportsConfirmation = True
                        m_frmMsg.Message = ValidateMessage()

                        nResult = m_frmMsg.ShowDialog()
                    End If

                    If nResult = DialogResult.Yes Then
                        StoreColumnWidth(ScreenName, Me, lsvData) : m_lsvItemSelected = Nothing
                    End If
                Case "Ctrl+T" : NavigateSelected(ScreenName, lsvData, m_objList)
                Case "Up" : NavigateUp(ScreenName, lsvData, m_objList)
                Case "Down" : NavigateDown(ScreenName, lsvData, m_objList)
            End Select

            If nResult = MsgBoxResult.Yes Then RaiseEvent OnOperatorClick(btn, e)
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "ctrlBtnsOperator1_OnOperatorClick", ex, True)
        End Try
    End Sub

#End Region

End Class
