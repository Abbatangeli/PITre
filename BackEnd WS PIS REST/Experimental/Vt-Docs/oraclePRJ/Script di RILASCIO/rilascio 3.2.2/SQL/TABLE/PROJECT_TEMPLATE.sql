
DROP TABLE [PROJECT_TEMPLATE]
GO
CREATE TABLE [PROJECT_TEMPLATE](
    [SYSTEM_ID] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
    [NAME] [varchar](255) NULL
)
GO

DROP TABLE [PROJECT_STRUCTURE]
GO
CREATE TABLE [PROJECT_STRUCTURE](
    [SYSTEM_ID] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
    [ID_PARENT] [int] NULL,
    [NAME] [varchar](255) NULL,
    [ID_TEMPLATE] [int] NOT NULL
)
GO
ALTER TABLE [PROJECT_STRUCTURE] WITH CHECK ADD FOREIGN KEY([ID_TEMPLATE])
REFERENCES [PROJECT_TEMPLATE] ([SYSTEM_ID])
GO

DROP TABLE [REL_PROJECT_STRUCTURE]
GO
CREATE TABLE [REL_PROJECT_STRUCTURE](
    [SYSTEM_ID] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
    [ID_TIPO_FASCICOLO] [int] NULL,
    [ID_TITOLARIO] [int] NULL,
    [ID_TEMPLATE] [int] NOT NULL
)
GO
ALTER TABLE [REL_PROJECT_STRUCTURE] WITH CHECK ADD FOREIGN KEY([ID_TEMPLATE])
REFERENCES [PROJECT_TEMPLATE] ([SYSTEM_ID])
GO