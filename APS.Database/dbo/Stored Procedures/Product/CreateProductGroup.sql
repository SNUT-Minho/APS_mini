CREATE PROCEDURE [dbo].[CreateProductGroup]
	@ProductGroupName NVarChar(25),
	@ParentProductGroupID INT = 0,
	@GroupUID INT = 1,

	@ProductGroupID INT Output
AS
	Insert Into ProductGroup(ProductGroupName,ParentProductGroupID,GroupUID)
	Values(@ProductGroupName,@ParentProductGroupID,@GroupUID)

	Select @ProductGroupID = SCOPE_IDENTITY()
GO
