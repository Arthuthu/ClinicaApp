CREATE PROCEDURE [dbo].[spClinica_Update]
	@Id uniqueidentifier,
	@Password nvarchar(50),
	@UpdatedDate datetime2(7)
AS
BEGIN
	UPDATE dbo.[Clinicas]
	SET Password = @Password, UpdatedDate = @UpdatedDate
	WHERE Id = @Id
END