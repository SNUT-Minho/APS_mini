CREATE PROCEDURE [dbo].[DeleteBOM]
	@ParentProductNumber Int
AS
	Delete BOM
	Where ParentProductNumber = @ParentProductNumber

	Update Product
	Set BOM = 0
	Where ProductNumber = @ParentProductNumber
Go
