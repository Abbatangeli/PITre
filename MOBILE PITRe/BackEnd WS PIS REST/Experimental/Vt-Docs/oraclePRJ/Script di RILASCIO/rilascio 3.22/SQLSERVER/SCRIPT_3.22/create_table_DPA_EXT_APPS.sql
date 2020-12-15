

DECLARE @CNT INT
  
SET @CNT = (SELECT COUNT(*) FROM SYS.tables WHERE name = 'DPA_EXT_APPS')    
  
IF (@CNT = 0)
BEGIN
	CREATE TABLE [DOCSADM].[DPA_EXT_APPS]
	(
		[SYSTEM_ID]				INT	IDENTITY(1,1)	NOT NULL,
		[VAR_CODE]				VARCHAR(32)		NULL,			
		[DESCRIPTION]			VARCHAR(512)			NULL,
				
		PRIMARY KEY CLUSTERED 
		(
			[SYSTEM_ID] ASC
		)
		WITH 
		(
			PAD_INDEX  = OFF
			, STATISTICS_NORECOMPUTE  = OFF
			, IGNORE_DUP_KEY = OFF
			, ALLOW_ROW_LOCKS  = ON
			, ALLOW_PAGE_LOCKS  = ON
		) ON [PRIMARY]
	) ON [PRIMARY]
PRINT 'CREATO TABELLA DPA_EXT_APPS'
END 
ELSE
	PRINT 'TABELLA ESISTENTE'


