CREATE PROCEDURE [dbo].[DeleteWorkStation]
	@Id Int
AS
	Delete WorkStation
	Where Id = @Id
Go
