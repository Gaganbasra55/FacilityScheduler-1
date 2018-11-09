USE [FS]
GO

/****** Object: Table [dbo].[Booking] Script Date: 11/8/2018 7:33:35 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Booking];


GO
CREATE TABLE [dbo].[Booking] (
    [booking_id]  INT      IDENTITY (1, 1) NOT NULL,
    [facility_id] INT      NOT NULL,
    [user_id]     INT      NOT NULL,
    [date]        DATE     NOT NULL,
    [time_start]  TIME (7) NOT NULL,
    [time_slots]  INT      NOT NULL
);


