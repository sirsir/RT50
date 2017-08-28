Public Class clsPBRStateComplete
    Inherits clsStateBase

#Region "Attribute"
    Private m_clsPlcCommunication As clsPlcCommunication
    Private m_drSkitMst As dsPAINT.dtSKIT_MSTRow
    Private m_drProd As dsPAINT.dtPRODUCTION_DATRow
    Private m_clsLog As New clsLogger
    Private m_clsDbLog As New clsDBLogger
    Private m_converter As System.Text.UTF8Encoding
#End Region

#Region "Constructor"

    Public Sub New(ByVal stageCode As Integer, ByVal currentStateCode As Integer, ByVal processNo As Integer, ByVal processName As String, ByVal memoryType As Byte, ByVal net As Integer, _
                       ByVal node As Integer, ByVal unit As Integer, ByVal readDataAddress As Integer, ByVal writeDataAddress As Integer, _
                       ByVal writeDMStatusAddress As Integer, ByVal entranceFlag As Boolean, ByVal writeDataLength As Integer, _
                       ByRef plcCommunicationThread As clsPlcCommunication, Optional ByVal sleepTimeInSec As Integer = 1)
        MyBase.New(stageCode, currentStateCode, processNo, processName, memoryType, net, node, unit, readDataAddress, writeDataAddress, writeDMStatusAddress, entranceFlag, writeDataLength)
        Me.m_clsPlcCommunication = plcCommunicationThread
        Me.m_drSkitMst = Nothing
        Me.m_drProd = Nothing
        Dim dtPaintCell As New dsPAINT.dtPAINT_CELLDataTable
        Me.m_converter = New System.Text.UTF8Encoding
    End Sub

#End Region

#Region "Method"

    Public Overrides Sub Process()
        m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "Process", "Start Function", "")
        If Not Me.m_blnWorkDone Then
            m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "Process", "m_blnWorkDone = False", "")
            If Me.m_drSkitMst Is Nothing Then
                m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "Process", "State Complete Without Update DB(From No data or Error)", "")
                Me.Reply2ToPlc()
                Me.m_blnWorkDone = True
            Else
                m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "Process", "State Complete With Update DB(From Processing)", "")
                Dim intNextState As Integer = Me.UpdateToDb()
                If intNextState = PROCESS_STATUS_ID_COMPLETE Then
                    m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "Process", "Update To database OK", "")
                    If Not Me.m_clsPlcCommunication.EntranceFlag Then
                        Me.ExportFile()
                    End If
                    Me.Reply2ToPlc()
                    m_clsDbLog.Log(DB_LOG_CODE_N_PLC_PBRI_INSTRUCTION_COMPLETE, Me.m_intProcessNo, Me.m_drSkitMst.MODEL_YEAR _
                                                                                                 , Me.m_drSkitMst.SUFFIX_CODE _
                                                                                                 , Me.m_drSkitMst.LOT_NO _
                                                                                                 , Me.m_drSkitMst.UNIT _
                                                                                                 , Me.m_drSkitMst.SKIT_NO)
                    Me.m_blnWorkDone = True
                Else
                    m_clsDbLog.Log(DB_LOG_CODE_E_PLC_PBRI_INSTRUCTION_FAILED, Me.m_intProcessNo, Me.m_drSkitMst.MODEL_YEAR _
                                                                                               , Me.m_drSkitMst.SUFFIX_CODE _
                                                                                               , Me.m_drSkitMst.LOT_NO _
                                                                                               , Me.m_drSkitMst.UNIT _
                                                                                               , Me.m_drSkitMst.SKIT_NO)
                    Me.m_blnWorkDone = True
                    m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "Process", "Update to database failed", "")
                    Dim initialParam As New ArrayList
                    initialParam.Add(0)     'SkidNo.
                    initialParam.Add(PLC_WRITE_STATUS_ERROR_PREFIX_ERROR)
                    Me.m_clsPlcCommunication.m_clsStateError.Initial(initialParam)
                    Me.m_clsPlcCommunication.SetState(Me.m_clsPlcCommunication.m_clsStateError)
                    Me.m_clsPlcCommunication.ForceToProcessCurrentState()
                End If
            End If
        Else
            m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "Process", "m_blnWorkDone = True", "")
            Dim intReadStatus = Me.ReadPlcStatus()
            If intReadStatus = PLC_READ_STATUS_WAITING Then
                m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "Process", "Read PLC Status : Waiting, Go to waiting state", "")
                Me.m_clsPlcCommunication.SetState(Me.m_clsPlcCommunication.m_clsStateWaiting)
                Me.m_clsPlcCommunication.ForceToProcessCurrentState()
            ElseIf intReadStatus = PLC_READ_STATUS_SAME_STATUS Then
                'DO NOTHING
            ElseIf intReadStatus = PLC_READ_STATUS_READ_FAILED Then
                'DO NOTHING
            ElseIf intReadStatus = PLC_READ_STATUS_INVALID_STAGE_CODE Then
                m_clsDbLog.Log(DB_LOG_CODE_E_PLC_PBRI_INVALID_STAGE_CODE, Me.m_intProcessNo)
                m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "Process", "Read PLC Status : Invalid stage code, Go to error state", "")
                Dim initialParam As New ArrayList
                initialParam.Add(0)     'SkidNo.
                initialParam.Add(PLC_WRITE_STATUS_ERROR_PREFIX_STAGE_CODE_INVALID)
                Me.m_clsPlcCommunication.m_clsStateError.Initial(initialParam)
                Me.m_clsPlcCommunication.SetState(Me.m_clsPlcCommunication.m_clsStateError)
                Me.m_clsPlcCommunication.ForceToProcessCurrentState()
            Else
                m_clsDbLog.Log(DB_LOG_CODE_E_PLC_PBRI_INVALID_REQ_STATUS, Me.m_intProcessNo)
                m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "Process", "Read PLC Status : Other, Go to error state", "")
                Dim initialParam As New ArrayList
                initialParam.Add(0)     'SkidNo.
                initialParam.Add(PLC_WRITE_STATUS_ERROR_PREFIX_STATUS_CODE_INVALID)
                Me.m_clsPlcCommunication.m_clsStateError.Initial(initialParam)
                Me.m_clsPlcCommunication.SetState(Me.m_clsPlcCommunication.m_clsStateError)
                Me.m_clsPlcCommunication.ForceToProcessCurrentState()
            End If
        End If
        m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "Process", "End Function", "")
    End Sub

    Public Overrides Sub Initial(Optional ByVal inObj As Object = Nothing)
        If inObj Is Nothing Then
            Me.m_drSkitMst = Nothing
            Me.m_drProd = Nothing
        Else
            Dim inputParam As ArrayList = DirectCast(inObj, ArrayList)
            If inputParam.Count = 2 Then
                Me.m_drSkitMst = DirectCast(inputParam(0), dsPAINT.dtSKIT_MSTRow)
                Me.m_drProd = DirectCast(inputParam(1), dsPAINT.dtPRODUCTION_DATRow)
            Else
                Me.m_drSkitMst = Nothing
                Me.m_drProd = Nothing
            End If
        End If
    End Sub

    Private Function UpdateToDb() As Integer

        Try
            Using ts As New TransactionScope
                Dim taT_Paint_Cell As New dsPAINTTableAdapters.taPAINT_CELL
                Dim taSkitMst As New dsPAINTTableAdapters.taSKIT_MST
                Dim intResult As Integer

                intResult = taT_Paint_Cell.Insert(Me.m_drSkitMst.MODEL_YEAR _
                                                  , Me.m_drSkitMst.SUFFIX_CODE _
                                                  , Me.m_drSkitMst.LOT_NO _
                                                  , Me.m_drSkitMst.UNIT _
                                                  , Me.m_intProcessNo _
                                                  , Date.Now)
                If intResult > 0 Then
                    m_clsLog.LogByLine(Me.m_intStageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "UpdateToDb", "Add new paint cell success", "")
                Else
                    m_clsLog.LogByLine(Me.m_intStageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "UpdateToDb", "Add new paint cell failed", "")
                    Return PROCESS_STATUS_ID_ERROR
                End If

                If Not Me.m_clsPlcCommunication.EntranceFlag AndAlso intResult > 0 Then
                    intResult = taSkitMst.Update(Nothing, Nothing, Nothing, Nothing, _
                                                 Me.m_drSkitMst.SKIT_NO, _
                                                 Me.m_drSkitMst.MODEL_YEAR, _
                                                 Me.m_drSkitMst.SUFFIX_CODE, _
                                                 Me.m_drSkitMst.LOT_NO, _
                                                 Me.m_drSkitMst.UNIT)
                    If intResult > 0 Then
                        m_clsLog.LogByLine(Me.m_intStageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "UpdateToDb", "Clear skit master success", "")
                    Else
                        m_clsLog.LogByLine(Me.m_intStageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "UpdateToDb", "Clear skit master failed", "")
                        Return PROCESS_STATUS_ID_ERROR
                    End If
                End If

                If intResult > 0 Then
                    ts.Complete()

                    Me.m_blnWorkDone = True
                    m_clsLog.LogByLine(Me.m_intStageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "UpdateToDb", "Update to database success", "")
                    Return PROCESS_STATUS_ID_COMPLETE
                Else
                    m_clsLog.LogByLine(Me.m_intStageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "UpdateToDb", "Update to database failed", "")
                    Return PROCESS_STATUS_ID_ERROR
                End If
            End Using
        Catch ex As Exception
            m_clsLog.LogByLine(Me.m_intStageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "UpdateToDb", "Exception", ex.Message.ToString)
            Return PROCESS_STATUS_ID_ERROR
        End Try
    End Function

    Private Function ReadPlcStatus() As Integer
        Dim blnResult As Boolean
        Dim intReadStatus As Integer
        Dim intReadStageCode As Integer
        Dim bytReadMessage((PLC_READ_STATUS_LENGTH * 2) - 1) As Byte

        m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "ReadPlcStatus", "Start Function", "")

        Try
            blnResult = ReadFromPlc(PLC_READ_STATUS_LENGTH, bytReadMessage)
            If blnResult Then
                intReadStageCode = OMRON.FinsGateway.PLCDataConverter.PLC2ByteAsBCDToSystemInteger(bytReadMessage, 0, 1)(0)
                intReadStatus = OMRON.FinsGateway.PLCDataConverter.PLC2ByteAsBCDToSystemInteger(bytReadMessage, 2, 1)(0)

                If intReadStageCode <> Me.m_intStageCode Then
                    Return PLC_READ_STATUS_INVALID_STAGE_CODE
                End If
            Else
                Me.m_clsPlcCommunication.ReportProgress(0)
                Return PLC_READ_STATUS_READ_FAILED
            End If
        Catch ex As Exception
            m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "ReadPlcStatus", "Exception", ex.Message.ToString)
            Return PROCESS_STATUS_ID_ERROR
        End Try

        If Not IsNewPlcMessage(intReadStatus, intReadStageCode) Then
            Return PLC_READ_STATUS_SAME_STATUS
        End If

        m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "ReadPlcStatus", "End Function", "")
        Return intReadStatus
    End Function

    Private Sub ExportFile()
        m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "ExportFile", "Start Function", "")

        If Me.m_drProd IsNot Nothing Then
            Dim objExport As clsExportFile
            objExport = New clsExportFile(Me.m_drProd, Me.m_intProcessNo)
            Dim strPath As String = modIni.ExportFilePath
            Dim strFileName As String = strPath & "\" & Date.Now.ToString("yyyyMMddHHmmss") & "_exp.txt"
            Try
                If Not Directory.Exists(strPath) Then
                    Directory.CreateDirectory(strPath)
                End If

                WriteFile(strFileName, objExport.ToString)
            Catch ex As Exception
                m_clsDbLog.Log(DB_LOG_CODE_E_PLC_PBRI_EXPORT_FILE_ERROR, Me.m_intProcessNo)
                m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "ExportFile", ex.Message, "")
            End Try
        End If

        m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "ExportFile", "End Function", "")
    End Sub

    Private Sub Reply2ToPlc()
        m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "Reply2ToPlc", "Start Function", "")

        Dim bytSendData(((PLC_READ_STATUS_LENGTH + PLC_WRITE_SKIT_NO_LENGTH) * 2) - 1) As Byte
        Dim bytClearData(((Me.m_intWriteDataLength - PLC_WRITE_STATUS_LENGTH - PLC_WRITE_SKIT_NO_LENGTH) * 2) - 1) As Byte

        bytSendData = OMRON.FinsGateway.PLCDataConverter.SystemIntegerToPLC2ByteAsBCD(Me.StageCode)
        ConcatByte(bytSendData, OMRON.FinsGateway.PLCDataConverter.SystemIntegerToPLC2ByteAsBCD(PLC_WRITE_STATUS_COMPLETE))
        If Me.m_drSkitMst IsNot Nothing Then
            ConcatByte(bytSendData, OMRON.FinsGateway.PLCDataConverter.SystemIntegerToPLC2ByteAsBCD(Me.m_drSkitMst.SKIT_NO))
        Else
            ConcatByte(bytSendData, OMRON.FinsGateway.PLCDataConverter.SystemIntegerToPLC2ByteAsBCD(0))
        End If
        'ConcatByte(bytSendData, bytClearData)
        ConcatByte(bytSendData, OMRON.FinsGateway.PLCDataConverter.SystemIntegerToPLC2ByteAsBCD(0))
        ConcatByte(bytSendData, Me.m_converter.GetBytes(" ".PadRight((Me.m_intWriteDataLength _
                        - PLC_WRITE_STATUS_LENGTH - PLC_WRITE_SKIT_NO_LENGTH - PLC_WRITE_LANE_NO_LENGTH) * 2)))
        'If Not WriteToPlc(Me.m_intWriteDataLength, bytSendData) Then
        '    Me.m_clsPlcCommunication.ReportProgress(0)
        'End If

        While Not WriteToPlc(Me.m_intWriteDataLength, bytSendData)
            Me.m_clsPlcCommunication.ReportProgress(0)
            Threading.Thread.Sleep(TimeSpan.FromSeconds(1))
        End While

        m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "Reply2ToPlc", "End Function", "")
    End Sub

#End Region

End Class
