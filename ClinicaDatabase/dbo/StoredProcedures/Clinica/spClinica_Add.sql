CREATE PROCEDURE [dbo].[spClinica_Add]
	@Id uniqueidentifier,
	@Username nvarchar(50),
	@Password nvarchar(20),
	@PasswordHash varbinary(MAX),
	@PasswordSalt varbinary(MAX),
	@CreatedDate datetime2(7)
AS
BEGIN
	INSERT INTO dbo.[Clinicas] (Id, Username, Password, PasswordHash, PasswordSalt, CreatedDate)
	VALUES (@Id, @Username, @Password, @PasswordHash, @PasswordSalt, @CreatedDate);
END
