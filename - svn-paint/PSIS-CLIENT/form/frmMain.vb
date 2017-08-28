Public Class frmMain

#Region "Constant"

#End Region

#Region "Attribute"
    Private m_previousScreenName As String

    Private m_frmMsg As New frmMsg
    Private m_objClsLogger As New clsLogger

    Private WithEvents m_objDBStatus As clsDBStatus
#End Region

#Region "Constructor"
    Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ' '' Start Check DB status
        m_objDBStatus = New clsDBStatus
        m_objDBStatus.RunWorkerAsync()
    End Sub
#End Region

#Region "Property"

#End Region

#Region "Method"
    Private Sub ShowScreen(ByVal nScreenName As enuScreenName)
        Select Case nScreenName
            Case enuScreenName.Instruction_Data, enuScreenName.WBS_Pass_Result, _
            enuScreenName.Paint_Pass_Result, enuScreenName.PBR_Pass_Result, _
            enuScreenName.Finishing_Line, enuScreenName.Paint_Shop, _
            enuScreenName.Option_Master, enuScreenName.PLC_Master, _
            enuScreenName.Paint_Progress_Result, enuScreenName.Process_Group_Result
                ctrlList1.Visible = True
            Case enuScreenName.WBS
                ctrlProgress1.ProgressMode = ctrlProgress.enuProgressMode.WBS
                ctrlProgress1.Visible = True
            Case enuScreenName.WBS_Monitoring
                ctrlWBSMonitoring1.MonitorMode = ctrlWBSMonitoring.enuMonitorMode.edit
                ctrlWBSMonitoring1.Visible = True
            Case enuScreenName.Paint
                ctrlProgress1.ProgressMode = ctrlProgress.enuProgressMode.Paint
                ctrlProgress1.Visible = True
            Case enuScreenName.Process_Master
                ctrlProcMstList1.Visible = True
            Case enuScreenName.Model_Option_Setting, enuScreenName.Process_Option_Setting
                ctrlOptionList1.Visible = True
            Case enuScreenName.Data_Log
                ctrlDataLog1.Visible = True
        End Select

        Me.Text = ParseColumnName(nScreenName.ToString)
    End Sub

    Private Sub HideScreen()
        ctrlList1.Visible = False
        ctrlWBSMonitoring1.Visible = False
        ctrlProgress1.Visible = False
        ctrlDataLog1.Visible = False
        ctrlOptionList1.Visible = False
        ctrlProcMstList1.Visible = False
    End Sub
#End Region

#Region "Event"
    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            flp1.AutoScroll = False

            ctrlMenu1.RegisterKeyPreview(Me)
            ctrlWBSMonitoring1.CtrlBtnsOperator1.RegisterKeyPreview(Me)
            ctrlProgress1.ctrlBtnsOperator1.RegisterKeyPreview(Me)
            ctrlDataLog1.CtrlBtnsOperator1.RegisterKeyPreview(Me)
            ctrlOptionList1.ctrlBtnsOperator1.RegisterKeyPreview(Me)
            ctrlProcMstList1.ctrlBtnsOperator1.RegisterKeyPreview(Me)
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "frmMain_Load", ex, True)
        End Try
    End Sub

    Private Sub CtrlMenu1_OnBtnClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ctrlMenu1.OnBtnClick
        Try
            Dim btn As Button = DirectCast(sender, Button)

            Select Case btn.Tag
                Case "F12"
                    m_objDBStatus.CancelAsync()
                    Application.Exit()
                Case Else
                    ctrlMenu1.Visible = False
                    ShowScreen(ScreenName)
            End Select
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "CtrlMenu1_OnBtnClick", ex, True)
        End Try
    End Sub

    Private Sub ctrlWBSMonitoring1_OnOperatorClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
            ctrlWBSMonitoring1.OnOperatorClick
        Try
            Dim btn As Button = DirectCast(sender, Button)

            Select Case btn.Tag
                Case "F11"
                    ctrlWBSMonitoring1.Visible = False
                    ShowScreen(enuScreenName.WBS)
                Case Else
                    OnOperatorClick(sender, e)
            End Select
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "ctrlWBSMonitoring1_OnOperatorClick", ex, True)
        End Try
    End Sub

    Private Sub OnOperatorClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
            ctrlList1.OnOperatorClick, ctrlProgress1.OnOperatorClick, ctrlDataLog1.OnOperatorClick, _
            ctrlOptionList1.OnOperatorClick, ctrlProcMstList1.OnOperatorClick
        Try
            Dim btn As Button = DirectCast(sender, Button)

            Select Case btn.Tag
                Case "F11"
                    HideScreen()
                    Select Case ScreenName
                        Case enuScreenName.Paint_Progress_Result, enuScreenName.Process_Group_Result
                            ScreenName = enuScreenName.Paint
                        Case Else
                            ScreenName = enuScreenName.WBS
                    End Select
                    ShowScreen(ScreenName)
                Case "F12"
                    HideScreen()
                    Me.Text = btn.Text.Substring(4)
                    ctrlMenu1.Visible = True
            End Select
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "OnOperatorClick", ex, True)
        End Try
    End Sub

    Private Sub ctrlProgress1_OnClickWBS(ByVal sender As Object, ByVal e As System.EventArgs) Handles ctrlProgress1.OnClickWBS
        Try
            Dim dt As dsPAINT.dtWBS_ONDataTable = DirectCast(sender, dsPAINT.dtWBS_ONDataTable)

            ctrlWBSMonitoring1.PreSetDataTable = dt
            ctrlWBSMonitoring1.MonitorMode = ctrlWBSMonitoring.enuMonitorMode.view
            ctrlWBSMonitoring1.Visible = True
            ctrlProgress1.Visible = False
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "ctrlProgress1_OnClickWBS", ex, True)
        End Try
    End Sub

    Private Sub ctrlProgress1_OnClickLableCount(ByVal sender As Object, ByVal e As System.EventArgs) Handles ctrlProgress1.OnClickLableCount
        Try
            ctrlProgress1.Visible = False

            Dim lbl As Label = DirectCast(sender, Label)
            Dim matchCase As Match = Regex.Match(lbl.Name, "lblCtrlGroup.*|lblProcCount.*")

            If matchCase.Success Then
                ctrlList1.SetProcessLabel(lbl)
                ScreenName = IIf(Regex.Match(lbl.Name, "lblCtrlGroup.*").Success, enuScreenName.Process_Group_Result, enuScreenName.Paint_Progress_Result)
                ShowScreen(ScreenName)
            Else
                If lbl.Name = "lblFinishingLine" Then
                    ScreenName = enuScreenName.Finishing_Line
                    ShowScreen(ScreenName)
                ElseIf lbl.Name = "lblPaintShop" Then
                    ScreenName = enuScreenName.Paint_Shop
                    ShowScreen(ScreenName)
                End If
            End If
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "ctrlProgress1_OnClickLableCount", ex, True)
        End Try
    End Sub

    Private Sub m_objDBStatus_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles m_objDBStatus.ProgressChanged
        Try
            Me.ctrlDBStatus1.FillColor(m_objDBStatus.SuccessColor, m_objDBStatus.FailColor)

            If Not m_objDBStatus.LastConnectionStatus Then
                If Not m_frmMsg.IsActivate Then
                    m_frmMsg.IsActivate = True
                    m_frmMsg.SupportsShutdownApplication = True
                    m_frmMsg.MsgType = frmMsg.enuMsgType.errors
                    m_frmMsg.Message = "CAN'T CONNECT TO DATABASE"

                    m_frmMsg.ShowDialog()
                End If
            Else
                For Each frm As Form In My.Application.OpenForms
                    If frm Is m_frmMsg Then frm.Close() : m_frmMsg.IsActivate = False : Exit For
                Next
            End If
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "m_objDBStatus_ProgressChanged", ex, True)
        End Try
    End Sub

    Private Sub ctrlList1_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ctrlList1.VisibleChanged
        If ctrlList1.Visible Then
            ctrlList1.ctrlBtnsOperator1.RegisterKeyPreview(Me)
        Else
            ctrlList1.ctrlBtnsOperator1.DisableKeyPreview(Me)
        End If
    End Sub
#End Region
End Class