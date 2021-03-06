USE [band_tracker_test]
GO
/****** Object:  Table [dbo].[bands]    Script Date: 7/24/2016 8:26:39 PM ******/
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
/****** Object:  Table [dbo].[bands_venues]    Script Date: 7/24/2016 8:26:40 PM ******/
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
/****** Object:  Table [dbo].[venues]    Script Date: 7/24/2016 8:26:40 PM ******/
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
