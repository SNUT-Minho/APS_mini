CREATE PROCEDURE [dbo].[DeleteWorkStation]
	@WId Int
AS
	Delete WorkStation
	Where WId = @WId
Go
