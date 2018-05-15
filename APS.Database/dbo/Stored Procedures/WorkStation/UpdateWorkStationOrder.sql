CREATE PROCEDURE [dbo].[UpdateWorkStationOrder]
	@Id Int,
	@ViewOrder Int,
	@GroupUID Int
AS
	Update WorkStation
	Set ViewOrder = @ViewOrder
	Where Id = @Id And GroupUID = @GroupUID 
Go
