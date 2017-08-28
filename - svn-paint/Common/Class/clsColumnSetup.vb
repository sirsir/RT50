Imports System.IO.File
Imports System.IO.StreamWriter
Imports System.IO

Public Class clsColumnSetup

    Private Const INI_FILE_NAME_COLUMN_SETUP As String = "ColumnSetUp.ini"
    Private Const INI_APP_NAME_COLUMN_SETUP As String = "ColumnSetUp"
    Private INI_KEY_SCREEN As String = ""


    Public Function writeInsColum(ByVal tbl As DataGridView, ByVal screen As String) As Boolean
        'UNUSED
        Dim oWrite As System.IO.StreamWriter
        Dim col As String = ""
        Dim inStr As String = ""
        oWrite = File.CreateText(Application.StartupPath + "\conf\column_" + screen + ".ini")


        Dim i As Integer
        For i = 1 To tbl.Columns.Count - 1

            oWrite.WriteLine(col)

        Next
        oWrite.Close()

    End Function

    Public Function chkInsColumIni(ByVal colCount As Integer, ByVal screen As String) As ArrayList
        'UNUSED
        Try
            Dim oRead As System.IO.StreamReader
            Dim colList As ArrayList = New ArrayList()
            oRead = File.OpenText(Application.StartupPath + "\conf\column_" + screen + ".ini")

            While Not oRead.EndOfStream
                colList.Add(oRead.ReadLine())
            End While
            oRead.Close()

            'set initial value

            'Dim i As Integer
            'Dim inStr As String = "50"
            'For i = 1 To colCount - 1
            '    inStr = inStr + ",50"
            'Next


            'INI_KEY_SCREEN = screen
            'Dim iniObj As IniFile = New IniFile()
            'Dim outStr As String = ""
            'outStr = iniObj.GetString(INI_APP_NAME_COLUMN_SETUP, INI_KEY_SCREEN, inStr, INI_FILE_NAME_COLUMN_SETUP)
            'Dim splitter() As String = Split(outStr, ",")

            Return colList

        Catch ex As Exception

            Dim oWrite As System.IO.StreamWriter
            Dim col As String = ""
            Dim colList As ArrayList = New ArrayList()

            oWrite = File.CreateText(Application.StartupPath + "\conf\column_" + screen + ".ini")
            Dim i As Integer

            For i = 0 To colCount - 1
                oWrite.WriteLine("50")
            Next
            oWrite.Close()

            'recursive
            colList = Me.chkInsColumIni(colCount, screen)

            Return colList
        End Try

    End Function

    Public Function setColumnIni(ByVal tbl As DataGridView, ByVal screen As String) As Boolean

        Dim col As String = ""
        Dim inStr As String = ""

        INI_KEY_SCREEN = screen
        inStr = tbl.Columns(0).Width.ToString()

        Dim i As Integer
        For i = 1 To tbl.Columns.Count - 1
            col = tbl.Columns(i).Width.ToString()
            inStr = inStr + "," + col
        Next

        Dim iniObj As clsIniFile = New clsIniFile

        Return iniObj.SetString(INI_APP_NAME_COLUMN_SETUP, INI_KEY_SCREEN, inStr, INI_FILE_NAME_COLUMN_SETUP)

    End Function

    Public Function getColumnIni(ByVal colCount As Integer, ByVal screen As String) As String()

        Dim i As Integer
        Dim inStr As String = "50"
        For i = 1 To colCount - 1
            inStr = inStr + ",50"
        Next


        INI_KEY_SCREEN = screen
        Dim iniObj As clsIniFile = New clsIniFile()
        Dim outStr As String = ""
        outStr = iniObj.GetString(INI_APP_NAME_COLUMN_SETUP, INI_KEY_SCREEN, inStr, INI_FILE_NAME_COLUMN_SETUP)

        Dim splitter() As String = Split(outStr, ",")

        Return splitter

    End Function

    Public Function isExistColumnIni(ByVal colCount As Integer, ByVal screen As String) As Boolean

        Dim i As Integer
        Dim inStr As String = "50"
        For i = 1 To colCount - 1
            inStr = inStr + ",50"
        Next


        INI_KEY_SCREEN = screen
        Dim iniObj As clsIniFile = New clsIniFile()
        Dim outStr As String = ""
        outStr = iniObj.GetString(INI_APP_NAME_COLUMN_SETUP, INI_KEY_SCREEN, inStr, INI_FILE_NAME_COLUMN_SETUP)

        If inStr = outStr Then
            Return False
        Else
            Dim splitter() As String = Split(outStr, ",")

            If splitter.Count = colCount Then
                Return True
            Else
                Return False
            End If
        End If

    End Function


End Class
