
CREATE TABLE [dbo].[Users] (
    [user_id]        INT           IDENTITY (1, 1) NOT NULL,
    [firstname]      NVARCHAR (20) NOT NULL,
    [lastname]       NVARCHAR (20) NULL,
    [email]          NCHAR (50)    NOT NULL,
    [category]       NVARCHAR (10) NOT NULL,
    [password]       NVARCHAR (20) NOT NULL,
    [admin_verified] BIT           NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([user_id] ASC)
);

CREATE TABLE [dbo].[Facility] (
    [facility_id]      INT           IDENTITY (1, 1) NOT NULL,
    [name]             NVARCHAR (50) NOT NULL,
    [time_slot_length] INT           NOT NULL,
    [day_start_time]   TIME (7)      NOT NULL,
    [day_end_time]     TIME (7)      NOT NULL,
    CONSTRAINT [PK_Facility] PRIMARY KEY CLUSTERED ([facility_id] ASC)
);

CREATE TABLE [dbo].[Booking] (
    [booking_id]  INT      IDENTITY (1, 1) NOT NULL,
    [facility_id] INT      NOT NULL,
    [user_id]     INT      NOT NULL,
    [date]        DATE     NOT NULL,
    [time_start]  TIME (7) NOT NULL,
    [time_slots]  INT      NOT NULL,
    CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED ([booking_id] ASC)
);

CREATE TABLE [dbo].[UserVerification] (
    [Id]                INT           IDENTITY (1, 1) NOT NULL,
    [user_id]           INT           NOT NULL,
    [booking_id]        INT           NOT NULL,
    [verification_code] NCHAR (10)    NULL,
    [status]            NVARCHAR (10) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[FacilityAccess] (
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,     
    [facility_id] INT NOT NULL, 
	[role] NVARCHAR(10) NOT NULL, 
    [access_granted] BIT NOT NULL	
);

--SELECT f.[facility_id], [name], access_granted FROM [Facility] f, [FacilityAccess] fa WHERE f.facility_id = fa.facility_id AND RTRIM(role)  = RTRIM('Student');


--ALTER TABLE UserVerification ALTER COLUMN verification_code nchar(10);
--ALTER TABLE UserVerification DROP CONSTRAINT FK_booking_id;
--ALTER TABLE UserVerification DROP CONSTRAINT FK_user_id;