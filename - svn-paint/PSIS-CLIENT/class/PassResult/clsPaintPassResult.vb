Public Class clsPaintPassResult
    Inherits clsModelBase

#Region "Constant"
    Private Const ROW_HEADER_COLUMN_NAME As String = _
    "PRODUCTION_DATE,ON_TIME,SKIT_NO,LOT_ID,MODEL_CODE,LOT_NO,UNIT,BLOCK_MODEL,BLOCK_SEQ,IMPORT_CODE,GA_SHOP"
#End Region

#Region "Attribute"

#End Region

#Region "Constructor"
#End Region

#Region "Property"

    Public Overrides ReadOnly Property ProcessType() As dsPAINT.dtPROCESS_MSTDataTable.enuProcessType
        Get
            Return dsPAINT.dtPROCESS_MSTDataTable.enuProcessType.Paint
        End Get
    End Property

#End Region

#Region "Method"
    Protected Overrides Sub FillByNextGroup(ByRef dt As DataTable, _
                                            ByVal cnt As Integer, _
                                            ByVal strProductionDate As String, _
                                            ByVal strOnTime As String)
        s_taRow.FillByNextGroup(dt, cnt, 0, strProductionDate, strOnTime)
    End Sub

    Protected Overrides Sub FillByPrevBtn(ByRef dt As DataTable, _
                                          ByVal cnt As Integer, _
                                          ByVal strProductionDate As String, _
                                          ByVal strOnTime As String)
        s_taRow.FillByPrevBtn(dt, cnt, 0, strProductionDate, strOnTime)
    End Sub

    Protected Overrides Function GetDataByOffsetBase(ByVal strProductionDate As String, _
                                                  ByVal strOnTime As String) As Integer
        Return s_taRow.GetDataByOffsetBase(0, strProductionDate, strOnTime)
    End Function

    Public Overrides Sub LoadData(ByVal strProductionDate As String, _
                                  ByVal strOnTime As String, _
                                  ByVal nFnc As enuFillBy)
        Dim dtRow As dsPAINT.dtPRODUCTION_DATDataTable = GetDataRow(strProductionDate, strOnTime, nFnc)
        s_taCol.FillByPassResult(ds.dtPROCESS_MST, ProcessType, ProcessType, False)
        s_taCell.FillByModelLotUnit(ds.dtPAINT_CELL)

        Dim dtCol As dsPAINT.dtPROCESS_MSTDataTable = ds.dtPROCESS_MST
        Dim dtCell As dsPAINT.dtPAINT_CELLDataTable = ds.dtPAINT_CELL

        m_strRowsHeaderColumnName = ROW_HEADER_COLUMN_NAME.Split(",")
        m_chs.Clear()
        m_chs.AddRange(GetColumnsHeader(dtRow.Columns))
        m_chs.AddRange(GetColumnsHeader(dtCol.Rows))

        Dim htRows As Hashtable = GetRowHashTable(dtRow.Rows)
        Dim htCols As Hashtable = GetColHashTable(dtCol.Rows)

        m_strRowsHeaderValue = GetRowsHeader(dtRow.Rows)
        m_lsvItems = GetRows(htRows, htCols, dtCell.Rows)

        'Rename column "SKIT NO" to "SKID NO"
        m_chs.Item(2).Text = "SKID NO"
    End Sub

    Protected Overrides Function GetColHashTable(ByVal drc As System.Data.DataRowCollection) As System.Collections.Hashtable
        Dim ht As Hashtable = New Hashtable

        Dim intOffset As Integer = m_chs.Count - drc.Count

        For Each r As dsPAINT.dtPROCESS_MSTRow In drc
            Dim strKey As String = String.Empty
            strKey = String.Format("{0}", r.PROCESS_NO)

            ht(strKey) = intOffset + drc.IndexOf(r)
        Next r

        Return ht
    End Function

    Protected Overrides Function GetRowHashTable(ByVal drc As System.Data.DataRowCollection) As System.Collections.Hashtable
        Dim ht As Hashtable = New Hashtable

        For Each r As dsPAINT.dtPRODUCTION_DATRow In drc
            Dim strKey As String = String.Empty
            strKey = String.Format("{0}{1}{2}{3}", r.MODEL_YEAR, r.SUFFIX_CODE, r.LOT_NO, r.UNIT)

            ht(strKey) = drc.IndexOf(r)
        Next r

        Return ht
    End Function

    Protected Overloads Function GetRows(ByVal htRows As System.Collections.Hashtable, _
                                         ByVal htCols As System.Collections.Hashtable, _
                                         ByVal drCells As System.Data.DataRowCollection) As ListViewItem()
        Dim lsvItems() As ListViewItem = New ListViewItem(m_strRowsHeaderValue.Count - 1) {}

        For Each rowKey As String In htRows.Keys
            Dim intRowIdx As Integer = htRows.Item(rowKey)
            Dim strVals() As String = m_strRowsHeaderValue(intRowIdx).Split(",")

            For Each colKey As String In htCols.Keys
                Dim strKey As String = String.Format("{0},{1}", rowKey, colKey)

                For Each drCell As dsPAINT.dtPAINT_CELLRow In drCells
                    Dim strCellKey As String = String.Format("{0}{1}{2}{3},{4}", _
                                                             drCell.MODEL_YEAR, drCell.SUFFIX_CODE, drCell.LOT_NO, drCell.UNIT, _
                                                             drCell.PROCESS_NO)

                    If strKey = strCellKey Then
                        Dim intColIdx As Integer = Convert.ToInt16(htCols.Item(colKey))
                        strVals(intColIdx) = drCell.RESULT_DATE.ToString
                    End If
                Next drCell
            Next colKey

            lsvItems(intRowIdx) = New ListViewItem(strVals.ToArray)
        Next rowKey

        Return lsvItems
    End Function
#End Region

#Region "Event"

#End Region

End Class
