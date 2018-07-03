CREATE PROCEDURE [dbo].[GetOrder]
	@OId Int
AS
	Select *
	From [Order]
	Where OId = @OId
Go