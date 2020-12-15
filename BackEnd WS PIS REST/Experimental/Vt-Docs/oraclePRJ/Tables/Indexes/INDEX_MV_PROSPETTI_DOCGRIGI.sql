--------------------------------------------------------
--  DDL for Index INDEX_MV_PROSPETTI_DOCGRIGI
--------------------------------------------------------

  CREATE INDEX "ITCOLL_6GIU12"."INDEX_MV_PROSPETTI_DOCGRIGI" ON "ITCOLL_6GIU12"."MV_PROSPETTI_DOCGRIGI" ("ID_AMM", "ID_REGISTRO", "CREATION_MONTH", "VAR_SEDE", "FLAG_IMMAGINE", "DISTINCT_COUNT") 
  PCTFREE 10 INITRANS 2 MAXTRANS 161 COMPUTE STATISTICS 
  STORAGE(INITIAL 131072 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "PITRE_INFOTN_DATA_COLL" ;