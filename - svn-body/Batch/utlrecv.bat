cd c:\AS400\AS400Path
del test.txt
cd c:\AS400\log-Service\Debug
log-service 0,0,"utlrecv start"
cd c:\HULFT Family\hulft7\binnt
utlrecv -f GHTD001A -h AS400T1 | c:\AS400\ReadStdIO\bin\Debug\ReadStdIO.exe