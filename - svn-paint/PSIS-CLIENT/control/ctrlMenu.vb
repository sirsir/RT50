Public Class ctrlMenu
#Region "Constant"
    Private Const SCREEN_BUTTON_TAG As String = _
    "F1,F2_1,F2_2,F2_3,F3_1,F3_2,F3_3,F4_1,F4_2,F4_3,F5,F6,F11,F12"
#End Region

#Region "Attribute"
    Private m_strScreenBtnsTag() As String
    Private m_ctrls As New List(Of Control)
    Private m_objClsLogger As New clsLogger
#End Region

#Region "Constructor"
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_strScreenBtnsTag = SCREEN_BUTTON_TAG.Split(",")

        Dim pnls() As Control = {flp1, pnlF2, pnlF3, pnlF4}

        For Each pnl As Control In pnls
            For Each ctrl As Control In pnl.Controls
                m_ctrls.Add(ctrl)
            Next
        Next

        m_ctrls.Add(btnF12)
        m_ctrls.Add(btnF11_1)
    End Sub
#End Region

#Region "Property"

#End Region

#Region "Method"
    Public Sub RegisterKeyPreview(ByVal frm As Windows.Forms.Form)
        AddHandler frm.KeyUp, AddressOf m_ctrlOwner_KeyUp
    End Sub

    Private Sub ShowSubMenu(ByVal ctrl As Control)
        pnlF2.Visible = (pnlF2.Tag = ctrl.Tag)
        pnlF3.Visible = (pnlF3.Tag = ctrl.Tag)
        pnlF4.Visible = (pnlF4.Tag = ctrl.Tag)
        btnF11_1.Visible = (pnlF2.Tag = ctrl.Tag) Or (pnlF3.Tag = ctrl.Tag) Or (pnlF4.Tag = ctrl.Tag)

        Dim pnl As Panel
        Select Case ctrl.Tag
            Case pnlF2.Tag
                pnl = pnlF2
            Case pnlF3.Tag
                pnl = pnlF3
            Case pnlF4.Tag
                pnl = pnlF4
            Case Else
                For Each tmpCtrl As Control In m_ctrls
                    If tmpCtrl.Parent Is pnlF2 Or tmpCtrl.Parent Is pnlF3 Or tmpCtrl.Parent Is pnlF4 Then
                        tmpCtrl.Enabled = False
                    End If
                Next

                pnl = Nothing
        End Select

        Dim btn As Button
        If pnl IsNot Nothing Then
            For Each pnlCtrl As Control In pnl.Controls
                btn = DirectCast(pnlCtrl, Button)
                btn.Enabled = pnl.Visible
            Next
        End If

        For Each flpCtrl As Control In flp1.Controls
            btn = DirectCast(flpCtrl, Button)
            btn.Enabled = Not btnF11_1.Visible
            btn.BackColor = IIf(flpCtrl Is ctrl, SystemColors.ButtonHighlight, SystemColors.Control)
            btn.UseVisualStyleBackColor = btn.Enabled
        Next
    End Sub
#End Region

#Region "Event"
    Public Event OnBtnClick(ByVal sender As Object, ByVal e As EventArgs)

    Private Sub m_ctrlOwner_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            If Me.Visible Then
                Dim strCtrlKeyCode As String

                For Each ctrl As Control In m_ctrls
                    strCtrlKeyCode = ctrl.Text.Split(":")(0).Trim

                    If strCtrlKeyCode = e.KeyCode.ToString AndAlso ctrl.Enabled Then
                        If m_strScreenBtnsTag.Contains(ctrl.Tag) Then
                            btnScreen_Click(ctrl, Nothing) : Exit For
                        Else
                            ShowSubMenu(ctrl) : Exit For
                        End If
                    End If
                Next ctrl
            End If
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "m_ctrlOwner_KeyUp", ex, True)
        End Try
    End Sub

    Private Sub btnScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
        btnF1.Click, btnF2_1.Click, btnF2_2.Click, btnF2_3.Click, _
        btnF3_1.Click, btnF3_2.Click, btnF3_3.Click, btnF4_1.Click, btnF4_2.Click, _
        btnF4_3.Click, btnF5.Click, btnF6.Click, btnF11.Click, btnF12.Click

        Try
            Dim btn As Button = DirectCast(sender, Button)

            Select Case btn.Tag
                Case "F1"
                    ScreenName = enuScreenName.Instruction_Data
                Case "F2_1"
                    ScreenName = enuScreenName.WBS
                Case "F2_2"
                    ScreenName = enuScreenName.WBS_Monitoring
                Case "F2_3"
                    ScreenName = enuScreenName.Paint
                Case "F3_1"
                    ScreenName = enuScreenName.WBS_Pass_Result
                Case "F3_2"
                    ScreenName = enuScreenName.Paint_Pass_Result
                Case "F3_3"
                    ScreenName = enuScreenName.PBR_Pass_Result
                Case "F4_1"
                    ScreenName = enuScreenName.Option_Master
                Case "F4_2"
                    ScreenName = enuScreenName.PLC_Master
                Case "F4_3"
                    ScreenName = enuScreenName.Process_Master
                Case "F5"
                    ScreenName = enuScreenName.Model_Option_Setting
                Case "F6"
                    ScreenName = enuScreenName.Process_Option_Setting
                Case "F11"
                    ScreenName = enuScreenName.Data_Log
            End Select

            RaiseEvent OnBtnClick(btn, e)
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "btnScreen_Click", ex, True)
        End Try
    End Sub

    Private Sub btnSub_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
        btnF11_1.Click, btnF2.Click, btnF3.Click, btnF4.Click
        Try
            Dim ctrl As Control = DirectCast(sender, Control)

            ShowSubMenu(ctrl)
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "btnSub_Click", ex, True)
        End Try
    End Sub
#End Region
End Class
