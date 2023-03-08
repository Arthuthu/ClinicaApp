CREATE PROCEDURE [dbo].[spClinica_GetById]
	@Id uniqueidentifier
AS
BEGIN
	SELECT * FROM dbo.[Clinicas]
	WHERE Id = @Id;
END
