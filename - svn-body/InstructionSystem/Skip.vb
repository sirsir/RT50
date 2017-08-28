Imports Common

Public Class Skip
    Dim logger As Logger = New Logger()

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()

    End Sub

    Private Sub Skip_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnCancel_Click", "Close Skip Screen", "")
        ProductionData.Show()
        Me.Dispose()
    End Sub


    Private Sub Skip_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "Skip_Load", "Load Skip Screen", "")
        Me.rdbLotBlock.Checked = True

        'Dim activeRowIndex As Integer = ProductionData.datagridPdata.CurrentCell.RowIndex
        'Me.lblValue.Text = ProductionData.datagridPdata.Item(9, activeRowIndex).Value.ToString

    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnOk_Click", "Click Skip Button", "")

        Try
            Dim taProd As New DataSet1TableAdapters.T_Production_DATTableAdapter
            Dim pDt As New DataSet1.T_Production_DATDataTable
            Dim activeRowIndex As Integer = ProductionData.datagridPdata.CurrentCell.RowIndex
            Dim result As Integer
            Dim strModelYear As String
            Dim strSuffixCode As String
            Dim strBlock As String
            Dim strLotNo As String
            Dim strUnit As String
            Using ts As New TransactionScope
                strModelYear = ProductionData.datagridPdata.Item(4, activeRowIndex).Value.ToString  'modelYear
                strSuffixCode = ProductionData.datagridPdata.Item(5, activeRowIndex).Value.ToString  'suffixCode
                strBlock = ProductionData.datagridPdata.Item(9, activeRowIndex).Value.ToString  'block
                strLotNo = ProductionData.datagridPdata.Item(7, activeRowIndex).Value.ToString  'lot no
                strUnit = ProductionData.datagridPdata.Item(8, activeRowIndex).Value.ToString  'unit

                If Me.rdbLotBlock.Checked = True Then

                    If strBlock <> "" Then
                        result = taProd.UpdateSkipDataByBlock(strBlock)
                        If result > 0 Then
                            pDt = taProd.GetDataByBlockModel(strBlock)
                        End If
                    Else
                        result = taProd.UpdateSkipDataByModelYearSuffixLot(strModelYear, strSuffixCode, strLotNo)
                        If result > 0 Then
                            pDt = taProd.GetDataByModelYearSuffixLotNo(strModelYear, strSuffixCode, strLotNo)
                        End If
                    End If

                    Dim manageInstructData As New ManageInstructionData
                    For Each aDR In pDt.Rows
                        manageInstructData.UpdateProductionRowToInstruction(aDR("ModelYear"), aDR("SuffixCode"), _
                                                                             aDR("LotNo"), aDR("Unit"))
                    Next

                End If

                If Me.rdbSelectedPart.Checked = True Then

                    result = taProd.UpdateSkipDataByPrimaryKey(strModelYear, strSuffixCode, strLotNo, strUnit)

                    Dim manageInstructData As New ManageInstructionData
                    manageInstructData.UpdateProductionRowToInstruction(strModelYear, strSuffixCode, _
                                                                        strLotNo, strUnit)
                    logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnOk_Click", "", "")
                End If
                ts.Complete()
            End Using
        Catch ex As Exception
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "btnOk_Click", ex.Message, "")
            MessageBox.Show("Skip Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

            Me.Dispose()
            'Reload Production Data
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
        End Try

    End Sub

    Private Sub rdbLotBlock_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbLotBlock.CheckedChanged
        Dim activeRowIndex As Integer = ProductionData.datagridPdata.CurrentCell.RowIndex

        If ProductionData.datagridPdata.Item(9, activeRowIndex).Value.ToString = "" Then
            Me.lblLabel.Text = "ModelCode"
            Me.lblValue.Text = ProductionData.datagridPdata.Item(4, activeRowIndex).Value.ToString + ProductionData.datagridPdata.Item(5, activeRowIndex).Value.ToString
            Me.lblLabel2.Text = "Lot No."
            Me.lblValue2.Text = ProductionData.datagridPdata.Item(7, activeRowIndex).Value.ToString
        Else
            Me.lblLabel.Text = "BLOCK"
            Me.lblValue.Text = ProductionData.datagridPdata.Item(9, activeRowIndex).Value.ToString
            Me.lblLabel2.Text = ""
            Me.lblValue2.Text = ""
        End If


    End Sub

    Private Sub rdbSelectedPart_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbSelectedPart.CheckedChanged
        Dim activeRowIndex As Integer = ProductionData.datagridPdata.CurrentCell.RowIndex
      
        Me.lblLabel.Text = "ModelCode"
        Me.lblValue.Text = ProductionData.datagridPdata.Item(4, activeRowIndex).Value.ToString + ProductionData.datagridPdata.Item(5, activeRowIndex).Value.ToString
        Me.lblLabel2.Text = "Lot No. "
        Me.lblValue2.Text = ProductionData.datagridPdata.Item(7, activeRowIndex).Value.ToString
        Me.lblValue2.Text = Me.lblValue2.Text & "  UNIT "
        Me.lblValue2.Text = Me.lblValue2.Text & ProductionData.datagridPdata.Item(8, activeRowIndex).Value.ToString

    End Sub

    Private Sub Skip_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyData
            Case Keys.F1
                btnOk_Click(sender, e)
            Case Keys.F12
                btnCancel_Click(sender, e)
        End Select
    End Sub
End Class