CREATE PROCEDURE [dbo].[GetAllRoutingConnection]
	@RID Int
AS
	Select *
	From RoutingConnection
	Where RID = @RID
Go
