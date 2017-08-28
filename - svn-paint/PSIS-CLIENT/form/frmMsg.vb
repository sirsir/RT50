Public Class frmMsg

#Region "Constant"
    Private Const STR_MSG_FORMAT As String = "{0} : {1}"
    Private Const STR_MSG_SHUTDOWN As String = vbCrLf & vbCrLf & " (F12) TO SHUTDOWN APPLICATION"
    Private Const STR_MSG_CONFIRMATION As String = vbCrLf & vbCrLf & " (Y) MAIN MENU (N) BACK TO SCREEN"
#End Region

#Region "Enumerator"
    Public Enum enuMsgType
        errors
        info
        warning
    End Enum
#End Region

#Region "Attribute"
    Private m_blnIsActivate As Boolean = False
    Private m_blnSupportsAutoClosing As Boolean = False
    Private m_blnSupportsCancellation As Boolean = False
    Private m_blnSupportsShutdownApplication As Boolean = False
    Private m_blnSupportsComfirmation As Boolean = False
    Private m_nMsgType As enuMsgType

    Private m_strMsg As String
#End Region

#Region "Constructor"

#End Region

#Region "Property"

    Public Property IsActivate() As Boolean
        Get
            Return m_blnIsActivate
        End Get
        Set(ByVal value As Boolean)
            m_blnIsActivate = value
        End Set
    End Property

    Public WriteOnly Property SupportsAutoClosing() As Boolean
        Set(ByVal value As Boolean)
            m_blnSupportsAutoClosing = value
        End Set
    End Property

    Public WriteOnly Property SupportsCancellation() As Boolean
        Set(ByVal value As Boolean)
            m_blnSupportsCancellation = value
        End Set
    End Property

    Public WriteOnly Property SupportsShutdownApplication() As Boolean
        Set(ByVal value As Boolean)
            m_blnSupportsShutdownApplication = value
        End Set
    End Property

    Public WriteOnly Property SupportsConfirmation() As Boolean
        Set(ByVal value As Boolean)
            m_blnSupportsComfirmation = value
        End Set
    End Property

    Public WriteOnly Property MsgType() As enuMsgType
        Set(ByVal value As enuMsgType)
            m_nMsgType = value
        End Set
    End Property

    Public WriteOnly Property Message() As String
        Set(ByVal value As String)
            Label1.Text = String.Format(STR_MSG_FORMAT, m_nMsgType.ToString.ToUpper, value)

            If m_blnSupportsComfirmation Then Label1.Text &= STR_MSG_CONFIRMATION
            If m_blnSupportsShutdownApplication Then Label1.Text &= STR_MSG_SHUTDOWN
        End Set
    End Property
#End Region

#Region "Method"
    Private Sub ResetSupportsOperation()
        m_blnSupportsAutoClosing = False
        m_blnSupportsCancellation = False
        m_blnSupportsShutdownApplication = False
        m_blnSupportsComfirmation = False
    End Sub
#End Region

#Region "Event"

    Private Sub tmr1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmr1.Tick
        If m_blnSupportsAutoClosing Then
            Me.Close()
        Else
            tmr1.Enabled = False
        End If

        ResetSupportsOperation()
    End Sub

    Private Sub Label1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label1.Click
        If m_blnSupportsCancellation Then Me.Close()

        ResetSupportsOperation()
    End Sub

    Private Sub frmMsg_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Select Case e.KeyCode
            Case Keys.F12
                If m_blnSupportsShutdownApplication Then Application.Exit()
            Case Keys.Y
                Me.DialogResult = Windows.Forms.DialogResult.Yes
                Me.Close()
            Case Keys.N
                Me.DialogResult = Windows.Forms.DialogResult.No
                Me.Close()
        End Select

        ResetSupportsOperation()
    End Sub
#End Region

End Class