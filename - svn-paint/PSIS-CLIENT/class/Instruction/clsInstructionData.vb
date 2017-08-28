Public Class clsInstructionData
    Inherits clsModelBase

#Region "Constant"
    Private Const ROW_HEADER_COLUMN_NAME As String = _
    "PRODUCTION_DATE,ON_TIME,SKIT_NO,LOT_ID,MODEL_CODE,LOT_NO,UNIT,BLOCK_MODEL,BLOCK_SEQ,IMPORT_CODE,GA_SHOP,CURRENT_PROCESS"
#End Region

#Region "Enumerator"
#End Region

#Region "Attribute"
    Private m_taOptMst As New taOPTION_MST
    Private m_taIntrucionData As New taINSTRUCTION_DATA

    Private m_nOptionType As dsPAINT.dtOPTION_MSTDataTable.enuOptionType = _
    dsPAINT.dtOPTION_MSTDataTable.enuOptionType.OptionTable
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
        'm_taOptMst.Fill(ds.dtOPTION_MST)   'Remove to not show options

        Dim strDateTime1 As String = ""
        Dim strDateTime2 As String = ""
        If dtRow IsNot Nothing AndAlso dtRow.Count > 0 Then
            Dim intLast As Integer = dtRow.Count - 1
            strDateTime1 = dtRow(0).PRODUCTION_DATE + dtRow(0).ON_TIME
            strDateTime2 = dtRow(intLast).PRODUCTION_DATE + dtRow(intLast).ON_TIME
            'm_taIntrucionData.FillByProductionDateTimeRange(ds.dtINSTRUCTION_DATA, strDateTime1, strDateTime2)
        Else
            'm_taIntrucionData.Fill(ds.dtINSTRUCTION_DATA)
        End If

        'Dim dtCol As dsPAINT.dtOPTION_MSTDataTable = ds.dtOPTION_MST   'Remove to not show options
        'Dim dtCell As dsPAINT.dtINSTRUCTION_DATADataTable = ds.dtINSTRUCTION_DATA   'Remove to not show options

        m_strRowsHeaderColumnName = ROW_HEADER_COLUMN_NAME.Split(",")
        m_chs.Clear()
        m_chs.AddRange(GetColumnsHeader(dtRow.Columns))

        'm_strDynamicColumnName = "OPTION_NAME"   'Remove to not show options
        'm_chs.AddRange(GetColumnsHeader(dtCol.Rows))   'Remove to not show options

        'Dim htRows As Hashtable = GetRowHashTable(dtRow.Rows)   'Remove to not show options
        'Dim htCols As Hashtable = GetColHashTable(dtCol.Rows)   'Remove to not show options

        m_strRowsHeaderValue = GetRowsHeader(dtRow.Rows)
        'm_lsvItems = GetRows(htRows, htCols, dtCell.Rows)   'Remove to not show options
        m_lsvItems = GetRows()

        'Rename column "SKIT NO" to "SKID NO"
        m_chs.Item(2).Text = "SKID NO"
    End Sub

    Public Overrides Sub InitialPoint(ByRef strProductionDate As String, _
                                        ByRef strOnTime As String)
        If strProductionDate = String.Empty Then strProductionDate = Format(Now, "yyyyMMdd")
        If strOnTime = String.Empty Then strOnTime = "0000"

        Dim strClosesProductionDate As String = s_taRow.ClosesProductionDate(strProductionDate)
        If strClosesProductionDate > 0 Then strProductionDate = strClosesProductionDate
    End Sub

    Protected Overrides Function GetColHashTable(ByVal drc As System.Data.DataRowCollection) As System.Collections.Hashtable
        Dim ht As Hashtable = New Hashtable

        Dim strFilterExpressionVal As String = _
        Convert.ToString(dsPAINT.dtOPTION_MSTDataTable.enuOptionType.Destination)
        Dim intOptDestLen As Integer = drc(0).Table.Select("OPTION_TYPE = " + strFilterExpressionVal).Length - 1

        Dim intOffset As Integer = m_chs.Count - (drc.Count - intOptDestLen)

        For Each r As dsPAINT.dtOPTION_MSTRow In drc
            Dim strKey As String = String.Empty
            strKey = String.Format("{0}", r.OPTION_ID)

            Dim intRowIdx As Integer = 0
            If r.OPTION_TYPE = dsPAINT.dtOPTION_MSTDataTable.enuOptionType.OptionTable Then
                intRowIdx = drc.IndexOf(r) - intOptDestLen
            End If

            ht(strKey) = intOffset + intRowIdx
        Next r

        Return ht
    End Function

    Protected Overrides Function GetRowHashTable(ByVal drc As System.Data.DataRowCollection) As System.Collections.Hashtable
        Dim ht As Hashtable = New Hashtable

        Dim intNotStrKey As Integer = 0
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

                For Each drCell As dsPAINT.dtINSTRUCTION_DATARow In drCells
                    Dim strCellKey As String = String.Format("{0}{1}{2}{3},{4}", _
                                                             drCell.MODEL_YEAR, drCell.SUFFIX_CODE, drCell.LOT_NO, drCell.UNIT, _
                                                             drCell.OPTION_ID)

                    If strKey = strCellKey Then
                        Dim intColIdx As Integer = Convert.ToInt16(htCols.Item(colKey))
                        strVals(intColIdx) = drCell.OPTION_DISPLAY
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
