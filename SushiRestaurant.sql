USE [SushiRestaurant]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 5/23/2024 8:31:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[RoleID] [int] NULL,
	[Email] [nvarchar](max) NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 5/23/2024 8:31:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 5/23/2024 8:31:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[ContactID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Status] [nvarchar](max) NULL,
	[Message] [nvarchar](max) NULL,
	[CreateMessageDate] [datetime] NULL,
	[ResponseMessage] [nvarchar](max) NULL,
	[ResponseMessageDate] [datetime] NULL,
 CONSTRAINT [PK_ContactUs] PRIMARY KEY CLUSTERED 
(
	[ContactID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[History]    Script Date: 5/23/2024 8:31:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[History](
	[HistoryId] [int] IDENTITY(1,1) NOT NULL,
	[OrdertId] [int] NULL,
	[ProductId] [int] NULL,
	[Quantity] [int] NULL,
	[Action] [nvarchar](max) NULL,
	[UserId] [int] NULL,
	[Date] [datetime] NULL,
 CONSTRAINT [PK_History] PRIMARY KEY CLUSTERED 
(
	[HistoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 5/23/2024 8:31:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[CustomerName] [nvarchar](max) NULL,
	[TotalPrice] [float] NULL,
	[OrderDate] [datetime] NULL,
	[Phone] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Note] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[TypeOrder] [nvarchar](max) NULL,
	[PaymentMethod] [nvarchar](max) NULL,
	[Status] [bit] NULL,
	[HistoryID] [int] NULL,
	[EndDate] [datetime] NULL,
	[TableID] [int] NULL,
	[PaymentProcess] [nvarchar](max) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 5/23/2024 8:31:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[OrderID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[Quantity] [int] NULL,
	[UnitPrice] [float] NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC,
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 5/23/2024 8:31:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](max) NULL,
	[Price] [float] NULL,
	[Quantity] [int] NULL,
	[ShortDes] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NULL,
	[CategoryID] [int] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservation]    Script Date: 5/23/2024 8:31:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservation](
	[ReservationID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[CustomerName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[NumOfGuests] [int] NULL,
	[ReservationDate] [date] NULL,
	[Time] [time](7) NULL,
	[Message] [nvarchar](max) NULL,
	[Status] [bit] NULL,
	[Location] [nvarchar](max) NULL,
 CONSTRAINT [PK_Reservation] PRIMARY KEY CLUSTERED 
(
	[ReservationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 5/23/2024 8:31:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table]    Script Date: 5/23/2024 8:31:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table](
	[TableID] [int] IDENTITY(1,1) NOT NULL,
	[TableName] [nvarchar](max) NULL,
	[Status] [nvarchar](max) NULL,
 CONSTRAINT [PK_Table] PRIMARY KEY CLUSTERED 
(
	[TableID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([UserID], [UserName], [Password], [RoleID], [Email]) VALUES (1, N'user', N'User@123', 1, N'user@gmail.com')
INSERT [dbo].[Account] ([UserID], [UserName], [Password], [RoleID], [Email]) VALUES (2, N'admin', N'Admin@123', 3, N'admin@gmail.com')
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Image]) VALUES (1, N'Dimsum', N'about-thumb-01.jpg')
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Image]) VALUES (2, N'Vegetable', N'tab-item-03.png')
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Image]) VALUES (3, N'BBQ', N'tab-item-04.png')
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Image]) VALUES (4, N'Noodle', N'tab-item-06.png')
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Image]) VALUES (5, N'Drink', N'tab-item-02.png')
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Image]) VALUES (6, N'Dessert', N'menu-item-02.jpg')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Contact] ON 

INSERT [dbo].[Contact] ([ContactID], [CustomerName], [Phone], [Address], [Email], [Status], [Message], [CreateMessageDate], [ResponseMessage], [ResponseMessageDate]) VALUES (1, N'Kim anh', N'1231231234', N'HN', N'anhhtk3082@gmail.com', N'No response yet', N'Boc phot', CAST(N'2021-07-21T16:41:30.260' AS DateTime), NULL, NULL)
INSERT [dbo].[Contact] ([ContactID], [CustomerName], [Phone], [Address], [Email], [Status], [Message], [CreateMessageDate], [ResponseMessage], [ResponseMessageDate]) VALUES (2, N'Le Thuy', N'1231231234', N'DP', N'tunguye@gmail.com', N'Responded', N'Service good', CAST(N'2021-07-21T16:41:30.260' AS DateTime), N'<p>&lt;html&gt; 12</p>
', CAST(N'2021-07-22T03:22:07.227' AS DateTime))
INSERT [dbo].[Contact] ([ContactID], [CustomerName], [Phone], [Address], [Email], [Status], [Message], [CreateMessageDate], [ResponseMessage], [ResponseMessageDate]) VALUES (3, N'Anna', N'1241253456', N'HCM', N'ana123@gmail.com', N'No response yet', N'Food very good', CAST(N'2021-07-21T16:41:30.260' AS DateTime), N'<p>&lt;html&gt; 12</p>
', CAST(N'2021-07-22T03:22:07.227' AS DateTime))
INSERT [dbo].[Contact] ([ContactID], [CustomerName], [Phone], [Address], [Email], [Status], [Message], [CreateMessageDate], [ResponseMessage], [ResponseMessageDate]) VALUES (4, N'Tuan Vu', N'1231231234', N'HN', N'kimanh3082@gmail.com', N'Responded', N'good service', CAST(N'2021-07-21T16:41:30.260' AS DateTime), N'<ol>
	<li><img alt="" src="https://i.pinimg.com/736x/ff/99/e8/ff99e81f59e3a9c02ff4f799f35cfc90.jpg" style="height:100px; width:100px" /></li>
	<li>ths</li>
	<li>i love you</li>
</ol>
', CAST(N'2021-07-22T03:38:36.967' AS DateTime))
INSERT [dbo].[Contact] ([ContactID], [CustomerName], [Phone], [Address], [Email], [Status], [Message], [CreateMessageDate], [ResponseMessage], [ResponseMessageDate]) VALUES (5, N'Phuong Hang', N'1231231234', N'HCM', N'anh@gmail.com', N'No response yet', N'good', CAST(N'2021-07-21T16:41:30.260' AS DateTime), NULL, NULL)
INSERT [dbo].[Contact] ([ContactID], [CustomerName], [Phone], [Address], [Email], [Status], [Message], [CreateMessageDate], [ResponseMessage], [ResponseMessageDate]) VALUES (6, N'Hoang Son', N'1231231234', N'Lang Son', N'kimanh@gmail.com', N'Responded', N'oki', CAST(N'2021-07-21T16:46:25.333' AS DateTime), N'<p><img alt="" src="https://i.pinimg.com/736x/ff/99/e8/ff99e81f59e3a9c02ff4f799f35cfc90.jpg" style="height:690px; width:690px" /></p>

<p>Đồ ăn rất ngon</p>

<p>K&iacute; hợp đồng kh&ocirc;ng</p>
', CAST(N'2021-07-22T16:29:41.770' AS DateTime))
INSERT [dbo].[Contact] ([ContactID], [CustomerName], [Phone], [Address], [Email], [Status], [Message], [CreateMessageDate], [ResponseMessage], [ResponseMessageDate]) VALUES (7, N'Mai Huong', N'1231231234', N'Campuchia', N'anh123@gmail.com', N'No response yet', N'123', CAST(N'2021-07-21T16:47:58.210' AS DateTime), N'seen', CAST(N'2021-07-22T02:53:14.433' AS DateTime))
INSERT [dbo].[Contact] ([ContactID], [CustomerName], [Phone], [Address], [Email], [Status], [Message], [CreateMessageDate], [ResponseMessage], [ResponseMessageDate]) VALUES (9, N'Pham Tuan', N'1231231234', N'DL', N'kimanh3082@gmail.com', N'Responded', N'123', CAST(N'2021-07-21T16:52:36.907' AS DateTime), N'<p><img alt="" src="https://i.pinimg.com/736x/ff/99/e8/ff99e81f59e3a9c02ff4f799f35cfc90.jpg" style="height:690px; width:690px" />r</p>

<p>Sang xịn min</p>

<p>k&iacute; hợp đồng lun</p>

<p>&nbsp;</p>
', CAST(N'2021-07-22T16:32:12.640' AS DateTime))
INSERT [dbo].[Contact] ([ContactID], [CustomerName], [Phone], [Address], [Email], [Status], [Message], [CreateMessageDate], [ResponseMessage], [ResponseMessageDate]) VALUES (10, N'Sinh Anh', N'1231231234', N'PL', N'kimanh3082@gmail.com', N'Responded', N'123', CAST(N'2021-07-21T16:53:29.603' AS DateTime), N'<p>oki la 123</p>
', CAST(N'2021-07-22T17:17:28.307' AS DateTime))
INSERT [dbo].[Contact] ([ContactID], [CustomerName], [Phone], [Address], [Email], [Status], [Message], [CreateMessageDate], [ResponseMessage], [ResponseMessageDate]) VALUES (11, N'Tuan Vu 123', N'1231231234', N'HN', N'tuanvu@gmail.com', N'No response yet', N'123', CAST(N'2021-07-21T16:54:48.440' AS DateTime), NULL, NULL)
INSERT [dbo].[Contact] ([ContactID], [CustomerName], [Phone], [Address], [Email], [Status], [Message], [CreateMessageDate], [ResponseMessage], [ResponseMessageDate]) VALUES (12, N'Linh Chi', N'123-123-1234', N'Long Bien', N'kimanh3082@gmail.com', N'Responded', N'oki', CAST(N'2021-07-22T00:13:49.857' AS DateTime), N'<p><img alt="" src="https://hinhnen123.com/wp-content/uploads/2021/06/anh-meo-cute-nhat-9.jpg" style="height:500px; width:500px" /></p>

<p>good</p>
', CAST(N'2021-07-22T16:52:49.123' AS DateTime))
INSERT [dbo].[Contact] ([ContactID], [CustomerName], [Phone], [Address], [Email], [Status], [Message], [CreateMessageDate], [ResponseMessage], [ResponseMessageDate]) VALUES (13, N'Tien Tai', N'123-123-1234', N'BG', N'kimanh3082@gmail.com', N'No response yet', N'oki', CAST(N'2021-07-22T00:16:31.377' AS DateTime), NULL, NULL)
INSERT [dbo].[Contact] ([ContactID], [CustomerName], [Phone], [Address], [Email], [Status], [Message], [CreateMessageDate], [ResponseMessage], [ResponseMessageDate]) VALUES (14, N'Huyen Lan', N'123-123-1234', N'Truong Chinh', N'sd@gmail.com', N'Responded', N'oki', CAST(N'2021-07-22T00:19:23.370' AS DateTime), N'<p><img alt="" src="https://pdp.edu.vn/wp-content/uploads/2021/04/hinh-anh-nen-con-meo-cute.jpg" style="height:90px; width:120px" /></p>

<ul>
	<li>cute</li>
	<li>oki</li>
</ul>
', CAST(N'2021-07-22T03:33:18.233' AS DateTime))
INSERT [dbo].[Contact] ([ContactID], [CustomerName], [Phone], [Address], [Email], [Status], [Message], [CreateMessageDate], [ResponseMessage], [ResponseMessageDate]) VALUES (15, N'Pham Trung', N'123-123-1234', N'Long Bien', N'kimanh3082@gmail.com', N'Responded', N'oki', CAST(N'2021-07-22T00:21:38.873' AS DateTime), N'<p>oki good job</p>

<p><img alt="" src="https://documen.tv/wp-content/uploads/mon_hoc/tong_hop/1_9999/ve-cho-minh-moi-ban-co-4-buc-anh-meo-de-thuong-nha-u-nha-cai-o-duoi-la-minh-cho-coi-thoi-dung-ve-997740.jpg" /></p>
', CAST(N'2021-07-22T16:47:59.667' AS DateTime))
INSERT [dbo].[Contact] ([ContactID], [CustomerName], [Phone], [Address], [Email], [Status], [Message], [CreateMessageDate], [ResponseMessage], [ResponseMessageDate]) VALUES (16, N'Phuong Trinh', N'123-123-1234', N'Long Bien 1234', N'kimanh3082@gmail.com', N'Responded', N'oki', CAST(N'2021-07-22T00:23:20.950' AS DateTime), N'<p><img alt="" src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS284qz9H6CeO08zBXfkOawN102He1shvldRQ&amp;usqp=CAU" style="height:168px; width:300px" /></p>

<p>oki k&iacute; hop dong</p>
', CAST(N'2021-07-22T16:46:13.347' AS DateTime))
INSERT [dbo].[Contact] ([ContactID], [CustomerName], [Phone], [Address], [Email], [Status], [Message], [CreateMessageDate], [ResponseMessage], [ResponseMessageDate]) VALUES (17, N'Manh Hoang', N'123-123-1234', N'HN', N'anhhtk3082@gmail.com', N'No response yet', N'oki', CAST(N'2021-07-22T00:26:27.507' AS DateTime), NULL, NULL)
INSERT [dbo].[Contact] ([ContactID], [CustomerName], [Phone], [Address], [Email], [Status], [Message], [CreateMessageDate], [ResponseMessage], [ResponseMessageDate]) VALUES (18, N'Huy Hoang', N'123-123-1234', N'Truong Chinh', N'anhhtk3082@gmail.com', N'No response yet', N'oki', CAST(N'2021-07-22T00:41:05.663' AS DateTime), NULL, NULL)
INSERT [dbo].[Contact] ([ContactID], [CustomerName], [Phone], [Address], [Email], [Status], [Message], [CreateMessageDate], [ResponseMessage], [ResponseMessageDate]) VALUES (19, N'Tien Dung', N'123-123-1234', N'Long Bien', N'kimanh3082@gmail.com', N'Responded', N'oki r', CAST(N'2021-07-22T01:21:01.527' AS DateTime), N'<p><img alt="" src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSq1AJq6j2f5i1FM9u-hrInCxWPhNUnK-sqsA&amp;usqp=CAU" style="height:221px; width:229px" /></p>

<p>oki la</p>
', CAST(N'2021-07-22T16:39:26.680' AS DateTime))
INSERT [dbo].[Contact] ([ContactID], [CustomerName], [Phone], [Address], [Email], [Status], [Message], [CreateMessageDate], [ResponseMessage], [ResponseMessageDate]) VALUES (20, N'Linh Chi', N'123-123-1234', N'Long Bien', N'kimanh3082@gmail.com', N'No response yet', N'oki', CAST(N'2021-07-22T16:55:15.277' AS DateTime), NULL, NULL)
INSERT [dbo].[Contact] ([ContactID], [CustomerName], [Phone], [Address], [Email], [Status], [Message], [CreateMessageDate], [ResponseMessage], [ResponseMessageDate]) VALUES (21, N'Kim Anh Hoang ok', N'123-123-1234', N'Long Bien 1234', N'kimanh3082@gmail.com', N'No response yet', N'oki', CAST(N'2021-07-22T17:07:35.530' AS DateTime), NULL, NULL)
INSERT [dbo].[Contact] ([ContactID], [CustomerName], [Phone], [Address], [Email], [Status], [Message], [CreateMessageDate], [ResponseMessage], [ResponseMessageDate]) VALUES (22, N'Linh Chi', N'123-123-1234', N'Long Bien', N'kimanh3082@gmail.com', N'No response yet', N'toi dong y', CAST(N'2021-07-22T17:11:48.100' AS DateTime), NULL, NULL)
INSERT [dbo].[Contact] ([ContactID], [CustomerName], [Phone], [Address], [Email], [Status], [Message], [CreateMessageDate], [ResponseMessage], [ResponseMessageDate]) VALUES (23, N'Kim Anh Hoang', N'123-123-1234', N'Long Bien', N'kimanh3082@gmail.com', N'Responded', N'oki chưa', CAST(N'2021-07-23T21:02:01.260' AS DateTime), N'<p>oki roi</p>
', CAST(N'2021-07-23T21:53:38.050' AS DateTime))
SET IDENTITY_INSERT [dbo].[Contact] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Quantity], [ShortDes], [Description], [Image], [CategoryID], [Status]) VALUES (1, N'Scallop and shrimp dumpling', 75.6, 3, N'Lorem ipsum dolor sit amet', N'Lorem ipsum dolor sit amet', N'236766cc-fe4f-4142-e4c5-191cdaf54263.jpg', 1, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Quantity], [ShortDes], [Description], [Image], [CategoryID], [Status]) VALUES (2, N'Shrimp dumpling', 69.3, 5, N'Lorem ipsum dolor sit amet', N'Lorem ipsum dolor sit amet', N'7702c6a7-3718-4f64-223f-1581b456b9d7.jpg', 1, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Quantity], [ShortDes], [Description], [Image], [CategoryID], [Status]) VALUES (3, N'Minced pork with shrimp & mushroom dumpling', 69.3, 8, N'Lorem ipsum dolor sit amet', N'Lorem ipsum dolor sit amet', N'943e1717-f5a1-486d-97ed-743206e3d68b.jpg', 1, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Quantity], [ShortDes], [Description], [Image], [CategoryID], [Status]) VALUES (4, N'Shanghai dumpling', 68.25, 7, N'Lorem ipsum dolor sit amet', N'Lorem ipsum dolor sit amet', N'70f53921-16a4-4e03-3b84-ed242a5aead7.jpg', 1, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Quantity], [ShortDes], [Description], [Image], [CategoryID], [Status]) VALUES (5, N'The shrimp cone', 65.1, 9, N'Lorem ipsum dolor sit amet', N'Lorem ipsum dolor sit amet', N'64b7c3d9-a044-4832-77f4-b4def949d2e5.jpg', 1, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Quantity], [ShortDes], [Description], [Image], [CategoryID], [Status]) VALUES (6, N'Steamed rice roll with bbq pork', 63, 8, N'Lorem ipsum dolor sit amet', N'Lorem ipsum dolor sit amet', N'59c174e0-3244-4dd9-029b-5a84c79cb17f.jpg', 1, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Quantity], [ShortDes], [Description], [Image], [CategoryID], [Status]) VALUES (7, N'Prawn Prawns Luc Luc', 75.6, 10, N'Lorem ipsum dolor sit amet', N'Lorem ipsum dolor sit amet', N'59c174e0-3244-4dd9-029b-5a84c79cb17f.jpg', 1, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Quantity], [ShortDes], [Description], [Image], [CategoryID], [Status]) VALUES (8, N'Stir fried broccoli with oyster sauce', 94.5, 10, N'Lorem ipsum dolor sit amet', N'Lorem ipsum dolor sit amet', N'1a309ab3-a1e4-4c8f-b1aa-1baa87f108f8.jpg', 2, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Quantity], [ShortDes], [Description], [Image], [CategoryID], [Status]) VALUES (9, N'Bunapi mushroom stir in dried shrimp sauce', 96.6, 10, N'Lorem ipsum dolor sit amet', N'Lorem ipsum dolor sit amet', N'c3083626-6e2e-4849-8d8c-eeb4888c-687cfcd3-201222111238.jpeg', 2, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Quantity], [ShortDes], [Description], [Image], [CategoryID], [Status]) VALUES (10, N'Stir-fried hong kong cabbage with garlic', 96.6, 10, N'Lorem ipsum dolor sit amet', N'Lorem ipsum dolor sit amet', N'c3083626-6e2e-4849-8d8c-eeb4888c-687cfcd3-201222111238.jpeg', 2, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Quantity], [ShortDes], [Description], [Image], [CategoryID], [Status]) VALUES (11, N'A Ma BBQ', 258.3, 8, N'Lorem ipsum dolor sit amet', N'Lorem ipsum dolor sit amet', N'a39d1607-75cd-4dd4-1c93-9877b61ca478.jpg', 3, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Quantity], [ShortDes], [Description], [Image], [CategoryID], [Status]) VALUES (12, N'Bbq duck in hong kong style', 186.9, 8, N'Lorem ipsum dolor sit amet', N'Lorem ipsum dolor sit amet', N'b92f4e3a-1e69-40f0-08c8-4da8b8713126.jpg', 3, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Quantity], [ShortDes], [Description], [Image], [CategoryID], [Status]) VALUES (13, N'Honey bbq pork', 165.9, 9, N'Lorem ipsum dolor sit amet', N'Lorem ipsum dolor sit amet', N'236766cc-fe4f-4142-e4c5-191cdaf54263.jpg', 3, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Quantity], [ShortDes], [Description], [Image], [CategoryID], [Status]) VALUES (14, N'Crispy Roasted Pork', 176.4, 7, N'Lorem ipsum dolor sit amet', N'Lorem ipsum dolor sit amet', N'236766cc-fe4f-4142-e4c5-191cdaf54263.jpg', 3, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Quantity], [ShortDes], [Description], [Image], [CategoryID], [Status]) VALUES (15, N'Deep fried pork rib with pepper & salt', 176.4, 8, N'Lorem ipsum dolor sit amet', N'Lorem ipsum dolor sit amet', N'236766cc-fe4f-4142-e4c5-191cdaf54263.jpg', 3, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Quantity], [ShortDes], [Description], [Image], [CategoryID], [Status]) VALUES (16, N'Deep dried pork rib with sweet & sour sauce', 176.4, 8, N'Lorem ipsum dolor sit amet', N'Lorem ipsum dolor sit amet', N'236766cc-fe4f-4142-e4c5-191cdaf54263.jpg', 3, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Quantity], [ShortDes], [Description], [Image], [CategoryID], [Status]) VALUES (17, N'A ma chicken (full)', 522.9, 10, N'Lorem ipsum dolor sit amet', N'Lorem ipsum dolor sit amet', N'70f53921-16a4-4e03-3b84-ed242a5aead7.jpg', 3, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Quantity], [ShortDes], [Description], [Image], [CategoryID], [Status]) VALUES (18, N'Wok-fried hot fun with sliced beef', 134.4, 10, N'Lorem ipsum dolor sit amet', N'Lorem ipsum dolor sit amet', N'70f53921-16a4-4e03-3b84-ed242a5aead7.jpg', 4, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Quantity], [ShortDes], [Description], [Image], [CategoryID], [Status]) VALUES (19, N'Dried noodle with bbq pork.', 96.6, 8, N'Lorem ipsum dolor sit amet', N'Lorem ipsum dolor sit amet', N'70f53921-16a4-4e03-3b84-ed242a5aead7.jpg', 4, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Quantity], [ShortDes], [Description], [Image], [CategoryID], [Status]) VALUES (20, N'Dried noodle with bbq crispy pork belly', 121.8, 8, N'Lorem ipsum dolor sit amet', N'Lorem ipsum dolor sit amet', N'70f53921-16a4-4e03-3b84-ed242a5aead7.jpg', 4, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Quantity], [ShortDes], [Description], [Image], [CategoryID], [Status]) VALUES (21, N'Dried noodle with bbq roasted duck', 96.6, 10, N'Lorem ipsum dolor sit amet', N'Lorem ipsum dolor sit amet', N'943e1717-f5a1-486d-97ed-743206e3d68b.jpg', 4, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Quantity], [ShortDes], [Description], [Image], [CategoryID], [Status]) VALUES (22, N'Dried noodle with bbq crispy pork belly', 96.6, 10, N'Lorem ipsum dolor sit amet', N'Lorem ipsum dolor sit amet', N'943e1717-f5a1-486d-97ed-743206e3d68b.jpg', 4, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Quantity], [ShortDes], [Description], [Image], [CategoryID], [Status]) VALUES (23, N'Prawn de mango', 207.9, 10, N'Lorem ipsum dolor sit amet', N'Lorem ipsum dolor sit amet', N'943e1717-f5a1-486d-97ed-743206e3d68b.jpg', 4, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Quantity], [ShortDes], [Description], [Image], [CategoryID], [Status]) VALUES (24, N'Deep fried prawn with salted egg yolk', 207.9, 10, N'Lorem ipsum dolor sit amet', N'Lorem ipsum dolor sit amet', N'59c174e0-3244-4dd9-029b-5a84c79cb17f.jpg', 4, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Quantity], [ShortDes], [Description], [Image], [CategoryID], [Status]) VALUES (25, N'Deep fried prawn in singapore style', 302.4, 10, N'Lorem ipsum dolor sit amet', N'Lorem ipsum dolor sit amet', N'59c174e0-3244-4dd9-029b-5a84c79cb17f.jpg', 4, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Quantity], [ShortDes], [Description], [Image], [CategoryID], [Status]) VALUES (26, N'1980s milk tea', 66.15, 10, N'Lorem ipsum dolor sit amet', N'Lorem ipsum dolor sit amet', N'59c174e0-3244-4dd9-029b-5a84c79cb17f.jpg', 5, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Quantity], [ShortDes], [Description], [Image], [CategoryID], [Status]) VALUES (27, N'Lychee tea', 60.8, 10, N'Lorem ipsum dolor sit amet', N'Lorem ipsum dolor sit amet', N'59c174e0-3244-4dd9-029b-5a84c79cb17f.jpg', 5, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Quantity], [ShortDes], [Description], [Image], [CategoryID], [Status]) VALUES (28, N'Peach lemon grass tea', 60.9, 10, N'Lorem ipsum dolor sit amet', N'Lorem ipsum dolor sit amet', N'59c174e0-3244-4dd9-029b-5a84c79cb17f.jpg', 5, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Quantity], [ShortDes], [Description], [Image], [CategoryID], [Status]) VALUES (29, N'Ginger lime tea', 57.75, 10, N'Lorem ipsum dolor sit amet', N'Lorem ipsum dolor sit amet', N'1a309ab3-a1e4-4c8f-b1aa-1baa87f108f8.jpg', 5, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Quantity], [ShortDes], [Description], [Image], [CategoryID], [Status]) VALUES (30, N'Fragrant lemonade with aloe vera', 63, 10, N'Lorem ipsum dolor sit amet', N'Lorem ipsum dolor sit amet', N'1a309ab3-a1e4-4c8f-b1aa-1baa87f108f8.jpg', 5, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Quantity], [ShortDes], [Description], [Image], [CategoryID], [Status]) VALUES (31, N'Watermelon juice', 60.9, 10, N'Lorem ipsum dolor sit amet', N'Lorem ipsum dolor sit amet', N'59c174e0-3244-4dd9-029b-5a84c79cb17f.jpg', 5, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Quantity], [ShortDes], [Description], [Image], [CategoryID], [Status]) VALUES (32, N'Buckwheat milk tea', 66.15, 10, N'Lorem ipsum dolor sit amet', N'Lorem ipsum dolor sit amet', N'236766cc-fe4f-4142-e4c5-191cdaf54263.jpg', 5, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Quantity], [ShortDes], [Description], [Image], [CategoryID], [Status]) VALUES (33, N'Red chrysanthemum tea', 60.9, 10, N'Lorem ipsum dolor sit amet', N'Lorem ipsum dolor sit amet', N'59c174e0-3244-4dd9-029b-5a84c79cb17f.jpg', 5, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Quantity], [ShortDes], [Description], [Image], [CategoryID], [Status]) VALUES (34, N'Plain tea', 60.9, 10, N'Lorem ipsum dolor sit amet', N'Lorem ipsum dolor sit amet', N'236766cc-fe4f-4142-e4c5-191cdaf54263.jpg', 5, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Quantity], [ShortDes], [Description], [Image], [CategoryID], [Status]) VALUES (35, N'Blended black sesame', 65.1, 6, N'Lorem ipsum dolor sit amet', N'Lorem ipsum dolor sit amet', N'236766cc-fe4f-4142-e4c5-191cdaf54263.jpg', 6, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Quantity], [ShortDes], [Description], [Image], [CategoryID], [Status]) VALUES (36, N'Chilled mango cream with sago & pomelo', 69.3, 9, N'Lorem ipsum dolor sit amet', N'Lorem ipsum dolor sit amet', N'59c174e0-3244-4dd9-029b-5a84c79cb17f.jpg', 6, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [Price], [Quantity], [ShortDes], [Description], [Image], [CategoryID], [Status]) VALUES (37, N'Lotus seed with logan', 65.1, 0, N'Lorem ipsum dolor sit amet', N'123', N'943e1717-f5a1-486d-97ed-743206e3d68b.jpg', 6, 1)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (1, N'User')
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (2, N'Staff')
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (3, N'Admin')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Role]
GO
ALTER TABLE [dbo].[History]  WITH CHECK ADD  CONSTRAINT [FK_History_Account] FOREIGN KEY([UserId])
REFERENCES [dbo].[Account] ([UserID])
GO
ALTER TABLE [dbo].[History] CHECK CONSTRAINT [FK_History_Account]
GO
ALTER TABLE [dbo].[History]  WITH CHECK ADD  CONSTRAINT [FK_History_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[History] CHECK CONSTRAINT [FK_History_Product]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Account] FOREIGN KEY([UserID])
REFERENCES [dbo].[Account] ([UserID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Account]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_History] FOREIGN KEY([HistoryID])
REFERENCES [dbo].[History] ([HistoryId])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_History]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Table] FOREIGN KEY([TableID])
REFERENCES [dbo].[Table] ([TableID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Table]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Order] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([OrderID])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Order]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Product]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([CategoryID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_Account] FOREIGN KEY([UserID])
REFERENCES [dbo].[Account] ([UserID])
GO
ALTER TABLE [dbo].[Reservation] CHECK CONSTRAINT [FK_Reservation_Account]
GO
