USE [master]
GO
/****** Object:  Database [DistribuzioniUtenze]    Script Date: 03/05/2024 20:27:59 ******/
CREATE DATABASE [DistribuzioniUtenze]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DistribuzioniUtenze', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\DistribuzioniUtenze.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DistribuzioniUtenze_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\DistribuzioniUtenze_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [DistribuzioniUtenze] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DistribuzioniUtenze].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DistribuzioniUtenze] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DistribuzioniUtenze] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DistribuzioniUtenze] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DistribuzioniUtenze] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DistribuzioniUtenze] SET ARITHABORT OFF 
GO
ALTER DATABASE [DistribuzioniUtenze] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DistribuzioniUtenze] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DistribuzioniUtenze] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DistribuzioniUtenze] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DistribuzioniUtenze] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DistribuzioniUtenze] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DistribuzioniUtenze] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DistribuzioniUtenze] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DistribuzioniUtenze] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DistribuzioniUtenze] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DistribuzioniUtenze] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DistribuzioniUtenze] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DistribuzioniUtenze] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DistribuzioniUtenze] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DistribuzioniUtenze] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DistribuzioniUtenze] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DistribuzioniUtenze] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DistribuzioniUtenze] SET RECOVERY FULL 
GO
ALTER DATABASE [DistribuzioniUtenze] SET  MULTI_USER 
GO
ALTER DATABASE [DistribuzioniUtenze] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DistribuzioniUtenze] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DistribuzioniUtenze] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DistribuzioniUtenze] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DistribuzioniUtenze] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DistribuzioniUtenze] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DistribuzioniUtenze', N'ON'
GO
ALTER DATABASE [DistribuzioniUtenze] SET QUERY_STORE = ON
GO
ALTER DATABASE [DistribuzioniUtenze] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [DistribuzioniUtenze]
GO
/****** Object:  User [distribuzioniUtenze]    Script Date: 03/05/2024 20:28:00 ******/
CREATE USER [distribuzioniUtenze] FOR LOGIN [distribuzioniUtenze] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [distribuzioniUtenze]
GO
/****** Object:  Table [dbo].[Destinatari]    Script Date: 03/05/2024 20:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Destinatari](
	[IdDestinatario] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](100) NULL,
 CONSTRAINT [PK_Destinatari_1] PRIMARY KEY CLUSTERED 
(
	[IdDestinatario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ListeDistribuzioni]    Script Date: 03/05/2024 20:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ListeDistribuzioni](
	[IdLista] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[IdProprietario] [int] NOT NULL,
 CONSTRAINT [PK_ListeUtenze] PRIMARY KEY CLUSTERED 
(
	[IdLista] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ListeUtenzeAssociate]    Script Date: 03/05/2024 20:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ListeUtenzeAssociate](
	[IdListaAssociata] [int] IDENTITY(1,1) NOT NULL,
	[IdDestinatario] [int] NOT NULL,
	[IdListaDistribuzione] [int] NOT NULL,
 CONSTRAINT [PK_ListaUtenzeAssociate] PRIMARY KEY CLUSTERED 
(
	[IdListaAssociata] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utenti]    Script Date: 03/05/2024 20:28:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utenti](
	[Email] [varchar](100) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Cognome] [varchar](100) NOT NULL,
	[Password] [varchar](100) NOT NULL,
	[IdUtente] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Utenti] PRIMARY KEY CLUSTERED 
(
	[IdUtente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ListeDistribuzioni]  WITH CHECK ADD  CONSTRAINT [FK_ListeDistribuzioni_Utenti] FOREIGN KEY([IdProprietario])
REFERENCES [dbo].[Utenti] ([IdUtente])
GO
ALTER TABLE [dbo].[ListeDistribuzioni] CHECK CONSTRAINT [FK_ListeDistribuzioni_Utenti]
GO
ALTER TABLE [dbo].[ListeUtenzeAssociate]  WITH CHECK ADD  CONSTRAINT [FK_ListaUtenzeAssociate_Destinatari] FOREIGN KEY([IdDestinatario])
REFERENCES [dbo].[Destinatari] ([IdDestinatario])
GO
ALTER TABLE [dbo].[ListeUtenzeAssociate] CHECK CONSTRAINT [FK_ListaUtenzeAssociate_Destinatari]
GO
ALTER TABLE [dbo].[ListeUtenzeAssociate]  WITH CHECK ADD  CONSTRAINT [FK_ListaUtenzeAssociate_ListeDistribuzioni] FOREIGN KEY([IdListaDistribuzione])
REFERENCES [dbo].[ListeDistribuzioni] ([IdLista])
GO
ALTER TABLE [dbo].[ListeUtenzeAssociate] CHECK CONSTRAINT [FK_ListaUtenzeAssociate_ListeDistribuzioni]
GO
ALTER TABLE [dbo].[Utenti]  WITH CHECK ADD  CONSTRAINT [FK_Utenti_Utenti] FOREIGN KEY([IdUtente])
REFERENCES [dbo].[Utenti] ([IdUtente])
GO
ALTER TABLE [dbo].[Utenti] CHECK CONSTRAINT [FK_Utenti_Utenti]
GO
USE [master]
GO
ALTER DATABASE [DistribuzioniUtenze] SET  READ_WRITE 
GO
