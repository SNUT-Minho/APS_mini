CREATE PROCEDURE [dbo].[GetAllMemos]
	@UID Int
AS
	Select *
	From Memos
	Where UID = @UID
	Order by ViewOrder;
Go
