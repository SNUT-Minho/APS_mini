CREATE PROCEDURE [dbo].[UpdateWorkStationOrder]
	@WId Int,
	@ViewOrder Int,
	@GroupUID Int
AS
	Update WorkStation
	Set ViewOrder = @ViewOrder
	Where WId = @WId And GroupUID = @GroupUID 
Go
