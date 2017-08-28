<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LineType
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
        Me.rdobCAB = New System.Windows.Forms.RadioButton
        Me.rdobPUBX = New System.Windows.Forms.RadioButton
        Me.btnSelect = New System.Windows.Forms.Button
        Me.lblLineName = New System.Windows.Forms.Label
        Me.lblLineCode = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'rdobCAB
        '
        Me.rdobCAB.AutoSize = True
        Me.rdobCAB.Location = New System.Drawing.Point(51, 28)
        Me.rdobCAB.Name = "rdobCAB"
        Me.rdobCAB.Size = New System.Drawing.Size(46, 17)
        Me.rdobCAB.TabIndex = 0
        Me.rdobCAB.TabStop = True
        Me.rdobCAB.Text = "CAB"
        Me.rdobCAB.UseVisualStyleBackColor = True
        '
        'rdobPUBX
        '
        Me.rdobPUBX.AutoSize = True
        Me.rdobPUBX.Location = New System.Drawing.Point(152, 28)
        Me.rdobPUBX.Name = "rdobPUBX"
        Me.rdobPUBX.Size = New System.Drawing.Size(54, 17)
        Me.rdobPUBX.TabIndex = 1
        Me.rdobPUBX.TabStop = True
        Me.rdobPUBX.Text = "PUBX"
        Me.rdobPUBX.UseVisualStyleBackColor = True
        '
        'btnSelect
        '
        Me.btnSelect.Location = New System.Drawing.Point(118, 129)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(75, 23)
        Me.btnSelect.TabIndex = 2
        Me.btnSelect.Text = "SELECT"
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'lblLineName
        '
        Me.lblLineName.AutoSize = True
        Me.lblLineName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLineName.Location = New System.Drawing.Point(162, 21)
        Me.lblLineName.Name = "lblLineName"
        Me.lblLineName.Size = New System.Drawing.Size(66, 16)
        Me.lblLineName.TabIndex = 4
        Me.lblLineName.Text = "lineName"
        '
        'lblLineCode
        '
        Me.lblLineCode.AutoSize = True
        Me.lblLineCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLineCode.Location = New System.Drawing.Point(78, 21)
        Me.lblLineCode.Name = "lblLineCode"
        Me.lblLineCode.Size = New System.Drawing.Size(62, 16)
        Me.lblLineCode.TabIndex = 5
        Me.lblLineCode.Text = "lineCode"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(27, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 16)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Line"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdobCAB)
        Me.GroupBox1.Controls.Add(Me.rdobPUBX)
        Me.GroupBox1.Location = New System.Drawing.Point(30, 54)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(251, 60)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        '
        'LineType
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(316, 164)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblLineCode)
        Me.Controls.Add(Me.lblLineName)
        Me.Controls.Add(Me.btnSelect)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "LineType"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select LineType"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rdobCAB As System.Windows.Forms.RadioButton
    Friend WithEvents rdobPUBX As System.Windows.Forms.RadioButton
    Friend WithEvents btnSelect As System.Windows.Forms.Button
    Friend WithEvents lblLineName As System.Windows.Forms.Label
    Friend WithEvents lblLineCode As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
