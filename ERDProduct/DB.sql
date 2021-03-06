USE [master]
GO
/****** Object:  Database [product2016]    Script Date: 14.02.2021 15:09:21 ******/
CREATE DATABASE [product2016]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'product2016', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\product2016.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'product2016_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\product2016_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [product2016] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [product2016].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [product2016] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [product2016] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [product2016] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [product2016] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [product2016] SET ARITHABORT OFF 
GO
ALTER DATABASE [product2016] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [product2016] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [product2016] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [product2016] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [product2016] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [product2016] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [product2016] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [product2016] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [product2016] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [product2016] SET  DISABLE_BROKER 
GO
ALTER DATABASE [product2016] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [product2016] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [product2016] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [product2016] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [product2016] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [product2016] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [product2016] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [product2016] SET RECOVERY FULL 
GO
ALTER DATABASE [product2016] SET  MULTI_USER 
GO
ALTER DATABASE [product2016] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [product2016] SET DB_CHAINING OFF 
GO
ALTER DATABASE [product2016] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [product2016] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [product2016] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [product2016] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'product2016', N'ON'
GO
ALTER DATABASE [product2016] SET QUERY_STORE = OFF
GO
USE [product2016]
GO
/****** Object:  Table [dbo].[CategoryProduct]    Script Date: 14.02.2021 15:09:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryProduct](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 14.02.2021 15:09:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Ammount] [int] NOT NULL,
	[Price] [decimal](10, 2) NOT NULL,
	[Reserv] [int] NULL,
	[IdCategory] [int] NOT NULL,
	[ProductListType] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductType]    Script Date: 14.02.2021 15:09:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 14.02.2021 15:09:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 14.02.2021 15:09:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdRole] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[ProductList] [int] NOT NULL,
 CONSTRAINT [PK__User__3214EC0780FFF473] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CategoryProduct] ON 

INSERT [dbo].[CategoryProduct] ([Id], [Name]) VALUES (1, N'Стулья')
INSERT [dbo].[CategoryProduct] ([Id], [Name]) VALUES (2, N'Столы')
INSERT [dbo].[CategoryProduct] ([Id], [Name]) VALUES (3, N'Шкафы')
INSERT [dbo].[CategoryProduct] ([Id], [Name]) VALUES (4, N'Окна')
INSERT [dbo].[CategoryProduct] ([Id], [Name]) VALUES (5, N'Диваны')
SET IDENTITY_INSERT [dbo].[CategoryProduct] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Id], [Name], [Ammount], [Price], [Reserv], [IdCategory], [ProductListType]) VALUES (1, N'Шкаф стенка', 10, CAST(16090.00 AS Decimal(10, 2)), 0, 3, 1)
INSERT [dbo].[Product] ([Id], [Name], [Ammount], [Price], [Reserv], [IdCategory], [ProductListType]) VALUES (2, N'Стул обкновенный', 14, CAST(1490.00 AS Decimal(10, 2)), 0, 1, 1)
INSERT [dbo].[Product] ([Id], [Name], [Ammount], [Price], [Reserv], [IdCategory], [ProductListType]) VALUES (3, N'Табуретка', 22, CAST(980.00 AS Decimal(10, 2)), 2, 1, 1)
INSERT [dbo].[Product] ([Id], [Name], [Ammount], [Price], [Reserv], [IdCategory], [ProductListType]) VALUES (4, N'Стол кухонный', 12, CAST(4390.00 AS Decimal(10, 2)), 4, 2, 1)
INSERT [dbo].[Product] ([Id], [Name], [Ammount], [Price], [Reserv], [IdCategory], [ProductListType]) VALUES (5, N'Стол журнальный', 16, CAST(3390.00 AS Decimal(10, 2)), 6, 2, 1)
INSERT [dbo].[Product] ([Id], [Name], [Ammount], [Price], [Reserv], [IdCategory], [ProductListType]) VALUES (7, N'Шкаф кухонный', 21, CAST(12890.00 AS Decimal(10, 2)), 10, 3, 1)
INSERT [dbo].[Product] ([Id], [Name], [Ammount], [Price], [Reserv], [IdCategory], [ProductListType]) VALUES (8, N'Окно пластиковое', 14, CAST(26190.00 AS Decimal(10, 2)), 0, 4, 1)
INSERT [dbo].[Product] ([Id], [Name], [Ammount], [Price], [Reserv], [IdCategory], [ProductListType]) VALUES (10, N'Диван 120х360', 8, CAST(29290.00 AS Decimal(10, 2)), 2, 5, 1)
INSERT [dbo].[Product] ([Id], [Name], [Ammount], [Price], [Reserv], [IdCategory], [ProductListType]) VALUES (11, N'Стул обкновенный', 14, CAST(990.00 AS Decimal(10, 2)), 16, 1, 3)
INSERT [dbo].[Product] ([Id], [Name], [Ammount], [Price], [Reserv], [IdCategory], [ProductListType]) VALUES (12, N'Табуретка', 22, CAST(480.00 AS Decimal(10, 2)), 2, 1, 3)
INSERT [dbo].[Product] ([Id], [Name], [Ammount], [Price], [Reserv], [IdCategory], [ProductListType]) VALUES (13, N'Стол кухонный', 0, CAST(3190.00 AS Decimal(10, 2)), 4, 2, 3)
INSERT [dbo].[Product] ([Id], [Name], [Ammount], [Price], [Reserv], [IdCategory], [ProductListType]) VALUES (14, N'Стол журнальный', 16, CAST(1790.00 AS Decimal(10, 2)), 6, 2, 3)
INSERT [dbo].[Product] ([Id], [Name], [Ammount], [Price], [Reserv], [IdCategory], [ProductListType]) VALUES (15, N'Шкаф купе', 9, CAST(12690.00 AS Decimal(10, 2)), 8, 3, 3)
INSERT [dbo].[Product] ([Id], [Name], [Ammount], [Price], [Reserv], [IdCategory], [ProductListType]) VALUES (16, N'Шкаф кухонный', 21, CAST(8890.00 AS Decimal(10, 2)), 10, 3, 3)
INSERT [dbo].[Product] ([Id], [Name], [Ammount], [Price], [Reserv], [IdCategory], [ProductListType]) VALUES (17, N'Окно пластиковое', 14, CAST(16190.00 AS Decimal(10, 2)), 0, 4, 3)
INSERT [dbo].[Product] ([Id], [Name], [Ammount], [Price], [Reserv], [IdCategory], [ProductListType]) VALUES (18, N'Диван раздвижной ', 8, CAST(10290.00 AS Decimal(10, 2)), 1, 5, 3)
INSERT [dbo].[Product] ([Id], [Name], [Ammount], [Price], [Reserv], [IdCategory], [ProductListType]) VALUES (19, N'Диван 120х360', 8, CAST(20290.00 AS Decimal(10, 2)), 2, 5, 3)
INSERT [dbo].[Product] ([Id], [Name], [Ammount], [Price], [Reserv], [IdCategory], [ProductListType]) VALUES (20, N'Шкаф стенка', 3, CAST(16090.00 AS Decimal(10, 2)), 0, 3, 4)
INSERT [dbo].[Product] ([Id], [Name], [Ammount], [Price], [Reserv], [IdCategory], [ProductListType]) VALUES (21, N'Стул обкновенный', 5, CAST(1490.00 AS Decimal(10, 2)), 0, 1, 4)
INSERT [dbo].[Product] ([Id], [Name], [Ammount], [Price], [Reserv], [IdCategory], [ProductListType]) VALUES (22, N'Табуретка', 2, CAST(980.00 AS Decimal(10, 2)), 2, 1, 4)
INSERT [dbo].[Product] ([Id], [Name], [Ammount], [Price], [Reserv], [IdCategory], [ProductListType]) VALUES (23, N'Стол кухонный', 7, CAST(4390.00 AS Decimal(10, 2)), 4, 2, 4)
INSERT [dbo].[Product] ([Id], [Name], [Ammount], [Price], [Reserv], [IdCategory], [ProductListType]) VALUES (24, N'Стол журнальный', 4, CAST(3390.00 AS Decimal(10, 2)), 6, 2, 4)
INSERT [dbo].[Product] ([Id], [Name], [Ammount], [Price], [Reserv], [IdCategory], [ProductListType]) VALUES (26, N'Шкаф кухонный', 9, CAST(12890.00 AS Decimal(10, 2)), 10, 3, 4)
INSERT [dbo].[Product] ([Id], [Name], [Ammount], [Price], [Reserv], [IdCategory], [ProductListType]) VALUES (27, N'Окно пластиковое', 1, CAST(26190.00 AS Decimal(10, 2)), 0, 4, 4)
INSERT [dbo].[Product] ([Id], [Name], [Ammount], [Price], [Reserv], [IdCategory], [ProductListType]) VALUES (28, N'Диван раздвижной', 4, CAST(19290.00 AS Decimal(10, 2)), 1, 5, 4)
INSERT [dbo].[Product] ([Id], [Name], [Ammount], [Price], [Reserv], [IdCategory], [ProductListType]) VALUES (29, N'Диван 120х360', 3, CAST(29290.00 AS Decimal(10, 2)), 2, 5, 4)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductType] ON 

INSERT [dbo].[ProductType] ([Id], [Name]) VALUES (1, N'Склад1')
INSERT [dbo].[ProductType] ([Id], [Name]) VALUES (2, N'Склад2')
INSERT [dbo].[ProductType] ([Id], [Name]) VALUES (3, N'Магазин1')
INSERT [dbo].[ProductType] ([Id], [Name]) VALUES (4, N'Проданный товар')
SET IDENTITY_INSERT [dbo].[ProductType] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([Id], [Name]) VALUES (1, N'Admin')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (2, N'ManagerOfBuy')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (3, N'MenagerOfSell')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [IdRole], [Name], [Login], [Password], [ProductList]) VALUES (1, 1, N'Aleksei', N'Admin', N'1', 1)
INSERT [dbo].[User] ([Id], [IdRole], [Name], [Login], [Password], [ProductList]) VALUES (2, 2, N'Lena', N'Buy', N'2', 1)
INSERT [dbo].[User] ([Id], [IdRole], [Name], [Login], [Password], [ProductList]) VALUES (3, 3, N'Petr', N'Sell', N'3', 3)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_CategoryProduct] FOREIGN KEY([IdCategory])
REFERENCES [dbo].[CategoryProduct] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_CategoryProduct]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductType] FOREIGN KEY([ProductListType])
REFERENCES [dbo].[ProductType] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_ProductType]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_ProductType] FOREIGN KEY([ProductList])
REFERENCES [dbo].[ProductType] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_ProductType]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([IdRole])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
USE [master]
GO
ALTER DATABASE [product2016] SET  READ_WRITE 
GO
