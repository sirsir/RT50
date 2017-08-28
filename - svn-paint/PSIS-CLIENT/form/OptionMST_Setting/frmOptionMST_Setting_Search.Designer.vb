<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOptionMST_Setting_Search
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
        Me.lblOptionDisplay = New System.Windows.Forms.Label
        Me.txtOptDisplay = New System.Windows.Forms.TextBox
        Me.lblMsg = New System.Windows.Forms.Label
        Me.btnExecution = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.dsPAINT1 = New Common.dsPAINT
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
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Please input the search condition."
        '
        'lblOptionDisplay
        '
        Me.lblOptionDisplay.BackColor = System.Drawing.SystemColors.Control
        Me.lblOptionDisplay.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOptionDisplay.Location = New System.Drawing.Point(25, 53)
        Me.lblOptionDisplay.Name = "lblOptionDisplay"
        Me.lblOptionDisplay.Size = New System.Drawing.Size(357, 24)
        Me.lblOptionDisplay.TabIndex = 5
        Me.lblOptionDisplay.Text = "Option Display"
        Me.lblOptionDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtOptDisplay
        '
        Me.txtOptDisplay.Location = New System.Drawing.Point(180, 54)
        Me.txtOptDisplay.Name = "txtOptDisplay"
        Me.txtOptDisplay.Size = New System.Drawing.Size(200, 22)
        Me.txtOptDisplay.TabIndex = 6
        '
        'lblMsg
        '
        Me.lblMsg.AutoSize = True
        Me.lblMsg.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsg.ForeColor = System.Drawing.Color.Red
        Me.lblMsg.Location = New System.Drawing.Point(25, 77)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(129, 16)
        Me.lblMsg.TabIndex = 7
        Me.lblMsg.Text = "Notification Message"
        '
        'btnExecution
        '
        Me.btnExecution.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExecution.Location = New System.Drawing.Point(72, 107)
        Me.btnExecution.Name = "btnExecution"
        Me.btnExecution.Size = New System.Drawing.Size(106, 29)
        Me.btnExecution.TabIndex = 8
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
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "CANCEL"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'dsPAINT1
        '
        Me.dsPAINT1.DataSetName = "dsPAINT"
        Me.dsPAINT1.Locale = New System.Globalization.CultureInfo("th-TH")
        Me.dsPAINT1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'frmOptionMST_Setting_Search
        '
        Me.AcceptButton = Me.btnExecution
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(394, 146)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnExecution)
        Me.Controls.Add(Me.lblMsg)
        Me.Controls.Add(Me.txtOptDisplay)
        Me.Controls.Add(Me.lblOptionDisplay)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOptionMST_Setting_Search"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Search Condition"
        CType(Me.dsPAINT1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblOptionDisplay As System.Windows.Forms.Label
    Friend WithEvents txtOptDisplay As System.Windows.Forms.TextBox
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents btnExecution As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents dsPAINT1 As Common.dsPAINT
End Class
