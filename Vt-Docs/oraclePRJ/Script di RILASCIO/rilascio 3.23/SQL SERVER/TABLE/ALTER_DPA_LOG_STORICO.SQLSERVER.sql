-- =============================================
-- Author:		FRANCESCO FONZO
-- Create date: 21/02/2013
-- Description:	CONVERSIONE DA ORACLE A SQL SERVER
-- =============================================

DECLARE @db_user	VARCHAR(1024)
SET @db_user = 'DOCSADM'


-- INSERIMENTO NELLA DPA_LOG_STORICO DI UNA NUOVA COLONNA VAR_COD_WORKING_APPLICATION 

DECLARE @COUNT INT

SET @COUNT = (SELECT COUNT(*) FROM SYS.columns WHERE name = 'VAR_COD_WORKING_APPLICATION' AND OBJECT_ID = (SELECT OBJECT_ID FROM SYS.tables WHERE name = 'DPA_LOG_STORICO'))

IF (@COUNT = 0)
BEGIN              
	EXECUTE DOCSADM.utl_add_column '3.23',@db_user,'DPA_LOG_STORICO','VAR_COD_WORKING_APPLICATION','VARCHAR(200)',NULL,NULL,NULL,NULL
END  
ELSE
	PRINT 'GIA'' ESISTENTE'