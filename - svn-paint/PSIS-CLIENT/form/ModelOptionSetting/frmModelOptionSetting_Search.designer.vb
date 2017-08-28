<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModelOptionSetting_Search
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblModelCode = New System.Windows.Forms.Label
        Me.btnExecution = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.lblMsg = New System.Windows.Forms.Label
        Me.dsPAINT1 = New Common.dsPAINT
        Me.mtbModelCode = New System.Windows.Forms.MaskedTextBox
        CType(Me.dsPAINT1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(22, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(205, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Please input the search condition."
        '
        'lblModelCode
        '
        Me.lblModelCode.BackColor = System.Drawing.SystemColors.Control
        Me.lblModelCode.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModelCode.Location = New System.Drawing.Point(25, 53)
        Me.lblModelCode.Name = "lblModelCode"
        Me.lblModelCode.Size = New System.Drawing.Size(293, 24)
        Me.lblModelCode.TabIndex = 4
        Me.lblModelCode.Text = "Model Code "
        Me.lblModelCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnExecution
        '
        Me.btnExecution.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExecution.Location = New System.Drawing.Point(72, 107)
        Me.btnExecution.Name = "btnExecution"
        Me.btnExecution.Size = New System.Drawing.Size(106, 29)
        Me.btnExecution.TabIndex = 1
        Me.btnExecution.Text = "EXECUTION"
        Me.btnExecution.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(210, 107)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(106, 29)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "CANCEL"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lblMsg
        '
        Me.lblMsg.AutoSize = True
        Me.lblMsg.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsg.ForeColor = System.Drawing.Color.Red
        Me.lblMsg.Location = New System.Drawing.Point(25, 77)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(129, 16)
        Me.lblMsg.TabIndex = 5
        Me.lblMsg.Text = "Notification Message"
        '
        'dsPAINT1
        '
        Me.dsPAINT1.DataSetName = "dsPAINT"
        Me.dsPAINT1.Locale = New System.Globalization.CultureInfo("th-TH")
        Me.dsPAINT1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'mtbModelCode
        '
        Me.mtbModelCode.Location = New System.Drawing.Point(216, 54)
        Me.mtbModelCode.Mask = "000AAA*A"
        Me.mtbModelCode.Name = "mtbModelCode"
        Me.mtbModelCode.Size = New System.Drawing.Size(100, 22)
        Me.mtbModelCode.TabIndex = 0
        '
        'frmModelOptionSetting_Search
        '
        Me.AcceptButton = Me.btnExecution
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(394, 146)
        Me.Controls.Add(Me.mtbModelCode)
        Me.Controls.Add(Me.lblMsg)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnExecution)
        Me.Controls.Add(Me.lblModelCode)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmModelOptionSetting_Search"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Search Condition"
        CType(Me.dsPAINT1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblModelCode As System.Windows.Forms.Label
    Friend WithEvents btnExecution As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents dsPAINT1 As Common.dsPAINT
    Friend WithEvents mtbModelCode As System.Windows.Forms.MaskedTextBox
End Class
