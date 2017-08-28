Public Module modFunction

#Region "Constant"

#End Region

#Region "Attribute"

#End Region

#Region "Constructor"

#End Region

#Region "Property"

#End Region

#Region "Method"

    Public Sub WriteFile(ByVal strFileName As String, _
                         ByVal strData As String)
        Try
            If File.Exists(strFileName) Then File.SetAttributes(strFileName, FileAttributes.Normal)

            Dim sw As StreamWriter = File.AppendText(strFileName)
            sw.WriteLine(strData)
            sw.Close()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub MergeExportFile(ByVal strMainFile As String, ByVal strMainPath As String)

        If Not Directory.Exists(strMainPath) Then Return

        Dim sw As StreamWriter = File.AppendText(strMainFile)
        Dim sr As StreamReader

        Try
            Dim di As New IO.DirectoryInfo(strMainPath)
            Dim fileInf() As FileInfo = di.GetFiles("*_exp.txt", SearchOption.AllDirectories)
            Dim listFileName As New List(Of String)
            Dim strReadLine As String
            Dim intDataNumber As Integer = 0
            Dim intDataSize As Integer = MODEL_CODE + LENGTH_OF_LOT_NO + LENGTH_OF_UNIT + _
                                         LENGTH_OF_BLOCK + LENGTH_OF_BLOCK_SEQ + TIMESTAMP + SPARE

            If fileInf.Length <= 0 Then Return
            Threading.Thread.Sleep(1000)
            For Each inf As FileInfo In fileInf
                listFileName.Add(inf.FullName)
            Next

            Dim sbData As New System.Text.StringBuilder

            ' '' ''FILE HEADER
            sbData.Append(TITLE_HEADER_NAME.ToString.PadRight(TITLE, " "))
            sbData.Append(_DATASET_NAME.ToString.PadRight(DATASET_NAME, " "))
            sbData.Append(Date.Now.ToString("yyyyMMdd").PadRight(_DATE, " "))
            sbData.Append(Date.Now.ToString("HHmmss").PadRight(TITLE, " "))
            sbData.Append(intDataSize.ToString.PadLeft(RECORD_SIZE, "0"))
            sbData.Append(BLOCK_SIZE_VALUE.ToString.PadLeft(BLOCK_SIZE, "0"))
            sbData.Append(String.Empty.PadRight(FILLER_HEADER, " "))
            sw.WriteLine(sbData.ToString)

            While listFileName.Count > 0
                sr = New StreamReader(listFileName(0))

                While sr IsNot Nothing
                    strReadLine = sr.ReadLine
                    If strReadLine Is Nothing OrElse strReadLine = String.Empty Then Exit While

                    sw.WriteLine(strReadLine)
                    intDataNumber += 1
                End While
                sr.Close()
                File.Delete(listFileName(0))
                listFileName.RemoveAt(0)
            End While

            ' '' ''FILE TRAILER
            sbData.Remove(0, sbData.Length)
            sbData.Append(TITLE_TRAILER_NAME.ToString.PadRight(TITLE, " "))
            sbData.Append(intDataNumber.ToString.PadLeft(DATA_NUMBER, "0"))
            sbData.Append(String.Empty.PadRight(FILLER_TRAILER, " "))
            sw.WriteLine(sbData.ToString)

        Catch ex As Exception

        Finally
            sw.Close()
            If (My.Computer.FileSystem.GetFileInfo(strMainFile)).Length <= 0 Then File.Delete(strMainFile)
        End Try
    End Sub

    Public Sub MergeErrorExportFile(ByVal strMainFile As String, _
                                    ByVal strMainPath As String, _
                                    ByVal strSubFile As String)

        Dim strTempFile As String = strMainPath + "\tempFile.txt"

        Try
            If Not File.Exists(strSubFile) Then Return

            If Not Directory.Exists(strMainPath) Then Return

            If File.Exists(strMainFile) Then File.Move(strMainFile, strTempFile)

            If File.Exists(strMainFile) Then File.Delete(strMainFile)

            Dim strReadLine As String
            Dim intDataNumber As Integer = 0
            Dim isFirstRow As Boolean = True
            Dim srMainFile As New StreamReader(strTempFile)
            Dim srSubFile As New StreamReader(strSubFile)
            Dim sw As StreamWriter = File.AppendText(strMainFile)

            While srMainFile IsNot Nothing
                strReadLine = srMainFile.ReadLine
                If strReadLine Is Nothing OrElse strReadLine = String.Empty Then
                    Exit While
                End If

                If strReadLine.Substring(0, TITLE) = (TITLE_HEADER_NAME.ToString.PadRight(TITLE, " ")).ToString Then
                    sw.WriteLine(strReadLine)
                ElseIf strReadLine.Substring(0, TITLE) = (TITLE_TRAILER_NAME.ToString.PadRight(TITLE, " ")).ToString Then
                    ' Nothing To do -> use trailer of sub file
                    Continue While
                Else
                    sw.WriteLine(strReadLine)
                    intDataNumber += 1
                End If
            End While
            srMainFile.Close()

            While srSubFile IsNot Nothing
                strReadLine = srSubFile.ReadLine
                If strReadLine Is Nothing Then
                    Exit While
                End If

                If strReadLine.Substring(0, TITLE) = (TITLE_HEADER_NAME.ToString.PadRight(TITLE, " ")).ToString Then
                    ' Nothing To do -> use header of main file
                    Continue While
                ElseIf strReadLine.Substring(0, TITLE) = (TITLE_TRAILER_NAME.ToString.PadRight(TITLE, " ")).ToString Then
                    Dim sbData As New System.Text.StringBuilder

                    sbData.Append(TITLE_TRAILER_NAME.ToString.PadRight(TITLE, " "))
                    sbData.Append(intDataNumber.ToString.PadLeft(DATA_NUMBER, "0"))
                    sbData.Append(String.Empty.PadRight(FILLER_TRAILER, " "))

                    strReadLine = sbData.ToString
                    sw.WriteLine(strReadLine)
                Else
                    sw.WriteLine(strReadLine)
                    intDataNumber += 1
                End If
            End While
            srSubFile.Close()
            sw.Close()

            File.Delete(strTempFile)
            File.Delete(strSubFile)
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Event"

#End Region

End Module
