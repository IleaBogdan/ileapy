CREATE TABLE [dbo].[Cards] (
    [Id]         INT             NOT NULL IDENTITY,
    [CardNumber] NVARCHAR (50)   NOT NULL,
    [CVC]        NCHAR (10)      NOT NULL,
    [ExpDate]    DATE            NOT NULL,
    [OwnerID]    INT             NOT NULL,
    [Amount]     DECIMAL (18, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

--- QUERYS:

-- AddNewCard:
INSERT INTO Cards
                         (CardNumber, CVC, ExpDate, OwnerID, Amount)
VALUES        (@CardNumber,@CVC,@ExpDate,@OwnerID,@Amount); 

-- GetCardsVIAId:
SELECT u.Id, u.Uname, STRING_AGG(CONCAT_WS('|', c.CardNumber, c.Id), ',') AS cards_details
FROM     Users AS u LEFT OUTER JOIN
                  Cards AS c ON u.Id = c.OwnerID
WHERE  (u.Id = @Id)
GROUP BY u.Id, u.Uname, u.Hpass, u.Mail, u.Phone, u.BDay, u.Address;

-- GetAmountById
SELECT        Amount
FROM            Cards
WHERE        (Id = @id);

-- GetCardIdBy
SELECT        Id
FROM            Cards
WHERE        (CardNumber = @cardNr) AND (CVC = @cvc) AND (ExpDate = @expDate);
