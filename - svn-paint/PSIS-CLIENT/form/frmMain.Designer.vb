<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.flp1 = New System.Windows.Forms.FlowLayoutPanel
        Me.ctrlDBStatus1 = New Common.ctrlDBStatus
        Me.ctrlProcMstList1 = New PSIS_CLIENT.ctrlProcMstList
        Me.ctrlOptionList1 = New PSIS_CLIENT.ctrlOptionList
        Me.ctrlProgress1 = New PSIS_CLIENT.ctrlProgress
        Me.ctrlList1 = New PSIS_CLIENT.ctrlList
        Me.ctrlMenu1 = New PSIS_CLIENT.ctrlMenu
        Me.ctrlWBSMonitoring1 = New PSIS_CLIENT.ctrlWBSMonitoring
        Me.ctrlDataLog1 = New PSIS_CLIENT.ctrlDataLog
        Me.ctrlLog1 = New PSIS_CLIENT.ctrlLog
        Me.flp1.SuspendLayout()
        Me.SuspendLayout()
        '
        'flp1
        '
        Me.flp1.AutoScroll = True
        Me.flp1.Controls.Add(Me.ctrlProcMstList1)
        Me.flp1.Controls.Add(Me.ctrlOptionList1)
        Me.flp1.Controls.Add(Me.ctrlProgress1)
        Me.flp1.Controls.Add(Me.ctrlList1)
        Me.flp1.Controls.Add(Me.ctrlMenu1)
        Me.flp1.Controls.Add(Me.ctrlWBSMonitoring1)
        Me.flp1.Controls.Add(Me.ctrlDataLog1)
        Me.flp1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flp1.Location = New System.Drawing.Point(0, 2)
        Me.flp1.Name = "flp1"
        Me.flp1.Size = New System.Drawing.Size(1018, 615)
        Me.flp1.TabIndex = 0
        '
        'ctrlDBStatus1
        '
        Me.ctrlDBStatus1.BackColor = System.Drawing.Color.Transparent
        Me.ctrlDBStatus1.LastConnectionStatus = False
        Me.ctrlDBStatus1.Location = New System.Drawing.Point(0, 670)
        Me.ctrlDBStatus1.Name = "ctrlDBStatus1"
        Me.ctrlDBStatus1.Size = New System.Drawing.Size(176, 30)
        Me.ctrlDBStatus1.TabIndex = 2
        '
        'ctrlProcMstList1
        '
        Me.ctrlProcMstList1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ctrlProcMstList1.Location = New System.Drawing.Point(3, 4)
        Me.ctrlProcMstList1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ctrlProcMstList1.Name = "ctrlProcMstList1"
        Me.ctrlProcMstList1.Size = New System.Drawing.Size(1014, 615)
        Me.ctrlProcMstList1.TabIndex = 6
        Me.ctrlProcMstList1.Visible = False
        '
        'ctrlOptionList1
        '
        Me.ctrlOptionList1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ctrlOptionList1.Location = New System.Drawing.Point(1023, 4)
        Me.ctrlOptionList1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ctrlOptionList1.Name = "ctrlOptionList1"
        Me.ctrlOptionList1.Size = New System.Drawing.Size(1014, 615)
        Me.ctrlOptionList1.TabIndex = 5
        Me.ctrlOptionList1.Visible = False
        '
        'ctrlProgress1
        '
        Me.ctrlProgress1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ctrlProgress1.Location = New System.Drawing.Point(2043, 4)
        Me.ctrlProgress1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ctrlProgress1.Name = "ctrlProgress1"
        Me.ctrlProgress1.ProgressMode = PSIS_CLIENT.ctrlProgress.enuProgressMode.WBS
        Me.ctrlProgress1.Size = New System.Drawing.Size(1014, 615)
        Me.ctrlProgress1.TabIndex = 2
        Me.ctrlProgress1.Visible = False
        '
        'ctrlList1
        '
        Me.ctrlList1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ctrlList1.Location = New System.Drawing.Point(3063, 4)
        Me.ctrlList1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ctrlList1.Name = "ctrlList1"
        Me.ctrlList1.Size = New System.Drawing.Size(1014, 615)
        Me.ctrlList1.TabIndex = 1
        Me.ctrlList1.Visible = False
        '
        'ctrlMenu1
        '
        Me.ctrlMenu1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ctrlMenu1.Location = New System.Drawing.Point(4083, 3)
        Me.ctrlMenu1.Name = "ctrlMenu1"
        Me.ctrlMenu1.Size = New System.Drawing.Size(1014, 615)
        Me.ctrlMenu1.TabIndex = 0
        '
        'ctrlWBSMonitoring1
        '
        Me.ctrlWBSMonitoring1.BackColor = System.Drawing.SystemColors.Control
        Me.ctrlWBSMonitoring1.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.ctrlWBSMonitoring1.Location = New System.Drawing.Point(5103, 4)
        Me.ctrlWBSMonitoring1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ctrlWBSMonitoring1.MonitorMode = PSIS_CLIENT.ctrlWBSMonitoring.enuMonitorMode.edit
        Me.ctrlWBSMonitoring1.Name = "ctrlWBSMonitoring1"
        Me.ctrlWBSMonitoring1.Size = New System.Drawing.Size(1014, 615)
        Me.ctrlWBSMonitoring1.TabIndex = 3
        Me.ctrlWBSMonitoring1.Visible = False
        '
        'ctrlDataLog1
        '
        Me.ctrlDataLog1.Location = New System.Drawing.Point(6123, 5)
        Me.ctrlDataLog1.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.ctrlDataLog1.Name = "ctrlDataLog1"
        Me.ctrlDataLog1.Size = New System.Drawing.Size(1014, 615)
        Me.ctrlDataLog1.TabIndex = 4
        Me.ctrlDataLog1.Visible = False
        '
        'ctrlLog1
        '
        Me.ctrlLog1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ctrlLog1.Location = New System.Drawing.Point(178, 623)
        Me.ctrlLog1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ctrlLog1.Name = "ctrlLog1"
        Me.ctrlLog1.Size = New System.Drawing.Size(840, 122)
        Me.ctrlLog1.TabIndex = 1
        '
        'frmMain
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1018, 744)
        Me.ControlBox = False
        Me.Controls.Add(Me.ctrlDBStatus1)
        Me.Controls.Add(Me.flp1)
        Me.Controls.Add(Me.ctrlLog1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmMain"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MAIN MENU"
        Me.flp1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents flp1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents ctrlMenu1 As PSIS_CLIENT.ctrlMenu
    Friend WithEvents ctrlList1 As PSIS_CLIENT.ctrlList
    Friend WithEvents ctrlWBSMonitoring1 As PSIS_CLIENT.ctrlWBSMonitoring
    Friend WithEvents ctrlProgress1 As PSIS_CLIENT.ctrlProgress
    Friend WithEvents ctrlDataLog1 As PSIS_CLIENT.ctrlDataLog
    Friend WithEvents ctrlOptionList1 As PSIS_CLIENT.ctrlOptionList
    Friend WithEvents ctrlProcMstList1 As PSIS_CLIENT.ctrlProcMstList
    Friend WithEvents ctrlLog1 As PSIS_CLIENT.ctrlLog
    Friend WithEvents ctrlDBStatus1 As Common.ctrlDBStatus
End Class
