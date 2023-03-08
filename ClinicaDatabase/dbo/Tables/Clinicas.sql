CREATE TABLE [dbo].[Clinicas]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NULL, 
    [Username] NVARCHAR(50) NULL, 
    [Password] NVARCHAR(20) NULL, 
    [CreatedDate] DATETIME2 NULL, 
    [UpdatedDate] DATETIME2 NULL
)
