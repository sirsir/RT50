<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlProgress
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
        Me.rectWBS = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        Me.flp = New System.Windows.Forms.FlowLayoutPanel
        Me.pnlWBS = New System.Windows.Forms.Panel
        Me.lblPaintShop = New System.Windows.Forms.Label
        Me.lblFinishingLine = New System.Windows.Forms.Label
        Me.lblWBS = New System.Windows.Forms.Label
        Me.pboPaintShop = New System.Windows.Forms.PictureBox
        Me.lblPaintShop1 = New System.Windows.Forms.Label
        Me.lblWbs1 = New System.Windows.Forms.Label
        Me.lblFinishingLine1 = New System.Windows.Forms.Label
        Me.ShapeContainer2 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Me.osh3 = New Microsoft.VisualBasic.PowerPacks.OvalShape
        Me.osh2 = New Microsoft.VisualBasic.PowerPacks.OvalShape
        Me.lsh10 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.lsh9 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.lsh8 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.lsh7 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.osh1 = New Microsoft.VisualBasic.PowerPacks.OvalShape
        Me.lsh6 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.lsh5 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.lsh4 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.lsh3 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.rectFinishLine = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        Me.pnlPaintProgress = New System.Windows.Forms.Panel
        Me.flpPntProg = New System.Windows.Forms.FlowLayoutPanel
        Me.timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.dsPAINT1 = New Common.dsPAINT
        Me.taFINISHING_LINE1 = New Common.dsPAINTTableAdapters.taFINISHING_LINE
        Me.taPAINT_SHOP1 = New Common.dsPAINTTableAdapters.taPAINT_SHOP
        Me.taPAINT_PROGRESS1 = New Common.dsPAINTTableAdapters.taPAINT_PROGRESS
        Me.taPROCESS_MST1 = New Common.dsPAINTTableAdapters.taPROCESS_MST
        Me.taWBS_ON1 = New Common.dsPAINTTableAdapters.taWBS_ON
        Me.taPROCESS_LINKAGE1 = New Common.dsPAINTTableAdapters.taPROCESS_LINKAGE
        Me.taPROCESS_GROUP_MST1 = New Common.dsPAINTTableAdapters.taPROCESS_GROUP_MST
        Me.ctrlBtnsOperator1 = New PSIS_CLIENT.ctrlBtnsOperator
        Me.flp.SuspendLayout()
        Me.pnlWBS.SuspendLayout()
        CType(Me.pboPaintShop, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPaintProgress.SuspendLayout()
        CType(Me.dsPAINT1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rectWBS
        '
        Me.rectWBS.FillColor = System.Drawing.SystemColors.Info
        Me.rectWBS.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.rectWBS.Location = New System.Drawing.Point(380, 98)
        Me.rectWBS.Name = "rectWBS"
        Me.rectWBS.Size = New System.Drawing.Size(250, 350)
        '
        'flp
        '
        Me.flp.AutoScroll = True
        Me.flp.Controls.Add(Me.pnlWBS)
        Me.flp.Controls.Add(Me.pnlPaintProgress)
        Me.flp.Location = New System.Drawing.Point(0, 0)
        Me.flp.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.flp.Name = "flp"
        Me.flp.Size = New System.Drawing.Size(1014, 527)
        Me.flp.TabIndex = 1
        '
        'pnlWBS
        '
        Me.pnlWBS.Controls.Add(Me.lblPaintShop)
        Me.pnlWBS.Controls.Add(Me.lblFinishingLine)
        Me.pnlWBS.Controls.Add(Me.lblWBS)
        Me.pnlWBS.Controls.Add(Me.pboPaintShop)
        Me.pnlWBS.Controls.Add(Me.lblPaintShop1)
        Me.pnlWBS.Controls.Add(Me.lblWbs1)
        Me.pnlWBS.Controls.Add(Me.lblFinishingLine1)
        Me.pnlWBS.Controls.Add(Me.ShapeContainer2)
        Me.pnlWBS.Location = New System.Drawing.Point(3, 4)
        Me.pnlWBS.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pnlWBS.Name = "pnlWBS"
        Me.pnlWBS.Size = New System.Drawing.Size(1008, 615)
        Me.pnlWBS.TabIndex = 2
        '
        'lblPaintShop
        '
        Me.lblPaintShop.BackColor = System.Drawing.SystemColors.Window
        Me.lblPaintShop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPaintShop.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblPaintShop.Location = New System.Drawing.Point(767, 262)
        Me.lblPaintShop.Name = "lblPaintShop"
        Me.lblPaintShop.Size = New System.Drawing.Size(30, 22)
        Me.lblPaintShop.TabIndex = 11
        Me.lblPaintShop.Text = "99"
        Me.lblPaintShop.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFinishingLine
        '
        Me.lblFinishingLine.BackColor = System.Drawing.SystemColors.Window
        Me.lblFinishingLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFinishingLine.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblFinishingLine.Location = New System.Drawing.Point(161, 301)
        Me.lblFinishingLine.Name = "lblFinishingLine"
        Me.lblFinishingLine.Size = New System.Drawing.Size(30, 22)
        Me.lblFinishingLine.TabIndex = 10
        Me.lblFinishingLine.Text = "99"
        Me.lblFinishingLine.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblWBS
        '
        Me.lblWBS.BackColor = System.Drawing.SystemColors.Window
        Me.lblWBS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWBS.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblWBS.Location = New System.Drawing.Point(490, 330)
        Me.lblWBS.Name = "lblWBS"
        Me.lblWBS.Size = New System.Drawing.Size(30, 22)
        Me.lblWBS.TabIndex = 9
        Me.lblWBS.Text = "99"
        Me.lblWBS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pboPaintShop
        '
        Me.pboPaintShop.Image = Global.PSIS_CLIENT.My.Resources.Resources.right_arrow
        Me.pboPaintShop.Location = New System.Drawing.Point(732, 223)
        Me.pboPaintShop.Name = "pboPaintShop"
        Me.pboPaintShop.Size = New System.Drawing.Size(100, 100)
        Me.pboPaintShop.TabIndex = 1
        Me.pboPaintShop.TabStop = False
        '
        'lblPaintShop1
        '
        Me.lblPaintShop1.AutoSize = True
        Me.lblPaintShop1.BackColor = System.Drawing.SystemColors.Control
        Me.lblPaintShop1.Location = New System.Drawing.Point(739, 320)
        Me.lblPaintShop1.Name = "lblPaintShop1"
        Me.lblPaintShop1.Size = New System.Drawing.Size(86, 16)
        Me.lblPaintShop1.TabIndex = 5
        Me.lblPaintShop1.Text = "PAINT SHOP"
        Me.lblPaintShop1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblWbs1
        '
        Me.lblWbs1.BackColor = System.Drawing.SystemColors.Info
        Me.lblWbs1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWbs1.Location = New System.Drawing.Point(381, 99)
        Me.lblWbs1.Name = "lblWbs1"
        Me.lblWbs1.Size = New System.Drawing.Size(248, 348)
        Me.lblWbs1.TabIndex = 4
        Me.lblWbs1.Text = "WBS"
        Me.lblWbs1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFinishingLine1
        '
        Me.lblFinishingLine1.BackColor = System.Drawing.SystemColors.Info
        Me.lblFinishingLine1.Location = New System.Drawing.Point(92, 263)
        Me.lblFinishingLine1.Name = "lblFinishingLine1"
        Me.lblFinishingLine1.Size = New System.Drawing.Size(198, 22)
        Me.lblFinishingLine1.TabIndex = 3
        Me.lblFinishingLine1.Text = "FINISHING LINE"
        Me.lblFinishingLine1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ShapeContainer2
        '
        Me.ShapeContainer2.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer2.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer2.Name = "ShapeContainer2"
        Me.ShapeContainer2.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.osh3, Me.osh2, Me.lsh10, Me.lsh9, Me.lsh8, Me.lsh7, Me.osh1, Me.lsh6, Me.lsh5, Me.lsh4, Me.lsh3, Me.rectFinishLine, Me.rectWBS})
        Me.ShapeContainer2.Size = New System.Drawing.Size(1008, 615)
        Me.ShapeContainer2.TabIndex = 0
        Me.ShapeContainer2.TabStop = False
        '
        'osh3
        '
        Me.osh3.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.osh3.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.osh3.Location = New System.Drawing.Point(660, 266)
        Me.osh3.Name = "osh3"
        Me.osh3.Size = New System.Drawing.Size(15, 15)
        '
        'osh2
        '
        Me.osh2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.osh2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.osh2.Cursor = System.Windows.Forms.Cursors.Default
        Me.osh2.Location = New System.Drawing.Point(903, 266)
        Me.osh2.Name = "osh2"
        Me.osh2.Size = New System.Drawing.Size(15, 15)
        '
        'lsh10
        '
        Me.lsh10.Cursor = System.Windows.Forms.Cursors.Default
        Me.lsh10.Name = "lsh10"
        Me.lsh10.X1 = 898
        Me.lsh10.X2 = 898
        Me.lsh10.Y1 = 280
        Me.lsh10.Y2 = 268
        '
        'lsh9
        '
        Me.lsh9.Cursor = System.Windows.Forms.Cursors.Default
        Me.lsh9.Name = "lsh9"
        Me.lsh9.X1 = 898
        Me.lsh9.X2 = 902
        Me.lsh9.Y1 = 268
        Me.lsh9.Y2 = 273
        '
        'lsh8
        '
        Me.lsh8.Cursor = System.Windows.Forms.Cursors.Default
        Me.lsh8.Name = "lsh8"
        Me.lsh8.X1 = 898
        Me.lsh8.X2 = 902
        Me.lsh8.Y1 = 280
        Me.lsh8.Y2 = 275
        '
        'lsh7
        '
        Me.lsh7.Cursor = System.Windows.Forms.Cursors.Default
        Me.lsh7.Name = "lsh7"
        Me.lsh7.X1 = 630
        Me.lsh7.X2 = 903
        Me.lsh7.Y1 = 274
        Me.lsh7.Y2 = 274
        '
        'osh1
        '
        Me.osh1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.osh1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.osh1.Location = New System.Drawing.Point(356, 265)
        Me.osh1.Name = "osh1"
        Me.osh1.Size = New System.Drawing.Size(15, 15)
        '
        'lsh6
        '
        Me.lsh6.Cursor = System.Windows.Forms.Cursors.Default
        Me.lsh6.Name = "lsh6"
        Me.lsh6.X1 = 375
        Me.lsh6.X2 = 375
        Me.lsh6.Y1 = 278
        Me.lsh6.Y2 = 266
        '
        'lsh5
        '
        Me.lsh5.Cursor = System.Windows.Forms.Cursors.Default
        Me.lsh5.Name = "lsh5"
        Me.lsh5.X1 = 375
        Me.lsh5.X2 = 379
        Me.lsh5.Y1 = 278
        Me.lsh5.Y2 = 273
        '
        'lsh4
        '
        Me.lsh4.Cursor = System.Windows.Forms.Cursors.Default
        Me.lsh4.Name = "lsh4"
        Me.lsh4.X1 = 375
        Me.lsh4.X2 = 379
        Me.lsh4.Y1 = 266
        Me.lsh4.Y2 = 271
        '
        'lsh3
        '
        Me.lsh3.Cursor = System.Windows.Forms.Cursors.Default
        Me.lsh3.Name = "lsh3"
        Me.lsh3.X1 = 290
        Me.lsh3.X2 = 380
        Me.lsh3.Y1 = 273
        Me.lsh3.Y2 = 273
        '
        'rectFinishLine
        '
        Me.rectFinishLine.BackColor = System.Drawing.SystemColors.Control
        Me.rectFinishLine.Cursor = System.Windows.Forms.Cursors.Default
        Me.rectFinishLine.FillColor = System.Drawing.SystemColors.Info
        Me.rectFinishLine.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.rectFinishLine.Location = New System.Drawing.Point(90, 261)
        Me.rectFinishLine.Name = "rectWBS"
        Me.rectFinishLine.Size = New System.Drawing.Size(200, 25)
        '
        'pnlPaintProgress
        '
        Me.pnlPaintProgress.Controls.Add(Me.flpPntProg)
        Me.pnlPaintProgress.Location = New System.Drawing.Point(3, 626)
        Me.pnlPaintProgress.Name = "pnlPaintProgress"
        Me.pnlPaintProgress.Size = New System.Drawing.Size(1008, 615)
        Me.pnlPaintProgress.TabIndex = 3
        Me.pnlPaintProgress.Visible = False
        '
        'flpPntProg
        '
        Me.flpPntProg.AutoScroll = True
        Me.flpPntProg.Location = New System.Drawing.Point(0, -7)
        Me.flpPntProg.Name = "flpPntProg"
        Me.flpPntProg.Size = New System.Drawing.Size(1008, 615)
        Me.flpPntProg.TabIndex = 0
        '
        'timer1
        '
        Me.timer1.Interval = 60000
        '
        'dsPAINT1
        '
        Me.dsPAINT1.DataSetName = "dsPAINT"
        Me.dsPAINT1.Locale = New System.Globalization.CultureInfo("th-TH")
        Me.dsPAINT1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'taFINISHING_LINE1
        '
        Me.taFINISHING_LINE1.ClearBeforeFill = True
        '
        'taPAINT_SHOP1
        '
        Me.taPAINT_SHOP1.ClearBeforeFill = True
        '
        'taPAINT_PROGRESS1
        '
        Me.taPAINT_PROGRESS1.ClearBeforeFill = True
        '
        'taPROCESS_MST1
        '
        Me.taPROCESS_MST1.ClearBeforeFill = True
        '
        'taWBS_ON1
        '
        Me.taWBS_ON1.ClearBeforeFill = True
        '
        'taPROCESS_LINKAGE1
        '
        Me.taPROCESS_LINKAGE1.ClearBeforeFill = True
        '
        'taPROCESS_GROUP_MST1
        '
        Me.taPROCESS_GROUP_MST1.ClearBeforeFill = True
        '
        'ctrlBtnsOperator1
        '
        Me.ctrlBtnsOperator1.F1 = False
        Me.ctrlBtnsOperator1.F10 = False
        Me.ctrlBtnsOperator1.F11 = False
        Me.ctrlBtnsOperator1.F12 = True
        Me.ctrlBtnsOperator1.F2 = False
        Me.ctrlBtnsOperator1.F3 = False
        Me.ctrlBtnsOperator1.F4 = False
        Me.ctrlBtnsOperator1.F5 = False
        Me.ctrlBtnsOperator1.F6 = False
        Me.ctrlBtnsOperator1.F7 = False
        Me.ctrlBtnsOperator1.F8 = False
        Me.ctrlBtnsOperator1.F9 = False
        Me.ctrlBtnsOperator1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ctrlBtnsOperator1.Location = New System.Drawing.Point(39, 535)
        Me.ctrlBtnsOperator1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ctrlBtnsOperator1.Name = "ctrlBtnsOperator1"
        Me.ctrlBtnsOperator1.Size = New System.Drawing.Size(936, 76)
        Me.ctrlBtnsOperator1.TabIndex = 4
        '
        'ctrlProgress
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.flp)
        Me.Controls.Add(Me.ctrlBtnsOperator1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "ctrlProgress"
        Me.Size = New System.Drawing.Size(1014, 613)
        Me.flp.ResumeLayout(False)
        Me.pnlWBS.ResumeLayout(False)
        Me.pnlWBS.PerformLayout()
        CType(Me.pboPaintShop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPaintProgress.ResumeLayout(False)
        CType(Me.dsPAINT1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rectWBS As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents flp As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pnlWBS As System.Windows.Forms.Panel
    Friend WithEvents ShapeContainer2 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents rectFinishLine As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents lsh3 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents osh1 As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents lsh6 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents lsh5 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents lsh4 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents osh2 As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents lsh10 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents lsh9 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents lsh8 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents lsh7 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents osh3 As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents pboPaintShop As System.Windows.Forms.PictureBox
    Friend WithEvents lblFinishingLine1 As System.Windows.Forms.Label
    Friend WithEvents lblPaintShop1 As System.Windows.Forms.Label
    Friend WithEvents lblWbs1 As System.Windows.Forms.Label
    Friend WithEvents ctrlBtnsOperator1 As PSIS_CLIENT.ctrlBtnsOperator
    Friend WithEvents lblWBS As System.Windows.Forms.Label
    Friend WithEvents dsPAINT1 As Common.dsPAINT
    Friend WithEvents taFINISHING_LINE1 As taFINISHING_LINE
    Friend WithEvents lblFinishingLine As System.Windows.Forms.Label
    Friend WithEvents lblPaintShop As System.Windows.Forms.Label
    Friend WithEvents taPAINT_SHOP1 As taPAINT_SHOP
    Friend WithEvents taPAINT_PROGRESS1 As taPAINT_PROGRESS
    Friend WithEvents taPROCESS_MST1 As taPROCESS_MST
    Friend WithEvents timer1 As System.Windows.Forms.Timer
    Friend WithEvents taWBS_ON1 As taWBS_ON
    Friend WithEvents taPROCESS_LINKAGE1 As taPROCESS_LINKAGE
    Friend WithEvents taPROCESS_GROUP_MST1 As Common.dsPAINTTableAdapters.taPROCESS_GROUP_MST
    Friend WithEvents pnlPaintProgress As System.Windows.Forms.Panel
    Friend WithEvents flpPntProg As System.Windows.Forms.FlowLayoutPanel

End Class
