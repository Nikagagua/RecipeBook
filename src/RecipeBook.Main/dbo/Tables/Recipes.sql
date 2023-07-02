﻿CREATE TABLE [dbo].[Recipes]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[Title] NVARCHAR(50) NOT NULL,
	[Description] NVARCHAR(500) NOT NULL,
	[Logo] NVARCHAR(MAX) NULL,
	[CreatedDate] DATETIMEOFFSET NOT NULL DEFAULT GETUTCDATE(),
)
