Imports System.IO
Public Module modDataSource
    Private g_cnn As SqlClient.SqlConnection = Nothing

    Public Class ta(Of taType As {Class, New})
        Sub New()
            
        End Sub

        Private Shared s_ta As taType = Nothing

        Public Shared Function GetTableAdapter(Optional ByVal bNewInstant As Boolean = True) As taType
            Dim ta As taType = Nothing

            If bNewInstant Then
                ta = New taType
                Dim xRead As System.Xml.XmlReader
                Dim theFile As FileStream = New FileStream(My.Application.Info.DirectoryPath & "\PIS-SERVER.exe.config", FileMode.Open, FileAccess.Read)
                xRead = Xml.XmlReader.Create(theFile)
                Dim bl As Boolean = xRead.ReadToFollowing("connectionStrings")
                bl = xRead.ReadToFollowing("add")
                Dim strConn As String
                strConn = xRead.GetAttribute("connectionString")

                SetConnection(strConn)

                s_ta = ta
            Else
                If s_ta Is Nothing Then
                    s_ta = New taType
                    Dim xRead As System.Xml.XmlReader
                    Dim theFile As FileStream = New FileStream(My.Application.Info.DirectoryPath & "\PIS-SERVER.exe.config", FileMode.Open, FileAccess.Read)
                    xRead = Xml.XmlReader.Create(theFile)
                    Dim bl As Boolean = xRead.ReadToFollowing("connectionStrings")
                    bl = xRead.ReadToFollowing("add")
                    Dim strConn As String
                    strConn = xRead.GetAttribute("connectionString")

                    SetConnection(strConn)

                End If
                ta = s_ta
            End If

            Debug.Assert(ta IsNot Nothing)

            If g_cnn IsNot Nothing Then
                If TypeOf (ta) Is ServerDatasetTableAdapters.T_LOG_DATTableAdapter Then
                    Dim ta_ As ServerDatasetTableAdapters.T_LOG_DATTableAdapter = _
                        TryCast(ta, ServerDatasetTableAdapters.T_LOG_DATTableAdapter)
                    ta_.Connection = g_cnn
                ElseIf TypeOf (ta) Is ServerDatasetTableAdapters.T_Instruction_DATTableAdapter Then
                    Dim ta_ As ServerDatasetTableAdapters.T_Instruction_DATTableAdapter = _
                        TryCast(ta, ServerDatasetTableAdapters.T_Instruction_DATTableAdapter)
                    ta_.Connection = g_cnn
                ElseIf TypeOf (ta) Is ServerDatasetTableAdapters.T_Production_DATTableAdapter Then
                    Dim ta_ As ServerDatasetTableAdapters.T_Production_DATTableAdapter = _
                        TryCast(ta, ServerDatasetTableAdapters.T_Production_DATTableAdapter)
                    ta_.Connection = g_cnn
                ElseIf TypeOf (ta) Is ServerDatasetTableAdapters.T_Line_MSTTableAdapter Then
                    Dim ta_ As ServerDatasetTableAdapters.T_Line_MSTTableAdapter = _
                        TryCast(ta, ServerDatasetTableAdapters.T_Line_MSTTableAdapter)
                    ta_.Connection = g_cnn
                Else
                    ' Unsupported type
                    Debug.Assert(False)
                End If
            End If
            GetTableAdapter = ta
        End Function
    End Class

    Public Sub SetConnection(ByRef strConnectionString As String)
        g_cnn = New SqlClient.SqlConnection(strConnectionString)
    End Sub

End Module
