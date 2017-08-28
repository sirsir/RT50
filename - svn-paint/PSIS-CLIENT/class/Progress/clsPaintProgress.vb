Public Class clsPaintProgress
    Inherits clsModelBase

#Region "Constant"
    Private Shadows Const ROW_HEADER_COLUMN_NAME As String = _
        "PRODUCTION_DATE,ON_TIME,SKIT_NO,LOT_ID,MODEL_CODE,LOT_NO,UNIT,BLOCK_MODEL,BLOCK_SEQ,PROCESS_RESULT_DATE,IMPORT_CODE,GA_SHOP"
#End Region

#Region "Attribute"
    Dim m_taPAINT_PROGRESS As dsPAINTTableAdapters.taPAINT_PROGRESS = New dsPAINTTableAdapters.taPAINT_PROGRESS
    Private m_lblProc As Label
#End Region

#Region "Constructor"
    Public Sub New(ByVal lblProc As Label)
        m_lblProc = lblProc
    End Sub
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
    End Sub

    Protected Overrides Sub FillByPrevBtn(ByRef dt As DataTable, _
                                          ByVal cnt As Integer, _
                                          ByVal strProductionDate As String, _
                                          ByVal strOnTime As String)
    End Sub

    Protected Overrides Function GetDataByOffsetBase(ByVal strProductionDate As String, _
                                                  ByVal strOnTime As String) As Integer
        Return 0
    End Function

    Public Overrides Sub LoadData(ByVal strProductionDate As String, _
                                  ByVal strOnTime As String, _
                                  ByVal nFnc As enuFillBy)
        Dim dt As dsPAINT.dtPAINT_PROGRESSDataTable = ds.dtPAINT_PROGRESS

        If Regex.Match(m_lblProc.Name, "lblCtrlGroup.*").Success Then
            m_taPAINT_PROGRESS.FillByGroupID(dt, Convert.ToInt32(m_lblProc.Name.Replace("lblCtrlGroup", "")))
        Else
            m_taPAINT_PROGRESS.Fill(dt, Convert.ToInt32(m_lblProc.Name.Replace("lblProcCount", "")))
        End If
        'dt.Select("", "PRODUCTION_DATE, ON_TIME")
        m_strRowsHeaderColumnName = ROW_HEADER_COLUMN_NAME.Split(",")
        m_chs.Clear()
        m_chs.AddRange(GetColumnsHeader(dt.Columns))

        'm_strRowsHeaderValue = GetRowsHeader(dt.Rows)
        m_strRowsHeaderValue = GetRowsHeader(dt.Select("", "PRODUCTION_DATE, ON_TIME"))
        m_lsvItems = GetRows()

        'Rename column "SKIT NO" to "SKID NO"
        m_chs.Item(2).Text = "SKID NO"
    End Sub

#End Region
End Class
