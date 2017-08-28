<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlLog
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.cboLogMsg = New System.Windows.Forms.ComboBox
        Me.dsPAINT1 = New Common.dsPAINT
        Me.btnClear = New System.Windows.Forms.Button
        Me.taLOG_DAT1 = New Common.dsPAINTTableAdapters.taLOG_DAT
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.dgvLogDat = New System.Windows.Forms.DataGridView
        Me.bsLogDat = New System.Windows.Forms.BindingSource(Me.components)
        Me.MESSAGEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dsPAINT1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvLogDat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsLogDat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboLogMsg
        '
        Me.cboLogMsg.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboLogMsg.BackColor = System.Drawing.SystemColors.Window
        Me.cboLogMsg.DataSource = Me.dsPAINT1
        Me.cboLogMsg.DisplayMember = "dtLOG_DAT.MESSAGE"
        Me.cboLogMsg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLogMsg.Enabled = False
        Me.cboLogMsg.Font = New System.Drawing.Font("Arial", 15.0!)
        Me.cboLogMsg.FormattingEnabled = True
        Me.cboLogMsg.IntegralHeight = False
        Me.cboLogMsg.Location = New System.Drawing.Point(3, 3)
        Me.cboLogMsg.Name = "cboLogMsg"
        Me.cboLogMsg.Size = New System.Drawing.Size(292, 31)
        Me.cboLogMsg.TabIndex = 0
        '
        'dsPAINT1
        '
        Me.dsPAINT1.DataSetName = "dsPAINT"
        Me.dsPAINT1.Locale = New System.Globalization.CultureInfo("th-TH")
        Me.dsPAINT1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'btnClear
        '
        Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClear.Location = New System.Drawing.Point(300, 47)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 1
        Me.btnClear.Text = "CLEAR"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'taLOG_DAT1
        '
        Me.taLOG_DAT1.ClearBeforeFill = True
        '
        'Timer1
        '
        '
        'dgvLogDat
        '
        Me.dgvLogDat.AllowUserToAddRows = False
        Me.dgvLogDat.AllowUserToDeleteRows = False
        Me.dgvLogDat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvLogDat.AutoGenerateColumns = False
        Me.dgvLogDat.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvLogDat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLogDat.ColumnHeadersVisible = False
        Me.dgvLogDat.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MESSAGEDataGridViewTextBoxColumn})
        Me.dgvLogDat.DataSource = Me.bsLogDat
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 15.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvLogDat.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvLogDat.Location = New System.Drawing.Point(4, 3)
        Me.dgvLogDat.Name = "dgvLogDat"
        Me.dgvLogDat.ReadOnly = True
        Me.dgvLogDat.RowHeadersVisible = False
        Me.dgvLogDat.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.dgvLogDat.RowTemplate.Height = 40
        Me.dgvLogDat.RowTemplate.ReadOnly = True
        Me.dgvLogDat.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvLogDat.Size = New System.Drawing.Size(291, 112)
        Me.dgvLogDat.TabIndex = 2
        '
        'bsLogDat
        '
        Me.bsLogDat.DataMember = "dtLOG_DAT"
        Me.bsLogDat.DataSource = Me.dsPAINT1
        '
        'MESSAGEDataGridViewTextBoxColumn
        '
        Me.MESSAGEDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.MESSAGEDataGridViewTextBoxColumn.DataPropertyName = "MESSAGE"
        Me.MESSAGEDataGridViewTextBoxColumn.HeaderText = "MESSAGE"
        Me.MESSAGEDataGridViewTextBoxColumn.Name = "MESSAGEDataGridViewTextBoxColumn"
        Me.MESSAGEDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ctrlLog
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.dgvLogDat)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.cboLogMsg)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "ctrlLog"
        Me.Size = New System.Drawing.Size(379, 119)
        CType(Me.dsPAINT1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvLogDat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsLogDat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cboLogMsg As System.Windows.Forms.ComboBox
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents dsPAINT1 As Common.dsPAINT
    Friend WithEvents taLOG_DAT1 As taLOG_DAT
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents dgvLogDat As System.Windows.Forms.DataGridView
    Friend WithEvents bsLogDat As System.Windows.Forms.BindingSource
    Friend WithEvents MESSAGEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
