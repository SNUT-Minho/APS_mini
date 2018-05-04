CREATE PROCEDURE [dbo].[GetProductByProductNumber]
	@ProductNumber Int
AS
	SELECT *
	From Product
	Where ProductNumber = @ProductNumber
Go