Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports Microsoft.SqlServer.Server
Imports System.Data.Sql
Imports System.Text.RegularExpressions


Partial Public Class Triggers

#Region "Constant"
    Const DELETE_FROM_PROD As String = _
            " DELETE FROM [dbo].[T_Production_DAT] "
    Const DELETE_FROM_INS As String = _
            " DELETE FROM [dbo].[T_Instruction_DAT] "
    Const INSERT_LOG_DAT As String = _
        " INSERT INTO [dbo].[T_LOG_DAT] VALUES (0,null,getdate(),'Flush data after T_LINE_MST changed',null,1) "
#End Region

   

#Region "Enumuration"
    Enum TablesColumn
        LineCode 
        LineName
        LineType
        MainLineFlag
        OnlineFlag
        IpAddress
        NetAddress
        NodeAddress
        UnitAddress
        ReadReqAddress
        WriteProductionAddress
        WriteCarryOutAddress
        Part1
        Part2
        Part3
        Part4
        Part5

    End Enum
#End Region




    ' Enter existing table or view for the target and uncomment the attribute line
    <Microsoft.SqlServer.Server.SqlTrigger(Name:="trgFlushAllData", Target:="T_Line_MST", Event:="AFTER INSERT ,UPDATE ")> _
    Public Shared Sub trgFlushAllData()
        ' Replace with your own code
        Sync()
    End Sub

#Region "Method"
    Private Shared Sub Sync()
        Try
            Dim updatedColumnCount As Integer
            Dim updatedColumns() As Boolean
            Dim counter As Integer
            Dim reader As SqlDataReader

            Dim conn As New SqlConnection("context connection=true")

            conn.Open()                             ' open the connection

            Dim cmd As SqlCommand
            cmd = conn.CreateCommand()

            Dim sqlPipe As SqlPipe = SqlContext.Pipe
            sqlPipe.Send("Synchronizing ")

            
            cmd.CommandText = "SELECT * FROM " & "T_Line_MST"
            reader = cmd.ExecuteReader()


            updatedColumnCount = SqlContext.TriggerContext.ColumnCount
            ReDim updatedColumns(reader.FieldCount - 1)

            'sqlPipe.Send("updCont: " & updatedColumnCount)
            sqlPipe.Send("reader:" & reader.FieldCount)
            Dim i As Integer

            'Dim caseColumn() As Object = {TablesColumn.LineCode.ToString(), _
            '                              TablesColumn.LineType.ToString(), _
            '                              TablesColumn.MainLineFlag.ToString(), _
            '                             TablesColumn.OnlineFlag.ToString(), _
            '                             TablesColumn.Part1.ToString(), _
            '                             TablesColumn.Part2.ToString(), _
            '                             TablesColumn.Part3.ToString(), _
            '                             TablesColumn.Part4.ToString(), _
            '                             TablesColumn.Part5.ToString()}

            Dim caseColumn() As String = {"LineCode", "LineType", "MainLineFlag", "OnlineFlag", "Part1", "Part2", "Part3", "Part4", "Part5"}

            Dim s As Integer

            SqlContext.Pipe.Send("updateColLength:" & updatedColumns.Length.ToString())

            For i = 0 To reader.FieldCount - 1
                sqlPipe.Send("i: " & i)
                updatedColumns(i) = SqlContext.TriggerContext.IsUpdatedColumn(i)
                SqlContext.Pipe.Send(reader.GetName(i) & updatedColumns(i).ToString())

                If updatedColumns(i) Then

                    For s = 0 To caseColumn.Length - 1
                        If reader.GetName(i).Equals(caseColumn(s)) Then
                            counter += 1
                        End If

                    Next

                End If

            Next


            conn.Close()
            If counter > 0 Then
                conn.Open()
                cmd = New SqlCommand(" SET NOCOUNT ON ", conn) : cmd.ExecuteNonQuery()
                cmd = New SqlCommand(DELETE_FROM_INS, conn) : cmd.ExecuteNonQuery()
                cmd = New SqlCommand(DELETE_FROM_PROD, conn) : cmd.ExecuteNonQuery()
                cmd = New SqlCommand(INSERT_LOG_DAT, conn) : cmd.ExecuteNonQuery()
                conn.Close()
            End If

        Catch ex As Exception
            'ToDo: Implement Exception Handling
            Throw ex
        End Try
    End Sub

#End Region


End Class
