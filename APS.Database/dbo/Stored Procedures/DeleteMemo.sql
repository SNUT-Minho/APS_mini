CREATE PROCEDURE [dbo].[DeleteMemo]
	@Id Int
AS
	Delete Memos
	Where Id = @Id 
Go
