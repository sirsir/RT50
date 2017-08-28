Namespace My

    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication

        Private m_clsLog As New clsLogger

        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup

            'Dim TargetProcess As System.Diagnostics.Process() = System.Diagnostics.Process.GetProcessesByName("PSIS-SERVER")
            'Dim TargetProcessDebug As System.Diagnostics.Process() = System.Diagnostics.Process.GetProcessesByName("PSIS-SERVER.vshost")
            'If TargetProcess.Length + TargetProcessDebug.Length <> 1 Then
            '    MsgBox("There is another instance of PSIS-SERVER running", MsgBoxStyle.Information)
            '    e.Cancel = True
            '    Return
            'End If

            m_clsLog.SystemStart()
            modIni.LoadIni(enuAppType.server)
            m_clsLog.Log(clsLogger.MessageType.NormalLog, Me.GetType.Name, "StartUp", "LoadINI", "")

            LoadLogMessageMaster()
            m_clsLog.Log(clsLogger.MessageType.NormalLog, Me.GetType.Name, "StartUp", "LoadLogMaster", "")

            LoadProcessMaster()
            For i As Integer = 0 To modLoadData.PlcStatusDataTable.Count - 1
                modLoadData.PlcStatusDataTable(i).CUR_STATUS = "Normal"
                modLoadData.PlcStatusDataTable(i).LASTEST_MSG = "Starting"
            Next
            m_clsLog.Log(clsLogger.MessageType.NormalLog, Me.GetType.Name, "StartUp", "LoadProcessMaster", "")

            'Initail PLC Driver
            HMI_LIB.FinsGW.uStartUP_FGW()

        End Sub

        Private Sub MyApplication_Shutdown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shutdown
            For i As Integer = 0 To modLoadData.ProcessMasterDataTable.Count - 1
                Dim dr As dsPAINT.dtPROCESS_MSTRow = modLoadData.ProcessMasterDataTable.Rows(i)
                HMI_LIB.FinsGW.uEndFGW(dr.PROCESS_NO)
            Next
            HMI_LIB.FinsGW.uEndFGW(0)
            System.GC.Collect()
            m_clsLog.SystemEnd()
        End Sub

    End Class

End Namespace

