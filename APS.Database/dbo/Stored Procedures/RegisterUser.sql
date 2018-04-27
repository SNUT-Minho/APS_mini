-- [!] 회원 가입 저장 프로시저 : UserRepository/RegisterUser
  -------------------------------------------------

CREATE PROCEDURE [dbo].[RegisterUser]
	@UserID NVarChar(25),		------------------------
	@UserName NVarChar(25),		-- Domains 테이블의 값---
	@Industry NVarChar(20),		------------------------
	--
	@Password NVarChar(50),		-- UserProfiles 테이블의 값 
	--
	@UID Int output,
	@CompanyName NvarChar(25) Output,
	-- 
	@GroupUID Int				-- 해당 사용자가 어떤 그룹에 속할 것인지를 결정하는 매개변수 (Company테이블의 CID)
AS
	If @UID Is Null
		Set @UID = 0


	-- Select @Industry = Industry From Industries Where IndustryVal = @Industry  

	-- Domains 테이블에 데이터 입력
	Insert Into Domains (UserID, GroupUID, UserName, Industry, Type)
	Values (@UserID, @GroupUID, @UserName, @Industry, 'User')

	-- Domains 테이블에 가장 나중에 입력된 UID값
	Select @UID = SCOPE_IDENTITY()

	-- UserProfiles 테이블에 데이터 입력
	Insert Into UserProfiles(UID, Password, Email, LastLoginDate, LastLoginIP, VisitedCount, Blocked )
	Values (@UID, @Password, NULL, NULL, NULL, 0, 0)

	Insert Into Membership(UserUID, GroupUID)
	Values (@UID, @GroupUID)	-- [!!미적용!!] GroupUID 의 값은 나중에 목록으로 만들어야됨 // Groups 테이블로 만들거나 / Domains에 Type을 Group으로 해서 만들면 됨
	
	Select @UID	-- 마지막에 UID값을 반환해서 현재 생성된 사용자의 UID를 Return

	Select @CompanyName = CompanyName -- @CompanyName 값을 반환
	From Company
	Where CID = @GroupUID
Go
