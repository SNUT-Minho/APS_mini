-- 회원 정보 수정 프리시저 : UserRepository/UpdateUser
-----------------------------------------------------

CREATE PROCEDURE [dbo].[UpdateUser]
	@Email NVarChar(50),
	@UserID NVarChar(25),
	@Password NVarChar(50),
	@CompanyName  NVarChar(50),
	@UserName  NVarChar(50),
	@Industry   NVarChar(20)
AS
	Declare @UID Int
	Select @UID = UID From Domains Where UserID = @UserID

	IF @UID Is Not Null
	Begin
		Update Domains
		Set CompanyName = @CompanyName, UserName = @UserName, Industry = @Industry
		Where UserID = @UserID

		IF @Password IS Not Null
		Begin
			Update UserProfiles
			Set	Password = @Password
			Where UID = @UID
		End

		IF @Email IS Not Null
		Begin
			Update UserProfiles
			Set	Email = @Email
			Where UID = @UID
		End
	End

	Select @@ROWCOUNT -- 업데이트된 내용이 있으면 1을 반환
Go
