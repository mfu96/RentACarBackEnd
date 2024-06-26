USE [master]
GO
/****** Object:  Database [RentACar]    Script Date: 18.03.2024 10:50:20 ******/
CREATE DATABASE [RentACar]
GO
USE [RentACar]
GO
/****** Object:  Table [dbo].[Brands]    Script Date: 18.03.2024 10:50:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brands](
	[BrandId] [int] IDENTITY(1,1) NOT NULL,
	[BrandName] [nvarchar](24) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Brands] PRIMARY KEY CLUSTERED 
(
	[BrandId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarImages]    Script Date: 18.03.2024 10:50:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarImages](
	[ImageId] [int] IDENTITY(1,1) NOT NULL,
	[CarId] [int] NULL,
	[ImagePath] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ImageDate] [datetime] NULL,
 CONSTRAINT [PK_CarImages] PRIMARY KEY CLUSTERED 
(
	[ImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 18.03.2024 10:50:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cars](
	[CarId] [int] IDENTITY(1,1) NOT NULL,
	[CarName] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[CategoryId] [int] NULL,
	[BrandId] [int] NULL,
	[ColorId] [int] NULL,
	[ModelYear] [int] NULL,
	[UnitPrice] [decimal](18, 0) NULL,
	[UnitsInStock] [smallint] NULL,
	[Description] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[State] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Cars] PRIMARY KEY CLUSTERED 
(
	[CarId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 18.03.2024 10:50:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Colors]    Script Date: 18.03.2024 10:50:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Colors](
	[ColorId] [int] IDENTITY(1,1) NOT NULL,
	[ColorName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Colors] PRIMARY KEY CLUSTERED 
(
	[ColorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CreditCards]    Script Date: 18.03.2024 10:50:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CreditCards](
	[CardId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[NameOnTheCard] [nchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[CardNumber] [nchar](16) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[CVV] [int] NOT NULL,
	[ExpirationDate] [nchar](4) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 18.03.2024 10:50:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[CompanyName] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OperationClaims]    Script Date: 18.03.2024 10:50:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OperationClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_OpetaionClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rentals]    Script Date: 18.03.2024 10:50:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rentals](
	[RentId] [int] IDENTITY(1,1) NOT NULL,
	[CarId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[RentDate] [datetime] NULL,
	[ReturnDate] [datetime] NULL,
 CONSTRAINT [PK_Rentals] PRIMARY KEY CLUSTERED 
(
	[RentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserOperationClaims]    Script Date: 18.03.2024 10:50:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserOperationClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[OperationClaimId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 18.03.2024 10:50:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[LastName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Email] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[PasswordHash] [varbinary](500) NOT NULL,
	[PasswordSalt] [varbinary](500) NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Brands] ON 
GO
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (1, N'Renault')
GO
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (2, N'Hyundai')
GO
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (3, N'Ford')
GO
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (4, N'Opel')
GO
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (5, N'Fiat')
GO
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (6, N'Peugeot')
GO
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (7, N'Toyota')
GO
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (8, N'Volkswagen')
GO
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (9, N'Bmw')
GO
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (10, N'Tata')
GO
SET IDENTITY_INSERT [dbo].[Brands] OFF
GO
SET IDENTITY_INSERT [dbo].[CarImages] ON 
GO
INSERT [dbo].[CarImages] ([ImageId], [CarId], [ImagePath], [ImageDate]) VALUES (33, 11, N'\uploads\8ddac1d0-434b-48f8-85c2-487e3d56edd3.png', CAST(N'2022-12-06T15:55:33.837' AS DateTime))
GO
INSERT [dbo].[CarImages] ([ImageId], [CarId], [ImagePath], [ImageDate]) VALUES (35, 7, N'\uploads\b027e04c-a1c7-4890-8018-d24926fb7666.jpg', CAST(N'2022-12-06T16:05:03.597' AS DateTime))
GO
INSERT [dbo].[CarImages] ([ImageId], [CarId], [ImagePath], [ImageDate]) VALUES (39, 12, N'\uploads\65a5037c-bd7d-477c-b9db-fe39000085ad.jpg', CAST(N'2022-12-07T16:06:49.287' AS DateTime))
GO
INSERT [dbo].[CarImages] ([ImageId], [CarId], [ImagePath], [ImageDate]) VALUES (40, 13, N'\uploads\94f95cbc-cf37-47af-99f0-5c4df22e2ac5.jpg', CAST(N'2022-12-07T16:07:10.883' AS DateTime))
GO
INSERT [dbo].[CarImages] ([ImageId], [CarId], [ImagePath], [ImageDate]) VALUES (41, 16, N'\uploads\ab790d71-1272-4bcb-ab6f-db93f35c5717.jpg', CAST(N'2023-01-07T19:27:09.267' AS DateTime))
GO
INSERT [dbo].[CarImages] ([ImageId], [CarId], [ImagePath], [ImageDate]) VALUES (42, 17, N'\uploads\86182a94-87a8-4912-8c96-0aacbe1a71eb.jpg', CAST(N'2023-01-08T00:45:47.407' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[CarImages] OFF
GO
SET IDENTITY_INSERT [dbo].[Cars] ON 
GO
INSERT [dbo].[Cars] ([CarId], [CarName], [CategoryId], [BrandId], [ColorId], [ModelYear], [UnitPrice], [UnitsInStock], [Description], [State]) VALUES (7, N'34MFU01', 3, 4, 4, 2021, CAST(350 AS Decimal(18, 0)), 2, N'Afilli mi acep?', NULL)
GO
INSERT [dbo].[Cars] ([CarId], [CarName], [CategoryId], [BrandId], [ColorId], [ModelYear], [UnitPrice], [UnitsInStock], [Description], [State]) VALUES (11, N'34MFU03', 3, 1, 5, 2020, CAST(150 AS Decimal(18, 0)), 5, N'Tam Şirket arabası', NULL)
GO
INSERT [dbo].[Cars] ([CarId], [CarName], [CategoryId], [BrandId], [ColorId], [ModelYear], [UnitPrice], [UnitsInStock], [Description], [State]) VALUES (12, N'34MFU04', 5, 10, 6, 2020, CAST(150 AS Decimal(18, 0)), 1, N'Tam Şirket arabası', NULL)
GO
INSERT [dbo].[Cars] ([CarId], [CarName], [CategoryId], [BrandId], [ColorId], [ModelYear], [UnitPrice], [UnitsInStock], [Description], [State]) VALUES (13, N'42MFU05', 3, 2, 3, 2021, CAST(250 AS Decimal(18, 0)), 3, N'Az yakar haliyle çok kaçmaz', NULL)
GO
INSERT [dbo].[Cars] ([CarId], [CarName], [CategoryId], [BrandId], [ColorId], [ModelYear], [UnitPrice], [UnitsInStock], [Description], [State]) VALUES (16, N'42MFU06', 5, 7, 1, 2021, CAST(250 AS Decimal(18, 0)), 2, N'Cebe uygun, fiyat performans', NULL)
GO
INSERT [dbo].[Cars] ([CarId], [CarName], [CategoryId], [BrandId], [ColorId], [ModelYear], [UnitPrice], [UnitsInStock], [Description], [State]) VALUES (17, N'GOLF', 4, 8, 1, 2010, CAST(175 AS Decimal(18, 0)), 1, N'42MFU07', NULL)
GO
SET IDENTITY_INSERT [dbo].[Cars] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (2, N'Mini')
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (3, N'Ekonomi')
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (4, N'Kompakt')
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (5, N'Orta Sınıf')
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (6, N'SUV')
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (7, N'Minibüs/Van')
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (8, N'Lüks')
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (9, N'Cabrio')
GO
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Colors] ON 
GO
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (1, N'Beyaz')
GO
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (2, N'Siyah')
GO
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (3, N'Gri')
GO
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (4, N'Gümüş')
GO
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (5, N'Kırmızı')
GO
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (6, N'Mavi')
GO
SET IDENTITY_INSERT [dbo].[Colors] OFF
GO
SET IDENTITY_INSERT [dbo].[CreditCards] ON 
GO
INSERT [dbo].[CreditCards] ([CardId], [CustomerId], [NameOnTheCard], [CardNumber], [CVV], [ExpirationDate]) VALUES (1, 2, N'Muhammed Furkan USLU                              ', N'1234123412341234', 123, N'1223')
GO
SET IDENTITY_INSERT [dbo].[CreditCards] OFF
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 
GO
INSERT [dbo].[Customers] ([CustomerId], [UserId], [CompanyName]) VALUES (2, 22, N'Doktorundan Kiralık A.Ş.')
GO
INSERT [dbo].[Customers] ([CustomerId], [UserId], [CompanyName]) VALUES (3, 15, N'Merdiven Altından Global''a A.Ş.')
GO
INSERT [dbo].[Customers] ([CustomerId], [UserId], [CompanyName]) VALUES (5, 21, N'Grafik Atölyesi')
GO
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[OperationClaims] ON 
GO
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (1, N'admin')
GO
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (2, N'editor')
GO
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (5, N'employer')
GO
SET IDENTITY_INSERT [dbo].[OperationClaims] OFF
GO
SET IDENTITY_INSERT [dbo].[Rentals] ON 
GO
INSERT [dbo].[Rentals] ([RentId], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (14, 13, 2, CAST(N'2022-02-07T00:00:00.000' AS DateTime), CAST(N'2024-02-10T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Rentals] ([RentId], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (15, 12, 2, CAST(N'2022-02-07T00:00:00.000' AS DateTime), CAST(N'2025-02-12T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Rentals] ([RentId], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (75, 11, 2, CAST(N'2023-01-06T00:00:00.000' AS DateTime), CAST(N'2023-02-15T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Rentals] ([RentId], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (77, 7, 2, CAST(N'2023-01-08T00:20:04.183' AS DateTime), CAST(N'2023-02-15T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Rentals] ([RentId], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (1086, 7, 2, CAST(N'2023-07-13T00:00:00.000' AS DateTime), CAST(N'2023-07-16T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Rentals] ([RentId], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (1087, 7, 3, CAST(N'2023-07-18T00:00:00.000' AS DateTime), CAST(N'2023-07-19T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Rentals] ([RentId], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (1088, 7, 5, CAST(N'2023-07-26T00:00:00.000' AS DateTime), CAST(N'2023-07-28T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Rentals] ([RentId], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (1089, 7, 3, CAST(N'2023-07-30T00:00:00.000' AS DateTime), CAST(N'2023-07-31T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Rentals] ([RentId], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (1090, 7, 2, CAST(N'2023-08-01T00:00:00.000' AS DateTime), CAST(N'2023-08-03T00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Rentals] OFF
GO
SET IDENTITY_INSERT [dbo].[UserOperationClaims] ON 
GO
INSERT [dbo].[UserOperationClaims] ([Id], [UserId], [OperationClaimId]) VALUES (9, 15, 1)
GO
INSERT [dbo].[UserOperationClaims] ([Id], [UserId], [OperationClaimId]) VALUES (10, 21, 2)
GO
INSERT [dbo].[UserOperationClaims] ([Id], [UserId], [OperationClaimId]) VALUES (11, 21, 5)
GO
INSERT [dbo].[UserOperationClaims] ([Id], [UserId], [OperationClaimId]) VALUES (12, 22, 5)
GO
SET IDENTITY_INSERT [dbo].[UserOperationClaims] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Email], [PasswordHash], [PasswordSalt], [Status]) VALUES (15, N'Muhammed Furkan', N'Uslu', N'mfurkan.uslu@mfu.com', 0x647D65B4EDDB33C7E2FEAD2C1D31712E12AF0B4DFFBEE51F2B08F9E49CFEA50CD47CF9C249437F9E98240ED6EF2A155E1038D785B8292D4C8BDF9F6C1E218FDB, 0x5D1FA17CC69C45D6D2608779936267120EC77A7EA8C0D9F72E8F22CDB208B52DE140F0D72DDD6036E7D4717CAB2D5374629AB9E3353AB13BDC2AA64F3A8623737FB9EF7AEE00CAD3BCEBC78D9B3826BA710648FFB5B44FDF5EB018E2F502387699A89A96619377CFB01B23C980931807E3AD4F043EF269A6D50B7FCE9985B854, 1)
GO
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Email], [PasswordHash], [PasswordSalt], [Status]) VALUES (21, N'Kamil', N'Uslu', N'kamil.uslu@mfu.com', 0xBFACB5FE7F9E1D45EE8A2A04EB6FC9E911F391A2F274B4D3F213ECADBC60910DD42A59BD0DA5AFE01907ED850CCBE732569D2276C2CE5D574E7BB7A11DDE12FD, 0xB67CF3E4E98C10213138D354296250E1FA2E01D84FB436F40141F78B6C0DF857175DAE942CD7690B35756AAB0C02284440F32E31CE487C3CD38B849D634D6DCFEBF6DAF0F4779AA9CBCA198C601600387D5243E4951B4090BFD8EA4FD1CD954C0DB3C469747D874DD7FFCD30635D74A12F534806BB77EF736D50C2A97EB3B8D8, 1)
GO
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Email], [PasswordHash], [PasswordSalt], [Status]) VALUES (22, N'Ibrahim', N'Simsek', N'ibrahim.simsek@mfu.com', 0xE4933D8418FBB14C6DD251F04674622CABA9B43C8E351847D99E9C88AE7FA9849BCB847BEB4A3C5A5013E883DE76F1F1C9E99D526C9D0CA5CBA22424228E6620, 0x7FF3CC4CCE8861582862EED68D210D62FF58511BCBC3FE6CFE5958E3F183F7A975B38020E46B393D07573B78ADF39D4C01352A537632CF50D9CCE2250F4193717E7E20D07AF9ABBCA415BCE1C98B80C10414438B85BA51BA4FEA439BC1E821A771F7D7FC32005B28C96285966E01E1147C798B2B08E1903F741462BFAFE5B504, 1)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[CarImages] ADD  DEFAULT (getdate()) FOR [ImageDate]
GO
ALTER TABLE [dbo].[Rentals] ADD  DEFAULT (NULL) FOR [ReturnDate]
GO
ALTER TABLE [dbo].[CarImages]  WITH CHECK ADD  CONSTRAINT [fk_carImages] FOREIGN KEY([CarId])
REFERENCES [dbo].[Cars] ([CarId])
GO
ALTER TABLE [dbo].[CarImages] CHECK CONSTRAINT [fk_carImages]
GO
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brands] ([BrandId])
GO
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD FOREIGN KEY([ColorId])
REFERENCES [dbo].[Colors] ([ColorId])
GO
ALTER TABLE [dbo].[CreditCards]  WITH CHECK ADD FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([CustomerId])
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Rentals]  WITH CHECK ADD FOREIGN KEY([CarId])
REFERENCES [dbo].[Cars] ([CarId])
GO
ALTER TABLE [dbo].[Rentals]  WITH CHECK ADD FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([CustomerId])
GO
ALTER TABLE [dbo].[UserOperationClaims]  WITH CHECK ADD FOREIGN KEY([OperationClaimId])
REFERENCES [dbo].[OperationClaims] ([Id])
GO
ALTER TABLE [dbo].[UserOperationClaims]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
USE [master]
GO
ALTER DATABASE [RentACar] SET  READ_WRITE 
GO
