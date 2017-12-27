Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Text
Imports System.Data.Common
Imports BE = Empleado.Entidad
Public Class DCatego
    Public Shared Function FillCategoria() As List(Of BE.Categoria)
        Dim Sql As String
        Sql = "select idCategoria,categoria,descripcion from categoria"

        Dim ListQuery As List(Of BE.Categoria) = New List(Of BE.Categoria)
        Dim cmd As SqlDataReader

        Using cn As SqlConnection = Conexion.GetConnection()
            Using command As New SqlCommand(Sql, cn)
                cmd = command.ExecuteReader
                While (cmd.Read())
                    Dim Catego As BE.Categoria = New BE.Categoria()
                    With Catego
                        .IdCategoria = Convert.ToInt64(cmd("idCategoria"))
                        .Categoria1 = Convert.ToString(cmd("categoria"))
                        .Descripcion = Convert.ToString(cmd("descripcion"))
                    End With
                    ListQuery.Add(Catego)
                End While
            End Using
        End Using
        Return ListQuery
    End Function

End Class

