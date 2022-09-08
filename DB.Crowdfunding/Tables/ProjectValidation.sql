CREATE TABLE [dbo].[ProjectValidation]
(
	[Id] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(), 
    [AdminId] UNIQUEIDENTIFIER NOT NULL, 
    [ProjectId] UNIQUEIDENTIFIER NOT NULL, 
    [DateValidation] DATETIME2(0) NOT NULL, 
    [DateLastEdit] DATETIME2(0) NOT NULL, 
    [Valid] BIT NOT NULL, 
    [Comment] NVARCHAR(500) NULL, 
    [Active] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [PK_ProjectValidation] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_ProjectValidation_Admin] FOREIGN KEY ([AdminId]) REFERENCES [Administrator]([Id]), 
    CONSTRAINT [FK_ProjectValidation_Project] FOREIGN KEY ([ProjectId]) REFERENCES [Project]([Id]) 
)
