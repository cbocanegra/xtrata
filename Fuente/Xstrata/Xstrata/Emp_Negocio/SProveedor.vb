Imports System
Imports System.Data
Imports BE = Empleado.Entidad
Imports BD = Emp_Datos
Public Class SProveedor
    Public Shared Function FillProv(ByVal cod As String) As List(Of BE.Proveedor)
        Dim Lisquery As List(Of BE.Proveedor) = New List(Of BE.Proveedor)
        Lisquery = BD.SProveedor.FillProveedor(cod)
        Return Lisquery
    End Function

    Public Shared Function ListaProveedores() As List(Of BE.Proveedor)
        Dim Lisquery As List(Of BE.Proveedor) = New List(Of BE.Proveedor)
        Lisquery = BD.SProveedor.ListarProveedor()
        Return Lisquery
    End Function

End Class
