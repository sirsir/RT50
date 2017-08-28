<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LineMSTDetail
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtLineCode = New System.Windows.Forms.TextBox
        Me.txtLineName = New System.Windows.Forms.TextBox
        Me.txtIPAddr = New System.Windows.Forms.TextBox
        Me.chkMainLine = New System.Windows.Forms.CheckBox
        Me.chkOnline = New System.Windows.Forms.CheckBox
        Me.txtNetAddr = New System.Windows.Forms.TextBox
        Me.txtNodeAddr = New System.Windows.Forms.TextBox
        Me.txtUnitAddr = New System.Windows.Forms.TextBox
        Me.txtReadReqAddr = New System.Windows.Forms.TextBox
        Me.txtWritePrdAddr = New System.Windows.Forms.TextBox
        Me.txtWriteCarrAddr = New System.Windows.Forms.TextBox
        Me.chkPart1 = New System.Windows.Forms.CheckBox
        Me.chkPart2 = New System.Windows.Forms.CheckBox
        Me.chkPart3 = New System.Windows.Forms.CheckBox
        Me.chkPart4 = New System.Windows.Forms.CheckBox
        Me.chkPart5 = New System.Windows.Forms.CheckBox
        Me.txtLineType = New System.Windows.Forms.TextBox
        Me.btnAddLine = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(5, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(122, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "LineCode"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(148, 24)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Add New Line "
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Label8, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Label9, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.Label10, 0, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.Label11, 0, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.Label12, 0, 10)
        Me.TableLayoutPanel1.Controls.Add(Me.Label13, 0, 11)
        Me.TableLayoutPanel1.Controls.Add(Me.Label14, 0, 12)
        Me.TableLayoutPanel1.Controls.Add(Me.Label15, 0, 13)
        Me.TableLayoutPanel1.Controls.Add(Me.Label16, 0, 14)
        Me.TableLayoutPanel1.Controls.Add(Me.Label17, 0, 15)
        Me.TableLayoutPanel1.Controls.Add(Me.Label18, 0, 16)
        Me.TableLayoutPanel1.Controls.Add(Me.txtLineCode, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtLineName, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtIPAddr, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.chkMainLine, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.chkOnline, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.txtNetAddr, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.txtNodeAddr, 1, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.txtUnitAddr, 1, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.txtReadReqAddr, 1, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.txtWritePrdAddr, 1, 10)
        Me.TableLayoutPanel1.Controls.Add(Me.txtWriteCarrAddr, 1, 11)
        Me.TableLayoutPanel1.Controls.Add(Me.chkPart1, 1, 12)
        Me.TableLayoutPanel1.Controls.Add(Me.chkPart2, 1, 13)
        Me.TableLayoutPanel1.Controls.Add(Me.chkPart3, 1, 14)
        Me.TableLayoutPanel1.Controls.Add(Me.chkPart4, 1, 15)
        Me.TableLayoutPanel1.Controls.Add(Me.chkPart5, 1, 16)
        Me.TableLayoutPanel1.Controls.Add(Me.txtLineType, 1, 2)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(16, 50)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 17
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882352!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882352!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882352!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882352!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882352!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882352!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882352!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882352!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882352!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882352!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882352!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882352!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882352!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882352!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882352!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882352!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882352!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(263, 446)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Location = New System.Drawing.Point(5, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 24)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "LineName"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Location = New System.Drawing.Point(5, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(122, 24)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "LineType"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Location = New System.Drawing.Point(5, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(122, 24)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "MainLineFlag"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Location = New System.Drawing.Point(5, 106)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(122, 24)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "OnlineFlag"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Location = New System.Drawing.Point(5, 132)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(122, 24)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "IpAddress"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label8.Location = New System.Drawing.Point(5, 158)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(122, 24)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "NetAddress"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label9.Location = New System.Drawing.Point(5, 184)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(122, 24)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "NodeAddress"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label10.Location = New System.Drawing.Point(5, 210)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(122, 24)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "UnitAddress"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label11.Location = New System.Drawing.Point(5, 236)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(122, 24)
        Me.Label11.TabIndex = 9
        Me.Label11.Text = "ReadReqAddress"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label12.Location = New System.Drawing.Point(5, 262)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(122, 24)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "WriteProductionAddress"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label13.Location = New System.Drawing.Point(5, 288)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(122, 24)
        Me.Label13.TabIndex = 11
        Me.Label13.Text = "WriteCarryOutAddress"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label14.Location = New System.Drawing.Point(5, 314)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(122, 24)
        Me.Label14.TabIndex = 12
        Me.Label14.Text = "Part1"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label15.Location = New System.Drawing.Point(5, 340)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(122, 24)
        Me.Label15.TabIndex = 13
        Me.Label15.Text = "Part2"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label16.Location = New System.Drawing.Point(5, 366)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(122, 24)
        Me.Label16.TabIndex = 14
        Me.Label16.Text = "Part3"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label17.Location = New System.Drawing.Point(5, 392)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(122, 24)
        Me.Label17.TabIndex = 15
        Me.Label17.Text = "Part4"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label18.Location = New System.Drawing.Point(5, 418)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(122, 26)
        Me.Label18.TabIndex = 16
        Me.Label18.Text = "Part5"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtLineCode
        '
        Me.txtLineCode.Location = New System.Drawing.Point(135, 5)
        Me.txtLineCode.Name = "txtLineCode"
        Me.txtLineCode.Size = New System.Drawing.Size(123, 20)
        Me.txtLineCode.TabIndex = 17
        '
        'txtLineName
        '
        Me.txtLineName.Location = New System.Drawing.Point(135, 31)
        Me.txtLineName.Name = "txtLineName"
        Me.txtLineName.Size = New System.Drawing.Size(123, 20)
        Me.txtLineName.TabIndex = 18
        '
        'txtIPAddr
        '
        Me.txtIPAddr.Location = New System.Drawing.Point(135, 135)
        Me.txtIPAddr.Name = "txtIPAddr"
        Me.txtIPAddr.Size = New System.Drawing.Size(123, 20)
        Me.txtIPAddr.TabIndex = 21
        '
        'chkMainLine
        '
        Me.chkMainLine.AutoSize = True
        Me.chkMainLine.Location = New System.Drawing.Point(135, 83)
        Me.chkMainLine.Name = "chkMainLine"
        Me.chkMainLine.Size = New System.Drawing.Size(15, 14)
        Me.chkMainLine.TabIndex = 22
        Me.chkMainLine.UseVisualStyleBackColor = True
        '
        'chkOnline
        '
        Me.chkOnline.AutoSize = True
        Me.chkOnline.Location = New System.Drawing.Point(135, 109)
        Me.chkOnline.Name = "chkOnline"
        Me.chkOnline.Size = New System.Drawing.Size(15, 14)
        Me.chkOnline.TabIndex = 23
        Me.chkOnline.UseVisualStyleBackColor = True
        '
        'txtNetAddr
        '
        Me.txtNetAddr.Location = New System.Drawing.Point(135, 161)
        Me.txtNetAddr.Name = "txtNetAddr"
        Me.txtNetAddr.Size = New System.Drawing.Size(123, 20)
        Me.txtNetAddr.TabIndex = 24
        '
        'txtNodeAddr
        '
        Me.txtNodeAddr.Location = New System.Drawing.Point(135, 187)
        Me.txtNodeAddr.Name = "txtNodeAddr"
        Me.txtNodeAddr.Size = New System.Drawing.Size(123, 20)
        Me.txtNodeAddr.TabIndex = 25
        '
        'txtUnitAddr
        '
        Me.txtUnitAddr.Location = New System.Drawing.Point(135, 213)
        Me.txtUnitAddr.Name = "txtUnitAddr"
        Me.txtUnitAddr.Size = New System.Drawing.Size(123, 20)
        Me.txtUnitAddr.TabIndex = 26
        '
        'txtReadReqAddr
        '
        Me.txtReadReqAddr.Location = New System.Drawing.Point(135, 239)
        Me.txtReadReqAddr.Name = "txtReadReqAddr"
        Me.txtReadReqAddr.Size = New System.Drawing.Size(123, 20)
        Me.txtReadReqAddr.TabIndex = 27
        '
        'txtWritePrdAddr
        '
        Me.txtWritePrdAddr.Location = New System.Drawing.Point(135, 265)
        Me.txtWritePrdAddr.Name = "txtWritePrdAddr"
        Me.txtWritePrdAddr.Size = New System.Drawing.Size(123, 20)
        Me.txtWritePrdAddr.TabIndex = 28
        '
        'txtWriteCarrAddr
        '
        Me.txtWriteCarrAddr.Location = New System.Drawing.Point(135, 291)
        Me.txtWriteCarrAddr.Name = "txtWriteCarrAddr"
        Me.txtWriteCarrAddr.Size = New System.Drawing.Size(123, 20)
        Me.txtWriteCarrAddr.TabIndex = 29
        '
        'chkPart1
        '
        Me.chkPart1.AutoSize = True
        Me.chkPart1.Location = New System.Drawing.Point(135, 317)
        Me.chkPart1.Name = "chkPart1"
        Me.chkPart1.Size = New System.Drawing.Size(15, 14)
        Me.chkPart1.TabIndex = 30
        Me.chkPart1.UseVisualStyleBackColor = True
        '
        'chkPart2
        '
        Me.chkPart2.AutoSize = True
        Me.chkPart2.Location = New System.Drawing.Point(135, 343)
        Me.chkPart2.Name = "chkPart2"
        Me.chkPart2.Size = New System.Drawing.Size(15, 14)
        Me.chkPart2.TabIndex = 31
        Me.chkPart2.UseVisualStyleBackColor = True
        '
        'chkPart3
        '
        Me.chkPart3.AutoSize = True
        Me.chkPart3.Location = New System.Drawing.Point(135, 369)
        Me.chkPart3.Name = "chkPart3"
        Me.chkPart3.Size = New System.Drawing.Size(15, 14)
        Me.chkPart3.TabIndex = 32
        Me.chkPart3.UseVisualStyleBackColor = True
        '
        'chkPart4
        '
        Me.chkPart4.AutoSize = True
        Me.chkPart4.Location = New System.Drawing.Point(135, 395)
        Me.chkPart4.Name = "chkPart4"
        Me.chkPart4.Size = New System.Drawing.Size(15, 14)
        Me.chkPart4.TabIndex = 33
        Me.chkPart4.UseVisualStyleBackColor = True
        '
        'chkPart5
        '
        Me.chkPart5.AutoSize = True
        Me.chkPart5.Location = New System.Drawing.Point(135, 421)
        Me.chkPart5.Name = "chkPart5"
        Me.chkPart5.Size = New System.Drawing.Size(15, 14)
        Me.chkPart5.TabIndex = 34
        Me.chkPart5.UseVisualStyleBackColor = True
        '
        'txtLineType
        '
        Me.txtLineType.Location = New System.Drawing.Point(135, 57)
        Me.txtLineType.Name = "txtLineType"
        Me.txtLineType.Size = New System.Drawing.Size(123, 20)
        Me.txtLineType.TabIndex = 19
        '
        'btnAddLine
        '
        Me.btnAddLine.Location = New System.Drawing.Point(101, 502)
        Me.btnAddLine.Name = "btnAddLine"
        Me.btnAddLine.Size = New System.Drawing.Size(85, 23)
        Me.btnAddLine.TabIndex = 3
        Me.btnAddLine.Text = "ADD LINE"
        Me.btnAddLine.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(192, 502)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(87, 23)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "CANCEL"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'LineMSTDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(302, 539)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnAddLine)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Label2)
        Me.Name = "LineMSTDetail"
        Me.Text = "LineMSTDetail"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtLineCode As System.Windows.Forms.TextBox
    Friend WithEvents txtLineName As System.Windows.Forms.TextBox
    Friend WithEvents txtLineType As System.Windows.Forms.TextBox
    Friend WithEvents txtIPAddr As System.Windows.Forms.TextBox
    Friend WithEvents chkMainLine As System.Windows.Forms.CheckBox
    Friend WithEvents chkOnline As System.Windows.Forms.CheckBox
    Friend WithEvents txtNetAddr As System.Windows.Forms.TextBox
    Friend WithEvents txtNodeAddr As System.Windows.Forms.TextBox
    Friend WithEvents txtUnitAddr As System.Windows.Forms.TextBox
    Friend WithEvents txtReadReqAddr As System.Windows.Forms.TextBox
    Friend WithEvents txtWritePrdAddr As System.Windows.Forms.TextBox
    Friend WithEvents txtWriteCarrAddr As System.Windows.Forms.TextBox
    Friend WithEvents chkPart1 As System.Windows.Forms.CheckBox
    Friend WithEvents chkPart2 As System.Windows.Forms.CheckBox
    Friend WithEvents chkPart3 As System.Windows.Forms.CheckBox
    Friend WithEvents chkPart4 As System.Windows.Forms.CheckBox
    Friend WithEvents chkPart5 As System.Windows.Forms.CheckBox
    Friend WithEvents btnAddLine As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
