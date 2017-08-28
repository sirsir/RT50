Imports Common
Imports System.Text.RegularExpressions

Public Class Search

    Public regexModelCode As String
    Public regexLotNo As String
    Public regexBlockModel As String

    Public reg_exp As New Regex("")
    Dim logger As Logger = New Logger()

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
        Me.Owner.Activate()
    End Sub

    Private Sub btnExecution_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExecution.Click
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnExecution_Click", "Click Execution Button", "")

        Dim chkRegularPass As Boolean = True
        regexModelCode = "^[0-9]{3}[A-Za-z0-9 ]{5}$"
        regexBlockModel = "^[A-Za-z0-9 ]{8}$"
        regexLotNo = "^[0-9]{3}$"

        'check Model Code
        Try
            Dim modelCode As String = Me.txbModelCode.Text.ToString
            If Not checkRegularExpressionInput(regexModelCode, modelCode) Then
                chkRegularPass = False
                MessageBox.Show("Please check Model Code." & vbCrLf & "Only 3 numbers(0-9) and 5 characters(A-Z for both upper and lower case) are accepted.")
            Else

                If Me.txbLotNo.Text.Length > 0 Or Me.txbBlock.Text.Length > 0 Then

                    If Me.Owner.Text = "PRODUCTION DATA" Then
                        Dim taProd As New DataSet1TableAdapters.T_Production_DATTableAdapter
                        Dim dtProd As New DataSet1.T_Production_DATDataTable

                        If txbBlock.Text.Length > 0 Then
                            'check BlockModel
                            Dim blockModel As String = txbBlock.Text
                            If Not checkRegularExpressionInput(regexBlockModel, blockModel) Then
                                chkRegularPass = False
                                MessageBox.Show("Please check Block Model." & vbCrLf & "Only 8 numbers(0-9) or characters(A-Z for both upper and lower case) are accepted.")
                            Else
                                dtProd = taProd.GetSkByYearSuffixBlock(modelCode, blockModel)
                            End If

                        ElseIf txbLotNo.Text.Length > 0 Then
                            'check LotNo
                            Dim lotNo As String = Me.txbLotNo.Text
                            If Not checkRegularExpressionInput(regexLotNo, lotNo) Then
                                chkRegularPass = False
                                MessageBox.Show("Please check Lot No." & vbCrLf & "Only 3 numbers(0-9) are accepted.")
                            Else
                                dtProd = taProd.GetSkByYearSuffixLot(modelCode, lotNo)
                            End If

                        End If

                        If chkRegularPass Then
                            If dtProd.Count > 0 Then
                                Dim dt As New DataTable
                                Dim drProd As DataSet1.T_Production_DATRow

                                drProd = dtProd.Rows(0)
                                ProductionData.ReloadData(drProd.ProductionDate, drProd.ProductionTime, drProd.SeqNo, drProd.SubSeq)
                                ProductionData.Activate()
                                Me.Close()
                            Else
                                MessageBox.Show("No data match with search condition.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error)

                            End If
                        End If

                    ElseIf Me.Owner.Text = "ADDITION INSERT" Then
                        Dim taProd As New DataSet1TableAdapters.T_Production_DATTableAdapter
                        Dim dtProd As New DataSet1.T_Production_DATDataTable

                        If txbBlock.Text.Length > 0 Then
                            'check BlockModel
                            Dim blockModel As String = txbBlock.Text
                            If Not checkRegularExpressionInput(regexBlockModel, blockModel) Then
                                chkRegularPass = False
                                MessageBox.Show("Please check Block Model." & vbCrLf & "Only 8 numbers(0-9) or characters(A-Z for both upper and lower case) are accepted.")
                            Else
                                dtProd = taProd.GetSkByYearSuffixBlock(modelCode, blockModel)
                            End If

                        ElseIf txbLotNo.Text.Length > 0 Then
                            'check LotNo
                            Dim lotNo As String = Me.txbLotNo.Text
                            If Not checkRegularExpressionInput(regexLotNo, lotNo) Then
                                chkRegularPass = False
                                MessageBox.Show("Please check Lot No." & vbCrLf & "Only 3 numbers(0-9) are accepted.")
                            Else
                                dtProd = taProd.GetSkByYearSuffixLot(modelCode, lotNo)
                            End If

                        End If

                        If chkRegularPass Then
                            If dtProd.Count > 0 Then

                                Dim dt As New DataTable
                                Dim drProd As DataSet1.T_Production_DATRow

                                drProd = dtProd.Rows(0)
                                AdditionInsert.ReloadData(drProd.ProductionDate, drProd.ProductionTime, drProd.SeqNo, drProd.SubSeq)
                                AdditionInsert.Activate()
                                Me.Close()

                            Else
                                MessageBox.Show("No data match with search condition.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error)

                            End If
                        End If

                    ElseIf Me.Owner.Text = "INSTRUCTION SCHEDULE" Then

                        Dim lineNo As Integer = InstructionSch.m_iLineNo
                        Dim taIns As New DataSet1TableAdapters.T_Instruction_DATTableAdapter
                        Dim dtIns As New DataSet1.T_Instruction_DATDataTable

                        If txbBlock.Text.Length > 0 Then
                            'check BlockModel
                            Dim blockModel As String = txbBlock.Text
                            If Not checkRegularExpressionInput(regexBlockModel, blockModel) Then
                                chkRegularPass = False
                                MessageBox.Show("Please check Block Model." & vbCrLf & "Only 8 numbers(0-9) or characters(A-Z for both upper and lower case) are accepted.")
                            Else
                                dtIns = taIns.GetSkByYearSuffixBlock(lineNo, modelCode, blockModel)
                            End If

                        ElseIf txbLotNo.Text.Length > 0 Then
                            'check LotNo
                            Dim lotNo As String = Me.txbLotNo.Text
                            If Not checkRegularExpressionInput(regexLotNo, lotNo) Then
                                chkRegularPass = False
                                MessageBox.Show("Please check Lot No." & vbCrLf & "Only 3 numbers(0-9) are accepted.")
                            Else
                                dtIns = taIns.GetSkByYearSuffixLot(lineNo, modelCode, lotNo)
                            End If

                        End If

                        If chkRegularPass Then
                            If dtIns.Count > 0 Then
                                Dim dt As New DataTable
                                Dim drIns As DataSet1.T_Instruction_DATRow

                                drIns = dtIns.Rows(0)
                                InstructionSch.ReloadData(drIns.ProductionDate, drIns.ProductionTime, drIns.SeqNo, drIns.SubSeq)
                                InstructionSch.Activate()
                                Me.Close()
                            Else
                                MessageBox.Show("No data match with search condition.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error)

                            End If
                        End If

                    ElseIf Me.Owner.Text = "CARRY OUT SCHEDULE" Then

                        Dim lineNo As Integer = CarryOutSch.m_iLineNo
                        Dim taIns As New DataSet1TableAdapters.T_Instruction_DATTableAdapter
                        Dim dtIns As New DataSet1.T_Instruction_DATDataTable

                        If txbBlock.Text.Length > 0 Then
                            'check BlockModel
                            Dim blockModel As String = txbBlock.Text
                            If Not checkRegularExpressionInput(regexBlockModel, blockModel) Then
                                chkRegularPass = False
                                MessageBox.Show("Please check Block Model." & vbCrLf & "Only 8 numbers(0-9) or characters(A-Z for both upper and lower case) are accepted.")
                            Else
                                dtIns = taIns.GetSkByYearSuffixBlock(lineNo, modelCode, blockModel)
                            End If

                        ElseIf txbLotNo.Text.Length > 0 Then
                            'check LotNo
                            Dim lotNo As String = Me.txbLotNo.Text
                            If Not checkRegularExpressionInput(regexLotNo, lotNo) Then
                                chkRegularPass = False
                                MessageBox.Show("Please check Lot No." & vbCrLf & "Only 3 numbers(0-9) are accepted.")
                            Else
                                dtIns = taIns.GetSkByYearSuffixLot(lineNo, modelCode, lotNo)
                            End If

                        End If
                        If chkRegularPass Then
                            If dtIns.Count > 0 Then
                                Dim dt As New DataTable
                                Dim drIns As DataSet1.T_Instruction_DATRow

                                drIns = dtIns.Rows(0)
                                CarryOutSch.ReloadData(drIns.ProductionDate, drIns.ProductionTime, drIns.SeqNo, drIns.SubSeq)
                                CarryOutSch.Activate()
                                Me.Close()
                            Else
                                MessageBox.Show("No data match with search condition.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error)

                            End If
                        End If
                    End If

                Else
                    MessageBox.Show("Please input Lot No or Block.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error)

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            logger.Log(Common.Logger.MessageType.ErrorLog, Me.GetType.Name, "btnExecution", ex.Message, "")
        End Try

    End Sub

    Private Function checkRegularExpressionInput(ByVal regexInput As String, ByVal strCheck As String) As Boolean

        Dim bl_result As Boolean = True

        reg_exp = New Regex(regexInput)
        bl_result = reg_exp.IsMatch(strCheck)

        Return bl_result

    End Function

    'Private Function GetProductionResult() As DataSet1.T_Production_DATDataTable

    '    Dim ta As New DataSet1TableAdapters.T_Production_DATTableAdapter
    '    Dim modelCode As String = txbModelCode.Text

    '    'regexBlockModel = "^[A-Za-z0-9 ]{8}$"
    '    'regexLotNo = "^[0-9]{3}$"

    '    Dim dtProd As New DataSet1.T_Production_DATDataTable

    '    If txbBlock.Text.Length > 0 Then

    '        'check BlockModel
    '        Dim blockModel As String = txbBlock.Text
    '        If checkRegularExpressionInput(regexBlockModel, blockModel) Then

    '            dtProd = ta.GetSkByYearSuffixBlock(modelCode, blockModel)

    '        End If

    '    ElseIf txbLotNo.Text.Length > 0 Then

    '        'check LotNo
    '        Dim lotNo As String = Me.txbLotNo.Text
    '        If checkRegularExpressionInput(regexLotNo, lotNo) Then

    '            dtProd = ta.GetSkByYearSuffixLot(modelCode, lotNo)

    '        End If

    '    End If

    '    Return dtProd

    'End Function

    'Private Function GetInstructionResult(ByVal lineNo As Integer) As DataSet1.T_Instruction_DATDataTable

    '    Dim ta As New DataSet1TableAdapters.T_Instruction_DATTableAdapter
    '    Dim modelCode As String = txbModelCode.Text

    '    regexBlockModel = "^[A-Za-z0-9 ]{8}$"
    '    regexLotNo = "^[0-9]{3}$"

    '    Dim dtIns As New DataSet1.T_Instruction_DATDataTable

    '    If txbBlock.Text.Length > 0 Then

    '        'check BlockModel
    '        Dim blockModel As String = txbBlock.Text
    '        If checkRegularExpressionInput(regexBlockModel, blockModel) Then

    '            dtIns = ta.GetSkByYearSuffixBlock(lineNo, modelCode, blockModel)

    '        End If

    '    ElseIf txbLotNo.Text.Length > 0 Then

    '        'check LotNo
    '        Dim lotNo As String = Me.txbLotNo.Text
    '        If checkRegularExpressionInput(regexLotNo, lotNo) Then

    '            dtIns = ta.GetSkByYearSuffixLot(lineNo, modelCode, lotNo)

    '        End If

    '    End If

    '    Return dtIns

    'End Function

    'Private Function GetInstructionIndexNo(ByVal lineNo As Integer) As Integer

    '    Dim ta As New DataSet1TableAdapters.T_Instruction_DATTableAdapter
    '    Dim modelCode As String = txbModelCode.Text

    '    regexBlockModel = "^[A-Za-z0-9 ]{8}$"
    '    regexLotNo = "^[A-Za-z0-9 ]{3}$"

    '    Dim indexNo As Integer
    '    If txbBlock.Text.Length > 0 Then

    '        'check BlockModel
    '        Dim blockModel As String = txbBlock.Text
    '        If checkRegularExpressionInput(regexBlockModel, blockModel) Then

    '            Try
    '                indexNo = ta.GetIndexNoByLineYearSuffixBlock(lineNo, modelCode, blockModel)
    '            Catch ex As Exception
    '                indexNo = 0
    '            End Try

    '        End If

    '    ElseIf txbLotNo.Text.Length > 0 Then

    '        'check LotNo
    '        Dim lotNo As String = Me.txbLotNo.Text
    '        If checkRegularExpressionInput(regexLotNo, lotNo) Then

    '            Try
    '                indexNo = ta.GetIndexNoByLineYearSuffixLot(lineNo, modelCode, lotNo)
    '            Catch ex As Exception
    '                indexNo = 0
    '            End Try

    '        End If

    '    End If

    '    Return indexNo

    'End Function

    Private Sub Search_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        logger.Log(Common.Logger.MessageType.NormalLog, Me.GetType.Name, "btnCancel_Click", "Close Search Screen", "")
        Me.Dispose()
    End Sub

    Private Sub Search_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyData
            Case Keys.F1
                btnExecution_Click(sender, e)
            Case Keys.F12
                btnCancel_Click(sender, e)
        End Select
    End Sub
End Class