CREATE TABLE [dbo].[Cards] (
    [Id]         INT             NOT NULL IDENTITY,
    [CardNumber] NVARCHAR (50)   NOT NULL,
    [CVC]        NCHAR (10)      NOT NULL,
    [ExpDate]    DATE            NOT NULL,
    [OwnerID]    INT             NOT NULL,
    [Amount]     DECIMAL (18, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

