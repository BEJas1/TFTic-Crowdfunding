CREATE PROCEDURE [dbo].[SP_User_Login]
	@email nvarchar(386),
	@password nvarchar(32)
AS
	SELECT 
        U.Id,
        U.Email,
        U.FirstName,
        U.LastName,
        U.Active,
        '*' AS [Password],
        R.Id AS [UserId],
        A.Id AS [AdminId],
        C.Id AS [CompanyId]
    FROM [User] U 
        LEFT OUTER JOIN [Administrator] A ON U.Id = A.Id 
        LEFT OUTER JOIN [Registered] R ON U.Id = R.Id 
        LEFT OUTER JOIN [Company] C ON U.Id = C.Id
    WHERE 
        U.Email = @email 
        AND U.Password = HASHBYTES('SHA2_512', dbo.SF_GetSalt() + @password) 
        AND U.Active = 1
RETURN 0
