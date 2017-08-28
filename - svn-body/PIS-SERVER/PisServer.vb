Imports System.IO
Imports System.Diagnostics
Imports System.Text.RegularExpressions
Imports Common
Imports HMI_LIB


Public Class PisServer
#Region "MEMBER"
    Private m_watchFolder As FileSystemWatcher
    Private m_FileNameList As New ArrayList
    Private m_clsAs400File As New clsAs400File
    Private m_Log As New Logger
    Private clsTLogDat As New TLogDat
    Private m_RowIndexDict As New Dictionary(Of Integer, Integer)

    'Private strServerIp As String
    Private intServerNode As Integer
    Private strWatchPath As String
    Private strBackupPath As String
    Private intAs400Period As Integer
    Private intPlcPeriod As Integer
    Private intLogPeriod As Integer
    'Private intNumberOfRetries As Integer
    Private intDisplayRowCount As Integer

    Private datStartSystem As New Date
    Private m_objPLCCommTesters As New List(Of clsPLCCommunicationTester)
    'Private m_objSysmacCS As OMRON.Compolet.SYSMAC.SysmacCS

    Private intTimerImportStopCounter As Integer

    Private Const WAIT_FOR_HEADER As Integer = 0
    Private Const WAIT_FOR_TRAIL As Integer = 1
    Private Const AS400_RECORD_SIZE As Integer = 1202

#End Region

#Region "METHOD"

#Region "PUBLIC METHOD"
    Public Sub AddProductionRowToInstruction(ByRef dtInst As ServerDataset.T_Instruction_DATDataTable, _
                                             ByVal dtLine As ServerDataset.T_Line_MSTDataTable, _
                                               ByVal drProd As ServerDataset.T_Production_DATRow)
        Dim logger As New Logger
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "AddProductionRowToInstruction", "Start", "")
        Try

            'Dim dtProd As ServerDataset.T_Production_DATDataTable = taT_Production_DAT.GetDataByPrimaryKey(modelYear, suffixCode, lotNo, Unit)
            'Dim drProd As ServerDataset.T_Production_DATRow = dtProd.Rows(0)

            Dim strProd As String
            Dim strInst As String
            Dim strLine As String
            Dim checkPartMismatch As Boolean = False

            For Each drLine As ServerDataset.T_Line_MSTRow In dtLine

                strProd = "MODEL"
                strProd += Format(drLine.LineCode, "0#")
                Dim drInst As ServerDataset.T_Instruction_DATRow = dtInst.NewRow
                drInst.SeqNo = drProd.SeqNo
                drInst.ModelYear = drProd.ModelYear
                drInst.SuffixCode = drProd.SuffixCode
                drInst.LotID = drProd.LotID
                drInst.LotNo = drProd.LotNo
                drInst.Unit = drProd.Unit
                drInst.BlockModel = drProd.BlockModel
                drInst.BlockSeq = drProd.BlockSeq
                drInst.MARK = drProd.MARK
                drInst.ProductionDate = drProd.ProductionDate
                drInst.ProductionTime = drProd.ProductionTime
                drInst.ImportCode = drProd.ImportCode
                drInst.YChassisFlag = drProd.YChassisFlag
                drInst.GAShop = drProd.GAShop
                drInst.HanmmerYears = drProd.HanmmerYears

                For partIndex As Integer = 1 To 5
                    strInst = "ASM"
                    strInst += Format(partIndex, "0#")
                    strLine = "Part"
                    strLine += partIndex.ToString
                    If drLine(strLine) <> Nothing Then
                        If CBool(drLine(strLine)) Then
                            drInst(strInst) = drProd(strProd + strInst).ToString
                        Else
                            drInst(strInst) = ""
                        End If
                    Else
                        drInst(strInst) = ""
                    End If
                Next

                drInst.XchgFlag = drProd.XchgFlag
                drInst.Line_No = drLine.LineCode
                drInst.SubSeq = drProd.SubSeq
                drInst.InsPassFlag = False
                drInst.CarrPassFlag = False

                'check part data not match
                If Not checkPartMismatch Then
                    If Not checkOnlineHaveData(drInst) Or checkDataOverLine(drInst) Then
                        checkPartMismatch = True
                    End If
                End If

                dtInst.Rows.Add(drInst)
            Next

            If checkPartMismatch Then
                clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_AS400, TLogDat.LogLevel.WarningLog, Nothing, _
                                            Now, "ModelYear : " & drProd.ModelYear & " , SuffixCode : " & drProd.SuffixCode & _
                                            " , LotNo : " & drProd.LotNo & " , Unit : " & drProd.Unit & " Parts data not match", Nothing)

                logger.Log(Common.Logger.MessageType.WarningLog, Me.GetType.Name, "AddProductionRowToInstruction", _
                                   "ModelYear : " & drProd.ModelYear & " , SuffixCode : " & drProd.SuffixCode & _
                                   " , LotNo : " & drProd.LotNo & " , Unit : " & drProd.Unit & _
                                   " Parts data not match", "")
            End If

            logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "AddProductionRowToInstruction", "Success", "")

        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "AddProductionRowToInstruction", ex.Message, ex.StackTrace)
            Throw ex
        End Try

    End Sub

    Public Function UpdateProductionRowToInstruction(ByVal drProd As ServerDataset.T_Production_DATRow, _
                                                        ByVal dtInst As ServerDataset.T_Instruction_DATDataTable, _
                                                        ByVal dtLine As ServerDataset.T_Line_MSTDataTable) As Integer
        Dim logger As New Logger
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "UpdateProductionRowToInstruction", "Start", "")
        Try

            Dim strProd As String
            Dim strInst As String
            Dim strLine As String
            Dim checkPartMismatch As Boolean = False

            For Each drLine As ServerDataset.T_Line_MSTRow In dtLine

                strProd = "MODEL"
                strProd += Format(drLine.LineCode, "0#")
                Dim drInst As ServerDataset.T_Instruction_DATRow = dtInst.FindByModelYearSuffixCodeLotNoUnitLine_No _
                                                        (drProd.ModelYear, drProd.SuffixCode, drProd.LotNo, drProd.Unit, drLine.LineCode)
                drInst.SeqNo = drProd.SeqNo
                drInst.ModelYear = drProd.ModelYear
                drInst.SuffixCode = drProd.SuffixCode
                drInst.LotID = drProd.LotID
                drInst.LotNo = drProd.LotNo
                drInst.Unit = drProd.Unit
                drInst.BlockModel = drProd.BlockModel
                drInst.BlockSeq = drProd.BlockSeq
                drInst.MARK = drProd.MARK
                drInst.ProductionDate = drProd.ProductionDate
                drInst.ProductionTime = drProd.ProductionTime
                drInst.ImportCode = drProd.ImportCode
                drInst.YChassisFlag = drProd.YChassisFlag
                drInst.GAShop = drProd.GAShop
                drInst.HanmmerYears = drProd.HanmmerYears

                For partIndex As Integer = 1 To 5
                    strInst = "ASM"
                    strInst += Format(partIndex, "0#")
                    strLine = "Part"
                    strLine += partIndex.ToString
                    If drLine(strLine) <> Nothing Then
                        If CBool(drLine(strLine)) Then
                            drInst(strInst) = drProd(strProd + strInst).ToString
                        Else
                            drInst(strInst) = ""
                        End If
                    Else
                        drInst(strInst) = ""
                    End If
                Next

                drInst.XchgFlag = drProd.XchgFlag
                drInst.Line_No = drLine.LineCode
                drInst.SubSeq = drProd.SubSeq

                'check part data not match
                If Not checkPartMismatch Then
                    If Not checkOnlineHaveData(drInst) Or checkDataOverLine(drInst) Then
                        checkPartMismatch = True
                    End If
                End If

            Next

            If checkPartMismatch Then
                clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_AS400, TLogDat.LogLevel.WarningLog, Nothing, _
                                            Now, "ModelYear : " & drProd.ModelYear & " , SuffixCode : " & drProd.SuffixCode & _
                                            " , LotNo : " & drProd.LotNo & " , Unit : " & drProd.Unit & " Parts data not match", Nothing)

                logger.Log(Common.Logger.MessageType.WarningLog, Me.GetType.Name, "UpdateProductionRowToInstruction", _
                                   "ModelYear : " & drProd.ModelYear & " , SuffixCode : " & drProd.SuffixCode & _
                                   " , LotNo : " & drProd.LotNo & " , Unit : " & drProd.Unit & _
                                   " Parts data not match", "")
            End If

            Dim intResult As Integer = taT_Instruction_DAT.Update(dtInst)
            logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "UpdateProductionRowToInstruction", "Success", "")
            Return intResult

        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "UpdateProductionRowToInstruction", ex.Message, ex.StackTrace)
            'Return 0
            Throw ex
        End Try
    End Function

    Public Function InsertProductionRowToInstruction(ByVal drProd As ServerDataset.T_Production_DATRow, _
                                                     ByVal dtLine As ServerDataset.T_Line_MSTDataTable) As Integer
        Dim logger As New Logger
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "InsertProductionRowToInstruction", "Start", "")
        Try

            Dim dtInst As New ServerDataset.T_Instruction_DATDataTable

            Dim strProd As String
            Dim strInst As String
            Dim strLine As String
            Dim checkPartMismatch As Boolean = False

            For Each drLine As ServerDataset.T_Line_MSTRow In dtLine

                strProd = "MODEL"
                strProd += Format(drLine.LineCode, "0#")
                Dim drInst As ServerDataset.T_Instruction_DATRow = dtInst.NewRow
                drInst.SeqNo = drProd.SeqNo
                drInst.ModelYear = drProd.ModelYear
                drInst.SuffixCode = drProd.SuffixCode
                drInst.LotID = drProd.LotID
                drInst.LotNo = drProd.LotNo
                drInst.Unit = drProd.Unit
                drInst.BlockModel = drProd.BlockModel
                drInst.BlockSeq = drProd.BlockSeq
                drInst.MARK = drProd.MARK
                drInst.ProductionDate = drProd.ProductionDate
                drInst.ProductionTime = drProd.ProductionTime
                drInst.ImportCode = drProd.ImportCode
                drInst.YChassisFlag = drProd.YChassisFlag
                drInst.GAShop = drProd.GAShop
                drInst.HanmmerYears = drProd.HanmmerYears

                For partIndex As Integer = 1 To 5
                    strInst = "ASM"
                    strInst += Format(partIndex, "0#")
                    strLine = "Part"
                    strLine += partIndex.ToString
                    If drLine(strLine) <> Nothing Then
                        If CBool(drLine(strLine)) Then
                            drInst(strInst) = drProd(strProd + strInst).ToString
                        Else
                            drInst(strInst) = ""
                        End If
                    Else
                        drInst(strInst) = ""
                    End If
                Next

                drInst.XchgFlag = drProd.XchgFlag
                drInst.Line_No = drLine.LineCode
                drInst.SubSeq = drProd.SubSeq
                drInst.InsPassFlag = False
                drInst.CarrPassFlag = False

                'check part data not match
                If Not checkPartMismatch Then
                    If Not checkOnlineHaveData(drInst) Or checkDataOverLine(drInst) Then
                        checkPartMismatch = True
                    End If
                End If

                dtInst.Rows.Add(drInst)
            Next

            If checkPartMismatch Then
                clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_AS400, TLogDat.LogLevel.WarningLog, Nothing, _
                                            Now, "ModelYear : " & drProd.ModelYear & " , SuffixCode : " & drProd.SuffixCode & _
                                            " , LotNo : " & drProd.LotNo & " , Unit : " & drProd.Unit & " Parts data not match", Nothing)

                logger.Log(Common.Logger.MessageType.WarningLog, Me.GetType.Name, "InsertProductionRowToInstruction", _
                                   "ModelYear : " & drProd.ModelYear & " , SuffixCode : " & drProd.SuffixCode & _
                                   " , LotNo : " & drProd.LotNo & " , Unit : " & drProd.Unit & _
                                   " Parts data not match", "")
            End If

            Dim intResult As Integer = taT_Instruction_DAT.Update(dtInst)
            logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "InsertProductionRowToInstruction", "Success", "")
            Return intResult
        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "InsertProductionRowToInstruction", ex.Message, ex.StackTrace)
            'Return 0
            'Throw New Exception("Cannot update production to instruction data")
            Throw ex
        End Try
    End Function

    Public Function checkOnlineHaveData(ByVal dr As ServerDataset.T_Instruction_DATRow) As Boolean
        Dim logger As New Logger    'TODO:A Check how to handle when checkOnlineHaveData Failed
        Try
            Dim taLine As ServerDatasetTableAdapters.T_Line_MSTTableAdapter = modDataSource.ta(Of PIS_SERVER.ServerDatasetTableAdapters.T_Line_MSTTableAdapter).GetTableAdapter()
            Dim lDt As New ServerDataset.T_Line_MSTDataTable

            lDt = taLine.GetDataByLineNo(dr.Line_No)
            Dim aDR As ServerDataset.T_Line_MSTRow = lDt.Rows(0)

            If aDR.Part1 = True And dr.ASM01 = "" Then
                Return False
            End If

            If aDR.Part2 = True And dr.ASM02 = "" Then
                Return False
            End If

            If aDR.Part3 = True And dr.ASM03 = "" Then
                Return False
            End If

            If aDR.Part4 = True And dr.ASM04 = "" Then
                Return False
            End If

            If aDR.Part5 = True And dr.ASM05 = "" Then
                Return False
            End If

            Return True

        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "checkOnlineHaveData", ex.Message, ex.StackTrace)
        End Try
    End Function

    Public Function checkDataOverLine(ByVal dr As ServerDataset.T_Instruction_DATRow) As Boolean
        Dim logger As New Logger    'TODO: A Check how to handle if checkDataOverLine failed
        Try
            Dim taLine As ServerDatasetTableAdapters.T_Line_MSTTableAdapter = modDataSource.ta(Of PIS_SERVER.ServerDatasetTableAdapters.T_Line_MSTTableAdapter).GetTableAdapter()
            Dim lDt As New ServerDataset.T_Line_MSTDataTable

            lDt = taLine.GetDataByLineNo(dr.Line_No)
            Dim aDR As ServerDataset.T_Line_MSTRow = lDt.Rows(0)

            If aDR.Part1 = False And dr.ASM01 <> "" Then
                Return True
            End If

            If aDR.Part2 = False And dr.ASM02 <> "" Then
                Return True
            End If

            If aDR.Part3 = False And dr.ASM03 <> "" Then
                Return True
            End If

            If aDR.Part4 = False And dr.ASM04 <> "" Then
                Return True
            End If

            If aDR.Part5 = False And dr.ASM05 <> "" Then
                Return True
            End If

            Return False

        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "checkDataOverLine", ex.Message, ex.StackTrace)
        End Try
    End Function

#End Region

#Region "PRIVATE METHOD"
    Private Sub ImportProductionDataFile()
        Dim logger As New Logger
        Dim clsTLogDat As New TLogDat
        Dim intResult As Integer = 0
        'If True Then
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "ImportProductionDataFile", "Start", "")
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "ImportProductionDataFile", "File Count = " & Me.m_FileNameList.Count, "")
        If Me.m_FileNameList.Count > 0 Then

            'Me.timImport.Stop()
            'ImportProductionDataFile = True
            Dim strFileNameWithPath As String = Me.m_FileNameList(0).ToString
            Dim strFileName As String = strFileNameWithPath.Substring(Me.strWatchPath.Length + 1)
            Dim strNow As String = Format(Now, "yyyyMMddHHmmss")
            Dim strFileRename As String = strNow & strFileName
            Dim strFileRenameWithPath As String = Me.strWatchPath & "\" & strFileRename
            Dim strBackupName As String = Me.strBackupPath & "\" & strNow.Substring(0, 8) & "\"
            If Not Directory.Exists(strBackupName) Then
                Directory.CreateDirectory(strBackupName)
                logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "ImportProductionDataFile", "Directory """ & strBackupName & """ created", "")
            End If
            strBackupName += strFileRename

            Dim theFile As FileStream = Nothing
            'Dim theFile2 As FileStream = Nothing
            Dim bCheckPass As Boolean = False
            Dim bImportPass As Boolean = False

            Try
                If Not My.Computer.FileSystem.FileExists(strFileNameWithPath) Then
                    If m_FileNameList.Count > 0 Then Me.m_FileNameList.RemoveAt(0)
                    logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "ImportProductionDataFile", "File " & strFileNameWithPath & " Not Exist, Remove From List", "")
                    Return
                End If

                theFile = New FileStream(strFileNameWithPath, FileMode.Open, FileAccess.Read)

                If Not theFile.CanRead Then
                    clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_AS400, TLogDat.LogLevel.ErrorLog, Nothing, Now, "Cannot read the file", Nothing)
                    logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "ImportProductionDataFile", "Cannot read the file", "")
                Else
                    Dim objAs400File As New clsAs400File

                    'close old fileName
                    theFile.Close()
                    logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "ImportProductionDataFile", "Can read the file", "")
                    MoveFile(strFileNameWithPath, strFileRenameWithPath)    'Rename File: Add Time Stamp
                    logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "ImportProductionDataFile", "File renamed to """ & strFileRenameWithPath & """", "")

                    'new renameFile
                    theFile = New FileStream(strFileRenameWithPath, FileMode.Open, FileAccess.Read)
                    logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "ImportProductionDataFile", "File opened to import", "")

                    bCheckPass = objAs400File.CheckAs400File(theFile, strFileRenameWithPath, strFileRename)
                    theFile.Close()

                    If bCheckPass Then
                        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "ImportProductionDataFile", "Check File Name For Split", "")
                        Dim blnIsSplittedFile As Boolean = strFileRenameWithPath.Contains(".txt.S")
                        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "ImportProductionDataFile", "blnIsSplittedFile = " & blnIsSplittedFile.ToString, "")
                        If Not blnIsSplittedFile Then
                            logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "ImportProductionDataFile", "File To Split Found", "")
                            Me.SplitFileByShift(strFileRenameWithPath)
                        End If
                        Dim di As New IO.DirectoryInfo(Me.strWatchPath)
                        Dim aFileInf() As IO.FileInfo = di.GetFiles("*.txt.S*", SearchOption.AllDirectories)

                        Dim intMaxRetryCount As Integer = 5
                        For Each fileInf As IO.FileInfo In aFileInf
                            Dim bImportSuccess As Boolean = False
                            Dim intRetryCount As Integer = 0

                            While Not bImportSuccess AndAlso intRetryCount < intMaxRetryCount
                                Dim sFile As IO.FileStream
                                Dim objAs400Import As New clsAs400File
                                sFile = New FileStream(fileInf.FullName, FileMode.Open, FileAccess.Read)
                                bImportSuccess = objAs400Import.ExtractAs400File(sFile, fileInf.FullName, fileInf.Name)
                                sFile.Close()
                                sFile.Dispose()
                                Threading.Thread.Sleep(TimeSpan.FromSeconds(2))
                                If bImportSuccess Then Exit While
                                intRetryCount += 1
                            End While
                            MoveFile(fileInf.FullName, Me.strBackupPath & "\" & strNow.Substring(0, 8) & "\" & fileInf.Name)
                        Next
                        'theFile = New FileStream(strFileRenameWithPath, FileMode.Open, FileAccess.Read)
                        'bCheckPass = objAs400File.ExtractAs400File(theFile, strFileRenameWithPath, strFileRename)
                        'theFile.Close()
                    End If

                    'close renameFile
                    theFile.Close()
                    logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "ImportProductionDataFile", "File closed", "")

                    If m_FileNameList.Count > 0 Then Me.m_FileNameList.RemoveAt(0)
                    logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "ImportProductionDataFile", "Remove filename from list, Remaining " & Me.m_FileNameList.Count & " records", "")

                    MoveFile(strFileRenameWithPath, strBackupName)
                    logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "ImportProductionDataFile", "File moved to backup folder", "")
                    logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "ImportProductionDataFile", "End", "")
                    End If
            Catch ex As Exception
                If theFile IsNot Nothing Then theFile.Close()
                clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_AS400, TLogDat.LogLevel.ErrorLog, Nothing, Now, ex.Message, Nothing)
                logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "ImportProductionDataFile", ex.Message, ex.StackTrace)

                If m_FileNameList.Count > 0 Then Me.m_FileNameList.RemoveAt(0)
                logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "ImportProductionDataFile", "Remove filename from list, Remaining " & Me.m_FileNameList.Count & " records", "")

                MoveFile(strFileRenameWithPath, strBackupName)
                logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "ImportProductionDataFile", "File moved to backup folder", "")
            End Try

        Else
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "ImportProductionDataFile", "File not found", "")
        End If
        'Me.timImport.Start()
    End Sub

    Private Sub SplitFileByShift(ByVal strOriFullPath As String)
        Dim sReader As New StreamReader(strOriFullPath)
        Dim sWriter As IO.StreamWriter = Nothing
        Dim blnEnd As Boolean = False
        Dim strRead As String = ""
        Dim intFileNumber As Integer = 0
        Dim objAs400 As New clsAs400File
        Dim logger As New Logger

        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "SplitFileByShift", "SplitFileByShift Start", "")
        While Not blnEnd
            strRead = ""
            strRead = sReader.ReadLine()
            If strRead IsNot Nothing Then
                Select Case objAs400.CheckRecordTypeReadLine(strRead)
                    Case clsAs400File.RECORD_TYPE_HEADER
                        intFileNumber += 1
                        sWriter = New IO.StreamWriter(strOriFullPath & ".S" & intFileNumber.ToString("D3"), True)
                        sWriter.WriteLine(strRead)
                    Case clsAs400File.RECORD_TYPE_PRODUCTION
                        sWriter.WriteLine(strRead)
                    Case clsAs400File.RECORD_TYPE_TRAIL
                        sWriter.WriteLine(strRead)
                        sWriter.Close()
                        sWriter.Dispose()
                    Case Else
                        If sWriter IsNot Nothing Then
                            sWriter.Close()
                            sWriter.Dispose()
                        End If
                        blnEnd = True
                End Select
            Else
                If sWriter IsNot Nothing Then
                    sWriter.Close()
                    sWriter.Dispose()
                End If
                blnEnd = True
            End If
        End While
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "SplitFileByShift", "SplitFileByShift End", "")
    End Sub

    Private Sub MoveFile(ByVal fromFile As String, ByVal toFile As String)
        Dim logg As New Logger
        logg.Log(Logger.MessageType.NormalLog, Me.GetType.Name, "MoveFile", "Move file start", "")
        'If System.IO.File.Exists(fromFile) = True Then
        '    If System.IO.File.Exists(toFile) = True Then
        '        logg.Log(Logger.MessageType.NormalLog, Me.GetType.Name, "MoveFile", "Destination file exist", "")
        '        System.IO.File.Delete(toFile)
        '        logg.Log(Logger.MessageType.NormalLog, Me.GetType.Name, "MoveFile", "Duplicate file deleted", "")
        '    End If
        '    System.IO.File.Move(fromFile, toFile)
        '    logg.Log(Logger.MessageType.NormalLog, Me.GetType.Name, "MoveFile", "Move file end", "")
        'Else
        '    logg.Log(Logger.MessageType.ErrorLog, Me.GetType.Name, "MoveFile", "File to move not exist", "")
        'End If
        Dim blnMoved As Boolean = False
        While Not blnMoved AndAlso System.IO.File.Exists(fromFile)
            Try
                If System.IO.File.Exists(toFile) = True Then
                    logg.Log(Logger.MessageType.NormalLog, Me.GetType.Name, "MoveFile", "Destination file exist", "")
                    System.IO.File.Delete(toFile)
                    logg.Log(Logger.MessageType.NormalLog, Me.GetType.Name, "MoveFile", "Duplicate file deleted", "")
                End If
                System.IO.File.Move(fromFile, toFile)
                logg.Log(Logger.MessageType.NormalLog, Me.GetType.Name, "MoveFile", "Move file end", "")
                blnMoved = True
            Catch ex As Exception
                logg.Log(Logger.MessageType.ErrorLog, Me.GetType.Name, "MoveFile", ex.Message, ex.StackTrace)
            End Try
        End While
    End Sub

    'Private Sub WatchFolder(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    Me.m_watchFolder = New System.IO.FileSystemWatcher()
    '    Me.m_watchFolder.Path = Me.strWatchPath


    '    Me.m_watchFolder.NotifyFilter = IO.NotifyFilters.DirectoryName
    '    Me.m_watchFolder.NotifyFilter = Me.m_watchFolder.NotifyFilter Or _
    '                               IO.NotifyFilters.FileName
    '    Me.m_watchFolder.NotifyFilter = Me.m_watchFolder.NotifyFilter Or _
    '                               IO.NotifyFilters.Attributes

    '    AddHandler Me.m_watchFolder.Created, AddressOf Me.PutNewFileNameToArray

    '    Me.m_watchFolder.EnableRaisingEvents = True

    'End Sub

    'Private Sub PutNewFileNameToArray(ByVal source As Object, ByVal e As  _
    '                  System.IO.FileSystemEventArgs)
    'Dim clsTLogDat As New TLogDat
    'Me.m_FileNameList.Add(e.FullPath)
    ''Dim intResult As Integer = WriteLog(0, Now, "AS400 Data Received", Nothing, Nothing)
    'clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_AS400, TLogDat.LogLevel.NormalLog, Nothing, Now, "New File Received", Nothing)
    'End Sub

    Private Sub LineMonitor()

        m_objPLCCommTesters.Clear()

        Dim i As Integer = 0

        Try

            'taT_Line_MST.Fill(dsServerDataset.T_Line_MST)

            For j As Integer = 0 To dsServerDataset.T_Line_MST.Rows.Count - 1
                'For j As Integer = 0 To 0
                Dim dr As ServerDataset.T_Line_MSTRow = dsServerDataset.T_Line_MST.Rows(j)

                Dim objPLCCommTester As New clsPLCCommunicationTester(dr)

                With objPLCCommTester
                    .WorkerReportsProgress = True
                    .WorkerSupportsCancellation = True

                    AddHandler .ProgressChanged, AddressOf BackgroundWorker_ProgressChanged

                    .RunWorkerAsync()
                End With

                m_objPLCCommTesters.Add(objPLCCommTester)
            Next j

        Catch ex As Exception

            Me.m_Log.Log(Logger.MessageType.ErrorLog, Me.GetType.Name, "LineMonitor", ex.Message, ex.StackTrace)
        End Try

    End Sub

    Private Sub LoadIni()
        Dim ini As New IniFile
        'Me.strServerIp = ini.GetString(ModConstant.INI_SECTION_SETTING, ModConstant.INI_KEY_SERVER_IP, "192.148.1.100", ModConstant.INI_FILE_NAME)
        Me.intServerNode = ini.GetInt(ModConstant.INI_SECTION_SETTING, ModConstant.INI_KEY_SERVER_NODE, "100", ModConstant.INI_FILE_NAME)
        Me.strWatchPath = ini.GetString(ModConstant.INI_SECTION_SETTING, ModConstant.INI_KEY_WATCH_PATH, "C:\AS400\ManualImport", ModConstant.INI_FILE_NAME)
        Me.strBackupPath = ini.GetString(ModConstant.INI_SECTION_SETTING, ModConstant.INI_KEY_BACKUP_WATCH_PATH, "C:\AS400\BackupManualImport", ModConstant.INI_FILE_NAME)
        Me.intAs400Period = ini.GetInt(ModConstant.INI_SECTION_SETTING, ModConstant.INI_KEY_AS400_PERIOD, "30", ModConstant.INI_FILE_NAME)
        Me.intPlcPeriod = ini.GetInt(ModConstant.INI_SECTION_SETTING, ModConstant.INI_KEY_PLC_PERIOD, "14", ModConstant.INI_FILE_NAME)
        Me.intLogPeriod = ini.GetInt(ModConstant.INI_SECTION_SETTING, ModConstant.INI_KEY_LOG_PERIOD, "30", ModConstant.INI_FILE_NAME)
        'Me.intNumberOfRetries = ini.GetInt(ModConstant.INI_SECTION_SETTING, ModConstant.INI_KEY_NUMBER_OF_RETRIES, "5", ModConstant.INI_FILE_NAME)
        Me.intDisplayRowCount = ini.GetInt(ModConstant.INI_SECTION_SETTING, ModConstant.INI_KEY_DISPLAY_ROW_COUNT, "200", ModConstant.INI_FILE_NAME)
    End Sub

    Private Sub PisServer_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.m_Log.SystemEnd()
        'For j As Integer = 0 To dsServerDataset.T_Line_MST.Rows.Count - 1
        '    Dim dr As ServerDataset.T_Line_MSTRow = dsServerDataset.T_Line_MST.Rows(j)
        '    HMI_LIB.FinsGW.uEndFGW(dr.LineCode)
        'Next j

        For Each objPLCCommTester As clsPLCCommunicationTester In m_objPLCCommTesters
            objPLCCommTester.CancelAsync()
            objPLCCommTester.Dispose()
        Next

        System.GC.Collect()
        Me.Dispose()

    End Sub

    Private Sub PisServer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '============= Check Process are Duplicate Running ========================
        Dim MatchingNames As System.Diagnostics.Process()
        Try
            Dim vMyProcessName As String = System.Diagnostics.Process.GetCurrentProcess.ProcessName

            'MessageBox.Show(vMyProcessName)

            MatchingNames = System.Diagnostics.Process.GetProcessesByName(vMyProcessName)

            If (MatchingNames.Length = 1) Then
                'MessageBox.Show("Started...")
            Else
                MessageBox.Show("PIS-SERVER Already Running!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Number & " " & Err.Description)
        End Try

        Try
            Me.datStartSystem = Now
            Dim clsTLogDat As New TLogDat
            LoadIni()
            'LOGGER
            Me.m_Log.SystemStart()
            Me.m_Log.Log(Logger.MessageType.NormalLog, Me.GetType.Name, "PisServer_Load", "Start", "")
            'clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_AS400, TLogDat.LogLevel.NormalLog, Nothing, Now, "Data Collect Start", Nothing)

            Me.taT_Line_MST.Fill(Me.dsServerDataset.T_Line_MST)
            For ind As Integer = 0 To Me.dsServerDataset.T_Line_MST.Count - 1
                Dim drLine As ServerDataset.T_Line_MSTRow = dsServerDataset.T_Line_MST.Rows(ind)
                m_RowIndexDict.Add(drLine.LineCode, ind)
            Next

            Me.bsTLineMST.DataSource = Me.dsServerDataset.T_Line_MST

            'Start Line Monitoring

            HMI_LIB.FinsGW.uStartUP_FGW()
            Me.LineMonitor()

            Me.taT_LOG_DAT.FillByNumRowAndSystemStart(Me.dsServerDataset.T_LOG_DAT, Me.intDisplayRowCount, Me.datStartSystem)
            Me.bsTLOGDAT.DataSource = Me.dsServerDataset.T_LOG_DAT

            'Me.taT_Instruction_DAT.Fill(Me.dsServerDataset.T_Instruction_DAT)

            'Dim intResult = WriteLog(0, Now, "Data Collect Start", Nothing, Nothing)
            Dim dtLogNow As Date = Now

            Threading.Thread.Sleep(1000)
            clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_AS400, TLogDat.LogLevel.NormalLog, Nothing, Now, "Data Collect Start", Nothing)

            'Timer for show clock
            Me.timClock.Enabled = True
            Me.timClock.Start()

            'Timer for import data
            Me.timImport.Enabled = True
            Me.timImport.Interval = 1000
            Me.timImport.Start()

            Me.BackgroundWorker1.RunWorkerAsync()


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.m_Log.Log(Logger.MessageType.ErrorLog, Me.GetType.Name, "PisServer_Load", ex.Message, ex.StackTrace)
            Me.Close()
        End Try

    End Sub

    Private Sub BackgroundWorker_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) 'Handles BackgroundWorker1.ProgressChanged
        Try
            Dim objPLCCommTester As clsPLCCommunicationTester = _
                    DirectCast(sender, clsPLCCommunicationTester)

            With objPLCCommTester
                Dim dr As ServerDataset.T_Line_MSTRow = dsServerDataset.T_Line_MST.FindByLineCode(.LineCode)

                Debug.Assert(dr IsNot Nothing)

                dr.Status = IIf(.IsConnected, "Normal", "Error")
                dr.Messages = .ErrorMessage
                Dim intLine As Integer = m_RowIndexDict(dr.LineCode)
                If .IsConnected Then
                    'Normal
                    Me.dgv_lineMonitorView.Rows(intLine).DefaultCellStyle.BackColor = Color.White
                    Me.dgv_lineMonitorView.Rows(intLine).DefaultCellStyle.SelectionBackColor = Color.White
                Else
                    'Error
                    Me.dgv_lineMonitorView.Rows(intLine).DefaultCellStyle.BackColor = Color.Red
                    Me.dgv_lineMonitorView.Rows(intLine).DefaultCellStyle.SelectionBackColor = Color.Red
                End If
            End With
        Catch ex As Exception
            Me.m_Log.Log(Logger.MessageType.ErrorLog, Me.GetType.Name, "BackgroundWorker_ProgressChanged", ex.Message, ex.StackTrace)
        End Try
    End Sub

    Private Sub TimClock_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timClock.Tick
        Me.Label1.Text = Format(Now, "dd/MMM/yyyy  HH:mm:ss")
        If timImport.Enabled = False Then
            intTimerImportStopCounter += 1
            If intTimerImportStopCounter > 10 Then
                timImport.Start()
            End If
        End If

    End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        System.GC.Collect()
        Me.Close()
    End Sub

    Private Sub TimImport_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timImport.Tick
        Try
            taT_LOG_DAT.FillByNumRowAndSystemStart(dsServerDataset.T_LOG_DAT, Me.intDisplayRowCount, Me.datStartSystem)

            Me.oshRed.FillColor = Color.DarkGray
            Me.oshGreen.FillColor = Color.Lime
            'Me.m_Log.Log(Logger.MessageType.NormalLog, Me.GetType.Name, "TimImport_Tick", "DB Connected", "")
        Catch ex As Exception

            Me.oshRed.FillColor = Color.Red
            Me.oshGreen.FillColor = Color.DarkGray
            Me.m_Log.Log(Logger.MessageType.NormalLog, Me.GetType.Name, "TimImport_Tick", "DB Connection Lost", "")
            timImport.Stop()
        End Try

    End Sub

    Private Sub dgv_dataCollectionView_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgv_dataCollectionView.MouseDown
        'timImport.Stop()
    End Sub

    Private Sub dgv_dataCollectionView_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgv_dataCollectionView.MouseUp
        timImport.Start()
    End Sub

    Private Sub dgv_dataCollectionView_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles dgv_dataCollectionView.Scroll
        timImport.Stop()
        intTimerImportStopCounter = 0
        If e.Type = ScrollEventType.EndScroll Then
            timImport.Start()
        End If
    End Sub
#End Region

#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim di As New IO.DirectoryInfo(Me.strWatchPath)
        Dim logg As New Common.Logger
        Dim clsTLogDat As New TLogDat
        Dim timNextTime As DateTime = My.Computer.Clock.LocalTime.AddMinutes(10)
        Try
            m_Log.Log(Logger.MessageType.NormalLog, Me.GetType.Name, "BackgroundWorker1_DoWork", "Start", "")
            If Not di.Exists Then
                m_Log.Log(Logger.MessageType.NormalLog, Me.GetType.Name, "BackgroundWorker1_DoWork", "Path not exist, creating " & Me.strWatchPath, "")
                di.Create()
                m_Log.Log(Logger.MessageType.NormalLog, Me.GetType.Name, "BackgroundWorker1_DoWork", "Path " & Me.strWatchPath & " created", "")
            End If
            While True
                Try
                    If My.Computer.Clock.LocalTime.ToOADate > timNextTime.ToOADate Then
                        m_Log.Log(Logger.MessageType.NormalLog, Me.GetType.Name, "BackgroundWorker1_DoWork", "Import File Thread is Running", "")
                        timNextTime = My.Computer.Clock.LocalTime.AddMinutes(10)
                    End If
                    Dim fileInf() As IO.FileInfo = di.GetFiles("*.txt", SearchOption.AllDirectories)
                    Dim fileInfS000() As IO.FileInfo = di.GetFiles("*.txt.S*", SearchOption.AllDirectories)

                    If Me.m_FileNameList Is Nothing Then
                        Me.m_FileNameList = New ArrayList
                    End If

                    If (fileInf.Length > 0 Or fileInfS000.Length > 0) And Me.m_FileNameList.Count = 0 Then

                        For Each inf As FileInfo In fileInf
                            Me.m_FileNameList.Add(inf.FullName)
                        Next

                        For Each inf As FileInfo In fileInfS000
                            Me.m_FileNameList.Add(inf.FullName)
                        Next

                        clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_AS400, TLogDat.LogLevel.NormalLog, Nothing, Now, "New Manual Import File Found", Nothing)
                        logg.Log(Logger.MessageType.NormalLog, Me.GetType.Name, "BackgroundWorker1_DoWork", "New " & fileInf.Length & " Manual Import File Found", "")
                        While Me.m_FileNameList.Count > 0
                            Me.ImportProductionDataFile()
                        End While
                    End If
                Catch ex As Exception
                    m_Log.Log(Logger.MessageType.ErrorLog, Me.GetType.Name, "BackgroundWorker1_DoWork", "Thread Not Stop", "")
                    m_Log.Log(Logger.MessageType.ErrorLog, Me.GetType.Name, "BackgroundWorker1_DoWork", ex.Message, ex.StackTrace)
                End Try
                Threading.Thread.Sleep(1000)
            End While
        Catch ex As Exception
            m_Log.Log(Logger.MessageType.ErrorLog, Me.GetType.Name, "BackgroundWorker1_DoWork", "Thread Stop", "")
            m_Log.Log(Logger.MessageType.ErrorLog, Me.GetType.Name, "BackgroundWorker1_DoWork", ex.Message, ex.StackTrace)
        End Try
    End Sub

    Private Sub btnSystemSetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSystemSetting.Click
        'TestScreen.ShowDialog()
        SystemSetting.ShowDialog()
    End Sub

End Class


#Region "CLASS PLC COMMUNICATION"

Public Class clsPLCCommunicationTester
    Inherits System.ComponentModel.BackgroundWorker
    '#Region "Constant"
    '    Private Const MSG_CPU As String = "0501"
    '#End Region

#Region "Attribute"
    Private m_intLineCode As Integer
    Private m_strLineName As String
    Private m_bKind As Byte

    Private m_nNetworkAddress As Short
    Private m_nNodeAddress As Short
    Private m_nUnitAddress As Short

    Private m_nNet(0) As Integer
    Private m_nNode(0) As Integer
    Private m_nUnit(0) As Integer

    Private m_bNet(1) As Byte
    Private m_bNode(1) As Byte
    Private m_bUnit(1) As Byte

    'for TestConnection
    Private m_bDataTestCon(1) As Byte
    Private m_ErrorTypeTestCon(0) As UInteger
    Private m_ErrorCodeTestCon(0) As UInteger

    'for Instruction
    Private m_bDataInstruction(3) As Byte
    Private m_ErrorTypeInstruction(0) As UInteger
    Private m_ErrorCodeInstruction(0) As UInteger

    'for CarryOut
    Private m_bDataCarryOut(9) As Byte
    Private m_ErrorTypeCarryOut(0) As UInteger
    Private m_ErrorCodeCarryOut(0) As UInteger

    'for Write ServerStatus
    Private m_ErrorTypeServerStatus(0) As UInteger
    Private m_ErrorCodeServerStatus(0) As UInteger

    Private m_intReadAddress As UInteger
    Private m_intWriteCarryAddress As UInteger
    Private m_intWriteProdAddress As UInteger

    Private m_intServerStatusAddress As UInteger

    Private m_blnIsConnected As Boolean
    Private m_strErrorMessage As String

    Private m_intInterval As UInteger
    Private m_intInstructionStatus As Integer
    Private m_intCarryOutStatus As Integer

    Private m_oldIntInstructionStatus As Integer
    Private m_oldIntInstructionReqLine As Integer
    Private m_oldIntInstructionReqDataType As Integer

    Private m_oldIntCarryOutStatus As Integer
    Private m_oldIntCarryOutReqLine As Integer
    Private m_oldIntCarryOutReqDataType As Integer



    Private m_lastWriteInstructionStatus As Integer
    Private m_lastWriteCarryOutStatus As Integer

    Dim m_clsTLogDat As New TLogDat
    Dim m_clsLogger As New Logger

    'Private Const INSTRUCTION_STATUS_WAIT_FOR_REQUEST As Integer = 0
    'Private Const INSTRUCTION_STATUS_REQUEST_RECEIVED As Integer = 1

    Private Const CARRY_OUT_STATUS_WAIT_FOR_REQUEST As Integer = 0
    Private Const CARRY_OUT_STATUS_REQUEST_RECEIVED As Integer = 1

    Private Const READ_INSTRUCTION_REQUEST_LENGTH As Integer = 2

    Private Const READ_CARRY_OUT_REQUEST_OFFSET As Integer = 2
    Private Const READ_CARRY_OUT_REQUEST_LENGTH As Integer = 5

    'Private Const WRITE_INSTRUCTION_LENGTH As Integer = 100    'With Reserved 
    Private Const WRITE_INSTRUCTION_LENGTH As Integer = 50
    Private Const WRITE_NO_INSTRUCTION_LENGTH As Integer = 50
    Private Const WRITE_COMPLETE_INSTRUCTION_LENGTH As Integer = 50
    Private Const WRITE_CARRY_OUT_STATUS As Integer = 2
    Private Const WRITE_SERVER_STATUS_LENGTH As Integer = 1

    Private Const PLC_MODEL_REQUEST_STATUS_WAITING As Integer = 0
    Private Const PLC_MODEL_REQUEST_STATUS_REQUEST As Integer = 1
    Private Const PLC_MODEL_REQUEST_STATUS_COMPLETE As Integer = 2
    Private Const PLC_MODEL_REQUEST_STATUS_FAULT As Integer = 4

    Private Const PLC_CARRY_OUT_REQUEST_STATUS_WAITING As Integer = 0
    Private Const PLC_CARRY_OUT_REQUEST_STATUS_REQUEST As Integer = 1

    Private Const SERVER_CARRY_OUT_STATUS_WAITING As Integer = 0
    Private Const SERVER_CARRY_OUT_STATUS_OK As Integer = 1
    Private Const SERVER_CARRY_OUT_STATUS_NG As Integer = 2

    Private Const SERVER_INSTRUCTION_STATUS_WAITING As Integer = 0
    Private Const SERVER_INSTRUCTION_STATUS_INSTRUCT As Integer = 1
    Private Const SERVER_INSTRUCTION_STATUS_FAULT As Integer = 4

    Private Const SERVER_STATUS_OFFLINE As Integer = 0
    Private Const SERVER_STATUS_ONLINE As Integer = 1
    Private Const SERVER_STATUS_FAULT As Integer = 2

    Private Const DATA_TYPE_VEHICLE As Integer = 1

    'Private WithEvents m_objFinsMsg As OMRON.Compolet.FinsGateway.FinsMsg
    'Private plcInterface As New clsPlcInterface
    'Private plcTestConnection As New clsPlcInterface
    'Private plcCarryInterface As New clsPlcInterface
    'Private plcStatusInterface As New clsPlcInterface
    Private plcInteract As New clsPlcInteract
    Private logger As New Logger

    Private converter As New System.Text.UTF8Encoding
#End Region

#Region "Constructor"
    Sub New(ByRef dr As ServerDataset.T_Line_MSTRow, _
            Optional ByVal intInterval As UInteger = 1000)
        Debug.Assert(dr IsNot Nothing)

        m_intLineCode = dr.LineCode
        m_strLineName = dr.LineName

        'HMI_LIB.FinsGW.uInitFGW(m_intLineCode, m_strLineName)
        m_bKind = "&H82" 'DM

        m_nNetworkAddress = dr.NetAddress
        m_nNodeAddress = dr.NodeAddress
        m_nUnitAddress = dr.UnitAddress

        m_nNet(0) = dr.NetAddress
        m_nNode(0) = dr.NodeAddress
        m_nUnit(0) = dr.UnitAddress

        OMRON.FinsGateway.PLCDataConverter.SystemIntegerToPLC2ByteAsBIN(m_nNet, m_bNet, 0)
        OMRON.FinsGateway.PLCDataConverter.SystemIntegerToPLC2ByteAsBIN(m_nNode, m_bNode, 0)
        OMRON.FinsGateway.PLCDataConverter.SystemIntegerToPLC2ByteAsBIN(m_nUnit, m_bUnit, 0)

        m_intReadAddress = dr.ReadReqAddress
        m_intWriteCarryAddress = dr.WriteCarryOutAddress
        m_intWriteProdAddress = dr.WriteProductionAddress

        m_intInterval = intInterval

        'm_intInstructionStatus = INSTRUCTION_STATUS_WAIT_FOR_REQUEST
        m_intCarryOutStatus = CARRY_OUT_STATUS_WAIT_FOR_REQUEST
    End Sub

    'Protected Overrides Sub Finalize()
    '    If m_objFinsMsg IsNot Nothing Then
    '        With m_objFinsMsg
    '            .Active = False
    '            .Dispose()
    '        End With
    '    End If

    '    MyBase.Finalize()
    'End Sub
#End Region

#Region "Property"
    Public ReadOnly Property LineCode() As Integer
        Get
            Return m_intLineCode
        End Get
    End Property

    Public ReadOnly Property NetworkAddress() As Short
        Get
            Return m_nNetworkAddress
        End Get
    End Property

    Public ReadOnly Property NodeAddress() As Short
        Get
            Return m_nNodeAddress
        End Get
    End Property

    Public ReadOnly Property UnitAddress() As Short
        Get
            Return m_nUnitAddress
        End Get
    End Property

    Public ReadOnly Property ReadAddress() As UInteger
        Get
            Return m_intReadAddress
        End Get
    End Property

    Public ReadOnly Property WriteCarryAddress() As UInteger
        Get
            Return m_intWriteCarryAddress
        End Get
    End Property

    Public ReadOnly Property WriteProdAddress() As UInteger
        Get
            Return m_intWriteProdAddress
        End Get
    End Property

    Public ReadOnly Property IsConnected() As Boolean
        Get
            Return m_blnIsConnected
        End Get
    End Property

    Public ReadOnly Property ErrorMessage() As String
        Get
            Return m_strErrorMessage
        End Get
    End Property
#End Region

#Region "Event"
    Private Sub clsPLCCommunicationTester_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Me.DoWork

        Try

            LoadIni()
            Dim intTimeOutCounter As Integer = 0
            Dim intThreadWorkCount As Integer = 0

            While Not CancellationPending
                Try
                    HMI_LIB.FinsGW.uInitFGW(m_intLineCode, m_strLineName)
                    intThreadWorkCount += 1

                    If TestConnection() Then
                        ' Use the connection
                        CommunicateWithPLC()
                        intTimeOutCounter = 0
                    Else
                        ' Do Something else
                        intTimeOutCounter += 1
                    End If


                    If intTimeOutCounter > 30 Then
                        Me.m_clsLogger.LogByLine(Me.m_intLineCode, Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "clsPLCCommunicationTester_DoWork", "PLC TestConnection Failed Exceed 30 times", "")
                        intTimeOutCounter = 0
                    End If

                    If intThreadWorkCount > 60 Then
                        Me.m_clsLogger.LogByLine(Me.m_intLineCode, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "clsPLCCommunicationTester_DoWork", "Thread is still working", "")
                        intThreadWorkCount = 0
                    End If

                Catch ex As Exception
                    'm_clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_PLC, TLogDat.LogLevel.ErrorLog, Nothing, Now, ex.Message, m_strLineName)
                    m_clsLogger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "clsPLCCommunicationTester_DoWork", ex.Message, ex.StackTrace)
                Finally
                    HMI_LIB.FinsGW.uEndFGW(m_intLineCode)
                End Try
                Threading.Thread.Sleep(m_intInterval)
            End While

        Catch ex As Exception
            'My.Application.Log.WriteException(ex, TraceEventType.Critical, "PLC Communication Tester")
            Me.m_clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_PLC, TLogDat.LogLevel.ErrorLog, Nothing, Now, ex.Message, m_strLineName)
            Me.m_clsLogger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "clsPLCCommunicationTester_DoWork", ex.Message, ex.StackTrace)
        End Try
    End Sub

#End Region

#Region "Method"
    Private Function TestConnection() As Boolean

        m_strErrorMessage = String.Empty

        Dim length As UShort = 1
        Dim bTestConnectionOk As Boolean

        Try
            bTestConnectionOk = HMI_LIB.FinsGW.uRead_MEM_Data_WithErrcode(m_intLineCode, m_bKind, m_bNet(1), m_bNode(1), _
                                                             m_bUnit(1), m_intReadAddress, length, m_bDataTestCon, _
                                                             m_ErrorTypeTestCon, m_ErrorCodeTestCon)
            If bTestConnectionOk Then

                m_blnIsConnected = True
                m_strErrorMessage = "PLC Node " & m_nNodeAddress.ToString & " Connected"
                Me.ReportProgress(100)
            Else
                m_blnIsConnected = False
                m_strErrorMessage = OMRON.FinsGateway.Messaging.FINS.MemoryAreaWriteResponse.GetResponseMessage(m_ErrorCodeTestCon(0))
                'm_strErrorMessage = OMRON.FinsGateway.Messaging.FINS.MemoryAreaWriteResponse.GetResponseMessage(errCode(0))
                'm_strErrorMessage = m_ErrorCode(0).ToString
                If m_strErrorMessage = "" Then
                    m_strErrorMessage = "Connection time out"
                End If
                Me.ReportProgress(0)
            End If

        Catch ex As Exception
            m_blnIsConnected = False
            m_clsLogger.LogByLine(m_intLineCode, Common.Logger.MessageType.ErrorLog, _
                                  Me.GetType.Name, "TestConnection", ex.Message, ex.StackTrace)
            m_strErrorMessage = ex.Message
            Me.ReportProgress(0)

        End Try

        Return m_blnIsConnected

    End Function

    'Private Function TestConnection() As Boolean
    '    m_strErrorMessage = String.Empty

    '    Try
    '        If m_objFinsMsg Is Nothing Then
    '            m_objFinsMsg = New OMRON.Compolet.FinsGateway.FinsMsg
    '            With m_objFinsMsg
    '                .NetworkAddress = m_nNetworkAddress
    '                .NodeAddress = m_nNodeAddress
    '                .UnitAddress = m_nUnitAddress
    '                .Active = True
    '            End With
    '        End If
    '        'm_objFinsMsg.SendFinsCommand(MSG_CPU)
    '        'm_objFinsMsg.ReceiveMessageString()

    '        plcTestConnection.ReadPlcDm(m_objFinsMsg, m_intReadAddress, READ_INSTRUCTION_REQUEST_LENGTH)
    '        If Not plcTestConnection.ReadResult Then
    '            m_blnIsConnected = False

    '            m_strErrorMessage = plcTestConnection.ReadResponseMessage

    '            Me.ReportProgress(0)
    '        Else
    '            m_blnIsConnected = True
    '            m_strErrorMessage = "PLC Node " & m_nNodeAddress.ToString & " Connected"
    '            Me.ReportProgress(100)

    '        End If

    '    Catch ex As Exception
    '        m_blnIsConnected = False

    '        m_strErrorMessage = ex.Message

    '        Me.ReportProgress(0)
    '    End Try

    '    Return m_blnIsConnected
    'End Function
#End Region

    Private Sub CommunicateWithPLC()
        WriteServerStatus(SERVER_STATUS_ONLINE)
        InstructionManagement()
        'CarryOutManagement()
    End Sub

    Private Sub WriteServerStatus(ByVal serverStatus As Integer)

        Dim length As UShort = WRITE_SERVER_STATUS_LENGTH
        Dim bWriteStatusOk As Boolean
        Try
            bWriteStatusOk = HMI_LIB.FinsGW.uWrite_MEM_Data_WithErrcode(m_intLineCode, m_bKind, m_bNet(1), m_bNode(1), _
                                                                      m_bUnit(1), m_intServerStatusAddress, length, _
                                                                      plcInteract.WriteServerStatus(serverStatus), _
                                                                      m_ErrorTypeServerStatus, m_ErrorCodeServerStatus)
            If bWriteStatusOk Then
                'm_clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_PLC, TLogDat.LogLevel.NormalLog, Nothing, _
                '                          Now, "Write server status to PLC completed at DM" & m_intServerStatusAddress, m_strLineName)
                logger.LogByLine(m_intLineCode, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "WriteServerStatus", _
                                    "Write server status to PLC completed at DM" & m_intServerStatusAddress, "")
                Me.ReportProgress(100)
            Else
                m_clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_PLC, TLogDat.LogLevel.ErrorLog, Nothing, _
                                      Now, "Cannot write server status to PLC at DM" & m_intServerStatusAddress, m_strLineName)
                logger.LogByLine(m_intLineCode, Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "WriteServerStatus", _
                                    "Cannot write server status to PLC at DM" & m_intServerStatusAddress, "")
                m_blnIsConnected = False
                m_strErrorMessage = OMRON.FinsGateway.Messaging.FINS.MemoryAreaWriteResponse.GetResponseMessage(m_ErrorCodeServerStatus(0))
                Me.ReportProgress(0)
            End If

        Catch ex As Exception
            m_blnIsConnected = False
            logger.LogByLine(m_intLineCode, Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "WriteServerStatus", _
                                    ex.Message, ex.StackTrace)
            m_strErrorMessage = ex.Message
            Me.ReportProgress(0)

        End Try
        'plcStatusInterface.WritePlcDm(m_objFinsMsg, m_intServerStatusAddress, plcInteract.WriteServerStatus(serverStatus))
        'If plcStatusInterface.WriteResult Then
        'Else
        '    m_clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_PLC, TLogDat.LogLevel.ErrorLog, Nothing, Now, plcStatusInterface.WriteResponseMessage, m_strLineName)
        'End If
    End Sub

    Private Sub InstructionManagement()

        Dim bReadInstructionOk As Boolean
        Try
            bReadInstructionOk = HMI_LIB.FinsGW.uRead_MEM_Data_WithErrcode(m_intLineCode, m_bKind, m_bNet(1), m_bNode(1), _
                                                             m_bUnit(1), m_intReadAddress, READ_INSTRUCTION_REQUEST_LENGTH, _
                                                             m_bDataInstruction, m_ErrorTypeInstruction, m_ErrorCodeInstruction)
            If bReadInstructionOk Then
                logger.LogByLine(m_intLineCode, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "Instruction Management", _
                             "PLC Read Result = True", "")

                Dim intInstructionStatus As Integer
                Dim intReqLine As Integer
                Dim intReqDataType As Integer
                intInstructionStatus = plcInteract.ReadModelDataRequestStatus(m_bDataInstruction)
                intReqDataType = plcInteract.ReadModelDataRequestDataType(m_bDataInstruction)
                intReqLine = plcInteract.ReadModelDataRequestLine(m_bDataInstruction)
                logger.LogByLine(m_intLineCode, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "Instruction Management", _
                             "Instruction Read: LineCode = " & intReqLine.ToString("D2") & ", DataType = " & intReqDataType.ToString("D2") _
                             & ", ReqStatus = " & intInstructionStatus.ToString("D2"), "")

                If (m_oldIntInstructionStatus <> intInstructionStatus) _
                    Or (m_oldIntInstructionReqDataType <> intReqDataType) _
                    Or (m_oldIntInstructionReqLine <> intReqLine) Then

                    If intReqLine = m_intLineCode And intReqDataType = DATA_TYPE_VEHICLE Then

                        Dim strReadInfo As String = "Valid Instruction Read: "
                        strReadInfo += " Line=" & intReqLine.ToString("D2") & ", Data Type=" & intReqDataType.ToString("D2") _
                                        & ", Status=" & intInstructionStatus.ToString("D2")
                        logger.LogByLine(m_intLineCode, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "InstructionManagement", strReadInfo, "")

                        If intInstructionStatus = PLC_MODEL_REQUEST_STATUS_COMPLETE Then
                            'write 0, stamp date if m_lastWriteInstructionStatus = SERVER_INSTRUCTION_STATUS_INSTRUCT
                            'write 0, not stamp date if m_lastWriteInstructionStatus = SERVER_INSTRUCTION_STATUS_FAULT
                            SendInstructionComplete(m_intLineCode)
                        ElseIf intInstructionStatus = PLC_MODEL_REQUEST_STATUS_WAITING Then
                            'Clear To 0
                            Dim length As UShort = WRITE_COMPLETE_INSTRUCTION_LENGTH
                            Dim bWriteProdOk As Boolean = False

                            While Not bWriteProdOk
                                bWriteProdOk = HMI_LIB.FinsGW.uWrite_MEM_Data_WithErrcode(m_intLineCode, m_bKind, m_bNet(1), m_bNode(1), _
                                                                                      m_bUnit(1), m_intWriteProdAddress, length, _
                                                                                      plcInteract.WriteCompleteInstruction(m_intLineCode), _
                                                                                      m_ErrorTypeInstruction, m_ErrorCodeInstruction)

                                m_lastWriteInstructionStatus = SERVER_INSTRUCTION_STATUS_WAITING
                                If bWriteProdOk Then
                                    Me.ReportProgress(100)
                                Else
                                    logger.LogByLine(m_intLineCode, Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "InstructionManagement", "Write status 0 for Line " + m_intLineCode.ToString + " Failed at DM" & m_intWriteProdAddress, "")
                                    m_blnIsConnected = False
                                    m_strErrorMessage = OMRON.FinsGateway.Messaging.FINS.MemoryAreaWriteResponse.GetResponseMessage(m_ErrorCodeInstruction(0))
                                    Me.ReportProgress(0)
                                    Threading.Thread.Sleep(TimeSpan.FromMilliseconds(300))
                                End If
                            End While
                        ElseIf intInstructionStatus = PLC_MODEL_REQUEST_STATUS_REQUEST Then
                            'write 1, 4
                            SendNextInstruction(m_intLineCode)
                        ElseIf intInstructionStatus = PLC_MODEL_REQUEST_STATUS_FAULT Then
                            'write 0
                            m_clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_PLC, TLogDat.LogLevel.ErrorLog, Nothing, Now, "PLC Request Status 04:False", m_strLineName)
                            logger.LogByLine(m_intLineCode, Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "InstructionManagement", "PLC Request Status 04:False", "")

                            'plcInterface.WritePlcDm(m_objFinsMsg, m_intWriteProdAddress, plcInteract.WriteCompleteInstruction(m_intLineCode))
                            Dim length As UShort = WRITE_COMPLETE_INSTRUCTION_LENGTH
                            Dim bWriteProdOk As Boolean = False

                            While Not bWriteProdOk
                                bWriteProdOk = HMI_LIB.FinsGW.uWrite_MEM_Data_WithErrcode(m_intLineCode, m_bKind, m_bNet(1), m_bNode(1), _
                                                                                      m_bUnit(1), m_intWriteProdAddress, length, _
                                                                                      plcInteract.WriteCompleteInstruction(m_intLineCode), _
                                                                                      m_ErrorTypeInstruction, m_ErrorCodeInstruction)
                                If Not bWriteProdOk Then
                                    logger.LogByLine(m_intLineCode, Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "InstructionManagement", "Cannot clear instruction status at DM" & m_intWriteProdAddress, "")
                                    logger.LogByLine(m_intLineCode, Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "InstructionManagement", "Error Message = " & OMRON.FinsGateway.Messaging.FINS.MemoryAreaWriteResponse.GetResponseMessage(m_ErrorCodeInstruction(0)), "")
                                    m_blnIsConnected = False
                                    m_strErrorMessage = OMRON.FinsGateway.Messaging.FINS.MemoryAreaWriteResponse.GetResponseMessage(m_ErrorCodeInstruction(0))
                                    Me.ReportProgress(0)
                                    Threading.Thread.Sleep(TimeSpan.FromMilliseconds(300))
                                Else
                                    logger.LogByLine(m_intLineCode, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "InstructionManagement", strReadInfo & " at DM" & m_intWriteProdAddress, "")
                                    m_blnIsConnected = False
                                    m_strErrorMessage = "PLC Request Status 04:False"
                                    Me.ReportProgress(100)
                                End If
                            End While
                        Else
                            'Invalid Request Status
                            Dim bWriteProdOk As Boolean = False
                            While Not bWriteProdOk
                                bWriteProdOk = WriteInstructionAbnormalCase()

                                If bWriteProdOk Then
                                    m_clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_PLC, TLogDat.LogLevel.ErrorLog, Nothing, Now, "Invalid Request Status in Instruction Request - Write Abnormal Success at DM" & m_intWriteProdAddress, m_strLineName)
                                    logger.LogByLine(m_intLineCode, Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "InstructionManagement", "Invalid Line Code in Instruction Request - Write Abnormal Success at DM" & m_intWriteProdAddress, "")
                                    Me.ReportProgress(100)
                                Else
                                    m_clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_PLC, TLogDat.LogLevel.ErrorLog, Nothing, Now, "Invalid Request Status in Instruction Request - Write Abnormal Failed at DM" & m_intWriteProdAddress, m_strLineName)
                                    logger.LogByLine(m_intLineCode, Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "InstructionManagement", "Invalid Line Code in Instruction Request - Write Abnormal Failed at DM" & m_intWriteProdAddress, "")
                                    m_blnIsConnected = False
                                    m_strErrorMessage = OMRON.FinsGateway.Messaging.FINS.MemoryAreaWriteResponse.GetResponseMessage(m_ErrorCodeInstruction(0))
                                    Me.ReportProgress(0)
                                    Threading.Thread.Sleep(TimeSpan.FromMilliseconds(300))
                                End If
                            End While
                        End If
                        'm_oldIntInstructionStatus = intInstructionStatus

                    ElseIf intReqLine <> m_intLineCode And intReqDataType <> DATA_TYPE_VEHICLE Then
                        'write 4
                        Dim bWriteProdOk As Boolean = False

                        While Not bWriteProdOk
                            bWriteProdOk = WriteInstructionAbnormalCase()

                            If bWriteProdOk Then
                                m_clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_PLC, TLogDat.LogLevel.ErrorLog, Nothing, Now, "Invalid Line Code and Data Type in Instruction Request - Write Abnormal Success at DM" & m_intWriteProdAddress, m_strLineName)
                                logger.LogByLine(m_intLineCode, Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "InstructionManagement", "Invalid Line Code and Data Type in Instruction Request - Write Abnormal Success at DM" & m_intWriteProdAddress, "")
                                m_blnIsConnected = False
                                m_strErrorMessage = "Invalid Line Code and Data Type in Instruction Request"
                                Me.ReportProgress(100)
                            Else
                                m_clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_PLC, TLogDat.LogLevel.ErrorLog, Nothing, Now, "Invalid Line Code and Data Type in Instruction Request - Write Abnormal Failed at DM" & m_intWriteProdAddress, m_strLineName)
                                logger.LogByLine(m_intLineCode, Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "InstructionManagement", "Invalid Line Code and Data Type in Instruction Request - Write Abnormal Failed at DM" & m_intWriteProdAddress, "")
                                m_blnIsConnected = False
                                m_strErrorMessage = OMRON.FinsGateway.Messaging.FINS.MemoryAreaWriteResponse.GetResponseMessage(m_ErrorCodeInstruction(0))
                                Me.ReportProgress(0)
                                Threading.Thread.Sleep(TimeSpan.FromMilliseconds(300))
                            End If
                        End While

                    ElseIf intReqLine <> m_intLineCode Then
                        'write 4
                        Dim bWriteProdOk As Boolean = False

                        While Not bWriteProdOk

                            bWriteProdOk = WriteInstructionAbnormalCase()

                            If bWriteProdOk Then
                                m_clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_PLC, TLogDat.LogLevel.ErrorLog, Nothing, Now, "Invalid Line Code in Instruction Request - Write Abnormal Success at DM" & m_intWriteProdAddress, m_strLineName)
                                logger.LogByLine(m_intLineCode, Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "InstructionManagement", "Invalid Line Code in Instruction Request - Write Abnormal Success at DM" & m_intWriteProdAddress, "")
                                m_blnIsConnected = False
                                m_strErrorMessage = "Invalid Line Code in Instruction Request"
                                Me.ReportProgress(100)
                            Else
                                m_clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_PLC, TLogDat.LogLevel.ErrorLog, Nothing, Now, "Invalid Line Code in Instruction Request - Write Abnormal Failed at DM" & m_intWriteProdAddress, m_strLineName)
                                logger.LogByLine(m_intLineCode, Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "InstructionManagement", "Invalid Line Code in Instruction Request - Write Abnormal Failed at DM" & m_intWriteProdAddress, "")
                                m_blnIsConnected = False
                                m_strErrorMessage = OMRON.FinsGateway.Messaging.FINS.MemoryAreaWriteResponse.GetResponseMessage(m_ErrorCodeInstruction(0))
                                Me.ReportProgress(0)
                                Threading.Thread.Sleep(TimeSpan.FromMilliseconds(300))
                            End If
                        End While

                    ElseIf intReqDataType <> DATA_TYPE_VEHICLE Then
                        'write 4
                        Dim bWriteProdOk As Boolean = False

                        While Not bWriteProdOk
                            bWriteProdOk = WriteInstructionAbnormalCase()

                            If bWriteProdOk Then
                                m_clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_PLC, TLogDat.LogLevel.ErrorLog, Nothing, Now, "Invalid Data Type in Instruction Request - Write Abnormal Success at DM" & m_intWriteProdAddress, m_strLineName)
                                logger.LogByLine(m_intLineCode, Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "InstructionManagement", "Invalid Data Type in Instruction Request - Write Abnormal Success at DM" & m_intWriteProdAddress, "")
                                m_blnIsConnected = False
                                m_strErrorMessage = "Invalid Data Type in Instruction Request"
                                Me.ReportProgress(100)
                            Else
                                m_clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_PLC, TLogDat.LogLevel.ErrorLog, Nothing, Now, "Invalid Data Type in Instruction Request - Write Abnormal Failed at DM" & m_intWriteProdAddress, m_strLineName)
                                logger.LogByLine(m_intLineCode, Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "InstructionManagement", "Invalid Data Type in Instruction Request - Write Abnormal Failed at DM" & m_intWriteProdAddress, "")
                                m_blnIsConnected = False
                                m_strErrorMessage = OMRON.FinsGateway.Messaging.FINS.MemoryAreaWriteResponse.GetResponseMessage(m_ErrorCodeInstruction(0))
                                Me.ReportProgress(0)
                                Threading.Thread.Sleep(TimeSpan.FromMilliseconds(300))
                            End If
                        End While
                    End If

                Else 'value not change
                    'NONE = STILL WAITING

                End If

                'keep last value
                m_oldIntInstructionStatus = intInstructionStatus
                m_oldIntInstructionReqDataType = intReqDataType
                m_oldIntInstructionReqLine = intReqLine

            Else
                m_clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_PLC, TLogDat.LogLevel.ErrorLog, Nothing, Now, OMRON.FinsGateway.Messaging.FINS.MemoryAreaWriteResponse.GetResponseMessage(m_ErrorCodeInstruction(0)), m_strLineName)
                logger.LogByLine(m_intLineCode, Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "InstructionManagement", _
                             "PLC Read Result = False, Error Message = " & OMRON.FinsGateway.Messaging.FINS.MemoryAreaWriteResponse.GetResponseMessage(m_ErrorCodeInstruction(0)), "")
                m_blnIsConnected = False
                m_strErrorMessage = OMRON.FinsGateway.Messaging.FINS.MemoryAreaWriteResponse.GetResponseMessage(m_ErrorCodeInstruction(0))
                Me.ReportProgress(0)
            End If

        Catch ex As Exception
            m_blnIsConnected = False
            logger.LogByLine(m_intLineCode, Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "InstructionManagement", _
                             ex.Message, ex.StackTrace)
            m_strErrorMessage = ex.Message
            Me.ReportProgress(0)

        End Try

    End Sub

    Private Sub CarryOutManagement()

        Dim bReadCarryOutOk As Boolean

        Try
            bReadCarryOutOk = HMI_LIB.FinsGW.uRead_MEM_Data_WithErrcode(m_intLineCode, m_bKind, m_bNet(1), m_bNode(1), _
                                                             m_bUnit(1), m_intReadAddress + READ_CARRY_OUT_REQUEST_OFFSET, _
                                                             READ_CARRY_OUT_REQUEST_LENGTH, m_bDataCarryOut, m_ErrorTypeCarryOut, m_ErrorCodeCarryOut)

            If bReadCarryOutOk Then

                logger.LogByLine(m_intLineCode, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "CarryOutManagement", _
                             "PLC Read Result = True", "")

                Dim intCarryOutStatus As Integer
                Dim intReqLine As Integer
                Dim intReqDataType As Integer
                Dim strCarryOutLot As String
                Dim strCarryOutUnit As String

                intCarryOutStatus = plcInteract.ReadCarryOutRequestStatus(m_bDataCarryOut)
                intReqDataType = plcInteract.ReadCarryOutRequestDataType(m_bDataCarryOut)
                intReqLine = plcInteract.ReadCarryOutRequestLine(m_bDataCarryOut)
                logger.LogByLine(m_intLineCode, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "CarryOutManagement", _
                             "Carry Out Read: LineCode = " & intReqLine.ToString("D2") & ", DataType = " & intReqDataType.ToString("D2") _
                             & ", ReqStatus = " & intCarryOutStatus.ToString("D2"), "")

                If m_oldIntCarryOutStatus <> intCarryOutStatus _
                    Or m_oldIntCarryOutReqLine <> intReqLine _
                    Or m_oldIntCarryOutReqDataType <> intReqDataType Then

                    If intReqLine = m_intLineCode And intReqDataType = DATA_TYPE_VEHICLE Then
                        strCarryOutLot = plcInteract.ReadCarryOutLot(m_bDataCarryOut)
                        strCarryOutUnit = plcInteract.ReadCarryOutUnit(m_bDataCarryOut)

                        Dim strReadInfo As String = "Valid Carry Out Read: "
                        strReadInfo += " Line=" & intReqLine.ToString("D2") & ", Data Type=" & intReqDataType.ToString("D2") _
                                        & ", Status=" & intCarryOutStatus.ToString("D2") _
                                        & ", Lot=" & strCarryOutLot _
                                        & ", Unit=" & strCarryOutUnit
                        logger.LogByLine(m_intLineCode, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "CarryOutManagement", strReadInfo, "")

                        If intCarryOutStatus = PLC_CARRY_OUT_REQUEST_STATUS_WAITING Then
                            SendCarryOutComplete(m_intLineCode)
                        ElseIf intCarryOutStatus = PLC_CARRY_OUT_REQUEST_STATUS_REQUEST Then

                            'write 1, 2
                            SendNextCarryOut(m_intLineCode, strCarryOutLot, strCarryOutUnit)

                        End If

                    ElseIf intReqLine <> m_intLineCode And intReqDataType <> DATA_TYPE_VEHICLE Then
                        'write 2
                        Dim bWriteCarrOk As Boolean
                        bWriteCarrOk = WriteCarryOutAbnormalCase()

                        If bWriteCarrOk Then
                            m_clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_PLC, TLogDat.LogLevel.ErrorLog, Nothing, Now, "Invalid Line Code and Data Type in Carry Out Request - Write Abnormal Success at DM" & m_intWriteCarryAddress, m_strLineName)
                            logger.LogByLine(m_intLineCode, Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "CarryOutManagement", "Invalid Line Code and Data Type in Carry Out Request - Write Abnormal Success at DM" & m_intWriteCarryAddress, "")
                            m_blnIsConnected = False
                            m_strErrorMessage = "Invalid Line Code and Data Type in Carry Out Request"
                            Me.ReportProgress(100)
                        Else
                            m_clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_PLC, TLogDat.LogLevel.ErrorLog, Nothing, Now, "Invalid Line Code and Data Type in Carry Out Request - Write Abnormal Failed at DM" & m_intWriteCarryAddress, m_strLineName)
                            logger.LogByLine(m_intLineCode, Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "CarryOutManagement", "Invalid Line Code and Data Type in Carry Out Request - Write Abnormal Failed at DM" & m_intWriteCarryAddress, "")
                            m_blnIsConnected = False
                            m_strErrorMessage = OMRON.FinsGateway.Messaging.FINS.MemoryAreaWriteResponse.GetResponseMessage(m_ErrorCodeCarryOut(0))
                            Me.ReportProgress(0)
                        End If

                    ElseIf intReqLine <> m_intLineCode Then
                        'write 2
                        Dim bWriteCarrOk As Boolean
                        bWriteCarrOk = WriteCarryOutAbnormalCase()

                        If bWriteCarrOk Then
                            m_clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_PLC, TLogDat.LogLevel.ErrorLog, Nothing, Now, "Invalid Line Code in Carry Out Request - Write Abnormal Success at DM" & m_intWriteCarryAddress, m_strLineName)
                            logger.LogByLine(m_intLineCode, Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "CarryOutManagement", "Invalid Line Code in Carry Out Request - Write Abnormal Successat DM" & m_intWriteCarryAddress, "")
                            m_blnIsConnected = False
                            m_strErrorMessage = "Invalid Line Code in Carry Out Request"
                            Me.ReportProgress(100)
                        Else
                            m_clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_PLC, TLogDat.LogLevel.ErrorLog, Nothing, Now, "Invalid Line Code in Carry Out Request - Write Abnormal Failed at DM" & m_intWriteCarryAddress, m_strLineName)
                            logger.LogByLine(m_intLineCode, Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "CarryOutManagement", "Invalid Line Code in Carry Out Request - Write Abnormal Failed at DM" & m_intWriteCarryAddress, "")
                            m_blnIsConnected = False
                            m_strErrorMessage = OMRON.FinsGateway.Messaging.FINS.MemoryAreaWriteResponse.GetResponseMessage(m_ErrorCodeCarryOut(0))
                            Me.ReportProgress(0)
                        End If

                    ElseIf intReqDataType <> DATA_TYPE_VEHICLE Then
                        'write 2
                        Dim bWriteCarrOk As Boolean
                        bWriteCarrOk = WriteCarryOutAbnormalCase()

                        If bWriteCarrOk Then
                            m_clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_PLC, TLogDat.LogLevel.ErrorLog, Nothing, Now, "Invalid Data Type in Carry Out Request - Write Abnormal Success at DM" & m_intWriteCarryAddress, m_strLineName)
                            logger.LogByLine(m_intLineCode, Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "CarryOutManagement", "Invalid Data Type in Carry Out Request - Write Abnormal Success at DM" & m_intWriteCarryAddress, "")
                            m_blnIsConnected = False
                            m_strErrorMessage = "Invalid Data Type in Carry Out Request"
                            Me.ReportProgress(100)
                        Else
                            m_clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_PLC, TLogDat.LogLevel.ErrorLog, Nothing, Now, "Invalid Data Type in Carry Out Request - Write Abnormal Failed at DM" & m_intWriteCarryAddress, m_strLineName)
                            logger.LogByLine(m_intLineCode, Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "CarryOutManagement", "Invalid Data Type in Carry Out Request - Write Abnormal Failed at DM" & m_intWriteCarryAddress, "")
                            m_blnIsConnected = False
                            m_strErrorMessage = OMRON.FinsGateway.Messaging.FINS.MemoryAreaWriteResponse.GetResponseMessage(m_ErrorCodeCarryOut(0))
                            Me.ReportProgress(0)
                        End If

                    End If

                Else 'value not change
                    'NONE = STILL WAITING
                End If

                'keep last value
                m_oldIntCarryOutStatus = intCarryOutStatus
                m_oldIntCarryOutReqLine = intReqLine
                m_oldIntCarryOutReqDataType = intReqDataType

            Else
                m_clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_PLC, TLogDat.LogLevel.ErrorLog, Nothing, Now, OMRON.FinsGateway.Messaging.FINS.MemoryAreaWriteResponse.GetResponseMessage(m_ErrorCodeCarryOut(0)), m_strLineName)
                logger.LogByLine(m_intLineCode, Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "CarryOutManagement", _
                                 "PLC Read Result = False, Error Message = " & OMRON.FinsGateway.Messaging.FINS.MemoryAreaWriteResponse.GetResponseMessage(m_ErrorCodeCarryOut(0)), "")
                m_blnIsConnected = False
                m_strErrorMessage = OMRON.FinsGateway.Messaging.FINS.MemoryAreaWriteResponse.GetResponseMessage(m_ErrorCodeCarryOut(0))
                Me.ReportProgress(0)
            End If

        Catch ex As Exception
            m_blnIsConnected = False
            logger.LogByLine(m_intLineCode, Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "CarryOutManagement", _
                             ex.Message, ex.StackTrace)
            m_strErrorMessage = ex.Message
            Me.ReportProgress(0)

        End Try

    End Sub

    Private Sub LoadIni()
        Dim ini As New IniFile
        Me.m_intServerStatusAddress = ini.GetInt(ModConstant.INI_SECTION_SETTING, ModConstant.INI_KEY_SERVER_STATUS_ADDRESS, 22999, ModConstant.INI_FILE_NAME)
    End Sub

    Private Function SendNextInstruction(ByVal lineNo As Integer) As Boolean
        Dim dtTempInst As New ServerDataset.T_Instruction_DATDataTable
        Dim dr As ServerDataset.T_Instruction_DATRow
        Dim taInstruction As New ServerDatasetTableAdapters.T_Instruction_DATTableAdapter


        Dim flag As Boolean = False

        Try
            taInstruction.FillNextInstructionByLineNo(dtTempInst, lineNo)
            If dtTempInst.Rows.Count > 0 Then

                dr = dtTempInst.Rows(0)
                'TODO Get row above and below to check for InspIn
                'If at first row get only record below

                '****************************************
                'If current record is InspIn
                If dr.XchgFlag.Substring(2, 2) = "02" Then

                    'get next record
                    Dim dtNextInst As New ServerDataset.T_Instruction_DATDataTable
                    Dim drNext As ServerDataset.T_Instruction_DATRow
                    taInstruction.FillByNextInstructionRecord(dtNextInst, 1, dr.ProductionDate, dr.ProductionTime, dr.SeqNo, dr.SubSeq, lineNo)
                    If dtNextInst.Rows.Count > 0 Then
                        drNext = dtNextInst.Rows(0)

                        drNext.XchgFlag = drNext.XchgFlag.Substring(0, 2) + "02"
                        WriteNextInstruction(drNext)

                    End If

                Else

                    'get previous record
                    Dim dtPreviousInst As New ServerDataset.T_Instruction_DATDataTable
                    'Dim drPrevious As ServerDataset.T_Instruction_DATRow
                    taInstruction.FillByPrevInstructionRecord(dtPreviousInst, 0, dr.ProductionDate, dr.ProductionTime, dr.SeqNo, dr.SubSeq, lineNo)

                    If dtPreviousInst.Rows.Count > 0 AndAlso dtPreviousInst(0).XchgFlag.Substring(2, 2) = "02" Then
                        'Previous record is InspIn
                        dr.XchgFlag = dr.XchgFlag.Substring(0, 2) + "02"
                        WriteNextInstruction(dr)

                    Else
                        WriteNextInstruction(dr)

                    End If

                End If

                Return True
                '****************************************

            Else
                'No Schedule case
                Dim bWriteProdOk As Boolean = False

                While Not bWriteProdOk
                    bWriteProdOk = WriteInstructionAbnormalCase()

                    If bWriteProdOk Then
                        m_clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_PLC, TLogDat.LogLevel.WarningLog, Nothing, Now, "No Instruction Waiting for Line " + m_intLineCode.ToString & " at DM" & m_intWriteProdAddress, m_strLineName)
                        logger.LogByLine(m_intLineCode, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "SendNextInstruction", "No Instruction Waiting for Line " + m_intLineCode.ToString & " at DM" & m_intWriteProdAddress, "")
                        m_blnIsConnected = False
                        m_strErrorMessage = "No Instruction Waiting for Line " + m_intLineCode.ToString
                        Me.ReportProgress(100)
                        Return True
                    Else
                        m_clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_PLC, TLogDat.LogLevel.ErrorLog, Nothing, Now, "No Instruction Waiting for Line " + m_intLineCode.ToString + " Failed at DM" & m_intWriteProdAddress, m_strLineName)
                        logger.LogByLine(m_intLineCode, Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "SendNextInstruction", "No Instruction Waiting for Line " + m_intLineCode.ToString + " Failed at DM" & m_intWriteProdAddress, "")
                        m_blnIsConnected = False
                        m_strErrorMessage = OMRON.FinsGateway.Messaging.FINS.MemoryAreaWriteResponse.GetResponseMessage(m_ErrorCodeInstruction(0))
                        Me.ReportProgress(0)
                        Threading.Thread.Sleep(TimeSpan.FromMilliseconds(300))
                    End If
                End While

            End If

        Catch ex As Exception
            m_blnIsConnected = False
            logger.LogByLine(m_intLineCode, Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "SendNextInstruction", ex.Message, ex.StackTrace)
            m_strErrorMessage = ex.Message

            ''Dim bWriteProdOk As Boolean = False
            ''While Not bWriteProdOk
            ''    bWriteProdOk = WriteInstructionAbnormalCase()
            ''    If bWriteProdOk Then
            ''        logger.LogByLine(m_intLineCode, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "SendNextInstruction", "WriteInstructionAbnormalCase for Line " + m_intLineCode.ToString & " at DM" & m_intWriteProdAddress, "")
            ''    Else
            ''        logger.LogByLine(m_intLineCode, Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "SendNextInstruction", "WriteInstructionAbnormalCase for Line " + m_intLineCode.ToString + " Failed at DM" & m_intWriteProdAddress, "")
            ''        Threading.Thread.Sleep(TimeSpan.FromMilliseconds(300))
            ''    End If
            ''    Me.ReportProgress(0)
            ''End While
            Return False
        End Try

        Return flag

    End Function

    Private Sub WriteNextInstruction(ByVal dr As ServerDataset.T_Instruction_DATRow)

        'check part not match with line master
        If PisServer.checkOnlineHaveData(dr) And Not PisServer.checkDataOverLine(dr) Then

            Dim prodResult As Integer = 0
            Dim length As UShort = WRITE_INSTRUCTION_LENGTH
            Dim bWriteProdOk As Boolean = False

            While Not bWriteProdOk
                bWriteProdOk = HMI_LIB.FinsGW.uWrite_MEM_Data_WithErrcode(m_intLineCode, m_bKind, m_bNet(1), m_bNode(1), _
                                                                      m_bUnit(1), m_intWriteProdAddress, length, _
                                                                      plcInteract.WriteInstruction(dr), _
                                                                      m_ErrorTypeInstruction, m_ErrorCodeInstruction)

                If bWriteProdOk Then
                    'prodResult = CheckProdInstructFlag(dr.ModelYear, dr.SuffixCode, dr.LotNo, dr.Unit)
                    m_clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_PLC, TLogDat.LogLevel.NormalLog, Nothing, Now, "ModelYear " + dr.ModelYear + " SuffixCode " + dr.SuffixCode + " LotNo " + dr.LotNo + " Line " + m_intLineCode.ToString + " Sent Instruction at DM" & m_intWriteProdAddress, m_strLineName)
                    logger.LogByLine(m_intLineCode, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "WriteNextInstruction", "ModelYear " + dr.ModelYear + " SuffixCode " + dr.SuffixCode + " LotNo " + dr.LotNo + " Line " + m_intLineCode.ToString + " Sent Instruction at DM" & m_intWriteProdAddress, "")
                    Me.ReportProgress(100)
                    m_lastWriteInstructionStatus = SERVER_INSTRUCTION_STATUS_INSTRUCT
                    'Return True
                Else
                    m_clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_PLC, TLogDat.LogLevel.ErrorLog, Nothing, Now, "ModelYear " + dr.ModelYear + " SuffixCode " + dr.SuffixCode + " LotNo " + dr.LotNo + " Line " + m_intLineCode.ToString + " Cannot Send Instruction to PLC at DM" & m_intWriteProdAddress, m_strLineName)
                    logger.LogByLine(m_intLineCode, Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "WriteNextInstruction", "ModelYear " + dr.ModelYear + " SuffixCode " + dr.SuffixCode + " LotNo " + dr.LotNo + " Line " + m_intLineCode.ToString + " Cannot Send Instruction to PLC at DM" & m_intWriteProdAddress, "")
                    m_blnIsConnected = False
                    m_strErrorMessage = OMRON.FinsGateway.Messaging.FINS.MemoryAreaWriteResponse.GetResponseMessage(m_ErrorCodeInstruction(0))
                    Me.ReportProgress(0)
                    'Return False
                    Threading.Thread.Sleep(TimeSpan.FromMilliseconds(300))
                End If
            End While

        Else

            'Parts mismatch with Line Master Parts

            Dim prodResult As Integer = 0
            Dim length As UShort = WRITE_INSTRUCTION_LENGTH
            Dim bWriteProdOk As Boolean = False

            While Not bWriteProdOk
                bWriteProdOk = HMI_LIB.FinsGW.uWrite_MEM_Data_WithErrcode(m_intLineCode, m_bKind, m_bNet(1), m_bNode(1), _
                                                                      m_bUnit(1), m_intWriteProdAddress, length, _
                                                                      plcInteract.WriteInstructionPartNotMatch(dr), _
                                                                      m_ErrorTypeInstruction, m_ErrorCodeInstruction)

                If bWriteProdOk Then
                    'prodResult = CheckProdInstructFlag(dr.ModelYear, dr.SuffixCode, dr.LotNo, dr.Unit)
                    m_clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_PLC, TLogDat.LogLevel.NormalLog, Nothing, Now, "ModelYear " + dr.ModelYear + _
                                              " SuffixCode " + dr.SuffixCode + " LotNo " + dr.LotNo + " Line " + m_intLineCode.ToString + _
                                              " Sent Part Not Match Instruction at DM" & m_intWriteProdAddress, m_strLineName)
                    logger.LogByLine(m_intLineCode, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "WriteNextInstruction", _
                                     "ModelYear " + dr.ModelYear + " SuffixCode " + dr.SuffixCode + " LotNo " + dr.LotNo + _
                                     " Line " + m_intLineCode.ToString + " Sent Part Not Match Instruction at DM" & m_intWriteProdAddress, "")
                    Me.ReportProgress(100)
                    m_lastWriteInstructionStatus = SERVER_INSTRUCTION_STATUS_INSTRUCT
                    'Return True
                Else
                    m_clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_PLC, TLogDat.LogLevel.ErrorLog, Nothing, Now, "ModelYear " + dr.ModelYear + _
                                              " SuffixCode " + dr.SuffixCode + " LotNo " + dr.LotNo + " Line " + m_intLineCode.ToString + _
                                              " Cannot Send Part Not Match Instruction to PLC at DM" & m_intWriteProdAddress, m_strLineName)
                    logger.LogByLine(m_intLineCode, Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "WriteNextInstruction", _
                                     "ModelYear " + dr.ModelYear + " SuffixCode " + dr.SuffixCode + " LotNo " + dr.LotNo + _
                                     " Line " + m_intLineCode.ToString + " Cannot Send Part Not Match Instruction to PLC at DM" & m_intWriteProdAddress, "")
                    m_blnIsConnected = False
                    m_strErrorMessage = OMRON.FinsGateway.Messaging.FINS.MemoryAreaWriteResponse.GetResponseMessage(m_ErrorCodeInstruction(0))
                    Me.ReportProgress(0)
                    'Return False
                    Threading.Thread.Sleep(TimeSpan.FromMilliseconds(300))
                End If
            End While
        End If

    End Sub

    Private Function WriteInstructionAbnormalCase() As Boolean
        Dim bWriteProdOk As Boolean
        Dim length As UShort = WRITE_NO_INSTRUCTION_LENGTH

        bWriteProdOk = HMI_LIB.FinsGW.uWrite_MEM_Data_WithErrcode(m_intLineCode, m_bKind, m_bNet(1), m_bNode(1), _
                                                              m_bUnit(1), m_intWriteProdAddress, length, _
                                                              plcInteract.WriteNoInstruction(m_intLineCode), _
                                                              m_ErrorTypeInstruction, m_ErrorCodeInstruction)

        m_lastWriteInstructionStatus = SERVER_INSTRUCTION_STATUS_FAULT

        Return bWriteProdOk

    End Function

    Private Function SendInstructionComplete(ByVal lineNo As Integer) As Boolean
        Dim dtTempInst As New ServerDataset.T_Instruction_DATDataTable
        Dim dr As ServerDataset.T_Instruction_DATRow
        Dim taInstruction As New ServerDatasetTableAdapters.T_Instruction_DATTableAdapter

        Try

            If m_lastWriteInstructionStatus = SERVER_INSTRUCTION_STATUS_FAULT Then
                'plcInterface.WritePlcDm(m_objFinsMsg, m_intWriteProdAddress, plcInteract.WriteCompleteInstruction(lineNo))
                Dim length As UShort = WRITE_COMPLETE_INSTRUCTION_LENGTH
                Dim bWriteProdOk As Boolean = False

                While Not bWriteProdOk
                    bWriteProdOk = HMI_LIB.FinsGW.uWrite_MEM_Data_WithErrcode(m_intLineCode, m_bKind, m_bNet(1), m_bNode(1), _
                                                                          m_bUnit(1), m_intWriteProdAddress, length, _
                                                                          plcInteract.WriteCompleteInstruction(lineNo), _
                                                                          m_ErrorTypeInstruction, m_ErrorCodeInstruction)

                    m_lastWriteInstructionStatus = SERVER_INSTRUCTION_STATUS_WAITING
                    If bWriteProdOk Then
                        m_clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_PLC, TLogDat.LogLevel.WarningLog, Nothing, Now, "Write Instruction Status Fault for Line " + m_intLineCode.ToString + " Complete at DM" & m_intWriteProdAddress, m_strLineName)
                        logger.LogByLine(m_intLineCode, Common.Logger.MessageType.WarningLog, Me.GetType.Name, "SendInstructionComplete", "Write Instruction Status Fault for Line " + m_intLineCode.ToString + " Complete at DM" & m_intWriteProdAddress, "")
                        Me.ReportProgress(100)
                    Else
                        logger.LogByLine(m_intLineCode, Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "SendInstructionComplete", "Write Instruction Status Fault for Line " + m_intLineCode.ToString + " Failed at DM" & m_intWriteProdAddress, "")
                        m_blnIsConnected = False
                        m_strErrorMessage = OMRON.FinsGateway.Messaging.FINS.MemoryAreaWriteResponse.GetResponseMessage(m_ErrorCodeInstruction(0))
                        Me.ReportProgress(0)
                        Threading.Thread.Sleep(TimeSpan.FromMilliseconds(300))
                    End If
                End While
                Return True
            End If

            taInstruction.FillNextInstructionByLineNo(dtTempInst, lineNo)

            If dtTempInst.Rows.Count > 0 Then
                If m_lastWriteInstructionStatus = SERVER_INSTRUCTION_STATUS_INSTRUCT Then

                    Using ts As New TransactionScope
                        dr = dtTempInst.Rows(0)

                        'TODO Get row above and below to check for InspIn
                        'If at first row get only record below
                        '****************************************
                        'If current record is InspIn
                        If dr.XchgFlag.Substring(2, 2) = "02" Then

                            WriteInstructionComplete(dr, lineNo)

                            'get next record
                            Dim dtNextInst As New ServerDataset.T_Instruction_DATDataTable
                            Dim drNext As ServerDataset.T_Instruction_DATRow
                            taInstruction.FillByNextInstructionRecord(dtNextInst, 1, dr.ProductionDate, dr.ProductionTime, dr.SeqNo, dr.SubSeq, lineNo)
                            If dtNextInst.Rows.Count > 0 Then
                                drNext = dtNextInst.Rows(0)
                                WriteInstructionComplete(drNext, lineNo)
                                logger.LogByLine(m_intLineCode, Common.Logger.MessageType.WarningLog, Me.GetType.Name, "SendInstructionComplete", _
                                                     "Write next record results because InspIn", "(" & dr.ModelYear & "," & dr.SuffixCode & "," & dr.LotNo & "," & dr.Unit & ")")
                            End If

                        Else

                            'get previous record
                            Dim dtPreviousInst As New ServerDataset.T_Instruction_DATDataTable
                            Dim drPrevious As ServerDataset.T_Instruction_DATRow
                            taInstruction.FillByPrevInstructionRecord(dtPreviousInst, 0, dr.ProductionDate, dr.ProductionTime, dr.SeqNo, dr.SubSeq, lineNo)

                            If dtPreviousInst.Rows.Count > 0 Then
                                drPrevious = dtPreviousInst.Rows(0)
                                If drPrevious.XchgFlag.Substring(2, 2) = "02" Then
                                    WriteInstructionComplete(drPrevious, lineNo)
                                    logger.LogByLine(m_intLineCode, Common.Logger.MessageType.WarningLog, Me.GetType.Name, "SendInstructionComplete", _
                                                     "Write prev record results because InspIn", "(" & dr.ModelYear & "," & dr.SuffixCode & "," & dr.LotNo & "," & dr.Unit & ")")
                                End If
                            End If

                            WriteInstructionComplete(dr, lineNo)
                        End If
                        ts.Complete()
                    End Using
                    Dim length As UShort = WRITE_COMPLETE_INSTRUCTION_LENGTH
                    Dim bWriteProdOk As Boolean = False

                    While Not bWriteProdOk
                        bWriteProdOk = HMI_LIB.FinsGW.uWrite_MEM_Data_WithErrcode(m_intLineCode, m_bKind, m_bNet(1), m_bNode(1), _
                                                                              m_bUnit(1), m_intWriteProdAddress, length, _
                                                                              plcInteract.WriteCompleteInstruction(lineNo), _
                                                                              m_ErrorTypeInstruction, m_ErrorCodeInstruction)

                        If bWriteProdOk Then
                            m_lastWriteInstructionStatus = SERVER_INSTRUCTION_STATUS_WAITING
                            logger.LogByLine(m_intLineCode, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "WriteInstructionComplete", " Instruction Complete at DM" & m_intWriteProdAddress, "")
                            Me.ReportProgress(100)
                        Else
                            m_blnIsConnected = False
                            m_strErrorMessage = OMRON.FinsGateway.Messaging.FINS.MemoryAreaWriteResponse.GetResponseMessage(m_ErrorCodeInstruction(0))
                            Me.ReportProgress(0)
                            Threading.Thread.Sleep(TimeSpan.FromMilliseconds(300))
                        End If
                    End While
                    logger.LogByLine(m_intLineCode, Common.Logger.MessageType.WarningLog, Me.GetType.Name, "SendInstructionComplete", "Commit Transaction", "")
                    Return True
                    '****************************************

                ElseIf m_lastWriteInstructionStatus = SERVER_INSTRUCTION_STATUS_FAULT Then
                    'plcInterface.WritePlcDm(m_objFinsMsg, m_intWriteProdAddress, plcInteract.WriteCompleteInstruction(lineNo))
                    Dim length As UShort = WRITE_COMPLETE_INSTRUCTION_LENGTH
                    Dim bWriteProdOk As Boolean = False

                    While Not bWriteProdOk
                        bWriteProdOk = HMI_LIB.FinsGW.uWrite_MEM_Data_WithErrcode(m_intLineCode, m_bKind, m_bNet(1), m_bNode(1), _
                                                                              m_bUnit(1), m_intWriteProdAddress, length, _
                                                                              plcInteract.WriteCompleteInstruction(lineNo), _
                                                                              m_ErrorTypeInstruction, m_ErrorCodeInstruction)

                        m_lastWriteInstructionStatus = SERVER_INSTRUCTION_STATUS_WAITING
                        If bWriteProdOk Then
                            m_clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_PLC, TLogDat.LogLevel.WarningLog, Nothing, Now, "Write Instruction Status Fault for Line " + m_intLineCode.ToString + " Complete at DM" & m_intWriteProdAddress, m_strLineName)
                            logger.LogByLine(m_intLineCode, Common.Logger.MessageType.WarningLog, Me.GetType.Name, "SendInstructionComplete", "Write Instruction Status Fault for Line " + m_intLineCode.ToString + " Complete at DM" & m_intWriteProdAddress, "")
                            Me.ReportProgress(100)
                        Else
                            logger.LogByLine(m_intLineCode, Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "SendInstructionComplete", "Write Instruction Status Fault for Line " + m_intLineCode.ToString + " Failed at DM" & m_intWriteProdAddress, "")
                            m_blnIsConnected = False
                            m_strErrorMessage = OMRON.FinsGateway.Messaging.FINS.MemoryAreaWriteResponse.GetResponseMessage(m_ErrorCodeInstruction(0))
                            Me.ReportProgress(0)
                            Threading.Thread.Sleep(TimeSpan.FromMilliseconds(300))
                        End If
                    End While
                    Return True
                ElseIf m_lastWriteInstructionStatus = SERVER_INSTRUCTION_STATUS_WAITING Then
                    ''Should Do Nothing
                End If
            Else
                'plcInterface.WritePlcDm(m_objFinsMsg, m_intWriteProdAddress, plcInteract.WriteCompleteInstruction(lineNo))
                Dim length As UShort = WRITE_COMPLETE_INSTRUCTION_LENGTH
                Dim bWriteProdOk As Boolean = False

                While Not bWriteProdOk
                    bWriteProdOk = HMI_LIB.FinsGW.uWrite_MEM_Data_WithErrcode(m_intLineCode, m_bKind, m_bNet(1), m_bNode(1), _
                                                                          m_bUnit(1), m_intWriteProdAddress, length, _
                                                                          plcInteract.WriteCompleteInstruction(lineNo), _
                                                                          m_ErrorTypeInstruction, m_ErrorCodeInstruction)

                    If bWriteProdOk Then
                        m_lastWriteInstructionStatus = SERVER_INSTRUCTION_STATUS_WAITING
                        m_clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_PLC, TLogDat.LogLevel.WarningLog, Nothing, Now, "No Instruction Waiting for Line " + m_intLineCode.ToString + " Complete at DM" & m_intWriteProdAddress, m_strLineName)
                        logger.LogByLine(m_intLineCode, Common.Logger.MessageType.WarningLog, Me.GetType.Name, "SendInstructionComplete", "No Instruction Waiting for Line " + m_intLineCode.ToString + " Complete at DM" & m_intWriteProdAddress, "")
                        Me.ReportProgress(100)
                    Else
                        logger.LogByLine(m_intLineCode, Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "SendInstructionComplete", "No Instruction Waiting for Line " + m_intLineCode.ToString + " Failed at DM" & m_intWriteProdAddress, "")
                        m_blnIsConnected = False
                        m_strErrorMessage = OMRON.FinsGateway.Messaging.FINS.MemoryAreaWriteResponse.GetResponseMessage(m_ErrorCodeInstruction(0))
                        Me.ReportProgress(0)
                        Threading.Thread.Sleep(TimeSpan.FromMilliseconds(300))
                    End If
                End While
                Return True
            End If
            Return True
        Catch ex As Exception
            m_blnIsConnected = False
            logger.LogByLine(m_intLineCode, Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "SendInstructionComplete", ex.Message, ex.StackTrace)
            m_strErrorMessage = ex.Message

            ''Dim bWriteProdOk As Boolean = False
            ''While Not bWriteProdOk
            ''    bWriteProdOk = WriteInstructionAbnormalCase()
            ''    If bWriteProdOk Then
            ''        logger.LogByLine(m_intLineCode, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "SendInstructionComplete", "WriteInstructionAbnormalCase for Line " + m_intLineCode.ToString & " at DM" & m_intWriteProdAddress, "")
            ''    Else
            ''        logger.LogByLine(m_intLineCode, Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "SendInstructionComplete", "WriteInstructionAbnormalCase for Line " + m_intLineCode.ToString + " Failed at DM" & m_intWriteProdAddress, "")
            ''        Threading.Thread.Sleep(TimeSpan.FromMilliseconds(300))
            ''    End If
            ''    Me.ReportProgress(0)
            ''End While
            Return False
        End Try

    End Function

    Private Sub WriteInstructionComplete(ByVal dr As ServerDataset.T_Instruction_DATRow, ByVal lineNo As Integer)

        Dim taInstruction As New ServerDatasetTableAdapters.T_Instruction_DATTableAdapter

        Try
            Dim prodResult As Integer = CheckProdInstructFlag(dr.ModelYear, dr.SuffixCode, dr.LotNo, dr.Unit)
            dr.InsResult = Now
            Dim intResult = taInstruction.Update(dr)

            If intResult > 0 Then
                'plcInterface.WritePlcDm(m_objFinsMsg, m_intWriteProdAddress, plcInteract.WriteCompleteInstruction(lineNo))
                ''''m_clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_PLC, TLogDat.LogLevel.NormalLog, Nothing, Now, "ModelYear " + dr.ModelYear + " SuffixCode " + dr.SuffixCode + " LotNo " + dr.LotNo + " Line " + m_intLineCode.ToString + " Instruction Complete at DM" & m_intWriteProdAddress, m_strLineName)
            Else
                ''''m_clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_PLC, TLogDat.LogLevel.ErrorLog, Nothing, Now, "ModelYear " + dr.ModelYear + " SuffixCode " + dr.SuffixCode + " LotNo " + dr.LotNo + " Line " + m_intLineCode.ToString + " Cannot Write Instruction Result To Database", m_strLineName)
                logger.LogByLine(m_intLineCode, Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "WriteInstructionComplete", "ModelYear " + dr.ModelYear + " SuffixCode " + dr.SuffixCode + " LotNo " + dr.LotNo + " Line " + m_intLineCode.ToString + " Cannot Write Instruction Result To Database", "")
                'Return False
            End If
        Catch ex As Exception
            logger.LogByLine(m_intLineCode, Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "WriteInstructionComplete", "ModelYear " + dr.ModelYear + " SuffixCode " + dr.SuffixCode + " LotNo " + dr.LotNo + " Line " + m_intLineCode.ToString + " Cannot Write Instruction Result To Database", "")
            Throw ex
        End Try
    End Sub

    Private Function SendNextCarryOut(ByVal lineNo As Integer, ByVal carryLot As String, ByVal carryUnit As String) As Boolean
        Dim dtTempInst As New ServerDataset.T_Instruction_DATDataTable
        Dim dr As ServerDataset.T_Instruction_DATRow
        Dim taInstruction As New ServerDatasetTableAdapters.T_Instruction_DATTableAdapter

        Dim flag As Boolean = False

        Try
            taInstruction.FilNextCarryOutByLineNo(dtTempInst, lineNo)
            If dtTempInst.Rows.Count > 0 Then
                dr = dtTempInst.Rows(0)
                'TODO Get row above and below to check for InspIn
                'If at first row get only record below
                '****************************************
                'If current record is InspIn
                If dr.XchgFlag.Substring(2, 2) = "02" Then

                    'WriteNextCarryOut(dr, carryLot, carryUnit)

                    'get next record
                    Dim dtNextInst As New ServerDataset.T_Instruction_DATDataTable
                    Dim drNext As ServerDataset.T_Instruction_DATRow
                    taInstruction.FillByNextInstructionRecord(dtNextInst, 1, dr.ProductionDate, dr.ProductionTime, dr.SeqNo, dr.SubSeq, lineNo)
                    If dtNextInst.Rows.Count > 0 Then
                        drNext = dtNextInst.Rows(0)

                        WriteNextCarryOut(drNext, carryLot, carryUnit)

                    End If

                Else

                    'get previous record
                    'Dim dtPreviousInst As New ServerDataset.T_Instruction_DATDataTable
                    'Dim drPrevious As ServerDataset.T_Instruction_DATRow
                    'taInstruction.FillByPrevInstructionRecord(dtPreviousInst, 0, dr.ProductionDate, dr.ProductionTime, dr.SeqNo, dr.SubSeq, lineNo)

                    'If dtPreviousInst.Rows.Count > 0 Then
                    '    drPrevious = dtPreviousInst.Rows(0)

                    '    If drPrevious.XchgFlag.Substring(2, 2) = "02" Then
                    '        WriteNextCarryOut(drPrevious, carryLot, carryUnit)
                    '    End If

                    'End If

                    WriteNextCarryOut(dr, carryLot, carryUnit)

                End If

                Return True
                '****************************************

            Else
                'TODO Send anything?
                m_clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_PLC, TLogDat.LogLevel.WarningLog, Nothing, Now, "No Carry Out Waiting for Line " + m_intLineCode.ToString, m_strLineName)
                logger.LogByLine(m_intLineCode, Common.Logger.MessageType.WarningLog, Me.GetType.Name, "SendNextCarryOut", "No Carry Out Waiting for Line " + m_intLineCode.ToString, "")
                m_blnIsConnected = False
                m_strErrorMessage = "No Carry Out Waiting for Line " + m_intLineCode.ToString
                Me.ReportProgress(0)
                Return False
            End If

        Catch ex As Exception
            m_blnIsConnected = False
            logger.LogByLine(m_intLineCode, Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "SendNextCarryOut", ex.Message, ex.StackTrace)
            m_strErrorMessage = ex.Message

            Dim bWriteCarrOk As Boolean = False
            While Not bWriteCarrOk
                bWriteCarrOk = WriteCarryOutAbnormalCase()
                If bWriteCarrOk Then
                    logger.LogByLine(m_intLineCode, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "SendNextCarryOut", "WriteCarryOutAbnormalCase for Line " + m_intLineCode.ToString & " at DM" & m_intWriteCarryAddress, "")
                Else
                    logger.LogByLine(m_intLineCode, Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "SendNextCarryOut", "WriteCarryOutAbnormalCase for Line " + m_intLineCode.ToString + " Failed at DM" & m_intWriteCarryAddress, "")
                    Threading.Thread.Sleep(TimeSpan.FromMilliseconds(300))
                End If
                Me.ReportProgress(0)
            End While
            Return False
        End Try

        Return flag
    End Function

    Private Sub WriteNextCarryOut(ByVal dr As ServerDataset.T_Instruction_DATRow, _
                                  ByVal carryLot As String, ByVal carryUnit As String)

        If (System.String.Compare(dr.LotNo, carryLot) = 0 And System.String.Compare(dr.Unit, carryUnit) = 0) Then

            Dim prodResult As Integer = 0
            'plcCarryInterface.WritePlcDm(m_objFinsMsg, m_intWriteCarryAddress, plcInteract.WriteCarryOutStatus(m_intLineCode, SERVER_CARRY_OUT_STATUS_OK))
            Dim length As UShort = WRITE_CARRY_OUT_STATUS
            Dim bWriteCarrOk As Boolean

            bWriteCarrOk = HMI_LIB.FinsGW.uWrite_MEM_Data_WithErrcode(m_intLineCode, m_bKind, m_bNet(1), m_bNode(1), _
                                                                  m_bUnit(1), m_intWriteCarryAddress, length, _
                                                                  plcInteract.WriteCarryOutStatus(m_intLineCode, SERVER_CARRY_OUT_STATUS_OK), _
                                                                  m_ErrorTypeCarryOut, m_ErrorCodeCarryOut)

            m_lastWriteCarryOutStatus = SERVER_CARRY_OUT_STATUS_OK
            If bWriteCarrOk Then
                m_clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_PLC, TLogDat.LogLevel.NormalLog, Nothing, Now, "ModelYear " + dr.ModelYear + " SuffixCode " + dr.SuffixCode + " LotNo " + dr.LotNo + " Line " + m_intLineCode.ToString + " Carry Out Sent To PLC at DM" & m_intWriteCarryAddress, m_strLineName)
                logger.LogByLine(m_intLineCode, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "SendNextCarryOut", "ModelYear " + dr.ModelYear + " SuffixCode " + dr.SuffixCode + " LotNo " + dr.LotNo + " Line " + m_intLineCode.ToString + " Carry Out Sent To PLC at DM" & m_intWriteCarryAddress, "")
                'prodResult = CheckProdInstructFlag(dr.ModelYear, dr.SuffixCode, dr.LotNo, dr.Unit)
                Me.ReportProgress(100)
                'Return True
            Else
                m_clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_PLC, TLogDat.LogLevel.ErrorLog, Nothing, Now, "ModelYear " + dr.ModelYear + " SuffixCode " + dr.SuffixCode + " LotNo " + dr.LotNo + " Line " + m_intLineCode.ToString + " Carry Out OK Sending To PLC Failed at DM" & m_intWriteCarryAddress, m_strLineName)
                logger.LogByLine(m_intLineCode, Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "SendNextCarryOut", "ModelYear " + dr.ModelYear + " SuffixCode " + dr.SuffixCode + " LotNo " + dr.LotNo + " Line " + m_intLineCode.ToString + " Carry Out OK Sending To PLC Failed at DM" & m_intWriteCarryAddress, "")
                m_blnIsConnected = False
                m_strErrorMessage = OMRON.FinsGateway.Messaging.FINS.MemoryAreaWriteResponse.GetResponseMessage(m_ErrorCodeCarryOut(0))
                Me.ReportProgress(0)
                'Return False
            End If
        Else
            'NG case
            Dim bWriteCarrOk As Boolean
            bWriteCarrOk = WriteCarryOutAbnormalCase()

            If bWriteCarrOk Then
                m_clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_PLC, TLogDat.LogLevel.ErrorLog, Nothing, Now, "Invalid LotNo: " + carryLot.ToString + ", Unit: " + carryUnit.ToString + " of Line " + m_intLineCode.ToString + " to Carry Out at DM" & m_intWriteCarryAddress, m_strLineName)
                logger.LogByLine(m_intLineCode, Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "SendNextCarryOut", "Invalid LotNo: " + carryLot.ToString + ", Unit: " + carryUnit.ToString + " of Line " + m_intLineCode.ToString + " to Carry Out at DM" & m_intWriteCarryAddress, "")
                m_blnIsConnected = False
                m_strErrorMessage = "Invalid LotNo: " + carryLot.ToString + ", Unit: " + carryUnit.ToString + " of Line " + m_intLineCode.ToString + " to Carry Out"
                Me.ReportProgress(100)
                'Return True
            Else
                m_clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_PLC, TLogDat.LogLevel.ErrorLog, Nothing, Now, "Line " + m_intLineCode.ToString + " Carry Out NG Sending To PLC Failed at DM" & m_intWriteCarryAddress, m_strLineName)
                logger.LogByLine(m_intLineCode, Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "SendNextCarryOut", "Line " + m_intLineCode.ToString + " Carry Out NG Sending To PLC Failed at DM" & m_intWriteCarryAddress, "")
                m_blnIsConnected = False
                m_strErrorMessage = OMRON.FinsGateway.Messaging.FINS.MemoryAreaWriteResponse.GetResponseMessage(m_ErrorCodeCarryOut(0))
                Me.ReportProgress(0)
                'Return False
            End If
        End If

    End Sub

    Private Function WriteCarryOutAbnormalCase() As Boolean
        Dim length As UShort = WRITE_CARRY_OUT_STATUS
        Dim bWriteCarrOk As Boolean

        bWriteCarrOk = HMI_LIB.FinsGW.uWrite_MEM_Data_WithErrcode(m_intLineCode, m_bKind, m_bNet(1), m_bNode(1), _
                                                              m_bUnit(1), m_intWriteCarryAddress, length, _
                                                              plcInteract.WriteCarryOutStatus(m_intLineCode, SERVER_CARRY_OUT_STATUS_NG), _
                                                              m_ErrorTypeCarryOut, m_ErrorCodeCarryOut)

        m_lastWriteCarryOutStatus = SERVER_CARRY_OUT_STATUS_NG

        Return bWriteCarrOk

    End Function

    Private Function SendCarryOutComplete(ByVal lineNo As Integer) As Boolean
        Dim dtTempInst As New ServerDataset.T_Instruction_DATDataTable
        Dim dr As ServerDataset.T_Instruction_DATRow
        Dim taInstruction As New ServerDatasetTableAdapters.T_Instruction_DATTableAdapter

        Dim flag As Boolean = False

        Try

            If m_lastWriteCarryOutStatus = SERVER_CARRY_OUT_STATUS_NG Then
                'plcCarryInterface.WritePlcDm(m_objFinsMsg, m_intWriteCarryAddress, plcInteract.WriteCarryOutStatus(m_intLineCode, SERVER_CARRY_OUT_STATUS_WAITING))
                Dim length As UShort = WRITE_CARRY_OUT_STATUS
                Dim bWriteCarrOk As Boolean

                bWriteCarrOk = HMI_LIB.FinsGW.uWrite_MEM_Data_WithErrcode(m_intLineCode, m_bKind, m_bNet(1), m_bNode(1), _
                                                                      m_bUnit(1), m_intWriteCarryAddress, length, _
                                                                      plcInteract.WriteCarryOutStatus(m_intLineCode, SERVER_CARRY_OUT_STATUS_WAITING), _
                                                                      m_ErrorTypeCarryOut, m_ErrorCodeCarryOut)
                If bWriteCarrOk Then
                    m_lastWriteCarryOutStatus = SERVER_CARRY_OUT_STATUS_WAITING
                    m_clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_PLC, TLogDat.LogLevel.NormalLog, Nothing, Now, " Line " + m_intLineCode.ToString + " Carry Out NG Complete at DM" & m_intWriteCarryAddress, m_strLineName)
                    logger.LogByLine(m_intLineCode, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "SendCarryOutComplete", " Line " + m_intLineCode.ToString + " Carry Out NG Complete at DM" & m_intWriteCarryAddress, "")
                    Me.ReportProgress(100)
                    Return True
                Else
                    m_clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_PLC, TLogDat.LogLevel.ErrorLog, Nothing, Now, " Line " + m_intLineCode.ToString + " Cannot Write Carry Out NG Complete To PLC at DM" & m_intWriteCarryAddress, m_strLineName)
                    logger.LogByLine(m_intLineCode, Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "SendCarryOutComplete", " Line " + m_intLineCode.ToString + " Cannot Write Carry Out NG Complete To PLC at DM" & m_intWriteCarryAddress, "")
                    m_blnIsConnected = False
                    m_strErrorMessage = OMRON.FinsGateway.Messaging.FINS.MemoryAreaWriteResponse.GetResponseMessage(m_ErrorCodeCarryOut(0))
                    Me.ReportProgress(0)
                    Return False
                End If
            End If

            taInstruction.FilNextCarryOutByLineNo(dtTempInst, lineNo)
            If dtTempInst.Rows.Count > 0 Then
                If m_lastWriteCarryOutStatus = SERVER_CARRY_OUT_STATUS_OK Then
                    dr = dtTempInst.Rows(0)

                    'TODO Get row above and below to check for InspIn
                    'If at first row get only record below
                    '****************************************
                    'If current record is InspIn
                    If dr.XchgFlag.Substring(2, 2) = "02" Then

                        WriteCarryOutComplete(dr)

                        'get next record
                        Dim dtNextInst As New ServerDataset.T_Instruction_DATDataTable
                        Dim drNext As ServerDataset.T_Instruction_DATRow
                        taInstruction.FillByNextInstructionRecord(dtNextInst, 1, dr.ProductionDate, dr.ProductionTime, dr.SeqNo, dr.SubSeq, lineNo)
                        If dtNextInst.Rows.Count > 0 Then
                            drNext = dtNextInst.Rows(0)

                            WriteCarryOutComplete(drNext)

                        End If

                    Else

                        'get previous record
                        Dim dtPreviousInst As New ServerDataset.T_Instruction_DATDataTable
                        Dim drPrevious As ServerDataset.T_Instruction_DATRow
                        taInstruction.FillByPrevInstructionRecord(dtPreviousInst, 0, dr.ProductionDate, dr.ProductionTime, dr.SeqNo, dr.SubSeq, lineNo)

                        If dtPreviousInst.Rows.Count > 0 Then
                            drPrevious = dtPreviousInst.Rows(0)

                            If drPrevious.XchgFlag.Substring(2, 2) = "02" Then
                                WriteCarryOutComplete(drPrevious)
                            End If

                        End If

                        WriteCarryOutComplete(dr)

                    End If

                    Return True
                    '****************************************

                    WriteCarryOutComplete(dr)

                ElseIf m_lastWriteCarryOutStatus = SERVER_CARRY_OUT_STATUS_NG Then
                    'plcCarryInterface.WritePlcDm(m_objFinsMsg, m_intWriteCarryAddress, plcInteract.WriteCarryOutStatus(m_intLineCode, SERVER_CARRY_OUT_STATUS_WAITING))
                    Dim length As UShort = WRITE_CARRY_OUT_STATUS
                    Dim bWriteCarrOk As Boolean

                    bWriteCarrOk = HMI_LIB.FinsGW.uWrite_MEM_Data_WithErrcode(m_intLineCode, m_bKind, m_bNet(1), m_bNode(1), _
                                                                          m_bUnit(1), m_intWriteCarryAddress, length, _
                                                                          plcInteract.WriteCarryOutStatus(m_intLineCode, SERVER_CARRY_OUT_STATUS_WAITING), _
                                                                          m_ErrorTypeCarryOut, m_ErrorCodeCarryOut)
                    If bWriteCarrOk Then
                        m_lastWriteCarryOutStatus = SERVER_CARRY_OUT_STATUS_WAITING
                        m_clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_PLC, TLogDat.LogLevel.NormalLog, Nothing, Now, " Line " + m_intLineCode.ToString + " Carry Out NG Complete at DM" & m_intWriteCarryAddress, m_strLineName)
                        logger.LogByLine(m_intLineCode, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "SendCarryOutComplete", " Line " + m_intLineCode.ToString + " Carry Out NG Complete at DM" & m_intWriteCarryAddress, "")
                        Me.ReportProgress(100)
                        Return True
                    Else
                        m_clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_PLC, TLogDat.LogLevel.ErrorLog, Nothing, Now, " Line " + m_intLineCode.ToString + " Cannot Write Carry Out NG Complete To PLC at DM" & m_intWriteCarryAddress, m_strLineName)
                        logger.LogByLine(m_intLineCode, Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "SendCarryOutComplete", " Line " + m_intLineCode.ToString + " Cannot Write Carry Out NG Complete To PLC at DM" & m_intWriteCarryAddress, "")
                        m_blnIsConnected = False
                        m_strErrorMessage = OMRON.FinsGateway.Messaging.FINS.MemoryAreaWriteResponse.GetResponseMessage(m_ErrorCodeCarryOut(0))
                        Me.ReportProgress(0)
                        Return False
                    End If
                Else
                    'Other Cases?
                End If
            Else
                'TODO Send aything?
                m_clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_PLC, TLogDat.LogLevel.WarningLog, Nothing, Now, "No Carry Out Waiting for Line " + m_intLineCode.ToString, m_strLineName)
                logger.LogByLine(m_intLineCode, Common.Logger.MessageType.WarningLog, Me.GetType.Name, "SendCarryOutComplete", "No Carry Out Waiting for Line " + m_intLineCode.ToString, "")
                m_blnIsConnected = False
                m_strErrorMessage = " Line " + m_intLineCode.ToString + "No Carry Out Schedule Remaining"
                Me.ReportProgress(0)
                Return False
            End If

        Catch ex As Exception
            m_blnIsConnected = False
            logger.LogByLine(m_intLineCode, Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "SendCarryOutComplete", ex.Message, ex.StackTrace)
            m_strErrorMessage = ex.Message


            Dim bWriteCarrOk As Boolean = False
            While Not bWriteCarrOk
                bWriteCarrOk = WriteCarryOutAbnormalCase()
                If bWriteCarrOk Then
                    logger.LogByLine(m_intLineCode, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "SendCarryOutComplete", "WriteCarryOutAbnormalCase for Line " + m_intLineCode.ToString & " at DM" & m_intWriteCarryAddress, "")
                Else
                    logger.LogByLine(m_intLineCode, Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "SendCarryOutComplete", "WriteCarryOutAbnormalCase for Line " + m_intLineCode.ToString + " Failed at DM" & m_intWriteCarryAddress, "")
                    Threading.Thread.Sleep(TimeSpan.FromMilliseconds(300))
                End If
                Me.ReportProgress(0)
            End While
            Return False

        End Try

        Return flag
    End Function

    Private Sub WriteCarryOutComplete(ByVal dr As ServerDataset.T_Instruction_DATRow)

        Dim taInstruction As New ServerDatasetTableAdapters.T_Instruction_DATTableAdapter

        dr.CarrResult = Now
        Dim intResult = taInstruction.Update(dr)
        Dim prodResult As Integer = 0
        If intResult > 0 Then
            'plcCarryInterface.WritePlcDm(m_objFinsMsg, m_intWriteCarryAddress, plcInteract.WriteCarryOutStatus(m_intLineCode, SERVER_CARRY_OUT_STATUS_WAITING))
            Dim length As UShort = WRITE_CARRY_OUT_STATUS
            Dim bWriteCarrOk As Boolean

            bWriteCarrOk = HMI_LIB.FinsGW.uWrite_MEM_Data_WithErrcode(m_intLineCode, m_bKind, m_bNet(1), m_bNode(1), _
                                                                  m_bUnit(1), m_intWriteCarryAddress, length, _
                                                                  plcInteract.WriteCarryOutStatus(m_intLineCode, SERVER_CARRY_OUT_STATUS_WAITING), _
                                                                  m_ErrorTypeCarryOut, m_ErrorCodeCarryOut)
            If bWriteCarrOk Then
                m_lastWriteCarryOutStatus = SERVER_CARRY_OUT_STATUS_WAITING
                m_clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_PLC, TLogDat.LogLevel.NormalLog, Nothing, Now, "ModelYear " + dr.ModelYear + " SuffixCode " + dr.SuffixCode + " LotNo " + dr.LotNo + " Line " + m_intLineCode.ToString + " Carry Out Complete at DM" & m_intWriteCarryAddress, m_strLineName)
                prodResult = CheckProdInstructFlag(dr.ModelYear, dr.SuffixCode, dr.LotNo, dr.Unit)
                logger.LogByLine(m_intLineCode, Common.Logger.MessageType.NormalLog, Me.GetType.Name, "SendCarryOutComplete", "ModelYear " + dr.ModelYear + " SuffixCode " + dr.SuffixCode + " LotNo " + dr.LotNo + " Line " + m_intLineCode.ToString + " Carry Out Complete at DM" & m_intWriteCarryAddress, "")
                Me.ReportProgress(100)
                'Return True
            Else
                m_clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_PLC, TLogDat.LogLevel.ErrorLog, Nothing, Now, "ModelYear " + dr.ModelYear + " SuffixCode " + dr.SuffixCode + " LotNo " + dr.LotNo + " Line " + m_intLineCode.ToString + " Cannot Write Carry Out Complete To PLC at DM" & m_intWriteCarryAddress, m_strLineName)
                logger.LogByLine(m_intLineCode, Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "SendCarryOutComplete", "ModelYear " + dr.ModelYear + " SuffixCode " + dr.SuffixCode + " LotNo " + dr.LotNo + " Line " + m_intLineCode.ToString + " Cannot Write Carry Out Complete To PLC at DM" & m_intWriteCarryAddress, "")
                m_blnIsConnected = False
                m_strErrorMessage = OMRON.FinsGateway.Messaging.FINS.MemoryAreaWriteResponse.GetResponseMessage(m_ErrorCodeCarryOut(0))
                Me.ReportProgress(0)
                'Return False
            End If
        Else
            m_clsTLogDat.InsertNewLog(TLogDat.LOG_TYPE_PLC, TLogDat.LogLevel.ErrorLog, Nothing, Now, "ModelYear " + dr.ModelYear + " SuffixCode " + dr.SuffixCode + " LotNo " + dr.LotNo + " Line " + m_intLineCode.ToString + " Cannot Write Carry Out Result To Database", m_strLineName)
            logger.LogByLine(m_intLineCode, Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "SendCarryOutComplete", "ModelYear " + dr.ModelYear + " SuffixCode " + dr.SuffixCode + " LotNo " + dr.LotNo + " Line " + m_intLineCode.ToString + " Cannot Write Carry Out Result To Database", "")
            m_blnIsConnected = False
            m_strErrorMessage = "ModelYear " + dr.ModelYear + " SuffixCode " + dr.SuffixCode + " LotNo " + dr.LotNo + " Line " + m_intLineCode.ToString + " Cannot Write Carry Out Result To Database"
            Me.ReportProgress(0)
            'Return False
        End If

    End Sub

    Public Function CheckProdInstructFlag(ByVal modelYear As String, ByVal suffixCode As String, ByVal lotNo As String, ByVal unit As String) As Integer
        Dim dtTempInst As New ServerDataset.T_Instruction_DATDataTable
        Dim drInst As ServerDataset.T_Instruction_DATRow
        Dim taInst As New ServerDatasetTableAdapters.T_Instruction_DATTableAdapter
        Dim dtTempProd As New ServerDataset.T_Production_DATDataTable
        Dim drProd As ServerDataset.T_Production_DATRow
        Dim taProd As New ServerDatasetTableAdapters.T_Production_DATTableAdapter
        Dim dtTempLine As New ServerDataset.T_Line_MSTDataTable
        Dim drLine As ServerDataset.T_Line_MSTRow
        Dim taLine As New ServerDatasetTableAdapters.T_Line_MSTTableAdapter
        Dim insNullCount As Integer = 0
        Dim blCabResult As Boolean = False
        Dim blPubxResult As Boolean = False
        'Try
        taLine.Fill(dtTempLine)
        taInst.FillByProdPk(dtTempInst, modelYear, suffixCode, lotNo, unit)

        'taProd.Fill(dtTempProd)
        'drProd = dtTempProd.FindByModelYearSuffixCodeLotNoUnit(modelYear, suffixCode, lotNo, unit)
        taProd.FillByPrimaryKey(dtTempProd, modelYear, suffixCode, lotNo, unit)
        drProd = dtTempProd.Rows(0)

        For index As Integer = 0 To dtTempInst.Rows.Count - 1
            drInst = dtTempInst.Rows(index)
            'If drInst.IsInsResultNull Then
            '    insNullCount += 1
            'End If

            drLine = dtTempLine.FindByLineCode(drInst.Line_No)
            If drLine.MainLineFlag And drLine.LineType = 1 And (Not drInst.IsCarrResultNull) Then
                blCabResult = True
            End If

            If drLine.MainLineFlag And drLine.LineType = 2 And (Not drInst.IsCarrResultNull) Then
                blPubxResult = True
            End If
        Next

        Dim intTempInstructFlag As Integer = 1  'Comment out following because it's not possible to write 0 drProd.InstructFlag
        'If insNullCount = dtTempInst.Rows.Count Then
        '    'drProd.InstructFlag = 0
        '    intTempInstructFlag = 1
        'ElseIf insNullCount < dtTempInst.Rows.Count Then
        '    'drProd.InstructFlag = 1
        '    intTempInstructFlag = 1
        'End If

        If drProd.IsYChassisFlagNull Or drProd.YChassisFlag = "0" Or drProd.YChassisFlag = "" Then
            If blCabResult And blPubxResult Then
                'drProd.InstructFlag = "2"
                intTempInstructFlag = 2
            End If
        ElseIf drProd.YChassisFlag = "1" Or drProd.YChassisFlag = "2" Then
            If blCabResult Then
                'drProd.InstructFlag = "2"
                intTempInstructFlag = 2
            End If
        ElseIf drProd.YChassisFlag = "3" Then
            If blPubxResult Then
                'drProd.InstructFlag = "2"
                intTempInstructFlag = 2
            End If
        End If

        Dim intResult As Integer = 0
        If drProd.InstructFlag <> intTempInstructFlag Then
            drProd.InstructFlag = intTempInstructFlag
            intResult = taProd.Update(drProd)
        End If
        Return intResult
        'Catch ex As Exception
        '    logger.LogByLine(m_intLineCode, Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "CheckProdInstFlag", ex.Message, ex.StackTrace)
        'End Try
    End Function

End Class

#End Region
