<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProcessMaster_AddEdit
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
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnExecute = New System.Windows.Forms.Button
        Me.lblProcName = New System.Windows.Forms.Label
        Me.txtProcName = New System.Windows.Forms.TextBox
        Me.cboProcType = New System.Windows.Forms.ComboBox
        Me.lblProcType = New System.Windows.Forms.Label
        Me.lblProcTime = New System.Windows.Forms.Label
        Me.lblMsgProcName = New System.Windows.Forms.Label
        Me.txtProcTime = New System.Windows.Forms.TextBox
        Me.lblMsgProcTime = New System.Windows.Forms.Label
        Me.lblProcCode = New System.Windows.Forms.Label
        Me.nmrProcCode = New System.Windows.Forms.NumericUpDown
        Me.lblMsgProcCode = New System.Windows.Forms.Label
        Me.cboProcGroup = New System.Windows.Forms.ComboBox
        Me.dsPAINT1 = New Common.dsPAINT
        Me.lblProcGroup = New System.Windows.Forms.Label
        Me.taOPTION_MST1 = New Common.dsPAINTTableAdapters.taOPTION_MST
        Me.taPROCESS_MST1 = New Common.dsPAINTTableAdapters.taPROCESS_MST
        Me.taPROCESS_OPTION_CELL1 = New Common.dsPAINTTableAdapters.taPROCESS_OPTION_CELL
        Me.taPROCESS_GROUP_MST1 = New Common.dsPAINTTableAdapters.taPROCESS_GROUP_MST
        CType(Me.nmrProcCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsPAINT1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(213, 280)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(106, 29)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "CANCEL"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnExecute
        '
        Me.btnExecute.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnExecute.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExecute.Location = New System.Drawing.Point(75, 280)
        Me.btnExecute.Name = "btnExecute"
        Me.btnExecute.Size = New System.Drawing.Size(106, 29)
        Me.btnExecute.TabIndex = 4
        Me.btnExecute.Text = "EXECUTION"
        Me.btnExecute.UseVisualStyleBackColor = True
        '
        'lblProcName
        '
        Me.lblProcName.BackColor = System.Drawing.SystemColors.Control
        Me.lblProcName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcName.Location = New System.Drawing.Point(10, 61)
        Me.lblProcName.Name = "lblProcName"
        Me.lblProcName.Size = New System.Drawing.Size(370, 24)
        Me.lblProcName.TabIndex = 7
        Me.lblProcName.Text = "Process Name"
        Me.lblProcName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtProcName
        '
        Me.txtProcName.BackColor = System.Drawing.SystemColors.Window
        Me.txtProcName.Location = New System.Drawing.Point(178, 62)
        Me.txtProcName.Name = "txtProcName"
        Me.txtProcName.Size = New System.Drawing.Size(200, 22)
        Me.txtProcName.TabIndex = 1
        '
        'cboProcType
        '
        Me.cboProcType.DisplayMember = "Display"
        Me.cboProcType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProcType.FormattingEnabled = True
        Me.cboProcType.Location = New System.Drawing.Point(178, 162)
        Me.cboProcType.Name = "cboProcType"
        Me.cboProcType.Size = New System.Drawing.Size(200, 24)
        Me.cboProcType.TabIndex = 3
        Me.cboProcType.ValueMember = "Value"
        '
        'lblProcType
        '
        Me.lblProcType.BackColor = System.Drawing.SystemColors.Control
        Me.lblProcType.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcType.Location = New System.Drawing.Point(10, 161)
        Me.lblProcType.Name = "lblProcType"
        Me.lblProcType.Size = New System.Drawing.Size(370, 26)
        Me.lblProcType.TabIndex = 11
        Me.lblProcType.Text = "Process Type"
        Me.lblProcType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblProcTime
        '
        Me.lblProcTime.BackColor = System.Drawing.SystemColors.Control
        Me.lblProcTime.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcTime.Location = New System.Drawing.Point(10, 111)
        Me.lblProcTime.Name = "lblProcTime"
        Me.lblProcTime.Size = New System.Drawing.Size(370, 24)
        Me.lblProcTime.TabIndex = 9
        Me.lblProcTime.Text = "Process Time (sec)"
        Me.lblProcTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMsgProcName
        '
        Me.lblMsgProcName.AutoSize = True
        Me.lblMsgProcName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsgProcName.ForeColor = System.Drawing.Color.Red
        Me.lblMsgProcName.Location = New System.Drawing.Point(10, 85)
        Me.lblMsgProcName.Name = "lblMsgProcName"
        Me.lblMsgProcName.Size = New System.Drawing.Size(129, 16)
        Me.lblMsgProcName.TabIndex = 8
        Me.lblMsgProcName.Text = "Notification Message"
        '
        'txtProcTime
        '
        Me.txtProcTime.Location = New System.Drawing.Point(328, 112)
        Me.txtProcTime.MaxLength = 4
        Me.txtProcTime.Name = "txtProcTime"
        Me.txtProcTime.Size = New System.Drawing.Size(50, 22)
        Me.txtProcTime.TabIndex = 2
        Me.txtProcTime.Text = "0"
        Me.txtProcTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblMsgProcTime
        '
        Me.lblMsgProcTime.AutoSize = True
        Me.lblMsgProcTime.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsgProcTime.ForeColor = System.Drawing.Color.Red
        Me.lblMsgProcTime.Location = New System.Drawing.Point(10, 135)
        Me.lblMsgProcTime.Name = "lblMsgProcTime"
        Me.lblMsgProcTime.Size = New System.Drawing.Size(129, 16)
        Me.lblMsgProcTime.TabIndex = 10
        Me.lblMsgProcTime.Text = "Notification Message"
        '
        'lblProcCode
        '
        Me.lblProcCode.BackColor = System.Drawing.SystemColors.Control
        Me.lblProcCode.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcCode.Location = New System.Drawing.Point(10, 12)
        Me.lblProcCode.Name = "lblProcCode"
        Me.lblProcCode.Size = New System.Drawing.Size(370, 24)
        Me.lblProcCode.TabIndex = 6
        Me.lblProcCode.Text = "Process Code"
        Me.lblProcCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'nmrProcCode
        '
        Me.nmrProcCode.Location = New System.Drawing.Point(328, 13)
        Me.nmrProcCode.Name = "nmrProcCode"
        Me.nmrProcCode.Size = New System.Drawing.Size(50, 22)
        Me.nmrProcCode.TabIndex = 0
        Me.nmrProcCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblMsgProcCode
        '
        Me.lblMsgProcCode.AutoSize = True
        Me.lblMsgProcCode.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsgProcCode.ForeColor = System.Drawing.Color.Red
        Me.lblMsgProcCode.Location = New System.Drawing.Point(10, 36)
        Me.lblMsgProcCode.Name = "lblMsgProcCode"
        Me.lblMsgProcCode.Size = New System.Drawing.Size(129, 16)
        Me.lblMsgProcCode.TabIndex = 12
        Me.lblMsgProcCode.Text = "Notification Message"
        '
        'cboProcGroup
        '
        Me.cboProcGroup.DataSource = Me.dsPAINT1
        Me.cboProcGroup.DisplayMember = "dtPROCESS_GROUP_MST.PROCESS_GROUP_NAME"
        Me.cboProcGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProcGroup.FormattingEnabled = True
        Me.cboProcGroup.Location = New System.Drawing.Point(178, 213)
        Me.cboProcGroup.Name = "cboProcGroup"
        Me.cboProcGroup.Size = New System.Drawing.Size(200, 24)
        Me.cboProcGroup.TabIndex = 14
        Me.cboProcGroup.ValueMember = "dtPROCESS_GROUP_MST.PROCESS_GROUP_ID"
        '
        'dsPAINT1
        '
        Me.dsPAINT1.DataSetName = "dsPAINT"
        Me.dsPAINT1.Locale = New System.Globalization.CultureInfo("th-TH")
        Me.dsPAINT1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'lblProcGroup
        '
        Me.lblProcGroup.BackColor = System.Drawing.SystemColors.Control
        Me.lblProcGroup.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcGroup.Location = New System.Drawing.Point(10, 212)
        Me.lblProcGroup.Name = "lblProcGroup"
        Me.lblProcGroup.Size = New System.Drawing.Size(370, 26)
        Me.lblProcGroup.TabIndex = 15
        Me.lblProcGroup.Text = "Process Group"
        Me.lblProcGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'taOPTION_MST1
        '
        Me.taOPTION_MST1.ClearBeforeFill = True
        '
        'taPROCESS_MST1
        '
        Me.taPROCESS_MST1.ClearBeforeFill = True
        '
        'taPROCESS_OPTION_CELL1
        '
        Me.taPROCESS_OPTION_CELL1.ClearBeforeFill = True
        '
        'taPROCESS_GROUP_MST1
        '
        Me.taPROCESS_GROUP_MST1.ClearBeforeFill = True
        '
        'frmProcessMaster_AddEdit
        '
        Me.AcceptButton = Me.btnExecute
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(394, 326)
        Me.Controls.Add(Me.cboProcGroup)
        Me.Controls.Add(Me.lblProcGroup)
        Me.Controls.Add(Me.lblMsgProcCode)
        Me.Controls.Add(Me.txtProcName)
        Me.Controls.Add(Me.lblProcName)
        Me.Controls.Add(Me.nmrProcCode)
        Me.Controls.Add(Me.lblProcCode)
        Me.Controls.Add(Me.lblMsgProcTime)
        Me.Controls.Add(Me.txtProcTime)
        Me.Controls.Add(Me.lblMsgProcName)
        Me.Controls.Add(Me.lblProcTime)
        Me.Controls.Add(Me.cboProcType)
        Me.Controls.Add(Me.lblProcType)
        Me.Controls.Add(Me.btnExecute)
        Me.Controls.Add(Me.btnCancel)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmProcessMaster_AddEdit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "{0} PROCESS MASTER"
        CType(Me.nmrProcCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsPAINT1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnExecute As System.Windows.Forms.Button
    Friend WithEvents dsPAINT1 As Common.dsPAINT
    Friend WithEvents taOPTION_MST1 As taOPTION_MST
    Friend WithEvents lblProcName As System.Windows.Forms.Label
    Friend WithEvents txtProcName As System.Windows.Forms.TextBox
    Friend WithEvents taPROCESS_MST1 As taPROCESS_MST
    Friend WithEvents taPROCESS_OPTION_CELL1 As taPROCESS_OPTION_CELL
    Friend WithEvents cboProcType As System.Windows.Forms.ComboBox
    Friend WithEvents lblProcType As System.Windows.Forms.Label
    Friend WithEvents lblProcTime As System.Windows.Forms.Label
    Friend WithEvents lblMsgProcName As System.Windows.Forms.Label
    Friend WithEvents txtProcTime As System.Windows.Forms.TextBox
    Friend WithEvents lblMsgProcTime As System.Windows.Forms.Label
    Friend WithEvents lblProcCode As System.Windows.Forms.Label
    Friend WithEvents nmrProcCode As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblMsgProcCode As System.Windows.Forms.Label
    Friend WithEvents cboProcGroup As System.Windows.Forms.ComboBox
    Friend WithEvents lblProcGroup As System.Windows.Forms.Label
    Friend WithEvents taPROCESS_GROUP_MST1 As taPROCESS_GROUP_MST
End Class
