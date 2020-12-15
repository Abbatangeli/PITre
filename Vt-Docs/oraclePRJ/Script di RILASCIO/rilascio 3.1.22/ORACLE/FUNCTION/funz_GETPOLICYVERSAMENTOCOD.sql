create or replace 
FUNCTION getPolicyVersamentoCod(IDDOC VARCHAR)
RETURN VARCHAR IS
	CODPOLICY VARCHAR(100);
  
  item VARCHAR(100);
  
  CURSOR cur IS
  SELECT P.VAR_CODICE
  FROM DPA_POLICY_PARER P, DPA_VERSAMENTI_POLICY V
  WHERE P.SYSTEM_ID=V.ID_POLICY AND V.ID_PROFILE=IDDOC
  ORDER BY V.DATA_ESECUZIONE_POLICY
  ;
  
BEGIN
CODPOLICY := NULL;

OPEN cur;
LOOP
FETCH cur INTO item;
EXIT WHEN cur%NOTFOUND;

IF(CODPOLICY=NULL) THEN
CODPOLICY := item;
ELSE
CODPOLICY := CODPOLICY || item || '; ';
END IF;

END LOOP;

/*	BEGIN
		SELECT P.VAR_CODICE INTO CODPOLICY
		FROM DPA_POLICY_PARER P, DPA_VERSAMENTI_POLICY V
		WHERE P.SYSTEM_ID=V.ID_POLICY AND V.ID_PROFILE=IDDOC;
	EXCEPTION
		WHEN NO_DATA_FOUND THEN CODPOLICY:=NULL;
	END;
*/
RETURN SUBSTR(CODPOLICY,1,LENGTH(CODPOLICY)-2);

END getPolicyVersamentoCod;