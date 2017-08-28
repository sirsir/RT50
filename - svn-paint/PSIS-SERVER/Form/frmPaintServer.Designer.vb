<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPaintServer
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.btnExit = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.dgv_logData = New System.Windows.Forms.DataGridView
        Me.OCCDATEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MESSAGEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.bsTLogDat = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgv_lineMonitorView = New System.Windows.Forms.DataGridView
        Me.PROCESSNAMEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PROCESS_CODE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.STAGE_CODE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.STATUS = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Messages = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PROCESSTIMEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PROCESSTYPEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.bsTProcessMst = New System.Windows.Forms.BindingSource(Me.components)
        Me.TimerReloadAS400Log = New System.Windows.Forms.Timer(Me.components)
        Me.ctrlDBStatus = New Common.ctrlDBStatus
        Me.TimerCallExpSend = New System.Windows.Forms.Timer(Me.components)
        Me.TimerLockFile = New System.Windows.Forms.Timer(Me.components)
        CType(Me.dgv_logData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsTLogDat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_lineMonitorView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsTProcessMst, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(930, 684)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(74, 42)
        Me.btnExit.TabIndex = 3
        Me.btnExit.Text = "EXIT"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SandyBrown
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.Location = New System.Drawing.Point(55, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(910, 52)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "RT50 Paint Shop"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label2.Location = New System.Drawing.Point(11, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(997, 68)
        Me.Label2.TabIndex = 8
        '
        'dgv_logData
        '
        Me.dgv_logData.AllowUserToResizeColumns = False
        Me.dgv_logData.AllowUserToResizeRows = False
        Me.dgv_logData.AutoGenerateColumns = False
        Me.dgv_logData.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_logData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_logData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_logData.ColumnHeadersVisible = False
        Me.dgv_logData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.OCCDATEDataGridViewTextBoxColumn, Me.MESSAGEDataGridViewTextBoxColumn})
        Me.dgv_logData.DataSource = Me.bsTLogDat
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_logData.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_logData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgv_logData.GridColor = System.Drawing.Color.White
        Me.dgv_logData.Location = New System.Drawing.Point(11, 91)
        Me.dgv_logData.Name = "dgv_logData"
        Me.dgv_logData.RowHeadersVisible = False
        Me.dgv_logData.Size = New System.Drawing.Size(994, 287)
        Me.dgv_logData.TabIndex = 10
        '
        'OCCDATEDataGridViewTextBoxColumn
        '
        Me.OCCDATEDataGridViewTextBoxColumn.DataPropertyName = "OCC_DATE"
        Me.OCCDATEDataGridViewTextBoxColumn.HeaderText = "OCC_DATE"
        Me.OCCDATEDataGridViewTextBoxColumn.Name = "OCCDATEDataGridViewTextBoxColumn"
        Me.OCCDATEDataGridViewTextBoxColumn.Width = 110
        '
        'MESSAGEDataGridViewTextBoxColumn
        '
        Me.MESSAGEDataGridViewTextBoxColumn.DataPropertyName = "MESSAGE"
        Me.MESSAGEDataGridViewTextBoxColumn.HeaderText = "MESSAGE"
        Me.MESSAGEDataGridViewTextBoxColumn.Name = "MESSAGEDataGridViewTextBoxColumn"
        Me.MESSAGEDataGridViewTextBoxColumn.Width = 860
        '
        'bsTLogDat
        '
        Me.bsTLogDat.DataMember = "dtLOG_DAT"
        Me.bsTLogDat.DataSource = GetType(Common.dsPAINT)
        '
        'dgv_lineMonitorView
        '
        Me.dgv_lineMonitorView.AllowUserToAddRows = False
        Me.dgv_lineMonitorView.AllowUserToDeleteRows = False
        Me.dgv_lineMonitorView.AllowUserToResizeRows = False
        Me.dgv_lineMonitorView.AutoGenerateColumns = False
        Me.dgv_lineMonitorView.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_lineMonitorView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgv_lineMonitorView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_lineMonitorView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PROCESSNAMEDataGridViewTextBoxColumn, Me.PROCESS_CODE, Me.STAGE_CODE, Me.STATUS, Me.Messages, Me.PROCESSTIMEDataGridViewTextBoxColumn, Me.PROCESSTYPEDataGridViewTextBoxColumn})
        Me.dgv_lineMonitorView.DataSource = Me.bsTProcessMst
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_lineMonitorView.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgv_lineMonitorView.GridColor = System.Drawing.Color.DarkGray
        Me.dgv_lineMonitorView.Location = New System.Drawing.Point(11, 387)
        Me.dgv_lineMonitorView.MultiSelect = False
        Me.dgv_lineMonitorView.Name = "dgv_lineMonitorView"
        Me.dgv_lineMonitorView.ReadOnly = True
        Me.dgv_lineMonitorView.RowHeadersVisible = False
        Me.dgv_lineMonitorView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgv_lineMonitorView.Size = New System.Drawing.Size(994, 284)
        Me.dgv_lineMonitorView.TabIndex = 11
        Me.dgv_lineMonitorView.TabStop = False
        '
        'PROCESSNAMEDataGridViewTextBoxColumn
        '
        Me.PROCESSNAMEDataGridViewTextBoxColumn.DataPropertyName = "PROCESS_NAME"
        Me.PROCESSNAMEDataGridViewTextBoxColumn.HeaderText = "PROCESS_NAME"
        Me.PROCESSNAMEDataGridViewTextBoxColumn.Name = "PROCESSNAMEDataGridViewTextBoxColumn"
        Me.PROCESSNAMEDataGridViewTextBoxColumn.ReadOnly = True
        Me.PROCESSNAMEDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'PROCESS_CODE
        '
        Me.PROCESS_CODE.DataPropertyName = "PROCESS_CODE"
        Me.PROCESS_CODE.HeaderText = "PROCESS_CODE"
        Me.PROCESS_CODE.Name = "PROCESS_CODE"
        Me.PROCESS_CODE.ReadOnly = True
        Me.PROCESS_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.PROCESS_CODE.Visible = False
        '
        'STAGE_CODE
        '
        Me.STAGE_CODE.DataPropertyName = "STAGE_CODE"
        Me.STAGE_CODE.HeaderText = "STAGE_CODE"
        Me.STAGE_CODE.Name = "STAGE_CODE"
        Me.STAGE_CODE.ReadOnly = True
        Me.STAGE_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'STATUS
        '
        Me.STATUS.DataPropertyName = "CUR_STATUS"
        Me.STATUS.HeaderText = "STATUS"
        Me.STATUS.Name = "STATUS"
        Me.STATUS.ReadOnly = True
        Me.STATUS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Messages
        '
        Me.Messages.DataPropertyName = "LASTEST_MSG"
        Me.Messages.HeaderText = "Messages"
        Me.Messages.Name = "Messages"
        Me.Messages.ReadOnly = True
        Me.Messages.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Messages.Width = 770
        '
        'PROCESSTIMEDataGridViewTextBoxColumn
        '
        Me.PROCESSTIMEDataGridViewTextBoxColumn.DataPropertyName = "PROCESS_TIME"
        Me.PROCESSTIMEDataGridViewTextBoxColumn.HeaderText = "PROCESS_TIME"
        Me.PROCESSTIMEDataGridViewTextBoxColumn.Name = "PROCESSTIMEDataGridViewTextBoxColumn"
        Me.PROCESSTIMEDataGridViewTextBoxColumn.ReadOnly = True
        Me.PROCESSTIMEDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.PROCESSTIMEDataGridViewTextBoxColumn.Visible = False
        '
        'PROCESSTYPEDataGridViewTextBoxColumn
        '
        Me.PROCESSTYPEDataGridViewTextBoxColumn.DataPropertyName = "PROCESS_TYPE"
        Me.PROCESSTYPEDataGridViewTextBoxColumn.HeaderText = "PROCESS_TYPE"
        Me.PROCESSTYPEDataGridViewTextBoxColumn.Name = "PROCESSTYPEDataGridViewTextBoxColumn"
        Me.PROCESSTYPEDataGridViewTextBoxColumn.ReadOnly = True
        Me.PROCESSTYPEDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.PROCESSTYPEDataGridViewTextBoxColumn.Visible = False
        '
        'bsTProcessMst
        '
        Me.bsTProcessMst.DataMember = "dtPlcStatus"
        Me.bsTProcessMst.DataSource = GetType(Common.dsPAINT)
        '
        'TimerReloadAS400Log
        '
        Me.TimerReloadAS400Log.Interval = 10
        '
        'ctrlDBStatus
        '
        Me.ctrlDBStatus.BackColor = System.Drawing.Color.Transparent
        Me.ctrlDBStatus.LastConnectionStatus = False
        Me.ctrlDBStatus.Location = New System.Drawing.Point(748, 677)
        Me.ctrlDBStatus.Name = "ctrlDBStatus"
        Me.ctrlDBStatus.Size = New System.Drawing.Size(176, 53)
        Me.ctrlDBStatus.TabIndex = 12
        '
        'TimerCallExpSend
        '
        Me.TimerCallExpSend.Interval = 1000
        '
        'TimerLockFile
        '
        Me.TimerLockFile.Interval = 5000
        '
        'frmPaintServer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1016, 734)
        Me.ControlBox = False
        Me.Controls.Add(Me.ctrlDBStatus)
        Me.Controls.Add(Me.dgv_lineMonitorView)
        Me.Controls.Add(Me.dgv_logData)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnExit)
        Me.Name = "frmPaintServer"
        Me.Text = "Paint Instrunction Server"
        CType(Me.dgv_logData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsTLogDat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_lineMonitorView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsTProcessMst, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgv_logData As System.Windows.Forms.DataGridView
    Friend WithEvents dgv_lineMonitorView As System.Windows.Forms.DataGridView
    Friend WithEvents bsTLogDat As System.Windows.Forms.BindingSource
    Friend WithEvents TimerReloadAS400Log As System.Windows.Forms.Timer
    Friend WithEvents OCCDATEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MESSAGEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bsTProcessMst As System.Windows.Forms.BindingSource
    Friend WithEvents PROCESSONLINEFLAGDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents PLCNETDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PLCNODEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PLCUNITDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents READDMDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WRITEDATADMDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WRITESTATUSDMDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ctrlDBStatus As Common.ctrlDBStatus
    Friend WithEvents PROCESSNAMEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PROCESS_CODE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STAGE_CODE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STATUS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Messages As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PROCESSTIMEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PROCESSTYPEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TimerCallExpSend As System.Windows.Forms.Timer
    Friend WithEvents TimerLockFile As System.Windows.Forms.Timer

End Class
