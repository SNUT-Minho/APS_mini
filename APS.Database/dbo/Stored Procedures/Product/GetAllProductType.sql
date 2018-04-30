CREATE PROCEDURE [dbo].[GetAllProductType]
	@GroupUID INT
AS
	Select  ProductTypeID,  ProductTypeName
	From	ProductType
	Where	GroupUID = @GroupUID
GO