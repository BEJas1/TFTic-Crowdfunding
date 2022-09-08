CREATE TABLE [dbo].[ProjectTier]
(
	[Id] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(), 
    [ProjectId] UNIQUEIDENTIFIER NOT NULL, 
    [Amount] DECIMAL(15, 2) NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(500) NOT NULL, 
    CONSTRAINT [PK_ProjectTier] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_ProjectTier_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [Project]([Id]), 
    CONSTRAINT [CK_ProjectTier_Amount] CHECK ([Amount] > 0) 
)
