CREATE PROCEDURE [dbo].[GetAllRoutingMember]
	@RID Int
AS
	Select *
	From Routing
	Where RID = @RID
Go	

