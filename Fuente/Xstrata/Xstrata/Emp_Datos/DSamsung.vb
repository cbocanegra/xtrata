Imports System.Data
Imports IBM.Data.DB2.iSeries
Imports System.Collections.Generic
Imports System.Text
Imports System.Data.Common
Imports BE = Empleado.Entidad

Public Class DSamsung
    Public Shared Function FillSamsung(ByVal Os As String, ByVal Refer As String, ByVal Nave As String, ByVal Canal As String, ByVal Bll As String, ByVal Aforo As String, ByVal Retiro As String, ByVal Numeracion As String, ByVal CodigoCli As String) As List(Of BE.Samsung)

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


        Dim ListQuery As List(Of BE.Samsung) = New List(Of BE.Samsung)
        Dim cmd As iDB2DataReader

        Using cn As iDB2Connection = ConexionDB2.GetConnection()
            Using command As New iDB2Command("DESCASA.SP_CONSULTA_SEG_WEB", cn)
                'Using command As New iDB2Command(Sql, cn)
                command.CommandType = CommandType.StoredProcedure '--CInt(op.Substring(3))                
                command.Parameters.Add("IN_OS", iDB2DbType.iDB2VarChar, 15).Value = Os
                command.Parameters.Add("IN_REFER", iDB2DbType.iDB2VarChar, 30).Value = Refer
                command.Parameters.Add("IN_NAVE", iDB2DbType.iDB2VarChar, 25).Value = Nave
                command.Parameters.Add("IN_CANAL", iDB2DbType.iDB2Numeric, 15).Value = Canal
                command.Parameters.Add("IN_BL", iDB2DbType.iDB2Numeric, 25).Value = Bll
                command.Parameters.Add("IN_AFORO", iDB2DbType.iDB2Numeric, 10).Value = Aforo
                command.Parameters.Add("IN_RETIRO", iDB2DbType.iDB2Numeric, 10).Value = Retiro
                command.Parameters.Add("IN_NUMERACION", iDB2DbType.iDB2Numeric, 10).Value = Numeracion
                command.Parameters.Add("IN_CLIENTE", iDB2DbType.iDB2VarChar, 20).Value = CodigoCli.ToString.Trim

                cmd = command.ExecuteReader()
                While (cmd.Read())
                    Dim ListaSamsung As BE.Samsung = New BE.Samsung()
                    With ListaSamsung
                        .PNNMOS = Convert.ToInt64(cmd("ORDEN"))
                        .DCTPOS = Convert.ToString(cmd("TIPO"))
                        .FNCDPR = Convert.ToString(cmd("SITUACION"))
                        .DDREGI = Convert.ToString(cmd("DDREGI"))
                        .DCDSRG = Convert.ToString(cmd("REGIMEN"))
                        .DCDSOP = Convert.ToString(cmd("OPERACION"))
                        .DCDSCD = Convert.ToString(cmd("CARGA"))
                        .DCDSCD1 = Convert.ToString(cmd("CANAL"))
                        .DCNMCL = Convert.ToString(cmd("CLIENTE"))
                        .DCREFE = Convert.ToString(cmd("REFERENCIA"))
                        .DCDSME = Convert.ToString(cmd("MERCADERIA"))
                        .DCNAVE = Convert.ToString(cmd("NAVE"))
                        .DDNAVE = Convert.ToString(cmd("ESTIMADO"))
                        .DDNAVE1 = Convert.ToString(cmd("LLEGADA"))
                        .DDTDES = Convert.ToString(cmd("TERMINO"))
                        .DCDSAB = Convert.ToString(cmd("TERMINAL"))
                        .PCNMDC = Convert.ToString(cmd("BL"))
                        .DCNMMA = Convert.ToString(cmd("MANIFIESTO"))
                        .DCNMDM = Convert.ToString(cmd("NUMERO"))
                        .DCDSCD2 = Convert.ToString(cmd("AGMARITIMO"))
                        .DCDSCD3 = Convert.ToString(cmd("CARGA"))
                        .DCDUIDUE = Convert.ToString(cmd("DUA"))
                        .DDNUME = Convert.ToString(cmd("NUMERACION"))
                        .DDNDUE = Convert.ToString(cmd("NUMERACION"))
                        .DDPGDR = Convert.ToString(cmd("PAGO"))
                        .DMTTDR = Convert.ToString(cmd("MONTO"))
                        .DDINIA = Convert.ToString(cmd("SENASA"))
                        .DDFINA = Convert.ToString(cmd("AFORO"))
                        .DDINIA1 = Convert.ToString(cmd("PRESENTACION"))
                        .DDINIA2 = Convert.ToString(cmd("LEVANTE"))
                        .DDFINA1 = Convert.ToString(cmd("RETIRO"))
                        .DCOBSE = Convert.ToString(cmd("DCOBSE"))
                    End With
                    ListQuery.Add(ListaSamsung)
                End While
            End Using
        End Using
        Return ListQuery

    End Function

    Public Shared Function MostrarNombreCliente(ByVal CodigoCliente As String) As String
        Dim sql As String = ""
        Dim Count As String
        Dim NameSp As String = ""
        Dim a As String = ""
        Dim NombreCliente As String = ""


        Dim cmdConultCli As iDB2DataReader


        NameSp = "DESCASA.AGENCIAS_SP_DESCRIP_CLIENTE"
        ' Using cn As iDB2Connection = Conexion.GetConnection(Cpnia, Serv)

        Try
            Using cn As iDB2Connection = ConexionDB2.GetConnection()
                Using Command As New iDB2Command(NameSp, cn)
                    Command.CommandType = CommandType.StoredProcedure
                    Command.Parameters.Add("IN_CODCLI", iDB2DbType.iDB2Numeric, 10).Value = CodigoCliente.ToString.Trim
                    cmdConultCli = Command.ExecuteReader

                    If cmdConultCli.HasRows Then
                        While cmdConultCli.Read
                            NombreCliente = cmdConultCli.GetString(0).ToString
                        End While

                    End If

                End Using
            End Using
        Catch ex As Exception
            NombreCliente = "N"
        End Try

        Return NombreCliente
    End Function

End Class

