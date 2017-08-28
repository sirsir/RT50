<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlWBSMonitoring
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
        Me.components = New System.ComponentModel.Container
        Me.lblHeader1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        Me.lblQueueHeader1 = New System.Windows.Forms.Label
        Me.lblQueueHeader2 = New System.Windows.Forms.Label
        Me.lblQueueHeader3 = New System.Windows.Forms.Label
        Me.lblQueueHeader4 = New System.Windows.Forms.Label
        Me.lblQueueHeader5 = New System.Windows.Forms.Label
        Me.lblQueueHeader6 = New System.Windows.Forms.Label
        Me.lblQueueHeader7 = New System.Windows.Forms.Label
        Me.lblQueueHeader8 = New System.Windows.Forms.Label
        Me.lblQueueHeader9 = New System.Windows.Forms.Label
        Me.lblQueueHeader10 = New System.Windows.Forms.Label
        Me.lblQueueHeader0 = New System.Windows.Forms.Label
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel
        Me.dsPAINT1 = New Common.dsPAINT
        Me.taLANE_MST1 = New Common.dsPAINTTableAdapters.taLANE_MST
        Me.lblLotNoUnitNo = New System.Windows.Forms.Label
        Me.lblModelCode = New System.Windows.Forms.Label
        Me.CtrlBtnsOperator1 = New PSIS_CLIENT.ctrlBtnsOperator
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.taWbsOn1 = New Common.dsPAINTTableAdapters.taWBS_ON
        Me.taSKIT_MST1 = New Common.dsPAINTTableAdapters.taSKIT_MST
        Me.FlowLayoutPanel2.SuspendLayout()
        CType(Me.dsPAINT1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblHeader1
        '
        Me.lblHeader1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblHeader1.BackColor = System.Drawing.Color.Blue
        Me.lblHeader1.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader1.Location = New System.Drawing.Point(0, 0)
        Me.lblHeader1.Name = "lblHeader1"
        Me.lblHeader1.Size = New System.Drawing.Size(1014, 62)
        Me.lblHeader1.TabIndex = 1
        Me.lblHeader1.Text = "WBS STOCK DATA"
        Me.lblHeader1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button1
        '
        Me.Button1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(131, 197)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(0, 416)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(6, 105)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(1005, 422)
        Me.FlowLayoutPanel1.TabIndex = 3
        '
        'lblQueueHeader1
        '
        Me.lblQueueHeader1.BackColor = System.Drawing.Color.Yellow
        Me.lblQueueHeader1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblQueueHeader1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQueueHeader1.Location = New System.Drawing.Point(65, 0)
        Me.lblQueueHeader1.Margin = New System.Windows.Forms.Padding(0)
        Me.lblQueueHeader1.Name = "lblQueueHeader1"
        Me.lblQueueHeader1.Size = New System.Drawing.Size(91, 15)
        Me.lblQueueHeader1.TabIndex = 5
        Me.lblQueueHeader1.Text = "1"
        Me.lblQueueHeader1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblQueueHeader2
        '
        Me.lblQueueHeader2.BackColor = System.Drawing.Color.Yellow
        Me.lblQueueHeader2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblQueueHeader2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQueueHeader2.Location = New System.Drawing.Point(156, 0)
        Me.lblQueueHeader2.Margin = New System.Windows.Forms.Padding(0)
        Me.lblQueueHeader2.Name = "lblQueueHeader2"
        Me.lblQueueHeader2.Size = New System.Drawing.Size(91, 15)
        Me.lblQueueHeader2.TabIndex = 6
        Me.lblQueueHeader2.Text = "2"
        Me.lblQueueHeader2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblQueueHeader3
        '
        Me.lblQueueHeader3.BackColor = System.Drawing.Color.Yellow
        Me.lblQueueHeader3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblQueueHeader3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQueueHeader3.Location = New System.Drawing.Point(247, 0)
        Me.lblQueueHeader3.Margin = New System.Windows.Forms.Padding(0)
        Me.lblQueueHeader3.Name = "lblQueueHeader3"
        Me.lblQueueHeader3.Size = New System.Drawing.Size(91, 15)
        Me.lblQueueHeader3.TabIndex = 7
        Me.lblQueueHeader3.Text = "3"
        Me.lblQueueHeader3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblQueueHeader4
        '
        Me.lblQueueHeader4.BackColor = System.Drawing.Color.Yellow
        Me.lblQueueHeader4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblQueueHeader4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQueueHeader4.Location = New System.Drawing.Point(338, 0)
        Me.lblQueueHeader4.Margin = New System.Windows.Forms.Padding(0)
        Me.lblQueueHeader4.Name = "lblQueueHeader4"
        Me.lblQueueHeader4.Size = New System.Drawing.Size(91, 15)
        Me.lblQueueHeader4.TabIndex = 8
        Me.lblQueueHeader4.Text = "4"
        Me.lblQueueHeader4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblQueueHeader5
        '
        Me.lblQueueHeader5.BackColor = System.Drawing.Color.Yellow
        Me.lblQueueHeader5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblQueueHeader5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQueueHeader5.Location = New System.Drawing.Point(429, 0)
        Me.lblQueueHeader5.Margin = New System.Windows.Forms.Padding(0)
        Me.lblQueueHeader5.Name = "lblQueueHeader5"
        Me.lblQueueHeader5.Size = New System.Drawing.Size(91, 15)
        Me.lblQueueHeader5.TabIndex = 9
        Me.lblQueueHeader5.Text = "5"
        Me.lblQueueHeader5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblQueueHeader6
        '
        Me.lblQueueHeader6.BackColor = System.Drawing.Color.Yellow
        Me.lblQueueHeader6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblQueueHeader6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQueueHeader6.Location = New System.Drawing.Point(520, 0)
        Me.lblQueueHeader6.Margin = New System.Windows.Forms.Padding(0)
        Me.lblQueueHeader6.Name = "lblQueueHeader6"
        Me.lblQueueHeader6.Size = New System.Drawing.Size(91, 15)
        Me.lblQueueHeader6.TabIndex = 10
        Me.lblQueueHeader6.Text = "6"
        Me.lblQueueHeader6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblQueueHeader7
        '
        Me.lblQueueHeader7.BackColor = System.Drawing.Color.Yellow
        Me.lblQueueHeader7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblQueueHeader7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQueueHeader7.Location = New System.Drawing.Point(611, 0)
        Me.lblQueueHeader7.Margin = New System.Windows.Forms.Padding(0)
        Me.lblQueueHeader7.Name = "lblQueueHeader7"
        Me.lblQueueHeader7.Size = New System.Drawing.Size(91, 15)
        Me.lblQueueHeader7.TabIndex = 11
        Me.lblQueueHeader7.Text = "7"
        Me.lblQueueHeader7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblQueueHeader8
        '
        Me.lblQueueHeader8.BackColor = System.Drawing.Color.Yellow
        Me.lblQueueHeader8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblQueueHeader8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQueueHeader8.Location = New System.Drawing.Point(702, 0)
        Me.lblQueueHeader8.Margin = New System.Windows.Forms.Padding(0)
        Me.lblQueueHeader8.Name = "lblQueueHeader8"
        Me.lblQueueHeader8.Size = New System.Drawing.Size(91, 15)
        Me.lblQueueHeader8.TabIndex = 12
        Me.lblQueueHeader8.Text = "8"
        Me.lblQueueHeader8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblQueueHeader9
        '
        Me.lblQueueHeader9.BackColor = System.Drawing.Color.Yellow
        Me.lblQueueHeader9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblQueueHeader9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQueueHeader9.Location = New System.Drawing.Point(793, 0)
        Me.lblQueueHeader9.Margin = New System.Windows.Forms.Padding(0)
        Me.lblQueueHeader9.Name = "lblQueueHeader9"
        Me.lblQueueHeader9.Size = New System.Drawing.Size(91, 15)
        Me.lblQueueHeader9.TabIndex = 13
        Me.lblQueueHeader9.Text = "9"
        Me.lblQueueHeader9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblQueueHeader10
        '
        Me.lblQueueHeader10.BackColor = System.Drawing.Color.Yellow
        Me.lblQueueHeader10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblQueueHeader10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQueueHeader10.Location = New System.Drawing.Point(884, 0)
        Me.lblQueueHeader10.Margin = New System.Windows.Forms.Padding(0)
        Me.lblQueueHeader10.Name = "lblQueueHeader10"
        Me.lblQueueHeader10.Size = New System.Drawing.Size(91, 15)
        Me.lblQueueHeader10.TabIndex = 14
        Me.lblQueueHeader10.Text = "10"
        Me.lblQueueHeader10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblQueueHeader0
        '
        Me.lblQueueHeader0.BackColor = System.Drawing.SystemColors.Control
        Me.lblQueueHeader0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblQueueHeader0.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQueueHeader0.Location = New System.Drawing.Point(0, 0)
        Me.lblQueueHeader0.Margin = New System.Windows.Forms.Padding(0)
        Me.lblQueueHeader0.Name = "lblQueueHeader0"
        Me.lblQueueHeader0.Size = New System.Drawing.Size(65, 15)
        Me.lblQueueHeader0.TabIndex = 4
        Me.lblQueueHeader0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.AutoSize = True
        Me.FlowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel2.Controls.Add(Me.lblQueueHeader0)
        Me.FlowLayoutPanel2.Controls.Add(Me.lblQueueHeader1)
        Me.FlowLayoutPanel2.Controls.Add(Me.lblQueueHeader2)
        Me.FlowLayoutPanel2.Controls.Add(Me.lblQueueHeader3)
        Me.FlowLayoutPanel2.Controls.Add(Me.lblQueueHeader4)
        Me.FlowLayoutPanel2.Controls.Add(Me.lblQueueHeader5)
        Me.FlowLayoutPanel2.Controls.Add(Me.lblQueueHeader6)
        Me.FlowLayoutPanel2.Controls.Add(Me.lblQueueHeader7)
        Me.FlowLayoutPanel2.Controls.Add(Me.lblQueueHeader8)
        Me.FlowLayoutPanel2.Controls.Add(Me.lblQueueHeader9)
        Me.FlowLayoutPanel2.Controls.Add(Me.lblQueueHeader10)
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(6, 90)
        Me.FlowLayoutPanel2.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(975, 15)
        Me.FlowLayoutPanel2.TabIndex = 4
        '
        'dsPAINT1
        '
        Me.dsPAINT1.DataSetName = "dsPAINT"
        Me.dsPAINT1.Locale = New System.Globalization.CultureInfo("th-TH")
        Me.dsPAINT1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'taLANE_MST1
        '
        Me.taLANE_MST1.ClearBeforeFill = True
        '
        'lblLotNoUnitNo
        '
        Me.lblLotNoUnitNo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLotNoUnitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotNoUnitNo.Location = New System.Drawing.Point(150, 70)
        Me.lblLotNoUnitNo.Margin = New System.Windows.Forms.Padding(0)
        Me.lblLotNoUnitNo.Name = "lblLotNoUnitNo"
        Me.lblLotNoUnitNo.Size = New System.Drawing.Size(121, 17)
        Me.lblLotNoUnitNo.TabIndex = 6
        Me.lblLotNoUnitNo.Text = "LOT No., UNIT No."
        Me.lblLotNoUnitNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblModelCode
        '
        Me.lblModelCode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblModelCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblModelCode.Location = New System.Drawing.Point(19, 70)
        Me.lblModelCode.Margin = New System.Windows.Forms.Padding(0)
        Me.lblModelCode.Name = "lblModelCode"
        Me.lblModelCode.Size = New System.Drawing.Size(121, 17)
        Me.lblModelCode.TabIndex = 5
        Me.lblModelCode.Text = "MODEL CODE"
        Me.lblModelCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CtrlBtnsOperator1
        '
        Me.CtrlBtnsOperator1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CtrlBtnsOperator1.F1 = False
        Me.CtrlBtnsOperator1.F10 = False
        Me.CtrlBtnsOperator1.F11 = False
        Me.CtrlBtnsOperator1.F12 = True
        Me.CtrlBtnsOperator1.F2 = False
        Me.CtrlBtnsOperator1.F3 = False
        Me.CtrlBtnsOperator1.F4 = False
        Me.CtrlBtnsOperator1.F5 = False
        Me.CtrlBtnsOperator1.F6 = False
        Me.CtrlBtnsOperator1.F7 = False
        Me.CtrlBtnsOperator1.F8 = False
        Me.CtrlBtnsOperator1.F9 = False
        Me.CtrlBtnsOperator1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CtrlBtnsOperator1.Location = New System.Drawing.Point(39, 535)
        Me.CtrlBtnsOperator1.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.CtrlBtnsOperator1.Name = "CtrlBtnsOperator1"
        Me.CtrlBtnsOperator1.Size = New System.Drawing.Size(936, 76)
        Me.CtrlBtnsOperator1.TabIndex = 0
        '
        'Timer1
        '
        '
        'taWbsOn1
        '
        Me.taWbsOn1.ClearBeforeFill = True
        '
        'taSKIT_MST1
        '
        Me.taSKIT_MST1.ClearBeforeFill = True
        '
        'ctrlWBSMonitoring
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.Controls.Add(Me.lblLotNoUnitNo)
        Me.Controls.Add(Me.lblModelCode)
        Me.Controls.Add(Me.FlowLayoutPanel2)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lblHeader1)
        Me.Controls.Add(Me.CtrlBtnsOperator1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "ctrlWBSMonitoring"
        Me.Size = New System.Drawing.Size(1014, 615)
        Me.FlowLayoutPanel2.ResumeLayout(False)
        CType(Me.dsPAINT1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CtrlBtnsOperator1 As PSIS_CLIENT.ctrlBtnsOperator
    Friend WithEvents lblHeader1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lblQueueHeader1 As System.Windows.Forms.Label
    Friend WithEvents lblQueueHeader2 As System.Windows.Forms.Label
    Friend WithEvents lblQueueHeader3 As System.Windows.Forms.Label
    Friend WithEvents lblQueueHeader4 As System.Windows.Forms.Label
    Friend WithEvents lblQueueHeader5 As System.Windows.Forms.Label
    Friend WithEvents lblQueueHeader6 As System.Windows.Forms.Label
    Friend WithEvents lblQueueHeader7 As System.Windows.Forms.Label
    Friend WithEvents lblQueueHeader8 As System.Windows.Forms.Label
    Friend WithEvents lblQueueHeader9 As System.Windows.Forms.Label
    Friend WithEvents lblQueueHeader10 As System.Windows.Forms.Label
    Friend WithEvents dsPAINT1 As Common.dsPAINT
    Friend WithEvents taLANE_MST1 As taLANE_MST
    Friend WithEvents lblQueueHeader0 As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lblLotNoUnitNo As System.Windows.Forms.Label
    Friend WithEvents lblModelCode As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents taWbsOn1 As taWBS_ON
    Friend WithEvents taSKIT_MST1 As taSKIT_MST

End Class
