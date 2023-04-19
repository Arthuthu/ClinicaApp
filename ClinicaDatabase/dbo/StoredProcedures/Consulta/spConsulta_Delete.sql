CREATE PROCEDURE [dbo].[spConsulta_Delete]
	@Id uniqueidentifier
AS
BEGIN
	DELETE FROM dbo.[Consultas]
	WHERE Id = @Id;
END
