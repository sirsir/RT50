CREATE DATABASE [pis_production] ON  PRIMARY 
( NAME = N'pis_production', FILENAME = N'D:\DB\MSSQL\DATA\omron\pis\production\pis_production.mdf' , SIZE = 4096KB , FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'pis_production_log', FILENAME = N'D:\DB\MSSQL\DATA\omron\pis\production\pis_production_log.ldf' , SIZE = 17408KB , FILEGROWTH = 10%)
GO
EXEC dbo.sp_dbcmptlevel @dbname=N'pis_production', @new_cmptlevel=90
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [pis_production].[dbo].[sp_fulltext_database] @action = 'disable'
end
GO
ALTER DATABASE [pis_production] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [pis_production] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [pis_production] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [pis_production] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [pis_production] SET ARITHABORT OFF 
GO
ALTER DATABASE [pis_production] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [pis_production] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [pis_production] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [pis_production] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [pis_production] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [pis_production] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [pis_production] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [pis_production] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [pis_production] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [pis_production] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [pis_production] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [pis_production] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [pis_production] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [pis_production] SET  READ_WRITE 
GO
ALTER DATABASE [pis_production] SET RECOVERY FULL 
GO
ALTER DATABASE [pis_production] SET  MULTI_USER 
GO
ALTER DATABASE [pis_production] SET PAGE_VERIFY CHECKSUM  
GO
USE [pis_production]
GO
IF NOT EXISTS (SELECT name FROM sys.filegroups WHERE is_default=1 AND name = N'PRIMARY') ALTER DATABASE [pis_production] MODIFY FILEGROUP [PRIMARY] DEFAULT
GO
