﻿DROP   PROCEDURE LIBORDAG.SP_TRANSFERENCIA_CONSULTAEXP4
CREATE PROCEDURE LIBORDAG.SP_TRANSFERENCIA_CONSULTAEXP4 ( 
	IN IN_COMPANIA VARCHAR(2) , 
	IN IN_CODIGO INTEGER , 
	IN IN_TIPO VARCHAR(10) , 
	IN IN_ZONA INTEGER , 
	IN IN_DIV VARCHAR(1) , 
	IN IN_ORDEN VARCHAR(10) , 
	IN IN_TIPOEXP VARCHAR(1) , 
	IN IN_FECHAI VARCHAR(30) , 
	IN IN_FECHAF VARCHAR(30) , 
	IN IN_PERIODO VARCHAR(4) ) 
	DYNAMIC RESULT SETS 1 
	LANGUAGE SQL 
	SPECIFIC LIBORDAG.SP_TRANSFERENCIA_CONSULTAEXP4 
	NOT DETERMINISTIC 
	MODIFIES SQL DATA 
	CALLED ON NULL INPUT 
	SET OPTION  ALWBLK = *ALLREAD , 
	ALWCPYDTA = *OPTIMIZE , 
	COMMIT = *NONE , 
	CLOSQLCSR = *ENDMOD , 
	DECRESULT = (31, 31, 00) , 
	DFTRDBCOL = QGPL , 
	DYNDFTCOL = *NO , 
	DYNUSRPRF = *USER , 
	SRTSEQ = *HEX   
	BEGIN 
  
DECLARE STRSQL VARCHAR ( 10000 ) DEFAULT '' ; 
DECLARE WK_FECHA1 VARCHAR ( 20 ) ; 
DECLARE WK_LIBRERIA VARCHAR ( 10 ) ; 
DECLARE FECHA NUMERIC ( 8 ) DEFAULT 0 ; 
DECLARE P1 CURSOR WITH RETURN FOR S1 ; 
  
SET FECHA = DC@RNSLIB . FECACTUAL ( ) ; 
  
SET WK_FECHA1 = DC@RNSLIB . CDATE ( FECHA ) ; 
SET WK_FECHA1 = WK_FECHA1 CONCAT ' 00:00:00.000000' ; 
--'2011-01-21'  CONCAT ' 00:00:00.000000' ; 
  
IF IN_COMPANIA = 'LZ' THEN 
SET WK_LIBRERIA = 'DC@RNSLIB' ; 
ELSE 
IF IN_COMPANIA = 'AM' THEN 
SET WK_LIBRERIA = 'DC@ALMAPER' ; 
ELSE 
SET WK_LIBRERIA = 'DC@DESLIB' ; 
END IF ; 
END IF ; 
  
IF IN_PERIODO = 1 THEN 
	SET STRSQL = 'SELECT distinct  D.PNNMOS, L.TCMPCL,  D.DCASCI,  D.DCDSME,  D. DCNAVE, S.DDNAVE,
				  D.DCDUIDUE, D.PNCDTR, C.DCDICT, S.DLUGME,  S.DCNMBK, S.DINGME,
				  S.DCAGNV, S.DDCANA, S.DNCANA, S.DDDESP, S.DCOBSE, S.DDSALN, S.DDVNRE, S.DDENBL, E.PCNMDC,
				  S.SESTRG, S.DCDUE, D.PNCDTR, DDRPDC,  
				  CASE  WHEN D.DCTPOS = ''IA'' THEN t.DDNUME
				        WHEN D.DCTPOS = ''IM'' THEN T.DDNUME
						WHEN D.DCTPOS = ''IP'' THEN T.DDNUME
						WHEN D.DCTPOS = ''IT'' THEN T.DDNUME
						WHEN D.DCTPOS = ''EA'' THEN S.DDNDUE
						WHEN D.DCTPOS = ''EM'' THEN S.DDNDUE
						WHEN D.DCTPOS = ''EP'' THEN S.DDNDUE
						WHEN D.DCTPOS = ''ET'' THEN S.DDNDUE END AS DDNUME , 
				  S.DDINME,D.DCREFE,D.DDREGI,D.DCTPOS,
				  D.PNCDRG,D.FNCDAD,D.FNCDPR, D.PNCDOP,D.DCPREC,D.DCVIGE,D.DDVNDE,D.DNCAM,D.DNTRAN,D.DCCONT,
				  D.DNFPAG,D.DNTPCA,D.SENVAS,V.DCDSRG,X.DCDSOP,D.DCDUIDUE,D.DCOBSE
				  FROM LIBORDAG.DORDENES D
				  LEFT OUTER JOIN LIBORDAG.DDOCEMB E ON D.PNCDTR = E.PNCDTR
                  LEFT OUTER JOIN LIBORDAG.DCONTENE C ON D.PNCDTR = C.PNCDTR
                  INNER JOIN DC@RNSLIB.RZZM01 L on D.DCASCI = L.CCLNT
                  LEFT OUTER JOIN LIBORDAG.DSEGEXP S on D.PNCDTR = S.PNCDTR
                  LEFT OUTER JOIN LIBORDAG.DSEGIMP T on D.PNCDTR = T.PNCDTR
                  JOIN LIBORDAG.CREGIMEN V ON D.PNCDRG = V.PNCDRG
                  LEFT JOIN LIBORDAG.COPERACI X ON D.PNCDOP = X.PNCDOP
				  WHERE  D.PNCDCO  = ''' || IN_COMPANIA || '''
				  AND D.PNCDNG = ''' || IN_DIV || ''' 
				  AND D.PNCDZO = ' || IN_ZONA || '
				  AND D.PNNMOS LIKE CONCAT(''%'',CONCAT(''' || IN_ORDEN || ''',''%'')) 
				  AND D.DCESTA = ''A'' ' ; 
  
	IF IN_FECHAI <> '' THEN 
		SET STRSQL = STRSQL || ' AND D.DDREGI >= ''' || IN_FECHAI || '''  and D.DDREGI <= ''' || IN_FECHAF || ''' ' ; 
	ELSE 
		SET STRSQL = STRSQL || ' AND D.DDREGI >= ''' || WK_FECHA1 || ''' ' ; 
	END IF ; 
  
  
--D.DCTPOS LIKE  CONCAT(''' || IN_TIPO || ''',''%'')    AND 
ELSE 
	SET STRSQL = 'SELECT distinct  D.PNNMOS, L.TCMPCL,  D.DCASCI,  D.DCDSME,  D. DCNAVE, S.DDNAVE,
				  D.DCDUIDUE, D.PNCDTR, C.DCDICT, S.DLUGME,  S.DCNMBK, S.DINGME,
				  S.DCAGNV, S.DDCANA, S.DNCANA, S.DDDESP, S.DCOBSE, S.DDSALN, S.DDVNRE, S.DDENBL, E.PCNMDC,
				  S.SESTRG, S.DCDUE, D.PNCDTR, DDRPDC,  
				  CASE  WHEN D.DCTPOS = ''IA'' THEN t.DDNUME
				        WHEN D.DCTPOS = ''IM'' THEN T.DDNUME
						WHEN D.DCTPOS = ''IP'' THEN T.DDNUME
						WHEN D.DCTPOS = ''IT'' THEN T.DDNUME
						WHEN D.DCTPOS = ''EA'' THEN S.DDNDUE
						WHEN D.DCTPOS = ''EM'' THEN S.DDNDUE
						WHEN D.DCTPOS = ''EP'' THEN S.DDNDUE
						WHEN D.DCTPOS = ''ET'' THEN S.DDNDUE END AS DDNUME , 
				  S.DDINME,D.DCREFE,D.DDREGI,D.DCTPOS,
				  D.PNCDRG,D.FNCDAD,D.FNCDPR, D.PNCDOP,D.DCPREC,D.DCVIGE,D.DDVNDE,D.DNCAM,D.DNTRAN,D.DCCONT,
				  D.DNFPAG,D.DNTPCA,D.SENVAS,V.DCDSRG,X.DCDSOP,D.DCDUIDUE,D.DCOBSE
				  FROM LIBORDAG.DORDENES D
				  LEFT OUTER JOIN LIBORDAG.DDOCEMB E ON D.PNCDTR = E.PNCDTR
                  LEFT OUTER JOIN LIBORDAG.DCONTENE C ON D.PNCDTR = C.PNCDTR
                  INNER JOIN DC@RNSLIB.RZZM01 L on D.DCASCI = L.CCLNT
                  LEFT OUTER JOIN LIBORDAG.DSEGEXP S on D.PNCDTR = S.PNCDTR
                  LEFT OUTER JOIN LIBORDAG.DSEGIMP T on D.PNCDTR = T.PNCDTR
                  JOIN LIBORDAG.CREGIMEN V ON D.PNCDRG = V.PNCDRG
                  LEFT JOIN LIBORDAG.COPERACI X ON D.PNCDOP = X.PNCDOP
				  WHERE  D.PNCDCO  = ''' || IN_COMPANIA || '''
				  AND D.PNCDNG = ''' || IN_DIV || ''' AND  D.PNCDZO = ' || IN_ZONA || '
				  AND D.PNNMOS LIKE CONCAT(''%'',CONCAT(''' || IN_ORDEN || ''',''%'')) AND D.DCESTA = ''A'' ' ; 
  
	IF IN_FECHAI <> '' THEN 
		SET STRSQL = STRSQL || ' AND D.DDREGI >= ''' || IN_FECHAI || '''  and D.DDREGI <= ''' || IN_FECHAF || ''' ' ; 
	END IF ; 
  
END IF ; 
  
  
/*   
IF IN_TIPOEXP = 'C' THEN  
SET STRSQL = STRSQL || ' And S.SESTRG = ''C'' ' ;  
END IF ;  
   
IF IN_TIPOEXP = 'E' THEN  
SET STRSQL = STRSQL || ' And S.SESTRG = '''' AND (E.PCNMDC IS NULL OR S.DCDUE IS NULL)  ' ;  
END IF ;  
   
IF IN_TIPOEXP = 'R' THEN  
SET STRSQL = STRSQL || ' And S.SESTRG <> ''C'' AND E.PCNMDC <> '''' AND  S.DCDUE <> ''''' ;  
END IF ;  
   
IF IN_FECHAI > 0 OR IN_FECHAF < 99999999 THEN  
SET STRSQL = STRSQL || ' AND (YEAR(S.DDNAVE) * 10000 + MONTH(S.DDNAVE) * 100 + DAY(S.DDNAVE)) BETWEEN ' || IN_FECHAI || ' AND ' || IN_FECHAF || '' ;  
END IF ;  
  */ 
SET STRSQL = STRSQL || '  ORDER BY D.PNNMOS DESC' ; 
  
PREPARE S1 FROM STRSQL ; 
OPEN P1 ; 
  
END  ;
