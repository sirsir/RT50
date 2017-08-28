<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlTxtInputWithChecking
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
        Me.lblError = New System.Windows.Forms.Label
        Me.txtInput = New System.Windows.Forms.TextBox
        Me.lblInput = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'lblError
        '
        Me.lblError.AutoSize = True
        Me.lblError.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblError.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblError.ForeColor = System.Drawing.Color.Red
        Me.lblError.Location = New System.Drawing.Point(4, 32)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(93, 16)
        Me.lblError.TabIndex = 24
        Me.lblError.Text = "Error Message"
        '
        'txtInput
        '
        Me.txtInput.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInput.Location = New System.Drawing.Point(253, 8)
        Me.txtInput.MaxLength = 0
        Me.txtInput.Name = "txtInput"
        Me.txtInput.Size = New System.Drawing.Size(121, 20)
        Me.txtInput.TabIndex = 23
        '
        'lblInput
        '
        Me.lblInput.BackColor = System.Drawing.SystemColors.Control
        Me.lblInput.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInput.Location = New System.Drawing.Point(6, 6)
        Me.lblInput.Name = "lblInput"
        Me.lblInput.Size = New System.Drawing.Size(370, 24)
        Me.lblInput.TabIndex = 22
        Me.lblInput.Text = "Input Name"
        Me.lblInput.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ctrlTxtInputWithChecking
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Controls.Add(Me.lblError)
        Me.Controls.Add(Me.txtInput)
        Me.Controls.Add(Me.lblInput)
        Me.Name = "ctrlTxtInputWithChecking"
        Me.Size = New System.Drawing.Size(380, 55)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblError As System.Windows.Forms.Label
    Friend WithEvents txtInput As System.Windows.Forms.TextBox
    Friend WithEvents lblInput As System.Windows.Forms.Label

End Class
