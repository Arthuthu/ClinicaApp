CREATE PROCEDURE [dbo].[spConsulta_GetById]
	@Id uniqueidentifier
AS
BEGIN
	SELECT * FROM dbo.[Consultas]
	WHERE Id = @Id;
END
