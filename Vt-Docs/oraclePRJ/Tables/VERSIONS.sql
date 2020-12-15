--------------------------------------------------------
--  DDL for Table VERSIONS
--------------------------------------------------------

  CREATE TABLE "ITCOLL_6GIU12"."VERSIONS" 
   (	"VERSION_ID" NUMBER(10,0), 
	"DOCNUMBER" NUMBER(10,0), 
	"VERSION" NUMBER(10,0), 
	"SUBVERSION" VARCHAR2(1 BYTE), 
	"VERSION_LABEL" VARCHAR2(10 BYTE), 
	"AUTHOR" NUMBER(10,0), 
	"TYPIST" NUMBER(10,0), 
	"LASTEDITDATE" DATE, 
	"LASTEDITTIME" DATE, 
	"COMMENTS" VARCHAR2(200 BYTE), 
	"NUM_PAG_ALLEGATI" NUMBER(10,0), 
	"DTA_CREAZIONE" DATE, 
	"CHA_DA_INVIARE" VARCHAR2(1 BYTE), 
	"DTA_ARRIVO" DATE, 
	"V_NAME_FN" VARCHAR2(7 BYTE), 
	"CARTACEO" NUMBER(*,0), 
	"SCARTA_FASC_CARTACEA" NUMBER(*,0), 
	"ID_PEOPLE_DELEGATO" NUMBER(10,0), 
	"CHA_SEGNATURA" VARCHAR2(1 BYTE)
   ) ;
