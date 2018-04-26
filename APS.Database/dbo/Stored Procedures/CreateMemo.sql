CREATE PROCEDURE [dbo].[CreateMemo]
	@UID Int,
	
	@Title NVarChar(10),
	@Description NVarChar(255),

	@Id Int Output,
	@CreatedTime DateTime Output

AS
	Insert Into Memos (UID, Title, Description) Values (@UID, @Title,@Description)

	Select @Id  = SCOPE_IDENTITY()

	Select @CreatedTime = CreatedTime
	From  Memos
	Where Id = @Id
Go
