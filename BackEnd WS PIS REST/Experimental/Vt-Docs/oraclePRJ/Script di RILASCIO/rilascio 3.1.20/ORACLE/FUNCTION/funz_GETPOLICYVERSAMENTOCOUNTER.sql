CREATE OR REPLACE FUNCTION getPolicyVersamentoCounter(IDDOC VARCHAR)
RETURN VARCHAR IS
	COUNTER NUMBER;
BEGIN

	BEGIN
		SELECT V.NUM_ESECUZIONE_POLICY INTO COUNTER
		FROM DPA_POLICY_PARER P, DPA_VERSAMENTI_POLICY V
		WHERE P.SYSTEM_ID=V.ID_POLICY AND V.ID_PROFILE=IDDOC;
	EXCEPTION
		WHEN NO_DATA_FOUND THEN COUNTER:=NULL;
	END;

RETURN COUNTER;

END getPolicyVersamentoCounter;