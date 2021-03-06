﻿CREATE PROCEDURE DC@RNSLIB.SP_SOLSEGORD_IMP_CONSULTA_SEGIMPORTACION_XTRATA_COSTOS ( 
	IN IN_NORDSR VARCHAR(10) , 
	IN IN_ZONA VARCHAR(2) , 
	IN IN_TIPO VARCHAR(2) ) 
	DYNAMIC RESULT SETS 1 
	LANGUAGE SQL 
	SPECIFIC DC@RNSLIB.SP_SOLSEGORD_IMP_CONSULTA_SEGIMPORTACION_XTRATA_COSTOS 
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
DECLARE WK_IGTOOP NUMERIC ( 18 , 5 ) ; 
DECLARE WK_IGTODT NUMERIC ( 18 , 5 ) ; 
DECLARE WK_ICTOAD NUMERIC ( 18 , 5 ) ; 
DECLARE WK_VALOR NUMERIC ( 18 , 5 ) ; 
  
DECLARE CU_01 CURSOR WITH RETURN FOR S1 ; 
  
--DECLARE GLOBAL TEMPORARY TABLE SESSION .COSTO (	CCODCOS		VARCHAR ( 6 ) ,	CDESCOS		VARCHAR ( 50 ) ,		NVALORI		NUMERIC ( 18 , 6 )  ) WITH REPLACE NOT LOGGED ; 
  
  
SET STRSQL = ' SELECT CSRVNV,NOMVAR, VALMRC
FROM  DC@RNSLIB.ZZ202201 A RIGHT  OUTER JOIN LIBORDAG.CCOSTOS  B ON  B.CSRVNV =A.NRVARB
WHERE PNNMOS = ''' || IN_NORDSR || '''  AND CZNFCC = ''' || IN_ZONA || '''  AND CPLNDV = ''1''
AND TPSRVA = ''' || IN_TIPO || ''' AND A.NRVARB IN (46,47,57) ' ; 
  
PREPARE S1 FROM STRSQL ; 
OPEN CU_01 ; 
END  ;
 