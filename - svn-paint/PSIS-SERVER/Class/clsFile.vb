Imports System.IO

Public Class clsFile

#Region "Enumerator"
    Public Enum enuImportType
        manual
        as400
    End Enum
#End Region

#Region "Attribute"
    Private m_strFileName As String
    Private m_listClsInstructionFormat As List(Of ClsInstructionFormat)
    Private m_blnError As Boolean
    Private m_blnValidFile As Boolean
    Private m_blnValidAllFiles As Boolean
    Private m_clsDBLog As New clsDBLogger
    Private m_clsLog As New clsLogger
    Private m_intInsertCount As Integer
    Private m_intUpdateCount As Integer
    Private m_intSkipCount As Integer
    Private m_strLogFileSuffix As String
    Private m_enuImportType As enuImportType
#End Region

#Region "Property"
    Public ReadOnly Property IsValidFile() As Boolean
        Get
            Return m_blnValidAllFiles
        End Get
    End Property
#End Region

#Region "Constructor"

    Public Sub New(ByVal enuType As enuImportType)
        m_enuImportType = enuType
        If m_enuImportType = enuImportType.as400 Then
            m_strLogFileSuffix = IMPORT_EXE_LOG_SUFFIX
        Else
            m_strLogFileSuffix = ""
        End If
        m_strFileName = String.Empty
        m_listClsInstructionFormat = New List(Of ClsInstructionFormat)
        m_blnError = False
        m_blnValidFile = False
        m_blnValidAllFiles = False

    End Sub

#End Region

#Region "Method"

    Public Sub ImportFile(ByVal strImportPath As String, ByVal strBackupPathIn As String)
        Dim strBackupPath As String = strBackupPathIn & "\" & Format(Date.Now, "yyyyMMdd")
        Dim strTempToFileName As String
        Dim strPrefixBackupFileName As String
        Dim listFileName As List(Of String)
        Dim di As New IO.DirectoryInfo(strImportPath)
        Dim diBak As New IO.DirectoryInfo(strBackupPath)
        Dim theFile As FileStream
        
        If Not di.Exists Then
            di.Create()
        End If

        If Not diBak.Exists Then
            diBak.Create()
        End If

        Dim fileInf() As IO.FileInfo = di.GetFiles("*.*", SearchOption.AllDirectories)

        If fileInf.Length > 0 Then
            listFileName = New List(Of String)

            'Check File
            For Each inf As FileInfo In fileInf
                listFileName.Add(inf.FullName)
            Next

            'Move File
            strPrefixBackupFileName = Format(Date.Now, "yyyyMMddHHmmss")
            For i = 0 To listFileName.Count - 1
                strTempToFileName = strBackupPath + "\" + strPrefixBackupFileName + "_" + listFileName.Item(i).Substring(listFileName.Item(i).LastIndexOf("\") + 1, listFileName.Item(i).Length - listFileName.Item(i).LastIndexOf("\") - 1)
                MoveFile(listFileName.Item(i), strTempToFileName)
                listFileName.Item(i) = strTempToFileName
            Next

            'Create Object
            m_blnValidAllFiles = False
            While listFileName.Count > 0
                If m_enuImportType = enuImportType.as400 Then
                    m_clsDBLog.Log(DB_LOG_CODE_N_AS400_IMPORT_FILE_FOUND, Nothing)
                Else
                    m_clsDBLog.Log(DB_LOG_CODE_N_MANUAL_IMPORT_FILE_FOUND, Nothing)
                End If
                theFile = New FileStream(listFileName.Item(0), FileMode.Open, FileAccess.Read)
                Me.m_strFileName = listFileName.Item(0)
                Me.m_listClsInstructionFormat.Clear()

                If theFile.CanRead Then
                    m_blnValidFile = False
                    Me.m_listClsInstructionFormat = ClsInstructionFormat.GetListInstanceByFileName(Me.m_strFileName)

                    If Me.m_listClsInstructionFormat.Count > 0 Then
                        Me.m_blnError = Me.m_listClsInstructionFormat.Item(Me.m_listClsInstructionFormat.Count - 1).IsError
                    End If

                    Me.CheckDupKeyAndSaveToDB()

                    If m_enuImportType = enuImportType.as400 AndAlso m_blnValidFile Then
                        Shell(My.Application.Info.DirectoryPath & "\utlsend.bat", AppWinStyle.Hide, True, 3000)
                    End If
                Else
                    m_clsDBLog.Log(ModConstant.DB_LOG_CODE_E_CAN_NOT_READ_FILE, Nothing)
                    Me.m_blnError = True
                End If
                listFileName.RemoveAt(0)
            End While
        End If
    End Sub

    Private Sub MoveFile(ByVal fromFile As String, ByVal toFile As String)
        If System.IO.File.Exists(fromFile) = True Then
            If System.IO.File.Exists(toFile) = True Then
                System.IO.File.Delete(toFile)
            End If
            System.IO.File.Move(fromFile, toFile)
        End If
    End Sub

    Public Sub CheckDupKeyAndSaveToDB()
        Dim dtProductionData As New dsPAINT.dtPRODUCTION_DATDataTable
        Dim dtProductionDataDbResulted As New dsPAINT.dtPRODUCTION_DATDataTable
        Dim dtProductionDataDbNotResulted As New dsPAINT.dtPRODUCTION_DATDataTable
        Dim dtModelOptionRow As New dsPAINT.dtMODEL_OPTION_ROWDataTable
        Dim drModelOptionRow As dsPAINT.dtMODEL_OPTION_ROWRow
        Dim drProductionData As dsPAINT.dtPRODUCTION_DATRow
        Dim taProductionData As New dsPAINTTableAdapters.taPRODUCTION_DAT
        Dim taModelOptionRow As New dsPAINTTableAdapters.taMODEL_OPTION_ROW
        Dim taModelOptionCell As New dsPAINTTableAdapters.taMODEL_OPTION_CELL
        Dim strModelYearPattern As String
        Dim strSuffixCodePattern As String
        Dim blnNoData As Boolean = True
        Dim blnErrorDupKey As Boolean = False

        Me.m_intInsertCount = 0
        Me.m_intUpdateCount = 0
        Me.m_intSkipCount = 0

        m_clsLog.Log(clsLogger.MessageType.NormalLog, Me.GetType.Name, "CheckDupKeyAndSaveToDB", "Start", "", m_strLogFileSuffix)
        Try
            taProductionData.FillByNotResulted(dtProductionDataDbNotResulted)
            taProductionData.FillByResulted(dtProductionDataDbResulted)
            modLoadData.LoadModelOptionRow()
            For i As Integer = 0 To m_listClsInstructionFormat.Count - 1
                If Not Me.m_blnError _
                    And Me.m_listClsInstructionFormat.Item(i).Header IsNot Nothing _
                    And Me.m_listClsInstructionFormat.Item(i).BodyList.Count > 0 _
                    And Me.m_listClsInstructionFormat.Item(i).Trailer IsNot Nothing _
                Then
                    For j As Integer = 0 To Me.m_listClsInstructionFormat.Item(i).BodyList.Count - 1
                        If Not CheckDupPrimaryKeyInFile(dtProductionData, Me.m_listClsInstructionFormat.Item(i).BodyList.Item(j)) Then
                            'If Not CheckDupSecondaryKeyInFile(dtProductionData, Me.m_listClsInstructionFormat.Item(i).BodyList.Item(j)) Then

                            If Me.RecordIsInDbAndResulted(Me.m_listClsInstructionFormat.Item(i).BodyList.Item(j), dtProductionDataDbResulted) Then
                                blnNoData = False
                                Continue For
                            End If

                            If Me.RecordIsInDbAndNotResulted(Me.m_listClsInstructionFormat.Item(i).BodyList.Item(j), dtProductionDataDbNotResulted) Then
                                blnNoData = False
                                Continue For
                            End If

                            drProductionData = dtProductionData.NewdtPRODUCTION_DATRow

                            strModelYearPattern = Me.m_listClsInstructionFormat.Item(i).BodyList.Item(j).ModelYear
                            strSuffixCodePattern = Me.m_listClsInstructionFormat.Item(i).BodyList.Item(j).SuffixCode.Substring(0, 3) _
                                                    & "*" & _
                                                    Me.m_listClsInstructionFormat.Item(i).BodyList.Item(j).SuffixCode.Substring(4, 1)

                            If modLoadData.GetCountModelOptionRowByModelYearAndSuffixCodePattern(strModelYearPattern, strSuffixCodePattern) <= 0 Then
                                Dim strExpression As String = "MODEL_YEAR_PATTERN = '" & strModelYearPattern & "'" & _
                                                " AND SUFFIX_CODE_PATTERN = '" & strSuffixCodePattern & "'"

                                Dim drTemp As dsPAINT.dtMODEL_OPTION_ROWRow() = dtModelOptionRow.Select(strExpression)
                                If drTemp Is Nothing OrElse drTemp.Length = 0 Then
                                    drModelOptionRow = dtModelOptionRow.NewdtMODEL_OPTION_ROWRow
                                    drModelOptionRow.MODEL_YEAR_PATTERN = strModelYearPattern
                                    drModelOptionRow.SUFFIX_CODE_PATTERN = strSuffixCodePattern
                                    dtModelOptionRow.AdddtMODEL_OPTION_ROWRow(drModelOptionRow)
                                End If
                            End If

                            Me.m_listClsInstructionFormat.Item(i).BodyList.Item(j).ConvertObjectToDatarow(drProductionData, Me.m_strFileName)
                            dtProductionData.AdddtPRODUCTION_DATRow(drProductionData)
                            Me.m_intInsertCount += 1
                            blnNoData = False

                            'Else
                            '    m_clsDBLog.Log(DB_LOG_CODE_E_DUP_SECOND_KEY, Nothing, Me.m_strFileName, Format(Me.m_listClsInstructionFormat.Item(i).Header.CreationDate, "dd/MM/yyyy"))
                            '    m_clsLog.Log(Logger.MessageType.ErrorLog, Me.GetType.Name, "CheckDupKeyAndSaveToDB", "Dup SK in " & Me.m_strFileName & ", Header date : " & Format(Me.m_listClsInstructionFormat.Item(i).Header.CreationDate, "dd/MM/yyyy"), "")
                            '    blnErrorDupKey = True
                            '    Exit For
                            'End If
                        Else
                            m_clsDBLog.Log(DB_LOG_CODE_E_DUP_PRIMARY_KEY, Nothing, Me.m_strFileName, Format(Me.m_listClsInstructionFormat.Item(i).Header.CreationDate, "dd/MM/yyyy"))
                            m_clsLog.Log(clsLogger.MessageType.ErrorLog, Me.GetType.Name, "CheckDupKeyAndSaveToDB", "Dup PK in " & Me.m_strFileName & ", Header date : " & Format(Me.m_listClsInstructionFormat.Item(i).Header.CreationDate, "dd/MM/yyyy"), "", m_strLogFileSuffix)
                            blnErrorDupKey = True
                            Exit For
                        End If
                    Next
                End If
            Next

            If blnNoData Then
                m_clsLog.Log(clsLogger.MessageType.NormalLog, Me.GetType.Name, "CheckDupKeyAndSaveToDB", "No Data To Import", "", m_strLogFileSuffix)
            Else
                If Not blnErrorDupKey Then
                    m_blnValidFile = True
                    Try
                        Dim blnIsError As Boolean = False
                        Using ts As New TransactionScope
                            Dim intResult As Integer
                            If dtModelOptionRow.Count > 0 Then
                                intResult = taModelOptionRow.Update(dtModelOptionRow)
                                If intResult > 0 Then
                                    m_clsLog.Log(clsLogger.MessageType.NormalLog, Me.GetType.Name, "CheckDupKeyAndSaveToDB", "Add new Model Option Row Success", "", m_strLogFileSuffix)
                                Else
                                    m_clsLog.Log(clsLogger.MessageType.ErrorLog, Me.GetType.Name, "CheckDupKeyAndSaveToDB", "Add new Model Option Row Error, Import file process is canceled", "", m_strLogFileSuffix)
                                    blnIsError = True
                                End If

                                If Not blnIsError Then
                                    intResult = taModelOptionCell.InsertNewModelOptionCells()
                                    If intResult > 0 Then
                                        m_clsLog.Log(clsLogger.MessageType.NormalLog, Me.GetType.Name, "CheckDupKeyAndSaveToDB", "Add new Model Option Cells Success", "", m_strLogFileSuffix)
                                    Else
                                        m_clsLog.Log(clsLogger.MessageType.ErrorLog, Me.GetType.Name, "CheckDupKeyAndSaveToDB", "Add new Model Option Cells Error, Import file process is canceled", "", m_strLogFileSuffix)
                                        blnIsError = True
                                    End If
                                End If
                            End If

                            If Not blnIsError AndAlso Me.m_intUpdateCount > 0 Then
                                intResult = taProductionData.Update(dtProductionDataDbNotResulted)

                                If intResult > 0 Then
                                    m_clsLog.Log(clsLogger.MessageType.NormalLog, Me.GetType.Name, "CheckDupKeyAndSaveToDB", "Update records in DB Success", "", m_strLogFileSuffix)
                                Else
                                    m_clsLog.Log(clsLogger.MessageType.ErrorLog, Me.GetType.Name, "CheckDupKeyAndSaveToDB", "Update records in DB Error", "", m_strLogFileSuffix)
                                    blnIsError = True
                                End If
                            End If

                            If Not blnIsError AndAlso Me.m_intInsertCount > 0 Then
                                intResult = taProductionData.Update(dtProductionData)

                                If intResult <= 0 Then
                                    blnIsError = True
                                End If
                            End If

                            If Not blnIsError Then
                                ts.Complete()
                            End If
                        End Using

                        If Not blnIsError Then
                            m_clsDBLog.Log(DB_LOG_CODE_N_SHOW_IMPORT_RESULT, Nothing, Me.m_strFileName, _
                                           Me.m_intInsertCount + Me.m_intUpdateCount + Me.m_intSkipCount, _
                                           Me.m_intInsertCount, _
                                           Me.m_intUpdateCount, _
                                           Me.m_intSkipCount)
                            m_clsLog.Log(clsLogger.MessageType.NormalLog, Me.GetType.Name, "CheckDupKeyAndSaveToDB", "Import Success", "", m_strLogFileSuffix)
                        Else
                            m_clsLog.Log(clsLogger.MessageType.ErrorLog, Me.GetType.Name, "CheckDupKeyAndSaveToDB", "Import Error", "", m_strLogFileSuffix)
                        End If

                    Catch ex As Exception
                        m_clsDBLog.Log(DB_LOG_CODE_E_ERROR_WHILE_IMPORT_FILE, Nothing)
                        m_clsLog.Log(clsLogger.MessageType.ErrorLog, Me.GetType.Name, "CheckDupKeyAndSaveToDB", ex.Message.ToString, ex.StackTrace, m_strLogFileSuffix)
                    End Try

                End If
            End If
        Catch ex As Exception
            m_clsLog.Log(clsLogger.MessageType.ErrorLog, Me.GetType.Name, "CheckDupKeyAndSaveToDB", "Exception", ex.Message.ToString, m_strLogFileSuffix)
        End Try
        m_clsLog.Log(clsLogger.MessageType.NormalLog, Me.GetType.Name, "CheckDupKeyAndSaveToDB", "End", "", m_strLogFileSuffix)

    End Sub

    Private Function CheckDupPrimaryKeyInFile(ByVal dt As dsPAINT.dtPRODUCTION_DATDataTable, ByVal clsBody As ClsBody) As Boolean
        Return Not IsNothing(dt.FindByMODEL_YEARSUFFIX_CODELOT_NOUNIT(clsBody.ModelYear, clsBody.SuffixCode, clsBody.LotNo, clsBody.Unit))
    End Function

    Private Function CheckDupSecondaryKeyInFile(ByVal dt As dsPAINT.dtPRODUCTION_DATDataTable, ByVal clsBody As ClsBody) As Boolean
        Return dt.Select("PRODUCTION_DATE = '" & RTrim(clsBody.ProductionDate) _
                         & "' And ON_TIME = '" & RTrim(clsBody.OnTime) & "'").Count > 0
    End Function

    Private Function RecordIsInDbAndResulted(ByRef record As ClsBody, _
                                             ByRef dtInDbResulted As dsPAINT.dtPRODUCTION_DATDataTable)
        Dim dr As dsPAINT.dtPRODUCTION_DATRow = dtInDbResulted.FindByMODEL_YEARSUFFIX_CODELOT_NOUNIT(record.ModelYear, _
                                                                                                         record.SuffixCode, _
                                                                                                         record.LotNo, _
                                                                                                         record.Unit)
        If dr Is Nothing Then
            Return False
        End If

        Me.m_intSkipCount += 1
        Return True
    End Function

    Private Function RecordIsInDbAndNotResulted(ByRef record As ClsBody, _
                                             ByRef dtInDbNotResulted As dsPAINT.dtPRODUCTION_DATDataTable)
        Dim dr As dsPAINT.dtPRODUCTION_DATRow = dtInDbNotResulted.FindByMODEL_YEARSUFFIX_CODELOT_NOUNIT(record.ModelYear, _
                                                                                                         record.SuffixCode, _
                                                                                                         record.LotNo, _
                                                                                                         record.Unit)
        If dr Is Nothing Then
            Return False
        End If

        record.ConvertObjectToDatarow(dr, Me.m_strFileName)
        Me.m_intUpdateCount += 1
        Return True
    End Function

#End Region

End Class
