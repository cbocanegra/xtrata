Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Text
Imports System.Data.Common
Imports BE = Empleado.Entidad

Public Class SProveedor
    Public Shared Function FillProveedor(ByVal cod As String) As List(Of BE.Proveedor)

        Dim Sql As String
        Sql = "select IdProveedor,nombre,representante,direccion, ciudad, departamento from proveedor where IdProveedor ='" & cod & "'"

        Dim ListQuery As List(Of BE.Proveedor) = New List(Of BE.Proveedor)
        Dim cmd As SqlDataReader

        Using cn As SqlConnection = Conexion.GetConnection()
            Using command As New SqlCommand(Sql, cn)
                cmd = command.ExecuteReader
                While (cmd.Read())
                    Dim CabSeguimiento As BE.Proveedor = New BE.Proveedor()
                    With CabSeguimiento
                        .IdProveedor = Convert.ToInt64(cmd("IdProveedor"))
                        .Nombre = Convert.ToString(cmd("nombre"))
                        .Representante = Convert.ToString(cmd("representante"))
                        .Direccion = Convert.ToString(cmd("Direccion"))
                        .Ciudad = Convert.ToString(cmd("Ciudad"))
                        .Departamento = Convert.ToString(cmd("Departamento"))
                    End With
                    ListQuery.Add(CabSeguimiento)
                End While
            End Using
        End Using
        Return ListQuery

    End Function


    Public Shared Function ListarProveedor() As List(Of BE.Proveedor)

        Dim Sql As String
        Sql = "select IdProveedor,nombre,representante,direccion, ciudad, departamento from proveedor"

        Dim ListQuery As List(Of BE.Proveedor) = New List(Of BE.Proveedor)
        Dim cmd As SqlDataReader

        Using cn As SqlConnection = Conexion.GetConnection()
            Using command As New SqlCommand(Sql, cn)
                cmd = command.ExecuteReader
                While (cmd.Read())
                    Dim CabSeguimiento As BE.Proveedor = New BE.Proveedor()
                    With CabSeguimiento
                        .IdProveedor = Convert.ToInt64(cmd("IdProveedor"))
                        .Nombre = Convert.ToString(cmd("nombre"))
                        .Representante = Convert.ToString(cmd("representante"))
                        .Direccion = Convert.ToString(cmd("Direccion"))
                        .Ciudad = Convert.ToString(cmd("Ciudad"))
                        .Departamento = Convert.ToString(cmd("Departamento"))
                    End With
                    ListQuery.Add(CabSeguimiento)
                End While
            End Using
        End Using
        Return ListQuery

    End Function

End Class

