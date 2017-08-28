<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlDataLog
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
        Me.saveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.tabCtrlDataLog = New System.Windows.Forms.TabControl
        Me.tabPgAS400LOG = New System.Windows.Forms.TabPage
        Me.dgvAS400Log = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LOGTYPEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LogLevelAS400Log = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PCNAMEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PROCESS_NO = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.dsPAINT1 = New Common.dsPAINT
        Me.MESSAGE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.bsLOG_DAT = New System.Windows.Forms.BindingSource(Me.components)
        Me.tabPgPLCLOG = New System.Windows.Forms.TabPage
        Me.dgvPLCLog = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LOGTYPEDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LogLevelPLCLog = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PCNAMEDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewComboBoxColumn2 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tabPgOperationLOG = New System.Windows.Forms.TabPage
        Me.dgvOperatLog = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LOGTYPEDataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LogLevelOperatLog = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PCNAMEDataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewComboBoxColumn1 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewComboBoxColumn3 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.CtrlBtnsOperator1 = New PSIS_CLIENT.ctrlBtnsOperator
        Me.taLOG_DAT1 = New Common.dsPAINTTableAdapters.taLOG_DAT
        Me.taPROCESS_MST1 = New Common.dsPAINTTableAdapters.taPROCESS_MST
        Me.tabCtrlDataLog.SuspendLayout()
        Me.tabPgAS400LOG.SuspendLayout()
        CType(Me.dgvAS400Log, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsPAINT1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsLOG_DAT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPgPLCLOG.SuspendLayout()
        CType(Me.dgvPLCLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPgOperationLOG.SuspendLayout()
        CType(Me.dgvOperatLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'saveFileDialog1
        '
        '
        'tabCtrlDataLog
        '
        Me.tabCtrlDataLog.Controls.Add(Me.tabPgAS400LOG)
        Me.tabCtrlDataLog.Controls.Add(Me.tabPgPLCLOG)
        Me.tabCtrlDataLog.Controls.Add(Me.tabPgOperationLOG)
        Me.tabCtrlDataLog.Location = New System.Drawing.Point(0, 0)
        Me.tabCtrlDataLog.Name = "tabCtrlDataLog"
        Me.tabCtrlDataLog.Padding = New System.Drawing.Point(0, 3)
        Me.tabCtrlDataLog.SelectedIndex = 0
        Me.tabCtrlDataLog.Size = New System.Drawing.Size(1034, 528)
        Me.tabCtrlDataLog.TabIndex = 1
        '
        'tabPgAS400LOG
        '
        Me.tabPgAS400LOG.BackColor = System.Drawing.Color.Transparent
        Me.tabPgAS400LOG.Controls.Add(Me.dgvAS400Log)
        Me.tabPgAS400LOG.Location = New System.Drawing.Point(4, 22)
        Me.tabPgAS400LOG.Name = "tabPgAS400LOG"
        Me.tabPgAS400LOG.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.tabPgAS400LOG.Size = New System.Drawing.Size(1026, 502)
        Me.tabPgAS400LOG.TabIndex = 0
        Me.tabPgAS400LOG.Text = "  AS 400 LOG  "
        '
        'dgvAS400Log
        '
        Me.dgvAS400Log.AllowUserToAddRows = False
        Me.dgvAS400Log.AllowUserToResizeRows = False
        Me.dgvAS400Log.AutoGenerateColumns = False
        Me.dgvAS400Log.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAS400Log.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn3, Me.LOGTYPEDataGridViewTextBoxColumn, Me.LogLevelAS400Log, Me.PCNAMEDataGridViewTextBoxColumn, Me.PROCESS_NO, Me.MESSAGE})
        Me.dgvAS400Log.DataSource = Me.bsLOG_DAT
        Me.dgvAS400Log.Location = New System.Drawing.Point(0, 3)
        Me.dgvAS400Log.Name = "dgvAS400Log"
        Me.dgvAS400Log.RowHeadersVisible = False
        Me.dgvAS400Log.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAS400Log.Size = New System.Drawing.Size(1010, 496)
        Me.dgvAS400Log.TabIndex = 0
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "DATE"
        Me.DataGridViewTextBoxColumn1.HeaderText = "DATE"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn1.Width = 42
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "TIME"
        Me.DataGridViewTextBoxColumn3.HeaderText = "TIME"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn3.Width = 39
        '
        'LOGTYPEDataGridViewTextBoxColumn
        '
        Me.LOGTYPEDataGridViewTextBoxColumn.DataPropertyName = "LOG_TYPE"
        Me.LOGTYPEDataGridViewTextBoxColumn.HeaderText = "LOG_TYPE"
        Me.LOGTYPEDataGridViewTextBoxColumn.Name = "LOGTYPEDataGridViewTextBoxColumn"
        Me.LOGTYPEDataGridViewTextBoxColumn.ReadOnly = True
        Me.LOGTYPEDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.LOGTYPEDataGridViewTextBoxColumn.Visible = False
        '
        'LogLevelAS400Log
        '
        Me.LogLevelAS400Log.DataPropertyName = "LOG_LEVEL"
        Me.LogLevelAS400Log.HeaderText = "LOG_LEVEL"
        Me.LogLevelAS400Log.Name = "LogLevelAS400Log"
        Me.LogLevelAS400Log.ReadOnly = True
        Me.LogLevelAS400Log.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.LogLevelAS400Log.Width = 74
        '
        'PCNAMEDataGridViewTextBoxColumn
        '
        Me.PCNAMEDataGridViewTextBoxColumn.DataPropertyName = "PC_NAME"
        Me.PCNAMEDataGridViewTextBoxColumn.HeaderText = "PC_NAME"
        Me.PCNAMEDataGridViewTextBoxColumn.Name = "PCNAMEDataGridViewTextBoxColumn"
        Me.PCNAMEDataGridViewTextBoxColumn.ReadOnly = True
        Me.PCNAMEDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.PCNAMEDataGridViewTextBoxColumn.Width = 64
        '
        'PROCESS_NO
        '
        Me.PROCESS_NO.DataPropertyName = "PROCESS_NO"
        Me.PROCESS_NO.DataSource = Me.dsPAINT1
        Me.PROCESS_NO.DisplayMember = "dtPROCESS_MST.PROCESS_NAME"
        Me.PROCESS_NO.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.PROCESS_NO.HeaderText = "PROCESS NAME"
        Me.PROCESS_NO.Name = "PROCESS_NO"
        Me.PROCESS_NO.ReadOnly = True
        Me.PROCESS_NO.ValueMember = "dtPROCESS_MST.PROCESS_NO"
        Me.PROCESS_NO.Width = 98
        '
        'dsPAINT1
        '
        Me.dsPAINT1.DataSetName = "dsPAINT"
        Me.dsPAINT1.Locale = New System.Globalization.CultureInfo("th-TH")
        Me.dsPAINT1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'MESSAGE
        '
        Me.MESSAGE.DataPropertyName = "MESSAGE"
        Me.MESSAGE.HeaderText = "CONTENT"
        Me.MESSAGE.Name = "MESSAGE"
        Me.MESSAGE.ReadOnly = True
        Me.MESSAGE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.MESSAGE.Width = 65
        '
        'bsLOG_DAT
        '
        Me.bsLOG_DAT.DataMember = "dtLOG_DAT"
        Me.bsLOG_DAT.DataSource = Me.dsPAINT1
        '
        'tabPgPLCLOG
        '
        Me.tabPgPLCLOG.Controls.Add(Me.dgvPLCLog)
        Me.tabPgPLCLOG.Location = New System.Drawing.Point(4, 22)
        Me.tabPgPLCLOG.Name = "tabPgPLCLOG"
        Me.tabPgPLCLOG.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.tabPgPLCLOG.Size = New System.Drawing.Size(1026, 502)
        Me.tabPgPLCLOG.TabIndex = 1
        Me.tabPgPLCLOG.Text = "  PLC LOG  "
        Me.tabPgPLCLOG.UseVisualStyleBackColor = True
        '
        'dgvPLCLog
        '
        Me.dgvPLCLog.AllowUserToAddRows = False
        Me.dgvPLCLog.AllowUserToResizeRows = False
        Me.dgvPLCLog.AutoGenerateColumns = False
        Me.dgvPLCLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPLCLog.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.LOGTYPEDataGridViewTextBoxColumn1, Me.LogLevelPLCLog, Me.PCNAMEDataGridViewTextBoxColumn1, Me.DataGridViewComboBoxColumn2, Me.DataGridViewTextBoxColumn11})
        Me.dgvPLCLog.DataSource = Me.bsLOG_DAT
        Me.dgvPLCLog.Location = New System.Drawing.Point(0, 3)
        Me.dgvPLCLog.Name = "dgvPLCLog"
        Me.dgvPLCLog.RowHeadersVisible = False
        Me.dgvPLCLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPLCLog.Size = New System.Drawing.Size(1010, 496)
        Me.dgvPLCLog.TabIndex = 0
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "DATE"
        Me.DataGridViewTextBoxColumn5.HeaderText = "DATE"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn5.Width = 42
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "TIME"
        Me.DataGridViewTextBoxColumn6.HeaderText = "TIME"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn6.Width = 39
        '
        'LOGTYPEDataGridViewTextBoxColumn1
        '
        Me.LOGTYPEDataGridViewTextBoxColumn1.DataPropertyName = "LOG_TYPE"
        Me.LOGTYPEDataGridViewTextBoxColumn1.HeaderText = "LOG_TYPE"
        Me.LOGTYPEDataGridViewTextBoxColumn1.Name = "LOGTYPEDataGridViewTextBoxColumn1"
        Me.LOGTYPEDataGridViewTextBoxColumn1.ReadOnly = True
        Me.LOGTYPEDataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.LOGTYPEDataGridViewTextBoxColumn1.Visible = False
        '
        'LogLevelPLCLog
        '
        Me.LogLevelPLCLog.DataPropertyName = "LOG_LEVEL"
        Me.LogLevelPLCLog.HeaderText = "LOG_LEVEL"
        Me.LogLevelPLCLog.Name = "LogLevelPLCLog"
        Me.LogLevelPLCLog.ReadOnly = True
        Me.LogLevelPLCLog.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.LogLevelPLCLog.Width = 74
        '
        'PCNAMEDataGridViewTextBoxColumn1
        '
        Me.PCNAMEDataGridViewTextBoxColumn1.DataPropertyName = "PC_NAME"
        Me.PCNAMEDataGridViewTextBoxColumn1.HeaderText = "PC_NAME"
        Me.PCNAMEDataGridViewTextBoxColumn1.Name = "PCNAMEDataGridViewTextBoxColumn1"
        Me.PCNAMEDataGridViewTextBoxColumn1.ReadOnly = True
        Me.PCNAMEDataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.PCNAMEDataGridViewTextBoxColumn1.Width = 64
        '
        'DataGridViewComboBoxColumn2
        '
        Me.DataGridViewComboBoxColumn2.DataPropertyName = "PROCESS_NO"
        Me.DataGridViewComboBoxColumn2.DataSource = Me.dsPAINT1
        Me.DataGridViewComboBoxColumn2.DisplayMember = "dtPROCESS_MST.PROCESS_NAME"
        Me.DataGridViewComboBoxColumn2.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.DataGridViewComboBoxColumn2.HeaderText = "PROCESS NAME"
        Me.DataGridViewComboBoxColumn2.Name = "DataGridViewComboBoxColumn2"
        Me.DataGridViewComboBoxColumn2.ReadOnly = True
        Me.DataGridViewComboBoxColumn2.ValueMember = "dtPROCESS_MST.PROCESS_NO"
        Me.DataGridViewComboBoxColumn2.Width = 88
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "MESSAGE"
        Me.DataGridViewTextBoxColumn11.HeaderText = "CONTENT"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn11.Width = 65
        '
        'tabPgOperationLOG
        '
        Me.tabPgOperationLOG.Controls.Add(Me.dgvOperatLog)
        Me.tabPgOperationLOG.Location = New System.Drawing.Point(4, 22)
        Me.tabPgOperationLOG.Name = "tabPgOperationLOG"
        Me.tabPgOperationLOG.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.tabPgOperationLOG.Size = New System.Drawing.Size(1026, 502)
        Me.tabPgOperationLOG.TabIndex = 2
        Me.tabPgOperationLOG.Text = "  Operation LOG  "
        Me.tabPgOperationLOG.UseVisualStyleBackColor = True
        '
        'dgvOperatLog
        '
        Me.dgvOperatLog.AllowUserToAddRows = False
        Me.dgvOperatLog.AllowUserToResizeRows = False
        Me.dgvOperatLog.AutoGenerateColumns = False
        Me.dgvOperatLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOperatLog.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn8, Me.LOGTYPEDataGridViewTextBoxColumn2, Me.LogLevelOperatLog, Me.PCNAMEDataGridViewTextBoxColumn2, Me.DataGridViewComboBoxColumn1, Me.DataGridViewTextBoxColumn10})
        Me.dgvOperatLog.DataSource = Me.bsLOG_DAT
        Me.dgvOperatLog.Location = New System.Drawing.Point(0, 3)
        Me.dgvOperatLog.Name = "dgvOperatLog"
        Me.dgvOperatLog.RowHeadersVisible = False
        Me.dgvOperatLog.Size = New System.Drawing.Size(1010, 496)
        Me.dgvOperatLog.TabIndex = 0
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "DATE"
        Me.DataGridViewTextBoxColumn2.HeaderText = "DATE"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn2.Width = 42
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "TIME"
        Me.DataGridViewTextBoxColumn8.HeaderText = "TIME"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn8.Width = 39
        '
        'LOGTYPEDataGridViewTextBoxColumn2
        '
        Me.LOGTYPEDataGridViewTextBoxColumn2.DataPropertyName = "LOG_TYPE"
        Me.LOGTYPEDataGridViewTextBoxColumn2.HeaderText = "LOG_TYPE"
        Me.LOGTYPEDataGridViewTextBoxColumn2.Name = "LOGTYPEDataGridViewTextBoxColumn2"
        Me.LOGTYPEDataGridViewTextBoxColumn2.ReadOnly = True
        Me.LOGTYPEDataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.LOGTYPEDataGridViewTextBoxColumn2.Visible = False
        '
        'LogLevelOperatLog
        '
        Me.LogLevelOperatLog.DataPropertyName = "LOG_LEVEL"
        Me.LogLevelOperatLog.HeaderText = "LOG_LEVEL"
        Me.LogLevelOperatLog.Name = "LogLevelOperatLog"
        Me.LogLevelOperatLog.ReadOnly = True
        Me.LogLevelOperatLog.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.LogLevelOperatLog.Width = 74
        '
        'PCNAMEDataGridViewTextBoxColumn2
        '
        Me.PCNAMEDataGridViewTextBoxColumn2.DataPropertyName = "PC_NAME"
        Me.PCNAMEDataGridViewTextBoxColumn2.HeaderText = "PC_NAME"
        Me.PCNAMEDataGridViewTextBoxColumn2.Name = "PCNAMEDataGridViewTextBoxColumn2"
        Me.PCNAMEDataGridViewTextBoxColumn2.ReadOnly = True
        Me.PCNAMEDataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.PCNAMEDataGridViewTextBoxColumn2.Width = 64
        '
        'DataGridViewComboBoxColumn1
        '
        Me.DataGridViewComboBoxColumn1.DataPropertyName = "PROCESS_NO"
        Me.DataGridViewComboBoxColumn1.DataSource = Me.dsPAINT1
        Me.DataGridViewComboBoxColumn1.DisplayMember = "dtPROCESS_MST.PROCESS_NAME"
        Me.DataGridViewComboBoxColumn1.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.DataGridViewComboBoxColumn1.HeaderText = "PROCESS NAME"
        Me.DataGridViewComboBoxColumn1.Name = "DataGridViewComboBoxColumn1"
        Me.DataGridViewComboBoxColumn1.ReadOnly = True
        Me.DataGridViewComboBoxColumn1.ValueMember = "dtPROCESS_MST.PROCESS_NO"
        Me.DataGridViewComboBoxColumn1.Width = 88
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "MESSAGE"
        Me.DataGridViewTextBoxColumn10.HeaderText = "CONTENT"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn10.Width = 65
        '
        'DataGridViewComboBoxColumn3
        '
        Me.DataGridViewComboBoxColumn3.DataPropertyName = "PROCESS_NO"
        Me.DataGridViewComboBoxColumn3.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.DataGridViewComboBoxColumn3.HeaderText = "PROCESS NAME"
        Me.DataGridViewComboBoxColumn3.Name = "DataGridViewComboBoxColumn3"
        Me.DataGridViewComboBoxColumn3.ReadOnly = True
        '
        'CtrlBtnsOperator1
        '
        Me.CtrlBtnsOperator1.F1 = False
        Me.CtrlBtnsOperator1.F10 = False
        Me.CtrlBtnsOperator1.F11 = False
        Me.CtrlBtnsOperator1.F12 = False
        Me.CtrlBtnsOperator1.F2 = False
        Me.CtrlBtnsOperator1.F3 = False
        Me.CtrlBtnsOperator1.F4 = False
        Me.CtrlBtnsOperator1.F5 = False
        Me.CtrlBtnsOperator1.F6 = False
        Me.CtrlBtnsOperator1.F7 = False
        Me.CtrlBtnsOperator1.F8 = False
        Me.CtrlBtnsOperator1.F9 = False
        Me.CtrlBtnsOperator1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CtrlBtnsOperator1.Location = New System.Drawing.Point(39, 535)
        Me.CtrlBtnsOperator1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CtrlBtnsOperator1.Name = "CtrlBtnsOperator1"
        Me.CtrlBtnsOperator1.Size = New System.Drawing.Size(936, 76)
        Me.CtrlBtnsOperator1.TabIndex = 0
        '
        'taLOG_DAT1
        '
        Me.taLOG_DAT1.ClearBeforeFill = True
        '
        'taPROCESS_MST1
        '
        Me.taPROCESS_MST1.ClearBeforeFill = True
        '
        'ctrlDataLog
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.tabCtrlDataLog)
        Me.Controls.Add(Me.CtrlBtnsOperator1)
        Me.Name = "ctrlDataLog"
        Me.Size = New System.Drawing.Size(1034, 615)
        Me.tabCtrlDataLog.ResumeLayout(False)
        Me.tabPgAS400LOG.ResumeLayout(False)
        CType(Me.dgvAS400Log, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsPAINT1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsLOG_DAT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPgPLCLOG.ResumeLayout(False)
        CType(Me.dgvPLCLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPgOperationLOG.ResumeLayout(False)
        CType(Me.dgvOperatLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CtrlBtnsOperator1 As PSIS_CLIENT.ctrlBtnsOperator
    Friend WithEvents bsLOG_DAT As System.Windows.Forms.BindingSource
    Friend WithEvents dsPAINT1 As Common.dsPAINT
    Friend WithEvents taLOG_DAT1 As taLOG_DAT
    Friend WithEvents DateDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TimeDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContentDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateDataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TimeDataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContentDataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TimeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContentDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents saveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents tabCtrlDataLog As System.Windows.Forms.TabControl
    Friend WithEvents tabPgAS400LOG As System.Windows.Forms.TabPage
    Friend WithEvents dgvAS400Log As System.Windows.Forms.DataGridView
    Friend WithEvents tabPgPLCLOG As System.Windows.Forms.TabPage
    Friend WithEvents dgvPLCLog As System.Windows.Forms.DataGridView
    Friend WithEvents tabPgOperationLOG As System.Windows.Forms.TabPage
    Friend WithEvents dgvOperatLog As System.Windows.Forms.DataGridView
    Friend WithEvents PROCESSNAMEDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PROCESSNAMEDataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PROCESSNAMEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn3 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents taPROCESS_MST1 As taPROCESS_MST
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LOGTYPEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LogLevelAS400Log As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PCNAMEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PROCESS_NO As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents MESSAGE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LOGTYPEDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LogLevelPLCLog As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PCNAMEDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn2 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LOGTYPEDataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LogLevelOperatLog As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PCNAMEDataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn1 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
