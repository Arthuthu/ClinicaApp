CREATE PROCEDURE [dbo].[spPaciente_Update]
@Id uniqueidentifier,
@NomeCompleto nvarchar(100),
@CPF nvarchar(15),
@CEP nvarchar(12),
@Estado nvarchar(20),
@Cidade nvarchar(50),
@Bairro nvarchar(30),
@Rua nvarchar(50),
@NumeroRua nvarchar(5),
@Email nvarchar(50),
@Cel nvarchar(15),
@UpdatedDate datetime2(7)
AS
BEGIN
UPDATE dbo.[Pacientes]
SET NomeCompleto = @NomeCompleto, CPF = @CPF, CEP = @CEP, Estado = @Estado, Cidade = @Cidade, Bairro = @Bairro, Rua = @Rua,  NumeroRua = @NumeroRua, Email = @Email, Cel = @Cel, UpdatedDate = @UpdatedDate
WHERE Id = @Id
END