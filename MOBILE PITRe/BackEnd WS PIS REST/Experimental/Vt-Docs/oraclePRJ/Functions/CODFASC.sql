--------------------------------------------------------
--  DDL for Function CODFASC
--------------------------------------------------------

  CREATE OR REPLACE FUNCTION "ITCOLL_6GIU12"."CODFASC" (docId INT)
RETURN varchar IS risultato varchar(2000);
BEGIN
Select codice into risultato from (
SELECT DISTINCT A.DESCRIPTION as codice
FROM PROJECT A
WHERE A.CHA_TIPO_PROJ = 'F'
AND A.SYSTEM_ID IN (SELECT A.ID_FASCICOLO FROM PROJECT A, PROJECT_COMPONENTS B WHERE A.SYSTEM_ID=B.PROJECT_ID AND B.LINK=docId)
)where rownum=1 ;
RETURN risultato;
END codFasc; 

/
