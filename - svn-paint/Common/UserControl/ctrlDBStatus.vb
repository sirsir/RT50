Public Class ctrlDBStatus

#Region "Attribute"
    Private m_blnLastResult As Boolean = False
#End Region

#Region "Constructor"

#End Region

#Region "Property"

    Public Property LastConnectionStatus() As Boolean
        Get
            Return m_blnLastResult
        End Get
        Set(ByVal value As Boolean)
            m_blnLastResult = value
        End Set
    End Property

#End Region

#Region "Method"

    Public Sub FillColor(ByVal clrSuccess As Color, ByVal clrFail As Color)
        oshSuccessStatus.FillColor = clrSuccess
        oshFailStatus.FillColor = clrFail
    End Sub

#End Region

End Class
