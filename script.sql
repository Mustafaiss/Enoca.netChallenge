USE [master]
GO
/****** Object:  Database [Enocadb]    Script Date: 19.01.2023 06:01:31 ******/
CREATE DATABASE [Enocadb] ON  PRIMARY 
( NAME = N'Enocadb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\Enocadb.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Enocadb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\Enocadb_log.LDF' , SIZE = 576KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Enocadb] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Enocadb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Enocadb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Enocadb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Enocadb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Enocadb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Enocadb] SET ARITHABORT OFF 
GO
ALTER DATABASE [Enocadb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Enocadb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Enocadb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Enocadb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Enocadb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Enocadb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Enocadb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Enocadb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Enocadb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Enocadb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Enocadb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Enocadb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Enocadb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Enocadb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Enocadb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Enocadb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Enocadb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Enocadb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Enocadb] SET  MULTI_USER 
GO
ALTER DATABASE [Enocadb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Enocadb] SET DB_CHAINING OFF 
GO
USE [Enocadb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 19.01.2023 06:01:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Firma]    Script Date: 19.01.2023 06:01:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Firma](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Firmaadi] [nvarchar](max) NOT NULL,
	[Onaydurumu] [nvarchar](max) NOT NULL,
	[Siparisizinbaslangicsaat] [nvarchar](max) NOT NULL,
	[Siparisizinbitissaat] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Firma] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Siparis]    Script Date: 19.01.2023 06:01:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Siparis](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Siparisverenad] [nvarchar](max) NOT NULL,
	[Siparistarihi] [nvarchar](max) NOT NULL,
	[FirmaId] [int] NOT NULL,
	[UrunId] [int] NOT NULL,
 CONSTRAINT [PK_Siparis] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Urunler]    Script Date: 19.01.2023 06:01:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Urunler](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Urunadi] [nvarchar](max) NOT NULL,
	[stok] [int] NOT NULL,
	[fiyat] [int] NOT NULL,
	[FirmaId] [int] NOT NULL,
 CONSTRAINT [PK_Urunler] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230119011334_Enocamg', N'7.0.2')
GO
SET IDENTITY_INSERT [dbo].[Firma] ON 

INSERT [dbo].[Firma] ([Id], [Firmaadi], [Onaydurumu], [Siparisizinbaslangicsaat], [Siparisizinbitissaat]) VALUES (1, N'Enoca', N'True', N'18:25', N'22:00')
INSERT [dbo].[Firma] ([Id], [Firmaadi], [Onaydurumu], [Siparisizinbaslangicsaat], [Siparisizinbitissaat]) VALUES (2, N'Enoca2', N'True', N'09:00', N'17:00')
SET IDENTITY_INSERT [dbo].[Firma] OFF
GO
SET IDENTITY_INSERT [dbo].[Siparis] ON 

INSERT [dbo].[Siparis] ([Id], [Siparisverenad], [Siparistarihi], [FirmaId], [UrunId]) VALUES (1, N'Mustafa', N'22:00', 1, 1)
INSERT [dbo].[Siparis] ([Id], [Siparisverenad], [Siparistarihi], [FirmaId], [UrunId]) VALUES (3, N'Beyza', N'21:59', 1, 1)
SET IDENTITY_INSERT [dbo].[Siparis] OFF
GO
SET IDENTITY_INSERT [dbo].[Urunler] ON 

INSERT [dbo].[Urunler] ([Id], [Urunadi], [stok], [fiyat], [FirmaId]) VALUES (1, N'İlkurun', 2, 5, 1)
SET IDENTITY_INSERT [dbo].[Urunler] OFF
GO
/****** Object:  Index [IX_Siparis_FirmaId]    Script Date: 19.01.2023 06:01:31 ******/
CREATE NONCLUSTERED INDEX [IX_Siparis_FirmaId] ON [dbo].[Siparis]
(
	[FirmaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Urunler_FirmaId]    Script Date: 19.01.2023 06:01:31 ******/
CREATE NONCLUSTERED INDEX [IX_Urunler_FirmaId] ON [dbo].[Urunler]
(
	[FirmaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Siparis]  WITH CHECK ADD  CONSTRAINT [FK_Siparis_Firma_FirmaId] FOREIGN KEY([FirmaId])
REFERENCES [dbo].[Firma] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Siparis] CHECK CONSTRAINT [FK_Siparis_Firma_FirmaId]
GO
ALTER TABLE [dbo].[Urunler]  WITH CHECK ADD  CONSTRAINT [FK_Urunler_Firma_FirmaId] FOREIGN KEY([FirmaId])
REFERENCES [dbo].[Firma] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Urunler] CHECK CONSTRAINT [FK_Urunler_Firma_FirmaId]
GO
USE [master]
GO
ALTER DATABASE [Enocadb] SET  READ_WRITE 
GO
