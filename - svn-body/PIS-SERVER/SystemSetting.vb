Imports Common

Public Class SystemSetting

    'Private Const SCREEN_NAME As String = "SYSTEM_SETTING"

    'Private Sub SystemSetting_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    '    Dim colObj As clsColumnSetup = New clsColumnSetup()
    '    'colObj.writeInsColum(DataGridIdata, SCREEN_NAME)
    '    colObj.setColumnIni(dtgLineMST, SCREEN_NAME)

    '    Me.Dispose()
    'End Sub

    Private m_clsLogger As New Logger

    Private Sub SystemSetting_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'TODO: This line of code loads data into the 'ServerDataset.T_Line_MST' table. You can move, or remove it, as needed.
        Try
            m_clsLogger.Log(Logger.MessageType.NormalLog, Me.GetType.Name, "SystemSetting_Load", "Start", "")
            Dim intResult As Integer = Me.T_Line_MSTTableAdapter.FillByAllMST(Me.ServerDataset.T_Line_MST)
            intResult = intResult
        Catch ex As Exception
            m_clsLogger.Log(Logger.MessageType.ErrorLog, Me.GetType.Name, "SystemSetting_Load", ex.Message, ex.StackTrace)
        End Try
        m_clsLogger.Log(Logger.MessageType.NormalLog, Me.GetType.Name, "SystemSetting_Load", "End", "")
        'Dim Line_MST_DT As ServerDataset.T_Line_MSTDataTable = New ServerDataset.T_Line_MSTDataTable
        'Dim TA_Line_MST As ServerDatasetTableAdapters.T_Line_MSTTableAdapter

        'Dim colObj As clsColumnSetup = New clsColumnSetup()
        'setDatagridColWidthIni(colObj.getColumnIni(dtgLineMST.Columns.Count, SCREEN_NAME))

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    'Private Sub setDatagridColWidthIni(ByVal arr As String())
    '    Dim i As Integer
    '    Dim array() As String
    '    array = arr
    '    For i = 0 To array.Length - 1
    '        Me.dtgLineMST.Columns(i).Width = Integer.Parse(array(i))
    '    Next
    'End Sub

    Private Sub btnUpdateLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateLine.Click



        Try
            m_clsLogger.Log(Logger.MessageType.NormalLog, Me.GetType.Name, "btnUpdateLine_Click", "Start", "")
            Dim Line_MST_DT As ServerDataset.T_Line_MSTDataTable = New ServerDataset.T_Line_MSTDataTable

            Me.T_Line_MSTTableAdapter.FillByAllMST(Line_MST_DT)

            Dim lineCode As Integer
            Dim lineName As String
            Dim lineType As Integer
            Dim MainLineFlg As Boolean
            Dim onlineFlg As Boolean

            Dim part1 As Boolean
            Dim part2 As Boolean
            Dim part3 As Boolean
            Dim part4 As Boolean
            Dim part5 As Boolean

            Dim ipAddr As String
            Dim readReq As Integer
            Dim writeProdReq As Integer
            Dim writeCrrOut As Integer
            'Dim status As String
            'Dim messages As String
            Dim netAddr As Integer
            Dim nodeAddr As Integer
            Dim unit As Integer

            For Each drLine In Line_MST_DT

                For i = 0 To dtgLineMST.Rows.Count - 1

                    If drLine.LineCode = dtgLineMST.Item(0, i).Value Then

                        lineCode = dtgLineMST.Item(0, i).Value
                        lineName = dtgLineMST.Item(1, i).Value.ToString
                        lineType = dtgLineMST.Item(2, i).Value
                        MainLineFlg = dtgLineMST.Item(3, i).Value
                        onlineFlg = dtgLineMST.Item(4, i).Value

                        part1 = dtgLineMST.Item(5, i).Value
                        part2 = dtgLineMST.Item(6, i).Value
                        part3 = dtgLineMST.Item(7, i).Value
                        part4 = dtgLineMST.Item(8, i).Value
                        part5 = dtgLineMST.Item(9, i).Value

                        ipAddr = dtgLineMST.Item(10, i).Value.ToString

                        readReq = dtgLineMST.Item(11, i).Value
                        writeProdReq = dtgLineMST.Item(12, i).Value
                        writeCrrOut = dtgLineMST.Item(13, i).Value
                        'status = dtgLineMST.Item(14, i).Value.ToString
                        'messages = dtgLineMST.Item(15, i).Value.ToString
                        netAddr = dtgLineMST.Item(16, i).Value
                        nodeAddr = dtgLineMST.Item(17, i).Value
                        unit = dtgLineMST.Item(18, i).Value

                        Me.T_Line_MSTTableAdapter.UpdateLineByLineCode(part1, part2, part3, part4, part5, onlineFlg, lineName, MainLineFlg, ipAddr, netAddr, nodeAddr, unit, readReq, writeProdReq, writeCrrOut, lineType, lineCode)

                        Exit For
                    End If

                Next

            Next

            MessageBox.Show("Update Line Master successful", "System Setting", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.T_Line_MSTTableAdapter.FillByAllMST(Me.ServerDataset.T_Line_MST)

            '************** new conecpt *************
            'Line_MST_DT = dtgLineMST.
            'T_Line_MSTTableAdapter.Update(Line_MST_DT)
        Catch ex As Exception
            m_clsLogger.Log(Logger.MessageType.ErrorLog, Me.GetType.Name, "btnUpdateLine_Click", ex.Message, ex.StackTrace)
        End Try
        m_clsLogger.Log(Logger.MessageType.NormalLog, Me.GetType.Name, "btnUpdateLine_Click", "End", "")

    End Sub

    'Private Sub btnAddLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    LineMSTDetail.Show()
    'End Sub

    'Private Sub btnDeleteLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    If MessageBox.Show("Confirm delete LineCode " & dtgLineMST.CurrentRow.Cells(0).Value, "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.OK Then
    '        Me.T_Line_MSTTableAdapter.DeleteLineByLineNo(dtgLineMST.CurrentRow.Cells(0).Value)
    '    End If

    '    Me.T_Line_MSTTableAdapter.FillByAllMST(Me.ServerDataset.T_Line_MST)

    'End Sub

    Private Sub dtgLineMST_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgLineMST.CellValueChanged

        If e.ColumnIndex = 4 And e.RowIndex <> -1 Then

            If dtgLineMST.Item(4, e.RowIndex).Value = False Then
                dtgLineMST.Item(2, e.RowIndex).Value = 0
            Else
                LineType.row = e.RowIndex
                LineType.LineCode = Me.dtgLineMST.Item(0, e.RowIndex).Value
                LineType.LineName = Me.dtgLineMST.Item(1, e.RowIndex).Value
                LineType.Show()
                Me.Enabled = False
            End If
        End If

    End Sub

    'Private Sub TLineMSTBindingSource_CurrentChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TLineMSTBindingSource.CurrentChanged

    'End Sub

    'Private Sub TLineMSTBindingSource_CurrentItemChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TLineMSTBindingSource.CurrentItemChanged

    'End Sub

    'Private Sub TLineMSTBindingSource_DataMemberChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TLineMSTBindingSource.DataMemberChanged

    'End Sub


End Class