CREATE PROCEDURE [dbo].[spPaciente_GetByCPF]
	@ClinicaId uniqueidentifier,
	@CPF nvarchar(50)
AS
BEGIN
	SELECT * FROM dbo.[Pacientes]
	WHERE ClinicaId = @ClinicaId AND CPF = @CPF;
END
