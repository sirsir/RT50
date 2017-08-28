Public Class frmWBSMonitoring_Edit

#Region "Constant"

#End Region

#Region "Enumerator"
#End Region

#Region "Attribute"
    Private m_intLaneNo As Integer
    'Private m_intSkitNo As Integer
    Private m_strModelYear As String
    Private m_strSuffixCode As String
    Private m_strLotNo As String
    Private m_strUnit As String

    Private m_objClsLogger As New clsLogger
#End Region

#Region "Constructor"

#End Region

#Region "Property"
    Public Property LaneNo() As Integer
        Get
            Return m_intLaneNo
        End Get
        Set(ByVal value As Integer)
            m_intLaneNo = value
            lblSelectedLaneNo.Text = m_intLaneNo
        End Set
    End Property

    Public Property ModelYear() As String
        Get
            Return m_strModelYear
        End Get
        Set(ByVal value As String)
            m_strModelYear = value
        End Set
    End Property

    Public Property SuffixCode() As String
        Get
            Return m_strSuffixCode
        End Get
        Set(ByVal value As String)
            m_strSuffixCode = value
        End Set
    End Property

    Public Property LotNo() As String
        Get
            Return m_strLotNo
        End Get
        Set(ByVal value As String)
            m_strLotNo = value
        End Set
    End Property

    Public Property Unit() As String
        Get
            Return m_strUnit
        End Get
        Set(ByVal value As String)
            m_strUnit = value
        End Set
    End Property

#End Region

#Region "Method"
#End Region

#Region "Event"

    Private Sub frmWBSMonitoring_Edit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'TODO: This line of code loads data into the 'dsPAINT.dtWBS_ON' table. You can move, or remove it, as needed.
            Me.taWBS_ON.Fill(dsPAINT1.dtWBS_ON)
            lblMsg.Text = String.Empty

            'TODO: This line of code loads data into the 'dsPAINT.dtLANE_MST' table. You can move, or remove it, as needed.
            Me.taWBS_ON.FillByWithEOL(dsPAINT1.dtWBS_ON, m_strModelYear, m_strSuffixCode, m_strLotNo, m_strUnit)
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "frmWBSMonitoring_Edit_Load", ex, True)
        End Try
    End Sub

    Private Sub btnExecute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExecute.Click
        Try
            Dim inputError As Boolean = False

            lblMsg.Text = String.Empty

            If DataGridView1.SelectedRows.Count = 0 Then
                If lblMsg.Text = String.Empty Then lblMsg.Text = "Error: Please select position"

                inputError = True
            End If

            If Not inputError Then
                Dim drv As DataRowView = bsWBS_ON.Current
                Dim dr As dsPAINT.dtWBS_ONRow = drv.Row
                LaneNo = dr.LANE_NO
                ModelYear = dr.MODEL_YEAR
                SuffixCode = dr.SUFFIX_CODE
                LotNo = dr.LOT_NO
                Unit = dr.UNIT

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "btnExecute_Click", ex, True)
        End Try
    End Sub

#End Region
End Class