<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModelOptionSetting_AddEdit
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.lblModelCode = New System.Windows.Forms.Label
        Me.lblMsg = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnNext = New System.Windows.Forms.Button
        Me.mtbModelCode = New System.Windows.Forms.MaskedTextBox
        Me.btnExecute = New System.Windows.Forms.Button
        Me.dgvData = New System.Windows.Forms.DataGridView
        Me.OPTIONIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.dsPAINT1 = New Common.dsPAINT
        Me.ISUSEDDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.MODELOPTIONROWIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.bsMODELOPTIONCELL = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridViewComboBoxColumn1 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewComboBoxColumn2 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewComboBoxColumn3 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewComboBoxColumn4 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewComboBoxColumn5 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewComboBoxColumn6 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewComboBoxColumn7 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.taMODEL_OPTION_ROW1 = New Common.dsPAINTTableAdapters.taMODEL_OPTION_ROW
        Me.taMODEL_OPTION_CELL1 = New Common.dsPAINTTableAdapters.taMODEL_OPTION_CELL
        Me.taOPTION_MST1 = New Common.dsPAINTTableAdapters.taOPTION_MST
        Me.lblDestination = New System.Windows.Forms.Label
        Me.cboDestination = New System.Windows.Forms.ComboBox
        Me.bsOPTIONMST = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsPAINT1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsMODELOPTIONCELL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsOPTIONMST, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblModelCode
        '
        Me.lblModelCode.BackColor = System.Drawing.SystemColors.Control
        Me.lblModelCode.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModelCode.Location = New System.Drawing.Point(12, 9)
        Me.lblModelCode.Name = "lblModelCode"
        Me.lblModelCode.Size = New System.Drawing.Size(370, 24)
        Me.lblModelCode.TabIndex = 5
        Me.lblModelCode.Text = "Model Code "
        Me.lblModelCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMsg
        '
        Me.lblMsg.AutoSize = True
        Me.lblMsg.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsg.ForeColor = System.Drawing.Color.Red
        Me.lblMsg.Location = New System.Drawing.Point(12, 33)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(129, 16)
        Me.lblMsg.TabIndex = 7
        Me.lblMsg.Text = "Notification Message"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(213, 527)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(106, 29)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "CANCEL"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnNext.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNext.Location = New System.Drawing.Point(75, 527)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(106, 29)
        Me.btnNext.TabIndex = 2
        Me.btnNext.Text = "NEXT"
        Me.btnNext.UseVisualStyleBackColor = True
        Me.btnNext.Visible = False
        '
        'mtbModelCode
        '
        Me.mtbModelCode.Location = New System.Drawing.Point(280, 10)
        Me.mtbModelCode.Mask = "000AAA*A"
        Me.mtbModelCode.Name = "mtbModelCode"
        Me.mtbModelCode.Size = New System.Drawing.Size(100, 22)
        Me.mtbModelCode.TabIndex = 0
        '
        'btnExecute
        '
        Me.btnExecute.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnExecute.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExecute.Location = New System.Drawing.Point(75, 527)
        Me.btnExecute.Name = "btnExecute"
        Me.btnExecute.Size = New System.Drawing.Size(106, 29)
        Me.btnExecute.TabIndex = 3
        Me.btnExecute.Text = "EXECUTION"
        Me.btnExecute.UseVisualStyleBackColor = True
        Me.btnExecute.Visible = False
        '
        'dgvData
        '
        Me.dgvData.AllowUserToAddRows = False
        Me.dgvData.AllowUserToDeleteRows = False
        Me.dgvData.AllowUserToResizeColumns = False
        Me.dgvData.AllowUserToResizeRows = False
        Me.dgvData.AutoGenerateColumns = False
        Me.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.OPTIONIDDataGridViewTextBoxColumn, Me.ISUSEDDataGridViewCheckBoxColumn, Me.MODELOPTIONROWIDDataGridViewTextBoxColumn})
        Me.dgvData.DataSource = Me.bsMODELOPTIONCELL
        Me.dgvData.Location = New System.Drawing.Point(12, 85)
        Me.dgvData.MultiSelect = False
        Me.dgvData.Name = "dgvData"
        Me.dgvData.RowHeadersVisible = False
        Me.dgvData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvData.Size = New System.Drawing.Size(370, 414)
        Me.dgvData.TabIndex = 2
        Me.dgvData.Visible = False
        '
        'OPTIONIDDataGridViewTextBoxColumn
        '
        Me.OPTIONIDDataGridViewTextBoxColumn.DataPropertyName = "OPTION_ID"
        Me.OPTIONIDDataGridViewTextBoxColumn.DataSource = Me.dsPAINT1
        Me.OPTIONIDDataGridViewTextBoxColumn.DisplayMember = "dtOPTION_MST.OPTION_DISPLAY"
        Me.OPTIONIDDataGridViewTextBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.OPTIONIDDataGridViewTextBoxColumn.HeaderText = "OPTION DISPLAY"
        Me.OPTIONIDDataGridViewTextBoxColumn.Name = "OPTIONIDDataGridViewTextBoxColumn"
        Me.OPTIONIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.OPTIONIDDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.OPTIONIDDataGridViewTextBoxColumn.ValueMember = "dtOPTION_MST.OPTION_ID"
        '
        'dsPAINT1
        '
        Me.dsPAINT1.DataSetName = "dsPAINT"
        Me.dsPAINT1.Locale = New System.Globalization.CultureInfo("th-TH")
        Me.dsPAINT1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ISUSEDDataGridViewCheckBoxColumn
        '
        Me.ISUSEDDataGridViewCheckBoxColumn.DataPropertyName = "IS_USED"
        Me.ISUSEDDataGridViewCheckBoxColumn.HeaderText = ""
        Me.ISUSEDDataGridViewCheckBoxColumn.Name = "ISUSEDDataGridViewCheckBoxColumn"
        '
        'MODELOPTIONROWIDDataGridViewTextBoxColumn
        '
        Me.MODELOPTIONROWIDDataGridViewTextBoxColumn.DataPropertyName = "MODEL_OPTION_ROW_ID"
        Me.MODELOPTIONROWIDDataGridViewTextBoxColumn.HeaderText = "MODEL_OPTION_ROW_ID"
        Me.MODELOPTIONROWIDDataGridViewTextBoxColumn.Name = "MODELOPTIONROWIDDataGridViewTextBoxColumn"
        Me.MODELOPTIONROWIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.MODELOPTIONROWIDDataGridViewTextBoxColumn.Visible = False
        '
        'bsMODELOPTIONCELL
        '
        Me.bsMODELOPTIONCELL.DataMember = "dtMODEL_OPTION_CELL"
        Me.bsMODELOPTIONCELL.DataSource = Me.dsPAINT1
        '
        'DataGridViewComboBoxColumn1
        '
        Me.DataGridViewComboBoxColumn1.HeaderText = "OPTION SEQ"
        Me.DataGridViewComboBoxColumn1.Name = "DataGridViewComboBoxColumn1"
        Me.DataGridViewComboBoxColumn1.Visible = False
        '
        'DataGridViewComboBoxColumn2
        '
        Me.DataGridViewComboBoxColumn2.HeaderText = "OPTION SEQ"
        Me.DataGridViewComboBoxColumn2.Name = "DataGridViewComboBoxColumn2"
        Me.DataGridViewComboBoxColumn2.Visible = False
        '
        'DataGridViewComboBoxColumn3
        '
        Me.DataGridViewComboBoxColumn3.HeaderText = "OPTION SEQ"
        Me.DataGridViewComboBoxColumn3.Name = "DataGridViewComboBoxColumn3"
        Me.DataGridViewComboBoxColumn3.Visible = False
        '
        'DataGridViewComboBoxColumn4
        '
        Me.DataGridViewComboBoxColumn4.HeaderText = "OPTION SEQ"
        Me.DataGridViewComboBoxColumn4.Name = "DataGridViewComboBoxColumn4"
        Me.DataGridViewComboBoxColumn4.Visible = False
        '
        'DataGridViewComboBoxColumn5
        '
        Me.DataGridViewComboBoxColumn5.HeaderText = "OPTION SEQ"
        Me.DataGridViewComboBoxColumn5.Name = "DataGridViewComboBoxColumn5"
        Me.DataGridViewComboBoxColumn5.Visible = False
        '
        'DataGridViewComboBoxColumn6
        '
        Me.DataGridViewComboBoxColumn6.DataPropertyName = "OPTION_SEQ"
        Me.DataGridViewComboBoxColumn6.HeaderText = "OPTION SEQ"
        Me.DataGridViewComboBoxColumn6.Name = "DataGridViewComboBoxColumn6"
        Me.DataGridViewComboBoxColumn6.ReadOnly = True
        Me.DataGridViewComboBoxColumn6.Visible = False
        '
        'DataGridViewComboBoxColumn7
        '
        Me.DataGridViewComboBoxColumn7.HeaderText = "OPTION SEQ"
        Me.DataGridViewComboBoxColumn7.Name = "DataGridViewComboBoxColumn7"
        Me.DataGridViewComboBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewComboBoxColumn7.Visible = False
        '
        'taMODEL_OPTION_ROW1
        '
        Me.taMODEL_OPTION_ROW1.ClearBeforeFill = True
        '
        'taMODEL_OPTION_CELL1
        '
        Me.taMODEL_OPTION_CELL1.ClearBeforeFill = True
        '
        'taOPTION_MST1
        '
        Me.taOPTION_MST1.ClearBeforeFill = True
        '
        'lblDestination
        '
        Me.lblDestination.BackColor = System.Drawing.SystemColors.Control
        Me.lblDestination.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDestination.Location = New System.Drawing.Point(12, 54)
        Me.lblDestination.Name = "lblDestination"
        Me.lblDestination.Size = New System.Drawing.Size(370, 26)
        Me.lblDestination.TabIndex = 6
        Me.lblDestination.Text = "Destination"
        Me.lblDestination.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblDestination.Visible = False
        '
        'cboDestination
        '
        Me.cboDestination.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.bsOPTIONMST, "OPTION_ID", True))
        Me.cboDestination.DataSource = Me.bsOPTIONMST
        Me.cboDestination.DisplayMember = "OPTION_DISPLAY"
        Me.cboDestination.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDestination.FormattingEnabled = True
        Me.cboDestination.Location = New System.Drawing.Point(230, 55)
        Me.cboDestination.Name = "cboDestination"
        Me.cboDestination.Size = New System.Drawing.Size(150, 24)
        Me.cboDestination.TabIndex = 1
        Me.cboDestination.ValueMember = "OPTION_ID"
        Me.cboDestination.Visible = False
        '
        'bsOPTIONMST
        '
        Me.bsOPTIONMST.AllowNew = False
        Me.bsOPTIONMST.DataMember = "dtOPTION_MST"
        Me.bsOPTIONMST.DataSource = Me.dsPAINT1
        Me.bsOPTIONMST.Filter = "OPTION_TYPE = 1"
        '
        'frmModelOptionSetting_AddEdit
        '
        Me.AcceptButton = Me.btnExecute
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(394, 573)
        Me.Controls.Add(Me.cboDestination)
        Me.Controls.Add(Me.dgvData)
        Me.Controls.Add(Me.btnExecute)
        Me.Controls.Add(Me.mtbModelCode)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.lblMsg)
        Me.Controls.Add(Me.lblModelCode)
        Me.Controls.Add(Me.lblDestination)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmModelOptionSetting_AddEdit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "{0} MODEL OPTION SETTING"
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsPAINT1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsMODELOPTIONCELL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsOPTIONMST, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblModelCode As System.Windows.Forms.Label
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents mtbModelCode As System.Windows.Forms.MaskedTextBox
    Friend WithEvents btnExecute As System.Windows.Forms.Button
    Friend WithEvents dgvData As System.Windows.Forms.DataGridView
    Friend WithEvents dsPAINT1 As Common.dsPAINT
    Friend WithEvents taMODEL_OPTION_ROW1 As taMODEL_OPTION_ROW
    Friend WithEvents taMODEL_OPTION_CELL1 As taMODEL_OPTION_CELL
    Friend WithEvents taOPTION_MST1 As taOPTION_MST
    Friend WithEvents bsMODELOPTIONCELL As System.Windows.Forms.BindingSource
    Friend WithEvents DataGridViewComboBoxColumn1 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn2 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn3 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn4 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn5 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn6 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn7 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents OPTIONIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents ISUSEDDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents MODELOPTIONROWIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblDestination As System.Windows.Forms.Label
    Friend WithEvents cboDestination As System.Windows.Forms.ComboBox
    Friend WithEvents bsOPTIONMST As System.Windows.Forms.BindingSource
End Class
