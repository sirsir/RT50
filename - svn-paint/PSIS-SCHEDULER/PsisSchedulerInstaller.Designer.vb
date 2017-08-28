<System.ComponentModel.RunInstaller(True)> Partial Class PsisSchedulerInstaller
    Inherits System.Configuration.Install.Installer

    'Installer overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.PsisServiceProcessInstaller = New System.ServiceProcess.ServiceProcessInstaller
        Me.PsisServiceInstaller = New System.ServiceProcess.ServiceInstaller
        '
        'PsisServiceProcessInstaller
        '
        Me.PsisServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem
        Me.PsisServiceProcessInstaller.Password = Nothing
        Me.PsisServiceProcessInstaller.Username = Nothing
        '
        'PsisServiceInstaller
        '
        Me.PsisServiceInstaller.DisplayName = "PSIS Scheduled Service"
        Me.PsisServiceInstaller.ServiceName = "PSIS_Service"
        Me.PsisServiceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic
        '
        'PsisSchedulerInstaller
        '
        Me.Installers.AddRange(New System.Configuration.Install.Installer() {Me.PsisServiceProcessInstaller, Me.PsisServiceInstaller})

    End Sub
    Friend WithEvents PsisServiceProcessInstaller As System.ServiceProcess.ServiceProcessInstaller
    Friend WithEvents PsisServiceInstaller As System.ServiceProcess.ServiceInstaller

End Class
