CREATE PROCEDURE [dbo].[GetAllMemos]
	@GroupUID Int
AS
	Select *
	From Memos
	Where GroupUID = @GroupUID
	Order by ViewOrder;
Go
