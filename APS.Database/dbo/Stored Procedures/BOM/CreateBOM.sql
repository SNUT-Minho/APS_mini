CREATE PROCEDURE [dbo].[CreateBOM]
	@ParentProductNumber Int,
	@ChildProductNumber Int,
	@Count Int
AS
	Insert Into BOM (ParentProductNumber, ChildProductNumber, [Count])
	Values(@ParentProductNumber, @ChildProductNumber, @Count)

	Update Product
	Set BOM = 1
	Where ProductNumber = @ParentProductNumber
Go
