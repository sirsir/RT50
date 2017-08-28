Public Class frmProcessSearch

#Region "Constant"

#End Region

#Region "Attribute"
    Private m_intProcNo As Integer
    Private m_intProcType As Integer = 1
    Private m_intProcCode As Integer
    Private m_intStageCode As Integer
    Private m_intPlcId As Integer

    Private m_taProcessMst As New taPROCESS_MST
    Private m_taPlcMst As New taPLC_MST
    Private m_objClsLogger As New clsLogger
#End Region

#Region "Constructor"

#End Region

#Region "Property"
    Public WriteOnly Property ProcessName() As String
        Set(ByVal value As String)
            txtProcName.Text = value
        End Set
    End Property

    Public ReadOnly Property ProcessNo() As Integer
        Get
            Return m_intProcNo
        End Get
    End Property

    Public Property ProcessType() As Integer
        Get
            Return m_intProcType
        End Get
        Set(ByVal value As Integer)
            m_intProcType = value
        End Set
    End Property

    Public ReadOnly Property ProcessCode() As Integer
        Get
            Return m_intProcCode
        End Get
    End Property

    Public ReadOnly Property StageCode() As Integer
        Get
            Return m_intStageCode
        End Get
    End Property

    Public ReadOnly Property PlcId() As Integer
        Get
            Return m_intPlcId
        End Get
    End Property
#End Region

#Region "Method"

    Private Sub GetResult()
        m_taProcessMst.FillByProcName(dsPAINT1.dtPROCESS_MST, _
                                      String.Concat(txtProcName.Text.Trim, "%"), _
                                      m_intProcType)
    End Sub

#End Region

#Region "Event"
    Private Sub frmProcessSearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            lblMsg.Text = String.Empty
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "frmProcessSearch_Load", ex, True)
        End Try
    End Sub

    Private Sub btnExecution_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExecution.Click
        Try
            lblMsg.Text = String.Empty
            lblProcessName.BackColor = SystemColors.Control

            GetResult()

            Select Case ScreenName
                Case enuScreenName.PLC_Master
            End Select

            Dim blnResult As Boolean = True
            If dsPAINT1.dtPROCESS_MST.Rows.Count > 0 Then
                Dim drRow As dsPAINT.dtPROCESS_MSTRow = dsPAINT1.dtPROCESS_MST.Rows(0)
                Select Case ScreenName
                    Case enuScreenName.PLC_Master
                        m_taPlcMst.Fill(dsPAINT1.dtPLC_MST)

                        If drRow.GetdtPLC_MSTRows.Length > 0 Then
                            m_intStageCode = drRow.GetdtPLC_MSTRows.First.STAGE_CODE
                            m_intPlcId = drRow.GetdtPLC_MSTRows.First.PLC_ID
                        End If
                    Case Else
                        m_intProcType = drRow.PROCESS_TYPE
                        m_intProcNo = drRow.PROCESS_NO
                        m_intProcCode = drRow.PROCESS_CODE
                End Select

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