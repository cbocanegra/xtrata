Imports System
Imports System.Data
Imports BE = Empleado.Entidad
Imports BD = Emp_Datos
Imports ENTD = Emp_Entidad

Public Class NXstrata
    Public Shared Function _ObtieneDatosXtrata(ByVal Os As String, ByVal Refer As String, ByVal Nave As String, ByVal Canal As String, ByVal Bll As String, ByVal Aforo As String, ByVal Retiro As String, ByVal Numeracion As String, ByVal CocCliente As String, ByVal TipoCanal As String, ByVal TipoOrden As String, ByVal EstadoOrden As String) As List(Of ENTD.XSTRATA)
        Dim ListaXstrata As List(Of ENTD.XSTRATA) = New List(Of ENTD.XSTRATA)
        ListaXstrata = BD.DXstrata.FillXstrata(Os, Refer, Nave, Canal, Bll, Aforo, Retiro, Numeracion, CocCliente, TipoCanal.ToString.Trim, TipoOrden.ToString.Trim, EstadoOrden.ToString.Trim)
        Return ListaXstrata
    End Function

    Public Shared Function _ObtieneDatosOrdenCompra(ByVal TipoOrdeCompra As String, ByVal ordenCompra As String) As List(Of ENTD.EOrdenCompra)
        Dim ListaOrdenCompra As List(Of ENTD.EOrdenCompra) = New List(Of ENTD.EOrdenCompra)
        ListaOrdenCompra = BD.DXstrata.ConsultaOrdenesCompra(TipoOrdeCompra.ToString.Trim, ordenCompra.ToString.Trim)
        Return ListaOrdenCompra
    End Function


    Public Shared Function _ValidaDatosAccesos(ByVal Usuario As String, ByVal Clave As String, ByVal TipApli As String) As List(Of ENTD.E_ValidarAcceso)
        Dim ListaValidarAcceso As List(Of ENTD.E_ValidarAcceso) = New List(Of ENTD.E_ValidarAcceso)
        ListaValidarAcceso = BD.DXstrata.ValidaAccesos(Usuario.ToString.Trim, Clave.ToString.Trim, TipApli.ToString)
        Return ListaValidarAcceso
    End Function

End Class
