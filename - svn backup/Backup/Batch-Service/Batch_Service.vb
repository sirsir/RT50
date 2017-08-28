Module Batch_Service

#Region "Constant"
    Private Const INI_SECTION_BATCH_SETTING As String = "BatchSetting"
    Private Const INI_KEY_BATCH_TIME As String = "BatchTime"
    Private Const INI_KEY_BATCH_SLEEP_SECOND As String = "BatchSleepSecond"
    Private Const BATCH_LOG_LINE_NO As Integer = 99
    Private Const MY_NAME = "Batch_Service"
#End Region

#Region "Attribute"
    Private m_clsLog As New clsServiceLogger
    Private m_clsIni As New clsServiceIniFile
    Private m_strBatPath As String
    Private m_strBatchTime As String
    Private m_intBatchSleep As Integer
#End Region

#Region "Event"
    Private Sub DoWork()
        m_clsLog.LogByLine(BATCH_LOG_LINE_NO, clsServiceLogger.MessageType.NormalLog, MY_NAME, "bgWorker_DoWork", "Start", "")
        While True
            Try
                Execute()
            Catch ex As Exception
                m_clsLog.LogByLine(BATCH_LOG_LINE_NO, clsServiceLogger.MessageType.ErrorLog, MY_NAME, "Main", ex.Message, ex.StackTrace)
            End Try
            Threading.Thread.Sleep(TimeSpan.FromSeconds(30))
        End While
    End Sub
#End Region

#Region "Method"
    Private Sub Execute()
        Dim datNow As DateTime = Now

        m_clsLog.LogByLine(BATCH_LOG_LINE_NO, clsServiceLogger.MessageType.NormalLog, MY_NAME, "Execute", "Execute Start", "")
        m_strBatchTime = m_clsIni.GetString(INI_SECTION_BATCH_SETTING, INI_KEY_BATCH_TIME, "0700", "PIS-Setting.ini")
        m_clsLog.LogByLine(BATCH_LOG_LINE_NO, clsServiceLogger.MessageType.NormalLog, MY_NAME, "Execute", "Batch Time = " & m_strBatchTime, "")
        If m_strBatchTime <> datNow.ToString("HHmm") Then
            Return
        End If

        'tmrBatch.Enabled = False
        m_intBatchSleep = m_clsIni.GetInt(INI_SECTION_BATCH_SETTING, INI_KEY_BATCH_SLEEP_SECOND, "30", "PIS-Setting.ini")
        m_clsLog.LogByLine(BATCH_LOG_LINE_NO, clsServiceLogger.MessageType.NormalLog, MY_NAME, "Execute", "Batch Sleep = " & m_intBatchSleep, "")
        m_clsLog.LogByLine(BATCH_LOG_LINE_NO, clsServiceLogger.MessageType.NormalLog, MY_NAME, "Execute", "Batch Path = " & m_strBatPath, "")

        If Not My.Computer.FileSystem.DirectoryExists(m_strBatPath) Then
            My.Computer.FileSystem.CreateDirectory(m_strBatPath)
        End If

        For Each strFile As String In My.Computer.FileSystem.GetFiles(m_strBatPath, FileIO.SearchOption.SearchTopLevelOnly, "*.bat")
            Try
                m_clsLog.LogByLine(BATCH_LOG_LINE_NO, clsServiceLogger.MessageType.NormalLog, MY_NAME, "Execute", "File Name = " & strFile, "")
                Shell(strFile, AppWinStyle.Hide, False)
                m_clsLog.LogByLine(BATCH_LOG_LINE_NO, clsServiceLogger.MessageType.NormalLog, MY_NAME, "Execute", "File Name = " & strFile & "End", "")
            Catch exSub As Exception
                m_clsLog.LogByLine(BATCH_LOG_LINE_NO, clsServiceLogger.MessageType.ErrorLog, MY_NAME, "MainSub", exSub.Message, exSub.StackTrace)
            Finally
                Threading.Thread.Sleep(TimeSpan.FromSeconds(m_intBatchSleep))
            End Try
        Next

    End Sub

    Sub Main()
        Dim MatchingNames As System.Diagnostics.Process()
        Try
            '===========================================================================
            ' Check Process is still Running
            Dim vMyProcessName As String = System.Diagnostics.Process.GetCurrentProcess.ProcessName

            MatchingNames = System.Diagnostics.Process.GetProcessesByName(vMyProcessName)

            If (MatchingNames.Length = 1) Then
                'MessageBox.Show("Started...")
            Else
                'MsgBox("This Program Already Running!!!", MsgBoxStyle.Information, "Error")
                m_clsLog.LogByLine(BATCH_LOG_LINE_NO, clsServiceLogger.MessageType.NormalLog, MY_NAME, "Main", "This Program Already Running!!!", "")
                End
            End If
            '===========================================================================
        Catch ex As Exception
            m_clsLog.LogByLine(BATCH_LOG_LINE_NO, clsServiceLogger.MessageType.NormalLog, MY_NAME, "Main", "This Program Already Running!!!", "")
            End
        End Try

        Try


            m_clsLog.LogByLine(BATCH_LOG_LINE_NO, clsServiceLogger.MessageType.NormalLog, MY_NAME, "Main", "Frame Batch Service Start", "")
            m_strBatPath = My.Application.Info.DirectoryPath & "\batch"
            DoWork()
        Catch ex As Exception
            m_clsLog.LogByLine(BATCH_LOG_LINE_NO, clsServiceLogger.MessageType.NormalLog, MY_NAME, "Main", ex.StackTrace, "")
        End Try
    End Sub
#End Region

End Module

Public Class clsServiceLogger
    ' メッセージタイプ
    Enum MessageType
        NormalLog = 0     ' 情報 Log
        WarningLog = 1    ' ワーニング Log
        ErrorLog = 2      ' エラー Log
    End Enum

    Private strProgramID As String      'プログラムID
    Private strTerminalName As String     '端末ID

    'Private nLogLevel As Integer      ' ログ出力レベル
    Private strLogFolder As String    'ログ出力フォルダ

    'コンストラクタ
    Public Sub New()
        Me.strTerminalName = My.Computer.Name

        Me.strLogFolder = "log"

        If Not System.IO.Directory.Exists(Me.strLogFolder) Then
            'フォルダがない場合はフォルダを作成する
            System.IO.Directory.CreateDirectory(Me.strLogFolder)
        End If
    End Sub

    'System の起動ラベルを出力
    'N31100のMainしか呼べません
    Public Sub SystemStart()
        'ログファイル名作成
        '        strFileName = "C:\" + CompName + Format(Now, "yyyyMMdd") + ".Log"
        Dim strFileName As String = strTerminalName + Format(Now, "yyyyMMdd") + ".Log"

        'ログファイル出力
        WriteLog(strFileName, Format(Now, "dd/MM/yyyy") + " " + Format(Now, "HH:mm:ss") + " ***** System Start ***")
    End Sub

    'System の終了ラベルを出力
    'N31100のMainしか呼べません
    Public Sub SystemEnd()
        'ログファイル名作成
        '        strFileName = "C:\" + CompName + Format(Now, "yyyyMMdd") + ".Log"
        Dim strFileName As String = strTerminalName + Format(Now, "yyyyMMdd") + ".Log"

        'ログファイル出力
        WriteLog(strFileName, Format(Now, "dd/MM/yyyy") + " " + Format(Now, "HH:mm:ss") + " ***** System End ***")
        WriteLog(strFileName, "")
    End Sub

    'ログ出力
    ' param  eMsgType      [in] メッセージタイプ
    ' param  strProgramID  [in] ログ出力プログラムID
    ' param  strModuleName [in] ログ出力モジュール名
    ' param  strProcedureName [in] ログ出力関数名
    ' param  strMessage    [in] メッセージ
    ' param  strMessageEx  [in] 追記メッセージ
    Public Sub Log(ByVal eMsgType As MessageType, _
                   ByVal strModuleName As String, _
                   ByVal strProcedureName As String, _
                   ByVal strMessage As String, _
                   ByVal strMessageEx As String)
        Me.Logging(eMsgType, _
                    Me.strTerminalName, _
                    strModuleName, _
                    strProcedureName, _
                    strMessage, _
                    strMessageEx)
    End Sub

    Public Sub LogByLine(ByVal intLineNo As Integer, _
                   ByVal eMsgType As MessageType, _
                   ByVal strModuleName As String, _
                   ByVal strProcedureName As String, _
                   ByVal strMessage As String, _
                   ByVal strMessageEx As String)
        Me.LoggingByLine(intLineNo, _
                    eMsgType, _
                    Me.strTerminalName, _
                    strModuleName, _
                    strProcedureName, _
                    strMessage, _
                    strMessageEx)
    End Sub

    'ログ出力
    ' eMsgType          [in] メッセージタイプ
    ' strTerminalName   [in] 端末名
    ' strModuleName     [in] ログ出力モジュール名
    ' strProcedureName  [in] ログ出力関数名
    ' strMessage        [in] メッセージ
    ' strMessageEx      [in] 追記メッセージ
    Private Sub Logging(ByVal eMsgType As MessageType, _
                     ByVal strTerminalName As String, _
                     ByVal strModuleName As String, _
                     ByVal strProcedureName As String, _
                     ByVal strMessage As String, _
                     ByVal strMessageEx As String)

        'ログレベル確認
        'If nLogMsgLv <= nOutputLogLv Then

        'ログレベル文字列取得
        Dim strLogLevel As String = GetMsgTypeName(eMsgType)

        ' ログ出力メッセージ作成
        Dim strLogMessage As String
        strLogMessage = Format(Now, "dd/MM/yyyy") + " " + Format(Now, "HH:mm:ss") + _
                        "[" + strLogLevel + "]" + _
                        "[" + strTerminalName + "]" + _
                        "[" + strModuleName + "]" + _
                        "[" + strProcedureName + "]" + _
                        "[" + strMessage + "]" + _
                        "[" + strMessageEx + "]"

        'ログファイル名作成
        '****ログファイルのパスは？****
        Dim strFileName As String
        '        strFileName = "C:\" + CompName + Format(Now, "yyyyMMdd") + ".Log"
        strFileName = strTerminalName + Format(Now, "yyyyMMdd") + ".Log"

        'ログファイル出力
        WriteLog(strFileName, strLogMessage)

        'End If

    End Sub

    'ログ出力
    ' eMsgType          [in] メッセージタイプ
    ' strTerminalName   [in] 端末名
    ' strModuleName     [in] ログ出力モジュール名
    ' strProcedureName  [in] ログ出力関数名
    ' strMessage        [in] メッセージ
    ' strMessageEx      [in] 追記メッセージ
    Private Sub LoggingByLine(ByVal intLineNo As Integer, _
                     ByVal eMsgType As MessageType, _
                     ByVal strTerminalName As String, _
                     ByVal strModuleName As String, _
                     ByVal strProcedureName As String, _
                     ByVal strMessage As String, _
                     ByVal strMessageEx As String)

        'ログレベル確認
        'If nLogMsgLv <= nOutputLogLv Then

        'ログレベル文字列取得
        Dim strLogLevel As String = GetMsgTypeName(eMsgType)

        ' ログ出力メッセージ作成
        Dim strLogMessage As String
        strLogMessage = Format(Now, "dd/MM/yyyy") + " " + Format(Now, "HH:mm:ss") + _
                        "[" + strLogLevel + "]" + _
                        "[" + strTerminalName + "]" + _
                        "[" + strModuleName + "]" + _
                        "[" + strProcedureName + "]" + _
                        "[" + strMessage + "]" + _
                        "[" + strMessageEx + "]"

        'ログファイル名作成
        '****ログファイルのパスは？****
        Dim strFileName As String
        '        strFileName = "C:\" + CompName + Format(Now, "yyyyMMdd") + ".Log"
        strFileName = strTerminalName + Format(Now, "yyyyMMdd") + "_Line" + intLineNo.ToString("D2") + ".Log"

        'ログファイル出力
        WriteLog(strFileName, strLogMessage)

        'End If

    End Sub

    ' Logレベル 名称を取得する
    Private Function GetMsgTypeName(ByVal eMsgType As MessageType) As String
        ' 初期値
        GetMsgTypeName = "-------"

        Select Case eMsgType
            Case clsServiceLogger.MessageType.ErrorLog
                GetMsgTypeName = "ERROR  "
            Case clsServiceLogger.MessageType.WarningLog
                GetMsgTypeName = "WARNING"
            Case clsServiceLogger.MessageType.NormalLog
                GetMsgTypeName = "NORMAL "
        End Select

    End Function

    'ログファイル出力
    Private Sub WriteLog(ByVal strFileName As String, ByVal strLogMessage As String)
        Try
            'ファイルパス生成
            Dim strFilePath As String = Me.strLogFolder + "\" + strFileName

            'ファイル追加形式でファイルを開く 
            Dim Writer As New IO.StreamWriter(strFilePath, True)

            '１行出力
            Writer.WriteLine(strLogMessage)

            'ファイルを閉じる
            Writer.Close()
        Catch ex As Exception

        End Try
    End Sub

End Class

Public Class clsServiceSystemPath
    'System Path取得
    Public Function GetSystemPath() As String
        'GetSystemPath = System.Environment.GetEnvironmentVariable("$Home")
        'GetSystemPath = My.Application.Info.DirectoryPath
        Environment.CurrentDirectory = My.Application.Info.DirectoryPath
        GetSystemPath = "..\"

        If (Not GetSystemPath.EndsWith("\")) Then
            GetSystemPath = GetSystemPath + "\"
        End If
    End Function

    'ConfフォルダPath取得
    Public Function GetConfPath() As String
        GetConfPath = GetSystemPath() + "conf\"

        While Not System.IO.Directory.Exists(GetConfPath)
            GetConfPath = "..\" + GetConfPath
        End While

    End Function

    'ExeフォルダPath取得
    Public Function GetExecPath() As String
        GetExecPath = GetSystemPath() + "exe\"
    End Function

    'LogフォルダPath取得
    Public Function GetLogPath() As String
        GetLogPath = GetLogPath() + "exe\"
    End Function

    Public Function GetDocPath() As String
        GetDocPath = GetSystemPath() + "doc\"
    End Function
End Class

Public Class clsServiceIniFile
    'API関数定義
    '指定のIniファイルの指定キーの値を取得(文字列)
    Private Declare Function GetPrivateProfileString Lib "KERNEL32.DLL" Alias "GetPrivateProfileStringA" ( _
                                ByVal lpAppName As String, _
                                ByVal lpKeyName As String, _
                                ByVal lpDefault As String, _
                                ByVal lpReturnedString As System.Text.StringBuilder, _
                                ByVal nSize As Integer, _
                                ByVal lpFileName As String) As Integer

    '指定のIniファイルの指定キーの値を取得(整数値)
    Private Declare Function GetPrivateProfileInt Lib "KERNEL32.DLL" Alias "GetPrivateProfileIntA" ( _
                                ByVal lpAppName As String, _
                                ByVal lpKeyName As String, _
                                ByVal nDefault As Integer, _
                                ByVal lpFileName As String) As Integer

    '指定のIniファイルの指定キーの値を変更(文字列)
    Private Declare Function WritePrivateProfileString Lib "KERNEL32.DLL" Alias "WritePrivateProfileStringA" ( _
                                ByVal lpAppName As String, _
                                ByVal lpKeyName As String, _
                                ByVal lpString As String, _
                                ByVal lpFileName As String) As Integer

    '読み込みバッファサイズ
    Private Const READ_BUFF_SIZE As Integer = 1024


    '指定のIniファイルの指定キーの値を取得(文字列)
    'param  strAppName        [in]セクション名
    'param  strKeyName        [in]キー名
    'param  strDefault        [in]初期値
    'param  strFileName       [in]Iniファイル名
    'rerurn 読込んだ文字を返す
    Public Function GetString(ByVal strAppName As String, _
                              ByVal strKeyName As String, _
                              ByVal strDefault As String, _
                              ByVal strFileName As String) As String

        '読み込みバッファを生成
        Dim strGetBuff As New System.Text.StringBuilder
        strGetBuff.Capacity = READ_BUFF_SIZE

        'ファイルパスを生成
        Dim strIniPath = GetConfFolderPath() + strFileName

        'API関数へ呼び変える
        Dim nReadSize As Integer = GetPrivateProfileString(strAppName, strKeyName, strDefault, strGetBuff, strGetBuff.Capacity, strIniPath)

        '読み込みバッファから引数へ変換
        GetString = strGetBuff.ToString

        If (GetString = strDefault) Then
            '初期値と戻り値が同じ場合、以下の可能性があるので、念の為書き込むようにする
            '・パラメータが記述されていない
            '・ファイルがない
            SetString(strAppName, strKeyName, strDefault, strFileName)
        End If

    End Function

    '指定のIniファイルの指定キーの値を取得(整数値)
    'param  strAppName        [in]セクション名
    'param  strKeyName        [in]キー名
    'param  nDefault          [in]初期値
    'param  strFileName       [in]Iniファイル名
    'rerurn 読込んだ整数値を返す
    Public Function GetInt(ByVal strAppName As String, _
                           ByVal strKeyName As String, _
                           ByVal nDefault As Integer, _
                           ByVal strFileName As String) As Integer

        'ファイルパスを生成
        Dim strIniPath = GetConfFolderPath() + strFileName

        'API関数へ呼び変える
        GetInt = GetPrivateProfileInt(strAppName, strKeyName, nDefault, strIniPath)

        If (GetInt = nDefault) Then
            '初期値と戻り値が同じ場合、以下の可能性があるので、念の為書き込むようにする
            '・パラメータが記述されていない
            '・ファイルがない
            SetInt(strAppName, strKeyName, nDefault, strFileName)
        End If
    End Function

    '指定のIniファイルの指定キーの値を変更(文字列)
    'param  strAppName        [in]セクション名
    'param  strKeyName        [in]キー名
    'param  strParam         [in]書き込む値
    'param  strFileName       [in]Iniファイル名
    'rerurn 成功した場合True、失敗した場合はFalseを返す
    Public Function SetString(ByVal strAppName As String, _
                              ByVal strKeyName As String, _
                              ByVal strParam As String, _
                              ByVal strFileName As String) As Boolean

        'ファイルパスを生成
        Dim strIniPath = GetConfFolderPath() + strFileName

        SetString = True
        'API関数へ呼び変える
        If WritePrivateProfileString(strAppName, strKeyName, strParam, strIniPath) = 0 Then
            SetString = False
        End If
    End Function

    '指定のIniファイルの指定キーの値を変更(文字列)
    'param  strAppName        [in]セクション名
    'param  strKeyName        [in]キー名
    'param  nParam            [in]書き込む値
    'param  strFileName       [in]Iniファイル名
    'rerurn 成功した場合True、失敗した場合はFalseを返す
    Public Function SetInt(ByVal strAppName As String, _
                           ByVal strKeyName As String, _
                           ByVal nParam As Integer, _
                           ByVal strFileName As String) As Boolean

        SetInt = True

        'ファイルパスを生成
        Dim strIniPath = GetConfFolderPath() + strFileName

        Dim strParam As String = nParam
        'API関数へ呼び変える
        If WritePrivateProfileString(strAppName, strKeyName, strParam, strIniPath) = 0 Then
            SetInt = False
        End If

    End Function

    'コンフィグフォルダを取得する
    Private Function GetConfFolderPath() As String
        '環境変数からPathを取得
        Dim sysPath As New clsServiceSystemPath
        GetConfFolderPath = sysPath.GetConfPath()
    End Function

    Public Sub New()

    End Sub
End Class
