CREATE PROCEDURE [dbo].[GetAllRoutingLst]
	@GroupUID Int
AS
	Select *
	From RoutingList
	Where GroupUID = @GroupUID
GO