<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DataLog
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
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.dataGridAs400Log = New System.Windows.Forms.DataGridView
        Me.TLOGDATBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSet1 = New InstructionSystem.DataSet1
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.datagridPlcLog = New System.Windows.Forms.DataGridView
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.datagridOperationLog = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOk = New System.Windows.Forms.Button
        Me.LogTypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.btnExport = New System.Windows.Forms.Button
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog
        Me.T_LOG_DATTableAdapter = New InstructionSystem.DataSet1TableAdapters.T_LOG_DATTableAdapter
        Me.IndexNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LogLevel0 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TimeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MessageDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PcNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LogTypeDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OccDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LogIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LogDetailDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IndexNoDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LogLevel1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DateDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TimeDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineNameDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MessageDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LogTypeDataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PcNameDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OccDateDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LogIdDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LogDetailDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IndexNoDataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LogLevel2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DateDataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TimeDataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PcNameDataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineNameDataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MessageDataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LogTypeDataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OccDateDataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LogIdDataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LogDetailDataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dataGridAs400Log, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TLOGDATBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.datagridPlcLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.datagridOperationLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(992, 675)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dataGridAs400Log)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(984, 649)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "AS400 LOG"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dataGridAs400Log
        '
        Me.dataGridAs400Log.AllowUserToAddRows = False
        Me.dataGridAs400Log.AllowUserToDeleteRows = False
        Me.dataGridAs400Log.AllowUserToResizeRows = False
        Me.dataGridAs400Log.AutoGenerateColumns = False
        Me.dataGridAs400Log.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridAs400Log.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IndexNoDataGridViewTextBoxColumn, Me.LogLevel0, Me.DateDataGridViewTextBoxColumn, Me.TimeDataGridViewTextBoxColumn, Me.LineNameDataGridViewTextBoxColumn, Me.MessageDataGridViewTextBoxColumn, Me.PcNameDataGridViewTextBoxColumn, Me.LogTypeDataGridViewTextBoxColumn1, Me.OccDateDataGridViewTextBoxColumn, Me.LogIdDataGridViewTextBoxColumn, Me.LogDetailDataGridViewTextBoxColumn})
        Me.dataGridAs400Log.DataSource = Me.TLOGDATBindingSource
        Me.dataGridAs400Log.Location = New System.Drawing.Point(20, 20)
        Me.dataGridAs400Log.MultiSelect = False
        Me.dataGridAs400Log.Name = "dataGridAs400Log"
        Me.dataGridAs400Log.ReadOnly = True
        Me.dataGridAs400Log.RowHeadersVisible = False
        Me.dataGridAs400Log.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dataGridAs400Log.Size = New System.Drawing.Size(939, 600)
        Me.dataGridAs400Log.TabIndex = 3
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
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.datagridPlcLog)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(984, 649)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "PLC LOG"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'datagridPlcLog
        '
        Me.datagridPlcLog.AllowUserToAddRows = False
        Me.datagridPlcLog.AllowUserToDeleteRows = False
        Me.datagridPlcLog.AllowUserToResizeRows = False
        Me.datagridPlcLog.AutoGenerateColumns = False
        Me.datagridPlcLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datagridPlcLog.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IndexNoDataGridViewTextBoxColumn1, Me.LogLevel1, Me.DateDataGridViewTextBoxColumn1, Me.TimeDataGridViewTextBoxColumn1, Me.LineNameDataGridViewTextBoxColumn1, Me.MessageDataGridViewTextBoxColumn1, Me.LogTypeDataGridViewTextBoxColumn2, Me.PcNameDataGridViewTextBoxColumn1, Me.OccDateDataGridViewTextBoxColumn1, Me.LogIdDataGridViewTextBoxColumn1, Me.LogDetailDataGridViewTextBoxColumn1})
        Me.datagridPlcLog.DataSource = Me.TLOGDATBindingSource
        Me.datagridPlcLog.Location = New System.Drawing.Point(20, 20)
        Me.datagridPlcLog.MultiSelect = False
        Me.datagridPlcLog.Name = "datagridPlcLog"
        Me.datagridPlcLog.ReadOnly = True
        Me.datagridPlcLog.RowHeadersVisible = False
        Me.datagridPlcLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.datagridPlcLog.Size = New System.Drawing.Size(939, 606)
        Me.datagridPlcLog.TabIndex = 2
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.datagridOperationLog)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(984, 649)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Operation Log"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'datagridOperationLog
        '
        Me.datagridOperationLog.AllowUserToAddRows = False
        Me.datagridOperationLog.AllowUserToDeleteRows = False
        Me.datagridOperationLog.AllowUserToResizeRows = False
        Me.datagridOperationLog.AutoGenerateColumns = False
        Me.datagridOperationLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datagridOperationLog.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IndexNoDataGridViewTextBoxColumn2, Me.LogLevel2, Me.DateDataGridViewTextBoxColumn2, Me.TimeDataGridViewTextBoxColumn2, Me.PcNameDataGridViewTextBoxColumn2, Me.LineNameDataGridViewTextBoxColumn2, Me.MessageDataGridViewTextBoxColumn2, Me.LogTypeDataGridViewTextBoxColumn3, Me.OccDateDataGridViewTextBoxColumn2, Me.LogIdDataGridViewTextBoxColumn2, Me.LogDetailDataGridViewTextBoxColumn2})
        Me.datagridOperationLog.DataSource = Me.TLOGDATBindingSource
        Me.datagridOperationLog.Location = New System.Drawing.Point(20, 20)
        Me.datagridOperationLog.MultiSelect = False
        Me.datagridOperationLog.Name = "datagridOperationLog"
        Me.datagridOperationLog.ReadOnly = True
        Me.datagridOperationLog.RowHeadersVisible = False
        Me.datagridOperationLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.datagridOperationLog.Size = New System.Drawing.Size(939, 606)
        Me.datagridOperationLog.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(866, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Label1"
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(898, 689)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(106, 35)
        Me.btnCancel.TabIndex = 18
        Me.btnCancel.Text = "F12:CANCEL"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnOk.Location = New System.Drawing.Point(786, 689)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(106, 35)
        Me.btnOk.TabIndex = 17
        Me.btnOk.Text = "F9:RELOAD"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'LogTypeDataGridViewTextBoxColumn
        '
        Me.LogTypeDataGridViewTextBoxColumn.DataPropertyName = "LogType"
        Me.LogTypeDataGridViewTextBoxColumn.HeaderText = "LogType"
        Me.LogTypeDataGridViewTextBoxColumn.Name = "LogTypeDataGridViewTextBoxColumn"
        Me.LogTypeDataGridViewTextBoxColumn.Visible = False
        Me.LogTypeDataGridViewTextBoxColumn.Width = 128
        '
        'Timer1
        '
        '
        'btnExport
        '
        Me.btnExport.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExport.Location = New System.Drawing.Point(674, 689)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(106, 35)
        Me.btnExport.TabIndex = 4
        Me.btnExport.Text = "F1:EXPORT"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'SaveFileDialog
        '
        Me.SaveFileDialog.DefaultExt = "csv"
        '
        'T_LOG_DATTableAdapter
        '
        Me.T_LOG_DATTableAdapter.ClearBeforeFill = True
        '
        'IndexNoDataGridViewTextBoxColumn
        '
        Me.IndexNoDataGridViewTextBoxColumn.DataPropertyName = "indexNo"
        Me.IndexNoDataGridViewTextBoxColumn.HeaderText = "   "
        Me.IndexNoDataGridViewTextBoxColumn.Name = "IndexNoDataGridViewTextBoxColumn"
        Me.IndexNoDataGridViewTextBoxColumn.ReadOnly = True
        Me.IndexNoDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'LogLevel0
        '
        Me.LogLevel0.DataPropertyName = "LogLevel"
        Me.LogLevel0.HeaderText = "LogLevel"
        Me.LogLevel0.Name = "LogLevel0"
        Me.LogLevel0.ReadOnly = True
        Me.LogLevel0.Visible = False
        '
        'DateDataGridViewTextBoxColumn
        '
        Me.DateDataGridViewTextBoxColumn.DataPropertyName = "Date"
        Me.DateDataGridViewTextBoxColumn.HeaderText = "Date"
        Me.DateDataGridViewTextBoxColumn.Name = "DateDataGridViewTextBoxColumn"
        Me.DateDataGridViewTextBoxColumn.ReadOnly = True
        Me.DateDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'TimeDataGridViewTextBoxColumn
        '
        Me.TimeDataGridViewTextBoxColumn.DataPropertyName = "Time"
        Me.TimeDataGridViewTextBoxColumn.HeaderText = "Time"
        Me.TimeDataGridViewTextBoxColumn.Name = "TimeDataGridViewTextBoxColumn"
        Me.TimeDataGridViewTextBoxColumn.ReadOnly = True
        Me.TimeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'LineNameDataGridViewTextBoxColumn
        '
        Me.LineNameDataGridViewTextBoxColumn.DataPropertyName = "LineName"
        Me.LineNameDataGridViewTextBoxColumn.HeaderText = "LineName"
        Me.LineNameDataGridViewTextBoxColumn.Name = "LineNameDataGridViewTextBoxColumn"
        Me.LineNameDataGridViewTextBoxColumn.ReadOnly = True
        Me.LineNameDataGridViewTextBoxColumn.Visible = False
        '
        'MessageDataGridViewTextBoxColumn
        '
        Me.MessageDataGridViewTextBoxColumn.DataPropertyName = "Message"
        Me.MessageDataGridViewTextBoxColumn.HeaderText = "Content"
        Me.MessageDataGridViewTextBoxColumn.Name = "MessageDataGridViewTextBoxColumn"
        Me.MessageDataGridViewTextBoxColumn.ReadOnly = True
        Me.MessageDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'PcNameDataGridViewTextBoxColumn
        '
        Me.PcNameDataGridViewTextBoxColumn.DataPropertyName = "PcName"
        Me.PcNameDataGridViewTextBoxColumn.HeaderText = "PcName"
        Me.PcNameDataGridViewTextBoxColumn.Name = "PcNameDataGridViewTextBoxColumn"
        Me.PcNameDataGridViewTextBoxColumn.ReadOnly = True
        Me.PcNameDataGridViewTextBoxColumn.Visible = False
        '
        'LogTypeDataGridViewTextBoxColumn1
        '
        Me.LogTypeDataGridViewTextBoxColumn1.DataPropertyName = "LogType"
        Me.LogTypeDataGridViewTextBoxColumn1.HeaderText = "LogType"
        Me.LogTypeDataGridViewTextBoxColumn1.Name = "LogTypeDataGridViewTextBoxColumn1"
        Me.LogTypeDataGridViewTextBoxColumn1.ReadOnly = True
        Me.LogTypeDataGridViewTextBoxColumn1.Visible = False
        '
        'OccDateDataGridViewTextBoxColumn
        '
        Me.OccDateDataGridViewTextBoxColumn.DataPropertyName = "OccDate"
        Me.OccDateDataGridViewTextBoxColumn.HeaderText = "OccDate"
        Me.OccDateDataGridViewTextBoxColumn.Name = "OccDateDataGridViewTextBoxColumn"
        Me.OccDateDataGridViewTextBoxColumn.ReadOnly = True
        Me.OccDateDataGridViewTextBoxColumn.Visible = False
        '
        'LogIdDataGridViewTextBoxColumn
        '
        Me.LogIdDataGridViewTextBoxColumn.DataPropertyName = "LogId"
        Me.LogIdDataGridViewTextBoxColumn.HeaderText = "LogId"
        Me.LogIdDataGridViewTextBoxColumn.Name = "LogIdDataGridViewTextBoxColumn"
        Me.LogIdDataGridViewTextBoxColumn.ReadOnly = True
        Me.LogIdDataGridViewTextBoxColumn.Visible = False
        '
        'LogDetailDataGridViewTextBoxColumn
        '
        Me.LogDetailDataGridViewTextBoxColumn.DataPropertyName = "logDetail"
        Me.LogDetailDataGridViewTextBoxColumn.HeaderText = "logDetail"
        Me.LogDetailDataGridViewTextBoxColumn.Name = "LogDetailDataGridViewTextBoxColumn"
        Me.LogDetailDataGridViewTextBoxColumn.ReadOnly = True
        Me.LogDetailDataGridViewTextBoxColumn.Visible = False
        '
        'IndexNoDataGridViewTextBoxColumn1
        '
        Me.IndexNoDataGridViewTextBoxColumn1.DataPropertyName = "indexNo"
        Me.IndexNoDataGridViewTextBoxColumn1.HeaderText = "   "
        Me.IndexNoDataGridViewTextBoxColumn1.Name = "IndexNoDataGridViewTextBoxColumn1"
        Me.IndexNoDataGridViewTextBoxColumn1.ReadOnly = True
        Me.IndexNoDataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'LogLevel1
        '
        Me.LogLevel1.DataPropertyName = "LogLevel"
        Me.LogLevel1.HeaderText = "LogLevel"
        Me.LogLevel1.Name = "LogLevel1"
        Me.LogLevel1.ReadOnly = True
        Me.LogLevel1.Visible = False
        '
        'DateDataGridViewTextBoxColumn1
        '
        Me.DateDataGridViewTextBoxColumn1.DataPropertyName = "Date"
        Me.DateDataGridViewTextBoxColumn1.HeaderText = "Date"
        Me.DateDataGridViewTextBoxColumn1.Name = "DateDataGridViewTextBoxColumn1"
        Me.DateDataGridViewTextBoxColumn1.ReadOnly = True
        Me.DateDataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'TimeDataGridViewTextBoxColumn1
        '
        Me.TimeDataGridViewTextBoxColumn1.DataPropertyName = "Time"
        Me.TimeDataGridViewTextBoxColumn1.HeaderText = "Time"
        Me.TimeDataGridViewTextBoxColumn1.Name = "TimeDataGridViewTextBoxColumn1"
        Me.TimeDataGridViewTextBoxColumn1.ReadOnly = True
        Me.TimeDataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'LineNameDataGridViewTextBoxColumn1
        '
        Me.LineNameDataGridViewTextBoxColumn1.DataPropertyName = "LineName"
        Me.LineNameDataGridViewTextBoxColumn1.HeaderText = "LineName"
        Me.LineNameDataGridViewTextBoxColumn1.Name = "LineNameDataGridViewTextBoxColumn1"
        Me.LineNameDataGridViewTextBoxColumn1.ReadOnly = True
        Me.LineNameDataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MessageDataGridViewTextBoxColumn1
        '
        Me.MessageDataGridViewTextBoxColumn1.DataPropertyName = "Message"
        Me.MessageDataGridViewTextBoxColumn1.HeaderText = "Content"
        Me.MessageDataGridViewTextBoxColumn1.Name = "MessageDataGridViewTextBoxColumn1"
        Me.MessageDataGridViewTextBoxColumn1.ReadOnly = True
        Me.MessageDataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'LogTypeDataGridViewTextBoxColumn2
        '
        Me.LogTypeDataGridViewTextBoxColumn2.DataPropertyName = "LogType"
        Me.LogTypeDataGridViewTextBoxColumn2.HeaderText = "LogType"
        Me.LogTypeDataGridViewTextBoxColumn2.Name = "LogTypeDataGridViewTextBoxColumn2"
        Me.LogTypeDataGridViewTextBoxColumn2.ReadOnly = True
        Me.LogTypeDataGridViewTextBoxColumn2.Visible = False
        '
        'PcNameDataGridViewTextBoxColumn1
        '
        Me.PcNameDataGridViewTextBoxColumn1.DataPropertyName = "PcName"
        Me.PcNameDataGridViewTextBoxColumn1.HeaderText = "PcName"
        Me.PcNameDataGridViewTextBoxColumn1.Name = "PcNameDataGridViewTextBoxColumn1"
        Me.PcNameDataGridViewTextBoxColumn1.ReadOnly = True
        Me.PcNameDataGridViewTextBoxColumn1.Visible = False
        '
        'OccDateDataGridViewTextBoxColumn1
        '
        Me.OccDateDataGridViewTextBoxColumn1.DataPropertyName = "OccDate"
        Me.OccDateDataGridViewTextBoxColumn1.HeaderText = "OccDate"
        Me.OccDateDataGridViewTextBoxColumn1.Name = "OccDateDataGridViewTextBoxColumn1"
        Me.OccDateDataGridViewTextBoxColumn1.ReadOnly = True
        Me.OccDateDataGridViewTextBoxColumn1.Visible = False
        '
        'LogIdDataGridViewTextBoxColumn1
        '
        Me.LogIdDataGridViewTextBoxColumn1.DataPropertyName = "LogId"
        Me.LogIdDataGridViewTextBoxColumn1.HeaderText = "LogId"
        Me.LogIdDataGridViewTextBoxColumn1.Name = "LogIdDataGridViewTextBoxColumn1"
        Me.LogIdDataGridViewTextBoxColumn1.ReadOnly = True
        Me.LogIdDataGridViewTextBoxColumn1.Visible = False
        '
        'LogDetailDataGridViewTextBoxColumn1
        '
        Me.LogDetailDataGridViewTextBoxColumn1.DataPropertyName = "logDetail"
        Me.LogDetailDataGridViewTextBoxColumn1.HeaderText = "logDetail"
        Me.LogDetailDataGridViewTextBoxColumn1.Name = "LogDetailDataGridViewTextBoxColumn1"
        Me.LogDetailDataGridViewTextBoxColumn1.ReadOnly = True
        Me.LogDetailDataGridViewTextBoxColumn1.Visible = False
        '
        'IndexNoDataGridViewTextBoxColumn2
        '
        Me.IndexNoDataGridViewTextBoxColumn2.DataPropertyName = "indexNo"
        Me.IndexNoDataGridViewTextBoxColumn2.HeaderText = "   "
        Me.IndexNoDataGridViewTextBoxColumn2.Name = "IndexNoDataGridViewTextBoxColumn2"
        Me.IndexNoDataGridViewTextBoxColumn2.ReadOnly = True
        Me.IndexNoDataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'LogLevel2
        '
        Me.LogLevel2.DataPropertyName = "LogLevel"
        Me.LogLevel2.HeaderText = "LogLevel"
        Me.LogLevel2.Name = "LogLevel2"
        Me.LogLevel2.ReadOnly = True
        Me.LogLevel2.Visible = False
        '
        'DateDataGridViewTextBoxColumn2
        '
        Me.DateDataGridViewTextBoxColumn2.DataPropertyName = "Date"
        Me.DateDataGridViewTextBoxColumn2.HeaderText = "Date"
        Me.DateDataGridViewTextBoxColumn2.Name = "DateDataGridViewTextBoxColumn2"
        Me.DateDataGridViewTextBoxColumn2.ReadOnly = True
        Me.DateDataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'TimeDataGridViewTextBoxColumn2
        '
        Me.TimeDataGridViewTextBoxColumn2.DataPropertyName = "Time"
        Me.TimeDataGridViewTextBoxColumn2.HeaderText = "Time"
        Me.TimeDataGridViewTextBoxColumn2.Name = "TimeDataGridViewTextBoxColumn2"
        Me.TimeDataGridViewTextBoxColumn2.ReadOnly = True
        Me.TimeDataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'PcNameDataGridViewTextBoxColumn2
        '
        Me.PcNameDataGridViewTextBoxColumn2.DataPropertyName = "PcName"
        Me.PcNameDataGridViewTextBoxColumn2.HeaderText = "PcName"
        Me.PcNameDataGridViewTextBoxColumn2.Name = "PcNameDataGridViewTextBoxColumn2"
        Me.PcNameDataGridViewTextBoxColumn2.ReadOnly = True
        Me.PcNameDataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'LineNameDataGridViewTextBoxColumn2
        '
        Me.LineNameDataGridViewTextBoxColumn2.DataPropertyName = "LineName"
        Me.LineNameDataGridViewTextBoxColumn2.HeaderText = "LineName"
        Me.LineNameDataGridViewTextBoxColumn2.Name = "LineNameDataGridViewTextBoxColumn2"
        Me.LineNameDataGridViewTextBoxColumn2.ReadOnly = True
        Me.LineNameDataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MessageDataGridViewTextBoxColumn2
        '
        Me.MessageDataGridViewTextBoxColumn2.DataPropertyName = "Message"
        Me.MessageDataGridViewTextBoxColumn2.HeaderText = "Content"
        Me.MessageDataGridViewTextBoxColumn2.Name = "MessageDataGridViewTextBoxColumn2"
        Me.MessageDataGridViewTextBoxColumn2.ReadOnly = True
        Me.MessageDataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'LogTypeDataGridViewTextBoxColumn3
        '
        Me.LogTypeDataGridViewTextBoxColumn3.DataPropertyName = "LogType"
        Me.LogTypeDataGridViewTextBoxColumn3.HeaderText = "LogType"
        Me.LogTypeDataGridViewTextBoxColumn3.Name = "LogTypeDataGridViewTextBoxColumn3"
        Me.LogTypeDataGridViewTextBoxColumn3.ReadOnly = True
        Me.LogTypeDataGridViewTextBoxColumn3.Visible = False
        '
        'OccDateDataGridViewTextBoxColumn2
        '
        Me.OccDateDataGridViewTextBoxColumn2.DataPropertyName = "OccDate"
        Me.OccDateDataGridViewTextBoxColumn2.HeaderText = "OccDate"
        Me.OccDateDataGridViewTextBoxColumn2.Name = "OccDateDataGridViewTextBoxColumn2"
        Me.OccDateDataGridViewTextBoxColumn2.ReadOnly = True
        Me.OccDateDataGridViewTextBoxColumn2.Visible = False
        '
        'LogIdDataGridViewTextBoxColumn2
        '
        Me.LogIdDataGridViewTextBoxColumn2.DataPropertyName = "LogId"
        Me.LogIdDataGridViewTextBoxColumn2.HeaderText = "LogId"
        Me.LogIdDataGridViewTextBoxColumn2.Name = "LogIdDataGridViewTextBoxColumn2"
        Me.LogIdDataGridViewTextBoxColumn2.ReadOnly = True
        Me.LogIdDataGridViewTextBoxColumn2.Visible = False
        '
        'LogDetailDataGridViewTextBoxColumn2
        '
        Me.LogDetailDataGridViewTextBoxColumn2.DataPropertyName = "logDetail"
        Me.LogDetailDataGridViewTextBoxColumn2.HeaderText = "logDetail"
        Me.LogDetailDataGridViewTextBoxColumn2.Name = "LogDetailDataGridViewTextBoxColumn2"
        Me.LogDetailDataGridViewTextBoxColumn2.ReadOnly = True
        Me.LogDetailDataGridViewTextBoxColumn2.Visible = False
        '
        'DataLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(1016, 730)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximumSize = New System.Drawing.Size(1024, 768)
        Me.MinimumSize = New System.Drawing.Size(1022, 732)
        Me.Name = "DataLog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LOG Data Display"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dataGridAs400Log, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TLOGDATBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.datagridPlcLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.datagridOperationLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents datagridPlcLog As System.Windows.Forms.DataGridView
    Friend WithEvents datagridOperationLog As System.Windows.Forms.DataGridView
    Friend WithEvents dataGridAs400Log As System.Windows.Forms.DataGridView
    Friend WithEvents LogTypeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataSet1 As InstructionSystem.DataSet1
    Friend WithEvents TLOGDATBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents T_LOG_DATTableAdapter As InstructionSystem.DataSet1TableAdapters.T_LOG_DATTableAdapter
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents IndexNoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LogLevel0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TimeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MessageDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PcNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LogTypeDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OccDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LogIdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LogDetailDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IndexNoDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LogLevel1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TimeDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineNameDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MessageDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LogTypeDataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PcNameDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OccDateDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LogIdDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LogDetailDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IndexNoDataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LogLevel2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateDataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TimeDataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PcNameDataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineNameDataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MessageDataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LogTypeDataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OccDateDataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LogIdDataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LogDetailDataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
