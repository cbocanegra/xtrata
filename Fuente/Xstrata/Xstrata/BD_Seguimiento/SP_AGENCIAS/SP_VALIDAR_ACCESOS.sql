﻿ DROP  PROCEDURE DC@RNSLIB.SP_VALIDAR_ACCESOS
 
 CREATE PROCEDURE DC@RNSLIB.SP_VALIDAR_ACCESOS ( 
	IN USUARIO VARCHAR(10) , 
	IN CLAVE VARCHAR(32) , 
	IN IDAPLIC VARCHAR(2) ) 
	DYNAMIC RESULT SETS 1 
	LANGUAGE SQL 
	SPECIFIC DC@RNSLIB.SP_VALIDAR_ACCESOS
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
	 
	DECLARE SQLSTMT CHARACTER ( 512 ) ; 
	 
	DECLARE C1 CURSOR WITH RETURN FOR		 
  
SELECT A . CCMPN , A . CDVSN , A . CPLNDV , A . CLBRCM , 
		CASE A . CPLNDV WHEN 0 THEN 0 ELSE 1 END AS STADO, C . TCMAPL , A . CCLNT 
	FROM DC@RNSLIB . MMUSWR A 
	LEFT OUTER JOIN DC@RNSLIB . MMUSRA B ON A . MMCUSR = B . MMCUSR 
	INNER JOIN DC@RNSLIB . MMAPLIC C ON B . CDGAPL = C . CDGAPL 
	WHERE A . MMCUSR = USUARIO AND A . MMCPUS = CLAVE AND B . CDGAPL = IDAPLIC ;	 
	OPEN C1 ; 
  

--PREPARE S1 FROM STRSQL ;	 
--OPEN P1 ;


END  
	
GO


GRANT ALL PRIVILEGES ON PROCEDURE DC@RNSLIB.SP_VALIDAR_ACCESOS TO PUBLIC