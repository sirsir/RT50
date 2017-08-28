 MsgBox("Delete Start")
 set shell = WScript.CreateObject("WScript.Shell")

 strShellScript = "sc delete PIS_Service"

 shell.Run(strShellScript)
 MsgBox("Delete Success")
