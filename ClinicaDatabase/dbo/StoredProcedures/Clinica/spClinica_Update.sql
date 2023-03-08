CREATE PROCEDURE [dbo].[spClinica_Update]
	@Id uniqueidentifier,
	@Name nvarchar(50),
	@Username nvarchar(50),
	@Password nvarchar (20),
	@UpdatedDate datetime2(7)
AS
BEGIN
	UPDATE dbo.[Clinicas]
	SET Name = @Name, @Username = @Username, Password = @Password, UpdatedDate = @UpdatedDate
	WHERE Id = @Id
END