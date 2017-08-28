Imports Common
Imports System.IO.File
Imports System.IO
Imports PIS_SERVER


Module PIS_SERVICE

    Private Const INI_FILE_NAME_SETUP As String = "PIS-SETTING.ini"
    Private Const INI_APP_NAME_SETUP As String = "Setting"
    Private INI_KEY_SCREEN As String = ""
    Private Const INI_KEY_HULFT_CMD_PATH As String = "HulftCmdPath"
    Private Const INI_KEY_HULFT_SAVE_FILE As String = "HulftSaveFile"
    Private Const INI_KEY_HULFT_KICK_FILE As String = "HulftKickFile"
    Private Const INI_KEY_HULFT_RECV_ID As String = "HulftRecvId"
    Private Const INI_KEY_HULFT_SEND_ID As String = "HulftSendId"
    Private Const INI_KEY_AS400_HOST As String = "AS400Host"
    Private Const FILE_NAME_UTLRECV As String = "utlrecv.bat"
    Private Const FILE_NAME_UTLSEND As String = "utlsend.bat"
    Private Const FILE_NAME_RECV_JOB_ERROR As String = "recv_joberror.bat"
    Private Const FILE_NAME_RECV_JOB_OK As String = "recv_jobok.bat"
    Private Const FILE_NAME_SEND_JOB_ERROR As String = "send_joberror.bat"
    Private Const FILE_NAME_SEND_JOB_OK As String = "send_jobok.bat"


    Dim logger As Logger = New Logger()
    Dim iniObj As IniFile = New IniFile()
    Dim clsTLogDat As New TLogDat
    Dim strAppPath As String = ""
    Dim strHulftCmdPath As String = ""
    Dim strHulftSaveFile As String = ""
    Dim strHulftKickFile As String = ""
    Dim strHulftRecvId As String = ""
    Dim strHulftSendId As String = ""
    Dim strAS400Host As String = ""


    Sub Main()
        Dim outStr As String = ""
        Dim dir As String
        Dim intHr = 0
        Dim intMin = 0

        logger.SystemStart()
        INI_KEY_SCREEN = "ScheduleTime"
        outStr = iniObj.GetString(INI_APP_NAME_SETUP, INI_KEY_SCREEN, "2300", INI_FILE_NAME_SETUP)
        intHr = CInt(outStr.Substring(0, 2))
        intMin = CInt(outStr.Substring(2, 2))

        If CreateBatchFile() Then
            logger.Log(Common.Logger.MessageType.NormalLog, "PIS_SERVICE", "Main", "Create Batch Files At Service Start Success", "")
        Else
            logger.Log(Common.Logger.MessageType.ErrorLog, "PIS_SERVICE", "Main", "Create Batch Files At Service Start Failed", "")
        End If

        While True

            Threading.Thread.Sleep(TimeSpan.FromMinutes(1))
            'Update Schedule Time
            INI_KEY_SCREEN = "ScheduleTime"
            outStr = iniObj.GetString(INI_APP_NAME_SETUP, INI_KEY_SCREEN, "2300", INI_FILE_NAME_SETUP)
            intHr = CInt(outStr.Substring(0, 2))
            intMin = CInt(outStr.Substring(2, 2))
            logger.Log(Common.Logger.MessageType.NormalLog, "PIS_SERVICE", "Main", "Scheduled time read: " & intHr & ":" & intMin, "")
            If Now.Hour <> intHr Or Now.Minute <> intMin Then Continue While ' Get hour from ini

            logger.Log(Common.Logger.MessageType.NormalLog, "PIS_SERVICE", "Main", "Start Working at Scheduled Time", "")
            'clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_OPERATION, TLogDat.LogLevel.NormalLog, Nothing, Now, "Clear old data service started", Nothing)

            Try
                If CreateBatchFile() Then
                    logger.Log(Common.Logger.MessageType.NormalLog, "PIS_SERVICE", "Main", "Create Batch Files Success", "")
                    'clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_OPERATION, TLogDat.LogLevel.NormalLog, Nothing, Now, "Create Batch Files Success", Nothing)

                    'T_PRODUCTION_DAT
                    'T_INSTRUCTION_DAT
                    INI_KEY_SCREEN = "dbPeriod"
                    outStr = iniObj.GetString(INI_APP_NAME_SETUP, INI_KEY_SCREEN, "30", INI_FILE_NAME_SETUP)
                    logger.Log(Common.Logger.MessageType.NormalLog, "PIS_SERVICE", "Main", "dbPeriod = " & outStr, "")
                    'Console.WriteLine("dbPeriod: " & outStr)
                    If deletePro(Integer.Parse(outStr)) Then
                        'logger.Log(Common.Logger.MessageType.NormalLog, "PIS_SERVICE", "Main", "Delete T_Production_DAT Success", "")
                        clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_OPERATION, TLogDat.LogLevel.NormalLog, My.Computer.Name, Now, "Delete T_Production_DAT Success", Nothing)
                    Else
                        'logger.Log(Common.Logger.MessageType.ErrorLog, "PIS_SERVICE", "Main", "Delete T_Production_DAT Failed", "")
                        clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_OPERATION, TLogDat.LogLevel.ErrorLog, My.Computer.Name, Now, "Delete T_Production_DAT Failed", Nothing)
                    End If
                    If deleteIns(Integer.Parse(outStr)) Then
                        'logger.Log(Common.Logger.MessageType.NormalLog, "PIS_SERVICE", "Main", "Delete T_Instruction_Dat Success", "")
                        clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_OPERATION, TLogDat.LogLevel.NormalLog, My.Computer.Name, Now, "Delete T_Instruction_DAT Success", Nothing)
                    Else
                        'logger.Log(Common.Logger.MessageType.ErrorLog, "PIS_SERVICE", "Main", "Delete T_Instruction_Dat Failed", "")
                        clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_OPERATION, TLogDat.LogLevel.ErrorLog, My.Computer.Name, Now, "Delete T_Instruction_DAT Failed", Nothing)
                    End If


                    'AS400Period Log
                    INI_KEY_SCREEN = "AS400Period"
                    outStr = iniObj.GetString(INI_APP_NAME_SETUP, INI_KEY_SCREEN, "30", INI_FILE_NAME_SETUP)
                    logger.Log(Common.Logger.MessageType.NormalLog, "PIS_SERVICE", "Main", "AS400 Log Period = " & outStr, "")
                    'Console.WriteLine("AS400Period: " & outStr)
                    If deleteLogDat(Integer.Parse(outStr), 0) Then
                        'logger.Log(Common.Logger.MessageType.NormalLog, "PIS_SERVICE", "Main", "Delete AS400 Log Success", "")
                        clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_OPERATION, TLogDat.LogLevel.NormalLog, My.Computer.Name, Now, "Delete AS400 Log Success", Nothing)
                    Else
                        'logger.Log(Common.Logger.MessageType.ErrorLog, "PIS_SERVICE", "Main", "Delete AS400 Log Failed", "")
                        clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_OPERATION, TLogDat.LogLevel.ErrorLog, My.Computer.Name, Now, "Delete AS400 Log Failed", Nothing)
                    End If


                    'PLCPeriod Log
                    INI_KEY_SCREEN = "PLCPeriod"
                    outStr = iniObj.GetString(INI_APP_NAME_SETUP, INI_KEY_SCREEN, "14", INI_FILE_NAME_SETUP)
                    logger.Log(Common.Logger.MessageType.NormalLog, "PIS_SERVICE", "Main", "PLC Log Period = " & outStr, "")
                    'Console.WriteLine("PLCPeriod: " & outStr)
                    If deleteLogDat(Integer.Parse(outStr), 1) Then
                        'logger.Log(Common.Logger.MessageType.NormalLog, "PIS_SERVICE", "Main", "Delete PLC Log Success", "")
                        clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_OPERATION, TLogDat.LogLevel.NormalLog, My.Computer.Name, Now, "Delete PLC Log Success", Nothing)
                    Else
                        'logger.Log(Common.Logger.MessageType.ErrorLog, "PIS_SERVICE", "Main", "Delete PLC Log Failed", "")
                        clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_OPERATION, TLogDat.LogLevel.ErrorLog, My.Computer.Name, Now, "Delete PLC Log Failed", Nothing)
                    End If


                    'LogPeriod Log (Operation Log)
                    INI_KEY_SCREEN = "LogPeriod"
                    outStr = iniObj.GetString(INI_APP_NAME_SETUP, INI_KEY_SCREEN, "30", INI_FILE_NAME_SETUP)
                    logger.Log(Common.Logger.MessageType.NormalLog, "PIS_SERVICE", "Main", "Operation Log Period = " & outStr, "")
                    'Console.WriteLine("LogPeriod: " & outStr)
                    If deleteLogDat(Integer.Parse(outStr), 2) Then
                        'logger.Log(Common.Logger.MessageType.NormalLog, "PIS_SERVICE", "Main", "Delete Operation Log Success", "")
                        clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_OPERATION, TLogDat.LogLevel.NormalLog, My.Computer.Name, Now, "Delete Operation Log Success", Nothing)
                    Else
                        'logger.Log(Common.Logger.MessageType.ErrorLog, "PIS_SERVICE", "Main", "Delete Operation Log Failed", "")
                        clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_OPERATION, TLogDat.LogLevel.ErrorLog, My.Computer.Name, Now, "Delete Operation Log Failed", Nothing)
                    End If

                    'delete AS400 File
                    INI_KEY_SCREEN = "dbPeriod"
                    outStr = iniObj.GetString(INI_APP_NAME_SETUP, INI_KEY_SCREEN, "30", INI_FILE_NAME_SETUP)
                    logger.Log(Common.Logger.MessageType.NormalLog, "PIS_SERVICE", "Main", "AS400 File Period = " & outStr, "")
                    INI_KEY_SCREEN = "BackupAS400Path"
                    dir = iniObj.GetString(INI_APP_NAME_SETUP, INI_KEY_SCREEN, "C:\AS400\BackupAS400File", INI_FILE_NAME_SETUP)
                    logger.Log(Common.Logger.MessageType.NormalLog, "PIS_SERVICE", "Main", "BackupAS400Path = " & dir, "")
                    'Console.WriteLine("dbPeriod: " & outStr)
                    'Console.WriteLine("Path: " & dir)
                    If deleteAS400File(Integer.Parse(outStr), dir) Then
                        'logger.Log(Common.Logger.MessageType.NormalLog, "PIS_SERVICE", "Main", "Delete AS400 Backup File Success", "")
                        clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_OPERATION, TLogDat.LogLevel.NormalLog, My.Computer.Name, Now, "Delete AS400 Backup File Success", Nothing)
                    Else
                        'logger.Log(Common.Logger.MessageType.ErrorLog, "PIS_SERVICE", "Main", "Delete AS400 Backup File Failed", "")
                        clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_OPERATION, TLogDat.LogLevel.ErrorLog, My.Computer.Name, Now, "Delete AS400 Backup File Failed", Nothing)
                    End If


                    'delete watch File
                    INI_KEY_SCREEN = "dbPeriod"
                    outStr = iniObj.GetString(INI_APP_NAME_SETUP, INI_KEY_SCREEN, "30", INI_FILE_NAME_SETUP)
                    logger.Log(Common.Logger.MessageType.NormalLog, "PIS_SERVICE", "Main", "Manual Import File Period = " & outStr, "")
                    'Dim dir As String
                    INI_KEY_SCREEN = "BackupWatchPath"
                    dir = iniObj.GetString(INI_APP_NAME_SETUP, INI_KEY_SCREEN, "C:\AS400\BackupManualImport", INI_FILE_NAME_SETUP)
                    logger.Log(Common.Logger.MessageType.NormalLog, "PIS_SERVICE", "Main", "BackupWatchPath = " & dir, "")
                    'Console.WriteLine("dbPeriod: " & outStr)
                    'Console.WriteLine("Path: " & dir)
                    If deleteAS400File(Integer.Parse(outStr), dir) Then
                        'logger.Log(Common.Logger.MessageType.NormalLog, "PIS_SERVICE", "Main", "Delete Manual Import Backup File Success", "")
                        clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_OPERATION, TLogDat.LogLevel.NormalLog, My.Computer.Name, Now, "Delete Manual Import Backup File Success", Nothing)
                    Else
                        'logger.Log(Common.Logger.MessageType.ErrorLog, "PIS_SERVICE", "Main", "Delete Manual Import Backup File Failed", "")
                        clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_OPERATION, TLogDat.LogLevel.ErrorLog, My.Computer.Name, Now, "Delete Manual Import Backup File Failed", Nothing)
                    End If

                    'delete local Log File
                    INI_KEY_SCREEN = "dbPeriod"
                    outStr = iniObj.GetString(INI_APP_NAME_SETUP, INI_KEY_SCREEN, "30", INI_FILE_NAME_SETUP)
                    logger.Log(Common.Logger.MessageType.NormalLog, "PIS_SERVICE", "Main", "dbPeriod = " & outStr, "")
                    'INI_KEY_SCREEN = "BackupAS400Path"
                    dir = My.Application.Info.DirectoryPath + "\log\"
                    logger.Log(Common.Logger.MessageType.NormalLog, "PIS_SERVICE", "Main", "Local Log Path = " & dir, "")
                    'Console.WriteLine("dbPeriod: " & outStr)
                    'Console.WriteLine("Path: " & dir)
                    If deleteAS400File(Integer.Parse(outStr), dir) Then
                        'logger.Log(Common.Logger.MessageType.NormalLog, "PIS_SERVICE", "Main", "Delete AS400 Backup File Success", "")
                        clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_OPERATION, TLogDat.LogLevel.NormalLog, My.Computer.Name, Now, "Delete Local Log File Success", Nothing)
                    Else
                        'logger.Log(Common.Logger.MessageType.ErrorLog, "PIS_SERVICE", "Main", "Delete AS400 Backup File Failed", "")
                        clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_OPERATION, TLogDat.LogLevel.ErrorLog, My.Computer.Name, Now, "Delete Local Log File Failed", Nothing)
                    End If

                    logger.Log(Common.Logger.MessageType.NormalLog, "PIS_SERVICE", "Main", "Start call utlrecv", "")
                    Shell(My.Application.Info.DirectoryPath & "\utlrecv.bat", AppWinStyle.Hide, True, 3000)

                    'logger.SystemEnd()
                    'logger.Log(Common.Logger.MessageType.NormalLog, "PIS_SERVICE", "Main", "End of clear old data service", "")
                    clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_OPERATION, TLogDat.LogLevel.NormalLog, My.Computer.Name, Now, "End of scheduled service", Nothing)

                Else
                    'logger.Log(Common.Logger.MessageType.ErrorLog, "PIS_SERVICE", "Main", "Create Batch Files Fail", "")
                    clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_OPERATION, TLogDat.LogLevel.ErrorLog, My.Computer.Name, Now, "Create Batch Files Fail", Nothing)
                End If
            Catch ex As Exception
                logger.Log(Common.Logger.MessageType.ErrorLog, "PIS_SERVICE", "Main", ex.StackTrace, "")
            End Try
        End While
    End Sub

    Private Function deletePro(ByVal expDate As Integer) As Boolean

        Dim strErrorMessage As String
        Try
            Dim dateExp As Date
            Dim dtPro As New ServerDataset.T_Production_DATDataTable
            Dim arrProRows() As ServerDataset.T_Production_DATRow
            Dim taPro As ServerDatasetTableAdapters.T_Production_DATTableAdapter = modDataSource.ta(Of PIS_SERVER.ServerDatasetTableAdapters.T_Production_DATTableAdapter).GetTableAdapter()
            Dim strDelDate As String
            Dim intResult As Integer = 0

            dateExp = Now.Subtract(New TimeSpan(expDate, 0, 0, 0))
            taPro.Fill(dtPro)

            strDelDate = (dateExp.Year.ToString) & dateExp.ToString("MMdd")
            arrProRows = dtPro.Select("ProductionDate < " & strDelDate)

            For Each dr As ServerDataset.T_Production_DATRow In arrProRows
                dr.Delete()
            Next
            intResult = taPro.Update(arrProRows)
            logger.Log(Common.Logger.MessageType.NormalLog, "PIS_SERVICE", "deletePro", "T_Production_DAT " & intResult.ToString & " records deleted.", "")
            Return True
        Catch ex As Exception
            strErrorMessage = ex.Message
            logger.Log(Common.Logger.MessageType.ErrorLog, "PIS_SERVICE", "deletePro", "Exception = " & ex.StackTrace, "")
            Return False
        End Try

    End Function

    Private Function deleteIns(ByVal expDate As Integer) As Boolean

        Dim strErrorMessage As String
        Try
            Dim dateExp As Date
            Dim dtIns As New ServerDataset.T_Instruction_DATDataTable
            Dim arrInsRows() As ServerDataset.T_Instruction_DATRow
            Dim taIns As ServerDatasetTableAdapters.T_Instruction_DATTableAdapter = modDataSource.ta(Of PIS_SERVER.ServerDatasetTableAdapters.T_Instruction_DATTableAdapter).GetTableAdapter()
            Dim strDelDate As String
            Dim intResult As Integer = 0

            dateExp = Now.Subtract(New TimeSpan(expDate, 0, 0, 0))
            taIns.Fill(dtIns)

            strDelDate = (dateExp.Year.ToString) & dateExp.ToString("MMdd")
            arrInsRows = dtIns.Select("ProductionDate < " & strDelDate)

            For Each dr As ServerDataset.T_Instruction_DATRow In arrInsRows
                dr.Delete()
            Next
            intResult = taIns.Update(arrInsRows)
            logger.Log(Common.Logger.MessageType.NormalLog, "PIS_SERVICE", "deleteIns", "T_Instruction_DAT " & intResult.ToString & " records deleted.", "")
            Return True
        Catch ex As Exception
            strErrorMessage = ex.Message
            logger.Log(Common.Logger.MessageType.ErrorLog, "PIS_SERVICE", "deleteIns", "Exception = " & ex.StackTrace, "")
            Return False
        End Try

    End Function

    Private Function deleteLogDat(ByVal expDate As Integer, ByVal logType As Integer) As Boolean

        Dim strErrorMessage As String
        Try
            Dim dateExp As Date
            Dim dtLog As New ServerDataset.T_LOG_DATDataTable
            Dim taLog As ServerDatasetTableAdapters.T_LOG_DATTableAdapter = modDataSource.ta(Of PIS_SERVER.ServerDatasetTableAdapters.T_LOG_DATTableAdapter).GetTableAdapter()
            Dim intResult As Integer = 0

            dateExp = Now.Subtract(New TimeSpan(expDate, 0, 0, 0))
            taLog.FillByDeleteDateAndLogType(dtLog, dateExp, logType)


            For Each dr As ServerDataset.T_LOG_DATRow In dtLog
                dr.Delete()
            Next
            intResult = taLog.Update(dtLog)
            logger.Log(Common.Logger.MessageType.NormalLog, "PIS_SERVICE", "deleteLogDat", "T_LOG_DAT Log Type = " & logType & ", " & intResult.ToString & " records deleted.", "")
            Return True
        Catch ex As Exception
            strErrorMessage = ex.Message
            logger.Log(Common.Logger.MessageType.ErrorLog, "PIS_SERVICE", "deleteLogDat", "Exception = " & ex.StackTrace, "")
            Return False
        End Try

    End Function

    Private Function GetDateTimeValueForSQL(ByVal varDateTime As Object) As String

        Const cstrDateFormatForSQL As String = "/MM/dd HH:mm:ss"

        Dim strText As String
        Dim strResult As String

        strResult = ""

        'If IsDBNull(varDateTime) Then
        If IsDBNull(varDateTime) OrElse IsNothing(varDateTime) Then 'Kong 20091109 : add "OrElse IsNothing(varDateTime)"
            strResult = "NULL"
        Else
            strText = CDate(varDateTime).Year & Format(varDateTime, cstrDateFormatForSQL)
            'strText = Replace(strText, " 12:00:00", "")

            strResult = "CONVERT(datetime, '" & strText & "',111)"
        End If

        Return strResult
    End Function

    Private Function deleteAS400File(ByVal expDate As Integer, ByVal dir As String) As Boolean

        Dim strFileSize As String = ""
        Dim di As New IO.DirectoryInfo(dir)
        Dim fileDate As Date
        Dim res As Integer
        Dim limitDate As Date
        Try
            If di.Exists Then
                limitDate = Now.Subtract(New TimeSpan(expDate, 0, 0, 0))

                Dim aryFi As IO.FileInfo() = di.GetFiles("*.*", SearchOption.AllDirectories)
                Dim fi As IO.FileInfo
                For Each fi In aryFi
                    strFileSize = (Math.Round(fi.Length / 1024)).ToString()
                    Console.WriteLine("File Name: {0}", fi.Name)
                    Console.WriteLine("File Full Name: {0}", fi.FullName)
                    Console.WriteLine("File Size (KB): {0}", strFileSize)
                    Console.WriteLine("File Extension: {0}", fi.Extension)
                    Console.WriteLine("Last Accessed: {0}", fi.LastAccessTime)
                    Console.WriteLine("Read Only: {0}", fi.IsReadOnly.ToString)
                    fileDate = fi.LastWriteTime
                    res = Date.Compare(fileDate, limitDate)
                    If res < 0 Then
                        If Not fi.IsReadOnly Then
                            fi.Delete()
                        End If

                    End If

                Next


                Dim aryDi As IO.DirectoryInfo() = di.GetDirectories("*.*", SearchOption.AllDirectories)
                Dim fileCount As Integer
                For Each direc As IO.DirectoryInfo In aryDi
                    Console.WriteLine("Directory Name: {0}", direc.Name)
                    Console.WriteLine("Directory Full Name: {0}", direc.FullName)
                    Console.WriteLine("Last Accessed: {0}", direc.LastAccessTime)

                    'fileDate = direc.LastWriteTime
                    aryFi = direc.GetFiles("*.*", SearchOption.AllDirectories)
                    fileCount = 0

                    For Each dfi As IO.FileInfo In aryFi
                        fileCount += 1
                    Next

                    'res = Date.Compare(fileDate, limitDate)
                    'If res < 0 Then
                    '    direc.Delete(True)
                    'End If

                    If fileCount = 0 Then
                        Console.WriteLine("No file.")
                        direc.Delete(True)
                    End If

                Next
                Return True
            Else
                logger.Log(Common.Logger.MessageType.ErrorLog, "PIS_SERVICE", "deleteAS400File", "Path: '" & dir & "' don't exist.", "")
                Return False
            End If
        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, "PIS_SERVICE", "deleteAS400File", ex.StackTrace, "")
            Return False
        End Try

    End Function

    Private Function CreateBatchFile() As Boolean
        strHulftCmdPath = iniObj.GetString(INI_APP_NAME_SETUP, INI_KEY_HULFT_CMD_PATH, "C:\HULFT Family\hulft7\binnt", INI_FILE_NAME_SETUP)
        strHulftSaveFile = iniObj.GetString(INI_APP_NAME_SETUP, INI_KEY_HULFT_SAVE_FILE, "C:\AS400\AS400Path\test.txt", INI_FILE_NAME_SETUP)
        strHulftKickFile = iniObj.GetString(INI_APP_NAME_SETUP, INI_KEY_HULFT_KICK_FILE, "C:\kick.txt", INI_FILE_NAME_SETUP)
        strHulftRecvId = iniObj.GetString(INI_APP_NAME_SETUP, INI_KEY_HULFT_RECV_ID, "GHTD001A", INI_FILE_NAME_SETUP)
        strHulftSendId = iniObj.GetString(INI_APP_NAME_SETUP, INI_KEY_HULFT_SEND_ID, "GHTD002N", INI_FILE_NAME_SETUP)
        strAS400Host = iniObj.GetString(INI_APP_NAME_SETUP, INI_KEY_AS400_HOST, "AS400T1", INI_FILE_NAME_SETUP)
        strAppPath = My.Application.Info.DirectoryPath

        Dim bl As Boolean = True
        bl = bl And WriteUtlRecvBat()
        bl = bl And WriteUtlSendBat()
        bl = bl And WriteRecvJobOkBat()
        bl = bl And WriteRecvJobErrorBat()
        bl = bl And WriteSendJobOkBat()
        bl = bl And WriteSendJobErrorBat()

        Return bl
    End Function

    Private Function WriteUtlRecvBat() As Boolean
        Try
            Dim strFilePath As String = strAppPath + "\" + FILE_NAME_UTLRECV

            Dim Writer As New IO.StreamWriter(strFilePath, False)

            Writer.WriteLine("del """ & strHulftSaveFile & """")
            Writer.WriteLine("call """ & strAppPath & "\log-service.exe"" 0 0 ""utlrecv start""")
            Writer.WriteLine("call """ & strHulftCmdPath & "\utlrecv"" -f " & strHulftRecvId & " -h " & strAS400Host & " | """ & strAppPath & "\ReadStdIO.exe""")

            Writer.Close()
            logger.Log(Common.Logger.MessageType.NormalLog, "PIS_SERVICE", "WriteUtlSendBat", "Create " & FILE_NAME_UTLRECV & " success", "")
            Return True
        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, "PIS_SERVICE", "WriteUtlRecvBat", ex.StackTrace, "")
            Return False
        End Try
    End Function

    Private Function WriteUtlSendBat() As Boolean
        Try
            Dim strFilePath As String = strAppPath + "\" + FILE_NAME_UTLSEND

            Dim Writer As New IO.StreamWriter(strFilePath, False)

            Writer.WriteLine("copy NUL """ & strHulftKickFile & """")
            Writer.WriteLine("call """ & strAppPath & "\log-service.exe"" 0 0 ""utlsend start""")
            Writer.WriteLine("call """ & strHulftCmdPath & "\utlsend"" -f " & strHulftSendId & " | """ & strAppPath & "\ReadStdIO.exe""")
            Writer.WriteLine("del """ & strHulftKickFile & """")

            Writer.Close()
            logger.Log(Common.Logger.MessageType.NormalLog, "PIS_SERVICE", "WriteUtlSendBat", "Create " & FILE_NAME_UTLSEND & " success", "")
            Return True
        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, "PIS_SERVICE", "WriteUtlSendBat", ex.StackTrace, "")
            Return False
        End Try
    End Function

    Private Function WriteRecvJobOkBat() As Boolean
        Try
            Dim strFilePath As String = strAppPath + "\" + FILE_NAME_RECV_JOB_OK

            Dim Writer As New IO.StreamWriter(strFilePath, False)

            Writer.WriteLine("call """ & strAppPath & "\log-service.exe"" 0 0 ""utlrecv job ok""")
            Writer.WriteLine("call """ & strAppPath & "\PIS-IMPORT.exe""")

            Writer.Close()
            logger.Log(Common.Logger.MessageType.NormalLog, "PIS_SERVICE", "WriteRecvJobOkBat", "Create " & FILE_NAME_RECV_JOB_OK & " success", "")
            Return True
        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, "PIS_SERVICE", "WriteRecvJobOkBat", ex.StackTrace, "")
            Return False
        End Try
    End Function

    Private Function WriteRecvJobErrorBat() As Boolean
        Try
            Dim strFilePath As String = strAppPath + "\" + FILE_NAME_RECV_JOB_ERROR

            Dim Writer As New IO.StreamWriter(strFilePath, False)

            Writer.WriteLine("call """ & strAppPath & "\log-service.exe"" 0 2 ""utlrecv job error""")

            Writer.Close()
            logger.Log(Common.Logger.MessageType.NormalLog, "PIS_SERVICE", "WriteRecvJobErrorBat", "Create " & FILE_NAME_RECV_JOB_ERROR & " success", "")
            Return True
        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, "PIS_SERVICE", "WriteRecvJobErrorBat", ex.StackTrace, "")
            Return False
        End Try
    End Function

    Private Function WriteSendJobOkBat() As Boolean
        Try
            Dim strFilePath As String = strAppPath + "\" + FILE_NAME_SEND_JOB_OK

            Dim Writer As New IO.StreamWriter(strFilePath, False)

            Writer.WriteLine("call """ & strAppPath & "\log-service.exe"" 0 0 ""utlsend job ok""")

            Writer.Close()
            logger.Log(Common.Logger.MessageType.NormalLog, "PIS_SERVICE", "WriteSendJobOkBat", "Create " & FILE_NAME_SEND_JOB_OK & " success", "")
            Return True
        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, "PIS_SERVICE", "WriteSendJobOkBat", ex.StackTrace, "")
            Return False
        End Try
    End Function

    Private Function WriteSendJobErrorBat() As Boolean
        Try
            Dim strFilePath As String = strAppPath + "\" + FILE_NAME_SEND_JOB_ERROR

            Dim Writer As New IO.StreamWriter(strFilePath, False)

            Writer.WriteLine("call """ & strAppPath & "\log-service.exe"" 0 2 ""utlsend job error""")

            Writer.Close()
            logger.Log(Common.Logger.MessageType.NormalLog, "PIS_SERVICE", "WriteSendJobErrorBat", "Create " & FILE_NAME_SEND_JOB_ERROR & " success", "")
            Return True
        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, "PIS_SERVICE", "WriteSendJobErrorBat", ex.StackTrace, "")
            Return False
        End Try
    End Function
End Module
