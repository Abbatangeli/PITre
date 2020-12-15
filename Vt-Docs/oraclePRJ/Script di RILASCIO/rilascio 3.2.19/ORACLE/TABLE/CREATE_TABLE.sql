CREATE TABLE DPA_PEOPLE_OTP_RESET_PASSWORD
(	
	SYSTEM_ID NUMBER, 
	USER_ID_PEOPLE VARCHAR2(128 BYTE), 
	VAR_EMAIL VARCHAR2(128 BYTE), 
	VAR_OTP VARCHAR2(128 BYTE), 
	DTA_INSERIMENTO DATE
); 

CREATE TABLE DPA_INFO_FILE
(	
	SYSTEM_ID NUMBER, 
	ID_PROFILE NUMBER,
	ID_DOCUMENTO_PRINCIPALE NUMBER,
	VERSION_ID NUMBER,
	DTA_ACQUISIZIONE DATE,	
	VAR_ESTENSIONE VARCHAR(256 BYTE),
	VAR_NOME_FILE VARCHAR(256 BYTE),
	VAR_DESC_INFO_FILE VARCHAR(256 BYTE),
	CHA_CONFORME CHAR(1) DEFAULT 1,	
	CHA_ESTENSIONE_CONFORME CHAR(1) DEFAULT 1,
	CHA_PRESENZA_MACRO CHAR(1) DEFAULT 0,
	CHA_PRESENZA_FORMS CHAR(1) DEFAULT 0,
	CHA_PRESENZA_JAVASCRIPT CHAR(1) DEFAULT 0,
	CHA_NOTIFICA CHAR(1) DEFAULT 0
); 

CREATE SEQUENCE SEQ_DPA_PEOPLE_OTP_RESET_PW INCREMENT BY 1 MAXVALUE 999999999999999999999999999 MINVALUE 1 NOCACHE;
CREATE SEQUENCE SEQ_DPA_INFO_FILE INCREMENT BY 1 MAXVALUE 999999999999999999999999999 MINVALUE 1 NOCACHE;