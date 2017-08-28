Public Class frmOptionMST_Setting_Search

#Region "Attribute"
    Private m_taOptMST As New taOPTION_MST
    Private m_objClsLogger As New clsLogger

    Private m_intOptSeq As Integer
    Private m_intOptType As Integer
#End Region

#Region "Property"
    Public ReadOnly Property OptionSeq() As Integer
        Get
            Return m_intOptSeq
        End Get
    End Property

    Public ReadOnly Property OptionType() As Integer
        Get
            Return m_intOptType
        End Get
    End Property
#End Region

#Region "Method"

    Private Sub GetResult()
        m_taOptMST.FillByOptDisp(dsPAINT1.dtOPTION_MST, _
                                 String.Concat(txtOptDisplay.Text.Trim, "%"))
    End Sub

#End Region

#Region "Event"
    Private Sub frmOptionMST_Setting_Search_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            lblMsg.Text = String.Empty
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "frmOptionMST_Setting_Search_Load", ex, True)
        End Try
    End Sub

    Private Sub btnExecution_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExecution.Click
        Try
            lblMsg.Text = String.Empty

            GetResult()

            If dsPAINT1.dtOPTION_MST.Rows.Count > 0 Then
                Dim drRow As dsPAINT.dtOPTION_MSTRow
                drRow = dsPAINT1.dtOPTION_MST.Rows(0)

                m_intOptType = drRow.OPTION_TYPE
                m_intOptSeq = drRow.OPTION_SEQ

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            ElseIf (lblMsg.Text = String.Empty) Then
                lblMsg.Text = "No data match with search condition"
            End If
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "btnExecution_Click", ex, True)
        End Try
    End Sub
#End Region

End Class