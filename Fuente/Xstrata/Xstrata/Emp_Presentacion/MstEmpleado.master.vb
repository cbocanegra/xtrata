
Partial Class MstEmpleado
    Inherits System.Web.UI.MasterPage

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Session.Remove("ValCpnia")
        Session.Remove("ValDiv")
        Session.Remove("ValPlanta")
        Session.Remove("ValLibreria")
        Session.Remove("ValFlgAccion")
        Session.Remove("ValUsuario")
        Session.Remove("ValClave")
        Session.Remove("SesionCodZona")
        Session.Remove("DatosPNNMOS")
        Session.Remove("DatosPNCDZO")
        Session.Remove("DatosDCTPOS")
        Session.Remove("DatosPNDCTR")
        Session.Remove("DatosPCNMDC")
        Session.Remove("DatosDDREGI")
        Response.Redirect("FrmLogin.aspx", True)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
End Class

