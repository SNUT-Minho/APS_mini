CREATE PROCEDURE [dbo].[UpdateMemoOrder]
	@Id Int,
	@ViewOrder Int,
	@UID Int
AS
	Update Memos
	Set ViewOrder = @ViewOrder
	Where Id = @Id And UID = @UID 
Go
