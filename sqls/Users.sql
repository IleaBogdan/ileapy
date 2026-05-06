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

--- QUERYS:

-- AddUser
INSERT INTO Users
                         (Uname, Hpass, Mail, Phone, BDay, Address)
VALUES        (@Uname,@Hpass,@Mail,@Phone,@BDay,@Address);   

-- CheckCredentials
SELECT        COUNT(*) AS cnt
FROM            Users
WHERE        (Uname = @uname) AND (Hpass = @hpass);

-- GetUserAndCardData
SELECT        u.Id, u.Uname, u.Hpass, u.Mail, u.Phone, u.BDay, u.Address, STRING_AGG(CONCAT_WS('|', c.CardNumber, c.Amount, c.ExpDate, c.CVC, c.Id), ',') AS cards_details
FROM            Users AS u LEFT OUTER JOIN
                         Cards AS c ON u.Id = c.OwnerID
WHERE        (u.Uname = @uname) AND (u.Hpass = @hpass)
GROUP BY u.Id, u.Uname, u.Hpass, u.Mail, u.Phone, u.BDay, u.Address;

-- GetIdsAndUnames
SELECT        Id, Uname
FROM            Users;

-- GetLeaderBoard
SELECT u.Id, u.Uname, COALESCE (m.message_count, 0) AS messages_sent, COALESCE (t_1.transaction_sum, 0) AS total_transactions_amount
FROM     Users AS u LEFT OUTER JOIN
(SELECT ID_From, COUNT(*) AS message_count
FROM      Messages
GROUP BY ID_From) AS m ON u.Id = m.ID_From LEFT OUTER JOIN
(SELECT c.OwnerID, SUM(t.Amount) AS transaction_sum
FROM      Transactions AS t INNER JOIN
                    Cards AS c ON t.ID_From = c.Id
WHERE   (t.Type = 1)
GROUP BY c.OwnerID) AS t_1 ON u.Id = t_1.OwnerID
ORDER BY messages_sent DESC, total_transactions_amount DESC;