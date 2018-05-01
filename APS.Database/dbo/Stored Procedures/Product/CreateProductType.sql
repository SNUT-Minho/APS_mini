CREATE PROCEDURE [dbo].[CreateProductType]
	@ProductTypeName NVarChar(25),
	@GroupUID INT = 1,

	@ProductTypeID INT Output
AS
	Insert Into ProductType(ProductTypeName,GroupUID)
	Values(@ProductTypeName,@GroupUID)

	Select @ProductTypeID = SCOPE_IDENTITY()
GO
