CREATE PROCEDURE [dbo].[GetAllWorkStation]
	@GroupUID Int,
	@PageCount Int
AS
	SELECT *
	From WorkStation 
	Where GroupUID = @GroupUID
	Order by ViewOrder
Go
