Imports Common
Imports System.IO
Imports System.ComponentModel
Imports PIS_SERVER

Module PIS_IMPORT

    Private filePath As String
    Private AS400Path As String
    Private AS400BackUpPath As String
    Private AppPath As String
    Private HULFTPath As String
    Private HULFTKickPath As String
    Private bgWorker As BackgroundWorker
    Private FileNameList As ArrayList
    Private logger As New Logger


    Sub Main()
        'Console.WriteLine("test import")
        'Console.ReadLine()
        
        checkFile()
    End Sub


    Sub checkFile()
        Dim clsTLogDat As New TLogDat

        logger.SystemStart()
        'Load Path
        Dim ini As IniFile = New IniFile()
        AS400Path = ini.GetString(ModConstant.INI_SECTION_SETTING, ModConstant.INI_KEY_AS400_PATH, "C:\AS400\AS400File", ModConstant.INI_FILE_NAME)
        AS400BackUpPath = ini.GetString(ModConstant.INI_SECTION_SETTING, ModConstant.INI_KEY_BACKUP_AS400_PATH, "C:\AS400\BackupAS400File", ModConstant.INI_FILE_NAME)
        'File.CreateText("..\conf\test.txt")
        'Read File
        Dim di As New IO.DirectoryInfo(AS400Path)
        If Not di.Exists Then
            di.Create()
        End If
        Dim fileInf() As IO.FileInfo = di.GetFiles("*.txt", SearchOption.AllDirectories)

        FileNameList = New ArrayList()

        If fileInf.Length > 0 Then
            For Each inf As FileInfo In fileInf
                FileNameList.Add(inf.FullName)
            Next

            clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_AS400, TLogDat.LogLevel.NormalLog, Nothing, Now, "New AS400 File Received", Nothing)
            logger.Log(Common.Logger.MessageType.NormalLog, "PIS-IMPORT", "checkFile", "New AS400 File Received", "")
            While FileNameList.Count > 0
                ImportProductionDataFile()
            End While
        Else
            clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_AS400, TLogDat.LogLevel.NormalLog, Nothing, Now, "No AS400 File In Folder", Nothing)
            logger.Log(Common.Logger.MessageType.WarningLog, "PIS-IMPORT", "checkFile", "No AS400 File In Folder", "")
        End If
        logger.SystemEnd()
    End Sub

    Sub ImportProductionDataFile()
        Dim clsTLogDat As New TLogDat
        logger.Log(Common.Logger.MessageType.NormalLog, "PIS-IMPORT", "ImportProductionDataFile", "Start", "")
        Dim strFileNameWithPath As String = FileNameList(0).ToString
        Dim strFileName As String = strFileNameWithPath.Substring(AS400Path.Length + 1)
        Dim strNow As String = Format(Now, "yyyyMMddHHmmss")
        Dim strFileRename As String = strNow & strFileName
        Dim strFileRenameWithPath As String = AS400Path & "\" & strFileRename
        Dim strBackupName As String = AS400BackUpPath & "\" & strNow.Substring(0, 8) & "\"
        If Not Directory.Exists(strBackupName) Then
            Directory.CreateDirectory(strBackupName)
        End If
        strBackupName += strFileRename

        Dim theFile As FileStream = Nothing
        'Dim theFile2 As FileStream = Nothing
        Dim bCheckPass As Boolean = False
        Dim bImportPass As Boolean = False

        Try
            theFile = New FileStream(strFileNameWithPath, FileMode.Open, FileAccess.Read)

            If Not theFile.CanRead Then

                clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_AS400, TLogDat.LogLevel.ErrorLog, Nothing, Now, "Cannot read the file", Nothing)
                logger.Log(Common.Logger.MessageType.NormalLog, "PIS-IMPORT", "ImportProductionDataFile", "Cannot read the file", "")
            Else
                Dim objAs400File As New clsAs400File

                theFile.Close()
                logger.Log(Common.Logger.MessageType.NormalLog, "PIS-IMPORT", "ImportProductionDataFile", "Can read the file", "")
                MoveFile(strFileNameWithPath, strFileRenameWithPath)
                logger.Log(Common.Logger.MessageType.NormalLog, "PIS-IMPORT", "ImportProductionDataFile", "File renamed to """ & strFileRenameWithPath & """", "")

                theFile = New FileStream(strFileRenameWithPath, FileMode.Open, FileAccess.Read)

                logger.Log(Common.Logger.MessageType.NormalLog, "PIS-IMPORT", "ImportProductionDataFile", "File opened to import", "")

                bCheckPass = objAs400File.CheckAs400File(theFile, strFileRenameWithPath, strFileRename)
                theFile.Close()

                If bCheckPass Then
                    'Execute Batch file for HULFT command - utlsend
                    Shell(My.Application.Info.DirectoryPath & "\utlsend.bat", AppWinStyle.Hide, True, 3000)
                    logger.Log(Common.Logger.MessageType.ErrorLog, "PIS-IMPORT", "ImportProductionDataFile", "Shell utlsend.bat", "")

                    SplitFileByShift(strFileRenameWithPath)
                    Dim di As New IO.DirectoryInfo(AS400Path)
                    Dim aFileInf() As IO.FileInfo = di.GetFiles("*.txt.S*", SearchOption.AllDirectories)

                    Dim intMaxRetryCount As Integer = 5
                    For Each fileInf As IO.FileInfo In aFileInf
                        Dim bImportSuccess As Boolean = False
                        Dim intRetryCount As Integer = 0

                        While Not bImportSuccess AndAlso intRetryCount < intMaxRetryCount
                            Dim sFile As IO.FileStream
                            sFile = New FileStream(fileInf.FullName, FileMode.Open, FileAccess.Read)
                            bImportSuccess = objAs400File.ExtractAs400File(sFile, fileInf.FullName, fileInf.Name)
                            sFile.Close()
                            sFile.Dispose()
                            Threading.Thread.Sleep(TimeSpan.FromSeconds(2))
                            If bImportSuccess Then Exit While
                            intRetryCount += 1
                        End While
                        MoveFile(fileInf.FullName, AS400BackUpPath & "\" & strNow.Substring(0, 8) & "\" & fileInf.Name)
                    Next
                    'theFile = New FileStream(strFileRenameWithPath, FileMode.Open, FileAccess.Read)
                    'bCheckPass = objAs400File.ExtractAs400File(theFile, strFileRenameWithPath, strFileRename)
                    'theFile.Close()

                End If

                theFile.Close()
                logger.Log(Common.Logger.MessageType.NormalLog, "PIS-IMPORT", "ImportProductionDataFile", "File closed", "")

                FileNameList.RemoveAt(0)
                logger.Log(Common.Logger.MessageType.NormalLog, "PIS-IMPORT", "ImportProductionDataFile", "Remove filename from list, Remaining " & FileNameList.Count & " records", "")

                MoveFile(strFileRenameWithPath, strBackupName)
                logger.Log(Common.Logger.MessageType.NormalLog, "PIS-IMPORT", "ImportProductionDataFile", "File moved to backup folder", "")
                logger.Log(Common.Logger.MessageType.NormalLog, "PIS-IMPORT", "ImportProductionDataFile", "End", "")
            End If
        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, "PIS-IMPORT", "ImportProductionDataFile", "Enter exception", "")
            theFile.Close()
            clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_AS400, TLogDat.LogLevel.ErrorLog, Nothing, Now, ex.Message, Nothing)
            logger.Log(Common.Logger.MessageType.ErrorLog, "PIS-IMPORT", "ImportProductionDataFile", ex.Message, ex.StackTrace)
            'logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "ImportProductionDataFile", "File closed", "")

            FileNameList.RemoveAt(0)
            logger.Log(Common.Logger.MessageType.ErrorLog, "PIS-IMPORT", "ImportProductionDataFile", "Remove filename from list, Remaining " & FileNameList.Count & " records", "")

            MoveFile(strFileRenameWithPath, strBackupName)

            logger.Log(Common.Logger.MessageType.ErrorLog, "PIS-IMPORT", "ImportProductionDataFile", "File moved to backup folder", "")
        End Try
        logger.Log(Common.Logger.MessageType.NormalLog, "PIS-IMPORT", "ImportProductionDataFile", "End", "")
    End Sub

    Private Sub MoveFile(ByVal fromFile As String, ByVal toFile As String)
        'If System.IO.File.Exists(fromFile) = True Then
        '    If System.IO.File.Exists(toFile) = True Then
        '        System.IO.File.Delete(toFile)
        '    End If
        '    System.IO.File.Move(fromFile, toFile)
        'End If
        Dim blnMoved As Boolean = False
        While Not blnMoved AndAlso System.IO.File.Exists(fromFile)
            Try
                If System.IO.File.Exists(toFile) = True Then
                    System.IO.File.Delete(toFile)
                End If
                System.IO.File.Move(fromFile, toFile)
                blnMoved = True
            Catch ex As Exception

            End Try
        End While
    End Sub

    Private Sub SplitFileByShift(ByVal strOriFullPath As String)
        Dim sReader As New StreamReader(strOriFullPath)
        Dim sWriter As IO.StreamWriter = Nothing
        Dim blnEnd As Boolean = False
        Dim strRead As String = ""
        Dim intFileNumber As Integer = 0
        Dim objAs400 As New clsAs400File

        While Not blnEnd
            strRead = ""
            strRead = sReader.ReadLine()
            If strRead IsNot Nothing Then
                Select Case objAs400.CheckRecordTypeReadLine(strRead)
                    Case clsAs400File.RECORD_TYPE_HEADER
                        intFileNumber += 1
                        sWriter = New IO.StreamWriter(strOriFullPath & ".S" & intFileNumber.ToString("D3"), True)
                        sWriter.WriteLine(strRead)
                    Case clsAs400File.RECORD_TYPE_PRODUCTION
                        sWriter.WriteLine(strRead)
                    Case clsAs400File.RECORD_TYPE_TRAIL
                        sWriter.WriteLine(strRead)
                        sWriter.Close()
                        sWriter.Dispose()
                    Case Else
                        If sWriter IsNot Nothing Then
                            sWriter.Close()
                            sWriter.Dispose()
                        End If
                        blnEnd = True
                End Select
            Else
                If sWriter IsNot Nothing Then
                    sWriter.Close()
                    sWriter.Dispose()
                End If
                blnEnd = True
            End If
        End While

    End Sub


End Module
