Public Module ModConstant

    Public Const PRODUCTION_DATA_SIZE_PER_PAGE As Integer = 24
    Public Const INSTRUCTION_DATA_SIZE_PER_PAGE As Integer = 20
    Public Const CARRYOUT_DATA_SIZE_PER_PAGE As Integer = 20

    Public Const INI_FILE_NAME As String = "PIS-Setting.ini"

    'SQL DB Setting in Ini file  
    Public Const INI_SECTION_SQLDB As String = "SqlDB"
    Public Const INI_KEY_DATASOURCE As String = "DataSource"
    Public Const INI_KEY_DATABASE As String = "Database"
    Public Const INI_KEY_USERID As String = "UserID"
    Public Const INI_KEY_PASSWORD As String = "Password"

    'Setting
    Public Const INI_SECTION_SETTING As String = "Setting"
    'Public Const INI_KEY_SERVER_IP As String = "ServerIp"
    Public Const INI_KEY_SERVER_NODE As String = "ServerNode"
    Public Const INI_KEY_SERVER_STATUS_ADDRESS As String = "ServerStatusAddress"
    Public Const INI_KEY_WATCH_PATH As String = "WatchPath"
    Public Const INI_KEY_BACKUP_WATCH_PATH As String = "BackupWatchPath"
    Public Const INI_KEY_AS400_PATH As String = "AS400Path"
    Public Const INI_KEY_BACKUP_AS400_PATH As String = "BackupAS400Path"
    Public Const INI_KEY_AS400_PERIOD As String = "AS400Period"
    Public Const INI_KEY_PLC_PERIOD As String = "PLCPeriod"
    Public Const INI_KEY_LOG_PERIOD As String = "LogPeriod"
    'Public Const INI_KEY_NUMBER_OF_RETRIES As String = "NumberOfRetries"
    Public Const INI_KEY_DISPLAY_ROW_COUNT As String = "DisplayRowCount"

    'Column name const
    Public Const newColumnName1 As String = "ASMPARTSNo1"
    Public Const newColumnName2 As String = "ASMPARTSNo2"
    Public Const newColumnName3 As String = "ASMPARTSNo3"
    Public Const newColumnName4 As String = "ASMPARTSNo4"
    Public Const newColumnName5 As String = "ASMPARTSNo5"

    'Public Const SPACE_8 As String = "        "
    'Public Const SPACE_10 As String = "          "

End Module
