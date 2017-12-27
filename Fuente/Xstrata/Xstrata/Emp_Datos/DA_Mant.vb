Imports System.Data
Imports IBM.Data.DB2.iSeries
Imports System.Collections.Generic
Imports System.Text
Imports System.Data.Common
Imports BE = Emp_Entity
Imports System.IO
Imports System
Imports System.Configuration

Public Class DA_Mant
    Public Shared Function GetTable(ByVal Tabla As String, Optional ByVal Param As String = "") As DataTable

        Dim NameSp As String = ""
        Dim dt As New DataTable
        NameSp = "LIBORDAG.SP_WEBAGENCIAS_GETTABLE"
        Try
            Using cn As iDB2Connection = ConexionDB2.Open("FZ", "RANSA")
                Using command As New iDB2Command(NameSp, cn)
                    Using adapter As New iDB2DataAdapter
                        command.CommandType = CommandType.StoredProcedure
                        command.Parameters.Add("IN_TABLA", iDB2DbType.iDB2VarChar, 2).Value = Tabla
                        command.Parameters.Add("IN_PARAM1", iDB2DbType.iDB2VarChar, 8).Value = Param
                        adapter.SelectCommand = command
                        adapter.Fill(dt)
                    End Using
                End Using
            End Using
        Catch ex As Exception
        End Try
        Return dt

    End Function


    Public Shared Function LlenaComboCliente(ByVal Cpnia As String, ByVal Serv As String, ByVal Texto As String) As DataTable
        Dim Libreria As String = ""
        Dim NameSp As String = ""
        Dim Msje As String = 0
        Dim dt As New DataTable
        If Cpnia = "" Then
            NameSp = "DC@DESLIB.SP_SEGUIMIENTODOCUMENTAL_GETTABLE_CLIENTE"
        Else
            NameSp = "DESCASA.SP_SEGUIMIENTODOCUMENTAL_GETTABLE_CLIENTE"
        End If

        Try
            Using cn As iDB2Connection = ConexionDB2.Open(Cpnia, Serv)
                Using command As New iDB2Command(NameSp, cn)
                    Using adapter As New iDB2DataAdapter
                        command.CommandType = CommandType.StoredProcedure
                        command.Parameters.Add("IN_COMPANIA", iDB2DbType.iDB2VarChar, 2).Value = Cpnia
                        command.Parameters.Add("IN_TEXTO", iDB2DbType.iDB2VarChar, 100).Value = Texto.Trim.ToUpper
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
