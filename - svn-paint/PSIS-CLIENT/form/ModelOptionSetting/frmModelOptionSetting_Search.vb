Public Class frmModelOptionSetting_Search

#Region "Constant"

#End Region

#Region "Attribute"
    Private m_strModelYearPattern As String
    Private m_strSuffixCodePattern As String

    Private m_taModelOptionRow As New taMODEL_OPTION_ROW
    Private m_objClsLogger As New clsLogger
#End Region

#Region "Constructor"

#End Region

#Region "Property"
    Public WriteOnly Property ModelCode() As String
        Set(ByVal value As String)
            mtbModelCode.Text = value
        End Set
    End Property

    Public ReadOnly Property ModelYearPattern() As String
        Get
            Return m_strModelYearPattern
        End Get
    End Property

    Public ReadOnly Property SuffixCodePattern() As String
        Get
            Return m_strSuffixCodePattern
        End Get
    End Property
#End Region

#Region "Method"

    Private Sub GetResult()
        Dim strModelCode As String = mtbModelCode.Text.ToUpper
        If Char.IsPunctuation(strModelCode.Last) Then strModelCode = strModelCode + "_"

        Dim strModelYearPattern As String = strModelCode.Substring(0, Math.Min(strModelCode.Length, 3)).Replace(" ", "_")
        Dim strSuffixCodePattern As String = strModelCode.Substring(3, Math.Min(strModelCode.Length - 3, 5)).Replace(" ", "_")

        m_taModelOptionRow.FillByModelCode(dsPAINT1.dtMODEL_OPTION_ROW, strModelYearPattern, strSuffixCodePattern)
    End Sub
#End Region

#Region "Event"
    Private Sub frmModelOptionSetting_Search_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            lblMsg.Text = String.Empty
        Catch ex As Exception
            m_objClsLogger.LogException(Me.GetType.Name, "frmModelOptionSetting_Search_Load", ex, True)
        End Try
    End Sub

    Private Sub btnExecution_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExecution.Click
        Try
            lblMsg.Text = String.Empty
            lblModelCode.BackColor = SystemColors.Control

            GetResult()

            If dsPAINT1.dtMODEL_OPTION_ROW.Rows.Count > 0 Then
                Dim drRow As dsPAINT.dtMODEL_OPTION_ROWRow
                drRow = dsPAINT1.dtMODEL_OPTION_ROW.Rows(0)

                m_strModelYearPattern = drRow.MODEL_YEAR_PATTERN
                m_strSuffixCodePattern = drRow.SUFFIX_CODE_PATTERN

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