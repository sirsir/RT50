Imports Common



Public Class Main_Menu
    Private m_clsGetRuntime As clsGetRuntime = clsGetRuntime.GetInstance()
    Dim logger As Logger = New Logger()
    Dim chkPrd As Boolean = True
    Dim chkIns As Boolean = True

    'Production Screen
    Private Sub btnF1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnF1.Click

        If chkPrd Then
            'Me.Hide()
            logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnF1_Click", "Open Production Screen", "")
            ProductionData.ShowDialog()
        Else
            MessageBox.Show("No data in Production!!!")
        End If

    End Sub

    'Instruction Screen
    Private Sub btnF2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnF2.Click

        If chkIns Then
            'Me.Hide()
            logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnF2_Click", "Open Instruction Screen", "")
            InstructionSch.ShowDialog()
        Else
            MessageBox.Show("No data in Instruction!!!")
        End If

    End Sub

    'Carry Out Screen
    Private Sub btnF3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnF3.Click

        If chkIns Then
            'Me.Hide()
            logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnF3_Click", "Open Carry Out Screen", "")
            CarryOutSch.ShowDialog()
        Else
            MessageBox.Show("No data in Instruction!!!")
        End If

    End Sub

    Private Sub btnF5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnF5.Click
        'Me.Hide()
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnF5_Click", "Open DataLog Screen", "")
        DataLog.ShowDialog()
    End Sub

    Private Sub btnF12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnF12.Click
        'Me.Hide()
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnF12_Click", "Open Shutdown Screen", "")
        Shutdown.ShowDialog()
    End Sub

    Private Sub Main_Menu_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyData
            Case Keys.F1
                btnF1_Click(sender, e)
            Case Keys.F2
                btnF2_Click(sender, e)
            Case Keys.F3
                btnF3_Click(sender, e)
            Case Keys.F5
                btnF5_Click(sender, e)
            Case Keys.F12
                btnF12_Click(sender, e)
        End Select
    End Sub

    Private Declare Function SetSysColors Lib "user32" (ByVal nChanges _
     As Long, ByVal lpSysColor As Long, ByVal lpColorValues As Long) As Long
    Private Declare Function GetSysColor Lib "user32" (ByVal nIndex _
       As Long) As Long


    Private Sub Main_Menu_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        m_clsGetRuntime.setRunTime()
        Timer1.Start()
        Timer2.Start()
        logger.SystemStart()

        Try
            'Dim prdt As DataSet1.T_Production_DATDataTable = New DataSet1.T_Production_DATDataTable()
            'Dim insdt As DataSet1.T_Instruction_DATDataTable = New DataSet1.T_Instruction_DATDataTable()

            'T_Production_DATTableAdapter.Fill(prdt)
            'T_Instruction_DATTableAdapter.Fill(insdt)



            'If prdt.Rows.Count = 0 Then
            '    chkPrd = False
            'End If

            'If insdt.Rows.Count = 0 Then
            '    chkIns = False
            'End If
        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "Load Main_Menu", ex.Message, "")
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            Dim aDate As Date = m_clsGetRuntime.getRunTime()
            Dim dt As DataSet1.T_LOG_DATDataTable = DataSet1.T_LOG_DAT
            T_LOG_DATTableAdapter.FillByTop30LogType0_1(dt, aDate)
            enableAllBtn()
        Catch ex As Exception
            disableAllBtn()
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "Timer1_Tick", ex.Message, "")
            'Timer1.Stop()
        End Try

    End Sub

    Private Sub cmboxLogInfo_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmboxLogInfo.DropDown
        Timer1.Stop()
    End Sub

    Private Sub cmboxLogInfo_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmboxLogInfo.DropDownClosed
        Timer1.Start()
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Label1.Text = Now.ToString("dd MMM yyyy  HH:mm:ss")
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub disableAllBtn()
        btnF1.Enabled = False
        btnF2.Enabled = False
        btnF3.Enabled = False
        btnF5.Enabled = False
        btnF12.Enabled = False
    End Sub

    Private Sub enableAllBtn()
        btnF1.Enabled = True
        btnF2.Enabled = True
        btnF3.Enabled = True
        btnF5.Enabled = True
        btnF12.Enabled = True
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnClear_Click", "Click Clear Button", "")
        m_clsGetRuntime.setRunTime()
    End Sub
End Class
