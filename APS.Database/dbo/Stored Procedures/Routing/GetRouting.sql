CREATE PROCEDURE [dbo].[GetRouting]
	@ProductNumber Int,
	@GroupUID Int
AS
	Declare @RID Int 

	Select @RID = RoutingNumber
	From Product
	Where ProductNumber = @ProductNumber and GroupUID = @GroupUID

	Select *
	From RoutingList
	Where RID = @RID
	
Go
