CREATE PROCEDURE [dbo].[spConsulta_GetAll]
	@ClinicaId uniqueidentifier
AS
BEGIN
	SELECT * FROM dbo.[Consultas]
	WHERE ClinicaId = @ClinicaId
END