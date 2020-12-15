-- INSERIMENTO EVENTI DI LIBRO FIRMA
INSERT INTO DPA_ANAGRAFICA_EVENTI (ID_EVENTO, VAR_COD_AZIONE, DESCRIZIONE, CHA_TIPO_EVENTO, Gruppo) 
VALUES ((select MAX(ID_EVENTO) FROM DPA_ANAGRAFICA_EVENTI) + 1,'DOCUMENTOSPEDISCI','Spedizione documento','E','EVENT');

INSERT INTO DPA_ANAGRAFICA_EVENTI (ID_EVENTO, VAR_COD_AZIONE, DESCRIZIONE, CHA_TIPO_EVENTO, Gruppo) 
VALUES ((select MAX(ID_EVENTO) FROM DPA_ANAGRAFICA_EVENTI) + 1,'PROCESSO_FIRMA_ERRORE_PASSO_AUTOMATICO','Errore esecuzione passo automatico.','N','ERRORE_PASSO_AUTOMATICO');

--INSERT INTO DPA_ANAGRAFICA_EVENTI (ID_EVENTO, VAR_COD_AZIONE, DESCRIZIONE, CHA_TIPO_EVENTO, Gruppo) 
--VALUES ((select MAX(ID_EVENTO) FROM DPA_ANAGRAFICA_EVENTI) + 1,'DESTINATARI_NON_INTEROPERANTI','Presenza di destinatati non interoperanti nella spedizione.','N','DESTINATARI_NON_INTEROPERANTI');

INSERT INTO DPA_ANAGRAFICA_EVENTI (ID_EVENTO, VAR_COD_AZIONE, DESCRIZIONE, CHA_TIPO_EVENTO, Gruppo) 
VALUES ((select MAX(ID_EVENTO) FROM DPA_ANAGRAFICA_EVENTI) + 1,'CONCLUSIONE_PROCESSO_AUTOMATICO_LF','Conclusione del processo di firma.','N','CONCLUSIONE_PROCESSO_LF');


-- INSERIMENTO ANAGRAFICA LOG ---

-- CONCLUSIONE PROCESSO AUTOMATICO ---
INSERT INTO DPA_ANAGRAFICA_LOG ( SYSTEM_ID,  VAR_CODICE,  VAR_DESCRIZIONE,  VAR_OGGETTO, VAR_METODO, MULTIPLICITY, ID_AMM, NOTIFICATION, CONFIGURABLE, NOTIFICATION_RECIPIENTS, COLOR )
VALUES( seq.nextval, 'CONCLUSIONE_PROCESSO_AUTOMATICO_LF', 'Conclusione del processo automatico di firma del documento', 'DOCUMENTO', 'CONCLUSIONE_PROCESSO_AUTOMATICO_LF', 'ONE', null, '1', '1', 'USERS_ROLE_IN_PROCESS', 'BLUE');
  
  
INSERT INTO dpa_event_type_assertions 
	(SELECT seq.NEXTVAL, L.SYSTEM_ID, L.var_descrizione, a.system_id, a.var_codice_amm, 'AMM', 'I', '1', a.system_id
	 FROM DPA_ANAGRAFICA_LOG L, DPA_AMMINISTRA A
	 WHERE L.VAR_CODICE = 'CONCLUSIONE_PROCESSO_AUTOMATICO_LF');
  
INSERT INTO DPA_LOG_ATTIVATI (SYSTEM_ID_ANAGRAFICA, ID_AMM, NOTIFY )
SELECT L.SYSTEM_ID, A.SYSTEM_ID, 'CON'
FROM DPA_ANAGRAFICA_LOG L, DPA_AMMINISTRA A
WHERE L.VAR_CODICE = 'CONCLUSIONE_PROCESSO_AUTOMATICO_LF';


-- ERRORE PROCESSO AUTOMATICO ---
INSERT INTO DPA_ANAGRAFICA_LOG( SYSTEM_ID, VAR_CODICE, VAR_DESCRIZIONE, VAR_OGGETTO, VAR_METODO, MULTIPLICITY, ID_AMM, NOTIFICATION, CONFIGURABLE,  NOTIFICATION_RECIPIENTS, COLOR )
VALUES( seq.nextval, 'PROCESSO_FIRMA_ERRORE_PASSO_AUTOMATICO', 'Errore di esecuzione del passo automatico sul documento', 'DOCUMENTO', 'PROCESSO_FIRMA_ERRORE_PASSO_AUTOMATICO', 'ONE',  null, '1', '1','USERS_ROLE_IN_PROCESS', 'RED');

  
INSERT INTO DPA_LOG_ATTIVATI ( SYSTEM_ID_ANAGRAFICA, ID_AMM,  NOTIFY )
SELECT L.SYSTEM_ID, A.SYSTEM_ID, 'OBB'
FROM DPA_ANAGRAFICA_LOG L, DPA_AMMINISTRA A
WHERE L.VAR_CODICE = 'PROCESSO_FIRMA_ERRORE_PASSO_AUTOMATICO';



-- PRESENZA DESTINATARI NON INTEROPERANTI ---
INSERT INTO DPA_ANAGRAFICA_LOG( SYSTEM_ID, VAR_CODICE, VAR_DESCRIZIONE, VAR_OGGETTO, VAR_METODO, MULTIPLICITY, ID_AMM, NOTIFICATION, CONFIGURABLE,  NOTIFICATION_RECIPIENTS, COLOR )
VALUES( seq.nextval, 'PROCESSO_FIRMA_DESTINATARI_NON_INTEROP', 'Presenza di destinatati non interoperanti nella spedizione del documento', 'DOCUMENTO', 'PROCESSO_FIRMA_DESTINATARI_NON_INTEROP', 'ONE',  null, '1', '1','USERS_ROLE_IN_PROCESS', 'BLUE');

  
INSERT INTO DPA_LOG_ATTIVATI ( SYSTEM_ID_ANAGRAFICA, ID_AMM,  NOTIFY )
SELECT L.SYSTEM_ID, A.SYSTEM_ID, 'OBB'
FROM DPA_ANAGRAFICA_LOG L, DPA_AMMINISTRA A
WHERE L.VAR_CODICE = 'PROCESSO_FIRMA_DESTINATARI_NON_INTEROP';




--INSERIMENTO NUOVA RAGIONE NON NOTIFICABILE
INSERT INTO DPA_RAGIONE_TRASM (SYSTEM_ID, VAR_DESC_RAGIONE, CHA_TIPO_RAGIONE, CHA_VIS, CHA_TIPO_DIRITTI, CHA_TIPO_DEST, CHA_RISPOSTA, VAR_NOTE, CHA_EREDITA, CHA_TIPO_RISPOSTA, ID_AMM, VAR_NOTIFICA_TRASM, CHA_CEDE_DIRITTI, CHA_MANTIENI_LETT, CHA_MANTIENI_SCRITT, CHA_RAG_SISTEMA, CHA_PROC_RES )
(SELECT SEQ.NEXTVAL, 'PASSO_DI_PROCESSO_AUTOMATICO', 'N', '0','W', 'T',	'0', 'Ragione di trasmissione di sistema per l''evento di passo di processo automatico', '0', 'C',	a.system_id, 'NN',	'N', 0,	0,	0, 'EVENT_AUTOMATICO'
  FROM dpa_amministra a
);
INSERT INTO DPA_RAGIONE_TRASM (SYSTEM_ID, VAR_DESC_RAGIONE, CHA_TIPO_RAGIONE, CHA_VIS, CHA_TIPO_DIRITTI, CHA_TIPO_DEST, CHA_RISPOSTA, VAR_NOTE, CHA_EREDITA, CHA_TIPO_RISPOSTA, ID_AMM, VAR_NOTIFICA_TRASM, CHA_CEDE_DIRITTI, CHA_MANTIENI_LETT, CHA_MANTIENI_SCRITT, CHA_RAG_SISTEMA, CHA_PROC_RES )
VALUES (SEQ.NEXTVAL, 'PASSO_DI_PROCESSO_AUTOMATICO', 'N', '0','W', 'T',	'0', 'Ragione di trasmissione di sistema per l''evento di passo di processo automatico', '0', 'C',	null, 'NN',	'N', 0,	0,	0, 'EVENT_AUTOMATICO'
);


UPDATE  DPA_LOG_ATTIVATI I
SET NOTIFY = 'NN'
WHERE SYSTEM_ID_ANAGRAFICA IN (SELECT SYSTEM_ID FROM DPA_ANAGRAFICA_LOG WHERE VAR_CODICE LIKE '%PASSO_DI_PROCESSO_AUTOMATICO%');  
