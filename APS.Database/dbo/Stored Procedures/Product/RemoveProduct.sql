CREATE PROCEDURE [dbo].[RemoveProduct]
	@ProductNumber Int
AS
	Delete Product
	Where ProductNumber = @ProductNumber

	Delete BOM
	Where ParentProductNumber = @ProductNumber
Go
