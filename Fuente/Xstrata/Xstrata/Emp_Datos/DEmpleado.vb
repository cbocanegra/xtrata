Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Text
Imports System.Data.Common
Imports BE = Empleado.Entidad


Public Class DEmpleado
    Public Shared Function FillEmpleado() As List(Of BE.Empleado)

        Dim Sql As String
        Sql = "select IdProducto,IdCategoria,IdProveedor,Nombre,UnidadMedida,PrecioProveedor,StockActual,StockMinimo from producto order by idCategoria"

        Dim ListQuery As List(Of BE.Empleado) = New List(Of BE.Empleado)
        Dim cmd As SqlDataReader

        Using cn As SqlConnection = Conexion.GetConnection()
            Using command As New SqlCommand(Sql, cn)
                cmd = command.ExecuteReader
                While (cmd.Read())
                    Dim CabSeguimiento As BE.Empleado = New BE.Empleado()
                    With CabSeguimiento
                        .IdProducto = Convert.ToInt64(cmd("IdProducto"))
                        .IdCategoria = Convert.ToInt64(cmd("IdCategoria"))
                        .IdProveedor = Convert.ToInt64(cmd("IdProveedor"))
                        .Nombre = Convert.ToString(cmd("Nombre"))
                        .UnidadMedida = Convert.ToString(cmd("UnidadMedida"))
                        .PrecioProveedor = Convert.ToDouble(cmd("PrecioProveedor"))
                        .StockActual = Convert.ToDouble(cmd("StockActual"))
                        .StockMinimo = Convert.ToDouble(cmd("StockMinimo"))
                    End With
                    ListQuery.Add(CabSeguimiento)
                End While
            End Using
        End Using
        Return ListQuery

    End Function

    Public Shared Function FillEmpleadoCat() As List(Of BE.Empleado)

        Dim Sql As String
        Sql = " select A.IdProducto,A.IdCategoria,B.Descripcion,A.IdProveedor,A.Nombre,A.UnidadMedida,A.PrecioProveedor,A.StockActual,A.StockMinimo " & _
              " from producto A " & _
              " INNER JOIN CATEGORIA B  ON  B.IDCATEGORIA=A.IDCATEGORIA " & _
              " order by A.idCategoria"

        Dim ListQuery As List(Of BE.Empleado) = New List(Of BE.Empleado)
        Dim cmd As SqlDataReader

        Using cn As SqlConnection = Conexion.GetConnection()
            Using command As New SqlCommand(Sql, cn)
                cmd = command.ExecuteReader
                While (cmd.Read())
                    Dim CabSeguimiento As BE.Empleado = New BE.Empleado()
                    With CabSeguimiento
                        .IdProducto = Convert.ToInt64(cmd("IdProducto"))
                        .IdCategoria = Convert.ToInt64(cmd("IdCategoria"))
                        .IdProveedor = Convert.ToInt64(cmd("IdProveedor"))
                        .Nombre = Convert.ToString(cmd("Nombre"))
                        .UnidadMedida = Convert.ToString(cmd("UnidadMedida"))
                        .PrecioProveedor = Convert.ToDouble(cmd("PrecioProveedor"))
                        .StockActual = Convert.ToDouble(cmd("StockActual"))
                        .StockMinimo = Convert.ToDouble(cmd("StockMinimo"))
                        .Descripcion = Convert.ToString(cmd("Descripcion"))
                    End With
                    ListQuery.Add(CabSeguimiento)
                End While
            End Using
        End Using
        Return ListQuery

    End Function
End Class

