<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOptionMST_Setting_AddEdit
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
        Me.btnNext = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnExecute = New System.Windows.Forms.Button
        Me.cboOptionType = New System.Windows.Forms.ComboBox
        Me.lblOptionType = New System.Windows.Forms.Label
        Me.lblDestination = New System.Windows.Forms.Label
        Me.txtDestination = New System.Windows.Forms.TextBox
        Me.pnlDestination = New System.Windows.Forms.Panel
        Me.lblDestinationError = New System.Windows.Forms.Label
        Me.lblName = New System.Windows.Forms.Label
        Me.lblCode = New System.Windows.Forms.Label
        Me.txtCode = New System.Windows.Forms.TextBox
        Me.lblDisplay = New System.Windows.Forms.Label
        Me.txtName = New System.Windows.Forms.TextBox
        Me.txtDisplay = New System.Windows.Forms.TextBox
        Me.lblNameError = New System.Windows.Forms.Label
        Me.lblDisplayError = New System.Windows.Forms.Label
        Me.pnlOption = New System.Windows.Forms.Panel
        Me.taOPTION_MST1 = New Common.dsPAINTTableAdapters.taOPTION_MST
        Me.dsPAINT1 = New Common.dsPAINT
        Me.pnlDestination.SuspendLayout()
        Me.pnlOption.SuspendLayout()
        CType(Me.dsPAINT1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(78, 249)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(84, 23)
        Me.btnNext.TabIndex = 0
        Me.btnNext.Text = "NEXT"
        Me.btnNext.UseVisualStyleBackColor = True
        Me.btnNext.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(214, 249)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "CANCEL"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnExecute
        '
        Me.btnExecute.Location = New System.Drawing.Point(78, 249)
        Me.btnExecute.Name = "btnExecute"
        Me.btnExecute.Size = New System.Drawing.Size(84, 23)
        Me.btnExecute.TabIndex = 8
        Me.btnExecute.Text = "EXECUTION"
        Me.btnExecute.UseVisualStyleBackColor = True
        Me.btnExecute.Visible = False
        '
        'cboOptionType
        '
        Me.cboOptionType.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar
        Me.cboOptionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOptionType.Items.AddRange(New Object() {"DESTINATION", "OPTION"})
        Me.cboOptionType.Location = New System.Drawing.Point(257, 10)
        Me.cboOptionType.Name = "cboOptionType"
        Me.cboOptionType.Size = New System.Drawing.Size(121, 21)
        Me.cboOptionType.TabIndex = 16
        '
        'lblOptionType
        '
        Me.lblOptionType.BackColor = System.Drawing.SystemColors.Control
        Me.lblOptionType.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOptionType.Location = New System.Drawing.Point(8, 9)
        Me.lblOptionType.Name = "lblOptionType"
        Me.lblOptionType.Size = New System.Drawing.Size(370, 24)
        Me.lblOptionType.TabIndex = 6
        Me.lblOptionType.Text = "OPTION TYPE"
        Me.lblOptionType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDestination
        '
        Me.lblDestination.BackColor = System.Drawing.SystemColors.Control
        Me.lblDestination.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDestination.Location = New System.Drawing.Point(2, 3)
        Me.lblDestination.Name = "lblDestination"
        Me.lblDestination.Size = New System.Drawing.Size(370, 24)
        Me.lblDestination.TabIndex = 11
        Me.lblDestination.Text = "DESTINATION"
        Me.lblDestination.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDestination
        '
        Me.txtDestination.Location = New System.Drawing.Point(249, 5)
        Me.txtDestination.MaxLength = 15
        Me.txtDestination.Name = "txtDestination"
        Me.txtDestination.Size = New System.Drawing.Size(121, 20)
        Me.txtDestination.TabIndex = 16
        '
        'pnlDestination
        '
        Me.pnlDestination.Controls.Add(Me.lblDestinationError)
        Me.pnlDestination.Controls.Add(Me.txtDestination)
        Me.pnlDestination.Controls.Add(Me.lblDestination)
        Me.pnlDestination.Location = New System.Drawing.Point(8, 52)
        Me.pnlDestination.Name = "pnlDestination"
        Me.pnlDestination.Size = New System.Drawing.Size(380, 55)
        Me.pnlDestination.TabIndex = 18
        Me.pnlDestination.Visible = False
        '
        'lblDestinationError
        '
        Me.lblDestinationError.AutoSize = True
        Me.lblDestinationError.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblDestinationError.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDestinationError.ForeColor = System.Drawing.Color.Red
        Me.lblDestinationError.Location = New System.Drawing.Point(0, 29)
        Me.lblDestinationError.Name = "lblDestinationError"
        Me.lblDestinationError.Size = New System.Drawing.Size(93, 16)
        Me.lblDestinationError.TabIndex = 21
        Me.lblDestinationError.Text = "Error Message"
        '
        'lblName
        '
        Me.lblName.BackColor = System.Drawing.SystemColors.Control
        Me.lblName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.Location = New System.Drawing.Point(2, 45)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(370, 24)
        Me.lblName.TabIndex = 11
        Me.lblName.Text = "NAME"
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCode
        '
        Me.lblCode.BackColor = System.Drawing.SystemColors.Control
        Me.lblCode.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCode.Location = New System.Drawing.Point(2, 2)
        Me.lblCode.Name = "lblCode"
        Me.lblCode.Size = New System.Drawing.Size(370, 24)
        Me.lblCode.TabIndex = 10
        Me.lblCode.Text = "CODE"
        Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(250, 3)
        Me.txtCode.MaxLength = 32
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(121, 20)
        Me.txtCode.TabIndex = 13
        '
        'lblDisplay
        '
        Me.lblDisplay.BackColor = System.Drawing.SystemColors.Control
        Me.lblDisplay.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDisplay.Location = New System.Drawing.Point(2, 90)
        Me.lblDisplay.Name = "lblDisplay"
        Me.lblDisplay.Size = New System.Drawing.Size(370, 24)
        Me.lblDisplay.TabIndex = 12
        Me.lblDisplay.Text = "DISPLAY"
        Me.lblDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(249, 47)
        Me.txtName.MaxLength = 15
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(121, 20)
        Me.txtName.TabIndex = 14
        '
        'txtDisplay
        '
        Me.txtDisplay.Location = New System.Drawing.Point(249, 92)
        Me.txtDisplay.MaxLength = 15
        Me.txtDisplay.Name = "txtDisplay"
        Me.txtDisplay.Size = New System.Drawing.Size(121, 20)
        Me.txtDisplay.TabIndex = 15
        '
        'lblNameError
        '
        Me.lblNameError.AutoSize = True
        Me.lblNameError.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNameError.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNameError.ForeColor = System.Drawing.Color.Red
        Me.lblNameError.Location = New System.Drawing.Point(0, 71)
        Me.lblNameError.Name = "lblNameError"
        Me.lblNameError.Size = New System.Drawing.Size(93, 16)
        Me.lblNameError.TabIndex = 23
        Me.lblNameError.Text = "Error Message"
        '
        'lblDisplayError
        '
        Me.lblDisplayError.AutoSize = True
        Me.lblDisplayError.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblDisplayError.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDisplayError.ForeColor = System.Drawing.Color.Red
        Me.lblDisplayError.Location = New System.Drawing.Point(0, 114)
        Me.lblDisplayError.Name = "lblDisplayError"
        Me.lblDisplayError.Size = New System.Drawing.Size(93, 16)
        Me.lblDisplayError.TabIndex = 24
        Me.lblDisplayError.Text = "Error Message"
        '
        'pnlOption
        '
        Me.pnlOption.Controls.Add(Me.lblDisplayError)
        Me.pnlOption.Controls.Add(Me.lblNameError)
        Me.pnlOption.Controls.Add(Me.txtDisplay)
        Me.pnlOption.Controls.Add(Me.txtName)
        Me.pnlOption.Controls.Add(Me.lblDisplay)
        Me.pnlOption.Controls.Add(Me.txtCode)
        Me.pnlOption.Controls.Add(Me.lblCode)
        Me.pnlOption.Controls.Add(Me.lblName)
        Me.pnlOption.Location = New System.Drawing.Point(8, 52)
        Me.pnlOption.Name = "pnlOption"
        Me.pnlOption.Size = New System.Drawing.Size(380, 135)
        Me.pnlOption.TabIndex = 17
        Me.pnlOption.Visible = False
        '
        'taOPTION_MST1
        '
        Me.taOPTION_MST1.ClearBeforeFill = True
        '
        'dsPAINT1
        '
        Me.dsPAINT1.DataSetName = "dsPAINT"
        Me.dsPAINT1.Locale = New System.Globalization.CultureInfo("th-TH")
        Me.dsPAINT1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'frmOptionMST_Setting_AddEdit
        '
        Me.AcceptButton = Me.btnExecute
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(392, 293)
        Me.Controls.Add(Me.pnlDestination)
        Me.Controls.Add(Me.pnlOption)
        Me.Controls.Add(Me.cboOptionType)
        Me.Controls.Add(Me.btnExecute)
        Me.Controls.Add(Me.lblOptionType)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnNext)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOptionMST_Setting_AddEdit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "OPTION MASTER SETTING"
        Me.pnlDestination.ResumeLayout(False)
        Me.pnlDestination.PerformLayout()
        Me.pnlOption.ResumeLayout(False)
        Me.pnlOption.PerformLayout()
        CType(Me.dsPAINT1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnExecute As System.Windows.Forms.Button
    Friend WithEvents cboOptionType As System.Windows.Forms.ComboBox
    Friend WithEvents lblOptionType As System.Windows.Forms.Label
    Friend WithEvents lblDestination As System.Windows.Forms.Label
    Friend WithEvents txtDestination As System.Windows.Forms.TextBox
    Friend WithEvents pnlDestination As System.Windows.Forms.Panel
    'Friend WithEvents taOPT_MST_COL_LENGTH1 As taOPT_MST_COL_LENGTH
    Friend WithEvents lblDestinationError As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplay As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtDisplay As System.Windows.Forms.TextBox
    Friend WithEvents lblNameError As System.Windows.Forms.Label
    Friend WithEvents lblDisplayError As System.Windows.Forms.Label
    Friend WithEvents pnlOption As System.Windows.Forms.Panel
    Friend WithEvents taOPTION_MST1 As taOPTION_MST
    Friend WithEvents dsPAINT1 As Common.dsPAINT
End Class
