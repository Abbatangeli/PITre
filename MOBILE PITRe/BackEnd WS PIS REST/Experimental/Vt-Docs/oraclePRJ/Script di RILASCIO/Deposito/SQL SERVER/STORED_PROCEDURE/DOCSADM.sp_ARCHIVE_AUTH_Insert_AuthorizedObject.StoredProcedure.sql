USE [PCM_DEPOSITO_1]
GO
/****** Object:  StoredProcedure [DOCSADM].[sp_ARCHIVE_AUTH_Insert_AuthorizedObject]    Script Date: 08/14/2013 11:50:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC   [DOCSADM].[sp_ARCHIVE_AUTH_Insert_AuthorizedObject]  
( @Authorization_ID int , @Project_ID int , @Profile_ID int , @System_ID int OUTPUT )
AS
BEGIN
INSERT INTO [DOCSADM].[ARCHIVE_AuthorizedObject] ([Authorization_ID] , [Project_ID], [Profile_ID])
VALUES ( @Authorization_ID, @Project_ID, @Profile_ID) 
SET @System_ID = SCOPE_IDENTITY()
END
GO
