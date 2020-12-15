--------------------------------------------------------
--  DDL for Table DPA_TODOLIST
--------------------------------------------------------

  CREATE TABLE "ITCOLL_6GIU12"."DPA_TODOLIST" 
   (	"ID_TRASMISSIONE" NUMBER(10,0), 
	"ID_TRASM_SINGOLA" NUMBER(10,0), 
	"ID_TRASM_UTENTE" NUMBER(10,0), 
	"DTA_INVIO" DATE, 
	"ID_PEOPLE_MITT" NUMBER(10,0), 
	"ID_RUOLO_MITT" NUMBER(10,0), 
	"ID_PEOPLE_DEST" NUMBER(10,0), 
	"ID_RAGIONE_TRASM" NUMBER(10,0), 
	"VAR_NOTE_GEN" VARCHAR2(300 BYTE), 
	"VAR_NOTE_SING" VARCHAR2(250 BYTE), 
	"DTA_SCADENZA" DATE, 
	"ID_PROFILE" NUMBER(10,0), 
	"ID_PROJECT" NUMBER(10,0), 
	"ID_RUOLO_DEST" NUMBER(10,0), 
	"ID_REGISTRO" NUMBER(10,0), 
	"CHA_TIPO_TRASM" CHAR(1 BYTE), 
	"DTA_VISTA" DATE DEFAULT TO_DATE('01/01/1753','dd/mm/yyyy'), 
	"ID_PEOPLE_DELEGATO" NUMBER(10,0)
   ) ;
