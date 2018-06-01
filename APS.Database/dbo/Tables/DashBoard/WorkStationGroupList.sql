CREATE TABLE [dbo].[WorkStationGroupList]
(
	[WorkStationGroupID] Int Identity(1,1) Not Null, -- WorkStation GroupID
	[WorkStationGroupTitle] NvarChar(15) Not Null,
	[GroupUID] Int Not Null
)
