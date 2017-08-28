<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        Me.btnExecute = New System.Windows.Forms.Button
        Me.dsPAINT1 = New Common.dsPAINT
        Me.txtStatusAll = New System.Windows.Forms.TextBox
        Me.btnSetStatus = New System.Windows.Forms.Button
        Me.lblStatusAll = New System.Windows.Forms.Label
        CType(Me.dsPAINT1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(12, 45)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(829, 338)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'btnExecute
        '
        Me.btnExecute.Location = New System.Drawing.Point(228, 13)
        Me.btnExecute.Name = "btnExecute"
        Me.btnExecute.Size = New System.Drawing.Size(75, 23)
        Me.btnExecute.TabIndex = 1
        Me.btnExecute.Text = "&Execute All"
        Me.btnExecute.UseVisualStyleBackColor = True
        '
        'dsPAINT1
        '
        Me.dsPAINT1.DataSetName = "dsPAINT"
        Me.dsPAINT1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'txtStatusAll
        '
        Me.txtStatusAll.Location = New System.Drawing.Point(79, 15)
        Me.txtStatusAll.Name = "txtStatusAll"
        Me.txtStatusAll.Size = New System.Drawing.Size(29, 20)
        Me.txtStatusAll.TabIndex = 2
        '
        'btnSetStatus
        '
        Me.btnSetStatus.Location = New System.Drawing.Point(114, 13)
        Me.btnSetStatus.Name = "btnSetStatus"
        Me.btnSetStatus.Size = New System.Drawing.Size(82, 23)
        Me.btnSetStatus.TabIndex = 3
        Me.btnSetStatus.Text = "&Set Status All"
        Me.btnSetStatus.UseVisualStyleBackColor = True
        '
        'lblStatusAll
        '
        Me.lblStatusAll.AutoSize = True
        Me.lblStatusAll.Location = New System.Drawing.Point(36, 18)
        Me.lblStatusAll.Name = "lblStatusAll"
        Me.lblStatusAll.Size = New System.Drawing.Size(37, 13)
        Me.lblStatusAll.TabIndex = 4
        Me.lblStatusAll.Text = "Status"
        '
        'Form1
        '
        Me.AcceptButton = Me.btnExecute
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(853, 395)
        Me.Controls.Add(Me.lblStatusAll)
        Me.Controls.Add(Me.btnSetStatus)
        Me.Controls.Add(Me.txtStatusAll)
        Me.Controls.Add(Me.btnExecute)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.KeyPreview = True
        Me.Name = "Form1"
        Me.Text = "PLC Communication Simulator"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dsPAINT1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnExecute As System.Windows.Forms.Button
    Friend WithEvents dsPAINT1 As Common.dsPAINT
    Friend WithEvents txtStatusAll As System.Windows.Forms.TextBox
    Friend WithEvents btnSetStatus As System.Windows.Forms.Button
    Friend WithEvents lblStatusAll As System.Windows.Forms.Label

End Class
