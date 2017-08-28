Imports System.IO
Imports Common
Imports PIS_SERVER

Public Class ReadStdIO

    Private m_clsTLogDat As New TLogDat
    Private logger As New Logger

    Private Sub ReadStdIO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim strData As String = Console.ReadLine

        'While strData <> String.Empty ' Not strData Like "*free*"
        '    MsgBox(strData)
        '    strData = Console.ReadLine
        'End While


        'MsgBox(strData)
        If strData <> String.Empty Then

            m_clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_AS400, TLogDat.LogLevel.ErrorLog, My.Computer.Name, Now, strData, Nothing)
            'logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "ReadStdIO From HULFT command", strData, "")

        End If

        Me.Dispose()
    End Sub
End Class
