Module ReadStdIO

    Sub Main()
        Dim m_clsDbLogger As New clsDBLogger
        Dim m_clsLogger As New clsLogger
        Dim strData As String = Console.ReadLine

        If strData <> String.Empty Then
            LoadIni(enuAppType.service)
            LoadLogMessageMaster()
            m_clsDbLogger.Log(DB_LOG_CODE_N_HULF_MESSAGE, Nothing, strData)
        Else
            m_clsLogger.Log(clsLogger.MessageType.ErrorLog, "ReadStdIO", "Main", "Log Message is empty", "")
        End If
    End Sub

End Module
