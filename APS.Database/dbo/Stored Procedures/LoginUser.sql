-- [!] 로그인 저장 프로시저 :  UserRepository/LoginUser
-------------------------------------------------

CREATE PROCEDURE [dbo].[LoginUser]
	@UserID NVarChar(25),
	@Password NVarChar(50),
	@LastLoginIP NVarChar(16),				-- IP주소(입력)
	@OriginLastLoginIP NVarChar(16) Output,		-- 이전 IP주소 (반환형 값)
	@OriginLastLoginDate DateTime Output	-- 마지막 로그인 날짜 (반환형 값)
AS
BEGIN
	Set @OriginLastLoginIP = ''
	Set @OriginLastLoginDate = NULL

	Declare @Result Int
	Declare @UID Int
	Declare @GroupUID Int
	Declare @UserName	NVarChar(25)

	Select @Result = Count(*), @UID = UID, @GroupUID = GroupUID, @UserName = UserName
	From Users
	Where UserID = @UserID And Password = @Password
	Group By UID, GroupUID, UserName    -- Group by 안하게되면 @UID, @CompanyName, @UserName이 중복이 된다.
  
	-- 로그인 History 저장
	IF @Result >0
	BEGIN
		SELECT 
			@OriginLastLoginDate = LastLoginDate,
			@OriginLastLoginIP = LastLoginIP
		FROM Users
		WHERE UID = @UID

		IF @OriginLastLoginDate Is Null
			Set @OriginLastLoginDate = GetDate()
		
		-- UserProfiles 테이블에 IP/DATE/COUNT 등을 업데이트
		UPDATE UserProfiles
		SET 
			LastLoginDate = GetDate(),
			LastLoginIP = @LastLoginIP,
			VisitedCount = VisitedCount + 1
		WHERE UID = @UID

		-- 로그인 히스토리 테이블
		Insert Into LoginHistories(UID ,UserID, GroupUID, UserName, LoginDate, LoginIP)
		Values(@UID, @UserID, @GroupUID, @UserName, GETDATE(), @LastLoginIP)

		Select '1' -- 로그인 성공 Signal
	END
	ELSE -- 만약 Result < 0 일때 즉 로그인 실패 했을 때
	BEGIN
		IF @OriginLastLoginDate Is Null
			Set @OriginLastLoginDate = GetDate() -- 로그인 시도 히스토리 기록
		Select '0' -- 로그인 실패 Signal
	END
END
GO
