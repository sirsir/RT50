Imports System.Text.RegularExpressions
Imports System.IO
Imports System.Diagnostics
Imports Common

Public Class clsAs400File
#Region "MEMBER"
    Private m_strHeaderTitle As String
    Private m_strDataSetName As String
    Private m_dtAs400Date As Date
    Private m_strTrailTitle As String
    Private m_intDataNumber As Integer
    Private m_intRecordSize As Integer
    Private m_intBlockSize As Integer
    Private clsTLogDat As New TLogDat
    Private clsLogger As New Logger
    Private m_arrRow As New ArrayList
    Private m_strFileName As String
    Private taT_Production_DAT As ServerDatasetTableAdapters.T_Production_DATTableAdapter = modDataSource.ta(Of PIS_SERVER.ServerDatasetTableAdapters.T_Production_DATTableAdapter).GetTableAdapter()
    Private taT_Line_MST As ServerDatasetTableAdapters.T_Line_MSTTableAdapter = modDataSource.ta(Of PIS_SERVER.ServerDatasetTableAdapters.T_Line_MSTTableAdapter).GetTableAdapter()
    Private dtLineAll As New ServerDataset.T_Line_MSTDataTable
    Private dtLineCab As New ServerDataset.T_Line_MSTDataTable
    Private dtLinePubx As New ServerDataset.T_Line_MSTDataTable
    Private dtTemp As New ServerDataset.T_Production_DATDataTable
    Private dtOldData As New ServerDataset.T_Production_DATDataTable
    'Private dtNewData As New ServerDataset.T_Production_DATDataTable
    Private m_minimalSk As String
    Private m_prodDateTime As String
    Private m_intInsertCount As Integer
    Private m_intUpdateCount As Integer
    Private m_intSkipCount As Integer

    Public Const RECORD_TYPE_HEADER As Integer = 1
    Public Const RECORD_TYPE_PRODUCTION As Integer = 2
    Public Const RECORD_TYPE_TRAIL As Integer = 3
    Public Const RECORD_TYPE_UNKNOWN As Integer = 4
    Private Const WAIT_FOR_HEADER As Integer = 0
    Private Const WAIT_FOR_TRAIL As Integer = 1
    Private Const AS400_RECORD_SIZE As Integer = 1202
    Private Const PRODUCTION_TIME_DAY_SHIFT_START As String = "0730"
#End Region

#Region "METHOD"
#Region "GET AND SET METHOD"
    Public Property HeaderTitle() As String
        Get
            Return m_strHeaderTitle
        End Get
        Set(ByVal value As String)
            m_strHeaderTitle = value
        End Set
    End Property

    Public Property DataSetName() As String
        Get
            Return m_strDataSetName
        End Get
        Set(ByVal value As String)
            m_strDataSetName = value
        End Set
    End Property

    Public Property As400Date() As Date
        Get
            Return m_dtAs400Date
        End Get
        Set(ByVal value As Date)
            m_dtAs400Date = value
        End Set
    End Property

    Public Property TrailTitle() As String
        Get
            Return m_strTrailTitle
        End Get
        Set(ByVal value As String)
            m_strTrailTitle = value
        End Set
    End Property

    Public Property DataNumber() As Integer
        Get
            Return m_intDataNumber
        End Get
        Set(ByVal value As Integer)
            m_intDataNumber = value
        End Set
    End Property

    Public Property RecordSize() As Integer
        Get
            Return m_intRecordSize
        End Get
        Set(ByVal value As Integer)
            m_intRecordSize = value
        End Set
    End Property

    Public Property BlockSize() As Integer
        Get
            Return m_intBlockSize
        End Get
        Set(ByVal value As Integer)
            m_intBlockSize = value
        End Set
    End Property
#End Region

    Public Sub ExtractHeader(ByVal strHeader As String)
        clsLogger.Log(Logger.MessageType.NormalLog, Me.GetType.Name, "ExtractHeader", "Start", "")
        Try
            Me.m_strHeaderTitle = strHeader.Substring(0, 6)
            Me.m_strDataSetName = strHeader.Substring(6, 18)
            Me.m_dtAs400Date = Date.ParseExact(strHeader.Substring(24, 14), "yyyyMMddHHmmss", Nothing)

            Dim strTemp As String = strHeader.Substring(38, 5).TrimStart(" ")
            Me.m_intRecordSize = CInt(strTemp)

            strTemp = strHeader.Substring(43, 5).TrimStart(" ")
            Me.m_intBlockSize = CInt(strTemp)
        Catch ex As Exception
            clsLogger.Log(Logger.MessageType.ErrorLog, Me.GetType.Name, "ExtractHeader", ex.Message, ex.StackTrace)
        End Try
        clsLogger.Log(Logger.MessageType.NormalLog, Me.GetType.Name, "ExtractHeader", "End", "")
    End Sub

    Public Sub ExtractTrail(ByVal strTrail As String)
        clsLogger.Log(Logger.MessageType.NormalLog, Me.GetType.Name, "ExtractTrail", "Start", "")
        Try
            Me.m_strTrailTitle = strTrail.Substring(0, 6)

            Dim strTemp As String = strTrail.Substring(6, 8).TrimStart(" ")
            Me.m_intDataNumber = CInt(strTemp)
        Catch ex As Exception
            clsLogger.Log(Logger.MessageType.ErrorLog, Me.GetType.Name, "ExtractTrail", ex.Message, ex.StackTrace)
        End Try
        clsLogger.Log(Logger.MessageType.NormalLog, Me.GetType.Name, "ExtractTrail", "End", "")
    End Sub

    Public Function CheckRecordType(ByVal str As String) As Integer
        If CheckHeader(str) Then
            Return clsAs400File.RECORD_TYPE_HEADER
        ElseIf CheckProduction(str) Then
            Return clsAs400File.RECORD_TYPE_PRODUCTION
        ElseIf CheckTrail(str) Then
            Return clsAs400File.RECORD_TYPE_TRAIL
        Else
            Return clsAs400File.RECORD_TYPE_UNKNOWN
        End If
    End Function

    Public Function CheckRecordTypeReadLine(ByVal str As String) As Integer
        If CheckHeaderReadLine(str) Then
            Return clsAs400File.RECORD_TYPE_HEADER
        ElseIf CheckProductionReadLine(str) Then
            Return clsAs400File.RECORD_TYPE_PRODUCTION
        ElseIf CheckTrailReadLine(str) Then
            Return clsAs400File.RECORD_TYPE_TRAIL
        Else
            Return clsAs400File.RECORD_TYPE_UNKNOWN
        End If
    End Function

    Public Function CheckHeader(ByVal str As String) As Boolean
        Dim bl As Boolean = False
        Dim strRegex As String

        strRegex = "^HEADERRT50 BODY         "
        strRegex += "[0-9]{14}"
        strRegex += "[0-9]{5}"
        strRegex += "[0-9]{5}"
        strRegex += "[A-Za-z0-9 ]{1152}"

        Dim reg_exp As New Regex(strRegex)
        bl = reg_exp.IsMatch(str)
        If bl And str.Length = AS400_RECORD_SIZE Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function CheckHeaderReadLine(ByVal str As String) As Boolean
        Dim bl As Boolean = False
        Dim strRegex As String

        strRegex = "^HEADERRT50 BODY         "
        strRegex += "[0-9]{14}"
        strRegex += "[0-9]{5}"
        strRegex += "[0-9]{5}"
        strRegex += "[A-Za-z0-9 ]{1150}"

        Dim reg_exp As New Regex(strRegex)
        bl = reg_exp.IsMatch(str)
        If bl And str.Length = AS400_RECORD_SIZE - 2 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function CheckProduction(ByVal str As String) As Boolean
        Dim bl As Boolean = False
        Dim strRegex As String

        strRegex = "^[0-9]{8}[A-Za-z0-9 ]{5}[0-9]{9}[A-Za-z0-9 ]{8}[0-9 ]{3}[A-Za-z0-9 ]{3}[0-9]{12}[A-Za-z0-9 -]{10}" 'End at ImportCode
        strRegex += "[ 1]{1}[A-Za-z0-9 ]{4}[ ]{37}([0-9]{10}|[ ]{10}){100}[ ]{100}"

        Dim reg_exp As New Regex(strRegex)
        bl = reg_exp.IsMatch(str)

        If bl And str.Length = AS400_RECORD_SIZE Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function CheckProductionReadLine(ByVal str As String) As Boolean
        Dim bl As Boolean = False
        Dim strRegex As String

        strRegex = "^[0-9]{8}[A-Za-z0-9 ]{5}[0-9]{9}[A-Za-z0-9 ]{8}[0-9 ]{3}[A-Za-z0-9 ]{3}[0-9]{12}[A-Za-z0-9 -]{10}" 'End at ImportCode
        strRegex += "[ 1]{1}[A-Za-z0-9 ]{4}[ ]{37}([0-9]{10}|[ ]{10}){100}[ ]{98}"

        Dim reg_exp As New Regex(strRegex)
        bl = reg_exp.IsMatch(str)

        If bl And str.Length = AS400_RECORD_SIZE - 2 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function CheckTrail(ByVal str As String) As Boolean
        Dim bl As Boolean = False
        Dim strRegex As String

        strRegex = "^TRAIL "
        strRegex += "[0-9]{8}"
        strRegex += "[A-Za-z0-9 ]{1186}"

        Dim reg_exp As New Regex(strRegex)
        bl = reg_exp.IsMatch(str)

        If bl And str.Length = AS400_RECORD_SIZE Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function CheckTrailReadLine(ByVal str As String) As Boolean
        Dim bl As Boolean = False
        Dim strRegex As String

        strRegex = "^TRAIL "
        strRegex += "[0-9]{8}"
        strRegex += "[A-Za-z0-9 ]{1184}"

        Dim reg_exp As New Regex(strRegex)
        bl = reg_exp.IsMatch(str)

        If bl And str.Length = AS400_RECORD_SIZE - 2 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub StringToHeaderDetail(ByVal str As String)
        Dim bl As Boolean = False
        bl = Me.CheckHeader(str)
        If bl Then
            Me.ExtractHeader(str)
        End If
    End Sub

    Public Sub StringToTrailDetail(ByVal str As String)
        Dim bl As Boolean = False
        bl = Me.CheckTrail(str)
        If bl Then
            Me.ExtractTrail(str)
        End If
    End Sub

    Public Sub StringToProductionDat(ByRef dr As ServerDataset.T_Production_DATRow, ByVal str As String, ByVal fileName As String)
        clsLogger.Log(Logger.MessageType.NormalLog, Me.GetType.Name, "StringToProductionDat", "Start", "")
        Dim bl As Boolean = False
        Try
            bl = Me.CheckProduction(str)
            If bl Then
                dr.SeqNo = RTrim(str.Substring(0, 5))
                dr.ModelYear = RTrim(str.Substring(5, 3))
                dr.SuffixCode = RTrim(str.Substring(8, 5))
                dr.LotID = RTrim(str.Substring(13, 3))
                dr.LotNo = RTrim(str.Substring(16, 3))
                dr.Unit = RTrim(str.Substring(19, 3))
                dr.BlockModel = RTrim(str.Substring(22, 8))
                dr.BlockSeq = RTrim(str.Substring(30, 3))
                dr.MARK = RTrim(str.Substring(33, 3))
                dr.ProductionDate = RTrim(str.Substring(36, 8))
                dr.ProductionTime = RTrim(str.Substring(44, 4))
                dr.ImportCode = RTrim(str.Substring(48, 10))
                dr.YChassisFlag = RTrim(str.Substring(58, 1))
                dr.GAShop = RTrim(str.Substring(59, 2))
                dr.HanmmerYears = RTrim(str.Substring(61, 2))
                dr.Reserve01 = RTrim(str.Substring(63, 37))
                dr.MODEL01ASM01 = RTrim(str.Substring(100, 10))
                dr.MODEL01ASM02 = RTrim(str.Substring(110, 10))
                dr.MODEL01ASM03 = RTrim(str.Substring(120, 10))
                dr.MODEL01ASM04 = RTrim(str.Substring(130, 10))
                dr.MODEL01ASM05 = RTrim(str.Substring(140, 10))
                dr.MODEL02ASM01 = RTrim(str.Substring(150, 10))
                dr.MODEL02ASM02 = RTrim(str.Substring(160, 10))
                dr.MODEL02ASM03 = RTrim(str.Substring(170, 10))
                dr.MODEL02ASM04 = RTrim(str.Substring(180, 10))
                dr.MODEL02ASM05 = RTrim(str.Substring(190, 10))
                dr.MODEL03ASM01 = RTrim(str.Substring(200, 10))
                dr.MODEL03ASM02 = RTrim(str.Substring(210, 10))
                dr.MODEL03ASM03 = RTrim(str.Substring(220, 10))
                dr.MODEL03ASM04 = RTrim(str.Substring(230, 10))
                dr.MODEL03ASM05 = RTrim(str.Substring(240, 10))
                dr.MODEL04ASM01 = RTrim(str.Substring(250, 10))
                dr.MODEL04ASM02 = RTrim(str.Substring(260, 10))
                dr.MODEL04ASM03 = RTrim(str.Substring(270, 10))
                dr.MODEL04ASM04 = RTrim(str.Substring(280, 10))
                dr.MODEL04ASM05 = RTrim(str.Substring(290, 10))
                dr.MODEL05ASM01 = RTrim(str.Substring(300, 10))
                dr.MODEL05ASM02 = RTrim(str.Substring(310, 10))
                dr.MODEL05ASM03 = RTrim(str.Substring(320, 10))
                dr.MODEL05ASM04 = RTrim(str.Substring(330, 10))
                dr.MODEL05ASM05 = RTrim(str.Substring(340, 10))
                dr.MODEL06ASM01 = RTrim(str.Substring(350, 10))
                dr.MODEL06ASM02 = RTrim(str.Substring(360, 10))
                dr.MODEL06ASM03 = RTrim(str.Substring(370, 10))
                dr.MODEL06ASM04 = RTrim(str.Substring(380, 10))
                dr.MODEL06ASM05 = RTrim(str.Substring(390, 10))
                dr.MODEL07ASM01 = RTrim(str.Substring(400, 10))
                dr.MODEL07ASM02 = RTrim(str.Substring(410, 10))
                dr.MODEL07ASM03 = RTrim(str.Substring(420, 10))
                dr.MODEL07ASM04 = RTrim(str.Substring(430, 10))
                dr.MODEL07ASM05 = RTrim(str.Substring(440, 10))
                dr.MODEL08ASM01 = RTrim(str.Substring(450, 10))
                dr.MODEL08ASM02 = RTrim(str.Substring(460, 10))
                dr.MODEL08ASM03 = RTrim(str.Substring(470, 10))
                dr.MODEL08ASM04 = RTrim(str.Substring(480, 10))
                dr.MODEL08ASM05 = RTrim(str.Substring(490, 10))
                dr.MODEL09ASM01 = RTrim(str.Substring(500, 10))
                dr.MODEL09ASM02 = RTrim(str.Substring(510, 10))
                dr.MODEL09ASM03 = RTrim(str.Substring(520, 10))
                dr.MODEL09ASM04 = RTrim(str.Substring(530, 10))
                dr.MODEL09ASM05 = RTrim(str.Substring(540, 10))
                dr.MODEL10ASM01 = RTrim(str.Substring(550, 10))
                dr.MODEL10ASM02 = RTrim(str.Substring(560, 10))
                dr.MODEL10ASM03 = RTrim(str.Substring(570, 10))
                dr.MODEL10ASM04 = RTrim(str.Substring(580, 10))
                dr.MODEL10ASM05 = RTrim(str.Substring(590, 10))
                dr.MODEL11ASM01 = RTrim(str.Substring(600, 10))
                dr.MODEL11ASM02 = RTrim(str.Substring(610, 10))
                dr.MODEL11ASM03 = RTrim(str.Substring(620, 10))
                dr.MODEL11ASM04 = RTrim(str.Substring(630, 10))
                dr.MODEL11ASM05 = RTrim(str.Substring(640, 10))
                dr.MODEL12ASM01 = RTrim(str.Substring(650, 10))
                dr.MODEL12ASM02 = RTrim(str.Substring(660, 10))
                dr.MODEL12ASM03 = RTrim(str.Substring(670, 10))
                dr.MODEL12ASM04 = RTrim(str.Substring(680, 10))
                dr.MODEL12ASM05 = RTrim(str.Substring(690, 10))
                dr.MODEL13ASM01 = RTrim(str.Substring(700, 10))
                dr.MODEL13ASM02 = RTrim(str.Substring(710, 10))
                dr.MODEL13ASM03 = RTrim(str.Substring(720, 10))
                dr.MODEL13ASM04 = RTrim(str.Substring(730, 10))
                dr.MODEL13ASM05 = RTrim(str.Substring(740, 10))
                dr.MODEL14ASM01 = RTrim(str.Substring(750, 10))
                dr.MODEL14ASM02 = RTrim(str.Substring(760, 10))
                dr.MODEL14ASM03 = RTrim(str.Substring(770, 10))
                dr.MODEL14ASM04 = RTrim(str.Substring(780, 10))
                dr.MODEL14ASM05 = RTrim(str.Substring(790, 10))
                dr.MODEL15ASM01 = RTrim(str.Substring(800, 10))
                dr.MODEL15ASM02 = RTrim(str.Substring(810, 10))
                dr.MODEL15ASM03 = RTrim(str.Substring(820, 10))
                dr.MODEL15ASM04 = RTrim(str.Substring(830, 10))
                dr.MODEL15ASM05 = RTrim(str.Substring(840, 10))
                dr.MODEL16ASM01 = RTrim(str.Substring(850, 10))
                dr.MODEL16ASM02 = RTrim(str.Substring(860, 10))
                dr.MODEL16ASM03 = RTrim(str.Substring(870, 10))
                dr.MODEL16ASM04 = RTrim(str.Substring(880, 10))
                dr.MODEL16ASM05 = RTrim(str.Substring(890, 10))
                dr.MODEL17ASM01 = RTrim(str.Substring(900, 10))
                dr.MODEL17ASM02 = RTrim(str.Substring(910, 10))
                dr.MODEL17ASM03 = RTrim(str.Substring(920, 10))
                dr.MODEL17ASM04 = RTrim(str.Substring(930, 10))
                dr.MODEL17ASM05 = RTrim(str.Substring(940, 10))
                dr.MODEL18ASM01 = RTrim(str.Substring(950, 10))
                dr.MODEL18ASM02 = RTrim(str.Substring(960, 10))
                dr.MODEL18ASM03 = RTrim(str.Substring(970, 10))
                dr.MODEL18ASM04 = RTrim(str.Substring(980, 10))
                dr.MODEL18ASM05 = RTrim(str.Substring(990, 10))
                dr.MODEL19ASM01 = RTrim(str.Substring(1000, 10))
                dr.MODEL19ASM02 = RTrim(str.Substring(1010, 10))
                dr.MODEL19ASM03 = RTrim(str.Substring(1020, 10))
                dr.MODEL19ASM04 = RTrim(str.Substring(1030, 10))
                dr.MODEL19ASM05 = RTrim(str.Substring(1040, 10))
                dr.MODEL20ASM01 = RTrim(str.Substring(1050, 10))
                dr.MODEL20ASM02 = RTrim(str.Substring(1060, 10))
                dr.MODEL20ASM03 = RTrim(str.Substring(1070, 10))
                dr.MODEL20ASM04 = RTrim(str.Substring(1080, 10))
                dr.MODEL20ASM05 = RTrim(str.Substring(1090, 10))
                dr.Reserve02 = RTrim(str.Substring(1100, 100))

                dr.SubSeq = Nothing
                dr.XchgFlag = Nothing
                dr.InstructFlag = Nothing
                If fileName.Length < 256 Then
                    dr.FileName = fileName
                Else
                    dr.FileName = fileName.Substring(0, 255)
                End If

            End If
        Catch ex As Exception
            clsLogger.Log(Logger.MessageType.NormalLog, Me.GetType.Name, "StringToProductionDat", ex.Message, ex.StackTrace)
        End Try
        clsLogger.Log(Logger.MessageType.NormalLog, Me.GetType.Name, "StringToProductionDat", "End", "")
    End Sub

    Public Function CheckAs400File(ByRef theFile As FileStream, _
                                             ByVal strFileNameWithPath As String, _
                                             ByVal strFileName As String) As Boolean
        clsLogger.Log(Logger.MessageType.NormalLog, Me.GetType.Name, "CheckAs400File", "Start", "")
        Dim fileDetail As IO.FileInfo
        Try
            fileDetail = My.Computer.FileSystem.GetFileInfo(strFileNameWithPath)
            Dim intReadPosition As Integer = 0
            Dim intByteCount As Integer
            Dim sReader As New StreamReader(theFile)
            Dim taT_Production_DAT As ServerDatasetTableAdapters.T_Production_DATTableAdapter = modDataSource.ta(Of PIS_SERVER.ServerDatasetTableAdapters.T_Production_DATTableAdapter).GetTableAdapter()

            'Dim arrByte As Byte() = New Byte(AS400_RECORD_SIZE - 1) {}
            Dim arrByte(AS400_RECORD_SIZE - 1) As Byte

            'If CInt(fileDetail.Length / AS400_RECORD_SIZE) <= 0 Then
            If fileDetail.Length = 0 Then
                clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_AS400, TLogDat.LogLevel.NormalLog, My.Computer.Name, Now, "No new AS400 File.", Nothing)
                clsLogger.Log(Logger.MessageType.NormalLog, Me.GetType.Name, "CheckAs400File", "Success", "")
                dtTemp = Nothing
                m_arrRow = Nothing
                Return False
            ElseIf (fileDetail.Length / AS400_RECORD_SIZE) < 1 Then

                clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_AS400, TLogDat.LogLevel.ErrorLog, My.Computer.Name, Now, "Invalid AS400 file: " & strFileName & " , Rejected this file.", Nothing)
                clsLogger.Log(Logger.MessageType.ErrorLog, Me.GetType.Name, "CheckAs400File", "Invalid AS400 file: " & strFileName & " , Rejected this file.", "")
                Return False
            Else

                Dim strTempData As String
                Dim intRecordStatus As Integer = WAIT_FOR_HEADER
                Dim intStartIndex As Integer = 0
                Dim intEndIndex As Integer = 0

                Dim intRecordType As Integer
                Dim index As Integer = 0
                Dim intHeaderTrailSet As Integer = 0

                Dim tmpDtProd As New ServerDataset.T_Production_DATDataTable


                While (intReadPosition < fileDetail.Length And index < 100000)
                    If index = 0 Then
                        intByteCount = theFile.Read(arrByte, 0, AS400_RECORD_SIZE)
                        intReadPosition += intByteCount
                        If intByteCount = AS400_RECORD_SIZE Then
                            strTempData = System.Text.Encoding.ASCII.GetString(arrByte)
                            intRecordType = CheckRecordType(strTempData)
                            If intRecordType <> clsAs400File.RECORD_TYPE_HEADER Then
                                intReadPosition = fileDetail.Length
                                dtTemp = Nothing
                                m_arrRow = Nothing
                                'Log invalid file header
                                clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_AS400, TLogDat.LogLevel.ErrorLog, My.Computer.Name, Now, "Invalid file header in " & strFileName & " , Rejected this file.", Nothing)
                                clsLogger.Log(Logger.MessageType.ErrorLog, Me.GetType.Name, "CheckAs400File", "Invalid file header in " & strFileName & " , Rejected this file.", "")
                                Return False
                            Else
                                '^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ OK is Header
                                intRecordStatus = WAIT_FOR_TRAIL
                                intStartIndex = index
                                ExtractHeader(strTempData)
                            End If
                        Else
                            intReadPosition = fileDetail.Length
                            clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_AS400, TLogDat.LogLevel.ErrorLog, My.Computer.Name, Now, "Invalid data file: " & strFileName & " , Rejected this file.", Nothing)
                            clsLogger.Log(Logger.MessageType.ErrorLog, Me.GetType.Name, "CheckAs400File", "Invalid data file: " & strFileName & " , Rejected this file.", "")
                            dtTemp = Nothing
                            m_arrRow = Nothing
                            Return False
                        End If

                    Else
                        intByteCount = theFile.Read(arrByte, 0, AS400_RECORD_SIZE)
                        intReadPosition += intByteCount

                        If intByteCount = AS400_RECORD_SIZE Then
                            strTempData = System.Text.Encoding.ASCII.GetString(arrByte)
                            intRecordType = CheckRecordType(strTempData)
                            If intRecordStatus = WAIT_FOR_HEADER Then
                                If intRecordType = clsAs400File.RECORD_TYPE_HEADER Then
                                    '^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ OK is Header
                                    intRecordStatus = WAIT_FOR_TRAIL
                                    intStartIndex = index
                                    ExtractHeader(strTempData)
                                Else
                                    intReadPosition = fileDetail.Length
                                    clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_AS400, TLogDat.LogLevel.ErrorLog, My.Computer.Name, Now, "Header record missing in " & strFileName & " , Rejected this file.", Nothing)
                                    clsLogger.Log(Logger.MessageType.ErrorLog, Me.GetType.Name, "CheckAs400File", "Header Record Missing in " & strFileName & " , Rejected this file.", "")
                                    dtTemp = Nothing
                                    m_arrRow = Nothing
                                    Return False
                                End If
                            ElseIf intRecordStatus = WAIT_FOR_TRAIL Then
                                If intRecordType = clsAs400File.RECORD_TYPE_PRODUCTION Then
                                    '^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ OK is Data
                                    'Read production data
                                    intRecordStatus = WAIT_FOR_TRAIL
                                    Dim dr As ServerDataset.T_Production_DATRow = dtTemp.NewT_Production_DATRow
                                    StringToProductionDat(dr, strTempData, strFileName)

                                    'check primary key and secondary key
                                    '...............................

                                    Dim tmpDrPk As ServerDataset.T_Production_DATRow
                                    Dim tmpDrSk() As ServerDataset.T_Production_DATRow

                                    tmpDrPk = tmpDtProd.FindByModelYearSuffixCodeLotNoUnit(dr.ModelYear, dr.SuffixCode, dr.LotNo, dr.Unit)

                                    If IsNothing(tmpDrPk) Then 'Not Duplicate primary key

                                        tmpDrSk = tmpDtProd.Select("productionDate = " & dr.ProductionDate.ToString _
                                                            & " And ProductionTime = " & dr.ProductionTime.ToString _
                                                            & " And SeqNo = " & dr.SeqNo.ToString)
                                        '& " And subSeq = " & dr.SubSeq.ToString)

                                        If tmpDrSk.Count = 0 Then

                                            'keep data for check primary key and secondary key
                                            Dim drNewRow As ServerDataset.T_Production_DATRow = tmpDtProd.NewT_Production_DATRow
                                            For j As Integer = 0 To drNewRow.ItemArray.Length - 1
                                                drNewRow.Item(j) = dr.Item(j)
                                            Next
                                            tmpDtProd.AddT_Production_DATRow(drNewRow)

                                            'keep the minimal of productiondate, productiontime, seqNo
                                            If IsNothing(m_minimalSk) Then
                                                m_minimalSk = dr.ProductionDate & dr.ProductionTime & dr.SeqNo
                                            End If
                                            If (dr.ProductionDate & dr.ProductionTime & dr.SeqNo) < m_minimalSk Then
                                                m_minimalSk = dr.ProductionDate & dr.ProductionTime & dr.SeqNo
                                            End If

                                            'add data prepare for import
                                            'm_arrRow.Add(dr)

                                        Else
                                            intReadPosition = fileDetail.Length
                                            dtTemp = Nothing
                                            m_arrRow = Nothing
                                            clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_AS400, TLogDat.LogLevel.ErrorLog, My.Computer.Name, Now, "Duplicate secondary key in " & strFileName & " , " & Format(m_dtAs400Date, "yyyyMMddHHmmss") & " , Rejected this file.", Nothing)
                                            clsLogger.Log(Logger.MessageType.ErrorLog, Me.GetType.Name, "CheckAs400File", "Duplicate secondary key in " & strFileName & " , " & Format(m_dtAs400Date, "yyyyMMddHHmmss") & " , Rejected this file.", "")
                                            Return False
                                        End If

                                    Else
                                        intReadPosition = fileDetail.Length
                                        dtTemp = Nothing
                                        m_arrRow = Nothing
                                        clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_AS400, TLogDat.LogLevel.ErrorLog, My.Computer.Name, Now, "Duplicate primary key in " & strFileName & " , " & Format(m_dtAs400Date, "yyyyMMddHHmmss") & " , Rejected this file.", Nothing)
                                        clsLogger.Log(Logger.MessageType.ErrorLog, Me.GetType.Name, "CheckAs400File", "Duplicate primary key in " & strFileName & " , " & Format(m_dtAs400Date, "yyyyMMddHHmmss") & " , Rejected this file.", "")
                                        Return False
                                    End If


                                ElseIf intRecordType = clsAs400File.RECORD_TYPE_TRAIL Then
                                    'Found correct trail
                                    intRecordStatus = WAIT_FOR_HEADER
                                    intEndIndex = index
                                    ExtractTrail(strTempData)
                                    If intEndIndex - intStartIndex - 1 = DataNumber Then
                                        ''Number of records in this session is correct
                                        DataNumber = 0
                                        'clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_AS400, Nothing, Now, _
                                        '                        (intEndIndex - intStartIndex - 1).ToString & " Records Imported", Nothing)
                                    Else
                                        'Record Number Incorrect
                                        intReadPosition = fileDetail.Length
                                        dtTemp = Nothing
                                        m_arrRow = Nothing
                                        clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_AS400, TLogDat.LogLevel.ErrorLog, My.Computer.Name, Now, "Number of record not match created at " & Format(m_dtAs400Date, "yyyyMMddHHmmss") & " in " & strFileName & " , Rejected this file.", Nothing)
                                        clsLogger.Log(Logger.MessageType.ErrorLog, Me.GetType.Name, "CheckAs400File", "Number of record not match created at " & Format(m_dtAs400Date, "yyyyMMddHHmmss") & " in " & strFileName & " , Rejected this file.", "")
                                        Return False
                                    End If
                                ElseIf intRecordType = clsAs400File.RECORD_TYPE_HEADER Then
                                    'Waiting for trail but got the header
                                    intReadPosition = fileDetail.Length
                                    dtTemp = Nothing
                                    m_arrRow = Nothing
                                    clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_AS400, TLogDat.LogLevel.ErrorLog, My.Computer.Name, Now, "Trail Record Missing in " & strFileName & " , Rejected this file.", Nothing)
                                    clsLogger.Log(Logger.MessageType.ErrorLog, Me.GetType.Name, "CheckAs400File", "Trail Record Missing in " & strFileName & " , Rejected this file.", "")
                                    Return False
                                Else
                                    'Unknown format received
                                    intReadPosition = fileDetail.Length
                                    dtTemp = Nothing
                                    m_arrRow = Nothing
                                    clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_AS400, TLogDat.LogLevel.ErrorLog, My.Computer.Name, Now, "Record: " & index & " is in invalid format, File: " & strFileName & " , Rejected this file.", Nothing)
                                    clsLogger.Log(Logger.MessageType.ErrorLog, Me.GetType.Name, "CheckAs400File", "Record: " & index & " is in invalid format, File: " & strFileName & " , Rejected this file.", "")
                                    Return False
                                End If

                            Else
                                intReadPosition = fileDetail.Length
                                dtTemp = Nothing
                                m_arrRow = Nothing
                                clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_AS400, TLogDat.LogLevel.ErrorLog, My.Computer.Name, Now, "Invalid record status in " & strFileName & " , Rejected this file.", Nothing)
                                clsLogger.Log(Logger.MessageType.ErrorLog, Me.GetType.Name, "CheckAs400File", "Invalid record status in " & strFileName & " , Rejected this file.", "")
                                Return False
                            End If

                        Else 'intByteCount <> AS400_RECORD_SIZE

                            If intRecordStatus = WAIT_FOR_HEADER Then
                                'Check Last Row "->"
                                If fileDetail.Length - intReadPosition > 0 Then
                                    Dim blEof As Boolean = False
                                    For Each bt As Byte In arrByte
                                        If bt = CByte(26) Then
                                            blEof = True
                                        End If
                                    Next
                                    If Not blEof Then
                                        dtTemp = Nothing
                                        m_arrRow = Nothing
                                        clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_AS400, TLogDat.LogLevel.ErrorLog, My.Computer.Name, Now, "Invalid record length in " & strFileName & " , Rejected this file.", Nothing)
                                        clsLogger.Log(Logger.MessageType.ErrorLog, Me.GetType.Name, "CheckAs400File", "Invalid record length in " & strFileName & " , Rejected this file.", "")
                                        Return False
                                    End If
                                    intReadPosition = fileDetail.Length
                                ElseIf fileDetail.Length - intReadPosition < 0 Then
                                    intReadPosition = fileDetail.Length
                                    dtTemp = Nothing
                                    m_arrRow = Nothing
                                    clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_AS400, TLogDat.LogLevel.ErrorLog, My.Computer.Name, Now, "Invalid read position in " & strFileName & " , Rejected this file.", Nothing)
                                    clsLogger.Log(Logger.MessageType.ErrorLog, Me.GetType.Name, "CheckAs400File", "Invalid read position in " & strFileName & " , Rejected this file.", "")
                                    Return False
                                End If
                            Else
                                intReadPosition = fileDetail.Length
                                dtTemp = Nothing
                                m_arrRow = Nothing
                                clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_AS400, TLogDat.LogLevel.ErrorLog, My.Computer.Name, Now, "Invalid record length in " & strFileName & " , Rejected this file.", Nothing)
                                clsLogger.Log(Logger.MessageType.ErrorLog, Me.GetType.Name, "CheckAs400File", "Invalid record length in " & strFileName & " , Rejected this file.", "")
                                Return False
                            End If
                        End If
                    End If
                    index += 1
                End While

                '*** check less than current record
                Dim drCheckDate As ServerDataset.T_Production_DATRow = Nothing
                Dim dtCheckDate As New ServerDataset.T_Production_DATDataTable
                'get current record
                dtCheckDate = taT_Production_DAT.GetDataByFirstInstructFlagLessThan2
                If dtCheckDate.Count > 0 Then
                    drCheckDate = dtCheckDate.Rows(0)
                End If
                If DateTimeSeqLessThanCurrentDatarow(m_minimalSk, drCheckDate) Then
                    'Cannot import record due to too old date and seq
                    clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_AS400, TLogDat.LogLevel.WarningLog, My.Computer.Name, _
                                            Now, "Production date time and SeqNo: " & m_minimalSk & _
                                            " is less than current record, Rejected this file.", Nothing)

                    clsLogger.Log(Logger.MessageType.WarningLog, Me.GetType.Name, "CheckAs400File", _
                                            "Production date time and SeqNo: " & m_minimalSk & _
                                            " is less than current record, Rejected this file.", "")
                    Return False
                End If

                'theFile.Close()
                clsLogger.Log(Logger.MessageType.NormalLog, Me.GetType.Name, "CheckAs400File", "Success", "")
                Return True

            End If
        Catch ex As Exception
            clsLogger.Log(Logger.MessageType.ErrorLog, Me.GetType.Name, "CheckAs400File", ex.Message, ex.StackTrace)
            Return False
        End Try
    End Function

    Public Function ExtractAs400File(ByRef theFile As FileStream, _
                                             ByVal strFileNameWithPath As String, _
                                             ByVal strFileName As String) As Boolean
        clsLogger.Log(Logger.MessageType.NormalLog, Me.GetType.Name, "ExtractAs400File", "Start", "")
        Dim fileDetail As IO.FileInfo
        'Dim datLastProductionDate As New DateTime
        'datLastProductionDate = DateTime.MinValue
        'Dim strLastProductionTime As String = "0000"
        Dim strDateFormat As String = "yyyyMMdd"

        Try

            Try
                'Delete orphaned T_Production_DAT
                Dim taProd As ServerDatasetTableAdapters.T_Production_DATTableAdapter = modDataSource.ta(Of PIS_SERVER.ServerDatasetTableAdapters.T_Production_DATTableAdapter).GetTableAdapter()
                Dim intResult As Integer = taProd.DeleteOrphanedProduction()
                If intResult > 0 Then
                    clsLogger.Log(Logger.MessageType.ErrorLog, Me.GetType.Name, "ExtractAs400File", "Orphaned Production Deleted", "")
                End If
            Catch ex As Exception
                clsLogger.Log(Logger.MessageType.ErrorLog, Me.GetType.Name, "ExtractAs400File", "Delete Orphaned Production Failed", "")
                clsLogger.Log(Logger.MessageType.ErrorLog, Me.GetType.Name, "ExtractAs400File", ex.Message, ex.StackTrace)
            End Try

            Try
                'Delete orphaned T_Instruction_DAT
                Dim taIns As ServerDatasetTableAdapters.T_Instruction_DATTableAdapter = modDataSource.ta(Of PIS_SERVER.ServerDatasetTableAdapters.T_Instruction_DATTableAdapter).GetTableAdapter()
                Dim intResult As Integer = taIns.DeleteOrphanedInstruction()
                If intResult > 0 Then
                    clsLogger.Log(Logger.MessageType.ErrorLog, Me.GetType.Name, "ExtractAs400File", "Orphaned Instruction Deleted", "")
                End If
            Catch ex As Exception
                clsLogger.Log(Logger.MessageType.ErrorLog, Me.GetType.Name, "ExtractAs400File", "Delete Orphaned Instruction Failed", "")
                clsLogger.Log(Logger.MessageType.ErrorLog, Me.GetType.Name, "ExtractAs400File", ex.Message, ex.StackTrace)
            End Try

            Using ts As New TransactionScope
                fileDetail = My.Computer.FileSystem.GetFileInfo(strFileNameWithPath)
                Dim intReadPosition As Integer = 0
                Dim intByteCount As Integer
                Dim sReader As New StreamReader(theFile)
                Dim taT_Production_DAT As ServerDatasetTableAdapters.T_Production_DATTableAdapter = modDataSource.ta(Of PIS_SERVER.ServerDatasetTableAdapters.T_Production_DATTableAdapter).GetTableAdapter()
                Dim importCountList As New ArrayList

                Dim arrByte(AS400_RECORD_SIZE - 1) As Byte

                If fileDetail.Length = 0 Then
                    clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_AS400, TLogDat.LogLevel.NormalLog, My.Computer.Name, Now, "No new AS400 File.", Nothing)
                    clsLogger.Log(Logger.MessageType.NormalLog, Me.GetType.Name, "ExtractAs400File", "Success", "")
                    dtTemp = Nothing
                    m_arrRow = Nothing
                    ts.Complete()
                    Return True
                    'Return False
                ElseIf (fileDetail.Length / AS400_RECORD_SIZE) < 1 Then

                    clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_AS400, TLogDat.LogLevel.ErrorLog, My.Computer.Name, Now, "Invalid AS400 file: " & strFileName & " , Rejected this file.", Nothing)
                    clsLogger.Log(Logger.MessageType.ErrorLog, Me.GetType.Name, "ExtractAs400File", "Invalid AS400 file: " & strFileName & " , Rejected this file.", "")
                    ts.Complete()
                    Return True
                    'Return False
                Else

                    Dim strTempData As String
                    Dim intRecordStatus As Integer = WAIT_FOR_HEADER
                    Dim intStartIndex As Integer = 0
                    Dim intEndIndex As Integer = 0

                    Dim intRecordType As Integer
                    Dim index As Integer = 0
                    Dim intHeaderTrailSet As Integer = 0

                    'Dim tmpDtProd As New ServerDataset.T_Production_DATDataTable

                    'Fill Old Data
                    taT_Production_DAT.FillAllPkSk(dtOldData)
                    clsLogger.Log(Logger.MessageType.NormalLog, Me.GetType.Name, "ExtractAs400File", "Fill old data end", "")
                    'Get Line Master
                    taT_Line_MST.Fill(dtLineAll)
                    clsLogger.Log(Logger.MessageType.NormalLog, Me.GetType.Name, "ExtractAs400File", "Get Line_MST success", "")
                    taT_Line_MST.FillByLineType(dtLineCab, 1)
                    clsLogger.Log(Logger.MessageType.NormalLog, Me.GetType.Name, "ExtractAs400File", "Get CAB line success", "")
                    taT_Line_MST.FillByLineType(dtLinePubx, 2)
                    clsLogger.Log(Logger.MessageType.NormalLog, Me.GetType.Name, "ExtractAs400File", "Get PUBX line success", "")

                    While (intReadPosition < fileDetail.Length And index < 100000)
                        If index = 0 Then
                            intByteCount = theFile.Read(arrByte, 0, AS400_RECORD_SIZE)
                            intReadPosition += intByteCount
                            If intByteCount = AS400_RECORD_SIZE Then
                                strTempData = System.Text.Encoding.ASCII.GetString(arrByte)
                                intRecordType = CheckRecordType(strTempData)
                                If intRecordType <> clsAs400File.RECORD_TYPE_HEADER Then
                                    intReadPosition = fileDetail.Length
                                    dtTemp = Nothing
                                    m_arrRow = Nothing
                                    'Log invalid file header
                                    clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_AS400, TLogDat.LogLevel.ErrorLog, My.Computer.Name, Now, "Invalid file header in " & strFileName & " , Rejected this file.", Nothing)
                                    clsLogger.Log(Logger.MessageType.ErrorLog, Me.GetType.Name, "ExtractAs400File", "Invalid file header in " & strFileName & " , Rejected this file.", "")
                                    ts.Complete()
                                    Return True
                                    'Return False
                                Else
                                    '^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ OK is Header
                                    intRecordStatus = WAIT_FOR_TRAIL
                                    intStartIndex = index
                                    ExtractHeader(strTempData)
                                End If
                            Else
                                intReadPosition = fileDetail.Length
                                clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_AS400, TLogDat.LogLevel.ErrorLog, My.Computer.Name, Now, "Invalid data file: " & strFileName & " , Rejected this file.", Nothing)
                                clsLogger.Log(Logger.MessageType.ErrorLog, Me.GetType.Name, "ExtractAs400File", "Invalid data file: " & strFileName & " , Rejected this file.", "")
                                dtTemp = Nothing
                                m_arrRow = Nothing
                                ts.Complete()
                                Return True
                                'Return False
                            End If

                        Else 'index <> 0
                            intByteCount = theFile.Read(arrByte, 0, AS400_RECORD_SIZE)
                            intReadPosition += intByteCount

                            If intByteCount = AS400_RECORD_SIZE Then
                                strTempData = System.Text.Encoding.ASCII.GetString(arrByte)
                                intRecordType = CheckRecordType(strTempData)
                                If intRecordStatus = WAIT_FOR_HEADER Then
                                    If intRecordType = clsAs400File.RECORD_TYPE_HEADER Then
                                        '^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ OK is Header
                                        intRecordStatus = WAIT_FOR_TRAIL
                                        index = 0
                                        intStartIndex = index
                                        ExtractHeader(strTempData)

                                        m_arrRow.Clear()
                                    Else
                                        intReadPosition = fileDetail.Length
                                        clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_AS400, TLogDat.LogLevel.ErrorLog, My.Computer.Name, Now, "Header record missing in " & strFileName & " , Rejected this file.", Nothing)
                                        clsLogger.Log(Logger.MessageType.ErrorLog, Me.GetType.Name, "ExtractAs400File", "Header Record Missing in " & strFileName & " , Rejected this file.", "")
                                        dtTemp = Nothing
                                        m_arrRow = Nothing
                                        ts.Complete()
                                        Return True
                                        'Return False
                                    End If
                                ElseIf intRecordStatus = WAIT_FOR_TRAIL Then

                                    If intRecordType = clsAs400File.RECORD_TYPE_PRODUCTION Then
                                        '^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ OK is Data
                                        'Read production data
                                        intRecordStatus = WAIT_FOR_TRAIL
                                        Dim dr As ServerDataset.T_Production_DATRow = dtTemp.NewT_Production_DATRow
                                        StringToProductionDat(dr, strTempData, strFileName)

                                        'If index = 1 Then
                                        '    m_prodDateTime = dr.ProductionDate & dr.ProductionTime
                                        'End If


                                        'If DateTime.ParseExact(dr.ProductionDate, strDateFormat, Nothing) > datLastProductionDate Then
                                        '    datLastProductionDate = DateTime.ParseExact(dr.ProductionDate, strDateFormat, Nothing)
                                        'End If

                                        'If dr.ProductionTime < strLastProductionTime Then
                                        '    datLastProductionDate = DateTime.ParseExact(dr.ProductionDate, strDateFormat, Nothing)
                                        '    datLastProductionDate = datLastProductionDate.AddDays(1)
                                        'End If

                                        'strLastProductionTime = dr.ProductionTime
                                        'dr.ProductionDate = datLastProductionDate.ToString(strDateFormat)

                                        If dr.ProductionTime < PRODUCTION_TIME_DAY_SHIFT_START Then
                                            Dim datTmp As DateTime = DateTime.ParseExact(dr.ProductionDate, strDateFormat, Nothing)
                                            datTmp = datTmp.AddDays(1)
                                            dr.ProductionDate = datTmp.ToString(strDateFormat)
                                        End If

                                        m_arrRow.Add(dr)


                                    ElseIf intRecordType = clsAs400File.RECORD_TYPE_TRAIL Then
                                        'Found correct trail
                                        intRecordStatus = WAIT_FOR_HEADER
                                        intEndIndex = index
                                        ExtractTrail(strTempData)
                                        If intEndIndex - intStartIndex - 1 = DataNumber Then
                                            ''Number of records in this session is correct
                                            DataNumber = 0

                                            'Import to DB
                                            Try
                                                CheckDataDetailAndImport(strFileName)
                                            Catch ex As Exception
                                                'clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_AS400, TLogDat.LogLevel.ErrorLog, My.Computer.Name, Now, ex.Message, Nothing)
                                                Throw ex
                                            End Try

                                            'count and keep No. of record import
                                            Dim countDetail(5) As Object
                                            countDetail(0) = m_prodDateTime 'first of group productionDate+Time
                                            countDetail(1) = m_intInsertCount + m_intUpdateCount + m_intSkipCount 'Total
                                            countDetail(2) = m_intInsertCount 'inserted record
                                            countDetail(3) = m_intUpdateCount 'updateed record
                                            countDetail(4) = m_intSkipCount ' skipped record

                                            importCountList.Add(countDetail)

                                        Else
                                            'Record Number Incorrect
                                            intReadPosition = fileDetail.Length
                                            dtTemp = Nothing
                                            m_arrRow = Nothing
                                            clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_AS400, TLogDat.LogLevel.ErrorLog, My.Computer.Name, Now, "Number of record not match created at " & Format(m_dtAs400Date, "yyyyMMddHHmmss") & " in " & strFileName & " , Rejected this file.", Nothing)
                                            clsLogger.Log(Logger.MessageType.ErrorLog, Me.GetType.Name, "ExtractAs400File", "Number of record not match created at " & Format(m_dtAs400Date, "yyyyMMddHHmmss") & " in " & strFileName & " , Rejected this file.", "")
                                            ts.Complete()
                                            Return True
                                            'Return False
                                        End If
                                    ElseIf intRecordType = clsAs400File.RECORD_TYPE_HEADER Then
                                        'Waiting for trail but got the header
                                        intReadPosition = fileDetail.Length
                                        dtTemp = Nothing
                                        m_arrRow = Nothing
                                        clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_AS400, TLogDat.LogLevel.ErrorLog, My.Computer.Name, Now, "Trail Record Missing in " & strFileName & " , Rejected this file.", Nothing)
                                        clsLogger.Log(Logger.MessageType.ErrorLog, Me.GetType.Name, "ExtractAs400File", "Trail Record Missing in " & strFileName & " , Rejected this file.", "")
                                        ts.Complete()
                                        Return True
                                        'Return False
                                    Else
                                        'Unknown format received
                                        intReadPosition = fileDetail.Length
                                        dtTemp = Nothing
                                        m_arrRow = Nothing
                                        clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_AS400, TLogDat.LogLevel.ErrorLog, My.Computer.Name, Now, "Record: " & index & " is in invalid format, File: " & strFileName & " , Rejected this file.", Nothing)
                                        clsLogger.Log(Logger.MessageType.ErrorLog, Me.GetType.Name, "ExtractAs400File", "Record: " & index & " is in invalid format, File: " & strFileName & " , Rejected this file.", "")
                                        ts.Complete()
                                        Return True
                                        'Return False
                                    End If

                                Else 'Invalid record status
                                    intReadPosition = fileDetail.Length
                                    dtTemp = Nothing
                                    m_arrRow = Nothing
                                    clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_AS400, TLogDat.LogLevel.ErrorLog, My.Computer.Name, Now, "Invalid record status in " & strFileName & " , Rejected this file.", Nothing)
                                    clsLogger.Log(Logger.MessageType.ErrorLog, Me.GetType.Name, "ExtractAs400File", "Invalid record status in " & strFileName & " , Rejected this file.", "")
                                    ts.Complete()
                                    Return True
                                    'Return False
                                End If

                            Else 'intByteCount <> AS400_RECORD_SIZE

                                If intRecordStatus = WAIT_FOR_HEADER Then
                                    'Check Last Row "->"
                                    If fileDetail.Length - intReadPosition > 0 Then
                                        Dim blEof As Boolean = False
                                        For Each bt As Byte In arrByte
                                            If bt = CByte(26) Then
                                                blEof = True
                                            End If
                                        Next
                                        If Not blEof Then
                                            dtTemp = Nothing
                                            m_arrRow = Nothing
                                            clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_AS400, TLogDat.LogLevel.ErrorLog, My.Computer.Name, Now, "Invalid record length in " & strFileName & " , Rejected this file.", Nothing)
                                            clsLogger.Log(Logger.MessageType.ErrorLog, Me.GetType.Name, "ExtractAs400File", "Invalid record length in " & strFileName & " , Rejected this file.", "")
                                            ts.Complete()
                                            Return True
                                            'Return False
                                        End If
                                        intReadPosition = fileDetail.Length
                                    ElseIf fileDetail.Length - intReadPosition < 0 Then
                                        intReadPosition = fileDetail.Length
                                        dtTemp = Nothing
                                        m_arrRow = Nothing
                                        clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_AS400, TLogDat.LogLevel.ErrorLog, My.Computer.Name, Now, "Invalid read position in " & strFileName & " , Rejected this file.", Nothing)
                                        clsLogger.Log(Logger.MessageType.ErrorLog, Me.GetType.Name, "ExtractAs400File", "Invalid read position in " & strFileName & " , Rejected this file.", "")
                                        ts.Complete()
                                        Return True
                                        'Return False
                                    End If
                                Else
                                    intReadPosition = fileDetail.Length
                                    dtTemp = Nothing
                                    m_arrRow = Nothing
                                    clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_AS400, TLogDat.LogLevel.ErrorLog, My.Computer.Name, Now, "Invalid record length in " & strFileName & " , Rejected this file.", Nothing)
                                    clsLogger.Log(Logger.MessageType.ErrorLog, Me.GetType.Name, "ExtractAs400File", "Invalid record length in " & strFileName & " , Rejected this file.", "")
                                    ts.Complete()
                                    Return True
                                    'Return False
                                End If
                            End If
                        End If
                        index += 1
                    End While

                    'write summary no. of record import
                    For i As Integer = 0 To importCountList.Count - 1

                        Dim countDetail(5) As Object

                        countDetail = importCountList(i)

                        clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_AS400, TLogDat.LogLevel.NormalLog, Nothing, Now, "File " & strFileName & " : Prod.Date " & countDetail(0) & " Total " & _
                                            countDetail(1) & " Records, " & countDetail(2) & " Records Inserted, " _
                                                & countDetail(3) & " Records Updated, " & countDetail(4) & " Records Skipped", Nothing)
                        clsLogger.Log(Logger.MessageType.NormalLog, Me.GetType.Name, "CheckDataDetailAndImport", "File " & strFileName & " : Prod.Date " & countDetail(0) & " Total" & _
                                                countDetail(1) & " Records, " & countDetail(2) & " Records Inserted, " _
                                                & countDetail(3) & " Records Updated, " & countDetail(4) & " Records Skipped", "")

                    Next

                    'theFile.Close()
                    ts.Complete()
                    clsLogger.Log(Logger.MessageType.NormalLog, Me.GetType.Name, "ExtractAs400File", "Success", "")
                    Return True

                End If
            End Using
        Catch ex As Exception
            clsLogger.Log(Logger.MessageType.ErrorLog, Me.GetType.Name, "ExtractAs400File", ex.Message, "")
            clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_AS400, TLogDat.LogLevel.NormalLog, Nothing, Now, "File " & strFileName & " Import Failed" , Nothing)
            Return False
        End Try
    End Function


    Public Function CheckDataDetailAndImport(ByVal fileName As String) As Boolean
        clsLogger.Log(Logger.MessageType.NormalLog, Me.GetType.Name, "CheckDataDetailAndImport", "Start", "")
        Dim intResult As Integer = 0
        Dim isCheckFormatPass As Boolean = True
        Dim taT_Instruction_DAT As ServerDatasetTableAdapters.T_Instruction_DATTableAdapter = modDataSource.ta(Of PIS_SERVER.ServerDatasetTableAdapters.T_Instruction_DATTableAdapter).GetTableAdapter()

        Dim drWithData As ServerDataset.T_Production_DATRow
        Dim drDupSk() As ServerDataset.T_Production_DATRow
        Dim strErrorMessage As String

        m_intInsertCount = 0
        m_intUpdateCount = 0
        m_intSkipCount = 0

        Dim dtNewData As New ServerDataset.T_Production_DATDataTable

        If dtTemp IsNot Nothing And m_arrRow IsNot Nothing Then
            Try
                clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_AS400, TLogDat.LogLevel.NormalLog, Nothing, Now, "Importing process ...", Nothing)
                clsLogger.Log(Logger.MessageType.NormalLog, Me.GetType.Name, "CheckDataDetailAndImport", "Importing process...", "")

                For Each dr As ServerDataset.T_Production_DATRow In m_arrRow

                    drWithData = dtOldData.FindByModelYearSuffixCodeLotNoUnit(dr.ModelYear, dr.SuffixCode, dr.LotNo, dr.Unit)

                    'dtDupSk = taT_Production_DAT.GetDataByProdDateTimeSeqNo(dr.ProductionDate, dr.ProductionTime, dr.SeqNo)

                    Dim strExpr As String = "ProductionDate = " & dr.ProductionDate & " And ProductionTime = " & dr.ProductionTime
                    strExpr += " And SeqNo = " & dr.SeqNo.ToString
                    Dim strSort As String = "ProductionDate, ProductionTime, SeqNo"
                    drDupSk = dtOldData.Select(strExpr, strSort)
                    If drWithData Is Nothing Then '*** Not dulplicate primary key

                        If drDupSk.Count = 0 Then '*** Not dulplicate primary key & Not duplicate secondary key

                            'Add new row
                            Dim drNewRow As ServerDataset.T_Production_DATRow = dtNewData.NewT_Production_DATRow
                            For j As Integer = 0 To drNewRow.ItemArray.Length - 1
                                drNewRow.Item(j) = dr.Item(j)
                            Next
                            drNewRow.XchgFlag = "0000"
                            dtNewData.Rows.Add(drNewRow)

                        Else '*** Not dulplicate primary key & Duplicate secondary key

                            'Add rows with re-order subSeq
                            Dim drNewRow As ServerDataset.T_Production_DATRow = dtNewData.NewT_Production_DATRow
                            For j As Integer = 0 To drNewRow.ItemArray.Length - 1
                                drNewRow.Item(j) = dr.Item(j)
                            Next

                            Dim maxSubSeq As Integer = taT_Production_DAT.GetMaxSubSeq(dr.SeqNo)
                            drNewRow.SubSeq = maxSubSeq + 1
                            drNewRow.XchgFlag = "0000"
                            dtNewData.Rows.Add(drNewRow)

                            clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_AS400, TLogDat.LogLevel.WarningLog, Nothing, Now, "Duplicate Production date: " & dr.ProductionDate & _
                                                    "  and ProductionTime: " & dr.ProductionTime & "  and SeqNo: " & dr.SeqNo & " , Add new record with next sub-seq", Nothing)
                            clsLogger.Log(Logger.MessageType.WarningLog, Me.GetType.Name, "CheckDataDetailAndImport", "Duplicate Production date: " & dr.ProductionDate & _
                                                    "  and ProductionTime: " & dr.ProductionTime & "  and SeqNo: " & dr.SeqNo & " , Add new record with next sub-seq", "")

                        End If

                    Else '*** Duplicate primary key

                        If drWithData.InstructFlag = 0 Or drWithData.IsInstructFlagNull Then

                            Dim bUpdateCase As Boolean = True
                            'Delete and add new record
                            taT_Instruction_DAT.DeleteAllLineByPrimaryKey(dr.ModelYear, dr.SuffixCode, dr.LotNo, dr.Unit)

                            If drDupSk.Count = 0 Then '*** Duplicate primary key & Not duplicate secondary key

                                Dim strTempXchgFlag As String = drWithData.XchgFlag
                                For j As Integer = 0 To drWithData.ItemArray.Length - 1
                                    drWithData.Item(j) = dr.Item(j)
                                Next
                                drWithData.XchgFlag = strTempXchgFlag

                            Else '*** Duplicate primary key & Duplicate secondary key

                                If drWithData.ModelYear = drDupSk(0).ModelYear And _
                                   drWithData.SuffixCode = drDupSk(0).SuffixCode And _
                                   drWithData.LotNo = drDupSk(0).LotNo And _
                                   drWithData.Unit = drDupSk(0).Unit Then
                                    '*** Duplicate in one record

                                    Dim strTempXchgFlag As String = drWithData.XchgFlag
                                    Dim strTempSubSeq As String = drWithData.SubSeq
                                    For j As Integer = 0 To drWithData.ItemArray.Length - 1
                                        drWithData.Item(j) = dr.Item(j)
                                    Next
                                    drWithData.XchgFlag = strTempXchgFlag
                                    drWithData.SubSeq = strTempSubSeq

                                Else '*** Duplicate with another record 

                                    'Delete and add new record
                                    taT_Production_DAT.DeleteByPrimaryKey(dr.ModelYear, dr.SuffixCode, dr.LotNo, dr.Unit)

                                    'Add rows with re-order subSeq
                                    Dim strTempXchgFlag As String = drWithData.XchgFlag
                                    Dim drNewRow As ServerDataset.T_Production_DATRow = dtNewData.NewT_Production_DATRow
                                    For j As Integer = 0 To drNewRow.ItemArray.Length - 1
                                        drNewRow.Item(j) = dr.Item(j)
                                    Next

                                    Dim maxSubSeq As Integer = taT_Production_DAT.GetMaxSubSeq(CInt(dr.SeqNo))
                                    drNewRow.SubSeq = maxSubSeq + 1
                                    drNewRow.XchgFlag = strTempXchgFlag
                                    dtNewData.Rows.Add(drNewRow)

                                    bUpdateCase = False
                                End If

                                'Dup Key And Dup Seq, If duplicate all in 1 record update
                                clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_AS400, TLogDat.LogLevel.WarningLog, Nothing, Now, "Duplicate Production date: " & dr.ProductionDate & _
                                                                                    "  and ProductionTime: " & dr.ProductionTime & "  and SeqNo: " & dr.SeqNo & " , Updating...", Nothing)
                                clsLogger.Log(Logger.MessageType.WarningLog, Me.GetType.Name, "CheckDataDetailAndImport", "Duplicate Production date: " & dr.ProductionDate & _
                                                                                    "  and ProductionTime: " & dr.ProductionTime & "  and SeqNo: " & dr.SeqNo & " , Updating...", "")
                            End If

                            'Update Production data
                            If bUpdateCase Then
                                Try
                                    intResult = taT_Production_DAT.Update(drWithData)

                                Catch ex As Exception
                                    isCheckFormatPass = False
                                    strErrorMessage = "Cannot update production data"
                                    'clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_AS400, TLogDat.LogLevel.ErrorLog, Nothing, Now, "Cannot update production data", Nothing)
                                    clsLogger.Log(Logger.MessageType.ErrorLog, Me.GetType.Name, "CheckDataDetailAndImport", "Cannot update production data", "")
                                    'Throw New Exception(strErrorMessage)
                                    Throw ex
                                End Try

                                Try
                                    If intResult > 0 Then

                                        'Insert Instruction data
                                        If drWithData.YChassisFlag = "" Or drWithData.YChassisFlag = "0" Then
                                            intResult = PisServer.InsertProductionRowToInstruction(drWithData, dtLineAll)
                                        ElseIf drWithData.YChassisFlag = "1" Or drWithData.YChassisFlag = "2" Then
                                            intResult = PisServer.InsertProductionRowToInstruction(drWithData, dtLineCab)
                                        ElseIf drWithData.YChassisFlag = "3" Then
                                            intResult = PisServer.InsertProductionRowToInstruction(drWithData, dtLinePubx)
                                        End If

                                        If intResult = 0 Then
                                            clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_AS400, TLogDat.LogLevel.ErrorLog, Nothing, Now, "Cannot update to T_Instruction_DAT", Nothing)
                                            clsLogger.Log(Logger.MessageType.ErrorLog, Me.GetType.Name, "CheckDataDetailAndImport", "Cannot update to T_Instruction_DAT", "")
                                        Else
                                            m_intUpdateCount += 1
                                        End If
                                    End If

                                Catch ex As Exception
                                    isCheckFormatPass = False
                                    'clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_AS400, TLogDat.LogLevel.ErrorLog, Nothing, Now, "Cannot update production data", Nothing)
                                    clsLogger.Log(Logger.MessageType.ErrorLog, Me.GetType.Name, "CheckDataDetailAndImport", "Cannot update production data", "")
                                    Throw ex
                                End Try
                            End If

                        Else 'already Instructed
                            'Cannot import record since it's already instructed
                            clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_AS400, TLogDat.LogLevel.WarningLog, Nothing, _
                                                    Now, "Cannot import Model: " & dr.ModelYear & dr.SuffixCode & _
                                                    "LotNo: " & dr.LotNo & "Unit: " & dr.Unit & " since it's already instructed", Nothing)
                            clsLogger.Log(Logger.MessageType.WarningLog, Me.GetType.Name, "CheckDataDetailAndImport", "Cannot import Model: " & dr.ModelYear & dr.SuffixCode & _
                                                    "LotNo: " & dr.LotNo & "Unit: " & dr.Unit & " since it's already instructed", "")
                            m_intSkipCount += 1

                        End If

                    End If

                Next
                clsLogger.Log(Logger.MessageType.NormalLog, Me.GetType.Name, "CheckDataDetailAndImport", "Check format end", "")
            Catch ex As Exception
                clsLogger.Log(Logger.MessageType.ErrorLog, Me.GetType.Name, "CheckDataDetailAndImport", ex.Message, ex.StackTrace)
                isCheckFormatPass = False
                Throw ex
            End Try


            If isCheckFormatPass Then

                clsLogger.Log(Logger.MessageType.NormalLog, Me.GetType.Name, "CheckDataDetailAndImport", "Check Format Passed, start import", "")
                Try

                    Dim dtInst As New ServerDataset.T_Instruction_DATDataTable

                    '***** Add Production data to Instruction data *****
                    For Each dr As ServerDataset.T_Production_DATRow In dtNewData

                        'Add new T_Instruction_DAT records
                        If dr.YChassisFlag = "" Or dr.YChassisFlag = "0" Then 'ALL
                            PisServer.AddProductionRowToInstruction(dtInst, dtLineAll, dr)

                        ElseIf dr.YChassisFlag = "1" Or dr.YChassisFlag = "2" Then 'CAB
                            PisServer.AddProductionRowToInstruction(dtInst, dtLineCab, dr)

                        ElseIf dr.YChassisFlag = "3" Then 'PUBX
                            PisServer.AddProductionRowToInstruction(dtInst, dtLinePubx, dr)

                        End If
                    Next

                    'Insert New Records
                    Try
                        intResult = taT_Production_DAT.Update(dtNewData)
                    Catch ex As Exception
                        clsLogger.Log(Logger.MessageType.ErrorLog, Me.GetType.Name, "CheckDataDetailAndImport", ex.Message, ex.StackTrace)
                        'Throw New Exception("Cannot insert to Production")
                        Throw ex
                    End Try

                    If intResult = 0 Then
                        clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_AS400, TLogDat.LogLevel.WarningLog, Nothing, Now, "No rows insert to T_Production_DAT", Nothing)
                        clsLogger.Log(Logger.MessageType.ErrorLog, Me.GetType.Name, "CheckDataDetailAndImport", "No rows insert to T_Production_DAT", "")
                    Else
                        m_intInsertCount = intResult
                        intResult = 0
                    End If


                    'Insert new records to T_Instruction_DAT
                    Try
                        intResult = taT_Instruction_DAT.Update(dtInst)
                    Catch ex As Exception
                        clsLogger.Log(Logger.MessageType.ErrorLog, Me.GetType.Name, "CheckDataDetailAndImport", ex.Message, ex.StackTrace)
                        'Throw New Exception("Cannot insert to Instruction")
                        Throw ex
                    End Try
                    clsLogger.Log(Logger.MessageType.NormalLog, Me.GetType.Name, "CheckDataDetailAndImport", "Import End", "")

                Catch ex As Exception
                    isCheckFormatPass = False
                    'clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_AS400, TLogDat.LogLevel.ErrorLog, Nothing, Now, ex.Message, Nothing)
                    clsLogger.Log(Logger.MessageType.ErrorLog, Me.GetType.Name, "CheckDataDetailAndImport", ex.Message, ex.StackTrace)
                    Throw ex
                End Try

            End If
            Return isCheckFormatPass

        End If

    End Function

    Private Function DateTimeSeqLessThanCurrentDatarow(ByVal str1 As String, ByVal dr2 As ServerDataset.T_Production_DATRow) As Boolean

        If IsNothing(dr2) Then
            Return False
        End If

        'Dim str1 As String = dr1.ProductionDate + dr1.ProductionTime + dr1.SeqNo
        'If Not dr1.IsSubSeqNull Then
        '    str1 += dr1.SubSeq.ToString("D3")
        'End If

        Dim str2 As String = dr2.ProductionDate + dr2.ProductionTime + dr2.SeqNo
        'If Not dr2.IsSubSeqNull Then
        '    str2 += dr2.SubSeq.ToString("D3")
        'End If

        If str1 < str2 Then
            Return True
        Else
            Return False
        End If

    End Function

    
#End Region

End Class
