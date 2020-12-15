CREATE PROCEDURE SP_INSERT_DPA_DETT_GLOBALI

AS

DECLARE @sysCorrente INT

DECLARE sysCursor CURSOR FOR
		select system_id from DPA_CORR_GLOBALI 
		WHERE cha_tipo_ie = 'E' AND CHA_TIPO_URP IN ('U', 'P') AND DTA_FINE IS NULL
		and system_id 
		not in (select id_corr_globali from dpa_dett_globali)
BEGIN

	OPEN  sysCursor
		 	 FETCH NEXT FROM sysCursor INTO @sysCorrente
			 WHILE @@FETCH_STATUS = 0
			 
			 	  BEGIN
					   
				  	   INSERT INTO DPA_DETT_GLOBALI 
					   (	 
							  ID_CORR_GLOBALI
					   )
					   VALUES
					   (
							 @sysCorrente
					   )
 				
				   	   FETCH NEXT FROM sysCursor INTO @sysCorrente
				END
			 
    
		CLOSE sysCursor
		DEALLOCATE sysCursor
	
	
END
GO