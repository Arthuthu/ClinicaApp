CREATE PROCEDURE [dbo].[spPaciente_GetAll]
	@ClinicaId uniqueidentifier
AS
BEGIN
	SELECT * FROM dbo.[Pacientes]
	WHERE ClinicaId = @ClinicaId;
END