Public Class ctrlBtnsOperator

#Region "Constant"
    Const BTN_F1_TEXT As String = "F1: ADD"
    Const BTN_F2_TEXT As String = "F2: EDIT"
    Const BTN_F3_TEXT As String = "F3: DELETE"
    Const BTN_F4_TEXT As String = "F4: PROCESS LINK"
    Const BTN_F5_TEXT As String = "F5: SAVE"
    Const BTN_F6_TEXT As String = "F6: {0}FILTER"
    Const BTN_F7_TEXT As String = "F7: PREVIOUS"
    Const BTN_F8_TEXT As String = "F8: NEXT"
    Const BTN_F9_TEXT As String = "F9: RELOAD"
    Const BTN_F10_TEXT As String = "F10: SEARCH"
    Const BTN_F11_TEXT As String = "F11: BACK"
    Const BTN_F12_TEXT As String = "F12: MAIN MENU"
#End Region

#Region "Enumerator"

#End Region

#Region "Attribute"
    Private m_objClsLogger As New clsLogger
#End Region

#Region "Constructor"

#End Region

#Region "Property"
    Public Property F1() As Boolean
        Get
            Return IsBtnUsed(btnF1)
        End Get
        Set(ByVal value As Boolean)
            SetBtnText(btnF1, value, BTN_F1_TEXT)
        End Set
    End Property

    Public Property F2() As Boolean
        Get
            Return IsBtnUsed(btnF2)
        End Get
        Set(ByVal value As Boolean)
            SetBtnText(btnF2, value, BTN_F2_TEXT)
        End Set
    End Property

    Public Property F3() As Boolean
        Get
            Return IsBtnUsed(btnF3)
        End Get
        Set(ByVal value As Boolean)
            SetBtnText(btnF3, value, BTN_F3_TEXT)
        End Set
    End Property

    Public Property F4() As Boolean
        Get
            Return IsBtnUsed(btnF4)
        End Get
        Set(ByVal value As Boolean)
            SetBtnText(btnF4, value, BTN_F4_TEXT)
        End Set
    End Property

    Public Property F5() As Boolean
        Get
            Return IsBtnUsed(btnF5)
        End Get
        Set(ByVal value As Boolean)
            SetBtnText(btnF5, value, BTN_F5_TEXT)
        End Set
    End Property

    Public Property F6() As Boolean
        Get
            Return IsBtnUsed(btnF6)
        End Get
        Set(ByVal value As Boolean)
            SetBtnText(btnF6, value, BTN_F6_TEXT)
        End Set
    End Property

    Public Property F7() As Boolean
        Get
            Return IsBtnUsed(btnF7)
        End Get
        Set(ByVal value As Boolean)
            SetBtnText(btnF7, value, BTN_F7_TEXT)
        End Set
    End Property

    Public Property F8() As Boolean
        Get
            Return IsBtnUsed(btnF8)
        End Get
        Set(ByVal value As Boolean)
            SetBtnText(btnF8, value, BTN_F8_TEXT)
        End Set
    End Property

    Public Property F9() As Boolean
        Get
            Return IsBtnUsed(btnF9)
        End Get
        Set(ByVal value As Boolean)
            SetBtnText(btnF9, value, BTN_F9_TEXT)
        End Set
    End Property

    Public Property F10() As Boolean
        Get
            Return IsBtnUsed(btnF10)
        End Get
        Set(ByVal value As Boolean)
            SetBtnText(btnF10, value, BTN_F10_TEXT)
        End Set
    End Property

    Public Property F11() As Boolean
        Get
            Return IsBtnUsed(btnF11)
        End Get
        Set(ByVal value As Boolean)
            SetBtnText(btnF11, value, BTN_F11_TEXT)
        End Set
    End Property

    Public Property F12() As Boolean
        Get
            Return IsBtnUsed(btnF12)
        End Get
        Set(ByVal value As Boolean)
            SetBtnText(btnF12, value, BTN_F12_TEXT)
        End Set
    End Property

#End Region

#Region "Method"
    Private Function IsBtnUsed(ByVal btn As Button)
        If btn.Text Like "BTN_F*_TEXT" Then SetBtnText(btn, False, btn.Tag)
        Return btn.Text.Last <> ":" OrElse btn Is btnManual
    End Function

    Private Sub SetBtnText(ByVal btn As Button, ByVal value As Boolean, ByVal strText As String)
        btn.Tag = strText.Split(":").First
        btn.Text = String.Format("{0}:{1}", btn.Tag, IIf(value, strText.Split(":").Last, String.Empty))
    End Sub

    Public Sub RegisterKeyPreview(ByVal frm As Windows.Forms.Form)
        AddHandler frm.KeyUp, AddressOf m_ctrlOwner_KeyUp
    End Sub

    Public Sub DisableKeyPreview(ByVal frm As Windows.Forms.Form)
        RemoveHandler frm.KeyUp, AddressOf m_ctrlOwner_KeyUp
    End Sub
#End Region

#Region "Event"
    Public Event OnOperatorClick(ByVal sender As Object, ByVal e As EventArgs)

    Private Sub btn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
            btnF1.Click, btnF2.Click, btnF3.Click, btnF4.Click, btnF5.Click, btnF6.Click, _
            btnF7.Click, btnF8.Click, btnF9.Click, btnF10.Click, btnF11.Click, btnF12.Click
        Try
            Dim btn As Button = DirectCast(sender, Button)

            If IsBtnUsed(btn) Then RaiseEvent OnOperatorClick(btn, e)
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "btn_Click", ex, True)
        End Try
    End Sub

    Private Sub m_ctrlOwner_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            If Me.Visible Then
                Dim bRaise As Boolean = False
                Dim btn As Button = Nothing

                Dim nSpecialKey As Integer
                If e.Control Then nSpecialKey += &H4
                If e.Shift Then nSpecialKey += &H2
                If e.Alt Then nSpecialKey += &H1

                Select Case nSpecialKey
                    Case &H0 ' None
                        Select Case e.KeyCode
                            Case Keys.F1, Keys.F2, Keys.F3, Keys.F4, Keys.F5, Keys.F6, _
                                 Keys.F7, Keys.F8, Keys.F9, Keys.F10, Keys.F11, Keys.F12
                                Dim btnFs() As Button = { _
                                    btnF1, btnF2, btnF3, btnF4, btnF5, btnF6, _
                                    btnF7, btnF8, btnF9, btnF10, btnF11, btnF12 _
                                }

                                For Each btn In btnFs
                                    bRaise = (IsBtnUsed(btn) AndAlso btn.Tag = e.KeyCode.ToString)

                                    If bRaise Then Exit For
                                Next btn
                            Case Keys.Up, Keys.Down
                                btnManual.Tag = e.KeyCode.ToString

                                btn = btnManual
                                bRaise = True
                        End Select
                    Case &H1 ' Alt
                    Case &H2 ' Shift
                    Case &H3 ' Shift+Alt
                    Case &H4 ' Ctrl
                        Select Case e.KeyCode
                            Case Keys.T
                                btnManual.Tag = String.Format("Ctrl+{0}", e.KeyCode.ToString)

                                btn = btnManual
                                bRaise = True
                        End Select
                    Case &H5 ' Ctrl+Alt
                    Case &H6 ' Ctrl+Shift
                    Case &H7 ' Ctrl+Shift+Alt
                End Select

                If bRaise Then RaiseEvent OnOperatorClick(btn, e)
            End If
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "m_ctrlOwner_KeyUp", ex, True)
        End Try
    End Sub
#End Region
End Class
