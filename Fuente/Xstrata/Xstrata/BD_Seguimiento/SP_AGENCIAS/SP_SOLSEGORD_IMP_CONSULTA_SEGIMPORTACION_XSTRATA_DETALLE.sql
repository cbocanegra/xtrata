﻿ CREATE PROCEDURE DC@RNSLIB.SP_SOLSEGORD_IMP_CONSULTA_SEGIMPORTACION_XTRATA_DETALLE ( 
	IN IN_NORDSR VARCHAR(10) , 
	IN IN_ZONA VARCHAR(2) ) 
	DYNAMIC RESULT SETS 1 
	LANGUAGE SQL 
	SPECIFIC DC@RNSLIB.SP_SOLSEGORD_IMP_CONSULTA_SEGIMPORTACION_XTRATA_DETALLE 
	NOT DETERMINISTIC 
	MODIFIES SQL DATA 
	CALLED ON NULL INPUT 
	SET OPTION  ALWBLK = *ALLREAD , 
	ALWCPYDTA = *OPTIMIZE , 
	COMMIT = *NONE , 
	CLOSQLCSR = *ENDMOD , 
	DECRESULT = (31, 31, 00) , 
	DFTRDBCOL = *NONE , 
	DYNDFTCOL = *NO , 
	DYNUSRPRF = *USER , 
	SRTSEQ = *HEX   
	BEGIN 
--Declaracion de Variables 
  
DECLARE WK_LIBRERIA VARCHAR ( 10 ) ; 
DECLARE STRSQL VARCHAR ( 6000 ) ; 
  
DECLARE CU_01 CURSOR WITH RETURN FOR S1 ; 
  
SET STRSQL = ' SELECT A.NSERIE,A.NMRODC,A.NMITOC,VALADV,VALIPM,VALIGV, B.VALMRC,C.VALMRC,D.VALMRC
FROM DC@RNSLIB.DUAA1 A
LEFT OUTER JOIN LIBORDAG.DCOSTOS B ON A.NSERIE = B.NSERIE AND A.NORDSR =B.PNNMOS AND B.STPGCT = 2 AND B.CSRVNV = 47
LEFT OUTER JOIN LIBORDAG.DCOSTOS C ON A.NSERIE = C.NSERIE AND A.NORDSR =C.PNNMOS AND C.STPGCT = 2 AND C.CSRVNV = 46
LEFT OUTER JOIN LIBORDAG.DCOSTOS D ON A.NSERIE = D.NSERIE AND A.NORDSR =D.PNNMOS AND D.STPGCT = 2 AND D.CSRVNV = 57
WHERE   A.CCMPN=''FZ'' AND A.TPSRVA LIKE ''I%''
AND A.CZNFCC  =  ''' || IN_ZONA || ''' 
AND  A.NORDSR = ''' || IN_NORDSR || ''' ' ; 
--   
PREPARE S1 FROM STRSQL ; 
OPEN CU_01 ; 
END  ;
