CREATE PROCEDURE [dbo].[CreateRouting]
	@RoutingName NVarChar(25),
	@SourceWID Int = 0,
	@X Int,
	@Y Int
AS
	Declare @Check Int
	Declare @RID Int
	
	Select @Check = COUNT(*)
	From RoutingList
	Where RoutingName = @RoutingName

	IF @Check > 0
		BEGIN
			Select @RID = RID
			From RoutingList
			Where RoutingName = @RoutingName

			Insert Into Routing(RID, SourceWID, X, Y) Values (@RID, @SourceWID, @X, @Y)
		END
	ELSE
		BEGIN
			Insert Into RoutingList(RoutingName) values(@RoutingName)
			SET @RID = SCOPE_IDENTITY()
			Insert Into Routing(RID, SourceWID, X, Y) Values (@RID, @SourceWID, @X, @Y)
		END
GO
