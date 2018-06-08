CREATE PROCEDURE [dbo].[GetAllOrderLst]
	@GroupUID Int,
	@StartDate DateTime,
	@EndDate DateTime
AS
	Select *
	From [Order]
	Where GroupUID = @GroupUID and StartDate >= @StartDate and EndDate <= @EndDate
	Order By OId
Go