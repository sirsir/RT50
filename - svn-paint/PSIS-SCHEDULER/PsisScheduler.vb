Public Class PsisScheduler

#Region "Constant"
    Private Const LOG_FILE_NAME_SUFFIX As String = "Service"
    Private Const FILE_NAME_UTL_RECV As String = "utlrecv.bat"
    Private Const FILE_NAME_RECV_OK As String = "recv_jobok.bat"
    Private Const FILE_NAME_RECV_ERROR As String = "recv_joberror.bat"
    Private Const FILE_NAME_UTL_SEND As String = "utlsend.bat"
    Private Const FILE_NAME_SEND_OK As String = "send_jobok.bat"
    Private Const FILE_NAME_SEND_ERROR As String = "send_joberror.bat"
    Private Const FILE_NAME_EXP_SEND As String = "expsend.bat"
    Private Const FILE_NAME_EXP_SEND_OK As String = "expsend_jobok.bat"
    Private Const FILE_NAME_EXP_SEND_ERROR As String = "expsend_joberror.bat"
#End Region

#Region "Attribute"
    Private m_clsDbLog As New clsDBLogger
    Private m_clsLog As New clsLogger
    Private m_strAppPath As String
    Private m_strHulftCmdPath As String
    Private m_strAS400Host As String
#End Region

#Region "Event"

    Protected Overrides Sub OnStart(ByVal args() As String)
        Me.m_clsLog.Log(Common.clsLogger.MessageType.NormalLog, "PSIS_SCHEDULER", "MAIN", "PSIS-SCHEDULER Start", "", LOG_FILE_NAME_SUFFIX)
        bgWorker.WorkerSupportsCancellation = True
        bgWorker.RunWorkerAsync()
    End Sub

    Protected Overrides Sub OnStop()
        bgWorker.CancelAsync()
        Me.m_clsLog.Log(Common.clsLogger.MessageType.NormalLog, "PSIS_SCHEDULER", "Main", "PSIS-SCHEDULER Stop", "", LOG_FILE_NAME_SUFFIX)
    End Sub

    Private Sub bgWorker_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgWorker.DoWork
        Try
            modIni.LoadIni(enuAppType.service)
            Me.m_strHulftCmdPath = modIni.HulftCommandPath
            Me.m_strAS400Host = modIni.AS400Host
            Me.m_strAppPath = My.Application.Info.DirectoryPath
            Me.Execute()
        Catch ex As Exception
            Me.m_clsLog.Log(clsLogger.MessageType.ErrorLog, "PSIS_SCHEDULER", "Main", ex.Message, ex.StackTrace, LOG_FILE_NAME_SUFFIX)
        End Try
    End Sub

#End Region

#Region "Method"

    Private Sub Execute()
        Dim strScheduleTime As String = ""
        Dim strReadDir As String
        Dim intReadPeriod As Integer
        Dim intHr = 0
        Dim intMin = 0

        If CreateBatchFile() Then
            Me.m_clsLog.Log(clsLogger.MessageType.NormalLog, "PSIS_SCHEDULER", "Main", "Create Batch Files At Service Start Success", "", LOG_FILE_NAME_SUFFIX)
        Else
            Me.m_clsLog.Log(clsLogger.MessageType.ErrorLog, "PSIS_SCHEDULER", "Main", "Create Batch Files At Service Start Failed", "", LOG_FILE_NAME_SUFFIX)
        End If

        While True

            Threading.Thread.Sleep(TimeSpan.FromMinutes(1))

            'Update Schedule Time
            strScheduleTime = modIni.ScheduleTime
            intHr = CInt(strScheduleTime.Substring(0, 2))
            intMin = CInt(strScheduleTime.Substring(2, 2))
            Me.m_clsLog.Log(clsLogger.MessageType.NormalLog, "PSIS_SCHEDULER", "Main", "Scheduled time read: " & intHr & ":" & intMin, "", LOG_FILE_NAME_SUFFIX)

            If Now.Hour <> intHr Or Now.Minute <> intMin Then Continue While ' Get hour from ini

            Me.m_clsLog.Log(clsLogger.MessageType.NormalLog, "PSIS_SCHEDULER", "Main", "Start Working at Scheduled Time", "", LOG_FILE_NAME_SUFFIX)

            Try
                If CreateBatchFile() Then
                    Me.m_clsLog.Log(clsLogger.MessageType.NormalLog, "PSIS_SCHEDULER", "Main", "Create Batch Files Success", "", LOG_FILE_NAME_SUFFIX)

                    strReadDir = modIni.BackupAS400Path
                    intReadPeriod = modIni.AS400BackupFilePeriod
                    m_clsLog.Log(clsLogger.MessageType.NormalLog, "PSIS_SCHEDULER", "Main", "Delete back up AS400 File start", "", LOG_FILE_NAME_SUFFIX)
                    If Me.deleteFile(intReadPeriod, strReadDir) Then
                        m_clsLog.Log(clsLogger.MessageType.NormalLog, "PSIS_SCHEDULER", "Main", "Delete back up AS400 File success", "", LOG_FILE_NAME_SUFFIX)
                    Else
                        m_clsLog.Log(clsLogger.MessageType.ErrorLog, "PSIS_SCHEDULER", "Main", "Delete back up AS400 File fail", "", LOG_FILE_NAME_SUFFIX)
                    End If

                    strReadDir = modIni.BackupWatchPath
                    m_clsLog.Log(clsLogger.MessageType.NormalLog, "PSIS_SCHEDULER", "Main", "Delete back up import File start", "", LOG_FILE_NAME_SUFFIX)
                    If Me.deleteFile(intReadPeriod, strReadDir) Then
                        m_clsLog.Log(clsLogger.MessageType.NormalLog, "PSIS_SCHEDULER", "Main", "Delete back up import File success", "", LOG_FILE_NAME_SUFFIX)
                    Else
                        m_clsLog.Log(clsLogger.MessageType.ErrorLog, "PSIS_SCHEDULER", "Main", "Delete back up import File fail", "", LOG_FILE_NAME_SUFFIX)
                    End If

                    strReadDir = modIni.BackupExportPath
                    m_clsLog.Log(clsLogger.MessageType.NormalLog, "PSIS_SCHEDULER", "Main", "Delete back up export File start", "", LOG_FILE_NAME_SUFFIX)
                    If Me.deleteFile(intReadPeriod, strReadDir) Then
                        m_clsLog.Log(clsLogger.MessageType.NormalLog, "PSIS_SCHEDULER", "Main", "Delete back up export File success", "", LOG_FILE_NAME_SUFFIX)
                    Else
                        m_clsLog.Log(clsLogger.MessageType.ErrorLog, "PSIS_SCHEDULER", "Main", "Delete back up export File fail", "", LOG_FILE_NAME_SUFFIX)
                    End If

                    strReadDir = My.Application.Info.DirectoryPath + "\log\"
                    intReadPeriod = modIni.LocalLogPeriod
                    m_clsLog.Log(clsLogger.MessageType.NormalLog, "PSIS_SCHEDULER", "Main", "Delete Local Log File start", "", LOG_FILE_NAME_SUFFIX)
                    If Me.deleteFile(intReadPeriod, strReadDir) Then
                        m_clsLog.Log(clsLogger.MessageType.NormalLog, "PSIS_SCHEDULER", "Main", "Delete Local Log File success", "", LOG_FILE_NAME_SUFFIX)
                    Else
                        m_clsLog.Log(clsLogger.MessageType.ErrorLog, "PSIS_SCHEDULER", "Main", "Delete Local Log File fail", "", LOG_FILE_NAME_SUFFIX)
                    End If

                    intReadPeriod = modIni.DBPeriod
                    m_clsLog.Log(clsLogger.MessageType.NormalLog, "PSIS_SCHEDULER", "Main", "Delete T_PRODUCTION_DAT table start", "", LOG_FILE_NAME_SUFFIX)
                    If Me.deleteTProductionDat(intReadPeriod) Then
                        m_clsLog.Log(clsLogger.MessageType.NormalLog, "PSIS_SCHEDULER", "Main", "Delete T_PRODUCTION_DAT table success", "", LOG_FILE_NAME_SUFFIX)
                    Else
                        m_clsLog.Log(clsLogger.MessageType.ErrorLog, "PSIS_SCHEDULER", "Main", "Delete T_PRODUCTION_DAT table fail", "", LOG_FILE_NAME_SUFFIX)
                    End If

                    'm_clsLog.Log(clsLogger.MessageType.NormalLog, "PSIS_SCHEDULER", "Main", "Delete T_WBS_ON table start", "", LOG_FILE_NAME_SUFFIX)
                    'If Me.deleteTWbsOn() Then
                    '    m_clsLog.Log(clsLogger.MessageType.NormalLog, "PSIS_SCHEDULER", "Main", "Delete T_WBS_ON table success", "", LOG_FILE_NAME_SUFFIX)
                    'Else
                    '    m_clsLog.Log(clsLogger.MessageType.ErrorLog, "PSIS_SCHEDULER", "Main", "Delete T_WBS_ON table fail", "", LOG_FILE_NAME_SUFFIX)
                    'End If

                    intReadPeriod = modIni.AS400Period
                    m_clsLog.Log(clsLogger.MessageType.NormalLog, "PSIS_SCHEDULER", "Main", "Delete T_LOG_DAT(AS400 Log) table start", "", LOG_FILE_NAME_SUFFIX)
                    If Me.deleteTLogDat(intReadPeriod, DB_LOG_TYPE_AS400) Then
                        m_clsLog.Log(clsLogger.MessageType.NormalLog, "PSIS_SCHEDULER", "Main", "Delete T_LOG_DAT(AS400 Log) table success", "", LOG_FILE_NAME_SUFFIX)
                    Else
                        m_clsLog.Log(clsLogger.MessageType.ErrorLog, "PSIS_SCHEDULER", "Main", "Delete T_LOG_DAT(AS400 Log) table fail", "", LOG_FILE_NAME_SUFFIX)
                    End If

                    intReadPeriod = modIni.PLCPeriod
                    m_clsLog.Log(clsLogger.MessageType.NormalLog, "PSIS_SCHEDULER", "Main", "Delete T_LOG_DAT(PLC Log) table start", "", LOG_FILE_NAME_SUFFIX)
                    If Me.deleteTLogDat(intReadPeriod, DB_LOG_TYPE_PLC) Then
                        m_clsLog.Log(clsLogger.MessageType.NormalLog, "PSIS_SCHEDULER", "Main", "Delete T_LOG_DAT(PLC Log) table success", "", LOG_FILE_NAME_SUFFIX)
                    Else
                        m_clsLog.Log(clsLogger.MessageType.ErrorLog, "PSIS_SCHEDULER", "Main", "Delete T_LOG_DAT(PLC Log) table fail", "", LOG_FILE_NAME_SUFFIX)
                    End If

                    intReadPeriod = modIni.LogPeriod
                    m_clsLog.Log(clsLogger.MessageType.NormalLog, "PSIS_SCHEDULER", "Main", "Delete T_LOG_DAT(Operation Log) table start", "", LOG_FILE_NAME_SUFFIX)
                    If Me.deleteTLogDat(intReadPeriod, DB_LOG_TYPE_OPERATION) Then
                        m_clsLog.Log(clsLogger.MessageType.NormalLog, "PSIS_SCHEDULER", "Main", "Delete T_LOG_DAT(Operation Log) table success", "", LOG_FILE_NAME_SUFFIX)
                    Else
                        m_clsLog.Log(clsLogger.MessageType.ErrorLog, "PSIS_SCHEDULER", "Main", "Delete T_LOG_DAT(Operation Log) table fail", "", LOG_FILE_NAME_SUFFIX)
                    End If

                    m_clsLog.Log(clsLogger.MessageType.NormalLog, "PSIS_SCHEDULER", "Main", "Delete T_LOG_DAT(Debug Log) table start", "", LOG_FILE_NAME_SUFFIX)
                    If Me.deleteTLogDat(intReadPeriod, DB_LOG_TYPE_DEBUG) Then
                        m_clsLog.Log(clsLogger.MessageType.NormalLog, "PSIS_SCHEDULER", "Main", "Delete T_LOG_DAT(Debug Log) table success", "", LOG_FILE_NAME_SUFFIX)
                    Else
                        m_clsLog.Log(clsLogger.MessageType.ErrorLog, "PSIS_SCHEDULER", "Main", "Delete T_LOG_DAT(Debug Log) table fail", "", LOG_FILE_NAME_SUFFIX)
                    End If

                    m_clsLog.Log(clsLogger.MessageType.NormalLog, "PSIS_SCHEDULER", "Main", "Start call utlrecv", "", LOG_FILE_NAME_SUFFIX)
                    Shell(My.Application.Info.DirectoryPath & "\utlrecv.bat", AppWinStyle.Hide, True, 3000)
                Else
                    Me.m_clsLog.Log(clsLogger.MessageType.ErrorLog, "PSIS_SCHEDULER", "Main", "Create Batch Files Failed", "", LOG_FILE_NAME_SUFFIX)
                End If
            Catch ex As Exception
                Me.m_clsLog.Log(clsLogger.MessageType.ErrorLog, "PSIS_SCHEDULER", "Main", ex.Message, ex.StackTrace, LOG_FILE_NAME_SUFFIX)
            End Try
        End While
    End Sub

    Private Function CreateBatchFile() As Boolean
        Dim bl As Boolean = True
        bl = bl And WriteUtlRecvBat()
        bl = bl And WriteUtlSendBat()
        bl = bl And WriteRecvJobOkBat()
        bl = bl And WriteRecvJobErrorBat()
        bl = bl And WriteSendJobOkBat()
        bl = bl And WriteSendJobErrorBat()
        bl = bl And WriteExpSendBat()
        bl = bl And WriteExpSendJobOkBat()
        bl = bl And WriteExpSendJobErrorBat()

        Return bl
    End Function

    Private Function WriteUtlRecvBat() As Boolean
        Dim strHulftSaveFile As String
        Dim strFilePath As String
        Dim strHulftRecvId As String

        Try
            strFilePath = Me.m_strAppPath + "\" + FILE_NAME_UTL_RECV
            strHulftSaveFile = modIni.HulftSaveFileName
            strHulftRecvId = modIni.HulftReceiveId

            Dim Writer As New IO.StreamWriter(strFilePath, False)

            Writer.WriteLine("del """ & strHulftSaveFile & """")
            Writer.WriteLine("call """ & Me.m_strAppPath & "\log-service.exe"" " & DB_LOG_CODE_N_UTL_RECV_START)
            Writer.WriteLine("call """ & Me.m_strHulftCmdPath & "\utlrecv"" -f " & strHulftRecvId & " -h " & Me.m_strAS400Host & " | """ & Me.m_strAppPath & "\ReadStdIO.exe""")

            Writer.Close()
            Me.m_clsLog.Log(Common.clsLogger.MessageType.NormalLog, "PSIS_SCHEDULER", "WriteUtlSendBat", "Create " & FILE_NAME_UTL_RECV & " success", "", LOG_FILE_NAME_SUFFIX)
            Return True
        Catch ex As Exception
            Me.m_clsLog.Log(Common.clsLogger.MessageType.ErrorLog, "PSIS_SCHEDULER", "WriteUtlRecvBat", ex.StackTrace, "", LOG_FILE_NAME_SUFFIX)
            Return False
        End Try
    End Function

    Private Function WriteUtlSendBat() As Boolean
        Dim strFilePath As String
        Dim strHulftKickFile As String
        Dim strHulftSendId As String

        Try
            strFilePath = Me.m_strAppPath + "\" + FILE_NAME_UTL_SEND
            strHulftKickFile = modIni.HulftKickFile
            strHulftSendId = modIni.HulftSendId

            Dim Writer As New IO.StreamWriter(strFilePath, False)

            Writer.WriteLine("copy NUL """ & strHulftKickFile & """")
            Writer.WriteLine("call """ & Me.m_strAppPath & "\log-service.exe"" " & DB_LOG_CODE_N_UTL_SEND_START)
            Writer.WriteLine("call """ & Me.m_strHulftCmdPath & "\utlsend"" -f " & strHulftSendId & " | """ & Me.m_strAppPath & "\ReadStdIO.exe""")
            Writer.WriteLine("del """ & strHulftKickFile & """")

            Writer.Close()
            Me.m_clsLog.Log(Common.clsLogger.MessageType.NormalLog, "PSIS_SCHEDULER", "WriteUtlSendBat", "Create " & FILE_NAME_UTL_SEND & " success", "", LOG_FILE_NAME_SUFFIX)
            Return True
        Catch ex As Exception
            Me.m_clsLog.Log(Common.clsLogger.MessageType.ErrorLog, "PSIS_SCHEDULER", "WriteUtlSendBat", ex.StackTrace, "", LOG_FILE_NAME_SUFFIX)
            Return False
        End Try
    End Function

    Private Function WriteRecvJobOkBat() As Boolean
        Dim strFilePath As String

        Try
            strFilePath = Me.m_strAppPath + "\" + FILE_NAME_RECV_OK

            Dim Writer As New IO.StreamWriter(strFilePath, False)

            Writer.WriteLine("call """ & Me.m_strAppPath & "\log-service.exe"" " & DB_LOG_CODE_N_UTL_RECV_JOB_OK)
            Writer.WriteLine("call """ & Me.m_strAppPath & "\PSIS-IMPORT.exe""")

            Writer.Close()
            Me.m_clsLog.Log(Common.clsLogger.MessageType.NormalLog, "PSIS_SCHEDULER", "WriteRecvJobOkBat", "Create " & FILE_NAME_RECV_OK & " success", "", LOG_FILE_NAME_SUFFIX)
            Return True
        Catch ex As Exception
            Me.m_clsLog.Log(Common.clsLogger.MessageType.ErrorLog, "PSIS_SCHEDULER", "WriteRecvJobOkBat", ex.StackTrace, "", LOG_FILE_NAME_SUFFIX)
            Return False
        End Try
    End Function

    Private Function WriteRecvJobErrorBat() As Boolean
        Dim strFilePath As String

        Try
            strFilePath = Me.m_strAppPath + "\" + FILE_NAME_RECV_ERROR

            Dim Writer As New IO.StreamWriter(strFilePath, False)

            Writer.WriteLine("call """ & Me.m_strAppPath & "\log-service.exe"" " & DB_LOG_CODE_E_UTL_RECV_JOB_ERROR)

            Writer.Close()
            Me.m_clsLog.Log(Common.clsLogger.MessageType.NormalLog, "PSIS_SCHEDULER", "WriteRecvJobErrorBat", "Create " & FILE_NAME_RECV_ERROR & " success", "", LOG_FILE_NAME_SUFFIX)
            Return True
        Catch ex As Exception
            Me.m_clsLog.Log(Common.clsLogger.MessageType.ErrorLog, "PSIS_SCHEDULER", "WriteRecvJobErrorBat", ex.StackTrace, "", LOG_FILE_NAME_SUFFIX)
            Return False
        End Try
    End Function

    Private Function WriteSendJobOkBat() As Boolean
        Dim strFilePath As String

        Try
            strFilePath = Me.m_strAppPath + "\" + FILE_NAME_SEND_OK

            Dim Writer As New IO.StreamWriter(strFilePath, False)

            Writer.WriteLine("call """ & Me.m_strAppPath & "\log-service.exe"" " & DB_LOG_CODE_N_UTL_SEND_JOB_OK)

            Writer.Close()
            Me.m_clsLog.Log(Common.clsLogger.MessageType.NormalLog, "PSIS_SCHEDULER", "WriteSendJobOkBat", "Create " & FILE_NAME_SEND_OK & " success", "", LOG_FILE_NAME_SUFFIX)
            Return True
        Catch ex As Exception
            Me.m_clsLog.Log(Common.clsLogger.MessageType.ErrorLog, "PSIS_SCHEDULER", "WriteSendJobOkBat", ex.StackTrace, "", LOG_FILE_NAME_SUFFIX)
            Return False
        End Try
    End Function

    Private Function WriteSendJobErrorBat() As Boolean
        Dim strFilePath As String

        Try
            strFilePath = Me.m_strAppPath + "\" + FILE_NAME_SEND_ERROR

            Dim Writer As New IO.StreamWriter(strFilePath, False)

            Writer.WriteLine("call """ & Me.m_strAppPath & "\log-service.exe"" " & DB_LOG_CODE_E_UTL_SEND_JOB_ERROR)

            Writer.Close()
            Me.m_clsLog.Log(Common.clsLogger.MessageType.NormalLog, "PSIS_SCHEDULER", "WriteSendJobErrorBat", "Create " & FILE_NAME_SEND_ERROR & " success", "", LOG_FILE_NAME_SUFFIX)
            Return True
        Catch ex As Exception
            Me.m_clsLog.Log(Common.clsLogger.MessageType.ErrorLog, "PSIS_SCHEDULER", "WriteSendJobErrorBat", ex.StackTrace, "", LOG_FILE_NAME_SUFFIX)
            Return False
        End Try
    End Function

    Private Function WriteExpSendBat() As Boolean
        Dim strFilePath As String
        Dim strHulftExportFile As String
        Dim strHulftExportId As String
        Dim strExportTimeOut As String
        Dim strExportWaitTime As String
        Dim strExportPath As String
        Dim strBackupExportPath As String
        Dim strBackupFileName As String

        Try
            strFilePath = Me.m_strAppPath + "\" + FILE_NAME_EXP_SEND
            strHulftExportFile = modIni.ExportFileFullPath
            strHulftExportId = modIni.HulftExportId
            strExportTimeOut = modIni.ExportFileTimeOut
            strBackupExportPath = modIni.BackupExportPath
            strExportWaitTime = modIni.ExportFileWaitingTime
            strExportPath = modIni.ExportFilePath
            strBackupFileName = strHulftExportFile.Substring(strHulftExportFile.LastIndexOf("\") + 1)

            Dim Writer As New IO.StreamWriter(strFilePath, False)

            Writer.WriteLine("@echo off")
            Writer.WriteLine("call """ & Me.m_strAppPath & "\log-service.exe"" " & DB_LOG_CODE_N_EXP_SEND_START)
            Writer.WriteLine("call """ & Me.m_strHulftCmdPath & "\utlsend"" -f " & strHulftExportId & " | """ & Me.m_strAppPath & "\ReadStdIO.exe""")
            Writer.WriteLine("ping 1.1.1.1 -n 1 -w " & strExportTimeOut & " > NUL")
            Writer.WriteLine("IF NOT EXIST " & strHulftExportFile & " exit /B 1")
            Writer.WriteLine("call """ & Me.m_strHulftCmdPath & "\utlsend"" -f " & strHulftExportId & " | """ & Me.m_strAppPath & "\ReadStdIO.exe""")
            Writer.WriteLine("ping 1.1.1.1 -n 1 -w " & strExportWaitTime & " > NUL")
            Writer.WriteLine("IF NOT EXIST " & strHulftExportFile & " exit /B 1")
            Writer.WriteLine("for /f ""delims="" %%a in ('cscript //nologo """ & Me.m_strAppPath & "\..\tool\GetCurrentDate.vbs"" 1') do (")
            Writer.WriteLine("set m_date=%%a)")
            Writer.WriteLine("IF NOT EXIST " & strBackupExportPath & "\%m_date% mkdir " & strBackupExportPath & "\%m_date%")
            Writer.WriteLine("for /f ""delims="" %%a in ('cscript //nologo """ & Me.m_strAppPath & "\..\tool\GetCurrentDate.vbs"" 2') do (")
            Writer.WriteLine("set baktime=%%a)")
            Writer.WriteLine("set bakfilename=%baktime%_" & strBackupFileName)
            Writer.WriteLine("ren " & strHulftExportFile & " %bakfilename%")
            Writer.WriteLine("move /y """ & strExportPath & "\%bakfilename%"" """ & strBackupExportPath & "\%m_date%\""")

            Writer.Close()
            Me.m_clsLog.Log(Common.clsLogger.MessageType.NormalLog, "PSIS_SCHEDULER", "WriteExpSendBat", "Create " & FILE_NAME_UTL_SEND & " success", "", LOG_FILE_NAME_SUFFIX)
            Return True
        Catch ex As Exception
            Me.m_clsLog.Log(Common.clsLogger.MessageType.ErrorLog, "PSIS_SCHEDULER", "WriteExpSendBat", ex.StackTrace, "", LOG_FILE_NAME_SUFFIX)
            Return False
        End Try
    End Function

    Private Function WriteExpSendJobOkBat() As Boolean
        Dim strFilePath As String
        Dim strHulftExportFile As String
        Dim strExportPath As String
        Dim strBackupExportPath As String
        Dim strBackupFileName As String

        Try
            strFilePath = Me.m_strAppPath + "\" + FILE_NAME_EXP_SEND_OK
            strHulftExportFile = modIni.ExportFileFullPath
            strExportPath = modIni.ExportFilePath
            strBackupExportPath = modIni.BackupExportPath
            strBackupFileName = strHulftExportFile.Substring(strHulftExportFile.LastIndexOf("\") + 1)

            Dim Writer As New IO.StreamWriter(strFilePath, False)

            Writer.WriteLine("@echo off")
            Writer.WriteLine("call """ & Me.m_strAppPath & "\log-service.exe"" " & DB_LOG_CODE_N_EXP_SEND_JOB_OK)
            Writer.WriteLine("IF NOT EXIST " & strHulftExportFile & " exit /B 1")
            Writer.WriteLine("for /f ""delims="" %%a in ('cscript //nologo """ & Me.m_strAppPath & "\..\tool\GetCurrentDate.vbs"" 1') do (")
            Writer.WriteLine("set m_date=%%a)")
            Writer.WriteLine("IF NOT EXIST " & strBackupExportPath & "\%m_date% mkdir " & strBackupExportPath & "\%m_date%")
            Writer.WriteLine("for /f ""delims="" %%a in ('cscript //nologo """ & Me.m_strAppPath & "\..\tool\GetCurrentDate.vbs"" 2') do (")
            Writer.WriteLine("set baktime=%%a)")
            Writer.WriteLine("set bakfilename=%baktime%_" & strBackupFileName)
            Writer.WriteLine("ren " & strHulftExportFile & " %bakfilename%")
            Writer.WriteLine("move /y """ & strExportPath & "\%bakfilename%"" """ & strBackupExportPath & "\%m_date%\""")

            Writer.Close()
            Me.m_clsLog.Log(Common.clsLogger.MessageType.NormalLog, "PSIS_SCHEDULER", "WriteExpSendJobOkBat", "Create " & FILE_NAME_SEND_OK & " success", "", LOG_FILE_NAME_SUFFIX)
            Return True
        Catch ex As Exception
            Me.m_clsLog.Log(Common.clsLogger.MessageType.ErrorLog, "PSIS_SCHEDULER", "WriteExpSendJobOkBat", ex.StackTrace, "", LOG_FILE_NAME_SUFFIX)
            Return False
        End Try
    End Function

    Private Function WriteExpSendJobErrorBat() As Boolean
        Dim strFilePath As String

        Try
            strFilePath = Me.m_strAppPath + "\" + FILE_NAME_EXP_SEND_ERROR

            Dim Writer As New IO.StreamWriter(strFilePath, False)

            Writer.WriteLine("call """ & Me.m_strAppPath & "\log-service.exe"" " & DB_LOG_CODE_E_EXP_SEND_JOB_ERROR)

            Writer.Close()
            Me.m_clsLog.Log(Common.clsLogger.MessageType.NormalLog, "PSIS_SCHEDULER", "WriteExpSendJobErrorBat", "Create " & FILE_NAME_SEND_ERROR & " success", "", LOG_FILE_NAME_SUFFIX)
            Return True
        Catch ex As Exception
            Me.m_clsLog.Log(Common.clsLogger.MessageType.ErrorLog, "PSIS_SCHEDULER", "WriteExpSendJobErrorBat", ex.StackTrace, "", LOG_FILE_NAME_SUFFIX)
            Return False
        End Try
    End Function

    Private Function deleteFile(ByVal period As Integer, ByVal dir As String) As Boolean

        Dim strFileSize As String = ""
        Dim di As New IO.DirectoryInfo(dir)
        Dim fileDate As Date
        Dim res As Integer
        Dim limitDate As Date
        Try
            If di.Exists Then
                limitDate = Now.Subtract(New TimeSpan(period, 0, 0, 0))

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

                    aryFi = direc.GetFiles("*.*", SearchOption.AllDirectories)
                    fileCount = 0

                    For Each dfi As IO.FileInfo In aryFi
                        fileCount += 1
                    Next

                    If fileCount = 0 Then
                        Console.WriteLine("No file.")
                        direc.Delete(True)
                    End If

                Next
                Return True
            Else
                m_clsLog.Log(clsLogger.MessageType.ErrorLog, "PSIS_SCHEDULER", "deleteAS400File", "Path: '" & dir & "' don't exist.", "", LOG_FILE_NAME_SUFFIX)
                Return False
            End If
        Catch ex As Exception
            m_clsLog.Log(clsLogger.MessageType.ErrorLog, "PSIS_SCHEDULER", "deleteAS400File", ex.StackTrace, "", LOG_FILE_NAME_SUFFIX)
            Return False
        End Try
    End Function

    Private Function deleteTLogDat(ByVal period As Integer, ByVal logType As Integer) As Boolean
        Try
            Dim dateExp As Date
            Dim taLog As New dsPAINTTableAdapters.taLOG_DAT
            Dim intResult As Integer = 0

            dateExp = Now.Subtract(New TimeSpan(period, 0, 0, 0))
            intResult = taLog.DeleteOldLogByLogTypeAndDate(logType, dateExp)

            m_clsLog.Log(Common.clsLogger.MessageType.NormalLog, "PSIS_SCHEDULER", "deleteTLogDat", "T_LOG_DAT Log Type = " & logType & ", " & intResult.ToString & " records deleted.", "", LOG_FILE_NAME_SUFFIX)
            Return True
        Catch ex As Exception
            m_clsLog.Log(Common.clsLogger.MessageType.ErrorLog, "PSIS_SCHEDULER", "deleteTLogDat", ex.Message, ex.StackTrace, LOG_FILE_NAME_SUFFIX)
            Return False
        End Try
    End Function

    Private Function deleteTProductionDat(ByVal period As Integer) As Boolean
        Try
            Dim taProdDat As New dsPAINTTableAdapters.taPRODUCTION_DAT
            Dim intResult As Integer = 0

            intResult = taProdDat.DeleteOldDataByDate(period)

            m_clsLog.Log(Common.clsLogger.MessageType.NormalLog, "PSIS_SCHEDULER", "deleteTProductionDat", "T_PRODUCTION_DAT, " & intResult.ToString & " records deleted.", "", LOG_FILE_NAME_SUFFIX)
            Return True
        Catch ex As Exception
            m_clsLog.Log(Common.clsLogger.MessageType.ErrorLog, "PSIS_SCHEDULER", "deleteTProductionDat", ex.Message, ex.StackTrace, LOG_FILE_NAME_SUFFIX)
            Return False
        End Try
    End Function

    'Private Function deleteTWbsOn() As Boolean
    '    Try
    '        Dim taWbsOn As New dsPAINTTableAdapters.taWBS_ON
    '        Dim intResult As Integer = 0

    '        intResult = taWbsOn.DeleteWbsAfterClearProductionDat()

    '        m_clsLog.Log(Common.clsLogger.MessageType.NormalLog, "PSIS_SCHEDULER", "deleteTWbsOn", "T_WBS_ON, " & intResult.ToString & " records deleted.", "", LOG_FILE_NAME_SUFFIX)
    '        Return True
    '    Catch ex As Exception
    '        m_clsLog.Log(Common.clsLogger.MessageType.ErrorLog, "PSIS_SCHEDULER", "deleteTWbsOn", ex.Message, ex.StackTrace, LOG_FILE_NAME_SUFFIX)
    '        Return False
    '    End Try
    'End Function

#End Region

End Class
