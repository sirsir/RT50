Public Class Form1
    Private dtPlcStatus As Common.dsPAINT.dtPlcStatusDataTable
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Common.modIni.LoadIni(Common.enuAppType.server)
        Common.modLoadData.LoadProcessMaster()
        dtPlcStatus = Common.modLoadData.PlcStatusDataTable()
        Dim arrCtrl As New ArrayList
        Dim dtPlcMst As Common.dsPAINT.dtPLC_MSTDataTable = Common.modLoadData.PlcMasterDataTable
        For Each dr As Common.dsPAINT.dtPlcStatusRow In dtPlcStatus
            Dim drPlcMst() As Common.dsPAINT.dtPLC_MSTRow = dtPlcMst.Select("STAGE_CODE = " & dr.STAGE_CODE)
            Me.FlowLayoutPanel1.Controls.Add(New ctrlPlcMessage(drPlcMst(0)))
        Next
    End Sub

    Private Sub btnExecute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExecute.Click
        Dim arrCtrl() As Control = Me.FlowLayoutPanel1.Controls.Find("ctrlPlcMessage", True)
        For Each ctrl As ctrlPlcMessage In arrCtrl
            'ctrl.WriteMessageToPlc()
            ctrl.BackgroundStart()
        Next
    End Sub

    Private Sub btnSetStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetStatus.Click
        Dim arrCtrl() As Control = Me.FlowLayoutPanel1.Controls.Find("ctrlPlcMessage", True)
        For Each ctrl As ctrlPlcMessage In arrCtrl
            ctrl.SetStatus(Me.txtStatusAll.Text)
        Next
    End Sub
End Class
