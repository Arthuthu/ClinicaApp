CREATE PROCEDURE [dbo].[spPaciente_Delete]
	@Id uniqueidentifier
AS
BEGIN
	DELETE FROM dbo.[Pacientes]
	WHERE Id = @Id;
END
