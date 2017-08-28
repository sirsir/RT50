Module PSIS_IMPORT

    Sub Main()
        Dim clsLog As New clsLogger
        Dim clsFile As New clsFile(PSIS_SERVER.clsFile.enuImportType.as400)

        modIni.LoadIni(enuAppType.service)

        clsLog.Log(clsLogger.MessageType.NormalLog, "PSIS_IMPORT", "ImportAS400File", "Start", "", IMPORT_EXE_LOG_SUFFIX)

        clsFile.ImportFile(modIni.AS400Path, modIni.BackupAS400Path)

        clsLog.Log(clsLogger.MessageType.NormalLog, "PSIS_IMPORT", "ImportAS400File", "End", "", IMPORT_EXE_LOG_SUFFIX)
    End Sub

End Module
