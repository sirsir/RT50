<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInstructionData_AddEdit
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
        Me.grpLeft = New System.Windows.Forms.GroupBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnExecute = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.twcSurfaceColorName = New PSIS_CLIENT.ctrlTxtInputWithChecking
        Me.twcSurfaceColorSfSw = New PSIS_CLIENT.ctrlTxtInputWithChecking
        Me.twcSurfaceColorXXX = New PSIS_CLIENT.ctrlTxtInputWithChecking
        Me.twcYChassis = New PSIS_CLIENT.ctrlTxtInputWithChecking
        Me.twcBodyColorName = New PSIS_CLIENT.ctrlTxtInputWithChecking
        Me.twcGaShop = New PSIS_CLIENT.ctrlTxtInputWithChecking
        Me.twcBodyColorOpt = New PSIS_CLIENT.ctrlTxtInputWithChecking
        Me.twcBodyShopCode = New PSIS_CLIENT.ctrlTxtInputWithChecking
        Me.twcBodyColorSeq = New PSIS_CLIENT.ctrlTxtInputWithChecking
        Me.twcHandleType = New PSIS_CLIENT.ctrlTxtInputWithChecking
        Me.twcBodyColorTcSw = New PSIS_CLIENT.ctrlTxtInputWithChecking
        Me.twcShift = New PSIS_CLIENT.ctrlTxtInputWithChecking
        Me.twcOnTime = New PSIS_CLIENT.ctrlTxtInputWithChecking
        Me.twcImportCode = New PSIS_CLIENT.ctrlTxtInputWithChecking
        Me.twcSeqNo = New PSIS_CLIENT.ctrlTxtInputWithChecking
        Me.twcModelCode = New PSIS_CLIENT.ctrlTxtInputWithChecking
        Me.twcProductionDate = New PSIS_CLIENT.ctrlTxtInputWithChecking
        Me.twcLotId = New PSIS_CLIENT.ctrlTxtInputWithChecking
        Me.twcMark = New PSIS_CLIENT.ctrlTxtInputWithChecking
        Me.twcLotNo = New PSIS_CLIENT.ctrlTxtInputWithChecking
        Me.twcBlockSeq = New PSIS_CLIENT.ctrlTxtInputWithChecking
        Me.twcUnit = New PSIS_CLIENT.ctrlTxtInputWithChecking
        Me.twcBlock = New PSIS_CLIENT.ctrlTxtInputWithChecking
        Me.grpLeft.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpLeft
        '
        Me.grpLeft.Controls.Add(Me.twcShift)
        Me.grpLeft.Controls.Add(Me.twcOnTime)
        Me.grpLeft.Controls.Add(Me.twcImportCode)
        Me.grpLeft.Controls.Add(Me.twcSeqNo)
        Me.grpLeft.Controls.Add(Me.twcModelCode)
        Me.grpLeft.Controls.Add(Me.twcProductionDate)
        Me.grpLeft.Controls.Add(Me.twcLotId)
        Me.grpLeft.Controls.Add(Me.twcMark)
        Me.grpLeft.Controls.Add(Me.twcLotNo)
        Me.grpLeft.Controls.Add(Me.twcBlockSeq)
        Me.grpLeft.Controls.Add(Me.twcUnit)
        Me.grpLeft.Controls.Add(Me.twcBlock)
        Me.grpLeft.Location = New System.Drawing.Point(12, 0)
        Me.grpLeft.Name = "grpLeft"
        Me.grpLeft.Size = New System.Drawing.Size(395, 748)
        Me.grpLeft.TabIndex = 11
        Me.grpLeft.TabStop = False
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(229, 709)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 12
        Me.btnCancel.Text = "CANCEL"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnExecute
        '
        Me.btnExecute.Location = New System.Drawing.Point(93, 709)
        Me.btnExecute.Name = "btnExecute"
        Me.btnExecute.Size = New System.Drawing.Size(84, 23)
        Me.btnExecute.TabIndex = 11
        Me.btnExecute.Text = "EXECUTION"
        Me.btnExecute.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnExecute)
        Me.GroupBox1.Controls.Add(Me.btnCancel)
        Me.GroupBox1.Controls.Add(Me.twcSurfaceColorName)
        Me.GroupBox1.Controls.Add(Me.twcSurfaceColorSfSw)
        Me.GroupBox1.Controls.Add(Me.twcSurfaceColorXXX)
        Me.GroupBox1.Controls.Add(Me.twcYChassis)
        Me.GroupBox1.Controls.Add(Me.twcBodyColorName)
        Me.GroupBox1.Controls.Add(Me.twcGaShop)
        Me.GroupBox1.Controls.Add(Me.twcBodyColorOpt)
        Me.GroupBox1.Controls.Add(Me.twcBodyShopCode)
        Me.GroupBox1.Controls.Add(Me.twcBodyColorSeq)
        Me.GroupBox1.Controls.Add(Me.twcHandleType)
        Me.GroupBox1.Controls.Add(Me.twcBodyColorTcSw)
        Me.GroupBox1.Location = New System.Drawing.Point(413, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(395, 748)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        '
        'twcSurfaceColorName
        '
        Me.twcSurfaceColorName.BackColor = System.Drawing.SystemColors.ControlLight
        Me.twcSurfaceColorName.EnableEdit = True
        Me.twcSurfaceColorName.ErrorMessage = ""
        Me.twcSurfaceColorName.HintMessage = ""
        Me.twcSurfaceColorName.InputName = ""
        Me.twcSurfaceColorName.InputText = ""
        Me.twcSurfaceColorName.Location = New System.Drawing.Point(9, 629)
        Me.twcSurfaceColorName.MaxLength = 0
        Me.twcSurfaceColorName.Name = "twcSurfaceColorName"
        Me.twcSurfaceColorName.RegexFormat = ""
        Me.twcSurfaceColorName.Size = New System.Drawing.Size(380, 55)
        Me.twcSurfaceColorName.TabIndex = 10
        '
        'twcSurfaceColorSfSw
        '
        Me.twcSurfaceColorSfSw.BackColor = System.Drawing.SystemColors.ControlLight
        Me.twcSurfaceColorSfSw.EnableEdit = True
        Me.twcSurfaceColorSfSw.ErrorMessage = ""
        Me.twcSurfaceColorSfSw.HintMessage = ""
        Me.twcSurfaceColorSfSw.InputName = ""
        Me.twcSurfaceColorSfSw.InputText = ""
        Me.twcSurfaceColorSfSw.Location = New System.Drawing.Point(9, 507)
        Me.twcSurfaceColorSfSw.MaxLength = 0
        Me.twcSurfaceColorSfSw.Name = "twcSurfaceColorSfSw"
        Me.twcSurfaceColorSfSw.RegexFormat = ""
        Me.twcSurfaceColorSfSw.Size = New System.Drawing.Size(380, 55)
        Me.twcSurfaceColorSfSw.TabIndex = 8
        '
        'twcSurfaceColorXXX
        '
        Me.twcSurfaceColorXXX.BackColor = System.Drawing.SystemColors.ControlLight
        Me.twcSurfaceColorXXX.EnableEdit = True
        Me.twcSurfaceColorXXX.ErrorMessage = ""
        Me.twcSurfaceColorXXX.HintMessage = ""
        Me.twcSurfaceColorXXX.InputName = ""
        Me.twcSurfaceColorXXX.InputText = ""
        Me.twcSurfaceColorXXX.Location = New System.Drawing.Point(9, 568)
        Me.twcSurfaceColorXXX.MaxLength = 0
        Me.twcSurfaceColorXXX.Name = "twcSurfaceColorXXX"
        Me.twcSurfaceColorXXX.RegexFormat = ""
        Me.twcSurfaceColorXXX.Size = New System.Drawing.Size(380, 55)
        Me.twcSurfaceColorXXX.TabIndex = 9
        '
        'twcYChassis
        '
        Me.twcYChassis.BackColor = System.Drawing.SystemColors.ControlLight
        Me.twcYChassis.EnableEdit = True
        Me.twcYChassis.ErrorMessage = Nothing
        Me.twcYChassis.HintMessage = ""
        Me.twcYChassis.InputName = ""
        Me.twcYChassis.InputText = ""
        Me.twcYChassis.Location = New System.Drawing.Point(9, 19)
        Me.twcYChassis.MaxLength = 0
        Me.twcYChassis.Name = "twcYChassis"
        Me.twcYChassis.RegexFormat = ""
        Me.twcYChassis.Size = New System.Drawing.Size(380, 55)
        Me.twcYChassis.TabIndex = 0
        '
        'twcBodyColorName
        '
        Me.twcBodyColorName.BackColor = System.Drawing.SystemColors.ControlLight
        Me.twcBodyColorName.EnableEdit = True
        Me.twcBodyColorName.ErrorMessage = ""
        Me.twcBodyColorName.HintMessage = ""
        Me.twcBodyColorName.InputName = ""
        Me.twcBodyColorName.InputText = ""
        Me.twcBodyColorName.Location = New System.Drawing.Point(9, 446)
        Me.twcBodyColorName.MaxLength = 0
        Me.twcBodyColorName.Name = "twcBodyColorName"
        Me.twcBodyColorName.RegexFormat = ""
        Me.twcBodyColorName.Size = New System.Drawing.Size(380, 55)
        Me.twcBodyColorName.TabIndex = 7
        '
        'twcGaShop
        '
        Me.twcGaShop.BackColor = System.Drawing.SystemColors.ControlLight
        Me.twcGaShop.EnableEdit = True
        Me.twcGaShop.ErrorMessage = ""
        Me.twcGaShop.HintMessage = ""
        Me.twcGaShop.InputName = ""
        Me.twcGaShop.InputText = ""
        Me.twcGaShop.Location = New System.Drawing.Point(9, 80)
        Me.twcGaShop.MaxLength = 0
        Me.twcGaShop.Name = "twcGaShop"
        Me.twcGaShop.RegexFormat = ""
        Me.twcGaShop.Size = New System.Drawing.Size(380, 55)
        Me.twcGaShop.TabIndex = 1
        '
        'twcBodyColorOpt
        '
        Me.twcBodyColorOpt.BackColor = System.Drawing.SystemColors.ControlLight
        Me.twcBodyColorOpt.EnableEdit = True
        Me.twcBodyColorOpt.ErrorMessage = ""
        Me.twcBodyColorOpt.HintMessage = ""
        Me.twcBodyColorOpt.InputName = ""
        Me.twcBodyColorOpt.InputText = ""
        Me.twcBodyColorOpt.Location = New System.Drawing.Point(9, 385)
        Me.twcBodyColorOpt.MaxLength = 0
        Me.twcBodyColorOpt.Name = "twcBodyColorOpt"
        Me.twcBodyColorOpt.RegexFormat = ""
        Me.twcBodyColorOpt.Size = New System.Drawing.Size(380, 55)
        Me.twcBodyColorOpt.TabIndex = 6
        '
        'twcBodyShopCode
        '
        Me.twcBodyShopCode.BackColor = System.Drawing.SystemColors.ControlLight
        Me.twcBodyShopCode.EnableEdit = True
        Me.twcBodyShopCode.ErrorMessage = ""
        Me.twcBodyShopCode.HintMessage = ""
        Me.twcBodyShopCode.InputName = ""
        Me.twcBodyShopCode.InputText = ""
        Me.twcBodyShopCode.Location = New System.Drawing.Point(9, 141)
        Me.twcBodyShopCode.MaxLength = 0
        Me.twcBodyShopCode.Name = "twcBodyShopCode"
        Me.twcBodyShopCode.RegexFormat = ""
        Me.twcBodyShopCode.Size = New System.Drawing.Size(380, 55)
        Me.twcBodyShopCode.TabIndex = 2
        '
        'twcBodyColorSeq
        '
        Me.twcBodyColorSeq.BackColor = System.Drawing.SystemColors.ControlLight
        Me.twcBodyColorSeq.EnableEdit = True
        Me.twcBodyColorSeq.ErrorMessage = ""
        Me.twcBodyColorSeq.HintMessage = ""
        Me.twcBodyColorSeq.InputName = ""
        Me.twcBodyColorSeq.InputText = ""
        Me.twcBodyColorSeq.Location = New System.Drawing.Point(9, 324)
        Me.twcBodyColorSeq.MaxLength = 0
        Me.twcBodyColorSeq.Name = "twcBodyColorSeq"
        Me.twcBodyColorSeq.RegexFormat = ""
        Me.twcBodyColorSeq.Size = New System.Drawing.Size(380, 55)
        Me.twcBodyColorSeq.TabIndex = 5
        '
        'twcHandleType
        '
        Me.twcHandleType.BackColor = System.Drawing.SystemColors.ControlLight
        Me.twcHandleType.EnableEdit = True
        Me.twcHandleType.ErrorMessage = ""
        Me.twcHandleType.HintMessage = ""
        Me.twcHandleType.InputName = ""
        Me.twcHandleType.InputText = ""
        Me.twcHandleType.Location = New System.Drawing.Point(9, 202)
        Me.twcHandleType.MaxLength = 0
        Me.twcHandleType.Name = "twcHandleType"
        Me.twcHandleType.RegexFormat = ""
        Me.twcHandleType.Size = New System.Drawing.Size(380, 55)
        Me.twcHandleType.TabIndex = 3
        '
        'twcBodyColorTcSw
        '
        Me.twcBodyColorTcSw.BackColor = System.Drawing.SystemColors.ControlLight
        Me.twcBodyColorTcSw.EnableEdit = True
        Me.twcBodyColorTcSw.ErrorMessage = ""
        Me.twcBodyColorTcSw.HintMessage = ""
        Me.twcBodyColorTcSw.InputName = ""
        Me.twcBodyColorTcSw.InputText = ""
        Me.twcBodyColorTcSw.Location = New System.Drawing.Point(9, 263)
        Me.twcBodyColorTcSw.MaxLength = 0
        Me.twcBodyColorTcSw.Name = "twcBodyColorTcSw"
        Me.twcBodyColorTcSw.RegexFormat = ""
        Me.twcBodyColorTcSw.Size = New System.Drawing.Size(380, 55)
        Me.twcBodyColorTcSw.TabIndex = 4
        '
        'twcShift
        '
        Me.twcShift.BackColor = System.Drawing.SystemColors.ControlLight
        Me.twcShift.EnableEdit = True
        Me.twcShift.ErrorMessage = ""
        Me.twcShift.HintMessage = ""
        Me.twcShift.InputName = ""
        Me.twcShift.InputText = ""
        Me.twcShift.Location = New System.Drawing.Point(6, 568)
        Me.twcShift.MaxLength = 0
        Me.twcShift.Name = "twcShift"
        Me.twcShift.RegexFormat = ""
        Me.twcShift.Size = New System.Drawing.Size(380, 55)
        Me.twcShift.TabIndex = 9
        '
        'twcOnTime
        '
        Me.twcOnTime.BackColor = System.Drawing.SystemColors.ControlLight
        Me.twcOnTime.EnableEdit = True
        Me.twcOnTime.ErrorMessage = ""
        Me.twcOnTime.HintMessage = ""
        Me.twcOnTime.InputName = ""
        Me.twcOnTime.InputText = ""
        Me.twcOnTime.Location = New System.Drawing.Point(6, 629)
        Me.twcOnTime.MaxLength = 0
        Me.twcOnTime.Name = "twcOnTime"
        Me.twcOnTime.RegexFormat = ""
        Me.twcOnTime.Size = New System.Drawing.Size(380, 55)
        Me.twcOnTime.TabIndex = 10
        '
        'twcImportCode
        '
        Me.twcImportCode.BackColor = System.Drawing.SystemColors.ControlLight
        Me.twcImportCode.EnableEdit = True
        Me.twcImportCode.ErrorMessage = Nothing
        Me.twcImportCode.HintMessage = ""
        Me.twcImportCode.InputName = ""
        Me.twcImportCode.InputText = ""
        Me.twcImportCode.Location = New System.Drawing.Point(6, 690)
        Me.twcImportCode.MaxLength = 0
        Me.twcImportCode.Name = "twcImportCode"
        Me.twcImportCode.RegexFormat = ""
        Me.twcImportCode.Size = New System.Drawing.Size(380, 55)
        Me.twcImportCode.TabIndex = 11
        '
        'twcSeqNo
        '
        Me.twcSeqNo.BackColor = System.Drawing.SystemColors.ControlLight
        Me.twcSeqNo.EnableEdit = True
        Me.twcSeqNo.ErrorMessage = Nothing
        Me.twcSeqNo.HintMessage = ""
        Me.twcSeqNo.InputName = ""
        Me.twcSeqNo.InputText = ""
        Me.twcSeqNo.Location = New System.Drawing.Point(6, 19)
        Me.twcSeqNo.MaxLength = 0
        Me.twcSeqNo.Name = "twcSeqNo"
        Me.twcSeqNo.RegexFormat = ""
        Me.twcSeqNo.Size = New System.Drawing.Size(380, 55)
        Me.twcSeqNo.TabIndex = 0
        '
        'twcModelCode
        '
        Me.twcModelCode.BackColor = System.Drawing.SystemColors.ControlLight
        Me.twcModelCode.EnableEdit = True
        Me.twcModelCode.ErrorMessage = Nothing
        Me.twcModelCode.HintMessage = ""
        Me.twcModelCode.InputName = ""
        Me.twcModelCode.InputText = ""
        Me.twcModelCode.Location = New System.Drawing.Point(6, 80)
        Me.twcModelCode.MaxLength = 0
        Me.twcModelCode.Name = "twcModelCode"
        Me.twcModelCode.RegexFormat = ""
        Me.twcModelCode.Size = New System.Drawing.Size(380, 55)
        Me.twcModelCode.TabIndex = 1
        '
        'twcProductionDate
        '
        Me.twcProductionDate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.twcProductionDate.EnableEdit = True
        Me.twcProductionDate.ErrorMessage = ""
        Me.twcProductionDate.HintMessage = ""
        Me.twcProductionDate.InputName = ""
        Me.twcProductionDate.InputText = ""
        Me.twcProductionDate.Location = New System.Drawing.Point(6, 507)
        Me.twcProductionDate.MaxLength = 0
        Me.twcProductionDate.Name = "twcProductionDate"
        Me.twcProductionDate.RegexFormat = ""
        Me.twcProductionDate.Size = New System.Drawing.Size(380, 55)
        Me.twcProductionDate.TabIndex = 8
        '
        'twcLotId
        '
        Me.twcLotId.BackColor = System.Drawing.SystemColors.ControlLight
        Me.twcLotId.EnableEdit = True
        Me.twcLotId.ErrorMessage = ""
        Me.twcLotId.HintMessage = ""
        Me.twcLotId.InputName = ""
        Me.twcLotId.InputText = ""
        Me.twcLotId.Location = New System.Drawing.Point(6, 141)
        Me.twcLotId.MaxLength = 0
        Me.twcLotId.Name = "twcLotId"
        Me.twcLotId.RegexFormat = ""
        Me.twcLotId.Size = New System.Drawing.Size(380, 55)
        Me.twcLotId.TabIndex = 2
        '
        'twcMark
        '
        Me.twcMark.BackColor = System.Drawing.SystemColors.ControlLight
        Me.twcMark.EnableEdit = True
        Me.twcMark.ErrorMessage = ""
        Me.twcMark.HintMessage = ""
        Me.twcMark.InputName = ""
        Me.twcMark.InputText = ""
        Me.twcMark.Location = New System.Drawing.Point(6, 446)
        Me.twcMark.MaxLength = 0
        Me.twcMark.Name = "twcMark"
        Me.twcMark.RegexFormat = ""
        Me.twcMark.Size = New System.Drawing.Size(380, 55)
        Me.twcMark.TabIndex = 7
        '
        'twcLotNo
        '
        Me.twcLotNo.BackColor = System.Drawing.SystemColors.ControlLight
        Me.twcLotNo.EnableEdit = True
        Me.twcLotNo.ErrorMessage = ""
        Me.twcLotNo.HintMessage = ""
        Me.twcLotNo.InputName = ""
        Me.twcLotNo.InputText = ""
        Me.twcLotNo.Location = New System.Drawing.Point(6, 202)
        Me.twcLotNo.MaxLength = 0
        Me.twcLotNo.Name = "twcLotNo"
        Me.twcLotNo.RegexFormat = ""
        Me.twcLotNo.Size = New System.Drawing.Size(380, 55)
        Me.twcLotNo.TabIndex = 3
        '
        'twcBlockSeq
        '
        Me.twcBlockSeq.BackColor = System.Drawing.SystemColors.ControlLight
        Me.twcBlockSeq.EnableEdit = True
        Me.twcBlockSeq.ErrorMessage = ""
        Me.twcBlockSeq.HintMessage = ""
        Me.twcBlockSeq.InputName = ""
        Me.twcBlockSeq.InputText = ""
        Me.twcBlockSeq.Location = New System.Drawing.Point(6, 385)
        Me.twcBlockSeq.MaxLength = 0
        Me.twcBlockSeq.Name = "twcBlockSeq"
        Me.twcBlockSeq.RegexFormat = ""
        Me.twcBlockSeq.Size = New System.Drawing.Size(380, 55)
        Me.twcBlockSeq.TabIndex = 6
        '
        'twcUnit
        '
        Me.twcUnit.BackColor = System.Drawing.SystemColors.ControlLight
        Me.twcUnit.EnableEdit = True
        Me.twcUnit.ErrorMessage = ""
        Me.twcUnit.HintMessage = ""
        Me.twcUnit.InputName = ""
        Me.twcUnit.InputText = ""
        Me.twcUnit.Location = New System.Drawing.Point(6, 263)
        Me.twcUnit.MaxLength = 0
        Me.twcUnit.Name = "twcUnit"
        Me.twcUnit.RegexFormat = ""
        Me.twcUnit.Size = New System.Drawing.Size(380, 55)
        Me.twcUnit.TabIndex = 4
        '
        'twcBlock
        '
        Me.twcBlock.BackColor = System.Drawing.SystemColors.ControlLight
        Me.twcBlock.EnableEdit = True
        Me.twcBlock.ErrorMessage = ""
        Me.twcBlock.HintMessage = ""
        Me.twcBlock.InputName = ""
        Me.twcBlock.InputText = ""
        Me.twcBlock.Location = New System.Drawing.Point(6, 324)
        Me.twcBlock.MaxLength = 0
        Me.twcBlock.Name = "twcBlock"
        Me.twcBlock.RegexFormat = ""
        Me.twcBlock.Size = New System.Drawing.Size(380, 55)
        Me.twcBlock.TabIndex = 5
        '
        'frmInstructionData_AddEdit
        '
        Me.AcceptButton = Me.btnExecute
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(819, 760)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grpLeft)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "frmInstructionData_AddEdit"
        Me.Text = "Instruction Data"
        Me.grpLeft.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents twcSeqNo As PSIS_CLIENT.ctrlTxtInputWithChecking
    Friend WithEvents twcModelCode As PSIS_CLIENT.ctrlTxtInputWithChecking
    Friend WithEvents twcLotId As PSIS_CLIENT.ctrlTxtInputWithChecking
    Friend WithEvents twcLotNo As PSIS_CLIENT.ctrlTxtInputWithChecking
    Friend WithEvents twcUnit As PSIS_CLIENT.ctrlTxtInputWithChecking
    Friend WithEvents twcBlock As PSIS_CLIENT.ctrlTxtInputWithChecking
    Friend WithEvents twcBlockSeq As PSIS_CLIENT.ctrlTxtInputWithChecking
    Friend WithEvents twcMark As PSIS_CLIENT.ctrlTxtInputWithChecking
    Friend WithEvents twcProductionDate As PSIS_CLIENT.ctrlTxtInputWithChecking
    Friend WithEvents twcShift As PSIS_CLIENT.ctrlTxtInputWithChecking
    Friend WithEvents twcOnTime As PSIS_CLIENT.ctrlTxtInputWithChecking
    Friend WithEvents grpLeft As System.Windows.Forms.GroupBox
    Friend WithEvents twcImportCode As PSIS_CLIENT.ctrlTxtInputWithChecking
    Friend WithEvents twcBodyColorTcSw As PSIS_CLIENT.ctrlTxtInputWithChecking
    Friend WithEvents twcHandleType As PSIS_CLIENT.ctrlTxtInputWithChecking
    Friend WithEvents twcBodyColorSeq As PSIS_CLIENT.ctrlTxtInputWithChecking
    Friend WithEvents twcBodyShopCode As PSIS_CLIENT.ctrlTxtInputWithChecking
    Friend WithEvents twcBodyColorOpt As PSIS_CLIENT.ctrlTxtInputWithChecking
    Friend WithEvents twcGaShop As PSIS_CLIENT.ctrlTxtInputWithChecking
    Friend WithEvents twcBodyColorName As PSIS_CLIENT.ctrlTxtInputWithChecking
    Friend WithEvents twcYChassis As PSIS_CLIENT.ctrlTxtInputWithChecking
    Friend WithEvents twcSurfaceColorXXX As PSIS_CLIENT.ctrlTxtInputWithChecking
    Friend WithEvents twcSurfaceColorSfSw As PSIS_CLIENT.ctrlTxtInputWithChecking
    Friend WithEvents twcSurfaceColorName As PSIS_CLIENT.ctrlTxtInputWithChecking
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnExecute As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
