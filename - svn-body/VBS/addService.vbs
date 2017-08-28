 MsgBox("Add Start")
 set shell = WScript.CreateObject("WScript.Shell")
 strPath = Wscript.ScriptFullName
 Set objFSO = CreateObject("Scripting.FileSystemObject")
 Set objFile = objFSO.GetFile(strPath)
 strFolder = objFSO.GetParentFolderName(objFile)
 
 Set scriptFolder = objFSO.GetFolder(strFolder) 
 
 Set setupFolder = scriptFolder.ParentFolder
 setupFolderPath = setupFolder.Path
 binPath = setupFolderPath & "\bin\"
 
 strServicePath = binPath & "PIS-SERVICE.exe"
 
 strShellScript = "sc create PIS_Service binPath= """ & strServicePath & """ start= auto DisplayName= ""PIS Scheduled Service"""

 shell.Run(strShellScript)
 MsgBox("Add Success")
