CREATE PROCEDURE [dbo].[spPaciente_Update]
	@Id uniqueidentifier,
	@Name nvarchar(50),
	@UpdatedDate datetime2(7)
AS
BEGIN
	UPDATE dbo.[Pacientes]
	SET Name = @Name, UpdatedDate = @UpdatedDate
	WHERE Id = @Id
END