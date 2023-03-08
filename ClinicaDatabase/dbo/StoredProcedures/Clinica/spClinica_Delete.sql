CREATE PROCEDURE [dbo].[spClinica_Delete]
	@Id uniqueidentifier
AS
BEGIN
	DELETE FROM dbo.[Clinicas]
	WHERE Id = @Id;
END
