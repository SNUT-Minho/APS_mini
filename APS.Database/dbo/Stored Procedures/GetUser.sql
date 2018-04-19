CREATE PROCEDURE [dbo].[GetUser]
	@UserID NVarChar(25)
AS
	Select * From Users Where UserID = @UserID
Go
