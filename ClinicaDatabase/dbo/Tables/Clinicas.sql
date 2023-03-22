CREATE TABLE [dbo].[Clinicas]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    [Username] NVARCHAR(50) NULL, 
    [Password] NVARCHAR(20) NULL, 
    [PasswordHash] VARBINARY(MAX) NULL, 
    [PasswordSalt] VARBINARY(MAX) NULL,
    [CreatedDate] DATETIME2 NULL, 
    [UpdatedDate] DATETIME2 NULL

)
