CREATE TABLE [dbo].[RoutingList]
(
	[RID] INT NOT NULL Identity(1,1) PRIMARY KEY,
	[GroupUID] INT NOT NULL,
	[RoutingName] NVarChar(25) NOT NULL
)
