Public Module modDatabase

#Region "Constant"

#End Region

#Region "Attribute"

#End Region

#Region "Constructor"

#End Region

#Region "Property"

    Public WriteOnly Property ConnectionString() As String
        Set(ByVal value As String)
            My.Settings("ConnectionString") = value
            My.Settings("psis_developmentConnectionString") = value
        End Set
    End Property

#End Region

#Region "Method"

    Public Function GetColumnValue(ByVal dr As DataRow, ByVal strColumnName As String) As Object
        Dim objValue As Object = Nothing

        If dr.Table.Columns.Contains(strColumnName) AndAlso Not IsDBNull(dr.Item(strColumnName)) Then
            objValue = dr.Item(strColumnName)
        End If

        Return objValue
    End Function

#End Region

#Region "Event"

#End Region

End Module
