CREATE PROCEDURE [dbo].[DeleteBOM]
	@ParentProductNumber Int
AS
	Delete BOM
	Where ParentProductNumber = @ParentProductNumber
Go
