Imports SD = Emp_Datos
Imports SN = Emp_Negocio
Imports Entidad = Emp_Entity
Imports Enty = Emp_Entidad

Partial Class SeguimientoOrdenes
    Inherits System.Web.UI.Page

    Dim orden As String
    Dim Ordenes As New List(Of Entidad.BE_OrdenServicio)
    Dim strmensaje As String

    Dim medio, cantidad, codcliente, aduana, TipoOper, Refer, FechaVenc, Prioridad, regimen, descMerca, tipocarga, tipopagoaduana, contacto As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LlenarGrillas()
        End If

        Label1.Visible = False
        Label2.Visible = False
    End Sub

    Public Sub LlenarGrillas()
        'Dim Ordenes As New List(Of ENT.BE_OrdenServicio)
        'Dim Documentos As New List(Of ENT.EDocumentoTecnica)
        Dim cliente As Integer
        Dim Fecharegistro, fechafin As String
        Dim Cpnia As String
        Dim servidor As String
        Dim Tipo As String
        Dim zona As String
        Dim Division As String

        'Cpnia()
        'If cmbCliente.SelectedIndex = -1 Or cmbCliente.Text.Trim = "" Then
        '    cliente = 0
        'Else
        '    cliente = cmbCliente.SelectedValue
        'End If

        '---''''FINES DE  PRUEBA'''---
        '  Cpnia =


        cliente = 0
        'Cpnia = "FZ"
        Cpnia = Session.Item("ValCpnia")
        servidor = ""
        Tipo = "I"
        zona = Session.Item("SesionCodZona")
        Division = Session.Item("ValDiv")



        orden = txtOrden.Text
        If dtregistro.Text <> "" Then
            Fecharegistro = dtregistro.Text
            fechafin = dtregistro.Text
            Fecharegistro = Fecharegistro.Substring(6, 4) & "-" & Fecharegistro.Substring(3, 2) & "-" & Fecharegistro.Substring(0, 2) & " " & "00:00:00.000000"
            fechafin = fechafin.Substring(6, 4) & "-" & fechafin.Substring(3, 2) & "-" & fechafin.Substring(0, 2) & " " & "24:00:00.000000"
        Else
            Fecharegistro = ""
            fechafin = ""
        End If
        If orden = "" Then
            orden = txtanio.Text
            Ordenes = SN.BR_OrdenServicio.ListadoOrdenesServicio(Cpnia, servidor, cliente, Tipo, zona, Division, orden, Fecharegistro, fechafin, 99999999, 1)
        Else
            orden = txtanio.Text & orden
            Ordenes = SN.BR_OrdenServicio.ListadoOrdenesServicio(Cpnia, servidor, cliente, Tipo, zona, division, orden, Fecharegistro, fechafin, 99999999, 2)
        End If

        gridOServ.DataSource = Ordenes
        gridOServ.DataBind()

        If Ordenes.Count = 0 Then
            '  XtraMessageBox.Show("No existen registros", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            strmensaje = "<script type='text/javascript'>alert('No existen registros del dia de Hoy...');</script>"
            ScriptManager.RegisterStartupScript(Me, Me.GetType, "alerta", strmensaje, False)
        End If
        ' If 'GridView2.RowCount > 0 Then
        ' CargarObservaciones(GridView2)
        ' CargarDocumentos(GridView2)
        ' txtObs.Enabled = True
        ' sbAceptar.Enabled = True
        ' Else
        ' gridObs.DataSource = Nothing
        ' End If
    End Sub

    Protected Sub btnBusqueda_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBusqueda.Click
        LlenarGrillas()
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Dim Indice As Integer = 0
        Dim result As Integer = 0
        Indice = Me.gridOServ.SelectedIndex

        If Indice = -1 Then
            Me.Label1.Visible = True
            Me.Label1.Text = "Debe Seleccionar un elemento de la grilla"

            Me.Label2.Visible = True
            Me.Label2.Text = "Debe Seleccionar un elemento de la grilla"

            Exit Sub
        Else
            'codcliente = gridOServ.GetRowCellValue(GridView2.FocusedRowHandle, "DCASCI").ToString.Trim
            '  codcliente = gridOServ.Rows(Indice).Cells(3).Text

            Try
                codcliente = gridOServ.DataKeys(Indice).Item(0).ToString.Trim()
                aduana = gridOServ.DataKeys(Indice).Item(1).ToString.Trim()
                regimen = gridOServ.DataKeys(Indice).Item(2).ToString.Trim()

                Refer = gridOServ.Rows(Indice).Cells(6).Text.Trim
                Prioridad = gridOServ.DataKeys(Indice).Item(3).ToString.Trim()
                descMerca = gridOServ.DataKeys(Indice).Item(4).ToString.Trim()

                TipoOper = ""
                Dim objOS As New Enty.EOrdenServ

                With objOS
                    .PNNMOS = gridOServ.Rows(Indice).Cells(1).Text.Trim
                    .PNCDTR = gridOServ.DataKeys(Indice).Item(12).ToString.Trim()
                    .PNCDCO = "FZ"
                    .PNCDNG = "A"
                    .PNDCPL = "1"  'planta sale del usuario login 
                    .PNCDZO = Session.Item("SesionCodZona")  'zona sale del usuario login
                    .PNCDRG = regimen
                    .PNCDOP = TipoOper
                    .DCASCI = codcliente
                    .DCTPOS = ""
                    .DCREFE = Refer
                    .FNCDAD = aduana
                    .DNOSPR = ""
                    .FNCDPR = Prioridad
                End With

                result = SN.NOrdenServ.InsertaOrdenServicioAscinsa(objOS)

                If result <> 0 Then
                    '  XtraMessageBox.Show("Se generó satisfactoriamente la Orden de Servicio Nº  " & objOS.PNNMOS)
                    Me.Label1.Visible = True
                    Me.Label1.Text = "Se generó satisfactoriamente la Orden de Servicio Nº  " & objOS.PNNMOS

                    Me.Label2.Visible = True
                    Me.Label2.Text = "Se generó satisfactoriamente la Orden de Servicio Nº  " & objOS.PNNMOS
                Else
                    '  XtraMessageBox.Show("No se pudo generar la Orden de Servicio en el ASCINSA")
                    Me.Label1.Visible = True
                    Me.Label1.Text = "No se pudo generar la Orden de Servicio en el ASCINSA"

                    Me.Label2.Visible = True
                    Me.Label2.Text = "No se pudo generar la Orden de Servicio en el ASCINSA"
                End If

            Catch ex As Exception
                Me.Label1.Visible = True
                Me.Label1.Text = "No se pudo generar la Orden de Servicio en el ASCINSA"


                Me.Label2.Visible = True
                Me.Label2.Text = "No se pudo generar la Orden de Servicio en el ASCINSA"
                'XtraMessageBox.Show("No se pudo generar la Orden de Servicio en el ASCINSA")
            End Try
            

        End If

    End Sub

    'Protected Sub BtnEditar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnEditar.Click



    '    Dim Indice As Integer = 0

    '    codcliente = gridOServ.DataKeys(Indice).Item(0).ToString.Trim()
    '    aduana = gridOServ.DataKeys(Indice).Item(1).ToString.Trim()
    '    regimen = gridOServ.DataKeys(Indice).Item(2).ToString.Trim()

    '    Refer = gridOServ.Rows(Indice).Cells(5).Text.Trim
    '    Prioridad = gridOServ.DataKeys(Indice).Item(3).ToString.Trim()
    '    descMerca = gridOServ.DataKeys(Indice).Item(4).ToString.Trim()


    '    Response.Redirect("NuevaOrdenServicio.aspx?TB_iframe=true&amp;height=515;width=900 rel = 'sexylightbox'", True)

    'End Sub
End Class
