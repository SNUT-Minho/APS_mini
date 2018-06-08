CREATE TABLE [dbo].[Order]
(
	[OId] INT Identity(1,1) NOT NULL PRIMARY KEY,
	[GroupUID] INT NOT NULL,
	[ProductNumber] INT NOT NULL,
	[RoutingName] NVarChar(25) NOT NULL,
	[Description] NVarChar(25) NOT NULL,
	[LotSize] INT NOT NULL,
	[StartDate] DateTime NOT NULL,
	[EndDate] DateTime NOT NULL,
	[CriticalRatio] INT NULL Default(0),
	[UserName] NVarChar(25) NOT NULL,
	[AllowWorkStationGroup] Int NULL Default(0),
	[Note] NVarChar(25) NULL Default('')-- 0: 불허 1: 허용
)
