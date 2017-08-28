Imports System.IO

Public Class ClsInstructionFormat

#Region "Constant"
    Public Const RECORD_TYPE_FORMAT_FAIL As Integer = -1
    Public Const RECORD_TYPE_END_OF_FILE As Integer = 4
    Public Const DATA_LENGTH As Integer = 202
    Public Const READ_STATUS_WAIT_FOR_HEADER_OR_EOF As Integer = 1
    Public Const READ_STATUS_WAIT_FOR_BODY_OR_TRAILER As Integer = 2
#End Region

#Region "Attribute"
    Private m_objClsHeader As ClsHeader
    Private m_listObjClsBody As List(Of ClsBody)
    Private m_objClsTrailer As ClsTrailer
    Private m_blnError As Boolean
#End Region

#Region "Constructor"

    Public Sub New()
        m_objClsHeader = Nothing
        m_listObjClsBody = New List(Of ClsBody)
        m_objClsTrailer = Nothing
        m_blnError = False
    End Sub

#End Region

#Region "Property"

    Public ReadOnly Property Header() As ClsHeader
        Get
            Return m_objClsHeader
        End Get
    End Property

    Public ReadOnly Property BodyList() As List(Of ClsBody)
        Get
            Return m_listObjClsBody
        End Get
    End Property

    Public ReadOnly Property Trailer() As ClsTrailer
        Get
            Return m_objClsTrailer
        End Get
    End Property

    Public ReadOnly Property IsError() As Boolean
        Get
            Return m_blnError
        End Get
    End Property

#End Region

#Region "Method"

    Public Shared Function GetListInstanceByFileName(ByVal strFileName As String) As List(Of ClsInstructionFormat)
        Dim strReadData As String
        Dim intReadedLineType As Integer
        Dim intCurrentReadStatus As Integer = READ_STATUS_WAIT_FOR_HEADER_OR_EOF
        Dim intBodyCount As Integer = 0
        Dim intCurrentReadLine As Integer = 0
        Dim sr As New StreamReader(strFileName)
        Dim tmpClsInstructionFormat As New ClsInstructionFormat
        Dim listClsInstructionFormatOutput As New List(Of ClsInstructionFormat)
        Dim clsDBLog As New clsDBLogger

        Try
            Do
                strReadData = sr.ReadLine()
                intReadedLineType = CheckFormat(strReadData)
                intCurrentReadLine += 1

                Select Case intCurrentReadStatus
                    Case READ_STATUS_WAIT_FOR_HEADER_OR_EOF
                        Select Case intReadedLineType
                            Case ClsHeader.RECORD_TYPE_HEADER
                                tmpClsInstructionFormat.m_objClsHeader = ClsHeader.ExtractToHeader(strReadData)
                                intCurrentReadStatus = READ_STATUS_WAIT_FOR_BODY_OR_TRAILER
                                Exit Select
                            Case ClsBody.RECORD_TYPE_BODY
                                clsDBLog.Log(DB_LOG_CODE_E_HEADER_MISSING, Nothing, strFileName)
                                tmpClsInstructionFormat.m_blnError = True
                                Exit Select
                            Case ClsTrailer.RECORD_TYPE_TRAILER
                                clsDBLog.Log(DB_LOG_CODE_E_HEADER_MISSING, Nothing, strFileName)
                                tmpClsInstructionFormat.m_blnError = True
                                Exit Select
                            Case RECORD_TYPE_END_OF_FILE
                                Exit Do
                            Case RECORD_TYPE_FORMAT_FAIL
                                If intCurrentReadLine = 1 Then
                                    clsDBLog.Log(DB_LOG_CODE_E_HEADER_MISSING, Nothing, strFileName)
                                End If
                                clsDBLog.Log(DB_LOG_CODE_E_INVALID_AT_RECORD, Nothing, _
                                                intCurrentReadLine, _
                                                strFileName, _
                                                IIf(IsNothing(tmpClsInstructionFormat.Header.CreationDate), _
                                                Format(tmpClsInstructionFormat.Header.CreationDate, "dd/MM/yyyy"), _
                                                Format(Date.Now, "dd/MM/yyyy")))
                                tmpClsInstructionFormat.m_blnError = True
                                Exit Select
                        End Select

                        Exit Select

                    Case READ_STATUS_WAIT_FOR_BODY_OR_TRAILER
                        Select Case intReadedLineType
                            Case ClsHeader.RECORD_TYPE_HEADER
                                clsDBLog.Log(DB_LOG_CODE_E_TRAIL_MISSING, Nothing, strFileName)
                                tmpClsInstructionFormat.m_blnError = True
                                Exit Select
                            Case ClsBody.RECORD_TYPE_BODY
                                tmpClsInstructionFormat.m_listObjClsBody.Add(ClsBody.ExtractToBody(strReadData))
                                intBodyCount += 1
                                Exit Select
                            Case ClsTrailer.RECORD_TYPE_TRAILER
                                tmpClsInstructionFormat.m_objClsTrailer = ClsTrailer.ExtractToTrailer(strReadData)
                                If tmpClsInstructionFormat.m_objClsTrailer.DataCount = intBodyCount Then
                                    listClsInstructionFormatOutput.Add(tmpClsInstructionFormat)
                                    tmpClsInstructionFormat = New ClsInstructionFormat
                                    intBodyCount = 0
                                    intCurrentReadStatus = READ_STATUS_WAIT_FOR_HEADER_OR_EOF
                                Else
                                    clsDBLog.Log(DB_LOG_CODE_E_MISMATCH_NUMBER_OF_RECORD, Nothing, _
                                                IIf(IsNothing(tmpClsInstructionFormat.Header.CreationDate), _
                                                Format(tmpClsInstructionFormat.Header.CreationDate, "dd/MM/yyyy"), _
                                                Format(Date.Now, "dd/MM/yyyy")), _
                                                strFileName)
                                    tmpClsInstructionFormat.m_blnError = True
                                End If
                                Exit Select
                            Case RECORD_TYPE_END_OF_FILE
                                clsDBLog.Log(DB_LOG_CODE_E_TRAIL_MISSING, Nothing, strFileName)
                                tmpClsInstructionFormat.m_blnError = True
                                Exit Select
                            Case RECORD_TYPE_FORMAT_FAIL
                                clsDBLog.Log(DB_LOG_CODE_E_INVALID_AT_RECORD, Nothing, _
                                                intCurrentReadLine, _
                                                strFileName, _
                                                IIf(IsNothing(tmpClsInstructionFormat.Header.CreationDate), _
                                                Format(tmpClsInstructionFormat.Header.CreationDate, "dd/MM/yyyy"), _
                                                Format(Date.Now, "dd/MM/yyyy")))
                                tmpClsInstructionFormat.m_blnError = True
                                Exit Select
                        End Select

                        Exit Select
                End Select

                If tmpClsInstructionFormat.m_blnError Then
                    listClsInstructionFormatOutput.Add(tmpClsInstructionFormat)
                    Exit Do
                End If
            Loop Until strReadData Is Nothing

            sr.Close()
        Catch ex As Exception
            sr.Close()
            tmpClsInstructionFormat = New ClsInstructionFormat
            clsDBLog.Log(DB_LOG_CODE_E_INVALID_AT_RECORD, Nothing, DB_LOG_CODE_E_ERROR_WHILE_IMPORT_FILE)
            tmpClsInstructionFormat.m_blnError = True
            listClsInstructionFormatOutput.Add(tmpClsInstructionFormat)
        End Try

        Return listClsInstructionFormatOutput
    End Function

    Private Shared Function CheckFormat(ByVal strData As String) As Integer
        If IsNothing(strData) Then
            Return RECORD_TYPE_END_OF_FILE
        ElseIf ClsHeader.CheckFormatHeader(strData) Then
            Return ClsHeader.RECORD_TYPE_HEADER
        ElseIf ClsBody.CheckFormatBody(strData) Then
            Return ClsBody.RECORD_TYPE_BODY
        ElseIf ClsTrailer.CheckFormatTrailer(strData) Then
            Return ClsTrailer.RECORD_TYPE_TRAILER
        ElseIf CheckEndOfFile(strData) Then
            Return RECORD_TYPE_END_OF_FILE
        Else
            Return RECORD_TYPE_FORMAT_FAIL
        End If
    End Function

    Private Shared Function CheckEndOfFile(ByVal strData As String) As Boolean
        If strData = "" Then
            Return True
        Else
            Return False
        End If
    End Function

#End Region

End Class
