<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlProcGroup
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
        Me.flpProcess = New System.Windows.Forms.FlowLayoutPanel
        Me.taPROCESS_MST1 = New Common.dsPAINTTableAdapters.taPROCESS_MST
        Me.taPROCESS_GROUP_MST1 = New Common.dsPAINTTableAdapters.taPROCESS_GROUP_MST
        Me.dsPAINT1 = New Common.dsPAINT
        Me.ctrlGroup = New PSIS_CLIENT.ctrlProcess
        CType(Me.dsPAINT1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'flpProcess
        '
        Me.flpProcess.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flpProcess.AutoScroll = True
        Me.flpProcess.BackColor = System.Drawing.Color.Gold
        Me.flpProcess.Location = New System.Drawing.Point(3, 41)
        Me.flpProcess.Name = "flpProcess"
        Me.flpProcess.Size = New System.Drawing.Size(212, 452)
        Me.flpProcess.TabIndex = 1
        '
        'taPROCESS_MST1
        '
        Me.taPROCESS_MST1.ClearBeforeFill = True
        '
        'taPROCESS_GROUP_MST1
        '
        Me.taPROCESS_GROUP_MST1.ClearBeforeFill = True
        '
        'dsPAINT1
        '
        Me.dsPAINT1.DataSetName = "dsPAINT"
        Me.dsPAINT1.Locale = New System.Globalization.CultureInfo("th-TH")
        Me.dsPAINT1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ctrlGroup
        '
        Me.ctrlGroup.BackColor = System.Drawing.Color.MistyRose
        Me.ctrlGroup.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ctrlGroup.Location = New System.Drawing.Point(-31, 9)
        Me.ctrlGroup.Name = "ctrlGroup"
        Me.ctrlGroup.Size = New System.Drawing.Size(188, 26)
        Me.ctrlGroup.TabIndex = 0
        '
        'ctrlProcGroup
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.ctrlGroup)
        Me.Controls.Add(Me.flpProcess)
        Me.Name = "ctrlProcGroup"
        Me.Size = New System.Drawing.Size(218, 500)
        CType(Me.dsPAINT1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents taPROCESS_MST1 As Common.dsPAINTTableAdapters.taPROCESS_MST
    Friend WithEvents taPROCESS_GROUP_MST1 As Common.dsPAINTTableAdapters.taPROCESS_GROUP_MST
    Friend WithEvents dsPAINT1 As Common.dsPAINT
    Friend WithEvents flpProcess As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents ctrlGroup As PSIS_CLIENT.ctrlProcess

End Class
