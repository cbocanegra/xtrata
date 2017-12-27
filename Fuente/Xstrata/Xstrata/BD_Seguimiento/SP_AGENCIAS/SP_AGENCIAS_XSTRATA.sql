﻿  DROP  PROCEDURE DESCASA.SP_CONSULTA_SEG_WEB_XSTRATA
  
  CREATE PROCEDURE DESCASA.SP_CONSULTA_SEG_WEB_XSTRATA ( 
	IN IN_OS VARCHAR(15) , 
	IN IN_REFER VARCHAR(30) , 
	IN IN_NAVE VARCHAR(25) , 
	IN IN_CANAL VARCHAR(15) , 
	IN IN_BL VARCHAR(25) , 
	IN IN_AFORO VARCHAR(10) , 
	IN IN_RETIRO VARCHAR(10) , 
	IN IN_NUMERACION VARCHAR(10),
	IN IN_CLIENTE VARCHAR(20),
	IN IN_TIP_CANAL VARCHAR(1),
	IN IN_TIP_ORDEN VARCHAR(2)) 
	
	DYNAMIC RESULT SETS 1 
	LANGUAGE SQL 
	SPECIFIC DESCASA.SP_CONSULTA_SEG_WEB_XSTRATA 
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
	DECLARE CREGIMEN VARCHAR ( 25 ) DEFAULT '' ; 
	DECLARE COPERACI VARCHAR ( 25 ) DEFAULT '' ; 
	DECLARE DCLIENTE VARCHAR ( 25 ) DEFAULT '' ; 
	DECLARE DSEGIMP VARCHAR ( 25 ) DEFAULT '' ;	 
	DECLARE DSEGEXP VARCHAR ( 25 ) DEFAULT '' ; 
	DECLARE CODIGOS VARCHAR ( 25 ) DEFAULT '' ; 
	DECLARE DVOLANTE VARCHAR ( 25 ) DEFAULT '' ; 
	DECLARE RACBASOS VARCHAR ( 25 ) DEFAULT '' ; 
	DECLARE DDOCEMB VARCHAR ( 25 ) DEFAULT '' ; 
	DECLARE DAGCARGA VARCHAR ( 25 ) DEFAULT '' ; 
	DECLARE AFORO VARCHAR ( 50 ) DEFAULT '' ; 
	DECLARE RETIRO VARCHAR ( 50 ) DEFAULT '' ; 
	DECLARE NUMERACION VARCHAR ( 50 ) DEFAULT '' ; 
	DECLARE TIPOCANAL VARCHAR ( 50 ) DEFAULT '' ; 
	DECLARE TIPOORDENES VARCHAR ( 50 ) DEFAULT '' ; 
	DECLARE CADENA VARCHAR ( 50 ) DEFAULT '' ;			 
	DECLARE STRSQL VARCHAR ( 5000 ) DEFAULT '' ;	 
	DECLARE P1 CURSOR WITH RETURN FOR S1 ; 
		 
	SET DORDENES = 'LIBORDAG.DORDENES' ; 
	SET CREGIMEN = 'LIBORDAG.CREGIMEN' ; 
	SET COPERACI = 'LIBORDAG.COPERACI' ; 
	SET DCLIENTE = 'LIBORDAG.DCLIENTE' ; 
	SET DSEGIMP = 'LIBORDAG.DSEGIMP' ; 
	SET DSEGEXP = 'LIBORDAG.DSEGEXP' ; 
	SET CODIGOS = 'LIBORDAG.CODIGOS' ; 
	SET DVOLANTE = 'LIBORDAG.DVOLANTE' ; 
	SET RACBASOS = 'LIBORDAG.RACBASOS' ; 
	SET DDOCEMB = 'LIBORDAG.DDOCEMB' ; 
	SET DAGCARGA = 'LIBORDAG.DAGCARGA' ; 
	SET CADENA = 'ORDER BY DDREGI DESC' ; 
				 
	SET STRSQL = 'SELECT DISTINCT  PNNMOS AS ORDEN ,R.PCNMDC AS BL,DCTPOS AS TIPO,
CASE  WHEN A.FNCDPR = ''00'' THEN ''NORMAL''
      WHEN A.FNCDPR = ''01'' THEN ''URGENTE''
      WHEN A.FNCDPR = ''02'' THEN ''SOCORRO''
      WHEN A.FNCDPR = ''10'' THEN ''ANTICIPADO''
      END AS DESPACHO,DCDSME AS MERCADERIA,
      SUBSTR(CAST(A.DDREGI AS VARCHAR(50)),9,2) || ''/'' ||
      SUBSTR(CAST(A.DDREGI AS VARCHAR(50)),6,2) || ''/'' ||
      SUBSTR(CAST(A.DDREGI AS VARCHAR(50)),1,4) AS DDREGI,
      O.DCDSRG AS REGIMEN,P.DCDSOP AS OPERACION,A.DCNAVE AS VAPOR,
      SUBSTR(CAST(E.DDETLG AS VARCHAR(50)),9,2) || ''/'' ||
      SUBSTR(CAST(E.DDETLG AS VARCHAR(50)),6,2) || ''/'' ||
      SUBSTR(CAST(E.DDETLG AS VARCHAR(50)),1,4) AS FECHA_ESTIMADA,
      SUBSTR(CAST(A.DDNAVE AS VARCHAR(50)),9,2) || ''/'' ||
      SUBSTR(CAST(A.DDNAVE AS VARCHAR(50)),6,2) || ''/'' ||
      SUBSTR(CAST(A.DDNAVE AS VARCHAR(50)),1,4) AS FECHA_LLEGADA,
      SUBSTR(CAST(A.DDTDES AS VARCHAR(50)),9,2) || ''/'' ||
      SUBSTR(CAST(A.DDTDES AS VARCHAR(50)),6,2) || ''/'' ||
      SUBSTR(CAST(A.DDTDES AS VARCHAR(50)),1,4) AS TERMINO_DESCARGA,
      D.DCDSAB AS ALMACENES,
      SUBSTR(CAST(E.DDOBVL AS VARCHAR(50)),9,2) || ''/'' ||
      SUBSTR(CAST(E.DDOBVL AS VARCHAR(50)),6,2) || ''/'' ||
      SUBSTR(CAST(E.DDOBVL AS VARCHAR(50)),1,4) AS FECHA_UBICACION,
      SUBSTR(CAST(S.DDFINA AS VARCHAR(50)),9,2) || ''/'' ||
      SUBSTR(CAST(S.DDFINA AS VARCHAR(50)),6,2) || ''/'' ||
      SUBSTR(CAST(S.DDFINA AS VARCHAR(50)),1,4)  AS FECHA_VISTOBUENO,
      SUBSTR(CAST(E.DDNUME AS VARCHAR(50)),9,2) || ''/'' ||
      SUBSTR(CAST(E.DDNUME AS VARCHAR(50)),6,2) || ''/'' ||
      SUBSTR(CAST(E.DDNUME AS VARCHAR(50)),1,4)  AS FECHA_NUMERACION,
      SUBSTR(CAST(E.DDPGDR AS VARCHAR(50)),9,2) || ''/'' ||
      SUBSTR(CAST(E.DDPGDR AS VARCHAR(50)),6,2) || ''/'' ||
      SUBSTR(CAST(E.DDPGDR AS VARCHAR(50)),1,4) AS FECHA_PAGO,
      E.DCBLTO AS TIPO_BULTO,A.DCCANA AS CANAL,
      SUBSTR(CAST(F.DDFINA AS VARCHAR(50)),9,2) || ''/'' ||
      SUBSTR(CAST(F.DDFINA AS VARCHAR(50)),6,2) || ''/'' ||
      SUBSTR(CAST(F.DDFINA AS VARCHAR(50)),1,4) AS DDAFOR,
      SUBSTR(CAST(G.DDINIA AS VARCHAR(50)),9,2) || ''/'' ||
      SUBSTR(CAST(G.DDINIA AS VARCHAR(50)),6,2) || ''/'' ||
      SUBSTR(CAST(G.DDINIA AS VARCHAR(50)),1,4) AS DDPRES,
      SUBSTR(CAST(H.DDINIA AS VARCHAR(50)),9,2) || ''/'' ||
      SUBSTR(CAST(H.DDINIA AS VARCHAR(50)),6,2) || ''/'' ||
      SUBSTR(CAST(H.DDINIA AS VARCHAR(50)),1,4) AS DDLEVA,
      SUBSTR(CAST(I.DDFINA AS VARCHAR(50)),9,2) || ''/'' ||
      SUBSTR(CAST(I.DDFINA AS VARCHAR(50)),6,2) || ''/'' ||
      SUBSTR(CAST(I.DDFINA AS VARCHAR(50)),1,4) AS DDRETI,
      B.NRUC AS NIT,A.DCDUIDUE AS DAM,T.DCOBSE AS OBERVACION,
      E.DCNMMN AS NRO_MANIFIESTO,A.DCREFE AS REFERENCIA,
      SUBSTR(CAST(R.DDRECE AS VARCHAR(50)),9,2) || ''/'' ||
      SUBSTR(CAST(R.DDRECE AS VARCHAR(50)),6,2) || ''/'' ||
      SUBSTR(CAST(R.DDRECE AS VARCHAR(50)),1,4) AS B_L,B.TCMPCL AS NOMB_CLI,
      V.DCDSCD AS CARGA,Q.DCDSCD AS LIQUIDADOR      
 FROM LIBORDAG.DORDENES A
 LEFT OUTER JOIN DC@RNSLIB.RZZM01 B ON A.DCASCI = B.CCLNT
 LEFT OUTER JOIN LIBORDAG.DVOLANTE C ON A.PNCDTR = C.PNCDTR AND C.PNCDDC = ''056''
 LEFT OUTER JOIN LIBORDAG.DSEGIMP  E ON A.PNCDTR = E.PNCDTR
 LEFT OUTER JOIN LIBORDAG.PCODIGOS D ON E.DCTRAL = D.PNCDIN AND D.PCTABL = ''DEPOSITO''
 LEFT OUTER JOIN LIBORDAG.RACBASOS F ON A.PNCDTR = F.PNCDTR AND F.PNCDAC = ''I13''
 LEFT OUTER JOIN LIBORDAG.RACBASOS G ON A.PNCDTR = G.PNCDTR AND G.PNCDAC = ''I16''
 LEFT OUTER JOIN LIBORDAG.RACBASOS H ON A.PNCDTR = H.PNCDTR AND H.PNCDAC = ''I12''
 LEFT OUTER JOIN LIBORDAG.RACBASOS I ON A.PNCDTR = I.PNCDTR AND I.PNCDAC = ''I15''
 LEFT OUTER JOIN LIBORDAG.RACBASOS J ON A.PNCDTR = J.PNCDTR AND J.PNCDAC = ''I14''
 LEFT OUTER JOIN LIBORDAG.CREGIMEN K ON A.PNCDRG = K.PNCDRG AND K.DCTPRE = ''I''
 LEFT OUTER JOIN LIBORDAG.PCODIGOS L ON A.FNCDPR = L.PNCDIN AND L.PCTABL = ''PRIODESP''
 LEFT OUTER JOIN LIBORDAG.RACBASOS M ON A.PNCDTR = M.PNCDTR AND M.PNCDAC = ''I18''
 LEFT OUTER JOIN LIBORDAG.RACBASOS S ON A.PNCDTR = S.PNCDTR AND S.PNCDAC = ''I03''
 LEFT OUTER JOIN LIBORDAG.RACBASOS T ON A.PNCDTR = T.PNCDTR AND T.PNCDAC = ''I23''
 LEFT OUTER JOIN LIBORDAG.DDOCOS   R ON A.PNCDTR=R.PNCDTR AND R.PNCDDC= ''004''  AND R.DCESTA = ''A''
 LEFT OUTER JOIN LIBORDAG.CREGIMEN  O ON A.PNCDRG= O.PNCDRG
 LEFT OUTER JOIN LIBORDAG.COPERACI  P ON A.PNCDOP= P.PNCDOP
 LEFT OUTER JOIN LIBORDAG.PCODIGOS  Q ON Q.PNCDIN= A.FCLIQR AND Q.PCTABL = ''LIQUIDAD''
 LEFT OUTER JOIN DC@RNSLIB.RZIK86   U ON A.PNCDRG = U.CODREG AND A.PNCDOP = U.TPOPRG
 LEFT OUTER JOIN LIBORDAG.PCODIGOS  V ON A.DNTPCA = V.PNCDIN AND V.PCTABL = ''TIPCARGA''
 WHERE  PNCDCO = ''FZ'' AND PNCDNG = ''A'' AND A.PNCDZO = ''1''
 AND PNDCPL = ''1'' AND DCTPOS IN (''IM'', ''IA'')
 AND A.DCESTA = ''A'' AND B.CCLNT = ' || IN_CLIENTE || ' AND A.PNNMOS > ''2012000000'' AND CHAR(PNNMOS) LIKE ''%' || IN_OS || '%'' AND A.DCREFE LIKE ''%' || IN_REFER || '%'' 
 AND A.DCDSME LIKE ''%' || IN_NAVE || '%'' AND V.DCDSCD LIKE ''%' || IN_CANAL || '%'' AND R.PCNMDC LIKE ''%' || IN_BL || '%'' ' ; 
		 
	/* IN_NAVE :::  ES MERCADERIA */		 
	/* IN_CANAL ::: CARGA */
			 
			 
				 
	IF ( IN_AFORO <> ' ' ) THEN 
			SET AFORO = 'AND CAST(F.DDFINA AS DATE)= ''' || IN_AFORO || '''' ;	 
			SET STRSQL = STRSQL || AFORO ; 
		END IF ; 
	 
		IF ( IN_RETIRO <> ' ' ) THEN 
			SET RETIRO = 'AND CAST(I.DDFINA AS DATE)= ''' || IN_RETIRO || '''' ; 
			SET STRSQL = STRSQL || RETIRO ; 
	END IF ; 
	 
	 
	IF ( IN_NUMERACION <> ' ' ) THEN 
			SET NUMERACION = 'AND CAST(E.DDNUME AS DATE)= ''' || IN_NUMERACION || '''' ; 
			SET STRSQL = STRSQL || NUMERACION ; 
	END IF ; 
	
	
	IF ( IN_TIP_CANAL <> 'T' ) THEN 
			SET TIPOCANAL = 'AND A.DCCANA= ''' || IN_TIP_CANAL || '''' ; 
			SET STRSQL = STRSQL || TIPOCANAL ; 
	END IF ; 
	
	IF ( IN_TIP_ORDEN <> 'T' ) THEN 
			SET TIPOORDENES = 'AND A.DCTPOS= ''' || IN_TIP_ORDEN || '''' ; 
			SET STRSQL = STRSQL || TIPOORDENES ; 
	END IF ; 
	
	
		 
		 SET STRSQL = STRSQL || CADENA ; 
	 
	 
	PREPARE S1 FROM STRSQL ;	 
	OPEN P1 ;	 

 
	 
END  
	
GO

GRANT ALL PRIVILEGES ON PROCEDURE DESCASA.SP_CONSULTA_SEG_WEB_XSTRATA TO PUBLIC
