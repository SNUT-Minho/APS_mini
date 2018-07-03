CREATE PROCEDURE [dbo].[GetAllProductLstByOfOrder]
	@ParentProductNumber int
	
AS
	Select *
	From BOM
	Where ParentProductNumber = @ParentProductNumber
GO
