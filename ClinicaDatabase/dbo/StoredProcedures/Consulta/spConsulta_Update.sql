CREATE PROCEDURE [dbo].[spConsulta_Update]
	@Id uniqueidentifier,
	@Data datetime2(7),
	@Descricao nvarchar(500),
	@UpdatedDate datetime2(7)
AS
BEGIN
	UPDATE dbo.[Consultas]
	SET Data = @Data, Descricao = @Descricao, UpdatedDate = @UpdatedDate
	WHERE Id = @Id
END