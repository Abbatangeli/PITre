-- =============================================
-- Author:		FRANCESCO FONZO
-- Create date: 22/02/2013
-- Description:	CONVERSIONE DA ORACLE A SQL SERVER
-- INSERT_DPA_ANAGRAFICA_LOG
-- =============================================

SET IDENTITY_INSERT DOCSADM.DPA_ANAGRAFICA_LOG ON

EXECUTE DOCSADM.UTL_INSERT_CHIAVE_LOG	'GET_DOC_FILTERS' , --CODICE               
						'RESTITUISCE LA LISTA DEI FILTRI DISPONIBILI PER LA RICERCA DOCUMENTI', --DESCRIZIONE          
						'DOCUMENTO', --OGGETTO              
						'GETDOCUMENTFILTERS', --METODO               
						NULL,     --FORZA_AGGIORNAMENTO  
						'3.23',   -- MYVERSIONE_CD         
						NULL      --RFU                  



EXECUTE DOCSADM.UTL_INSERT_CHIAVE_LOG 'GET_FASC_FILTERS', 'RESTITUISCE LA LISTA DEI FILTRI DISPONIBILI PER LA RICERCA FASCICOLI', 'FASCICOLO', 'GETPROJECTFILTERS'	, NULL, '3.23', NULL


EXECUTE DOCSADM.UTL_INSERT_CHIAVE_LOG 'GET_CORR_FILTERS', 'RESTITUISCE LA LISTA DEI FILTRI DISPONIBILI PER LA RICERCA CORRISPONDENTI', 'UTENTE', 'GETDOCUMENTFILTERS'	, NULL, '3.23', NULL


EXECUTE DOCSADM.UTL_INSERT_CHIAVE_LOG 'GET_USER_FILTERS', 'RESTITUISCE LA LISTA DEI FILTRI DISPONIBILI PER LA RICERCA UTENTI', 'UTENTE', 'GETUSERFILTERS', NULL, '3.23', NULL


EXECUTE DOCSADM.UTL_INSERT_CHIAVE_LOG 'CREATE_DOC_AND_ADD_IN_FASC', 'CREA UN NUOVO DOCUMENTO E LO INSERISCE NEL FASCICOLO', 'DOCUMENTO', 'CREATEDOCUMENTANDADDINPROJECT', NULL, '3.23', NULL


EXECUTE DOCSADM.UTL_INSERT_CHIAVE_LOG 'CESSIONE_DIRITTI_NO_OWNER', 'CEDO I DIRITTI DI UN DOC ANCHE SE NON NE SONO L OWNER', 'DOCUMENTO', 'EXECSENDERRIGTHSNOOWNER', NULL, '3.23', NULL


EXECUTE DOCSADM.UTL_INSERT_CHIAVE_LOG 'AMM_MODIFICA_CHIAVI', 'MODIFICA CHIAVI DI CONFIGURAZIONE', 'AOO', 'AMMMODCHIAVI', NULL, '3.23', NULL