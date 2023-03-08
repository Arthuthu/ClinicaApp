CREATE PROCEDURE [dbo].[spPaciente_GetById]
	@Id uniqueidentifier
AS
BEGIN
	SELECT * FROM dbo.[Pacientes]
	WHERE Id = @Id;
END
