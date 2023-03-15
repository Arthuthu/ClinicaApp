﻿CREATE TABLE [dbo].[Pacientes]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Nome] NVARCHAR(50) NOT NULL,
    [Sobrenome] NVARCHAR(50) NULL, 
    [CPF] NVARCHAR(15) NULL, 
    [CEP] NVARCHAR(12) NULL, 
    [Estado] NVARCHAR(20) NULL, 
    [Cidade] NVARCHAR(50) NULL, 
    [Rua] NVARCHAR(50) NULL, 
    [Bairro] NVARCHAR(30) NULL, 
    [NumeroRua] NVARCHAR(5) NULL, 
    [Email] NVARCHAR(50) NULL, 
    [Cel] NVARCHAR(15) NULL, 
    [CreatedDate] DATETIME2 NULL, 
    [UpdatedDate] DATETIME2 NULL, 
    [ClinicaId] UNIQUEIDENTIFIER NULL,
    FOREIGN KEY (ClinicaId) REFERENCES Clinicas(Id) ON DELETE CASCADE
)
