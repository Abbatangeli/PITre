--------------------------------------------------------
--  DDL for Table GROUPS
--------------------------------------------------------

  CREATE TABLE "ITCOLL_6GIU12"."GROUPS" 
   (	"SYSTEM_ID" NUMBER(10,0), 
	"GROUP_ID" VARCHAR2(32 BYTE), 
	"NETWORK_ID" VARCHAR2(254 BYTE), 
	"GROUP_NAME" VARCHAR2(256 BYTE), 
	"PROFILE_DEFAULTS" LONG, 
	"DISABLED" VARCHAR2(1 BYTE), 
	"ALLOW_LOGIN" VARCHAR2(1 BYTE), 
	"UNIV_ACCESS" NUMBER(10,0), 
	"DELETE_VERSIONS" VARCHAR2(1 BYTE), 
	"EDIT_PREVIOUS_VER" VARCHAR2(1 BYTE), 
	"MAX_VERSIONS" NUMBER(10,0), 
	"MAX_SUBVERSIONS" NUMBER(10,0), 
	"NEW_VERSIONS" VARCHAR2(1 BYTE), 
	"SAVE_TO_REM_LIB" VARCHAR2(1 BYTE), 
	"PRECONNECT_LIBS" VARCHAR2(1 BYTE), 
	"NV_AUTHOR_EDIT" VARCHAR2(1 BYTE), 
	"NV_ENTERED_BY" VARCHAR2(1 BYTE), 
	"NV_BILLABLE" VARCHAR2(1 BYTE), 
	"DISPLAY_VER_LIST" VARCHAR2(1 BYTE), 
	"MV_DOCS_IF_CHNG" VARCHAR2(1 BYTE), 
	"CHECKOUT" VARCHAR2(1 BYTE), 
	"OTHER_CHECKIN" VARCHAR2(1 BYTE), 
	"CHECKIN_REMINDER" VARCHAR2(1 BYTE), 
	"RESET_STATUS" VARCHAR2(1 BYTE), 
	"COPY_IN_USE" VARCHAR2(1 BYTE), 
	"TEMPLATE_MANAGER" VARCHAR2(1 BYTE), 
	"MASS_UPD_PROFILES" VARCHAR2(1 BYTE), 
	"AUTO_LOGIN" VARCHAR2(1 BYTE), 
	"VIEW_UNSECURED" VARCHAR2(1 BYTE), 
	"PROMPT_PAGES" VARCHAR2(1 BYTE), 
	"NONBILL_PAGES" VARCHAR2(1 BYTE), 
	"DEFAULT_PAGES" NUMBER(10,0), 
	"GET_EDIT_INFO" VARCHAR2(1 BYTE), 
	"VISIT_AUTHOR_EDIT" VARCHAR2(1 BYTE), 
	"VISIT_ENTERED_BY" VARCHAR2(1 BYTE), 
	"LCP_RUN" VARCHAR2(1 BYTE), 
	"EDIT_VTS" VARCHAR2(1 BYTE), 
	"EDIT_LIBPARMS" VARCHAR2(1 BYTE), 
	"EDIT_WS_PARAMS" VARCHAR2(1 BYTE), 
	"EDIT_USER_DEFAULTS" VARCHAR2(1 BYTE), 
	"MANAGE_GROUPS" VARCHAR2(1 BYTE), 
	"DI_RUN" VARCHAR2(1 BYTE), 
	"MBLINST_RUN" VARCHAR2(1 BYTE), 
	"DI_MANAGE" VARCHAR2(1 BYTE), 
	"CR_RUN" VARCHAR2(1 BYTE), 
	"SM_RUN" VARCHAR2(1 BYTE), 
	"DD_RUN" VARCHAR2(1 BYTE), 
	"DB_EDIT" VARCHAR2(1 BYTE), 
	"DBI_RUN" VARCHAR2(1 BYTE), 
	"INDEXER_RUN" VARCHAR2(1 BYTE), 
	"INTERCHANGE_RUN" VARCHAR2(1 BYTE), 
	"PROFSEC" VARCHAR2(1 BYTE), 
	"ALLOW_DOC_DELETE" VARCHAR2(1 BYTE), 
	"ALLOW_CONTENT_DEL" VARCHAR2(1 BYTE), 
	"ALLOW_QUEUE_DEL" VARCHAR2(1 BYTE), 
	"PROFILE_FORM" NUMBER(10,0), 
	"HITLIST_FORM" NUMBER(10,0), 
	"ACL_DEFAULTS" VARCHAR2(254 BYTE), 
	"REMOVE_MON_LIST" VARCHAR2(1 BYTE), 
	"DISPLAY_MON_LIST" VARCHAR2(1 BYTE), 
	"WARN_SECURE" VARCHAR2(1 BYTE), 
	"ONLY_READONLY" VARCHAR2(1 BYTE), 
	"FORCE_CHECKIN" VARCHAR2(1 BYTE), 
	"MBL_EDITCOPY" VARCHAR2(1 BYTE), 
	"MBL_OVERWRITE" VARCHAR2(1 BYTE), 
	"MIN_DISKFREE" NUMBER(10,0), 
	"AUTOCLEAN" VARCHAR2(1 BYTE), 
	"DEF_SHAD_RETENTION" NUMBER(10,0), 
	"SHADOW_DOCS" VARCHAR2(1 BYTE), 
	"SHADOW_PROFILES" VARCHAR2(1 BYTE), 
	"SHADOW_SEC_DOCS" VARCHAR2(1 BYTE), 
	"DEFAULT_FT_INDEX" NUMBER(10,0), 
	"DISABLE_NATIVE" VARCHAR2(1 BYTE), 
	"MAKE_READ_ONLY" VARCHAR2(1 BYTE), 
	"REMOVE_READ_ONLY" VARCHAR2(1 BYTE), 
	"MAKE_VER_READONLY" VARCHAR2(1 BYTE), 
	"MAKE_VER_WRITABLE" VARCHAR2(1 BYTE), 
	"PUBLISH_VERSION" VARCHAR2(1 BYTE), 
	"UNPUBLISH_VERSION" VARCHAR2(1 BYTE), 
	"DATE_FORMAT" VARCHAR2(10 BYTE), 
	"TIME_FORMAT" VARCHAR2(10 BYTE), 
	"ITEM_MAX" NUMBER(10,0), 
	"PAGE_MAX" NUMBER(10,0), 
	"DEFAULT_VIEWER" VARCHAR2(10 BYTE), 
	"FRONTEND_PROFILE" VARCHAR2(1 BYTE), 
	"MANAGE_PRF" VARCHAR2(1 BYTE), 
	"MANAGE_CYD" VARCHAR2(1 BYTE), 
	"DPACKAGE" NUMBER(10,0), 
	"ALLOW_APPINT" VARCHAR2(1 BYTE), 
	"ALLOW_USRSETTINGS" VARCHAR2(1 BYTE), 
	"ALLOW_DOC_CREATE" VARCHAR2(1 BYTE), 
	"CREATE_FOLDER" VARCHAR2(1 BYTE), 
	"ROOT_FOLDER" VARCHAR2(1 BYTE), 
	"CREATE_RELATION" VARCHAR2(1 BYTE), 
	"SHOW_RELATED" VARCHAR2(1 BYTE), 
	"REMOVE_RELATION" VARCHAR2(1 BYTE), 
	"ALLOW_NOTIF" VARCHAR2(1 BYTE), 
	"ALLOW_PREVIEW" VARCHAR2(1 BYTE), 
	"WARN_UPDATE_AVAIL" VARCHAR2(1 BYTE)
   ) ;