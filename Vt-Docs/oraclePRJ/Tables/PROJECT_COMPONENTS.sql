--------------------------------------------------------
--  DDL for Table PROJECT_COMPONENTS
--------------------------------------------------------

  CREATE TABLE "ITCOLL_6GIU12"."PROJECT_COMPONENTS" 
   (	"DESCRIPTION" VARCHAR2(60 BYTE), 
	"LIBRARY" NUMBER(10,0), 
	"TYPE" VARCHAR2(1 BYTE), 
	"PROJECT_ID" NUMBER(10,0), 
	"LINK" NUMBER(10,0), 
	"COMP_ORDER" NUMBER(10,0), 
	"VAR_CODICE_COMP" VARCHAR2(250 BYTE), 
	"PROT_TIT" VARCHAR2(255 BYTE), 
	"DTA_CLASS" DATE, 
	"CHA_FASC_PRIMARIA" VARCHAR2(1 BYTE) DEFAULT ('0')
   ) ;