CREATE TABLE [dbo].[WorkStation]
(
	[WId] INT NOT NULL Identity(1,1) PRIMARY KEY,
	[Title] NVarChar(20) Not Null,
	[Image] NVarChar(55) Null Default('DefaultImage'),
	[Description] NVarChar(255) Not Null,
	[SetupTime] float NOT NULL,
	[ProcessingTime] float NOT NULL,

	[ViewOrder] Int	Default(1),
	[GroupUID] Int Not Null Default(1), -- 작성 그룹 코드번호
	[WorkStationGroupID] Int Null Default(0)
)
