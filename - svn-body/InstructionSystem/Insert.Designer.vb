<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Insert
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
        Me.labelBlockNo = New System.Windows.Forms.Label
        Me.lblLabel = New System.Windows.Forms.Label
        Me.rdbSelectedPart = New System.Windows.Forms.RadioButton
        Me.rdbLotBlock = New System.Windows.Forms.RadioButton
        Me.DataGridInsertData = New System.Windows.Forms.DataGridView
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOk = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.lblValue = New System.Windows.Forms.Label
        Me.lblLabel2 = New System.Windows.Forms.Label
        Me.lblValue2 = New System.Windows.Forms.Label
        Me.TProductionDATBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSet1 = New InstructionSystem.DataSet1
        Me.T_Production_DATTableAdapter = New InstructionSystem.DataSet1TableAdapters.T_Production_DATTableAdapter
        Me.IndexNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SeqNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SubSeqDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SEQDESCDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
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
        Me.MODEL01ASM01DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL01ASM02DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL01ASM03DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL01ASM04DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL01ASM05DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL02ASM01DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL02ASM02DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL02ASM03DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL02ASM04DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL02ASM05DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL03ASM01DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL03ASM02DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL03ASM03DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL03ASM04DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL03ASM05DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL04ASM01DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL04ASM02DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL04ASM03DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL04ASM04DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL04ASM05DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL05ASM01DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL05ASM02DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL05ASM03DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL05ASM04DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL05ASM05DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL06ASM01DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL06ASM02DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL06ASM03DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL06ASM04DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL06ASM05DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL07ASM01DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL07ASM02DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL07ASM03DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL07ASM04DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL07ASM05DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL08ASM01DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL08ASM02DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL08ASM03DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL08ASM04DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL08ASM05DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL09ASM01DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL09ASM02DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL09ASM03DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL09ASM04DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL09ASM05DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL10ASM01DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL10ASM02DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL10ASM03DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL10ASM04DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL10ASM05DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL11ASM01DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL11ASM02DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL11ASM03DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL11ASM04DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL11ASM05DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL12ASM01DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL12ASM02DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL12ASM03DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL12ASM04DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL12ASM05DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL13ASM01DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL13ASM02DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL13ASM03DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL13ASM04DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL13ASM05DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL14ASM01DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL14ASM02DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL14ASM03DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL14ASM04DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL14ASM05DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL15ASM01DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL15ASM02DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL15ASM03DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL15ASM04DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL15ASM05DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL16ASM01DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL16ASM02DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL16ASM03DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL16ASM04DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL16ASM05DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL17ASM01DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL17ASM02DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL17ASM03DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL17ASM04DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL17ASM05DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL18ASM01DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL18ASM02DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL18ASM03DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL18ASM04DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL18ASM05DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL19ASM01DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL19ASM02DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL19ASM03DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL19ASM04DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL19ASM05DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL20ASM01DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL20ASM02DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL20ASM03DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL20ASM04DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MODEL20ASM05DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Reserve01DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Reserve02DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.XchgFlagDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InstructFlagDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FileNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DataGridInsertData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TProductionDATBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'labelBlockNo
        '
        Me.labelBlockNo.AutoSize = True
        Me.labelBlockNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.labelBlockNo.Location = New System.Drawing.Point(194, 97)
        Me.labelBlockNo.Name = "labelBlockNo"
        Me.labelBlockNo.Size = New System.Drawing.Size(0, 17)
        Me.labelBlockNo.TabIndex = 7
        '
        'lblLabel
        '
        Me.lblLabel.AutoSize = True
        Me.lblLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblLabel.Location = New System.Drawing.Point(97, 97)
        Me.lblLabel.Name = "lblLabel"
        Me.lblLabel.Size = New System.Drawing.Size(79, 17)
        Me.lblLabel.TabIndex = 6
        Me.lblLabel.Text = "ModelCode"
        '
        'rdbSelectedPart
        '
        Me.rdbSelectedPart.AutoSize = True
        Me.rdbSelectedPart.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.rdbSelectedPart.Location = New System.Drawing.Point(54, 55)
        Me.rdbSelectedPart.Name = "rdbSelectedPart"
        Me.rdbSelectedPart.Size = New System.Drawing.Size(110, 21)
        Me.rdbSelectedPart.TabIndex = 5
        Me.rdbSelectedPart.Text = "Selected part"
        Me.rdbSelectedPart.UseVisualStyleBackColor = True
        '
        'rdbLotBlock
        '
        Me.rdbLotBlock.AutoSize = True
        Me.rdbLotBlock.Checked = True
        Me.rdbLotBlock.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.rdbLotBlock.Location = New System.Drawing.Point(54, 28)
        Me.rdbLotBlock.Name = "rdbLotBlock"
        Me.rdbLotBlock.Size = New System.Drawing.Size(159, 21)
        Me.rdbLotBlock.TabIndex = 4
        Me.rdbLotBlock.TabStop = True
        Me.rdbLotBlock.Text = "Lot No. part / BLOCK"
        Me.rdbLotBlock.UseVisualStyleBackColor = True
        '
        'DataGridInsertData
        '
        Me.DataGridInsertData.AllowUserToAddRows = False
        Me.DataGridInsertData.AllowUserToDeleteRows = False
        Me.DataGridInsertData.AllowUserToResizeRows = False
        Me.DataGridInsertData.AutoGenerateColumns = False
        Me.DataGridInsertData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridInsertData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IndexNoDataGridViewTextBoxColumn, Me.SeqNoDataGridViewTextBoxColumn, Me.SubSeqDataGridViewTextBoxColumn, Me.SEQDESCDataGridViewTextBoxColumn, Me.ModelYearDataGridViewTextBoxColumn, Me.SuffixCodeDataGridViewTextBoxColumn, Me.LotIDDataGridViewTextBoxColumn, Me.LotNoDataGridViewTextBoxColumn, Me.UnitDataGridViewTextBoxColumn, Me.BlockModelDataGridViewTextBoxColumn, Me.BlockSeqDataGridViewTextBoxColumn, Me.MARKDataGridViewTextBoxColumn, Me.ProductionDateDataGridViewTextBoxColumn, Me.ProductionTimeDataGridViewTextBoxColumn, Me.ImportCodeDataGridViewTextBoxColumn, Me.YChassisFlagDataGridViewTextBoxColumn, Me.GAShopDataGridViewTextBoxColumn, Me.HanmmerYearsDataGridViewTextBoxColumn, Me.MODEL01ASM01DataGridViewTextBoxColumn, Me.MODEL01ASM02DataGridViewTextBoxColumn, Me.MODEL01ASM03DataGridViewTextBoxColumn, Me.MODEL01ASM04DataGridViewTextBoxColumn, Me.MODEL01ASM05DataGridViewTextBoxColumn, Me.MODEL02ASM01DataGridViewTextBoxColumn, Me.MODEL02ASM02DataGridViewTextBoxColumn, Me.MODEL02ASM03DataGridViewTextBoxColumn, Me.MODEL02ASM04DataGridViewTextBoxColumn, Me.MODEL02ASM05DataGridViewTextBoxColumn, Me.MODEL03ASM01DataGridViewTextBoxColumn, Me.MODEL03ASM02DataGridViewTextBoxColumn, Me.MODEL03ASM03DataGridViewTextBoxColumn, Me.MODEL03ASM04DataGridViewTextBoxColumn, Me.MODEL03ASM05DataGridViewTextBoxColumn, Me.MODEL04ASM01DataGridViewTextBoxColumn, Me.MODEL04ASM02DataGridViewTextBoxColumn, Me.MODEL04ASM03DataGridViewTextBoxColumn, Me.MODEL04ASM04DataGridViewTextBoxColumn, Me.MODEL04ASM05DataGridViewTextBoxColumn, Me.MODEL05ASM01DataGridViewTextBoxColumn, Me.MODEL05ASM02DataGridViewTextBoxColumn, Me.MODEL05ASM03DataGridViewTextBoxColumn, Me.MODEL05ASM04DataGridViewTextBoxColumn, Me.MODEL05ASM05DataGridViewTextBoxColumn, Me.MODEL06ASM01DataGridViewTextBoxColumn, Me.MODEL06ASM02DataGridViewTextBoxColumn, Me.MODEL06ASM03DataGridViewTextBoxColumn, Me.MODEL06ASM04DataGridViewTextBoxColumn, Me.MODEL06ASM05DataGridViewTextBoxColumn, Me.MODEL07ASM01DataGridViewTextBoxColumn, Me.MODEL07ASM02DataGridViewTextBoxColumn, Me.MODEL07ASM03DataGridViewTextBoxColumn, Me.MODEL07ASM04DataGridViewTextBoxColumn, Me.MODEL07ASM05DataGridViewTextBoxColumn, Me.MODEL08ASM01DataGridViewTextBoxColumn, Me.MODEL08ASM02DataGridViewTextBoxColumn, Me.MODEL08ASM03DataGridViewTextBoxColumn, Me.MODEL08ASM04DataGridViewTextBoxColumn, Me.MODEL08ASM05DataGridViewTextBoxColumn, Me.MODEL09ASM01DataGridViewTextBoxColumn, Me.MODEL09ASM02DataGridViewTextBoxColumn, Me.MODEL09ASM03DataGridViewTextBoxColumn, Me.MODEL09ASM04DataGridViewTextBoxColumn, Me.MODEL09ASM05DataGridViewTextBoxColumn, Me.MODEL10ASM01DataGridViewTextBoxColumn, Me.MODEL10ASM02DataGridViewTextBoxColumn, Me.MODEL10ASM03DataGridViewTextBoxColumn, Me.MODEL10ASM04DataGridViewTextBoxColumn, Me.MODEL10ASM05DataGridViewTextBoxColumn, Me.MODEL11ASM01DataGridViewTextBoxColumn, Me.MODEL11ASM02DataGridViewTextBoxColumn, Me.MODEL11ASM03DataGridViewTextBoxColumn, Me.MODEL11ASM04DataGridViewTextBoxColumn, Me.MODEL11ASM05DataGridViewTextBoxColumn, Me.MODEL12ASM01DataGridViewTextBoxColumn, Me.MODEL12ASM02DataGridViewTextBoxColumn, Me.MODEL12ASM03DataGridViewTextBoxColumn, Me.MODEL12ASM04DataGridViewTextBoxColumn, Me.MODEL12ASM05DataGridViewTextBoxColumn, Me.MODEL13ASM01DataGridViewTextBoxColumn, Me.MODEL13ASM02DataGridViewTextBoxColumn, Me.MODEL13ASM03DataGridViewTextBoxColumn, Me.MODEL13ASM04DataGridViewTextBoxColumn, Me.MODEL13ASM05DataGridViewTextBoxColumn, Me.MODEL14ASM01DataGridViewTextBoxColumn, Me.MODEL14ASM02DataGridViewTextBoxColumn, Me.MODEL14ASM03DataGridViewTextBoxColumn, Me.MODEL14ASM04DataGridViewTextBoxColumn, Me.MODEL14ASM05DataGridViewTextBoxColumn, Me.MODEL15ASM01DataGridViewTextBoxColumn, Me.MODEL15ASM02DataGridViewTextBoxColumn, Me.MODEL15ASM03DataGridViewTextBoxColumn, Me.MODEL15ASM04DataGridViewTextBoxColumn, Me.MODEL15ASM05DataGridViewTextBoxColumn, Me.MODEL16ASM01DataGridViewTextBoxColumn, Me.MODEL16ASM02DataGridViewTextBoxColumn, Me.MODEL16ASM03DataGridViewTextBoxColumn, Me.MODEL16ASM04DataGridViewTextBoxColumn, Me.MODEL16ASM05DataGridViewTextBoxColumn, Me.MODEL17ASM01DataGridViewTextBoxColumn, Me.MODEL17ASM02DataGridViewTextBoxColumn, Me.MODEL17ASM03DataGridViewTextBoxColumn, Me.MODEL17ASM04DataGridViewTextBoxColumn, Me.MODEL17ASM05DataGridViewTextBoxColumn, Me.MODEL18ASM01DataGridViewTextBoxColumn, Me.MODEL18ASM02DataGridViewTextBoxColumn, Me.MODEL18ASM03DataGridViewTextBoxColumn, Me.MODEL18ASM04DataGridViewTextBoxColumn, Me.MODEL18ASM05DataGridViewTextBoxColumn, Me.MODEL19ASM01DataGridViewTextBoxColumn, Me.MODEL19ASM02DataGridViewTextBoxColumn, Me.MODEL19ASM03DataGridViewTextBoxColumn, Me.MODEL19ASM04DataGridViewTextBoxColumn, Me.MODEL19ASM05DataGridViewTextBoxColumn, Me.MODEL20ASM01DataGridViewTextBoxColumn, Me.MODEL20ASM02DataGridViewTextBoxColumn, Me.MODEL20ASM03DataGridViewTextBoxColumn, Me.MODEL20ASM04DataGridViewTextBoxColumn, Me.MODEL20ASM05DataGridViewTextBoxColumn, Me.Reserve01DataGridViewTextBoxColumn, Me.Reserve02DataGridViewTextBoxColumn, Me.XchgFlagDataGridViewTextBoxColumn, Me.InstructFlagDataGridViewTextBoxColumn, Me.FileNameDataGridViewTextBoxColumn})
        Me.DataGridInsertData.DataSource = Me.TProductionDATBindingSource
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridInsertData.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridInsertData.Location = New System.Drawing.Point(12, 144)
        Me.DataGridInsertData.MultiSelect = False
        Me.DataGridInsertData.Name = "DataGridInsertData"
        Me.DataGridInsertData.ReadOnly = True
        Me.DataGridInsertData.RowHeadersVisible = False
        Me.DataGridInsertData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridInsertData.Size = New System.Drawing.Size(979, 468)
        Me.DataGridInsertData.TabIndex = 8
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(817, 639)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(151, 35)
        Me.btnCancel.TabIndex = 15
        Me.btnCancel.Text = "F12:CANCEL"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Enabled = False
        Me.btnOk.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnOk.Location = New System.Drawing.Point(477, 639)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(151, 35)
        Me.btnOk.TabIndex = 14
        Me.btnOk.Text = "F1:OK"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Enabled = False
        Me.btnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(648, 639)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(151, 35)
        Me.btnDelete.TabIndex = 13
        Me.btnDelete.Text = "F3:DELETE"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'lblValue
        '
        Me.lblValue.AutoSize = True
        Me.lblValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblValue.Location = New System.Drawing.Point(201, 97)
        Me.lblValue.Name = "lblValue"
        Me.lblValue.Size = New System.Drawing.Size(12, 17)
        Me.lblValue.TabIndex = 16
        Me.lblValue.Text = " "
        '
        'lblLabel2
        '
        Me.lblLabel2.AutoSize = True
        Me.lblLabel2.Location = New System.Drawing.Point(324, 97)
        Me.lblLabel2.Name = "lblLabel2"
        Me.lblLabel2.Size = New System.Drawing.Size(42, 13)
        Me.lblLabel2.TabIndex = 17
        Me.lblLabel2.Text = "Lot No."
        '
        'lblValue2
        '
        Me.lblValue2.AutoSize = True
        Me.lblValue2.Location = New System.Drawing.Point(385, 97)
        Me.lblValue2.Name = "lblValue2"
        Me.lblValue2.Size = New System.Drawing.Size(0, 13)
        Me.lblValue2.TabIndex = 19
        '
        'TProductionDATBindingSource
        '
        Me.TProductionDATBindingSource.DataMember = "T_Production_DAT"
        Me.TProductionDATBindingSource.DataSource = Me.DataSet1
        '
        'DataSet1
        '
        Me.DataSet1.DataSetName = "DataSet1"
        Me.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'T_Production_DATTableAdapter
        '
        Me.T_Production_DATTableAdapter.ClearBeforeFill = True
        '
        'IndexNoDataGridViewTextBoxColumn
        '
        Me.IndexNoDataGridViewTextBoxColumn.DataPropertyName = "indexNo"
        Me.IndexNoDataGridViewTextBoxColumn.HeaderText = "     "
        Me.IndexNoDataGridViewTextBoxColumn.Name = "IndexNoDataGridViewTextBoxColumn"
        Me.IndexNoDataGridViewTextBoxColumn.ReadOnly = True
        Me.IndexNoDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'SeqNoDataGridViewTextBoxColumn
        '
        Me.SeqNoDataGridViewTextBoxColumn.DataPropertyName = "SeqNo"
        Me.SeqNoDataGridViewTextBoxColumn.HeaderText = "SeqNo"
        Me.SeqNoDataGridViewTextBoxColumn.Name = "SeqNoDataGridViewTextBoxColumn"
        Me.SeqNoDataGridViewTextBoxColumn.ReadOnly = True
        Me.SeqNoDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'SubSeqDataGridViewTextBoxColumn
        '
        Me.SubSeqDataGridViewTextBoxColumn.DataPropertyName = "SubSeq"
        Me.SubSeqDataGridViewTextBoxColumn.HeaderText = "SubSeq"
        Me.SubSeqDataGridViewTextBoxColumn.Name = "SubSeqDataGridViewTextBoxColumn"
        Me.SubSeqDataGridViewTextBoxColumn.ReadOnly = True
        Me.SubSeqDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'SEQDESCDataGridViewTextBoxColumn
        '
        Me.SEQDESCDataGridViewTextBoxColumn.DataPropertyName = "SEQ_DESC"
        Me.SEQDESCDataGridViewTextBoxColumn.HeaderText = "SEQ_DESC"
        Me.SEQDESCDataGridViewTextBoxColumn.Name = "SEQDESCDataGridViewTextBoxColumn"
        Me.SEQDESCDataGridViewTextBoxColumn.ReadOnly = True
        Me.SEQDESCDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.SEQDESCDataGridViewTextBoxColumn.Visible = False
        '
        'ModelYearDataGridViewTextBoxColumn
        '
        Me.ModelYearDataGridViewTextBoxColumn.DataPropertyName = "ModelYear"
        Me.ModelYearDataGridViewTextBoxColumn.HeaderText = "ModelYear"
        Me.ModelYearDataGridViewTextBoxColumn.Name = "ModelYearDataGridViewTextBoxColumn"
        Me.ModelYearDataGridViewTextBoxColumn.ReadOnly = True
        Me.ModelYearDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'SuffixCodeDataGridViewTextBoxColumn
        '
        Me.SuffixCodeDataGridViewTextBoxColumn.DataPropertyName = "SuffixCode"
        Me.SuffixCodeDataGridViewTextBoxColumn.HeaderText = "SuffixCode"
        Me.SuffixCodeDataGridViewTextBoxColumn.Name = "SuffixCodeDataGridViewTextBoxColumn"
        Me.SuffixCodeDataGridViewTextBoxColumn.ReadOnly = True
        Me.SuffixCodeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'LotIDDataGridViewTextBoxColumn
        '
        Me.LotIDDataGridViewTextBoxColumn.DataPropertyName = "LotID"
        Me.LotIDDataGridViewTextBoxColumn.HeaderText = "LotID"
        Me.LotIDDataGridViewTextBoxColumn.Name = "LotIDDataGridViewTextBoxColumn"
        Me.LotIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.LotIDDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'LotNoDataGridViewTextBoxColumn
        '
        Me.LotNoDataGridViewTextBoxColumn.DataPropertyName = "LotNo"
        Me.LotNoDataGridViewTextBoxColumn.HeaderText = "LotNo"
        Me.LotNoDataGridViewTextBoxColumn.Name = "LotNoDataGridViewTextBoxColumn"
        Me.LotNoDataGridViewTextBoxColumn.ReadOnly = True
        Me.LotNoDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'UnitDataGridViewTextBoxColumn
        '
        Me.UnitDataGridViewTextBoxColumn.DataPropertyName = "Unit"
        Me.UnitDataGridViewTextBoxColumn.HeaderText = "Unit"
        Me.UnitDataGridViewTextBoxColumn.Name = "UnitDataGridViewTextBoxColumn"
        Me.UnitDataGridViewTextBoxColumn.ReadOnly = True
        Me.UnitDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'BlockModelDataGridViewTextBoxColumn
        '
        Me.BlockModelDataGridViewTextBoxColumn.DataPropertyName = "BlockModel"
        Me.BlockModelDataGridViewTextBoxColumn.HeaderText = "BlockModel"
        Me.BlockModelDataGridViewTextBoxColumn.Name = "BlockModelDataGridViewTextBoxColumn"
        Me.BlockModelDataGridViewTextBoxColumn.ReadOnly = True
        Me.BlockModelDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'BlockSeqDataGridViewTextBoxColumn
        '
        Me.BlockSeqDataGridViewTextBoxColumn.DataPropertyName = "BlockSeq"
        Me.BlockSeqDataGridViewTextBoxColumn.HeaderText = "BlockSeq"
        Me.BlockSeqDataGridViewTextBoxColumn.Name = "BlockSeqDataGridViewTextBoxColumn"
        Me.BlockSeqDataGridViewTextBoxColumn.ReadOnly = True
        Me.BlockSeqDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MARKDataGridViewTextBoxColumn
        '
        Me.MARKDataGridViewTextBoxColumn.DataPropertyName = "MARK"
        Me.MARKDataGridViewTextBoxColumn.HeaderText = "MARK"
        Me.MARKDataGridViewTextBoxColumn.Name = "MARKDataGridViewTextBoxColumn"
        Me.MARKDataGridViewTextBoxColumn.ReadOnly = True
        Me.MARKDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ProductionDateDataGridViewTextBoxColumn
        '
        Me.ProductionDateDataGridViewTextBoxColumn.DataPropertyName = "ProductionDate"
        Me.ProductionDateDataGridViewTextBoxColumn.HeaderText = "ProductionDate"
        Me.ProductionDateDataGridViewTextBoxColumn.Name = "ProductionDateDataGridViewTextBoxColumn"
        Me.ProductionDateDataGridViewTextBoxColumn.ReadOnly = True
        Me.ProductionDateDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ProductionTimeDataGridViewTextBoxColumn
        '
        Me.ProductionTimeDataGridViewTextBoxColumn.DataPropertyName = "ProductionTime"
        Me.ProductionTimeDataGridViewTextBoxColumn.HeaderText = "ProductionTime"
        Me.ProductionTimeDataGridViewTextBoxColumn.Name = "ProductionTimeDataGridViewTextBoxColumn"
        Me.ProductionTimeDataGridViewTextBoxColumn.ReadOnly = True
        Me.ProductionTimeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ImportCodeDataGridViewTextBoxColumn
        '
        Me.ImportCodeDataGridViewTextBoxColumn.DataPropertyName = "ImportCode"
        Me.ImportCodeDataGridViewTextBoxColumn.HeaderText = "ImportCode"
        Me.ImportCodeDataGridViewTextBoxColumn.Name = "ImportCodeDataGridViewTextBoxColumn"
        Me.ImportCodeDataGridViewTextBoxColumn.ReadOnly = True
        Me.ImportCodeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'YChassisFlagDataGridViewTextBoxColumn
        '
        Me.YChassisFlagDataGridViewTextBoxColumn.DataPropertyName = "YChassisFlag"
        Me.YChassisFlagDataGridViewTextBoxColumn.HeaderText = "YChassisFlag"
        Me.YChassisFlagDataGridViewTextBoxColumn.Name = "YChassisFlagDataGridViewTextBoxColumn"
        Me.YChassisFlagDataGridViewTextBoxColumn.ReadOnly = True
        Me.YChassisFlagDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GAShopDataGridViewTextBoxColumn
        '
        Me.GAShopDataGridViewTextBoxColumn.DataPropertyName = "GAShop"
        Me.GAShopDataGridViewTextBoxColumn.HeaderText = "GAShop"
        Me.GAShopDataGridViewTextBoxColumn.Name = "GAShopDataGridViewTextBoxColumn"
        Me.GAShopDataGridViewTextBoxColumn.ReadOnly = True
        Me.GAShopDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'HanmmerYearsDataGridViewTextBoxColumn
        '
        Me.HanmmerYearsDataGridViewTextBoxColumn.DataPropertyName = "HanmmerYears"
        Me.HanmmerYearsDataGridViewTextBoxColumn.HeaderText = "HanmmerYears"
        Me.HanmmerYearsDataGridViewTextBoxColumn.Name = "HanmmerYearsDataGridViewTextBoxColumn"
        Me.HanmmerYearsDataGridViewTextBoxColumn.ReadOnly = True
        Me.HanmmerYearsDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL01ASM01DataGridViewTextBoxColumn
        '
        Me.MODEL01ASM01DataGridViewTextBoxColumn.DataPropertyName = "MODEL01ASM01"
        Me.MODEL01ASM01DataGridViewTextBoxColumn.HeaderText = "MODEL01ASM01"
        Me.MODEL01ASM01DataGridViewTextBoxColumn.Name = "MODEL01ASM01DataGridViewTextBoxColumn"
        Me.MODEL01ASM01DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL01ASM01DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL01ASM02DataGridViewTextBoxColumn
        '
        Me.MODEL01ASM02DataGridViewTextBoxColumn.DataPropertyName = "MODEL01ASM02"
        Me.MODEL01ASM02DataGridViewTextBoxColumn.HeaderText = "MODEL01ASM02"
        Me.MODEL01ASM02DataGridViewTextBoxColumn.Name = "MODEL01ASM02DataGridViewTextBoxColumn"
        Me.MODEL01ASM02DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL01ASM02DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL01ASM03DataGridViewTextBoxColumn
        '
        Me.MODEL01ASM03DataGridViewTextBoxColumn.DataPropertyName = "MODEL01ASM03"
        Me.MODEL01ASM03DataGridViewTextBoxColumn.HeaderText = "MODEL01ASM03"
        Me.MODEL01ASM03DataGridViewTextBoxColumn.Name = "MODEL01ASM03DataGridViewTextBoxColumn"
        Me.MODEL01ASM03DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL01ASM03DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL01ASM04DataGridViewTextBoxColumn
        '
        Me.MODEL01ASM04DataGridViewTextBoxColumn.DataPropertyName = "MODEL01ASM04"
        Me.MODEL01ASM04DataGridViewTextBoxColumn.HeaderText = "MODEL01ASM04"
        Me.MODEL01ASM04DataGridViewTextBoxColumn.Name = "MODEL01ASM04DataGridViewTextBoxColumn"
        Me.MODEL01ASM04DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL01ASM04DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL01ASM05DataGridViewTextBoxColumn
        '
        Me.MODEL01ASM05DataGridViewTextBoxColumn.DataPropertyName = "MODEL01ASM05"
        Me.MODEL01ASM05DataGridViewTextBoxColumn.HeaderText = "MODEL01ASM05"
        Me.MODEL01ASM05DataGridViewTextBoxColumn.Name = "MODEL01ASM05DataGridViewTextBoxColumn"
        Me.MODEL01ASM05DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL01ASM05DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL02ASM01DataGridViewTextBoxColumn
        '
        Me.MODEL02ASM01DataGridViewTextBoxColumn.DataPropertyName = "MODEL02ASM01"
        Me.MODEL02ASM01DataGridViewTextBoxColumn.HeaderText = "MODEL02ASM01"
        Me.MODEL02ASM01DataGridViewTextBoxColumn.Name = "MODEL02ASM01DataGridViewTextBoxColumn"
        Me.MODEL02ASM01DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL02ASM01DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL02ASM02DataGridViewTextBoxColumn
        '
        Me.MODEL02ASM02DataGridViewTextBoxColumn.DataPropertyName = "MODEL02ASM02"
        Me.MODEL02ASM02DataGridViewTextBoxColumn.HeaderText = "MODEL02ASM02"
        Me.MODEL02ASM02DataGridViewTextBoxColumn.Name = "MODEL02ASM02DataGridViewTextBoxColumn"
        Me.MODEL02ASM02DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL02ASM02DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL02ASM03DataGridViewTextBoxColumn
        '
        Me.MODEL02ASM03DataGridViewTextBoxColumn.DataPropertyName = "MODEL02ASM03"
        Me.MODEL02ASM03DataGridViewTextBoxColumn.HeaderText = "MODEL02ASM03"
        Me.MODEL02ASM03DataGridViewTextBoxColumn.Name = "MODEL02ASM03DataGridViewTextBoxColumn"
        Me.MODEL02ASM03DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL02ASM03DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL02ASM04DataGridViewTextBoxColumn
        '
        Me.MODEL02ASM04DataGridViewTextBoxColumn.DataPropertyName = "MODEL02ASM04"
        Me.MODEL02ASM04DataGridViewTextBoxColumn.HeaderText = "MODEL02ASM04"
        Me.MODEL02ASM04DataGridViewTextBoxColumn.Name = "MODEL02ASM04DataGridViewTextBoxColumn"
        Me.MODEL02ASM04DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL02ASM04DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL02ASM05DataGridViewTextBoxColumn
        '
        Me.MODEL02ASM05DataGridViewTextBoxColumn.DataPropertyName = "MODEL02ASM05"
        Me.MODEL02ASM05DataGridViewTextBoxColumn.HeaderText = "MODEL02ASM05"
        Me.MODEL02ASM05DataGridViewTextBoxColumn.Name = "MODEL02ASM05DataGridViewTextBoxColumn"
        Me.MODEL02ASM05DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL02ASM05DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL03ASM01DataGridViewTextBoxColumn
        '
        Me.MODEL03ASM01DataGridViewTextBoxColumn.DataPropertyName = "MODEL03ASM01"
        Me.MODEL03ASM01DataGridViewTextBoxColumn.HeaderText = "MODEL03ASM01"
        Me.MODEL03ASM01DataGridViewTextBoxColumn.Name = "MODEL03ASM01DataGridViewTextBoxColumn"
        Me.MODEL03ASM01DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL03ASM01DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL03ASM02DataGridViewTextBoxColumn
        '
        Me.MODEL03ASM02DataGridViewTextBoxColumn.DataPropertyName = "MODEL03ASM02"
        Me.MODEL03ASM02DataGridViewTextBoxColumn.HeaderText = "MODEL03ASM02"
        Me.MODEL03ASM02DataGridViewTextBoxColumn.Name = "MODEL03ASM02DataGridViewTextBoxColumn"
        Me.MODEL03ASM02DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL03ASM02DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL03ASM03DataGridViewTextBoxColumn
        '
        Me.MODEL03ASM03DataGridViewTextBoxColumn.DataPropertyName = "MODEL03ASM03"
        Me.MODEL03ASM03DataGridViewTextBoxColumn.HeaderText = "MODEL03ASM03"
        Me.MODEL03ASM03DataGridViewTextBoxColumn.Name = "MODEL03ASM03DataGridViewTextBoxColumn"
        Me.MODEL03ASM03DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL03ASM03DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL03ASM04DataGridViewTextBoxColumn
        '
        Me.MODEL03ASM04DataGridViewTextBoxColumn.DataPropertyName = "MODEL03ASM04"
        Me.MODEL03ASM04DataGridViewTextBoxColumn.HeaderText = "MODEL03ASM04"
        Me.MODEL03ASM04DataGridViewTextBoxColumn.Name = "MODEL03ASM04DataGridViewTextBoxColumn"
        Me.MODEL03ASM04DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL03ASM04DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL03ASM05DataGridViewTextBoxColumn
        '
        Me.MODEL03ASM05DataGridViewTextBoxColumn.DataPropertyName = "MODEL03ASM05"
        Me.MODEL03ASM05DataGridViewTextBoxColumn.HeaderText = "MODEL03ASM05"
        Me.MODEL03ASM05DataGridViewTextBoxColumn.Name = "MODEL03ASM05DataGridViewTextBoxColumn"
        Me.MODEL03ASM05DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL03ASM05DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL04ASM01DataGridViewTextBoxColumn
        '
        Me.MODEL04ASM01DataGridViewTextBoxColumn.DataPropertyName = "MODEL04ASM01"
        Me.MODEL04ASM01DataGridViewTextBoxColumn.HeaderText = "MODEL04ASM01"
        Me.MODEL04ASM01DataGridViewTextBoxColumn.Name = "MODEL04ASM01DataGridViewTextBoxColumn"
        Me.MODEL04ASM01DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL04ASM01DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL04ASM02DataGridViewTextBoxColumn
        '
        Me.MODEL04ASM02DataGridViewTextBoxColumn.DataPropertyName = "MODEL04ASM02"
        Me.MODEL04ASM02DataGridViewTextBoxColumn.HeaderText = "MODEL04ASM02"
        Me.MODEL04ASM02DataGridViewTextBoxColumn.Name = "MODEL04ASM02DataGridViewTextBoxColumn"
        Me.MODEL04ASM02DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL04ASM02DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL04ASM03DataGridViewTextBoxColumn
        '
        Me.MODEL04ASM03DataGridViewTextBoxColumn.DataPropertyName = "MODEL04ASM03"
        Me.MODEL04ASM03DataGridViewTextBoxColumn.HeaderText = "MODEL04ASM03"
        Me.MODEL04ASM03DataGridViewTextBoxColumn.Name = "MODEL04ASM03DataGridViewTextBoxColumn"
        Me.MODEL04ASM03DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL04ASM03DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL04ASM04DataGridViewTextBoxColumn
        '
        Me.MODEL04ASM04DataGridViewTextBoxColumn.DataPropertyName = "MODEL04ASM04"
        Me.MODEL04ASM04DataGridViewTextBoxColumn.HeaderText = "MODEL04ASM04"
        Me.MODEL04ASM04DataGridViewTextBoxColumn.Name = "MODEL04ASM04DataGridViewTextBoxColumn"
        Me.MODEL04ASM04DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL04ASM04DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL04ASM05DataGridViewTextBoxColumn
        '
        Me.MODEL04ASM05DataGridViewTextBoxColumn.DataPropertyName = "MODEL04ASM05"
        Me.MODEL04ASM05DataGridViewTextBoxColumn.HeaderText = "MODEL04ASM05"
        Me.MODEL04ASM05DataGridViewTextBoxColumn.Name = "MODEL04ASM05DataGridViewTextBoxColumn"
        Me.MODEL04ASM05DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL04ASM05DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL05ASM01DataGridViewTextBoxColumn
        '
        Me.MODEL05ASM01DataGridViewTextBoxColumn.DataPropertyName = "MODEL05ASM01"
        Me.MODEL05ASM01DataGridViewTextBoxColumn.HeaderText = "MODEL05ASM01"
        Me.MODEL05ASM01DataGridViewTextBoxColumn.Name = "MODEL05ASM01DataGridViewTextBoxColumn"
        Me.MODEL05ASM01DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL05ASM01DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL05ASM02DataGridViewTextBoxColumn
        '
        Me.MODEL05ASM02DataGridViewTextBoxColumn.DataPropertyName = "MODEL05ASM02"
        Me.MODEL05ASM02DataGridViewTextBoxColumn.HeaderText = "MODEL05ASM02"
        Me.MODEL05ASM02DataGridViewTextBoxColumn.Name = "MODEL05ASM02DataGridViewTextBoxColumn"
        Me.MODEL05ASM02DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL05ASM02DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL05ASM03DataGridViewTextBoxColumn
        '
        Me.MODEL05ASM03DataGridViewTextBoxColumn.DataPropertyName = "MODEL05ASM03"
        Me.MODEL05ASM03DataGridViewTextBoxColumn.HeaderText = "MODEL05ASM03"
        Me.MODEL05ASM03DataGridViewTextBoxColumn.Name = "MODEL05ASM03DataGridViewTextBoxColumn"
        Me.MODEL05ASM03DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL05ASM03DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL05ASM04DataGridViewTextBoxColumn
        '
        Me.MODEL05ASM04DataGridViewTextBoxColumn.DataPropertyName = "MODEL05ASM04"
        Me.MODEL05ASM04DataGridViewTextBoxColumn.HeaderText = "MODEL05ASM04"
        Me.MODEL05ASM04DataGridViewTextBoxColumn.Name = "MODEL05ASM04DataGridViewTextBoxColumn"
        Me.MODEL05ASM04DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL05ASM04DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL05ASM05DataGridViewTextBoxColumn
        '
        Me.MODEL05ASM05DataGridViewTextBoxColumn.DataPropertyName = "MODEL05ASM05"
        Me.MODEL05ASM05DataGridViewTextBoxColumn.HeaderText = "MODEL05ASM05"
        Me.MODEL05ASM05DataGridViewTextBoxColumn.Name = "MODEL05ASM05DataGridViewTextBoxColumn"
        Me.MODEL05ASM05DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL05ASM05DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL06ASM01DataGridViewTextBoxColumn
        '
        Me.MODEL06ASM01DataGridViewTextBoxColumn.DataPropertyName = "MODEL06ASM01"
        Me.MODEL06ASM01DataGridViewTextBoxColumn.HeaderText = "MODEL06ASM01"
        Me.MODEL06ASM01DataGridViewTextBoxColumn.Name = "MODEL06ASM01DataGridViewTextBoxColumn"
        Me.MODEL06ASM01DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL06ASM01DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL06ASM02DataGridViewTextBoxColumn
        '
        Me.MODEL06ASM02DataGridViewTextBoxColumn.DataPropertyName = "MODEL06ASM02"
        Me.MODEL06ASM02DataGridViewTextBoxColumn.HeaderText = "MODEL06ASM02"
        Me.MODEL06ASM02DataGridViewTextBoxColumn.Name = "MODEL06ASM02DataGridViewTextBoxColumn"
        Me.MODEL06ASM02DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL06ASM02DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL06ASM03DataGridViewTextBoxColumn
        '
        Me.MODEL06ASM03DataGridViewTextBoxColumn.DataPropertyName = "MODEL06ASM03"
        Me.MODEL06ASM03DataGridViewTextBoxColumn.HeaderText = "MODEL06ASM03"
        Me.MODEL06ASM03DataGridViewTextBoxColumn.Name = "MODEL06ASM03DataGridViewTextBoxColumn"
        Me.MODEL06ASM03DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL06ASM03DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL06ASM04DataGridViewTextBoxColumn
        '
        Me.MODEL06ASM04DataGridViewTextBoxColumn.DataPropertyName = "MODEL06ASM04"
        Me.MODEL06ASM04DataGridViewTextBoxColumn.HeaderText = "MODEL06ASM04"
        Me.MODEL06ASM04DataGridViewTextBoxColumn.Name = "MODEL06ASM04DataGridViewTextBoxColumn"
        Me.MODEL06ASM04DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL06ASM04DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL06ASM05DataGridViewTextBoxColumn
        '
        Me.MODEL06ASM05DataGridViewTextBoxColumn.DataPropertyName = "MODEL06ASM05"
        Me.MODEL06ASM05DataGridViewTextBoxColumn.HeaderText = "MODEL06ASM05"
        Me.MODEL06ASM05DataGridViewTextBoxColumn.Name = "MODEL06ASM05DataGridViewTextBoxColumn"
        Me.MODEL06ASM05DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL06ASM05DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL07ASM01DataGridViewTextBoxColumn
        '
        Me.MODEL07ASM01DataGridViewTextBoxColumn.DataPropertyName = "MODEL07ASM01"
        Me.MODEL07ASM01DataGridViewTextBoxColumn.HeaderText = "MODEL07ASM01"
        Me.MODEL07ASM01DataGridViewTextBoxColumn.Name = "MODEL07ASM01DataGridViewTextBoxColumn"
        Me.MODEL07ASM01DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL07ASM01DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL07ASM02DataGridViewTextBoxColumn
        '
        Me.MODEL07ASM02DataGridViewTextBoxColumn.DataPropertyName = "MODEL07ASM02"
        Me.MODEL07ASM02DataGridViewTextBoxColumn.HeaderText = "MODEL07ASM02"
        Me.MODEL07ASM02DataGridViewTextBoxColumn.Name = "MODEL07ASM02DataGridViewTextBoxColumn"
        Me.MODEL07ASM02DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL07ASM02DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL07ASM03DataGridViewTextBoxColumn
        '
        Me.MODEL07ASM03DataGridViewTextBoxColumn.DataPropertyName = "MODEL07ASM03"
        Me.MODEL07ASM03DataGridViewTextBoxColumn.HeaderText = "MODEL07ASM03"
        Me.MODEL07ASM03DataGridViewTextBoxColumn.Name = "MODEL07ASM03DataGridViewTextBoxColumn"
        Me.MODEL07ASM03DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL07ASM03DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL07ASM04DataGridViewTextBoxColumn
        '
        Me.MODEL07ASM04DataGridViewTextBoxColumn.DataPropertyName = "MODEL07ASM04"
        Me.MODEL07ASM04DataGridViewTextBoxColumn.HeaderText = "MODEL07ASM04"
        Me.MODEL07ASM04DataGridViewTextBoxColumn.Name = "MODEL07ASM04DataGridViewTextBoxColumn"
        Me.MODEL07ASM04DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL07ASM04DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL07ASM05DataGridViewTextBoxColumn
        '
        Me.MODEL07ASM05DataGridViewTextBoxColumn.DataPropertyName = "MODEL07ASM05"
        Me.MODEL07ASM05DataGridViewTextBoxColumn.HeaderText = "MODEL07ASM05"
        Me.MODEL07ASM05DataGridViewTextBoxColumn.Name = "MODEL07ASM05DataGridViewTextBoxColumn"
        Me.MODEL07ASM05DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL07ASM05DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL08ASM01DataGridViewTextBoxColumn
        '
        Me.MODEL08ASM01DataGridViewTextBoxColumn.DataPropertyName = "MODEL08ASM01"
        Me.MODEL08ASM01DataGridViewTextBoxColumn.HeaderText = "MODEL08ASM01"
        Me.MODEL08ASM01DataGridViewTextBoxColumn.Name = "MODEL08ASM01DataGridViewTextBoxColumn"
        Me.MODEL08ASM01DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL08ASM01DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL08ASM02DataGridViewTextBoxColumn
        '
        Me.MODEL08ASM02DataGridViewTextBoxColumn.DataPropertyName = "MODEL08ASM02"
        Me.MODEL08ASM02DataGridViewTextBoxColumn.HeaderText = "MODEL08ASM02"
        Me.MODEL08ASM02DataGridViewTextBoxColumn.Name = "MODEL08ASM02DataGridViewTextBoxColumn"
        Me.MODEL08ASM02DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL08ASM02DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL08ASM03DataGridViewTextBoxColumn
        '
        Me.MODEL08ASM03DataGridViewTextBoxColumn.DataPropertyName = "MODEL08ASM03"
        Me.MODEL08ASM03DataGridViewTextBoxColumn.HeaderText = "MODEL08ASM03"
        Me.MODEL08ASM03DataGridViewTextBoxColumn.Name = "MODEL08ASM03DataGridViewTextBoxColumn"
        Me.MODEL08ASM03DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL08ASM03DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL08ASM04DataGridViewTextBoxColumn
        '
        Me.MODEL08ASM04DataGridViewTextBoxColumn.DataPropertyName = "MODEL08ASM04"
        Me.MODEL08ASM04DataGridViewTextBoxColumn.HeaderText = "MODEL08ASM04"
        Me.MODEL08ASM04DataGridViewTextBoxColumn.Name = "MODEL08ASM04DataGridViewTextBoxColumn"
        Me.MODEL08ASM04DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL08ASM04DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL08ASM05DataGridViewTextBoxColumn
        '
        Me.MODEL08ASM05DataGridViewTextBoxColumn.DataPropertyName = "MODEL08ASM05"
        Me.MODEL08ASM05DataGridViewTextBoxColumn.HeaderText = "MODEL08ASM05"
        Me.MODEL08ASM05DataGridViewTextBoxColumn.Name = "MODEL08ASM05DataGridViewTextBoxColumn"
        Me.MODEL08ASM05DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL08ASM05DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL09ASM01DataGridViewTextBoxColumn
        '
        Me.MODEL09ASM01DataGridViewTextBoxColumn.DataPropertyName = "MODEL09ASM01"
        Me.MODEL09ASM01DataGridViewTextBoxColumn.HeaderText = "MODEL09ASM01"
        Me.MODEL09ASM01DataGridViewTextBoxColumn.Name = "MODEL09ASM01DataGridViewTextBoxColumn"
        Me.MODEL09ASM01DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL09ASM01DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL09ASM02DataGridViewTextBoxColumn
        '
        Me.MODEL09ASM02DataGridViewTextBoxColumn.DataPropertyName = "MODEL09ASM02"
        Me.MODEL09ASM02DataGridViewTextBoxColumn.HeaderText = "MODEL09ASM02"
        Me.MODEL09ASM02DataGridViewTextBoxColumn.Name = "MODEL09ASM02DataGridViewTextBoxColumn"
        Me.MODEL09ASM02DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL09ASM02DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL09ASM03DataGridViewTextBoxColumn
        '
        Me.MODEL09ASM03DataGridViewTextBoxColumn.DataPropertyName = "MODEL09ASM03"
        Me.MODEL09ASM03DataGridViewTextBoxColumn.HeaderText = "MODEL09ASM03"
        Me.MODEL09ASM03DataGridViewTextBoxColumn.Name = "MODEL09ASM03DataGridViewTextBoxColumn"
        Me.MODEL09ASM03DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL09ASM03DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL09ASM04DataGridViewTextBoxColumn
        '
        Me.MODEL09ASM04DataGridViewTextBoxColumn.DataPropertyName = "MODEL09ASM04"
        Me.MODEL09ASM04DataGridViewTextBoxColumn.HeaderText = "MODEL09ASM04"
        Me.MODEL09ASM04DataGridViewTextBoxColumn.Name = "MODEL09ASM04DataGridViewTextBoxColumn"
        Me.MODEL09ASM04DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL09ASM04DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL09ASM05DataGridViewTextBoxColumn
        '
        Me.MODEL09ASM05DataGridViewTextBoxColumn.DataPropertyName = "MODEL09ASM05"
        Me.MODEL09ASM05DataGridViewTextBoxColumn.HeaderText = "MODEL09ASM05"
        Me.MODEL09ASM05DataGridViewTextBoxColumn.Name = "MODEL09ASM05DataGridViewTextBoxColumn"
        Me.MODEL09ASM05DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL09ASM05DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL10ASM01DataGridViewTextBoxColumn
        '
        Me.MODEL10ASM01DataGridViewTextBoxColumn.DataPropertyName = "MODEL10ASM01"
        Me.MODEL10ASM01DataGridViewTextBoxColumn.HeaderText = "MODEL10ASM01"
        Me.MODEL10ASM01DataGridViewTextBoxColumn.Name = "MODEL10ASM01DataGridViewTextBoxColumn"
        Me.MODEL10ASM01DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL10ASM01DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL10ASM02DataGridViewTextBoxColumn
        '
        Me.MODEL10ASM02DataGridViewTextBoxColumn.DataPropertyName = "MODEL10ASM02"
        Me.MODEL10ASM02DataGridViewTextBoxColumn.HeaderText = "MODEL10ASM02"
        Me.MODEL10ASM02DataGridViewTextBoxColumn.Name = "MODEL10ASM02DataGridViewTextBoxColumn"
        Me.MODEL10ASM02DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL10ASM02DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL10ASM03DataGridViewTextBoxColumn
        '
        Me.MODEL10ASM03DataGridViewTextBoxColumn.DataPropertyName = "MODEL10ASM03"
        Me.MODEL10ASM03DataGridViewTextBoxColumn.HeaderText = "MODEL10ASM03"
        Me.MODEL10ASM03DataGridViewTextBoxColumn.Name = "MODEL10ASM03DataGridViewTextBoxColumn"
        Me.MODEL10ASM03DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL10ASM03DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL10ASM04DataGridViewTextBoxColumn
        '
        Me.MODEL10ASM04DataGridViewTextBoxColumn.DataPropertyName = "MODEL10ASM04"
        Me.MODEL10ASM04DataGridViewTextBoxColumn.HeaderText = "MODEL10ASM04"
        Me.MODEL10ASM04DataGridViewTextBoxColumn.Name = "MODEL10ASM04DataGridViewTextBoxColumn"
        Me.MODEL10ASM04DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL10ASM04DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL10ASM05DataGridViewTextBoxColumn
        '
        Me.MODEL10ASM05DataGridViewTextBoxColumn.DataPropertyName = "MODEL10ASM05"
        Me.MODEL10ASM05DataGridViewTextBoxColumn.HeaderText = "MODEL10ASM05"
        Me.MODEL10ASM05DataGridViewTextBoxColumn.Name = "MODEL10ASM05DataGridViewTextBoxColumn"
        Me.MODEL10ASM05DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL10ASM05DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL11ASM01DataGridViewTextBoxColumn
        '
        Me.MODEL11ASM01DataGridViewTextBoxColumn.DataPropertyName = "MODEL11ASM01"
        Me.MODEL11ASM01DataGridViewTextBoxColumn.HeaderText = "MODEL11ASM01"
        Me.MODEL11ASM01DataGridViewTextBoxColumn.Name = "MODEL11ASM01DataGridViewTextBoxColumn"
        Me.MODEL11ASM01DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL11ASM01DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL11ASM02DataGridViewTextBoxColumn
        '
        Me.MODEL11ASM02DataGridViewTextBoxColumn.DataPropertyName = "MODEL11ASM02"
        Me.MODEL11ASM02DataGridViewTextBoxColumn.HeaderText = "MODEL11ASM02"
        Me.MODEL11ASM02DataGridViewTextBoxColumn.Name = "MODEL11ASM02DataGridViewTextBoxColumn"
        Me.MODEL11ASM02DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL11ASM02DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL11ASM03DataGridViewTextBoxColumn
        '
        Me.MODEL11ASM03DataGridViewTextBoxColumn.DataPropertyName = "MODEL11ASM03"
        Me.MODEL11ASM03DataGridViewTextBoxColumn.HeaderText = "MODEL11ASM03"
        Me.MODEL11ASM03DataGridViewTextBoxColumn.Name = "MODEL11ASM03DataGridViewTextBoxColumn"
        Me.MODEL11ASM03DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL11ASM03DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL11ASM04DataGridViewTextBoxColumn
        '
        Me.MODEL11ASM04DataGridViewTextBoxColumn.DataPropertyName = "MODEL11ASM04"
        Me.MODEL11ASM04DataGridViewTextBoxColumn.HeaderText = "MODEL11ASM04"
        Me.MODEL11ASM04DataGridViewTextBoxColumn.Name = "MODEL11ASM04DataGridViewTextBoxColumn"
        Me.MODEL11ASM04DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL11ASM04DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL11ASM05DataGridViewTextBoxColumn
        '
        Me.MODEL11ASM05DataGridViewTextBoxColumn.DataPropertyName = "MODEL11ASM05"
        Me.MODEL11ASM05DataGridViewTextBoxColumn.HeaderText = "MODEL11ASM05"
        Me.MODEL11ASM05DataGridViewTextBoxColumn.Name = "MODEL11ASM05DataGridViewTextBoxColumn"
        Me.MODEL11ASM05DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL11ASM05DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL12ASM01DataGridViewTextBoxColumn
        '
        Me.MODEL12ASM01DataGridViewTextBoxColumn.DataPropertyName = "MODEL12ASM01"
        Me.MODEL12ASM01DataGridViewTextBoxColumn.HeaderText = "MODEL12ASM01"
        Me.MODEL12ASM01DataGridViewTextBoxColumn.Name = "MODEL12ASM01DataGridViewTextBoxColumn"
        Me.MODEL12ASM01DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL12ASM01DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL12ASM02DataGridViewTextBoxColumn
        '
        Me.MODEL12ASM02DataGridViewTextBoxColumn.DataPropertyName = "MODEL12ASM02"
        Me.MODEL12ASM02DataGridViewTextBoxColumn.HeaderText = "MODEL12ASM02"
        Me.MODEL12ASM02DataGridViewTextBoxColumn.Name = "MODEL12ASM02DataGridViewTextBoxColumn"
        Me.MODEL12ASM02DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL12ASM02DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL12ASM03DataGridViewTextBoxColumn
        '
        Me.MODEL12ASM03DataGridViewTextBoxColumn.DataPropertyName = "MODEL12ASM03"
        Me.MODEL12ASM03DataGridViewTextBoxColumn.HeaderText = "MODEL12ASM03"
        Me.MODEL12ASM03DataGridViewTextBoxColumn.Name = "MODEL12ASM03DataGridViewTextBoxColumn"
        Me.MODEL12ASM03DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL12ASM03DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL12ASM04DataGridViewTextBoxColumn
        '
        Me.MODEL12ASM04DataGridViewTextBoxColumn.DataPropertyName = "MODEL12ASM04"
        Me.MODEL12ASM04DataGridViewTextBoxColumn.HeaderText = "MODEL12ASM04"
        Me.MODEL12ASM04DataGridViewTextBoxColumn.Name = "MODEL12ASM04DataGridViewTextBoxColumn"
        Me.MODEL12ASM04DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL12ASM04DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL12ASM05DataGridViewTextBoxColumn
        '
        Me.MODEL12ASM05DataGridViewTextBoxColumn.DataPropertyName = "MODEL12ASM05"
        Me.MODEL12ASM05DataGridViewTextBoxColumn.HeaderText = "MODEL12ASM05"
        Me.MODEL12ASM05DataGridViewTextBoxColumn.Name = "MODEL12ASM05DataGridViewTextBoxColumn"
        Me.MODEL12ASM05DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL12ASM05DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL13ASM01DataGridViewTextBoxColumn
        '
        Me.MODEL13ASM01DataGridViewTextBoxColumn.DataPropertyName = "MODEL13ASM01"
        Me.MODEL13ASM01DataGridViewTextBoxColumn.HeaderText = "MODEL13ASM01"
        Me.MODEL13ASM01DataGridViewTextBoxColumn.Name = "MODEL13ASM01DataGridViewTextBoxColumn"
        Me.MODEL13ASM01DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL13ASM01DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL13ASM02DataGridViewTextBoxColumn
        '
        Me.MODEL13ASM02DataGridViewTextBoxColumn.DataPropertyName = "MODEL13ASM02"
        Me.MODEL13ASM02DataGridViewTextBoxColumn.HeaderText = "MODEL13ASM02"
        Me.MODEL13ASM02DataGridViewTextBoxColumn.Name = "MODEL13ASM02DataGridViewTextBoxColumn"
        Me.MODEL13ASM02DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL13ASM02DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL13ASM03DataGridViewTextBoxColumn
        '
        Me.MODEL13ASM03DataGridViewTextBoxColumn.DataPropertyName = "MODEL13ASM03"
        Me.MODEL13ASM03DataGridViewTextBoxColumn.HeaderText = "MODEL13ASM03"
        Me.MODEL13ASM03DataGridViewTextBoxColumn.Name = "MODEL13ASM03DataGridViewTextBoxColumn"
        Me.MODEL13ASM03DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL13ASM03DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL13ASM04DataGridViewTextBoxColumn
        '
        Me.MODEL13ASM04DataGridViewTextBoxColumn.DataPropertyName = "MODEL13ASM04"
        Me.MODEL13ASM04DataGridViewTextBoxColumn.HeaderText = "MODEL13ASM04"
        Me.MODEL13ASM04DataGridViewTextBoxColumn.Name = "MODEL13ASM04DataGridViewTextBoxColumn"
        Me.MODEL13ASM04DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL13ASM04DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL13ASM05DataGridViewTextBoxColumn
        '
        Me.MODEL13ASM05DataGridViewTextBoxColumn.DataPropertyName = "MODEL13ASM05"
        Me.MODEL13ASM05DataGridViewTextBoxColumn.HeaderText = "MODEL13ASM05"
        Me.MODEL13ASM05DataGridViewTextBoxColumn.Name = "MODEL13ASM05DataGridViewTextBoxColumn"
        Me.MODEL13ASM05DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL13ASM05DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL14ASM01DataGridViewTextBoxColumn
        '
        Me.MODEL14ASM01DataGridViewTextBoxColumn.DataPropertyName = "MODEL14ASM01"
        Me.MODEL14ASM01DataGridViewTextBoxColumn.HeaderText = "MODEL14ASM01"
        Me.MODEL14ASM01DataGridViewTextBoxColumn.Name = "MODEL14ASM01DataGridViewTextBoxColumn"
        Me.MODEL14ASM01DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL14ASM01DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL14ASM02DataGridViewTextBoxColumn
        '
        Me.MODEL14ASM02DataGridViewTextBoxColumn.DataPropertyName = "MODEL14ASM02"
        Me.MODEL14ASM02DataGridViewTextBoxColumn.HeaderText = "MODEL14ASM02"
        Me.MODEL14ASM02DataGridViewTextBoxColumn.Name = "MODEL14ASM02DataGridViewTextBoxColumn"
        Me.MODEL14ASM02DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL14ASM02DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL14ASM03DataGridViewTextBoxColumn
        '
        Me.MODEL14ASM03DataGridViewTextBoxColumn.DataPropertyName = "MODEL14ASM03"
        Me.MODEL14ASM03DataGridViewTextBoxColumn.HeaderText = "MODEL14ASM03"
        Me.MODEL14ASM03DataGridViewTextBoxColumn.Name = "MODEL14ASM03DataGridViewTextBoxColumn"
        Me.MODEL14ASM03DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL14ASM03DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL14ASM04DataGridViewTextBoxColumn
        '
        Me.MODEL14ASM04DataGridViewTextBoxColumn.DataPropertyName = "MODEL14ASM04"
        Me.MODEL14ASM04DataGridViewTextBoxColumn.HeaderText = "MODEL14ASM04"
        Me.MODEL14ASM04DataGridViewTextBoxColumn.Name = "MODEL14ASM04DataGridViewTextBoxColumn"
        Me.MODEL14ASM04DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL14ASM04DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL14ASM05DataGridViewTextBoxColumn
        '
        Me.MODEL14ASM05DataGridViewTextBoxColumn.DataPropertyName = "MODEL14ASM05"
        Me.MODEL14ASM05DataGridViewTextBoxColumn.HeaderText = "MODEL14ASM05"
        Me.MODEL14ASM05DataGridViewTextBoxColumn.Name = "MODEL14ASM05DataGridViewTextBoxColumn"
        Me.MODEL14ASM05DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL14ASM05DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL15ASM01DataGridViewTextBoxColumn
        '
        Me.MODEL15ASM01DataGridViewTextBoxColumn.DataPropertyName = "MODEL15ASM01"
        Me.MODEL15ASM01DataGridViewTextBoxColumn.HeaderText = "MODEL15ASM01"
        Me.MODEL15ASM01DataGridViewTextBoxColumn.Name = "MODEL15ASM01DataGridViewTextBoxColumn"
        Me.MODEL15ASM01DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL15ASM01DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL15ASM02DataGridViewTextBoxColumn
        '
        Me.MODEL15ASM02DataGridViewTextBoxColumn.DataPropertyName = "MODEL15ASM02"
        Me.MODEL15ASM02DataGridViewTextBoxColumn.HeaderText = "MODEL15ASM02"
        Me.MODEL15ASM02DataGridViewTextBoxColumn.Name = "MODEL15ASM02DataGridViewTextBoxColumn"
        Me.MODEL15ASM02DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL15ASM02DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL15ASM03DataGridViewTextBoxColumn
        '
        Me.MODEL15ASM03DataGridViewTextBoxColumn.DataPropertyName = "MODEL15ASM03"
        Me.MODEL15ASM03DataGridViewTextBoxColumn.HeaderText = "MODEL15ASM03"
        Me.MODEL15ASM03DataGridViewTextBoxColumn.Name = "MODEL15ASM03DataGridViewTextBoxColumn"
        Me.MODEL15ASM03DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL15ASM03DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL15ASM04DataGridViewTextBoxColumn
        '
        Me.MODEL15ASM04DataGridViewTextBoxColumn.DataPropertyName = "MODEL15ASM04"
        Me.MODEL15ASM04DataGridViewTextBoxColumn.HeaderText = "MODEL15ASM04"
        Me.MODEL15ASM04DataGridViewTextBoxColumn.Name = "MODEL15ASM04DataGridViewTextBoxColumn"
        Me.MODEL15ASM04DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL15ASM04DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL15ASM05DataGridViewTextBoxColumn
        '
        Me.MODEL15ASM05DataGridViewTextBoxColumn.DataPropertyName = "MODEL15ASM05"
        Me.MODEL15ASM05DataGridViewTextBoxColumn.HeaderText = "MODEL15ASM05"
        Me.MODEL15ASM05DataGridViewTextBoxColumn.Name = "MODEL15ASM05DataGridViewTextBoxColumn"
        Me.MODEL15ASM05DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL15ASM05DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL16ASM01DataGridViewTextBoxColumn
        '
        Me.MODEL16ASM01DataGridViewTextBoxColumn.DataPropertyName = "MODEL16ASM01"
        Me.MODEL16ASM01DataGridViewTextBoxColumn.HeaderText = "MODEL16ASM01"
        Me.MODEL16ASM01DataGridViewTextBoxColumn.Name = "MODEL16ASM01DataGridViewTextBoxColumn"
        Me.MODEL16ASM01DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL16ASM01DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL16ASM02DataGridViewTextBoxColumn
        '
        Me.MODEL16ASM02DataGridViewTextBoxColumn.DataPropertyName = "MODEL16ASM02"
        Me.MODEL16ASM02DataGridViewTextBoxColumn.HeaderText = "MODEL16ASM02"
        Me.MODEL16ASM02DataGridViewTextBoxColumn.Name = "MODEL16ASM02DataGridViewTextBoxColumn"
        Me.MODEL16ASM02DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL16ASM02DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL16ASM03DataGridViewTextBoxColumn
        '
        Me.MODEL16ASM03DataGridViewTextBoxColumn.DataPropertyName = "MODEL16ASM03"
        Me.MODEL16ASM03DataGridViewTextBoxColumn.HeaderText = "MODEL16ASM03"
        Me.MODEL16ASM03DataGridViewTextBoxColumn.Name = "MODEL16ASM03DataGridViewTextBoxColumn"
        Me.MODEL16ASM03DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL16ASM03DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL16ASM04DataGridViewTextBoxColumn
        '
        Me.MODEL16ASM04DataGridViewTextBoxColumn.DataPropertyName = "MODEL16ASM04"
        Me.MODEL16ASM04DataGridViewTextBoxColumn.HeaderText = "MODEL16ASM04"
        Me.MODEL16ASM04DataGridViewTextBoxColumn.Name = "MODEL16ASM04DataGridViewTextBoxColumn"
        Me.MODEL16ASM04DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL16ASM04DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL16ASM05DataGridViewTextBoxColumn
        '
        Me.MODEL16ASM05DataGridViewTextBoxColumn.DataPropertyName = "MODEL16ASM05"
        Me.MODEL16ASM05DataGridViewTextBoxColumn.HeaderText = "MODEL16ASM05"
        Me.MODEL16ASM05DataGridViewTextBoxColumn.Name = "MODEL16ASM05DataGridViewTextBoxColumn"
        Me.MODEL16ASM05DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL16ASM05DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL17ASM01DataGridViewTextBoxColumn
        '
        Me.MODEL17ASM01DataGridViewTextBoxColumn.DataPropertyName = "MODEL17ASM01"
        Me.MODEL17ASM01DataGridViewTextBoxColumn.HeaderText = "MODEL17ASM01"
        Me.MODEL17ASM01DataGridViewTextBoxColumn.Name = "MODEL17ASM01DataGridViewTextBoxColumn"
        Me.MODEL17ASM01DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL17ASM01DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL17ASM02DataGridViewTextBoxColumn
        '
        Me.MODEL17ASM02DataGridViewTextBoxColumn.DataPropertyName = "MODEL17ASM02"
        Me.MODEL17ASM02DataGridViewTextBoxColumn.HeaderText = "MODEL17ASM02"
        Me.MODEL17ASM02DataGridViewTextBoxColumn.Name = "MODEL17ASM02DataGridViewTextBoxColumn"
        Me.MODEL17ASM02DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL17ASM02DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL17ASM03DataGridViewTextBoxColumn
        '
        Me.MODEL17ASM03DataGridViewTextBoxColumn.DataPropertyName = "MODEL17ASM03"
        Me.MODEL17ASM03DataGridViewTextBoxColumn.HeaderText = "MODEL17ASM03"
        Me.MODEL17ASM03DataGridViewTextBoxColumn.Name = "MODEL17ASM03DataGridViewTextBoxColumn"
        Me.MODEL17ASM03DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL17ASM03DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL17ASM04DataGridViewTextBoxColumn
        '
        Me.MODEL17ASM04DataGridViewTextBoxColumn.DataPropertyName = "MODEL17ASM04"
        Me.MODEL17ASM04DataGridViewTextBoxColumn.HeaderText = "MODEL17ASM04"
        Me.MODEL17ASM04DataGridViewTextBoxColumn.Name = "MODEL17ASM04DataGridViewTextBoxColumn"
        Me.MODEL17ASM04DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL17ASM04DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL17ASM05DataGridViewTextBoxColumn
        '
        Me.MODEL17ASM05DataGridViewTextBoxColumn.DataPropertyName = "MODEL17ASM05"
        Me.MODEL17ASM05DataGridViewTextBoxColumn.HeaderText = "MODEL17ASM05"
        Me.MODEL17ASM05DataGridViewTextBoxColumn.Name = "MODEL17ASM05DataGridViewTextBoxColumn"
        Me.MODEL17ASM05DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL17ASM05DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL18ASM01DataGridViewTextBoxColumn
        '
        Me.MODEL18ASM01DataGridViewTextBoxColumn.DataPropertyName = "MODEL18ASM01"
        Me.MODEL18ASM01DataGridViewTextBoxColumn.HeaderText = "MODEL18ASM01"
        Me.MODEL18ASM01DataGridViewTextBoxColumn.Name = "MODEL18ASM01DataGridViewTextBoxColumn"
        Me.MODEL18ASM01DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL18ASM01DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL18ASM02DataGridViewTextBoxColumn
        '
        Me.MODEL18ASM02DataGridViewTextBoxColumn.DataPropertyName = "MODEL18ASM02"
        Me.MODEL18ASM02DataGridViewTextBoxColumn.HeaderText = "MODEL18ASM02"
        Me.MODEL18ASM02DataGridViewTextBoxColumn.Name = "MODEL18ASM02DataGridViewTextBoxColumn"
        Me.MODEL18ASM02DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL18ASM02DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL18ASM03DataGridViewTextBoxColumn
        '
        Me.MODEL18ASM03DataGridViewTextBoxColumn.DataPropertyName = "MODEL18ASM03"
        Me.MODEL18ASM03DataGridViewTextBoxColumn.HeaderText = "MODEL18ASM03"
        Me.MODEL18ASM03DataGridViewTextBoxColumn.Name = "MODEL18ASM03DataGridViewTextBoxColumn"
        Me.MODEL18ASM03DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL18ASM03DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL18ASM04DataGridViewTextBoxColumn
        '
        Me.MODEL18ASM04DataGridViewTextBoxColumn.DataPropertyName = "MODEL18ASM04"
        Me.MODEL18ASM04DataGridViewTextBoxColumn.HeaderText = "MODEL18ASM04"
        Me.MODEL18ASM04DataGridViewTextBoxColumn.Name = "MODEL18ASM04DataGridViewTextBoxColumn"
        Me.MODEL18ASM04DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL18ASM04DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL18ASM05DataGridViewTextBoxColumn
        '
        Me.MODEL18ASM05DataGridViewTextBoxColumn.DataPropertyName = "MODEL18ASM05"
        Me.MODEL18ASM05DataGridViewTextBoxColumn.HeaderText = "MODEL18ASM05"
        Me.MODEL18ASM05DataGridViewTextBoxColumn.Name = "MODEL18ASM05DataGridViewTextBoxColumn"
        Me.MODEL18ASM05DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL18ASM05DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL19ASM01DataGridViewTextBoxColumn
        '
        Me.MODEL19ASM01DataGridViewTextBoxColumn.DataPropertyName = "MODEL19ASM01"
        Me.MODEL19ASM01DataGridViewTextBoxColumn.HeaderText = "MODEL19ASM01"
        Me.MODEL19ASM01DataGridViewTextBoxColumn.Name = "MODEL19ASM01DataGridViewTextBoxColumn"
        Me.MODEL19ASM01DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL19ASM01DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL19ASM02DataGridViewTextBoxColumn
        '
        Me.MODEL19ASM02DataGridViewTextBoxColumn.DataPropertyName = "MODEL19ASM02"
        Me.MODEL19ASM02DataGridViewTextBoxColumn.HeaderText = "MODEL19ASM02"
        Me.MODEL19ASM02DataGridViewTextBoxColumn.Name = "MODEL19ASM02DataGridViewTextBoxColumn"
        Me.MODEL19ASM02DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL19ASM02DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL19ASM03DataGridViewTextBoxColumn
        '
        Me.MODEL19ASM03DataGridViewTextBoxColumn.DataPropertyName = "MODEL19ASM03"
        Me.MODEL19ASM03DataGridViewTextBoxColumn.HeaderText = "MODEL19ASM03"
        Me.MODEL19ASM03DataGridViewTextBoxColumn.Name = "MODEL19ASM03DataGridViewTextBoxColumn"
        Me.MODEL19ASM03DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL19ASM03DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL19ASM04DataGridViewTextBoxColumn
        '
        Me.MODEL19ASM04DataGridViewTextBoxColumn.DataPropertyName = "MODEL19ASM04"
        Me.MODEL19ASM04DataGridViewTextBoxColumn.HeaderText = "MODEL19ASM04"
        Me.MODEL19ASM04DataGridViewTextBoxColumn.Name = "MODEL19ASM04DataGridViewTextBoxColumn"
        Me.MODEL19ASM04DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL19ASM04DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL19ASM05DataGridViewTextBoxColumn
        '
        Me.MODEL19ASM05DataGridViewTextBoxColumn.DataPropertyName = "MODEL19ASM05"
        Me.MODEL19ASM05DataGridViewTextBoxColumn.HeaderText = "MODEL19ASM05"
        Me.MODEL19ASM05DataGridViewTextBoxColumn.Name = "MODEL19ASM05DataGridViewTextBoxColumn"
        Me.MODEL19ASM05DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL19ASM05DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL20ASM01DataGridViewTextBoxColumn
        '
        Me.MODEL20ASM01DataGridViewTextBoxColumn.DataPropertyName = "MODEL20ASM01"
        Me.MODEL20ASM01DataGridViewTextBoxColumn.HeaderText = "MODEL20ASM01"
        Me.MODEL20ASM01DataGridViewTextBoxColumn.Name = "MODEL20ASM01DataGridViewTextBoxColumn"
        Me.MODEL20ASM01DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL20ASM01DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL20ASM02DataGridViewTextBoxColumn
        '
        Me.MODEL20ASM02DataGridViewTextBoxColumn.DataPropertyName = "MODEL20ASM02"
        Me.MODEL20ASM02DataGridViewTextBoxColumn.HeaderText = "MODEL20ASM02"
        Me.MODEL20ASM02DataGridViewTextBoxColumn.Name = "MODEL20ASM02DataGridViewTextBoxColumn"
        Me.MODEL20ASM02DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL20ASM02DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL20ASM03DataGridViewTextBoxColumn
        '
        Me.MODEL20ASM03DataGridViewTextBoxColumn.DataPropertyName = "MODEL20ASM03"
        Me.MODEL20ASM03DataGridViewTextBoxColumn.HeaderText = "MODEL20ASM03"
        Me.MODEL20ASM03DataGridViewTextBoxColumn.Name = "MODEL20ASM03DataGridViewTextBoxColumn"
        Me.MODEL20ASM03DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL20ASM03DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL20ASM04DataGridViewTextBoxColumn
        '
        Me.MODEL20ASM04DataGridViewTextBoxColumn.DataPropertyName = "MODEL20ASM04"
        Me.MODEL20ASM04DataGridViewTextBoxColumn.HeaderText = "MODEL20ASM04"
        Me.MODEL20ASM04DataGridViewTextBoxColumn.Name = "MODEL20ASM04DataGridViewTextBoxColumn"
        Me.MODEL20ASM04DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL20ASM04DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MODEL20ASM05DataGridViewTextBoxColumn
        '
        Me.MODEL20ASM05DataGridViewTextBoxColumn.DataPropertyName = "MODEL20ASM05"
        Me.MODEL20ASM05DataGridViewTextBoxColumn.HeaderText = "MODEL20ASM05"
        Me.MODEL20ASM05DataGridViewTextBoxColumn.Name = "MODEL20ASM05DataGridViewTextBoxColumn"
        Me.MODEL20ASM05DataGridViewTextBoxColumn.ReadOnly = True
        Me.MODEL20ASM05DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Reserve01DataGridViewTextBoxColumn
        '
        Me.Reserve01DataGridViewTextBoxColumn.DataPropertyName = "Reserve01"
        Me.Reserve01DataGridViewTextBoxColumn.HeaderText = "Reserve01"
        Me.Reserve01DataGridViewTextBoxColumn.Name = "Reserve01DataGridViewTextBoxColumn"
        Me.Reserve01DataGridViewTextBoxColumn.ReadOnly = True
        Me.Reserve01DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Reserve02DataGridViewTextBoxColumn
        '
        Me.Reserve02DataGridViewTextBoxColumn.DataPropertyName = "Reserve02"
        Me.Reserve02DataGridViewTextBoxColumn.HeaderText = "Reserve02"
        Me.Reserve02DataGridViewTextBoxColumn.Name = "Reserve02DataGridViewTextBoxColumn"
        Me.Reserve02DataGridViewTextBoxColumn.ReadOnly = True
        Me.Reserve02DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'XchgFlagDataGridViewTextBoxColumn
        '
        Me.XchgFlagDataGridViewTextBoxColumn.DataPropertyName = "XchgFlag"
        Me.XchgFlagDataGridViewTextBoxColumn.HeaderText = "XchgFlag"
        Me.XchgFlagDataGridViewTextBoxColumn.Name = "XchgFlagDataGridViewTextBoxColumn"
        Me.XchgFlagDataGridViewTextBoxColumn.ReadOnly = True
        Me.XchgFlagDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'InstructFlagDataGridViewTextBoxColumn
        '
        Me.InstructFlagDataGridViewTextBoxColumn.DataPropertyName = "InstructFlag"
        Me.InstructFlagDataGridViewTextBoxColumn.HeaderText = "InstructFlag"
        Me.InstructFlagDataGridViewTextBoxColumn.Name = "InstructFlagDataGridViewTextBoxColumn"
        Me.InstructFlagDataGridViewTextBoxColumn.ReadOnly = True
        Me.InstructFlagDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'FileNameDataGridViewTextBoxColumn
        '
        Me.FileNameDataGridViewTextBoxColumn.DataPropertyName = "FileName"
        Me.FileNameDataGridViewTextBoxColumn.HeaderText = "FileName"
        Me.FileNameDataGridViewTextBoxColumn.Name = "FileNameDataGridViewTextBoxColumn"
        Me.FileNameDataGridViewTextBoxColumn.ReadOnly = True
        Me.FileNameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Insert
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(1016, 734)
        Me.Controls.Add(Me.lblValue2)
        Me.Controls.Add(Me.lblLabel2)
        Me.Controls.Add(Me.lblValue)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.DataGridInsertData)
        Me.Controls.Add(Me.labelBlockNo)
        Me.Controls.Add(Me.lblLabel)
        Me.Controls.Add(Me.rdbSelectedPart)
        Me.Controls.Add(Me.rdbLotBlock)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximumSize = New System.Drawing.Size(1024, 768)
        Me.MinimumSize = New System.Drawing.Size(1022, 732)
        Me.Name = "Insert"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Insert"
        CType(Me.DataGridInsertData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TProductionDATBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents labelBlockNo As System.Windows.Forms.Label
    Friend WithEvents lblLabel As System.Windows.Forms.Label
    Friend WithEvents rdbSelectedPart As System.Windows.Forms.RadioButton
    Friend WithEvents rdbLotBlock As System.Windows.Forms.RadioButton
    Friend WithEvents DataGridInsertData As System.Windows.Forms.DataGridView
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents DataSet1 As InstructionSystem.DataSet1
    Friend WithEvents TProductionDATBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents T_Production_DATTableAdapter As InstructionSystem.DataSet1TableAdapters.T_Production_DATTableAdapter
    Friend WithEvents lblValue As System.Windows.Forms.Label
    Friend WithEvents lblLabel2 As System.Windows.Forms.Label
    Friend WithEvents lblValue2 As System.Windows.Forms.Label
    Friend WithEvents IndexNoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SeqNoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SubSeqDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SEQDESCDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
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
    Friend WithEvents MODEL01ASM01DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL01ASM02DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL01ASM03DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL01ASM04DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL01ASM05DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL02ASM01DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL02ASM02DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL02ASM03DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL02ASM04DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL02ASM05DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL03ASM01DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL03ASM02DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL03ASM03DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL03ASM04DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL03ASM05DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL04ASM01DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL04ASM02DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL04ASM03DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL04ASM04DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL04ASM05DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL05ASM01DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL05ASM02DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL05ASM03DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL05ASM04DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL05ASM05DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL06ASM01DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL06ASM02DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL06ASM03DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL06ASM04DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL06ASM05DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL07ASM01DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL07ASM02DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL07ASM03DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL07ASM04DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL07ASM05DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL08ASM01DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL08ASM02DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL08ASM03DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL08ASM04DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL08ASM05DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL09ASM01DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL09ASM02DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL09ASM03DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL09ASM04DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL09ASM05DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL10ASM01DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL10ASM02DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL10ASM03DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL10ASM04DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL10ASM05DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL11ASM01DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL11ASM02DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL11ASM03DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL11ASM04DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL11ASM05DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL12ASM01DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL12ASM02DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL12ASM03DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL12ASM04DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL12ASM05DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL13ASM01DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL13ASM02DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL13ASM03DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL13ASM04DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL13ASM05DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL14ASM01DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL14ASM02DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL14ASM03DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL14ASM04DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL14ASM05DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL15ASM01DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL15ASM02DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL15ASM03DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL15ASM04DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL15ASM05DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL16ASM01DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL16ASM02DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL16ASM03DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL16ASM04DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL16ASM05DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL17ASM01DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL17ASM02DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL17ASM03DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL17ASM04DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL17ASM05DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL18ASM01DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL18ASM02DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL18ASM03DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL18ASM04DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL18ASM05DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL19ASM01DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL19ASM02DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL19ASM03DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL19ASM04DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL19ASM05DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL20ASM01DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL20ASM02DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL20ASM03DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL20ASM04DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEL20ASM05DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Reserve01DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Reserve02DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents XchgFlagDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InstructFlagDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FileNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
