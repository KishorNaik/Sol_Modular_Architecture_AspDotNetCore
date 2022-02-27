CREATE TABLE [dbo].[tblUsers] (
    [UserId]       NUMERIC (18)     IDENTITY (1, 1) NOT NULL,
    [UserIdentity] UNIQUEIDENTIFIER NULL,
    [FirstName]    VARCHAR (100)    NULL,
    [LastName]     VARCHAR (100)    NULL,
    [Email]        VARCHAR (100)    NULL,
    [HashPassword] VARCHAR (MAX)    NULL,
    [Salt] VARCHAR(MAX) NULL, 
    PRIMARY KEY CLUSTERED ([UserId] ASC)
);

