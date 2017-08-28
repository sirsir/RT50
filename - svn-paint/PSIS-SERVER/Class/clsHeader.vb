Imports System.Text.RegularExpressions

Public Class ClsHeader

#Region "Constant"
    Public Const RECORD_TYPE_HEADER As Integer = 1
#End Region

#Region "Attribute"
    Dim m_strTitle As String
    Dim m_strDataSetName As String
    Dim m_dtCreationDate As Date
    Dim m_intRecordSize As Integer
    Dim m_intBlockSize As Integer
    Dim m_strFiller As String
#End Region

#Region "Constructor"

    Public Sub New()
        m_strTitle = String.Empty
        m_strDataSetName = String.Empty
        m_dtCreationDate = Nothing
        m_intRecordSize = -1
        m_intBlockSize = -1
        m_strFiller = String.Empty
    End Sub

#End Region

#Region "Property"

    Public ReadOnly Property CreationDate() As Date
        Get
            Return m_dtCreationDate
        End Get
    End Property

#End Region

#Region "Method"

    Public Shared Function ExtractToHeader(ByVal strData As String) As clsHeader
        Dim strTemp As String

        If strData = String.Empty Or strData.Length = 0 Then
            Return Nothing
        End If

        Dim objClsHeader As clsHeader = New clsHeader
        objClsHeader.m_strTitle = strData.Substring(0, 6)
        objClsHeader.m_strDataSetName = strData.Substring(6, 18)
        objClsHeader.m_dtCreationDate = Date.ParseExact(strData.Substring(24, 14), "yyyyMMddHHmmss", Nothing)

        strTemp = strData.Substring(38, 5).TrimStart(" ")
        objClsHeader.m_intRecordSize = CInt(strTemp)

        strTemp = strData.Substring(43, 5).TrimStart(" ")
        objClsHeader.m_intBlockSize = CInt(strTemp)

        Return objClsHeader
    End Function

    Public Shared Function CheckFormatHeader(ByVal strData As String) As Boolean
        Dim bResult As Boolean = False
        Dim strRegex As String

        If strData = String.Empty Or strData.Length = 0 Then
            Return bResult
        End If
        strRegex = "^HEADERRT50 PAINT        "
        strRegex += "[0-9]{14}"
        strRegex += "[0-9]{5}"
        strRegex += "[0-9]{5}"
        strRegex += "[A-Za-z0-9 ]{152}"

        Dim reg_exp As New Regex(strRegex)

        bResult = reg_exp.IsMatch(strData)

        Return bResult
    End Function

#End Region

End Class
