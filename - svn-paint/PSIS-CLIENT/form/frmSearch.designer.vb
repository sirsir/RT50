<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSearch
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblModelCode = New System.Windows.Forms.Label
        Me.lblLotNo = New System.Windows.Forms.Label
        Me.lblUnitNo = New System.Windows.Forms.Label
        Me.txtModelCode = New System.Windows.Forms.TextBox
        Me.txtLotNo = New System.Windows.Forms.TextBox
        Me.txtUnitNo = New System.Windows.Forms.TextBox
        Me.btnExecution = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.lblMsg = New System.Windows.Forms.Label
        Me.lblSkitNo = New System.Windows.Forms.Label
        Me.txtSkitNo = New System.Windows.Forms.TextBox
        Me.dsPAINT1 = New Common.dsPAINT
        CType(Me.dsPAINT1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(22, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(205, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Please input the search condition."
        '
        'lblModelCode
        '
        Me.lblModelCode.BackColor = System.Drawing.SystemColors.Control
        Me.lblModelCode.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModelCode.Location = New System.Drawing.Point(25, 53)
        Me.lblModelCode.Name = "lblModelCode"
        Me.lblModelCode.Size = New System.Drawing.Size(293, 24)
        Me.lblModelCode.TabIndex = 1
        Me.lblModelCode.Text = "Model Code "
        Me.lblModelCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLotNo
        '
        Me.lblLotNo.BackColor = System.Drawing.SystemColors.Control
        Me.lblLotNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLotNo.Location = New System.Drawing.Point(25, 81)
        Me.lblLotNo.Name = "lblLotNo"
        Me.lblLotNo.Size = New System.Drawing.Size(293, 24)
        Me.lblLotNo.TabIndex = 2
        Me.lblLotNo.Text = "Lot No."
        Me.lblLotNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUnitNo
        '
        Me.lblUnitNo.BackColor = System.Drawing.SystemColors.Control
        Me.lblUnitNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnitNo.Location = New System.Drawing.Point(24, 109)
        Me.lblUnitNo.Name = "lblUnitNo"
        Me.lblUnitNo.Size = New System.Drawing.Size(293, 24)
        Me.lblUnitNo.TabIndex = 3
        Me.lblUnitNo.Text = "Unit No."
        Me.lblUnitNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtModelCode
        '
        Me.txtModelCode.Location = New System.Drawing.Point(168, 54)
        Me.txtModelCode.MaxLength = 8
        Me.txtModelCode.Name = "txtModelCode"
        Me.txtModelCode.Size = New System.Drawing.Size(148, 22)
        Me.txtModelCode.TabIndex = 0
        '
        'txtLotNo
        '
        Me.txtLotNo.Location = New System.Drawing.Point(168, 82)
        Me.txtLotNo.MaxLength = 3
        Me.txtLotNo.Name = "txtLotNo"
        Me.txtLotNo.Size = New System.Drawing.Size(148, 22)
        Me.txtLotNo.TabIndex = 1
        '
        'txtUnitNo
        '
        Me.txtUnitNo.Location = New System.Drawing.Point(168, 110)
        Me.txtUnitNo.MaxLength = 3
        Me.txtUnitNo.Name = "txtUnitNo"
        Me.txtUnitNo.Size = New System.Drawing.Size(148, 22)
        Me.txtUnitNo.TabIndex = 2
        '
        'btnExecution
        '
        Me.btnExecution.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExecution.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExecution.Location = New System.Drawing.Point(72, 237)
        Me.btnExecution.Name = "btnExecution"
        Me.btnExecution.Size = New System.Drawing.Size(106, 29)
        Me.btnExecution.TabIndex = 4
        Me.btnExecution.Text = "EXECUTION"
        Me.btnExecution.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(210, 237)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(106, 29)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "CANCEL"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lblMsg
        '
        Me.lblMsg.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblMsg.AutoSize = True
        Me.lblMsg.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsg.ForeColor = System.Drawing.Color.Red
        Me.lblMsg.Location = New System.Drawing.Point(25, 207)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(129, 16)
        Me.lblMsg.TabIndex = 9
        Me.lblMsg.Text = "Notification Message"
        '
        'lblSkitNo
        '
        Me.lblSkitNo.BackColor = System.Drawing.SystemColors.Control
        Me.lblSkitNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSkitNo.Location = New System.Drawing.Point(24, 163)
        Me.lblSkitNo.Name = "lblSkitNo"
        Me.lblSkitNo.Size = New System.Drawing.Size(293, 24)
        Me.lblSkitNo.TabIndex = 3
        Me.lblSkitNo.Text = "Skid No."
        Me.lblSkitNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSkitNo
        '
        Me.txtSkitNo.Location = New System.Drawing.Point(168, 164)
        Me.txtSkitNo.MaxLength = 3
        Me.txtSkitNo.Name = "txtSkitNo"
        Me.txtSkitNo.Size = New System.Drawing.Size(148, 22)
        Me.txtSkitNo.TabIndex = 3
        '
        'dsPAINT1
        '
        Me.dsPAINT1.DataSetName = "dsPAINT"
        Me.dsPAINT1.Locale = New System.Globalization.CultureInfo("th-TH")
        Me.dsPAINT1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'frmSearch
        '
        Me.AcceptButton = Me.btnExecution
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(394, 291)
        Me.Controls.Add(Me.lblMsg)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnExecution)
        Me.Controls.Add(Me.txtSkitNo)
        Me.Controls.Add(Me.txtUnitNo)
        Me.Controls.Add(Me.txtLotNo)
        Me.Controls.Add(Me.txtModelCode)
        Me.Controls.Add(Me.lblSkitNo)
        Me.Controls.Add(Me.lblUnitNo)
        Me.Controls.Add(Me.lblLotNo)
        Me.Controls.Add(Me.lblModelCode)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(400, 250)
        Me.Name = "frmSearch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Search Condition"
        CType(Me.dsPAINT1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblModelCode As System.Windows.Forms.Label
    Friend WithEvents lblLotNo As System.Windows.Forms.Label
    Friend WithEvents lblUnitNo As System.Windows.Forms.Label
    Friend WithEvents txtModelCode As System.Windows.Forms.TextBox
    Friend WithEvents txtLotNo As System.Windows.Forms.TextBox
    Friend WithEvents txtUnitNo As System.Windows.Forms.TextBox
    Friend WithEvents btnExecution As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents dsPAINT1 As Common.dsPAINT
    Friend WithEvents lblSkitNo As System.Windows.Forms.Label
    Friend WithEvents txtSkitNo As System.Windows.Forms.TextBox
End Class
