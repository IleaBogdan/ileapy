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

--- QUERYS:

-- GetTransactions
SELECT        t.Id, t.ID_From, t.ID_To, CASE WHEN t .Type = 1 THEN - t .Amount ELSE t .Amount END AS Amount, t.Message, t.Date, t.Type, u.Uname AS ToOwnerName
FROM            Transactions AS t LEFT OUTER JOIN
                         Cards AS c_to ON t.ID_To = c_to.Id LEFT OUTER JOIN
                         Users AS u ON c_to.OwnerID = u.Id
WHERE        (t.ID_From IN
(SELECT        Id
FROM            Cards AS c
WHERE        (OwnerID = @Id)));

-- InsertTransaction
INSERT INTO Transactions
                         (ID_From, ID_To, Amount, Message, Date, Type)
VALUES        (@ID_From,@ID_To,@Amount,@Message,@Date,@Type);