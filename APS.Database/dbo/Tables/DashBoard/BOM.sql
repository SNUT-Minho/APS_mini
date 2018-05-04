CREATE TABLE [dbo].[BOM]
(
	[BOM_ID] INT NOT NULL Identity(1,1) PRIMARY KEY,
	[ParentProductNumber] INT NOT NULL,
	[ChildProductNumber] INT NOT NULL,
	[Count] INT NOT NULL
)
