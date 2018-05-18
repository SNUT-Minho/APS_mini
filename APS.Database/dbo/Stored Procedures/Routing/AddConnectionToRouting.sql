CREATE PROCEDURE [dbo].[AddConnectionToRouting]
	@RoutingName NvarChar(25),
	@SourceWID Int,
	@TargetWID Int
AS
	Declare @RID Int 
	Select @RID = RID  From RoutingList Where RoutingName = @RoutingName

	Update Routing
	Set TargetWID = @TargetWID
	Where RID = @RID AND SourceWID = @SourceWID
GO

