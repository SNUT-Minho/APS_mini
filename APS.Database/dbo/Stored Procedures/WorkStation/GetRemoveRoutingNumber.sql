CREATE PROCEDURE [dbo].[GetRemoveRoutingNumber]
	@WID Int
AS
	Select RID
	From RoutingNode
	Where SourceWID = @WID
Go
