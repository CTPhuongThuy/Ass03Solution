USE [master]
GO
/****** Object:  Database [Assignment]    Script Date: 7/3/2022 4:24:44 PM ******/
CREATE DATABASE [Assignment]
GO
USE [Assignment]
GO
/****** Object:  Table [dbo].[Member]    Script Date: 7/3/2022 4:24:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[Member](
	[MemberId] [int] NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[CompanyName] [varchar](40) NOT NULL,
	[City] [varchar](15) NOT NULL,
	[Country] [varchar](15) NOT NULL,
	[Password] [varchar](30) NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Member] PRIMARY KEY CLUSTERED 
(
	[MemberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 7/3/2022 4:24:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[OrderDetailId] [int] NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[UnitPrice] [money] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Discount] [float] NOT NULL,
	[Status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Orders]    Script Date: 7/3/2022 4:24:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] NOT NULL,
	[MemberId] [int] NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[RequireDate] [datetime] NULL,
	[ShippedDate] [datetime] NULL,
	[Freight] [money] NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 7/3/2022 4:24:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Product](
	[ProductId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[ProductName] [varchar](40) NOT NULL,
	[Weight] [varchar](20) NOT NULL,
	[UnitPrice] [money] NOT NULL,
	[UnitslnStock] [int] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Member] ([MemberId], [Email], [CompanyName], [City], [Country], [Password], [Status]) VALUES (1, N'jack@gmail.com', N'F-SOFT', N'HCM', N'Viet Nam', N'123', 1)
GO
INSERT [dbo].[Member] ([MemberId], [Email], [CompanyName], [City], [Country], [Password], [Status]) VALUES (2, N'quang@gmail.com', N'ViettelPay', N'HCM', N'Viet Nam', N'123', 1)
GO
INSERT [dbo].[Member] ([MemberId], [Email], [CompanyName], [City], [Country], [Password], [Status]) VALUES (3, N'quan@gmail.com', N'KMS', N'Ha Noi', N'Viet Nam', N'123', 1)
GO
INSERT [dbo].[Member] ([MemberId], [Email], [CompanyName], [City], [Country], [Password], [Status]) VALUES (4, N'doan@gmail.com', N'Zalo', N'Da Nang', N'Viet Nam', N'123', 1)
GO
INSERT [dbo].[OrderDetail] ([OrderDetailId], [OrderId], [ProductId], [UnitPrice], [Quantity], [Discount], [Status]) VALUES (1, 1, 10, 100000.0000, 1, 20, 1)
GO
INSERT [dbo].[OrderDetail] ([OrderDetailId], [OrderId], [ProductId], [UnitPrice], [Quantity], [Discount], [Status]) VALUES (2, 2, 11, 199000.0000, 1, 30, 1)
GO
INSERT [dbo].[OrderDetail] ([OrderDetailId], [OrderId], [ProductId], [UnitPrice], [Quantity], [Discount], [Status]) VALUES (3, 3, 12, 200000.0000, 2, 40, 1)
GO
INSERT [dbo].[Orders] ([OrderId], [MemberId], [OrderDate], [RequireDate], [ShippedDate], [Freight], [Status]) VALUES (1, 1, CAST(N'2022-02-02 00:00:00.000' AS DateTime), CAST(N'2022-02-06 00:00:00.000' AS DateTime), CAST(N'2022-02-07 00:00:00.000' AS DateTime), 100000.0000, 1)
GO
INSERT [dbo].[Orders] ([OrderId], [MemberId], [OrderDate], [RequireDate], [ShippedDate], [Freight], [Status]) VALUES (2, 2, CAST(N'2020-02-09 00:00:00.000' AS DateTime), CAST(N'2020-02-10 00:00:00.000' AS DateTime), CAST(N'2020-02-12 00:00:00.000' AS DateTime), 1500000.0000, 1)
GO
INSERT [dbo].[Orders] ([OrderId], [MemberId], [OrderDate], [RequireDate], [ShippedDate], [Freight], [Status]) VALUES (3, 3, CAST(N'2022-04-02 00:00:00.000' AS DateTime), CAST(N'2022-04-06 00:00:00.000' AS DateTime), CAST(N'2022-04-06 00:00:00.000' AS DateTime), 200000.0000, 1)
GO
INSERT [dbo].[Orders] ([OrderId], [MemberId], [OrderDate], [RequireDate], [ShippedDate], [Freight], [Status]) VALUES (4, 3, CAST(N'2021-12-04 00:00:00.000' AS DateTime), CAST(N'2021-12-10 00:00:00.000' AS DateTime), CAST(N'2021-12-10 00:00:00.000' AS DateTime), 175000.0000, 1)
GO
INSERT [dbo].[Orders] ([OrderId], [MemberId], [OrderDate], [RequireDate], [ShippedDate], [Freight], [Status]) VALUES (5, 2, CAST(N'2020-05-06 00:00:00.000' AS DateTime), CAST(N'2020-06-06 00:00:00.000' AS DateTime), CAST(N'2020-07-06 00:00:00.000' AS DateTime), 100000000.0000, 1)
GO
INSERT [dbo].[Orders] ([OrderId], [MemberId], [OrderDate], [RequireDate], [ShippedDate], [Freight], [Status]) VALUES (6, 1, CAST(N'2020-02-13 00:00:00.000' AS DateTime), CAST(N'2020-02-11 00:00:00.000' AS DateTime), CAST(N'2020-02-14 00:00:00.000' AS DateTime), 2221212.0000, 1)
GO
INSERT [dbo].[Orders] ([OrderId], [MemberId], [OrderDate], [RequireDate], [ShippedDate], [Freight], [Status]) VALUES (7, 2, CAST(N'2020-02-20 00:00:00.000' AS DateTime), CAST(N'2020-02-22 00:00:00.000' AS DateTime), CAST(N'2020-02-24 00:00:00.000' AS DateTime), 123123123.0000, 1)
GO
INSERT [dbo].[Product] ([ProductId], [CategoryId], [ProductName], [Weight], [UnitPrice], [UnitslnStock], [Status]) VALUES (10, 5, N'Laptop', N'2 kg', 100000.0000, 3212, 1)
GO
INSERT [dbo].[Product] ([ProductId], [CategoryId], [ProductName], [Weight], [UnitPrice], [UnitslnStock], [Status]) VALUES (11, 6, N'Man Hinh', N'3 kg', 100000.0000, 3224, 1)
GO
INSERT [dbo].[Product] ([ProductId], [CategoryId], [ProductName], [Weight], [UnitPrice], [UnitslnStock], [Status]) VALUES (12, 7, N'Ao hoodie', N'2 kg', 50000.0000, 3142, 1)
GO
INSERT [dbo].[Product] ([ProductId], [CategoryId], [ProductName], [Weight], [UnitPrice], [UnitslnStock], [Status]) VALUES (13, 8, N'Loa JBL', N'1 kg', 100000.0000, 3121, 1)
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Order]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Product]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Order_Member] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Member] ([MemberId])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Order_Member]
GO
USE [master]
GO
ALTER DATABASE [Assignment] SET  READ_WRITE 
GO
