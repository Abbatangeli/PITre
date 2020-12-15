--------------------------------------------------------
--  DDL for Table DPA_ITEMS_CONSERVAZIONE
--------------------------------------------------------

  CREATE TABLE "ITCOLL_6GIU12"."DPA_ITEMS_CONSERVAZIONE" 
   (	"SYSTEM_ID" NUMBER, 
	"ID_CONSERVAZIONE" NUMBER, 
	"ID_PROFILE" NUMBER, 
	"ID_PROJECT" NUMBER, 
	"CHA_TIPO_DOC" CHAR(1 BYTE), 
	"VAR_OGGETTO" VARCHAR2(2000 BYTE), 
	"ID_REGISTRO" NUMBER, 
	"DATA_INS" DATE, 
	"CHA_STATO" CHAR(1 BYTE), 
	"VAR_XML_METADATI" CLOB, 
	"SIZE_ITEM" NUMBER, 
	"COD_FASC" VARCHAR2(64 BYTE), 
	"DOCNUMBER" NUMBER, 
	"CHA_TIPO_OGGETTO" CHAR(1 CHAR), 
	"VAR_TIPO_FILE" VARCHAR2(32 BYTE), 
	"NUMERO_ALLEGATI" NUMBER, 
	"CHA_ESITO" CHAR(1 BYTE), 
	"VAR_TIPO_ATTO" VARCHAR2(64 BYTE), 
	"POLICY_VALIDA" CHAR(1 BYTE), 
	"VALIDAZIONE_FIRMA" CHAR(1 BYTE)
   ) ;
