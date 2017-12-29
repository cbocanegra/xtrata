Imports IBM.Data.DB2.iSeries
Imports Entidad = Emp_Entity
Imports System.Threading


Public Class DOrdenesXTRATA
    Inherits ConexionDB2
    'Dim Envio As New EnviaInformacion.AddData
    'Dim Envio_Prueba As New EnviaInformacion_Prueba.ServiciosMIQ
    Dim Envio_Prod As New EnviaInformacion_Prod.Servicios_WHSE
    Private Costos As Thread
    Public pstrcliente, pstrOrden, pstrZona, pstrPNDCTR, pstrNEmbarcador, pstrfecha, pstrbl As String
    Public Compania_Usuario As String = "FZ"
    Public Servidor As String = "RANSA"

    Public Function Ordenes(ByVal Orden As String, ByVal Zona As String, ByVal Cliente As Integer, ByVal fecha As String, ByVal fechaconcat As String, _
        ByVal tipo As String, ByVal Usuario As String) As List(Of Entidad.EOrdenXSTRATA)
        Dim COrden As New List(Of Entidad.EOrdenXSTRATA)
        Dim Cmd As New iDB2Command
        Dim Ds As New DataSet
        Dim Da As New iDB2DataAdapter
        Dim NameSp As String = ""

        NameSp = "DC@RNSLIB.SP_AGRANSA_WEB_SEGUI_ORD_MOSTRAR_ORDENES_IMPO"
        Try

            Using cn As iDB2Connection = ConexionDB2.GetConnection()
                Using command As New iDB2Command(NameSp, cn)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add("IN_ZONA", iDB2DbType.iDB2VarChar, 2).Value = Zona.ToString.Trim
                    command.Parameters.Add("IN_ORDEN", iDB2DbType.iDB2VarChar, 10).Value = Orden.ToString.Trim
                    command.Parameters.Add("IN_CCLNT", iDB2DbType.iDB2Numeric, 6).Value = Cliente
                    command.Parameters.Add("IN_USUARIO", iDB2DbType.iDB2VarChar, 10).Value = Usuario
                    command.ExecuteNonQuery()
                    Da.SelectCommand = command
                    Da.Fill(Ds, "Orden")

                    If Ds.Tables("Orden").Rows.Count > 0 Then
                        COrden = CargarOrden(Ds.Tables("Orden"))
                    End If

                    ConexionDB2.GetConnection.Close()
                End Using

                Return COrden
            End Using
        Catch ex As iDB2Exception
            ConexionDB2.GetConnection.Close()
        End Try
    End Function

    Public Function Distribucion_Costos(ByVal Orden As String, _
                                              ByVal Tipo As String, _
                                              ByVal Zona As String, _
                                              ByVal cliente As String)

        Dim valor As String
        valor = Inserta_CostosAdicionales(Orden, Tipo, Zona, cliente, 46)
        If valor <> "" Then
            Return valor
        End If
        valor = Inserta_CostosAdicionales(Orden, Tipo, Zona, cliente, 47)
        If valor <> "" Then
            Return valor
        End If
        valor = Inserta_CostosAdicionales(Orden, Tipo, Zona, cliente, 57)
        If valor <> "" Then
            Return valor
        End If

        Inserta_CostosOrden(Orden, Tipo, Zona, cliente, "")


        Return valor
    End Function

    Public Function Inserta_CostosOrden(ByVal Orden As String, _
                                          ByVal Tipo As String, _
                                          ByVal Zona As String, _
                                          ByVal cliente As String, _
                                          ByVal Rubro As String)

        Dim Cmd As New iDB2Command
        Dim Ds As New DataSet
        Dim Da As New iDB2DataAdapter



        Dim NameSp As String = ""
        NameSp = "DC@RNSLIB.SP_SOLSEGORD_IMP_DISTRIBUCION_ORDEN_COMPRA"

        Try

            Using cn As iDB2Connection = ConexionDB2.GetConnection()
                Using command As New iDB2Command(NameSp, cn)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add("IN_NORDSR", iDB2DbType.iDB2VarChar, 10).Value = Orden
                    command.Parameters.Add("IN_TIPO", iDB2DbType.iDB2VarChar, 10).Value = Tipo
                    command.Parameters.Add("IN_ZONA", iDB2DbType.iDB2VarChar, 2).Value = Zona
                    command.Parameters.Add("IN_CCLNT", iDB2DbType.iDB2Numeric, 10).Value = cliente
                    command.Parameters.Add("IN_RUBRO", iDB2DbType.iDB2VarChar, 2).Value = Rubro

                    command.Connection = cn
                    Da.InsertCommand = command
                    command.ExecuteNonQuery()
                    '  ConexionDB2.GetConnection.Close()
                End Using

            End Using

        Catch ex As iDB2Exception
            Throw ex
            Return ex
        End Try



        'Try

        '    Cn = Conection.Conection.Open(Compania_Usuario, Servidor)
        '    Cmd.CommandType = CommandType.StoredProcedure
        '    Cmd.CommandText = Libreria & "SP_SOLSEGORD_IMP_DISTRIBUCION_ORDEN_COMPRA"
        '    Cmd.Parameters.Add("IN_NORDSR", Orden)
        '    Cmd.Parameters.Add("IN_TIPO", Tipo)
        '    Cmd.Parameters.Add("IN_ZONA", Zona)
        '    Cmd.Parameters.Add("IN_CCLNT", cliente)
        '    Cmd.Parameters.Add("IN_RUBRO", Rubro)
        '    Cmd.Connection = Cn
        '    Da.InsertCommand = Cmd
        '    Cmd.ExecuteNonQuery()
        '    Close()
        'Catch ex As iDB2Exception
        '    Throw ex
        '    Return ex
        'End Try
        Return ""
    End Function

    Public Function Inserta_CostosAdicionales(ByVal Orden As String, _
                                              ByVal Tipo As String, _
                                              ByVal Zona As String, _
                                              ByVal cliente As String, _
                                              ByVal Rubro As String)

        Dim Cmd As New iDB2Command
        Dim Ds As New DataSet
        Dim Da As New iDB2DataAdapter
        Dim NameSp As String = ""
        NameSp = "DC@RNSLIB.SP_SOLSEGORD_IMP_DISTRIBUCION_COSTOS"

        Try

            Using cn As iDB2Connection = ConexionDB2.GetConnection()
                Using command As New iDB2Command(NameSp, cn)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add("IN_NORDSR", iDB2DbType.iDB2VarChar, 10).Value = Orden
                    command.Parameters.Add("IN_TIPO", iDB2DbType.iDB2VarChar, 10).Value = Tipo
                    command.Parameters.Add("IN_ZONA", iDB2DbType.iDB2VarChar, 2).Value = Zona
                    command.Parameters.Add("IN_CCLNT", iDB2DbType.iDB2Numeric, 10).Value = cliente
                    command.Parameters.Add("IN_RUBRO", iDB2DbType.iDB2VarChar, 2).Value = Rubro

                    command.Connection = cn
                    Da.InsertCommand = command
                    command.ExecuteNonQuery()
                    '  ConexionDB2.GetConnection.Close()
                End Using

            End Using

        Catch ex As iDB2Exception
            Throw ex
            Return ex
        End Try

        'Try

        '    Cn = Conection.Conection.Open(Compania_Usuario, Servidor)
        '    Cmd.CommandType = CommandType.StoredProcedure
        '    Cmd.CommandText = Libreria & "SP_SOLSEGORD_IMP_DISTRIBUCION_COSTOS"
        '    Cmd.Parameters.Add("IN_NORDSR", Orden)
        '    Cmd.Parameters.Add("IN_TIPO", Tipo)
        '    Cmd.Parameters.Add("IN_ZONA", Zona)
        '    Cmd.Parameters.Add("IN_CCLNT", cliente)
        '    Cmd.Parameters.Add("IN_RUBRO", Rubro)
        '    Cmd.Connection = Cn
        '    Da.InsertCommand = Cmd
        '    Cmd.ExecuteNonQuery()
        '    Close()
        'Catch ex As iDB2Exception
        '    Throw ex
        '    Return ex

        'End Try

        Return ""
    End Function



    Public Function CheckPoint_Update(ByVal orden As String, ByVal zona As String, ByVal PNDCTR As String, ByVal codigo As String, ByVal Fecha As String) As String
        Dim Cmd As New iDB2Command
        Dim Ds As New DataSet
        Dim Da As New iDB2DataAdapter
        Dim NameSp As String = ""
        NameSp = "DC@RNSLIB.SP_SOLSEGORD_IMP_ACTUALIZAR_CHECKPOINT_XSTRATA"
        Try

            'Cn = Conection.Conection.Open(Compania_Usuario, Servidor)
            '  Cmd.CommandType = CommandType.StoredProcedure
            '  Cmd.CommandText = Libreria & "SP_SOLSEGORD_IMP_INSERTAR_FECHA_CHECKPOINT"

            Using cn As iDB2Connection = ConexionDB2.GetConnection()
                Using command As New iDB2Command(NameSp, cn)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add("IN_NORDSR", iDB2DbType.iDB2VarChar, 10).Value = orden
                    command.Parameters.Add("IN_PNDCTR", iDB2DbType.iDB2VarChar, 10).Value = PNDCTR
                    command.Parameters.Add("IN_ZONA", iDB2DbType.iDB2VarChar, 2).Value = zona
                    command.Parameters.Add("IN_CODIGO", iDB2DbType.iDB2VarChar, 10).Value = codigo
                    command.Parameters.Add("IN_FECHA", iDB2DbType.iDB2VarChar, 30).Value = Fecha

                    command.Connection = cn
                    Da.InsertCommand = command
                    command.ExecuteNonQuery()
                    '  ConexionDB2.GetConnection.Close()

                End Using

            End Using

        Catch ex As iDB2Exception
            Throw ex
            Return "ERROR"
        End Try

        'Try
        '    Cn = Conection.Conection.Open(Compania_Usuario, Servidor)
        '    Cmd.CommandType = CommandType.StoredProcedure
        '    Cmd.CommandText = Libreria & ""
        '    Cmd.Parameters.Add("IN_NORDSR", orden)
        '    Cmd.Parameters.Add("IN_PNDCTR", PNDCTR)
        '    Cmd.Parameters.Add("IN_ZONA", zona)
        '    Cmd.Parameters.Add("IN_CODIGO", codigo)
        '    Cmd.Parameters.Add("IN_FECHA", Fecha)
        '    Cmd.Connection = Cn
        '    Da.InsertCommand = Cmd
        '    Cmd.ExecuteNonQuery()
        '    Close()
        'Catch ex As iDB2Exception
        '    Throw ex
        '    Return "ERROR"
        'End Try
        Return "OK"
    End Function


    Public Function Costo_Ordenes(ByVal Orden As String, ByVal Zona As String, ByVal Tipo As String) As List(Of Entidad.EConsultaCosto)
        Dim COrden As New List(Of Entidad.EConsultaCosto)
        Dim Cmd As New iDB2Command
        Dim Ds As New DataSet
        Dim Da As New iDB2DataAdapter
        Dim NameSp As String = ""
        NameSp = "DC@RNSLIB.SP_SOLSEGORD_IMP_CONSULTA_SEGIMPORTACION_XTRATA_COSTOS"


        Try
            'Cn = Conection.Conection.Open(Compania_Usuario, Servidor)            
            Using cn As iDB2Connection = ConexionDB2.GetConnection()
                Using command As New iDB2Command(NameSp, cn)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add("IN_NORDSR", iDB2DbType.iDB2VarChar, 10).Value = Orden
                    command.Parameters.Add("IN_ZONA", iDB2DbType.iDB2VarChar, 2).Value = Zona
                    command.Parameters.Add("IN_TIPO", iDB2DbType.iDB2VarChar, 2).Value = Tipo
                    command.ExecuteNonQuery()
                    Da.SelectCommand = command
                    Da.Fill(Ds, "Costo")

                    If Ds.Tables("Costo").Rows.Count > 0 Then
                        COrden = CargarCostoConsulta(Ds.Tables("Costo"))
                    End If
                    ConexionDB2.GetConnection.Close()

                End Using
            End Using

            Return COrden
        Catch ex As iDB2Exception
            Throw ex
        End Try


        'Try
        '    Cn = Conection.Conection.Open(Compania_Usuario, Servidor)
        '    Cmd.CommandTimeout = 0
        '    Cmd.CommandType = CommandType.StoredProcedure
        '    Cmd.CommandText = Libreria & "SP_SOLSEGORD_IMP_CONSULTA_SEGIMPORTACION_XTRATA_COSTOS"
        '    Cmd.Parameters.Add("IN_NORDSR", Orden)
        '    Cmd.Parameters.Add("IN_ZONA", Zona)
        '    Cmd.Parameters.Add("IN_TIPO", Tipo)
        '    Cmd.Connection = Cn
        '    Da.SelectCommand = Cmd
        '    Da.Fill(Ds, "Costo")

        '    If Ds.Tables("Costo").Rows.Count > 0 Then
        '        COrden = CargarCostoConsulta(Ds.Tables("Costo"))
        '    End If
        '    Close()
        '    Return COrden
        'Catch ex As iDB2Exception
        '    Throw ex
        'End Try
    End Function
    Public Function CargarCostoConsulta(ByVal dT As DataTable) As List(Of Entidad.EConsultaCosto)
        Dim C As New List(Of Entidad.EConsultaCosto)
        For Each Item As DataRow In dT.Rows
            Dim E As New Entidad.EConsultaCosto
            E.CCODCOS = CStr(Item(0))
            E.CDESCOS = CStr(Item(1))
            If IsDBNull(Item(2)) Then
                E.NVALORI = ""
            Else

                E.NVALORI = (CStr(Item(2)))
            End If

            C.Add(E)
        Next
        Return C
    End Function


    Public Function ChecktPoint_Ordenes(ByVal Orden As String, ByVal Zona As String, ByVal Cliente As String) As List(Of Entidad.ECheckPoint)
        Dim COrden As New List(Of Entidad.ECheckPoint)
        Dim Cmd As New iDB2Command
        Dim Ds As New DataSet
        Dim Da As New iDB2DataAdapter
        Dim NameSp As String = ""
        NameSp = "DC@RNSLIB.SP_SOLSEGORD_IMP_XTRATA_SELECT_CHECKPOINT"

        Try
            'Cn = Conection.Conection.Open(Compania_Usuario, Servidor)            
            Using cn As iDB2Connection = ConexionDB2.GetConnection()
                Using command As New iDB2Command(NameSp, cn)
                    command.CommandType = CommandType.StoredProcedure
                    ' Cmd.CommandText = Libreria & "SP_SOLSEGORD_IMP_CONSULTA_SEGIMPORTACION_XTRATA_DETALLE"
                    ' command.Parameters.Add("IN_NORDSR", iDB2DbType.iDB2VarChar, 10).Value = Orden
                    ' command.Parameters.Add("IN_ZONA", iDB2DbType.iDB2VarChar, 2).Value = Zona
                    command.Parameters.Add("IN_NORDSR", iDB2DbType.iDB2VarChar, 10).Value = Orden
                    command.Parameters.Add("IN_PNDCTR", iDB2DbType.iDB2VarChar, 10).Value = ""
                    command.Parameters.Add("IN_ZONA", iDB2DbType.iDB2VarChar, 2).Value = Zona
                    command.Parameters.Add("IN_CCLNT", iDB2DbType.iDB2Numeric, 10).Value = Cliente
                    'Cmd.Parameters.Add("IN_ZONA", Zona)
                    ' Cmd.Parameters.Add("IN_CCLNT", Cliente)
                    'Cmd.Connection = cn
                    command.ExecuteNonQuery()
                    Da.SelectCommand = command
                    Da.Fill(Ds, "Orden")

                    If Ds.Tables("Orden").Rows.Count > 0 Then
                        COrden = CargarCheckPoint(Ds.Tables("Orden"))
                    End If
                    ConexionDB2.GetConnection.Close()

                End Using
            End Using

            Return COrden
        Catch ex As iDB2Exception
            Throw ex
        End Try


        'Try
        '    Cn = Conection.Conection.Open(Compania_Usuario, Servidor)
        '    Cmd.CommandTimeout = 0
        '    Cmd.CommandType = CommandType.StoredProcedure
        '    Cmd.CommandText = Libreria & "SP_SOLSEGORD_IMP_XTRATA_SELECT_CHECKPOINT"
        '    Cmd.Parameters.Add("IN_NORDSR", Orden)
        '    Cmd.Parameters.Add("IN_PNDCTR", "")
        '    Cmd.Parameters.Add("IN_ZONA", Zona)
        '    Cmd.Parameters.Add("IN_CCLNT", Cliente)
        '    Cmd.Connection = Cn
        '    Da.SelectCommand = Cmd
        '    Da.Fill(Ds, "Orden")

        '    If Ds.Tables("Orden").Rows.Count > 0 Then
        '        COrden = CargarCheckPoint(Ds.Tables("Orden"))
        '    End If
        '    Close()
        '    Return COrden
        'Catch ex As iDB2Exception
        '    Throw ex
        'End Try
    End Function


    Public Function CargarCheckPoint(ByVal dT As DataTable) As List(Of Entidad.ECheckPoint)
        Dim C As New List(Of Entidad.ECheckPoint)
        For Each Item As DataRow In dT.Rows
            Dim E As New Entidad.ECheckPoint
            'PNCDCO, PNCDNG, PNCDZO, PNDCPL, PNNMOS, PNCDRG, PNCDOP, DCASCI, DCTPOS, DDREGI, DCDSME, B.TCMPCL
            'L.DCDSAB AS DESPAC, K.DCDSRG, A.DCNAVE, C.DDNAVE, C.DDTDES, D.DCDSAB, A.DCCANA, M.DCOBSE,
            'E.DDNUME, E.DDPGDR, J.DDINIA AS DDSENA,J.DDFINA AS DOSENA,E.DDINSP, F.DDFINA AS DDAFOR,
            'G.DDINIA AS DDPRES, H.DDINIA AS DDLEVA, I.DDFINA AS DDRETI,E.DCNMRM,E.DDCREC,E.DDTREC

            E.CODIGO = CStr(Item(0))
            E.DESCRIPCION = CStr(Item(1))
            If IsDBNull(Item(2)) Then
                E.FECHA = ""
            Else

                E.FECHA = FormatoFecha(CStr(Item(2)))
            End If

            C.Add(E)
        Next
        Return C
    End Function


    Public Function Detalle_Ordenes(ByVal Orden As String, ByVal Zona As String) As List(Of Entidad.EOrdenDetalleXSTRATA)
        Dim COrden As New List(Of Entidad.EOrdenDetalleXSTRATA)
        Dim Cmd As New iDB2Command
        Dim Ds As New DataSet
        Dim Da As New iDB2DataAdapter
        Dim NameSp As String = ""
        NameSp = "DC@RNSLIB.SP_SOLSEGORD_IMP_CONSULTA_SEGIMPORTACION_XTRATA_DETALLE"
        Try
            'Cn = Conection.Conection.Open(Compania_Usuario, Servidor)
            ' Cn = Conection.Conection.Open(Compania_Usuario, Servidor)
            Using cn As iDB2Connection = ConexionDB2.GetConnection()
                Using command As New iDB2Command(NameSp, cn)

                    '   Cmd.CommandTimeout = 0
                    command.CommandType = CommandType.StoredProcedure
                    ' Cmd.CommandText = Libreria & "SP_SOLSEGORD_IMP_CONSULTA_SEGIMPORTACION_XTRATA_DETALLE"
                    command.Parameters.Add("IN_NORDSR", iDB2DbType.iDB2VarChar, 10).Value = Orden
                    command.Parameters.Add("IN_ZONA", iDB2DbType.iDB2VarChar, 2).Value = Zona
                    'Cmd.Connection = cn
                    command.ExecuteNonQuery()
                    Da.SelectCommand = command
                    Da.Fill(Ds, "Orden")

                    If Ds.Tables("Orden").Rows.Count > 0 Then
                        COrden = CargarOrdenDetalle(Ds.Tables("Orden"))
                    End If
                    ConexionDB2.GetConnection.Close()

                End Using
            End Using

            Return COrden
        Catch ex As iDB2Exception
            Throw ex
        End Try
    End Function


    Public Function CargarOrdenDetalle(ByVal dT As DataTable) As List(Of Entidad.EOrdenDetalleXSTRATA)
        Dim C As New List(Of Entidad.EOrdenDetalleXSTRATA)
        For Each Item As DataRow In dT.Rows
            Dim E As New Entidad.EOrdenDetalleXSTRATA
            'PNCDCO, PNCDNG, PNCDZO, PNDCPL, PNNMOS, PNCDRG, PNCDOP, DCASCI, DCTPOS, DDREGI, DCDSME, B.TCMPCL
            'L.DCDSAB AS DESPAC, K.DCDSRG, A.DCNAVE, C.DDNAVE, C.DDTDES, D.DCDSAB, A.DCCANA, M.DCOBSE,
            'E.DDNUME, E.DDPGDR, J.DDINIA AS DDSENA,J.DDFINA AS DOSENA,E.DDINSP, F.DDFINA AS DDAFOR,
            'G.DDINIA AS DDPRES, H.DDINIA AS DDLEVA, I.DDFINA AS DDRETI,E.DCNMRM,E.DDCREC,E.DDTREC

            E.NSERIE = CStr(Item(0))
            E.NMRODC = CStr(Item(1))
            E.NMITOC = CStr(Item(2))
            E.VALADV = CStr(Item(3))
            E.VALIPM = CStr(Item(4))
            E.VALIGV = CStr(Item(5))

            If IsDBNull(Item(6)) Then
                E.VALGAS = ""
            Else
                E.VALGAS = CStr(Item(6))
            End If
            If IsDBNull(Item(7)) Then
                E.VALCOM = ""
            Else
                E.VALCOM = CStr(Item(7))
            End If

            If IsDBNull(Item(8)) Then
                E.VALTRA = ""
            Else
                E.VALTRA = CStr(Item(8))
            End If

            C.Add(E)
        Next
        Return C
    End Function


    Public Function FechasCheckpoint_Insert(ByVal EDetalle As Entidad.EOrdenXSTRATA) As String
        Dim Cmd As New iDB2Command
        Dim Ds As New DataSet
        Dim Da As New iDB2DataAdapter
        Dim NameSp As String = ""

        NameSp = "DC@RNSLIB.SP_SOLSEGORD_IMP_INSERTAR_FECHA_CHECKPOINT"

        Try

            'Cn = Conection.Conection.Open(Compania_Usuario, Servidor)
            '  Cmd.CommandType = CommandType.StoredProcedure
            '  Cmd.CommandText = Libreria & "SP_SOLSEGORD_IMP_INSERTAR_FECHA_CHECKPOINT"

            Using cn As iDB2Connection = ConexionDB2.GetConnection()
                Using command As New iDB2Command(NameSp, cn)
                    command.CommandType = CommandType.StoredProcedure

                    command.Parameters.Add("IN_PNCDTR", EDetalle.PNDCTR)
                    command.Parameters.Add("IN_RECEPCION", EDetalle.DDRDDC)
                    command.Parameters.Add("IN_CARGA", EDetalle.DDCRDP)
                    command.Parameters.Add("IN_EMBARQUE", EDetalle.DDOEMB)
                    command.Parameters.Add("IN_SOBREESTADIA", EDetalle.DNSBRE)
                    command.Parameters.Add("IN_DLIBRES", EDetalle.DNDSLB)
                    command.Parameters.Add("IN_DDETLG ", EDetalle.DDETLG)
                    command.Parameters.Add("IN_DDNAVE ", EDetalle.DDNAVE)
                    command.Parameters.Add("IN_DDTDES ", EDetalle.DDTDES)
                    command.Parameters.Add("IN_DDOBVL ", EDetalle.DDOBVL)
                    command.Parameters.Add("IN_DDAFPR ", EDetalle.DDAFPR)
                    command.Parameters.Add("IN_VDDFINA ", EDetalle.VDDFINA)
                    command.Parameters.Add("IN_DDANUM ", EDetalle.DDANUM)
                    command.Parameters.Add("IN_DDNUME ", EDetalle.DDNUME)
                    command.Parameters.Add("IN_DDPGDR ", EDetalle.DDPGDR)
                    command.Parameters.Add("IN_DDAFOR", EDetalle.DDAFOR)
                    command.Parameters.Add("IN_DDPRES", EDetalle.DDPRES)
                    command.Parameters.Add("IN_DDLEVA", EDetalle.DDLEVA)
                    command.Parameters.Add("IN_DDRETI", EDetalle.DDRETI)
                    command.Parameters.Add("IN_DDTREC", EDetalle.DDTREC)

                    command.Connection = cn
                    Da.InsertCommand = command
                    command.ExecuteNonQuery()

                    ConexionDB2.GetConnection.Close()

                End Using

            End Using

        Catch ex As iDB2Exception
            Throw ex
        End Try
        Return ""
    End Function

    Public Function CargarOrden(ByVal dT As DataTable) As List(Of Entidad.EOrdenXSTRATA)
        Dim C As New List(Of Entidad.EOrdenXSTRATA)
        For Each Item As DataRow In dT.Rows
            Dim E As New Entidad.EOrdenXSTRATA

            E.DCASCI = CStr(Item(7))
            E.DCDSME = CStr(Item(10))
            E.DCREFE = CStr(Item(12))
            E.DCTPOS = CStr(Item(8))
            E.DDREGI = CStr(Item(9))
            E.PNCDCO = CStr(Item(0))
            E.PNCDNG = CStr(Item(1))
            E.PNCDOP = CStr(Item(6))
            E.PNCDRG = CStr(Item(5))
            E.PNCDZO = CStr(Item(2))
            E.PNDCPL = CStr(Item(3))
            E.PNNMOS = CStr(Item(4))
            E.TCMPCL = CStr(Item(11))
            E.DCDSRG = CStr(Item(13))
            E.DCDSOP = CStr(Item(14))
            E.PNDCTR = CStr(Item(15))
            E.DESPAC = CStr(Item(36))
            If IsDBNull(Item(17)) Then
                E.DCDSRG = ""
            Else
                E.DCDSRG = CStr(Item(17))
            End If
            If IsDBNull(Item(18)) Then
                E.DCNAVE = ""
            Else
                E.DCNAVE = CStr(Item(18))
            End If

            If IsDBNull(Item(19)) Then
                E.DDNAVE = ""
            Else
                E.DDNAVE = CStr(Item(19))
            End If

            If IsDBNull(Item(20)) Then
                E.DDTDES = ""
            Else
                E.DDTDES = FormatoFecha(CStr(Item(20)))
            End If

            If IsDBNull(Item(21)) Then
                E.DCDSAB = ""
            Else
                E.DCDSAB = CStr(Item(21))
            End If

            If IsDBNull(Item(22)) Then
                E.DCCANA = ""
            Else
                E.DCCANA = CStr(Item(22))
            End If

            If IsDBNull(Item(23)) Then
                E.DCOBSE = ""
            Else
                E.DCOBSE = CStr(Item(23))
            End If

            If IsDBNull(Item(24)) Then
                E.DDNUME = ""
            Else
                E.DDNUME = FormatoFecha(CStr(Item(24)))
            End If

            If IsDBNull(Item(25)) Then
                E.DDPGDR = ""
            Else
                E.DDPGDR = CStr(Item(25))
            End If

            If IsDBNull(Item(26)) Then
                E.DDSENA = ""
            Else
                E.DDSENA = FormatoFecha(CStr(Item(26)))
            End If

            If IsDBNull(Item(27)) Then
                E.DOSENA = ""
            Else
                E.DOSENA = FormatoFecha(CStr(Item(27)))
            End If

            If IsDBNull(Item(28)) Then
                E.DDINSP = ""
            Else
                E.DDINSP = FormatoFecha(CStr(Item(28)))
            End If

            If IsDBNull(Item(29)) Then
                E.DDAFOR = ""
            Else
                E.DDAFOR = FormatoFecha(CStr(Item(29)))
            End If

            If IsDBNull(Item(30)) Then
                E.DDPRES = ""
            Else
                E.DDPRES = FormatoFecha(CStr(Item(30)))
            End If

            If IsDBNull(Item(31)) Then
                E.DDLEVA = ""
            Else
                E.DDLEVA = FormatoFecha(CStr(Item(31)))
            End If

            If IsDBNull(Item(32)) Then
                E.DDRETI = ""
            Else
                E.DDRETI = FormatoFecha(CStr(Item(32)))
            End If

            If IsDBNull(Item(33)) Then
                E.DCNMRM = ""
            Else
                E.DCNMRM = CStr(Item(33))
            End If

            If IsDBNull(Item(34)) Then
                E.DDCREC = ""
            Else
                E.DDCREC = FormatoFecha(CStr(Item(34)))
            End If

            If IsDBNull(Item(35)) Then
                E.DDTREC = ""
            Else
                E.DDTREC = FormatoFecha(Item(35))
            End If

            If IsDBNull(Item(37)) Then
                E.NRUC = ""
            Else
                E.NRUC = (Item(37))
            End If

            If IsDBNull(Item(38)) Then
                E.LIQUIDADOR = ""
            Else
                E.LIQUIDADOR = (Item(38))
            End If

            If IsDBNull(Item(39)) Then
                E.DDANUM = ""
            Else
                E.DDANUM = FormatoFecha(Item(39))
            End If

            If IsDBNull(Item(40)) Then
                E.DDETLG = ""
            Else
                E.DDETLG = FormatoFecha(Item(40))
            End If

            If IsDBNull(Item(41)) Then
                E.DDOBVL = ""
            Else
                E.DDOBVL = FormatoFecha(Item(41))
            End If
            'DDAFPR
            If IsDBNull(Item(42)) Then
                E.DDAFPR = ""
            Else
                E.DDAFPR = FormatoFecha(Item(42))
            End If

            If IsDBNull(Item(43)) Then
                E.DDOBDT = ""
            Else
                E.DDOBDT = FormatoFecha(Item(43))
            End If

            If IsDBNull(Item(44)) Then
                E.DDRETI1 = ""
            Else
                E.DDRETI1 = FormatoFecha(Item(44))
            End If

            If IsDBNull(Item(45)) Then
                E.DCINDD = ""
            Else
                If E.DCINDD = (Item(45)) Then
                    If E.DCINDD = "X" Then
                        E.DCINDD = "COMPLETA"
                    Else
                        E.DCINDD = E.DDRETI1
                    End If
                End If
            End If

            If IsDBNull(Item(46)) Then
                E.VDDFINA = ""
            Else
                E.VDDFINA = FormatoFecha(Item(46))
            End If

            If IsDBNull(Item(47)) Then
                E.DCOBSE1 = ""
            Else
                E.DCOBSE1 = (Item(47))
            End If

            If IsDBNull(Item(48)) Then
                E.FECHABL = ""
            Else
                E.FECHABL = FormatoFecha(Item(48))
            End If

            If IsDBNull(Item(49)) Then
                E.TCMPRO = ""
            Else
                E.TCMPRO = (Item(49))
            End If

            If IsDBNull(Item(50)) Then
                E.DCCTRL = ""
            Else
                E.DCCTRL = (Item(50))
            End If

            If IsDBNull(Item(51)) Then
                E.DCDUIDUE = ""
            Else
                E.DCDUIDUE = (Item(51))
            End If


            If IsDBNull(Item(52)) Then
                E.DDRDDC = ""
            Else
                E.DDRDDC = (Item(52))
            End If

            If IsDBNull(Item(53)) Then
                E.DDCRDP = ""
            Else
                E.DDCRDP = (Item(53))
            End If

            If IsDBNull(Item(54)) Then
                E.DDOEMB = ""
            Else
                E.DDOEMB = (Item(54))
            End If

            If IsDBNull(Item(55)) Then
                E.DNSBRE = ""
            Else
                E.DNSBRE = (Item(55))
            End If

            If IsDBNull(Item(56)) Then
                E.DNDSLB = ""
            Else
                E.DNDSLB = (Item(56))
            End If

            If IsDBNull(Item(57)) Then
                E.PCNMDC = ""
            Else
                E.PCNMDC = (Item(57))
            End If

            If IsDBNull(Item(58)) Then
                E.TZNFCC = ""
            Else
                E.TZNFCC = (Item(58))
            End If

            If IsDBNull(Item(59)) Then
                E.DCMOTI = ""
            Else
                E.DCMOTI = (Item(59))
            End If


            C.Add(E)
        Next
        Return C

    End Function


    Public Shared Function FormatoFecha(ByVal fecha As String) As String
        If fecha = "" Then
            Return ""
        Else
            Dim año As String = fecha.Substring(0, 10)
            'Dim mes As String = fecha.Substring(6, 2)
            'Dim dia As String = fecha.Substring(9, 2)
            Return año '& "/" & mes & "/" & dia
        End If

    End Function


    Public Function Envia_WebService_New(ByVal Cliente As String, ByVal Orden As String, ByVal Zona As String, ByVal PNDCTR As String, ByVal BL As String, ByVal Fecha As String) As String
        Dim cadena As String = ""
        Dim cadena1 As String = ""
        Dim dtbl As DataTable
        Dim NEmbarcador As String
        dtbl = Devuelve_BL(PNDCTR)

        'If dtbl.Rows.Count > 0 Then

        Dim dstTemp1 As DataSet = Nothing

        NEmbarcador = Envio_Prod.Get_FileNumber("D82F0842-957E-4A2F-ABE0-B5113C2A7B20", "75", BL)

        If NEmbarcador = "" Then
            Return MsgBox("No se encuentra N° de Embarcador", MsgBoxStyle.Exclamation, "Aviso")
            'Return cadena
        ElseIf Trim(NEmbarcador) = "Error Inesperado" Then
            Return "WebService MIQ : Get_FileNumber indica Error Inesperado"
        End If
        'If dstTemp1.Tables(0).Rows.Count > 0 Then
        '    NEmbarcador = dstTemp1.Tables("t005").Rows(0).Item(0)
        'Else
        '    MsgBox("No se encuentra N° de Embarcador", MsgBoxStyle.Exclamation, "Aviso")
        '    Return cadena '
        'End If
        'End If

        '06OE12118757
        pstrcliente = Cliente
        pstrNEmbarcador = NEmbarcador ' "PE201207MI02287-PE0012"
        pstrOrden = Orden
        pstrPNDCTR = PNDCTR
        pstrZona = Zona
        pstrfecha = Fecha.Substring(6, 4) & Fecha.Substring(3, 2) & Fecha.Substring(0, 2)
        pstrbl = BL

        If NEmbarcador = "CONOCIMIENTO DE EMBARQUE ERRONEO/INEXISTENTE, POR FAVOR VERIFICAR" Then
            Return NEmbarcador
        End If

        cadena = Enviar_Enbarque_T005_New(Cliente, Orden, Zona, PNDCTR, NEmbarcador)
        If cadena = "Transacción Finalizada - BL - INSERTADO" Or cadena = "Transacción Finalizada - BL - ACTUALIZADO" Or cadena = "" Then
        Else
            Return "WebService MIQ : Put_BL indica -> " & cadena
        End If

        'cadena = Enviar_Items_T007(Cliente, Orden, Zona, PNDCTR, "PE201207MI02287-PE0012")
        'If cadena = "Ok" Or cadena = "" Then
        'Else
        '   Return cadena
        'End If

        cadena = Enviar_CheckPoint_T008_New(Cliente, Orden, Zona, NEmbarcador)
        If cadena = "Transacción Finalizada - CHECKPOINT BL INSERTADO" Or cadena = "Transacción Finalizada - CHECKPOINT BL ACTUALIZADO" Or cadena = "" Then
        Else
            Return "WebService MIQ : Checkpoint indica -> " & cadena
        End If

        ''Enviar_Costos() 
        cadena = Enviar_Costos_T006_new()
        If cadena = "Transacción Finalizada - COSTO INSERTADO" Or cadena = "Transacción Finalizada - COSTO ACTUALIZADO" Then
            cadena = "Ok"
        Else
            Return "WebService MIQ : Costo -> " & cadena
        End If

        Return cadena
    End Function


    Public Function Devuelve_BL(ByVal PNDCTR As String)
        Dim dt As DataTable
        Dim NameSp As String = ""
        NameSp = "DC@RNSLIB.SP_SOLSEGORD_IMP_SELECT_BL"
        dt = New DataTable
        Try
            Using cn As iDB2Connection = ConexionDB2.GetConnection()
                Using command As New iDB2Command(NameSp, cn)
                    Using adapter As New iDB2DataAdapter
                        command.CommandType = CommandType.StoredProcedure
                        command.Parameters.Add("IN_PNDCTR", iDB2DbType.iDB2VarChar).Value = PNDCTR
                        adapter.SelectCommand = command
                        adapter.Fill(dt)
                    End Using
                End Using
            End Using
            'Close()
        Catch ex As Exception
        End Try
        Return dt
    End Function


    Public Function Enviar_Enbarque_T005_New(ByVal Cliente As String, ByVal Orden As String, ByVal Zona As String, ByVal PNDCTR As String, ByVal NEmbarcador As String) As String
        Dim dstTemp As New DataSet
        Dim strCadena As String = ""
        Dim oDt As DataTable
        Try
            oDt = Lista_Datos_T005_New(Cliente, Orden, Zona, PNDCTR, NEmbarcador)

            If oDt.Rows.Count > 0 Then
                'dstTemp.Tables.Add(oDt.Copy)
                strCadena = Envio_Prod.Put_BL(oDt.Rows(0).Item(0).ToString, oDt.Rows(0).Item(1).ToString, oDt.Rows(0).Item(2).ToString, oDt.Rows(0).Item(3).ToString, _
                                                oDt.Rows(0).Item(4).ToString, oDt.Rows(0).Item(5).ToString, oDt.Rows(0).Item(6).ToString, oDt.Rows(0).Item(7).ToString, _
                                                oDt.Rows(0).Item(8).ToString, oDt.Rows(0).Item(9).ToString, oDt.Rows(0).Item(10).ToString, oDt.Rows(0).Item(11).ToString, _
                                                oDt.Rows(0).Item(12).ToString)

                'strCadena = Envio_Prueba.Put_BL(oDt.Rows(0).Item(0).ToString, oDt.Rows(0).Item(1).ToString, oDt.Rows(0).Item(2).ToString, oDt.Rows(0).Item(3).ToString, _
                '                                oDt.Rows(0).Item(4).ToString, oDt.Rows(0).Item(5).ToString, oDt.Rows(0).Item(6).ToString, oDt.Rows(0).Item(7).ToString, _
                '                                oDt.Rows(0).Item(8).ToString, oDt.Rows(0).Item(9).ToString, oDt.Rows(0).Item(10).ToString, oDt.Rows(0).Item(11).ToString, _
                '                                oDt.Rows(0).Item(12).ToString)


                'strCadena = Envio_Prueba.Put_BL(DSTEMP, dstTemp, EnviaInformacion.typeTable.t005, "SIDRNS , NORDAGE , DORDAGE , STIPREG , SNOMTER ,SCANAL , SDIALIB , SSOBEST ,SOBS ,SDUA")
            End If
        Catch ex As Exception
            strCadena = "Error"
        End Try
        Return strCadena
    End Function



    Public Function Lista_Datos_T005_New(ByVal Cliente As String, ByVal Orden As String, ByVal Zona As String, ByVal PNDCTR As String, ByVal embarcador As String) As DataTable
        Dim dt As DataTable
        Dim NameSp As String = ""
        NameSp = "DC@RNSLIB.SP_SOLSEGORD_IMP_XTRATA_EMBARQUE_Q01_NEW"
        dt = New DataTable
        Try
            Using cn As iDB2Connection = ConexionDB2.GetConnection()
                Using command As New iDB2Command(NameSp, cn)
                    Using adapter As New iDB2DataAdapter
                        command.CommandType = CommandType.StoredProcedure
                        command.Parameters.Add("IN_NORSCI", iDB2DbType.iDB2VarChar, 10).Value = Orden
                        command.Parameters.Add("IN_PNDCTR", iDB2DbType.iDB2VarChar).Value = PNDCTR
                        command.Parameters.Add("IN_ZONA", iDB2DbType.iDB2VarChar).Value = Zona
                        command.Parameters.Add("IN_CCLNT", iDB2DbType.iDB2Integer).Value = Cliente
                        command.Parameters.Add("IN_EMBARCADOR", iDB2DbType.iDB2VarChar).Value = embarcador
                        adapter.SelectCommand = command
                        adapter.Fill(dt)
                    End Using
                End Using
            End Using
            'Close()
        Catch ex As Exception
        End Try
        Return dt
    End Function


    Public Function Enviar_CheckPoint_T008_New(ByVal Cliente As String, ByVal Orden As String, ByVal Zona As String, ByVal NEmbarcador As String) As String
        Dim dstTemp As New DataSet
        Dim strCadena As String = ""
        Dim oDt As DataTable
        'oDt = Lista_Datos_T008(Cliente, Orden, Zona)
        'Try
        '    If oDt.Rows.Count > 0 Then
        '        dstTemp.Tables.Add(oDt.Copy)
        '        strCadena = Envio.sendDataSet(dstTemp, EnviaInformacion.typeTable.t008)
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
        'Return strCadena

        oDt = Lista_Datos_T008_New(Cliente, Orden, Zona, NEmbarcador)
        Try
            If oDt.Rows.Count > 0 Then
                ' dstTemp.Tables.Add(oDt.Copy)

                For i = 0 To oDt.Rows.Count - 1
                    strCadena = Envio_Prod.Put_CheckPoint_BL(oDt.Rows(i).Item(0).ToString, oDt.Rows(i).Item(1).ToString, _
                                                               oDt.Rows(i).Item(2).ToString, oDt.Rows(i).Item(3).ToString, _
                                                               oDt.Rows(i).Item(4).ToString, oDt.Rows(i).Item(5).ToString, _
                                                               oDt.Rows(i).Item(6).ToString)

                    If strCadena.Trim = "" Or (strCadena.Trim <> "Transacción Finalizada - CHECKPOINT BL INSERTADO" And strCadena.Trim <> "Transacción Finalizada - CHECKPOINT BL ACTUALIZADO") Then
                        Return strCadena
                    End If

                Next

                'strCadena = Envio.sendDataSet(dstTemp, EnviaInformacion.typeTable.t008)
            End If



        Catch ex As Exception
            ' MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strCadena = "Error"
        End Try
        Return strCadena

    End Function

    Public Function Lista_Datos_T008_New(ByVal Cliente As String, ByVal Orden As String, ByVal Zona As String, ByVal embarcador As String) As DataTable
        Dim dt As DataTable
        Dim NameSp As String = ""
        NameSp = "DC@RNSLIB.SP_SOLSEGORD_IMP_XTRATA_CHECKPOINT_Q01_NEW"
        dt = New DataTable
        Try
            Using cn As iDB2Connection = ConexionDB2.GetConnection()
                Using command As New iDB2Command(NameSp, cn)
                    Using adapter As New iDB2DataAdapter
                        command.CommandType = CommandType.StoredProcedure
                        command.Parameters.Add("IN_NORSCI", iDB2DbType.iDB2VarChar, 10).Value = Orden
                        command.Parameters.Add("IN_PNDCTR", iDB2DbType.iDB2VarChar).Value = ""
                        command.Parameters.Add("IN_ZONA", iDB2DbType.iDB2VarChar).Value = Zona
                        command.Parameters.Add("IN_CCLNT", iDB2DbType.iDB2Integer).Value = Cliente
                        command.Parameters.Add("IN_EMBARCADOR", iDB2DbType.iDB2VarChar).Value = embarcador
                        adapter.SelectCommand = command
                        adapter.Fill(dt)
                    End Using
                End Using
            End Using
        Catch ex As Exception
        End Try
        Return dt
    End Function


    Public Function Enviar_Costos_T006_new() As String
        Dim dstTemp As New DataSet
        Dim strCadena As String = ""
        Dim oDt As DataTable
        oDt = Lista_Datos_T006_New(pstrcliente, pstrOrden, pstrZona, pstrPNDCTR, pstrNEmbarcador, pstrfecha, pstrbl)
        If oDt.Rows.Count > 0 Then
            dstTemp.Tables.Add(oDt.Copy)
            ' strCadena = Envio.sendDataSet(dstTemp, EnviaInformacion.typeTable.t006)

            If dstTemp.Tables(0).Rows.Count > 0 Then

                For i = 0 To dstTemp.Tables(0).Rows.Count - 1
                    strCadena = Envio_Prod.Put_Costs(oDt.Rows(i).Item(0).ToString, oDt.Rows(i).Item(1).ToString, oDt.Rows(i).Item(2).ToString, _
                                                      oDt.Rows(i).Item(3).ToString, oDt.Rows(i).Item(4).ToString, oDt.Rows(i).Item(5).ToString, _
                                                      oDt.Rows(i).Item(6).ToString, oDt.Rows(i).Item(7).ToString, oDt.Rows(i).Item(8).ToString, _
                                                      oDt.Rows(i).Item(9).ToString, oDt.Rows(i).Item(10).ToString, oDt.Rows(i).Item(11).ToString)

                    If strCadena.Trim = "" Or (strCadena.Trim <> "Transacción Finalizada - COSTO INSERTADO" And strCadena.Trim <> "Transacción Finalizada - COSTO ACTUALIZADO") Then
                        Return strCadena
                    End If
                Next

                'Dim DT_T006 As New DataTable
                'DT_T006 = dstTemp.Tables(0).Copy
                'Dim dstT006 As DataSet = New DataSet
                'Dim TOT_FILA_T006 As Int32 = 0
                'Dim drT006 As DataRow
                'Dim dtT006TMP As New DataTable
                'dtT006TMP = DT_T006.Clone
                'TOT_FILA_T006 = DT_T006.Rows.Count - 1
                'For FILA As Integer = 0 To TOT_FILA_T006
                '    dtT006TMP.Rows.Clear()
                '    dstT006.Tables.Clear()
                '    drT006 = dtT006TMP.NewRow
                '    For COLUMNA As Integer = 0 To dtT006TMP.Columns.Count - 1
                '        drT006(COLUMNA) = DT_T006.Rows(FILA)(COLUMNA)
                '    Next
                '    dtT006TMP.Rows.Add(drT006)
                '    dstT006.Tables.Add(dtT006TMP.Copy)
                '    strCadena = Envio.sendDataSet(dstT006, EnviaInformacion.typeTable.t006)
                'Next
            End If
        End If
        'dstT011.Tables.Add(dstTemp.Tables(0).Copy)
        'dstT006.Tables.Add(dstTemp.Tables(1).Copy)
        'strCadena = objRansYrc.sendDataSet(dstT011, typeTable.t011)
        'strCadena = objRansYrc.sendDataSet(dstT006, typeTable.t006)
        'If strCadena = "Ok" Then
        '    MsgBox("N° Orden " & pstrOrden & " consumida satisfactoriamente", MsgBoxStyle.Exclamation, "Aviso")
        'ElseIf strCadena = "" Then
        'Else
        '    MsgBox(strCadena, MsgBoxStyle.Information, "Aviso")
        'End If
        Return strCadena
    End Function

    Public Function Lista_Datos_T006_New(ByVal Cliente As String, ByVal Orden As String, ByVal Zona As String, ByVal PNDCTR As String, ByVal embarcador As String, ByVal fecha As String, ByVal BL As String) As DataTable
        Dim dt As DataTable
        Dim NameSp As String = ""
        NameSp = "DC@RNSLIB.SP_SOLSEGORD_IMP_XTRATA_SUSTENTO_COSTOS_Q01_NEW"
        dt = New DataTable
        Try
            Using cn As iDB2Connection = ConexionDB2.GetConnection()
                Using command As New iDB2Command(NameSp, cn)
                    Using adapter As New iDB2DataAdapter
                        command.CommandType = CommandType.StoredProcedure
                        command.Parameters.Add("IN_NORSCI", iDB2DbType.iDB2VarChar, 10).Value = Orden
                        command.Parameters.Add("IN_PNDCTR", iDB2DbType.iDB2VarChar).Value = PNDCTR
                        command.Parameters.Add("IN_ZONA", iDB2DbType.iDB2VarChar).Value = Zona
                        command.Parameters.Add("IN_CCLNT", iDB2DbType.iDB2Integer).Value = Cliente
                        command.Parameters.Add("IN_EMBARCADOR", iDB2DbType.iDB2VarChar).Value = embarcador
                        command.Parameters.Add("IN_FECHA", iDB2DbType.iDB2Numeric).Value = fecha
                        command.Parameters.Add("IN_BL", iDB2DbType.iDB2Numeric).Value = BL
                        adapter.SelectCommand = command
                        adapter.Fill(dt)
                    End Using
                End Using
            End Using
        Catch ex As Exception
        End Try
        Return dt
    End Function


End Class
