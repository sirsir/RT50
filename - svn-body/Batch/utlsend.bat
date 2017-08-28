c:\
copy NUL kick.txt
cd c:\AS400\log-Service\Debug
log-service 0,0,"utlsend start"
cd c:\HULFT Family\hulft7\binnt
utlsend -f GHTD002N | c:\AS400\ReadStdIO\bin\Debug\ReadStdIO.exe
c:\
del kick.txt