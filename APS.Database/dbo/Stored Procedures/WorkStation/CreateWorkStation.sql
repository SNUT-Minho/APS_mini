CREATE PROCEDURE [dbo].[CreateWorkStation]
	@Title NVarChar(20),
	@Image NVarChar(50),
	@Description NVarChar(255),
	@SetupTime INT,
	@ProcessingTime INT,
	@GroupUID INT,
	@Id INT Output
AS
	Insert Into WorkStation(Title, Image, Description, SetupTime, ProcessingTime, GroupUID) Values(@Title, @Image, @Description, @SetupTime, @ProcessingTime, @GroupUID)
	Select @Id = SCOPE_IDENTITY()
GO
