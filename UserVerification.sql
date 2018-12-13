USE [FS]
GO

/****** Object: Table [dbo].[UserVerification] Script Date: 12/13/2018 2:37:28 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[UserVerification];


GO
CREATE TABLE [dbo].[UserVerification] (
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [user_id] INT NOT NULL, 
    [facility_id] INT NOT NULL, 
    [verification_code] VARBINARY(MAX) NOT NULL ,
	CONSTRAINT FK_user_id FOREIGN KEY (user_id)     
    REFERENCES 
	[dbo].[Users] (user_id)  ,
	CONSTRAINT FK_facility_id FOREIGN KEY (facility_id)     
    REFERENCES 
	[dbo].[Facility] (facility_id)     
    ON DELETE CASCADE    
    ON UPDATE CASCADE    
);


