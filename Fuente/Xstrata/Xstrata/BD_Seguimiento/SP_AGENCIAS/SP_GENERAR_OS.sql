﻿ DROP PROCEDURE LIBORDAG.SP_WEBAGENCIAS_CREAR_OS
 CREATE PROCEDURE LIBORDAG.SP_WEBAGENCIAS_CREAR_OS ( 
	IN XPNCDTR VARCHAR(10) , 
	IN XPNCDCO VARCHAR(5) , 
	IN XPNCDNG VARCHAR(5) , 
	IN XPNDCPL VARCHAR(5) , 
	IN XPNCDZO VARCHAR(5) , 
	IN XPNCDRG VARCHAR(5) , 
	IN XPNCDOP VARCHAR(5) , 
	IN XDCASCI VARCHAR(10) , 
	IN XDCASSA VARCHAR(20) , 
	IN XDCTPOS CHAR(2) , 
	IN XDCREFE VARCHAR(1024) , 
	IN XFNCDAD VARCHAR(10) , 
	IN XDCPREC CHAR(1) , 
	IN XDNOSPR VARCHAR(10) , 
	IN XDCVIGE CHAR(1) , 
	IN XFNCDPR CHAR(2) , 
	IN XDDVNDE DATE , 
	IN XDCDSME VARCHAR(60) , 
	IN XDCLUGA VARCHAR(60) , 
	IN XDNTPCA VARCHAR(10) , 
	IN XDCINSP CHAR(1) , 
	IN XDNCAM NUMERIC(17, 5) , 
	IN XDNTRAN VARCHAR(10) , 
	IN XDCORIG CHAR(1) , 
	IN XDCCONT VARCHAR(60) , 
	IN XDCREEI CHAR(1) , 
	IN XDCLIGA CHAR(1) , 
	IN XDCFACTU VARCHAR(60) , 
	IN XDCAVIS VARCHAR(10) , 
	IN XDCRECL CHAR(1) , 
	IN XDCOBSE VARCHAR(60) , 
	IN XDCREG CHAR(1) , 
	IN XDNFPAG VARCHAR(10) ,
	IN XDCMOTI VARCHAR(60), 
	OUT XPNNMOS2 CHAR(10) ) 
	DYNAMIC RESULT SETS 1 
	LANGUAGE SQL 
	SPECIFIC LIBORDAG.SP_WEBAGENCIAS_CREAR_OS 
	NOT DETERMINISTIC 
	MODIFIES SQL DATA 
	CALLED ON NULL INPUT 
	SET OPTION  ALWBLK = *ALLREAD , 
	ALWCPYDTA = *OPTIMIZE , 
	COMMIT = *CS , 
	CLOSQLCSR = *ENDMOD , 
	DECRESULT = (31, 31, 00) , 
	DFTRDBCOL = LIBORDAG , 
	DYNDFTCOL = *NO , 
	DYNUSRPRF = *USER , 
	SRTSEQ = *HEX   
	BEGIN 
	 
DECLARE XDNNMAC INTEGER ; 
/*PARA EXTRAER ULTIMO NUMERO DE LA TABLA PCORRELA*/ 
--DECLARE XPNNMOS VARCHAR ( 20 ) ; 
/*NUMERO DE ORDEN DE SERVICIO*/ 
DECLARE XPNANNO SMALLINT ; 
DECLARE	WK_FECHA	NUMERIC ( 10 , 0 )	DEFAULT 0 ; 
DECLARE	WK_HORA		NUMERIC ( 10 , 0 )	DEFAULT 0 ; 
  
  
  
/*PARA OBTENER EL ANIO DE LA FECHA DE HOY*/ 
DECLARE XMEDIO CHAR ( 1 ) ; 
DECLARE XTIREG CHAR ( 1 ) ; 
DECLARE XDCTPOS1 CHAR ( 2 ) ; 
DECLARE XOSPREC VARCHAR ( 10 ) ; 
DECLARE XOSREGU VARCHAR ( 10 ) ; 
DECLARE XPNNMOS VARCHAR ( 10 ) ; 
DECLARE C1 CURSOR FOR SELECT PNNMOS AS NUMERO_OS FROM DORDENES WHERE PNCDTR = XPNCDTR ; SET XPNANNO = YEAR ( CURRENT_DATE ) ; 
  
-- Obtengo la fecha y hora actual 
SET	WK_FECHA = YEAR ( CURRENT DATE ) * 10000 + MONTH ( CURRENT DATE ) * 100 + DAY ( CURRENT DATE ) ; 
SET	WK_HORA = HOUR ( CURRENT TIME ) * 10000 + MINUTE ( CURRENT TIME ) * 100 + SECOND ( CURRENT TIME ) ; 
  
  
IF NOT EXISTS ( SELECT PNNMOS AS NUMERO_OS FROM DORDENES WHERE PNCDTR = XPNCDTR ) THEN 
  
/* OBTENEMOS EL MEDIO */ 
SELECT SUBSTR ( DCDSCD , 1 , 1 ) INTO XMEDIO FROM PCODIGOS WHERE PCTABL = 'VIATRANS' AND PNCDIN = XDNTRAN ; 
  
/* OBTENEMOS TIPO DE REGIMEN */ 
SELECT DCTPRE INTO XTIREG FROM CREGIMEN WHERE PNCDRG = XPNCDRG ; 
SET XDCTPOS1 = XTIREG CONCAT XMEDIO ; 
  
/* OBTENEMOS LA ORDEN DE SERVICIO */ 
CALL LIBORDAG . PIGENEORDE ( XPNANNO , XPNCDCO , XPNCDNG , XPNCDZO , XPNDCPL , XTIREG , XMEDIO , '050' , XPNNMOS ) ; 
  
/* PARA LOS ORDENES PRECEDENTES Y REGULARIZADAS*/ 
IF XDCREG = 'S' THEN 
SET XOSPREC = '' ; 
SET XOSREGU = XDNOSPR ; 
END IF ; 
  
IF XDCPREC = 'S' THEN 
SET XOSPREC = XDNOSPR ; 
SET XOSREGU = '' ; 
END IF ; 
  
SELECT PNCDAS INTO XDCASSA FROM LIBORDAG . DCLIENTE WHERE DCASCI1 = XDCASCI ; 
  
/* INSERTAMOS LA ORDEN DE SERVICIO */ 
INSERT INTO DORDENES ( PNCDTR , PNCDCO , PNCDNG , PNDCPL , PNCDZO , PNNMOS , PNCDRG , PNCDOP , DCASCI , DCASSA , DCTPOS , DDREGI , DCREFE , FNCDAD , DCPREC , 
DNOSPR , DCVIGE , DNOSRG , FNCDPR , DDVNDE , DCDSME , DCLUGA , DNTPCA , DNCAM , DCINSP , DNTRAN , DCORIG , DCCONT , DCREEI , DCLIGA , DCFACTU , 
DCAVIS , DCRECL , DCOBSE , DCDUIDUE , DCFNF , DCESTA , FCHCRT , HRACRT , USRCRT , DCMOTI) 
VALUES ( XPNCDTR , XPNCDCO , XPNCDNG , XPNDCPL , XPNCDZO , XPNNMOS , XPNCDRG , XPNCDOP , XDCASCI , XDCASSA , XDCTPOS1 , CURRENT_TIMESTAMP , XDCREFE , XFNCDAD , XDCPREC , 
XOSPREC , XDCVIGE , XOSREGU , XFNCDPR , XDDVNDE , XDCDSME , XDCLUGA , XDNTPCA , XDNCAM , XDCINSP , XDNTRAN , XDCORIG , XDCCONT , XDCREEI , XDCLIGA , XDCASCI , 
XDCAVIS , XDCRECL , XDCOBSE , '' , 'N' , 'A' , WK_FECHA , WK_HORA , 'VISUAL', XDCMOTI) ; 
  
/* PARA LAS ACTIVIDADES */ /*  ES NECESARIO INICIALIZAR DCOBSE EN BLANCO, */ /*  PARA PODER CONCATENAR LAS OBSERVACIONES DEL SEGUIMIENTO */ 
INSERT INTO RACBASOS ( PNCDTR , PNCDAC , DCOBSE , DCESTA ) SELECT XPNCDTR , PNCDAC , '' , DCESTA FROM DACTIVID WHERE LEFT ( PNCDAC , 1 ) = XTIREG AND DCESTA = 'A' ; 
  
/*PARA GENERAR LOS SEGUIMIENTO DE IMPORTACION*/ 
IF XTIREG = 'I' THEN 
INSERT INTO DSEGIMP ( PNCDTR ) VALUES ( XPNCDTR ) ; 
/* ACTUALIZAR ACTIVIDAD APERTURA */ 
UPDATE RACBASOS SET DDINIA = CURRENT_TIMESTAMP WHERE PNCDTR = XPNCDTR AND PNCDAC = 'I01' ; 
/* ACTUALIZAR ACTIVIDAD SENASA */ 
IF XDCINSP = 'N' THEN 
UPDATE RACBASOS SET DCESTA = 'I' WHERE PNCDTR = XPNCDTR AND PNCDAC = 'I14' ; 
END IF ; 
END IF ; 
  
/*PARA GENERAR LOS SEGUIMIENTO DE EXPORTACION*/ 
IF XTIREG = 'E' THEN 
INSERT INTO DSEGEXP ( PNCDTR ) VALUES ( XPNCDTR ) ; 
/* ACTUALIZAR ACTIVIDAD APERTURA */ 
UPDATE RACBASOS SET DDINIA = CURRENT_TIMESTAMP WHERE PNCDTR = XPNCDTR AND PNCDAC = 'E01' ; 
/* ACTUALIZAR ACTIVIDAD SENASA */ 
IF XDCINSP = 'N' THEN 
UPDATE RACBASOS SET DCESTA = 'I' WHERE PNCDTR = XPNCDTR AND PNCDAC = 'E08' ; 
END IF ; 
END IF ; 
  
UPDATE DORDENES SET 
--DNTPCA =XDNTPCA, 
DNFPAG = XDNFPAG 
WHERE PNCDTR = XPNCDTR ; 
  
  
/* GENERAMOS LOS DOCUMENTOS FALTANTES */ 
INSERT INTO DDOCFALT ( PNCDTR , PNCDDC , DCMDRQ ) SELECT XPNCDTR , PNCDDC , DCMDRE FROM RDOCOPE WHERE PNCDRG = XPNCDRG AND PNCDOP = XPNCDOP ; 
  
/* EXPORTACION AEREA: BORRA BOOKING/CARTA INSTRUCCION */ 
IF XDCTPOS1 = 'EA' THEN 
DELETE FROM DDOCFALT WHERE PNCDTR = XPNCDTR AND PNCDDC IN ( '217' , '218' ) ; 
END IF ; 
  
  
/* EJECUTA SP DE AUDITORIA    */ 
CALL LIBORDAG . PIAUDIT ( 'I' , XPNCDTR , NULL , XPNNMOS ) ; 
  
SET XPNNMOS2 = XPNNMOS ; 
/* CERRAMOS LA TRANSACCION SI TODO FUE CORRECTO */ 
UPDATE CAUDTRAN SET DDFNTR = CURRENT_TIMESTAMP WHERE PNCDTR = XPNCDTR ; 
OPEN C1 ; 
SET RESULT SETS CURSOR C1 ; 
  
ELSE 
  
/* OBTENEMOS EL MEDIO */ 
SELECT SUBSTR ( DCDSCD , 1 , 1 ) INTO XMEDIO FROM PCODIGOS WHERE PCTABL = 'VIATRANS' AND PNCDIN = XDNTRAN ; 
  
/* OBTENEMOS TIPO DE REGIMEN */ 
SELECT DCTPRE INTO XTIREG FROM CREGIMEN WHERE PNCDRG = XPNCDRG ; 
SET XDCTPOS1 = XTIREG CONCAT XMEDIO ; 
  
/* PARA LOS ORDENES PRECEDENTES Y REGULARIZADAS*/ 
IF XDCREG = 'S' THEN 
SET XOSPREC = '' ; 
SET XOSREGU = XDNOSPR ; 
END IF ; 
  
IF XDCPREC = 'S' THEN 
SET XOSPREC = XDNOSPR ; 
SET XOSREGU = '' ; 
END IF ; 
  
SELECT PNCDAS INTO XDCASSA FROM LIBORDAG . DCLIENTE WHERE DCASCI1 = XDCASCI ; 
  
UPDATE DORDENES SET 
--PNCDCO = XPNCDCO, 
--PNCDNG = XPNCDNG, 
--PNDCPL = XPNDCPL, 
--PNCDZO = XPNCDZO,  
--PNCDRG = XPNCDRG , 
--PNCDOP = XPNCDOP, 
DCASCI = XDCASCI , 
DCASSA = XDCASSA , 
DCTPOS = XDCTPOS1 , 
--DDREGI = CURRENT_TIMESTAMP, 
DCREFE = XDCREFE , 
FNCDAD = XFNCDAD , 
DCPREC = XDCPREC , 
DNOSPR = XOSPREC , 
DCVIGE = XDCVIGE , 
DNOSRG = XOSREGU , 
FNCDPR = XFNCDPR , 
DDVNDE = XDDVNDE , 
DCDSME = XDCDSME , 
DCLUGA = XDCLUGA , 
DNTPCA = XDNTPCA , 
DNCAM = XDNCAM , 
DCINSP = XDCINSP , 
DNTRAN = XDNTRAN , 
DCORIG = XDCORIG , 
DCCONT = XDCCONT , 
DCREEI = XDCREEI , 
DCLIGA = XDCLIGA , 
DCFACTU = XDCASCI , 
DCAVIS = XDCAVIS , 
DCRECL = XDCRECL , 
DCOBSE = XDCOBSE , 
DCDUIDUE = '' , 
DCFNF = 'N' , 
DCESTA = 'A' , 
FULTAC = WK_FECHA , 
HULTAC = WK_HORA , 
CULUSA = 'VISUAL',
DCMOTI = XDCMOTI 
WHERE PNCDTR = XPNCDTR ; 
  
SELECT PNNMOS AS NUMERO_OS INTO XPNNMOS FROM DORDENES WHERE PNCDTR = XPNCDTR ; 
  
SET XPNNMOS2 = XPNNMOS ; 
OPEN C1 ; 
SET RESULT SETS CURSOR C1 ; 
  
END IF ; 
  
  
END  

GO

GRANT ALL PRIVILEGES ON PROCEDURE LIBORDAG.SP_WEBAGENCIAS_CREAR_OS TO PUBLIC
