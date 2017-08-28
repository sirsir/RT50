<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProcessMaster_EditLink
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
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnExecute = New System.Windows.Forms.Button
        Me.lblCurrProc = New System.Windows.Forms.Label
        Me.txtProcName = New System.Windows.Forms.TextBox
        Me.dsPAINT1 = New Common.dsPAINT
        Me.taPROCESS_MST1 = New Common.dsPAINTTableAdapters.taPROCESS_MST
        Me.lsbAllProc = New System.Windows.Forms.ListBox
        Me.bsPROCESSMST = New System.Windows.Forms.BindingSource(Me.components)
        Me.lblAllProc = New System.Windows.Forms.Label
        Me.btnRight = New System.Windows.Forms.Button
        Me.btnLeft = New System.Windows.Forms.Button
        Me.pboRightArrow = New System.Windows.Forms.PictureBox
        Me.lblPrevProc = New System.Windows.Forms.Label
        Me.taPROCESS_LINKAGE1 = New Common.dsPAINTTableAdapters.taPROCESS_LINKAGE
        Me.lsbPrevProc = New System.Windows.Forms.ListBox
        Me.bsPROCESSLINKAGE = New System.Windows.Forms.BindingSource(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        CType(Me.dsPAINT1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsPROCESSMST, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pboRightArrow, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsPROCESSLINKAGE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(418, 180)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(106, 29)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "CANCEL"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnExecute
        '
        Me.btnExecute.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnExecute.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExecute.Location = New System.Drawing.Point(280, 180)
        Me.btnExecute.Name = "btnExecute"
        Me.btnExecute.Size = New System.Drawing.Size(106, 29)
        Me.btnExecute.TabIndex = 4
        Me.btnExecute.Text = "EXECUTION"
        Me.btnExecute.UseVisualStyleBackColor = True
        '
        'lblCurrProc
        '
        Me.lblCurrProc.BackColor = System.Drawing.SystemColors.Control
        Me.lblCurrProc.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrProc.Location = New System.Drawing.Point(320, 18)
        Me.lblCurrProc.Name = "lblCurrProc"
        Me.lblCurrProc.Size = New System.Drawing.Size(204, 120)
        Me.lblCurrProc.TabIndex = 6
        Me.lblCurrProc.Text = "Current Process"
        Me.lblCurrProc.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtProcName
        '
        Me.txtProcName.BackColor = System.Drawing.SystemColors.Window
        Me.txtProcName.Location = New System.Drawing.Point(322, 73)
        Me.txtProcName.Name = "txtProcName"
        Me.txtProcName.ReadOnly = True
        Me.txtProcName.Size = New System.Drawing.Size(200, 22)
        Me.txtProcName.TabIndex = 1
        Me.txtProcName.TabStop = False
        Me.txtProcName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dsPAINT1
        '
        Me.dsPAINT1.DataSetName = "dsPAINT"
        Me.dsPAINT1.Locale = New System.Globalization.CultureInfo("th-TH")
        Me.dsPAINT1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'taPROCESS_MST1
        '
        Me.taPROCESS_MST1.ClearBeforeFill = True
        '
        'lsbAllProc
        '
        Me.lsbAllProc.DataSource = Me.bsPROCESSMST
        Me.lsbAllProc.DisplayMember = "PROCESS_NAME"
        Me.lsbAllProc.FormattingEnabled = True
        Me.lsbAllProc.ItemHeight = 16
        Me.lsbAllProc.Location = New System.Drawing.Point(14, 48)
        Me.lsbAllProc.Name = "lsbAllProc"
        Me.lsbAllProc.Size = New System.Drawing.Size(200, 100)
        Me.lsbAllProc.TabIndex = 0
        Me.lsbAllProc.ValueMember = "PROCESS_NO"
        '
        'bsPROCESSMST
        '
        Me.bsPROCESSMST.AllowNew = True
        Me.bsPROCESSMST.DataMember = "dtPROCESS_MST"
        Me.bsPROCESSMST.DataSource = Me.dsPAINT1
        Me.bsPROCESSMST.Sort = "PROCESS_TYPE, PROCESS_NO, ENTRANCE_FLAG DESC"
        '
        'lblAllProc
        '
        Me.lblAllProc.BackColor = System.Drawing.SystemColors.Control
        Me.lblAllProc.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAllProc.Location = New System.Drawing.Point(12, 28)
        Me.lblAllProc.Name = "lblAllProc"
        Me.lblAllProc.Size = New System.Drawing.Size(204, 122)
        Me.lblAllProc.TabIndex = 14
        Me.lblAllProc.Text = "All Process"
        Me.lblAllProc.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnRight
        '
        Me.btnRight.Location = New System.Drawing.Point(220, 58)
        Me.btnRight.Name = "btnRight"
        Me.btnRight.Size = New System.Drawing.Size(35, 35)
        Me.btnRight.TabIndex = 1
        Me.btnRight.Text = ">"
        Me.btnRight.UseVisualStyleBackColor = True
        '
        'btnLeft
        '
        Me.btnLeft.Location = New System.Drawing.Point(220, 103)
        Me.btnLeft.Name = "btnLeft"
        Me.btnLeft.Size = New System.Drawing.Size(35, 35)
        Me.btnLeft.TabIndex = 3
        Me.btnLeft.Text = "<"
        Me.btnLeft.UseVisualStyleBackColor = True
        '
        'pboRightArrow
        '
        Me.pboRightArrow.Image = Global.PSIS_CLIENT.My.Resources.Resources.right_arrow
        Me.pboRightArrow.Location = New System.Drawing.Point(214, 38)
        Me.pboRightArrow.Name = "pboRightArrow"
        Me.pboRightArrow.Size = New System.Drawing.Size(100, 100)
        Me.pboRightArrow.TabIndex = 18
        Me.pboRightArrow.TabStop = False
        '
        'lblPrevProc
        '
        Me.lblPrevProc.BackColor = System.Drawing.SystemColors.Control
        Me.lblPrevProc.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrevProc.Location = New System.Drawing.Point(6, 18)
        Me.lblPrevProc.Name = "lblPrevProc"
        Me.lblPrevProc.Size = New System.Drawing.Size(204, 122)
        Me.lblPrevProc.TabIndex = 19
        Me.lblPrevProc.Text = "Previous Process"
        Me.lblPrevProc.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'taPROCESS_LINKAGE1
        '
        Me.taPROCESS_LINKAGE1.ClearBeforeFill = True
        '
        'lsbPrevProc
        '
        Me.lsbPrevProc.DataSource = Me.bsPROCESSLINKAGE
        Me.lsbPrevProc.DisplayMember = "FROM_PROCESS_NAME"
        Me.lsbPrevProc.FormattingEnabled = True
        Me.lsbPrevProc.ItemHeight = 16
        Me.lsbPrevProc.Location = New System.Drawing.Point(8, 38)
        Me.lsbPrevProc.Name = "lsbPrevProc"
        Me.lsbPrevProc.Size = New System.Drawing.Size(200, 100)
        Me.lsbPrevProc.TabIndex = 2
        Me.lsbPrevProc.ValueMember = "FROM_PROCESS_NO"
        '
        'bsPROCESSLINKAGE
        '
        Me.bsPROCESSLINKAGE.DataMember = "dtPROCESS_LINKAGE"
        Me.bsPROCESSLINKAGE.DataSource = Me.dsPAINT1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.pboRightArrow)
        Me.GroupBox1.Controls.Add(Me.txtProcName)
        Me.GroupBox1.Controls.Add(Me.lsbPrevProc)
        Me.GroupBox1.Controls.Add(Me.lblPrevProc)
        Me.GroupBox1.Controls.Add(Me.lblCurrProc)
        Me.GroupBox1.Location = New System.Drawing.Point(261, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(530, 145)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        '
        'frmProcessMaster_EditLink
        '
        Me.AcceptButton = Me.btnExecute
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(804, 226)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnLeft)
        Me.Controls.Add(Me.btnRight)
        Me.Controls.Add(Me.lsbAllProc)
        Me.Controls.Add(Me.lblAllProc)
        Me.Controls.Add(Me.btnExecute)
        Me.Controls.Add(Me.btnCancel)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmProcessMaster_EditLink"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "EDIT {0} PREVIOUS PROCESS"
        CType(Me.dsPAINT1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsPROCESSMST, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pboRightArrow, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsPROCESSLINKAGE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnExecute As System.Windows.Forms.Button
    Friend WithEvents dsPAINT1 As Common.dsPAINT
    Friend WithEvents lblCurrProc As System.Windows.Forms.Label
    Friend WithEvents txtProcName As System.Windows.Forms.TextBox
    Friend WithEvents taPROCESS_MST1 As taPROCESS_MST
    Friend WithEvents lsbAllProc As System.Windows.Forms.ListBox
    Friend WithEvents lblAllProc As System.Windows.Forms.Label
    Friend WithEvents btnRight As System.Windows.Forms.Button
    Friend WithEvents btnLeft As System.Windows.Forms.Button
    Friend WithEvents pboRightArrow As System.Windows.Forms.PictureBox
    Friend WithEvents lblPrevProc As System.Windows.Forms.Label
    Friend WithEvents taPROCESS_LINKAGE1 As taPROCESS_LINKAGE
    Friend WithEvents lsbPrevProc As System.Windows.Forms.ListBox
    Friend WithEvents bsPROCESSMST As System.Windows.Forms.BindingSource
    Friend WithEvents bsPROCESSLINKAGE As System.Windows.Forms.BindingSource
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
