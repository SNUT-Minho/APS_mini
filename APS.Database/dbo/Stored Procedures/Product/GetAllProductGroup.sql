CREATE PROCEDURE [dbo].[GetAllProductGroup]
	@ParentProductGroupID INT,
	@GroupUID INT
AS
			Select  ProductGroupID, ProductGroupName
			From	ProductGroup
			Where	GroupUID = @GroupUID AND ParentProductGroupID = @ParentProductGroupID
GO