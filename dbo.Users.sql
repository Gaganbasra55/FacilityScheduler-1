USE [FS]
GO

/****** Object: Table [dbo].[Users] Script Date: 11/8/2018 7:33:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Users];


GO
CREATE TABLE [dbo].[Users] (
    [user_id]        INT           IDENTITY (1, 1) NOT NULL,
    [firstname]      NVARCHAR (20) NOT NULL,
    [lastname]       NVARCHAR (20) NULL,
    [email]          NCHAR (50)    NOT NULL,
    [category]       NVARCHAR (10) NOT NULL,
    [password]       NVARCHAR (20) NOT NULL,
    [admin_verified] BIT           NULL
);


