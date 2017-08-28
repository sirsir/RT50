Public Class ctrlLog

#Region "Constant"

#End Region

#Region "Enumerator"

#End Region

#Region "Attribute"
    Private m_objClsLogger As New clsLogger
#End Region

#Region "Constructor"

#End Region

#Region "Property"

#End Region

#Region "Method"
    Private Sub ReloadLog(ByVal blnReset As Boolean)
        Static dtOccDate As Date

        If blnReset Then dtOccDate = Now

        taLOG_DAT1.FillByOccurDate(dsPAINT1.dtLOG_DAT, My.Settings.Log_Count, dtOccDate)

        'If cboLogMsg.Items.Count > 1 Then cboLogMsg.SelectedIndex = 0

        SetColor()
    End Sub

    Private Sub SetColor()
        If dgvLogDat.Rows.Count > 0 Then
            dgvLogDat.BackgroundColor = Color.Red
            dgvLogDat.RowsDefaultCellStyle.BackColor = Color.Red
        Else
            dgvLogDat.BackgroundColor = Color.White
            dgvLogDat.RowsDefaultCellStyle.BackColor = Color.White
        End If
    End Sub
#End Region

#Region "Event"

    Private Sub ctrlLog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Timer1.Interval = My.Settings.Log_Interval.TotalMilliseconds
            Timer1.Enabled = True

            ReloadLog(True)
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "ctrlLog_Load", ex, True)
        End Try
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Try
            ReloadLog(True)
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "btnClear_Click", ex, True)
        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            Timer1.Enabled = False

            ReloadLog(False)

            Timer1.Enabled = True
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "Timer1_Tick", ex, True)
            Timer1.Enabled = True
        End Try
    End Sub

    'Private Sub ctrlLog_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
    '    If Me.Visible = True Then SetColor()
    'End Sub
#End Region

End Class
