Public Class ctrlProcGroup

#Region "Attribute"
    Dim m_intProcGroupID As Integer
    Dim m_dtProcMST As dsPAINT.dtPROCESS_MSTDataTable = New dsPAINT.dtPROCESS_MSTDataTable
    Dim m_taProcMST As dsPAINTTableAdapters.taPROCESS_MST = New dsPAINTTableAdapters.taPROCESS_MST
    Dim m_dtPaintProgress As dsPAINT.dtPAINT_PROGRESSDataTable = New dsPAINT.dtPAINT_PROGRESSDataTable
    Dim m_taPaintProgress As dsPAINTTableAdapters.taPAINT_PROGRESS = New dsPAINTTableAdapters.taPAINT_PROGRESS
    Dim m_intCountGroup As Integer
    Private m_objClsLogger As New clsLogger
#End Region

#Region "Constructor"
    Public Sub New(ByVal intProcGroupID As Integer, ByVal intCountGroup As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_intProcGroupID = intProcGroupID
        m_intCountGroup = intCountGroup

        LoadProcess()
    End Sub
#End Region

#Region "Method"
    Private Sub LoadProcess()
        Dim intSumCount As Integer

        m_taProcMST.FillByProcGroupID(m_dtProcMST, m_intProcGroupID)

        Me.ctrlGroup.lblProcCode.Hide()

        AddHandler Me.ctrlGroup.lblProcCount.Click, AddressOf lblCountClick

        For Each row As dsPAINT.dtPROCESS_MSTRow In m_dtProcMST.Rows
            Dim ctrlProc As ctrlProcess = New ctrlProcess()

            m_taPaintProgress.Fill(m_dtPaintProgress, row.PROCESS_NO)

            ctrlProc.lblProcCode.Text = row.PROCESS_CODE
            ctrlProc.lblProcName.Text = row.PROCESS_NAME
            ctrlProc.lblProcCount.Text = m_dtPaintProgress.Rows.Count
            ctrlProc.lblProcCount.Name = "lblProcCount" + row.PROCESS_NO.ToString

            intSumCount += m_dtPaintProgress.Rows.Count

            Me.flpProcess.Controls.Add(ctrlProc)

            AddHandler ctrlProc.lblProcCount.Click, AddressOf lblCountClick

            If m_intCountGroup > 4 Then
                ctrlProc.lblProcCode.Size = New Size(ctrlProc.lblProcCode.Size.Width - 3, ctrlProc.lblProcCode.Size.Height - 5)
                ctrlProc.lblProcCode.Font = New System.Drawing.Font("Arial", 7)
                ctrlProc.lblProcCode.Location = New Point(ctrlProc.lblProcCode.Location.X + 15, ctrlProc.lblProcCode.Location.Y)

                ctrlProc.lblProcName.Size = New Size(ctrlProc.lblProcName.Size.Width - 20, ctrlProc.lblProcName.Size.Height - 5)
                ctrlProc.lblProcName.Font = New System.Drawing.Font("Arial", 7)
                ctrlProc.lblProcName.Location = New Point(ctrlProc.lblProcName.Location.X + 10, ctrlProc.lblProcName.Location.Y)

                ctrlProc.lblProcCount.Size = New Size(ctrlProc.lblProcCount.Size.Width - 3, ctrlProc.lblProcCount.Size.Height - 5)
                ctrlProc.lblProcCount.Font = New System.Drawing.Font("Arial", 7)
                ctrlProc.lblProcCount.Location = New Point(ctrlProc.lblProcCount.Location.X - 11, ctrlProc.lblProcCount.Location.Y)

                ctrlProc.Size = New Size(ctrlProc.Size.Width - 30, ctrlProc.Size.Height - 5)
            End If
        Next

        Me.ctrlGroup.lblProcCount.Text = intSumCount.ToString
    End Sub
#End Region

#Region "Event"
    Public Event OnClickLableCount(ByVal sender As Object, ByVal e As EventArgs)

    Private Sub lblCountClick(ByVal sender As Object, ByVal e As EventArgs)
        Try
            RaiseEvent OnClickLableCount(sender, e)
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "OnClickLableCount", ex, True)
        End Try
    End Sub
#End Region
End Class
