CREATE TABLE [dbo].[Messages] (
    [Id]      INT        IDENTITY (1, 1) NOT NULL,
    [ID_From] INT        NOT NULL,
    [ID_To]   INT        NOT NULL,
    [Message] NVARCHAR (255) NOT NULL,
    [Date]    DATETIME   NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

--- QUERYS:

-- GetMessages
SELECT        m.Id, m.ID_From, m.ID_To, m.Message, m.Date, CASE WHEN m.ID_From = @UserId THEN u_to.Uname ELSE u_from.Uname END AS OtherUserUname
FROM            Messages AS m LEFT OUTER JOIN
                         Users AS u_from ON m.ID_From = u_from.Id LEFT OUTER JOIN
                         Users AS u_to ON m.ID_To = u_to.Id
WHERE        (m.ID_From = @UserId) OR (m.ID_To = @UserId);
-- GetMessages with HAVING
SELECT        m.Id, m.ID_From, m.ID_To, m.Message, m.Date, CASE WHEN m.ID_From = @UserId THEN u_to.Uname ELSE u_from.Uname END AS OtherUserUname
FROM            Messages AS m LEFT OUTER JOIN
                         Users AS u_from ON m.ID_From = u_from.Id LEFT OUTER JOIN
                         Users AS u_to ON m.ID_To = u_to.Id
WHERE        (m.ID_From = @UserId) OR
                         (m.ID_To = @UserId)
GROUP BY m.Id, m.ID_From, m.ID_To, m.Message, m.Date, u_from.Uname, u_to.Uname
HAVING        (COUNT(CASE WHEN m.ID_From = @UserId THEN m.ID_To ELSE m.ID_From END) >= 1);

-- InsertQuery
INSERT INTO Messages
                         (ID_From, ID_To, Message, Date)
VALUES        (@ID_From,@ID_To,@Message,@Date); 
SELECT Id, ID_From, ID_To, Message, Date FROM Messages WHERE (Id = SCOPE_IDENTITY());