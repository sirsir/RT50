<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlPlcMessage
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
        Me.components = New System.ComponentModel.Container
        Me.smcPlc = New OMRON.Compolet.SYSMAC.SysmacCS(Me.components)
        Me.txtMessage = New System.Windows.Forms.TextBox
        Me.txtLane = New System.Windows.Forms.TextBox
        Me.lblEx = New System.Windows.Forms.Label
        Me.lblLane = New System.Windows.Forms.Label
        Me.lblStatus = New System.Windows.Forms.Label
        Me.txtStatus = New System.Windows.Forms.TextBox
        Me.lblError = New System.Windows.Forms.Label
        Me.lblProcess = New System.Windows.Forms.Label
        Me.btnExecute = New System.Windows.Forms.Button
        Me.lblSkitNo = New System.Windows.Forms.Label
        Me.txtSkitNo = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'smcPlc
        '
        Me.smcPlc.Active = False
        Me.smcPlc.DeviceName = ""
        Me.smcPlc.HeartBeatTimer = CType(0, Long)
        Me.smcPlc.NetworkAddress = CType(0, Short)
        Me.smcPlc.NodeAddress = CType(0, Short)
        Me.smcPlc.ReceiveTimeLimit = CType(750, Long)
        Me.smcPlc.UnitAddress = CType(0, Short)
        Me.smcPlc.UseNameServer = False
        '
        'txtMessage
        '
        Me.txtMessage.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMessage.Location = New System.Drawing.Point(341, 19)
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.Size = New System.Drawing.Size(272, 20)
        Me.txtMessage.TabIndex = 0
        '
        'txtLane
        '
        Me.txtLane.Location = New System.Drawing.Point(206, 19)
        Me.txtLane.MaxLength = 1
        Me.txtLane.Name = "txtLane"
        Me.txtLane.Size = New System.Drawing.Size(29, 20)
        Me.txtLane.TabIndex = 1
        '
        'lblEx
        '
        Me.lblEx.AutoSize = True
        Me.lblEx.Location = New System.Drawing.Point(242, 22)
        Me.lblEx.Name = "lblEx"
        Me.lblEx.Size = New System.Drawing.Size(98, 13)
        Me.lblEx.TabIndex = 2
        Me.lblEx.Text = "Message (Optional)"
        '
        'lblLane
        '
        Me.lblLane.AutoSize = True
        Me.lblLane.Location = New System.Drawing.Point(156, 22)
        Me.lblLane.Name = "lblLane"
        Me.lblLane.Size = New System.Drawing.Size(48, 13)
        Me.lblLane.TabIndex = 3
        Me.lblLane.Text = "Lane No"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(2, 22)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(37, 13)
        Me.lblStatus.TabIndex = 5
        Me.lblStatus.Text = "Status"
        '
        'txtStatus
        '
        Me.txtStatus.Location = New System.Drawing.Point(42, 19)
        Me.txtStatus.MaxLength = 2
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(29, 20)
        Me.txtStatus.TabIndex = 4
        Me.txtStatus.Text = "0"
        '
        'lblError
        '
        Me.lblError.AutoSize = True
        Me.lblError.ForeColor = System.Drawing.Color.Red
        Me.lblError.Location = New System.Drawing.Point(2, 48)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(39, 13)
        Me.lblError.TabIndex = 6
        Me.lblError.Text = "Label1"
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Location = New System.Drawing.Point(2, 4)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(39, 13)
        Me.lblProcess.TabIndex = 7
        Me.lblProcess.Text = "Label1"
        '
        'btnExecute
        '
        Me.btnExecute.Location = New System.Drawing.Point(538, 42)
        Me.btnExecute.Name = "btnExecute"
        Me.btnExecute.Size = New System.Drawing.Size(75, 23)
        Me.btnExecute.TabIndex = 8
        Me.btnExecute.Text = "Execute"
        Me.btnExecute.UseVisualStyleBackColor = True
        '
        'lblSkitNo
        '
        Me.lblSkitNo.AutoSize = True
        Me.lblSkitNo.Location = New System.Drawing.Point(77, 22)
        Me.lblSkitNo.Name = "lblSkitNo"
        Me.lblSkitNo.Size = New System.Drawing.Size(42, 13)
        Me.lblSkitNo.TabIndex = 10
        Me.lblSkitNo.Text = "Skit No"
        '
        'txtSkitNo
        '
        Me.txtSkitNo.Location = New System.Drawing.Point(122, 19)
        Me.txtSkitNo.MaxLength = 3
        Me.txtSkitNo.Name = "txtSkitNo"
        Me.txtSkitNo.Size = New System.Drawing.Size(29, 20)
        Me.txtSkitNo.TabIndex = 9
        '
        'ctrlPlcMessage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblSkitNo)
        Me.Controls.Add(Me.txtSkitNo)
        Me.Controls.Add(Me.btnExecute)
        Me.Controls.Add(Me.lblProcess)
        Me.Controls.Add(Me.lblError)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.lblLane)
        Me.Controls.Add(Me.lblEx)
        Me.Controls.Add(Me.txtLane)
        Me.Controls.Add(Me.txtMessage)
        Me.Name = "ctrlPlcMessage"
        Me.Size = New System.Drawing.Size(619, 69)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents smcPlc As OMRON.Compolet.SYSMAC.SysmacCS
    Friend WithEvents txtMessage As System.Windows.Forms.TextBox
    Friend WithEvents txtLane As System.Windows.Forms.TextBox
    Friend WithEvents lblEx As System.Windows.Forms.Label
    Friend WithEvents lblLane As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents lblError As System.Windows.Forms.Label
    Friend WithEvents lblProcess As System.Windows.Forms.Label
    Friend WithEvents btnExecute As System.Windows.Forms.Button
    Friend WithEvents lblSkitNo As System.Windows.Forms.Label
    Friend WithEvents txtSkitNo As System.Windows.Forms.TextBox

End Class
