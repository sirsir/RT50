Public Class clsOptionMasterSetting
    Inherits clsModelBase

#Region "Constant"
    Private Const ROW_HEADER_COLUMN_NAME As String = "OPTION_NAME,OPTION_SEQ,OPTION_CODE,OPTION_DISPLAY,OPTION_TYPE"
#End Region

#Region "Attribute"
    Private Shared s_ta_OPT_MST As New taOPTION_MST
    Private m_taOptMST As New taOPTION_MST
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

#Region "Event"

#End Region

#Region "Method"
    Protected Overrides Sub FillByNextGroup(ByRef dt As DataTable, _
                                            ByVal cnt As Integer, _
                                            ByVal strOptionType As String, _
                                            ByVal strOptionSeq As String)

        m_taOptMST.FillByNextGroup(dt, cnt, Convert.ToInt32(strOptionType), Convert.ToInt32(strOptionSeq))
    End Sub

    Protected Overrides Sub FillByPrevBtn(ByRef dt As DataTable, _
                                          ByVal cnt As Integer, _
                                          ByVal strOptionType As String, _
                                          ByVal strOptionSeq As String)
        m_taOptMST.FillByPrevBtn(dt, cnt, Convert.ToInt32(strOptionType), Convert.ToInt32(strOptionSeq))
    End Sub

    Protected Overrides Function GetDataByOffsetBase(ByVal strOptionType As String, _
                                                  ByVal strOptionSeq As String) As Integer
        Return m_taOptMST.GetDataByOffsetBase(Convert.ToInt32(strOptionType), Convert.ToInt32(strOptionSeq))
    End Function

    Public Overrides Sub LoadData(ByVal strOptionType As String, _
                                  ByVal strOptionSeq As String, _
                                  ByVal nFnc As enuFillBy)
        Dim dtRow As dsPAINT.dtOPTION_MSTDataTable = GetDataRow(strOptionType, strOptionSeq, nFnc)
        Dim dtCol As New dsPAINT.dtPROCESS_MSTDataTable

        m_strRowsHeaderColumnName = ROW_HEADER_COLUMN_NAME.Split(",")
        m_chs.Clear()
        m_chs.AddRange(GetColumnsHeader(dtRow.Columns))

        ' ''Add OPTION_TYPE Hidden Column
        Dim chOptType As New ColumnHeader
        chOptType.Text = ParseColumnName("OPTION_TYPE")
        m_chs.Add(chOptType)

        ' ''Add OPTION_ID Hidden Column
        Dim chOptId As New ColumnHeader
        chOptId.Text = ParseColumnName("OPTION_ID")
        m_chs.Add(chOptId)
        m_strRowsHeaderColumnName = String.Concat(ROW_HEADER_COLUMN_NAME, ",OPTION_TYPE,OPTION_ID").Split(",")

        m_strRowsHeaderValue = GetRowsHeader(dtRow.Rows)
        m_lsvItems = GetRows()

        For index As Integer = 0 To m_lsvItems.Length - 1
            m_lsvItems(index).SubItems(4).Text = IIf(m_lsvItems(index).SubItems(4).Text = "1", "DESTINATION", "OPTION")
        Next

        ' ''Remove OPTION_TYPE,OPTION_ID Hidden Column
        m_chs.RemoveRange(m_chs.Count - 2, 2)
    End Sub
    Public Overrides Sub InitialPoint(ByRef strOptionType As String, _
                                      ByRef strOptionSeq As String)
        'strOptionType = IIf(strOptionType.Length = 0, "0", strOptionType)
        'strOptionSeq = IIf(strOptionSeq.Length = 0, "0", strOptionSeq)

        If strOptionType.Length = 0 Then
            strOptionType = "0"
        Else
            If strOptionType = "DESTINATION" Or strOptionType = "1" Then
                strOptionType = "1"
            Else
                strOptionType = "2"
            End If
        End If
        strOptionSeq = IIf(strOptionSeq.Length = 0, "0", strOptionSeq)
    End Sub

    Protected Overrides Function EmptyTable() As DataTable
        Return ds.dtOPTION_MST
    End Function
#End Region

End Class
