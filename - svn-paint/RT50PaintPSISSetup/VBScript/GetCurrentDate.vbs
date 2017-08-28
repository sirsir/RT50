args = WScript.Arguments.Count
If args = 1 Then
    'mode : 1 get date only, 2 get date and time
    mode = Wscript.Arguments(0)
    If (mode <> 1 And mode <> 2) Then
         WScript.Quit
    End If
Else
    WScript.Quit
End If
current = Now
c_date = Year(current)
If Month(current) < 10 Then
    c_date = c_date & "0" & Month(current)
Else
    c_date = c_date & Month(current)
End If
If Day(current) < 10 Then
    c_date = c_date & "0" & Day(current)
Else
    c_date = c_date & Day(current)
End If

If mode = 2 Then
    If Hour(current) < 10 Then
        c_date = c_date & "0" & Hour(current)
    Else
        c_date = c_date & Hour(current)
    End If
    If Minute(current) < 10 Then
        c_date = c_date & "0" & Minute(current)
    Else
        c_date = c_date & Minute(current)
    End If
    If Second(current) < 10 Then
        c_date = c_date & "0" & Second(current)
    Else
        c_date = c_date & Second(current)
    End If
End If
Wscript.echo c_date