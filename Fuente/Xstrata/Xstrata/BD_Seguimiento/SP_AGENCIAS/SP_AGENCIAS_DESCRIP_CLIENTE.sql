﻿DROP  PROCEDURE DESCASA.AGENCIAS_SP_DESCRIP_CLIENTE
 CREATE PROCEDURE DESCASA.AGENCIAS_SP_DESCRIP_CLIENTE ( 
	IN IN_CODCLI NUMERIC(10)) 
	
	DYNAMIC RESULT SETS 1 
	LANGUAGE SQL 
	SPECIFIC DESCASA.AGENCIAS_SP_DESCRIP_CLIENTE 
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
		 
	 --Declaracion de Variables 
	 
	DECLARE DORDENES VARCHAR ( 25 ) DEFAULT '' ;
	DECLARE DRNSLIB VARCHAR ( 25 ) DEFAULT '' ; 					
	DECLARE CADENA VARCHAR ( 50 ) DEFAULT '' ;			 
	DECLARE STRSQL VARCHAR ( 5000 ) DEFAULT '' ;	 
	DECLARE P1 CURSOR WITH RETURN FOR S1 ; 
		 
	SET DRNSLIB = 'DC@RNSLIB' ; 
	
				 
	SET STRSQL = 'SELECT TCMPCL
		FROM ' || DRNSLIB || '.RZZM01		
		WHERE CCLNT = ' || IN_CODCLI || ' ' ; 
		 							 
	 
PREPARE S1 FROM STRSQL ;	 
OPEN P1 ;	 
			 	 
END  
	
GO

GRANT ALL PRIVILEGES ON PROCEDURE DESCASA.AGENCIAS_SP_DESCRIP_CLIENTE TO PUBLIC

 