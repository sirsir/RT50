Public Class ctrlWBSM_StockData

#Region "Constant"
    Friend Const LBL_MODLE_CODE_BACKGROUND As Integer = &HFFFFBF00
    Friend Const LBL_LOT_NO_UNIT_NO_BACKGROUND As Integer = &HFF8DB3E3

    Friend Const LBL_SELECTED_MODLE_CODE_BACKGROUND As Integer = &HFF3333FF
    Friend Const LBL_SELECTED_LOT_NO_BACKGROUND As Integer = &HFF7777FF
#End Region

#Region "Enumerator"

#End Region

#Region "Attribute"
    Private m_blnSelected As Boolean
    Private m_objClsLogger As New clsLogger

    Private m_strModelYear As String
    Private m_strSuffixCode As String
    Private m_strLotNo As String
    Private m_strUnit As String
#End Region

#Region "Constructor"

#End Region

#Region "Property"
    Public Property ModelCode() As String
        Get
            Return lblModelCode.Text
        End Get
        Set(ByVal value As String)
            lblModelCode.Text = value

            RefreshVisible()
        End Set
    End Property

    Public Property LotNoUnitNo() As String
        Get
            Return lblLotNoUnitNo.Text
        End Get
        Set(ByVal value As String)
            lblLotNoUnitNo.Text = value
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

    Public ReadOnly Property Selected() As Boolean
        Get
            Return m_blnSelected
        End Get
    End Property

#End Region

#Region "Method"

    Private Sub RefreshVisible()
        Dim bEmpty As Boolean = lblModelCode.Text = String.Empty
        lblModelCode.BackColor = IIf(bEmpty, SystemColors.Control, Color.FromArgb(LBL_MODLE_CODE_BACKGROUND))
        lblLotNoUnitNo.BackColor = IIf(bEmpty, SystemColors.Control, Color.FromArgb(LBL_LOT_NO_UNIT_NO_BACKGROUND))

        Me.Cursor = IIf(bEmpty, Cursors.Default, Cursors.Hand)
    End Sub

    Public Sub Deselect()
        RefreshSelection(False)
    End Sub

    Private Sub RefreshSelection(ByVal blnSelected As Boolean)
        m_blnSelected = blnSelected

        If m_blnSelected Then
            lblModelCode.BackColor = Color.FromArgb(LBL_SELECTED_MODLE_CODE_BACKGROUND)
            lblLotNoUnitNo.BackColor = Color.FromArgb(LBL_SELECTED_LOT_NO_BACKGROUND)
        Else
            RefreshVisible()
        End If
    End Sub

#End Region

#Region "Event"
    Friend Shadows Event Click(ByVal sender As Object, ByVal e As System.EventArgs)

    Private Sub lblLotNoUnitNo_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles lblLotNoUnitNo.Paint
        Try
            Dim g As Graphics = e.Graphics

            g.DrawLine(Pens.Black, 0, 0, lblLotNoUnitNo.Width, 0)
            g.DrawLine(Pens.Black, 0, lblLotNoUnitNo.Height - 1, lblLotNoUnitNo.Width, lblLotNoUnitNo.Height - 1)
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "lblLotNoUnitNo_Paint", ex, True)
        End Try
    End Sub

    Private Sub lbl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
            lblModelCode.Click, lblLotNoUnitNo.Click
        Try
            Dim bEmpty As Boolean = lblModelCode.Text = String.Empty

            If Not bEmpty AndAlso Not m_blnSelected Then
                RaiseEvent Click(Me, e)

                RefreshSelection(True)
            End If
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "lbl_Click", ex, True)
        End Try
    End Sub

#End Region
End Class
