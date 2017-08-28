Public Class clsGetRuntime

#Region "MEMBER"
#Region "PRIVATE MEMBER"
    Private Shared m_thisInstance As clsGetRuntime
    Private runTime As Date
#End Region
#End Region

#Region "METHOD"
#Region "CONSTRUCTOR AND DESTRUCTOR"
    Protected Sub New()
        'This prevents .NET from creating a default Public constructor and also prevents any caller
        'from creating their own instance of the object. However, by using Protected, the class can 
        'still be subclassed if you need to do this.
    End Sub
#End Region

#Region "PUBLIC METHOD"
    Public Shared Function GetInstance() As clsGetRuntime
        If (m_thisInstance Is Nothing) Then
            m_thisInstance = New clsGetRuntime
        End If
        Return m_thisInstance
    End Function

    Public Sub setRunTime()
        runTime = Now
    End Sub

    Public Function getRunTime() As Date
        Return runTime
    End Function


#End Region
#End Region
End Class