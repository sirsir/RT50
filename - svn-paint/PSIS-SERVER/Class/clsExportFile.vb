Public Class clsExportFile

#Region "Constant"

#End Region

#Region "Attribute"
    Private m_drProd As dsPAINT.dtPRODUCTION_DATRow
    Private m_drPaints() As dsPAINT.dtPAINT_CELLRow
    Private m_drPaint As dsPAINT.dtPAINT_CELLRow

    Private m_dtPaints As New dsPAINT.dtPAINT_CELLDataTable
    Private m_taPaint As New dsPAINTTableAdapters.taPAINT_CELL
#End Region

#Region "Constructor"
    Public Sub New(ByVal drProd As dsPAINT.dtPRODUCTION_DATRow, ByVal processNo As Integer)

        Dim intResult As Integer = m_taPaint.FillByPK(m_dtPaints, drProd.MODEL_YEAR, drProd.SUFFIX_CODE, drProd.LOT_NO, drProd.UNIT, processNo)

        If intResult > 0 Then
            m_drPaint = m_dtPaints(0)
        End If
        m_drProd = drProd
    End Sub
#End Region

#Region "Property"
    Public ReadOnly Property Size() As Integer
        Get
            Return HeaderSize + DataSize + TrailerSize
        End Get
    End Property

    Public ReadOnly Property HeaderSize() As Integer
        Get
            Return TITLE + DATASET_NAME + _DATE + TIME + RECORD_SIZE + BLOCK_SIZE + FILLER_HEADER
        End Get
    End Property

    Public ReadOnly Property DataSize() As Integer
        Get
            Return MODEL_CODE + LENGTH_OF_LOT_NO + LENGTH_OF_UNIT + _
                    LENGTH_OF_BLOCK + LENGTH_OF_BLOCK_SEQ + TIMESTAMP + SPARE
        End Get
    End Property

    Public ReadOnly Property TrailerSize() As Integer
        Get
            Return TITLE + DATA_NUMBER + FILLER_TRAILER
        End Get
    End Property
#End Region

#Region "Method"

    Public Overrides Function ToString() As String
        Dim sbData As New System.Text.StringBuilder

        '' ''FILLER PART
        '' '' ''FILE HEADER
        'sbData.Append(TITLE_HEADER_NAME.ToString.PadRight(TITLE, " "))
        'sbData.Append(_DATASET_NAME.ToString.PadRight(DATASET_NAME, " "))
        'sbData.Append(Date.Now.ToString("yyyyMMdd").PadRight(_DATE, " "))
        'sbData.Append(Date.Now.ToString("HHmmss").PadRight(TITLE, " "))
        'sbData.Append(DataSize.ToString.PadLeft(RECORD_SIZE, "0"))
        'sbData.Append(BLOCK_SIZE_VALUE.ToString.PadLeft(BLOCK_SIZE, "0"))
        'sbData.Append(String.Empty.PadRight(FILLER_HEADER, " "))

        '' ''New Line
        'sbData.Append(vbCrLf)

        ' ''DATA PART
        sbData.Append(String.Concat(m_drProd.MODEL_YEAR, m_drProd.SUFFIX_CODE).ToString.PadRight(MODEL_CODE, " "))
        sbData.Append(m_drProd.LOT_NO.ToString.PadRight(LENGTH_OF_LOT_NO, " "))
        sbData.Append(m_drProd.UNIT.ToString.PadRight(LENGTH_OF_UNIT, " "))
        sbData.Append(m_drProd.BLOCK_MODEL.ToString.PadRight(LENGTH_OF_BLOCK, " "))
        sbData.Append(m_drProd.BLOCK_SEQ.ToString.PadRight(LENGTH_OF_BLOCK_SEQ, " "))
        sbData.Append(m_drPaint.PROCESS_RESULT_DATE.ToString("yyyyMMddHHmmss").PadRight(TIMESTAMP, " "))
        sbData.Append(String.Empty.PadRight(SPARE, " "))

        '' ''New Line
        'sbData.Append(vbCrLf)

        '' '' ''FILE TRAILER
        'sbData.Append(TITLE_TRAILER_NAME.ToString.PadRight(TITLE, " "))
        'sbData.Append(DATA_NUMBER_VALUE.ToString.PadLeft(DATA_NUMBER, "0"))
        'sbData.Append(String.Empty.PadRight(FILLER_TRAILER, " "))

        Return sbData.ToString
    End Function

#End Region

#Region "Event"

#End Region

End Class
