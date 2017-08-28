Imports Common

Public Class InspOut
    Dim logger As Logger = New Logger()

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        
        Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnOk_Click", "Click OK Button", "")

        newConCeptOKBtn()

    End Sub

    Private Sub newConCeptOKBtn()
        Try
            Dim ta As New DataSet1TableAdapters.T_Production_DATTableAdapter
            Dim pDt As New DataSet1.T_Production_DATDataTable
            Dim dr As DataRow
            Dim activeRowIndex As Integer = ProductionData.datagridPdata.CurrentCell.RowIndex

            Dim modelYear As String
            Dim suffixCode As String
            Dim lotNo As String
            Dim unit As String
            Dim ychass As String

            modelYear = ProductionData.datagridPdata.Item(4, activeRowIndex).Value 'model year
            suffixCode = ProductionData.datagridPdata.Item(5, activeRowIndex).Value 'suffix code
            lotNo = ProductionData.datagridPdata.Item(7, activeRowIndex).Value 'lot no
            unit = ProductionData.datagridPdata.Item(8, activeRowIndex).Value 'unit
            ychass = ProductionData.datagridPdata.Item(15, activeRowIndex).Value.ToString() 'YChassisFlag


            Dim res As Boolean

            If ychass = "" Or ychass = "0" Then
                'check 2 line
                res = checkProductInsResult(modelYear, suffixCode, lotNo, unit, 1)
                res = res Or checkProductInsResult(modelYear, suffixCode, lotNo, unit, 2)
            ElseIf ychass = "1" Or ychass = "2" Then
                'check line 1 only
                res = checkProductInsResult(modelYear, suffixCode, lotNo, unit, 1)
            ElseIf ychass = "3" Then
                'check line 2 only
                res = checkProductInsResult(modelYear, suffixCode, lotNo, unit, 2)
            End If

            pDt = ta.GetDataByPrimaryKey(modelYear, suffixCode, lotNo, unit)

            dr = pDt.Rows(0)

            If res Then 'Have result

                'Already Instructed
                If chkCompulsion.Checked Then

                    dr.Item("XchgFlag") = dr.Item("XchgFlag").ToString.Substring(0, 2) + "01"

                    Dim result As Integer

                    Using ts As New TransactionScope
                        result = ta.Update(dr)

                        Dim logMSG As String
                        logMSG = "Production data " & Me.lblLabel.Text & " " & Me.lblValue.Text & " " & Me.lblLabel2.Text & Me.lblValue2.Text & " inspection-out."

                        'Write Log
                        Dim logger As TLogDat
                        logger = New TLogDat
                        logger.InsertNewLog(TLogDat.LOG_TYPE_OPERATION, TLogDat.LogLevel.NormalLog, My.Computer.Name, Now, logMSG, Nothing)


                        Dim manageInstructData As New ManageInstructionData
                        manageInstructData.UpdateProductionRowToInstructionForInspOut(dr)
                        ts.Complete()
                    End Using
                    Me.Dispose()

                    'Reload Production Data
                    ReloadProductionScreen()

                Else
                    MessageBox.Show("Already Instruct." & vbCrLf & "Need to compulsion", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If


            Else 'No result

                'Not instruct yet
                dr.Item("XchgFlag") = dr.Item("XchgFlag").ToString.Substring(0, 2) + "01"

                Dim result As Integer
                Using ts As New TransactionScope
                    result = ta.Update(dr)

                    Dim logMSG As String
                    logMSG = "Production data " & Me.lblLabel.Text & " " & Me.lblValue.Text & " " & Me.lblLabel2.Text & Me.lblValue2.Text & " inspection-out."

                    'Write Log
                    Dim logger As TLogDat
                    logger = New TLogDat
                    logger.InsertNewLog(TLogDat.LOG_TYPE_OPERATION, TLogDat.LogLevel.NormalLog, My.Computer.Name, Now, logMSG, Nothing)

                    Dim manageInstructData As New ManageInstructionData
                    manageInstructData.UpdateProductionRowToInstructionForInspOut(dr)
                    ts.Complete()
                End Using

                Me.Dispose()
                'Reload Production Data
                ReloadProductionScreen()

            End If
        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "newConCeptOKbtn", ex.Message, "")
            MessageBox.Show("Error when Inspection Out, please try again.")
            ReloadProductionScreen()
            Me.Close()

        End Try
    End Sub

    Private Sub ReloadProductionScreen()
        Dim prodDate As String = ""
        Dim prodTime As String = ""
        Dim seqNo As String = ""
        Dim subSeq As Integer = 0

        prodDate = ProductionData.datagridPdata.Item(12, 0).Value
        prodTime = ProductionData.datagridPdata.Item(13, 0).Value
        seqNo = ProductionData.datagridPdata.Item(1, 0).Value
        subSeq = ProductionData.datagridPdata.Item(2, 0).Value

        ProductionData.Show()
        ProductionData.ReloadData(prodDate, prodTime, seqNo, subSeq)
    End Sub


    Private Function checkProductInsResult(ByVal modelYear As String, ByVal suffixCode As String, ByVal lotNo As String, ByVal unit As String, ByVal lineType As Integer) As Boolean

        Try
            Dim M_ta As New DataSet1TableAdapters.T_Line_MSTTableAdapter
            Dim I_ta As New DataSet1TableAdapters.T_Instruction_DATTableAdapter

            Dim MainlineCode As String = M_ta.GetMainLineCodeByLineType(lineType)

            Dim dt As New DataSet1.T_Instruction_DATDataTable
            I_ta.FillByModelYearSuffixLotUnitLineNo(dt, modelYear, suffixCode, lotNo, unit, MainlineCode)

            If dt.Rows(0)("InsResult") Is DBNull.Value Then
                'No result
                Return False
            Else
                'have result
                Return True
            End If
        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "newConCeptOKbtn", ex.Message, "")
        End Try
    End Function

    Private Sub InspOut_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnCancel_Click", "Close InspOut Screen", "")

        ProductionData.Show()
        Me.Dispose()
    End Sub


    Private Sub InspOut_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "InspOut_Load", "Load InspOut Screen", "")

        Dim activeRowIndex As Integer = ProductionData.datagridPdata.CurrentCell.RowIndex

        'Me.lblLabel2.Text = ProductionData.datagridPdata.Item(9, activeRowIndex).Value.ToString

        Me.lblLabel.Text = "ModelCode"
        Me.lblValue.Text = ProductionData.datagridPdata.Item(4, activeRowIndex).Value.ToString + ProductionData.datagridPdata.Item(5, activeRowIndex).Value.ToString
        Me.lblLabel2.Text = "Lot No. "
        Me.lblValue2.Text = ProductionData.datagridPdata.Item(7, activeRowIndex).Value.ToString
        Me.lblValue2.Text = Me.lblValue2.Text & "  UNIT "
        Me.lblValue2.Text = Me.lblValue2.Text & ProductionData.datagridPdata.Item(8, activeRowIndex).Value.ToString

        checkInsResult()

    End Sub

    Private Sub checkInsResult()
        Try

            Dim activeRowIndex As Integer = ProductionData.datagridPdata.CurrentCell.RowIndex

            Dim modelYear As String
            Dim suffixCode As String
            Dim lotNo As String
            Dim unit As String
            Dim ychass As String

            modelYear = ProductionData.datagridPdata.Item(4, activeRowIndex).Value 'model year
            suffixCode = ProductionData.datagridPdata.Item(5, activeRowIndex).Value 'suffix code
            lotNo = ProductionData.datagridPdata.Item(7, activeRowIndex).Value 'lot no
            unit = ProductionData.datagridPdata.Item(8, activeRowIndex).Value 'unit
            ychass = ProductionData.datagridPdata.Item(15, activeRowIndex).Value.ToString() 'YChassisFlag

            Dim res As Boolean

            If ychass = "" Or ychass = "0" Then
                'check 2 line
                res = checkProductInsResult(modelYear, suffixCode, lotNo, unit, 1)
                res = res Or checkProductInsResult(modelYear, suffixCode, lotNo, unit, 2)
            ElseIf ychass = "1" Or ychass = "2" Then
                'check line 1 only
                res = checkProductInsResult(modelYear, suffixCode, lotNo, unit, 1)
            ElseIf ychass = "3" Then
                'check line 2 only
                res = checkProductInsResult(modelYear, suffixCode, lotNo, unit, 2)
            End If

            If res Then
                chkCompulsion.Enabled = True
            Else
                chkCompulsion.Enabled = False

            End If
        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "chkInsResult", ex.Message, "")
        End Try
    End Sub

    Private Sub InspOut_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyData
            Case Keys.F1
                btnOk_Click(sender, e)
            Case Keys.F12
                btnCancel_Click(sender, e)
        End Select
    End Sub
End Class