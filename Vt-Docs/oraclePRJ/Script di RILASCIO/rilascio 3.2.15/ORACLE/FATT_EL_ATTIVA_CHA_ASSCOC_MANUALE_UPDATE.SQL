UPDATE 
DPA_TIPO_ATTO 
SET CHA_ASSOC_MANUALE = 1 
WHERE SYSTEM_ID = 
(SELECT SYSTEM_ID FROM DPA_TIPO_ATTO WHERE UPPER(VAR_DESC_ATTO) = 'FATTURA ELETTRONICA ATTIVA')