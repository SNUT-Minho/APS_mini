CREATE PROCEDURE [dbo].[CheckProductNumer]
	@ProductNumber INT,
	@GroupUID INT,
	@Result Int OUTPUT
AS
	Select @Result = Count(*)
	From Product
	Where GroupUID = @GroupUID And ProductNumber = @ProductNumber
Go
