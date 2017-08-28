Public Class frmInstructionData_AddEdit

#Region "Constant"

#End Region


#Region "Enumerator"
    Public Enum enuFormMode
        Add
        Edit
    End Enum
#End Region

#Region "Attribute"
    Private m_enuFormMode As enuFormMode
    Private m_strModelYear As String
    Private m_strSuffixCode As String
    Private m_strLotNo As String
    Private m_strUnit As String
    Private m_strProductionDate As String
    Private m_strOnTime As String
    Private m_dr As dsPAINT.dtPRODUCTION_DATRow
    Private m_dt As dsPAINT.dtPRODUCTION_DATDataTable
    Private m_ta As dsPAINTTableAdapters.taPRODUCTION_DAT
    Private m_objClsLogger As New clsLogger
#End Region

#Region "Constructor"

#End Region

#Region "Property"
    Public WriteOnly Property FormMode() As enuFormMode
        Set(ByVal value As enuFormMode)
            m_enuFormMode = value
            Select Case m_enuFormMode
                Case enuFormMode.Add
                    Me.twcSeqNo.EnableEdit = True
                    Me.twcModelCode.EnableEdit = True
                    Me.twcLotId.EnableEdit = True
                    Me.twcLotNo.EnableEdit = True
                    Me.twcUnit.EnableEdit = True
                    Me.twcBlock.EnableEdit = True
                    Me.twcBlockSeq.EnableEdit = True
                    Me.twcMark.EnableEdit = True
                    Me.twcProductionDate.EnableEdit = True
                    Me.twcShift.EnableEdit = True
                    Me.twcOnTime.EnableEdit = True
                    Me.twcImportCode.EnableEdit = True
                    Me.twcYChassis.EnableEdit = True
                    Me.twcGaShop.EnableEdit = True
                    Me.twcBodyShopCode.EnableEdit = True
                    Me.twcHandleType.EnableEdit = True
                    Me.twcBodyColorTcSw.EnableEdit = True
                    Me.twcBodyColorSeq.EnableEdit = True
                    Me.twcBodyColorOpt.EnableEdit = True
                    Me.twcBodyColorName.EnableEdit = True
                    Me.twcSurfaceColorSfSw.EnableEdit = True
                    Me.twcSurfaceColorXXX.EnableEdit = True
                    Me.twcSurfaceColorName.EnableEdit = True
                    Me.Text = "Instruction Data Add"
                Case enuFormMode.Edit
                    Me.twcSeqNo.EnableEdit = False
                    Me.twcModelCode.EnableEdit = False
                    Me.twcLotId.EnableEdit = False
                    Me.twcLotNo.EnableEdit = False
                    Me.twcUnit.EnableEdit = False
                    Me.twcBlock.EnableEdit = False
                    Me.twcBlockSeq.EnableEdit = False
                    Me.twcMark.EnableEdit = True
                    Me.twcProductionDate.EnableEdit = True
                    Me.twcShift.EnableEdit = True
                    Me.twcOnTime.EnableEdit = True
                    Me.twcImportCode.EnableEdit = True
                    Me.twcYChassis.EnableEdit = True
                    Me.twcGaShop.EnableEdit = True
                    Me.twcBodyShopCode.EnableEdit = True
                    Me.twcHandleType.EnableEdit = True
                    Me.twcBodyColorTcSw.EnableEdit = True
                    Me.twcBodyColorSeq.EnableEdit = True
                    Me.twcBodyColorOpt.EnableEdit = True
                    Me.twcBodyColorName.EnableEdit = True
                    Me.twcSurfaceColorSfSw.EnableEdit = True
                    Me.twcSurfaceColorXXX.EnableEdit = True
                    Me.twcSurfaceColorName.EnableEdit = True
                    Me.Text = "Instruction Data Edit"
            End Select
        End Set
    End Property

    Public Property ModelYear() As String
        Get
            Return m_strModelYear
        End Get
        Set(ByVal value As String)
            m_strModelYear = value
        End Set
    End Property

    Public Property SuffixCode() As String
        Get
            Return m_strSuffixCode
        End Get
        Set(ByVal value As String)
            m_strSuffixCode = value
        End Set
    End Property

    Public Property LotNo() As String
        Get
            Return m_strLotNo
        End Get
        Set(ByVal value As String)
            m_strLotNo = value
        End Set
    End Property

    Public Property Unit() As String
        Get
            Return m_strUnit
        End Get
        Set(ByVal value As String)
            m_strUnit = value
        End Set
    End Property

    Public Property ProductionDate() As String
        Get
            Return m_strProductionDate
        End Get
        Set(ByVal value As String)
            m_strProductionDate = value
        End Set
    End Property

    Public Property OnTime() As String
        Get
            Return m_strOnTime
        End Get
        Set(ByVal value As String)
            m_strOnTime = value
        End Set
    End Property
#End Region

#Region "Method"
    Private Sub Initialize()
        Me.twcSeqNo.InputName = "SEQ. No."
        Me.twcModelCode.InputName = "Model Code"
        Me.twcLotId.InputName = "Lot ID."
        Me.twcLotNo.InputName = "Lot No."
        Me.twcUnit.InputName = "Unit"
        Me.twcBlock.InputName = "Block"
        Me.twcBlockSeq.InputName = "Block Seq."
        Me.twcMark.InputName = "Mark"
        Me.twcProductionDate.InputName = "Production Date"
        Me.twcShift.InputName = "Shift"          'Not Sure
        Me.twcOnTime.InputName = "On Time"
        Me.twcImportCode.InputName = "Import Code"
        Me.twcYChassis.InputName = "Y-Chassis"
        Me.twcGaShop.InputName = "GA Shop"
        Me.twcBodyShopCode.InputName = "Body Shop Code"
        Me.twcHandleType.InputName = "Handle Type"
        Me.twcBodyColorTcSw.InputName = "Body Color TC SW"
        Me.twcBodyColorSeq.InputName = "Body Color Seq."
        Me.twcBodyColorOpt.InputName = "Body Color Opt."
        Me.twcBodyColorName.InputName = "Body Color Name"
        Me.twcSurfaceColorSfSw.InputName = "Surface Color SF SW"
        Me.twcSurfaceColorXXX.InputName = "Surface Color ???"
        Me.twcSurfaceColorName.InputName = "Surface Color Name"

        Me.twcSeqNo.HintMessage = "00000"
        'Me.twcModelCode.HintMessage = "Model Code"
        ' Me.twcLotId.HintMessage = "Lot ID."
        'Me.twcLotNo.HintMessage = "Lot No."
        'Me.twcUnit.HintMessage = "Unit"
        'Me.twcBlock.HintMessage = "Block"
        'Me.twcBlockSeq.HintMessage = "Block Seq."
        'Me.twcMark.HintMessage = "Mark"
        Me.twcProductionDate.HintMessage = "YYYYMMDD"
        'Me.twcShift.HintMessage = "Shift"          'Not Sure
        Me.twcOnTime.HintMessage = "HHMM"
        'Me.twcImportCode.HintMessage = "Import Code"
        'Me.twcYChassis.HintMessage = "Y-Chassis"
        Me.twcGaShop.HintMessage = "LA/UA"
        'Me.twcBodyShopCode.HintMessage = "Body Shop Code"
        Me.twcHandleType.HintMessage = "LH/RH"
        'Me.twcBodyColorTcSw.HintMessage = "Body Color TC SW"
        'Me.twcBodyColorSeq.HintMessage = "Body Color Seq."
        'Me.twcBodyColorOpt.HintMessage = "Body Color Opt."
        'Me.twcBodyColorName.HintMessage = "Body Color Name"
        'Me.twcSurfaceColorSfSw.HintMessage = "Surface Color SF SW"
        'Me.twcSurfaceColorXXX.HintMessage = "Surface Color ???"
        'Me.twcSurfaceColorName.HintMessage = "Surface Color Name"

        Me.twcSeqNo.MaxLength = 5
        Me.twcModelCode.MaxLength = 8
        Me.twcLotId.MaxLength = 3
        Me.twcLotNo.MaxLength = 3
        Me.twcUnit.MaxLength = 3
        Me.twcBlock.MaxLength = 8
        Me.twcBlockSeq.MaxLength = 3
        Me.twcMark.MaxLength = 3
        Me.twcProductionDate.MaxLength = 8
        Me.twcShift.MaxLength = 1
        Me.twcOnTime.MaxLength = 4
        Me.twcImportCode.MaxLength = 10
        Me.twcYChassis.MaxLength = 1
        Me.twcGaShop.MaxLength = 2
        Me.twcBodyShopCode.MaxLength = 2
        Me.twcHandleType.MaxLength = 2
        Me.twcBodyColorTcSw.MaxLength = 3
        Me.twcBodyColorSeq.MaxLength = 3
        Me.twcBodyColorOpt.MaxLength = 3
        Me.twcBodyColorName.MaxLength = 20
        Me.twcSurfaceColorSfSw.MaxLength = 3
        Me.twcSurfaceColorXXX.MaxLength = 3
        Me.twcSurfaceColorName.MaxLength = 20

        Me.twcSeqNo.RegexFormat = "[0-9]{5}"
        Me.twcModelCode.RegexFormat = "[0-9]{3}[0-9A-Za-z]{5}"
        Me.twcLotId.RegexFormat = "[0-9]{1,3}"
        Me.twcLotNo.RegexFormat = "[0-9]{1,3}"
        Me.twcUnit.RegexFormat = ("[0-9]{1,3}")
        Me.twcBlock.RegexFormat = "^$|([ ]{1,8})|[0-9A-Za-z]{8}"
        Me.twcBlockSeq.RegexFormat = "^$|[ ]{1,3}|([0-9]{1,3})"
        Me.twcMark.RegexFormat = "^$|(^[0-9A-Za-z ]{1,3})"
        Me.twcProductionDate.RegexFormat = "[0-9]{8}"
        Me.twcShift.RegexFormat = "[0-9A-Za-z ]{1}"          'Not Sure
        Me.twcOnTime.RegexFormat = "[0-9]{4}"
        Me.twcImportCode.RegexFormat = "[0-9A-Za-z -]{10}"
        Me.twcYChassis.RegexFormat = "^$|([ 1]{1})"
        Me.twcGaShop.RegexFormat = "[LU]A"
        Me.twcBodyShopCode.RegexFormat = "^$|(^[0-9A-Za-z #(.)=-]{1,2})"
        Me.twcHandleType.RegexFormat = "[LR]H"
        Me.twcBodyColorTcSw.RegexFormat = "^$|(^[0-9A-Za-z #(.)=-]{1,3})"
        Me.twcBodyColorSeq.RegexFormat = "^$|(^[0-9A-Za-z #(.)=-]{1,3})"
        Me.twcBodyColorOpt.RegexFormat = "^$|(^[0-9A-Za-z #(.)=-]{1,3})"
        Me.twcBodyColorName.RegexFormat = "^$|(^[0-9A-Za-z #(.)=-]{1,20})"
        Me.twcSurfaceColorSfSw.RegexFormat = "^$|(^[0-9A-Za-z #(.)=-]{1,3})"
        Me.twcSurfaceColorXXX.RegexFormat = "^$|(^[0-9A-Za-z #(.)=-]{1,3})"
        Me.twcSurfaceColorName.RegexFormat = "^$|(^[0-9A-Za-z #(.)=-]{1,20})"
    End Sub

    Private Function InsertRow() As Boolean
        Try
            'm_dt = New dsPAINT.dtPRODUCTION_DATDataTable
            'm_ta.Fill(m_dt)
            'm_dr = m_dt.FindByMODEL_YEARSUFFIX_CODELOT_NOUNIT(Me.twcModelCode.InputText.Substring(0, 3), Me.twcModelCode.InputText.Substring(3, 5), _
            '                        Me.twcLotNo.InputText, Me.twcUnit.InputText)
            'If m_dr IsNot Nothing Then
            '    MsgBox("Cannot Insert Duplicate Record", MsgBoxStyle.Exclamation, "Warning")
            '    m_dr = Nothing
            '    Return False
            'End If

            m_dt = m_ta.GetDataByPk(Me.twcModelCode.InputText.Substring(0, 3), Me.twcModelCode.InputText.Substring(3, 5), _
                                    Me.twcLotNo.InputText, Me.twcUnit.InputText)
            If m_dt IsNot Nothing AndAlso m_dt.Rows.Count > 0 Then
                MsgBox("Cannot Insert Duplicate Record", MsgBoxStyle.Exclamation, "Warning")
                m_dr = Nothing
                Return False
            End If

            m_dr = m_dt.NewdtPRODUCTION_DATRow
            With m_dr
                .BeginEdit()
                .SEQ_NO = Me.twcSeqNo.InputText.PadRight(5, " ")
                .MODEL_YEAR = Me.twcModelCode.InputText.Substring(0, 3)
                .SUFFIX_CODE = Me.twcModelCode.InputText.Substring(3, 5)
                .LOT_ID = Me.twcLotId.InputText.PadRight(3, " ")
                .LOT_NO = Me.twcLotNo.InputText
                .UNIT = Me.twcUnit.InputText
                .BLOCK_MODEL = Me.twcBlock.InputText.PadRight(8, " ")
                .BLOCK_SEQ = Me.twcBlockSeq.InputText.PadRight(3, " ")
                .MARK = Me.twcMark.InputText.PadRight(3, " ")
                .PRODUCTION_DATE = Me.twcProductionDate.InputText.PadRight(8, " ")
                .SHIFT = Me.twcShift.InputText.PadRight(1, " ")
                .ON_TIME = Me.twcOnTime.InputText.PadRight(4, " ")
                .IMPORT_CODE = Me.twcImportCode.InputText.PadRight(10, " ")
                .Y_CHASSIS_FLAG = Me.twcYChassis.InputText.PadRight(1, " ")
                .GA_SHOP = Me.twcGaShop.InputText.PadRight(2, " ")
                .BODY_SHOP_CODE = Me.twcBodyShopCode.InputText.PadRight(2, " ")
                .HANDLE_TYPE = Me.twcHandleType.InputText.PadRight(2, " ")
                .BODY_COLOR_TC_SW = Me.twcBodyColorTcSw.InputText.PadRight(3, " ")
                .BODY_COLOR_SEQ = Me.twcBodyColorSeq.InputText.PadRight(3, " ")
                .BODY_COLOR_OPT = Me.twcBodyColorOpt.InputText.PadRight(3, " ")
                .BODY_COLOR_NAME = Me.twcBodyColorName.InputText.PadRight(20, " ")
                .SURFACE_COLOR_SF_SW = Me.twcSurfaceColorSfSw.InputText.PadRight(3, " ")
                .SURFACE_COLOR_XXX = Me.twcSurfaceColorXXX.InputText.PadRight(3, " ")
                .SURFACE_COLOR_NAME = Me.twcSurfaceColorName.InputText.PadRight(20, " ")
                .EndEdit()
            End With
            m_dt.AdddtPRODUCTION_DATRow(m_dr)
            m_ta.Update(m_dr)

            '------------------
            Dim strModelYearPattern As String
            Dim strSuffixCodePattern As String
            Dim intResult As Integer
            strModelYearPattern = m_dr.MODEL_YEAR
            strSuffixCodePattern = m_dr.SUFFIX_CODE.Substring(0, 3) _
                                    & "*" & _
                                    m_dr.SUFFIX_CODE.Substring(4, 1)

            If modLoadData.GetCountModelOptionRowByModelYearAndSuffixCodePattern(strModelYearPattern, strSuffixCodePattern) <= 0 Then
                Dim strExpression As String = "MODEL_YEAR_PATTERN = '" & strModelYearPattern & "'" & _
                                " AND SUFFIX_CODE_PATTERN = '" & strSuffixCodePattern & "'"

                Dim dtModelOptionRow As New dsPAINT.dtMODEL_OPTION_ROWDataTable
                Dim ta As New dsPAINTTableAdapters.taMODEL_OPTION_ROW

                intResult = ta.FillByModelCode(dtModelOptionRow, strModelYearPattern, strSuffixCodePattern)

                If intResult = 0 Then
                    intResult = ta.Insert(strModelYearPattern, strSuffixCodePattern)
                End If
            End If
            '------------------
            If intResult > 0 Then
                m_dr.AcceptChanges()
                Return True
            Else
                m_dr.RejectChanges()
                Return False
            End If
        Catch ex As Exception
            m_dr.RejectChanges()
            m_objClsLogger.LogException(Me.GetType.Name, "UpdateRow", ex, True)
            Return False
        End Try
    End Function

    Private Function UpdateRow() As Boolean
        Try
            With m_dr
                .BeginEdit()
                .MARK = Me.twcMark.InputText.PadRight(3, " ")
                .PRODUCTION_DATE = Me.twcProductionDate.InputText.PadRight(8, " ")
                .SHIFT = Me.twcShift.InputText.PadRight(1, " ")
                .ON_TIME = Me.twcOnTime.InputText.PadRight(4, " ")
                .IMPORT_CODE = Me.twcImportCode.InputText.PadRight(10, " ")
                .Y_CHASSIS_FLAG = Me.twcYChassis.InputText.PadRight(1, " ")
                .GA_SHOP = Me.twcGaShop.InputText.PadRight(2, " ")
                .BODY_SHOP_CODE = Me.twcBodyShopCode.InputText.PadRight(2, " ")
                .HANDLE_TYPE = Me.twcHandleType.InputText.PadRight(2, " ")
                .BODY_COLOR_TC_SW = Me.twcBodyColorTcSw.InputText.PadRight(3, " ")
                .BODY_COLOR_SEQ = Me.twcBodyColorSeq.InputText.PadRight(3, " ")
                .BODY_COLOR_OPT = Me.twcBodyColorOpt.InputText.PadRight(3, " ")
                .BODY_COLOR_NAME = Me.twcBodyColorName.InputText.PadRight(20, " ")
                .SURFACE_COLOR_SF_SW = Me.twcSurfaceColorSfSw.InputText.PadRight(3, " ")
                .SURFACE_COLOR_XXX = Me.twcSurfaceColorXXX.InputText.PadRight(3, " ")
                .SURFACE_COLOR_NAME = Me.twcSurfaceColorName.InputText.PadRight(20, " ")
                .EndEdit()
            End With

            m_ta.Update(m_dr)
            m_dr.AcceptChanges()
            Return True
        Catch ex As Exception
            m_dr.RejectChanges()
            m_objClsLogger.LogException(Me.GetType.Name, "UpdateRow", ex, True)
            Return False
        End Try
    End Function
#End Region

#Region "Event"

    Private Sub btnExecute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExecute.Click
        Try
            Dim blnCheckResult As Boolean = True

            blnCheckResult = blnCheckResult And Me.twcSeqNo.CheckInput()
            blnCheckResult = blnCheckResult And Me.twcModelCode.CheckInput()
            blnCheckResult = blnCheckResult And Me.twcLotId.CheckInput()
            blnCheckResult = blnCheckResult And Me.twcLotNo.CheckInput()
            blnCheckResult = blnCheckResult And Me.twcUnit.CheckInput()
            blnCheckResult = blnCheckResult And Me.twcBlock.CheckInput()
            blnCheckResult = blnCheckResult And Me.twcBlockSeq.CheckInput()
            blnCheckResult = blnCheckResult And Me.twcMark.CheckInput()
            blnCheckResult = blnCheckResult And Me.twcProductionDate.CheckInput()
            blnCheckResult = blnCheckResult And Me.twcShift.CheckInput()          'Not Sure
            blnCheckResult = blnCheckResult And Me.twcOnTime.CheckInput()
            blnCheckResult = blnCheckResult And Me.twcImportCode.CheckInput()
            blnCheckResult = blnCheckResult And Me.twcYChassis.CheckInput()
            blnCheckResult = blnCheckResult And Me.twcGaShop.CheckInput()
            blnCheckResult = blnCheckResult And Me.twcBodyShopCode.CheckInput()
            blnCheckResult = blnCheckResult And Me.twcHandleType.CheckInput()
            blnCheckResult = blnCheckResult And Me.twcBodyColorTcSw.CheckInput()
            blnCheckResult = blnCheckResult And Me.twcBodyColorSeq.CheckInput()
            blnCheckResult = blnCheckResult And Me.twcBodyColorOpt.CheckInput()
            blnCheckResult = blnCheckResult And Me.twcBodyColorName.CheckInput()
            blnCheckResult = blnCheckResult And Me.twcSurfaceColorSfSw.CheckInput()
            blnCheckResult = blnCheckResult And Me.twcSurfaceColorXXX.CheckInput()
            blnCheckResult = blnCheckResult And Me.twcSurfaceColorName.CheckInput()

            If blnCheckResult Then
                Select Case m_enuFormMode
                    Case enuFormMode.Add
                        If InsertRow() Then
                            Me.ProductionDate = m_dr.PRODUCTION_DATE
                            Me.OnTime = m_dr.ON_TIME
                            Me.ModelYear = m_dr.MODEL_YEAR
                            Me.SuffixCode = m_dr.SUFFIX_CODE
                            Me.LotNo = m_dr.LOT_NO
                            Me.Unit = m_dr.UNIT
                            Me.DialogResult = Windows.Forms.DialogResult.OK
                        End If
                    Case enuFormMode.Edit
                        If UpdateRow() Then
                            Me.ProductionDate = m_dr.PRODUCTION_DATE
                            Me.OnTime = m_dr.ON_TIME
                            Me.ModelYear = m_dr.MODEL_YEAR
                            Me.SuffixCode = m_dr.SUFFIX_CODE
                            Me.LotNo = m_dr.LOT_NO
                            Me.Unit = m_dr.UNIT
                            Me.DialogResult = Windows.Forms.DialogResult.OK
                        End If
                End Select
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmInstructionData_AddEdit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.Initialize()
            Me.twcSeqNo.txtInput.Focus()
            m_ta = New dsPAINTTableAdapters.taPRODUCTION_DAT
            If m_enuFormMode = enuFormMode.Edit Then
                m_dt = m_ta.GetDataByPk(m_strModelYear, m_strSuffixCode, m_strLotNo, m_strUnit)
                If m_dt IsNot Nothing AndAlso m_dt.Rows.Count = 1 Then
                    m_dr = m_dt(0)
                    With m_dr
                        Me.twcSeqNo.InputText = .SEQ_NO
                        Me.twcModelCode.InputText = .MODEL_YEAR & .SUFFIX_CODE
                        Me.twcLotId.InputText = .LOT_ID
                        Me.twcLotNo.InputText = .LOT_NO
                        Me.twcUnit.InputText = .UNIT
                        Me.twcBlock.InputText = .BLOCK_MODEL
                        Me.twcBlockSeq.InputText = .BLOCK_SEQ
                        Me.twcMark.InputText = .MARK
                        Me.twcProductionDate.InputText = .PRODUCTION_DATE
                        Me.twcShift.InputText = .SHIFT
                        Me.twcOnTime.InputText = .ON_TIME
                        Me.twcImportCode.InputText = .IMPORT_CODE
                        Me.twcYChassis.InputText = .Y_CHASSIS_FLAG
                        Me.twcGaShop.InputText = .GA_SHOP
                        Me.twcBodyShopCode.InputText = .BODY_SHOP_CODE
                        Me.twcHandleType.InputText = .HANDLE_TYPE
                        Me.twcBodyColorTcSw.InputText = .BODY_COLOR_TC_SW
                        Me.twcBodyColorSeq.InputText = .BODY_COLOR_SEQ
                        Me.twcBodyColorOpt.InputText = .BODY_COLOR_OPT
                        Me.twcBodyColorName.InputText = .BODY_COLOR_NAME
                        Me.twcSurfaceColorSfSw.InputText = .SURFACE_COLOR_SF_SW
                        Me.twcSurfaceColorXXX.InputText = .SURFACE_COLOR_XXX
                        Me.twcSurfaceColorName.InputText = .SURFACE_COLOR_NAME

                        Me.twcMark.txtInput.Focus()
                    End With
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
#End Region
End Class