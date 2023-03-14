CREATE PROCEDURE [dbo].[spPaciente_Add]
	@Id uniqueidentifier,
	@Name nvarchar(50),
	@Username nvarchar(50),
	@Password nvarchar(20),
	@CreatedDate datetime2(7)
AS
BEGIN
	INSERT INTO dbo.[Clinicas] (Id, Name, Username, Password, CreatedDate)
	VALUES (@Id, @Name, @Username, @Password, @CreatedDate);
END
