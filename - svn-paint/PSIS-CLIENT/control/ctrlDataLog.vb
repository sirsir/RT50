Public Class ctrlDataLog

#Region "Attribute"
    Private m_objClsLogger As New clsLogger
    Private m_arrStrTabName As String() = {"AS400", "PLC", "Operation"}
    Private m_arrStrLogLevel As String() = {"Normal Log", "Warning Log", "Error Log"}
#End Region

#Region "Method"
    Public Sub DisplayScreen()
        Me.tabCtrlDataLog.SelectedIndex = 0
        TabCtrlDataLog_SelectedIndexChanged()
        SetBtnsOperator()
    End Sub

    Private Sub SetBtnsOperator()
        CtrlBtnsOperator1.F5 = True
        CtrlBtnsOperator1.F9 = True
        CtrlBtnsOperator1.F12 = True
    End Sub

    Private Sub SaveDataLog()
        saveFileDialog1.FileName = Date.Now.ToString("yyyyMMdd") & "_" & m_arrStrTabName(Me.tabCtrlDataLog.SelectedIndex)
        saveFileDialog1.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*"

        saveFileDialog1.ShowDialog()
        setDataGridColor()
    End Sub

    Private Sub saveFileDialog1_FileOk(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles saveFileDialog1.FileOk
        Dim dt As dsPAINT.dtLOG_DATDataTable
        Dim myStream As IO.Stream
        Dim sw As IO.StringWriter = New IO.StringWriter

        Try
            taLOG_DAT1.FillByLogType(dsPAINT1.dtLOG_DAT, Me.tabCtrlDataLog.SelectedIndex + 1)

            dt = dsPAINT1.dtLOG_DAT

            myStream = saveFileDialog1.OpenFile()
            If (myStream IsNot Nothing) Then
                'Code to write stream goes here.
                myStream.Close()
            End If

            sw.WriteLine("DATE,TIME,LOG_TYPE,LOG_LEVEL,PC_NAME,PROCESS_NAME,CONTENT")

            For Each row As dsPAINT.dtLOG_DATRow In dt.Rows
                Dim col As String = New String("{0},{1},{2},{3},{4},{5},{6}")

                col = String.Format(col, _
                                    row._DATE, _
                                    row.TIME, _
                                    m_arrStrTabName(Me.tabCtrlDataLog.SelectedIndex), _
                                    m_arrStrLogLevel(row.LOG_LEVEL), _
                                    row.PC_NAME, _
                                    IIf(row.PROCESS_NAME IsNot Nothing, row.PROCESS_NAME, String.Empty), _
                                    row.MESSAGE)

                sw.WriteLine(col)
            Next

            System.IO.File.WriteAllText(saveFileDialog1.FileName, sw.ToString())
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "saveFileDialog1_FileOk", ex, True)
        End Try
    End Sub

    Private Sub setDataGridColor()
        Select Case Me.tabCtrlDataLog.SelectedIndex
            Case 0
                For row As Integer = 0 To Me.dgvAS400Log.Rows.Count - 1
                    Select Case Me.dgvAS400Log.Rows(row).Cells("LogLevelAS400Log").Value
                        Case 1 : Me.dgvAS400Log.Rows(row).DefaultCellStyle.BackColor = Color.Yellow
                        Case 2 : Me.dgvAS400Log.Rows(row).DefaultCellStyle.BackColor = Color.Red
                    End Select
                Next
            Case 1
                For row As Integer = 0 To Me.dgvPLCLog.Rows.Count - 1
                    Select Case Me.dgvPLCLog.Rows(row).Cells("LogLevelPLCLog").Value
                        Case 1 : Me.dgvPLCLog.Rows(row).DefaultCellStyle.BackColor = Color.Yellow
                        Case 2 : Me.dgvPLCLog.Rows(row).DefaultCellStyle.BackColor = Color.Red
                    End Select
                Next
            Case 2
                For row As Integer = 0 To Me.dgvOperatLog.Rows.Count - 1
                    Select Case Me.dgvOperatLog.Rows(row).Cells("LogLevelOperatLog").Value
                        Case 1 : Me.dgvOperatLog.Rows(row).DefaultCellStyle.BackColor = Color.Yellow
                        Case 2 : Me.dgvOperatLog.Rows(row).DefaultCellStyle.BackColor = Color.Red
                    End Select
                Next
        End Select
    End Sub
#End Region

#Region "Event"
    Public Event OnOperatorClick(ByVal sender As Object, ByVal e As EventArgs)

    Private Sub ctrlDataLog_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        Try
            If Me.Visible Then
                taPROCESS_MST1.Fill(dsPAINT1.dtPROCESS_MST)

                DisplayScreen()
            End If
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "ctrlDataLog_VisibleChanged", ex, True)
        End Try
    End Sub

    Private Sub TabCtrlDataLog_SelectedIndexChanged() Handles tabCtrlDataLog.SelectedIndexChanged
        Try
            taLOG_DAT1.FillByLogType(dsPAINT1.dtLOG_DAT, Me.tabCtrlDataLog.SelectedIndex + 1)

            setDataGridColor()
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "TabCtrlDataLog_SelectedIndexChanged", ex, True)
        End Try
    End Sub

    Private Sub CtrlBtnsOperator1_OnOperatorClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles CtrlBtnsOperator1.OnOperatorClick
        Try
            Dim btn As Button = DirectCast(sender, Button)

            Select Case btn.Tag
                Case "F5"
                    SaveDataLog()
                Case "F9"
                    TabCtrlDataLog_SelectedIndexChanged()
                Case "F12"
                    RaiseEvent OnOperatorClick(btn, e)
            End Select
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "CtrlBtnsOperator1_OnOperatorClick", ex, True)
        End Try
    End Sub
#End Region
End Class
