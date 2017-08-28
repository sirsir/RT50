<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlProcess
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblProcCode = New System.Windows.Forms.Label
        Me.lblProcCount = New System.Windows.Forms.Label
        Me.lblProcName = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'lblProcCode
        '
        Me.lblProcCode.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblProcCode.BackColor = System.Drawing.SystemColors.Window
        Me.lblProcCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProcCode.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblProcCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcCode.Location = New System.Drawing.Point(1, 2)
        Me.lblProcCode.Name = "lblProcCode"
        Me.lblProcCode.Size = New System.Drawing.Size(30, 22)
        Me.lblProcCode.TabIndex = 12
        Me.lblProcCode.Text = "99"
        Me.lblProcCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblProcCount
        '
        Me.lblProcCount.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblProcCount.BackColor = System.Drawing.SystemColors.Window
        Me.lblProcCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProcCount.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblProcCount.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.lblProcCount.Location = New System.Drawing.Point(155, 2)
        Me.lblProcCount.Name = "lblProcCount"
        Me.lblProcCount.Size = New System.Drawing.Size(30, 22)
        Me.lblProcCount.TabIndex = 13
        Me.lblProcCount.Text = "99"
        Me.lblProcCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblProcName
        '
        Me.lblProcName.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblProcName.BackColor = System.Drawing.SystemColors.Window
        Me.lblProcName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProcName.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblProcName.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.lblProcName.Location = New System.Drawing.Point(34, 2)
        Me.lblProcName.Name = "lblProcName"
        Me.lblProcName.Size = New System.Drawing.Size(119, 22)
        Me.lblProcName.TabIndex = 14
        Me.lblProcName.Text = "99"
        Me.lblProcName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblProcName.UseMnemonic = False
        '
        'ctrlProcess
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.MistyRose
        Me.Controls.Add(Me.lblProcName)
        Me.Controls.Add(Me.lblProcCount)
        Me.Controls.Add(Me.lblProcCode)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ctrlProcess"
        Me.Size = New System.Drawing.Size(188, 26)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblProcCode As System.Windows.Forms.Label
    Friend WithEvents lblProcCount As System.Windows.Forms.Label
    Friend WithEvents lblProcName As System.Windows.Forms.Label

End Class
