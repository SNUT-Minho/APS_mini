CREATE PROCEDURE [dbo].[CreateRouting]
	@GroupUID Int,
	@RoutingName NVarChar(25),
	@SourceWID Int,
	@X Int,
	@Y Int,
	@ProcessingTime Int,
	@SetupTime Int,
	@Cycle Int
AS
	Declare @Check Int
	Declare @RID Int

	--IF @SourceWID > 0
	--	BEGIN
	--		Select @ProcessingTime = ProcessingTime, @SetupTime = SetupTime
	--		From WorkStation
	--		Where WId = @SourceWID
	--	END

	

	Select @Check = COUNT(*)
	From RoutingList
	Where RoutingName = @RoutingName

	IF @Check > 0
		BEGIN
			Select @RID = RID
			From RoutingList
			Where RoutingName = @RoutingName

			Insert Into RoutingNode(RID, SourceWID, X, Y, ProcessingTime, SetupTime, Cycle) Values (@RID, @SourceWID, @X, @Y, @ProcessingTime, @SetupTime, @Cycle)
		END
	ELSE
		BEGIN
			Insert Into RoutingList(RoutingName,GroupUID) values(@RoutingName, @GroupUID)
			SET @RID = SCOPE_IDENTITY()
			Insert Into RoutingNode(RID, SourceWID, X, Y, ProcessingTime, SetupTime, Cycle) Values (@RID, @SourceWID, @X, @Y, @ProcessingTime, @SetupTime, @Cycle)
		END
GO
