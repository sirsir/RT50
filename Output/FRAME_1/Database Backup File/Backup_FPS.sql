use fps_development 
GO
dbcc shrinkfile (N'fps_development_log' , 1) 
GO
sp_BackupDatabaseFPS 'fps_development', 'F'
GO
QUIT