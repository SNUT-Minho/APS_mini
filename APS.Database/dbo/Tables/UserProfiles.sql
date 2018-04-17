-- 회원의 개인정보
-- 외부로 드러나지 않는 정보들, 비밀번호 등의 노출되면 안되는 정보, 관리자만 확인 가능한 정보

CREATE TABLE [dbo].[UserProfiles]
(
	[ID] INT Identity(1,1) NOT NULL PRIMARY KEY,     -- 일련번호
	[UID] Int Not Null,								 -- Domains Table의 UID 값(회원 일련번호)
	[Password] NVarChar(50) Not Null,				 -- 비밀번호
	[Email] NVarChar(50) Not Null,					 -- 이메일

	[CreatedDate] DateTime Default(GetDate()),		 -- 계정 생성일
	[LastLoginDate] DateTime Null,					 -- 마지막 로그인 날짜
	[LastLoginIP] NvarChar(16) Null,				 -- 마지막 로그인 IP
	[VisitedCount] Int Default(0),					 -- 로그인 횟수
	[Blocked] Bit Default(0)						 -- 계정 잠금 여부 (0: 활성 / 1: 비활성)
)
