CREATE PROCEDURE [dbo].[GetAllCompany]
	
AS
	SELECT CompanyName, CID
	From Company
	Where CID <> 1 
	Order By CID
Go
