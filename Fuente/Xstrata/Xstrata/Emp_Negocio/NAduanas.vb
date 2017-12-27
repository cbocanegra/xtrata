Imports System
Imports System.Data
Imports BE = Emp_Entidad
Imports BD = Emp_Datos

Public Class NAduanas
    Public Shared Function FillCabeceraAduana(ByVal OrdenServ As String) As List(Of BE.DUAA)
        Dim ListCabecera As List(Of BE.DUAA) = New List(Of BE.DUAA)
        ListCabecera = BD.DAduanas.FillCabeceraAduana(OrdenServ.ToString.Trim)
        Return ListCabecera
    End Function

    Public Shared Function FillDetalleAduana(ByVal NroordenServicio As String) As List(Of BE.DUAA1)
        Dim Lisquery As List(Of BE.DUAA1) = New List(Of BE.DUAA1)
        Lisquery = BD.DAduanas.FillDetalleDUA(NroordenServicio.ToString.Trim)
        Return Lisquery
    End Function
End Class
