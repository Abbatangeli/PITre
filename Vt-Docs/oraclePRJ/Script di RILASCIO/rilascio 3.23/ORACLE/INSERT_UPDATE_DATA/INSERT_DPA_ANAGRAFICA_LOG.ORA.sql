BEGIN
 -- by Veltri
   utl_insert_chiave_microfunz
      ('IMP_DOC_PREG',
       'Abilita la voce di menu'' Import Documenti Pregressi sotto Documenti',
       NULL,
       'N',
       NULL,
       '3.23',
       NULL
      );

END;
/

Begin 
-- Olivari: inserito nella tabella DPA_Anagrafica_Log le righe per i relativi WS aggiunti ai PIS
Utl_Insert_Chiave_Log(
    'GET_DOC_FILTERS' , --Codice               
    'Restituisce la lista dei filtri disponibili per la ricerca documenti', --Descrizione          
    'DOCUMENTO', --oggetto              
    'GETDOCUMENTFILTERS', --Metodo               
    Null,     --Forza_Aggiornamento  
    '3.23',   -- Myversione_Cd         
    Null      --RFU                  
    );
End;    
/




Begin 
Utl_Insert_Chiave_Log(
'GET_FASC_FILTERS', 'Restituisce la lista dei filtri disponibili per la ricerca fascicoli'
, 'FASCICOLO', 'GETPROJECTFILTERS'	, Null, '3.23', Null);
End;    
/

Begin 
Utl_Insert_Chiave_Log(
'GET_CORR_FILTERS', 'Restituisce la lista dei filtri disponibili per la ricerca corrispondenti'
, 'UTENTE', 'GETDOCUMENTFILTERS'	, Null, '3.23', Null);
End;    
/

Begin 
Utl_Insert_Chiave_Log(
'GET_USER_FILTERS', 'Restituisce la lista dei filtri disponibili per la ricerca utenti'
, 'UTENTE', 'GETUSERFILTERS'		, Null, '3.23', Null);
End;    
/

Begin 
Utl_Insert_Chiave_Log(
'CREATE_DOC_AND_ADD_IN_FASC', 'Crea un nuovo documento e lo inserisce nel fascicolo'
, 'DOCUMENTO', 'CREATEDOCUMENTANDADDINPROJECT', Null, '3.23', Null);
End;    
/

Begin 
-- MEV Attivazione Cessione Diritti
-- by Iacozzilli Giordano.
Utl_Insert_Chiave_Log(
'CESSIONE_DIRITTI_NO_OWNER', 'Cedo i diritti di un doc anche se non ne sono l owner'
, 'DOCUMENTO', 'EXECSENDERRIGTHSNOOWNER', Null, '3.23', Null);
--**************************************************************************--

End;    
/


Begin 
-- by Lorusso
Utl_Insert_Chiave_Log(
'AMM_MODIFICA_CHIAVI', 'Modifica chiavi di configurazione'
, 'AOO', 'AMMMODCHIAVI', Null, '3.23', Null);
End;    
/
