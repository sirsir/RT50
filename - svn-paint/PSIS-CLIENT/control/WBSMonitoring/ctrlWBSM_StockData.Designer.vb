<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlWBSM_StockData
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
        Me.lblModelCode = New System.Windows.Forms.Label
        Me.lblLotNoUnitNo = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'lblModelCode
        '
        Me.lblModelCode.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblModelCode.Location = New System.Drawing.Point(0, 0)
        Me.lblModelCode.Margin = New System.Windows.Forms.Padding(0)
        Me.lblModelCode.Name = "lblModelCode"
        Me.lblModelCode.Size = New System.Drawing.Size(91, 20)
        Me.lblModelCode.TabIndex = 0
        Me.lblModelCode.Text = "000ABCDE"
        Me.lblModelCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLotNoUnitNo
        '
        Me.lblLotNoUnitNo.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblLotNoUnitNo.Location = New System.Drawing.Point(0, 20)
        Me.lblLotNoUnitNo.Margin = New System.Windows.Forms.Padding(0)
        Me.lblLotNoUnitNo.Name = "lblLotNoUnitNo"
        Me.lblLotNoUnitNo.Size = New System.Drawing.Size(91, 20)
        Me.lblLotNoUnitNo.TabIndex = 1
        Me.lblLotNoUnitNo.Text = "000 00"
        Me.lblLotNoUnitNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ctrlWBSM_StockData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.lblLotNoUnitNo)
        Me.Controls.Add(Me.lblModelCode)
        Me.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "ctrlWBSM_StockData"
        Me.Size = New System.Drawing.Size(91, 41)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblModelCode As System.Windows.Forms.Label
    Friend WithEvents lblLotNoUnitNo As System.Windows.Forms.Label

End Class
