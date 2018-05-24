CREATE PROCEDURE [dbo].[DeleteRouting]
	@RID INT
AS
	Delete RoutingList
	Where RID = @RID

	Delete RoutingNode
	Where RID = @RID

	Delete RoutingConnection
	Where RID = @RID
GO