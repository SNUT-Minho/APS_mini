-- 회원의 도메인정보
-- 외부적으로 드러나는 정보들 (비밀번호, 이메일등의 개인정보는 UserProfiles에서 관리)
 
CREATE TABLE [dbo].[Domains]
(
	[UID] INT Identity(1,1) NOT NULL PRIMARY KEY,    -- 유저 일련번호
	[UserID] NVarChar(25) Not Null,				     -- 회원 아이디
	[CompanyName] NVarChar(50) Not Null,			 -- 회사명 (ex 삼성SDS)
	[UserName] NVarChar(25) Not Null,			     -- 사용자 이름 (ex 이민호)
	-- [CompanyLogoImage]							 -- 파일 저장할 수 있는 서버 (유료)가 필요
	
	-----------------------------------------

	[Description] NVarChar(255) Null,			 -- 회사소개
	[Industry] NVarChar(20) Default(N'기타'),		     -- 회사가 속해 있는 산업 분야 
	
	------------------------------------------

	[Type] NVarChar(10) Not Null,					 -- User/Group (ex 특정 회사 Group 에 여러개의 아이디를 생성)
)
