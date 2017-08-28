<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SystemSetting
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dtgLineMST = New System.Windows.Forms.DataGridView
        Me.LineCodeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineTypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MainLineFlagDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.OnlineFlagDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Part1DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Part2DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Part3DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Part4DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Part5DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.IpAddressDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReadReqAddressDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WriteProductionAddressDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WriteCarryOutAddressDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MessagesDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NetAddressDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NodeAddressDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnitAddressDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TLineMSTBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ServerDataset = New PIS_SERVER.ServerDataset
        Me.btnUpdateLine = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.T_Line_MSTTableAdapter = New PIS_SERVER.ServerDatasetTableAdapters.T_Line_MSTTableAdapter
        CType(Me.dtgLineMST, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TLineMSTBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ServerDataset, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtgLineMST
        '
        Me.dtgLineMST.AllowUserToAddRows = False
        Me.dtgLineMST.AllowUserToDeleteRows = False
        Me.dtgLineMST.AllowUserToResizeRows = False
        Me.dtgLineMST.AutoGenerateColumns = False
        Me.dtgLineMST.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtgLineMST.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgLineMST.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LineCodeDataGridViewTextBoxColumn, Me.LineNameDataGridViewTextBoxColumn, Me.LineTypeDataGridViewTextBoxColumn, Me.MainLineFlagDataGridViewCheckBoxColumn, Me.OnlineFlagDataGridViewCheckBoxColumn, Me.Part1DataGridViewCheckBoxColumn, Me.Part2DataGridViewCheckBoxColumn, Me.Part3DataGridViewCheckBoxColumn, Me.Part4DataGridViewCheckBoxColumn, Me.Part5DataGridViewCheckBoxColumn, Me.IpAddressDataGridViewTextBoxColumn, Me.ReadReqAddressDataGridViewTextBoxColumn, Me.WriteProductionAddressDataGridViewTextBoxColumn, Me.WriteCarryOutAddressDataGridViewTextBoxColumn, Me.StatusDataGridViewTextBoxColumn, Me.MessagesDataGridViewTextBoxColumn, Me.NetAddressDataGridViewTextBoxColumn, Me.NodeAddressDataGridViewTextBoxColumn, Me.UnitAddressDataGridViewTextBoxColumn})
        Me.dtgLineMST.DataSource = Me.TLineMSTBindingSource
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgLineMST.DefaultCellStyle = DataGridViewCellStyle2
        Me.dtgLineMST.Location = New System.Drawing.Point(12, 12)
        Me.dtgLineMST.MultiSelect = False
        Me.dtgLineMST.Name = "dtgLineMST"
        Me.dtgLineMST.RowHeadersVisible = False
        Me.dtgLineMST.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgLineMST.Size = New System.Drawing.Size(868, 480)
        Me.dtgLineMST.TabIndex = 2
        '
        'LineCodeDataGridViewTextBoxColumn
        '
        Me.LineCodeDataGridViewTextBoxColumn.DataPropertyName = "LineCode"
        Me.LineCodeDataGridViewTextBoxColumn.HeaderText = "LineCode"
        Me.LineCodeDataGridViewTextBoxColumn.Name = "LineCodeDataGridViewTextBoxColumn"
        Me.LineCodeDataGridViewTextBoxColumn.ReadOnly = True
        Me.LineCodeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.LineCodeDataGridViewTextBoxColumn.Width = 58
        '
        'LineNameDataGridViewTextBoxColumn
        '
        Me.LineNameDataGridViewTextBoxColumn.DataPropertyName = "LineName"
        Me.LineNameDataGridViewTextBoxColumn.HeaderText = "LineName"
        Me.LineNameDataGridViewTextBoxColumn.Name = "LineNameDataGridViewTextBoxColumn"
        Me.LineNameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.LineNameDataGridViewTextBoxColumn.Width = 61
        '
        'LineTypeDataGridViewTextBoxColumn
        '
        Me.LineTypeDataGridViewTextBoxColumn.DataPropertyName = "LineType"
        Me.LineTypeDataGridViewTextBoxColumn.HeaderText = "LineType"
        Me.LineTypeDataGridViewTextBoxColumn.Name = "LineTypeDataGridViewTextBoxColumn"
        Me.LineTypeDataGridViewTextBoxColumn.ReadOnly = True
        Me.LineTypeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.LineTypeDataGridViewTextBoxColumn.Width = 57
        '
        'MainLineFlagDataGridViewCheckBoxColumn
        '
        Me.MainLineFlagDataGridViewCheckBoxColumn.DataPropertyName = "MainLineFlag"
        Me.MainLineFlagDataGridViewCheckBoxColumn.HeaderText = "MainLineFlag"
        Me.MainLineFlagDataGridViewCheckBoxColumn.Name = "MainLineFlagDataGridViewCheckBoxColumn"
        Me.MainLineFlagDataGridViewCheckBoxColumn.Width = 76
        '
        'OnlineFlagDataGridViewCheckBoxColumn
        '
        Me.OnlineFlagDataGridViewCheckBoxColumn.DataPropertyName = "OnlineFlag"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.NullValue = "False"
        Me.OnlineFlagDataGridViewCheckBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.OnlineFlagDataGridViewCheckBoxColumn.FalseValue = "false"
        Me.OnlineFlagDataGridViewCheckBoxColumn.HeaderText = "OnlineFlag"
        Me.OnlineFlagDataGridViewCheckBoxColumn.Name = "OnlineFlagDataGridViewCheckBoxColumn"
        Me.OnlineFlagDataGridViewCheckBoxColumn.TrueValue = "true"
        Me.OnlineFlagDataGridViewCheckBoxColumn.Width = 63
        '
        'Part1DataGridViewCheckBoxColumn
        '
        Me.Part1DataGridViewCheckBoxColumn.DataPropertyName = "Part1"
        Me.Part1DataGridViewCheckBoxColumn.HeaderText = "Part1"
        Me.Part1DataGridViewCheckBoxColumn.Name = "Part1DataGridViewCheckBoxColumn"
        Me.Part1DataGridViewCheckBoxColumn.Width = 38
        '
        'Part2DataGridViewCheckBoxColumn
        '
        Me.Part2DataGridViewCheckBoxColumn.DataPropertyName = "Part2"
        Me.Part2DataGridViewCheckBoxColumn.HeaderText = "Part2"
        Me.Part2DataGridViewCheckBoxColumn.Name = "Part2DataGridViewCheckBoxColumn"
        Me.Part2DataGridViewCheckBoxColumn.Width = 38
        '
        'Part3DataGridViewCheckBoxColumn
        '
        Me.Part3DataGridViewCheckBoxColumn.DataPropertyName = "Part3"
        Me.Part3DataGridViewCheckBoxColumn.HeaderText = "Part3"
        Me.Part3DataGridViewCheckBoxColumn.Name = "Part3DataGridViewCheckBoxColumn"
        Me.Part3DataGridViewCheckBoxColumn.Width = 38
        '
        'Part4DataGridViewCheckBoxColumn
        '
        Me.Part4DataGridViewCheckBoxColumn.DataPropertyName = "Part4"
        Me.Part4DataGridViewCheckBoxColumn.HeaderText = "Part4"
        Me.Part4DataGridViewCheckBoxColumn.Name = "Part4DataGridViewCheckBoxColumn"
        Me.Part4DataGridViewCheckBoxColumn.Width = 38
        '
        'Part5DataGridViewCheckBoxColumn
        '
        Me.Part5DataGridViewCheckBoxColumn.DataPropertyName = "Part5"
        Me.Part5DataGridViewCheckBoxColumn.HeaderText = "Part5"
        Me.Part5DataGridViewCheckBoxColumn.Name = "Part5DataGridViewCheckBoxColumn"
        Me.Part5DataGridViewCheckBoxColumn.Width = 38
        '
        'IpAddressDataGridViewTextBoxColumn
        '
        Me.IpAddressDataGridViewTextBoxColumn.DataPropertyName = "IpAddress"
        Me.IpAddressDataGridViewTextBoxColumn.HeaderText = "IpAddress"
        Me.IpAddressDataGridViewTextBoxColumn.Name = "IpAddressDataGridViewTextBoxColumn"
        Me.IpAddressDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.IpAddressDataGridViewTextBoxColumn.Width = 60
        '
        'ReadReqAddressDataGridViewTextBoxColumn
        '
        Me.ReadReqAddressDataGridViewTextBoxColumn.DataPropertyName = "ReadReqAddress"
        Me.ReadReqAddressDataGridViewTextBoxColumn.HeaderText = "ReadReqAddress"
        Me.ReadReqAddressDataGridViewTextBoxColumn.Name = "ReadReqAddressDataGridViewTextBoxColumn"
        Me.ReadReqAddressDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ReadReqAddressDataGridViewTextBoxColumn.Width = 97
        '
        'WriteProductionAddressDataGridViewTextBoxColumn
        '
        Me.WriteProductionAddressDataGridViewTextBoxColumn.DataPropertyName = "WriteProductionAddress"
        Me.WriteProductionAddressDataGridViewTextBoxColumn.HeaderText = "WriteProductionAddress"
        Me.WriteProductionAddressDataGridViewTextBoxColumn.Name = "WriteProductionAddressDataGridViewTextBoxColumn"
        Me.WriteProductionAddressDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.WriteProductionAddressDataGridViewTextBoxColumn.Width = 127
        '
        'WriteCarryOutAddressDataGridViewTextBoxColumn
        '
        Me.WriteCarryOutAddressDataGridViewTextBoxColumn.DataPropertyName = "WriteCarryOutAddress"
        Me.WriteCarryOutAddressDataGridViewTextBoxColumn.HeaderText = "WriteCarryOutAddress"
        Me.WriteCarryOutAddressDataGridViewTextBoxColumn.Name = "WriteCarryOutAddressDataGridViewTextBoxColumn"
        Me.WriteCarryOutAddressDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.WriteCarryOutAddressDataGridViewTextBoxColumn.Width = 117
        '
        'StatusDataGridViewTextBoxColumn
        '
        Me.StatusDataGridViewTextBoxColumn.DataPropertyName = "Status"
        Me.StatusDataGridViewTextBoxColumn.HeaderText = "Status"
        Me.StatusDataGridViewTextBoxColumn.Name = "StatusDataGridViewTextBoxColumn"
        Me.StatusDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.StatusDataGridViewTextBoxColumn.Visible = False
        Me.StatusDataGridViewTextBoxColumn.Width = 43
        '
        'MessagesDataGridViewTextBoxColumn
        '
        Me.MessagesDataGridViewTextBoxColumn.DataPropertyName = "Messages"
        Me.MessagesDataGridViewTextBoxColumn.HeaderText = "Messages"
        Me.MessagesDataGridViewTextBoxColumn.Name = "MessagesDataGridViewTextBoxColumn"
        Me.MessagesDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.MessagesDataGridViewTextBoxColumn.Visible = False
        Me.MessagesDataGridViewTextBoxColumn.Width = 61
        '
        'NetAddressDataGridViewTextBoxColumn
        '
        Me.NetAddressDataGridViewTextBoxColumn.DataPropertyName = "NetAddress"
        Me.NetAddressDataGridViewTextBoxColumn.HeaderText = "NetAddress"
        Me.NetAddressDataGridViewTextBoxColumn.Name = "NetAddressDataGridViewTextBoxColumn"
        Me.NetAddressDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.NetAddressDataGridViewTextBoxColumn.Width = 68
        '
        'NodeAddressDataGridViewTextBoxColumn
        '
        Me.NodeAddressDataGridViewTextBoxColumn.DataPropertyName = "NodeAddress"
        Me.NodeAddressDataGridViewTextBoxColumn.HeaderText = "NodeAddress"
        Me.NodeAddressDataGridViewTextBoxColumn.Name = "NodeAddressDataGridViewTextBoxColumn"
        Me.NodeAddressDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.NodeAddressDataGridViewTextBoxColumn.Width = 77
        '
        'UnitAddressDataGridViewTextBoxColumn
        '
        Me.UnitAddressDataGridViewTextBoxColumn.DataPropertyName = "UnitAddress"
        Me.UnitAddressDataGridViewTextBoxColumn.HeaderText = "UnitAddress"
        Me.UnitAddressDataGridViewTextBoxColumn.Name = "UnitAddressDataGridViewTextBoxColumn"
        Me.UnitAddressDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.UnitAddressDataGridViewTextBoxColumn.Width = 70
        '
        'TLineMSTBindingSource
        '
        Me.TLineMSTBindingSource.DataMember = "T_Line_MST"
        Me.TLineMSTBindingSource.DataSource = Me.ServerDataset
        '
        'ServerDataset
        '
        Me.ServerDataset.DataSetName = "ServerDataset"
        Me.ServerDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'btnUpdateLine
        '
        Me.btnUpdateLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdateLine.Location = New System.Drawing.Point(614, 514)
        Me.btnUpdateLine.Name = "btnUpdateLine"
        Me.btnUpdateLine.Size = New System.Drawing.Size(130, 40)
        Me.btnUpdateLine.TabIndex = 3
        Me.btnUpdateLine.Text = "UPDATE LINE"
        Me.btnUpdateLine.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(750, 514)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(130, 40)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "CANCEL"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'T_Line_MSTTableAdapter
        '
        Me.T_Line_MSTTableAdapter.ClearBeforeFill = True
        '
        'SystemSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(892, 566)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnUpdateLine)
        Me.Controls.Add(Me.dtgLineMST)
        Me.Name = "SystemSetting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SystemSetting"
        CType(Me.dtgLineMST, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TLineMSTBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ServerDataset, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtgLineMST As System.Windows.Forms.DataGridView
    Friend WithEvents btnUpdateLine As System.Windows.Forms.Button
    Friend WithEvents ServerDataset As PIS_SERVER.ServerDataset
    Friend WithEvents TLineMSTBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents T_Line_MSTTableAdapter As PIS_SERVER.ServerDatasetTableAdapters.T_Line_MSTTableAdapter
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents LineCodeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineTypeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MainLineFlagDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents OnlineFlagDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Part1DataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Part2DataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Part3DataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Part4DataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Part5DataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents IpAddressDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReadReqAddressDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WriteProductionAddressDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WriteCarryOutAddressDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MessagesDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NetAddressDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NodeAddressDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitAddressDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
