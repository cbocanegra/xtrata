Imports SD = Emp_Datos
Imports SN = Emp_Negocio
Imports SE = Empleado.Entidad
Imports ENTID = Emp_Entidad
Imports System.Collections.Generic
Imports System.Collections
Imports System.Data.SqlClient
Imports System
Imports System.Data
Imports IBM.Data.DB2.iSeries
Imports System.IO
Partial Class OrdenesdeCompra
    Inherits System.Web.UI.Page

    Dim slistaOrdenCompra As List(Of ENTID.EOrdenCompra)
    Dim VCif, Vpeso, Vtipo As String
    Dim TotalSuma As String


    Sub Fill_OrdenesCompra(ByVal TipoBusqueda As String, ByVal OrdenComp As String)
        slistaOrdenCompra = SN.NXstrata._ObtieneDatosOrdenCompra(TipoBusqueda.ToString.Trim, OrdenComp.ToString.Trim)
        Me.gdvOrdenCompra.DataSource = slistaOrdenCompra
        Me.gdvOrdenCompra.DataBind()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Label2.Visible = False
    End Sub

    Protected Sub btnBusqueda_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBusqueda.Click
        Dim I As Integer = 0

        If opcCIF.Checked = False And OpcPeso.Checked = False Then
            Me.Label2.Visible = True
            Me.Label2.Text = "Debe seleccionar una opcion ...!!!"
            Exit Sub
        End If

        If txtOrdenesCompra.Text = "" Then
            Me.Label2.Visible = True
            Me.Label2.Text = "Debe ingresar una orden de compra ...!!!"
            Exit Sub
        End If

        Session.Add("ValorOrdeCompra", txtOrdenesCompra.Text)

        If opcCIF.Checked = True Then
            Vtipo = 2
        Else
            Vtipo = 3
        End If

        Fill_OrdenesCompra(Vtipo, txtOrdenesCompra.Text.ToString.Trim)

        If slistaOrdenCompra.Count = 0 Then
            lblTotal.Visible = False
            txtSuma.Visible = False
            txtSuma.Text = ""
        End If

        For I = 0 To slistaOrdenCompra.Count - 1
            TotalSuma = Val(TotalSuma) + slistaOrdenCompra.Item(I).VALMRC
        Next

        If slistaOrdenCompra.Count > 1 Then
            lblTotal.Visible = True
            txtSuma.Visible = True
            txtSuma.Text = Format(Val(TotalSuma), "##,###.#00")
        End If


    End Sub

    Protected Sub gdvOrdenCompra_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gdvOrdenCompra.PageIndexChanging
        'Fill_OrdenesCompra(Vtipo, Session.Item("ValorOrdeCompra").ToString.Trim)
        'Me.gdvOrdenCompra.PageIndex = e.NewPageIndex
        'Me.gdvOrdenCompra.DataBind()
    End Sub
End Class
