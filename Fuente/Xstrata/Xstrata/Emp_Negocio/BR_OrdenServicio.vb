Imports System
Imports System.Data
Imports BE = Empleado.Entidad
Imports BD = Emp_Datos
Imports Ent = Emp_Entity

Public Class BR_OrdenServicio
    Public Shared Function ListadoOrdenesServicio(ByVal Cpnia As String, ByVal Servidor As String, ByVal Cliente As Integer, ByVal tipo As String, ByVal zona As Integer, ByVal division As String, ByVal orden As String, ByVal FechaI As String, ByVal FechaF As String, ByVal TIPOEXP As String, ByVal periodo As String) As List(Of Ent.BE_OrdenServicio)
        ListadoOrdenesServicio = BD.DA_OrdenServicio.ListadoOrdenesServicio(Cpnia, Servidor, Cliente, tipo, zona, division, orden, TIPOEXP, FechaI, FechaF, periodo)
    End Function
End Class
