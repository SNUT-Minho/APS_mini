-- [1] 그룹 리스트 뷰
-- Domain Table 내에서 Type이 'Group'인 유저만 모아서 정렬 

-- [2] 그룹 리스트(정보)
-- /Models/Group.cs

CREATE VIEW [dbo].[Groups]
As
	Select
		UID,
		UserID,
		CompanyName,
		UserName,
		Type,
		Description
	From
		Domains
	Where
		Type = 'Group'
	With Check Option
Go

