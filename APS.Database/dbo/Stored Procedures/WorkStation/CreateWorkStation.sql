CREATE PROCEDURE [dbo].[CreateWorkStation]
	@Title NVarChar(20),
	@Image NVarChar(50),
	@Description NVarChar(255),
	@SetupTime INT,
	@ProcessingTime INT,
	@GroupUID INT,
	@WId INT Output
AS
	Declare @ViewOrder Int = 1

	Select @ViewOrder = Max(ViewOrder)
	From WorkStation

	IF @ViewOrder Is Null
	Set @ViewOrder = 0

	Insert Into WorkStation(Title, Image, Description, SetupTime, ProcessingTime, GroupUID, ViewOrder) Values(@Title, @Image, @Description, @SetupTime, @ProcessingTime, @GroupUID, (@ViewOrder+1))
	Select @WId = SCOPE_IDENTITY()
GO
