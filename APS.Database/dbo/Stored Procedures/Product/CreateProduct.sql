CREATE PROCEDURE [dbo].[CreateProduct]
	@ProductGroupID INT, 
	@ProductNumber INT,
	@Description NVarChar(255),
	@ProductTypeID INT,
	@GroupUID INT,
	@UID INT,
	
	@PID INT Output,
	@ProductGroupName NvarChar(25) Output,
	@ProductTypeName NVarChar(25) Output
AS
	Insert Into Product(ProductGroupID, ProductNumber, Description, ProductTypeID, GroupUID, UID) 
	Values (@ProductGroupID, @ProductNumber, @Description, @ProductTypeID, @GroupUID, @UID)

	Select @PID =  SCOPE_IDENTITY()

	Select @ProductGroupName = ProductGroupName
	From ProductGroup
	Where ProductGroupID = @ProductGroupID

	Select @ProductTypeName = ProductTypeName
	From ProductType
	Where ProductTypeID = @ProductTypeID
GO
