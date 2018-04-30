-- 산업의 Value 값에 1:1 매칭되는 string값 가지고 있는 테이블
-- Register 테이블에서 선택되어진 Value값에 따라서 Industries 테이블에서 값을 가져온다.

CREATE TABLE [dbo].[Industries]
(
	[Id] INT NOT NULL PRIMARY KEY Identity(1,1),
	[IndustryVal] NVARCHAR(5) NOT NULL,
	[Industry] NVarChar(20) NOT NULL
)
