Imports System.Text.RegularExpressions

Public Class ClsBody

#Region "Constant"
    Public Const RECORD_TYPE_BODY As Integer = 2
#End Region

#Region "Attribute"
    Dim m_strSeq As String
    Dim m_strModelYear As String
    Dim m_strSuffixCode As String
    Dim m_strLodId As String
    Dim m_strLotNo As String
    Dim m_strUnit As String
    Dim m_strBlock As String
    Dim m_strBlockSeq As String
    Dim m_strMark As String
    Dim m_strProductionDate As String
    Dim m_strShift As String
    Dim m_strOnTime As String
    Dim m_strImportCode As String
    Dim m_strYChassisFlag As String
    Dim m_strGAShop As String
    Dim m_strBodyShopCode As String
    Dim m_strHandleType As String
    Dim m_strBCTCSW As String
    Dim m_strBCSeq As String
    Dim m_strBCOpt As String
    Dim m_strBCName As String
    Dim m_strSCSFSW As String
    Dim m_strSCOther As String
    Dim m_strSCName As String
    Dim m_strSpare As String
#End Region

#Region "Constructor"

    Public Sub New()
        m_strSeq = String.Empty
        m_strModelYear = String.Empty
        m_strSuffixCode = String.Empty
        m_strLodId = String.Empty
        m_strLotNo = String.Empty
        m_strUnit = String.Empty
        m_strBlock = String.Empty
        m_strBlockSeq = String.Empty
        m_strMark = String.Empty
        m_strProductionDate = String.Empty
        m_strShift = String.Empty
        m_strOnTime = String.Empty
        m_strImportCode = String.Empty
        m_strYChassisFlag = String.Empty
        m_strGAShop = String.Empty
        m_strBodyShopCode = String.Empty
        m_strHandleType = String.Empty
        m_strBCTCSW = String.Empty
        m_strBCSeq = String.Empty
        m_strBCOpt = String.Empty
        m_strBCName = String.Empty
        m_strSCSFSW = String.Empty
        m_strSCOther = String.Empty
        m_strSCName = String.Empty
        m_strSpare = String.Empty
    End Sub

#End Region

#Region "Property"

    Public ReadOnly Property SeqNo() As String
        Get
            Return m_strSeq
        End Get
    End Property

    Public ReadOnly Property ModelYear() As String
        Get
            Return m_strModelYear
        End Get
    End Property

    Public ReadOnly Property SuffixCode() As String
        Get
            Return m_strSuffixCode
        End Get
    End Property

    Public ReadOnly Property LotId() As String
        Get
            Return m_strLodId
        End Get
    End Property

    Public ReadOnly Property LotNo() As String
        Get
            Return m_strLotNo
        End Get
    End Property

    Public ReadOnly Property Unit() As String
        Get
            Return m_strUnit
        End Get
    End Property

    Public ReadOnly Property Block() As String
        Get
            Return m_strBlock
        End Get
    End Property

    Public ReadOnly Property BlockSeq() As String
        Get
            Return m_strBlockSeq
        End Get
    End Property

    Public ReadOnly Property Mark() As String
        Get
            Return m_strMark
        End Get
    End Property

    Public ReadOnly Property ProductionDate() As String
        Get
            Return m_strProductionDate
        End Get
    End Property

    Public ReadOnly Property Shift() As String
        Get
            Return m_strShift
        End Get
    End Property

    Public ReadOnly Property OnTime() As String
        Get
            Return m_strOnTime
        End Get
    End Property

    Public ReadOnly Property ImportCode() As String
        Get
            Return m_strImportCode
        End Get
    End Property

    Public ReadOnly Property YChasisFlag() As String
        Get
            Return m_strYChassisFlag
        End Get
    End Property

    Public ReadOnly Property GAShop() As String
        Get
            Return m_strGAShop
        End Get
    End Property

    Public ReadOnly Property BodyShopCode() As String
        Get
            Return m_strBodyShopCode
        End Get
    End Property

    Public ReadOnly Property HandleType() As String
        Get
            Return m_strHandleType
        End Get
    End Property

    Public ReadOnly Property BodyColorTCSW() As String
        Get
            Return m_strBCTCSW
        End Get
    End Property

    Public ReadOnly Property BodyColorSeq() As String
        Get
            Return m_strBCSeq
        End Get
    End Property

    Public ReadOnly Property BodyColorOpt() As String
        Get
            Return m_strBCOpt
        End Get
    End Property

    Public ReadOnly Property BodyColorName() As String
        Get
            Return m_strBCName
        End Get
    End Property

    Public ReadOnly Property SurfaceColorSFSW() As String
        Get
            Return m_strSCSFSW
        End Get
    End Property

    Public ReadOnly Property SurfaceColorOther() As String
        Get
            Return m_strBCOpt
        End Get
    End Property

    Public ReadOnly Property SurfaceColorName() As String
        Get
            Return m_strSCName
        End Get
    End Property

    Public ReadOnly Property Spare() As String
        Get
            Return m_strSpare
        End Get
    End Property

#End Region

#Region "Method"

    Public Shared Function ExtractToBody(ByVal strData As String) As ClsBody
        If strData = String.Empty Or strData.Length = 0 Then
            Return Nothing
        End If

        Dim objClsBody As ClsBody = New ClsBody
        objClsBody.m_strSeq = strData.Substring(0, LENGTH_OF_SEQ_NO)
        objClsBody.m_strModelYear = strData.Substring(5, LENGTH_OF_MODEL_YEAR)
        objClsBody.m_strSuffixCode = strData.Substring(8, LENGTH_OF_SUFFIX_CODE)
        objClsBody.m_strLodId = strData.Substring(13, LENGTH_OF_LOT_ID)
        objClsBody.m_strLotNo = strData.Substring(16, LENGTH_OF_LOT_NO)
        objClsBody.m_strUnit = strData.Substring(19, LENGTH_OF_UNIT)
        objClsBody.m_strBlock = strData.Substring(22, LENGTH_OF_BLOCK)
        objClsBody.m_strBlockSeq = strData.Substring(30, LENGTH_OF_BLOCK_SEQ)
        objClsBody.m_strMark = strData.Substring(33, LENGTH_OF_MARK)
        objClsBody.m_strProductionDate = strData.Substring(36, LENGTH_OF_PRODUCTION_DATE)
        objClsBody.m_strShift = strData.Substring(44, LENGTH_OF_SHIFT)
        objClsBody.m_strOnTime = strData.Substring(45, LENGTH_OF_ONTIME)
        objClsBody.m_strImportCode = strData.Substring(49, LENGTH_OF_IMPORT_CODE)
        objClsBody.m_strYChassisFlag = strData.Substring(59, LENGTH_OF_Y_CHASSIS_FLAG)
        objClsBody.m_strGAShop = strData.Substring(60, LENGTH_OF_GA_SHOP)
        objClsBody.m_strBodyShopCode = strData.Substring(62, LENGTH_OF_BODY_SHOP_CODE)
        objClsBody.m_strHandleType = strData.Substring(64, LENGTH_OF_HANDLE_TYPE)
        objClsBody.m_strBCTCSW = strData.Substring(66, LENGTH_OF_BODY_COLOR_TC_SW)
        objClsBody.m_strBCSeq = strData.Substring(69, LENGTH_OF_BODY_COLOR_SEQ)
        objClsBody.m_strBCOpt = strData.Substring(72, LENGTH_OF_BODY_COLOR_OPT)
        objClsBody.m_strBCName = strData.Substring(75, LENGTH_OF_BODY_COLOR_NAME)
        objClsBody.m_strSCSFSW = strData.Substring(95, LENGTH_OF_SURFACE_COLOR_SF_SW)
        objClsBody.m_strSCOther = strData.Substring(98, LENGTH_OF_SURFACE_COLOR_XXX)
        objClsBody.m_strSCName = strData.Substring(101, LENGTH_OF_SURFACE_COLOR_NAME)
        objClsBody.m_strSpare = strData.Substring(121, LENGTH_OF_SPARE)

        Return objClsBody
    End Function

    Public Shared Function CheckFormatBody(ByVal strData As String) As Boolean
        Dim bResult As Boolean = False
        Dim strRegex As String

        If strData = String.Empty Or strData.Length = 0 Then
            Return bResult
        End If

        Dim strLineFeed As String = "^"
        Dim strSeqNo As String = "[0-9]{5}"
        Dim strModelYear As String = "[0-9]{3}"
        Dim strSuffixCode As String = "[0-9A-Za-z ]{5}"
        Dim strLotId As String = "[0-9]{3}"
        Dim strLotNo As String = "[0-9]{3}"
        Dim strUnit As String = "[0-9]{3}"
        Dim strBlock As String = "[0-9A-Za-z ]{8}"
        Dim strBlockSeq As String = "[0-9 ]{3}"
        Dim strMark As String = "[0-9A-Za-z ]{3}"
        Dim strProductionDate As String = "[0-9]{8}"
        Dim strShift As String = "[0-9A-Za-z ]{1}"          'Not Sure
        Dim strOntime As String = "[0-9]{4}"
        Dim strImportCode As String = "[0-9A-Za-z -]{10}"
        Dim strYChasisFlag As String = "[ 1]{1}"
        Dim strtmp As String = "[0-9A-Za-z #(.)=-]{140}"

        'Dim strGAShop As String = "[0-9A-Za-z ]{2}"         'Not Sure
        'Dim strBodyShopCode As String = "[0-9A-Za-z ]{2}"   'Not Sure
        'Dim strHandleType As String = "[0-9A-Za-z ]{2}"     'Not Sure
        'Dim strBCTCSW As String = "[0-9A-Za-z ]{3}"         'Not Sure
        'Dim strBCSeq As String = "[0-9A-Za-z ]{3}"          'Not Sure
        'Dim strBCOpt As String = "[0-9A-Za-z ]{3}"          'Not Sure
        'Dim strBCName As String = "[0-9A-Za-z #]{20}"       'Not Sure
        'Dim strSCSFSW As String = "[0-9A-Za-z ]{3}"         'Not Sure
        'Dim strSCOther As String = "[0-9A-Za-z ]{3}"        'Not Sure
        'Dim strSCName As String = "[0-9A-Za-z ]{20}"        'Not Sure
        'Dim strSpare As String = "[0-9A-Za-z ]{79}"         'Not Sure

        strRegex = strLineFeed & strSeqNo & strModelYear & strSuffixCode & strLotId & strLotNo & strUnit & strBlock & strBlockSeq & strMark _
                    & strProductionDate & strShift & strOntime & strImportCode & strYChasisFlag & strtmp
        '& strGAShop & strBodyShopCode & strHandleType & strBCTCSW & strBCSeq & strBCOpt & strBCName & strSCSFSW & strSCOther & strSCName & strSpare

        Dim reg_exp As New Regex(strRegex)
        bResult = reg_exp.IsMatch(strData)

        Return bResult
    End Function

    Public Sub ConvertObjectToDatarow(ByRef dr As dsPAINT.dtPRODUCTION_DATRow, ByVal strFileName As String)
        dr.SEQ_NO = Me.m_strSeq
        dr.MODEL_YEAR = Me.m_strModelYear
        dr.SUFFIX_CODE = Me.m_strSuffixCode
        dr.LOT_ID = Me.m_strLodId
        dr.LOT_NO = Me.m_strLotNo
        dr.UNIT = Me.m_strUnit
        dr.BLOCK_MODEL = Me.m_strBlock
        dr.BLOCK_SEQ = Me.m_strBlockSeq
        dr.MARK = Me.m_strMark
        dr.PRODUCTION_DATE = Me.m_strProductionDate
        dr.SHIFT = Me.m_strShift
        dr.ON_TIME = Me.m_strOnTime
        dr.IMPORT_CODE = Me.m_strImportCode
        dr.Y_CHASSIS_FLAG = Me.m_strYChassisFlag
        dr.GA_SHOP = Me.m_strGAShop
        dr.BODY_SHOP_CODE = Me.m_strBodyShopCode
        dr.HANDLE_TYPE = Me.m_strHandleType
        dr.BODY_COLOR_TC_SW = Me.m_strBCTCSW
        dr.BODY_COLOR_SEQ = Me.m_strBCSeq
        dr.BODY_COLOR_OPT = Me.m_strBCOpt
        dr.BODY_COLOR_NAME = Me.m_strBCName
        dr.SURFACE_COLOR_SF_SW = Me.m_strSCSFSW
        dr.SURFACE_COLOR_XXX = Me.m_strSCOther
        dr.SURFACE_COLOR_NAME = Me.m_strSCName
        dr.FILE_NAME = strFileName
    End Sub

#End Region

End Class
