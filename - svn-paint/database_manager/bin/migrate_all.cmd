echo off

COLOR 47
TITLE Migrate All

cls

set /P SYSTEM=System (prod): 
set /P RAILS_ENV=RAILS_ENV (development,production,test): 

CD ../%SYSTEM%_database
rake db:migrate RAILS_ENV=%RAILS_ENV% --trace
