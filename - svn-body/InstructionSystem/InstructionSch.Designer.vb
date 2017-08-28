<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InstructionSch
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InstructionSch))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.btnF12 = New System.Windows.Forms.Button
        Me.btnF11 = New System.Windows.Forms.Button
        Me.btnF10 = New System.Windows.Forms.Button
        Me.btnF9 = New System.Windows.Forms.Button
        Me.btnF8 = New System.Windows.Forms.Button
        Me.btnF7 = New System.Windows.Forms.Button
        Me.btnF6 = New System.Windows.Forms.Button
        Me.btnF5 = New System.Windows.Forms.Button
        Me.btnF4 = New System.Windows.Forms.Button
        Me.btnF3 = New System.Windows.Forms.Button
        Me.btnF2 = New System.Windows.Forms.Button
        Me.btnF1 = New System.Windows.Forms.Button
        Me.btnLine10 = New System.Windows.Forms.Button
        Me.btnLine9 = New System.Windows.Forms.Button
        Me.btnLine8 = New System.Windows.Forms.Button
        Me.btnLine7 = New System.Windows.Forms.Button
        Me.btnLine6 = New System.Windows.Forms.Button
        Me.btnLine5 = New System.Windows.Forms.Button
        Me.btnLine4 = New System.Windows.Forms.Button
        Me.btnLine3 = New System.Windows.Forms.Button
        Me.btnLine2 = New System.Windows.Forms.Button
        Me.btnLine1 = New System.Windows.Forms.Button
        Me.cmboxLogInfo = New System.Windows.Forms.ComboBox
        Me.TLOGDATBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSet1 = New InstructionSystem.DataSet1
        Me.btnLeft = New System.Windows.Forms.Button
        Me.btnRight = New System.Windows.Forms.Button
        Me.DataGridIdata = New System.Windows.Forms.DataGridView
        Me.IndexNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SeqNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SubSeqDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ModelYearDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SuffixCodeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LotIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LotNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnitDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BlockModelDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BlockSeqDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MARKDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProductionDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProductionTimeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ImportCodeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.YChassisFlagDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GAShopDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HanmmerYearsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ASM01DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ASM02DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ASM03DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ASM04DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ASM05DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.XchgFlagDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InsResultDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InsPassFlagDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.LineNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CarrResultDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CarrPassFlagDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.TInstructionDATBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnLine20 = New System.Windows.Forms.Button
        Me.btnLine19 = New System.Windows.Forms.Button
        Me.btnLine18 = New System.Windows.Forms.Button
        Me.btnLine17 = New System.Windows.Forms.Button
        Me.btnLine16 = New System.Windows.Forms.Button
        Me.btnLine15 = New System.Windows.Forms.Button
        Me.btnLine14 = New System.Windows.Forms.Button
        Me.btnLine13 = New System.Windows.Forms.Button
        Me.btnLine12 = New System.Windows.Forms.Button
        Me.btnLine11 = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.btnClear = New System.Windows.Forms.Button
        Me.lblTime = New System.Windows.Forms.Label
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.T_Instruction_DATTableAdapter = New InstructionSystem.DataSet1TableAdapters.T_Instruction_DATTableAdapter
        Me.T_Production_DATTableAdapter = New InstructionSystem.DataSet1TableAdapters.T_Production_DATTableAdapter
        Me.T_LOG_DATTableAdapter = New InstructionSystem.DataSet1TableAdapters.T_LOG_DATTableAdapter
        Me.T_Line_MSTTableAdapter = New InstructionSystem.DataSet1TableAdapters.T_Line_MSTTableAdapter
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LOT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.TLOGDATBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridIdata, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TInstructionDATBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnF12
        '
        Me.btnF12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnF12.Location = New System.Drawing.Point(853, 657)
        Me.btnF12.Name = "btnF12"
        Me.btnF12.Size = New System.Drawing.Size(151, 35)
        Me.btnF12.TabIndex = 38
        Me.btnF12.TabStop = False
        Me.btnF12.Text = "F12:MENU"
        Me.btnF12.UseVisualStyleBackColor = True
        '
        'btnF11
        '
        Me.btnF11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnF11.Location = New System.Drawing.Point(686, 657)
        Me.btnF11.Name = "btnF11"
        Me.btnF11.Size = New System.Drawing.Size(151, 35)
        Me.btnF11.TabIndex = 37
        Me.btnF11.TabStop = False
        Me.btnF11.Text = "F11:________"
        Me.btnF11.UseVisualStyleBackColor = True
        '
        'btnF10
        '
        Me.btnF10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnF10.Location = New System.Drawing.Point(519, 657)
        Me.btnF10.Name = "btnF10"
        Me.btnF10.Size = New System.Drawing.Size(151, 35)
        Me.btnF10.TabIndex = 36
        Me.btnF10.TabStop = False
        Me.btnF10.Text = "F10:SEARCH"
        Me.btnF10.UseVisualStyleBackColor = True
        '
        'btnF9
        '
        Me.btnF9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnF9.Location = New System.Drawing.Point(347, 657)
        Me.btnF9.Name = "btnF9"
        Me.btnF9.Size = New System.Drawing.Size(151, 35)
        Me.btnF9.TabIndex = 35
        Me.btnF9.TabStop = False
        Me.btnF9.Text = "F9:RELOAD"
        Me.btnF9.UseVisualStyleBackColor = True
        '
        'btnF8
        '
        Me.btnF8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnF8.Location = New System.Drawing.Point(177, 657)
        Me.btnF8.Name = "btnF8"
        Me.btnF8.Size = New System.Drawing.Size(151, 35)
        Me.btnF8.TabIndex = 34
        Me.btnF8.TabStop = False
        Me.btnF8.Text = "F8:NEXT"
        Me.btnF8.UseVisualStyleBackColor = True
        '
        'btnF7
        '
        Me.btnF7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnF7.Location = New System.Drawing.Point(12, 657)
        Me.btnF7.Name = "btnF7"
        Me.btnF7.Size = New System.Drawing.Size(151, 35)
        Me.btnF7.TabIndex = 33
        Me.btnF7.TabStop = False
        Me.btnF7.Text = "F7:PREVIOUS"
        Me.btnF7.UseVisualStyleBackColor = True
        '
        'btnF6
        '
        Me.btnF6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnF6.Location = New System.Drawing.Point(853, 615)
        Me.btnF6.Name = "btnF6"
        Me.btnF6.Size = New System.Drawing.Size(151, 35)
        Me.btnF6.TabIndex = 32
        Me.btnF6.TabStop = False
        Me.btnF6.Text = "F6:_________"
        Me.btnF6.UseVisualStyleBackColor = True
        '
        'btnF5
        '
        Me.btnF5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnF5.Location = New System.Drawing.Point(686, 615)
        Me.btnF5.Name = "btnF5"
        Me.btnF5.Size = New System.Drawing.Size(151, 35)
        Me.btnF5.TabIndex = 31
        Me.btnF5.TabStop = False
        Me.btnF5.Text = "F5:_________"
        Me.btnF5.UseVisualStyleBackColor = True
        '
        'btnF4
        '
        Me.btnF4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnF4.Location = New System.Drawing.Point(519, 615)
        Me.btnF4.Name = "btnF4"
        Me.btnF4.Size = New System.Drawing.Size(151, 35)
        Me.btnF4.TabIndex = 30
        Me.btnF4.TabStop = False
        Me.btnF4.Text = "F4:_________"
        Me.btnF4.UseVisualStyleBackColor = True
        '
        'btnF3
        '
        Me.btnF3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnF3.Location = New System.Drawing.Point(347, 615)
        Me.btnF3.Name = "btnF3"
        Me.btnF3.Size = New System.Drawing.Size(151, 35)
        Me.btnF3.TabIndex = 29
        Me.btnF3.TabStop = False
        Me.btnF3.Text = "F3:_________"
        Me.btnF3.UseVisualStyleBackColor = True
        '
        'btnF2
        '
        Me.btnF2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnF2.Location = New System.Drawing.Point(177, 615)
        Me.btnF2.Name = "btnF2"
        Me.btnF2.Size = New System.Drawing.Size(151, 35)
        Me.btnF2.TabIndex = 28
        Me.btnF2.TabStop = False
        Me.btnF2.Text = "F2:_________"
        Me.btnF2.UseVisualStyleBackColor = True
        '
        'btnF1
        '
        Me.btnF1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnF1.Location = New System.Drawing.Point(9, 615)
        Me.btnF1.Name = "btnF1"
        Me.btnF1.Size = New System.Drawing.Size(151, 35)
        Me.btnF1.TabIndex = 27
        Me.btnF1.TabStop = False
        Me.btnF1.Text = "F1:CHANGE"
        Me.btnF1.UseVisualStyleBackColor = True
        '
        'btnLine10
        '
        Me.btnLine10.BackColor = System.Drawing.Color.LightGreen
        Me.btnLine10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnLine10.Location = New System.Drawing.Point(773, 67)
        Me.btnLine10.Name = "btnLine10"
        Me.btnLine10.Size = New System.Drawing.Size(151, 35)
        Me.btnLine10.TabIndex = 48
        Me.btnLine10.Text = "Line10"
        Me.btnLine10.UseVisualStyleBackColor = False
        '
        'btnLine9
        '
        Me.btnLine9.BackColor = System.Drawing.Color.LightGreen
        Me.btnLine9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnLine9.Location = New System.Drawing.Point(605, 67)
        Me.btnLine9.Name = "btnLine9"
        Me.btnLine9.Size = New System.Drawing.Size(151, 35)
        Me.btnLine9.TabIndex = 47
        Me.btnLine9.Text = "Line9"
        Me.btnLine9.UseVisualStyleBackColor = False
        '
        'btnLine8
        '
        Me.btnLine8.BackColor = System.Drawing.Color.LightGreen
        Me.btnLine8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnLine8.Location = New System.Drawing.Point(439, 67)
        Me.btnLine8.Name = "btnLine8"
        Me.btnLine8.Size = New System.Drawing.Size(151, 35)
        Me.btnLine8.TabIndex = 46
        Me.btnLine8.Text = "Line8"
        Me.btnLine8.UseVisualStyleBackColor = False
        '
        'btnLine7
        '
        Me.btnLine7.BackColor = System.Drawing.Color.LightGreen
        Me.btnLine7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnLine7.Location = New System.Drawing.Point(274, 67)
        Me.btnLine7.Name = "btnLine7"
        Me.btnLine7.Size = New System.Drawing.Size(151, 35)
        Me.btnLine7.TabIndex = 45
        Me.btnLine7.Text = "Line7"
        Me.btnLine7.UseVisualStyleBackColor = False
        '
        'btnLine6
        '
        Me.btnLine6.BackColor = System.Drawing.Color.LightGreen
        Me.btnLine6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnLine6.Location = New System.Drawing.Point(111, 67)
        Me.btnLine6.Name = "btnLine6"
        Me.btnLine6.Size = New System.Drawing.Size(151, 35)
        Me.btnLine6.TabIndex = 44
        Me.btnLine6.Text = "Line6"
        Me.btnLine6.UseVisualStyleBackColor = False
        '
        'btnLine5
        '
        Me.btnLine5.BackColor = System.Drawing.Color.LightGreen
        Me.btnLine5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnLine5.Location = New System.Drawing.Point(773, 26)
        Me.btnLine5.Name = "btnLine5"
        Me.btnLine5.Size = New System.Drawing.Size(151, 35)
        Me.btnLine5.TabIndex = 43
        Me.btnLine5.Text = "Line5"
        Me.btnLine5.UseVisualStyleBackColor = False
        '
        'btnLine4
        '
        Me.btnLine4.BackColor = System.Drawing.Color.LightGreen
        Me.btnLine4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnLine4.Location = New System.Drawing.Point(605, 26)
        Me.btnLine4.Name = "btnLine4"
        Me.btnLine4.Size = New System.Drawing.Size(151, 35)
        Me.btnLine4.TabIndex = 42
        Me.btnLine4.Text = "Line4"
        Me.btnLine4.UseVisualStyleBackColor = False
        '
        'btnLine3
        '
        Me.btnLine3.BackColor = System.Drawing.Color.LightGreen
        Me.btnLine3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnLine3.Location = New System.Drawing.Point(439, 26)
        Me.btnLine3.Name = "btnLine3"
        Me.btnLine3.Size = New System.Drawing.Size(151, 35)
        Me.btnLine3.TabIndex = 41
        Me.btnLine3.Text = "Line3"
        Me.btnLine3.UseVisualStyleBackColor = False
        '
        'btnLine2
        '
        Me.btnLine2.BackColor = System.Drawing.Color.LightGreen
        Me.btnLine2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnLine2.Location = New System.Drawing.Point(274, 26)
        Me.btnLine2.Name = "btnLine2"
        Me.btnLine2.Size = New System.Drawing.Size(151, 35)
        Me.btnLine2.TabIndex = 40
        Me.btnLine2.Text = "Line2"
        Me.btnLine2.UseVisualStyleBackColor = False
        '
        'btnLine1
        '
        Me.btnLine1.BackColor = System.Drawing.Color.LightGreen
        Me.btnLine1.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnLine1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnLine1.Location = New System.Drawing.Point(111, 26)
        Me.btnLine1.Name = "btnLine1"
        Me.btnLine1.Size = New System.Drawing.Size(151, 35)
        Me.btnLine1.TabIndex = 39
        Me.btnLine1.Text = "Line1"
        Me.btnLine1.UseVisualStyleBackColor = False
        '
        'cmboxLogInfo
        '
        Me.cmboxLogInfo.DataSource = Me.TLOGDATBindingSource
        Me.cmboxLogInfo.DisplayMember = "logDetail"
        Me.cmboxLogInfo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmboxLogInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmboxLogInfo.FormattingEnabled = True
        Me.cmboxLogInfo.Location = New System.Drawing.Point(9, 698)
        Me.cmboxLogInfo.MaxDropDownItems = 30
        Me.cmboxLogInfo.Name = "cmboxLogInfo"
        Me.cmboxLogInfo.Size = New System.Drawing.Size(880, 24)
        Me.cmboxLogInfo.TabIndex = 49
        Me.cmboxLogInfo.TabStop = False
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
        'btnLeft
        '
        Me.btnLeft.BackColor = System.Drawing.Color.LightGreen
        Me.btnLeft.Enabled = False
        Me.btnLeft.Image = CType(resources.GetObject("btnLeft.Image"), System.Drawing.Image)
        Me.btnLeft.Location = New System.Drawing.Point(27, 33)
        Me.btnLeft.Name = "btnLeft"
        Me.btnLeft.Size = New System.Drawing.Size(75, 53)
        Me.btnLeft.TabIndex = 50
        Me.btnLeft.TabStop = False
        Me.btnLeft.UseVisualStyleBackColor = False
        '
        'btnRight
        '
        Me.btnRight.BackColor = System.Drawing.Color.LightGreen
        Me.btnRight.Image = CType(resources.GetObject("btnRight.Image"), System.Drawing.Image)
        Me.btnRight.Location = New System.Drawing.Point(930, 33)
        Me.btnRight.Name = "btnRight"
        Me.btnRight.Size = New System.Drawing.Size(75, 53)
        Me.btnRight.TabIndex = 51
        Me.btnRight.TabStop = False
        Me.btnRight.UseVisualStyleBackColor = False
        '
        'DataGridIdata
        '
        Me.DataGridIdata.AllowUserToAddRows = False
        Me.DataGridIdata.AllowUserToDeleteRows = False
        Me.DataGridIdata.AllowUserToResizeRows = False
        Me.DataGridIdata.AutoGenerateColumns = False
        Me.DataGridIdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridIdata.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IndexNoDataGridViewTextBoxColumn, Me.SeqNoDataGridViewTextBoxColumn, Me.SubSeqDataGridViewTextBoxColumn, Me.ModelYearDataGridViewTextBoxColumn, Me.SuffixCodeDataGridViewTextBoxColumn, Me.LotIDDataGridViewTextBoxColumn, Me.LotNoDataGridViewTextBoxColumn, Me.UnitDataGridViewTextBoxColumn, Me.BlockModelDataGridViewTextBoxColumn, Me.BlockSeqDataGridViewTextBoxColumn, Me.MARKDataGridViewTextBoxColumn, Me.ProductionDateDataGridViewTextBoxColumn, Me.ProductionTimeDataGridViewTextBoxColumn, Me.ImportCodeDataGridViewTextBoxColumn, Me.YChassisFlagDataGridViewTextBoxColumn, Me.GAShopDataGridViewTextBoxColumn, Me.HanmmerYearsDataGridViewTextBoxColumn, Me.ASM01DataGridViewTextBoxColumn, Me.ASM02DataGridViewTextBoxColumn, Me.ASM03DataGridViewTextBoxColumn, Me.ASM04DataGridViewTextBoxColumn, Me.ASM05DataGridViewTextBoxColumn, Me.XchgFlagDataGridViewTextBoxColumn, Me.InsResultDataGridViewTextBoxColumn, Me.InsPassFlagDataGridViewCheckBoxColumn, Me.LineNoDataGridViewTextBoxColumn, Me.CarrResultDataGridViewTextBoxColumn, Me.CarrPassFlagDataGridViewCheckBoxColumn})
        Me.DataGridIdata.DataSource = Me.TInstructionDATBindingSource
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridIdata.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridIdata.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DataGridIdata.Location = New System.Drawing.Point(12, 125)
        Me.DataGridIdata.MultiSelect = False
        Me.DataGridIdata.Name = "DataGridIdata"
        Me.DataGridIdata.RowHeadersVisible = False
        Me.DataGridIdata.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.DataGridIdata.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridIdata.Size = New System.Drawing.Size(991, 484)
        Me.DataGridIdata.TabIndex = 0
        '
        'IndexNoDataGridViewTextBoxColumn
        '
        Me.IndexNoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.IndexNoDataGridViewTextBoxColumn.DataPropertyName = "indexNo"
        DataGridViewCellStyle1.Format = "yyyy/MM/dd hh:mm"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.IndexNoDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.IndexNoDataGridViewTextBoxColumn.HeaderText = "indexNo"
        Me.IndexNoDataGridViewTextBoxColumn.Name = "IndexNoDataGridViewTextBoxColumn"
        Me.IndexNoDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'SeqNoDataGridViewTextBoxColumn
        '
        Me.SeqNoDataGridViewTextBoxColumn.DataPropertyName = "SeqNo"
        Me.SeqNoDataGridViewTextBoxColumn.HeaderText = "SeqNo"
        Me.SeqNoDataGridViewTextBoxColumn.Name = "SeqNoDataGridViewTextBoxColumn"
        Me.SeqNoDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'SubSeqDataGridViewTextBoxColumn
        '
        Me.SubSeqDataGridViewTextBoxColumn.DataPropertyName = "SubSeq"
        Me.SubSeqDataGridViewTextBoxColumn.HeaderText = "SubSeq"
        Me.SubSeqDataGridViewTextBoxColumn.Name = "SubSeqDataGridViewTextBoxColumn"
        Me.SubSeqDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ModelYearDataGridViewTextBoxColumn
        '
        Me.ModelYearDataGridViewTextBoxColumn.DataPropertyName = "ModelYear"
        Me.ModelYearDataGridViewTextBoxColumn.HeaderText = "ModelYear"
        Me.ModelYearDataGridViewTextBoxColumn.Name = "ModelYearDataGridViewTextBoxColumn"
        Me.ModelYearDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'SuffixCodeDataGridViewTextBoxColumn
        '
        Me.SuffixCodeDataGridViewTextBoxColumn.DataPropertyName = "SuffixCode"
        Me.SuffixCodeDataGridViewTextBoxColumn.HeaderText = "SuffixCode"
        Me.SuffixCodeDataGridViewTextBoxColumn.Name = "SuffixCodeDataGridViewTextBoxColumn"
        Me.SuffixCodeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'LotIDDataGridViewTextBoxColumn
        '
        Me.LotIDDataGridViewTextBoxColumn.DataPropertyName = "LotID"
        Me.LotIDDataGridViewTextBoxColumn.HeaderText = "LotID"
        Me.LotIDDataGridViewTextBoxColumn.Name = "LotIDDataGridViewTextBoxColumn"
        Me.LotIDDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'LotNoDataGridViewTextBoxColumn
        '
        Me.LotNoDataGridViewTextBoxColumn.DataPropertyName = "LotNo"
        Me.LotNoDataGridViewTextBoxColumn.HeaderText = "LotNo"
        Me.LotNoDataGridViewTextBoxColumn.Name = "LotNoDataGridViewTextBoxColumn"
        Me.LotNoDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'UnitDataGridViewTextBoxColumn
        '
        Me.UnitDataGridViewTextBoxColumn.DataPropertyName = "Unit"
        Me.UnitDataGridViewTextBoxColumn.HeaderText = "Unit"
        Me.UnitDataGridViewTextBoxColumn.Name = "UnitDataGridViewTextBoxColumn"
        Me.UnitDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'BlockModelDataGridViewTextBoxColumn
        '
        Me.BlockModelDataGridViewTextBoxColumn.DataPropertyName = "BlockModel"
        Me.BlockModelDataGridViewTextBoxColumn.HeaderText = "BlockModel"
        Me.BlockModelDataGridViewTextBoxColumn.Name = "BlockModelDataGridViewTextBoxColumn"
        Me.BlockModelDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'BlockSeqDataGridViewTextBoxColumn
        '
        Me.BlockSeqDataGridViewTextBoxColumn.DataPropertyName = "BlockSeq"
        Me.BlockSeqDataGridViewTextBoxColumn.HeaderText = "BlockSeq"
        Me.BlockSeqDataGridViewTextBoxColumn.Name = "BlockSeqDataGridViewTextBoxColumn"
        Me.BlockSeqDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MARKDataGridViewTextBoxColumn
        '
        Me.MARKDataGridViewTextBoxColumn.DataPropertyName = "MARK"
        Me.MARKDataGridViewTextBoxColumn.HeaderText = "MARK"
        Me.MARKDataGridViewTextBoxColumn.Name = "MARKDataGridViewTextBoxColumn"
        Me.MARKDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ProductionDateDataGridViewTextBoxColumn
        '
        Me.ProductionDateDataGridViewTextBoxColumn.DataPropertyName = "ProductionDate"
        Me.ProductionDateDataGridViewTextBoxColumn.HeaderText = "ProductionDate"
        Me.ProductionDateDataGridViewTextBoxColumn.Name = "ProductionDateDataGridViewTextBoxColumn"
        Me.ProductionDateDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ProductionTimeDataGridViewTextBoxColumn
        '
        Me.ProductionTimeDataGridViewTextBoxColumn.DataPropertyName = "ProductionTime"
        Me.ProductionTimeDataGridViewTextBoxColumn.HeaderText = "ProductionTime"
        Me.ProductionTimeDataGridViewTextBoxColumn.Name = "ProductionTimeDataGridViewTextBoxColumn"
        Me.ProductionTimeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ImportCodeDataGridViewTextBoxColumn
        '
        Me.ImportCodeDataGridViewTextBoxColumn.DataPropertyName = "ImportCode"
        Me.ImportCodeDataGridViewTextBoxColumn.HeaderText = "ImportCode"
        Me.ImportCodeDataGridViewTextBoxColumn.Name = "ImportCodeDataGridViewTextBoxColumn"
        Me.ImportCodeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'YChassisFlagDataGridViewTextBoxColumn
        '
        Me.YChassisFlagDataGridViewTextBoxColumn.DataPropertyName = "YChassisFlag"
        Me.YChassisFlagDataGridViewTextBoxColumn.HeaderText = "YChassisFlag"
        Me.YChassisFlagDataGridViewTextBoxColumn.Name = "YChassisFlagDataGridViewTextBoxColumn"
        Me.YChassisFlagDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GAShopDataGridViewTextBoxColumn
        '
        Me.GAShopDataGridViewTextBoxColumn.DataPropertyName = "GAShop"
        Me.GAShopDataGridViewTextBoxColumn.HeaderText = "GAShop"
        Me.GAShopDataGridViewTextBoxColumn.Name = "GAShopDataGridViewTextBoxColumn"
        Me.GAShopDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'HanmmerYearsDataGridViewTextBoxColumn
        '
        Me.HanmmerYearsDataGridViewTextBoxColumn.DataPropertyName = "HanmmerYears"
        Me.HanmmerYearsDataGridViewTextBoxColumn.HeaderText = "HanmmerYears"
        Me.HanmmerYearsDataGridViewTextBoxColumn.Name = "HanmmerYearsDataGridViewTextBoxColumn"
        Me.HanmmerYearsDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ASM01DataGridViewTextBoxColumn
        '
        Me.ASM01DataGridViewTextBoxColumn.DataPropertyName = "ASM01"
        Me.ASM01DataGridViewTextBoxColumn.HeaderText = "ASM01"
        Me.ASM01DataGridViewTextBoxColumn.Name = "ASM01DataGridViewTextBoxColumn"
        Me.ASM01DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ASM02DataGridViewTextBoxColumn
        '
        Me.ASM02DataGridViewTextBoxColumn.DataPropertyName = "ASM02"
        Me.ASM02DataGridViewTextBoxColumn.HeaderText = "ASM02"
        Me.ASM02DataGridViewTextBoxColumn.Name = "ASM02DataGridViewTextBoxColumn"
        Me.ASM02DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ASM03DataGridViewTextBoxColumn
        '
        Me.ASM03DataGridViewTextBoxColumn.DataPropertyName = "ASM03"
        Me.ASM03DataGridViewTextBoxColumn.HeaderText = "ASM03"
        Me.ASM03DataGridViewTextBoxColumn.Name = "ASM03DataGridViewTextBoxColumn"
        Me.ASM03DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ASM04DataGridViewTextBoxColumn
        '
        Me.ASM04DataGridViewTextBoxColumn.DataPropertyName = "ASM04"
        Me.ASM04DataGridViewTextBoxColumn.HeaderText = "ASM04"
        Me.ASM04DataGridViewTextBoxColumn.Name = "ASM04DataGridViewTextBoxColumn"
        Me.ASM04DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ASM05DataGridViewTextBoxColumn
        '
        Me.ASM05DataGridViewTextBoxColumn.DataPropertyName = "ASM05"
        Me.ASM05DataGridViewTextBoxColumn.HeaderText = "ASM05"
        Me.ASM05DataGridViewTextBoxColumn.Name = "ASM05DataGridViewTextBoxColumn"
        Me.ASM05DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'XchgFlagDataGridViewTextBoxColumn
        '
        Me.XchgFlagDataGridViewTextBoxColumn.DataPropertyName = "XchgFlag"
        Me.XchgFlagDataGridViewTextBoxColumn.HeaderText = "XchgFlag"
        Me.XchgFlagDataGridViewTextBoxColumn.Name = "XchgFlagDataGridViewTextBoxColumn"
        Me.XchgFlagDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.XchgFlagDataGridViewTextBoxColumn.Visible = False
        '
        'InsResultDataGridViewTextBoxColumn
        '
        Me.InsResultDataGridViewTextBoxColumn.DataPropertyName = "InsResult"
        Me.InsResultDataGridViewTextBoxColumn.HeaderText = "InsResult"
        Me.InsResultDataGridViewTextBoxColumn.Name = "InsResultDataGridViewTextBoxColumn"
        Me.InsResultDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'InsPassFlagDataGridViewCheckBoxColumn
        '
        Me.InsPassFlagDataGridViewCheckBoxColumn.DataPropertyName = "InsPassFlag"
        Me.InsPassFlagDataGridViewCheckBoxColumn.HeaderText = "InsPassFlag"
        Me.InsPassFlagDataGridViewCheckBoxColumn.Name = "InsPassFlagDataGridViewCheckBoxColumn"
        Me.InsPassFlagDataGridViewCheckBoxColumn.Visible = False
        '
        'LineNoDataGridViewTextBoxColumn
        '
        Me.LineNoDataGridViewTextBoxColumn.DataPropertyName = "Line_No"
        Me.LineNoDataGridViewTextBoxColumn.HeaderText = "Line_No"
        Me.LineNoDataGridViewTextBoxColumn.Name = "LineNoDataGridViewTextBoxColumn"
        Me.LineNoDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.LineNoDataGridViewTextBoxColumn.Visible = False
        '
        'CarrResultDataGridViewTextBoxColumn
        '
        Me.CarrResultDataGridViewTextBoxColumn.DataPropertyName = "CarrResult"
        DataGridViewCellStyle2.Format = "yyyy/MM/dd hh:mm"
        Me.CarrResultDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.CarrResultDataGridViewTextBoxColumn.HeaderText = "CarrResult"
        Me.CarrResultDataGridViewTextBoxColumn.Name = "CarrResultDataGridViewTextBoxColumn"
        Me.CarrResultDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.CarrResultDataGridViewTextBoxColumn.Visible = False
        '
        'CarrPassFlagDataGridViewCheckBoxColumn
        '
        Me.CarrPassFlagDataGridViewCheckBoxColumn.DataPropertyName = "CarrPassFlag"
        Me.CarrPassFlagDataGridViewCheckBoxColumn.HeaderText = "CarrPassFlag"
        Me.CarrPassFlagDataGridViewCheckBoxColumn.Name = "CarrPassFlagDataGridViewCheckBoxColumn"
        Me.CarrPassFlagDataGridViewCheckBoxColumn.Visible = False
        '
        'TInstructionDATBindingSource
        '
        Me.TInstructionDATBindingSource.DataMember = "T_Instruction_DAT"
        Me.TInstructionDATBindingSource.DataSource = Me.DataSet1
        '
        'btnLine20
        '
        Me.btnLine20.BackColor = System.Drawing.Color.LightGreen
        Me.btnLine20.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnLine20.Location = New System.Drawing.Point(773, 67)
        Me.btnLine20.Name = "btnLine20"
        Me.btnLine20.Size = New System.Drawing.Size(151, 35)
        Me.btnLine20.TabIndex = 62
        Me.btnLine20.TabStop = False
        Me.btnLine20.Text = "Line20"
        Me.btnLine20.UseVisualStyleBackColor = False
        Me.btnLine20.Visible = False
        '
        'btnLine19
        '
        Me.btnLine19.BackColor = System.Drawing.Color.LightGreen
        Me.btnLine19.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnLine19.Location = New System.Drawing.Point(605, 67)
        Me.btnLine19.Name = "btnLine19"
        Me.btnLine19.Size = New System.Drawing.Size(151, 35)
        Me.btnLine19.TabIndex = 61
        Me.btnLine19.TabStop = False
        Me.btnLine19.Text = "Line19"
        Me.btnLine19.UseVisualStyleBackColor = False
        Me.btnLine19.Visible = False
        '
        'btnLine18
        '
        Me.btnLine18.BackColor = System.Drawing.Color.LightGreen
        Me.btnLine18.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnLine18.Location = New System.Drawing.Point(439, 67)
        Me.btnLine18.Name = "btnLine18"
        Me.btnLine18.Size = New System.Drawing.Size(151, 35)
        Me.btnLine18.TabIndex = 60
        Me.btnLine18.TabStop = False
        Me.btnLine18.Text = "Line18"
        Me.btnLine18.UseVisualStyleBackColor = False
        Me.btnLine18.Visible = False
        '
        'btnLine17
        '
        Me.btnLine17.BackColor = System.Drawing.Color.LightGreen
        Me.btnLine17.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnLine17.Location = New System.Drawing.Point(274, 67)
        Me.btnLine17.Name = "btnLine17"
        Me.btnLine17.Size = New System.Drawing.Size(151, 35)
        Me.btnLine17.TabIndex = 59
        Me.btnLine17.TabStop = False
        Me.btnLine17.Text = "Line17"
        Me.btnLine17.UseVisualStyleBackColor = False
        Me.btnLine17.Visible = False
        '
        'btnLine16
        '
        Me.btnLine16.BackColor = System.Drawing.Color.LightGreen
        Me.btnLine16.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnLine16.Location = New System.Drawing.Point(111, 67)
        Me.btnLine16.Name = "btnLine16"
        Me.btnLine16.Size = New System.Drawing.Size(151, 35)
        Me.btnLine16.TabIndex = 58
        Me.btnLine16.TabStop = False
        Me.btnLine16.Text = "Line16"
        Me.btnLine16.UseVisualStyleBackColor = False
        Me.btnLine16.Visible = False
        '
        'btnLine15
        '
        Me.btnLine15.BackColor = System.Drawing.Color.LightGreen
        Me.btnLine15.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnLine15.Location = New System.Drawing.Point(773, 26)
        Me.btnLine15.Name = "btnLine15"
        Me.btnLine15.Size = New System.Drawing.Size(151, 35)
        Me.btnLine15.TabIndex = 57
        Me.btnLine15.TabStop = False
        Me.btnLine15.Text = "Line15"
        Me.btnLine15.UseVisualStyleBackColor = False
        Me.btnLine15.Visible = False
        '
        'btnLine14
        '
        Me.btnLine14.BackColor = System.Drawing.Color.LightGreen
        Me.btnLine14.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnLine14.Location = New System.Drawing.Point(605, 26)
        Me.btnLine14.Name = "btnLine14"
        Me.btnLine14.Size = New System.Drawing.Size(151, 35)
        Me.btnLine14.TabIndex = 56
        Me.btnLine14.TabStop = False
        Me.btnLine14.Text = "Line14"
        Me.btnLine14.UseVisualStyleBackColor = False
        Me.btnLine14.Visible = False
        '
        'btnLine13
        '
        Me.btnLine13.BackColor = System.Drawing.Color.LightGreen
        Me.btnLine13.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnLine13.Location = New System.Drawing.Point(439, 26)
        Me.btnLine13.Name = "btnLine13"
        Me.btnLine13.Size = New System.Drawing.Size(151, 35)
        Me.btnLine13.TabIndex = 55
        Me.btnLine13.TabStop = False
        Me.btnLine13.Text = "Line13"
        Me.btnLine13.UseVisualStyleBackColor = False
        Me.btnLine13.Visible = False
        '
        'btnLine12
        '
        Me.btnLine12.BackColor = System.Drawing.Color.LightGreen
        Me.btnLine12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnLine12.Location = New System.Drawing.Point(274, 26)
        Me.btnLine12.Name = "btnLine12"
        Me.btnLine12.Size = New System.Drawing.Size(151, 35)
        Me.btnLine12.TabIndex = 54
        Me.btnLine12.TabStop = False
        Me.btnLine12.Text = "Line12"
        Me.btnLine12.UseVisualStyleBackColor = False
        Me.btnLine12.Visible = False
        '
        'btnLine11
        '
        Me.btnLine11.BackColor = System.Drawing.Color.LightGreen
        Me.btnLine11.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnLine11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnLine11.Location = New System.Drawing.Point(111, 26)
        Me.btnLine11.Name = "btnLine11"
        Me.btnLine11.Size = New System.Drawing.Size(151, 35)
        Me.btnLine11.TabIndex = 53
        Me.btnLine11.TabStop = False
        Me.btnLine11.Text = "Line11"
        Me.btnLine11.UseVisualStyleBackColor = False
        Me.btnLine11.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 2000
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(895, 698)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(109, 24)
        Me.btnClear.TabIndex = 63
        Me.btnClear.TabStop = False
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'lblTime
        '
        Me.lblTime.AutoSize = True
        Me.lblTime.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblTime.Location = New System.Drawing.Point(885, 9)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(39, 13)
        Me.lblTime.TabIndex = 64
        Me.lblTime.Text = "Label1"
        Me.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        'T_LOG_DATTableAdapter
        '
        Me.T_LOG_DATTableAdapter.ClearBeforeFill = True
        '
        'T_Line_MSTTableAdapter
        '
        Me.T_Line_MSTTableAdapter.ClearBeforeFill = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.LOT, Me.Column4})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 108)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(991, 33)
        Me.DataGridView1.TabIndex = 67
        '
        'Column1
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle5
        Me.Column1.HeaderText = " "
        Me.Column1.Name = "Column1"
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column2
        '
        Me.Column2.HeaderText = " "
        Me.Column2.Name = "Column2"
        Me.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column3
        '
        Me.Column3.HeaderText = "MODEL CODE"
        Me.Column3.Name = "Column3"
        Me.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'LOT
        '
        Me.LOT.HeaderText = "LOT"
        Me.LOT.Name = "LOT"
        Me.LOT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column4
        '
        Me.Column4.HeaderText = " "
        Me.Column4.Name = "Column4"
        Me.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'InstructionSch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGreen
        Me.ClientSize = New System.Drawing.Size(1016, 734)
        Me.Controls.Add(Me.lblTime)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnLine11)
        Me.Controls.Add(Me.btnLine20)
        Me.Controls.Add(Me.btnLine19)
        Me.Controls.Add(Me.btnLine18)
        Me.Controls.Add(Me.btnLine17)
        Me.Controls.Add(Me.btnLine16)
        Me.Controls.Add(Me.btnLine15)
        Me.Controls.Add(Me.btnLine14)
        Me.Controls.Add(Me.btnLine13)
        Me.Controls.Add(Me.btnLine12)
        Me.Controls.Add(Me.btnLine1)
        Me.Controls.Add(Me.DataGridIdata)
        Me.Controls.Add(Me.btnRight)
        Me.Controls.Add(Me.btnLeft)
        Me.Controls.Add(Me.cmboxLogInfo)
        Me.Controls.Add(Me.btnLine10)
        Me.Controls.Add(Me.btnLine9)
        Me.Controls.Add(Me.btnLine8)
        Me.Controls.Add(Me.btnLine7)
        Me.Controls.Add(Me.btnLine6)
        Me.Controls.Add(Me.btnLine5)
        Me.Controls.Add(Me.btnLine4)
        Me.Controls.Add(Me.btnLine3)
        Me.Controls.Add(Me.btnLine2)
        Me.Controls.Add(Me.btnF12)
        Me.Controls.Add(Me.btnF11)
        Me.Controls.Add(Me.btnF10)
        Me.Controls.Add(Me.btnF9)
        Me.Controls.Add(Me.btnF8)
        Me.Controls.Add(Me.btnF7)
        Me.Controls.Add(Me.btnF6)
        Me.Controls.Add(Me.btnF5)
        Me.Controls.Add(Me.btnF4)
        Me.Controls.Add(Me.btnF3)
        Me.Controls.Add(Me.btnF2)
        Me.Controls.Add(Me.btnF1)
        Me.Controls.Add(Me.DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximumSize = New System.Drawing.Size(1024, 768)
        Me.MinimumSize = New System.Drawing.Size(1022, 732)
        Me.Name = "InstructionSch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "INSTRUCTION SCHEDULE"
        CType(Me.TLOGDATBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridIdata, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TInstructionDATBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnF12 As System.Windows.Forms.Button
    Friend WithEvents btnF11 As System.Windows.Forms.Button
    Friend WithEvents btnF10 As System.Windows.Forms.Button
    Friend WithEvents btnF9 As System.Windows.Forms.Button
    Friend WithEvents btnF8 As System.Windows.Forms.Button
    Friend WithEvents btnF7 As System.Windows.Forms.Button
    Friend WithEvents btnF6 As System.Windows.Forms.Button
    Friend WithEvents btnF5 As System.Windows.Forms.Button
    Friend WithEvents btnF4 As System.Windows.Forms.Button
    Friend WithEvents btnF3 As System.Windows.Forms.Button
    Friend WithEvents btnF2 As System.Windows.Forms.Button
    Friend WithEvents btnF1 As System.Windows.Forms.Button
    Friend WithEvents btnLine10 As System.Windows.Forms.Button
    Friend WithEvents btnLine9 As System.Windows.Forms.Button
    Friend WithEvents btnLine8 As System.Windows.Forms.Button
    Friend WithEvents btnLine7 As System.Windows.Forms.Button
    Friend WithEvents btnLine6 As System.Windows.Forms.Button
    Friend WithEvents btnLine5 As System.Windows.Forms.Button
    Friend WithEvents btnLine4 As System.Windows.Forms.Button
    Friend WithEvents btnLine3 As System.Windows.Forms.Button
    Friend WithEvents btnLine2 As System.Windows.Forms.Button
    Friend WithEvents btnLine1 As System.Windows.Forms.Button
    Friend WithEvents cmboxLogInfo As System.Windows.Forms.ComboBox
    Friend WithEvents btnLeft As System.Windows.Forms.Button
    Friend WithEvents btnRight As System.Windows.Forms.Button
    Friend WithEvents DataGridIdata As System.Windows.Forms.DataGridView
    Friend WithEvents btnLine20 As System.Windows.Forms.Button
    Friend WithEvents btnLine19 As System.Windows.Forms.Button
    Friend WithEvents btnLine18 As System.Windows.Forms.Button
    Friend WithEvents btnLine17 As System.Windows.Forms.Button
    Friend WithEvents btnLine16 As System.Windows.Forms.Button
    Friend WithEvents btnLine15 As System.Windows.Forms.Button
    Friend WithEvents btnLine14 As System.Windows.Forms.Button
    Friend WithEvents btnLine13 As System.Windows.Forms.Button
    Friend WithEvents btnLine12 As System.Windows.Forms.Button
    Friend WithEvents btnLine11 As System.Windows.Forms.Button
    Friend WithEvents DataSet1 As InstructionSystem.DataSet1
    Friend WithEvents TInstructionDATBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents T_Instruction_DATTableAdapter As InstructionSystem.DataSet1TableAdapters.T_Instruction_DATTableAdapter
    Friend WithEvents T_Production_DATTableAdapter As InstructionSystem.DataSet1TableAdapters.T_Production_DATTableAdapter
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents T_LOG_DATTableAdapter As InstructionSystem.DataSet1TableAdapters.T_LOG_DATTableAdapter
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents TLOGDATBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents T_Line_MSTTableAdapter As DataSet1TableAdapters.T_Line_MSTTableAdapter
    Friend WithEvents lblTime As System.Windows.Forms.Label
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents IndexNoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SeqNoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SubSeqDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ModelYearDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SuffixCodeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LotIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LotNoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BlockModelDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BlockSeqDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MARKDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductionDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductionTimeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ImportCodeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents YChassisFlagDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GAShopDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HanmmerYearsDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ASM01DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ASM02DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ASM03DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ASM04DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ASM05DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents XchgFlagDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InsResultDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InsPassFlagDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents LineNoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CarrResultDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CarrPassFlagDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LOT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
