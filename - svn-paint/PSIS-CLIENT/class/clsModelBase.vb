Public MustInherit Class clsModelBase

#Region "Constant"
    Protected Const DYNAMIC_COLUMN_NAME As String = "PROCESS_NAME"
#End Region

#Region "Enumerator"
    Protected Enum enuHashValue
        row
        col
    End Enum

    Enum enuFillBy
        NextGroup
        PrevBtn
        NextBtn
        Up
    End Enum
#End Region

#Region "Attribute"
    Protected m_strDynamicColumnName As String = DYNAMIC_COLUMN_NAME

    Protected m_strRowsHeaderColumnName() As String
    Protected m_strRowsHeaderValue() As String
    Protected m_strColumnNames As New List(Of String)

    Protected m_chs As New List(Of ColumnHeader)
    Protected m_lsvColumnItems() As ListViewItem
    Protected m_lsvItems() As ListViewItem

    Protected Shared s_taRow As New taPRODUCTION_DAT
    Protected Shared s_taCol As New taPROCESS_MST
    Protected Shared s_taCell As New taPAINT_CELL

    Protected Shared ds As New dsPAINT

    Protected m_blnIsNewModelCode As Boolean = True
#End Region

#Region "Constructor"

#End Region

#Region "Property"
    Public MustOverride ReadOnly Property ProcessType() As dsPAINT.dtPROCESS_MSTDataTable.enuProcessType

    Public ReadOnly Property Columns() As ColumnHeader()
        Get
            Return m_chs.ToArray
        End Get
    End Property

    Public ReadOnly Property ColumnDetails() As ListViewItem()
        Get
            Return m_lsvColumnItems
        End Get
    End Property

    Public ReadOnly Property Rows() As ListViewItem()
        Get
            Return m_lsvItems
        End Get
    End Property

    Public Property IsNotNewModelCode() As Boolean
        Get
            Return m_blnIsNewModelCode
        End Get
        Set(ByVal value As Boolean)
            m_blnIsNewModelCode = value
        End Set
    End Property
#End Region

#Region "Method"
    Protected MustOverride Sub FillByNextGroup(ByRef dt As DataTable, _
                                               ByVal cnt As Integer, _
                                               ByVal strParam1 As String, _
                                               ByVal strParam2 As String)

    Protected MustOverride Sub FillByPrevBtn(ByRef dt As DataTable, _
                                             ByVal cnt As Integer, _
                                             ByVal strParam1 As String, _
                                             ByVal strParam2 As String)

    Protected MustOverride Function GetDataByOffsetBase(ByVal strParam1 As String, _
                                                     ByVal strParam2 As String) As Integer

    Public MustOverride Sub LoadData(ByVal strParam1 As String, _
                                     ByVal strParam2 As String, _
                                     ByVal nFnc As enuFillBy)

    Public Overridable Sub InitialPoint(ByRef strParam1 As String, _
                                        ByRef strParam2 As String)
        If strParam1 = String.Empty Or strParam2 = String.Empty Then
            Dim dt As New dsPAINT.dtPRODUCTION_DATDataTable

            s_taRow.FillByLastestResult(dt, ProcessType)

            If dt.Rows.Count > 0 Then
                Dim drLatest As dsPAINT.dtPRODUCTION_DATRow = dt.Rows(0)

                Dim latestParam1 As String = Param1(drLatest)
                Dim lateststrParam2 As String = drLatest.ON_TIME

                s_taRow.FillByPrevBtn(dt, My.Settings.MAX_ROW_COUNT, IIf(ProcessType = dsPAINT.dtPROCESS_MSTDataTable.enuProcessType.PBR, 1, 0), latestParam1, lateststrParam2)

                If dt.Rows.Count > 0 Then
                    Dim drPreviuous As dsPAINT.dtPRODUCTION_DATRow = dt.Rows(dt.Rows.Count - 1)

                    Dim proviousParam1 As String = Param1(drPreviuous)
                    Dim proviousParam2 As String = drPreviuous.ON_TIME

                    s_taRow.FillByNextGroup(dt, 2, IIf(ProcessType = dsPAINT.dtPROCESS_MSTDataTable.enuProcessType.PBR, 1, 0), proviousParam1, proviousParam2)

                    If dt.Rows.Count > 0 Then
                        Dim drNext As dsPAINT.dtPRODUCTION_DATRow = dt.Rows(0)

                        strParam1 = Param1(drNext)
                        strParam2 = drNext.ON_TIME
                    End If
                End If
            End If
        End If

        If strParam1 = String.Empty Then strParam1 = "0"
        If strParam2 = String.Empty Then strParam2 = "0"
    End Sub

    Private Function Param1(ByRef drLatest As dsPAINT.dtPRODUCTION_DATRow) As String
        Param1 = String.Empty
        If ProcessType = dsPAINT.dtPROCESS_MSTDataTable.enuProcessType.PBR Then
            Param1 &= IIf(drLatest.BLOCK_MODEL = String.Empty, "ZZZZZZZZ", drLatest.BLOCK_MODEL)
            Param1 &= IIf(drLatest.BLOCK_SEQ Is String.Empty, "ZZZ", drLatest.BLOCK_SEQ)
        End If
        Param1 &= drLatest.PRODUCTION_DATE
    End Function

    Protected Overridable Function EmptyTable() As DataTable
        Return ds.dtPRODUCTION_DAT
    End Function

    Protected Function GetDataRow(ByVal strParam1 As String, ByVal strParam2 As String, _
                                  ByVal nFnc As enuFillBy) As DataTable
        Dim dt As DataTable = EmptyTable()

        InitialPoint(strParam1, strParam2)

        Dim cnt As Integer
        Select Case nFnc
            Case enuFillBy.NextGroup : cnt = My.Settings.MAX_ROW_COUNT
            Case enuFillBy.PrevBtn : cnt = My.Settings.MAX_ROW_COUNT + 1
            Case enuFillBy.NextBtn, enuFillBy.Up : cnt = 2
        End Select

        Select Case nFnc
            Case enuFillBy.NextGroup, enuFillBy.NextBtn
                FillByNextGroup(dt, cnt, strParam1, strParam2)
            Case enuFillBy.PrevBtn, enuFillBy.Up
                FillByPrevBtn(dt, cnt, strParam1, strParam2)
        End Select

        If Not ScreenName = enuScreenName.PBR_Pass_Result Then
            If nFnc = enuFillBy.NextGroup Then
                Dim index As Integer = GetDataByOffsetBase(strParam1, strParam2)

                Dim i As Integer = index
                For Each dr As DataRow In dt.Rows
                    dr.Item("INDEX_NO") = i
                    i += 1
                Next dr
            End If
        End If

        Return dt
    End Function

    Protected Function GetColumnsHeader(ByVal dcc As DataColumnCollection) As ColumnHeader()
        Dim strColumnNames() As String = New String(m_strRowsHeaderColumnName.Length - 1) {}
        For Each c As DataColumn In dcc
            If m_strRowsHeaderColumnName.Contains(c.ColumnName) Then
                Dim intIdx As Integer = Array.IndexOf(m_strRowsHeaderColumnName, c.ColumnName)
                strColumnNames(intIdx) = ParseColumnName(c.ColumnName)
            End If
        Next c

        Return ColumnsHeader(strColumnNames.Distinct.ToArray)
    End Function

    Protected Function GetColumnsHeader(ByVal drc As DataRowCollection) As ColumnHeader()
        Dim strColumnNames As New List(Of String)
        For Each r As DataRow In drc
            strColumnNames.Add(ParseColumnName(GetColumnValue(r, m_strDynamicColumnName)))
        Next r

        Return ColumnsHeader(strColumnNames.Distinct.ToArray)
    End Function

    Protected Function ColumnsHeader(ByVal strColumnNames() As String) As ColumnHeader()
        Dim chs As New List(Of ColumnHeader)
        For Each strColumnName As String In strColumnNames
            Dim ch As ColumnHeader = New ColumnHeader
            ch.Text = strColumnName

            chs.Add(ch)
        Next strColumnName

        m_strColumnNames.AddRange(strColumnNames)

        Return chs.ToArray
    End Function

    Protected Function GetRowsHeader(ByVal drRows As System.Data.DataRowCollection) As String()
        Dim strRowsHeaderValue() As String = New String(drRows.Count - 1) {}

        For Each dr As DataRow In drRows
            Dim strVals As String = String.Empty

            For Each ch As ColumnHeader In m_chs
                Dim strVal As String = String.Empty
                If m_strRowsHeaderColumnName.Contains(ParseColumn(ch.Text)) Then
                    strVal = IIf(IsDBNull(dr.Item(ParseColumn(ch.Text))), String.Empty, dr.Item(ParseColumn(ch.Text)))
                End If

                strVals &= strVal
                If ch IsNot m_chs.Last Then strVals &= ","
            Next ch

            strRowsHeaderValue(drRows.IndexOf(dr)) = strVals
        Next dr

        Return strRowsHeaderValue
    End Function

    Protected Function GetRowsHeader(ByVal drRows As System.Data.DataRow()) As String()
        Dim strRowsHeaderValue() As String = New String(drRows.Count - 1) {}

        Dim intIndex As Integer = 0
        For Each dr As DataRow In drRows
            Dim strVals As String = String.Empty

            For Each ch As ColumnHeader In m_chs
                Dim strVal As String = String.Empty
                If m_strRowsHeaderColumnName.Contains(ParseColumn(ch.Text)) Then
                    strVal = IIf(IsDBNull(dr.Item(ParseColumn(ch.Text))), String.Empty, dr.Item(ParseColumn(ch.Text)))
                End If

                strVals &= strVal
                If ch IsNot m_chs.Last Then strVals &= ","
            Next ch

            strRowsHeaderValue(intIndex) = strVals
            intIndex += 1
        Next dr

        Return strRowsHeaderValue
    End Function

    Protected Overridable Function GetColHashTable(ByVal drc As DataRowCollection) As Hashtable
        Return Nothing
    End Function

    Protected Overridable Function GetRowHashTable(ByVal drc As DataRowCollection) As Hashtable
        Return Nothing
    End Function

    Protected Function GetRows() As ListViewItem()
        Dim lsvItems() As ListViewItem = New ListViewItem(m_strRowsHeaderValue.Count - 1) {}

        For Each strRowHeaderValue As String In m_strRowsHeaderValue
            Dim intRowIdx As Integer = Array.IndexOf(m_strRowsHeaderValue, strRowHeaderValue)
            lsvItems(intRowIdx) = New ListViewItem(strRowHeaderValue.Split(","))
        Next strRowHeaderValue

        Return lsvItems
    End Function
#End Region

#Region "Event"

#End Region
End Class
