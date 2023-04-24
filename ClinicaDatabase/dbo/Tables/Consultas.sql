﻿CREATE TABLE [dbo].[Consultas]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Data] DATETIME2 NOT NULL, 
    [Descricao] NVARCHAR(500) NULL, 
    [PacienteCel] NVARCHAR(15) NULL,
    [PacienteNome] NVARCHAR(100) NULL,
    [CreatedDate] DATETIME2 NULL, 
    [UpdatedDate] DATETIME2 NULL, 
    [PacienteId] UNIQUEIDENTIFIER NOT NULL,
    [ClinicaId] UNIQUEIDENTIFIER NULL, 
    FOREIGN KEY (PacienteId) REFERENCES Pacientes(Id) ON DELETE CASCADE
)
