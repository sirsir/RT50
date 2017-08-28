<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlDBStatus
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        Me.oshFailStatus = New Microsoft.VisualBasic.PowerPacks.OvalShape
        Me.oshSuccessStatus = New Microsoft.VisualBasic.PowerPacks.OvalShape
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape1, Me.oshFailStatus, Me.oshSuccessStatus})
        Me.ShapeContainer1.Size = New System.Drawing.Size(176, 53)
        Me.ShapeContainer1.TabIndex = 0
        Me.ShapeContainer1.TabStop = False
        '
        'RectangleShape1
        '
        Me.RectangleShape1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RectangleShape1.Location = New System.Drawing.Point(4, 2)
        Me.RectangleShape1.Name = "RectangleShape1"
        Me.RectangleShape1.Size = New System.Drawing.Size(169, 49)
        '
        'oshFailStatus
        '
        Me.oshFailStatus.AccessibleName = ""
        Me.oshFailStatus.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.oshFailStatus.BackColor = System.Drawing.SystemColors.Control
        Me.oshFailStatus.FillColor = System.Drawing.Color.Red
        Me.oshFailStatus.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.oshFailStatus.Location = New System.Drawing.Point(127, 5)
        Me.oshFailStatus.Name = "oshFailStatus"
        Me.oshFailStatus.Size = New System.Drawing.Size(42, 42)
        '
        'oshSuccessStatus
        '
        Me.oshSuccessStatus.AccessibleName = ""
        Me.oshSuccessStatus.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.oshSuccessStatus.BackColor = System.Drawing.SystemColors.Control
        Me.oshSuccessStatus.FillColor = System.Drawing.Color.DarkGray
        Me.oshSuccessStatus.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.oshSuccessStatus.Location = New System.Drawing.Point(78, 5)
        Me.oshSuccessStatus.Name = "oshSuccessStatus"
        Me.oshSuccessStatus.Size = New System.Drawing.Size(42, 42)
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "DB Status"
        '
        'ctrlDBStatus
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Name = "ctrlDBStatus"
        Me.Size = New System.Drawing.Size(176, 53)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents oshSuccessStatus As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents oshFailStatus As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape

End Class
