CREATE TABLE [dbo].[ProductGroup]
(
	[Id] INT NOT NULL Identity(1,1) PRIMARY KEY,
	[UID] INT NOT NULL,
	[GID] INT NOT NULL,
	[Group] NVarChar(25) NOT NULL
)
