Public Class clsWBSProgressStateProcessing
    Inherits clsStateBase

#Region "Attribute"
    Private m_clsPlcCommunication As clsPlcCommunication
    Private m_strInstruction As String
    Private m_converter As System.Text.UTF8Encoding
    Private m_clsLog As New clsLogger
    Private m_clsDbLog As New clsDBLogger
#End Region

#Region "Constructor"

    Public Sub New(ByVal stageCode As Integer, ByVal currentStateCode As Integer, ByVal processNo As Integer, ByVal processName As String, ByVal memoryType As Byte, ByVal net As Integer, _
                       ByVal node As Integer, ByVal unit As Integer, ByVal readDataAddress As Integer, ByVal writeDataAddress As Integer, _
                       ByVal writeDMStatusAddress As Integer, ByVal entranceFlag As Boolean, ByVal writeDataLength As Integer, _
                       ByRef plcCommunicationThread As clsPlcCommunication, Optional ByVal sleepTimeInSec As Integer = 1)
        MyBase.New(stageCode, currentStateCode, processNo, processName, memoryType, net, node, unit, readDataAddress, writeDataAddress, writeDMStatusAddress, entranceFlag, writeDataLength)
        Me.m_clsPlcCommunication = plcCommunicationThread
        Me.m_converter = New System.Text.UTF8Encoding
        Me.m_strInstruction = String.Empty
    End Sub

#End Region

#Region "Method"

    Public Overrides Sub Process()
        m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "Process", "Start Function", "")
        GetData()
        SendInstructionToPLC()
        m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "Process", "End Function", "")
    End Sub

    Public Overrides Sub Initial(Optional ByVal inObj As Object = Nothing)

    End Sub

    Private Sub SendInstructionToPLC()
        m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "SendInstructionToPLC", "Start Function", "")
        Try
            Dim intSendDataLength As Integer = Me.m_intWriteDataLength
            Dim bytSendData((intSendDataLength * 2) - 1) As Byte

            bytSendData = Me.m_converter.GetBytes(Me.m_strInstruction)

            If Not WriteToPlc(intSendDataLength, bytSendData, 0, 200) Then
                Me.m_clsPlcCommunication.ReportProgress(0)
            End If
        Catch ex As Exception
            m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "SendInstructionToPLC", "Exception", ex.Message.ToString)
        End Try
        m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "SendInstructionToPLC", "End Function", "")
    End Sub

    Private Sub GetData()
        Dim taLaneMst As New dsPAINTTableAdapters.taLANE_MST
        Dim taProd As New dsPAINTTableAdapters.taPRODUCTION_DAT
        'Dim taSkit As New dsPAINTTableAdapters.taSKIT_MST
        Dim taWbs As New dsPAINTTableAdapters.taWBS_ON
        Dim dtProd As New dsPAINT.dtPRODUCTION_DATDataTable
        Dim dtLane As New dsPAINT.dtLANE_MSTDataTable
        'Dim dtSkit As New dsPAINT.dtSKIT_MSTDataTable
        Dim dtWbs As New dsPAINT.dtWBS_ONDataTable

        m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "GetData", "Start Function", "")
        Try
            Me.m_strInstruction = String.Empty
            
            If taLaneMst.Fill(dtLane) <= 0 Then
                'm_clsDbLog.Log(DB_LOG_CODE_E_PLC_WBSP_NO_LANE_DATA, Me.m_intProcessNo)
                m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "GetData", "Lane No not exist in master", "")
                Throw New Exception("No Lane Master Data")
            End If

            If taProd.Fill(dtProd) <= 0 Then
                'm_clsDbLog.Log(DB_LOG_CODE_E_PLC_WBSP_NO_PROD_DATA, Me.m_intProcessNo)
                m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "GetData", "No Production Data", "")
                Throw New Exception("No Production Data")
            End If

            'If taSkit.Fill(dtSkit) <= 0 Then
            '    'm_clsDbLog.Log(DB_LOG_CODE_E_PLC_WBSP_NO_SKIT_DATA, Me.m_intProcessNo)
            '    m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "GetData", "No Skit Exist", "")
            '    Throw New Exception("No Skit Master Data")
            'End If

            If taWbs.Fill(dtWbs) <= 0 Then
                'm_clsDbLog.Log(DB_LOG_CODE_E_PLC_WBSP_NO_WBS_ON_DATA, Me.m_intProcessNo)
                m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "GetData", "No Wbs On Data", "")
                Throw New Exception("No Wbs Data")
            End If

            Dim strLane As String
            Dim intLaneLength As Integer = PLC_WRITE_WBS_PROGRESS_PER_LANE_RECORD_COUNT * PLC_WRITE_WBS_PROGRESS_PER_RECORD_DATA_LENGTH
            Dim intLaneIndex As Integer
            For Each drl As dsPAINT.dtLANE_MSTRow In dtLane
                strLane = String.Empty
                Dim drWbsTemp() As dsPAINT.dtWBS_ONRow = dtWbs.Select("LANE_NO = " & drl.LANE_NO, "SEQUENCE")
                'Dim drSkitTemp As dsPAINT.dtSKIT_MSTRow
                Dim drProdTemp As dsPAINT.dtPRODUCTION_DATRow

                intLaneIndex = 0
                For Each drw As dsPAINT.dtWBS_ONRow In drWbsTemp
                    Dim strRecord As String = String.Empty
                    'drSkitTemp = dtSkit.FindBySKIT_NO(drw.SKIT_NO)
                    'If Not drSkitTemp.IsMODEL_YEARNull Then
                    drProdTemp = dtProd.FindByMODEL_YEARSUFFIX_CODELOT_NOUNIT(drw.MODEL_YEAR _
                                                                              , drw.SUFFIX_CODE _
                                                                              , drw.LOT_NO _
                                                                              , drw.UNIT)

                    If drProdTemp IsNot Nothing Then
                        strRecord &= drProdTemp.MODEL_YEAR
                        strRecord &= drProdTemp.SUFFIX_CODE
                        strRecord &= drProdTemp.LOT_NO
                        strRecord &= drProdTemp.UNIT
                        strRecord &= drProdTemp.GA_SHOP
                        'strRecord &= ("/" & " ".ToString(PLC_WRITE_ASCII_SKIT_NO_FORMAT)) _
                        '.PadRight(PLC_WRITE_ASCII_SKIT_NO_LENGTH, PLC_OPTION_DATA_PADDER)
                        strRecord &= " ".PadRight(PLC_WRITE_ASCII_SKIT_NO_LENGTH, PLC_OPTION_DATA_PADDER)
                    End If
                    'End If
                    strLane &= strRecord.PadRight(PLC_WRITE_WBS_PROGRESS_PER_RECORD_DATA_LENGTH, PLC_OPTION_DATA_PADDER)

                    intLaneIndex += 1
                    If intLaneIndex >= 10 Then
                        Exit For
                    End If
                Next

                Me.m_strInstruction &= strLane.PadRight(intLaneLength, PLC_OPTION_DATA_PADDER)
            Next

        Catch ex As Exception
            m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.ErrorLog, Me.GetType.Name, "GetData", "Exception", ex.Message.ToString)
        Finally
            If Me.m_strInstruction IsNot Nothing AndAlso Me.m_strInstruction <> String.Empty Then
                Me.m_strInstruction = Me.m_strInstruction.PadRight(PLC_WRITE_ASCII_WBS_PROGRESS_DATA_LENGTH, PLC_OPTION_DATA_PADDER)
            Else
                Me.m_strInstruction = PLC_OPTION_DATA_PADDER.PadRight(PLC_WRITE_ASCII_WBS_PROGRESS_DATA_LENGTH, PLC_OPTION_DATA_PADDER)
                m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "GetData", "No data to instruct", "")
            End If
        End Try

        m_clsLog.LogByLine(Me.m_clsPlcCommunication.StageCode, clsLogger.MessageType.NormalLog, Me.GetType.Name, "GetData", "End Function", "")
    End Sub

#End Region

End Class
