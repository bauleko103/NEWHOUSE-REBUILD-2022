USE [master]
GO
/****** Object:  Database [NEWHOUSE2022]    Script Date: 08/10/2022 3:42:55 AM ******/
CREATE DATABASE [NEWHOUSE2022]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NEWHOUSE2022', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\NEWHOUSE2022.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'NEWHOUSE2022_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\NEWHOUSE2022_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [NEWHOUSE2022] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NEWHOUSE2022].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NEWHOUSE2022] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NEWHOUSE2022] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NEWHOUSE2022] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NEWHOUSE2022] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NEWHOUSE2022] SET ARITHABORT OFF 
GO
ALTER DATABASE [NEWHOUSE2022] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NEWHOUSE2022] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NEWHOUSE2022] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NEWHOUSE2022] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NEWHOUSE2022] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NEWHOUSE2022] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NEWHOUSE2022] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NEWHOUSE2022] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NEWHOUSE2022] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NEWHOUSE2022] SET  DISABLE_BROKER 
GO
ALTER DATABASE [NEWHOUSE2022] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NEWHOUSE2022] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NEWHOUSE2022] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NEWHOUSE2022] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NEWHOUSE2022] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NEWHOUSE2022] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NEWHOUSE2022] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NEWHOUSE2022] SET RECOVERY FULL 
GO
ALTER DATABASE [NEWHOUSE2022] SET  MULTI_USER 
GO
ALTER DATABASE [NEWHOUSE2022] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NEWHOUSE2022] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NEWHOUSE2022] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NEWHOUSE2022] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [NEWHOUSE2022] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [NEWHOUSE2022] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'NEWHOUSE2022', N'ON'
GO
ALTER DATABASE [NEWHOUSE2022] SET QUERY_STORE = OFF
GO
USE [NEWHOUSE2022]
GO
/****** Object:  Table [dbo].[ADMIN]    Script Date: 08/10/2022 3:42:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ADMIN](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TaiKhoan] [nvarchar](100) NULL,
	[MatKhau] [nvarchar](100) NULL,
	[LoginErrorMessage] [nvarchar](100) NULL,
 CONSTRAINT [PK_ADMIN] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CongNghe]    Script Date: 08/10/2022 3:42:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CongNghe](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TuaDe11] [nvarchar](50) NULL,
	[NoiDung11] [ntext] NULL,
	[TuaDe12] [nvarchar](50) NULL,
	[NoiDung12] [ntext] NULL,
	[Hinh1] [nvarchar](max) NULL,
	[TuaDe2] [nvarchar](50) NULL,
	[NoiDung2] [ntext] NULL,
	[Hinh2] [nvarchar](max) NULL,
	[TuaDeChinh] [nvarchar](50) NULL,
	[TrichDan] [ntext] NULL,
 CONSTRAINT [PK_CongNghe] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DoiTac]    Script Date: 08/10/2022 3:42:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DoiTac](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TuaDe] [nvarchar](50) NULL,
	[Link] [nvarchar](max) NULL,
	[Hinh] [nvarchar](max) NULL,
 CONSTRAINT [PK_DoiTac] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DUAN]    Script Date: 08/10/2022 3:42:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DUAN](
	[IDDuan] [int] IDENTITY(1,1) NOT NULL,
	[TuaDe] [nvarchar](100) NULL,
	[TuaDePhu] [nvarchar](100) NULL,
	[NgayThang] [nvarchar](100) NULL,
	[NoiDung] [ntext] NULL,
	[Hinh] [nvarchar](max) NULL,
	[GioiThieu] [ntext] NULL,
	[LoaiDuAn] [nvarchar](300) NULL,
 CONSTRAINT [PK_DUAN] PRIMARY KEY CLUSTERED 
(
	[IDDuan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GiaiPhap]    Script Date: 08/10/2022 3:42:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiaiPhap](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TuaDe] [nvarchar](50) NULL,
	[NoiDung] [ntext] NULL,
	[Hinh] [nvarchar](max) NULL,
 CONSTRAINT [PK_GiaiPhap] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IconXaHoi]    Script Date: 08/10/2022 3:42:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IconXaHoi](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Icon1] [nvarchar](max) NULL,
	[Link1] [nvarchar](max) NULL,
	[Icon2] [nvarchar](max) NULL,
	[Link2] [nvarchar](max) NULL,
	[Icon3] [nvarchar](max) NULL,
	[Link3] [nvarchar](max) NULL,
	[Icon4] [nvarchar](max) NULL,
	[Link4] [nvarchar](max) NULL,
 CONSTRAINT [PK_IconXaHoi] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KTS]    Script Date: 08/10/2022 3:42:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KTS](
	[IDKTS] [int] IDENTITY(1,1) NOT NULL,
	[TuaDe] [nvarchar](100) NULL,
	[TuaDePhu] [nvarchar](100) NULL,
	[NoiDung] [ntext] NULL,
	[Hinh] [nvarchar](max) NULL,
	[LoaiKTS] [nvarchar](100) NULL,
	[NgayThang] [nvarchar](100) NULL,
	[CongViec] [nvarchar](100) NULL,
	[GioiThieu] [nvarchar](max) NULL,
 CONSTRAINT [PK_KTS] PRIMARY KEY CLUSTERED 
(
	[IDKTS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KTS_DUAN]    Script Date: 08/10/2022 3:42:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KTS_DUAN](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDDuan] [int] NULL,
	[IDKTS] [int] NULL,
 CONSTRAINT [PK_KTS_DUAN] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LienHe]    Script Date: 08/10/2022 3:42:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LienHe](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Map] [nvarchar](max) NULL,
	[DiaChi] [nvarchar](100) NULL,
	[SoDienThoai] [varchar](50) NULL,
	[Mail] [nchar](10) NULL,
	[ThongTin] [ntext] NULL,
 CONSTRAINT [PK_LienHe] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoiGioiThieu]    Script Date: 08/10/2022 3:42:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoiGioiThieu](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[GioiThieuSanPham] [ntext] NULL,
	[GioiThieuTinhNang] [ntext] NULL,
	[GioiThieuKTS] [ntext] NULL,
 CONSTRAINT [PK_LoiGioiThieu] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 08/10/2022 3:42:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TuaDe] [nvarchar](50) NULL,
	[TuaDePhu] [nvarchar](200) NULL,
	[HinhGioiThieu] [nvarchar](max) NULL,
	[NoiDung] [ntext] NULL,
	[ViTri] [int] NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Slide]    Script Date: 08/10/2022 3:42:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slide](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SoThuTu] [int] NOT NULL,
	[TuaDe] [nvarchar](50) NULL,
	[TuaDePhu] [nvarchar](50) NULL,
	[Hinh] [nvarchar](max) NULL,
 CONSTRAINT [PK_Slide] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TinhNang]    Script Date: 08/10/2022 3:42:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TinhNang](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TuaDe] [nvarchar](50) NULL,
	[Hinh] [nvarchar](max) NULL,
	[NoiDung] [nvarchar](200) NULL,
 CONSTRAINT [PK_TinhNang] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TinTuc]    Script Date: 08/10/2022 3:42:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TinTuc](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TuaDe] [nvarchar](50) NULL,
	[Hinh] [nvarchar](max) NULL,
	[Link] [nvarchar](max) NULL,
 CONSTRAINT [PK_TinTuc] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ADMIN] ON 

INSERT [dbo].[ADMIN] ([ID], [TaiKhoan], [MatKhau], [LoginErrorMessage]) VALUES (1, N'baule', N'123', NULL)
SET IDENTITY_INSERT [dbo].[ADMIN] OFF
GO
SET IDENTITY_INSERT [dbo].[CongNghe] ON 

INSERT [dbo].[CongNghe] ([ID], [TuaDe11], [NoiDung11], [TuaDe12], [NoiDung12], [Hinh1], [TuaDe2], [NoiDung2], [Hinh2], [TuaDeChinh], [TrichDan]) VALUES (1, N'a', N'<p>aaaaaaaa</p>
', N'a', N'<p>a&aacute;dfasdfasdf</p>
', N'congnghe11.png', N'a', N'<p>aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa</p>
', N'congnghe21.png', N'aaahghb', N'<h5 style="text-align:center">ESSENTIAL TO LAYOUT</h5>

<h5 style="text-align:center">TRỌNG LƯỢNG NHẸ ĐỂ DỰNG L&Ecirc;N</h5>

<h5 style="text-align:center">90% ĐƯỢC L&Agrave;M TẠI XƯỞNG</h5>

<h5 style="text-align:center">4 NGƯỜI C&Oacute; THỂ X&Acirc;Y DỰNG TRONG 3 NG&Agrave;Y</h5>

<h5 style="text-align:center">T&Aacute;I SỬ DỤNG 100%</h5>
')
SET IDENTITY_INSERT [dbo].[CongNghe] OFF
GO
SET IDENTITY_INSERT [dbo].[DoiTac] ON 

INSERT [dbo].[DoiTac] ([ID], [TuaDe], [Link], [Hinh]) VALUES (1002, N'aaaaaaaaaa', N'aaaaa', N'doitac1002.jpg')
SET IDENTITY_INSERT [dbo].[DoiTac] OFF
GO
SET IDENTITY_INSERT [dbo].[DUAN] ON 

INSERT [dbo].[DUAN] ([IDDuan], [TuaDe], [TuaDePhu], [NgayThang], [NoiDung], [Hinh], [GioiThieu], [LoaiDuAn]) VALUES (3, N'bca', N'1', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[DUAN] ([IDDuan], [TuaDe], [TuaDePhu], [NgayThang], [NoiDung], [Hinh], [GioiThieu], [LoaiDuAn]) VALUES (4, N'AAA', N'2', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[DUAN] ([IDDuan], [TuaDe], [TuaDePhu], [NgayThang], [NoiDung], [Hinh], [GioiThieu], [LoaiDuAn]) VALUES (5, N'BBB', N'3', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[DUAN] ([IDDuan], [TuaDe], [TuaDePhu], [NgayThang], [NoiDung], [Hinh], [GioiThieu], [LoaiDuAn]) VALUES (6, N'CẤU TRÚC SANDWICH', N'aaaaaaaaaa', NULL, N'<p>&aacute;dfasdf</p>
', NULL, NULL, NULL)
INSERT [dbo].[DUAN] ([IDDuan], [TuaDe], [TuaDePhu], [NgayThang], [NoiDung], [Hinh], [GioiThieu], [LoaiDuAn]) VALUES (7, N'BAU', N'A', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[DUAN] ([IDDuan], [TuaDe], [TuaDePhu], [NgayThang], [NoiDung], [Hinh], [GioiThieu], [LoaiDuAn]) VALUES (8, N'BAU', N'A', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[DUAN] ([IDDuan], [TuaDe], [TuaDePhu], [NgayThang], [NoiDung], [Hinh], [GioiThieu], [LoaiDuAn]) VALUES (9, N'a', N'a', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[DUAN] ([IDDuan], [TuaDe], [TuaDePhu], [NgayThang], [NoiDung], [Hinh], [GioiThieu], [LoaiDuAn]) VALUES (10, N'a', N'A', NULL, N'<p>aaaaaaaaaaaaaaaaaaa</p>
', N'duan10.jpg', NULL, NULL)
SET IDENTITY_INSERT [dbo].[DUAN] OFF
GO
SET IDENTITY_INSERT [dbo].[GiaiPhap] ON 

INSERT [dbo].[GiaiPhap] ([ID], [TuaDe], [NoiDung], [Hinh]) VALUES (5, N'CẤU TRÚC SANDWICH', N'<p>Thay thế kết cấu truyền thống b&ecirc; t&ocirc;ng cho s&agrave;n v&agrave; tường dựa tr&ecirc;n kết cấu khung bằng phương ph&aacute;p kết hợp c&aacute;c lớp chịu lực, cấu tạo, xen kẽ tạo ra những tấm s&agrave;n tường chịu lực cao được &aacute;p dụng từ l&acirc;u trong thiết kế kết cấu hiện đại.<br />
Sự s&aacute;ng tạo đặc biệt của New House System khi thay hệ keo tổng hợp tại nh&agrave; m&aacute;y của tấm sandwich panel truyền thống bằng hệ nối smart lock, cho ph&eacute;p xấy dựng những tấm s&agrave;n - tường chịu lực vượt nhịp lớn l&ecirc;n đến 9m kh&ocirc;ng cần khung c&oacute; thể lắp đặt dễ d&agrave;ng với 2 c&ocirc;ng nh&acirc;n khỏe mạnh.<br />
Ngo&agrave;i ra &aacute;p dụng c&ocirc;ng nghệ gfc composite cho ph&aacute;p c&aacute;c lớp chịu lực thay thế cho gỗ v&agrave; th&eacute;p trong m&ocirc;i trường v&ugrave;ng biển giải quyết b&agrave;i to&aacute;n kh&oacute; cho hệ sandwich truyền thống đang gặp phải kh&ocirc;ng ứng dụng được.<br />
Multilayer structure solution developed and certified in 2016.&nbsp;</p>
', N'giaiPhap5.png')
INSERT [dbo].[GiaiPhap] ([ID], [TuaDe], [NoiDung], [Hinh]) VALUES (7, N'HỆ HOÀN THIỆN TẾ BÀO', N'<p>Tất cả c&aacute;c ho&agrave;n thiện truyền thống thường được thực hiện tại c&ocirc;ng trường với nhiều rủi ro chất lượng g&acirc;y ra sự tốn k&eacute;m thời gian v&agrave; kh&ocirc;ng d&ugrave;ng lại được khi thay thế cho c&aacute;c hệ s&agrave;n v&agrave; gạch.<br />
New house system ph&aacute;t triển triệt để c&aacute;c lớp ho&agrave;n thiện truyền thống gắn kết với lớp kết cấu qua hệ clips v&agrave; modul era c&aacute;c tấm độc lập c&oacute; khối lượng nhỏ hơn 10kg/cell cho ph&eacute;p c&ocirc;ng t&aacute;c ho&agrave;n thiện ch&iacute;nh x&aacute;c như đo cắt v&agrave; thay thế đễ d&agrave;ng trong trường hợp hư hỏng v&agrave; đổi mới.<br />
Hệ cell system của new house gần như ứng dụng cho tất cả c&aacute;c lớp ho&agrave;n thiện to&agrave;n diện như: đ&aacute; gỗ, kim loại, một số hệ gạch, k&iacute;nh c&aacute;c loại. Thậm ch&iacute; c&oacute; cả green roof v&agrave; green wall.<br />
Cho ph&eacute;p ho&agrave;n thiện tr&ecirc;n bất k&igrave; bề mặt n&agrave;o bằng c&aacute;ch chia nhỏ c&aacute;c bề mặt từ c&aacute;c hệ đơn nhịp đơn giản đến hệ paramatric phức tạp hơn.</p>
', N'giaiPhap7.png')
SET IDENTITY_INSERT [dbo].[GiaiPhap] OFF
GO
SET IDENTITY_INSERT [dbo].[IconXaHoi] ON 

INSERT [dbo].[IconXaHoi] ([ID], [Icon1], [Link1], [Icon2], [Link2], [Icon3], [Link3], [Icon4], [Link4]) VALUES (1, NULL, N'a', NULL, N'a', NULL, N'a', NULL, N'a')
SET IDENTITY_INSERT [dbo].[IconXaHoi] OFF
GO
SET IDENTITY_INSERT [dbo].[KTS] ON 

INSERT [dbo].[KTS] ([IDKTS], [TuaDe], [TuaDePhu], [NoiDung], [Hinh], [LoaiKTS], [NgayThang], [CongViec], [GioiThieu]) VALUES (1, N'BAU', N'a', N'a', N'A', N'A', N'A', N'A', NULL)
INSERT [dbo].[KTS] ([IDKTS], [TuaDe], [TuaDePhu], [NoiDung], [Hinh], [LoaiKTS], [NgayThang], [CongViec], [GioiThieu]) VALUES (2, N'HOALE', N'A', N'A', N'A', N'A', N'A', N'A', NULL)
SET IDENTITY_INSERT [dbo].[KTS] OFF
GO
SET IDENTITY_INSERT [dbo].[KTS_DUAN] ON 

INSERT [dbo].[KTS_DUAN] ([ID], [IDDuan], [IDKTS]) VALUES (1, 3, 2)
INSERT [dbo].[KTS_DUAN] ([ID], [IDDuan], [IDKTS]) VALUES (2, 4, 1)
INSERT [dbo].[KTS_DUAN] ([ID], [IDDuan], [IDKTS]) VALUES (3, 4, 1)
SET IDENTITY_INSERT [dbo].[KTS_DUAN] OFF
GO
SET IDENTITY_INSERT [dbo].[LienHe] ON 

INSERT [dbo].[LienHe] ([ID], [Map], [DiaChi], [SoDienThoai], [Mail], [ThongTin]) VALUES (1, N'a', N'aa', N'a', N'a         ', N'a')
SET IDENTITY_INSERT [dbo].[LienHe] OFF
GO
SET IDENTITY_INSERT [dbo].[LoiGioiThieu] ON 

INSERT [dbo].[LoiGioiThieu] ([ID], [GioiThieuSanPham], [GioiThieuTinhNang], [GioiThieuKTS]) VALUES (1, N'Chúng tôi đang phát triển 4 hệ nhà tiêu chuẩn bao gồm: The LOG, The KARO, The SLAB và The DOME. Đồng thời, Chúng tôi cũng là đơn vị duy nhất thực hiện các mẫu thử ở tỉ lệ thực tế 1:1. Không chỉ kiếm tra về sự tiện dụng của không gian kiến trúc, các mẫu thử này còn giúp chúng tôi kiểm nghiệm tính ổn định, mức độ bền vững tối thiểu trong các điều kiện cực kì khắc nghiệt. Tất cả các mẫu thử đều ổn định sau hơn hai năm với những điều kiện tự nhiên như mưa lớn, gió mạnh hoặc nắng nóng. Các nguyên vật liệu sử dụng cho các mẫu thử chỉ là vật liệu tận dụng có chất lượng kém, so với vật liệu chất lượng thực đã được xử lí và sản xuất bởi các đơn vị chuyên nghiệp chỉ bằng khoảng 20%. CÁC THIẾT KẾ GIỚI HẠN CHO MẪU THỬ. cho phép nhà đầu tư ấn định các mức độ đầu tư và thời gian sản phẩm.
bbbbbbbbb', N'Là một trong 4 loại nhà được phát triển bởi công ty New House, điểm khác biệt của The Log so với phần còn lại(the Slab, the Kolumn, the Dome) là cấu trúc phát triển từ phương pháp xếp chồng gỗ lên nhau để tạo thành tường và sàn. Dưới đây sẽ cho bạn một cái nhìn tốt hơn về sản phẩm The Log dòng Economics.
bbbbbb', N'Những tác phẩm chưa từng được công bố, tác phẩm là tâm huyết của các kiến trúc sư nhiều năm kinh nghiệm. Những kiến trúc sư nổi tiếng, ấp ủ những mẫu thiết kế mới, sáng tạo và vô cùng độc đáo.
Hãy sở hữu cho mình ngay một tác phẩm độc đáo nhất tại New House.
TIẾT KIỆM THỜI GIAN VÀ TIỀN BẠC – KẾT NỐI SÁNG TẠO
Hơn 100 thiết kế độc đáo, đặc biệt đang chờ bạn.
aaaaaaa')
SET IDENTITY_INSERT [dbo].[LoiGioiThieu] OFF
GO
SET IDENTITY_INSERT [dbo].[SanPham] ON 

INSERT [dbo].[SanPham] ([ID], [TuaDe], [TuaDePhu], [HinhGioiThieu], [NoiDung], [ViTri]) VALUES (3, N'CẤU TRÚC SANDWICH', N'aaaaaaaaaa', N'sanpham3.jpg', N'<p><img alt="" src="/DATA/Images/pexels-eyup-beyhan-13787836.jpg" style="height:1200px; width:800px" /></p>

<p><img alt="" src="/DATA/Images/pexels-alleksana-4238325.jpg" style="height:1200px; width:800px" /></p>
', NULL)
SET IDENTITY_INSERT [dbo].[SanPham] OFF
GO
SET IDENTITY_INSERT [dbo].[Slide] ON 

INSERT [dbo].[Slide] ([ID], [SoThuTu], [TuaDe], [TuaDePhu], [Hinh]) VALUES (2, 4, N'aaa', N'aaaaaaaaaa', N'slide2.png')
INSERT [dbo].[Slide] ([ID], [SoThuTu], [TuaDe], [TuaDePhu], [Hinh]) VALUES (3, 6, N'aaa', N'aaaaaaaaaa', N'slide3.png')
INSERT [dbo].[Slide] ([ID], [SoThuTu], [TuaDe], [TuaDePhu], [Hinh]) VALUES (4, 7, N'aaa', N'aaaaaaaaaa', N'slide4.jpg')
SET IDENTITY_INSERT [dbo].[Slide] OFF
GO
SET IDENTITY_INSERT [dbo].[TinTuc] ON 

INSERT [dbo].[TinTuc] ([ID], [TuaDe], [Hinh], [Link]) VALUES (1, N'aaaaaaaaaa', N'tintuc1.jpg', N'ádfasdf')
SET IDENTITY_INSERT [dbo].[TinTuc] OFF
GO
/****** Object:  Index [UQ__Slide__9D08B27F178D5082]    Script Date: 08/10/2022 3:42:55 AM ******/
ALTER TABLE [dbo].[Slide] ADD UNIQUE NONCLUSTERED 
(
	[SoThuTu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[KTS_DUAN]  WITH CHECK ADD  CONSTRAINT [FK_KTS_DUAN_DUAN] FOREIGN KEY([IDDuan])
REFERENCES [dbo].[DUAN] ([IDDuan])
GO
ALTER TABLE [dbo].[KTS_DUAN] CHECK CONSTRAINT [FK_KTS_DUAN_DUAN]
GO
ALTER TABLE [dbo].[KTS_DUAN]  WITH CHECK ADD  CONSTRAINT [FK_KTS_DUAN_KTS] FOREIGN KEY([IDKTS])
REFERENCES [dbo].[KTS] ([IDKTS])
GO
ALTER TABLE [dbo].[KTS_DUAN] CHECK CONSTRAINT [FK_KTS_DUAN_KTS]
GO
USE [master]
GO
ALTER DATABASE [NEWHOUSE2022] SET  READ_WRITE 
GO
