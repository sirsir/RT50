Public Class clsProcessMaster
    Inherits clsModelBase

#Region "Constant"
    Private Const ROW_HEADER_COLUMN_NAME As String = _
    "PROCESS_CODE,PROCESS_NAME,PROCESS_TYPE,PROCESS_GROUP_ID,PROCESS_TIME,ENTRANCE_FLAG"
#End Region

#Region "Attribute"
    Private m_blnIsIncludeWBSProgress As Boolean = False
    Private m_blnIsIncludeFinishing As Boolean = True

    Private m_taProcGrpMst As New taPROCESS_GROUP_MST
#End Region

#Region "Constructor"

#End Region

#Region "Property"

    Public Overrides ReadOnly Property ProcessType() As dsPAINT.dtPROCESS_MSTDataTable.enuProcessType
        Get
            Return dsPAINT.dtPROCESS_MSTDataTable.enuProcessType.Finishing
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
        m_taProcGrpMst.Fill(ds.dtPROCESS_GROUP_MST)

        m_strRowsHeaderColumnName = ROW_HEADER_COLUMN_NAME.Split(",")
        m_chs.Clear()
        m_chs.AddRange(GetColumnsHeader(dtRow.Columns))

        ' ''Add PROCESS_GROUP_ID Hidden Column
        Dim chProcGroupId As New ColumnHeader
        chProcGroupId.Text = ParseColumnName("PROCESS_GROUP_ID")
        m_chs.Add(chProcGroupId)

        ' ''Add PROCESS_TYPE Hidden Column
        Dim chProcType As New ColumnHeader
        chProcType.Text = ParseColumnName("PROCESS_TYPE")
        m_chs.Add(chProcType)

        ' ''Add PROCESS_NO Hidden Column
        Dim chProcNo As New ColumnHeader
        chProcNo.Text = ParseColumnName("PROCESS_NO")
        m_chs.Add(chProcNo)
        m_strRowsHeaderColumnName = String.Concat(ROW_HEADER_COLUMN_NAME, ",PROCESS_GROUP_ID,PROCESS_TYPE,PROCESS_NO").Split(",")

        Dim htRows As Hashtable = GetRowHashTable(dtRow.Rows)
        Dim htCols As Hashtable = GetColHashTable()

        m_strRowsHeaderValue = GetRowsHeader(dtRow.Rows)
        m_lsvItems = GetRows(htRows, htCols, dtRow.Rows)

        ' ''Remove PROCESS_GROUP_ID,PROCESS_TYPE,PROCESS_NO Hidden Column
        m_chs.RemoveRange(m_chs.Count - 3, 3)

        ' ''Replace PROCESS_GROUP_ID with PROCESS_GROUP_NAME
        m_chs.Item(3).Text = "PROCESS GROUP NAME"
    End Sub

    Public Overrides Sub InitialPoint(ByRef strProcessType As String, _
                                      ByRef strProcessNo As String)
        If strProcessType = String.Empty Then
            strProcessType = ProcessType
        End If
    End Sub

    Protected Overrides Function EmptyTable() As DataTable
        Return ds.dtPROCESS_MST
    End Function

    Protected Overloads Function GetColHashTable() As System.Collections.Hashtable
        Dim ht As Hashtable = New Hashtable

        For Each ch As ColumnHeader In m_chs
            If m_chs.IndexOf(ch) < m_chs.Count - 3 Then
                Dim strKey As String = String.Empty
                strKey = String.Format("{0}", ParseColumn(ch.Text))

                ht(strKey) = m_chs.IndexOf(ch)
            End If
        Next ch

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
                Dim drCell As dsPAINT.dtPROCESS_MSTRow = drCells.Item(intRowIdx)

                Select Case colKey
                    Case "PROCESS_TYPE"
                        Dim nProcType As dsPAINT.dtPROCESS_MSTDataTable.enuProcessType = _
                        CType(drCell.PROCESS_TYPE, dsPAINT.dtPROCESS_MSTDataTable.enuProcessType)

                        strVals(Convert.ToInt16(htCols.Item(colKey))) = nProcType.ToString
                    Case "PROCESS_GROUP_ID"
                        strVals(Convert.ToInt16(htCols.Item(colKey))) = drCell.PROCESS_GROUP_NAME.ToString
                    Case "ENTRANCE_FLAG"
                        strVals(Convert.ToInt16(htCols.Item(colKey))) = Convert.ToInt32(drCell.Item(colKey)).ToString
                End Select
            Next

            lsvItems(intRowIdx) = New ListViewItem(strVals.ToArray)
        Next rowKey

        Return lsvItems
    End Function

#End Region

#Region "Event"

#End Region

End Class
