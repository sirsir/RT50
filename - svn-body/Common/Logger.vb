'ログ出力クラス
Public Class Logger
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
            Case Logger.MessageType.ErrorLog
                GetMsgTypeName = "ERROR  "
            Case Logger.MessageType.WarningLog
                GetMsgTypeName = "WARNING"
            Case Logger.MessageType.NormalLog
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
