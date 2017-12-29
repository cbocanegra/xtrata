Imports System.Data
Imports IBM.Data.DB2.iSeries
Imports System.Collections.Generic
Imports System.Text
Imports System.Data.Common
Imports BE = Empleado.Entidad
Imports Entidad = Emp_Entidad

Public Class DXstrata
    Public Shared Function FillXstrata(ByVal Os As String, ByVal Refer As String, ByVal Nave As String, ByVal Canal As String, ByVal Bll As String, ByVal Aforo As String, ByVal Retiro As String, ByVal Numeracion As String, ByVal CodigoCli As String, ByVal TipoCanal As String, ByVal Tipoorden As String, ByVal EstadoOrdenes As String) As List(Of Entidad.XSTRATA)

        Dim Sql As String
        'Sql = "select IdProveedor,nombre,representante,direccion, ciudad, departamento from proveedor where IdProveedor ='" & cod & "'"

        Dim Recup As New DataTable
        ' Dim Lectura As DbDataReader = Nothing
        Dim Aforos, Retiros, Order As String
        Order = " ORDER BY A.DDREGI DESC"

        'Dim sql As String

        'Sql = " SELECT A.PNNMOS AS ORDEN, A.DCTPOS AS TIPO, CASE WHEN A.FNCDPR = '00' " & _
        '       " THEN 'Normal' WHEN A.FNCDPR = '01' THEN 'Urgente' WHEN A.FNCDPR = '02' " & _
        '       " THEN 'Socorro' WHEN A.FNCDPR = '10' THEN 'Anticipado' END AS SITUACION, " & _
        '       " SUBSTR(CAST(A.DDREGI AS VARCHAR(50)),9,2) || '/' ||" & _
        '       " SUBSTR(CAST(A.DDREGI AS VARCHAR(50)),6,2) || '/' ||" & _
        '       " SUBSTR(CAST(A.DDREGI AS VARCHAR(50)),1,4) AS DDREGI, B.DCDSRG AS REGIMEN, C.DCDSOP AS OPERACION, G.DCDSCD AS CARGA, " & _
        '       " H.DCDSCD AS CANAL, D.DCNMCL AS CLIENTE, A.DCREFE AS REFERENCIA, A.DCDSME AS MERCADERIA, " & _
        '       " P.DCNAVE AS NAVE, SUBSTR(CAST(P.DDNAVE AS VARCHAR(50)),9,2) || '/' || " & _
        '       " SUBSTR(CAST(P.DDNAVE AS VARCHAR(50)),6,2) || '/' || " & _
        '       " SUBSTR(CAST(P.DDNAVE AS VARCHAR(50)),1,4)  AS ESTIMADO, " & _
        '       " SUBSTR(CAST(I.DDNAVE AS VARCHAR(50)),9,2) || '/' ||" & _
        '       " SUBSTR(CAST(I.DDNAVE AS VARCHAR(50)),6,2) || '/' ||" & _
        '       " SUBSTR(CAST(I.DDNAVE AS VARCHAR(50)),1,4) AS LLEGADA, " & _
        '       " SUBSTR(CAST(I.DDTDES AS VARCHAR(50)),9,2) || '/' ||" & _
        '       " SUBSTR(CAST(I.DDTDES AS VARCHAR(50)),6,2) || '/' ||" & _
        '       " SUBSTR(CAST(I.DDTDES AS VARCHAR(50)),1,4)  AS TERMINO, " & _
        '       " J.DCDSAB AS TERMINAL, P.PCNMDC AS BL, I.DCNMMA AS MANIFIESTO, I.DCNMDM AS NUMERO, " & _
        '       " Q.DCDSCD AS AGMARITIMO, S.DCDSCD AS AGCARGA, A.DCDUIDUE AS DUA, " & _
        '       " CASE WHEN SUBSTR(A.DCTPOS, 1, 1) = 'I' THEN " & _
        '       " SUBSTR(CAST(E.DDNUME AS VARCHAR(50)),9,2) || '/' ||" & _
        '       " SUBSTR(CAST(E.DDNUME AS VARCHAR(50)),6,2) || '/' ||" & _
        '       " SUBSTR(CAST(E.DDNUME AS VARCHAR(50)),1,4)  WHEN SUBSTR(A.DCTPOS, 1, 1) = 'E' " & _
        '       " THEN SUBSTR(CAST(F.DDNDUE AS VARCHAR(50)),9,2) || '/' ||" & _
        '       " SUBSTR(CAST(F.DDNDUE AS VARCHAR(50)),6,2) || '/' ||" & _
        '       " SUBSTR(CAST(F.DDNDUE AS VARCHAR(50)),1,4)  END AS NUMERACION, " & _
        '       " SUBSTR(CAST(E.DDPGDR AS VARCHAR(50)),9,2) || '/' ||" & _
        '       " SUBSTR(CAST(E.DDPGDR AS VARCHAR(50)),6,2) || '/' ||" & _
        '       " SUBSTR(CAST(E.DDPGDR AS VARCHAR(50)),1,4) AS PAGO, " & _
        '       " E.DMTTDR AS MONTO, " & _
        '       " SUBSTR(CAST(K.DDINIA AS VARCHAR(50)),9,2) || '/' ||" & _
        '       " SUBSTR(CAST(K.DDINIA AS VARCHAR(50)),6,2) || '/' ||" & _
        '       " SUBSTR(CAST(K.DDINIA AS VARCHAR(50)),1,4)  AS SENASA, " & _
        '       " SUBSTR(CAST(L.DDFINA AS VARCHAR(50)),9,2) || '/' ||" & _
        '       " SUBSTR(CAST(L.DDFINA AS VARCHAR(50)),6,2) || '/' ||" & _
        '       " SUBSTR(CAST(L.DDFINA AS VARCHAR(50)),1,4)  AS AFORO, " & _
        '       " CAST(M.DDINIA AS DATE) AS PRESENTACION,  " & _
        '       " N.DDINIA AS LEVANTE, O.DDFINA AS RETIRO " & _
        '       " FROM LIBORDAG.DORDENES A " & _
        '       " JOIN LIBORDAG.CREGIMEN B ON A.PNCDRG = B.PNCDRG " & _
        '       " JOIN LIBORDAG.COPERACI C ON A.PNCDOP = C.PNCDOP " & _
        '       " JOIN LIBORDAG.DCLIENTE D ON A.DCASCI = D.DCASCI  " & _
        '       " LEFT OUTER JOIN LIBORDAG.DSEGIMP E ON A.PNCDTR = E.PNCDTR " & _
        '       " LEFT OUTER JOIN LIBORDAG.DSEGEXP F ON A.PNCDTR = F.PNCDTR " & _
        '       " LEFT OUTER JOIN LIBORDAG.PCODIGOS G ON A.DNTPCA = G.PNCDIN AND G.PCTABL = 'TIPCARGA' " & _
        '       " LEFT OUTER JOIN LIBORDAG.PCODIGOS H ON A.DCCANA = H.PNCDIN AND H.PCTABL = 'CANAL' " & _
        '       " LEFT OUTER JOIN LIBORDAG.DVOLANTE I ON A.PNCDTR = I.PNCDTR " & _
        '       " LEFT OUTER JOIN LIBORDAG.PCODIGOS J ON I.FNCDDP = J.PNCDIN AND J.PCTABL = 'DEPOSITO' " & _
        '       " LEFT OUTER JOIN LIBORDAG.RACBASOS K ON A.PNCDTR = K.PNCDTR AND K.PNCDAC = 'I14' " & _
        '       " LEFT OUTER JOIN LIBORDAG.RACBASOS L ON A.PNCDTR = L.PNCDTR AND L.PNCDAC = 'I13' " & _
        '       " LEFT OUTER JOIN LIBORDAG.RACBASOS M ON A.PNCDTR = M.PNCDTR AND M.PNCDAC = 'I16' " & _
        '       " LEFT OUTER JOIN LIBORDAG.RACBASOS N ON A.PNCDTR = N.PNCDTR AND N.PNCDAC = 'I12' " & _
        '       " LEFT OUTER JOIN LIBORDAG.RACBASOS O ON A.PNCDTR = O.PNCDTR AND O.PNCDAC = 'I15' " & _
        '       " LEFT OUTER JOIN LIBORDAG.DDOCEMB P ON A.PNCDTR = P.PNCDTR " & _
        '       " LEFT OUTER JOIN LIBORDAG.PCODIGOS Q ON E.DCAGMR = Q.PNCDIN AND Q.PCTABL = 'AGETRAN' " & _
        '       " LEFT OUTER JOIN LIBORDAG.DAGCARGA R ON A.PNCDTR = R.PNCDTR " & _
        '       " LEFT OUTER JOIN LIBORDAG.PCODIGOS S ON R.PNCDIN = S.PNCDIN AND S.PCTABL = 'AGECARGA' " & _
        '       " WHERE A.PNCDCO = 'FZ' AND A.PNCDNG = 'A' AND A.PNDCPL = '1' AND A.PNCDZO = '1' " & _
        '       " AND A.DCESTA = 'A' AND A.DCASCI='31172' " & _
        '       " AND CHAR(PNNMOS) LIKE '%" & Os & "%' AND A.DCREFE like '%" & Refer & "%' " & _
        '       " AND A.DCDSME like '%" & Nave & "%' AND G.DCDSCD LIKE '%" & Canal & "%' AND P.PCNMDC LIKE '%" & Bll & "%' "

        'If Aforo.Length > 0 Then
        '    Aforos = "AND CAST(L.DDFINA AS DATE)= '" & Aforo & "'"
        '    Aforos = "AND CAST(L.DDFINA AS DATE)= '2010-10-18' "
        '    sql = sql & Aforos
        'End If
        'If Retiro.Length > 0 Then
        '    Retiros = "AND CAST(O.DDFINA AS DATE)= '" & Retiro & "'"
        '    sql = sql & Retiros
        'End If

        'sql = sql & Order


        Dim ListQuery As List(Of Entidad.XSTRATA) = New List(Of Entidad.XSTRATA)
        Dim cmd As iDB2DataReader

        Using cn As iDB2Connection = ConexionDB2.GetConnection()
            Using command As New iDB2Command("DESCASA.SP_CONSULTA_SEG_WEB_XSTRATAP", cn)
                'Using command As New iDB2Command(Sql, cn)
                command.CommandType = CommandType.StoredProcedure '--CInt(op.Substring(3))                
                command.Parameters.Add("IN_OS", iDB2DbType.iDB2VarChar, 15).Value = Os
                command.Parameters.Add("IN_REFER", iDB2DbType.iDB2VarChar, 30).Value = Refer
                command.Parameters.Add("IN_NAVE", iDB2DbType.iDB2VarChar, 25).Value = Nave   'mercaderia
                command.Parameters.Add("IN_CANAL", iDB2DbType.iDB2Numeric, 15).Value = Canal 'carga
                command.Parameters.Add("IN_BL", iDB2DbType.iDB2Numeric, 25).Value = Bll
                command.Parameters.Add("IN_AFORO", iDB2DbType.iDB2Numeric, 10).Value = Aforo
                command.Parameters.Add("IN_RETIRO", iDB2DbType.iDB2Numeric, 10).Value = Retiro
                command.Parameters.Add("IN_NUMERACION", iDB2DbType.iDB2Numeric, 10).Value = Numeracion
                command.Parameters.Add("IN_CLIENTE", iDB2DbType.iDB2VarChar, 20).Value = CodigoCli.ToString.Trim
                command.Parameters.Add("IN_TIP_CANAL", iDB2DbType.iDB2VarChar, 1).Value = TipoCanal.ToString.Trim
                command.Parameters.Add("IN_TIP_ORDEN", iDB2DbType.iDB2VarChar, 2).Value = Tipoorden.ToString.Trim
                command.Parameters.Add("IN_EST_ORDEN", iDB2DbType.iDB2VarChar, 1).Value = EstadoOrdenes.ToString.Trim


                cmd = command.ExecuteReader()
                While (cmd.Read())
                    Dim ListaXstrata As Entidad.XSTRATA = New Entidad.XSTRATA()
                    With ListaXstrata
                        .PNNMOS = Convert.ToInt64(cmd("ORDEN"))
                        .PCNMDC = Convert.ToString(cmd("BL"))
                        .DCTPOS = Convert.ToString(cmd("TIPO"))
                        .DESPACHO = Convert.ToString(cmd("DESPACHO")) ' ESTUVO COMO SITUACION
                        .DCDSME = Convert.ToString(cmd("MERCADERIA"))
                        .DDREGI = Convert.ToString(cmd("DDREGI"))
                        .DCDSRG = Convert.ToString(cmd("REGIMEN"))
                        .DCDSOP = Convert.ToString(cmd("OPERACION"))
                        .DCNAVE = Convert.ToString(cmd("VAPOR"))
                        .FECHA_ESTIMADA = Convert.ToString(cmd("FECHA_ESTIMADA"))
                        .FECHA_LLEGADA = Convert.ToString(cmd("FECHA_LLEGADA"))
                        .TERMINO_DESCARGA = Convert.ToString(cmd("TERMINO_DESCARGA"))
                        .DCDSAB = Convert.ToString(cmd("ALMACENES"))
                        .FECHA_UBICACION = Convert.ToString(cmd("FECHA_UBICACION"))
                        .FECHA_VISTOBUENO = Convert.ToString(cmd("FECHA_VISTOBUENO"))
                        .FECHA_NUMERACION = Convert.ToString(cmd("FECHA_NUMERACION"))
                        .FECHA_PAGO = Convert.ToString(cmd("FECHA_PAGO"))
                        .DCBLTO = Convert.ToString(cmd("TIPO_BULTO"))
                        .DCCANA = Convert.ToString(cmd("CANAL"))
                        .DDAFOR = Convert.ToString(cmd("DDAFOR"))
                        .DDPRES = Convert.ToString(cmd("DDPRES"))
                        .DDLEVA = Convert.ToString(cmd("DDLEVA"))
                        .DDRETI = Convert.ToString(cmd("DDRETI"))
                        .NRUC = Convert.ToString(cmd("NIT"))
                        .DCDUIDUE = Convert.ToString(cmd("DAM"))
                        .DCOBSE = Convert.ToString(cmd("OBERVACION"))
                        .DCNMMN = Convert.ToString(cmd("NRO_MANIFIESTO"))
                        .DCREFE = Convert.ToString(cmd("REFERENCIA"))
                        .B_L = Convert.ToString(cmd("B_L"))
                        .TCMPCL = Convert.ToString(cmd("NOMB_CLI"))
                        .DCDSCD = Convert.ToString(cmd("CARGA"))
                        .LIQUIDADOR = Convert.ToString(cmd("LIQUIDADOR"))
                    End With
                    ListQuery.Add(ListaXstrata)
                End While
            End Using
        End Using
        Return ListQuery

    End Function

    Public Shared Function ConsultaOrdenesCompra(ByVal TipoOrdenCompra As String, ByVal NroOrdenCompra As String) As List(Of Entidad.EOrdenCompra)


        Dim ListQuery As List(Of Entidad.EOrdenCompra) = New List(Of Entidad.EOrdenCompra)
        Dim cmd As iDB2DataReader

        Using cn As iDB2Connection = ConexionDB2.GetConnection()
            Using command As New iDB2Command("DESCASA.SP_AGENCIAS_ORDENCOMPRA", cn)
                'Using command As New iDB2Command(Sql, cn)
                command.CommandType = CommandType.StoredProcedure '--CInt(op.Substring(3))                
                command.Parameters.Add("IN_TIPOORDEN", iDB2DbType.iDB2Numeric, 15).Value = TipoOrdenCompra.ToString.Trim
                command.Parameters.Add("IN_NROORDENC", iDB2DbType.iDB2VarChar, 30).Value = NroOrdenCompra.ToString.Trim
                
                cmd = command.ExecuteReader()
                While (cmd.Read())
                    Dim ListaXst As Entidad.EOrdenCompra = New Entidad.EOrdenCompra
                    With ListaXst
                        .NMRODC = Convert.ToString(cmd("NMRODC"))
                        .CSRVNV = Convert.ToString(cmd("CSRVNV"))
                        .NOMVAR = Convert.ToString(cmd("NOMVAR"))
                        .VALMRC = Convert.ToString(cmd("VALMRC")) ' ESTUVO COMO SITUACION
                        .STPGCT = Convert.ToString(cmd("STPGCT"))                                          
                    End With
                    ListQuery.Add(ListaXst)
                End While
            End Using
        End Using
        Return ListQuery

    End Function


    Public Shared Function ValidaAccesos(ByVal Usuario As String, ByVal Clave As String) As List(Of Entidad.E_ValidarAcceso)

        Dim ListAccesos As List(Of Entidad.E_ValidarAcceso) = New List(Of Entidad.E_ValidarAcceso)
        Dim cmd As iDB2DataReader

        Using cn As iDB2Connection = ConexionDB2.GetConnection()
            'Using command As New iDB2Command("DC@RNSLIB.SP_VALIDAR_ACCESOS", cn)
            Using command As New iDB2Command("DC@RNSLIB.SP_AGRANSA_WEB_SEGUI_ORD_VALIDAR_ACCESOS", cn)
                'Using command As New iDB2Command(Sql, cn)
                command.CommandType = CommandType.StoredProcedure '--CInt(op.Substring(3))                
                command.Parameters.Add("USUARIO", iDB2DbType.iDB2VarChar, 10).Value = Usuario.ToString.Trim
                command.Parameters.Add("CLAVE", iDB2DbType.iDB2VarChar, 32).Value = Clave.ToString.Trim                

                cmd = command.ExecuteReader()
                While (cmd.Read())
                    Dim ListaXst As Entidad.E_ValidarAcceso = New Entidad.E_ValidarAcceso
                    With ListaXst
                        .CCMPN = Convert.ToString(cmd("CCMPN"))
                        .CDVSN = Convert.ToString(cmd("CDVSN"))
                        .CLBRCM = Convert.ToString(cmd("CLBRCM"))
                        .STADO = Convert.ToString(cmd("STADO")) ' ESTUVO COMO SITUACION
                        .TCMAPL = Convert.ToString(cmd("TCMAPL"))
                        .CCLNT = Convert.ToString(cmd("CCLNT"))
                    End With
                    ListAccesos.Add(ListaXst)
                End While
            End Using
        End Using
        Return ListAccesos

    End Function


End Class
