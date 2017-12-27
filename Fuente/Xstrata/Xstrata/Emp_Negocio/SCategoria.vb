Imports System
Imports System.Data
Imports BE = Empleado.Entidad
Imports BD = Emp_Datos

Public Class SCategoria
    Public Shared Function FillCategoria() As List(Of BE.Categoria)
        Dim Lisquery As List(Of BE.Categoria) = New List(Of BE.Categoria)
        Lisquery = BD.DCatego.FillCategoria()
        Return Lisquery
    End Function
End Class
