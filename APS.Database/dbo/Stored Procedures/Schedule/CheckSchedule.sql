CREATE PROCEDURE [dbo].[CheckSchedule]
	@GroupUID Int,
	@WId Int,
	@EndDate DateTime
AS
	Select Count(*)
	From [Schedule]
	Where WId =@WId and GroupUID = @GroupUID and StartDate < @EndDate and EndDate >= @EndDate
Go
