CREATE FUNCTION [dbo].[SF_Hash]
(
	@saltedpassword nvarchar(68)
)
RETURNS VARBINARY(64)
AS
BEGIN
	RETURN HASHBYTES('SHA2_512', @saltedpassword)
END
