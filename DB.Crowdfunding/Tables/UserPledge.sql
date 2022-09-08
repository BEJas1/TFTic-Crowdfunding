CREATE TABLE [dbo].[UserPledge]
(
	[Id] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(), 
    [UserId] UNIQUEIDENTIFIER NOT NULL, 
    [ProjectId] UNIQUEIDENTIFIER NOT NULL, 
    [Amount] DECIMAL(15, 2) NOT NULL, 
    [PledgeDate] DATETIME2(0) NOT NULL, 
    CONSTRAINT [PK_UserPledge] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_UserPledge_UserId] FOREIGN KEY ([UserId]) REFERENCES [Registered]([Id]), 
    CONSTRAINT [FK_UserPledge_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [Project]([Id]), 
    CONSTRAINT [CK_UserPledge_Amount] CHECK ([Amount] > 0) 
)
