CREATE PROCEDURE [dbo].[GetAllProduct]
	@GroupUID Int,
	@ProductGroupID Int,
	@ProductSubGroupID Int,
	@ProductTypeID INT
AS
	IF @ProductGroupID = 0 AND @ProductSubGroupID = 0 AND @ProductTypeID = 0
		Begin
			select *
			From Product
			Where GroupUID = @GroupUID
		END
	ELSE IF @ProductGroupID = 0 AND @ProductSubGroupID = 0
		Begin
			select *
			From Product
			Where ProductTypeID = @ProductTypeID
		END
	--ELSE IF @ProductGroupID = 0 AND @ProductTypeID = 0
	--	Begin
	--		select *
	--		From Product
	--		Where 
	--	END	// Group 이 0인데 sub가 0이 아닌것은 말이안된다.

	ELSE IF @ProductSubGroupID = 0 AND @ProductTypeID = 0
		Begin
			select *
			From Product
			Where ProductGroupID = @ProductGroupID
		END
	ELSE IF @ProductGroupID = 0 
		Begin
			select *
			From Product
			Where ProductTypeID = @ProductTypeID
		END
	ELSE IF @ProductSubGroupID = 0
		Begin
			select *
			From Product
			Where ProductGroupID = @ProductGroupID And ProductTypeID = @ProductTypeID
		END
	ELSE IF @ProductTypeID = 0
		Begin
			select *
			From Product
			Where ProductGroupID = @ProductGroupID And ProductSubGroupID = @ProductSubGroupID
		END
	ELSE 
		Begin
			select *
			From Product
			Where ProductGroupID = @ProductGroupID And ProductSubGroupID = @ProductSubGroupID And ProductTypeID = @ProductTypeID
		END
Go


