--------------------------------------------------------
--  DDL for Table DPA_NOTIFICA
--------------------------------------------------------

  CREATE TABLE "ITCOLL_6GIU12"."DPA_NOTIFICA" 
   (	"SYSTEM_ID" NUMBER, 
	"ID_TIPO_NOTIFICA" NUMBER, 
	"DOCNUMBER" NUMBER, 
	"VAR_MITTENTE" VARCHAR2(255 BYTE), 
	"VAR_TIPO_DESTINATARIO" VARCHAR2(100 BYTE), 
	"VAR_DESTINATARIO" VARCHAR2(255 BYTE), 
	"VAR_RISPOSTE" VARCHAR2(255 BYTE), 
	"VAR_OGGETTO" VARCHAR2(2000 BYTE), 
	"VAR_GESTIONE_EMITTENTE" VARCHAR2(255 BYTE), 
	"VAR_ZONA" VARCHAR2(10 BYTE), 
	"VAR_GIORNO_ORA" DATE, 
	"VAR_IDENTIFICATIVO" VARCHAR2(516 BYTE), 
	"VAR_MSGID" VARCHAR2(516 BYTE), 
	"VAR_TIPO_RICEVUTA" VARCHAR2(516 BYTE), 
	"VAR_CONSEGNA" VARCHAR2(516 BYTE), 
	"VAR_RICEZIONE" VARCHAR2(516 BYTE), 
	"VAR_ERRORE_ESTESO" CLOB, 
	"VAR_ERRORE_RICEVUTA" VARCHAR2(50 BYTE), 
	"VERSION_ID" NUMBER(10,0) DEFAULT null
   ) ;
