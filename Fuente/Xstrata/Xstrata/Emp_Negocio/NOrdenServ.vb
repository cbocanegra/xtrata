Imports System
Imports System.Data
Imports BD = Emp_Datos
Imports ENTD = Emp_Entidad
'Imports 


Public Class NOrdenServ

    Public Shared Function ListarOrdenServicio(ByVal Compania As String) As List(Of ENTD.EOrdenServ)
        Dim ListaOrdenServicio As List(Of ENTD.EOrdenServ) = New List(Of ENTD.EOrdenServ)
        ListaOrdenServicio = BD.DOrdenServ.ListarOrdenServicio(Compania.Trim)
        Return ListaOrdenServicio
    End Function


    Public Shared Function InsertaOrdenServicio(ByVal Entidad As ENTD.EOrdenServ) As Integer
        InsertaOrdenServicio = BD.DOrdenServ.InsertaOrdenServicio(Entidad)
    End Function

    Public Shared Function GetNumeroOS() As String
        GetNumeroOS = BD.DOrdenServ.GetNumeroOS()
    End Function

    Public Shared Function InsertaOrdenServicioAscinsa(ByVal Entidad As ENTD.EOrdenServ) As Integer
        InsertaOrdenServicioAscinsa = BD.DOrdenServ.InsertaOrdenServicioAscinsa(Entidad)
    End Function
End Class
