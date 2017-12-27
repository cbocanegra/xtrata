Imports SD = Emp_Datos
Imports SN = Emp_Negocio
Imports SE = Empleado.Entidad
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System
Imports System.Data

Partial Class Proveedor
    Inherits System.Web.UI.Page
    Dim pif As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        pif = Request.QueryString("prov")
        Label2.Text = "El Proveedor que se ha escogido es el " + pif + ""
        LlenarProveedor()
    End Sub
    Sub LlenarProveedor()
        Dim slista As List(Of SE.Proveedor)
        slista = SN.SProveedor.FillProv(pif)
        Me.GdvProveedor.DataSource = slista
        Me.GdvProveedor.DataBind()
    End Sub
End Class
