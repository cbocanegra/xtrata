Imports Emp_Datos
Imports Emp_Entity

Public Class NOrdenXTRATA
    Dim D As New Emp_Datos.DOrdenesXTRATA
    Public Function Orden_Select(ByVal orden As String, ByVal Zona As String, ByVal cliente As String, ByVal fecha As String, ByVal fechaconcat As String, ByVal tipo As String)
        Return D.Ordenes(orden, Zona, cliente, fecha, fechaconcat, tipo)
    End Function

    Public Function FechasChekpoint_Insert(ByVal Edetalle As EOrdenXSTRATA) As String
        Return D.FechasCheckpoint_Insert(Edetalle)
    End Function


    Public Function Orden_Select_Detalle(ByVal orden As String, ByVal Zona As String)
        Return D.Detalle_Ordenes(orden, Zona)
    End Function

    Public Function Orden_CheckPoint(ByVal orden As String, ByVal Zona As String, ByVal Cliente As String)
        Return D.ChecktPoint_Ordenes(orden, Zona, Cliente)
    End Function

    Public Function Orden_Costo(ByVal orden As String, ByVal Zona As String, ByVal Tipo As String)
        Return D.Costo_Ordenes(orden, Zona, Tipo)
    End Function

    Public Function CheckPoint_Update(ByVal Orden As String, _
                                 ByVal zona As String, _
                                 ByVal PNDCTR As String, _
                                 ByVal codigo As String, _
                                  ByVal fecha As String) As String
        Return D.CheckPoint_Update(Orden, zona, PNDCTR, codigo, fecha)
    End Function


    Public Function Distribucion_Costos(ByVal Orden As String, _
                                              ByVal Tipo As String, _
                                              ByVal Zona As String, _
                                              ByVal cliente As String)
        Return D.Distribucion_Costos(Orden, Tipo, Zona, cliente)
    End Function


    Public Function Enviar_WebService_New(ByVal Cliente As String, ByVal Orden As String, ByVal Zona As String, ByVal pndctr As String, ByVal bl As String, ByVal fecha As String) As String
        Return D.Envia_WebService_New(Cliente, Orden, Zona, pndctr, bl, fecha)
    End Function
End Class
