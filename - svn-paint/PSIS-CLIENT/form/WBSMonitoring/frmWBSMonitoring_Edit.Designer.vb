<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWBSMonitoring_Edit
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
        Me.components = New System.ComponentModel.Container
        Me.btnExecute = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.lblMsg = New System.Windows.Forms.Label
        Me.lblSelectedLaneNo = New System.Windows.Forms.Label
        Me.lblSelectedSkitNo = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.LANENODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SEQUENCEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POSITIONDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.bsWBS_ON = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsPAINT1 = New Common.dsPAINT
        Me.taWBS_ON = New Common.dsPAINTTableAdapters.taWBS_ON
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsWBS_ON, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsPAINT1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnExecute
        '
        Me.btnExecute.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnExecute.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExecute.Location = New System.Drawing.Point(22, 225)
        Me.btnExecute.Name = "btnExecute"
        Me.btnExecute.Size = New System.Drawing.Size(106, 29)
        Me.btnExecute.TabIndex = 8
        Me.btnExecute.Text = "EXECUTION"
        Me.btnExecute.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(160, 225)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(106, 29)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "CANCEL"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lblMsg
        '
        Me.lblMsg.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblMsg.AutoSize = True
        Me.lblMsg.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsg.ForeColor = System.Drawing.Color.Red
        Me.lblMsg.Location = New System.Drawing.Point(12, 194)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(129, 16)
        Me.lblMsg.TabIndex = 11
        Me.lblMsg.Text = "Notification Message"
        '
        'lblSelectedLaneNo
        '
        Me.lblSelectedLaneNo.AutoSize = True
        Me.lblSelectedLaneNo.BackColor = System.Drawing.Color.Transparent
        Me.lblSelectedLaneNo.Location = New System.Drawing.Point(103, 15)
        Me.lblSelectedLaneNo.Name = "lblSelectedLaneNo"
        Me.lblSelectedLaneNo.Size = New System.Drawing.Size(13, 13)
        Me.lblSelectedLaneNo.TabIndex = 12
        Me.lblSelectedLaneNo.Text = "0"
        '
        'lblSelectedSkitNo
        '
        Me.lblSelectedSkitNo.AutoSize = True
        Me.lblSelectedSkitNo.BackColor = System.Drawing.Color.Transparent
        Me.lblSelectedSkitNo.Location = New System.Drawing.Point(103, 42)
        Me.lblSelectedSkitNo.Name = "lblSelectedSkitNo"
        Me.lblSelectedSkitNo.Size = New System.Drawing.Size(13, 13)
        Me.lblSelectedSkitNo.TabIndex = 12
        Me.lblSelectedSkitNo.Text = "0"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 24)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Lane"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 24)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Skid No"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LANENODataGridViewTextBoxColumn, Me.SEQUENCEDataGridViewTextBoxColumn, Me.POSITIONDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.bsWBS_ON
        Me.DataGridView1.Location = New System.Drawing.Point(12, 63)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(268, 128)
        Me.DataGridView1.TabIndex = 13
        '
        'LANENODataGridViewTextBoxColumn
        '
        Me.LANENODataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.LANENODataGridViewTextBoxColumn.DataPropertyName = "LANE_NO"
        Me.LANENODataGridViewTextBoxColumn.HeaderText = "Lane"
        Me.LANENODataGridViewTextBoxColumn.Name = "LANENODataGridViewTextBoxColumn"
        Me.LANENODataGridViewTextBoxColumn.ReadOnly = True
        Me.LANENODataGridViewTextBoxColumn.Width = 56
        '
        'SEQUENCEDataGridViewTextBoxColumn
        '
        Me.SEQUENCEDataGridViewTextBoxColumn.DataPropertyName = "SEQUENCE"
        Me.SEQUENCEDataGridViewTextBoxColumn.HeaderText = "SEQUENCE"
        Me.SEQUENCEDataGridViewTextBoxColumn.Name = "SEQUENCEDataGridViewTextBoxColumn"
        Me.SEQUENCEDataGridViewTextBoxColumn.ReadOnly = True
        Me.SEQUENCEDataGridViewTextBoxColumn.Visible = False
        '
        'POSITIONDataGridViewTextBoxColumn
        '
        Me.POSITIONDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.POSITIONDataGridViewTextBoxColumn.DataPropertyName = "POSITION"
        Me.POSITIONDataGridViewTextBoxColumn.HeaderText = "Before Unit"
        Me.POSITIONDataGridViewTextBoxColumn.Name = "POSITIONDataGridViewTextBoxColumn"
        Me.POSITIONDataGridViewTextBoxColumn.ReadOnly = True
        Me.POSITIONDataGridViewTextBoxColumn.Width = 85
        '
        'bsWBS_ON
        '
        Me.bsWBS_ON.DataMember = "dtWBS_ON"
        Me.bsWBS_ON.DataSource = Me.dsPAINT1
        '
        'dsPAINT1
        '
        Me.dsPAINT1.DataSetName = "dsPAINT"
        Me.dsPAINT1.Locale = New System.Globalization.CultureInfo("th-TH")
        Me.dsPAINT1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'taWBS_ON
        '
        Me.taWBS_ON.ClearBeforeFill = True
        '
        'frmWBSMonitoring_Edit
        '
        Me.AcceptButton = Me.btnExecute
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblSelectedSkitNo)
        Me.Controls.Add(Me.lblSelectedLaneNo)
        Me.Controls.Add(Me.lblMsg)
        Me.Controls.Add(Me.btnExecute)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmWBSMonitoring_Edit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Edit Lane/Position"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsWBS_ON, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsPAINT1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnExecute As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents lblSelectedLaneNo As System.Windows.Forms.Label
    Friend WithEvents lblSelectedSkitNo As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents dsPAINT1 As Common.dsPAINT
    Friend WithEvents bsWBS_ON As System.Windows.Forms.BindingSource
    Friend WithEvents taWBS_ON As taWBS_ON
    Friend WithEvents SKITNODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LANENODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SEQUENCEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POSITIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
