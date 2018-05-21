CREATE PROCEDURE [dbo].[AddConnectionToRouting]
	@RoutingName NvarChar(25),
	@SourceWID Int,
	@TargetWID Int
AS
	Declare @RID Int 
	Select @RID = RID  From RoutingList Where RoutingName = @RoutingName

	Insert Into RoutingConnection(RID, SourceWID, TargetWID) values(@RID, @SourceWID, @TargetWID)
GO

