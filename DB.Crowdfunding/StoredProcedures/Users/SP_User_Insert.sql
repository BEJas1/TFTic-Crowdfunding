CREATE PROCEDURE [dbo].[SP_User_Insert]
	@id uniqueidentifier,
	@email nvarchar(386),
	@firstname nvarchar(50),
	@lastname nvarchar(50),
	@password nvarchar(32)
AS
	DECLARE @salt uniqueidentifier = NEWID()

	INSERT INTO [User] ([Id], [Email], [FirstName], [LastName], [Password])
	OUTPUT inserted.Id
	VALUES (@id, @email, @firstname, @lastname, HASHBYTES('SHA2_512', dbo.SF_GetSalt() + @password))
RETURN 0
