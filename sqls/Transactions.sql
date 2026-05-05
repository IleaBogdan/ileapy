CREATE TABLE [dbo].[Transactions] (
    [Id]      INT             IDENTITY (1, 1) NOT NULL,
    [ID_From] INT             NOT NULL,
    [ID_To]   INT             NOT NULL,
    [Amount]  DECIMAL (18, 2) NOT NULL,
    [Message] NVARCHAR (255)     NOT NULL,
    [Date]    DATETIME        NOT NULL,
    [Type]    INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

