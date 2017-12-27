Imports NEG = Emp_Negocio
Imports ENT = Emp_Entity
Imports ENTI = Emp_Entidad
Imports System.IO
Imports System
Imports System.Data


Partial Class NuevaOrdenServicio
    Inherits System.Web.UI.Page
    Dim FecPeriodo As String = ""
    Dim AnoPeriodo As String = ""
    Dim DatoPeriodo As String = ""
    Dim FechInic As String = ""
    Dim FechFinal As String = ""
    Dim PeriodoS As String
    Dim Cpnia As String
    Dim servidor, usuario, zona As String
    Dim medio, cantidad, cliente, aduana, TipoOper, Refer, FechaVenc, Prioridad, PrioridaAsinsa, regimen, descMerca, tipocarga, tipopagoaduana, contacto As String
    Dim precedente As String = ""
    Dim vigencia As String = ""
    Dim regularizacion As String = ""
    Private _idOrden As String = ""
    Dim DatoBL As String = ""
    'DATOS DE LA EDICION'
    Dim CodOS As String = ""
    Dim Zonas As String = ""
    Dim Referencia As String = ""
    Dim Clientes As String = ""
    Dim Contactos As String = ""
    Dim Aduanas As String = ""
    Dim tipo As String = ""
    Dim medios As String = ""
    Dim regimens As String = ""
    Dim prioridades As String = ""
    Dim Venc As String = ""
    Dim DescripM As String = ""
    Dim tipocargas As String = ""
    Dim cantidads As String = ""
    Dim tipopago As String = ""
    Dim Pndctr As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Pndctr = Request.QueryString("lblpndctr")

            If Pndctr <> "" Then
                Me.btnCargaDatos.Visible = True
                aduana = Request.QueryString("aduana")  'txtaduana.Text  
                medio = Request.QueryString("Medio") 'txtmedio.Text
                TipoOper = Request.QueryString("Tipo") 'txttipo.Text
                regimen = Request.QueryString("regimen")  'txtregimen.Text
                Prioridad = Request.QueryString("Prioridad") ' txtprioridad.Text
                tipocarga = Request.QueryString("Tipocarga")  ' txttipocarga.Text 
                tipopagoaduana = Request.QueryString("Tipopago") 'txttipopago.Text


                txtCodOS.Text = Request.QueryString("CodOser")
                txtzona.Text = Session.Item("SesionCodZona")
                txtRef.Text = Request.QueryString("idRefer")
                txtCodCli.Text = Request.QueryString("IdCli")
                txtcontacto.Text = Request.QueryString("Contacto")

                txtaduana.Text = Request.QueryString("Aduana")
                txttipo.Text = Request.QueryString("tipo")
                txtmedio.Text = Request.QueryString("Medio")
                txtregimen.Text = Request.QueryString("Regimen")
                txtprioridad.Text = Request.QueryString("Prioridad")
                dtVenc.Text = Request.QueryString("FVenc")
                txtDescripM.Text = Request.QueryString("DescripM")
                txttipocarga.Text = Request.QueryString("Tipocarga")
                txtcantidad.Text = Request.QueryString("Cantidad")
                txttipopago.Text = Request.QueryString("Tipopago")
                lblpndctr.Text = Request.QueryString("lblpndctr")

            End If

            ' txtCodOS.Text = "12548"
            zona = Session.Item("SesionCodZona")
            LlenaCombos()

        End If


        Me.Label1.Text = ""
        Me.Label1.Visible = False
    End Sub


    Private Sub LlenaCombos()
        '  cmbCliente.DataSource = NEG.BR_Mant.GetTable("CL")
        cmbAduana.DataSource = NEG.BR_Mant.GetTable("AD")
        cmbAduana.DataTextField = "DCDSCD"
        cmbAduana.DataValueField = "PNCDIN"
        cmbAduana.DataBind()

        cmbMedio.DataSource = NEG.BR_Mant.GetTable("ME")
        cmbMedio.DataTextField = "DCDSCD"
        cmbMedio.DataValueField = "PNCDIN"
        cmbMedio.DataBind()

        cmbPrioridad.DataSource = NEG.BR_Mant.GetTable("PR")
        cmbPrioridad.DataTextField = "DCDSCD"
        cmbPrioridad.DataValueField = "PNCDIN"
        cmbPrioridad.DataBind()


        cmbRegimen.DataSource = NEG.BR_Mant.GetTable("RE")
        cmbRegimen.DataTextField = "DCDSRG"
        cmbRegimen.DataValueField = "PNCDRG"
        cmbRegimen.DataBind()


        cmbTipoPago.DataSource = NEG.BR_Mant.GetTable("TP")
        cmbTipoPago.DataTextField = "DCDSCD"
        cmbTipoPago.DataValueField = "PNCDIN"
        cmbTipoPago.DataBind()

        cmbZona.DataSource = NEG.BR_Mant.GetTable("ZO")
        cmbZona.DataTextField = "TZNFCC"
        cmbZona.DataValueField = "CZNFCC"
        cmbZona.DataBind()


        cbotipocarga.DataSource = NEG.BR_Mant.GetTable("TC")
        cbotipocarga.DataTextField = "DCDSCD"
        cbotipocarga.DataValueField = "PNCDIN"
        cbotipocarga.DataBind()

        '  Me.lkcliente.Properties.DataSource = NEG.BR_Mant.GetTable("CL")
        lkcliente.DataSource = NEG.BR_Mant.GetTable("CL")
        lkcliente.DataTextField = "DCNMCL"
        lkcliente.DataValueField = "DCASCI1"
        lkcliente.DataBind()


        '    Limpiar()

        If txtCodOS.Text = "" Then
            cmbZona.SelectedValue = -1
            cmbAduana.SelectedValue = -1
            cmbRegimen.SelectedValue = -1
            cmbPrioridad.SelectedValue = -1
            cmbMedio.SelectedValue = -1
            cmbTipoPago.SelectedValue = -1
            'cmbAduana.DataSource = NEG.BR_Mant.GetTable("AD")
            'cmbRegimen.DataSource = NEG.BR_Mant.GetTable("RE")
            'cmbPrioridad.DataSource = NEG.BR_Mant.GetTable("PR")
            'cmbMedio.DataSource = NEG.BR_Mant.GetTable("ME")
        End If


        If lblpndctr.Text <> "" Then
            Me.cmbZona.SelectedValue = zona
            Me.cmbAduana.SelectedValue = aduana
            Me.cmbMedio.SelectedValue = medio
            Me.cmbPrioridad.SelectedValue = Prioridad.ToString.Trim
            Me.cmbRegimen.SelectedValue = regimen
            Me.cmbTipoOper.SelectedValue = TipoOper
            Me.cmbTipoPago.SelectedValue = tipopagoaduana
            Me.cbotipocarga.SelectedValue = tipocarga
            Me.lkcliente.SelectedValue = txtCodCli.Text
        End If
    End Sub


    Protected Sub cmbZona_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbZona.SelectedIndexChanged
        txtzona.Text = cmbZona.SelectedValue
    End Sub

    Protected Sub cmbMedio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMedio.SelectedIndexChanged
        txtmedio.Text = cmbMedio.SelectedValue
        
    End Sub

    Protected Sub cmbTipoPago_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipoPago.SelectedIndexChanged
        txttipopago.Text = cmbTipoPago.SelectedValue
    End Sub

    Protected Sub cbotipocarga_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbotipocarga.SelectedIndexChanged
        txttipocarga.Text = cbotipocarga.SelectedValue
    End Sub

    Protected Sub cmbRegimen_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbRegimen.SelectedIndexChanged
        If cmbRegimen.SelectedIndex <> -1 Then

            If cmbTipoOper.Items.Count >= 1 Then
                cmbTipoOper.Items.Clear()
            End If

            cmbTipoOper.DataSource = NEG.BR_Mant.GetTable("TO", cmbRegimen.SelectedValue.ToString.Trim)
            cmbTipoOper.DataTextField = "DCDSOP"
            cmbTipoOper.DataValueField = "PNCDOP"
            cmbTipoOper.DataBind()

            If cmbTipoOper.Items.Count = 1 Then
                txttipo.Text = cmbTipoOper.SelectedValue
            Else
                txttipo.Text = cmbTipoOper.SelectedValue
            End If

            txtregimen.Text = cmbRegimen.SelectedValue
        End If
    End Sub

    Protected Sub cmbTipoOper_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipoOper.SelectedIndexChanged
        txttipo.Text = cmbTipoOper.SelectedValue
    End Sub

    Protected Sub cmbPrioridad_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPrioridad.SelectedIndexChanged
        txtprioridad.Text = cmbPrioridad.SelectedValue
    End Sub

    Protected Sub cmbAduana_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAduana.SelectedIndexChanged
        txtaduana.Text = cmbAduana.SelectedValue
    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim result As Integer = 0
        Dim pnnmos As String = ""
        Dim Data As DataTable


        Dim val As String = Validar()
        Try
            If txtzona.Text = "" Then
                Me.Label1.Visible = True
                Label1.Text = "Debe seleccionar una Zona.."
                txtzona.Focus()
                Exit Sub
            End If


            If txtCodCli.Text = "" Then
                Me.Label1.Visible = True
                Label1.Text = "Debe seleccionar un Cliente.."
                txtCodCli.Focus()
                Exit Sub
            End If


            If txtaduana.Text = "" Then
                Me.Label1.Visible = True
                Label1.Text = "Debe seleccionar La Aduana.."
                txtaduana.Focus()
                Exit Sub
            End If



            If txtregimen.Text = "" Then
                Me.Label1.Visible = True
                Label1.Text = "Debe seleccionar el Regimen.."
                txtregimen.Focus()
                Exit Sub
            End If

            If txtprioridad.Text = "" Then
                Me.Label1.Visible = True
                Label1.Text = "Debe seleccionar la prioridad.."
                txtprioridad.Focus()
                Exit Sub
            End If

            If txttipocarga.Text = "" Then
                Me.Label1.Visible = True
                Label1.Text = "Debe seleccionar el tipo de Carga.."
                txttipocarga.Focus()
                Exit Sub
            End If

            If txttipopago.Text = "" Then
                Me.Label1.Visible = True
                Label1.Text = "Debe seleccionar el tipo de Pago.."
                txttipopago.Focus()
                Exit Sub
            End If

            If dtVenc.Text = "" Then
                dtVenc.Text = ""
            Else
                If ValidarFecha(dtVenc.Text) = False Then
                    '   If Date.TryParse(txtAforo.Text, fech1) = True Then
                    dtVenc.Text = ""
                    Me.Label1.Visible = True
                    Me.Label1.Text = "Fecha Incorrecta"
                    dtVenc.Focus()
                    Exit Sub
                End If
            End If

                If rbPrecedentte.Checked = True Then
                    'TipoDocu = "W"
                    ' Session.Add("TipoDoc", TipoDocu)
                    precedente = "S"
                    vigencia = "N"
                    regularizacion = "N"
                End If

                If RbVigencia.Checked = True Then
                    'TipoDocu = "W"
                    ' Session.Add("TipoDoc", TipoDocu)
                    precedente = "N"
                    vigencia = "S"
                    regularizacion = "N"
                End If

                If RbRegularizacion.Checked = True Then
                    'TipoDocu = "W"
                    ' Session.Add("TipoDoc", TipoDocu)
                    precedente = "N"
                    vigencia = "N"
                    regularizacion = "S"
                End If

                If RbNinguno.Checked = True Then
                    'TipoDocu = "W"
                    ' Session.Add("TipoDoc", TipoDocu)
                    precedente = "N"
                    vigencia = "N"
                    regularizacion = "N"
                End If

                If val = 1 Then

                    medio = cmbMedio.SelectedValue.ToString
                    cliente = lkcliente.SelectedValue.ToString
                    aduana = cmbAduana.SelectedValue
                    TipoOper = cmbTipoOper.SelectedValue
                    regimen = cmbRegimen.SelectedValue.ToString
                    Refer = IIf(txtRef.Text = "", "", txtRef.Text)
                    FechaVenc = dtVenc.Text
                    Prioridad = cmbPrioridad.SelectedValue.ToString

                    Data = NEG.BR_Mant.GetTable("PA", Prioridad)

                    If Data.Rows.Count > 0 Then
                        PrioridaAsinsa = Data.Rows(0).Item(0).ToString
                    Else
                        PrioridaAsinsa = "00"
                    End If

                    descMerca = txtDescripM.Text.Trim
                    zona = cmbZona.SelectedValue
                    tipocarga = cbotipocarga.SelectedValue.ToString
                    tipopagoaduana = cmbTipoPago.SelectedValue.ToString
                    cantidad = txtcantidad.Text
                contacto = txtcontacto.Text.Trim
                DatoBL = Me.txtBL.Text.Trim


                    Dim objOS As New ENTI.EOrdenServ

                    With objOS
                        If lblpndctr.Text = "" Then
                        .PNCDTR = NEG.NOrdenServ.GetNumeroOS()
                        '.PNCDTR = "T000185755"
                        Else
                            .PNCDTR = Me.lblpndctr.Text
                        End If

                        .PNCDCO = "FZ"
                        .PNCDNG = "A"
                        .PNDCPL = "1"  'planta sale del usuario login 
                        .PNCDZO = zona  'zona sale del usuario login
                        .PNCDRG = regimen
                        .PNCDOP = TipoOper
                        .DCASCI = cliente
                        .DCASSA = txtAscinsa.Text
                        .DCTPOS = ""
                        .DCREFE = Refer
                        .FNCDAD = aduana
                        .DCPREC = precedente
                        .DNOSPR = "" 'txtOrdenServicio
                        .DCVIGE = vigencia
                        .FNCDPR = Prioridad
                        .DDVNDE = FechaVenc
                        .DCDSME = descMerca
                        .DCLUGA = "" 'txtLugarEntregaMercaderia
                        .DNTPCA = "" 'cboTipoCarga
                        .DCINSP = "" 'strInspeccionSanitaria 
                        If cantidad = "" Then
                            .DNCAM = 0
                        Else
                            .DNCAM = txtcantidad.Text
                        End If
                        .DNTRAN = medio
                        .DCORIG = ""
                        .DCCONT = contacto 'txtPersonaContacto
                        .DCREEI = "X"
                        .DCLIGA = "N" 'strLigadoaOs
                        .DCFACTU = "" 'cboFacturarA
                        .DCAVIS = ""
                        .DCRECL = "" 'strReclamarVolanteCliente
                        .DCOBSE = "" 'txtObservacionesOrdenServicio
                        .DCREG = ""
                        .DNFPAG = tipopagoaduana
                    .DNTPCA = tipocarga
                    .DCMOTI = DatoBL
                    End With

                pnnmos = NEG.NOrdenServ.InsertaOrdenServicio(objOS)
                    If pnnmos <> "" Then
                        objOS.PNNMOS = pnnmos
                    result = NEG.NOrdenServ.InsertaOrdenServicioAscinsa(objOS)
                        If result <> 0 Then
                            ' XtraMessageBox.Show("Se generó satisfactoriamente la Orden de Servicio Nº  " & objOS.PNNMOS)
                            Me.Label1.Visible = True
                            Label1.Text = "Se generó satisfactoriamente la Orden de Servicio Nº " & objOS.PNNMOS.ToString.Trim
                        Else
                            '  XtraMessageBox.Show("No se pudo generar la Orden de Servicio en el ASCINSA")
                            Me.Label1.Visible = True
                            Label1.Text = "No se pudo Generar la Orden de Servicio en el ASCINSA"
                        End If
                    Else
                        'XtraMessageBox.Show("No se pudo generar la Orden de Servicio en el ISERIES")
                        Me.Label1.Visible = True
                        Label1.Text = "No se pudo Generar la Orden de Servicio en el ISERIES"
                    End If

                Else
                    Me.Label1.Visible = True
                    Label1.Text = "Debe llenar todas las listas de selección o Combos...!!!"
                End If
        Catch ex As Exception
            Me.Label1.Visible = True
            If pnnmos = "" Then
                Label1.Text = "No se pudo Generar la Orden de Servicio en el ISERIES.."
            Else
                Label1.Text = "No se pudo Generar la Orden en el ASCINSA.."
            End If

            'XtraMessageBox.Show("No se pudo generar la Orden de Servicio en el ISERIES")
        End Try
       

    End Sub

    Private Function Validar() As Integer
        Validar = 1

        If cmbMedio.SelectedIndex = 0 Then
            Validar = 0
            Me.Label1.Visible = True
            Label1.Text = "Debe ingresar el Medio"
            ' MessageBox.Show("Debe ingresar el Medio")
            cmbMedio.Focus()
        Else
            If Me.lkcliente.SelectedIndex = 0 Then
                Validar = 0
                Me.Label1.Visible = True
                Label1.Text = "Debe ingresar un Cliente"
                'MessageBox.Show("Debe ingresar un Cliente")
                lkcliente.Focus()
            Else
                If cmbAduana.SelectedIndex = 0 Then
                    Validar = 0
                    Me.Label1.Visible = True
                    Label1.Text = "Debe ingresar Aduana"
                    'MessageBox.Show("")
                    cmbAduana.Focus()
                Else
                    If txttipo.Text = "" Then
                        Validar = 0
                        Me.Label1.Visible = True
                        Label1.Text = "Debe ingresar Tipo de Operación"
                        'MessageBox.Show("Debe ingresar Tipo de Operación")
                        cmbTipoOper.Focus()
                    Else
                        If cmbRegimen.SelectedIndex = 0 Then
                            Validar = 0
                            Me.Label1.Visible = True
                            Label1.Text = "Debe Ingresar Régimen"
                            'MessageBox.Show("Debe Ingresar Régimen")
                            cmbRegimen.Focus()
                        Else
                            If cmbPrioridad.SelectedIndex = 0 Then
                                Validar = 0
                                Me.Label1.Visible = True
                                Label1.Text = "Debe ingresar Prioridad de Despacho"
                                'XtraMessageBox.Show("Debe ingresar Prioridad de Despacho")
                                cmbPrioridad.Focus()
                            Else
                                If txtDescripM.Text = "" Then
                                    Validar = 0
                                    Me.Label1.Visible = True
                                    Label1.Text = "Debe Ingresar Descripción de la Mercadería"
                                    'XtraMessageBox.Show("Debe Ingresar Descripción de la Mercadería")
                                    txtDescripM.Focus()
                                Else
                                    'If dtVenc.Text = "" Then
                                    '    Validar = 0
                                    '    XtraMessageBox.Show("Debe Ingresar Fecha de Vencimiento")
                                    '    dtVenc.Focus()
                                    'Else
                                    If cbotipocarga.SelectedIndex = 0 Then
                                        Validar = 0
                                        Me.Label1.Visible = True
                                        Label1.Text = "Debe ingresar Tipo de Carga"
                                        'XtraMessageBox.Show("Debe ingresar Tipo de Carga")
                                        cbotipocarga.Focus()
                                        'End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If

    End Function

    Private Sub Limpiar()
        cmbMedio.SelectedIndex = 0
        'cmbCliente.SelectedIndex = -1
        cmbAduana.SelectedIndex = 0
        cmbZona.SelectedIndex = 0
        cmbTipoOper.SelectedIndex = -1
        txtRef.Text = ""
        dtVenc.Text = ""
        cmbPrioridad.SelectedIndex = 0
        cmbRegimen.SelectedIndex = 0
        cmbZona.SelectedIndex = 0
        cmbTipoPago.SelectedIndex = 0
        txtDescripM.Text = ""
        cbotipocarga.SelectedIndex = 0
        txtcantidad.Text = 0
        txtSIL.Text = ""
        txtzona.Text = ""
        'txtcliente.Text = ""
        txtaduana.Text = ""
        txtregimen.Text = ""
        txttipo.Text = ""
        txtprioridad.Text = ""
        txtmedio.Text = ""
        txttipocarga.Text = ""
        txttipopago.Text = ""
        lblpndctr.Text = ""
    End Sub

    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        'TipoOper = cmbTipoOper.SelectedValue
        Limpiar()
    End Sub

    Function ValidarFecha(ByVal dato As String) As Boolean

        Dim Success As Boolean = True

        If Not IsDate(dato) Then
            ' LblDesde.Visible = True
            Success = False
            Exit Function
        End If

        '   Dim date1 As DateTime = CDate(dato.Text.Trim())
        Return Success
    End Function

    Protected Sub lkcliente_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lkcliente.SelectedIndexChanged
        txtCodCli.Text = lkcliente.SelectedValue
    End Sub

   
End Class
