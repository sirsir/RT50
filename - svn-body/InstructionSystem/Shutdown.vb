Public Class Shutdown
    Dim logger As Common.Logger = New Common.Logger()


    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnExit_Click", "Exit Application", "")

        Application.Exit()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnCancel_Click", "Click Cancel Button", "")
        Me.Close()
        Main_Menu.Show()
    End Sub

    Private Sub btnShutdown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShutdown.Click
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnShutdown_Click", "Click Shutdown Button", "")
        'Dim t As Single

        'Dim objWMIService, objComputer As Object

        ''Now get some privileges

        'objWMIService = GetObject("Winmgmts:{impersonationLevel=impersonate,(Debug,Shutdown)}")


        'For Each objComputer In objWMIService.InstancesOf("Win32_OperatingSystem")

        '    t = objComputer.Win32Shutdown(8 + 4, 0)

        '    If t <> 0 Then

        '        MessageBox.show("Error occurred!!!")

        '    Else

        '        'LogOff your system

        '    End If

        'Next

        Shell("shutdown -s -f")
    End Sub

    Private Sub Shutdown_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Close()
        Main_Menu.Show()
    End Sub

End Class