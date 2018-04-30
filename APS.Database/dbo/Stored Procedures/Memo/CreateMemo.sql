CREATE PROCEDURE [dbo].[CreateMemo]
	@UID Int,
	@GroupUID Int,

	@Title NVarChar(10),
	@Description NVarChar(255),

	@Id Int Output,
	@CreatedTime DateTime Output

AS
	Insert Into Memos (UID, GroupUID, Title, Description) Values (@UID, @GroupUID, @Title, @Description)

	Select @Id  = SCOPE_IDENTITY()

	Select @CreatedTime = CreatedTime
	From  Memos
	Where Id = @Id
Go
