CREATE PROCEDURE [dbo].[spPaciente_Add]
	@Id uniqueidentifier,
	@Name nvarchar(50),
	@CreatedDate datetime2(7),
	@ClinicaId uniqueidentifier
AS
BEGIN
	INSERT INTO dbo.[Pacientes] (Id, Name, CreatedDate, ClinicaId)
	VALUES (@Id, @Name, @CreatedDate, @ClinicaId);
END
