CREATE PROCEDURE [dbo].[GetAllWorkStationList]
	@GroupUID Int
AS
	Select *
	From WorkStation
	Where GroupUID = @GroupUID
	Order by ViewOrder
Go
