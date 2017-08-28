Public Class ctrlProgress
#Region "Constant"

#End Region

#Region "Enumerator"
    Public Enum enuProgressMode
        WBS
        Paint
    End Enum
#End Region

#Region "Attribute"
    Private m_nProgressMode As enuProgressMode
    Private m_dtProcGroupMST As dsPAINT.dtPROCESS_GROUP_MSTDataTable = New dsPAINT.dtPROCESS_GROUP_MSTDataTable
    Private m_taProcGroupMST As dsPAINTTableAdapters.taPROCESS_GROUP_MST = New dsPAINTTableAdapters.taPROCESS_GROUP_MST
    Private m_objClsLogger As New clsLogger
#End Region

#Region "Constructor"

#End Region

#Region "Property"
    Public Property ProgressMode() As enuProgressMode
        Get
            Return m_nProgressMode
        End Get
        Set(ByVal value As enuProgressMode)
            m_nProgressMode = value
            SetDisplayPanel()
        End Set
    End Property
#End Region

#Region "Method"
    Private Sub LoadCountings()
        Select Case m_nProgressMode
            Case enuProgressMode.WBS
                taWBS_ON1.Fill(dsPAINT1.dtWBS_ON)
                lblWBS.Text = dsPAINT1.dtWBS_ON.Rows.Count

                taFINISHING_LINE1.Fill(dsPAINT1.dtFINISHING_LINE)
                lblFinishingLine.Text = dsPAINT1.dtFINISHING_LINE.Rows.Count
                taPAINT_SHOP1.Fill(dsPAINT1.dtPAINT_SHOP)
                lblPaintShop.Text = dsPAINT1.dtPAINT_SHOP.Rows.Count
            Case enuProgressMode.Paint
                Me.flpPntProg.Controls.Clear()
                m_taProcGroupMST.FillByProcGroupSeq(m_dtProcGroupMST)

                For Each row As dsPAINT.dtPROCESS_GROUP_MSTRow In m_dtProcGroupMST.Rows
                    Dim ctrlProcGroup As ctrlProcGroup = New ctrlProcGroup(row.PROCESS_GROUP_ID, m_dtProcGroupMST.Rows.Count)

                    ctrlProcGroup.ctrlGroup.lblProcName.Text = row.PROCESS_GROUP_NAME
                    ctrlProcGroup.ctrlGroup.lblProcCount.Name = "lblCtrlGroup" + row.PROCESS_GROUP_ID.ToString

                    Me.flpPntProg.Controls.Add(ctrlProcGroup)

                    AddHandler ctrlProcGroup.OnClickLableCount, AddressOf lblCount_Click

                    If m_dtProcGroupMST.Rows.Count > 4 Then
                        ctrlProcGroup.Size = New Size(Me.flpPntProg.Size.Width / 5.3, 610)
                        ctrlProcGroup.Margin = New Padding(5)
                    End If
                Next

        End Select

        'Dim tmp As Label = Me.Controls.Find("lbl", True)(0)
    End Sub

    Private Sub SetDisplayPanel()
        Select Case m_nProgressMode
            Case enuProgressMode.WBS
                pnlWBS.Visible = True
                pnlPaintProgress.Visible = False
            Case enuProgressMode.Paint
                pnlWBS.Visible = False
                pnlPaintProgress.Visible = True
        End Select
    End Sub
#End Region

#Region "Event"
    Public Event OnOperatorClick(ByVal sender As Object, ByVal e As EventArgs)
    Public Event OnClickWBS(ByVal sender As Object, ByVal e As EventArgs)
    Public Event OnClickLableCount(ByVal sender As Object, ByVal e As EventArgs)

    Private Sub ctrlProgress_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            flp.AutoScroll = False
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "ctrlProgress_Load", ex, True)
        End Try
    End Sub

    Private Sub ctrlBtnsOperator1_OnOperatorClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ctrlBtnsOperator1.OnOperatorClick
        Try
            Dim btn As Button = DirectCast(sender, Button)

            Select Case btn.Tag
                Case "F12"
                    RaiseEvent OnOperatorClick(btn, e)
            End Select
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "ctrlBtnsOperator1_OnOperatorClick", ex, True)
        End Try
    End Sub

    Private Sub lblWBS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblWBS.Click
        Try
            RaiseEvent OnClickWBS(dsPAINT1.dtWBS_ON, e)
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "lblWBS_Click", ex, True)
        End Try
    End Sub

    Private Sub lblCount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
    lblFinishingLine.Click, lblPaintShop.Click
        Try
            RaiseEvent OnClickLableCount(sender, e)
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "lblCount_Click", ex, True)
        End Try
    End Sub

    Public Sub lblProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            RaiseEvent OnClickLableCount(sender, e)
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "lblProcess_Click", ex, True)
        End Try
    End Sub

    Private Sub ctrlProgress_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        Try
            If Me.Visible = True Then
                LoadCountings()
                timer1.Interval = My.Settings.Counting_Progress_Interval.TotalMilliseconds
                timer1.Start()
            Else
                timer1.Stop()
            End If
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "ctrlProgress_VisibleChanged", ex, True)
        End Try
    End Sub

    Private Sub timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles timer1.Tick
        Try
            timer1.Stop()

            LoadCountings()

            timer1.Start()
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "timer1_Tick", ex, True)
        End Try
    End Sub
#End Region

End Class
