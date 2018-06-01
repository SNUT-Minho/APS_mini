CREATE PROCEDURE [dbo].[CreateWorkStationGroup]
	@GroupUID Int,
	@WorkStationGroupTitle NVarChar(15)
AS
	Insert Into WorkStationGroupList(GroupUID, WorkStationGroupTitle) Values(@GroupUID, @WorkStationGroupTitle)
	
	Select *
	From WorkStationGroupList
	Where WorkStationGroupTitle = @WorkStationGroupTitle
Go
