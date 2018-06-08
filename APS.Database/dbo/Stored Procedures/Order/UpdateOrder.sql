CREATE PROCEDURE [dbo].[UpdateOrder]
	@GroupUID INT,
	@OId INT,
	
	@LotSize INT,
	@StartDate NVarChar(25),
	@EndDate NVarChar(25),
	@CriticalRatio INT,
	@UserName NVarChar(25),
	@AllowWorkStationGroup INT

AS

	Update [Order]
	Set LotSize = @LotSize , StartDate = @StartDate , EndDate = @EndDate , CriticalRatio = @CriticalRatio , UserName = @UserName , AllowWorkStationGroup = @AllowWorkStationGroup
	Where OId = @OId
	
Go