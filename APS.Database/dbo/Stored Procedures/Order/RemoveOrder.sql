CREATE PROCEDURE [dbo].[RemoveOrder]
	@OId Int
AS
	Delete [Order]
	Where OId = @OId
Go