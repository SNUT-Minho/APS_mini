CREATE PROCEDURE [dbo].[UpdateNote]
	@OId Int,
	@Note NVarChar(25)
AS
	Update [Order]
	Set Note = @Note
	Where OId = @OId
Go
