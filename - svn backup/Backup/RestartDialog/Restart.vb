Public Class Restart

    Private Sub Restart_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Hide()
        If MessageBox.Show("You must restart to complete the installation/uninstallation of RT50 Body PIS. Click OK to restart now or Cancel if you plan to restart later.", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.OK Then
            Me.Close()
            Shell("shutdown -r -f -t 3")
        Else
            Me.Close()
            Application.Exit()
        End If
    End Sub
End Class
