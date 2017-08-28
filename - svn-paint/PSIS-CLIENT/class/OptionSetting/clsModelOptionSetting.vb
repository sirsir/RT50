Public Class clsModelOptionSetting
    Inherits clsModelBase

#Region "Constant"
    Private Const ROW_HEADER_COLUMN_NAME As String = "MODEL_CODE"
#End Region

#Region "Attribute"
    Private m_taModelOptRow As New taMODEL_OPTION_ROW
    Private m_taOptMst As New taOPTION_MST
    Private m_taModelOptCell As New taMODEL_OPTION_CELL
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

    Protected Overrides Sub FillByNextGroup(ByRef dt As System.Data.DataTable, _
                                            ByVal cnt As Integer, _
                                            ByVal strModelYearPattern As String, _
                                            ByVal strSuffixCodePattern As String)
        m_taModelOptRow.FillByNextGroup(dt, _
                                        cnt, _
                                        strModelYearPattern, _
                                        strSuffixCodePattern, _
                                        Convert.ToInt32(IsNotNewModelCode))
    End Sub

    Protected Overrides Function GetDataByOffsetBase(ByVal strModelYearPattern As String, _
                                                  ByVal strSuffixCodePattern As String) As Integer
        Return m_taModelOptRow.GetDataByOffsetBase(strModelYearPattern, _
                                                strSuffixCodePattern, _
                                                Convert.ToInt32(IsNotNewModelCode))
    End Function

    Protected Overrides Sub FillByPrevBtn(ByRef dt As System.Data.DataTable, _
                                          ByVal cnt As Integer, _
                                          ByVal strModelYearPattern As String, _
                                          ByVal strSuffixCodePattern As String)
        m_taModelOptRow.FillByPrevBtn(dt, _
                                      cnt, _
                                      strModelYearPattern, _
                                      strSuffixCodePattern, _
                                      Convert.ToInt32(IsNotNewModelCode))
    End Sub

    Public Overrides Sub LoadData(ByVal strModelYearPattern As String, _
                                  ByVal strSuffixCodePattern As String, _
                                  ByVal nFnc As enuFillBy)
        Dim dtRow As dsPAINT.dtMODEL_OPTION_ROWDataTable = GetDataRow(strModelYearPattern, strSuffixCodePattern, nFnc)
        m_taOptMst.Fill(ds.dtOPTION_MST)
        m_taModelOptCell.Fill(ds.dtMODEL_OPTION_CELL)

        Dim dtCol As dsPAINT.dtOPTION_MSTDataTable = ds.dtOPTION_MST
        Dim dtCell As dsPAINT.dtMODEL_OPTION_CELLDataTable = ds.dtMODEL_OPTION_CELL

        m_strRowsHeaderColumnName = ROW_HEADER_COLUMN_NAME.Split(",")
        m_chs.Clear()
        m_chs.AddRange(GetColumnsHeader(dtRow.Columns))

        m_strDynamicColumnName = "OPTION_SEQ_NAME"
        m_chs.AddRange(GetColumnsHeader(dtCol.Rows))

        ' ''Add MODEL_OPTION_ROW_ID Hidden Column
        Dim chModelOptRowId As New ColumnHeader
        chModelOptRowId.Text = ParseColumnName("MODEL_OPTION_ROW_ID")
        m_chs.Add(chModelOptRowId)
        m_strRowsHeaderColumnName = String.Concat(ROW_HEADER_COLUMN_NAME, ",MODEL_OPTION_ROW_ID").Split(",")

        ' ''Add column details
        Dim strRowsHeaderColumn As New String(",", ROW_HEADER_COLUMN_NAME.Split(",").Length)
        m_lsvColumnItems = GetColumnDetails(strRowsHeaderColumn, dtCol.Rows)

        Dim htRows As Hashtable = GetRowHashTable(dtRow.Rows)
        Dim htCols As Hashtable = GetColHashTable(dtCol.Rows)

        m_strRowsHeaderValue = GetRowsHeader(dtRow.Rows)
        m_lsvItems = GetRows(htRows, htCols, dtCell.Rows)

        ' ''Remove MODEL_OPTION_ROW_ID Hidden Column
        m_chs.RemoveAt(m_chs.Count - 1)
    End Sub

    Public Overrides Sub InitialPoint(ByRef strModelYearPattern As String, _
                                      ByRef strSuffixCodePattern As String)
        ' ''If strModelYearPattern = String.Empty Then
        ' ''    strModelYearPattern = String.Format("{0:0}*0", (Now.Year Mod 100) / 10)
        ' ''End If
    End Sub

    Protected Overrides Function EmptyTable() As DataTable
        Return ds.dtMODEL_OPTION_ROW
    End Function

    Protected Overrides Function GetColHashTable(ByVal drc As System.Data.DataRowCollection) As System.Collections.Hashtable
        Dim ht As Hashtable = New Hashtable

        Dim strFilterExpressionVal As String = _
        Convert.ToString(dsPAINT.dtOPTION_MSTDataTable.enuOptionType.Destination)
        Dim intOptDestLen As Integer = drc(0).Table.Select("OPTION_TYPE = " + strFilterExpressionVal).Length - 1

        Dim intOffset As Integer = m_chs.Count - (drc.Count - intOptDestLen)
        intOffset -= 1 ' ''Remove MODEL_OPTION_ROW_ID Hidden Column

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

        For Each r As dsPAINT.dtMODEL_OPTION_ROWRow In drc
            Dim strKey As String = String.Empty
            strKey = String.Format("{0}", r.MODEL_OPTION_ROW_ID)

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

                For Each drCell As dsPAINT.dtMODEL_OPTION_CELLRow In drCells
                    Dim strCellKey As String = String.Format("{0},{1}", drCell.MODEL_OPTION_ROW_ID, drCell.OPTION_ID)

                    If strKey = strCellKey Then
                        Dim intColIdx As Integer = Convert.ToInt16(htCols.Item(colKey))
                        Dim blnIsOptDest As Boolean = _
                        drCell.OPTION_TYPE = dsPAINT.dtOPTION_MSTDataTable.enuOptionType.Destination

                        strVals(intColIdx) = IIf(drCell.IS_USED, _
                                                 IIf(blnIsOptDest, _
                                                     drCell.OPTION_DISPLAY, _
                                                     Convert.ToInt32(drCell.IS_USED).ToString), _
                                                 Convert.ToInt32(drCell.IS_USED).ToString)
                    End If
                Next drCell
            Next colKey

            lsvItems(intRowIdx) = New ListViewItem(strVals.ToArray)
        Next rowKey

        Return lsvItems
    End Function

    Private Function GetColumnDetails(ByVal strHeaderColumnBase As String, _
                                      ByVal cols As DataRowCollection) As ListViewItem()
        Dim blnIsAddDestination As Boolean = True
        Dim blnIsOptionTable As Boolean = False

        Dim strCode As String = strHeaderColumnBase
        Dim strName As String = strHeaderColumnBase
        Dim strDisplay As String = strHeaderColumnBase
        For Each col As dsPAINT.dtOPTION_MSTRow In cols
            blnIsOptionTable = (col.OPTION_TYPE = dsPAINT.dtOPTION_MSTDataTable.enuOptionType.OptionTable)
            If blnIsAddDestination Or blnIsOptionTable Then
                strCode &= "CODE: " + col.OPTION_CODE
                strName &= "NAME: " + col.OPTION_NAME
                strDisplay &= "DISPLAY: " + IIf(blnIsAddDestination, String.Empty, col.OPTION_DISPLAY)
            End If

            If (blnIsAddDestination Or blnIsOptionTable) AndAlso cols.IndexOf(col) < cols.Count - 1 Then
                strCode &= ","
                strName &= ","
                strDisplay &= ","

                blnIsAddDestination = False
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
