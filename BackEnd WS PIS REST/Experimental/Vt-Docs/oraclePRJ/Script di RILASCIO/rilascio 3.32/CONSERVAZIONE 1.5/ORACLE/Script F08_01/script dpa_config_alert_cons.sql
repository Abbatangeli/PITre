CREATE TABLE DPA_CONFIG_ALERT_CONS
(
SYSTEM_ID						NUMBER	NOT NULL,
ID_AMM							NUMBER,

VAR_SERVER_SMTP						VARCHAR2(64 BYTE),
NUM_PORTA_SMTP						NUMBER,
CHA_SMTP_SSL						CHAR(1 BYTE),
VAR_USER_MAIL						VARCHAR2(128 BYTE),
VAR_PWD_MAIL						VARCHAR2(128 BYTE),
VAR_MAIL_NOTIFICA					CHAR(500 BYTE),
VAR_MAIL_DESTINATARIO				VARCHAR2(128 BYTE),

CHA_ALERT_LEGGIBILITA_SCADENZA			CHAR(1 BYTE),
NUM_LEGG_SCADENZA_TERMINE			NUMBER,
NUM_LEGG_SCADENZA_TOLLERANZA		NUMBER,

CHA_ALERT_LEGGIBILITA_MAX_DOC			CHAR(1 BYTE),
NUM_LEGGIBILITA_MAX_DOC_PERC			NUMBER,

CHA_ALERT_LEGGIBILITA_SING		CHAR(1 BYTE),
NUM_LEGG_SING_MAX_OPER		NUMBER,
NUM_LEGG_SING_PERIODO_MON	NUMBER,

CHA_ALERT_DOWNLOAD			CHAR(1 BYTE),
NUM_DOWNLOAD_MAX_OPER				NUMBER,
NUM_DOWNLOAD_PERIODO_MON			NUMBER,

CHA_ALERT_SFOGLIA			CHAR(1 BYTE),
NUM_SFOGLIA_MAX_OPER				NUMBER,
NUM_SFOGLIA_PERIODO_MON			NUMBER

)