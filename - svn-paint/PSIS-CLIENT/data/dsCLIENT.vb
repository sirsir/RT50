Partial Class dsCLIENT
    Partial Class dtPLC_MSTDataTable

    End Class

    Partial Class dtPROCESS_MSTDataTable
#Region "Constant"

#End Region

#Region "Enumerator"
        Public Enum enuProcessType
            Finishing
            WBS
            Paint
            PBR
            All = 99
        End Enum
#End Region

#Region "Attribute"

#End Region

#Region "Constructor"

#End Region

#Region "Property"

#End Region

#Region "Method"

#End Region

#Region "Event"

#End Region
    End Class

    Partial Class dtOPTION_MSTDataTable
#Region "Constant"

#End Region

#Region "Enumerator"
        Public Enum enuOptionType
            Destination = 1
            OptionTable = 2
        End Enum
#End Region

#Region "Attribute"

#End Region

#Region "Constructor"

#End Region

#Region "Property"

#End Region

#Region "Method"

#End Region

#Region "Event"

#End Region
    End Class

    Partial Class dtMODEL_OPTION_CELLRow
#Region "Constant"

#End Region

#Region "Attribute"

#End Region

#Region "Constructor"

#End Region

#Region "Property"
        Public ReadOnly Property OPTION_DISPLAY() As String
            Get
                If dtOPTION_MSTRow Is Nothing Then
                    Return Nothing
                Else
                    Return dtOPTION_MSTRow.OPTION_DISPLAY
                End If
            End Get
        End Property

        Public ReadOnly Property OPTION_TYPE() As Integer
            Get
                If dtOPTION_MSTRow Is Nothing Then
                    Return Nothing
                Else
                    Return dtOPTION_MSTRow.OPTION_TYPE
                End If
            End Get
        End Property
#End Region

#Region "Method"

#End Region

#Region "Event"

#End Region
    End Class

    Partial Class dtPROCESS_MSTRow
#Region "Constant"

#End Region

#Region "Attribute"

#End Region

#Region "Constructor"

#End Region

#Region "Property"
        Public ReadOnly Property PROCESS_GROUP_NAME() As String
            Get
                If dtPROCESS_GROUP_MSTRow Is Nothing Then
                    Return Nothing
                Else
                    Return dtPROCESS_GROUP_MSTRow.PROCESS_GROUP_NAME
                End If
            End Get
        End Property
#End Region

#Region "Method"

#End Region

#Region "Event"

#End Region
    End Class

    Partial Class dtLOG_DATRow
#Region "Constant"

#End Region

#Region "Attribute"

#End Region

#Region "Constructor"

#End Region

#Region "Property"
        Public ReadOnly Property PROCESS_NAME() As String
            Get
                If dtPROCESS_MSTRow Is Nothing Then
                    Return Nothing
                Else
                    Return dtPROCESS_MSTRow.PROCESS_NAME
                End If
            End Get
        End Property
#End Region

#Region "Method"

#End Region

#Region "Event"

#End Region
    End Class
End Class

