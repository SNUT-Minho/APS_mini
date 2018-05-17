CREATE PROCEDURE [dbo].[GetAllWorkStationList]
	@GroupUID Int
AS
	Select *
	From WorkStation
	Where GroupUID = @GroupUID
Go
