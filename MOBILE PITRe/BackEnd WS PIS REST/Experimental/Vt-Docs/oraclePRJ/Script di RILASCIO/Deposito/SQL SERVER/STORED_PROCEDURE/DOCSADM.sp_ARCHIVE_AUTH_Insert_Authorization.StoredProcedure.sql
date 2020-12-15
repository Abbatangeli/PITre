USE [PCM_DEPOSITO_1]
GO
/****** Object:  StoredProcedure [DOCSADM].[sp_ARCHIVE_AUTH_Insert_Authorization]    Script Date: 08/14/2013 11:50:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC   [DOCSADM].[sp_ARCHIVE_AUTH_Insert_Authorization]  
( @People_ID int , @StartDate datetime , @EndDate datetime ,@Note Varchar(2000), @System_ID int OUTPUT )
AS
BEGIN
INSERT INTO [DOCSADM].[ARCHIVE_Authorization] ([People_ID] , [StartDate], [EndDate], [Note])
VALUES ( @People_ID, @StartDate, @EndDate, @Note) 
SET @System_ID = SCOPE_IDENTITY()
END
GO
