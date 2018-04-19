CREATE PROCEDURE [dbo].[DeleteUser]
	@UserID NVarChar(25),
	@Password NVarChar(50)
AS
	Declare @UID Int
	Declare @Result Int

	Select @UID = UID 
	From Domains
	Where UserID = @UserID 

	IF @UID Is Not Null
	Begin
		Select @Result = Count(*)
		From UserProfiles
		Where Password = @Password And UID = @UID
	End

	IF @Result Is Not Null
	Begin
		Delete Domains Where UID = @UID And Type = 'User'
		Delete UserProfiles Where UID = @UID
		Delete Membership Where UserUID = @UID
	End

	Select @@ROWCOUNT  -- 업데이트 된 내용이 있으면 1을 반환
GO
