CREATE PROCEDURE [dbo].[CreateProduct]
	@ProductGroupID INT,
	@ProductSubGroupID INT,
	@ProductNumber INT,
	@Description NVarChar(255),
	@ProductTypeID INT,
	@GroupUID INT,
	@UID INT,
	
	@PID INT Output,
	@ProductGroupName NvarChar(25) Output,
	@ProductSubGroupName NvarChar(25) Output,
	@ProductTypeName NVarChar(25) Output,
	@CreateUserName NVarChar(25) Output
AS
		Insert Into Product(ProductGroupID,ProductSubGroupID, ProductNumber, Description, ProductTypeID, GroupUID, UID) 
		Values (@ProductGroupID,@ProductSubGroupID, @ProductNumber, @Description, @ProductTypeID, @GroupUID, @UID)

		Select @PID =  SCOPE_IDENTITY()

		Select @ProductGroupName = ProductGroupName
		From ProductGroup
		Where ProductGroupID = @ProductGroupID

		Select @ProductSubGroupName = ProductGroupName
		From ProductGroup
		Where ProductGroupID = @ProductSubGroupID

		Select @ProductTypeName = ProductTypeName
		From ProductType
		Where ProductTypeID = @ProductTypeID

		Select @CreateUserName = UserName
		From Domains
		Where UID = @UID
GO
