--------------------------------------------------------
--  DDL for Index IDX_DPA_OGGETTARIO
--------------------------------------------------------

  CREATE INDEX "ITCOLL_6GIU12"."IDX_DPA_OGGETTARIO" ON "ITCOLL_6GIU12"."DPA_OGGETTARIO" ("VAR_DESC_OGGETTO", "ID_REGISTRO") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 48234496 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "PITRE_INFOTN_DATA_COLL" ;