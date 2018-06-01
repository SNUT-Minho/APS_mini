CREATE PROCEDURE [dbo].[RemoveRoutingInfo]
	@RID Int
AS
	Delete RoutingNode
	Where RID = @RID

	Delete RoutingList
	Where RID = @RID

	Delete RoutingConnection
	Where RID = @RID

	Update Product
	Set RoutingNumber = null
	Where RoutingNumber = @RID
Go
