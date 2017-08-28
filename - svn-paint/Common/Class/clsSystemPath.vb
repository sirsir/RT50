Public Class clsSystemPath
    'System Path取得
    Public Function GetSystemPath() As String
        'GetSystemPath = System.Environment.GetEnvironmentVariable("$Home")
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
