CREATE PROCEDURE [dbo].[GetAllBOM]
	@ParentProductNumber INT

AS
	Select *
	From BOM
	Where ParentProductNumber = @ParentProductNumber
	Order by ChildProductNumber
GO
