CREATE OR REPLACE FUNCTION getPolicyVersamentoCod(IDDOC VARCHAR)
RETURN VARCHAR IS
	CODPOLICY VARCHAR(100);
BEGIN

	BEGIN
		SELECT P.VAR_CODICE INTO CODPOLICY
		FROM DPA_POLICY_PARER P, DPA_VERSAMENTI_POLICY V
		WHERE P.SYSTEM_ID=V.ID_POLICY AND V.ID_PROFILE=IDDOC;
	EXCEPTION
		WHEN NO_DATA_FOUND THEN CODPOLICY:=NULL;
	END;

RETURN CODPOLICY;

END getPolicyVersamentoCod;