Public Class ctrlList
#Region "Constant"

#End Region

#Region "Enumerator"
    'Public Enum enuScreenName
    '    None
    '    Instruction_Data
    '    WBS_Pass_Result
    '    Paint_Pass_Result
    '    PBR_Pass_Result
    '    Parameter_Setting
    '    Finishing_Line
    '    Paint_Shop
    '    Paint_Progress
    'End Enum
#End Region

#Region "Attribute"
    Private m_enuScreenName As enuScreenName
    Private m_objList As clsModelBase
    Private m_lblProc As Label
    Private m_objClsLogger As New clsLogger
    Private m_objClsDBLogger As New clsDBLogger
#End Region

#Region "Constructor"

#End Region

#Region "Property"

#End Region

#Region "Method"
    Private Sub LoadHeaderName()
        Select Case ScreenName
            Case enuScreenName.Process_Group_Result
                Dim dtProcGrp As dsPAINT.dtPROCESS_GROUP_MSTDataTable = New dsPAINT.dtPROCESS_GROUP_MSTDataTable
                Dim taProcGrp As dsPAINTTableAdapters.taPROCESS_GROUP_MST = New dsPAINTTableAdapters.taPROCESS_GROUP_MST
                taProcGrp.Fill(dtProcGrp)
                lblHeader1.Text = dtProcGrp.FindByPROCESS_GROUP_ID(Convert.ToInt32(m_lblProc.Name.Replace("lblCtrlGroup", ""))).PROCESS_GROUP_NAME
            Case enuScreenName.Paint_Progress_Result
                Dim dtProc_MST As dsPAINT.dtPROCESS_MSTDataTable = New dsPAINT.dtPROCESS_MSTDataTable
                Dim taProc_MST As taPROCESS_MST = New taPROCESS_MST
                taProc_MST.Fill(dtProc_MST)
                lblHeader1.Text = dtProc_MST.FindByPROCESS_NO(Convert.ToInt32(m_lblProc.Name.Replace("lblProcCount", ""))).PROCESS_NAME
            Case Else
                lblHeader1.Text = ParseColumnName(ScreenName.ToString)
        End Select

    End Sub

    Private Sub LoadData()
        Dim columns() As ColumnHeader = Nothing
        Dim rows() As ListViewItem = Nothing

        Select Case ScreenName
            Case enuScreenName.Instruction_Data
                m_objList = New clsInstructionData
            Case enuScreenName.WBS_Pass_Result
                m_objList = New clsWBSPassResult
            Case enuScreenName.Paint_Pass_Result
                m_objList = New clsPaintPassResult
            Case enuScreenName.PBR_Pass_Result
                m_objList = New clsPBRPassResult
            Case enuScreenName.Finishing_Line
                m_objList = New clsFinishingLine
            Case enuScreenName.Paint_Shop
                m_objList = New clsPaintShop
            Case enuScreenName.Paint_Progress_Result, enuScreenName.Process_Group_Result
                m_objList = New clsPaintProgress(m_lblProc)
            Case enuScreenName.Option_Master
                m_objList = New clsOptionMasterSetting
            Case enuScreenName.PLC_Master
                m_objList = New clsPLC_MST_Setting
            Case Else
                m_objList = Nothing
        End Select

        lsvData.Clear()
        If m_objList IsNot Nothing Then
            m_objList.LoadData("", "", clsModelBase.enuFillBy.NextGroup)

            lsvData.Columns.AddRange(m_objList.Columns)
            lsvData.Items.AddRange(m_objList.Rows)
        End If
    End Sub

    Private Sub ResetBtnsOperator()
        ctrlBtnsOperator1.F1 = False
        ctrlBtnsOperator1.F2 = False
        ctrlBtnsOperator1.F3 = False
        ctrlBtnsOperator1.F4 = False
        ctrlBtnsOperator1.F5 = False
        ctrlBtnsOperator1.F6 = False
        ctrlBtnsOperator1.F7 = False
        ctrlBtnsOperator1.F8 = False
        ctrlBtnsOperator1.F9 = False
        ctrlBtnsOperator1.F10 = False
        ctrlBtnsOperator1.F11 = False
        ctrlBtnsOperator1.F12 = True
    End Sub

    Private Sub SetBtnsOperator()
        ResetBtnsOperator()

        Select Case ScreenName
            Case enuScreenName.Option_Master, enuScreenName.PLC_Master
                ctrlBtnsOperator1.F1 = True
                ctrlBtnsOperator1.F2 = True
                ctrlBtnsOperator1.F3 = True
                ctrlBtnsOperator1.F7 = True
                ctrlBtnsOperator1.F8 = True
                ctrlBtnsOperator1.F9 = True
                ctrlBtnsOperator1.F10 = True
            Case enuScreenName.Instruction_Data
                'ctrlBtnsOperator1.F2 = True
                'ctrlBtnsOperator1.F7 = True
                'ctrlBtnsOperator1.F8 = True
                'ctrlBtnsOperator1.F9 = True
                'ctrlBtnsOperator1.F10 = True

                ctrlBtnsOperator1.F1 = True
                ctrlBtnsOperator1.F2 = True
                ctrlBtnsOperator1.F3 = True
                ctrlBtnsOperator1.F4 = True
                ctrlBtnsOperator1.btnF4.Text = "F4: PROCESS EDIT"
                ctrlBtnsOperator1.F7 = True
                ctrlBtnsOperator1.F8 = True
                ctrlBtnsOperator1.F9 = True
                ctrlBtnsOperator1.F10 = True
            Case enuScreenName.WBS_Pass_Result, _
            enuScreenName.Paint_Pass_Result, enuScreenName.PBR_Pass_Result
                ctrlBtnsOperator1.F7 = True
                ctrlBtnsOperator1.F8 = True
                ctrlBtnsOperator1.F9 = True
                ctrlBtnsOperator1.F10 = True
            Case enuScreenName.Finishing_Line, enuScreenName.Paint_Shop, enuScreenName.Paint, _
            enuScreenName.Paint_Progress_Result, enuScreenName.Process_Group_Result
                ctrlBtnsOperator1.F11 = True
                ctrlBtnsOperator1.F12 = False
        End Select
    End Sub

    Private Sub NavigateSearch()
        Dim dlg As Object = Nothing
        Dim blnDialogResult As Boolean = True
        Dim objFirstRow As ListViewItem = Nothing

        If lsvData.SelectedItems.Count > 0 Then objFirstRow = lsvData.SelectedItems(0)

        Select Case ScreenName
            Case enuScreenName.PLC_Master
                dlg = New frmProcessSearch
                dlg.ProcessType = 0

                If objFirstRow IsNot Nothing Then
                    dlg.ProcessName = objFirstRow.SubItems(8).Text
                End If

                blnDialogResult = (dlg.ShowDialog = DialogResult.OK)
            Case enuScreenName.Option_Master
                dlg = New frmOptionMST_Setting_Search

                blnDialogResult = (dlg.ShowDialog = DialogResult.OK)
            Case Else
                dlg = New frmSearch

                If objFirstRow IsNot Nothing Then
                    dlg.ModelCode = objFirstRow.SubItems(4).Text
                    dlg.LotNo = objFirstRow.SubItems(5).Text
                    dlg.UnitNo = objFirstRow.SubItems(6).Text
                End If

                blnDialogResult = (dlg.ShowDialog = DialogResult.OK)
        End Select

        Dim strParam1 As String = String.Empty
        Dim strParam2 As String = String.Empty

        Select Case ScreenName
            Case enuScreenName.PLC_Master
                strParam1 = dlg.StageCode
                strParam2 = dlg.PlcId
            Case enuScreenName.Option_Master
                strParam1 = dlg.OptionType
                strParam2 = dlg.OptionSeq
            Case enuScreenName.PBR_Pass_Result
                strParam1 = dlg.SelectedProductionDate + "," + dlg.SelectedOnTime
                strParam2 = dlg.BlockModel + "," + dlg.BlockSeq + "," + IIf(dlg.BlockModel <> "", "0", "1")
            Case Else
                strParam1 = dlg.SelectedProductionDate
                strParam2 = dlg.SelectedOnTime
        End Select

        If blnDialogResult Then
            NavigateTo(m_objList, strParam1, strParam2, lsvData)
        Else
            lsvData.Focus()
        End If
    End Sub

    Private Sub Add()
        Dim dlg As Object = Nothing
        Dim blnDialogResult As Boolean = True

        Select Case ScreenName
            Case enuScreenName.Option_Master
                dlg = New frmOptionMST_Setting_AddEdit
                dlg.FormMode = frmOptionMST_Setting_AddEdit.enuFormMode.Add

                blnDialogResult = (dlg.ShowDialog = DialogResult.OK)
            Case enuScreenName.PLC_Master
                dlg = New frmPLC_MST_Setting_AddEdit
                dlg.FormMode = frmPLC_MST_Setting_AddEdit.enuFormMode.Add

                blnDialogResult = (dlg.ShowDialog = DialogResult.OK)
            Case enuScreenName.Instruction_Data
                dlg = New frmInstructionData_AddEdit
                dlg.FormMode = frmInstructionData_AddEdit.enuFormMode.Add

                blnDialogResult = (dlg.ShowDialog = DialogResult.OK)
        End Select

        Dim strParam1 As String = String.Empty
        Dim strParam2 As String = String.Empty

        Select Case ScreenName
            Case enuScreenName.Instruction_Data
                strParam1 = dlg.ProductionDate
                strParam2 = dlg.OnTime
            Case enuScreenName.Option_Master
                strParam1 = dlg.OptionType
                strParam2 = dlg.OptionSeq
            Case enuScreenName.PLC_Master
                strParam1 = dlg.StageCode
                strParam2 = dlg.PlcId
        End Select

        If blnDialogResult Then
            Select Case ScreenName
                Case enuScreenName.Instruction_Data
                    m_objClsDBLogger.Log(DB_LOG_CODE_N_ADD_INSTRUCTION_DATA_ROW, Nothing, dlg.ModelYear & dlg.SuffixCode, dlg.LotNo, dlg.Unit)
                Case enuScreenName.Option_Master
                    m_objClsDBLogger.Log(DB_LOG_CODE_N_ADD_OPTION_MST_ROW, Nothing, dlg.OptionDisplay)
                Case enuScreenName.PLC_Master
                    m_objClsDBLogger.Log(DB_LOG_CODE_N_ADD_PLC_MST_ROW, Nothing, Convert.ToInt32(dlg.StageCode))
            End Select
            NavigateTo(m_objList, strParam1, strParam2, lsvData)
        Else
            If lsvData.SelectedItems.Count > 0 Then lsvData.Focus()
        End If
    End Sub

    Private Sub Edit()
        If lsvData.SelectedItems.Count > 0 Then
            Dim dlg As Object = Nothing
            Dim blnDialogResult As Boolean = True
            Dim objFirstRow As ListViewItem = lsvData.SelectedItems(0)

            Select Case ScreenName
                Case enuScreenName.Instruction_Data
                    dlg = New frmInstructionData_AddEdit
                    dlg.FormMode = frmInstructionData_AddEdit.enuFormMode.Edit

                    dlg.ProductionDate = objFirstRow.SubItems(0).Text
                    dlg.OnTime = objFirstRow.SubItems(1).Text
                    dlg.ModelYear = objFirstRow.SubItems(4).Text.Substring(0, 3)
                    dlg.SuffixCode = objFirstRow.SubItems(4).Text.Substring(3, 5)
                    dlg.LotNo = objFirstRow.SubItems(5).Text
                    dlg.Unit = objFirstRow.SubItems(6).Text

                    blnDialogResult = (dlg.ShowDialog = DialogResult.OK)

                Case enuScreenName.Option_Master
                    dlg = New frmOptionMST_Setting_AddEdit
                    dlg.FormMode = frmOptionMST_Setting_AddEdit.enuFormMode.Edit

                    dlg.OptionDisplay = objFirstRow.SubItems(3).Text
                    dlg.OptionType = Convert.ToInt32(objFirstRow.SubItems(objFirstRow.SubItems.Count - 2).Text)
                    dlg.OptionId = Convert.ToInt32(objFirstRow.SubItems(objFirstRow.SubItems.Count - 1).Text)

                    blnDialogResult = (dlg.ShowDialog = DialogResult.OK)
                Case enuScreenName.PLC_Master
                    dlg = New frmPLC_MST_Setting_AddEdit
                    dlg.FormMode = frmPLC_MST_Setting_AddEdit.enuFormMode.Edit

                    dlg.StageCode = Convert.ToInt32(objFirstRow.SubItems(0).Text)
                    dlg.PlcId = Convert.ToInt32(objFirstRow.SubItems(objFirstRow.SubItems.Count - 1).Text)

                    blnDialogResult = (dlg.ShowDialog = DialogResult.OK)
            End Select

            Dim strParam1 As String = String.Empty
            Dim strParam2 As String = String.Empty

            Select Case ScreenName
                Case enuScreenName.Instruction_Data
                    strParam1 = dlg.ProductionDate
                    strParam2 = dlg.OnTime
                Case enuScreenName.Option_Master
                    strParam1 = dlg.OptionType
                    strParam2 = dlg.OptionSeq
                Case enuScreenName.PLC_Master
                    strParam1 = dlg.StageCode
                    strParam2 = dlg.PlcId
            End Select

            If blnDialogResult Then
                Select Case ScreenName
                    Case enuScreenName.Instruction_Data
                        m_objClsDBLogger.Log(DB_LOG_CODE_N_EDIT_INSTRUCTION_DATA_ROW, Nothing, dlg.ModelYear & dlg.SuffixCode, dlg.LotNo, dlg.Unit)
                    Case enuScreenName.Option_Master
                        m_objClsDBLogger.Log(DB_LOG_CODE_N_EDIT_OPTION_MST_ROW, Nothing, dlg.OptionDisplay)
                    Case enuScreenName.PLC_Master
                        m_objClsDBLogger.Log(DB_LOG_CODE_N_EDIT_PLC_MST_ROW, Nothing, Convert.ToInt32(dlg.StageCode))
                End Select
                NavigateTo(m_objList, strParam1, strParam2, lsvData)
            Else
                lsvData.Focus()
            End If
        Else
            MsgBox("Please select " + lblHeader1.Text + " for edit " + lblHeader1.Text, MsgBoxStyle.Exclamation, "Warning")
        End If
    End Sub

    Private Sub Delete()
        If lsvData.SelectedItems.Count > 0 Then
            If MsgBox("Are you sure?", MsgBoxStyle.YesNo, "Delete Confirmation") = MsgBoxResult.Yes Then
                Dim objFirstRow As ListViewItem = lsvData.SelectedItems(0)

                Select Case ScreenName
                    Case enuScreenName.Instruction_Data
                        Dim ta As New taPRODUCTION_DAT

                        Dim strModelYear As String = objFirstRow.SubItems(4).Text.Substring(0, 3)
                        Dim strSuffixCode As String = objFirstRow.SubItems(4).Text.Substring(3, 5)
                        Dim strLotNo As String = objFirstRow.SubItems(5).Text
                        Dim strUnit As String = objFirstRow.SubItems(6).Text

                        ta.DeleteByPk(strModelYear, strSuffixCode, strLotNo, strUnit)
                        m_objClsDBLogger.Log(DB_LOG_CODE_N_DELETE_INSTRUCTION_DATA_ROW, Nothing, strModelYear & strSuffixCode, strLotNo, strUnit)

                    Case enuScreenName.Option_Master
                        Dim ta As New taOPTION_MST

                        Dim intOptId As Integer = _
                            Convert.ToInt32(objFirstRow.SubItems(objFirstRow.SubItems.Count - 1).Text)

                        ta.Delete(intOptId)
                        m_objClsDBLogger.Log(DB_LOG_CODE_N_DELETE_OPTION_MST_ROW, Nothing, objFirstRow.SubItems(3).Text)

                    Case enuScreenName.PLC_Master
                        Dim ta As New taPLC_MST

                        Dim intPlcId As Integer = _
                            Convert.ToInt32(objFirstRow.SubItems(objFirstRow.SubItems.Count - 1).Text)
                        Dim intStageCode As Integer = Convert.ToInt32(objFirstRow.SubItems(0).Text)

                        ta.Delete(intPlcId)
                        m_objClsDBLogger.Log(DB_LOG_CODE_N_DELETE_PLC_MST_ROW, Nothing, Convert.ToInt32(objFirstRow.SubItems(0).Text))

                End Select

                NavigateCurrent(ScreenName, lsvData, m_objList)
            Else
                lsvData.Focus()
            End If
        Else
            MsgBox("Please select " + lblHeader1.Text + " for delete " + lblHeader1.Text, MsgBoxStyle.Exclamation, "Warning")
        End If
    End Sub

    Private Sub EditProcess()
        If lsvData.SelectedItems.Count > 0 Then
            Dim dlg As Object = Nothing
            Dim blnDialogResult As Boolean = True
            Dim objFirstRow As ListViewItem = lsvData.SelectedItems(0)

            Select Case ScreenName
                Case enuScreenName.Instruction_Data
                    dlg = New frmProductionTracking_AddEdit
                    dlg.FormMode = frmProductionTracking_AddEdit.enuFormMode.Edit

                    dlg.ProductionDate = objFirstRow.SubItems(0).Text
                    dlg.OnTime = objFirstRow.SubItems(1).Text
                    dlg.ModelYear = objFirstRow.SubItems(4).Text.Substring(0, 3)
                    dlg.SuffixCode = objFirstRow.SubItems(4).Text.Substring(3, 5)
                    dlg.LotNo = objFirstRow.SubItems(5).Text
                    dlg.Unit = objFirstRow.SubItems(6).Text

                    blnDialogResult = (dlg.ShowDialog = DialogResult.OK)
            End Select

            Dim strParam1 As String = String.Empty
            Dim strParam2 As String = String.Empty

            Select Case ScreenName
                Case enuScreenName.Instruction_Data
                    strParam1 = dlg.ProductionDate
                    strParam2 = dlg.OnTime
            End Select

            If blnDialogResult Then
                Select Case ScreenName
                    Case enuScreenName.Instruction_Data
                        Dim sufStr As String = IIf(dlg.CurrentProcess = "WBS", dlg.CurrentProcess + ", LaneNo = " + dlg.LaneNo, dlg.CurrentProcess)
                        m_objClsDBLogger.Log(DB_LOG_CODE_N_EDIT_PROCESS_INSTRUCTION_DATA_ROW, Nothing, dlg.skitno.ToString, sufStr)
                End Select
                NavigateTo(m_objList, strParam1, strParam2, lsvData)
            Else
                lsvData.Focus()
            End If
        Else
            MsgBox("Please select " + lblHeader1.Text + " for edit " + lblHeader1.Text, MsgBoxStyle.Exclamation, "Warning")
        End If
    End Sub

    Public Sub SetProcessLabel(ByVal lblProcess As Label)
        m_lblProc = lblProcess
    End Sub
#End Region

#Region "Event"
    Public Event OnOperatorClick(ByVal sender As Object, ByVal e As EventArgs)

    Private Sub CtrlBtnsOperator1_OnOperatorClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ctrlBtnsOperator1.OnOperatorClick
        Try
            Dim btn As Button = DirectCast(sender, Button)

            Select Case btn.Tag
                Case "F1" : Add()
                Case "F2" : Edit()
                Case "F3" : Delete()
                Case "F4" : EditProcess()
                Case "F7" : NavigatePrevious(ScreenName, lsvData, m_objList)
                Case "F8" : NavigateNext(ScreenName, lsvData, m_objList)
                Case "F9" : NavigateCurrent(ScreenName, lsvData, m_objList)
                Case "F10" : NavigateSearch()
                Case "F11", "F12" : StoreColumnWidth(ScreenName, Me, lsvData)
                Case "Ctrl+T" : NavigateSelected(ScreenName, lsvData, m_objList)
                Case "Up" : NavigateUp(ScreenName, lsvData, m_objList)
                Case "Down" : NavigateDown(ScreenName, lsvData, m_objList)
            End Select

            RaiseEvent OnOperatorClick(btn, e)
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "CtrlBtnsOperator1_OnOperatorClick", ex, True)
        End Try
    End Sub

    Private Sub ctrlList_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        Try
            If Me.Visible Then
                SetBtnsOperator()
                LoadHeaderName()
                LoadData()
                LoadColumnWidth(ScreenName, Me, lsvData)
            End If
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "ctrlList_VisibleChanged", ex, True)
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

    Private Sub lsvData_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lsvData.MouseClick
        Try
            Select Case e.Button
                Case Windows.Forms.MouseButtons.Right : NavigateSelected(ScreenName, lsvData, m_objList)
            End Select
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "lsvData_MouseClick", ex, True)
        End Try
    End Sub

#End Region
End Class
