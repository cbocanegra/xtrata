Imports Emp_Entity
Imports Emp_Negocio

Partial Class FrmXstrata
    Inherits System.Web.UI.Page

    Dim VALOR As Integer
    Dim TIPOIMP As String = ""
    Dim DatOrdenes As String()
    Dim Codcli As String = 3177
    Dim strmensaje As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarOrdenes()
        End If
    End Sub

    Public Sub CargarOrdenes()
        Dim Negocio As New NOrdenXTRATA
        ' --- SACAR LOS HARD CODE Y PONERLOS EN VARIBALES---'
        '  Me.dgvOrden.DataSource = Negocio.Orden_Select(Me.txtOrden.Text, zona, VALOR, FormatoFecha(txtfecha.Text), FechaConcatenada(fechaactual1), TIPOIMP)
        Dim BuscaPeriodo As String = ""

        If txtOrden.Text = "" Then
            BuscaPeriodo = txtanio.Text
        Else
            BuscaPeriodo = txtanio.Text.Trim & txtOrden.Text.Trim
        End If
        Me.gridOServ.DataSource = Negocio.Orden_Select(BuscaPeriodo, Session.Item("SesionCodZona").ToString.Trim, VALOR, 0, 0, TIPOIMP)
        gridOServ.DataBind()
        If gridOServ.Rows.Count > 0 Then
            Button2.Visible = True
            Button1.Visible = True
            OcultarGrillas()
        Else
            Button2.Visible = False
            Button1.Visible = False
            OcultarGrillas()
        End If
    End Sub

    Protected Sub gridOServ_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridOServ.PageIndexChanging
        Me.gridOServ.PageIndex = e.NewPageIndex
        Session.Remove("DatosPNNMOS")
        Session.Remove("DatosPNCDZO")
        Session.Remove("DatosDCTPOS")
        Session.Remove("DatosPNDCTR")
        Me.Label2.Visible = False
        Me.Label3.Visible = False
        Me.Label4.Visible = False
        OcultarGrillas()
        CargarOrdenes()
    End Sub

    Protected Sub ibt_Click2(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)


        Dim strcodigo As String = ""

        Dim index As Integer = 0
        Dim CodInsp As Integer = 0

        Dim rows As Integer
        strcodigo = (CType(sender, ImageButton)).CommandArgument
        DatOrdenes = Split(strcodigo, ",")
        Session.Add("DatosPNNMOS", DatOrdenes(0).ToString.Trim)
        Session.Add("DatosPNCDZO", DatOrdenes(1).ToString.Trim)
        Session.Add("DatosDCTPOS", DatOrdenes(2).ToString.Trim)
        Session.Add("DatosPNDCTR", DatOrdenes(3).ToString.Trim)
        Session.Add("DatosPCNMDC", DatOrdenes(4).ToString.Trim)
        Session.Add("DatosDDREGI", DatOrdenes(5).ToString.Trim)
        'Session.Add("CodInspect", DatInspector(3).ToString.Trim)
        'Session.Add("NomInspect", DatInspector(4).ToString.Trim)


        For Each row As GridViewRow In gridOServ.Rows
            If gridOServ.DataKeys(row.RowIndex).Value = Nothing Then
                index = 0
            Else
                CodInsp = gridOServ.DataKeys(row.RowIndex).Values("PNNMOS").ToString.Trim
            End If

            If CodInsp = DatOrdenes(0) Then
                row.Cells(6).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)
                row.Cells(7).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)
                row.Cells(8).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)
                row.Cells(9).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)
                row.Cells(10).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)
                row.Cells(11).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)
                row.Cells(12).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)
                row.Cells(13).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)
                row.Cells(14).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)
                row.Cells(15).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)
                row.Cells(16).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)
                row.Cells(17).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)
                row.Cells(18).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)
                row.Cells(19).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)
                row.Cells(20).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)
                row.Cells(21).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)
                row.Cells(22).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)
                row.Cells(23).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)
                row.Cells(24).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)
                row.Cells(25).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)
                row.Cells(26).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)
                row.Cells(27).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)
                row.Cells(28).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)
                row.Cells(29).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)
                row.Cells(30).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)
                row.Cells(31).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)
                row.Cells(32).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)
                row.Cells(32).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)
                row.Cells(33).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)
                row.Cells(33).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)
                row.Cells(34).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)
                row.Cells(35).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)
                row.Cells(36).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)
                row.Cells(37).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)
                row.Cells(38).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)
                row.Cells(39).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)
                row.Cells(40).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)
                row.Cells(41).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)
                row.Cells(42).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)
                row.Cells(43).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)
                row.Cells(44).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)
                row.Cells(45).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)
                row.Cells(46).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)
                row.Cells(47).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)
                row.Cells(48).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)
                row.Cells(49).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)
                row.Cells(50).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)
                row.Cells(51).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)
                row.Cells(52).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)
                row.Cells(53).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)
                row.Cells(54).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)
                row.Cells(55).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)
                row.Cells(56).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)
                row.Cells(57).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)
                '  row.Cells(58).BackColor = System.Drawing.Color.FromArgb(&HB4, &HDA, &H40)

            Else
                gridOServ.GridLines = GridLines.Both
                row.Cells(6).BackColor = Drawing.Color.White
                row.Cells(7).BackColor = Drawing.Color.White
                row.Cells(8).BackColor = Drawing.Color.White
                row.Cells(9).BackColor = Drawing.Color.White
                row.Cells(10).BackColor = Drawing.Color.White
                row.Cells(11).BackColor = Drawing.Color.White
                row.Cells(12).BackColor = Drawing.Color.White
                row.Cells(13).BackColor = Drawing.Color.White
                row.Cells(14).BackColor = Drawing.Color.White
                row.Cells(15).BackColor = Drawing.Color.White
                row.Cells(16).BackColor = Drawing.Color.White
                row.Cells(17).BackColor = Drawing.Color.White
                row.Cells(18).BackColor = Drawing.Color.White
                row.Cells(19).BackColor = Drawing.Color.White
                row.Cells(20).BackColor = Drawing.Color.White
                row.Cells(21).BackColor = Drawing.Color.White
                row.Cells(22).BackColor = Drawing.Color.White
                row.Cells(23).BackColor = Drawing.Color.White
                row.Cells(24).BackColor = Drawing.Color.White
                row.Cells(25).BackColor = Drawing.Color.White
                row.Cells(26).BackColor = Drawing.Color.White
                row.Cells(27).BackColor = Drawing.Color.White
                row.Cells(28).BackColor = Drawing.Color.White
                row.Cells(29).BackColor = Drawing.Color.White
                row.Cells(30).BackColor = Drawing.Color.White
                row.Cells(31).BackColor = Drawing.Color.White
                row.Cells(32).BackColor = Drawing.Color.White
                row.Cells(33).BackColor = Drawing.Color.White
                row.Cells(34).BackColor = Drawing.Color.White
                row.Cells(35).BackColor = Drawing.Color.White
                row.Cells(36).BackColor = Drawing.Color.White
                row.Cells(37).BackColor = Drawing.Color.White
                row.Cells(38).BackColor = Drawing.Color.White
                row.Cells(39).BackColor = Drawing.Color.White
                row.Cells(40).BackColor = Drawing.Color.White
                row.Cells(41).BackColor = Drawing.Color.White
                row.Cells(42).BackColor = Drawing.Color.White
                row.Cells(43).BackColor = Drawing.Color.White
                row.Cells(44).BackColor = Drawing.Color.White
                row.Cells(45).BackColor = Drawing.Color.White
                row.Cells(46).BackColor = Drawing.Color.White
                row.Cells(47).BackColor = Drawing.Color.White
                row.Cells(48).BackColor = Drawing.Color.White
                row.Cells(49).BackColor = Drawing.Color.White
                row.Cells(50).BackColor = Drawing.Color.White
                row.Cells(51).BackColor = Drawing.Color.White
                row.Cells(52).BackColor = Drawing.Color.White
                row.Cells(53).BackColor = Drawing.Color.White
                row.Cells(54).BackColor = Drawing.Color.White
                row.Cells(55).BackColor = Drawing.Color.White
                row.Cells(56).BackColor = Drawing.Color.White
                row.Cells(57).BackColor = Drawing.Color.White
                'row.Cells(58).BackColor = Drawing.Color.White
                ' gridOServ.
            End If

        Next

        If Session.Item("DatosPNNMOS").ToString.Trim <> "" Then
            CargarDetalle()
            CargarCheckPoint()
            CargarTotalCosto()
            Me.Label2.Visible = True
            Me.Label3.Visible = True
            Me.Label4.Visible = True
            btnDistribucion.Visible = True
        End If
    End Sub

    Public Sub CargarDetalle()
        Dim Negocio As New NOrdenXTRATA

        If Session.Item("DatosPNCDZO").ToString.Trim <> "" Then
            GdvDetalle.DataSource = Negocio.Orden_Select_Detalle(Session.Item("DatosPNNMOS").ToString.Trim, (Session.Item("DatosPNCDZO").ToString.Trim))
            GdvDetalle.DataBind()
            GdvDetalle.Visible = True
            ' Observacion = GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "DCOBSE1")
            'GridView2.BestFitColumns()
        End If
    End Sub

    Public Sub CargarCheckPoint()
        Dim Negocio As New NOrdenXTRATA
        If Session.Item("DatosPNCDZO").ToString.Trim <> "" Then
            Me.GdvChkPoint.DataSource = Negocio.Orden_CheckPoint(Session.Item("DatosPNNMOS").ToString.Trim, Session.Item("DatosPNCDZO").ToString.Trim, Codcli)
            GdvChkPoint.DataBind()
            GdvChkPoint.Visible = True
            ' Observacion = GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "DCOBSE1")
            'GridView3.BestFitColumns()
        End If
    End Sub

    Public Sub CargarTotalCosto()
        If Session.Item("DatosDCTPOS").ToString.Trim <> "" Then
            Dim Negocio As New NOrdenXTRATA
            GdvCostos.DataSource = Negocio.Orden_Costo(Session.Item("DatosPNNMOS").ToString.Trim, Session.Item("DatosPNCDZO").ToString.Trim, Session.Item("DatosDCTPOS").ToString.Trim)
            GdvCostos.DataBind()
            GdvCostos.Visible = True
            'GridView4.BestFitColumns()
        End If
    End Sub

    Public Sub OcultarGrillas()
        GdvDetalle.Visible = False
        GdvChkPoint.Visible = False
        GdvCostos.Visible = False
        btnDistribucion.Visible = False
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click       
        Consumir()
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Session.Remove("DatosPNNMOS")
        Session.Remove("DatosPNCDZO")
        Session.Remove("DatosDCTPOS")
        Session.Remove("DatosPNDCTR")
        Session.Remove("DatosPCNMDC")
        Session.Remove("DatosDDREGI")
        Me.Label2.Visible = False
        Me.Label3.Visible = False
        Me.Label4.Visible = False
        OcultarGrillas()

        CargarOrdenes()
    End Sub

    Protected Sub btnDistribucion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDistribucion.Click
        Dim Negocio As New NOrdenXTRATA
        Dim Resultado As String = ""
        Resultado = Negocio.Distribucion_Costos(Session.Item("DatosPNNMOS").ToString.Trim, Session.Item("DatosDCTPOS").ToString.Trim, Session.Item("DatosPNCDZO").ToString.Trim, Codcli)

        If Resultado = "" Then
            ' MessageBox.Show("Se actualizo correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            '  MessageBox.Show(Resultado, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
            strmensaje = "<script type='text/javascript'>alert('Hubo un error en la Distribucion...');</script>"
            ScriptManager.RegisterStartupScript(Me, Me.GetType, "alerta", strmensaje, False)
        End If

        CargarTotalCosto()
        Consumir()
    End Sub

    Public Sub Consumir()
        Dim Negocio As New NOrdenXTRATA
        Dim cadena As String
        If Session.Item("DatosDCTPOS") IsNot Nothing Then
            ' Cursor = System.Windows.Forms.Cursors.WaitCursor
            If Session.Item("DatosPCNMDC").ToString.Trim <> "" Then
                cadena = Negocio.Enviar_WebService_New(Codcli, Session.Item("DatosPNNMOS").ToString.Trim, Session.Item("DatosPNCDZO").ToString.Trim, Session.Item("DatosPNDCTR").ToString.Trim, Session.Item("DatosPCNMDC").ToString.Trim, Session.Item("DatosDDREGI").ToString.Trim)
                'cadena = Negocio.Enviar_WebService_New(Codcli, GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "PNNMOS"), GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "PNCDZO"), GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "PNDCTR"), GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "PCNMDC"), GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DDREGI"))
                ' cadena = "Ok"
                If cadena = "Ok" Then
                    'MsgBox("N° Orden " & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "PNNMOS") & " consumida satisfactoriamente", MsgBoxStyle.Exclamation, "Aviso")
                    strmensaje = "<script type='text/javascript'>alert('Nro ORDEN     :  " & Session.Item("DatosPNNMOS").ToString.Trim & "   fue consumida satisfactoriamnete...');</script>"
                    ScriptManager.RegisterStartupScript(Me, Me.GetType, "alerta", strmensaje, False)
                Else
                    'MsgBox(cadena, MsgBoxStyle.Information, "Aviso")
                    strmensaje = "<script type='text/javascript'>alert('AVISO...   : " & cadena & " ');</script>"
                    ScriptManager.RegisterStartupScript(Me, Me.GetType, "alerta", strmensaje, False)

                End If
            Else
                'MsgBox("La Orden de Servicio no tiene BL", MsgBoxStyle.Exclamation, "Aviso")
                strmensaje = "<script type='text/javascript'>alert('La Orden de Servicio no tiene BL..!!!');</script>"
                ScriptManager.RegisterStartupScript(Me, Me.GetType, "alerta", strmensaje, False)
            End If

            '  Cursor = System.Windows.Forms.Cursors.Arrow
        Else
            strmensaje = "<script type='text/javascript'>alert('Debe seleccionar registro para consumir...');</script>"
            ScriptManager.RegisterStartupScript(Me, Me.GetType, "alerta", strmensaje, False)
        End If
    End Sub

    Protected Sub btnBusqueda_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBusqueda.Click
        CargarOrdenes()
    End Sub
End Class
