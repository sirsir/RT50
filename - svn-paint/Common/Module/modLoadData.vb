Public Module modLoadData

#Region "Attribute"
    Private m_dsPaint As New dsPAINT

    Private m_taMessageMst As New dsPAINTTableAdapters.taMESSAGE_MST
    Private m_taProcessMst As New dsPAINTTableAdapters.taPROCESS_MST
    Private m_taPlcMst As New dsPAINTTableAdapters.taPLC_MST
    Private m_taProductionDat As New dsPAINTTableAdapters.taPRODUCTION_DAT
    Private m_taModelOptionRow As New dsPAINTTableAdapters.taMODEL_OPTION_ROW
    Private m_taLogDat As New dsPAINTTableAdapters.taLOG_DAT
    Private m_taPaintCell As New dsPAINTTableAdapters.taPAINT_CELL
    Private m_taPlcStatus As New dsPAINTTableAdapters.taPlcStatusTableAdapter

    'Private m_taMessageMst As New dsPsisServerTableAdapters.taMessageMst
    'Private m_taProcessMst As New dsPsisServerTableAdapters.taProcessMst
    'Private m_taPlcMst As New dsPsisServerTableAdapters.taPlcMst
    'Private m_taProductionDat As New dsPsisServerTableAdapters.taProductionDat
    'Private m_taModelOptionRow As New dsPsisServerTableAdapters.taModelOptionRow
    'Private m_taLogDat As New dsPsisServerTableAdapters.taLogDat
    'Private m_taPaintCell As New dsPsisServerTableAdapters.taPaintCell
    'Private m_taProdDat As New dsPsisServerTableAdapters.taProductionDat
#End Region

#Region "Property"

    Public ReadOnly Property LogMessageMasterDataTable() As dsPAINT.dtMESSAGE_MSTDataTable
        Get
            Return m_dsPaint.dtMESSAGE_MST
        End Get
    End Property

    Public ReadOnly Property ProcessMasterDataTable() As dsPAINT.dtPROCESS_MSTDataTable
        Get
            Return m_dsPaint.dtPROCESS_MST
        End Get
    End Property

    Public ReadOnly Property PlcStatusDataTable() As dsPAINT.dtPlcStatusDataTable
        Get
            Return m_dsPaint.dtPlcStatus
        End Get
    End Property

    Public ReadOnly Property PlcMasterDataTable() As dsPAINT.dtPLC_MSTDataTable
        Get
            Return m_dsPaint.dtPLC_MST
        End Get
    End Property

    Public ReadOnly Property GetPLCStatusByStageCode(ByVal strCode As Integer) As dsPAINT.dtPlcStatusRow
        Get
            Return m_dsPaint.dtPlcStatus.Select("STAGE_CODE = '" & strCode & "'")(0)
        End Get
    End Property

    Public ReadOnly Property GetPLCMasterByStageCode(ByVal strCode As Integer) As dsPAINT.dtPLC_MSTRow
        Get
            Return m_dsPaint.dtPLC_MST.Select("STAGE_CODE = '" & strCode & "'")(0)
        End Get
    End Property

    Public ReadOnly Property LogData() As dsPAINT.dtLOG_DATDataTable
        Get
            Return m_dsPaint.dtLOG_DAT
        End Get
    End Property

    Public ReadOnly Property GetCountModelOptionRowByModelYearAndSuffixCodePattern(ByVal strModelYear As String, ByVal strSuffixCode As String) As Integer
        Get
            Return m_dsPaint.dtMODEL_OPTION_ROW.Select("MODEL_YEAR_PATTERN = '" & RTrim(strModelYear) & "' And SUFFIX_CODE_PATTERN = '" & RTrim(strSuffixCode) & "'").Count
        End Get
    End Property

    Public ReadOnly Property DataSet() As dsPAINT
        Get
            Return m_dsPaint
        End Get
    End Property
#End Region

#Region "Method"

    Public Sub LoadLogMessageMaster()
        m_taMessageMst.Fill(m_dsPaint.dtMESSAGE_MST)
    End Sub

    Public Sub LoadProcessMaster()
        m_taProcessMst.Fill(m_dsPaint.dtPROCESS_MST)
        m_taPlcStatus.FillAllStageCode(m_dsPaint.dtPlcStatus)
        m_taPlcMst.Fill(m_dsPaint.dtPLC_MST)
    End Sub

    Public Sub LoadProductionData()
        m_taProductionDat.Fill(m_dsPaint.dtPRODUCTION_DAT)
    End Sub

    Public Sub LoadAS400Log(ByVal rowCount As Integer, ByVal startTime As Date)
        m_taLogDat.FillByNumRowAndSystemStart(m_dsPaint.dtLOG_DAT, rowCount, startTime)
    End Sub

    Public Sub LoadModelOptionRow()
        m_taModelOptionRow.Fill(m_dsPaint.dtMODEL_OPTION_ROW)
    End Sub

#End Region

End Module

