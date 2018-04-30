CREATE PROCEDURE [dbo].[GetSecureCode]
	@CID Int
AS
	SELECT SecureCode
	From Company
	Where CID = @CID
Go
