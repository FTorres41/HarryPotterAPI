USE [dbHarryPotter]
GO

/****** Object:  Table [dbo].[Character]    Script Date: 14/08/2020 11:26:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Character](
	[id] [uniqueidentifier] NOT NULL,
	[name] [nvarchar](250) NOT NULL,
	[role] [nvarchar](50) NULL,
	[school] [nvarchar](250) NULL,
	[house] [nvarchar](50) NULL,
	[patronus] [nvarchar](50) NULL
) ON [PRIMARY]
GO


