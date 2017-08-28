echo off

COLOR 3f
TITLE DB Files Monitoring

cls

set /P SYSTEM=System (prod): 
set /P RAILS_ENV=RAILS_ENV (development,production,test): 
set /P INTERVAL=Refresh interval (minutes): 
set /P SHOW_TOP=Show Top (10, 20, ...): 

CD ../%SYSTEM%_database
echo MonitorFile.new.run(%INTERVAL%,%SHOW_TOP%) > monitor_file.script
ruby script\console %RAILS_ENV% < monitor_file.script
del monitor_file.script
