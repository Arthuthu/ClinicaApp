CREATE PROCEDURE [dbo].[spClinica_GetByUsername]
	@Username nvarchar(50)
AS
BEGIN
	SELECT * FROM dbo.[Clinicas]
	WHERE Username = @Username;
END
