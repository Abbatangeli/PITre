--------------------------------------------------------
--  DDL for Table DPA_CONSOLIDATED_DOCS
--------------------------------------------------------

  CREATE TABLE "ITCOLL_6GIU12"."DPA_CONSOLIDATED_DOCS" 
   (	"ID" NUMBER(10,0), 
	"DOCNAME" VARCHAR2(240 BYTE), 
	"CREATION_DATE" DATE, 
	"DOCUMENTTYPE" NUMBER(10,0), 
	"AUTHOR" NUMBER(10,0), 
	"AUTHOR_NAME" VARCHAR2(4000 BYTE), 
	"ID_RUOLO_CREATORE" NUMBER, 
	"RUOLO_CREATORE" VARCHAR2(4000 BYTE), 
	"NUM_PROTO" NUMBER(10,0), 
	"NUM_ANNO_PROTO" NUMBER(10,0), 
	"DTA_PROTO" DATE, 
	"ID_PEOPLE_PROT" NUMBER, 
	"PEOPLE_PROT" VARCHAR2(4000 BYTE), 
	"ID_RUOLO_PROT" NUMBER, 
	"RUOLO_PROT" VARCHAR2(4000 BYTE), 
	"ID_REGISTRO" NUMBER(10,0), 
	"REGISTRO" VARCHAR2(4000 BYTE), 
	"CHA_TIPO_PROTO" VARCHAR2(1 BYTE), 
	"VAR_PROTO_IN" VARCHAR2(128 BYTE), 
	"DTA_PROTO_IN" DATE, 
	"DTA_ANNULLA" DATE, 
	"ID_OGGETTO" NUMBER(10,0), 
	"VAR_PROF_OGGETTO" VARCHAR2(2000 BYTE), 
	"MITT_DEST" VARCHAR2(4000 BYTE), 
	"ID_DOCUMENTO_PRINCIPALE" NUMBER(*,0)
   ) ;
