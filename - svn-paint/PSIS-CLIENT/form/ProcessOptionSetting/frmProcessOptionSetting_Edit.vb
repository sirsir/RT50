Public Class frmProcessOptionSetting_Edit
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

            txtProcNo.Text = m_intProcNo
        End Set
    End Property

    Public Property ProcessName() As String
        Get
            Return m_row.PROCESS_NAME
        End Get
        Set(ByVal value As String)
            m_strProcName = value

            txtProcName.Text = m_strProcName
        End Set
    End Property

    Public ReadOnly Property ProcessCode() As Integer
        Get
            Return m_row.PROCESS_CODE
        End Get
    End Property

    Public Property ProcessType() As Integer
        Get
            Return m_intProcType
        End Get
        Set(ByVal value As Integer)
            m_intProcType = value
        End Set
    End Property

#End Region

#Region "Method"
    Private Sub RefreshForm()
        dgvData.Visible = (m_enuFormMode = enuFormMode.Edit)
        btnExecute.Visible = (m_enuFormMode = enuFormMode.Edit)
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
                Case enuFormMode.Edit
                    For Each col As dsPAINT.dtOPTION_MSTRow In dtOptionMst.Rows
                        Dim dr As dsPAINT.dtPROCESS_OPTION_CELLRow = _
                            dtProcessOptionCell.FindByPROCESS_NOOPTION_ID(m_row.PROCESS_NO, col.OPTION_ID)

                        If col.OPTION_TYPE = OptionType() AndAlso dr Is Nothing Then InsertCells(col)
                    Next
            End Select

            dtProcessOptionCell.AcceptChanges()
        Catch ex As Exception
            dtProcessOptionCell.RejectChanges()
            m_objClsLogger.LogException(Me.GetType.Name, "LoadCells", ex, True)
        End Try

        ShowCells()
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

    Private Sub UpdateCells()
        Try
            Dim dr As dsPAINT.dtPROCESS_OPTION_CELLRow

            ' ''Update Option Table Cell
            For i As Integer = 0 To bsPROCESSOPTIONCELL.Count - 1
                dr = bsPROCESSOPTIONCELL.Item(i).Row

                With dr
                    .BeginEdit()
                    .IS_USED = .IS_USED
                    .EndEdit()
                End With
            Next

            taPROCESS_OPTION_CELL1.Update(dtProcessOptionCell)
            dtProcessOptionCell.AcceptChanges()
        Catch ex As Exception
            dtProcessOptionCell.RejectChanges()
            m_objClsLogger.LogException(Me.GetType.Name, "UpdateCells", ex, True)
        End Try
    End Sub

    Private Sub ShowCells()
        bsPROCESSOPTIONCELL.Filter = "PROCESS_NO = " + m_row.PROCESS_NO.ToString
    End Sub
#End Region

#Region "Event"

    Private Sub frmModelOptionSetting_Edit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Text = String.Format(Me.Text, m_enuFormMode.ToString.ToUpper)
            m_enuLastFormMode = m_enuFormMode

            taPROCESS_MST1.Fill(dsPAINT1.dtPROCESS_MST)
            taOPTION_MST1.Fill(dsPAINT1.dtOPTION_MST)
            taPROCESS_OPTION_CELL1.FillByOptSeq(dsPAINT1.dtPROCESS_OPTION_CELL, OptionType)

            If m_enuFormMode = enuFormMode.Edit Then
                m_row = dtProcessMst.FindByPROCESS_NO(m_intProcNo)
                LoadCells(enuFormMode.Edit)
            End If
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "frmModelOptionSetting_Edit_Load", ex, True)
        End Try
    End Sub

    Private Sub btnExecute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExecute.Click
        Try
            Select Case m_enuFormMode
                Case enuFormMode.Edit
                    UpdateCells()

                    Me.DialogResult = Windows.Forms.DialogResult.OK
            End Select
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "btnExecute_Click", ex, True)
        End Try
    End Sub

#End Region
End Class