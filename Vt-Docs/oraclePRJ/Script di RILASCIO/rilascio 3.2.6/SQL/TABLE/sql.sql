CREATE TABLE DPA_REPORT_VERSAMENTO
(
ID_AMM					INTEGER,
VAR_FIXED_RECIPIENTS	VARCHAR(2000),
CHA_ATTIVA_STRUTTURA	VARCHAR(1),
CHA_MAIL_STRUTTURA		VARCHAR(200),
MAIL_SUBJECT			VARCHAR(100),
MAIL_BODY				VARCHAR(2000),
VAR_SMTP_SERVER			VARCHAR(128),
VAR_MAIL_FROM			VARCHAR(128),
VAR_USERNAME_SMTP		VARCHAR(128),
VAR_PASSWORD_SMTP		VARCHAR(128),
VAR_PORT_SMTP			INTEGER,
CHA_SSL					CHAR(1)
)

ALTER TABLE DPA_EL_REGISTRI ADD
(
ID_UTENTE_RESP 			INTEGER
)

ALTER TABLE DPA_POLICY_PARER ADD 
(
CHA_ESCLUDI_FATTURE 	VARCHAR(1)
)