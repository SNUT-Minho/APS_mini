CREATE PROCEDURE [dbo].[CreateWorkStation]
	@Title NVarChar(20),
	@Image NVarChar(50),
	@Description NVarChar(255),
	@SetupTime INT,
	@ProcessingTime INT,
	@GroupUID INT,
	@WorkStationGroupID Int,
	@WId INT Output
AS
	Declare @ViewOrder Int = 1

	Select @ViewOrder = Max(ViewOrder)
	From WorkStation

	IF @ViewOrder Is Null
	Set @ViewOrder = 0

	Insert Into WorkStation(Title, Image, Description, SetupTime, ProcessingTime, GroupUID, ViewOrder, WorkStationGroupID) Values(@Title, @Image, @Description, @SetupTime, @ProcessingTime, @GroupUID, (@ViewOrder+1), @WorkStationGroupID)
	Select @WId = SCOPE_IDENTITY()
GO
