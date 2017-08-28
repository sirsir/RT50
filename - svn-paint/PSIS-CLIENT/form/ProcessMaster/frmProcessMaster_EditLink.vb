Public Class frmProcessMaster_EditLink
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
    Private m_strSelectedPrevProc As String
    Private m_intProcCode As Integer

    Private m_enuFormMode As enuFormMode
    Private m_enuLastFormMode As enuFormMode
    Private m_row As dsPAINT.dtPROCESS_MSTRow

    Private m_dtPrevProc As New DataTable
    Private m_dtAllProc As New DataTable
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

    Private ReadOnly Property dtProcessLinkage() As dsPAINT.dtPROCESS_LINKAGEDataTable
        Get
            Return dsPAINT1.dtPROCESS_LINKAGE
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

    Public WriteOnly Property ProcessName() As String
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

    Public Property ProcessCode() As Integer
        Get
            Return m_intProcCode
        End Get
        Set(ByVal value As Integer)
            m_intProcCode = value
        End Set
    End Property
#End Region

#Region "Method"
    Private Sub RefreshForm()
        'btnExecute.Visible = (m_enuFormMode = enuFormMode.Edit)
    End Sub

    Private Function IsEntrance() As Boolean
        'Dim blnEntrance As Boolean = False
        Dim blnEntrance As Boolean = True

        For i As Integer = 0 To bsPROCESSLINKAGE.Count - 1
            Dim row As dsPAINT.dtPROCESS_LINKAGERow = bsPROCESSLINKAGE.Item(i).Row

            'If row.PROCESS_TYPE <> m_row.PROCESS_TYPE Then blnEntrance = True : Exit For
            If row.PROCESS_TYPE = m_row.PROCESS_TYPE Then blnEntrance = False : Exit For
        Next

        Return blnEntrance
    End Function

    Private Sub UpdateRow()
        Try
            With m_row
                .BeginEdit()
                .ENTRANCE_FLAG = IsEntrance()
                .EndEdit()
            End With

            taPROCESS_MST1.Update(dtProcessMst)
            dtProcessMst.AcceptChanges()
        Catch ex As Exception
            dtProcessMst.RejectChanges()
            m_objClsLogger.LogException(Me.GetType.Name, "UpdateRow", ex, True)
        End Try
    End Sub

    Private Sub FetchData(Optional ByVal intSelectedProcNo As Integer = 0)
        LoadPreviousProcess()

        If bsPROCESSLINKAGE.Count > 0 Then intSelectedProcNo = bsPROCESSLINKAGE.Item(0).Row.FROM_PROCESS_NO

        LoadAllProcess(intSelectedProcNo)

        btnRight.Enabled = (bsPROCESSMST.Count > 0)
        btnLeft.Enabled = (bsPROCESSLINKAGE.Count > 0)
    End Sub

    Private Sub LoadAllProcess(ByVal intSelectedProcNo As Integer)
        Dim strFilterExpression As String = String.Empty
        strFilterExpression &= "(PROCESS_NO NOT IN ({0}))"
        strFilterExpression &= " AND (PROCESS_TYPE > {1}-1 OR (PROCESS_TYPE = {1}-1 AND 1 = {2}))"
        strFilterExpression &= " AND (PROCESS_TYPE < {1} OR (PROCESS_TYPE = {1} AND 1 = {3}))"

        Dim blnDiffType As Boolean = bsPROCESSLINKAGE.Count = 0

        Dim rowSelected As dsPAINT.dtPROCESS_MSTRow = dtProcessMst.FindByPROCESS_NO(intSelectedProcNo)

        Dim blnIsSelf As Boolean = IsSelf()
        If rowSelected IsNot Nothing AndAlso rowSelected.PROCESS_TYPE <> m_row.PROCESS_TYPE Then
            blnIsSelf = blnIsSelf And blnDiffType
            blnDiffType = True
        End If

        bsPROCESSMST.Filter = String.Format(strFilterExpression, _
                                            m_strSelectedPrevProc, _
                                            m_row.PROCESS_TYPE, _
                                            Convert.ToInt32(blnDiffType), _
                                            Convert.ToInt32(blnIsSelf))

        For i As Integer = 0 To bsPROCESSMST.Count - 1
            If bsPROCESSMST.Item(i).Row.PROCESS_NO = intSelectedProcNo Then bsPROCESSMST.Position = i : Exit For
        Next
    End Sub

    Private Sub LoadPreviousProcess()
        bsPROCESSLINKAGE.Filter = "TO_PROCESS_NO = " + m_row.PROCESS_NO.ToString

        m_strSelectedPrevProc = m_row.PROCESS_NO.ToString
        For i As Integer = 0 To bsPROCESSLINKAGE.Count - 1
            If i < bsPROCESSLINKAGE.Count Then m_strSelectedPrevProc &= ","

            Dim row As dsPAINT.dtPROCESS_LINKAGERow = bsPROCESSLINKAGE.Item(i).Row
            m_strSelectedPrevProc &= row.FROM_PROCESS_NO
        Next
    End Sub

    Private Sub AddPreviousProcess(ByVal selectedRow As dsPAINT.dtPROCESS_MSTRow)
        Dim rowNew As dsPAINT.dtPROCESS_LINKAGERow = Nothing

        Try
            rowNew = dtProcessLinkage.NewdtPROCESS_LINKAGERow

            With rowNew
                .BeginEdit()
                .FROM_PROCESS_NO = selectedRow.PROCESS_NO
                .TO_PROCESS_NO = m_row.PROCESS_NO
                .FROM_PROCESS_NAME = selectedRow.PROCESS_NAME
                .PROCESS_TIME = selectedRow.PROCESS_TIME
                .PROCESS_TYPE = selectedRow.PROCESS_TYPE
                .ENTRANCE_FLAG = selectedRow.ENTRANCE_FLAG
                .EndEdit()
            End With

            dtProcessLinkage.AdddtPROCESS_LINKAGERow(rowNew)
        Catch ex As Exception
            If rowNew IsNot Nothing Then rowNew.CancelEdit()
            dtProcessLinkage.RejectChanges()
            m_objClsLogger.LogException(Me.GetType.Name, "AddPreviousProcess", ex, True)
        End Try

        FetchData(selectedRow.PROCESS_NO)
    End Sub

    Private Sub RemovePreviousProcess(ByVal selectedRow As dsPAINT.dtPROCESS_LINKAGERow)
        Dim intSelectedProcNo As Integer = selectedRow.FROM_PROCESS_NO

        For i As Integer = 0 To bsPROCESSLINKAGE.Count - 1
            If bsPROCESSLINKAGE.Item(i).Row Is selectedRow Then bsPROCESSLINKAGE.RemoveAt(i) : Exit For
        Next

        FetchData(intSelectedProcNo)
    End Sub

    Private Function IsSelf() As Boolean
        Return (m_intProcType = dsPAINT.dtPROCESS_MSTDataTable.enuProcessType.Paint Or _
                m_intProcType = dsPAINT.dtPROCESS_MSTDataTable.enuProcessType.PBR)
    End Function
#End Region

#Region "Event"

    Private Sub frmProcessMaster_EditLink_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Text = String.Format(Me.Text, m_strProcName)
            m_enuLastFormMode = m_enuFormMode

            taPROCESS_MST1.Fill(dsPAINT1.dtPROCESS_MST)
            taPROCESS_LINKAGE1.FillByFromProcNo(dsPAINT1.dtPROCESS_LINKAGE)

            If m_enuFormMode = enuFormMode.Edit Then
                m_row = dtProcessMst.FindByPROCESS_NO(m_intProcNo)

                FetchData()
            End If
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "frmProcessMaster_EditLink_Load", ex, True)
        End Try
    End Sub

    Private Sub btnExecute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExecute.Click
        Try
            UpdateRow()

            taPROCESS_LINKAGE1.Update(dtProcessLinkage)
            dtProcessLinkage.AcceptChanges()

            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            dtProcessLinkage.RejectChanges()
            m_objClsLogger.LogException(Me.GetType.Name, "btnExecute_Click", ex, True)
        End Try
    End Sub

    Private Sub btnRight_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRight.Click
        Try
            Dim selectedRow As dsPAINT.dtPROCESS_MSTRow = dtProcessMst.FindByPROCESS_NO(lsbAllProc.SelectedValue)

            AddPreviousProcess(selectedRow)

            bsPROCESSLINKAGE.MoveLast()
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "btnRight_Click", ex, True)
        End Try
    End Sub

    Private Sub btnLeft_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLeft.Click
        Try
            Dim selectedRow As dsPAINT.dtPROCESS_LINKAGERow = _
            dtProcessLinkage.FindByFROM_PROCESS_NOTO_PROCESS_NO(lsbPrevProc.SelectedValue, m_row.PROCESS_NO)

            RemovePreviousProcess(selectedRow)
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "btnLeft_Click", ex, True)
        End Try
    End Sub

#End Region
End Class
