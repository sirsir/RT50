﻿'Imports Common

Module addhost
    Sub Main()
        'Dim clsLogger As New Logger
        'clsLogger.Log(Logger.MessageType.NormalLog, "addhost", "Main", "addhost start", "")
        Try
            'Shell("setHost.bat", AppWinStyle.Hide, True)
            addHost()
            'clsLogger.Log(Logger.MessageType.NormalLog, "addhost", "Main", "addhost end", "")
        Catch ex As Exception
            'clsLogger.Log(Logger.MessageType.NormalLog, "addhost", "Main", ex.StackTrace, "")
        End Try
    End Sub

    Private Sub addHost()
        Const fileRead As Integer = 1
        Const fileWrite As Integer = 2
        'Const fileAppend As Integer = 8
        Const SPACES As Integer = 20

        Dim objFSO, objFlagFile
        Dim strLine, strNewHostFile, strNewHostLine, _
           strComment, bFound, bOmitRemainder, arrHostEnteries, i
        Dim Seps(2)

        Dim nNameLen
        Dim nAddSpaces

        Seps(0) = " "
        Seps(1) = vbTab

        bFound = False
        bOmitRemainder = False

        strComment = ""
        strNewHostFile = ""
        strNewHostLine = ""

        'Shell = WScript.CreateObject("WScript.Shell")
        Dim windowsdir As String
        Dim strHostFile As String
        Dim strHost As String
        Dim strIp As String

        windowsdir = Environment.GetEnvironmentVariable("SystemRoot")
        strHostFile = windowsdir & "\system32\drivers\etc\hosts"
        strHost = "pis-server"
        strIp = "192.148.1.100"

        objFSO = CreateObject("Scripting.FileSystemObject")

        If objFSO.FileExists(strHostFile) Then

            objFlagFile = objFSO.OpenTextFile(strHostFile, fileRead)
            Do While Not objFlagFile.AtEndOfStream
                strLine = UCase(Trim(objFlagFile.ReadLine))
                If strLine <> "" And Left(strLine, 1) <> "#" Then
                    If InStr(strLine, "#") > 0 Then
                        strComment = " " & Right(strLine, _
                           Len(strLine) - InStr(strLine, "#") + 1)
                        strLine = Left(strLine, InStr(strLine, "#") - 1)
                    Else
                        strComment = ""
                    End If
                    arrHostEnteries = Tokenize(strLine, Seps)
                    If UBound(arrHostEnteries) > 0 Then
                        nNameLen = Len(arrHostEnteries(0))
                        nAddSpaces = SPACES - nNameLen
                        strNewHostLine = arrHostEnteries(0) & Space(nAddSpaces)
                        If arrHostEnteries(0) = UCase(Trim(strIP)) Then
                            'Check the entries for certain IP...
                            For i = (LBound(arrHostEnteries) + 1) _
                                     To (UBound(arrHostEnteries) - 1)
                                If arrHostEnteries(i) = UCase(Trim(strHost)) Then
                                    bFound = True
                                    strNewHostLine = strNewHostLine _
                                           & " " & UCase(Trim(strHost))
                                Else
                                    strNewHostLine = strNewHostLine _
                                             & " " & arrHostEnteries(i)
                                End If
                            Next

                            If Not bFound Then
                                strNewHostLine = strNewHostLine _
                                       & " " & UCase(Trim(strHost))
                                bFound = True
                            End If

                        Else 'Check if it exist in different IP ranges and remove them
                            If UBound(arrHostEnteries) = 1 Then
                                strNewHostLine = ""
                                strComment = ""
                            Else
                                For i = (LBound(arrHostEnteries) + 1) _
                                         To (UBound(arrHostEnteries) - 1)
                                    If arrHostEnteries(i) <> UCase(Trim(strHost)) Then
                                        strNewHostLine = strNewHostLine _
                                                 & " " & arrHostEnteries(i)
                                    ElseIf UBound(arrHostEnteries) = 2 Then
                                        strNewHostLine = ""
                                        strComment = ""
                                    End If
                                Next
                            End If
                        End If
                    End If
                    If strNewHostLine <> "" Then
                        strNewHostFile = strNewHostFile & _
                               strNewHostLine & strComment & vbCrLf
                    End If
                Else ' Comments and Blank Lines Added Here
                    strNewHostLine = strLine
                    strNewHostFile = strNewHostFile & strNewHostLine & vbCrLf
                End If
                strNewHostLine = ""
            Loop
            objFlagFile.Close()

            If Not bFound Then
                strNewHostLine = UCase(Trim(strIp)) & "       " _
                  & UCase(Trim(strHost)) & vbCrLf
                strNewHostFile = strNewHostFile & strNewHostLine
            End If

        Else ' File doesn't exist so create it and write
            strNewHostFile = UCase(Trim(strIP)) & _
                   "       " & UCase(Trim(strHost))
        End If

        objFlagFile = objFSO.OpenTextFile(strHostFile, fileWrite)
        objFlagFile.Write(strNewHostFile)
        objFlagFile.Close()


    End Sub

    Private Function Tokenize(ByVal TokenString, ByRef TokenSeparators())

        Dim NumWords, a(), i
        NumWords = 0

        Dim NumSeps
        NumSeps = UBound(TokenSeparators)

        Dim SepIndex, SepPosition As Integer
        Do
            SepPosition = 0
            SepIndex = -1

            For i = 0 To NumSeps - 1

                ' Find location of separator in the string
                Dim pos
                pos = InStr(TokenString, TokenSeparators(i))

                ' Is the separator present, and is it closest
                ' to the beginning of the string?
                If pos > 0 And ((SepPosition = 0) Or _
                         (pos < SepPosition)) Then
                    SepPosition = pos
                    SepIndex = i
                End If

            Next

            ' Did we find any separators?
            If SepIndex < 0 Then

                ' None found - so the token is the remaining string
                ReDim Preserve a(NumWords + 1)
                a(NumWords) = TokenString

            Else

                ' Found a token - pull out the substring
                Dim substr
                substr = Trim(Left(TokenString, SepPosition - 1))

                ' Add the token to the list
                ReDim Preserve a(NumWords + 1)
                a(NumWords) = substr

                ' Cutoff the token we just found
                Dim TrimPosition
                TrimPosition = SepPosition + Len(TokenSeparators(SepIndex))
                TokenString = Trim(Mid(TokenString, TrimPosition))

            End If

            NumWords = NumWords + 1
        Loop While (SepIndex >= 0)

        Tokenize = a

    End Function
End Module