Public Class frmProcessMaster_AddEdit
#Region "Constant"

#End Region

#Region "Enumerator"
    Public Enum enuFormMode
        Add
        Edit
    End Enum
#End Region

#Region "Attribute"
    Private m_intProcNo As Integer
    Private m_strProcName As String
    Private m_intProcType As Integer
    Private m_intProcTime As Integer
    Private m_intProcCode As Integer
    Private m_intProcGroup As Integer

    Private m_enuFormMode As enuFormMode
    Private m_enuLastFormMode As enuFormMode
    Private m_row As dsPAINT.dtPROCESS_MSTRow

    Private m_objClsLogger As New clsLogger
#End Region

#Region "Constructor"

#End Region

#Region "Property"
    Public WriteOnly Property FormMode() As enuFormMode
        Set(ByVal value As enuFormMode)
            m_enuFormMode = value

            RefreshForm()
        End Set
    End Property

    Private ReadOnly Property dtProcessMst() As dsPAINT.dtPROCESS_MSTDataTable
        Get
            Return dsPAINT1.dtPROCESS_MST
        End Get
    End Property

    Private ReadOnly Property dtOptionMst() As dsPAINT.dtOPTION_MSTDataTable
        Get
            Return dsPAINT1.dtOPTION_MST
        End Get
    End Property

    Private ReadOnly Property dtProcessOptionCell() As dsPAINT.dtPROCESS_OPTION_CELLDataTable
        Get
            Return dsPAINT1.dtPROCESS_OPTION_CELL
        End Get
    End Property

    Private ReadOnly Property OptionType() As dsPAINT.dtOPTION_MSTDataTable.enuOptionType
        Get
            Return dsPAINT.dtOPTION_MSTDataTable.enuOptionType.OptionTable
        End Get
    End Property

    Public Property ProcessNo() As Integer
        Get
            Return m_intProcNo
        End Get
        Set(ByVal value As Integer)
            m_intProcNo = value
        End Set
    End Property

    Public Property ProcessName() As String
        Get
            Return m_strProcName
        End Get
        Set(ByVal value As String)
            m_strProcName = value

            txtProcName.Text = m_strProcName
        End Set
    End Property

    Public Property ProcessType() As Integer
        Get
            Return m_intProcType
        End Get
        Set(ByVal value As Integer)
            m_intProcType = value
        End Set
    End Property

    Public Property ProcessTime() As Integer
        Get
            Return m_intProcTime
        End Get
        Set(ByVal value As Integer)
            m_intProcTime = value

            txtProcTime.Text = m_intProcTime
        End Set
    End Property

    Public Property ProcessCode() As Integer
        Get
            Return m_intProcCode
        End Get
        Set(ByVal value As Integer)
            m_intProcCode = value

            nmrProcCode.Value = m_intProcCode
        End Set
    End Property

    Public Property ProcessGroup() As Integer
        Get
            Return m_intProcGroup
        End Get
        Set(ByVal value As Integer)
            m_intProcGroup = value
        End Set
    End Property
#End Region

#Region "Method"
    Private Sub RefreshForm()
        'btnExecute.Visible = (m_enuFormMode = enuFormMode.Edit)
    End Sub

    Private Function IsNotValidate() As Boolean
        Dim blnNotValid As Boolean = True
        Dim clrProcCodeIsValid As Color = SystemColors.Control
        Dim clrProcNameIsValid As Color = SystemColors.Control
        Dim clrProcTimeIsValid As Color = SystemColors.Control
        Dim strMsgProcCode As String = String.Empty
        Dim strMsgProcName As String = String.Empty
        Dim strMsgProcTime As String = String.Empty

        Dim intProcCode As Integer = nmrProcCode.Value
        Dim strProcName As String = txtProcName.Text.Trim.ToUpper
        Dim strProcTime As String = txtProcTime.Text.Trim

        For Each dr As dsPAINT.dtPROCESS_MSTRow In dtProcessMst
            If intProcCode <> m_intProcCode AndAlso intProcCode = dr.PROCESS_CODE Then
                strMsgProcCode = String.Format("Error: {0} is duplicated.", intProcCode)

                clrProcCodeIsValid = Color.Red
                blnNotValid = False

                Exit For
            End If
        Next


        If strProcName.Length = 0 Then
            strMsgProcName = "Error: Process Name can not empty value."

            clrProcNameIsValid = Color.Red
            blnNotValid = False
        Else
            Dim drs() As dsPAINT.dtPROCESS_MSTRow = dtProcessMst.Select("UPPER_PROCESS_NAME = '" + strProcName + "'")

            If drs.Length > 0 AndAlso drs.First.PROCESS_NAME <> m_strProcName Then
                strMsgProcName = String.Format("Error: {0} is duplicated.", txtProcName.Text.Trim)

                clrProcNameIsValid = Color.Red
                blnNotValid = False
            End If
        End If

        If strProcTime.Length = 0 Then
            strMsgProcTime = "Error: Process Time can not empty value."

            clrProcTimeIsValid = Color.Red
            blnNotValid = False
        ElseIf Convert.ToInt32(strProcTime) > 3600 Then
            strMsgProcTime = "Error: Process Time can not over 3600 sec."

            clrProcTimeIsValid = Color.Red
            blnNotValid = False
        End If

        lblProcCode.BackColor = clrProcCodeIsValid
        lblProcName.BackColor = clrProcNameIsValid
        lblProcTime.BackColor = clrProcTimeIsValid
        lblMsgProcCode.Text = strMsgProcCode
        lblMsgProcName.Text = strMsgProcName
        lblMsgProcTime.Text = strMsgProcTime

        Return blnNotValid
    End Function

    Private Function InsertRow() As dsPAINT.dtPROCESS_MSTRow
        Dim dr As dsPAINT.dtPROCESS_MSTRow = Nothing

        Try
            dr = dtProcessMst.NewdtPROCESS_MSTRow

            With dr
                .BeginEdit()
                .PROCESS_CODE = nmrProcCode.Value
                .PROCESS_NAME = txtProcName.Text.Trim
                .PROCESS_TIME = txtProcTime.Text
                .PROCESS_TYPE = cboProcType.SelectedValue
                .PROCESS_GROUP_ID = cboProcGroup.SelectedValue
                .ENTRANCE_FLAG = False
                .EndEdit()
            End With

            dtProcessMst.AdddtPROCESS_MSTRow(dr)

            taPROCESS_MST1.Update(dtProcessMst)
            dtProcessMst.AcceptChanges()
        Catch ex As Exception
            dtProcessMst.RejectChanges()
            m_objClsLogger.LogException(Me.GetType.Name, "InsertRow", ex, True)
        End Try

        Return dr
    End Function

    Private Sub UpdateRow()
        Try
            With m_row
                .BeginEdit()
                .PROCESS_CODE = nmrProcCode.Value
                .PROCESS_NAME = txtProcName.Text.Trim
                .PROCESS_TIME = txtProcTime.Text
                .PROCESS_TYPE = cboProcType.SelectedValue
                .PROCESS_GROUP_ID = cboProcGroup.SelectedValue
                .EndEdit()
            End With

            taPROCESS_MST1.Update(dtProcessMst)
            dtProcessMst.AcceptChanges()
        Catch ex As Exception
            dtProcessMst.RejectChanges()
            m_objClsLogger.LogException(Me.GetType.Name, "UpdateRow", ex, True)
        End Try
    End Sub

    Private Sub LoadCells(ByVal nFormMode As enuFormMode)
        Try
            Select Case nFormMode
                Case enuFormMode.Add
                    For Each col As dsPAINT.dtOPTION_MSTRow In dtOptionMst.Rows
                        If col.OPTION_TYPE = OptionType() Then
                            InsertCells(col)
                        End If
                    Next
            End Select

            dtProcessOptionCell.AcceptChanges()
        Catch ex As Exception
            dtProcessOptionCell.RejectChanges()
            m_objClsLogger.LogException(Me.GetType.Name, "LoadCells", ex, True)
        End Try
    End Sub

    Private Sub InsertCells(ByVal col As dsPAINT.dtOPTION_MSTRow)
        Dim dr As dsPAINT.dtPROCESS_OPTION_CELLRow = dtProcessOptionCell.NewdtPROCESS_OPTION_CELLRow

        With dr
            .BeginEdit()
            .PROCESS_NO = m_row.PROCESS_NO
            .OPTION_ID = col.OPTION_ID
            .IS_USED = False
            .EndEdit()
        End With

        dtProcessOptionCell.AdddtPROCESS_OPTION_CELLRow(dr)

        taPROCESS_OPTION_CELL1.Update(dtProcessOptionCell)
    End Sub

    Private Function dtProcessType() As DataTable
        Dim dtProcTypeItem As New DataTable
        dtProcTypeItem.Columns.Add("Value")
        dtProcTypeItem.Columns.Add("Display")

        For Each nProcType As dsPAINT.dtPROCESS_MSTDataTable.enuProcessType In ProcTypes
            If nProcType <> dsPAINT.dtPROCESS_MSTDataTable.enuProcessType.All Then
                Dim dr As DataRow = dtProcTypeItem.NewRow
                dr.Item(0) = Convert.ToInt32(nProcType)
                dr.Item(1) = nProcType.ToString

                dtProcTypeItem.Rows.Add(dr)
            End If
        Next

        Return dtProcTypeItem
    End Function
#End Region

#Region "Event"

    Private Sub frmProcessMaster_AddEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Text = String.Format(Me.Text, m_enuFormMode.ToString.ToUpper)
            m_enuLastFormMode = m_enuFormMode

            lblMsgProcCode.Text = String.Empty
            lblMsgProcName.Text = String.Empty
            lblMsgProcTime.Text = String.Empty

            taPROCESS_MST1.Fill(dsPAINT1.dtPROCESS_MST)
            taOPTION_MST1.Fill(dsPAINT1.dtOPTION_MST)
            taPROCESS_OPTION_CELL1.FillByOptSeq(dsPAINT1.dtPROCESS_OPTION_CELL, OptionType)
            taPROCESS_GROUP_MST1.Fill(dsPAINT1.dtPROCESS_GROUP_MST)

            cboProcType.DataSource = dtProcessType()

            If m_enuFormMode = enuFormMode.Edit Then
                m_row = dtProcessMst.FindByPROCESS_NO(m_intProcNo)
                cboProcType.SelectedValue = m_intProcType
                cboProcGroup.SelectedValue = m_intProcGroup
            End If
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "frmProcessMaster_AddEdit_Load", ex, True)
        End Try
    End Sub

    Private Sub btnExecute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExecute.Click
        Try
            lblProcCode.BackColor = SystemColors.Control
            lblProcName.BackColor = SystemColors.Control
            lblProcTime.BackColor = SystemColors.Control
            lblMsgProcCode.Text = String.Empty
            lblMsgProcName.Text = String.Empty
            lblMsgProcTime.Text = String.Empty

            If IsNotValidate() Then
                Select Case m_enuFormMode
                    Case enuFormMode.Add
                        m_row = InsertRow()
                        LoadCells(enuFormMode.Add)

                        m_intProcCode = m_row.PROCESS_CODE
                        m_intProcType = m_row.PROCESS_TYPE
                        m_intProcGroup = m_row.PROCESS_GROUP_ID
                    Case enuFormMode.Edit
                        UpdateRow()

                        m_intProcCode = m_row.PROCESS_CODE
                        m_intProcType = m_row.PROCESS_TYPE
                        m_intProcGroup = m_row.PROCESS_GROUP_ID
                End Select

                Me.DialogResult = Windows.Forms.DialogResult.OK
                m_strProcName = m_row.PROCESS_NAME
            End If
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "btnExecute_Click", ex, True)
        End Try
    End Sub

    Private Sub txtProcTime_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProcTime.KeyPress
        Try
            If Char.IsNumber(e.KeyChar) = False AndAlso Char.IsControl(e.KeyChar) = False Then
                e.Handled = True
            End If
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "txtProcTime_KeyPress", ex, True)
        End Try
    End Sub

#End Region

End Class
