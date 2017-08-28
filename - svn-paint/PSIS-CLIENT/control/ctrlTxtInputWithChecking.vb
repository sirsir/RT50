Public Class ctrlTxtInputWithChecking

#Region "Constant"

#End Region

#Region "Enumerator"
    Public Enum enuFormMode
        Add
        Edit
    End Enum
#End Region

#Region "Attribute"
    Private m_strInputName As String
    Private m_strHint As String
    Private m_intMaxLength As Integer
    Private m_strErrorMessage As String
    Private m_strRegex As String
    Private m_regExp As Regex
    Private m_blnEnableEdit As Boolean

#End Region

#Region "Constructor"
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Initialize()
    End Sub
#End Region

#Region "Property"
    Public Property InputName() As String
        Get
            Return m_strInputName
        End Get
        Set(ByVal value As String)
            m_strInputName = value
            Me.AddHint()
        End Set
    End Property

    Public Property HintMessage() As String
        Get
            Return m_strHint
        End Get
        Set(ByVal value As String)
            m_strHint = value
            Me.AddHint()
        End Set
    End Property

    Public Property ErrorMessage() As String
        Get
            Return m_strErrorMessage
        End Get
        Set(ByVal value As String)
            m_strErrorMessage = value
            Me.lblError.Text = m_strErrorMessage
            If m_strErrorMessage IsNot Nothing AndAlso m_strErrorMessage.Length > 0 Then
                Me.lblInput.BackColor = Color.Red
            Else
                Me.lblInput.BackColor = SystemColors.Control
            End If
        End Set
    End Property

    Public Property RegexFormat() As String
        Get
            Return m_strRegex
        End Get
        Set(ByVal value As String)
            m_strRegex = value

            If m_strRegex <> Nothing _
            AndAlso m_strRegex <> String.Empty _
            AndAlso m_strRegex.Length <> 0 Then
                m_regExp = New Regex(m_strRegex)
            End If
        End Set
    End Property

    Public Property MaxLength() As Integer
        Get
            Return m_intMaxLength
        End Get
        Set(ByVal value As Integer)
            If value > 0 Then
                m_intMaxLength = value
            Else
                m_intMaxLength = 0
            End If
            Me.txtInput.MaxLength = m_intMaxLength
        End Set
    End Property

    Public Property EnableEdit() As Boolean
        Get
            Return m_blnEnableEdit
        End Get
        Set(ByVal value As Boolean)
            m_blnEnableEdit = value
            Me.txtInput.ReadOnly = Not m_blnEnableEdit
        End Set
    End Property

    Public Property InputText() As String
        Get
            Return Me.txtInput.Text
        End Get
        Set(ByVal value As String)
            Me.txtInput.Text = value
        End Set
    End Property
#End Region

#Region "Method"
    Public Sub Initialize()
        Me.RegexFormat = String.Empty
        Me.HintMessage = String.Empty
        Me.MaxLength = 0
        Me.EnableEdit = True
        Me.ErrorMessage = String.Empty
    End Sub

    Public Function CheckInput() As Boolean
        Me.ErrorMessage = String.Empty

        If Not CheckRegexPass() Then
            Me.ErrorMessage = String.Format("{0} INVALID FORMAT", m_strInputName, m_strRegex)
            Return False
        End If

        Return True
    End Function

    Private Sub AddHint()
        Dim strTemp1 As String = ""
        Dim strTemp2 As String = ""

        If m_strInputName Is Nothing Then
            strTemp1 = String.Empty
        Else
            strTemp1 = m_strInputName
        End If

        If m_strHint Is Nothing OrElse m_strHint = String.Empty Then
            strTemp2 = String.Empty
        Else
            strTemp2 = " (" & m_strHint & ")"
        End If
        Me.lblInput.Text = strTemp1 & strTemp2
    End Sub

    Private Function CheckRegexPass() As Boolean
        If m_strRegex Is Nothing OrElse m_strRegex = String.Empty OrElse m_strRegex.Length = 0 Then
            Return True     'Not check regular expression
        End If

        Return m_regExp.IsMatch(Me.txtInput.Text)
    End Function
#End Region

#Region "Event"

#End Region

End Class
