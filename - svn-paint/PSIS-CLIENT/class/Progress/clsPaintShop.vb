Public Class clsPaintShop
    Inherits clsModelBase

#Region "Constant"
    Private Shadows Const ROW_HEADER_COLUMN_NAME As String = _
    "PRODUCTION_DATE,ON_TIME,SKIT_NO,LOT_ID,MODEL_CODE,LOT_NO,UNIT,BLOCK_MODEL,BLOCK_SEQ,IMPORT_CODE,GA_SHOP,PROCESS_RESULT_DATE"
#End Region

#Region "Attribute"
    Private m_taPAINT_SHOP As New taPAINT_SHOP
#End Region

#Region "Constructor"
#End Region

#Region "Property"

    Public Overrides ReadOnly Property ProcessType() As dsPAINT.dtPROCESS_MSTDataTable.enuProcessType
        Get
            Return Nothing
        End Get
    End Property

#End Region

#Region "Method"
    Protected Overrides Sub FillByNextGroup(ByRef dt As DataTable, _
                                            ByVal cnt As Integer, _
                                            ByVal strProductionDate As String, _
                                            ByVal strOnTime As String)
        's_taRow.FillByNextGroup(dt, cnt, strProductionDate, strOnTime)
    End Sub

    Protected Overrides Sub FillByPrevBtn(ByRef dt As DataTable, _
                                          ByVal cnt As Integer, _
                                          ByVal strProductionDate As String, _
                                          ByVal strOnTime As String)
        's_taRow.FillByPrevBtn(dt, cnt, strProductionDate, strOnTime)
    End Sub

    Protected Overrides Function GetDataByOffsetBase(ByVal strProductionDate As String, _
                                                  ByVal strOnTime As String) As Integer
        Return 0 ' s_taRow.GetDataByOffsetBase(strProductionDate, strOnTime)
    End Function

    Public Overrides Sub LoadData(ByVal strProductionDate As String, _
                                  ByVal strOnTime As String, _
                                  ByVal nFnc As enuFillBy)
        m_taPAINT_SHOP.Fill(ds.dtPAINT_SHOP)
        Dim dt As dsPAINT.dtPAINT_SHOPDataTable = ds.dtPAINT_SHOP

        m_strRowsHeaderColumnName = ROW_HEADER_COLUMN_NAME.Split(",")
        m_chs.Clear()
        m_chs.AddRange(GetColumnsHeader(dt.Columns))

        m_strRowsHeaderValue = GetRowsHeader(dt.Rows)
        m_lsvItems = GetRows()

        'Rename column "SKIT NO" to "SKID NO"
        m_chs.Item(2).Text = "SKID NO"
    End Sub

#End Region

End Class
