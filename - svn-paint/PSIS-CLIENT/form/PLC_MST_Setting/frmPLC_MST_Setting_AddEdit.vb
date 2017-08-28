Public Class frmPLC_MST_Setting_AddEdit

#Region "Enumerator"
    Public Enum enuFormMode
        Add
        Edit
    End Enum
#End Region

#Region "Attribute"
    Dim m_arrLblErrorMsg() As Label
    Dim m_arrTxtBox() As TextBox
    Dim m_arrLblCrtl() As Label

    Private m_strStageCode As String
    Private m_intPlcId As Integer

    Private m_row As dsPAINT.dtPLC_MSTRow
    Private m_enuFormMode As enuFormMode

    Private m_objClsLogger As New clsLogger
#End Region

#Region "Property"

    Public WriteOnly Property FormMode() As enuFormMode
        Set(ByVal value As enuFormMode)
            m_enuFormMode = value
        End Set
    End Property

    Private ReadOnly Property dtPlcMst() As dsPAINT.dtPLC_MSTDataTable
        Get
            Return dsPAINT1.dtPLC_MST
        End Get
    End Property

    Public Property StageCode() As String
        Get
            Return m_strStageCode
        End Get
        Set(ByVal value As String)
            m_strStageCode = value
        End Set
    End Property

    Public Property PlcId() As Integer
        Get
            Return m_intPlcId
        End Get
        Set(ByVal value As Integer)
            m_intPlcId = value
        End Set
    End Property
#End Region

#Region "Method"

    Private Sub ResetErrorMSG()
        For index As Integer = 0 To m_arrTxtBox.Length - 1
            m_arrLblErrorMsg(index).Text = String.Empty
            m_arrLblCrtl(index).BackColor = SystemColors.Control
        Next
    End Sub

    Private Function IsNotValidate() As Boolean
        Dim blnNotValid As Boolean = True
        Dim intStageCode As Integer
        Dim strErrMSG As String
        Dim blnStageCodeDup As Boolean = False

        If m_arrTxtBox(0).Text.Length = 0 Then
            intStageCode = 0
        Else
            intStageCode = Convert.ToInt32(m_arrTxtBox(0).Text)
        End If

        Dim drs() As dsPAINT.dtPLC_MSTRow = dtPlcMst.Select("STAGE_CODE = " + intStageCode.ToString)

        If m_enuFormMode = enuFormMode.Add And drs.Length > 0 AndAlso intStageCode = drs(0).STAGE_CODE Then
            blnStageCodeDup = True
        ElseIf m_enuFormMode = enuFormMode.Edit And drs.Length > 0 AndAlso intStageCode <> m_row.STAGE_CODE Then
            blnStageCodeDup = True
        End If

        If blnStageCodeDup Then
            m_arrLblErrorMsg(0).Text = "STAGE CODE IS DUPLICATE"
            m_arrLblCrtl(0).BackColor = Color.Red
            blnNotValid = False
        End If

        For index As Integer = 0 To m_arrTxtBox.Length - 1
            If m_arrTxtBox(index).Text.Length = 0 Then
                strErrMSG = String.Format("PLEASE INSERT {0} VALUE", ParseColumnName(m_arrTxtBox(index).Name.Substring(3)))
                m_arrLblErrorMsg(index).Text = strErrMSG
                m_arrLblCrtl(index).BackColor = Color.Red
                blnNotValid = False
            End If
        Next

        Return blnNotValid
    End Function

    Private Function InsertRow() As dsPAINT.dtPLC_MSTRow
        Dim dr As dsPAINT.dtPLC_MSTRow = Nothing

        Try
            dr = dtPlcMst.NewdtPLC_MSTRow

            With dr
                .BeginEdit()
                .STAGE_CODE = Convert.ToInt32(m_arrTxtBox(0).Text)
                .PLC_NET = Convert.ToInt32(m_arrTxtBox(1).Text)
                .PLC_NODE = Convert.ToInt32(m_arrTxtBox(2).Text)
                .PLC_UNIT = Convert.ToInt32(m_arrTxtBox(3).Text)
                .READ_DM = Convert.ToInt32(m_arrTxtBox(4).Text)
                .WRITE_DATA_DM = Convert.ToInt32(m_arrTxtBox(5).Text)
                .WRITE_STATUS_DM = Convert.ToInt32(m_arrTxtBox(6).Text)
                .PLC_ONLINE_FLAG = chkPLC_ONLINE_FLAG.Checked
                .PROCESS_NO = cboPROCESS_NAME.SelectedValue
                .EndEdit()
            End With

            dtPlcMst.AdddtPLC_MSTRow(dr)
            taPLC_MST1.Update(dtPlcMst)
            dtPlcMst.AcceptChanges()
        Catch ex As Exception
            dtPlcMst.RejectChanges()
            m_objClsLogger.LogException(Me.GetType.Name, "InsertRow", ex, True)
        End Try

        Return dr
    End Function

    Private Sub UpdateRow()
        Try
            With m_row
                .BeginEdit()
                .STAGE_CODE = Convert.ToInt32(m_arrTxtBox(0).Text)
                .PLC_NET = Convert.ToInt32(m_arrTxtBox(1).Text)
                .PLC_NODE = Convert.ToInt32(m_arrTxtBox(2).Text)
                .PLC_UNIT = Convert.ToInt32(m_arrTxtBox(3).Text)
                .READ_DM = Convert.ToInt32(m_arrTxtBox(4).Text)
                .WRITE_DATA_DM = Convert.ToInt32(m_arrTxtBox(5).Text)
                .WRITE_STATUS_DM = Convert.ToInt32(m_arrTxtBox(6).Text)
                .PLC_ONLINE_FLAG = chkPLC_ONLINE_FLAG.Checked
                .PROCESS_NO = cboPROCESS_NAME.SelectedValue
                .EndEdit()
            End With

            taPLC_MST1.Update(m_row)
            m_row.AcceptChanges()
        Catch ex As Exception
            m_row.RejectChanges()
            m_objClsLogger.LogException(Me.GetType.Name, "UpdateRow", ex, True)
        End Try
    End Sub

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsNumber(e.KeyChar) = False AndAlso Char.IsControl(e.KeyChar) = False Then
            e.Handled = True
        End If
    End Sub

    Private Sub LoadCells()
        For index As Integer = 0 To m_arrTxtBox.Length - 1
            m_arrTxtBox(index).Text = m_row.Item(index + 1)
        Next

        chkPLC_ONLINE_FLAG.Checked = m_row.Item(9)
        cboPROCESS_NAME.SelectedValue = m_row.Item(8)
    End Sub
#End Region

#Region "Event"

    Private Sub frmPLC_MST_Setting_AddEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            m_arrLblErrorMsg = New Label() {lblSTAGE_CODE_Err, lblPLC_NET_Err, lblPLC_NODE_Err, _
                             lblPLC_UNIT_Err, lblREAD_DM_Err, lblWRITE_DATA_DM_Err, _
                             lblWRITE_STATUS_DM_Err}
            m_arrTxtBox = New TextBox() {txtSTAGE_CODE, txtPLC_NET, txtPLC_NODE, txtPLC_UNIT, txtREAD_DM, _
                                     txtWRITE_DATA_DM, txtWRITE_STATUS_DM}

            For Each txt As TextBox In m_arrTxtBox
                AddHandler txt.KeyPress, AddressOf txt_KeyPress
            Next

            m_arrLblCrtl = New Label() {lblSTAGE_CODE, lblPLC_NET, lblPLC_NODE, lblPLC_UNIT, lblREAD_DM, _
                                        lblWRITE_DATA_DM, lblWRITE_STATUS_DM}

            taPROCESS_MST1.Fill(Me.dsPAINT1.dtPROCESS_MST)
            taPLC_MST1.Fill(dsPAINT1.dtPLC_MST)

            ResetErrorMSG()

            If m_enuFormMode = enuFormMode.Edit Then
                m_row = dtPlcMst.FindByPLC_ID(m_intPlcId)

                LoadCells()
            End If
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "frmPLC_MST_Setting_AddEdit_Load", ex, True)
        End Try
    End Sub

    Private Sub btnExecution_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExecution.Click
        Try
            ResetErrorMSG()

            If IsNotValidate() Then
                Select Case m_enuFormMode
                    Case enuFormMode.Add
                        m_row = InsertRow()
                    Case enuFormMode.Edit
                        UpdateRow()

                        m_strStageCode = m_row.STAGE_CODE
                        m_intPlcId = m_row.PLC_ID
                End Select

                m_strStageCode = m_row.STAGE_CODE
                m_intPlcId = m_row.PLC_ID

                Me.DialogResult = Windows.Forms.DialogResult.OK
            End If
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "btnExecution_Click", ex, True)
        End Try
    End Sub
#End Region
End Class