CREATE TABLE [dbo].[ProductType]
(
	[Id] INT NOT NULL Identity(1,1) PRIMARY KEY,
	[TID] INT NOT NULL,
	[Type] NvarChar(10) NOT NULL
)
