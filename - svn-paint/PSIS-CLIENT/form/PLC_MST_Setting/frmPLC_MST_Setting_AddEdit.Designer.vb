<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPLC_MST_Setting_AddEdit
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
        Me.lblSTAGE_CODE = New System.Windows.Forms.Label
        Me.lblSTAGE_CODE_Err = New System.Windows.Forms.Label
        Me.lblPLC_NET = New System.Windows.Forms.Label
        Me.lblPLC_NET_Err = New System.Windows.Forms.Label
        Me.lblPLC_NODE = New System.Windows.Forms.Label
        Me.lblPLC_UNIT = New System.Windows.Forms.Label
        Me.lblPLC_NODE_Err = New System.Windows.Forms.Label
        Me.lblPLC_UNIT_Err = New System.Windows.Forms.Label
        Me.lblREAD_DM = New System.Windows.Forms.Label
        Me.lblREAD_DM_Err = New System.Windows.Forms.Label
        Me.lblWRITE_DATA_DM = New System.Windows.Forms.Label
        Me.lblWRITE_DATA_DM_Err = New System.Windows.Forms.Label
        Me.lblWRITE_STATUS_DM = New System.Windows.Forms.Label
        Me.lblWRITE_STATUS_DM_Err = New System.Windows.Forms.Label
        Me.lblPLC_ONLINE_FLAG = New System.Windows.Forms.Label
        Me.lblPROCESS_NAME = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnExecution = New System.Windows.Forms.Button
        Me.txtSTAGE_CODE = New System.Windows.Forms.TextBox
        Me.txtPLC_NET = New System.Windows.Forms.TextBox
        Me.txtPLC_NODE = New System.Windows.Forms.TextBox
        Me.txtPLC_UNIT = New System.Windows.Forms.TextBox
        Me.txtREAD_DM = New System.Windows.Forms.TextBox
        Me.txtWRITE_DATA_DM = New System.Windows.Forms.TextBox
        Me.txtWRITE_STATUS_DM = New System.Windows.Forms.TextBox
        Me.cboPROCESS_NAME = New System.Windows.Forms.ComboBox
        Me.bsPROCESSMST = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsPAINT1 = New Common.dsPAINT
        Me.chkPLC_ONLINE_FLAG = New System.Windows.Forms.CheckBox
        Me.taPROCESS_MST1 = New Common.dsPAINTTableAdapters.taPROCESS_MST
        Me.taPLC_MST1 = New Common.dsPAINTTableAdapters.taPLC_MST
        CType(Me.bsPROCESSMST, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsPAINT1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblSTAGE_CODE
        '
        Me.lblSTAGE_CODE.BackColor = System.Drawing.SystemColors.Control
        Me.lblSTAGE_CODE.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSTAGE_CODE.Location = New System.Drawing.Point(12, 9)
        Me.lblSTAGE_CODE.Name = "lblSTAGE_CODE"
        Me.lblSTAGE_CODE.Size = New System.Drawing.Size(370, 24)
        Me.lblSTAGE_CODE.TabIndex = 6
        Me.lblSTAGE_CODE.Text = "STAGE CODE"
        Me.lblSTAGE_CODE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSTAGE_CODE_Err
        '
        Me.lblSTAGE_CODE_Err.AutoSize = True
        Me.lblSTAGE_CODE_Err.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSTAGE_CODE_Err.ForeColor = System.Drawing.Color.Red
        Me.lblSTAGE_CODE_Err.Location = New System.Drawing.Point(12, 33)
        Me.lblSTAGE_CODE_Err.Name = "lblSTAGE_CODE_Err"
        Me.lblSTAGE_CODE_Err.Size = New System.Drawing.Size(142, 16)
        Me.lblSTAGE_CODE_Err.TabIndex = 8
        Me.lblSTAGE_CODE_Err.Text = "STAGE CODE ERROR"
        '
        'lblPLC_NET
        '
        Me.lblPLC_NET.BackColor = System.Drawing.SystemColors.Control
        Me.lblPLC_NET.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPLC_NET.Location = New System.Drawing.Point(12, 49)
        Me.lblPLC_NET.Name = "lblPLC_NET"
        Me.lblPLC_NET.Size = New System.Drawing.Size(370, 24)
        Me.lblPLC_NET.TabIndex = 9
        Me.lblPLC_NET.Text = "PLC NET"
        Me.lblPLC_NET.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPLC_NET_Err
        '
        Me.lblPLC_NET_Err.AutoSize = True
        Me.lblPLC_NET_Err.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPLC_NET_Err.ForeColor = System.Drawing.Color.Red
        Me.lblPLC_NET_Err.Location = New System.Drawing.Point(12, 73)
        Me.lblPLC_NET_Err.Name = "lblPLC_NET_Err"
        Me.lblPLC_NET_Err.Size = New System.Drawing.Size(112, 16)
        Me.lblPLC_NET_Err.TabIndex = 10
        Me.lblPLC_NET_Err.Text = "PLC NET ERROR"
        '
        'lblPLC_NODE
        '
        Me.lblPLC_NODE.BackColor = System.Drawing.SystemColors.Control
        Me.lblPLC_NODE.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPLC_NODE.Location = New System.Drawing.Point(12, 89)
        Me.lblPLC_NODE.Name = "lblPLC_NODE"
        Me.lblPLC_NODE.Size = New System.Drawing.Size(370, 24)
        Me.lblPLC_NODE.TabIndex = 11
        Me.lblPLC_NODE.Text = "PLC NODE"
        Me.lblPLC_NODE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPLC_UNIT
        '
        Me.lblPLC_UNIT.BackColor = System.Drawing.SystemColors.Control
        Me.lblPLC_UNIT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPLC_UNIT.Location = New System.Drawing.Point(12, 129)
        Me.lblPLC_UNIT.Name = "lblPLC_UNIT"
        Me.lblPLC_UNIT.Size = New System.Drawing.Size(370, 24)
        Me.lblPLC_UNIT.TabIndex = 12
        Me.lblPLC_UNIT.Text = "PLC UNIT"
        Me.lblPLC_UNIT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPLC_NODE_Err
        '
        Me.lblPLC_NODE_Err.AutoSize = True
        Me.lblPLC_NODE_Err.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPLC_NODE_Err.ForeColor = System.Drawing.Color.Red
        Me.lblPLC_NODE_Err.Location = New System.Drawing.Point(12, 113)
        Me.lblPLC_NODE_Err.Name = "lblPLC_NODE_Err"
        Me.lblPLC_NODE_Err.Size = New System.Drawing.Size(124, 16)
        Me.lblPLC_NODE_Err.TabIndex = 13
        Me.lblPLC_NODE_Err.Text = "PLC NODE ERROR"
        '
        'lblPLC_UNIT_Err
        '
        Me.lblPLC_UNIT_Err.AutoSize = True
        Me.lblPLC_UNIT_Err.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPLC_UNIT_Err.ForeColor = System.Drawing.Color.Red
        Me.lblPLC_UNIT_Err.Location = New System.Drawing.Point(12, 153)
        Me.lblPLC_UNIT_Err.Name = "lblPLC_UNIT_Err"
        Me.lblPLC_UNIT_Err.Size = New System.Drawing.Size(115, 16)
        Me.lblPLC_UNIT_Err.TabIndex = 14
        Me.lblPLC_UNIT_Err.Text = "PLC UNIT ERROR"
        '
        'lblREAD_DM
        '
        Me.lblREAD_DM.BackColor = System.Drawing.SystemColors.Control
        Me.lblREAD_DM.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblREAD_DM.Location = New System.Drawing.Point(12, 169)
        Me.lblREAD_DM.Name = "lblREAD_DM"
        Me.lblREAD_DM.Size = New System.Drawing.Size(370, 24)
        Me.lblREAD_DM.TabIndex = 15
        Me.lblREAD_DM.Text = "READ DM"
        Me.lblREAD_DM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblREAD_DM_Err
        '
        Me.lblREAD_DM_Err.AutoSize = True
        Me.lblREAD_DM_Err.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblREAD_DM_Err.ForeColor = System.Drawing.Color.Red
        Me.lblREAD_DM_Err.Location = New System.Drawing.Point(12, 193)
        Me.lblREAD_DM_Err.Name = "lblREAD_DM_Err"
        Me.lblREAD_DM_Err.Size = New System.Drawing.Size(118, 16)
        Me.lblREAD_DM_Err.TabIndex = 16
        Me.lblREAD_DM_Err.Text = "READ DM ERROR"
        '
        'lblWRITE_DATA_DM
        '
        Me.lblWRITE_DATA_DM.BackColor = System.Drawing.SystemColors.Control
        Me.lblWRITE_DATA_DM.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWRITE_DATA_DM.Location = New System.Drawing.Point(12, 209)
        Me.lblWRITE_DATA_DM.Name = "lblWRITE_DATA_DM"
        Me.lblWRITE_DATA_DM.Size = New System.Drawing.Size(370, 24)
        Me.lblWRITE_DATA_DM.TabIndex = 17
        Me.lblWRITE_DATA_DM.Text = "WRITE DATA DM"
        Me.lblWRITE_DATA_DM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblWRITE_DATA_DM_Err
        '
        Me.lblWRITE_DATA_DM_Err.AutoSize = True
        Me.lblWRITE_DATA_DM_Err.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWRITE_DATA_DM_Err.ForeColor = System.Drawing.Color.Red
        Me.lblWRITE_DATA_DM_Err.Location = New System.Drawing.Point(12, 233)
        Me.lblWRITE_DATA_DM_Err.Name = "lblWRITE_DATA_DM_Err"
        Me.lblWRITE_DATA_DM_Err.Size = New System.Drawing.Size(134, 16)
        Me.lblWRITE_DATA_DM_Err.TabIndex = 18
        Me.lblWRITE_DATA_DM_Err.Text = "WRITE DATA ERROR"
        '
        'lblWRITE_STATUS_DM
        '
        Me.lblWRITE_STATUS_DM.BackColor = System.Drawing.SystemColors.Control
        Me.lblWRITE_STATUS_DM.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWRITE_STATUS_DM.Location = New System.Drawing.Point(12, 249)
        Me.lblWRITE_STATUS_DM.Name = "lblWRITE_STATUS_DM"
        Me.lblWRITE_STATUS_DM.Size = New System.Drawing.Size(370, 24)
        Me.lblWRITE_STATUS_DM.TabIndex = 19
        Me.lblWRITE_STATUS_DM.Text = "WRITE STATUS DM"
        Me.lblWRITE_STATUS_DM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblWRITE_STATUS_DM_Err
        '
        Me.lblWRITE_STATUS_DM_Err.AutoSize = True
        Me.lblWRITE_STATUS_DM_Err.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWRITE_STATUS_DM_Err.ForeColor = System.Drawing.Color.Red
        Me.lblWRITE_STATUS_DM_Err.Location = New System.Drawing.Point(12, 273)
        Me.lblWRITE_STATUS_DM_Err.Name = "lblWRITE_STATUS_DM_Err"
        Me.lblWRITE_STATUS_DM_Err.Size = New System.Drawing.Size(175, 16)
        Me.lblWRITE_STATUS_DM_Err.TabIndex = 20
        Me.lblWRITE_STATUS_DM_Err.Text = "WRITE STATUS DM ERROR"
        '
        'lblPLC_ONLINE_FLAG
        '
        Me.lblPLC_ONLINE_FLAG.BackColor = System.Drawing.SystemColors.Control
        Me.lblPLC_ONLINE_FLAG.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPLC_ONLINE_FLAG.Location = New System.Drawing.Point(12, 289)
        Me.lblPLC_ONLINE_FLAG.Name = "lblPLC_ONLINE_FLAG"
        Me.lblPLC_ONLINE_FLAG.Size = New System.Drawing.Size(370, 24)
        Me.lblPLC_ONLINE_FLAG.TabIndex = 21
        Me.lblPLC_ONLINE_FLAG.Text = "PLC ONLINE FLAG"
        Me.lblPLC_ONLINE_FLAG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPROCESS_NAME
        '
        Me.lblPROCESS_NAME.BackColor = System.Drawing.SystemColors.Control
        Me.lblPROCESS_NAME.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPROCESS_NAME.Location = New System.Drawing.Point(12, 329)
        Me.lblPROCESS_NAME.Name = "lblPROCESS_NAME"
        Me.lblPROCESS_NAME.Size = New System.Drawing.Size(370, 24)
        Me.lblPROCESS_NAME.TabIndex = 23
        Me.lblPROCESS_NAME.Text = "PROCESS NAME"
        Me.lblPROCESS_NAME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(218, 380)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 25
        Me.btnCancel.Text = "CANCEL"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnExecution
        '
        Me.btnExecution.Location = New System.Drawing.Point(78, 380)
        Me.btnExecution.Name = "btnExecution"
        Me.btnExecution.Size = New System.Drawing.Size(77, 23)
        Me.btnExecution.TabIndex = 26
        Me.btnExecution.Text = "EXECUTION"
        Me.btnExecution.UseVisualStyleBackColor = True
        '
        'txtSTAGE_CODE
        '
        Me.txtSTAGE_CODE.Location = New System.Drawing.Point(265, 11)
        Me.txtSTAGE_CODE.MaxLength = 15
        Me.txtSTAGE_CODE.Name = "txtSTAGE_CODE"
        Me.txtSTAGE_CODE.Size = New System.Drawing.Size(115, 20)
        Me.txtSTAGE_CODE.TabIndex = 27
        '
        'txtPLC_NET
        '
        Me.txtPLC_NET.Location = New System.Drawing.Point(265, 51)
        Me.txtPLC_NET.MaxLength = 15
        Me.txtPLC_NET.Name = "txtPLC_NET"
        Me.txtPLC_NET.Size = New System.Drawing.Size(115, 20)
        Me.txtPLC_NET.TabIndex = 28
        '
        'txtPLC_NODE
        '
        Me.txtPLC_NODE.Location = New System.Drawing.Point(265, 91)
        Me.txtPLC_NODE.MaxLength = 15
        Me.txtPLC_NODE.Name = "txtPLC_NODE"
        Me.txtPLC_NODE.Size = New System.Drawing.Size(115, 20)
        Me.txtPLC_NODE.TabIndex = 29
        '
        'txtPLC_UNIT
        '
        Me.txtPLC_UNIT.Location = New System.Drawing.Point(265, 131)
        Me.txtPLC_UNIT.MaxLength = 15
        Me.txtPLC_UNIT.Name = "txtPLC_UNIT"
        Me.txtPLC_UNIT.Size = New System.Drawing.Size(115, 20)
        Me.txtPLC_UNIT.TabIndex = 30
        '
        'txtREAD_DM
        '
        Me.txtREAD_DM.Location = New System.Drawing.Point(265, 171)
        Me.txtREAD_DM.MaxLength = 15
        Me.txtREAD_DM.Name = "txtREAD_DM"
        Me.txtREAD_DM.Size = New System.Drawing.Size(115, 20)
        Me.txtREAD_DM.TabIndex = 31
        '
        'txtWRITE_DATA_DM
        '
        Me.txtWRITE_DATA_DM.Location = New System.Drawing.Point(265, 211)
        Me.txtWRITE_DATA_DM.MaxLength = 15
        Me.txtWRITE_DATA_DM.Name = "txtWRITE_DATA_DM"
        Me.txtWRITE_DATA_DM.Size = New System.Drawing.Size(115, 20)
        Me.txtWRITE_DATA_DM.TabIndex = 32
        '
        'txtWRITE_STATUS_DM
        '
        Me.txtWRITE_STATUS_DM.Location = New System.Drawing.Point(265, 251)
        Me.txtWRITE_STATUS_DM.MaxLength = 15
        Me.txtWRITE_STATUS_DM.Name = "txtWRITE_STATUS_DM"
        Me.txtWRITE_STATUS_DM.Size = New System.Drawing.Size(115, 20)
        Me.txtWRITE_STATUS_DM.TabIndex = 33
        '
        'cboPROCESS_NAME
        '
        Me.cboPROCESS_NAME.DataSource = Me.bsPROCESSMST
        Me.cboPROCESS_NAME.DisplayMember = "PROCESS_NAME"
        Me.cboPROCESS_NAME.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPROCESS_NAME.DropDownWidth = 115
        Me.cboPROCESS_NAME.FormattingEnabled = True
        Me.cboPROCESS_NAME.Location = New System.Drawing.Point(265, 331)
        Me.cboPROCESS_NAME.Name = "cboPROCESS_NAME"
        Me.cboPROCESS_NAME.Size = New System.Drawing.Size(115, 21)
        Me.cboPROCESS_NAME.TabIndex = 35
        Me.cboPROCESS_NAME.ValueMember = "PROCESS_NO"
        '
        'bsPROCESSMST
        '
        Me.bsPROCESSMST.DataMember = "dtPROCESS_MST"
        Me.bsPROCESSMST.DataSource = Me.dsPAINT1
        '
        'dsPAINT1
        '
        Me.dsPAINT1.DataSetName = "dsPAINT"
        Me.dsPAINT1.Locale = New System.Globalization.CultureInfo("th-TH")
        Me.dsPAINT1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'chkPLC_ONLINE_FLAG
        '
        Me.chkPLC_ONLINE_FLAG.AutoSize = True
        Me.chkPLC_ONLINE_FLAG.Location = New System.Drawing.Point(265, 292)
        Me.chkPLC_ONLINE_FLAG.Name = "chkPLC_ONLINE_FLAG"
        Me.chkPLC_ONLINE_FLAG.Size = New System.Drawing.Size(15, 14)
        Me.chkPLC_ONLINE_FLAG.TabIndex = 36
        Me.chkPLC_ONLINE_FLAG.UseVisualStyleBackColor = True
        '
        'taPROCESS_MST1
        '
        Me.taPROCESS_MST1.ClearBeforeFill = True
        '
        'taPLC_MST1
        '
        Me.taPLC_MST1.ClearBeforeFill = True
        '
        'frmPLC_MST_Setting_AddEdit
        '
        Me.AcceptButton = Me.btnExecution
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(394, 415)
        Me.Controls.Add(Me.chkPLC_ONLINE_FLAG)
        Me.Controls.Add(Me.cboPROCESS_NAME)
        Me.Controls.Add(Me.txtWRITE_STATUS_DM)
        Me.Controls.Add(Me.txtWRITE_DATA_DM)
        Me.Controls.Add(Me.txtREAD_DM)
        Me.Controls.Add(Me.txtPLC_UNIT)
        Me.Controls.Add(Me.txtPLC_NODE)
        Me.Controls.Add(Me.txtPLC_NET)
        Me.Controls.Add(Me.txtSTAGE_CODE)
        Me.Controls.Add(Me.btnExecution)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.lblPROCESS_NAME)
        Me.Controls.Add(Me.lblPLC_ONLINE_FLAG)
        Me.Controls.Add(Me.lblWRITE_STATUS_DM_Err)
        Me.Controls.Add(Me.lblWRITE_STATUS_DM)
        Me.Controls.Add(Me.lblWRITE_DATA_DM_Err)
        Me.Controls.Add(Me.lblWRITE_DATA_DM)
        Me.Controls.Add(Me.lblREAD_DM_Err)
        Me.Controls.Add(Me.lblREAD_DM)
        Me.Controls.Add(Me.lblPLC_UNIT_Err)
        Me.Controls.Add(Me.lblPLC_NODE_Err)
        Me.Controls.Add(Me.lblPLC_UNIT)
        Me.Controls.Add(Me.lblPLC_NODE)
        Me.Controls.Add(Me.lblPLC_NET_Err)
        Me.Controls.Add(Me.lblPLC_NET)
        Me.Controls.Add(Me.lblSTAGE_CODE_Err)
        Me.Controls.Add(Me.lblSTAGE_CODE)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPLC_MST_Setting_AddEdit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "PLC MASTER SETTING"
        CType(Me.bsPROCESSMST, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsPAINT1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblSTAGE_CODE As System.Windows.Forms.Label
    Friend WithEvents lblSTAGE_CODE_Err As System.Windows.Forms.Label
    Friend WithEvents lblPLC_NET As System.Windows.Forms.Label
    Friend WithEvents lblPLC_NET_Err As System.Windows.Forms.Label
    Friend WithEvents lblPLC_NODE As System.Windows.Forms.Label
    Friend WithEvents lblPLC_UNIT As System.Windows.Forms.Label
    Friend WithEvents lblPLC_NODE_Err As System.Windows.Forms.Label
    Friend WithEvents lblPLC_UNIT_Err As System.Windows.Forms.Label
    Friend WithEvents lblREAD_DM As System.Windows.Forms.Label
    Friend WithEvents lblREAD_DM_Err As System.Windows.Forms.Label
    Friend WithEvents lblWRITE_DATA_DM As System.Windows.Forms.Label
    Friend WithEvents lblWRITE_DATA_DM_Err As System.Windows.Forms.Label
    Friend WithEvents lblWRITE_STATUS_DM As System.Windows.Forms.Label
    Friend WithEvents lblWRITE_STATUS_DM_Err As System.Windows.Forms.Label
    Friend WithEvents lblPLC_ONLINE_FLAG As System.Windows.Forms.Label
    Friend WithEvents lblPROCESS_NAME As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnExecution As System.Windows.Forms.Button
    Friend WithEvents txtSTAGE_CODE As System.Windows.Forms.TextBox
    Friend WithEvents txtPLC_NET As System.Windows.Forms.TextBox
    Friend WithEvents txtPLC_NODE As System.Windows.Forms.TextBox
    Friend WithEvents txtPLC_UNIT As System.Windows.Forms.TextBox
    Friend WithEvents txtREAD_DM As System.Windows.Forms.TextBox
    Friend WithEvents txtWRITE_DATA_DM As System.Windows.Forms.TextBox
    Friend WithEvents txtWRITE_STATUS_DM As System.Windows.Forms.TextBox
    Friend WithEvents cboPROCESS_NAME As System.Windows.Forms.ComboBox
    Friend WithEvents chkPLC_ONLINE_FLAG As System.Windows.Forms.CheckBox
    Friend WithEvents dsPAINT1 As Common.dsPAINT
    Friend WithEvents bsPROCESSMST As System.Windows.Forms.BindingSource
    Friend WithEvents taPROCESS_MST1 As taPROCESS_MST
    Friend WithEvents taPLC_MST1 As taPLC_MST
End Class
