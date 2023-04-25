CREATE PROCEDURE [dbo].[spPaciente_GetByNome]
	@ClinicaId uniqueidentifier,
	@NomeCompleto nvarchar(50)
AS
BEGIN
	SELECT * FROM dbo.[Pacientes]
	WHERE ClinicaId = @ClinicaId AND NomeCompleto = @NomeCompleto;
END
