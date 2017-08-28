<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlProcMstList
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
        Me.lsvData = New System.Windows.Forms.ListView
        Me.lblHeader1 = New System.Windows.Forms.Label
        Me.txtCurrProc = New System.Windows.Forms.TextBox
        Me.txtPrevProc = New System.Windows.Forms.TextBox
        Me.txtNextProc = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.taPROCESS_LINKAGE1 = New Common.dsPAINTTableAdapters.taPROCESS_LINKAGE
        Me.dsPAINT1 = New Common.dsPAINT
        Me.taPROCESS_MST1 = New Common.dsPAINTTableAdapters.taPROCESS_MST
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.pboRightArrow = New System.Windows.Forms.PictureBox
        Me.ctrlBtnsOperator1 = New PSIS_CLIENT.ctrlBtnsOperator
        CType(Me.dsPAINT1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pboRightArrow, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lsvData
        '
        Me.lsvData.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lsvData.FullRowSelect = True
        Me.lsvData.GridLines = True
        Me.lsvData.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lsvData.Location = New System.Drawing.Point(18, 53)
        Me.lsvData.MultiSelect = False
        Me.lsvData.Name = "lsvData"
        Me.lsvData.OwnerDraw = True
        Me.lsvData.Size = New System.Drawing.Size(746, 475)
        Me.lsvData.TabIndex = 1
        Me.lsvData.UseCompatibleStateImageBehavior = False
        Me.lsvData.View = System.Windows.Forms.View.Details
        '
        'lblHeader1
        '
        Me.lblHeader1.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader1.Location = New System.Drawing.Point(60, 0)
        Me.lblHeader1.Margin = New System.Windows.Forms.Padding(57, 0, 3, 0)
        Me.lblHeader1.Name = "lblHeader1"
        Me.lblHeader1.Size = New System.Drawing.Size(954, 50)
        Me.lblHeader1.TabIndex = 5
        Me.lblHeader1.Text = "Label1"
        Me.lblHeader1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCurrProc
        '
        Me.txtCurrProc.BackColor = System.Drawing.SystemColors.Window
        Me.txtCurrProc.Location = New System.Drawing.Point(12, 247)
        Me.txtCurrProc.Name = "txtCurrProc"
        Me.txtCurrProc.ReadOnly = True
        Me.txtCurrProc.Size = New System.Drawing.Size(200, 22)
        Me.txtCurrProc.TabIndex = 6
        Me.txtCurrProc.TabStop = False
        Me.txtCurrProc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPrevProc
        '
        Me.txtPrevProc.BackColor = System.Drawing.SystemColors.Window
        Me.txtPrevProc.Location = New System.Drawing.Point(12, 37)
        Me.txtPrevProc.Multiline = True
        Me.txtPrevProc.Name = "txtPrevProc"
        Me.txtPrevProc.ReadOnly = True
        Me.txtPrevProc.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtPrevProc.Size = New System.Drawing.Size(200, 75)
        Me.txtPrevProc.TabIndex = 7
        Me.txtPrevProc.TabStop = False
        '
        'txtNextProc
        '
        Me.txtNextProc.BackColor = System.Drawing.SystemColors.Window
        Me.txtNextProc.Location = New System.Drawing.Point(12, 395)
        Me.txtNextProc.Multiline = True
        Me.txtNextProc.Name = "txtNextProc"
        Me.txtNextProc.ReadOnly = True
        Me.txtNextProc.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtNextProc.Size = New System.Drawing.Size(200, 75)
        Me.txtNextProc.TabIndex = 8
        Me.txtNextProc.TabStop = False
        Me.txtNextProc.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(75, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 16)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "PREVIOUS"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(75, 228)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 16)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "CURRENT"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(92, 376)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 16)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "NEXT"
        Me.Label3.Visible = False
        '
        'taPROCESS_LINKAGE1
        '
        Me.taPROCESS_LINKAGE1.ClearBeforeFill = True
        '
        'dsPAINT1
        '
        Me.dsPAINT1.DataSetName = "dsPAINT"
        Me.dsPAINT1.Locale = New System.Globalization.CultureInfo("th-TH")
        Me.dsPAINT1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'taPROCESS_MST1
        '
        Me.taPROCESS_MST1.ClearBeforeFill = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtNextProc)
        Me.GroupBox1.Controls.Add(Me.pboRightArrow)
        Me.GroupBox1.Controls.Add(Me.txtCurrProc)
        Me.GroupBox1.Controls.Add(Me.txtPrevProc)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(770, 49)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(224, 479)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PSIS_CLIENT.My.Resources.Resources.right_arrow
        Me.PictureBox1.Location = New System.Drawing.Point(59, 289)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 75)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 13
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'pboRightArrow
        '
        Me.pboRightArrow.Image = Global.PSIS_CLIENT.My.Resources.Resources.down_arrow
        Me.pboRightArrow.Location = New System.Drawing.Point(59, 133)
        Me.pboRightArrow.Name = "pboRightArrow"
        Me.pboRightArrow.Size = New System.Drawing.Size(100, 75)
        Me.pboRightArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pboRightArrow.TabIndex = 12
        Me.pboRightArrow.TabStop = False
        '
        'ctrlBtnsOperator1
        '
        Me.ctrlBtnsOperator1.F1 = False
        Me.ctrlBtnsOperator1.F10 = False
        Me.ctrlBtnsOperator1.F11 = False
        Me.ctrlBtnsOperator1.F12 = False
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
        Me.ctrlBtnsOperator1.TabIndex = 3
        '
        'ctrlProcMstList
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblHeader1)
        Me.Controls.Add(Me.ctrlBtnsOperator1)
        Me.Controls.Add(Me.lsvData)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "ctrlProcMstList"
        Me.Size = New System.Drawing.Size(1014, 615)
        CType(Me.dsPAINT1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pboRightArrow, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lsvData As System.Windows.Forms.ListView
    Friend WithEvents ctrlBtnsOperator1 As PSIS_CLIENT.ctrlBtnsOperator
    Friend WithEvents lblHeader1 As System.Windows.Forms.Label
    Friend WithEvents txtCurrProc As System.Windows.Forms.TextBox
    Friend WithEvents txtPrevProc As System.Windows.Forms.TextBox
    Friend WithEvents txtNextProc As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents taPROCESS_LINKAGE1 As taPROCESS_LINKAGE
    Friend WithEvents dsPAINT1 As Common.dsPAINT
    Friend WithEvents taPROCESS_MST1 As taPROCESS_MST
    Friend WithEvents pboRightArrow As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox

End Class
