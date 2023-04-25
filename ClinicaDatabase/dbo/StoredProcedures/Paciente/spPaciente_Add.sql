CREATE PROCEDURE [dbo].[spPaciente_Add]
	@Id uniqueidentifier,
	@NomeCompleto nvarchar(100),
	@CPF nvarchar(15),
	@CEP nvarchar(12),
	@Estado nvarchar(20),
	@Cidade nvarchar(50),
	@Rua nvarchar(50),
	@Bairro nvarchar(30),
	@NumeroRua nvarchar(5),
	@Email nvarchar(50),
	@Cel nvarchar(15),
	@CreatedDate datetime2(7),
	@ClinicaId uniqueidentifier
AS
BEGIN
	INSERT INTO dbo.[Pacientes] (Id, NomeCompleto, CPF, CEP, Estado, Cidade, Rua, Bairro, NumeroRua, Email, Cel, CreatedDate, ClinicaId)
	VALUES (@Id, @NomeCompleto, @CPF, @CEP, @Estado, @Cidade, @Rua, @Bairro, @NumeroRua, @Email, @Cel, @CreatedDate, @ClinicaId);
END
