CREATE TABLE [dbo].[Administrator]
(
	[Id] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [PK_Administrator] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Administrator_User] FOREIGN KEY ([Id]) REFERENCES [User]([Id]) ON DELETE CASCADE
)
