Module logService

    Sub Main()
        Dim arrArgs As System.Collections.ObjectModel.ReadOnlyCollection(Of String) = My.Application.CommandLineArgs
        'arrArgs(0) - LOG_CODE  : 

        If arrArgs.Count = 0 Then
            Console.WriteLine("Wrong insert parameter!!!")
            Console.WriteLine("*arrArgs(0) - LOG_CODE  : ")
            Console.WriteLine("Example:")
            Console.WriteLine("log-service <<LOG_CODE>>")
        Else
            Dim clsDbLogger As New clsDBLogger
            LoadIni(enuAppType.service)
            LoadLogMessageMaster()
            clsDbLogger.Log(arrArgs(0), Nothing)
        End If
    End Sub

End Module
