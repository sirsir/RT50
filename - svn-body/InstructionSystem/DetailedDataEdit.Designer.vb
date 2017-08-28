<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DetailedDataEdit
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
        Me.grModelCode = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtSuffixc = New System.Windows.Forms.TextBox
        Me.txtModelYear = New System.Windows.Forms.TextBox
        Me.grLot = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtUnit = New System.Windows.Forms.TextBox
        Me.txtLotNo = New System.Windows.Forms.TextBox
        Me.txtLotID = New System.Windows.Forms.TextBox
        Me.grProduction = New System.Windows.Forms.GroupBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtTime = New System.Windows.Forms.TextBox
        Me.txtDate = New System.Windows.Forms.TextBox
        Me.grImport = New System.Windows.Forms.GroupBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtImportCode = New System.Windows.Forms.TextBox
        Me.grOther = New System.Windows.Forms.GroupBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtHanmmerYear = New System.Windows.Forms.TextBox
        Me.txtGAShop = New System.Windows.Forms.TextBox
        Me.txtYChassisFlag = New System.Windows.Forms.TextBox
        Me.txtMark = New System.Windows.Forms.TextBox
        Me.txtSEQmain = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.datagirdEdit = New System.Windows.Forms.DataGridView
        Me.LineCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ASMPARTSNo1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ASMPARTSNo2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ASMPARTSNo3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ASMPARTSNo4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ASMPARTSNo5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnUpdate = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.txtBlockModel = New System.Windows.Forms.TextBox
        Me.txtBlockSeq = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.label8 = New System.Windows.Forms.Label
        Me.grRandomInfo = New System.Windows.Forms.GroupBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rdbPubx = New System.Windows.Forms.RadioButton
        Me.rdbCab = New System.Windows.Forms.RadioButton
        Me.rdbAll = New System.Windows.Forms.RadioButton
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.grModelCode.SuspendLayout()
        Me.grLot.SuspendLayout()
        Me.grProduction.SuspendLayout()
        Me.grImport.SuspendLayout()
        Me.grOther.SuspendLayout()
        CType(Me.datagirdEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grRandomInfo.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grModelCode
        '
        Me.grModelCode.Controls.Add(Me.Label3)
        Me.grModelCode.Controls.Add(Me.Label2)
        Me.grModelCode.Controls.Add(Me.txtSuffixc)
        Me.grModelCode.Controls.Add(Me.txtModelYear)
        Me.grModelCode.ForeColor = System.Drawing.Color.Blue
        Me.grModelCode.Location = New System.Drawing.Point(69, 32)
        Me.grModelCode.Name = "grModelCode"
        Me.grModelCode.Size = New System.Drawing.Size(419, 77)
        Me.grModelCode.TabIndex = 0
        Me.grModelCode.TabStop = False
        Me.grModelCode.Text = "MODEL CODE"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(45, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Suffixc"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(50, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Year"
        '
        'txtSuffixc
        '
        Me.txtSuffixc.Location = New System.Drawing.Point(146, 45)
        Me.txtSuffixc.MaxLength = 5
        Me.txtSuffixc.Name = "txtSuffixc"
        Me.txtSuffixc.Size = New System.Drawing.Size(174, 20)
        Me.txtSuffixc.TabIndex = 3
        '
        'txtModelYear
        '
        Me.txtModelYear.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtModelYear.Location = New System.Drawing.Point(146, 19)
        Me.txtModelYear.MaxLength = 3
        Me.txtModelYear.Name = "txtModelYear"
        Me.txtModelYear.Size = New System.Drawing.Size(174, 20)
        Me.txtModelYear.TabIndex = 2
        '
        'grLot
        '
        Me.grLot.Controls.Add(Me.Label6)
        Me.grLot.Controls.Add(Me.Label4)
        Me.grLot.Controls.Add(Me.Label5)
        Me.grLot.Controls.Add(Me.txtUnit)
        Me.grLot.Controls.Add(Me.txtLotNo)
        Me.grLot.Controls.Add(Me.txtLotID)
        Me.grLot.ForeColor = System.Drawing.Color.Blue
        Me.grLot.Location = New System.Drawing.Point(69, 115)
        Me.grLot.Name = "grLot"
        Me.grLot.Size = New System.Drawing.Size(419, 98)
        Me.grLot.TabIndex = 1
        Me.grLot.TabStop = False
        Me.grLot.Text = "LOT"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(47, 74)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Unit"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(49, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "No."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(50, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(20, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "ID"
        '
        'txtUnit
        '
        Me.txtUnit.Location = New System.Drawing.Point(146, 71)
        Me.txtUnit.MaxLength = 3
        Me.txtUnit.Name = "txtUnit"
        Me.txtUnit.Size = New System.Drawing.Size(174, 20)
        Me.txtUnit.TabIndex = 6
        '
        'txtLotNo
        '
        Me.txtLotNo.Location = New System.Drawing.Point(146, 45)
        Me.txtLotNo.MaxLength = 3
        Me.txtLotNo.Name = "txtLotNo"
        Me.txtLotNo.Size = New System.Drawing.Size(174, 20)
        Me.txtLotNo.TabIndex = 5
        '
        'txtLotID
        '
        Me.txtLotID.Location = New System.Drawing.Point(146, 19)
        Me.txtLotID.MaxLength = 3
        Me.txtLotID.Name = "txtLotID"
        Me.txtLotID.Size = New System.Drawing.Size(174, 20)
        Me.txtLotID.TabIndex = 4
        '
        'grProduction
        '
        Me.grProduction.Controls.Add(Me.Label10)
        Me.grProduction.Controls.Add(Me.Label9)
        Me.grProduction.Controls.Add(Me.txtTime)
        Me.grProduction.Controls.Add(Me.txtDate)
        Me.grProduction.ForeColor = System.Drawing.Color.Blue
        Me.grProduction.Location = New System.Drawing.Point(520, 32)
        Me.grProduction.Name = "grProduction"
        Me.grProduction.Size = New System.Drawing.Size(419, 74)
        Me.grProduction.TabIndex = 3
        Me.grProduction.TabStop = False
        Me.grProduction.Text = "PRODUCTION"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(54, 48)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(37, 13)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "TIME"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(54, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 13)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "DATE"
        '
        'txtTime
        '
        Me.txtTime.Location = New System.Drawing.Point(166, 45)
        Me.txtTime.MaxLength = 4
        Me.txtTime.Name = "txtTime"
        Me.txtTime.Size = New System.Drawing.Size(174, 20)
        Me.txtTime.TabIndex = 10
        '
        'txtDate
        '
        Me.txtDate.Location = New System.Drawing.Point(166, 19)
        Me.txtDate.MaxLength = 8
        Me.txtDate.Name = "txtDate"
        Me.txtDate.Size = New System.Drawing.Size(174, 20)
        Me.txtDate.TabIndex = 9
        '
        'grImport
        '
        Me.grImport.Controls.Add(Me.Label11)
        Me.grImport.Controls.Add(Me.txtImportCode)
        Me.grImport.ForeColor = System.Drawing.Color.Blue
        Me.grImport.Location = New System.Drawing.Point(520, 112)
        Me.grImport.Name = "grImport"
        Me.grImport.Size = New System.Drawing.Size(419, 50)
        Me.grImport.TabIndex = 4
        Me.grImport.TabStop = False
        Me.grImport.Text = "IMPORT"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(54, 22)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(41, 13)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "CODE"
        '
        'txtImportCode
        '
        Me.txtImportCode.Location = New System.Drawing.Point(166, 19)
        Me.txtImportCode.MaxLength = 10
        Me.txtImportCode.Name = "txtImportCode"
        Me.txtImportCode.Size = New System.Drawing.Size(174, 20)
        Me.txtImportCode.TabIndex = 11
        '
        'grOther
        '
        Me.grOther.Controls.Add(Me.Label15)
        Me.grOther.Controls.Add(Me.Label14)
        Me.grOther.Controls.Add(Me.Label13)
        Me.grOther.Controls.Add(Me.Label12)
        Me.grOther.Controls.Add(Me.txtHanmmerYear)
        Me.grOther.Controls.Add(Me.txtGAShop)
        Me.grOther.Controls.Add(Me.txtYChassisFlag)
        Me.grOther.Controls.Add(Me.txtMark)
        Me.grOther.ForeColor = System.Drawing.Color.Blue
        Me.grOther.Location = New System.Drawing.Point(520, 168)
        Me.grOther.Name = "grOther"
        Me.grOther.Size = New System.Drawing.Size(419, 135)
        Me.grOther.TabIndex = 5
        Me.grOther.TabStop = False
        Me.grOther.Text = "OTHER"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(25, 106)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(107, 13)
        Me.Label15.TabIndex = 12
        Me.Label15.Text = "HANMMER YEAR"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(48, 79)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(57, 13)
        Me.Label14.TabIndex = 12
        Me.Label14.Text = "GA Shop"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(32, 53)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(90, 13)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "Y-Chassis Flag"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(54, 26)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(42, 13)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "MARK"
        '
        'txtHanmmerYear
        '
        Me.txtHanmmerYear.Location = New System.Drawing.Point(166, 103)
        Me.txtHanmmerYear.MaxLength = 2
        Me.txtHanmmerYear.Name = "txtHanmmerYear"
        Me.txtHanmmerYear.Size = New System.Drawing.Size(174, 20)
        Me.txtHanmmerYear.TabIndex = 15
        '
        'txtGAShop
        '
        Me.txtGAShop.Location = New System.Drawing.Point(166, 76)
        Me.txtGAShop.MaxLength = 2
        Me.txtGAShop.Name = "txtGAShop"
        Me.txtGAShop.Size = New System.Drawing.Size(174, 20)
        Me.txtGAShop.TabIndex = 14
        '
        'txtYChassisFlag
        '
        Me.txtYChassisFlag.Location = New System.Drawing.Point(166, 50)
        Me.txtYChassisFlag.MaxLength = 1
        Me.txtYChassisFlag.Name = "txtYChassisFlag"
        Me.txtYChassisFlag.Size = New System.Drawing.Size(174, 20)
        Me.txtYChassisFlag.TabIndex = 13
        '
        'txtMark
        '
        Me.txtMark.Location = New System.Drawing.Point(166, 23)
        Me.txtMark.MaxLength = 3
        Me.txtMark.Name = "txtMark"
        Me.txtMark.Size = New System.Drawing.Size(174, 20)
        Me.txtMark.TabIndex = 12
        '
        'txtSEQmain
        '
        Me.txtSEQmain.Location = New System.Drawing.Point(215, 10)
        Me.txtSEQmain.MaxLength = 5
        Me.txtSEQmain.Name = "txtSEQmain"
        Me.txtSEQmain.Size = New System.Drawing.Size(174, 20)
        Me.txtSEQmain.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(116, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "SEQ"
        '
        'datagirdEdit
        '
        Me.datagirdEdit.AllowUserToAddRows = False
        Me.datagirdEdit.AllowUserToDeleteRows = False
        Me.datagirdEdit.AllowUserToResizeRows = False
        Me.datagirdEdit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datagirdEdit.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LineCode, Me.LineName, Me.ASMPARTSNo1, Me.ASMPARTSNo2, Me.ASMPARTSNo3, Me.ASMPARTSNo4, Me.ASMPARTSNo5})
        Me.datagirdEdit.Location = New System.Drawing.Point(32, 356)
        Me.datagirdEdit.MultiSelect = False
        Me.datagirdEdit.Name = "datagirdEdit"
        Me.datagirdEdit.RowHeadersVisible = False
        Me.datagirdEdit.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.datagirdEdit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.datagirdEdit.Size = New System.Drawing.Size(945, 286)
        Me.datagirdEdit.TabIndex = 18
        '
        'LineCode
        '
        Me.LineCode.DataPropertyName = "LineCode"
        Me.LineCode.HeaderText = "LineCode"
        Me.LineCode.Name = "LineCode"
        Me.LineCode.ReadOnly = True
        '
        'LineName
        '
        Me.LineName.DataPropertyName = "LineName"
        Me.LineName.HeaderText = "LineName"
        Me.LineName.Name = "LineName"
        Me.LineName.ReadOnly = True
        '
        'ASMPARTSNo1
        '
        Me.ASMPARTSNo1.DataPropertyName = "ASMPARTSNo1"
        Me.ASMPARTSNo1.HeaderText = "ASMPARTSNo1"
        Me.ASMPARTSNo1.MaxInputLength = 10
        Me.ASMPARTSNo1.Name = "ASMPARTSNo1"
        '
        'ASMPARTSNo2
        '
        Me.ASMPARTSNo2.DataPropertyName = "ASMPARTSNo2"
        Me.ASMPARTSNo2.HeaderText = "ASMPARTSNo2"
        Me.ASMPARTSNo2.MaxInputLength = 10
        Me.ASMPARTSNo2.Name = "ASMPARTSNo2"
        '
        'ASMPARTSNo3
        '
        Me.ASMPARTSNo3.DataPropertyName = "ASMPARTSNo3"
        Me.ASMPARTSNo3.HeaderText = "ASMPARTSNo3"
        Me.ASMPARTSNo3.MaxInputLength = 10
        Me.ASMPARTSNo3.Name = "ASMPARTSNo3"
        '
        'ASMPARTSNo4
        '
        Me.ASMPARTSNo4.DataPropertyName = "ASMPARTSNo4"
        Me.ASMPARTSNo4.HeaderText = "ASMPARTSNo4"
        Me.ASMPARTSNo4.MaxInputLength = 10
        Me.ASMPARTSNo4.Name = "ASMPARTSNo4"
        '
        'ASMPARTSNo5
        '
        Me.ASMPARTSNo5.DataPropertyName = "ASMPARTSNo5"
        Me.ASMPARTSNo5.HeaderText = "ASMPARTSNo5"
        Me.ASMPARTSNo5.MaxInputLength = 10
        Me.ASMPARTSNo5.Name = "ASMPARTSNo5"
        '
        'btnUpdate
        '
        Me.btnUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnUpdate.Location = New System.Drawing.Point(607, 666)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(151, 35)
        Me.btnUpdate.TabIndex = 16
        Me.btnUpdate.Text = "F1:UPDATE"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(779, 666)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(151, 35)
        Me.btnCancel.TabIndex = 17
        Me.btnCancel.Text = "F12:CANCEL"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'txtBlockModel
        '
        Me.txtBlockModel.Location = New System.Drawing.Point(146, 19)
        Me.txtBlockModel.MaxLength = 8
        Me.txtBlockModel.Name = "txtBlockModel"
        Me.txtBlockModel.Size = New System.Drawing.Size(174, 20)
        Me.txtBlockModel.TabIndex = 7
        '
        'txtBlockSeq
        '
        Me.txtBlockSeq.Location = New System.Drawing.Point(146, 45)
        Me.txtBlockSeq.MaxLength = 3
        Me.txtBlockSeq.Name = "txtBlockSeq"
        Me.txtBlockSeq.Size = New System.Drawing.Size(174, 20)
        Me.txtBlockSeq.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(20, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "BLOCK MODEL"
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.label8.ForeColor = System.Drawing.Color.Black
        Me.label8.Location = New System.Drawing.Point(45, 47)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(29, 13)
        Me.label8.TabIndex = 12
        Me.label8.Text = "Seq"
        '
        'grRandomInfo
        '
        Me.grRandomInfo.Controls.Add(Me.label8)
        Me.grRandomInfo.Controls.Add(Me.Label7)
        Me.grRandomInfo.Controls.Add(Me.txtBlockSeq)
        Me.grRandomInfo.Controls.Add(Me.txtBlockModel)
        Me.grRandomInfo.ForeColor = System.Drawing.Color.Blue
        Me.grRandomInfo.Location = New System.Drawing.Point(69, 219)
        Me.grRandomInfo.Name = "grRandomInfo"
        Me.grRandomInfo.Size = New System.Drawing.Size(419, 76)
        Me.grRandomInfo.TabIndex = 2
        Me.grRandomInfo.TabStop = False
        Me.grRandomInfo.Text = "RANDOM INFO"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdbPubx)
        Me.GroupBox1.Controls.Add(Me.rdbCab)
        Me.GroupBox1.Controls.Add(Me.rdbAll)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox1.Location = New System.Drawing.Point(69, 301)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(419, 40)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "PRODUCTION INFO"
        '
        'rdbPubx
        '
        Me.rdbPubx.AutoSize = True
        Me.rdbPubx.Enabled = False
        Me.rdbPubx.ForeColor = System.Drawing.Color.Black
        Me.rdbPubx.Location = New System.Drawing.Point(252, 17)
        Me.rdbPubx.Name = "rdbPubx"
        Me.rdbPubx.Size = New System.Drawing.Size(54, 17)
        Me.rdbPubx.TabIndex = 14
        Me.rdbPubx.TabStop = True
        Me.rdbPubx.Text = "PUBX"
        Me.rdbPubx.UseVisualStyleBackColor = True
        '
        'rdbCab
        '
        Me.rdbCab.AutoSize = True
        Me.rdbCab.Enabled = False
        Me.rdbCab.ForeColor = System.Drawing.Color.Black
        Me.rdbCab.Location = New System.Drawing.Point(146, 17)
        Me.rdbCab.Name = "rdbCab"
        Me.rdbCab.Size = New System.Drawing.Size(46, 17)
        Me.rdbCab.TabIndex = 13
        Me.rdbCab.TabStop = True
        Me.rdbCab.Text = "CAB"
        Me.rdbCab.UseVisualStyleBackColor = True
        '
        'rdbAll
        '
        Me.rdbAll.AutoSize = True
        Me.rdbAll.Enabled = False
        Me.rdbAll.ForeColor = System.Drawing.Color.Black
        Me.rdbAll.Location = New System.Drawing.Point(48, 17)
        Me.rdbAll.Name = "rdbAll"
        Me.rdbAll.Size = New System.Drawing.Size(44, 17)
        Me.rdbAll.TabIndex = 0
        Me.rdbAll.TabStop = True
        Me.rdbAll.Text = "ALL"
        Me.rdbAll.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        '
        'DetailedDataEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(1018, 734)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.datagirdEdit)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtSEQmain)
        Me.Controls.Add(Me.grOther)
        Me.Controls.Add(Me.grImport)
        Me.Controls.Add(Me.grProduction)
        Me.Controls.Add(Me.grRandomInfo)
        Me.Controls.Add(Me.grLot)
        Me.Controls.Add(Me.grModelCode)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximumSize = New System.Drawing.Size(1024, 768)
        Me.MinimumSize = New System.Drawing.Size(1022, 732)
        Me.Name = "DetailedDataEdit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detailed data edit"
        Me.grModelCode.ResumeLayout(False)
        Me.grModelCode.PerformLayout()
        Me.grLot.ResumeLayout(False)
        Me.grLot.PerformLayout()
        Me.grProduction.ResumeLayout(False)
        Me.grProduction.PerformLayout()
        Me.grImport.ResumeLayout(False)
        Me.grImport.PerformLayout()
        Me.grOther.ResumeLayout(False)
        Me.grOther.PerformLayout()
        CType(Me.datagirdEdit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grRandomInfo.ResumeLayout(False)
        Me.grRandomInfo.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grModelCode As System.Windows.Forms.GroupBox
    Friend WithEvents grLot As System.Windows.Forms.GroupBox
    Friend WithEvents grProduction As System.Windows.Forms.GroupBox
    Friend WithEvents grImport As System.Windows.Forms.GroupBox
    Friend WithEvents grOther As System.Windows.Forms.GroupBox
    Friend WithEvents txtSEQmain As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSuffixc As System.Windows.Forms.TextBox
    Friend WithEvents txtModelYear As System.Windows.Forms.TextBox
    Friend WithEvents txtUnit As System.Windows.Forms.TextBox
    Friend WithEvents txtLotNo As System.Windows.Forms.TextBox
    Friend WithEvents txtLotID As System.Windows.Forms.TextBox
    Friend WithEvents txtTime As System.Windows.Forms.TextBox
    Friend WithEvents txtDate As System.Windows.Forms.TextBox
    Friend WithEvents txtImportCode As System.Windows.Forms.TextBox
    Friend WithEvents txtHanmmerYear As System.Windows.Forms.TextBox
    Friend WithEvents txtGAShop As System.Windows.Forms.TextBox
    Friend WithEvents txtYChassisFlag As System.Windows.Forms.TextBox
    Friend WithEvents txtMark As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents datagirdEdit As System.Windows.Forms.DataGridView
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents txtBlockModel As System.Windows.Forms.TextBox
    Friend WithEvents txtBlockSeq As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents label8 As System.Windows.Forms.Label
    Friend WithEvents grRandomInfo As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdbPubx As System.Windows.Forms.RadioButton
    Friend WithEvents rdbCab As System.Windows.Forms.RadioButton
    Friend WithEvents rdbAll As System.Windows.Forms.RadioButton
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents LineCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ASMPARTSNo1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ASMPARTSNo2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ASMPARTSNo3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ASMPARTSNo4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ASMPARTSNo5 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
