CREATE PROCEDURE [dbo].[GetAllProductGroup]
	@GroupUID INT
AS
	Select  ProductGroupID, ProductGroupName
	From	ProductGroup
	Where	GroupUID = @GroupUID

GO