<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProcessOptionSetting_Edit
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.lblProcNo = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnExecute = New System.Windows.Forms.Button
        Me.dgvData = New System.Windows.Forms.DataGridView
        Me.OPTIONIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.dsPAINT1 = New Common.dsPAINT
        Me.ISUSEDDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.PROCESSNODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.bsPROCESSOPTIONCELL = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridViewComboBoxColumn1 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewComboBoxColumn2 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewComboBoxColumn3 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewComboBoxColumn4 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewComboBoxColumn5 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewComboBoxColumn6 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewComboBoxColumn7 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.lblProcName = New System.Windows.Forms.Label
        Me.txtProcName = New System.Windows.Forms.TextBox
        Me.txtProcNo = New System.Windows.Forms.TextBox
        Me.taOPTION_MST1 = New Common.dsPAINTTableAdapters.taOPTION_MST
        Me.taPROCESS_MST1 = New Common.dsPAINTTableAdapters.taPROCESS_MST
        Me.taPROCESS_OPTION_CELL1 = New Common.dsPAINTTableAdapters.taPROCESS_OPTION_CELL
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsPAINT1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsPROCESSOPTIONCELL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblProcNo
        '
        Me.lblProcNo.BackColor = System.Drawing.SystemColors.Control
        Me.lblProcNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcNo.Location = New System.Drawing.Point(12, 9)
        Me.lblProcNo.Name = "lblProcNo"
        Me.lblProcNo.Size = New System.Drawing.Size(370, 24)
        Me.lblProcNo.TabIndex = 5
        Me.lblProcNo.Text = "Process No"
        Me.lblProcNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.OPTIONIDDataGridViewTextBoxColumn, Me.ISUSEDDataGridViewCheckBoxColumn, Me.PROCESSNODataGridViewTextBoxColumn})
        Me.dgvData.DataSource = Me.bsPROCESSOPTIONCELL
        Me.dgvData.Location = New System.Drawing.Point(12, 62)
        Me.dgvData.MultiSelect = False
        Me.dgvData.Name = "dgvData"
        Me.dgvData.RowHeadersVisible = False
        Me.dgvData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvData.Size = New System.Drawing.Size(370, 444)
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
        Me.OPTIONIDDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
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
        'PROCESSNODataGridViewTextBoxColumn
        '
        Me.PROCESSNODataGridViewTextBoxColumn.DataPropertyName = "PROCESS_NO"
        Me.PROCESSNODataGridViewTextBoxColumn.HeaderText = "PROCESS_NO"
        Me.PROCESSNODataGridViewTextBoxColumn.Name = "PROCESSNODataGridViewTextBoxColumn"
        Me.PROCESSNODataGridViewTextBoxColumn.Visible = False
        '
        'bsPROCESSOPTIONCELL
        '
        Me.bsPROCESSOPTIONCELL.DataMember = "dtPROCESS_OPTION_CELL"
        Me.bsPROCESSOPTIONCELL.DataSource = Me.dsPAINT1
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
        'lblProcName
        '
        Me.lblProcName.BackColor = System.Drawing.SystemColors.Control
        Me.lblProcName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcName.Location = New System.Drawing.Point(12, 35)
        Me.lblProcName.Name = "lblProcName"
        Me.lblProcName.Size = New System.Drawing.Size(370, 24)
        Me.lblProcName.TabIndex = 6
        Me.lblProcName.Text = "Process Name"
        Me.lblProcName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtProcName
        '
        Me.txtProcName.BackColor = System.Drawing.SystemColors.Window
        Me.txtProcName.Enabled = False
        Me.txtProcName.Location = New System.Drawing.Point(180, 36)
        Me.txtProcName.Name = "txtProcName"
        Me.txtProcName.ReadOnly = True
        Me.txtProcName.Size = New System.Drawing.Size(200, 22)
        Me.txtProcName.TabIndex = 1
        Me.txtProcName.TabStop = False
        '
        'txtProcNo
        '
        Me.txtProcNo.BackColor = System.Drawing.SystemColors.Window
        Me.txtProcNo.Enabled = False
        Me.txtProcNo.Location = New System.Drawing.Point(330, 10)
        Me.txtProcNo.Name = "txtProcNo"
        Me.txtProcNo.ReadOnly = True
        Me.txtProcNo.Size = New System.Drawing.Size(50, 22)
        Me.txtProcNo.TabIndex = 0
        Me.txtProcNo.TabStop = False
        Me.txtProcNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        'frmProcessOptionSetting_Edit
        '
        Me.AcceptButton = Me.btnExecute
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(394, 573)
        Me.Controls.Add(Me.txtProcNo)
        Me.Controls.Add(Me.txtProcName)
        Me.Controls.Add(Me.dgvData)
        Me.Controls.Add(Me.btnExecute)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.lblProcNo)
        Me.Controls.Add(Me.lblProcName)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmProcessOptionSetting_Edit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "{0} PROCESS OPTION SETTING"
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsPAINT1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsPROCESSOPTIONCELL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblProcNo As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnExecute As System.Windows.Forms.Button
    Friend WithEvents dgvData As System.Windows.Forms.DataGridView
    Friend WithEvents dsPAINT1 As Common.dsPAINT
    Friend WithEvents taOPTION_MST1 As taOPTION_MST
    Friend WithEvents DataGridViewComboBoxColumn1 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn2 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn3 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn4 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn5 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn6 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn7 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents lblProcName As System.Windows.Forms.Label
    Friend WithEvents txtProcName As System.Windows.Forms.TextBox
    Friend WithEvents txtProcNo As System.Windows.Forms.TextBox
    Friend WithEvents taPROCESS_MST1 As taPROCESS_MST
    Friend WithEvents taPROCESS_OPTION_CELL1 As taPROCESS_OPTION_CELL
    Friend WithEvents bsPROCESSOPTIONCELL As System.Windows.Forms.BindingSource
    Friend WithEvents OPTIONIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents ISUSEDDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents PROCESSNODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
