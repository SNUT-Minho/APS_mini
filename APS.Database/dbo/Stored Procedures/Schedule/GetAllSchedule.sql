CREATE PROCEDURE [dbo].[GetAllSchedule]
	@GroupUID Int,
	@StartDate DateTime,
	@EndDate DateTime
AS
	Select *
	From [Schedule]
	Where GroupUID = @GroupUID and StartDate >= @StartDate and EndDate <= @EndDate
	Order By OId
Go
