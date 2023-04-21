CREATE PROCEDURE [dbo].[spConsulta_GetConsultasByPacienteId]
	@PacienteId uniqueidentifier,
	@ClinicaId uniqueidentifier
AS
BEGIN
	SELECT * FROM dbo.[Consultas]
	WHERE PacienteId = @PacienteId AND ClinicaId = @ClinicaId;
END
