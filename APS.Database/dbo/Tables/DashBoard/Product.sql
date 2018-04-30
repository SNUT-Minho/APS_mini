CREATE TABLE [dbo].[Product]
(
	[PID] INT NOT NULL Identity(1,1) PRIMARY KEY,		-- 일련번호
	[ProductGroupID] INT NULL Default(0),				-- 제품 그룹 번호(EC-I)
	[ProductNumber] INT NOT NULL,						-- 품목번호
	[ParentNumber] INT NULL,							-- 부모 품목 번호
	[ProductOrder] INT Default(0),						-- 품목 순서
	[Description] NVarChar(255) NOT NULL,				-- 품목 설명
	[ProductTypeID] Int NULL Default(1),								-- 완제품 1 / 반제품 2 / 원자재 3
	
	-- ** 
	[GroupUID] INT NOT NULL,							-- 해당 그룹(삼성 SDS)
	[UID] INT NOT NULL									-- 작성자 일련번호
)
