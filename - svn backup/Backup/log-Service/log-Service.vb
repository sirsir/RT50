Imports System.IO
Imports Common
Imports PIS_SERVER

Module log_Service

    Sub Main()
        Dim arrArgs As System.Collections.ObjectModel.ReadOnlyCollection(Of String) = My.Application.CommandLineArgs
        'arrArgs(0) - logType  : 0 , 1 , 2
        'arrArgs(1) - logLevel : 0 - errorLog
        '                        1 - normalLog
        '                        2 - warningLog
        'arrArgs(2) - logMessage 
        'arrArgs(3) - module name
        'arrArgs(4) - procedure name

        If arrArgs.Count = 0 Then
            Console.WriteLine("Wrong insert parameter!!!")
            Console.WriteLine("*arrArgs(0) - logType  : 0 (AS400) , 1 (PLC) , 2 (Operation)")
            Console.WriteLine("*arrArgs(1) - logLevel : 0 - normalLog")
            Console.WriteLine("                         1 - warningLog")
            Console.WriteLine("                         2 - errorLog")
            Console.WriteLine("*arrArgs(2) - logMessage")
            Console.WriteLine("arrArgs(3) - module name")
            Console.WriteLine("arrArgs(4) - procedure name")
            Console.WriteLine("Example:")
            Console.WriteLine("log-service 0 0 ""example log msg""")
            Console.ReadLine()
        Else

            Dim clsTLogDat As New TLogDat
            Dim log As New Logger
            
            Dim Number As Integer = arrArgs(1)
            Select Case Number
                Case 0
                    clsTLogDat.InsertNewLog(arrArgs(0), TLogDat.LogLevel.NormalLog, My.Computer.Name, Now, arrArgs(2), Nothing)

                Case 1
                    clsTLogDat.InsertNewLog(arrArgs(0), TLogDat.LogLevel.WarningLog, My.Computer.Name, Now, arrArgs(2), Nothing)

                Case 2
                    clsTLogDat.InsertNewLog(arrArgs(0), TLogDat.LogLevel.ErrorLog, My.Computer.Name, Now, arrArgs(2), Nothing)
            End Select

            If arrArgs.Count < 4 Then
                log.Log(arrArgs(1), Nothing, Nothing, arrArgs(2), Nothing)
            ElseIf arrArgs.Count < 5 Then
                log.Log(arrArgs(1), arrArgs(3), Nothing, arrArgs(2), Nothing)
            Else
                log.Log(arrArgs(1), arrArgs(3), arrArgs(4), arrArgs(2), Nothing)
            End If
        End If

    End Sub

End Module
