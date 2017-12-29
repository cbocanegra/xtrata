Imports MySql.Data.MySqlClient
Imports System.Data
Imports IBM.Data.DB2.iSeries
Imports System.Collections.Generic
Imports System.Text
Imports System.Data.Common
Imports BE = Emp_Entidad
Imports ENTI = Emp_Entity


Public Class DOrdenServ

    Public Cn As New iDB2Connection

    Public Shared Function ListarOrdenServicio(ByVal Compania As String) As List(Of BE.EOrdenServ)

        '    Dim Recup As New DataTable
        '    Dim Aforos, Retiros, Order As String
        '    Order = " ORDER BY A.DDREGI DESC"

        Dim ListQuery As List(Of BE.EOrdenServ) = New List(Of BE.EOrdenServ)
        '    Dim cmd As iDB2DataReader

        '    Using cn As iDB2Connection = ConexionDB2.GetConnection()
        '        Using command As New iDB2Command("DESCASA.SP_CONSULTA_SEG_WEB_XSTRATAP", cn)
        '            'Using command As New iDB2Command(Sql, cn)
        '            command.CommandType = CommandType.StoredProcedure '--CInt(op.Substring(3))                
        '            command.Parameters.Add("IN_OS", iDB2DbType.iDB2VarChar, 15).Value = Os
        '            command.Parameters.Add("IN_REFER", iDB2DbType.iDB2VarChar, 30).Value = Refer
        '            command.Parameters.Add("IN_NAVE", iDB2DbType.iDB2VarChar, 25).Value = Nave   'mercaderia
        '            command.Parameters.Add("IN_CANAL", iDB2DbType.iDB2Numeric, 15).Value = Canal 'carga
        '            command.Parameters.Add("IN_BL", iDB2DbType.iDB2Numeric, 25).Value = Bll
        '            command.Parameters.Add("IN_AFORO", iDB2DbType.iDB2Numeric, 10).Value = Aforo
        '            command.Parameters.Add("IN_RETIRO", iDB2DbType.iDB2Numeric, 10).Value = Retiro
        '            command.Parameters.Add("IN_NUMERACION", iDB2DbType.iDB2Numeric, 10).Value = Numeracion
        '            command.Parameters.Add("IN_CLIENTE", iDB2DbType.iDB2VarChar, 20).Value = CodigoCli.ToString.Trim
        '            command.Parameters.Add("IN_TIP_CANAL", iDB2DbType.iDB2VarChar, 1).Value = TipoCanal.ToString.Trim
        '            command.Parameters.Add("IN_TIP_ORDEN", iDB2DbType.iDB2VarChar, 2).Value = Tipoorden.ToString.Trim
        '            command.Parameters.Add("IN_EST_ORDEN", iDB2DbType.iDB2VarChar, 1).Value = EstadoOrdenes.ToString.Trim


        '            cmd = command.ExecuteReader()
        '            While (cmd.Read())
        '                Dim ListaXstrata As Entidad.XSTRATA = New Entidad.XSTRATA()
        '                With ListaXstrata
        '                    .PNNMOS = Convert.ToInt64(cmd("ORDEN"))
        '                    .PCNMDC = Convert.ToString(cmd("BL"))
        '                    .DCTPOS = Convert.ToString(cmd("TIPO"))
        '                    .DESPACHO = Convert.ToString(cmd("DESPACHO")) ' ESTUVO COMO SITUACION
        '                    .DCDSME = Convert.ToString(cmd("MERCADERIA"))
        '                    .DDREGI = Convert.ToString(cmd("DDREGI"))
        '                    .DCDSRG = Convert.ToString(cmd("REGIMEN"))
        '                    .DCDSOP = Convert.ToString(cmd("OPERACION"))
        '                    .DCNAVE = Convert.ToString(cmd("VAPOR"))
        '                    .FECHA_ESTIMADA = Convert.ToString(cmd("FECHA_ESTIMADA"))
        '                    .FECHA_LLEGADA = Convert.ToString(cmd("FECHA_LLEGADA"))
        '                    .TERMINO_DESCARGA = Convert.ToString(cmd("TERMINO_DESCARGA"))
        '                    .DCDSAB = Convert.ToString(cmd("ALMACENES"))
        '                    .FECHA_UBICACION = Convert.ToString(cmd("FECHA_UBICACION"))
        '                    .FECHA_VISTOBUENO = Convert.ToString(cmd("FECHA_VISTOBUENO"))
        '                    .FECHA_NUMERACION = Convert.ToString(cmd("FECHA_NUMERACION"))
        '                    .FECHA_PAGO = Convert.ToString(cmd("FECHA_PAGO"))
        '                    .DCBLTO = Convert.ToString(cmd("TIPO_BULTO"))
        '                    .DCCANA = Convert.ToString(cmd("CANAL"))
        '                    .DDAFOR = Convert.ToString(cmd("DDAFOR"))
        '                    .DDPRES = Convert.ToString(cmd("DDPRES"))
        '                    .DDLEVA = Convert.ToString(cmd("DDLEVA"))
        '                    .DDRETI = Convert.ToString(cmd("DDRETI"))
        '                    .NRUC = Convert.ToString(cmd("NIT"))
        '                    .DCDUIDUE = Convert.ToString(cmd("DAM"))
        '                    .DCOBSE = Convert.ToString(cmd("OBERVACION"))
        '                    .DCNMMN = Convert.ToString(cmd("NRO_MANIFIESTO"))
        '                    .DCREFE = Convert.ToString(cmd("REFERENCIA"))
        '                    .B_L = Convert.ToString(cmd("B_L"))
        '                    .TCMPCL = Convert.ToString(cmd("NOMB_CLI"))
        '                    .DCDSCD = Convert.ToString(cmd("CARGA"))
        '                    .LIQUIDADOR = Convert.ToString(cmd("LIQUIDADOR"))
        '                End With
        '                ListQuery.Add(ListaXstrata)
        '            End While
        '        End Using
        '    End Using
        Return ListQuery

    End Function

    Public Shared Function InsertaOrdenServicio(ByVal Entidad As BE.EOrdenServ) As Integer
        Dim NameSp As String = ""
        Dim Sociedad As String = ""
        Dim codigo As String = ""
        Dim a As Integer
        NameSp = "LIBORDAG.SP_WEBAGENCIAS_CREAR_OS"
        Try
            Using cn As iDB2Connection = ConexionDB2.GetConnection()
                Using command As New iDB2Command(NameSp, cn)
                    command.CommandType = CommandType.StoredProcedure
                    With Entidad
                        command.Parameters.Add("XPNCDTR", iDB2DbType.iDB2VarChar, 10).Value = .PNCDTR.Trim
                        command.Parameters.Add("XPNCDCO", iDB2DbType.iDB2VarChar, 5).Value = .PNCDCO.Trim
                        command.Parameters.Add("XPNCDNG", iDB2DbType.iDB2VarChar, 5).Value = .PNCDNG.Trim
                        command.Parameters.Add("XPNDCPL", iDB2DbType.iDB2VarChar, 5).Value = .PNDCPL.Trim
                        command.Parameters.Add("XPNCDZO", iDB2DbType.iDB2VarChar, 5).Value = .PNCDZO.Trim
                        command.Parameters.Add("XPNCDRG", iDB2DbType.iDB2VarChar, 5).Value = .PNCDRG.Trim
                        command.Parameters.Add("XPNCDOP", iDB2DbType.iDB2VarChar, 5).Value = .PNCDOP.Trim
                        command.Parameters.Add("XDCASCI", iDB2DbType.iDB2VarChar, 10).Value = .DCASCI.Trim
                        command.Parameters.Add("XDCASSA", iDB2DbType.iDB2VarChar, 20).Value = .DCASSA.Trim
                        command.Parameters.Add("XDCTPOS", iDB2DbType.iDB2Char, 2).Value = .DCTPOS.Trim
                        command.Parameters.Add("XDCREFE", iDB2DbType.iDB2VarChar, 1024).Value = .DCREFE.Trim
                        command.Parameters.Add("XFNCDAD", iDB2DbType.iDB2VarChar, 10).Value = .FNCDAD
                        command.Parameters.Add("XDCPREC", iDB2DbType.iDB2Char, 1).Value = .DCPREC.Trim
                        command.Parameters.Add("XDNOSPR", iDB2DbType.iDB2VarChar, 10).Value = .DNOSPR
                        command.Parameters.Add("XDCVIGE", iDB2DbType.iDB2Char, 1).Value = .DCVIGE
                        command.Parameters.Add("XFNCDPR", iDB2DbType.iDB2Char, 2).Value = .FNCDPR.Trim

                        If .DDVNDE = "" Then
                            command.Parameters.Add("XDCDSME", iDB2DbType.iDB2VarChar, 60).Value = Nothing
                        Else
                            command.Parameters.Add("XDDVNDE", iDB2DbType.iDB2VarChar, 10).Value = .DDVNDE.Substring(6, 4) & "-" & .DDVNDE.Substring(3, 2) & "-" & .DDVNDE.Substring(0, 2)
                        End If

                        command.Parameters.Add("XDCDSME", iDB2DbType.iDB2VarChar, 60).Value = .DCDSME.Trim
                        command.Parameters.Add("XDCLUGA", iDB2DbType.iDB2VarChar, 60).Value = .DCLUGA.Trim
                        command.Parameters.Add("XDNTPCA", iDB2DbType.iDB2VarChar, 10).Value = .DNTPCA.Trim
                        command.Parameters.Add("XDCINSP", iDB2DbType.iDB2Char, 1).Value = .DCINSP.Trim
                        command.Parameters.Add("XDNCAM", iDB2DbType.iDB2Numeric, 17).Value = .DNCAM
                        command.Parameters.Add("XDNTRAN", iDB2DbType.iDB2VarChar, 10).Value = .DNTRAN.Trim
                        command.Parameters.Add("XDCORIG", iDB2DbType.iDB2Char, 1).Value = .DCORIG.Trim
                        command.Parameters.Add("XDCCONT", iDB2DbType.iDB2VarChar, 60).Value = .DCCONT.Trim
                        command.Parameters.Add("XDCREEI", iDB2DbType.iDB2Char, 1).Value = .DCREEI.Trim
                        command.Parameters.Add("XDCLIGA", iDB2DbType.iDB2Char, 1).Value = .DCLIGA.Trim
                        command.Parameters.Add("XDCFACTU", iDB2DbType.iDB2VarChar, 60).Value = .DCFACTU.Trim
                        command.Parameters.Add("XDCAVIS", iDB2DbType.iDB2VarChar, 10).Value = .DCAVIS.Trim
                        command.Parameters.Add("XDCRECL", iDB2DbType.iDB2Char, 1).Value = .DCRECL.Trim
                        command.Parameters.Add("XDCOBSE", iDB2DbType.iDB2VarChar, 60).Value = .DCOBSE.Trim
                        command.Parameters.Add("XDCREG", iDB2DbType.iDB2Char, 1).Value = .DCREG.Trim
                        'command.Parameters.Add("XDNTPCA", iDB2DbType.iDB2Char, 5).Value = .DNTPCA.Trim
                        command.Parameters.Add("XDNFPAG", iDB2DbType.iDB2VarChar, 10).Value = .DNFPAG.Trim
                        command.Parameters.Add("XDCMOTI", iDB2DbType.iDB2VarChar, 60).Value = .DCMOTI.Trim

                        command.Parameters.Add("XPNNMOS2", iDB2DbType.iDB2VarChar, 10).Direction = ParameterDirection.Output
                        a = command.ExecuteNonQuery()
                        codigo = command.Parameters("XPNNMOS2").Value
                    End With
                End Using
            End Using
            If codigo <> "" Then
                Using cn As iDB2Connection = ConexionDB2.GetConnection()
                    Using command As New iDB2Command("LIBORDAG.SP_WEBAGENCIAS_CREAR_OS_ZZ201001", cn)
                        command.CommandType = CommandType.StoredProcedure
                        With Entidad
                            command.Parameters.Add("XPNCDTR", iDB2DbType.iDB2VarChar, 10).Value = .PNCDTR.Trim
                            a = command.ExecuteNonQuery()
                        End With
                    End Using
                End Using

                Using cn As iDB2Connection = ConexionDB2.GetConnection()
                    Using command As New iDB2Command("LIBORDAG.SP_WEBAGENCIAS_CREAR_OS_ZZ201002", cn)
                        command.CommandType = CommandType.StoredProcedure
                        With Entidad
                            command.Parameters.Add("XPNCDTR", iDB2DbType.iDB2VarChar, 10).Value = .PNCDTR.Trim
                            a = command.ExecuteNonQuery()
                        End With
                    End Using
                End Using

                Using cn As iDB2Connection = ConexionDB2.GetConnection()
                    Using command As New iDB2Command("LIBORDAG.SP_WEBAGENCIAS_CREAR_OS_CONTROLGASTOS", cn)
                        command.CommandType = CommandType.StoredProcedure
                        With Entidad
                            command.Parameters.Add("XPNCDTR", iDB2DbType.iDB2VarChar, 10).Value = .PNCDTR.Trim
                            a = command.ExecuteNonQuery()
                        End With
                    End Using
                End Using

            End If
        Catch ex As Exception
        End Try
        Return codigo
    End Function

    Public Shared Function GetNumeroOS() As String
        Dim NameSp As String = ""
        Dim dt As New DataTable
        NameSp = "LIBORDAG.SP_WEBAGENCIAS_GENERAPNCDTR_OS"
        Try
            Using cn As iDB2Connection = ConexionDB2.GetConnection()
                Using command As New iDB2Command(NameSp, cn)
                    Using adapter As New iDB2DataAdapter
                        command.CommandType = CommandType.StoredProcedure
                        command.Parameters.Add("X_PNCDTR", iDB2DbType.iDB2VarChar).Direction = ParameterDirection.Output
                        command.ExecuteNonQuery()
                        Return command.Parameters("X_PNCDTR").Value

                    End Using
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function InsertaOrdenServicioAscinsa(ByVal Entidad As BE.EOrdenServ) As Integer
        Dim orden As String = ""
        Dim conection As New MySqlConnection()
        Dim sql, sql2 As String
        Dim Cod_cli, tipo_doc, num_doc, nom_impo, dir_impo, cantidad As String
        Dim fecha As Date = Now.ToString
        Dim datofecha As String = fecha.ToString.Substring(6, 4) & "-" & fecha.ToString.Substring(3, 2) & "-" & _
                                  fecha.ToString.Substring(0, 2) & " " & fecha.Hour.ToString & ":" & _
                                  fecha.Minute.ToString & ":" & fecha.Second.ToString


        sql = "SELECT PNCDAS FROM LIBORDAG.DCLIENTE WHERE DCASCI1=" & Entidad.DCASCI

        Using cn As iDB2Connection = ConexionDB2.GetConnection()
            Using command As New iDB2Command(sql, cn)
                Using datos As iDB2DataReader = command.ExecuteReader
                    datos.Read()
                    Cod_cli = datos.GetString(0).Trim
                End Using
            End Using
        End Using

        Dim upd As MySqlCommand
        conection.ConnectionString = "Server=RANCALASC2;Database=ADUANAS; Uid=sa;Pwd=rbt86572a;"
        conection.Open()

        Dim sqlmysql As String = " SELECT GEN017C002, TAB002C004,TAB002C002,TAB002C005 " & _
                                     " FROM TAB002_1 WHERE TAB002C001='" & Cod_cli & "'"

        Using command As New MySqlCommand(sqlmysql, conection)
            Using datos As MySqlDataReader = command.ExecuteReader
                datos.Read()
                tipo_doc = datos.GetString(0)
                num_doc = datos.GetString(1)
                nom_impo = datos.GetString(2)
                dir_impo = datos.GetString(3)
            End Using
        End Using

        Dim sqlmysql1 As String = " SELECT COUNT(NUME_ORDEN) " & _
                                   " FROM ADU005 WHERE ANO_PRESE=" & Entidad.PNNMOS.Substring(0, 4) & " AND NUME_ORDEN = '" & Entidad.PNNMOS.Substring(4, 6) & "'"

        Using command As New MySqlCommand(sqlmysql1, conection)
            Using datos As MySqlDataReader = command.ExecuteReader
                datos.Read()
                cantidad = datos.GetString(0)
            End Using
        End Using



        Try

            If cantidad = "0" Then
                Dim query2 As String = ""
                With Entidad
                    query2 = " INSERT INTO ADU005 (CODI_REGI, CODI_ADUAN, ANO_PRESE, NUME_ORDEN, CODI_CLIE , TIPO_DOCUM, NUME_DOCUM, " & _
                             " NOMB_IMPOR, DIRE_IMPOR , FCH_REGIST, REFERENCIA,MERCADERIA ,CODI_TDESP) " & _
                             " VALUES('" & .PNCDRG & "','" & .FNCDAD & "'," & .PNNMOS.Substring(0, 4) & ",'" & _
                             .PNNMOS.Substring(4, 6) & "','" & Cod_cli & "'," & tipo_doc & ",'" & num_doc & "','" & _
                             nom_impo & "','" & dir_impo & "' ,'" & datofecha & "','" & .DCREFE & "','" & .DCDSME & "','" & _
                             .FNCDPRA & "')"
                    upd = New MySqlCommand(query2, conection)
                    InsertaOrdenServicioAscinsa = upd.ExecuteNonQuery()
                End With
            Else
                Dim query2 As String = ""
                With Entidad
                    query2 = " UPDATE ADU005 SET  TIPO_DOCUM = '" & tipo_doc & "'," & _
                             " CODI_CLIE  = '" & Cod_cli & "'," & _
                             " NUME_DOCUM = '" & num_doc & "'," & _
                             " NOMB_IMPOR = '" & nom_impo & "'," & _
                             " DIRE_IMPOR = '" & dir_impo & "'," & _
                             " REFERENCIA = '" & .DCREFE & "'," & _
                             " MERCADERIA = '" & .DCDSME & "'," & _
                             " CODI_TDESP = '" & .FNCDPRA & "'" & _
                             " WHERE ANO_PRESE = '" & .PNNMOS.Substring(0, 4) & "' AND NUME_ORDEN = '" & .PNNMOS.Substring(4, 6) & "' AND" & _
                             " CODI_ADUAN = '" & .FNCDAD & "' AND CODI_REGI  = '" & .PNCDRG & "'"

                    upd = New MySqlCommand(query2, conection)
                    InsertaOrdenServicioAscinsa = upd.ExecuteNonQuery()
                End With
            End If

            With Entidad
                sql2 = "UPDATE LIBORDAG.DORDENES  SET  SENVAS = 'S' WHERE PNCDTR = ' " & .PNCDTR & "'"
            End With

            Using cn As iDB2Connection = ConexionDB2.GetConnection()
                Using command As New iDB2Command(sql2, cn)
                    command.ExecuteNonQuery()
                End Using
            End Using

        Catch ex As Exception

            With Entidad
                sql2 = "UPDATE LIBORDAG.DORDENES  SET  SENVAS = 'N' WHERE PNCDTR = ' " & .PNCDTR & "'"
            End With

            Using cn As iDB2Connection = ConexionDB2.GetConnection()
                Using command As New iDB2Command(sql2, cn)
                    command.ExecuteNonQuery()
                End Using
            End Using

            InsertaOrdenServicioAscinsa = "0"
        End Try
        Return InsertaOrdenServicioAscinsa
    End Function



    Public Shared Function ValidarTipoUsuarios(ByVal Usuario As String) As String
        Dim Libreria As String = ""
        Dim NameSp As String = ""
        Dim Msje As String = 0
        Dim CompDiv As String = ""


        'NameSp = "DESCASA.ING_VALIDA_DATOS_USUARIO_TIPO"
        NameSp = "DC@RNSLIB.SP_AGRANSA_WEB_SEGUI_ORD_VALIDA_DATOS_USUARIO_TIPO"
        Try
            Using cn As iDB2Connection = ConexionDB2.GetConnection()
                Using command As New iDB2Command(NameSp, cn)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add("IN_USER", iDB2DbType.iDB2VarChar, 10).Value = Usuario.ToString.Trim
                    command.Parameters.Add("IN_CMPNIA", iDB2DbType.iDB2Char, 2).Direction = ParameterDirection.Output
                    command.Parameters.Add("IN_DIVISION", iDB2DbType.iDB2Char, 1).Direction = ParameterDirection.Output
                    command.Parameters.Add("IN_TIPO", iDB2DbType.iDB2Char, 1).Direction = ParameterDirection.Output
                    command.ExecuteNonQuery()
                    CompDiv = Convert.ToString(command.Parameters("IN_CMPNIA").Value) & Convert.ToString(command.Parameters("IN_DIVISION").Value) & Convert.ToString(command.Parameters("IN_TIPO").Value)
                    command.ExecuteNonQuery()
                    cn.Close()
                End Using
            End Using
        Catch ex As Exception
            Return CompDiv
        End Try

        Return CompDiv

    End Function

    Public Shared Function Zona(ByVal usuario As String) As List(Of ENTI.EZonas)
        Dim CZona As New List(Of ENTI.EZonas)
        Dim Cmd As New iDB2Command
        Dim Ds As New DataSet
        Dim Da As New iDB2DataAdapter


        Try
            ConexionDB2.GetConnection()
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.CommandText = "DESCASA.SP_SOLSEGORD_IMP_ZONAS"
            Cmd.Parameters.Add("IN_USER", usuario.ToString.Trim)
            'Cmd.Parameters.Add("IN_USUARIO", UsuArio)
            'Cmd.Parameters.Add("IN_ZONA", Zona)
            Cmd.Connection = ConexionDB2.GetConnection()
            Da.SelectCommand = Cmd
            Da.Fill(Ds, "ZONA")

            If Ds.Tables("ZONA").Rows.Count > 0 Then
                CZona = CargarZona(Ds.Tables("ZONA"))
            End If

            ConexionDB2.GetConnection.Close()
            Return CZona
        Catch ex As iDB2Exception
            ConexionDB2.GetConnection.Close()
            Throw ex
        End Try
    End Function

    Public Shared Function CargarZona(ByVal dT As DataTable) As List(Of ENTI.EZonas)
        Dim C As New List(Of Enti.EZonas)
        For Each Item As DataRow In dT.Rows
            Dim E As New Enti.EZonas

            E.CODZONA = CStr(Item(1))
            E.ZONA = CStr(Item(0))

            C.Add(E)
        Next
        Return C

    End Function

    Public Shared Function Usuario_Numeros_Zona(ByVal Usuario As String) As Integer
        Dim Valor As Integer = 0
        Dim Cmd As New iDB2Command
        Dim Ds As New DataSet
        Dim Da As New iDB2DataAdapter
        Dim NameSp As String = ""

        'NameSp = "DESCASA.SP_SOLSEGORD_IMP_CANT_USUARIOXZONA"
        NameSp = "DC@RNSLIB.SP_AGRANSA_WEB_SEGUI_ORD_USUARIOXZONA"

        Try
            Using cn As iDB2Connection = ConexionDB2.GetConnection()
                Using command As New iDB2Command(NameSp, cn)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add("IN_USUARIO", iDB2DbType.iDB2VarChar, 10).Value = Usuario.ToString.Trim
                    command.ExecuteNonQuery()

                    Da.SelectCommand = command
                    Da.Fill(Ds, "ZONA")
                    If Ds.Tables("ZONA").Rows.Count > 0 Then
                        Valor = Ds.Tables("ZONA").Rows.Count
                    End If
                    cn.Close()
                End Using
            End Using
        Catch ex As Exception
            ConexionDB2.GetConnection.Close()
        End Try

        Return Valor
    End Function
    'Public Shared Function Close() As iDB2Connection
    '    Cn.Close()
    '    Return Cn
    'End Function


    Public Shared Function ZonaUsuario(ByVal Usuario As String) As List(Of ENTI.EZonas)
        Dim CZona As New List(Of ENTI.EZonas)
        Dim Cmd As New iDB2Command
        Dim Ds As New DataSet
        Dim Da As New iDB2DataAdapter


        Try
            ConexionDB2.GetConnection()
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.CommandText = "DC@RNSLIB.SP_AGRANSA_WEB_SEGUI_ORD_ZONAS_USUARIO"
            Cmd.Parameters.Add("IN_USUARIO", Usuario.Trim)
            Cmd.Connection = ConexionDB2.GetConnection()
            Da.SelectCommand = Cmd
            Da.Fill(Ds, "ZONA")

            If Ds.Tables("ZONA").Rows.Count > 0 Then
                CZona = CargarZona(Ds.Tables("ZONA"))
            End If

            ConexionDB2.GetConnection.Close()
            Return CZona
        Catch ex As iDB2Exception
            ConexionDB2.GetConnection.Close()
            Throw ex
        End Try
    End Function

    Public Shared Function ClienteUsuario(ByVal Usuario As String) As List(Of ENTI.EClientes)
        Dim CCliente As New List(Of ENTI.EClientes)
        Dim Cmd As New iDB2Command
        Dim Ds As New DataSet
        Dim Da As New iDB2DataAdapter

        Try
            ConexionDB2.GetConnection()
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.CommandText = "DC@RNSLIB.SP_AGRANSA_WEB_SEGUI_ORD_CLIENTES_USUARIO"
            Cmd.Parameters.Add("IN_USUARIO", Usuario.Trim)
            Cmd.Connection = ConexionDB2.GetConnection()
            Da.SelectCommand = Cmd
            Da.Fill(Ds, "CLIENTE")

            If Ds.Tables("CLIENTE").Rows.Count > 0 Then
                For Each Item As DataRow In Ds.Tables("CLIENTE").Rows
                    Dim Cliente As New ENTI.EClientes()
                    Cliente.CODCLIENTE = Convert.ToInt32(Item(0))
                    'Cliente.NOMBRECLIENTE = Item(1).ToString()
                    CCliente.Add(Cliente)
                Next
            End If

            ConexionDB2.GetConnection.Close()
            Return CCliente
        Catch ex As iDB2Exception
            ConexionDB2.GetConnection.Close()
            Throw ex
        End Try

    End Function

End Class
