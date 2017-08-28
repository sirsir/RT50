Public Class frmSearch

#Region "Constant"

#End Region

#Region "Attribute"
    Private m_regexpModelCode As New Regex("^([0-9 ]{1,3}|[0-9 ]{3}[0-9A-Za-z ]{1,5})$")
    Private m_regexpLotNo As New Regex("^[0-9 ]{1,3}$")
    Private m_regexpUnitNo As New Regex("^[0-9 ]{1,3}$")
    Private m_regexpSkitNo As New Regex("^[0-9]{0,3}$")
    Private m_objClsLogger As New clsLogger

    Private m_strSelectedProductionDate As String
    Private m_strSelectedOnTime As String
    Private m_strBlockModel As String
    Private m_strBlockSeq As String

    Private Shared s_taPRODUCTION_DAT As New taPRODUCTION_DAT
#End Region

#Region "Constructor"

#End Region

#Region "Property"
    Public WriteOnly Property ModelCode() As String
        Set(ByVal value As String)
            txtModelCode.Text = value
        End Set
    End Property

    Public WriteOnly Property LotNo() As String
        Set(ByVal value As String)
            txtLotNo.Text = value
        End Set
    End Property

    Public WriteOnly Property UnitNo() As String
        Set(ByVal value As String)
            txtUnitNo.Text = value
        End Set
    End Property

    Public ReadOnly Property SelectedProductionDate() As String
        Get
            Return m_strSelectedProductionDate
        End Get
    End Property

    Public ReadOnly Property SelectedOnTime() As String
        Get
            Return m_strSelectedOnTime
        End Get
    End Property

    Public ReadOnly Property BlockModel() As String
        Get
            Return m_strBlockModel
        End Get
    End Property

    Public ReadOnly Property BlockSeq() As String
        Get
            Return m_strBlockSeq
        End Get
    End Property
#End Region

#Region "Method"
    Private Function GetInstructionIndex(ByVal lineCode As Integer) As Integer
        'Dim filter_exp As String = ""
        'Dim indexNo As Integer
        'Dim inputError As Boolean = False

        'If txtCtrlCode.Text.Length > 0 Then
        '    If checkRegularExpressionInput(regexModelCode, txtCtrlCode.Text) Then
        '        filter_exp += "ModelCode = '" & txtCtrlCode.Text & "'"
        '    Else
        '        MessageBox.Show("Error: Control Code is invalid.")
        '        inputError = True
        '    End If
        'End If

        'If txtLotNo.Text.Length > 0 Then
        '    If checkRegularExpressionInput(regexLotNo, txtLotNo.Text) Then
        '        If filter_exp.Length > 0 Then
        '            filter_exp += " AND LotNo = '" & txtLotNo.Text & "'"
        '        Else
        '            filter_exp += "LotNo = '" & txtLotNo.Text & "'"
        '        End If
        '    Else
        '        MessageBox.Show("Error: Lot No. is invalid.")
        '        inputError = True
        '    End If
        'End If

        'If txtUnitNo.Text.Length > 0 Then
        '    If checkRegularExpressionInput(regexUnitNo, txtUnitNo.Text) Then
        '        If filter_exp.Length > 0 Then
        '            filter_exp += " AND UnitNo = '" & txtUnitNo.Text & "'"
        '        Else
        '            filter_exp += "UnitNo = '" & txtUnitNo.Text & "'"
        '        End If
        '    Else
        '        MessageBox.Show("Error: Suffix Code is invalid.")
        '        inputError = True
        '    End If
        'End If

        'If txtDate.Text.Length > 0 Then
        '    If checkRegularExpressionInput(regexDate, txtDate.Text) Then
        '        If filter_exp.Length > 0 Then
        '            filter_exp += " AND FrameLineOffDate = '" & txtDate.Text & "'"
        '        Else
        '            filter_exp += "FrameLineOffDate = '" & txtDate.Text & "'"
        '        End If
        '    Else
        '        MessageBox.Show("Error: Date is invalid.")
        '        inputError = True
        '    End If
        'End If

        'If filter_exp.Length = 0 Then
        '    MessageBox.Show("Error: no input")
        '    Return -1
        'End If

        'If Not inputError Then
        '    Try
        '        indexNo = InstructionSchedule.instrData.searchIndexByLineCode(lineCode, filter_exp)
        '    Catch ex As Exception
        '        indexNo = 0
        '        'MessageBox.Show(ex.Message)
        '    End Try

        '    Return indexNo
        'Else
        '    Return -1
        'End If

    End Function

    Private Sub GetProductionResult()
        Dim strModelCode As String = txtModelCode.Text
        Dim strLotNo As String = txtLotNo.Text
        Dim strUnitNo As String = txtUnitNo.Text
        Dim strSkitNo As String = txtSkitNo.Text

        Dim strModelYear As String = String.Empty
        Dim strSuffixcode As String = String.Empty

        Dim inputError As Boolean = False

        Dim arrList() As Object = { _
            New Object() {strModelCode, m_regexpModelCode, lblModelCode}, _
            New Object() {strLotNo, m_regexpLotNo, lblLotNo}, _
            New Object() {strUnitNo, m_regexpUnitNo, lblUnitNo}, _
            New Object() {strSkitNo, m_regexpSkitNo, lblSkitNo} _
        }

        For Each arr As Object() In arrList
            Dim txt As String = arr(0)
            Dim regex As Regex = arr(1)
            Dim lbl As Label = arr(2)

            If txt.Length > 0 Then
                If Not regex.IsMatch(txt) Then
                    If lblMsg.Text = String.Empty Then lblMsg.Text = String.Format("Error: {0} is invalid.", lbl.Text)
                    lbl.BackColor = Color.Red

                    inputError = True
                ElseIf lbl Is lblModelCode Then
                    strModelYear = strModelCode.Substring(0, Math.Min(strModelCode.Length, 3))
                    If strModelCode.Length <= 3 Then
                        strSuffixcode = "%"
                    Else
                        strSuffixcode = strModelCode.Substring(3, Math.Min(strModelCode.Length - 3, 5))
                    End If
                End If
            Else
                Select Case lbl.Name
                    Case "lblModelCode" : strModelYear = "%" : strSuffixcode = "%"
                    Case "lblLotNo" : strLotNo = "%"
                    Case "lblUnitNo" : strUnitNo = "%"
                    Case "lblSkitNo" : strSkitNo = "0"
                End Select

            End If
        Next arr

        If strModelCode = "%" And strLotNo = "%" And strUnitNo = "%" And strSkitNo = "0" Then
            lblMsg.Text = "Error: No input."

            dsPAINT1.dtPRODUCTION_DAT.Clear()
        End If

        If Not inputError Then
            strModelYear = String.Format("{0}%", strModelYear)
            strSuffixcode = String.Format("{0}%", strSuffixcode)
            strLotNo = String.Format("{0}%", strLotNo)
            strUnitNo = String.Format("{0}%", strUnitNo)

            s_taPRODUCTION_DAT.FillByModelLotUnit(dsPAINT1.dtPRODUCTION_DAT, strModelYear, strSuffixcode, strLotNo, strUnitNo, strSkitNo)
        Else
            dsPAINT1.dtPRODUCTION_DAT.Clear()
        End If
    End Sub
#End Region

#Region "Event"
    Private Sub frmSearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            lblMsg.Text = String.Empty
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "frmSearch_Load", ex, True)
        End Try
    End Sub

    Private Sub btnExecution_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExecution.Click
        Try
            lblMsg.Text = String.Empty
            lblModelCode.BackColor = SystemColors.Control
            lblLotNo.BackColor = SystemColors.Control
            lblUnitNo.BackColor = SystemColors.Control

            GetProductionResult()

            If dsPAINT1.dtPRODUCTION_DAT.Rows.Count > 0 Then
                Dim drProd As dsPAINT.dtPRODUCTION_DATRow

                drProd = dsPAINT1.dtPRODUCTION_DAT.Rows(0)

                m_strSelectedProductionDate = drProd.PRODUCTION_DATE
                m_strSelectedOnTime = drProd.ON_TIME
                m_strBlockModel = drProd.BLOCK_MODEL
                m_strBlockSeq = drProd.BLOCK_SEQ

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            ElseIf (lblMsg.Text = String.Empty) Then
                lblMsg.Text = "No data match with search condition"
            End If
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "btnExecution_Click", ex, True)
        End Try
    End Sub
#End Region

End Class