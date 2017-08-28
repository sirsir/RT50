<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main_Menu
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
        Me.components = New System.ComponentModel.Container
        Me.lblText1 = New System.Windows.Forms.Label
        Me.lblText2 = New System.Windows.Forms.Label
        Me.btnF1 = New System.Windows.Forms.Button
        Me.btnF2 = New System.Windows.Forms.Button
        Me.btnF3 = New System.Windows.Forms.Button
        Me.btnF5 = New System.Windows.Forms.Button
        Me.btnF12 = New System.Windows.Forms.Button
        Me.cmboxLogInfo = New System.Windows.Forms.ComboBox
        Me.TLOGDATBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSet1 = New InstructionSystem.DataSet1
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.T_LOG_DATTableAdapter = New InstructionSystem.DataSet1TableAdapters.T_LOG_DATTableAdapter
        Me.Label1 = New System.Windows.Forms.Label
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.T_Instruction_DATTableAdapter = New InstructionSystem.DataSet1TableAdapters.T_Instruction_DATTableAdapter
        Me.T_Production_DATTableAdapter = New InstructionSystem.DataSet1TableAdapters.T_Production_DATTableAdapter
        Me.btnClear = New System.Windows.Forms.Button
        CType(Me.TLOGDATBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblText1
        '
        Me.lblText1.AutoSize = True
        Me.lblText1.BackColor = System.Drawing.Color.Lime
        Me.lblText1.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblText1.Location = New System.Drawing.Point(196, 9)
        Me.lblText1.Name = "lblText1"
        Me.lblText1.Size = New System.Drawing.Size(627, 55)
        Me.lblText1.TabIndex = 0
        Me.lblText1.Text = "RT50 BODY PRODUCTION"
        Me.lblText1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblText2
        '
        Me.lblText2.BackColor = System.Drawing.Color.Yellow
        Me.lblText2.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblText2.Location = New System.Drawing.Point(196, 64)
        Me.lblText2.Name = "lblText2"
        Me.lblText2.Size = New System.Drawing.Size(627, 55)
        Me.lblText2.TabIndex = 1
        Me.lblText2.Text = "INSTRUCTION SYSTEM"
        Me.lblText2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnF1
        '
        Me.btnF1.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnF1.Location = New System.Drawing.Point(64, 139)
        Me.btnF1.Name = "btnF1"
        Me.btnF1.Size = New System.Drawing.Size(886, 90)
        Me.btnF1.TabIndex = 2
        Me.btnF1.Text = "F1 PRODUCTION DATA"
        Me.btnF1.UseVisualStyleBackColor = True
        '
        'btnF2
        '
        Me.btnF2.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnF2.Location = New System.Drawing.Point(64, 249)
        Me.btnF2.Name = "btnF2"
        Me.btnF2.Size = New System.Drawing.Size(886, 90)
        Me.btnF2.TabIndex = 3
        Me.btnF2.Text = "F2 INSTRUCTION SCHEDULE"
        Me.btnF2.UseVisualStyleBackColor = True
        '
        'btnF3
        '
        Me.btnF3.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnF3.Location = New System.Drawing.Point(64, 359)
        Me.btnF3.Name = "btnF3"
        Me.btnF3.Size = New System.Drawing.Size(886, 90)
        Me.btnF3.TabIndex = 4
        Me.btnF3.Text = "F3 CARRY OUT SCHEDULE"
        Me.btnF3.UseVisualStyleBackColor = True
        '
        'btnF5
        '
        Me.btnF5.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnF5.Location = New System.Drawing.Point(64, 468)
        Me.btnF5.Name = "btnF5"
        Me.btnF5.Size = New System.Drawing.Size(886, 90)
        Me.btnF5.TabIndex = 5
        Me.btnF5.Text = "F5 DATA LOG"
        Me.btnF5.UseVisualStyleBackColor = True
        '
        'btnF12
        '
        Me.btnF12.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnF12.Location = New System.Drawing.Point(64, 574)
        Me.btnF12.Name = "btnF12"
        Me.btnF12.Size = New System.Drawing.Size(886, 90)
        Me.btnF12.TabIndex = 6
        Me.btnF12.Text = "F12 SHUT DOWN"
        Me.btnF12.UseVisualStyleBackColor = True
        '
        'cmboxLogInfo
        '
        Me.cmboxLogInfo.DataSource = Me.TLOGDATBindingSource
        Me.cmboxLogInfo.DisplayMember = "logDetail"
        Me.cmboxLogInfo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmboxLogInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmboxLogInfo.FormattingEnabled = True
        Me.cmboxLogInfo.Location = New System.Drawing.Point(64, 683)
        Me.cmboxLogInfo.MaxDropDownItems = 30
        Me.cmboxLogInfo.Name = "cmboxLogInfo"
        Me.cmboxLogInfo.Size = New System.Drawing.Size(771, 24)
        Me.cmboxLogInfo.TabIndex = 7
        '
        'TLOGDATBindingSource
        '
        Me.TLOGDATBindingSource.DataMember = "T_LOG_DAT"
        Me.TLOGDATBindingSource.DataSource = Me.DataSet1
        '
        'DataSet1
        '
        Me.DataSet1.DataSetName = "DataSet1"
        Me.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Timer1
        '
        Me.Timer1.Interval = 2000
        '
        'T_LOG_DATTableAdapter
        '
        Me.T_LOG_DATTableAdapter.ClearBeforeFill = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(874, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 66
        Me.Label1.Text = "Label1"
        '
        'Timer2
        '
        '
        'T_Instruction_DATTableAdapter
        '
        Me.T_Instruction_DATTableAdapter.ClearBeforeFill = True
        '
        'T_Production_DATTableAdapter
        '
        Me.T_Production_DATTableAdapter.ClearBeforeFill = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(841, 682)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(109, 24)
        Me.btnClear.TabIndex = 67
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'Main_Menu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(1016, 734)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmboxLogInfo)
        Me.Controls.Add(Me.btnF12)
        Me.Controls.Add(Me.btnF5)
        Me.Controls.Add(Me.btnF3)
        Me.Controls.Add(Me.btnF2)
        Me.Controls.Add(Me.btnF1)
        Me.Controls.Add(Me.lblText2)
        Me.Controls.Add(Me.lblText1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximumSize = New System.Drawing.Size(1024, 768)
        Me.MinimumSize = New System.Drawing.Size(1022, 732)
        Me.Name = "Main_Menu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "INSTRUCTION SYSTEM MAIN MENU"
        CType(Me.TLOGDATBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblText1 As System.Windows.Forms.Label
    Friend WithEvents lblText2 As System.Windows.Forms.Label
    Friend WithEvents btnF1 As System.Windows.Forms.Button
    Friend WithEvents btnF2 As System.Windows.Forms.Button
    Friend WithEvents btnF3 As System.Windows.Forms.Button
    Friend WithEvents btnF5 As System.Windows.Forms.Button
    Friend WithEvents btnF12 As System.Windows.Forms.Button
    Friend WithEvents cmboxLogInfo As System.Windows.Forms.ComboBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents DataSet1 As InstructionSystem.DataSet1
    Friend WithEvents TLOGDATBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents T_LOG_DATTableAdapter As InstructionSystem.DataSet1TableAdapters.T_LOG_DATTableAdapter
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents T_Instruction_DATTableAdapter As InstructionSystem.DataSet1TableAdapters.T_Instruction_DATTableAdapter
    Friend WithEvents T_Production_DATTableAdapter As InstructionSystem.DataSet1TableAdapters.T_Production_DATTableAdapter
    Friend WithEvents btnClear As System.Windows.Forms.Button

End Class
