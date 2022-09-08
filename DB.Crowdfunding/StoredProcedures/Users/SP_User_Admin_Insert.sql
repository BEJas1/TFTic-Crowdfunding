CREATE PROCEDURE [dbo].[SP_User_Admin_Insert]
	@email nvarchar(386),
	@firstname nvarchar(50),
	@lastname nvarchar(50),
	@password nvarchar(32)
AS
	DECLARE @id uniqueidentifier = NEWID()

	EXEC SP_User_Insert @id, @email, @firstname, @lastname, @password

	INSERT INTO [Administrator] VALUES (@id)
RETURN 0
