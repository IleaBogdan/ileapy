CREATE TABLE [dbo].[Messages] (
    [Id]      INT        IDENTITY (1, 1) NOT NULL,
    [ID_From] INT        NOT NULL,
    [ID_To]   INT        NOT NULL,
    [Message] NVARCHAR (255) NOT NULL,
    [Date]    DATETIME   NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

