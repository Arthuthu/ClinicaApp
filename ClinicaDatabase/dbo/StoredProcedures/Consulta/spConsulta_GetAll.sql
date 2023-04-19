CREATE PROCEDURE [dbo].[spConsulta_GetAll]
	@ClinicaId uniqueidentifier,
	@PacienteId uniqueidentifier
AS
BEGIN
	SELECT * FROM dbo.[Consultas]
	WHERE ClinicaId = @ClinicaId
END