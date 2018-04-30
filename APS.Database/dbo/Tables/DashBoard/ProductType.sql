CREATE TABLE [dbo].[ProductType]
(
	[ProductTypeID] Int Identity(1,1) NOT NULL PRIMARY KEY, -- 완제품 1 / 반제품 2 / 원자재 3
	[ProductTypeName] NVarChar(25) NOT NULL,
	[GroupUID] INT NOT NULL Default(1)
)
