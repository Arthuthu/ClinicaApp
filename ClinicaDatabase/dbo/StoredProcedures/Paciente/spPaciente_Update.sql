CREATE PROCEDURE [dbo].[spPaciente_Update]
@Id uniqueidentifier,
@Nome nvarchar(50),
@Sobrenome nvarchar(50),
@CPF nvarchar(15),
@CEP nvarchar(12),
@Estado nvarchar(20),
@Cidade nvarchar(50),
@Rua nvarchar(50),
@Bairro nvarchar(30),
@NumeroRua nvarchar(5),
@Email nvarchar(50),
@Cel nvarchar(15),
@UpdatedDate datetime2(7)
AS
BEGIN
UPDATE dbo.[Pacientes]
SET Nome = @Nome, Sobrenome = @Sobrenome, CPF = @CPF, CEP = @CEP, Estado = @Estado, Cidade = @Cidade, Rua = @Rua, Bairro = @Bairro, NumeroRua = @NumeroRua, Email = @Email, Cel = @Cel, UpdatedDate = @UpdatedDate
WHERE Id = @Id
END