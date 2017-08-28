Public Class clsProcessOptionSetting
    Inherits clsModelBase

#Region "Constant"
    Private Const ROW_HEADER_COLUMN_NAME As String = "PROCESS_CODE,PROCESS_NAME"
#End Region

#Region "Attribute"
    Private m_taOptMst As New taOPTION_MST
    Private m_taProcOptCell As New taPROCESS_OPTION_CELL

    Private m_nOptionType As dsPAINT.dtOPTION_MSTDataTable.enuOptionType = _
    dsPAINT.dtOPTION_MSTDataTable.enuOptionType.OptionTable

    Private m_blnIsIncludeWBSProgress As Boolean = False
    Private m_blnIsIncludeFinishing As Boolean = False
#End Region

#Region "Constructor"

#End Region

#Region "Property"

    Public Overrides ReadOnly Property ProcessType() As dsPAINT.dtPROCESS_MSTDataTable.enuProcessType
        Get
            Return dsPAINT.dtPROCESS_MSTDataTable.enuProcessType.WBS
        End Get
    End Property

#End Region

#Region "Method"

    Protected Overrides Sub FillByNextGroup(ByRef dt As System.Data.DataTable, _
                                            ByVal cnt As Integer, _
                                            ByVal strProcessType As String, _
                                            ByVal strProcessCode As String)
        Dim intProcType As Integer = 0
        Dim intProcCode As Integer = 0

        If strProcessType.Trim.Length > 0 Then intProcType = Convert.ToInt32(strProcessType)
        If strProcessCode.Trim.Length > 0 Then intProcCode = Convert.ToInt32(strProcessCode)

        s_taCol.FillByNextGroup(dt, cnt, intProcType, intProcCode, Convert.ToInt32(m_blnIsIncludeWBSProgress))
    End Sub

    Protected Overrides Function GetDataByOffsetBase(ByVal strProcessType As String, _
                                                  ByVal strProcessCode As String) As Integer
        Dim intProcType As Integer = 0
        Dim intProcCode As Integer = 0

        If strProcessType.Trim.Length > 0 Then intProcType = Convert.ToInt32(strProcessType)
        If strProcessCode.Trim.Length > 0 Then intProcCode = Convert.ToInt32(strProcessCode)

        Return s_taCol.GetDataByOffsetBase(intProcType, intProcCode)
    End Function

    Protected Overrides Sub FillByPrevBtn(ByRef dt As System.Data.DataTable, _
                                          ByVal cnt As Integer, _
                                          ByVal strProcessType As String, _
                                          ByVal strProcessCode As String)
        Dim intProcType As Integer = 0
        Dim intProcCode As Integer = 0

        If strProcessType.Trim.Length > 0 Then intProcType = Convert.ToInt32(strProcessType)
        If strProcessCode.Trim.Length > 0 Then intProcCode = Convert.ToInt32(strProcessCode)

        s_taCol.FillByPrevBtn(dt, cnt, intProcType, intProcCode, Convert.ToInt32(m_blnIsIncludeFinishing))
    End Sub

    Public Overrides Sub LoadData(ByVal strProcessType As String, _
                                  ByVal strProcessCode As String, _
                                  ByVal nFnc As enuFillBy)
        Dim dtRow As dsPAINT.dtPROCESS_MSTDataTable = GetDataRow(strProcessType, strProcessCode, nFnc)
        m_taOptMst.FillByOptType(ds.dtOPTION_MST, m_nOptionType)
        m_taProcOptCell.Fill(ds.dtPROCESS_OPTION_CELL)

        Dim dtCol As dsPAINT.dtOPTION_MSTDataTable = ds.dtOPTION_MST
        Dim dtCell As dsPAINT.dtPROCESS_OPTION_CELLDataTable = ds.dtPROCESS_OPTION_CELL

        m_strRowsHeaderColumnName = ROW_HEADER_COLUMN_NAME.Split(",")
        m_chs.Clear()
        m_chs.AddRange(GetColumnsHeader(dtRow.Columns))

        m_strDynamicColumnName = "OPTION_SEQ_NAME"
        m_chs.AddRange(GetColumnsHeader(dtCol.Rows))

        ' ''Add PROCESS_TYPE Hidden Column
        Dim chProcType As New ColumnHeader
        chProcType.Text = ParseColumnName("PROCESS_TYPE")
        m_chs.Add(chProcType)

        ' ''Add PROCESS_NO Hidden Column
        Dim chProcNo As New ColumnHeader
        chProcNo.Text = ParseColumnName("PROCESS_NO")
        m_chs.Add(chProcNo)
        m_strRowsHeaderColumnName = String.Concat(ROW_HEADER_COLUMN_NAME, ",PROCESS_TYPE,PROCESS_NO").Split(",")

        ' ''Add column details
        Dim strRowsHeaderColumn As New String(",", ROW_HEADER_COLUMN_NAME.Split(",").Length)
        m_lsvColumnItems = GetColumnDetails(strRowsHeaderColumn, dtCol.Rows)

        Dim htRows As Hashtable = GetRowHashTable(dtRow.Rows)
        Dim htCols As Hashtable = GetColHashTable(dtCol.Rows)

        m_strRowsHeaderValue = GetRowsHeader(dtRow.Rows)
        m_lsvItems = GetRows(htRows, htCols, dtCell.Rows)

        ' ''Remove PROCESS_TYPE,PROCESS_NO Hidden Column
        m_chs.RemoveRange(m_chs.Count - 2, 2)
    End Sub

    Public Overrides Sub InitialPoint(ByRef strProcessType As String, _
                                      ByRef strProcessCode As String)
        If strProcessType = String.Empty Then
            strProcessType = ProcessType
        End If
    End Sub

    Protected Overrides Function EmptyTable() As DataTable
        Return ds.dtPROCESS_MST
    End Function

    Protected Overrides Function GetColHashTable(ByVal drc As System.Data.DataRowCollection) As System.Collections.Hashtable
        Dim ht As Hashtable = New Hashtable

        Dim strFilterExpressionVal As String = _
        Convert.ToString(dsPAINT.dtOPTION_MSTDataTable.enuOptionType.Destination)
        Dim intOptDestLen As Integer = drc(0).Table.Select("OPTION_TYPE = " + strFilterExpressionVal).Length

        Dim intOffset As Integer = m_chs.Count - (drc.Count - intOptDestLen)
        intOffset -= 2 ' ''Remove PROCESS_TYPE, PROCESS_NO Hidden Column

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

        For Each r As dsPAINT.dtPROCESS_MSTRow In drc
            Dim strKey As String = String.Empty
            strKey = String.Format("{0}", r.PROCESS_NO)

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

                For Each drCell As dsPAINT.dtPROCESS_OPTION_CELLRow In drCells
                    Dim strCellKey As String = String.Format("{0},{1}", drCell.PROCESS_NO, drCell.OPTION_ID)

                    If strKey = strCellKey Then
                        Dim intColIdx As Integer = Convert.ToInt16(htCols.Item(colKey))
                        strVals(intColIdx) = Convert.ToInt32(drCell.IS_USED).ToString
                    End If
                Next drCell
            Next colKey

            lsvItems(intRowIdx) = New ListViewItem(strVals.ToArray)
        Next rowKey

        Return lsvItems
    End Function

    Private Function GetColumnDetails(ByVal strHeaderColumnBase As String, _
                                      ByVal cols As DataRowCollection) As ListViewItem()
        Dim blnIsAddDestination As Boolean = False
        Dim blnIsOptionTable As Boolean = False

        Dim strCode As String = strHeaderColumnBase
        Dim strName As String = strHeaderColumnBase
        Dim strDisplay As String = strHeaderColumnBase
        For Each col As dsPAINT.dtOPTION_MSTRow In cols
            blnIsOptionTable = (col.OPTION_TYPE = dsPAINT.dtOPTION_MSTDataTable.enuOptionType.OptionTable)
            If blnIsAddDestination Or blnIsOptionTable Then
                strCode &= "CODE: " + IIf(IsDBNull(col.OPTION_CODE), String.Empty, col.OPTION_CODE)
                strName &= "NAME: " + col.OPTION_NAME
                strDisplay &= "DISPLAY: " + IIf(blnIsAddDestination, String.Empty, col.OPTION_DISPLAY)
            End If

            If (blnIsAddDestination Or blnIsOptionTable) AndAlso cols.IndexOf(col) < cols.Count - 1 Then
                strCode &= ","
                strName &= ","
                strDisplay &= ","
            End If
        Next

        Return New ListViewItem() {New ListViewItem(strCode.Split(",")), _
                                   New ListViewItem(strName.Split(",")), _
                                   New ListViewItem(strDisplay.Split(","))}
    End Function
#End Region

#Region "Event"

#End Region
End Class
