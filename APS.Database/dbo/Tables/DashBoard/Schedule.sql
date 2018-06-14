CREATE TABLE [dbo].[Schedule]
(
	[SId] INT NOT NULL IdentitY(1,1) PRIMARY KEY,
	[GroupUID] INT NOT NULL,
	[OId] INT NOT NULL,
	[WId] INT NOT NULL,
	[StartDate] DateTime NOT NULL,
	[EndDate] DateTime NOT NULL
)
