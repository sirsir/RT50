<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlList
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
        Me.lblHeader1 = New System.Windows.Forms.Label
        Me.lsvData = New System.Windows.Forms.ListView
        Me.ctrlBtnsOperator1 = New PSIS_CLIENT.ctrlBtnsOperator
        Me.SuspendLayout()
        '
        'lblHeader1
        '
        Me.lblHeader1.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader1.Location = New System.Drawing.Point(60, 0)
        Me.lblHeader1.Margin = New System.Windows.Forms.Padding(57, 0, 3, 0)
        Me.lblHeader1.Name = "lblHeader1"
        Me.lblHeader1.Size = New System.Drawing.Size(954, 50)
        Me.lblHeader1.TabIndex = 0
        Me.lblHeader1.Text = "Label1"
        Me.lblHeader1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblHeader1.UseMnemonic = False
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
        Me.lsvData.Size = New System.Drawing.Size(972, 475)
        Me.lsvData.TabIndex = 0
        Me.lsvData.UseCompatibleStateImageBehavior = False
        Me.lsvData.View = System.Windows.Forms.View.Details
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
        Me.ctrlBtnsOperator1.TabIndex = 0
        '
        'ctrlList
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.lsvData)
        Me.Controls.Add(Me.lblHeader1)
        Me.Controls.Add(Me.ctrlBtnsOperator1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "ctrlList"
        Me.Size = New System.Drawing.Size(1014, 615)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ctrlBtnsOperator1 As PSIS_CLIENT.ctrlBtnsOperator
    Friend WithEvents lblHeader1 As System.Windows.Forms.Label
    Friend WithEvents lsvData As System.Windows.Forms.ListView

End Class
