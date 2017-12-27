Imports System
Imports System.Data
Imports BE = Empleado.Entidad
Imports BD = Emp_Datos
Public Class NSamsung
    Public Shared Function _GetSamsung(ByVal Os As String, ByVal Refer As String, ByVal Nave As String, ByVal Canal As String, ByVal Bll As String, ByVal Aforo As String, ByVal Retiro As String, ByVal Numeracion As String, ByVal CocCliente As String) As List(Of BE.Samsung)
        Dim Lisquery As List(Of BE.Samsung) = New List(Of BE.Samsung)
        Lisquery = BD.DSamsung.FillSamsung(Os, Refer, Nave, Canal, Bll, Aforo, Retiro, Numeracion, CocCliente)
        Return Lisquery
    End Function


    Public Shared Function _NombreClientes(ByVal CodigoClientes As String) As String
        Dim ListaMostraNombre As String
        ListaMostraNombre = BD.DSamsung.MostrarNombreCliente(CodigoClientes.ToString.Trim)
        Return ListaMostraNombre
    End Function


End Class
