Public Module modIni

#Region "Constant"
    Private Const INI_FILE_NAME As String = "PSIS-Setting.ini"

    'Setting
    Private Const INI_SECTION_SETTING As String = "Setting"
    Private Const INI_KEY_SERVER_IP As String = "ServerIp"
    Private Const INI_KEY_SERVER_NODE As String = "ServerNode"
    Private Const INI_KEY_NET As String = "Net"
    Private Const INI_KEY_NODE As String = "Node"
    Private Const INI_KEY_UNIT As String = "Unit"
    Private Const INI_KEY_SERVER_STATUS_ADDRESS As String = "ServerStatusAddress"
    Private Const INI_KEY_WATCH_PATH As String = "WatchPath"
    Private Const INI_KEY_BACKUP_WATCH_PATH As String = "BackupWatchPath"
    Private Const INI_KEY_AS400_PATH As String = "AS400Path"
    Private Const INI_KEY_BACKUP_AS400_PATH As String = "BackupAS400Path"
    Private Const INI_KEY_AS400_PERIOD As String = "AS400Period"
    Private Const INI_KEY_PLC_PERIOD As String = "PLCPeriod"
    Private Const INI_KEY_LOG_PERIOD As String = "LogPeriod"
    Private Const INI_KEY_NUMBER_OF_RETRIES As String = "NumberOfRetries"
    Private Const INI_KEY_DISPLAY_ROW_COUNT As String = "DisplayRowCount"
    Private Const INI_KEY_DB_CONNECTION_STRING As String = "DBStringConnection"
    Private Const INI_KEY_MAX_SKIT_NO As String = "MaxSkitNo"
    Private Const INI_KEY_EXPORT_FILE_FULL_PATH As String = "HulftExportFile"
    Private Const INI_KEY_EXPORT_FILE_PATH As String = "ExportPath"
    Private Const INI_KEY_BACKUP_EXPORT_PATH As String = "BackupExportPath"
    Private Const INI_KEY_DB_DATA_PERIOD As String = "dbPeriod"
    Private Const INI_KEY_AS400_BACKUP_FILE_PERIOD As String = "AS400BackupFilePeriod"
    Private Const INI_KEY_LOCAL_LOG_PERIOD As String = "LocalLogPeriod"
    Private Const INI_KEY_SCHEDULER_TIME As String = "ScheduleTime"
    Private Const INI_KEY_HULFT_CMD_PATH As String = "HulftCmdPath"
    Private Const INI_KEY_HULFT_KICK_FILE As String = "HulftKickFile"
    Private Const INI_KEY_HULFT_RECV_ID As String = "HulftRecvId"
    Private Const INI_KEY_HULFT_SEND_ID As String = "HulftSendId"
    Private Const INI_KEY_HULFT_EXPORT_ID As String = "HulftExportId"
    Private Const INI_KEY_AS400_HOST As String = "AS400Host"
    Private Const INI_KEY_HULFT_SAVE_FILE As String = "HulftSaveFile"
    Private Const INI_KEY_EXPORT_TIME_OUT As String = "ExportTimeOut"
    Private Const INI_KEY_EXPORT_WAIT_TIME As String = "ExportWaitTime"
    Private Const INI_KEY_ERROR_EXPORT_PATH As String = "ErrorExportPath"
    Private Const INI_KEY_ERROR_EXPORT_FILE As String = "ErrorExportFile"
    Private Const INI_KEY_EXPORT_SLEEP As String = "ExportSleep"
#End Region

#Region "Enumerator"
    Public Enum enuAppType
        server
        client
        service
    End Enum
#End Region

#Region "Attribute"
    Private m_objIniFile As New clsIniFile

    Private m_strWatchPath As String
    Private m_strBackupWatchPath As String
    Private m_strAs400Path As String
    Private m_strBackupAs400Path As String
    Private m_intAS400Period As Integer
    Private m_intPLCPeriod As Integer
    Private m_intLogPeriod As Integer
    Private m_intAS400BackupFilePeriod As Integer
    Private m_intDispRow As Integer
    Private m_intRetries As Integer
    Private m_intSkitNo As Integer
    Private m_intExportSleep As Integer
    Private m_strExpFileFullPath As String
    Private m_strExpFilePath As String
    Private m_strBackupExpPath As String
    Private m_intDbPeriod As Integer
    Private m_intLocalLogPeriod As Integer
    Private m_strScheduleTime As String
    Private m_strHulftCmdPath As String
    Private m_strHulftKickFile As String
    Private m_strHulftRecvId As String
    Private m_strHulttSendId As String
    Private m_strHulftExpId As String
    Private m_strAs400Host As String
    Private m_strHulftSaveFile As String
    Private m_strExptimeOut As String
    Private m_strExpWaitTime As String
    Private m_datAppStartTime As Date
    Private m_strErrorExpPath As String
    Private m_strErrorExpFile As String
#End Region

#Region "Property"

    'Public ReadOnly Property ServerIp() As String
    '    Get
    '        Return m_strServerIp
    '    End Get
    'End Property

    'Public ReadOnly Property ServerNode() As Integer
    '    Get
    '        Return m_intServerNode
    '    End Get
    'End Property

    'Public ReadOnly Property Net() As Integer
    '    Get
    '        Return m_intNet
    '    End Get
    'End Property

    'Public ReadOnly Property Node() As Integer
    '    Get
    '        Return m_intNode
    '    End Get
    'End Property

    'Public ReadOnly Property Unit() As Integer
    '    Get
    '        Return m_intUnit
    '    End Get
    'End Property

    Public ReadOnly Property WatchPath() As String
        Get
            Return m_strWatchPath
        End Get
    End Property

    Public ReadOnly Property BackupWatchPath() As String
        Get
            Return m_strBackupWatchPath
        End Get
    End Property

    Public ReadOnly Property AS400Period() As Integer
        Get
            Return m_intAS400Period
        End Get
    End Property

    Public ReadOnly Property PLCPeriod() As Integer
        Get
            Return m_intPLCPeriod
        End Get
    End Property

    Public ReadOnly Property LogPeriod() As Integer
        Get
            Return m_intLogPeriod
        End Get
    End Property

    Public ReadOnly Property DisplayRows() As Integer
        Get
            Return m_intDispRow
        End Get
    End Property

    'Public ReadOnly Property TotalRetry() As Integer
    '    Get
    '        Return m_intRetries
    '    End Get
    'End Property

    'Public ReadOnly Property ServerStatusAddress() As String
    '    Get
    '        Return m_strServerStatusAddr
    '    End Get
    'End Property

    Public ReadOnly Property AS400Path() As String
        Get
            Return m_strAs400Path
        End Get
    End Property

    Public ReadOnly Property BackupAS400Path() As String
        Get
            Return m_strBackupAs400Path
        End Get
    End Property

    Public ReadOnly Property MaxSkitNo() As Integer
        Get
            Return m_intSkitNo
        End Get
    End Property

    Public ReadOnly Property ExportFileFullPath() As String
        Get
            Return m_strExpFileFullPath
        End Get
    End Property

    Public ReadOnly Property ExportFilePath() As String
        Get
            Return m_strExpFilePath
        End Get
    End Property

    Public ReadOnly Property BackupExportPath() As String
        Get
            Return m_strBackupExpPath
        End Get
    End Property

    Public ReadOnly Property DBPeriod() As Integer
        Get
            Return m_intDbPeriod
        End Get
    End Property

    Public ReadOnly Property AS400BackupFilePeriod() As Integer
        Get
            Return m_intAS400BackupFilePeriod
        End Get
    End Property

    Public ReadOnly Property LocalLogPeriod() As Integer
        Get
            Return m_intLocalLogPeriod
        End Get
    End Property

    Public ReadOnly Property ScheduleTime() As String
        Get
            Return m_strScheduleTime
        End Get
    End Property

    Public ReadOnly Property HulftCommandPath() As String
        Get
            Return m_strHulftCmdPath
        End Get
    End Property

    Public ReadOnly Property HulftKickFile() As String
        Get
            Return m_strHulftKickFile
        End Get
    End Property

    Public ReadOnly Property HulftReceiveId() As String
        Get
            Return m_strHulftRecvId
        End Get
    End Property

    Public ReadOnly Property HulftSendId() As String
        Get
            Return m_strHulttSendId
        End Get
    End Property

    Public ReadOnly Property HulftExportId() As String
        Get
            Return m_strHulftExpId
        End Get
    End Property

    Public ReadOnly Property AS400Host() As String
        Get
            Return m_strAs400Host
        End Get
    End Property

    Public ReadOnly Property HulftSaveFileName() As String
        Get
            Return m_strHulftSaveFile
        End Get
    End Property

    Public ReadOnly Property ExportFileTimeOut() As String
        Get
            Return m_strExptimeOut
        End Get
    End Property

    Public ReadOnly Property ExportFileWaitingTime() As String
        Get
            Return m_strExpWaitTime
        End Get
    End Property

    Public ReadOnly Property AppStartTime() As Date
        Get
            Return m_datAppStartTime
        End Get
    End Property

    Public ReadOnly Property ErrorExportPath() As String
        Get
            Return m_strErrorExpPath
        End Get
    End Property

    Public ReadOnly Property ErrorExportFile() As String
        Get
            Return m_strErrorExpFile
        End Get
    End Property

    Public ReadOnly Property ExportSleepTime() As Integer
        Get
            Return m_intExportSleep
        End Get
    End Property
#End Region

#Region "Constructor"

#End Region

#Region "Method"

    Public Sub LoadIni(ByVal nAppType As enuAppType)
        modDatabase.ConnectionString = m_objIniFile.GetString(INI_SECTION_SETTING, _
                                                              INI_KEY_DB_CONNECTION_STRING, _
                                                              My.Settings.ConnectionString, _
                                                              INI_FILE_NAME)

        Select Case nAppType
            Case enuAppType.client

            Case enuAppType.server
                'm_strServerIp = m_objIniFile.GetString(INI_SECTION_SETTING, INI_KEY_SERVER_IP, "localhost", INI_FILE_NAME)
                'm_intServerNode = m_objIniFile.GetInt(INI_SECTION_SETTING, INI_KEY_SERVER_NODE, 100, INI_FILE_NAME)
                'm_intNet = m_objIniFile.GetInt(INI_SECTION_SETTING, INI_KEY_NET, 10, INI_FILE_NAME)
                'm_intNode = m_objIniFile.GetInt(INI_SECTION_SETTING, INI_KEY_NODE, 101, INI_FILE_NAME)
                'm_intUnit = m_objIniFile.GetInt(INI_SECTION_SETTING, INI_KEY_UNIT, 0, INI_FILE_NAME)
                m_strWatchPath = m_objIniFile.GetString(INI_SECTION_SETTING, INI_KEY_WATCH_PATH, "C:\AS400\ManualImport", INI_FILE_NAME)
                m_strBackupWatchPath = m_objIniFile.GetString(INI_SECTION_SETTING, INI_KEY_BACKUP_WATCH_PATH, "C:\AS400\BackupManualImport", INI_FILE_NAME)
                m_intDispRow = m_objIniFile.GetInt(INI_SECTION_SETTING, INI_KEY_DISPLAY_ROW_COUNT, 200, INI_FILE_NAME)
                m_intRetries = m_objIniFile.GetInt(INI_SECTION_SETTING, INI_KEY_NUMBER_OF_RETRIES, 5, INI_FILE_NAME)
                'm_strServerStatusAddr = m_objIniFile.GetString(INI_SECTION_SETTING, INI_KEY_SERVER_STATUS_ADDRESS, "22999", INI_FILE_NAME)
                m_intSkitNo = m_objIniFile.GetInt(INI_SECTION_SETTING, INI_KEY_MAX_SKIT_NO, 600, INI_FILE_NAME)
                m_strExpFileFullPath = m_objIniFile.GetString(INI_SECTION_SETTING, INI_KEY_EXPORT_FILE_FULL_PATH, "C:\AS400\ExportPath\exp.txt", INI_FILE_NAME)
                m_strExpFilePath = m_objIniFile.GetString(INI_SECTION_SETTING, INI_KEY_EXPORT_FILE_PATH, "C:\AS400\ExportPath", INI_FILE_NAME)
                m_strErrorExpPath = m_objIniFile.GetString(INI_SECTION_SETTING, INI_KEY_ERROR_EXPORT_PATH, "C:\AS400\ErrorExportPath", INI_FILE_NAME)
                m_strErrorExpFile = m_objIniFile.GetString(INI_SECTION_SETTING, INI_KEY_ERROR_EXPORT_FILE, "C:\AS400\ErrorExportPath\err.txt", INI_FILE_NAME)
                m_intExportSleep = m_objIniFile.GetInt(INI_SECTION_SETTING, INI_KEY_EXPORT_SLEEP, 6000, INI_FILE_NAME)
                m_datAppStartTime = Date.Now

            Case enuAppType.service
                m_intAS400Period = m_objIniFile.GetInt(INI_SECTION_SETTING, INI_KEY_AS400_PERIOD, 30, INI_FILE_NAME)
                m_intPLCPeriod = m_objIniFile.GetInt(INI_SECTION_SETTING, INI_KEY_PLC_PERIOD, 14, INI_FILE_NAME)
                m_intLogPeriod = m_objIniFile.GetInt(INI_SECTION_SETTING, INI_KEY_LOG_PERIOD, 30, INI_FILE_NAME)
                m_strAs400Path = m_objIniFile.GetString(INI_SECTION_SETTING, INI_KEY_AS400_PATH, "C:\AS400\AS400Path", INI_FILE_NAME)
                m_strBackupAs400Path = m_objIniFile.GetString(INI_SECTION_SETTING, INI_KEY_BACKUP_AS400_PATH, "C:\AS400\BackupFile", INI_FILE_NAME)
                m_strBackupWatchPath = m_objIniFile.GetString(INI_SECTION_SETTING, INI_KEY_BACKUP_WATCH_PATH, "C:\AS400\BackupManualImport", INI_FILE_NAME)
                m_strExpFileFullPath = m_objIniFile.GetString(INI_SECTION_SETTING, INI_KEY_EXPORT_FILE_FULL_PATH, "C:\AS400\ExportPath\exp.txt", INI_FILE_NAME)
                m_strExpFilePath = m_objIniFile.GetString(INI_SECTION_SETTING, INI_KEY_EXPORT_FILE_PATH, "C:\AS400\ExportPath", INI_FILE_NAME)
                m_strBackupExpPath = m_objIniFile.GetString(INI_SECTION_SETTING, INI_KEY_BACKUP_EXPORT_PATH, "C:\AS400\BackupExportPath", INI_FILE_NAME)
                m_intDbPeriod = m_objIniFile.GetInt(INI_SECTION_SETTING, INI_KEY_DB_DATA_PERIOD, 30, INI_FILE_NAME)
                m_intAS400BackupFilePeriod = m_objIniFile.GetInt(INI_SECTION_SETTING, INI_KEY_AS400_BACKUP_FILE_PERIOD, 30, INI_FILE_NAME)
                m_intLocalLogPeriod = m_objIniFile.GetInt(INI_SECTION_SETTING, INI_KEY_LOCAL_LOG_PERIOD, 10, INI_FILE_NAME)
                m_strScheduleTime = m_objIniFile.GetString(INI_SECTION_SETTING, INI_KEY_SCHEDULER_TIME, "2300", INI_FILE_NAME)
                m_strHulftCmdPath = m_objIniFile.GetString(INI_SECTION_SETTING, INI_KEY_HULFT_CMD_PATH, "C:\HULFT Family\hulft7\binnt", INI_FILE_NAME)
                m_strHulftKickFile = m_objIniFile.GetString(INI_SECTION_SETTING, INI_KEY_HULFT_KICK_FILE, "C:\FrameKick.txt", INI_FILE_NAME)
                m_strHulftRecvId = m_objIniFile.GetString(INI_SECTION_SETTING, INI_KEY_HULFT_RECV_ID, "GHTD003A", INI_FILE_NAME)
                m_strHulttSendId = m_objIniFile.GetString(INI_SECTION_SETTING, INI_KEY_HULFT_SEND_ID, "GHTD004N", INI_FILE_NAME)
                m_strHulftExpId = m_objIniFile.GetString(INI_SECTION_SETTING, INI_KEY_HULFT_EXPORT_ID, "GHTD005A", INI_FILE_NAME)
                m_strAs400Host = m_objIniFile.GetString(INI_SECTION_SETTING, INI_KEY_AS400_HOST, "AS400T1", INI_FILE_NAME)
                m_strHulftSaveFile = m_objIniFile.GetString(INI_SECTION_SETTING, INI_KEY_HULFT_SAVE_FILE, "C:\AS400\AS400Path\test.txt", INI_FILE_NAME)
                m_strExptimeOut = m_objIniFile.GetString(INI_SECTION_SETTING, INI_KEY_EXPORT_TIME_OUT, "6000", INI_FILE_NAME)
                m_strExpWaitTime = m_objIniFile.GetString(INI_SECTION_SETTING, INI_KEY_EXPORT_WAIT_TIME, "3000", INI_FILE_NAME)
                m_strErrorExpPath = m_objIniFile.GetString(INI_SECTION_SETTING, INI_KEY_ERROR_EXPORT_PATH, "C:\AS400\ErrorExportPath", INI_FILE_NAME)
                m_strErrorExpFile = m_objIniFile.GetString(INI_SECTION_SETTING, INI_KEY_ERROR_EXPORT_FILE, "C:\AS400\ErrorExportPath\err.txt", INI_FILE_NAME)
        End Select
    End Sub

#End Region

#Region "Event"

#End Region

End Module
