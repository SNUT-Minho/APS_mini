CREATE PROCEDURE [dbo].[GetProductDescription]
	@ProductNumber int

AS
	SELECT [Description]
	From Product
	Where ProductNumber = @ProductNumber
Go
