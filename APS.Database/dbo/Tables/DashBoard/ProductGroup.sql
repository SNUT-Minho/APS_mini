CREATE TABLE [dbo].[ProductGroup]
(
	[ProductGroupID] INT NOT NULL Identity(1,1) PRIMARY KEY,
	[ProductGroupName] NVarChar(25) NOT NULL,
	[ParentProductGroupID] INT NULL Default(0),
	[GroupUID] INT NOT NULL Default(1)
)
  