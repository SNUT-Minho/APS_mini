--[1] 회원 리스트 뷰
-- Domian Table 내에서 Type이 'User'인 유저만 모아서 정렬
-- Domains Table + UserProfiles 정보 합친 것 

--[2] 사용자 리스트(정보)
-- /Models/User.cs


CREATE VIEW [dbo].[Users]
As	
	Select
		Domains.UID As UID,
		Domains.UserID As UserID,
		Domains.CompanyName As CompanyName,
		Domains.UserName As UserName,
		Domains.Description As Description,
		Domains.Industry As Industry,
		Domains.Type As Type,
		UserProfiles.Password As Password,
		UserProfiles.Email As Email,

		UserProfiles.CreatedDate As CreatedDate,
		UserProfiles.LastLoginDate AS LastLoginDate,
		UserProfiles.LastLoginIP As LastLoginIP,
		UserProfiles.VisitedCount As VisitedCount,
		UserProfiles.Blocked As Blocked
	From
		Domains Join UserProfiles
		On
			Domains.UID = UserProfiles.UID
	Where
		Domains.Type = 'User'
	With Check Option
Go
