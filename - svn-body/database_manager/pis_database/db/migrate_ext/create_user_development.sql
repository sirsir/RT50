/****** Object:  Login [pisuser]    Script Date: 08/18/2010 18:40:28 ******/
/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [pisuser]    Script Date: 08/18/2010 18:40:28 ******/
CREATE LOGIN [pisuser] WITH PASSWORD=N'-2(Bî©l8tAc74¤,Ü8CMÃy[/zY', DEFAULT_DATABASE=[pis_development], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=ON
GO
EXEC sys.sp_addsrvrolemember @loginame = N'pisuser', @rolename = N'sysadmin'
GO
ALTER LOGIN [pisuser] DISABLE