Imports SD = Emp_Datos
Imports SN = Emp_Negocio
Imports SE = Emp_Entidad

Imports System.Collections.Generic
Imports System.Collections
Imports System.Data.SqlClient
Imports System
Imports System.Data
Imports IBM.Data.DB2.iSeries
Imports System.IO

Partial Class FrmDetalleOrdCompra
    Inherits System.Web.UI.Page
    Dim OrdenServ As String
    Dim NroBLs As String
    Dim sDUAA As List(Of SE.DUAA)
    Dim sDetalleDUAA As List(Of SE.DUAA1)
   
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        OrdenServ = Request.QueryString("NroOrden")
        NroBLs = Request.QueryString("NroBL")
        If OrdenServ.Length > 0 Then
            LlenarGrilla(OrdenServ.ToString.Trim)
            LlenarDetalleGrilla(OrdenServ.ToString.Trim)
            lblOs.Text = NroBLs
        End If        
    End Sub

    Private Sub LlenarGrilla(ByVal NroOrdenServicio As String)
        sDUAA = SN.NAduanas.FillCabeceraAduana(NroOrdenServicio)
        Me.GdvCabAduanas.DataSource = sDUAA
        Me.GdvCabAduanas.DataBind()
    End Sub

    Private Sub LlenarDetalleGrilla(ByVal NroOrdenServicio As String)
        sDetalleDUAA = SN.NAduanas.FillDetalleAduana(NroOrdenServicio)
        Me.GdvDetalleDua.DataSource = sDetalleDUAA
        Me.GdvDetalleDua.DataBind()
    End Sub

    Protected Sub btnBusqueda_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBusqueda.Click

        Dim style As String = ""
        Dim sb As StringBuilder = New StringBuilder()
        Dim sw As StringWriter = New StringWriter(sb)
        Dim htw As HtmlTextWriter = New HtmlTextWriter(sw)
        Dim Label As String = ""
        Dim pagina As Page = New Page
        Dim grilla As New GridView
        Dim grilla1 As New GridView

        'Dim Html As String
        'Html = "<table border='0' cellpadding='0' cellspacing='1' width='98%' bgcolor='#DCE3DB' alignt='center'>" & _
        '                    "<thead >" & _
        '                        "<th align='center' bgcolor='#CBCF9C'><font face='Arial' color='#000000'>Nro.Warrant</font></th>" & _
        '                        "<th align='center' bgcolor='#CBCF9C'><font face='Arial' color='#000000'>Fecha Vencto.</th>" & _
        '                        "<th align='center' bgcolor='#CBCF9C'><font face='Arial' color='#000000'>Saldo Warrant</th>" & _
        '                    "</thead>" & _
        '                    "<tbody>"
        'Html += "</tbody></table>"


        Me.lblAduana.Text = "ADUANAS" & Chr(13) & Chr(13)

        Me.lblDetalle.Text = "DETALLE DE ADUANAS" & Chr(13) & Chr(13) & _
                             "___________________________   "
        

        grilla.EnableViewState = False
        grilla.AllowPaging = False
        grilla.DataSource = sDUAA
        grilla.DataBind()


        grilla1.EnableViewState = False
        grilla1.AllowPaging = False
        grilla1.DataSource = sDetalleDUAA
        grilla1.DataBind()

        '---------------HEADERS-------------------------------------------------------

        Dim row As Integer
        Dim row1 As Integer

        '---------------SETEANDO CABECERA GRILLA--------------------------------------
        grilla.HeaderRow.Cells(0).Text = "TS"
        grilla.HeaderRow.Cells(1).Text = "Regimen"
        grilla.HeaderRow.Cells(2).Text = "Nro orden Servicio"
        grilla.HeaderRow.Cells(3).Text = "Ref. orden"
        grilla.HeaderRow.Cells(4).Text = "Valor de Mercaderia"
        grilla.HeaderRow.Cells(5).Text = "valor Flete"
        grilla.HeaderRow.Cells(6).Text = "valor Seguro"
        grilla.HeaderRow.Cells(7).Text = "Valor CIF"
        grilla.HeaderRow.Cells(8).Text = "Valor Advalorem"
        grilla.HeaderRow.Cells(9).Text = "Valor SobreTasa"
        grilla.HeaderRow.Cells(10).Text = "Valor IGV"
        grilla.HeaderRow.Cells(11).Text = "Valor IPM"
        grilla.HeaderRow.Cells(12).Text = "Nro. Factura"
        grilla.HeaderRow.Cells(13).Text = "Fecha Factura"

        grilla.HeaderRow.BackColor = Drawing.Color.FromArgb(0, 155, 58)
        grilla.HeaderRow.ForeColor = Drawing.Color.FromArgb(255, 255, 255)
        '-----------------------------------------------------------------------------

        '---------------COLUMNS-------------------------------------------------------
        For row = 0 To grilla.Rows.Count - 1
            If ((row + 2) Mod 2) = 0 Then
                grilla.Rows(row).BackColor = Drawing.Color.FromArgb(247, 246, 243)
                grilla.Rows(row).ForeColor = Drawing.Color.FromArgb(0, 0, 0)
            Else
                grilla.Rows(row).BackColor = Drawing.Color.FromArgb(255, 255, 255)
                grilla.Rows(row).ForeColor = Drawing.Color.FromArgb(40, 71, 117)
            End If
        Next
        '-----------------------------------------------------------------------------


        grilla1.HeaderRow.Cells(0).Text = "TS"
        grilla1.HeaderRow.Cells(1).Text = "Nro Orden Serv."
        grilla1.HeaderRow.Cells(2).Text = "Nro. Serie"
        grilla1.HeaderRow.Cells(3).Text = "Partida "
        grilla1.HeaderRow.Cells(4).Text = "Nro Fac. Comercial"
        grilla1.HeaderRow.Cells(5).Text = "Nro Item Fact."
        grilla1.HeaderRow.Cells(6).Text = "Nro Ord Compra "
        grilla1.HeaderRow.Cells(7).Text = "Nro Item O/Compra"
        grilla1.HeaderRow.Cells(8).Text = "Mercaderia"
        grilla1.HeaderRow.Cells(9).Text = "Flete"
        grilla1.HeaderRow.Cells(10).Text = "Seguro"
        grilla1.HeaderRow.Cells(11).Text = "FOB"
        grilla1.HeaderRow.Cells(12).Text = "CIF"
        grilla1.HeaderRow.Cells(13).Text = "Antidump"
        grilla1.HeaderRow.Cells(14).Text = "Mora"
        grilla1.HeaderRow.Cells(15).Text = "ADV"
        grilla1.HeaderRow.Cells(16).Text = "SBT"
        grilla1.HeaderRow.Cells(17).Text = "DES"
        grilla1.HeaderRow.Cells(18).Text = "ISC"
        grilla1.HeaderRow.Cells(19).Text = "IGV"
        grilla1.HeaderRow.Cells(20).Text = "IPM"
        grilla1.HeaderRow.Cells(21).Text = "ICP"
        grilla1.HeaderRow.Cells(22).Text = "RNP"


        grilla1.HeaderRow.BackColor = Drawing.Color.FromArgb(0, 155, 58)
        grilla1.HeaderRow.ForeColor = Drawing.Color.FromArgb(255, 255, 255)
        '-----------------------------------------------------------------------------

        '---------------COLUMNS-------------------------------------------------------
        For row = 0 To grilla1.Rows.Count - 1
            If ((row1 + 2) Mod 2) = 0 Then
                grilla1.Rows(row1).BackColor = Drawing.Color.FromArgb(247, 246, 243)
                grilla1.Rows(row1).ForeColor = Drawing.Color.FromArgb(0, 0, 0)
            Else
                grilla1.Rows(row1).BackColor = Drawing.Color.FromArgb(255, 255, 255)
                grilla1.Rows(row1).ForeColor = Drawing.Color.FromArgb(40, 71, 117)
            End If
        Next

        'grilla.Columns(0).Visible = False
        Dim form = New HtmlForm
        pagina.EnableEventValidation = False
        pagina.DesignerInitialize()
        pagina.Controls.Add(form)
        form.Controls.Add(lblAduana)
        form.Controls.Add(grilla)
        form.Controls.Add(lblDetalle)
        form.Controls.Add(grilla1)
        pagina.RenderControl(htw)
        Response.Clear()
        Response.Buffer = True
        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("Content-Disposition", "attachment;filename=OrdenCompra.xls")
        Response.Charset = "UTF-8"
        Response.ContentEncoding = Encoding.Default
        Response.Write(style)
        Dim Titulo As String = "Orden Serv  : " & sDUAA.Item(0).NORDSR
        HttpContext.Current.Response.Write(Titulo)
        Response.Write(sb.ToString())
        Response.End()

    End Sub

End Class
