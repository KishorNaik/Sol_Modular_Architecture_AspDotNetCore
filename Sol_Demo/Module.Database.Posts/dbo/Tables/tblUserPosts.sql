CREATE TABLE [dbo].[tblUserPosts] (
    [PostId]       NUMERIC (18)     IDENTITY (1, 1) NOT NULL,
    [PostIdentity] UNIQUEIDENTIFIER NULL,
    [Post]         VARCHAR (MAX)    NULL,
    [UserIdentity] UNIQUEIDENTIFIER NULL,
    PRIMARY KEY CLUSTERED ([PostId] ASC)
);

