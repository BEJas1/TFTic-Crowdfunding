CREATE TABLE [dbo].[Company]
(
	[Id] UNIQUEIDENTIFIER NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Tva] NCHAR(12) NOT NULL, 
    [Address] NVARCHAR(100) NOT NULL, 
    [Number] NVARCHAR(10) NOT NULL, 
    [ZipCode] NVARCHAR(10) NOT NULL, 
    [City] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_Company] PRIMARY KEY ([Id]), 
    CONSTRAINT [UK_Company_Tva] UNIQUE ([Tva]), 
    CONSTRAINT [FK_Company_Registered] FOREIGN KEY ([Id]) REFERENCES [Registered]([Id]) ON DELETE CASCADE
)
