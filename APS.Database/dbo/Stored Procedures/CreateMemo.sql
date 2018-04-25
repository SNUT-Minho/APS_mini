CREATE PROCEDURE [dbo].[CreateMemo]
	@Title NVarChar(10),
	@Description NVarChar(255),
	@Id Int Output,
	@CreatedTime DateTime Output
AS
	Insert Into Memos (Title, Description) Values (@Title,@Description)

	Select @Id  = SCOPE_IDENTITY()

	Select @CreatedTime = CreatedTime
	From  Memos
	Where Id = @Id
Go
