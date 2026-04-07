CREATE TABLE [dbo].[Users] (
    [Id]      INT           NOT NULL IDENTITY,
    [Uname]   NVARCHAR (50) NOT NULL,
    [Hpass]   NVARCHAR (50) NOT NULL,
    [Mail]    NVARCHAR (50) NOT NULL,
    [Phone]   NCHAR (10)    NOT NULL,
    [BDay]    DATE          NOT NULL,
    [Address] NCHAR (10)    NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

