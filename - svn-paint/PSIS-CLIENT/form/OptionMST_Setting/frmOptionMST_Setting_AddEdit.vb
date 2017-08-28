Public Class frmOptionMST_Setting_AddEdit

#Region "Enumerator"
    Public Enum enuFormMode
        Add
        Edit
    End Enum
#End Region

#Region "Attribute"
    Private m_enuFormMode As enuFormMode

    Private m_intOptId As Integer
    Private m_intOptType As Integer
    Private m_strOptCode As String
    Private m_strOptName As String
    Private m_strOptDisp As String
    Private m_intOptSeq As Integer

    Private m_row As dsPAINT.dtOPTION_MSTRow

    Private m_objClsLogger As New clsLogger
#End Region

#Region "Property"
    Public WriteOnly Property FormMode() As enuFormMode
        Set(ByVal value As enuFormMode)
            m_enuFormMode = value

            RefreshForm()
        End Set
    End Property

    Public ReadOnly Property dtOptMst() As dsPAINT.dtOPTION_MSTDataTable
        Get
            Return dsPAINT1.dtOPTION_MST
        End Get
    End Property

    Public WriteOnly Property OptionId() As Integer
        Set(ByVal value As Integer)
            m_intOptId = value
        End Set
    End Property

    Public Property OptionType() As Integer
        Get
            Return m_intOptType
        End Get
        Set(ByVal value As Integer)
            m_intOptType = value
        End Set
    End Property

    Public WriteOnly Property OptionCode() As String
        Set(ByVal value As String)
            m_strOptCode = value
        End Set
    End Property

    Public WriteOnly Property OptionName() As String
        Set(ByVal value As String)
            m_strOptName = value
        End Set
    End Property

    Public Property OptionDisplay() As String
        Get
            Return m_strOptDisp
        End Get
        Set(ByVal value As String)
            m_strOptDisp = value
        End Set
    End Property

    Public ReadOnly Property OptionSeq() As Integer
        Get
            Return m_intOptSeq
        End Get
    End Property

#End Region

#Region "Method"
    Private Sub RefreshForm()
        btnNext.Visible = (m_enuFormMode = enuFormMode.Add)
        btnExecute.Visible = (m_enuFormMode = enuFormMode.Edit)

        Select Case m_enuFormMode
            Case enuFormMode.Add
                cboOptionType.SelectedIndex = 0
        End Select
    End Sub

    Private Sub ResetErrorMSG()
        Select Case m_intOptType
            Case dsPAINT.dtOPTION_MSTDataTable.enuOptionType.Destination
                lblDestinationError.Text = String.Empty
                lblDestination.BackColor = SystemColors.Control
            Case dsPAINT.dtOPTION_MSTDataTable.enuOptionType.OptionTable
                lblNameError.Text = String.Empty
                lblName.BackColor = SystemColors.Control
                lblDisplayError.Text = String.Empty
                lblDisplay.BackColor = SystemColors.Control
        End Select
    End Sub

    Private Function IsNotValidate() As Boolean
        Dim blnNotValid As Boolean = True

        Select Case m_intOptType
            Case dsPAINT.dtOPTION_MSTDataTable.enuOptionType.Destination
                If Not txtDestination.Text.Trim.Length > 0 Then
                    lblDestinationError.Text = "PLEASE INSERT DESTINATION"
                    lblDestination.BackColor = Color.Red
                    blnNotValid = False
                Else
                    Dim drs() As dsPAINT.dtOPTION_MSTRow = dtOptMst.Select("OPTION_DISPLAY = '" + txtDestination.Text.Trim + "'")

                    If drs.Length > 0 AndAlso m_strOptDisp <> txtDestination.Text.Trim AndAlso m_enuFormMode = enuFormMode.Add Then
                        lblDestinationError.Text = "DESTINATION IS DUPLICATED"
                        lblDestination.BackColor = Color.Red
                        blnNotValid = False
                    End If
                End If
            Case dsPAINT.dtOPTION_MSTDataTable.enuOptionType.OptionTable
                If Not txtName.Text.Trim.Length > 0 Then
                    lblNameError.Text = "PLEASE INSERT NAME"
                    lblName.BackColor = Color.Red
                    blnNotValid = False
                End If

                If Not txtDisplay.Text.Trim.Length > 0 Then
                    lblDisplayError.Text = "PLEASE INSERT DISPLAY"
                    lblDisplay.BackColor = Color.Red
                    blnNotValid = False
                Else
                    Dim drs() As dsPAINT.dtOPTION_MSTRow = dtOptMst.Select("OPTION_DISPLAY = '" + txtDestination.Text.Trim + "'")

                    If drs.Length > 0 AndAlso m_strOptDisp <> txtDisplay.Text.Trim AndAlso m_enuFormMode = enuFormMode.Add Then
                        lblDisplayError.Text = "DISPLAY IS DUPLICATED"
                        lblDisplay.BackColor = Color.Red
                        blnNotValid = False
                    End If
                End If
        End Select

        Return blnNotValid
    End Function

    Private ReadOnly Property dtOptionMST_Row() As dsPAINT.dtOPTION_MSTDataTable
        Get
            Return dsPAINT1.dtOPTION_MST
        End Get
    End Property

    Private Function InsertRow()
        Dim taModelOptionCell As taMODEL_OPTION_CELL = New taMODEL_OPTION_CELL
        Dim taProcOptCell As taPROCESS_OPTION_CELL = New taPROCESS_OPTION_CELL

        Dim dr As dsPAINT.dtOPTION_MSTRow = dtOptMst.NewdtOPTION_MSTRow
        With dr
            .BeginEdit()
            .OPTION_NAME = IIf(m_intOptType = dsPAINT.dtOPTION_MSTDataTable.enuOptionType.Destination, _
                               cboOptionType.SelectedItem, txtName.Text)
            .OPTION_TYPE = m_intOptType
            .OPTION_DISPLAY = IIf(m_intOptType = dsPAINT.dtOPTION_MSTDataTable.enuOptionType.Destination, _
                                  txtDestination.Text, txtDisplay.Text)
            .OPTION_CODE = IIf(txtCode.Text.Length = 0, Nothing, txtCode.Text)
            .OPTION_SEQ = taOPTION_MST1.GetNextOptSeq(m_intOptType)
            .EndEdit()
        End With

        Try
            Using ts As New TransactionScope
                dtOptionMST_Row.AdddtOPTION_MSTRow(dr)
                taOPTION_MST1.Update(dtOptionMST_Row)
                dtOptionMST_Row.AcceptChanges()

                If m_intOptType = dsPAINT.dtOPTION_MSTDataTable.enuOptionType.OptionTable Then
                    taModelOptionCell.InsertNewWhenInsertNewOpt()
                    taProcOptCell.InsertNewWhenInsertNewOpt()
                End If

                ts.Complete()

                m_intOptType = dr.OPTION_TYPE
                m_intOptSeq = dr.OPTION_SEQ
            End Using
        Catch ex As Exception
            dtOptionMST_Row.RejectChanges()
            m_objClsLogger.LogException(Me.GetType.Name, "InsertRow", ex, True)
        End Try

        Return dr
    End Function

    Private Sub LoadCells()
        Select Case m_row.OPTION_TYPE
            Case dsPAINT.dtOPTION_MSTDataTable.enuOptionType.Destination
                cboOptionType.SelectedIndex = dsPAINT.dtOPTION_MSTDataTable.enuOptionType.Destination - 1
                cboOptionType.Enabled = False

                lblDestinationError.Text = String.Empty
                txtDestination.Text = m_row.OPTION_DISPLAY

                pnlDestination.Visible = True
            Case dsPAINT.dtOPTION_MSTDataTable.enuOptionType.OptionTable
                cboOptionType.SelectedIndex = dsPAINT.dtOPTION_MSTDataTable.enuOptionType.OptionTable - 1
                cboOptionType.Enabled = False

                lblDisplayError.Text = String.Empty
                lblNameError.Text = String.Empty

                txtCode.Text = m_row.OPTION_CODE
                txtName.Text = m_row.OPTION_NAME
                txtDisplay.Text = m_row.OPTION_DISPLAY

                pnlOption.Visible = True
        End Select
    End Sub

    Private Sub UpdateRow()
        Try
            Select Case m_row.OPTION_TYPE
                Case dsPAINT.dtOPTION_MSTDataTable.enuOptionType.Destination
                    With m_row
                        .BeginEdit()
                        .OPTION_DISPLAY = txtDestination.Text
                        .EndEdit()
                    End With
                Case dsPAINT.dtOPTION_MSTDataTable.enuOptionType.OptionTable
                    With m_row
                        .BeginEdit()
                        .OPTION_DISPLAY = txtDisplay.Text
                        .OPTION_NAME = txtName.Text
                        .OPTION_CODE = txtCode.Text
                        .EndEdit()
                    End With
            End Select

            taOPTION_MST1.Update(dtOptionMST_Row)
            dtOptionMST_Row.AcceptChanges()

            m_intOptType = m_row.OPTION_TYPE.ToString
            m_intOptSeq = m_row.OPTION_SEQ.ToString
        Catch ex As Exception
            dtOptionMST_Row.RejectChanges()
            m_objClsLogger.LogException(Me.GetType.Name, "UpdateRow", ex, True)
        End Try
    End Sub
#End Region

#Region "Event"
    Private Sub btnAccept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Try
            If cboOptionType.SelectedItem = "DESTINATION" Then
                m_intOptType = dsPAINT.dtOPTION_MSTDataTable.enuOptionType.Destination
            ElseIf cboOptionType.SelectedItem = "OPTION" Then
                m_intOptType = dsPAINT.dtOPTION_MSTDataTable.enuOptionType.OptionTable
            End If

            Select Case m_intOptType
                Case dsPAINT.dtOPTION_MSTDataTable.enuOptionType.Destination
                    lblDestinationError.Text = String.Empty
                    pnlDestination.Visible = True
                Case dsPAINT.dtOPTION_MSTDataTable.enuOptionType.OptionTable
                    lblDisplayError.Text = String.Empty
                    lblNameError.Text = String.Empty
                    pnlOption.Visible = True
            End Select

            cboOptionType.Enabled = False
            btnNext.Visible = False
            btnExecute.Visible = True
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "btnAccept_Click", ex, True)
        End Try
    End Sub

    Private Sub btnExecute_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExecute.Click
        Try
            ResetErrorMSG()

            If IsNotValidate() Then
                Select Case m_enuFormMode
                    Case enuFormMode.Add
                        m_row = InsertRow()
                    Case enuFormMode.Edit
                        UpdateRow()
                End Select

                Me.DialogResult = Windows.Forms.DialogResult.OK
                m_strOptDisp = m_row.OPTION_DISPLAY
            End If
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "btnExecute_Click", ex, True)
        End Try
    End Sub

    Private Sub frmOptionMST_Setting_AddEdit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            taOPTION_MST1.Fill(dsPAINT1.dtOPTION_MST)

            If m_enuFormMode = enuFormMode.Edit Then
                m_row = dtOptMst.FindByOPTION_ID(m_intOptId)
                m_strOptDisp = m_row.OPTION_DISPLAY

                LoadCells()
            End If
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "frmOptionMST_Setting_AddEdit_Load", ex, True)
        End Try
    End Sub
#End Region

End Class