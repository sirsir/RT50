use psis_development 
GO
sp_BackupDatabasePSIS 'psis_development', 'F'
GO
alter database psis_development set recovery simple
go

checkpoint
go

alter database psis_development set recovery full
go

backup database  psis_development to disk = 'D:\BAK_PSIS\mydb1.bak' with init
go

dbcc shrinkfile (N'psis_development_log' , 1)
go

--Repeat
alter database psis_development set recovery simple
go

checkpoint
go

alter database psis_development set recovery full
go

backup database  psis_development to disk = 'D:\BAK_PSIS\mydb1.bak' with init
go

dbcc shrinkfile (N'psis_development_log' , 1)
go
QUIT