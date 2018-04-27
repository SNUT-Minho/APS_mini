CREATE PROCEDURE [dbo].[CreateCompany]
	@CompanyName NVarChar(25),
	@CID INT Output,
	@SecureCode INT Output
AS

	Set @SecureCode = ABS(CheckSum(NewID())%10000000000) + 1

	Insert Company(CompanyName, SecureCode) Values(@CompanyName, @SecureCode)

	Select @CID = SCOPE_IDENTITY()
Go
