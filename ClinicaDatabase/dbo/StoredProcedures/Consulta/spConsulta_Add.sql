CREATE PROCEDURE [dbo].[spConsulta_Add]
	@Id uniqueidentifier,
	@Data datetime2(7),
	@Descricao nvarchar(500),
	@PacienteCel nvarchar(15),
	@PacienteNome nvarchar(100),
	@CreatedDate datetime2(7),
	@PacienteId uniqueidentifier,
	@ClinicaId uniqueidentifier
AS
BEGIN
	INSERT INTO dbo.[Consultas] (Id, Data, Descricao, PacienteCel, PacienteNome, CreatedDate, PacienteId, ClinicaId)
	VALUES (@Id, @Data, @Descricao, @PacienteCel, @PacienteNome, @CreatedDate, @PacienteId, @ClinicaId);
END
