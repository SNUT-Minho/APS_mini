CREATE TABLE [dbo].[Company]
(
	[CID] INT NOT NULL Identity(1,1) PRIMARY KEY,
	[CompanyName] NVarChar(25),
	[SecureCode] Int Not Null Default(0)
)
