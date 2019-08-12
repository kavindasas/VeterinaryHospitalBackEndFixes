USE [VeteDB]
GO

/****** Object:  Table [dbo].[Staff]    Script Date: 28/07/2019 12:20:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Message](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Subject] [varchar](100) NOT NULL,
	[Message] [varchar](400) NOT NULL,
	CreatedDate	[DATETIME] default CURRENT_TIMESTAMP
)



