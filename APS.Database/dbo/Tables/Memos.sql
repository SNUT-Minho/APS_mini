CREATE TABLE [dbo].[Memos]
(
	[Id] INT NOT NULL Identity(1,1) PRIMARY KEY,
	[UID] INT NOT NULL Default(1),
	[Title] NVarChar(10) Not Null,
	[CreatedTime] DateTime Default(GetDate()),
	[Description] NVarChar(255) Not Null,
	[ViewOrder] Int	Default(1)
)
