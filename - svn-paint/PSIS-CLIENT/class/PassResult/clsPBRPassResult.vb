Public Class clsPBRPassResult
    Inherits clsModelBase

#Region "Constant"
    Private Const ROW_HEADER_COLUMN_NAME As String = _
    "PRODUCTION_DATE,ON_TIME,SKIT_NO,LOT_ID,MODEL_CODE,LOT_NO,UNIT,BLOCK_MODEL,BLOCK_SEQ,IMPORT_CODE,GA_SHOP,PBR_ON,PBR_OFF,BLANK_COL"
#End Region

#Region "Attribute"
    Private m_taPBRPassResult As New taPBRPassResult
    Private m_dtPBRPassResult As New dsPAINT.dtPBRPassResultDataTable
    Private m_strBlockModel As String
    Private m_strBlockSeq As String
    Private m_strBlankCol As String
#End Region

#Region "Constructor"
#End Region

#Region "Property"

    Public Overrides ReadOnly Property ProcessType() As dsPAINT.dtPROCESS_MSTDataTable.enuProcessType
        Get
            Return dsPAINT.dtPROCESS_MSTDataTable.enuProcessType.PBR
        End Get
    End Property

#End Region

#Region "Method"
    Private Sub setParam(ByRef strProdDateWithOntime As String, _
                                            ByRef strBlkModelWithBlkSeqAndBlankCol As String)
        If strProdDateWithOntime = "" And strBlkModelWithBlkSeqAndBlankCol = "" Then
            m_strBlockModel = ""
            m_strBlockSeq = ""
            m_strBlankCol = ""
        Else
            Dim arrStr1 As String()
            Dim arrStr2 As String()

            arrStr1 = strProdDateWithOntime.Split(",")
            arrStr2 = strBlkModelWithBlkSeqAndBlankCol.Split(",")

            m_strBlockModel = arrStr2(0)
            m_strBlockSeq = arrStr2(1)
            m_strBlankCol = arrStr2(2)
            strProdDateWithOntime = arrStr1(0)
            strBlkModelWithBlkSeqAndBlankCol = arrStr1(1)
        End If
    End Sub

    Protected Overrides Sub FillByNextGroup(ByRef dt As DataTable, _
                                            ByVal cnt As Integer, _
                                            ByVal strProdDateWithOntime As String, _
                                            ByVal strBlkModelWithBlkSeqAndBlankCol As String)
        setParam(strProdDateWithOntime, strBlkModelWithBlkSeqAndBlankCol)
        m_taPBRPassResult.FillByNextGroup(dt, cnt, m_strBlankCol, m_strBlockModel, m_strBlockSeq, strProdDateWithOntime, strBlkModelWithBlkSeqAndBlankCol)
    End Sub

    Protected Overrides Sub FillByPrevBtn(ByRef dt As DataTable, _
                                          ByVal cnt As Integer, _
                                          ByVal strProdDateWithOntime As String, _
                                          ByVal strBlkModelWithBlkSeqAndBlankCol As String)

        setParam(strProdDateWithOntime, strBlkModelWithBlkSeqAndBlankCol)
        m_taPBRPassResult.FillByPrevBtn(dt, cnt, m_strBlankCol, m_strBlockModel, m_strBlockSeq, strProdDateWithOntime, strBlkModelWithBlkSeqAndBlankCol)
    End Sub

    Protected Overrides Function GetDataByOffsetBase(ByVal strProdDateWithOntime As String, _
                                                  ByVal strBlkModelWithBlkSeqAndBlankCol As String) As Integer
        Return 0
    End Function


    Public Overrides Sub InitialPoint(ByRef strParam1 As String, _
                                        ByRef strParam2 As String)
        If strParam1 = "" And strParam2 = "" Then
            Dim taPbr As New taPBRPassResult
            Dim dtPbr As dsPAINT.dtPBRPassResultDataTable = New dsPAINT.dtPBRPassResultDataTable

            taPbr.FillByInnitialPoint(dtPbr)
            If dtPbr.Rows.Count > 0 Then
                Dim drPbr As dsPAINT.dtPBRPassResultRow

                drPbr = dtPbr.Rows(0)

                taPbr.FillByPrevBtn(dtPbr, My.Settings.MAX_ROW_COUNT, drPbr.BLANK_COL, _
                                       drPbr.BLOCK_MODEL, drPbr.BLOCK_SEQ, drPbr.PRODUCTION_DATE, _
                                       drPbr.ON_TIME)

                drPbr = dtPbr.Rows(dtPbr.Rows.Count - 1)
                strParam1 = drPbr.PRODUCTION_DATE + "," + drPbr.ON_TIME
                strParam2 = drPbr.BLOCK_MODEL + "," + drPbr.BLOCK_SEQ + "," + drPbr.BLANK_COL
            End If
        End If
    End Sub

    Public Overrides Sub LoadData(ByVal strProdDateWithOntime As String, _
                                  ByVal strBlkModelWithBlkSeqAndBlankCol As String, _
                                  ByVal nFnc As enuFillBy)
        Dim dtRow As dsPAINT.dtPBRPassResultDataTable = GetDataRow(strProdDateWithOntime, strBlkModelWithBlkSeqAndBlankCol, nFnc)

        m_strRowsHeaderColumnName = ROW_HEADER_COLUMN_NAME.Split(",")
        m_chs.Clear()
        m_chs.AddRange(GetColumnsHeader(dtRow.Columns))

        m_strRowsHeaderValue = GetRowsHeader(dtRow.Rows)
        m_lsvItems = GetRows()

        'Rename column "SKIT NO" to "SKID NO"
        m_chs.Item(2).Text = "SKID NO"

        ' ''Remove BLANK_COL Column
        m_chs.RemoveRange(m_chs.Count - 1, 1)
    End Sub

    Protected Overrides Function EmptyTable() As DataTable
        Return ds.dtPBRPassResult
    End Function
#End Region

#Region "Event"

#End Region

End Class
