CREATE PROCEDURE [dbo].[GetAllRoutingMember]
	@RID Int
AS
	Select *
	From RoutingNode
	Where RID = @RID
Go	

