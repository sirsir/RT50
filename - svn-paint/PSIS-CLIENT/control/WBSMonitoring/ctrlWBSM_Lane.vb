Public Class ctrlWBSM_Lane

#Region "Constant"
    Const LBL_HEADER_TEST As String = "LANE NO. {0}"

#End Region

#Region "Enumerator"

#End Region

#Region "Attribute"
    Private m_intLaneNo As Integer
    Private m_drData As List(Of dsPAINT.dtWBS_ONRow)
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

            RefreshHeader()
        End Set
    End Property

    Public WriteOnly Property Data() As List(Of dsPAINT.dtWBS_ONRow)
        Set(ByVal value As List(Of dsPAINT.dtWBS_ONRow))
            m_drData = value

            RefreshData()
        End Set
    End Property

    Public ReadOnly Property Selected() As Boolean
        Get
            Return SelectedStockData IsNot Nothing
        End Get
    End Property

    Public ReadOnly Property StockData() As List(Of ctrlWBSM_StockData)
        Get
            Dim objWBSM_StockDatas() As ctrlWBSM_StockData = { _
                CtrlWBSM_StockData1, CtrlWBSM_StockData2, _
                CtrlWBSM_StockData3, CtrlWBSM_StockData4, _
                CtrlWBSM_StockData5, CtrlWBSM_StockData6, _
                CtrlWBSM_StockData7, CtrlWBSM_StockData8, _
                CtrlWBSM_StockData9, CtrlWBSM_StockData10 _
            }


            Return objWBSM_StockDatas.ToList
        End Get
    End Property

    Public ReadOnly Property SelectedStockData() As ctrlWBSM_StockData
        Get
            Dim objSelectedStockData As ctrlWBSM_StockData = Nothing

            For Each objWBSM_StockData As ctrlWBSM_StockData In StockData
                If objWBSM_StockData.Selected Then
                    objSelectedStockData = objWBSM_StockData
                    Exit For
                End If
            Next objWBSM_StockData

            Return objSelectedStockData
        End Get
    End Property
#End Region

#Region "Method"

    Private Sub RefreshHeader()
        lblHeader.Text = String.Format(LBL_HEADER_TEST, m_intLaneNo)
    End Sub

    Private Sub RefreshData()
        Dim sd As List(Of ctrlWBSM_StockData) = StockData

        For Each objWBSM_StockData As ctrlWBSM_StockData In sd
            Dim i As Integer = sd.IndexOf(objWBSM_StockData)

            objWBSM_StockData.ModelCode = String.Empty
            objWBSM_StockData.LotNoUnitNo = String.Empty

            If i < m_drData.Count Then
                Dim dr As dsPAINT.dtWBS_ONRow = m_drData(i)

                'If dr.dtSKIT_MSTRow IsNot Nothing Then
                objWBSM_StockData.ModelCode = String.Format("{0}{1}", dr.MODEL_YEAR, dr.SUFFIX_CODE)
                objWBSM_StockData.LotNoUnitNo = String.Format("{0} {1}", dr.LOT_NO, dr.UNIT)
                objWBSM_StockData.ModelYear = dr.MODEL_YEAR
                objWBSM_StockData.SuffixCode = dr.SUFFIX_CODE
                objWBSM_StockData.LotNo = dr.LOT_NO
                objWBSM_StockData.Unit = dr.UNIT
                'End If

            End If
        Next objWBSM_StockData
    End Sub

    Public Sub DeselectAll()
        For Each objWBSM_StockData As ctrlWBSM_StockData In StockData
            objWBSM_StockData.Deselect()
        Next objWBSM_StockData
    End Sub

#End Region

#Region "Event"
    Friend Shadows Event Click(ByVal sender As Object, ByVal e As System.EventArgs)

    Private Sub CtrlWBSM_StockData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
            CtrlWBSM_StockData1.Click, CtrlWBSM_StockData2.Click, _
            CtrlWBSM_StockData3.Click, CtrlWBSM_StockData4.Click, _
            CtrlWBSM_StockData5.Click, CtrlWBSM_StockData6.Click, _
            CtrlWBSM_StockData7.Click, CtrlWBSM_StockData8.Click, _
            CtrlWBSM_StockData9.Click, CtrlWBSM_StockData10.Click

        Try
            RaiseEvent Click(sender, e)
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "CtrlWBSM_StockData_Click", ex, True)
        End Try

    End Sub

#End Region
End Class
