Public Class clsImportFile
    Inherits System.ComponentModel.BackgroundWorker

#Region "Attribute"
    Private m_strWatchPath As String
    Private m_strBackUpPath As String
    Private m_clsLog As New clsLogger
    Private m_clsFile As clsFile
#End Region

#Region "Constructor"

    Public Sub New(ByVal strImportPath As String, ByVal strBackUpPath As String)
        m_strWatchPath = strImportPath
        m_strBackUpPath = strBackUpPath
        m_clsFile = New clsFile(clsFile.enuImportType.manual)
    End Sub

#End Region

#Region "Event"

    Private Sub clsImportFile_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Me.DoWork
        While True
            ImportAllFile()
            Threading.Thread.Sleep(System.TimeSpan.FromSeconds(2))
        End While
    End Sub

#End Region

#Region "Method"

    Private Sub ImportAllFile()
        m_clsLog.Log(clsLogger.MessageType.NormalLog, Me.GetType.Name, "CheckNewFile", "Start", "")

        m_clsFile.ImportFile(m_strWatchPath, m_strBackUpPath)

        m_clsLog.Log(clsLogger.MessageType.NormalLog, Me.GetType.Name, "CheckNewFile", "End", "")
    End Sub

#End Region

End Class
