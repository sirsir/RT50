Public Class clsPLC_MST_Setting
    Inherits clsModelBase

#Region "Constant"
    Private Const ROW_HEADER_COLUMN_NAME As String = _
    "STAGE_CODE,PLC_NET,PLC_NODE,PLC_UNIT,READ_DM,WRITE_DATA_DM,WRITE_STATUS_DM,PLC_ONLINE_FLAG,PROCESS_NO"
#End Region

#Region "Constructor"

#End Region

#Region "Attribute"
    Private m_taPLC_MST As New taPLC_MST
    Private m_taProcMST As New taPROCESS_MST
#End Region

#Region "Property"

    Public Overrides ReadOnly Property ProcessType() As dsPAINT.dtPROCESS_MSTDataTable.enuProcessType
        Get
            Return Nothing
        End Get
    End Property

#End Region

#Region "Method"

    Protected Overrides Sub FillByNextGroup(ByRef dt As System.Data.DataTable, _
                                            ByVal cnt As Integer, _
                                            ByVal strStageCode As String, _
                                            ByVal strPLC_ID As String)
        m_taPLC_MST.FillByNextGroup(dt, cnt, Convert.ToInt32(strStageCode), Convert.ToInt32(strPLC_ID))
    End Sub

    Protected Overrides Function GetDataByOffsetBase(ByVal strStageCode As String, _
                                                  ByVal strPLC_ID As String) As Integer
        Return m_taPLC_MST.GetDataByOffsetBase(Convert.ToInt32(strStageCode), Convert.ToInt32(strPLC_ID))
    End Function

    Protected Overrides Sub FillByPrevBtn(ByRef dt As System.Data.DataTable, _
                                          ByVal cnt As Integer, _
                                          ByVal strStageCode As String, _
                                          ByVal strPLC_ID As String)
        m_taPLC_MST.FillByPrevBtn(dt, cnt, Convert.ToInt32(strStageCode), Convert.ToInt32(strPLC_ID))
    End Sub

    Public Overrides Sub LoadData(ByVal strStageCode As String, _
                                  ByVal strPLC_ID As String, _
                                  ByVal nFnc As enuFillBy)
        Dim dtRow As dsPAINT.dtPLC_MSTDataTable = GetDataRow(strStageCode, strPLC_ID, nFnc)
        Dim dtCol As New dsPAINT.dtPROCESS_MSTDataTable

        m_strRowsHeaderColumnName = ROW_HEADER_COLUMN_NAME.Split(",")
        m_chs.Clear()
        m_chs.AddRange(GetColumnsHeader(dtRow.Columns))

        ' ''Add PLC_ID Hidden Column
        Dim chPlcId As New ColumnHeader
        chPlcId.Text = ParseColumnName("PLC_ID")
        m_chs.Add(chPlcId)
        m_strRowsHeaderColumnName = String.Concat(ROW_HEADER_COLUMN_NAME, ",PROCESS_NO,PLC_ID").Split(",")

        m_strRowsHeaderValue = GetRowsHeader(dtRow.Rows)
        m_lsvItems = GetRows()

        ''display PROCESS_NAME
        m_taProcMST.Fill(dtCol)
        For index As Integer = 0 To dtRow.Rows.Count - 1
            Dim dr As dsPAINT.dtPROCESS_MSTRow = dtCol.FindByPROCESS_NO(dtRow.Rows(index).Item("PROCESS_NO"))
            m_lsvItems(index).SubItems(8).Text = dr.PROCESS_NAME
        Next
        m_chs(8).Text = "PROCESS NAME"

        '' ''Remove PLC_ID Hidden Column
        m_chs.RemoveAt(m_chs.Count - 1)
    End Sub

    Public Overrides Sub InitialPoint(ByRef strStageCode As String, _
                                      ByRef strPLC_ID As String)
        strStageCode = IIf(strStageCode.Length = 0, "0", strStageCode)
        strPLC_ID = IIf(strPLC_ID.Length = 0, "0", strPLC_ID)
    End Sub

    Protected Overrides Function EmptyTable() As DataTable
        Return ds.dtPLC_MST
    End Function

#End Region

#Region "Event"

#End Region

End Class
