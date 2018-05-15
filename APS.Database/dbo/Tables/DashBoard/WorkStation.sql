CREATE TABLE [dbo].[WorkStation]
(
	[Id] INT NOT NULL Identity(1,1) PRIMARY KEY,
	[Title] NVarChar(20) Not Null,
	[Image] NVarChar(55) Null Default('DefaultImage'),
	[Description] NVarChar(255) Not Null,
	[SetupTime] INT NOT NULL,
	[ProcessingTime] INT NOT NULL,

	[ViewOrder] Int	Default(1),
	[GroupUID] Int Not Null Default(1) -- 작성 그룹 코드번호
)
