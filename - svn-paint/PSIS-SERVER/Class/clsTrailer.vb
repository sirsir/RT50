Imports System.Text.RegularExpressions

Public Class ClsTrailer

#Region "Constant"
    Public Const RECORD_TYPE_TRAILER As Integer = 3
#End Region

#Region "Attribute"
    Dim m_strTitle As String
    Dim m_intDataCount As Integer
    Dim m_strFiller As String
#End Region

#Region "Constructor"
    Public Sub New()
        m_strTitle = String.Empty
        m_intDataCount = -1
        m_strFiller = String.Empty
    End Sub
#End Region

#Region "Property"

    Public ReadOnly Property DataCount()
        Get
            Return m_intDataCount
        End Get
    End Property

#End Region

#Region "Method"

    Public Shared Function ExtractToTrailer(ByVal strData As String) As clsTrailer
        Dim strTemp As String

        If strData = String.Empty Or strData.Length = 0 Then
            Return Nothing
        End If

        Dim objClsTrailer As clsTrailer = New clsTrailer
        objClsTrailer.m_strTitle = strData.Substring(0, 6)

        strTemp = strData.Substring(6, 8).TrimStart(" ")
        objClsTrailer.m_intDataCount = CInt(strTemp)

        Return objClsTrailer
    End Function

    Public Shared Function CheckFormatTrailer(ByVal strData As String) As Boolean
        Dim bResult As Boolean = False
        Dim strRegex As String

        If strData = String.Empty Or strData.Length = 0 Then
            Return bResult
        End If

        strRegex = "^TRAIL "
        strRegex += "[0-9]{8}"
        strRegex += "[A-Za-z0-9 ]{186}"

        Dim reg_exp As New Regex(strRegex)

        bResult = reg_exp.IsMatch(strData)

        Return bResult
    End Function

#End Region

End Class
