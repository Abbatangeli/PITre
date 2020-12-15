ALTER TABLE DPA_TIPO_FIRMA
 DROP PRIMARY KEY CASCADE;

DROP TABLE DPA_TIPO_FIRMA CASCADE CONSTRAINTS;

CREATE TABLE DPA_TIPO_FIRMA
(
  SYSTEM_ID       NUMBER(10),
  CHA_TIPO_FIRMA  VARCHAR2(2 BYTE),
  VAR_DESCRIZIONE VARCHAR2(256 BYTE)
)

LOGGING 
NOCOMPRESS 
NOCACHE
NOPARALLEL
MONITORING;

ALTER TABLE DPA_TIPO_FIRMA ADD (
  PRIMARY KEY (SYSTEM_ID)
  ENABLE VALIDATE);

DELETE DPA_TIPO_FIRMA;

INSERT INTO DPA_TIPO_FIRMA
VALUES (1, 'N', 'Nessuna firma');
INSERT INTO DPA_TIPO_FIRMA
VALUES (2, 'E', 'Firma elettronica');
INSERT INTO DPA_TIPO_FIRMA
VALUES (3, 'P', 'Firma digitale PADES');
INSERT INTO DPA_TIPO_FIRMA
VALUES (4, 'C', 'Firma digitale CADES');
INSERT INTO DPA_TIPO_FIRMA
VALUES (5, 'T', 'Firma TSD');
INSERT INTO DPA_TIPO_FIRMA
VALUES (6, 'X', 'Firma XADES');
INSERT INTO DPA_TIPO_FIRMA
VALUES (7, 'PE', 'Firma PADES ed elettornica');
INSERT INTO DPA_TIPO_FIRMA
VALUES (8, 'CE', 'Firma CADES ed elettornica');
INSERT INTO DPA_TIPO_FIRMA
VALUES (9, 'XE', 'Firma XADES ed elettornica');
INSERT INTO DPA_TIPO_FIRMA
VALUES (10, 'TE', 'Firma TSD ed elettornica');
COMMIT;