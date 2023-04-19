CREATE PROCEDURE [dbo].[spConsulta_Add]
	@Id uniqueidentifier,
	@Data datetime2(7),
	@Descricao nvarchar(500),
	@CreatedDate datetime2(7),
	@PacienteId uniqueidentifier,
	@ClinicaId uniqueidentifier
AS
BEGIN
	INSERT INTO dbo.[Consultas] (Id, Data, Descricao, CreatedDate, PacienteId, ClinicaId)
	VALUES (@Id, @Data, @Descricao, @CreatedDate, @PacienteId, @ClinicaId);
END
