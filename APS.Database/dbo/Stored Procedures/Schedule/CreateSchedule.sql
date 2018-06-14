CREATE PROCEDURE [dbo].[CreateSchedule]
	@OId Int,
	@GroupUID INT,
	@WId Int,
	@StartDate Datetime,
	@EndDate DateTime
AS

	Insert Schedule (OId, WId, GroupUID, StartDate, EndDate) Values (@OId, @WId, @GroupUID, @StartDate, @EndDate)
GO
  