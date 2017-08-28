Imports Common

Public Class InsertSeqAndSub

    Public Shared Sub ReorderSubSeq(ByVal baseSeq As String, ByVal baseSub As Integer, ByVal baseProdDate As String, ByVal baseProdTime As String)

        Dim logg As New Logger
        logg.Log(Logger.MessageType.NormalLog, "InsertSeqAndSub", "ReorderSubSeq", "Start", "")
        Dim taProduction As New DataSet1TableAdapters.T_Production_DATTableAdapter
        Dim dtProduction As New DataSet1.T_Production_DATDataTable
        Dim manage As New ManageInstructionData
        Try
            dtProduction = taProduction.GetDataBySeqNoProductionDateTime(baseSeq, baseProdDate, baseProdTime)

            'Dim inc As Integer = baseSub + 2
            'For Each aDR As DataSet1.T_Production_DATRow In dtProduction.Rows

            '    If aDR.SubSeq > baseSub Then
            '        aDR.SubSeq = inc
            '        inc += 1
            '    End If

            'Next

            'taProduction.Update(dtProduction)

            For i As Integer = dtProduction.Count - 1 To 0 Step -1

                If dtProduction(i).SubSeq > baseSub Then
                    dtProduction(i).SubSeq += 1

                    taProduction.Update(dtProduction(i))
                    manage.UpdateSkFromProductionRowToInstruction(dtProduction(i))
                End If
            Next
            logg.Log(Logger.MessageType.NormalLog, "InsertSeqAndSub", "ReorderSubSeq", "", "")
        Catch ex As Exception
            logg.Log(Logger.MessageType.ErrorLog, "InsertSeqAndSub", "ReorderSubSeq", ex.StackTrace, "")
            Throw ex
        End Try

    End Sub

    Public Shared Sub ReorderSubSeqForInspIn(ByVal baseSeq As String, ByVal baseSub As Integer, ByVal baseProdDate As String, ByVal baseProdTime As String)

        Dim logg As New Logger
        logg.Log(Logger.MessageType.NormalLog, "InsertSeqAndSub", "ReorderSubSeq", "Start", "")
        Dim taProduction As New DataSet1TableAdapters.T_Production_DATTableAdapter
        Dim dtProduction As New DataSet1.T_Production_DATDataTable
        Dim manage As New ManageInstructionData
        Try
            dtProduction = taProduction.GetDataBySeqNoProductionDateTime(baseSeq, baseProdDate, baseProdTime)

            'Dim inc As Integer = baseSub + 2
            'For Each aDR As DataSet1.T_Production_DATRow In dtProduction.Rows

            '    If aDR.SubSeq > baseSub Then
            '        aDR.SubSeq = inc
            '        inc += 1
            '    End If

            'Next

            'taProduction.Update(dtProduction)

            For i As Integer = dtProduction.Count - 1 To 0 Step -1

                If dtProduction(i).SubSeq > baseSub Then
                    dtProduction(i).SubSeq += 1

                    taProduction.Update(dtProduction(i))
                End If
            Next
            logg.Log(Logger.MessageType.NormalLog, "InsertSeqAndSub", "ReorderSubSeq", "", "")
        Catch ex As Exception
            logg.Log(Logger.MessageType.ErrorLog, "InsertSeqAndSub", "ReorderSubSeq", ex.StackTrace, "")
            Throw ex
        End Try

    End Sub
End Class
