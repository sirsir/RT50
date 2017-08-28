Imports Common

Public Class TLogDat

#Region "ENUM"
    Public Enum RecordIndex
        LogType
        PcName
        OccDate
        Message
        LineName
        LogId
    End Enum

    Public Enum LogLevel
        NormalLog
        WarningLog
        ErrorLog
    End Enum
#End Region

#Region "MEMBER"
    Private Const m_strTableName As String = "T_LOG_DAT"
    Private m_iLogType As Integer
    Private m_strPcName As String
    Private m_strLineName As String
    Private m_dtOccDate As Date
    Private m_strMessage As String
    Private m_iLogId As Integer

    'Private m_singletonSqlDb As SingletonSqlDB = SingletonSqlDB.GetInstance()

    Public Const LOG_TYPE_AS400 As Integer = 0
    Public Const LOG_TYPE_PLC As Integer = 1
    Public Const LOG_TYPE_OPERATION As Integer = 2
    Private clsLogger As New Logger
    Private taT_Log_DAT As ServerDatasetTableAdapters.T_LOG_DATTableAdapter = modDataSource.ta(Of PIS_SERVER.ServerDatasetTableAdapters.T_LOG_DATTableAdapter).GetTableAdapter()
    Private dtT_Log_DAT As New ServerDataset.T_LOG_DATDataTable
    Private result As Integer = 0


#End Region

#Region "METHOD"
#Region "GET AND SET METHOD"
    Public Property logType() As Integer
        Get
            Return m_iLogType
        End Get
        Set(ByVal value As Integer)
            m_iLogType = value
        End Set
    End Property

    Public Property pcName() As String
        Get
            Return m_strPcName
        End Get
        Set(ByVal value As String)
            m_strPcName = value
        End Set
    End Property

    Public Property occDate() As Date
        Get
            Return m_dtOccDate
        End Get
        Set(ByVal value As Date)
            m_dtOccDate = value
        End Set
    End Property

    Public Property message() As String
        Get
            Return m_strMessage
        End Get
        Set(ByVal value As String)
            m_strMessage = value
        End Set
    End Property

    Public Property lineName() As String
        Get
            Return m_strLineName
        End Get
        Set(ByVal value As String)
            m_strLineName = value
        End Set
    End Property

    Public Property logId() As Integer
        Get
            Return m_iLogId
        End Get
        Set(ByVal value As Integer)
            m_iLogId = value
        End Set
    End Property
#End Region

    'Public Sub SetData(ByVal row As DataRow)
    '    Me.m_iLogType = CInt(row("LogType"))
    '    Me.m_strPcName = CStr(row("PcName"))
    '    Me.m_dtOccDate = CDate(row("OccDate"))
    '    Me.m_strMessage = CStr(row("Message"))
    '    Me.m_strLineName = CStr(row("LineName"))
    '    Me.m_iLogId = CInt(row("LogId"))
    'End Sub

    Public Sub New()

    End Sub

    Public Sub InsertNewLog(ByVal logType As Integer, ByVal logLevel As LogLevel, ByVal pcName As String, ByVal occDate As Date, _
                                 ByVal logMessage As String, ByVal lineName As String)

        'Dim strInsertValue As String

        If CStr(logType) IsNot Nothing And CStr(occDate) IsNot Nothing Then

            'Dim taT_Log_DAT As ServerDatasetTableAdapters.T_LOG_DATTableAdapter = modDataSource.ta(Of PIS_SERVER.ServerDatasetTableAdapters.T_LOG_DATTableAdapter).GetTableAdapter()
            'Dim dtT_Log_DAT As New ServerDataset.T_LOG_DATDataTable
            Try
                result = taT_Log_DAT.Insert(logType, pcName, occDate, logMessage, lineName, logLevel)
                If result > 0 Then
                    clsLogger.Log(Logger.MessageType.NormalLog, "TLogDat", "InsertNewLog", "Log Inserted: logType = " & logType _
                                  & ", pcName = " & pcName & ", occDate = " & Format(occDate, "yyyy/MM/dd HH:mm") & ", lineName = " & lineName _
                                  & ", logLevel = " & logLevel & ", Message = " & logMessage, "")
                Else
                    clsLogger.Log(Logger.MessageType.ErrorLog, "TLogDat", "InsertNewLog", "Cannot insert log to database", "")
                End If
            Catch ex As Exception
                clsLogger.Log(Logger.MessageType.ErrorLog, "TLogDat", "InsertNewLog", ex.ToString, "")
            End Try

            'strInsertValue = CStr(logType) & ","

            'If CStr(pcName) IsNot Nothing Then
            '    If pcName.Length < 60 Then
            '        strInsertValue += "'" & CStr(pcName) & "',"
            '    Else
            '        strInsertValue += "'" & CStr(pcName.Substring(0, 60)) & "',"
            '    End If
            'Else
            '    strInsertValue += "NULL,"
            'End If

            'strInsertValue += GetDateTimeValueForSQL(occDate) & ","
            ''strInsertValue += "'" & Now.ToString & "',"

            'If CStr(logMessage) IsNot Nothing Then
            '    If logMessage.Length < 255 Then
            '        strInsertValue += "'" & CStr(logMessage) & "',"
            '    Else
            '        strInsertValue += "'" & CStr(logMessage.Substring(0, 255)) & "',"
            '    End If
            'Else
            '    strInsertValue += "NULL,"
            'End If

            'If CStr(lineName) IsNot Nothing Then
            '    If lineName.Length < 60 Then
            '        strInsertValue += "'" & CStr(lineName) & "'"
            '    Else
            '        strInsertValue += "'" & CStr(lineName.Substring(0, 60)) & "'"
            '    End If
            'Else
            '    strInsertValue += "NULL"
            'End If
            'If logLevel = 0 Then
            '    strInsertValue += ",0"
            'ElseIf logLevel = 1 Then
            '    strInsertValue += ",1"
            'Else
            '    strInsertValue += ",2"
            'End If

            'Dim strQuery As String = "INSERT INTO " & m_strTableName & " VALUES(" & strInsertValue & ")"  '(LogType,PcName,OccDate,Message,LineName) 

            'clsLogger.Log(Logger.MessageType.NormalLog, "TLogDat", "InsertNewLog", "SQL String = " & strQuery, "")
            'Dim bl = m_singletonSqlDb.Connect()
            'If bl Then
            '    clsLogger.Log(Logger.MessageType.NormalLog, "TLogDat", "InsertNewLog", "Connect = " & bl.ToString, "")
            'Else
            '    clsLogger.Log(Logger.MessageType.ErrorLog, "TLogDat", "InsertNewLog", "Connect = " & bl.ToString, "")
            'End If
            ''Start transaction
            'bl = m_singletonSqlDb.Transaction()
            'If bl Then
            '    clsLogger.Log(Logger.MessageType.NormalLog, "TLogDat", "InsertNewLog", "Transaction = " & bl.ToString, "")
            'Else
            '    clsLogger.Log(Logger.MessageType.ErrorLog, "TLogDat", "InsertNewLog", "Transaction = " & bl.ToString, "")
            'End If

            ''Insert Record into transaction table
            'If (Not m_singletonSqlDb.ExecNonQuery(strQuery)) Then
            '    m_singletonSqlDb.Rollback()
            '    clsLogger.Log(Logger.MessageType.ErrorLog, "TLogDat", "InsertNewLog", "ExecNonQuery = " & False, "")
            'End If
            'If (Not m_singletonSqlDb.Commit()) Then
            '    m_singletonSqlDb.Rollback()
            '    clsLogger.Log(Logger.MessageType.ErrorLog, "TLogDat", "InsertNewLog", "Commit = " & False, "")
            'End If
        Else
            clsLogger.Log(Logger.MessageType.ErrorLog, "TLogDat", "InsertNewLog", "Please check logType and occDate", "")
        End If

    End Sub

    'Private Function GetDateTimeValueForSQL(ByVal varDateTime As Object) As String

    '    Const cstrDateFormatForSQL As String = "/MM/dd HH:mm:ss"

    '    Dim strText As String
    '    Dim strResult As String

    '    strResult = ""

    '    'If IsDBNull(varDateTime) Then
    '    If IsDBNull(varDateTime) OrElse IsNothing(varDateTime) Then 'Kong 20091109 : add "OrElse IsNothing(varDateTime)"
    '        strResult = "NULL"
    '    Else
    '        strText = CDate(varDateTime).Year & Format(varDateTime, cstrDateFormatForSQL)
    '        'strText = Replace(strText, " 12:00:00", "")

    '        strResult = "CONVERT(datetime, '" & strText & "',111)"
    '    End If

    '    Return strResult
    'End Function
#End Region

End Class
