echo off

COLOR 0A
TITLE Schema Monitoring

cls

set /P SYSTEM=System (prod): 
set /P RAILS_ENV=RAILS_ENV (development,production,test): 

CD ../%SYSTEM%_database
rake db:schema:monitor RAILS_ENV=%RAILS_ENV%
