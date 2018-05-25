CREATE PROCEDURE [dbo].[UpdateRouting]
	@GroupUID Int, -- 소속 Group
	@ProductNumber Int, -- Product Number
	@RID Int  -- Routing Number
AS
	Update Product
	Set	RoutingNumber = @RID
	Where ProductNumber = @ProductNumber And GroupUID = @GroupUID
Go