Public Class LineMSTDetail

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub


    Private Sub btnAddLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddLine.Click

        If validateValue() Then
            Dim TA_LineMST As New ServerDatasetTableAdapters.T_Line_MSTTableAdapter()
            Dim result As Integer = TA_LineMST.InsertNewLine(Convert.ToInt32(txtLineCode.Text), txtLineName.Text, Convert.ToInt32(txtLineType.Text), chkMainLine.Checked, chkOnline.Checked, txtIPAddr.Text, Convert.ToInt32(txtNetAddr.Text), Convert.ToInt32(txtUnitAddr.Text), Convert.ToInt32(txtReadReqAddr.Text), Convert.ToInt32(txtWritePrdAddr.Text), Convert.ToInt32(txtWriteCarrAddr.Text), chkPart1.Checked, chkPart2.Checked, chkPart3.Checked, chkPart4.Checked, chkPart5.Checked, Convert.ToInt32(txtNodeAddr.Text))

            If result = 0 Then
                MessageBox.Show("Failed to add new line!!!")
            Else
                Me.Dispose()
                SystemSetting.T_Line_MSTTableAdapter.Fill(SystemSetting.ServerDataset.T_Line_MST)
            End If

        End If

    End Sub

    Public Function validateValue()
        Dim flag As Boolean = True
        Dim ErrMSG As String = ""
        If txtLineCode.Text = "" Then
            ''
            flag = False
            ErrMSG += "Please inser LineCode." & vbCrLf & "===============" & vbCrLf
        ElseIf Not IsNumeric(txtLineCode.Text) Then
            flag = False
            ErrMSG += "LineCode must be numeric." & vbCrLf & "===============" & vbCrLf
        End If

        If txtLineName.Text = "" Then
            flag = False
            ErrMSG += "Please inser LineName." & vbCrLf & "===============" & vbCrLf
        End If

        If txtLineType.Text = "" Then
            ''
            flag = False
            ErrMSG += "Please inser LineType." & vbCrLf & "===============" & vbCrLf
        ElseIf Not IsNumeric(txtLineType.Text) Then
            flag = False
            ErrMSG += "LineType must be numberic." & vbCrLf & "===============" & vbCrLf
        End If

        If txtIPAddr.Text = "" Then
            flag = False
            ErrMSG += "Please inser IPAddress." & vbCrLf & "===============" & vbCrLf
        End If

        If txtNetAddr.Text = "" Then
            ''
            flag = False
            ErrMSG += "Please inser NetAddress." & vbCrLf & "===============" & vbCrLf
        ElseIf Not IsNumeric(txtNetAddr.Text) Then
            flag = False
            ErrMSG += "NetAddress must be numeric." & vbCrLf & "===============" & vbCrLf
        End If

        If txtNodeAddr.Text = "" Then
            ''
            flag = False
            ErrMSG += "Please inser NodeAddress." & vbCrLf & "===============" & vbCrLf
        ElseIf Not IsNumeric(txtNodeAddr.Text) Then
            flag = False
            ErrMSG += "NodeAddress must be numeric." & vbCrLf & "===============" & vbCrLf
        End If

        If txtUnitAddr.Text = "" Then
            ''
            flag = False
            ErrMSG += "Please inser UnitAddress." & vbCrLf & "===============" & vbCrLf
        ElseIf Not IsNumeric(txtUnitAddr.Text) Then
            flag = False
            ErrMSG += "UnitAddress must be numeric." & vbCrLf & "===============" & vbCrLf
        End If

        If txtReadReqAddr.Text = "" Then
            ''
            flag = False
            ErrMSG += "Please inser ReadReqAddress." & vbCrLf & "===============" & vbCrLf
        ElseIf Not IsNumeric(txtReadReqAddr.Text) Then
            flag = False
            ErrMSG += "ReadReqAddress must be numeric." & vbCrLf & "===============" & vbCrLf
        End If

        If txtWritePrdAddr.Text = "" Then
            ''
            flag = False
            ErrMSG += "Please inser WriteProductionAddress." & vbCrLf & "===============" & vbCrLf
        ElseIf Not IsNumeric(txtWritePrdAddr.Text) Then
            flag = False
            ErrMSG += "WriteProductionAddress must be numeric." & vbCrLf & "===============" & vbCrLf
        End If

        If txtWriteCarrAddr.Text = "" Then
            ''
            flag = False
            ErrMSG += "Please inser WriteCarryOutAddress." & vbCrLf & "===============" & vbCrLf
        ElseIf Not IsNumeric(txtWriteCarrAddr.Text) Then
            flag = False
            ErrMSG += "WriteCarryOutAddress must be numeric." & vbCrLf & "===============" & vbCrLf
        End If


        If Not flag Then
            MessageBox.Show(ErrMSG)
        End If

        Return flag
    End Function

End Class