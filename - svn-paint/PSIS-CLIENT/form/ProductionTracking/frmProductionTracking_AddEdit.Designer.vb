<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProductionTracking_AddEdit
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
        Me.lblProductionDate = New System.Windows.Forms.Label
        Me.btnExecute = New System.Windows.Forms.Button
        Me.txtProductionDate = New System.Windows.Forms.TextBox
        Me.lblOnTime = New System.Windows.Forms.Label
        Me.lblModelYear = New System.Windows.Forms.Label
        Me.lblSuffixCode = New System.Windows.Forms.Label
        Me.txtOnTime = New System.Windows.Forms.TextBox
        Me.txtModelYear = New System.Windows.Forms.TextBox
        Me.txtSuffixCode = New System.Windows.Forms.TextBox
        Me.lblLotNo = New System.Windows.Forms.Label
        Me.lblUnit = New System.Windows.Forms.Label
        Me.txtLotNo = New System.Windows.Forms.TextBox
        Me.txtUnit = New System.Windows.Forms.TextBox
        Me.lblProcessNo = New System.Windows.Forms.Label
        Me.lblSkitNo = New System.Windows.Forms.Label
        Me.lblLaneNo = New System.Windows.Forms.Label
        Me.cmbSkitNo = New System.Windows.Forms.ComboBox
        Me.dsPAINT1 = New Common.dsPAINT
        Me.cmbProcessNo = New System.Windows.Forms.ComboBox
        Me.cmbLaneNo = New System.Windows.Forms.ComboBox
        Me.taPROCESS_MST = New Common.dsPAINTTableAdapters.taPROCESS_MST
        Me.taLANE_MST = New Common.dsPAINTTableAdapters.taLANE_MST
        Me.taSKIT_MST = New Common.dsPAINTTableAdapters.taSKIT_MST
        Me.taPAINT_CELL = New Common.dsPAINTTableAdapters.taPAINT_CELL
        Me.taWBS_ON = New Common.dsPAINTTableAdapters.taWBS_ON
        Me.lblMsg = New System.Windows.Forms.Label
        CType(Me.dsPAINT1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(213, 325)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "CANCEL"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lblProductionDate
        '
        Me.lblProductionDate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProductionDate.Location = New System.Drawing.Point(12, 9)
        Me.lblProductionDate.Name = "lblProductionDate"
        Me.lblProductionDate.Size = New System.Drawing.Size(370, 24)
        Me.lblProductionDate.TabIndex = 6
        Me.lblProductionDate.Text = "PRODUCTION DATE"
        Me.lblProductionDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnExecute
        '
        Me.btnExecute.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExecute.Location = New System.Drawing.Point(75, 325)
        Me.btnExecute.Name = "btnExecute"
        Me.btnExecute.Size = New System.Drawing.Size(84, 23)
        Me.btnExecute.TabIndex = 9
        Me.btnExecute.Text = "EXECUTION"
        Me.btnExecute.UseVisualStyleBackColor = True
        '
        'txtProductionDate
        '
        Me.txtProductionDate.Location = New System.Drawing.Point(213, 11)
        Me.txtProductionDate.Name = "txtProductionDate"
        Me.txtProductionDate.ReadOnly = True
        Me.txtProductionDate.Size = New System.Drawing.Size(167, 20)
        Me.txtProductionDate.TabIndex = 0
        Me.txtProductionDate.TabStop = False
        '
        'lblOnTime
        '
        Me.lblOnTime.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOnTime.Location = New System.Drawing.Point(12, 37)
        Me.lblOnTime.Name = "lblOnTime"
        Me.lblOnTime.Size = New System.Drawing.Size(370, 24)
        Me.lblOnTime.TabIndex = 10
        Me.lblOnTime.Text = "ON-TIME"
        Me.lblOnTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblModelYear
        '
        Me.lblModelYear.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModelYear.Location = New System.Drawing.Point(12, 65)
        Me.lblModelYear.Name = "lblModelYear"
        Me.lblModelYear.Size = New System.Drawing.Size(370, 24)
        Me.lblModelYear.TabIndex = 11
        Me.lblModelYear.Text = "MODEL YEAR"
        Me.lblModelYear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSuffixCode
        '
        Me.lblSuffixCode.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSuffixCode.Location = New System.Drawing.Point(13, 93)
        Me.lblSuffixCode.Name = "lblSuffixCode"
        Me.lblSuffixCode.Size = New System.Drawing.Size(370, 24)
        Me.lblSuffixCode.TabIndex = 12
        Me.lblSuffixCode.Text = "SUFFIX CODE"
        Me.lblSuffixCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtOnTime
        '
        Me.txtOnTime.Location = New System.Drawing.Point(213, 39)
        Me.txtOnTime.Name = "txtOnTime"
        Me.txtOnTime.ReadOnly = True
        Me.txtOnTime.Size = New System.Drawing.Size(167, 20)
        Me.txtOnTime.TabIndex = 1
        Me.txtOnTime.TabStop = False
        '
        'txtModelYear
        '
        Me.txtModelYear.Location = New System.Drawing.Point(213, 67)
        Me.txtModelYear.Name = "txtModelYear"
        Me.txtModelYear.ReadOnly = True
        Me.txtModelYear.Size = New System.Drawing.Size(167, 20)
        Me.txtModelYear.TabIndex = 2
        Me.txtModelYear.TabStop = False
        '
        'txtSuffixCode
        '
        Me.txtSuffixCode.Location = New System.Drawing.Point(213, 95)
        Me.txtSuffixCode.Name = "txtSuffixCode"
        Me.txtSuffixCode.ReadOnly = True
        Me.txtSuffixCode.Size = New System.Drawing.Size(167, 20)
        Me.txtSuffixCode.TabIndex = 3
        Me.txtSuffixCode.TabStop = False
        '
        'lblLotNo
        '
        Me.lblLotNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLotNo.Location = New System.Drawing.Point(12, 118)
        Me.lblLotNo.Name = "lblLotNo"
        Me.lblLotNo.Size = New System.Drawing.Size(370, 24)
        Me.lblLotNo.TabIndex = 11
        Me.lblLotNo.Text = "LOT NO"
        Me.lblLotNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUnit
        '
        Me.lblUnit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnit.Location = New System.Drawing.Point(13, 146)
        Me.lblUnit.Name = "lblUnit"
        Me.lblUnit.Size = New System.Drawing.Size(370, 24)
        Me.lblUnit.TabIndex = 12
        Me.lblUnit.Text = "UNIT"
        Me.lblUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLotNo
        '
        Me.txtLotNo.Location = New System.Drawing.Point(213, 120)
        Me.txtLotNo.Name = "txtLotNo"
        Me.txtLotNo.ReadOnly = True
        Me.txtLotNo.Size = New System.Drawing.Size(167, 20)
        Me.txtLotNo.TabIndex = 4
        Me.txtLotNo.TabStop = False
        '
        'txtUnit
        '
        Me.txtUnit.Location = New System.Drawing.Point(213, 148)
        Me.txtUnit.Name = "txtUnit"
        Me.txtUnit.ReadOnly = True
        Me.txtUnit.Size = New System.Drawing.Size(167, 20)
        Me.txtUnit.TabIndex = 5
        Me.txtUnit.TabStop = False
        '
        'lblProcessNo
        '
        Me.lblProcessNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcessNo.Location = New System.Drawing.Point(11, 227)
        Me.lblProcessNo.Name = "lblProcessNo"
        Me.lblProcessNo.Size = New System.Drawing.Size(371, 24)
        Me.lblProcessNo.TabIndex = 11
        Me.lblProcessNo.Text = "CURRENT PROCESS"
        Me.lblProcessNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSkitNo
        '
        Me.lblSkitNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSkitNo.Location = New System.Drawing.Point(11, 200)
        Me.lblSkitNo.Name = "lblSkitNo"
        Me.lblSkitNo.Size = New System.Drawing.Size(371, 25)
        Me.lblSkitNo.TabIndex = 12
        Me.lblSkitNo.Text = "SKID NO"
        Me.lblSkitNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLaneNo
        '
        Me.lblLaneNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLaneNo.Location = New System.Drawing.Point(11, 252)
        Me.lblLaneNo.Name = "lblLaneNo"
        Me.lblLaneNo.Size = New System.Drawing.Size(371, 24)
        Me.lblLaneNo.TabIndex = 11
        Me.lblLaneNo.Text = "LANE NO"
        Me.lblLaneNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbSkitNo
        '
        Me.cmbSkitNo.DataSource = Me.dsPAINT1
        Me.cmbSkitNo.DisplayMember = "dtSKIT_MST.SKIT_NO"
        Me.cmbSkitNo.FormatString = "###;###"
        Me.cmbSkitNo.FormattingEnabled = True
        Me.cmbSkitNo.Location = New System.Drawing.Point(213, 202)
        Me.cmbSkitNo.MaxLength = 3
        Me.cmbSkitNo.Name = "cmbSkitNo"
        Me.cmbSkitNo.Size = New System.Drawing.Size(167, 21)
        Me.cmbSkitNo.TabIndex = 6
        Me.cmbSkitNo.ValueMember = "dtSKIT_MST.SKIT_NO"
        '
        'dsPAINT1
        '
        Me.dsPAINT1.DataSetName = "dsPAINT"
        Me.dsPAINT1.Locale = New System.Globalization.CultureInfo("th-TH")
        Me.dsPAINT1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cmbProcessNo
        '
        Me.cmbProcessNo.DataSource = Me.dsPAINT1
        Me.cmbProcessNo.DisplayMember = "dtPROCESS_MST.PROCESS_NAME"
        Me.cmbProcessNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProcessNo.FormattingEnabled = True
        Me.cmbProcessNo.Location = New System.Drawing.Point(213, 228)
        Me.cmbProcessNo.Name = "cmbProcessNo"
        Me.cmbProcessNo.Size = New System.Drawing.Size(167, 21)
        Me.cmbProcessNo.TabIndex = 7
        Me.cmbProcessNo.ValueMember = "dtPROCESS_MST.PROCESS_NO"
        '
        'cmbLaneNo
        '
        Me.cmbLaneNo.DataSource = Me.dsPAINT1
        Me.cmbLaneNo.DisplayMember = "dtLANE_MST.LANE_NO"
        Me.cmbLaneNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLaneNo.FormattingEnabled = True
        Me.cmbLaneNo.Location = New System.Drawing.Point(213, 253)
        Me.cmbLaneNo.Name = "cmbLaneNo"
        Me.cmbLaneNo.Size = New System.Drawing.Size(167, 21)
        Me.cmbLaneNo.TabIndex = 8
        Me.cmbLaneNo.ValueMember = "dtLANE_MST.LANE_NO"
        '
        'taPROCESS_MST
        '
        Me.taPROCESS_MST.ClearBeforeFill = True
        '
        'taLANE_MST
        '
        Me.taLANE_MST.ClearBeforeFill = True
        '
        'taSKIT_MST
        '
        Me.taSKIT_MST.ClearBeforeFill = True
        '
        'taPAINT_CELL
        '
        Me.taPAINT_CELL.ClearBeforeFill = True
        '
        'taWBS_ON
        '
        Me.taWBS_ON.ClearBeforeFill = True
        '
        'lblMsg
        '
        Me.lblMsg.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblMsg.AutoSize = True
        Me.lblMsg.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsg.ForeColor = System.Drawing.Color.Red
        Me.lblMsg.Location = New System.Drawing.Point(11, 292)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(129, 16)
        Me.lblMsg.TabIndex = 17
        Me.lblMsg.Text = "Notification Message"
        '
        'frmProductionTracking_AddEdit
        '
        Me.AcceptButton = Me.btnExecute
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(392, 369)
        Me.Controls.Add(Me.lblMsg)
        Me.Controls.Add(Me.cmbLaneNo)
        Me.Controls.Add(Me.cmbProcessNo)
        Me.Controls.Add(Me.cmbSkitNo)
        Me.Controls.Add(Me.txtUnit)
        Me.Controls.Add(Me.txtSuffixCode)
        Me.Controls.Add(Me.txtLotNo)
        Me.Controls.Add(Me.txtModelYear)
        Me.Controls.Add(Me.txtOnTime)
        Me.Controls.Add(Me.lblSkitNo)
        Me.Controls.Add(Me.lblUnit)
        Me.Controls.Add(Me.lblLaneNo)
        Me.Controls.Add(Me.lblProcessNo)
        Me.Controls.Add(Me.lblSuffixCode)
        Me.Controls.Add(Me.lblLotNo)
        Me.Controls.Add(Me.lblModelYear)
        Me.Controls.Add(Me.lblOnTime)
        Me.Controls.Add(Me.txtProductionDate)
        Me.Controls.Add(Me.btnExecute)
        Me.Controls.Add(Me.lblProductionDate)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmProductionTracking_AddEdit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmProductionTracking_AddEdit"
        CType(Me.dsPAINT1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblProductionDate As System.Windows.Forms.Label
    Friend WithEvents btnExecute As System.Windows.Forms.Button
    Friend WithEvents txtProductionDate As System.Windows.Forms.TextBox
    Friend WithEvents lblOnTime As System.Windows.Forms.Label
    Friend WithEvents lblModelYear As System.Windows.Forms.Label
    Friend WithEvents lblSuffixCode As System.Windows.Forms.Label
    Friend WithEvents txtOnTime As System.Windows.Forms.TextBox
    Friend WithEvents txtModelYear As System.Windows.Forms.TextBox
    Friend WithEvents txtSuffixCode As System.Windows.Forms.TextBox
    Friend WithEvents lblLotNo As System.Windows.Forms.Label
    Friend WithEvents lblUnit As System.Windows.Forms.Label
    Friend WithEvents txtLotNo As System.Windows.Forms.TextBox
    Friend WithEvents txtUnit As System.Windows.Forms.TextBox
    Friend WithEvents lblProcessNo As System.Windows.Forms.Label
    Friend WithEvents lblSkitNo As System.Windows.Forms.Label
    Friend WithEvents lblLaneNo As System.Windows.Forms.Label
    Friend WithEvents cmbSkitNo As System.Windows.Forms.ComboBox
    Friend WithEvents cmbProcessNo As System.Windows.Forms.ComboBox
    Friend WithEvents cmbLaneNo As System.Windows.Forms.ComboBox
    Friend WithEvents dsPAINT1 As Common.dsPAINT
    Friend WithEvents taPROCESS_MST As taPROCESS_MST
    Friend WithEvents taLANE_MST As taLANE_MST
    Friend WithEvents taSKIT_MST As taSKIT_MST
    Friend WithEvents taPAINT_CELL As taPAINT_CELL
    Friend WithEvents taWBS_ON As taWBS_ON
    Friend WithEvents lblMsg As System.Windows.Forms.Label
End Class
