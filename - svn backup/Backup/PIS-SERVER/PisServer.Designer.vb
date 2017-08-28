<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PisServer
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker
        Me.logEvent = New System.Diagnostics.EventLog
        Me.dgv_dataCollectionView = New System.Windows.Forms.DataGridView
        Me.OccDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MessageDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.bsTLOGDAT = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsServerDataset = New PIS_SERVER.ServerDataset
        Me.dgv_lineMonitorView = New System.Windows.Forms.DataGridView
        Me.LineCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MessagesDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.bsTLineMST = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnExit = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.timClock = New System.Windows.Forms.Timer(Me.components)
        Me.timImport = New System.Windows.Forms.Timer(Me.components)
        Me.ServiceController1 = New System.ServiceProcess.ServiceController
        Me.Label4 = New System.Windows.Forms.Label
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        Me.oshRed = New Microsoft.VisualBasic.PowerPacks.OvalShape
        Me.oshGreen = New Microsoft.VisualBasic.PowerPacks.OvalShape
        Me.btnSystemSetting = New System.Windows.Forms.Button
        Me.ServerDataset = New PIS_SERVER.ServerDataset
        Me.taT_Line_MST = New PIS_SERVER.ServerDatasetTableAdapters.T_Line_MSTTableAdapter
        Me.taT_Production_DAT = New PIS_SERVER.ServerDatasetTableAdapters.T_Production_DATTableAdapter
        Me.taT_LOG_DAT = New PIS_SERVER.ServerDatasetTableAdapters.T_LOG_DATTableAdapter
        Me.taT_Instruction_DAT = New PIS_SERVER.ServerDatasetTableAdapters.T_Instruction_DATTableAdapter
        CType(Me.logEvent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_dataCollectionView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsTLOGDAT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsServerDataset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_lineMonitorView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsTLineMST, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ServerDataset, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BackgroundWorker1
        '
        '
        'logEvent
        '
        Me.logEvent.Log = "Application"
        Me.logEvent.SynchronizingObject = Me
        '
        'dgv_dataCollectionView
        '
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        Me.dgv_dataCollectionView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgv_dataCollectionView.AutoGenerateColumns = False
        Me.dgv_dataCollectionView.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_dataCollectionView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgv_dataCollectionView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_dataCollectionView.ColumnHeadersVisible = False
        Me.dgv_dataCollectionView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.OccDateDataGridViewTextBoxColumn, Me.MessageDataGridViewTextBoxColumn})
        Me.dgv_dataCollectionView.DataSource = Me.bsTLOGDAT
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_dataCollectionView.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgv_dataCollectionView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgv_dataCollectionView.GridColor = System.Drawing.Color.White
        Me.dgv_dataCollectionView.Location = New System.Drawing.Point(12, 95)
        Me.dgv_dataCollectionView.Name = "dgv_dataCollectionView"
        Me.dgv_dataCollectionView.RowHeadersVisible = False
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black
        Me.dgv_dataCollectionView.RowsDefaultCellStyle = DataGridViewCellStyle9
        Me.dgv_dataCollectionView.Size = New System.Drawing.Size(992, 261)
        Me.dgv_dataCollectionView.TabIndex = 0
        '
        'OccDateDataGridViewTextBoxColumn
        '
        Me.OccDateDataGridViewTextBoxColumn.DataPropertyName = "OccDate"
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.Format = "yyyy/MM/dd  HH:mm:ss"
        DataGridViewCellStyle6.NullValue = Nothing
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        Me.OccDateDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.OccDateDataGridViewTextBoxColumn.HeaderText = "OccDate"
        Me.OccDateDataGridViewTextBoxColumn.Name = "OccDateDataGridViewTextBoxColumn"
        Me.OccDateDataGridViewTextBoxColumn.Width = 120
        '
        'MessageDataGridViewTextBoxColumn
        '
        Me.MessageDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.MessageDataGridViewTextBoxColumn.DataPropertyName = "Message"
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        Me.MessageDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle7
        Me.MessageDataGridViewTextBoxColumn.HeaderText = "Message"
        Me.MessageDataGridViewTextBoxColumn.Name = "MessageDataGridViewTextBoxColumn"
        '
        'bsTLOGDAT
        '
        Me.bsTLOGDAT.DataMember = "T_LOG_DAT"
        Me.bsTLOGDAT.DataSource = Me.dsServerDataset
        '
        'dsServerDataset
        '
        Me.dsServerDataset.DataSetName = "ServerDataset"
        Me.dsServerDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'dgv_lineMonitorView
        '
        Me.dgv_lineMonitorView.AllowUserToAddRows = False
        Me.dgv_lineMonitorView.AllowUserToDeleteRows = False
        Me.dgv_lineMonitorView.AllowUserToResizeRows = False
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.dgv_lineMonitorView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_lineMonitorView.AutoGenerateColumns = False
        Me.dgv_lineMonitorView.BackgroundColor = System.Drawing.Color.White
        Me.dgv_lineMonitorView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_lineMonitorView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LineCode, Me.LineNameDataGridViewTextBoxColumn, Me.StatusDataGridViewTextBoxColumn, Me.MessagesDataGridViewTextBoxColumn})
        Me.dgv_lineMonitorView.DataSource = Me.bsTLineMST
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Transparent
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_lineMonitorView.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_lineMonitorView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgv_lineMonitorView.GridColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgv_lineMonitorView.Location = New System.Drawing.Point(15, 369)
        Me.dgv_lineMonitorView.MultiSelect = False
        Me.dgv_lineMonitorView.Name = "dgv_lineMonitorView"
        Me.dgv_lineMonitorView.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_lineMonitorView.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgv_lineMonitorView.RowHeadersVisible = False
        Me.dgv_lineMonitorView.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Silver
        Me.dgv_lineMonitorView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgv_lineMonitorView.Size = New System.Drawing.Size(989, 309)
        Me.dgv_lineMonitorView.TabIndex = 1
        '
        'LineCode
        '
        Me.LineCode.DataPropertyName = "LineCode"
        Me.LineCode.HeaderText = "LineCode"
        Me.LineCode.Name = "LineCode"
        Me.LineCode.ReadOnly = True
        Me.LineCode.Visible = False
        '
        'LineNameDataGridViewTextBoxColumn
        '
        Me.LineNameDataGridViewTextBoxColumn.DataPropertyName = "LineName"
        Me.LineNameDataGridViewTextBoxColumn.HeaderText = "LineName"
        Me.LineNameDataGridViewTextBoxColumn.Name = "LineNameDataGridViewTextBoxColumn"
        Me.LineNameDataGridViewTextBoxColumn.ReadOnly = True
        Me.LineNameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.LineNameDataGridViewTextBoxColumn.Width = 250
        '
        'StatusDataGridViewTextBoxColumn
        '
        Me.StatusDataGridViewTextBoxColumn.DataPropertyName = "Status"
        Me.StatusDataGridViewTextBoxColumn.HeaderText = "STATUS"
        Me.StatusDataGridViewTextBoxColumn.MaxInputLength = 2000
        Me.StatusDataGridViewTextBoxColumn.Name = "StatusDataGridViewTextBoxColumn"
        Me.StatusDataGridViewTextBoxColumn.ReadOnly = True
        Me.StatusDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.StatusDataGridViewTextBoxColumn.Width = 225
        '
        'MessagesDataGridViewTextBoxColumn
        '
        Me.MessagesDataGridViewTextBoxColumn.DataPropertyName = "Messages"
        Me.MessagesDataGridViewTextBoxColumn.HeaderText = "Messages"
        Me.MessagesDataGridViewTextBoxColumn.MaxInputLength = 2000
        Me.MessagesDataGridViewTextBoxColumn.Name = "MessagesDataGridViewTextBoxColumn"
        Me.MessagesDataGridViewTextBoxColumn.ReadOnly = True
        Me.MessagesDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.MessagesDataGridViewTextBoxColumn.Width = 508
        '
        'bsTLineMST
        '
        Me.bsTLineMST.DataMember = "T_Line_MST"
        Me.bsTLineMST.DataSource = Me.dsServerDataset
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(33, 701)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "DateTime"
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(874, 693)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(130, 30)
        Me.btnExit.TabIndex = 3
        Me.btnExit.Text = "EXIT"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Lime
        Me.Label2.Location = New System.Drawing.Point(12, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(992, 68)
        Me.Label2.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.RoyalBlue
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.Location = New System.Drawing.Point(50, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(910, 52)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "RT50 BodyShop ASM LINE Data Collect Program"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'timClock
        '
        Me.timClock.Interval = 500
        '
        'timImport
        '
        '
        'ServiceController1
        '
        Me.ServiceController1.ServiceName = "CPU_UNIT"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(569, 701)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "DB Status"
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape1, Me.oshRed, Me.oshGreen})
        Me.ShapeContainer1.Size = New System.Drawing.Size(1016, 734)
        Me.ShapeContainer1.TabIndex = 8
        Me.ShapeContainer1.TabStop = False
        '
        'RectangleShape1
        '
        Me.RectangleShape1.Location = New System.Drawing.Point(556, 686)
        Me.RectangleShape1.Name = "RectangleShape1"
        Me.RectangleShape1.Size = New System.Drawing.Size(174, 42)
        '
        'oshRed
        '
        Me.oshRed.BackColor = System.Drawing.SystemColors.Control
        Me.oshRed.FillColor = System.Drawing.Color.DarkGray
        Me.oshRed.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.oshRed.Location = New System.Drawing.Point(684, 691)
        Me.oshRed.Name = "oshRed"
        Me.oshRed.Size = New System.Drawing.Size(32, 31)
        '
        'oshGreen
        '
        Me.oshGreen.FillColor = System.Drawing.Color.Lime
        Me.oshGreen.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.oshGreen.Location = New System.Drawing.Point(635, 691)
        Me.oshGreen.Name = "oshGreen"
        Me.oshGreen.Size = New System.Drawing.Size(32, 31)
        '
        'btnSystemSetting
        '
        Me.btnSystemSetting.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSystemSetting.Location = New System.Drawing.Point(738, 693)
        Me.btnSystemSetting.Name = "btnSystemSetting"
        Me.btnSystemSetting.Size = New System.Drawing.Size(130, 30)
        Me.btnSystemSetting.TabIndex = 9
        Me.btnSystemSetting.Text = "System Setting"
        Me.btnSystemSetting.UseVisualStyleBackColor = True
        '
        'ServerDataset
        '
        Me.ServerDataset.DataSetName = "ServerDataset"
        Me.ServerDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'taT_Line_MST
        '
        Me.taT_Line_MST.ClearBeforeFill = True
        '
        'taT_Production_DAT
        '
        Me.taT_Production_DAT.ClearBeforeFill = True
        '
        'taT_LOG_DAT
        '
        Me.taT_LOG_DAT.ClearBeforeFill = True
        '
        'taT_Instruction_DAT
        '
        Me.taT_Instruction_DAT.ClearBeforeFill = True
        '
        'PisServer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1016, 734)
        Me.Controls.Add(Me.btnSystemSetting)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgv_lineMonitorView)
        Me.Controls.Add(Me.dgv_dataCollectionView)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Name = "PisServer"
        Me.Text = "RT-50 PIS"
        CType(Me.logEvent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_dataCollectionView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsTLOGDAT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsServerDataset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_lineMonitorView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsTLineMST, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ServerDataset, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents logEvent As System.Diagnostics.EventLog
    Friend WithEvents dgv_dataCollectionView As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgv_lineMonitorView As System.Windows.Forms.DataGridView
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents timClock As System.Windows.Forms.Timer
    Friend WithEvents timImport As System.Windows.Forms.Timer

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Friend WithEvents bsTLineMST As System.Windows.Forms.BindingSource
    Friend WithEvents dsServerDataset As PIS_SERVER.ServerDataset
    Friend WithEvents taT_Line_MST As PIS_SERVER.ServerDatasetTableAdapters.T_Line_MSTTableAdapter
    'Friend WithEvents taTemP_Production_DAT As PIS_SERVER.ServerDatasetTableAdapters.TEMP_Production_DATTableAdapter
    Friend WithEvents taT_Production_DAT As PIS_SERVER.ServerDatasetTableAdapters.T_Production_DATTableAdapter
    Friend WithEvents taT_LOG_DAT As PIS_SERVER.ServerDatasetTableAdapters.T_LOG_DATTableAdapter
    Friend WithEvents PcNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineNameDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bsTLOGDAT As System.Windows.Forms.BindingSource
    Friend WithEvents ServerDataset As PIS_SERVER.ServerDataset
    Friend WithEvents taT_Instruction_DAT As PIS_SERVER.ServerDatasetTableAdapters.T_Instruction_DATTableAdapter
    Friend WithEvents ServiceController1 As System.ServiceProcess.ServiceController
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents oshRed As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents oshGreen As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents OccDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MessageDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnSystemSetting As System.Windows.Forms.Button
    Friend WithEvents LineCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MessagesDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
