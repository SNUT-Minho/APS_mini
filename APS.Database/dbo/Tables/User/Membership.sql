-- 각 User 별로 어떤 Group 속해 있는지를 보여해주는 테이블
-- ex) 삼성그룹 -> 삼성전자 User 
CREATE TABLE [dbo].[Membership]
(
	UserUID Int Default(0),		
	GroupUID Int Default(0),
	Primary Key(UserUID, GroupUID)
)
