CREATE PROCEDURE [dbo].[GetCompany]
	@CID Int
AS
	SELECT CompanyName
	From Company
	Where CID = @CID
Go
