﻿begin
  Utl_Insert_Chiave_Config('BE_CONS_VER_LEG_GG_NOTIFICHE','Intervallo in giorni dalla scadenza delle verifiche di leggibilità su documenti in Conservazione per inviare notifiche nel Centro Servizi '  -- Codice, Descrizione
  ,'10','B','1'        --Valore               ,Tipo_Chiave        ,Visibile
  ,'1','0','CS 1.5'   --Modificabile         ,Globale            ,myversione_CD
  ,NULL, NULL, NULL);  --Codice_Old_Webconfig ,Forza_Update_Valore,RFU
  end;
  
UPDATE dpa_chiavi_configurazione
SET
cha_conservazione='1'
WHERE
var_codice='BE_CONS_VER_LEG_GG_NOTIFICHE';
