CREATE PROCEDURE [dbo].[spConsulta_Add]
	@Id uniqueidentifier,
	@Data datetime2(7),
	@Descricao nvarchar(500),
	@CreatedDate datetime2(7),
	@PacienteId uniqueidentifier
AS
BEGIN
	INSERT INTO dbo.[Consultas] (Id, Data, Descricao, CreatedDate, PacienteId)
	VALUES (@Id, @Data, @Descricao, @CreatedDate, @PacienteId);
END
