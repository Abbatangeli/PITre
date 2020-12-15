-- =============================================
-- Author:		FRANCESCO FONZO
-- Create date: 21/02/2013
-- Description:	CONVERSIONE DA ORACLE A SQL SERVER
-- =============================================

DECLARE @db_user	VARCHAR(1024)
SET @db_user = 'DOCSADM'

-- INSERIMENTO NELLA DPA_EL_REGISTRI DI DUE NUOVE COLONNE VAR_PREG E ANNO_PREG

DECLARE @COUNT	INT

SET @COUNT = (SELECT COUNT(*) FROM SYS.columns WHERE name = 'VAR_PREG' AND OBJECT_ID = (SELECT OBJECT_ID FROM SYS.tables WHERE name = 'DPA_EL_REGISTRI'))

IF (@COUNT = 0)
BEGIN
	EXECUTE DOCSADM.utl_add_column '3.23',@db_user,'DPA_EL_REGISTRI','VAR_PREG','CHAR(1)',NULL,NULL,NULL,NULL
END
ELSE
	PRINT 'GIA'' ESISTENTE'

SET @COUNT = (SELECT COUNT(*) FROM SYS.columns WHERE name = 'ANNO_PREG' AND OBJECT_ID = (SELECT OBJECT_ID FROM SYS.tables WHERE name = 'DPA_EL_REGISTRI'))

IF (@COUNT = 0)
BEGIN
	EXECUTE DOCSADM.utl_add_column '3.23',@db_user,'DPA_EL_REGISTRI','ANNO_PREG','VARCHAR(10)',NULL,NULL,NULL,NULL
END
ELSE
	PRINT 'GIA'' ESISTENTE'