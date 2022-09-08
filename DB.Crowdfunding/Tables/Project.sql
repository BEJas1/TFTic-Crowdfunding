CREATE TABLE [dbo].[Project]
(
	[Id] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(), 
    [CompanyId] UNIQUEIDENTIFIER NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [CumulativeTier] BIT NOT NULL, 
    [VideoUrl] NVARCHAR(256) NULL, 
    [Ceiling] DECIMAL(15, 2) NOT NULL, 
    [Iban] NVARCHAR(32) NOT NULL, 
    [DateCreated] DATETIME2(0) NOT NULL, 
    [DateLastEdit] DATETIME2(0) NOT NULL, 
    [DatePublication] DATETIME2(0) NULL, 
    [Published] BIT NOT NULL, 
    [Active] BIT NOT NULL
    CONSTRAINT [PK_Project] PRIMARY KEY ([Id]) DEFAULT 1, 
    CONSTRAINT [FK_Project_Company] FOREIGN KEY ([CompanyId]) REFERENCES [Company]([Id]), 
    CONSTRAINT [CK_Project_Ceiling] CHECK ([Ceiling] > 0) 
)
