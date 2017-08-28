<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlMenu
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
        Me.lblHeader2 = New System.Windows.Forms.Label
        Me.lblHeader1 = New System.Windows.Forms.Label
        Me.flp1 = New System.Windows.Forms.FlowLayoutPanel
        Me.btnF1 = New System.Windows.Forms.Button
        Me.btnF2 = New System.Windows.Forms.Button
        Me.btnF3 = New System.Windows.Forms.Button
        Me.btnF4 = New System.Windows.Forms.Button
        Me.btnF5 = New System.Windows.Forms.Button
        Me.btnF6 = New System.Windows.Forms.Button
        Me.btnF11 = New System.Windows.Forms.Button
        Me.btnF12 = New System.Windows.Forms.Button
        Me.flp2 = New System.Windows.Forms.FlowLayoutPanel
        Me.pnlF2 = New System.Windows.Forms.Panel
        Me.btnF2_1 = New System.Windows.Forms.Button
        Me.btnF2_2 = New System.Windows.Forms.Button
        Me.btnF2_3 = New System.Windows.Forms.Button
        Me.pnlF3 = New System.Windows.Forms.Panel
        Me.btnF3_1 = New System.Windows.Forms.Button
        Me.btnF3_2 = New System.Windows.Forms.Button
        Me.btnF3_3 = New System.Windows.Forms.Button
        Me.pnlF4 = New System.Windows.Forms.Panel
        Me.btnF4_1 = New System.Windows.Forms.Button
        Me.btnF4_2 = New System.Windows.Forms.Button
        Me.btnF4_3 = New System.Windows.Forms.Button
        Me.btnF11_1 = New System.Windows.Forms.Button
        Me.flp1.SuspendLayout()
        Me.flp2.SuspendLayout()
        Me.pnlF2.SuspendLayout()
        Me.pnlF3.SuspendLayout()
        Me.pnlF4.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblHeader2
        '
        Me.lblHeader2.BackColor = System.Drawing.Color.Yellow
        Me.lblHeader2.Font = New System.Drawing.Font("Arial", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader2.Location = New System.Drawing.Point(195, 55)
        Me.lblHeader2.Name = "lblHeader2"
        Me.lblHeader2.Size = New System.Drawing.Size(628, 55)
        Me.lblHeader2.TabIndex = 7
        Me.lblHeader2.Text = "INSTRUCTION SYSTEM"
        Me.lblHeader2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblHeader1
        '
        Me.lblHeader1.BackColor = System.Drawing.Color.Lime
        Me.lblHeader1.Font = New System.Drawing.Font("Arial", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader1.Location = New System.Drawing.Point(195, 0)
        Me.lblHeader1.Name = "lblHeader1"
        Me.lblHeader1.Size = New System.Drawing.Size(628, 55)
        Me.lblHeader1.TabIndex = 6
        Me.lblHeader1.Text = "RT50 PAINT PRODUCTION"
        Me.lblHeader1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'flp1
        '
        Me.flp1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flp1.Controls.Add(Me.btnF1)
        Me.flp1.Controls.Add(Me.btnF2)
        Me.flp1.Controls.Add(Me.btnF3)
        Me.flp1.Controls.Add(Me.btnF4)
        Me.flp1.Controls.Add(Me.btnF5)
        Me.flp1.Controls.Add(Me.btnF6)
        Me.flp1.Controls.Add(Me.btnF11)
        Me.flp1.Controls.Add(Me.btnF12)
        Me.flp1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flp1.Location = New System.Drawing.Point(3, 111)
        Me.flp1.Name = "flp1"
        Me.flp1.Size = New System.Drawing.Size(504, 497)
        Me.flp1.TabIndex = 0
        '
        'btnF1
        '
        Me.btnF1.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnF1.Location = New System.Drawing.Point(3, 3)
        Me.btnF1.Name = "btnF1"
        Me.btnF1.Size = New System.Drawing.Size(498, 43)
        Me.btnF1.TabIndex = 0
        Me.btnF1.Tag = "F1"
        Me.btnF1.Text = "F1: INSTRUCTION DATA"
        Me.btnF1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnF1.UseVisualStyleBackColor = True
        '
        'btnF2
        '
        Me.btnF2.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnF2.Location = New System.Drawing.Point(3, 52)
        Me.btnF2.Name = "btnF2"
        Me.btnF2.Size = New System.Drawing.Size(498, 43)
        Me.btnF2.TabIndex = 1
        Me.btnF2.Tag = "F2"
        Me.btnF2.Text = "F2: PROGRESS                              >"
        Me.btnF2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnF2.UseVisualStyleBackColor = True
        '
        'btnF3
        '
        Me.btnF3.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnF3.Location = New System.Drawing.Point(3, 101)
        Me.btnF3.Name = "btnF3"
        Me.btnF3.Size = New System.Drawing.Size(498, 43)
        Me.btnF3.TabIndex = 3
        Me.btnF3.Tag = "F3"
        Me.btnF3.Text = "F3: PASS RESULT                          >"
        Me.btnF3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnF3.UseVisualStyleBackColor = True
        '
        'btnF4
        '
        Me.btnF4.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnF4.Location = New System.Drawing.Point(3, 150)
        Me.btnF4.Name = "btnF4"
        Me.btnF4.Size = New System.Drawing.Size(498, 43)
        Me.btnF4.TabIndex = 4
        Me.btnF4.Tag = "F4"
        Me.btnF4.Text = "F4: MASTER DATA                         >"
        Me.btnF4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnF4.UseVisualStyleBackColor = True
        '
        'btnF5
        '
        Me.btnF5.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnF5.Location = New System.Drawing.Point(3, 199)
        Me.btnF5.Name = "btnF5"
        Me.btnF5.Size = New System.Drawing.Size(498, 43)
        Me.btnF5.TabIndex = 5
        Me.btnF5.Tag = "F5"
        Me.btnF5.Text = "F5: MODEL OPTION SETTING"
        Me.btnF5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnF5.UseVisualStyleBackColor = True
        '
        'btnF6
        '
        Me.btnF6.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnF6.Location = New System.Drawing.Point(3, 248)
        Me.btnF6.Name = "btnF6"
        Me.btnF6.Size = New System.Drawing.Size(498, 43)
        Me.btnF6.TabIndex = 6
        Me.btnF6.Tag = "F6"
        Me.btnF6.Text = "F6: PROCESS OPTION SETTING"
        Me.btnF6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnF6.UseVisualStyleBackColor = True
        '
        'btnF11
        '
        Me.btnF11.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnF11.Location = New System.Drawing.Point(3, 297)
        Me.btnF11.Name = "btnF11"
        Me.btnF11.Size = New System.Drawing.Size(498, 43)
        Me.btnF11.TabIndex = 10
        Me.btnF11.Tag = "F11"
        Me.btnF11.Text = "F11: LOG DATA"
        Me.btnF11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnF11.UseVisualStyleBackColor = True
        '
        'btnF12
        '
        Me.btnF12.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnF12.Location = New System.Drawing.Point(3, 346)
        Me.btnF12.Name = "btnF12"
        Me.btnF12.Size = New System.Drawing.Size(498, 43)
        Me.btnF12.TabIndex = 20
        Me.btnF12.Tag = "F12"
        Me.btnF12.Text = "F12: SHUTDOWN"
        Me.btnF12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnF12.UseVisualStyleBackColor = True
        '
        'flp2
        '
        Me.flp2.Controls.Add(Me.pnlF2)
        Me.flp2.Controls.Add(Me.pnlF3)
        Me.flp2.Controls.Add(Me.pnlF4)
        Me.flp2.Controls.Add(Me.btnF11_1)
        Me.flp2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flp2.Location = New System.Drawing.Point(507, 111)
        Me.flp2.Name = "flp2"
        Me.flp2.Size = New System.Drawing.Size(504, 497)
        Me.flp2.TabIndex = 1
        Me.flp2.TabStop = True
        '
        'pnlF2
        '
        Me.pnlF2.Controls.Add(Me.btnF2_1)
        Me.pnlF2.Controls.Add(Me.btnF2_2)
        Me.pnlF2.Controls.Add(Me.btnF2_3)
        Me.pnlF2.Location = New System.Drawing.Point(3, 3)
        Me.pnlF2.Name = "pnlF2"
        Me.pnlF2.Size = New System.Drawing.Size(498, 141)
        Me.pnlF2.TabIndex = 0
        Me.pnlF2.Tag = "F2"
        Me.pnlF2.Visible = False
        '
        'btnF2_1
        '
        Me.btnF2_1.Enabled = False
        Me.btnF2_1.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnF2_1.Location = New System.Drawing.Point(0, 0)
        Me.btnF2_1.Name = "btnF2_1"
        Me.btnF2_1.Size = New System.Drawing.Size(498, 43)
        Me.btnF2_1.TabIndex = 0
        Me.btnF2_1.Tag = "F2_1"
        Me.btnF2_1.Text = "F1: WBS"
        Me.btnF2_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnF2_1.UseVisualStyleBackColor = True
        '
        'btnF2_2
        '
        Me.btnF2_2.Enabled = False
        Me.btnF2_2.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnF2_2.Location = New System.Drawing.Point(0, 49)
        Me.btnF2_2.Name = "btnF2_2"
        Me.btnF2_2.Size = New System.Drawing.Size(498, 43)
        Me.btnF2_2.TabIndex = 1
        Me.btnF2_2.Tag = "F2_2"
        Me.btnF2_2.Text = "F2: WBS MONITORING"
        Me.btnF2_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnF2_2.UseVisualStyleBackColor = True
        '
        'btnF2_3
        '
        Me.btnF2_3.Enabled = False
        Me.btnF2_3.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnF2_3.Location = New System.Drawing.Point(0, 98)
        Me.btnF2_3.Name = "btnF2_3"
        Me.btnF2_3.Size = New System.Drawing.Size(498, 43)
        Me.btnF2_3.TabIndex = 2
        Me.btnF2_3.Tag = "F2_3"
        Me.btnF2_3.Text = "F3: PAINT"
        Me.btnF2_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnF2_3.UseVisualStyleBackColor = True
        '
        'pnlF3
        '
        Me.pnlF3.Controls.Add(Me.btnF3_1)
        Me.pnlF3.Controls.Add(Me.btnF3_2)
        Me.pnlF3.Controls.Add(Me.btnF3_3)
        Me.pnlF3.Location = New System.Drawing.Point(3, 150)
        Me.pnlF3.Name = "pnlF3"
        Me.pnlF3.Size = New System.Drawing.Size(498, 141)
        Me.pnlF3.TabIndex = 0
        Me.pnlF3.Tag = "F3"
        Me.pnlF3.Visible = False
        '
        'btnF3_1
        '
        Me.btnF3_1.Enabled = False
        Me.btnF3_1.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnF3_1.Location = New System.Drawing.Point(0, 0)
        Me.btnF3_1.Name = "btnF3_1"
        Me.btnF3_1.Size = New System.Drawing.Size(498, 43)
        Me.btnF3_1.TabIndex = 0
        Me.btnF3_1.Tag = "F3_1"
        Me.btnF3_1.Text = "F1: WBS"
        Me.btnF3_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnF3_1.UseVisualStyleBackColor = True
        '
        'btnF3_2
        '
        Me.btnF3_2.Enabled = False
        Me.btnF3_2.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnF3_2.Location = New System.Drawing.Point(0, 49)
        Me.btnF3_2.Name = "btnF3_2"
        Me.btnF3_2.Size = New System.Drawing.Size(498, 43)
        Me.btnF3_2.TabIndex = 1
        Me.btnF3_2.Tag = "F3_2"
        Me.btnF3_2.Text = "F2: PAINT"
        Me.btnF3_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnF3_2.UseVisualStyleBackColor = True
        '
        'btnF3_3
        '
        Me.btnF3_3.Enabled = False
        Me.btnF3_3.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnF3_3.Location = New System.Drawing.Point(0, 98)
        Me.btnF3_3.Name = "btnF3_3"
        Me.btnF3_3.Size = New System.Drawing.Size(498, 43)
        Me.btnF3_3.TabIndex = 2
        Me.btnF3_3.Tag = "F3_3"
        Me.btnF3_3.Text = "F3: PBR"
        Me.btnF3_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnF3_3.UseVisualStyleBackColor = True
        '
        'pnlF4
        '
        Me.pnlF4.Controls.Add(Me.btnF4_1)
        Me.pnlF4.Controls.Add(Me.btnF4_2)
        Me.pnlF4.Controls.Add(Me.btnF4_3)
        Me.pnlF4.Location = New System.Drawing.Point(3, 297)
        Me.pnlF4.Name = "pnlF4"
        Me.pnlF4.Size = New System.Drawing.Size(498, 141)
        Me.pnlF4.TabIndex = 0
        Me.pnlF4.Tag = "F4"
        Me.pnlF4.Visible = False
        '
        'btnF4_1
        '
        Me.btnF4_1.Enabled = False
        Me.btnF4_1.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnF4_1.Location = New System.Drawing.Point(0, 0)
        Me.btnF4_1.Name = "btnF4_1"
        Me.btnF4_1.Size = New System.Drawing.Size(498, 43)
        Me.btnF4_1.TabIndex = 0
        Me.btnF4_1.Tag = "F4_1"
        Me.btnF4_1.Text = "F1: OPTION"
        Me.btnF4_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnF4_1.UseVisualStyleBackColor = True
        '
        'btnF4_2
        '
        Me.btnF4_2.Enabled = False
        Me.btnF4_2.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnF4_2.Location = New System.Drawing.Point(0, 49)
        Me.btnF4_2.Name = "btnF4_2"
        Me.btnF4_2.Size = New System.Drawing.Size(498, 43)
        Me.btnF4_2.TabIndex = 1
        Me.btnF4_2.Tag = "F4_2"
        Me.btnF4_2.Text = "F2: PLC"
        Me.btnF4_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnF4_2.UseVisualStyleBackColor = True
        '
        'btnF4_3
        '
        Me.btnF4_3.Enabled = False
        Me.btnF4_3.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnF4_3.Location = New System.Drawing.Point(0, 98)
        Me.btnF4_3.Name = "btnF4_3"
        Me.btnF4_3.Size = New System.Drawing.Size(498, 43)
        Me.btnF4_3.TabIndex = 2
        Me.btnF4_3.Tag = "F4_3"
        Me.btnF4_3.Text = "F3: PROCESS"
        Me.btnF4_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnF4_3.UseVisualStyleBackColor = True
        '
        'btnF11_1
        '
        Me.btnF11_1.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnF11_1.Location = New System.Drawing.Point(3, 444)
        Me.btnF11_1.Name = "btnF11_1"
        Me.btnF11_1.Size = New System.Drawing.Size(498, 43)
        Me.btnF11_1.TabIndex = 1
        Me.btnF11_1.Tag = "F11_1"
        Me.btnF11_1.Text = "F11: BACK"
        Me.btnF11_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnF11_1.UseVisualStyleBackColor = True
        Me.btnF11_1.Visible = False
        '
        'ctrlMenu
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.flp2)
        Me.Controls.Add(Me.flp1)
        Me.Controls.Add(Me.lblHeader2)
        Me.Controls.Add(Me.lblHeader1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ctrlMenu"
        Me.Size = New System.Drawing.Size(1014, 615)
        Me.flp1.ResumeLayout(False)
        Me.flp2.ResumeLayout(False)
        Me.pnlF2.ResumeLayout(False)
        Me.pnlF3.ResumeLayout(False)
        Me.pnlF4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblHeader2 As System.Windows.Forms.Label
    Friend WithEvents lblHeader1 As System.Windows.Forms.Label
    Friend WithEvents flp1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnF1 As System.Windows.Forms.Button
    Friend WithEvents btnF2 As System.Windows.Forms.Button
    Friend WithEvents btnF3 As System.Windows.Forms.Button
    Friend WithEvents btnF4 As System.Windows.Forms.Button
    Friend WithEvents btnF5 As System.Windows.Forms.Button
    Friend WithEvents btnF6 As System.Windows.Forms.Button
    Friend WithEvents btnF11 As System.Windows.Forms.Button
    Friend WithEvents btnF12 As System.Windows.Forms.Button
    Friend WithEvents flp2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pnlF2 As System.Windows.Forms.Panel
    Friend WithEvents btnF2_1 As System.Windows.Forms.Button
    Friend WithEvents btnF2_2 As System.Windows.Forms.Button
    Friend WithEvents btnF2_3 As System.Windows.Forms.Button
    Friend WithEvents pnlF3 As System.Windows.Forms.Panel
    Friend WithEvents btnF3_1 As System.Windows.Forms.Button
    Friend WithEvents btnF3_2 As System.Windows.Forms.Button
    Friend WithEvents btnF3_3 As System.Windows.Forms.Button
    Friend WithEvents pnlF4 As System.Windows.Forms.Panel
    Friend WithEvents btnF4_1 As System.Windows.Forms.Button
    Friend WithEvents btnF4_2 As System.Windows.Forms.Button
    Friend WithEvents btnF4_3 As System.Windows.Forms.Button
    Friend WithEvents btnF11_1 As System.Windows.Forms.Button

End Class
