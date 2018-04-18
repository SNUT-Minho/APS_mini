CREATE PROCEDURE [dbo].[CheckUserID]
	@UserID NVarChar(25),
	@Result Int Output
AS
	Select @Result = Count(*) From Domains Where UserID = @UserID
GO
  