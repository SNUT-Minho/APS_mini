CREATE TABLE [dbo].[LoginHistories]
(
	[ID] INT NOT NULL Identity(1,1) PRIMARY KEY,
	[UID] INT NOT NULL,
	[UserID] NVarChar(25) NOT NULL,
	[GroupUID] NVarChar(50) NOT NULL,
	[UserName] NVarChar(25) NOT NULL,
	[LoginDate] DateTime NOT NUll,					
	[LoginIP] NvarChar(16) NOT NUll
)
