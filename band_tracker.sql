USE [band_tracker]
GO
/****** Object:  Table [dbo].[bands]    Script Date: 7/24/2016 8:26:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[bands](
	[name] [varchar](255) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[bands_venues]    Script Date: 7/24/2016 8:26:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bands_venues](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[venues_id] [int] NULL,
	[bands_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[venues]    Script Date: 7/24/2016 8:26:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[venues](
	[name] [varchar](255) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[bands] ON 

INSERT [dbo].[bands] ([name], [id]) VALUES (N'Nas', 4)
INSERT [dbo].[bands] ([name], [id]) VALUES (N'QuestLove', 5)
INSERT [dbo].[bands] ([name], [id]) VALUES (N'The Killers', 3)
INSERT [dbo].[bands] ([name], [id]) VALUES (N'Tegan And Sara', 6)
INSERT [dbo].[bands] ([name], [id]) VALUES (N'the cool guys', 8)
INSERT [dbo].[bands] ([name], [id]) VALUES (N'Hip Guy', 7)
SET IDENTITY_INSERT [dbo].[bands] OFF
SET IDENTITY_INSERT [dbo].[bands_venues] ON 

INSERT [dbo].[bands_venues] ([id], [venues_id], [bands_id]) VALUES (5, 3, 2)
INSERT [dbo].[bands_venues] ([id], [venues_id], [bands_id]) VALUES (2, 3, 1)
INSERT [dbo].[bands_venues] ([id], [venues_id], [bands_id]) VALUES (6, 3, 2)
INSERT [dbo].[bands_venues] ([id], [venues_id], [bands_id]) VALUES (4, 3, 1)
INSERT [dbo].[bands_venues] ([id], [venues_id], [bands_id]) VALUES (7, 3, 2)
INSERT [dbo].[bands_venues] ([id], [venues_id], [bands_id]) VALUES (8, 3, 2)
INSERT [dbo].[bands_venues] ([id], [venues_id], [bands_id]) VALUES (9, 3, 2)
INSERT [dbo].[bands_venues] ([id], [venues_id], [bands_id]) VALUES (10, 3, 2)
INSERT [dbo].[bands_venues] ([id], [venues_id], [bands_id]) VALUES (11, 3, 2)
INSERT [dbo].[bands_venues] ([id], [venues_id], [bands_id]) VALUES (12, 3, 2)
INSERT [dbo].[bands_venues] ([id], [venues_id], [bands_id]) VALUES (13, 3, 2)
INSERT [dbo].[bands_venues] ([id], [venues_id], [bands_id]) VALUES (14, 3, 2)
INSERT [dbo].[bands_venues] ([id], [venues_id], [bands_id]) VALUES (15, 3, 2)
INSERT [dbo].[bands_venues] ([id], [venues_id], [bands_id]) VALUES (16, 3, 2)
INSERT [dbo].[bands_venues] ([id], [venues_id], [bands_id]) VALUES (17, 3, 2)
INSERT [dbo].[bands_venues] ([id], [venues_id], [bands_id]) VALUES (18, 3, 2)
INSERT [dbo].[bands_venues] ([id], [venues_id], [bands_id]) VALUES (19, 3, 2)
INSERT [dbo].[bands_venues] ([id], [venues_id], [bands_id]) VALUES (20, 3, 2)
INSERT [dbo].[bands_venues] ([id], [venues_id], [bands_id]) VALUES (21, 3, 2)
INSERT [dbo].[bands_venues] ([id], [venues_id], [bands_id]) VALUES (22, 3, 2)
INSERT [dbo].[bands_venues] ([id], [venues_id], [bands_id]) VALUES (23, 3, 2)
INSERT [dbo].[bands_venues] ([id], [venues_id], [bands_id]) VALUES (24, 3, 2)
INSERT [dbo].[bands_venues] ([id], [venues_id], [bands_id]) VALUES (25, 3, 2)
INSERT [dbo].[bands_venues] ([id], [venues_id], [bands_id]) VALUES (26, 3, 2)
INSERT [dbo].[bands_venues] ([id], [venues_id], [bands_id]) VALUES (27, 3, 2)
INSERT [dbo].[bands_venues] ([id], [venues_id], [bands_id]) VALUES (28, 3, 2)
INSERT [dbo].[bands_venues] ([id], [venues_id], [bands_id]) VALUES (76, 5, 3)
INSERT [dbo].[bands_venues] ([id], [venues_id], [bands_id]) VALUES (58, 4, 3)
INSERT [dbo].[bands_venues] ([id], [venues_id], [bands_id]) VALUES (62, 4, 2)
INSERT [dbo].[bands_venues] ([id], [venues_id], [bands_id]) VALUES (60, 4, 2)
INSERT [dbo].[bands_venues] ([id], [venues_id], [bands_id]) VALUES (66, 4, 3)
INSERT [dbo].[bands_venues] ([id], [venues_id], [bands_id]) VALUES (64, 4, 2)
INSERT [dbo].[bands_venues] ([id], [venues_id], [bands_id]) VALUES (67, 3, 4)
INSERT [dbo].[bands_venues] ([id], [venues_id], [bands_id]) VALUES (68, 4, 2)
INSERT [dbo].[bands_venues] ([id], [venues_id], [bands_id]) VALUES (73, 4, 2)
INSERT [dbo].[bands_venues] ([id], [venues_id], [bands_id]) VALUES (71, 8, 2)
INSERT [dbo].[bands_venues] ([id], [venues_id], [bands_id]) VALUES (77, 3, 5)
INSERT [dbo].[bands_venues] ([id], [venues_id], [bands_id]) VALUES (75, 6, 2)
INSERT [dbo].[bands_venues] ([id], [venues_id], [bands_id]) VALUES (78, 5, 2)
INSERT [dbo].[bands_venues] ([id], [venues_id], [bands_id]) VALUES (42, 3, 6)
INSERT [dbo].[bands_venues] ([id], [venues_id], [bands_id]) VALUES (43, 3, 7)
SET IDENTITY_INSERT [dbo].[bands_venues] OFF
SET IDENTITY_INSERT [dbo].[venues] ON 

INSERT [dbo].[venues] ([name], [id]) VALUES (N'Key arena', 3)
SET IDENTITY_INSERT [dbo].[venues] OFF
