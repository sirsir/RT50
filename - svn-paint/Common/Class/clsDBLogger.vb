Public Class clsDBLogger

#Region "Constant"
    Private Const ERROR_INVLID_INPUT_LOG_ID As String = "DLOG/ERRO-90200"
    Private Const FORMAT_FOR_REPLACE_BY_STRING As String = "%s"
    Private Const FORMAT_FOR_REPLACE_BY_INTEGER As String = "%d"
    Private Const FORMAT_FOR_REPLACE_BY_DOUBLE As String = "%f"
    Private Const LENGTH_OF_REPLACE_FORMAT As Integer = 2
    Private Const LENGTH_OF_NUMBER_CODE As Integer = 5

    Public Const DB_LOG_TYPE_AS400 As Integer = 1
    Public Const DB_LOG_TYPE_PLC As Integer = 2
    Public Const DB_LOG_TYPE_OPERATION As Integer = 3
    Public Const DB_LOG_TYPE_PROGRAMMING As Integer = 9
    Public Const DB_LOG_LEVEL_NORMAL As Integer = 0
    Public Const DB_LOG_LEVEL_WARNING As Integer = 1
    Public Const DB_LOG_LEVEL_ERROR As Integer = 2
#End Region

#Region "Attribute"
    Private m_strLogId As String
    Private m_strOccurDate As String
    Private m_strMessage As String
    Private m_intProcessNo As Integer
    Private m_listClsDBLogger As New List(Of clsDBLogger)
    Private m_taT_Log_Dat As New dsPAINTTableAdapters.taLOG_DAT
    Private m_clsLogger As clsLogger
#End Region

#Region "Constructor"
    Public Sub New()
        m_strLogId = String.Empty
        m_strOccurDate = Nothing
        m_strMessage = String.Empty
        m_intProcessNo = -1
        m_clsLogger = New clsLogger
    End Sub
#End Region

#Region "Property"

    Public ReadOnly Property LogType() As Integer
        Get
            Dim intLogType As Integer = -1
            If m_strLogId <> String.Empty And m_strMessage <> String.Empty Then
                intLogType = CInt(m_strLogId.Substring(m_strLogId.Length - LENGTH_OF_NUMBER_CODE, 1))
            End If

            Return IIf(CheckExistLogType(intLogType), intLogType, -1)
        End Get
    End Property

    Public ReadOnly Property LogLevel() As Integer
        Get
            Dim intLogLevel As Integer = -1
            If m_strLogId <> String.Empty And m_strMessage <> String.Empty Then
                intLogLevel = CInt(m_strLogId.Substring(m_strLogId.Length - LENGTH_OF_NUMBER_CODE + 2, 1))
            End If

            Return IIf(CheckExistLogLevel(intLogLevel), intLogLevel, -1)
        End Get
    End Property

    Public ReadOnly Property PCName() As String
        Get
            Return My.Computer.Name.ToString
        End Get
    End Property

    Public ReadOnly Property OccurDate() As Date
        Get
            Return m_strOccurDate
        End Get
    End Property

    Public ReadOnly Property LogCode() As String
        Get
            Return m_strLogId
        End Get
    End Property

    Public ReadOnly Property Message() As String
        Get
            Return m_strMessage
        End Get
    End Property

    Public ReadOnly Property ProcessNo() As Integer
        Get
            Return m_intProcessNo
        End Get
    End Property

#End Region

#Region "Method"

    Public Function SetParam(ByVal strLogId As String, ByVal intProcessNo As Integer, ByVal ParamArray aMsgParam() As Object) As clsDBLogger
        Dim strLogMessage As String
        Dim blnInvalidInput As Boolean = False
        Dim clsDBLogger As New clsDBLogger

        strLogMessage = GetMessageByLogId(strLogId)
        If strLogMessage <> String.Empty Then
            clsDBLogger.m_strLogId = strLogId
            clsDBLogger.m_strOccurDate = Date.Now
            clsDBLogger.m_strMessage = ConvertInputToMessage(strLogMessage, aMsgParam)

            If clsDBLogger.m_strMessage = String.Empty Then
                blnInvalidInput = True
            End If

            If Not IsNothing(intProcessNo) Then
                clsDBLogger.m_intProcessNo = intProcessNo
            End If
        Else
            blnInvalidInput = True
        End If

        If blnInvalidInput Then
            clsDBLogger.m_strLogId = ERROR_INVLID_INPUT_LOG_ID
            clsDBLogger.m_strOccurDate = Date.Now
            clsDBLogger.m_strMessage = "Log ID : " & strLogId & " " & GetMessageByLogId(ERROR_INVLID_INPUT_LOG_ID)
            Me.m_clsLogger.Log(clsLogger.MessageType.ErrorLog, Me.GetType.Name, "SetParam", clsDBLogger.m_strMessage, "")
        End If

        Return clsDBLogger
    End Function

    Public Sub Log(ByVal strLogId As String, ByVal intProcessNo As Integer, ByVal ParamArray aMsgParam() As Object)
        ClearLogList()
        Dim clsDBLogger As clsDBLogger = SetParam(strLogId, intProcessNo, aMsgParam)
        If Me IsNot Nothing Then
            m_listClsDBLogger.Add(clsDBLogger)
            Me.SaveDbLog()
        End If
    End Sub

    Public Sub AddLogList(ByVal strLogId As String, ByVal intProcessNo As Integer, ByVal ParamArray aMsgParam() As Object)
        Dim clsDBLogger As clsDBLogger = SetParam(strLogId, intProcessNo, aMsgParam)
        m_listClsDBLogger.Add(clsDBLogger)
    End Sub

    Public Sub ClearLogList()
        m_listClsDBLogger = New List(Of clsDBLogger)
    End Sub

    Public Sub SaveDbLog()
        Dim i As Integer
        Dim dt As New dsPAINT.dtLOG_DATDataTable
        Dim dr As dsPAINT.dtLOG_DATRow

        For i = 0 To m_listClsDBLogger.Count - 1
            If m_listClsDBLogger(i) IsNot Nothing Then
                dr = dt.NewdtLOG_DATRow
                SetDataRowByObject(dr, m_listClsDBLogger(i))
                dt.AdddtLOG_DATRow(dr)
            End If
        Next

        Try
            Dim intResult As Integer = m_taT_Log_Dat.Update(dt)
        Catch ex As Exception
            m_clsLogger.Log(clsLogger.MessageType.ErrorLog, "DBLogger", "SaveDbLog", "Exception", ex.Message.ToString)
        End Try

        ClearLogList()
    End Sub

    Private Function GetMessageByLogId(ByVal strLogId As String) As String
        Dim strMessage As String = String.Empty
        Dim dr As dsPAINT.dtMESSAGE_MSTRow
        If modLoadData.LogMessageMasterDataTable Is Nothing OrElse modLoadData.LogMessageMasterDataTable.Count <= 0 Then
            modLoadData.LoadLogMessageMaster()
        End If

        dr = modLoadData.LogMessageMasterDataTable.FindByLOG_CODE(strLogId)

        If dr IsNot Nothing Then
            strMessage = dr.LOG_MESSAGE
        End If

        Return strMessage
    End Function

    Private Function ConvertInputToMessage(ByVal strMessageTemplate As String, ByVal aMsgParam() As Object) As String
        Dim strCurReplaceFormat As String
        Dim indexOfPercent As Integer
        Dim strMsgInFrontOfReplaceSign As String
        Dim strMsgBehindReplaceSign As String
        Dim i As Integer

        For i = 0 To aMsgParam.Length - 1
            indexOfPercent = strMessageTemplate.IndexOf("%", indexOfPercent)
            If indexOfPercent > 0 Then
                strCurReplaceFormat = strMessageTemplate.Substring(indexOfPercent, LENGTH_OF_REPLACE_FORMAT)
                If CheckIsReplaceFormat(strCurReplaceFormat) Then
                    If (TypeOf aMsgParam(i) Is String And strCurReplaceFormat = FORMAT_FOR_REPLACE_BY_STRING) _
                        Or (TypeOf aMsgParam(i) Is Integer And strCurReplaceFormat = FORMAT_FOR_REPLACE_BY_INTEGER) _
                        Or (TypeOf aMsgParam(i) Is Double And strCurReplaceFormat = FORMAT_FOR_REPLACE_BY_DOUBLE) _
                    Then
                        strMsgInFrontOfReplaceSign = strMessageTemplate.Substring(0, indexOfPercent + strCurReplaceFormat.Length)
                        strMsgBehindReplaceSign = strMessageTemplate.Substring(indexOfPercent + strCurReplaceFormat.Length, strMessageTemplate.Length - (indexOfPercent + strCurReplaceFormat.Length))
                        strMsgInFrontOfReplaceSign = strMsgInFrontOfReplaceSign.Replace(strCurReplaceFormat, aMsgParam(i).ToString)
                        strMessageTemplate = strMsgInFrontOfReplaceSign + strMsgBehindReplaceSign
                    End If
                End If
            Else
                strMessageTemplate = String.Empty
                GoTo ExitPoint
            End If
        Next

        If Not CheckIsMessageOutputCorrect(strMessageTemplate) Then
            strMessageTemplate = String.Empty
        End If

ExitPoint:
        Return strMessageTemplate
    End Function

    Private Function CheckIsReplaceFormat(ByVal strFormat As String) As Boolean
        If strFormat = FORMAT_FOR_REPLACE_BY_STRING _
            Or strFormat = FORMAT_FOR_REPLACE_BY_INTEGER _
            Or strFormat = FORMAT_FOR_REPLACE_BY_DOUBLE _
        Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function CheckIsMessageOutputCorrect(ByVal strMsg) As Boolean
        Dim blnResult As Boolean = True
        Dim indexOfPercent As Integer
        Dim strCurReplaceFormat As String

        indexOfPercent = strMsg.IndexOf("%", indexOfPercent)
        If indexOfPercent > 0 Then
            strCurReplaceFormat = strMsg.Substring(indexOfPercent, LENGTH_OF_REPLACE_FORMAT)

            If (strCurReplaceFormat = FORMAT_FOR_REPLACE_BY_STRING) _
                Or (strCurReplaceFormat = FORMAT_FOR_REPLACE_BY_INTEGER) _
                Or (strCurReplaceFormat = FORMAT_FOR_REPLACE_BY_DOUBLE) _
            Then
                blnResult = False
            End If
        End If

        Return blnResult
    End Function

    Private Sub SetDataRowByObject(ByRef dr As dsPAINT.dtLOG_DATRow, ByVal clsDBLogger As clsDBLogger)
        dr.LOG_TYPE = clsDBLogger.LogType
        dr.LOG_LEVEL = clsDBLogger.LogLevel
        dr.PC_NAME = clsDBLogger.PCName
        dr.OCC_DATE = clsDBLogger.OccurDate
        dr.LOG_CODE = clsDBLogger.LogCode
        dr.MESSAGE = clsDBLogger.Message
        If clsDBLogger.ProcessNo > 0 Then
            dr.PROCESS_NO = clsDBLogger.ProcessNo
        End If
    End Sub

    Private Function CheckExistLogType(ByVal intLogType As Integer) As Boolean
        If intLogType = DB_LOG_TYPE_AS400 _
            Or intLogType = DB_LOG_TYPE_PLC _
            Or intLogType = DB_LOG_TYPE_OPERATION _
            Or intLogType = DB_LOG_TYPE_PROGRAMMING _
        Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function CheckExistLogLevel(ByVal intLogLevel As Integer) As Boolean
        If intLogLevel = DB_LOG_LEVEL_NORMAL _
            Or intLogLevel = DB_LOG_LEVEL_WARNING _
            Or intLogLevel = DB_LOG_LEVEL_ERROR _
        Then
            Return True
        Else
            Return False
        End If
    End Function

#End Region

End Class
