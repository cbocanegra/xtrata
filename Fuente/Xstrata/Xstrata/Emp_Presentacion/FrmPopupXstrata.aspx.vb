
Imports Entidad = Emp_Entity
Imports Datos = Emp_Datos
Imports Emp_Negocio

Partial Class FrmPopupXstrata
    Inherits System.Web.UI.Page

    Dim Norden As String = ""
    Dim NroBL As String = ""
    Dim FecEstimada As String = ""
    Dim FecLlegada As String = ""
    Dim DatosTI As String = ""
    Dim DatoCli As String = ""
    Dim DatMercancia As String = ""
    Dim DatTipo As String = ""
    Dim DatPNCDTR As String = ""
    Dim DatDDRDDC As String = ""
    Dim DatDDCRDP As String = ""
    Dim DatDDOEMB As String = ""
    Dim DatDNSBRE As String = ""
    Dim DatDNDSLB As String = ""
    Dim DatDDTDES As String = ""
    Dim DatDDTREC As String = ""
    Dim DatDDOBVL As String = ""
    Dim DatDDAFPR As String = ""
    Dim DatVDDFINA As String = ""
    Dim datDDANUM As String = ""
    Dim datDDNUME As String = ""
    Dim DatDDPGDR As String = ""
    Dim DatDDAFOR As String = ""
    Dim DatDDPRES As String = ""
    Dim DatDDLEVA As String = ""
    Dim DatDDRETI As String = ""


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            Norden = Request.QueryString("CodOser").ToString.Trim
            NroBL = Request.QueryString("BL").ToString.Trim
            FecEstimada = Request.QueryString("FecEstimad").ToString.Trim
            FecLlegada = Request.QueryString("FecLlegada").ToString.Trim
            DatosTI = Request.QueryString("DTI").ToString.Trim
            DatoCli = Request.QueryString("CLI").ToString.Trim
            DatMercancia = Request.QueryString("Mercancia").ToString.Trim
            DatTipo = Request.QueryString("Tipo").ToString.Trim

            DatPNCDTR = Request.QueryString("V_PNDCTR").ToString.Trim
            Session.Add("SPNDCTR", DatPNCDTR)

            DatDDRDDC = Request.QueryString("V_DDRDDC").ToString.Trim
            Session.Add("SDDRDDC", DatDDRDDC)

            DatDDCRDP = Request.QueryString("V_DDCRDP").ToString.Trim
            Session.Add("SDDCRDP", DatDDCRDP)

            DatDDOEMB = Request.QueryString("V_DDOEMB").ToString.Trim


            DatDNSBRE = Request.QueryString("V_DNSBRE").ToString.Trim
            Session.Add("SDNSBRE", DatDNSBRE)

            DatDNDSLB = Request.QueryString("V_DNDSLB").ToString.Trim
            Session.Add("SDNDSLB", DatDNDSLB)

            DatDDTDES = Request.QueryString("V_DDTDES").ToString.Trim
            Session.Add("SDDTDES", DatDDTDES)

            DatDDTREC = Request.QueryString("V_DDTREC").ToString.Trim
            Session.Add("SDDTREC", DatDDTREC)

            DatDDOBVL = Request.QueryString("V_DDOBVL").ToString.Trim
            Session.Add("SDDOBVL", DatDDOBVL)

            DatDDAFPR = Request.QueryString("V_DDAFPR").ToString.Trim
            Session.Add("SDDAFPR", DatDDAFPR)


            DatVDDFINA = Request.QueryString("V_VDDFINA").ToString.Trim
            Session.Add("SVDDFINA", DatVDDFINA)


            datDDANUM = Request.QueryString("V_DDANUM").ToString.Trim
            Session.Add("SDDANUM", datDDANUM)


            datDDNUME = Request.QueryString("V_DDNUME").ToString.Trim
            Session.Add("SDDNUME", datDDNUME)


            DatDDPGDR = Request.QueryString("V_DDPGDR").ToString.Trim
            Session.Add("SDDPGDR", DatDDPGDR)


            DatDDAFOR = Request.QueryString("V_DDAFOR").ToString.Trim
            Session.Add("SDDAFOR", DatDDAFOR)

            DatDDPRES = Request.QueryString("V_DDPRES").ToString.Trim
            Session.Add("SDDPRES", DatDDPRES)


            DatDDLEVA = Request.QueryString("V_DDLEVA").ToString.Trim
            Session.Add("SDDLEVA", DatDDLEVA)


            DatDDRETI = Request.QueryString("V_DDRETI").ToString.Trim
            Session.Add("SDDRETI", DatDDRETI)


            txtBL.Text = NroBL.Trim
            txtTI.Text = DatosTI.Trim
            txtCliente.Text = DatoCli.Trim
            txtMercaderia.Text = DatMercancia.Trim
            txtTipos.Text = DatTipo.Trim
            txtFecEstimada.Text = FecEstimada
            txtFechaLlegada.Text = FecLlegada
            txtFechaEmbarque.Text = DatDDOEMB
            lblOrdenServicio.Text = Norden

        End If

    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim Negocio As New NOrdenXTRATA

        If Session.Item("SPNDCTR").ToString.Trim = "" Then

        Else
            Dim EDetalle As New Entidad.EOrdenXSTRATA
            With EDetalle
                .PNDCTR = Session.Item("SPNDCTR").ToString.Trim
                .DDRDDC = FormatoFecha(Session.Item("SDDRDDC").ToString.Trim)
                .DDCRDP = FormatoFecha(Session.Item("SDDCRDP").ToString.Trim)
                .DDOEMB = FormatoFecha(txtFechaEmbarque.Text.ToString.Trim)
                .DNSBRE = Session.Item("SDNSBRE").ToString.Trim
                If .DNSBRE = "" Then
                    .DNSBRE = 0
                End If
                .DNDSLB = Session.Item("SDNDSLB").ToString.Trim
                If .DNDSLB = "" Then
                    .DNDSLB = 0
                End If
                .DDETLG = FormatoFecha(txtFecEstimada.Text.ToString.Trim) & " " & FormatoHora(horaactual, txtFecEstimada.Text.ToString.Trim)
                .DDNAVE = FormatoFecha(txtFechaLlegada.Text.ToString.Trim)
                .DDTDES = FormatoFecha(Session.Item("SDDTDES").ToString.Trim) & " " & FormatoHora(horaactual, Session.Item("SDDTDES").ToString.Trim)
                .DDTREC = FormatoFecha(Session.Item("SDDTDES").ToString.Trim)
                .DDOBVL = FormatoFecha(Session.Item("SDDOBVL").ToString.Trim) & " " & FormatoHora(horaactual, Session.Item("SDDOBVL").ToString.Trim)
                .DDAFPR = FormatoFecha(Session.Item("SDDAFPR").ToString.Trim) & " " & FormatoHora(horaactual, Session.Item("SDDAFPR").ToString.Trim)
                .VDDFINA = FormatoFecha(Session.Item("SVDDFINA").ToString.Trim) & " " & FormatoHora(horaactual, Session.Item("SVDDFINA").ToString.Trim)
                .DDANUM = FormatoFecha(Session.Item("SDDANUM").ToString.Trim) & " " & FormatoHora(horaactual, Session.Item("SDDANUM").ToString.Trim)
                .DDNUME = FormatoFecha(Session.Item("SDDNUME").ToString.Trim) & " " & FormatoHora(horaactual, Session.Item("SDDNUME").ToString.Trim)
                .DDPGDR = FormatoFecha(Session.Item("SDDPGDR").ToString.Trim) & " " & FormatoHora(horaactual, Session.Item("SDDPGDR").ToString.Trim)
                .DDAFOR = FormatoFecha(Session.Item("SDDAFOR").ToString.Trim) & " " & FormatoHora(horaactual, Session.Item("SDDAFOR").ToString.Trim)
                .DDPRES = FormatoFecha(Session.Item("SDDPRES").ToString.Trim) & " " & FormatoHora(horaactual, Session.Item("SDDPRES").ToString.Trim)
                .DDLEVA = FormatoFecha(Session.Item("SDDLEVA").ToString.Trim) & " " & FormatoHora(horaactual, Session.Item("SDDLEVA").ToString.Trim)
                .DDRETI = FormatoFecha(Session.Item("SDDRETI").ToString.Trim) & " " & FormatoHora(horaactual, Session.Item("SDDRETI").ToString.Trim)
            End With

            Negocio.FechasChekpoint_Insert(EDetalle)
            Me.Label1.Visible = True
            Me.Label1.Text = "Modificacion Exitosa..!!"

        End If
    End Sub

    Public Function FormatoFecha(ByVal fecha As String) As String
        If fecha = "" Then
            Return ""
        Else
            Dim año As String = fecha.Substring(6, 4)
            Dim mes As String = fecha.Substring(3, 2)
            Dim dia As String = fecha.Substring(0, 2)
            Return año & "-" & mes & "-" & dia
        End If

    End Function

    Public Function FormatoHora(ByVal hora As String, ByVal fecha As String) As String
        If fecha = "  /  /" Or fecha = "" Then
            Return ""
        Else
            hora = hora.Substring(0, 8)
            Return hora
        End If
    End Function


    Public Function horaactual() As String
        Dim hora As String
        Dim minutos As String
        Dim segundos As String
        Dim cadena As String
        hora = Hour(TimeString)
        minutos = Minute(TimeString)
        segundos = Second(TimeString)
        If hora < 10 Then
            hora = "0" & hora
        End If
        If minutos < 10 Then
            minutos = "0" & minutos
        End If
        If segundos < 10 Then
            segundos = "0" & segundos
        End If
        cadena = hora & ":" & minutos & ":" & segundos
        Return cadena
    End Function
End Class
