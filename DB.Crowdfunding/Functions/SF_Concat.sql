CREATE FUNCTION [dbo].[SF_Concat]
(
	@password nvarchar(32),
	@salt uniqueidentifier
)
RETURNS NVARCHAR(68)
AS
BEGIN
	RETURN CONCAT(@password, @salt)
END
