<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Skip
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.rdbLotBlock = New System.Windows.Forms.RadioButton
        Me.rdbSelectedPart = New System.Windows.Forms.RadioButton
        Me.lblLabel = New System.Windows.Forms.Label
        Me.labelBlockNo = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOk = New System.Windows.Forms.Button
        Me.lblValue = New System.Windows.Forms.Label
        Me.lblLabel2 = New System.Windows.Forms.Label
        Me.lblValue2 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'rdbLotBlock
        '
        Me.rdbLotBlock.AutoSize = True
        Me.rdbLotBlock.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.rdbLotBlock.Location = New System.Drawing.Point(78, 12)
        Me.rdbLotBlock.Name = "rdbLotBlock"
        Me.rdbLotBlock.Size = New System.Drawing.Size(159, 21)
        Me.rdbLotBlock.TabIndex = 0
        Me.rdbLotBlock.Text = "Lot No. part / BLOCK"
        Me.rdbLotBlock.UseVisualStyleBackColor = True
        '
        'rdbSelectedPart
        '
        Me.rdbSelectedPart.AutoSize = True
        Me.rdbSelectedPart.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.rdbSelectedPart.Location = New System.Drawing.Point(78, 39)
        Me.rdbSelectedPart.Name = "rdbSelectedPart"
        Me.rdbSelectedPart.Size = New System.Drawing.Size(110, 21)
        Me.rdbSelectedPart.TabIndex = 1
        Me.rdbSelectedPart.Text = "Selected part"
        Me.rdbSelectedPart.UseVisualStyleBackColor = True
        '
        'lblLabel
        '
        Me.lblLabel.AutoSize = True
        Me.lblLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblLabel.Location = New System.Drawing.Point(78, 115)
        Me.lblLabel.Name = "lblLabel"
        Me.lblLabel.Size = New System.Drawing.Size(54, 17)
        Me.lblLabel.TabIndex = 2
        Me.lblLabel.Text = "BLOCK"
        '
        'labelBlockNo
        '
        Me.labelBlockNo.AutoSize = True
        Me.labelBlockNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.labelBlockNo.Location = New System.Drawing.Point(175, 115)
        Me.labelBlockNo.Name = "labelBlockNo"
        Me.labelBlockNo.Size = New System.Drawing.Size(0, 17)
        Me.labelBlockNo.TabIndex = 3
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(325, 171)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(106, 29)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "F12:CANCEL"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnOk.Location = New System.Drawing.Point(198, 171)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(106, 29)
        Me.btnOk.TabIndex = 9
        Me.btnOk.Text = "F1:OK"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'lblValue
        '
        Me.lblValue.AutoSize = True
        Me.lblValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblValue.Location = New System.Drawing.Point(155, 115)
        Me.lblValue.Name = "lblValue"
        Me.lblValue.Size = New System.Drawing.Size(54, 17)
        Me.lblValue.TabIndex = 11
        Me.lblValue.Text = "BLOCK"
        '
        'lblLabel2
        '
        Me.lblLabel2.AutoSize = True
        Me.lblLabel2.Location = New System.Drawing.Point(255, 117)
        Me.lblLabel2.Name = "lblLabel2"
        Me.lblLabel2.Size = New System.Drawing.Size(39, 13)
        Me.lblLabel2.TabIndex = 12
        Me.lblLabel2.Text = "Label1"
        '
        'lblValue2
        '
        Me.lblValue2.AutoSize = True
        Me.lblValue2.Location = New System.Drawing.Point(322, 117)
        Me.lblValue2.Name = "lblValue2"
        Me.lblValue2.Size = New System.Drawing.Size(39, 13)
        Me.lblValue2.TabIndex = 13
        Me.lblValue2.Text = "Label2"
        '
        'Skip
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(494, 218)
        Me.Controls.Add(Me.lblValue2)
        Me.Controls.Add(Me.lblLabel2)
        Me.Controls.Add(Me.lblValue)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.labelBlockNo)
        Me.Controls.Add(Me.lblLabel)
        Me.Controls.Add(Me.rdbSelectedPart)
        Me.Controls.Add(Me.rdbLotBlock)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(500, 250)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(500, 250)
        Me.Name = "Skip"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SKIP"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rdbLotBlock As System.Windows.Forms.RadioButton
    Friend WithEvents rdbSelectedPart As System.Windows.Forms.RadioButton
    Friend WithEvents lblLabel As System.Windows.Forms.Label
    Friend WithEvents labelBlockNo As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents lblValue As System.Windows.Forms.Label
    Friend WithEvents lblLabel2 As System.Windows.Forms.Label
    Friend WithEvents lblValue2 As System.Windows.Forms.Label
End Class
