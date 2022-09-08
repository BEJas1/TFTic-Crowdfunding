﻿CREATE TABLE [dbo].[Registered]
(
	[Id] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [PK_Registered] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Registered_User] FOREIGN KEY ([Id]) REFERENCES [User]([Id]) ON DELETE CASCADE 
)