USE [FS]
GO

/****** Object: Table [dbo].[Facility] Script Date: 11/8/2018 7:33:46 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Facility];


GO
CREATE TABLE [dbo].[Facility] (
    [facility_id]      INT           IDENTITY (1, 1) NOT NULL,
    [name]             NVARCHAR (50) NOT NULL,
    [time_slot_length] INT           NOT NULL,
    [day_start_time]   TIME (7)      NOT NULL,
    [day_end_time]     TIME (7)      NOT NULL
);


