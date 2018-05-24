CREATE PROCEDURE [dbo].[UpdateRoutingInfo]
	@SourceWID Int,
	@RID INT,
	@ProcessingTime float,
	@SetupTime float,
	@Cycle Int
AS
	Update RoutingNode
	SET ProcessingTime =@ProcessingTime, SetupTime =@SetupTime, Cycle = @Cycle
	Where RID = @RID AND SourceWID = @SourceWID
Go
