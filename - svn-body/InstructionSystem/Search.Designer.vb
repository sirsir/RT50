<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Search
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
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txbModelCode = New System.Windows.Forms.TextBox
        Me.txbLotNo = New System.Windows.Forms.TextBox
        Me.txbBlock = New System.Windows.Forms.TextBox
        Me.btnExecution = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(22, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(222, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Please input the search condition."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(22, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "MODEL CODE *"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.Location = New System.Drawing.Point(22, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "LOT No."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label4.Location = New System.Drawing.Point(22, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 17)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "BLOCK"
        '
        'txbModelCode
        '
        Me.txbModelCode.Location = New System.Drawing.Point(168, 55)
        Me.txbModelCode.MaxLength = 8
        Me.txbModelCode.Name = "txbModelCode"
        Me.txbModelCode.Size = New System.Drawing.Size(148, 20)
        Me.txbModelCode.TabIndex = 4
        '
        'txbLotNo
        '
        Me.txbLotNo.Location = New System.Drawing.Point(168, 83)
        Me.txbLotNo.MaxLength = 3
        Me.txbLotNo.Name = "txbLotNo"
        Me.txbLotNo.Size = New System.Drawing.Size(148, 20)
        Me.txbLotNo.TabIndex = 5
        '
        'txbBlock
        '
        Me.txbBlock.Location = New System.Drawing.Point(168, 111)
        Me.txbBlock.MaxLength = 8
        Me.txbBlock.Name = "txbBlock"
        Me.txbBlock.Size = New System.Drawing.Size(148, 20)
        Me.txbBlock.TabIndex = 6
        '
        'btnExecution
        '
        Me.btnExecution.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnExecution.Location = New System.Drawing.Point(239, 171)
        Me.btnExecution.Name = "btnExecution"
        Me.btnExecution.Size = New System.Drawing.Size(106, 29)
        Me.btnExecution.TabIndex = 7
        Me.btnExecution.Text = "F1:Execution"
        Me.btnExecution.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(366, 171)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(106, 29)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "F12:CANCEL"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Search
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(494, 218)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnExecution)
        Me.Controls.Add(Me.txbBlock)
        Me.Controls.Add(Me.txbLotNo)
        Me.Controls.Add(Me.txbModelCode)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(500, 250)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(500, 250)
        Me.Name = "Search"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Search Condition"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txbModelCode As System.Windows.Forms.TextBox
    Friend WithEvents txbLotNo As System.Windows.Forms.TextBox
    Friend WithEvents txbBlock As System.Windows.Forms.TextBox
    Friend WithEvents btnExecution As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
