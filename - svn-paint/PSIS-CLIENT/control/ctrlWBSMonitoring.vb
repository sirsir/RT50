Public Class ctrlWBSMonitoring

#Region "Constant"

#End Region

#Region "Enumerator"
    Public Enum enuMonitorMode
        view
        edit
    End Enum
#End Region

#Region "Attribute"
    Friend ctrlWBSM_Lanes As List(Of PSIS_CLIENT.ctrlWBSM_Lane)

    Private m_nMonitorMode As enuMonitorMode
    Private m_dtPreSetDataTable As dsPAINT.dtWBS_ONDataTable
    Private m_drReverseLane() As dsPAINT.dtLANE_MSTRow

    Private m_objClsLogger As New clsLogger
    Private m_objDBClsLogger As New clsDBLogger
#End Region

#Region "Constructor"

#End Region

#Region "Property"
    Public Property MonitorMode() As enuMonitorMode
        Get
            Return m_nMonitorMode
        End Get
        Set(ByVal value As enuMonitorMode)
            m_nMonitorMode = value
        End Set
    End Property

    Public WriteOnly Property PreSetDataTable() As dsPAINT.dtWBS_ONDataTable
        Set(ByVal value As dsPAINT.dtWBS_ONDataTable)
            m_dtPreSetDataTable = value
        End Set
    End Property
#End Region

#Region "Method"

    Private Sub LoadLanes()
        taLANE_MST1.Fill(dsPAINT1.dtLANE_MST)
        m_drReverseLane = dsPAINT1.dtLANE_MST.Select("", "LANE_NO DESC")

        For Each dr As dsPAINT.dtLANE_MSTRow In m_drReverseLane
            Dim ctrlWBSM_Lane As New ctrlWBSM_Lane

            ctrlWBSM_Lane.LaneNo = dr.LANE_NO
            ctrlWBSM_Lane.Name = String.Format("CtrlWBSM_Lane{0}", dr.LANE_NO)
            ctrlWBSM_Lane.Width = lblQueueHeader0.Width + lblQueueHeader1.Width * 10 + 5

            Me.FlowLayoutPanel1.Controls.Add(ctrlWBSM_Lane)

            AddHandler ctrlWBSM_Lane.Click, AddressOf CtrlWBSM_Lane_Click
        Next dr
    End Sub

    Private Sub LoadData()
        Dim htData As New Hashtable
        Dim data As List(Of dsPAINT.dtWBS_ONRow)
        Dim dt As dsPAINT.dtWBS_ONDataTable

        If m_nMonitorMode = enuMonitorMode.view Then
            dt = m_dtPreSetDataTable
        Else
            taWbsOn1.Fill(dsPAINT1.dtWBS_ON)
            dt = dsPAINT1.dtWBS_ON
        End If

        Dim ds As dsPAINT = dt.DataSet

        taSKIT_MST1.Fill(ds.dtSKIT_MST)

        If dt IsNot Nothing Then
            For Each dr As dsPAINT.dtWBS_ONRow In dt
                If htData(dr.LANE_NO) Is Nothing Then htData(dr.LANE_NO) = New List(Of dsPAINT.dtWBS_ONRow)

                data = htData(dr.LANE_NO)
                data.Add(dr)
            Next dr
        End If

        For Each ctrlWBSM_Lane As ctrlWBSM_Lane In Me.FlowLayoutPanel1.Controls
            If htData(ctrlWBSM_Lane.LaneNo) Is Nothing Then htData(ctrlWBSM_Lane.LaneNo) = New List(Of dsPAINT.dtWBS_ONRow)

            ctrlWBSM_Lane.DeselectAll()
            ctrlWBSM_Lane.Data = htData(ctrlWBSM_Lane.LaneNo)
        Next ctrlWBSM_Lane
    End Sub

    Private Sub SetLegendColor()
        lblModelCode.BackColor = Color.FromArgb(ctrlWBSM_StockData.LBL_MODLE_CODE_BACKGROUND)
        lblLotNoUnitNo.BackColor = Color.FromArgb(ctrlWBSM_StockData.LBL_LOT_NO_UNIT_NO_BACKGROUND)
    End Sub

    Private Sub Edit()
        Dim objLane As ctrlWBSM_Lane = GetSelectedLane()
        If objLane IsNot Nothing Then
            Dim htSelectedData As Hashtable = GetSelectedStockData(objLane)
            If htSelectedData.Count > 0 Then
                Dim intPosition As Integer = htSelectedData("Position")
                Dim strModelYear As String = htSelectedData("ModelYear")
                Dim strSuffixCode As String = htSelectedData("SuffixCode")
                Dim strLotNo As String = htSelectedData("LotNo")
                Dim strUnit As String = htSelectedData("Unit")

                Dim frm As New frmWBSMonitoring_Edit
                frm.LaneNo = objLane.LaneNo
                frm.ModelYear = strModelYear
                frm.SuffixCode = strSuffixCode
                frm.LotNo = strLotNo
                frm.Unit = strUnit

                If frm.ShowDialog = DialogResult.OK Then
                    Dim objTagetLane As ctrlWBSM_Lane = GetLaneByNo(frm.LaneNo)
                    Dim strTargetModelyear As String = frm.ModelYear
                    Dim strTargetSuffixCode As String = frm.SuffixCode
                    Dim strTargetLotNo As String = frm.LotNo
                    Dim strTargetUnit As String = frm.Unit

                    Dim bDirty As Boolean = False

                    If objLane.LaneNo <> objTagetLane.LaneNo Or (strModelYear <> strTargetModelyear Or _
                                                                 strSuffixCode <> strTargetSuffixCode Or _
                                                                 strLotNo <> strTargetLotNo Or _
                                                                 strUnit <> strTargetUnit) Then
                        Dim taWBS_ON As New taWBS_ON

                        taWBS_ON.ShiftSeq(objTagetLane.LaneNo, strTargetModelyear, strTargetSuffixCode, strTargetLotNo, strTargetUnit)
                        taWBS_ON.MoveLaneSeq(objTagetLane.LaneNo, strModelYear, strSuffixCode, strLotNo, strUnit, _
                                             strTargetModelyear, strTargetSuffixCode, strTargetLotNo, strTargetUnit)
                        taWBS_ON.ReorderSeq()

                        Dim strSuff As String = IIf((strTargetModelyear = "000" AndAlso strTargetSuffixCode = "00000" AndAlso _
                                                     strTargetLotNo = "000" AndAlso strTargetUnit = "000"), _
                                                     "at last position", _
                                                     "before ModelCode = " + strTargetModelyear + strTargetSuffixCode + ", LotNo = " _
                                                      + strTargetLotNo + ", Unit = " + strTargetUnit)

                        m_objDBClsLogger.Log(DB_LOG_CODE_N_EDIT_WBS_STOCK_DATA, Nothing, strModelYear + strSuffixCode, strLotNo, strUnit, objTagetLane.LaneNo.ToString, strSuff)

                        bDirty = True
                    End If

                    If bDirty Then LoadData()
                End If
            End If
        End If
    End Sub

    Private Function GetSelectedLane() As ctrlWBSM_Lane
        GetSelectedLane = Nothing

        For Each ctrlWBSM_Lane As ctrlWBSM_Lane In Me.FlowLayoutPanel1.Controls
            If ctrlWBSM_Lane.Selected Then
                GetSelectedLane = ctrlWBSM_Lane
                Exit For
            End If
        Next ctrlWBSM_Lane
    End Function

    Private Function GetLaneByNo(ByVal intLaneNo As Integer) As ctrlWBSM_Lane
        GetLaneByNo = Nothing

        For Each ctrlWBSM_Lane As ctrlWBSM_Lane In Me.FlowLayoutPanel1.Controls
            If ctrlWBSM_Lane.LaneNo = intLaneNo Then
                GetLaneByNo = ctrlWBSM_Lane
                Exit For
            End If
        Next ctrlWBSM_Lane
    End Function

    Private Function GetSelectedStockData(ByVal objLane As ctrlWBSM_Lane) As Hashtable
        GetSelectedStockData = New Hashtable

        Dim sd As List(Of ctrlWBSM_StockData) = objLane.StockData

        For Each objWBSM_StockData As ctrlWBSM_StockData In sd
            If objWBSM_StockData.Selected Then
                GetSelectedStockData.Add("Position", sd.IndexOf(objWBSM_StockData) + 1)
                GetSelectedStockData.Add("ModelYear", objWBSM_StockData.ModelYear)
                GetSelectedStockData.Add("SuffixCode", objWBSM_StockData.SuffixCode)
                GetSelectedStockData.Add("LotNo", objWBSM_StockData.LotNo)
                GetSelectedStockData.Add("Unit", objWBSM_StockData.Unit)

                Exit For
            End If
        Next objWBSM_StockData
    End Function
#End Region

#Region "Event"
    Public Event OnOperatorClick(ByVal sender As Object, ByVal e As EventArgs)

    Private Sub ctrlWBSMonitoring_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            LoadLanes()
            SetLegendColor()
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "ctrlWBSMonitoring_Load", ex, True)
        End Try
    End Sub

    Private Sub CtrlWBSM_Lane_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim objWBSM_StockData As ctrlWBSM_StockData = DirectCast(sender, ctrlWBSM_StockData)

            For Each ctrlWBSM_Lane As ctrlWBSM_Lane In Me.FlowLayoutPanel1.Controls
                ctrlWBSM_Lane.DeselectAll()
            Next ctrlWBSM_Lane
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "CtrlWBSM_Lane_Click", ex, True)
        End Try
    End Sub

    Private Sub CtrlBtnsOperator1_OnOperatorClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles CtrlBtnsOperator1.OnOperatorClick
        Try
            Dim btn As Button = DirectCast(sender, Button)

            Select Case btn.Tag
                Case "F2"
                    Edit()
                Case "F11", "F12"
                    RaiseEvent OnOperatorClick(btn, e)
            End Select
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "CtrlBtnsOperator1_OnOperatorClick", ex, True)
        End Try
    End Sub

    Private Sub ctrlWBSMonitoring_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        Try
            If Me.Visible Then
                CtrlBtnsOperator1.F2 = (m_nMonitorMode = enuMonitorMode.edit)
                CtrlBtnsOperator1.F11 = (m_nMonitorMode = enuMonitorMode.view)
                CtrlBtnsOperator1.F12 = Not CtrlBtnsOperator1.F11

                Timer1.Enabled = (m_nMonitorMode = enuMonitorMode.edit)
                Timer1.Interval = My.Settings.WBSMonitor_Interval.TotalMilliseconds

                LoadData()
            End If
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "ctrlWBSMonitoring_VisibleChanged", ex, True)
        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            Timer1.Enabled = False

            LoadData()

            Timer1.Enabled = True
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "Timer1_Tick", ex, True)
        End Try
    End Sub

#End Region
End Class
