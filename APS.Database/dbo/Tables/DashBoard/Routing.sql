CREATE TABLE [dbo].[Routing]
(
	[Id] INT NOT NULL Identity(1,1) PRIMARY KEY,
	[RID] NVarChar(25) NOT NULL,
	[SourceWID] INT NOT NULL,
	[TargetWID] INT NULL,
	[X] INT NOT NULL,
	[Y] INT NOT NULL
)
