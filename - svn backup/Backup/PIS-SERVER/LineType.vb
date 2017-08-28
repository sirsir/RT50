Public Class LineType

    Public row As Integer
    Public LineCode As Integer
    Public LineName As String

    Private Sub LineType_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.lblLineCode.Text = LineCode.ToString
        Me.lblLineName.Text = LineName.ToString
    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click

        If rdobCAB.Checked Then
            SystemSetting.dtgLineMST.Item(2, row).Value = 1
        ElseIf rdobPUBX.Checked Then
            SystemSetting.dtgLineMST.Item(2, row).Value = 2
        End If

        Me.Dispose()
        SystemSetting.Enabled = True
        SystemSetting.Activate()

    End Sub
    
End Class