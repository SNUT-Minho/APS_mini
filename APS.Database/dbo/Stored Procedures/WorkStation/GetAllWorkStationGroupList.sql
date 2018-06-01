CREATE PROCEDURE [dbo].[GetAllWorkStationGroupList]
	@GroupUID Int
AS
	Select *
	From WorkStationGroupList
	Where GroupUID = @GroupUID
Go
