Imports System.Data
Imports System.Collections.Generic
Imports System.Text
Imports System.Data.Common
Imports IBM.Data.DB2.iSeries
Imports System.Collections
Imports ENTD = Emp_Entity



Public Class DA_OrdenServicio
    Public Shared Function ListadoOrdenesServicio(ByVal Cpnia As String, ByVal Servidor As String, ByVal Cliente As Integer, ByVal tipo As String, ByVal zona As Integer, ByVal division As String, ByVal orden As String, ByVal tipoexp As String, ByVal FechaI As String, ByVal FechaF As String, ByVal periodo As String) As List(Of ENTD.BE_OrdenServicio)

        Dim NameSp As String = ""
        NameSp = "LIBORDAG.SP_TRANSFERENCIA_CONSULTAEXP3"

        Dim ListOS As List(Of ENTD.BE_OrdenServicio) = New List(Of ENTD.BE_OrdenServicio)
        Dim fecha As String
        Dim dfecha As DateTime
        Try
            Dim cmd As iDB2DataReader
            Using cn As iDB2Connection = ConexionDB2.Open(Cpnia, Servidor)
                Using command As New iDB2Command(NameSp, cn)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add("IN_COMPANIA", iDB2DbType.iDB2VarChar, 2).Value = Cpnia
                    command.Parameters.Add("IN_CODIGO", iDB2DbType.iDB2Integer).Value = Cliente
                    command.Parameters.Add("IN_TIPO", iDB2DbType.iDB2VarChar, 2).Value = tipo
                    command.Parameters.Add("IN_ZONA", iDB2DbType.iDB2Integer).Value = zona
                    command.Parameters.Add("IN_DIV", iDB2DbType.iDB2VarChar, 1).Value = division
                    command.Parameters.Add("IN_ORDEN", iDB2DbType.iDB2VarChar, 10).Value = orden
                    command.Parameters.Add("IN_TIPOEXP", iDB2DbType.iDB2VarChar, 1).Value = tipoexp.Trim
                    command.Parameters.Add("IN_FECHAI", iDB2DbType.iDB2VarChar).Value = FechaI
                    command.Parameters.Add("IN_FECHAF", iDB2DbType.iDB2VarChar).Value = FechaF
                    command.Parameters.Add("IN_PERIODO", iDB2DbType.iDB2VarChar).Value = periodo
                    cmd = command.ExecuteReader
                    While (cmd.Read())
                        Dim OS As ENTD.BE_OrdenServicio = New ENTD.BE_OrdenServicio()
                        With OS
                            .PNCDTR = Convert.ToString(cmd("PNCDTR"))
                            .PNNMOS = Convert.ToString(cmd("PNNMOS"))
                            .TCMPCL = Convert.ToString(cmd("TCMPCL"))
                            .DCDSME = Convert.ToString(cmd("DCDSME"))
                            .DCNAVE = Convert.ToString(cmd("DCNAVE")).Trim
                            fecha = Convert.ToString(cmd("DDNAVE")).ToString
                            If fecha <> "" And fecha.Length >= 10 Then
                                .DDNAVE = fecha.Substring(0, 2) & "/" & fecha.Substring(3, 2) & "/" & fecha.Substring(6, 4)
                            End If
                            .DCDUIDUE = Convert.ToString(cmd("DCDUIDUE")).Trim
                            .DCDICT = Convert.ToString(cmd("DCDICT"))
                            .DLUGME = Convert.ToString(cmd("DLUGME"))
                            If .DLUGME = "P" Then
                                .DLUGME = "Planta"
                            ElseIf .DLUGME = "A" Then
                                .DLUGME = "Almacen"
                            End If
                            .DDDESP = Convert.ToString(cmd("DDDESP"))
                            If fecha <> "" Then
                                dfecha = Convert.ToDateTime(cmd("DDNAVE"))
                                dfecha = dfecha.AddDays(30)
                                fecha = dfecha.ToString
                            End If


                            .DDVNRE = Convert.ToString(cmd("DDVNRE"))
                            If .DDVNRE = "" Then
                                If fecha <> "" Then
                                    .DDVNRE = fecha.Substring(0, 2) & "/" & fecha.Substring(3, 2) & "/" & fecha.Substring(6, 4)
                                Else
                                    .DDVNRE = ""
                                End If
                            Else
                                .DDVNRE = Convert.ToString(cmd("DDVNRE")).Substring(0, 2) & "/" & Convert.ToString(cmd("DDVNRE")).Substring(3, 2) & "/" & Convert.ToString(cmd("DDVNRE")).Substring(6, 4)
                            End If

                            .DCNMBK = Convert.ToString(cmd("DCNMBK"))
                            .DINGME = Convert.ToString(cmd("DINGME"))
                            .DCAGNV = Convert.ToString(cmd("DCAGNV"))
                            .DDCANA = Convert.ToString(cmd("DDCANA"))
                            If .DDCANA <> "" And .DDCANA.Length >= 10 Then
                                .DDCANA = Convert.ToString(cmd("DDCANA")).Substring(0, 2) & "/" & Convert.ToString(cmd("DDCANA")).Substring(3, 2) & "/" & Convert.ToString(cmd("DDCANA")).Substring(6, 4)
                            End If
                            .DNCANA = Convert.ToString(cmd("DNCANA"))
                            If .DNCANA = "N" Then
                                .DNCANA = "Naranja"
                            ElseIf .DNCANA = "R" Then
                                .DNCANA = "Rojo"
                            End If
                            .DCOBSE = Convert.ToString(cmd("DCOBSE"))
                            .DDSALN = Convert.ToString(cmd("DDSALN"))
                            .DDENBL = Convert.ToString(cmd("DDENBL"))
                            If .DDENBL <> "" And .DDENBL.Length >= 10 Then
                                .DDENBL = Convert.ToString(cmd("DDENBL")).Substring(0, 2) & "/" & Convert.ToString(cmd("DDENBL")).Substring(3, 2) & "/" & Convert.ToString(cmd("DDENBL")).Substring(6, 4)
                            End If
                            .PCNMDC = Convert.ToString(cmd("PCNMDC"))
                            .SESTRG = Convert.ToString(cmd("SESTRG"))
                            'If .DDENBL <> "" Then
                            '    .DDIF = DateDiff(DateInterval.Day, Convert.ToDateTime(cmd("DDNAVE")), Convert.ToDateTime(cmd("DDENBL")))
                            'End If
                            .RAT = Convert.ToString(cmd("DDRPDC"))
                            If .RAT <> "" And .RAT.Length >= 10 Then
                                .RAT = .RAT.Substring(0, 2) & "/" & .RAT.Substring(3, 2) & "/" & .RAT.Substring(6, 4)
                            End If
                            .DUA = Convert.ToString(cmd("DCDUE"))
                            .DDREGI = Convert.ToString(cmd("DDREGI"))
                            .DCREFE = Convert.ToString(cmd("DCREFE"))
                            .DCTPOS = Convert.ToString(cmd("DCTPOS"))
                            .PNCDRG = Convert.ToString(cmd("PNCDRG"))
                            .FNCDAD = Convert.ToString(cmd("FNCDAD"))
                            .DCDSME = Convert.ToString(cmd("DCDSME"))
                            .FNCDPR = Convert.ToString(cmd("FNCDPR"))
                            .DCASCI = Convert.ToString(cmd("DCASCI"))

                            .PNCDOP = Convert.ToString(cmd("PNCDOP"))
                            .DCPREC = Convert.ToString(cmd("DCPREC"))
                            .DCVIGE = Convert.ToString(cmd("DCVIGE"))
                            .DDVNDE = Convert.ToString(cmd("DDVNDE"))
                            .DNCAM = Convert.ToString(cmd("DNCAM"))
                            .DNTRAN = Convert.ToString(cmd("DNTRAN"))
                            .DCCONT = Convert.ToString(cmd("DCCONT"))

                            .DNFPAG = Convert.ToString(cmd("DNFPAG"))
                            .DNTPCA = Convert.ToString(cmd("DNTPCA"))
                            .SENVAS = Convert.ToString(cmd("SENVAS"))
                        End With
                        ListOS.Add(OS)
                    End While
                End Using
            End Using
        Catch ex As Exception
        End Try
        Return ListOS
    End Function
End Class
