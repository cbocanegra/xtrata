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
Partial Class Ejeplo
    Inherits System.Web.UI.Page
    Dim CapturaCampos, alcampos As New ArrayList
    Dim slista As List(Of SE.Samsung)
    Dim SlistaXstrata As List(Of ENTID.XSTRATA)
    Dim Os, Refer, Nave, Canal, BLL, Aforos, Retiros, FormatAforo, FormatRetiro, FormatNumeracion, Numeraciones, TipCanal, TipOrdenServicio, EstadoOserv As String
    Dim contador As Integer
    'Sub Llenar_Empleado()
    '    slista = SN.SEmpleado.FillEmp
    '    Me.DtgRepresentante.DataSource = slista
    '    Me.DtgRepresentante.DataBind()
    'End Sub
    Sub Fill_Samsung()
        slista = SN.NSamsung._GetSamsung(Session.Item("OrdSesion"), Session.Item("Referencia"), Session.Item("Naves"), Session.Item("Canal"), Session.Item("BLLs"), Session.Item("Aforo"), Session.Item("Retir"), Session.Item("Numerac"), Session.Item("ValCodigoCli"))
        Me.DtgRepresentante.DataSource = slista
        Me.GridView1.DataSource = slista
        Me.DtgRepresentante.DataBind()
        Me.GridView1.DataBind()
    End Sub

    Sub Fill_Xstrata()
        SlistaXstrata = SN.NXstrata._ObtieneDatosXtrata(Session.Item("OrdSesion"), Session.Item("Referencia"), Session.Item("Naves"), Session.Item("Canal"), Session.Item("BLLs"), Session.Item("Aforo"), Session.Item("Retir"), Session.Item("Numerac"), Session.Item("ValCodigoCli"), Session.Item("TiposCanal"), Session.Item("TiposOrden"), Session.Item("EstadoOrden"))
        Me.DtgRepresentante.DataSource = SlistaXstrata
        Me.GridView1.DataSource = SlistaXstrata
        Me.DtgRepresentante.DataBind()
        Me.GridView1.DataBind()
    End Sub


    Public Shared Function _GetData() As DataTable

        Dim Recup As New DataTable
        Try
            Dim cadena As String
            cadena = " select IdProducto,IdCategoria,IdProveedor,Nombre,UnidadMedida,PrecioProveedor,StockActual,StockMinimo from producto "            
            Recup = TraerDataTable(cadena)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Recup
    End Function

    Public Function _GetSamsung(ByVal Os As String, ByVal Refer As String, ByVal Nave As String, ByVal Canal As String, ByVal Bll As String, ByVal Aforo As String, ByVal Retiro As String) As DataTable

        Dim Recup As New DataTable
        Dim Aforos, Retiros, Order As String
        Order = " ORDER BY A.DDREGI DESC"
        Try
            Dim cadena As String
            cadena = " SELECT A.PNNMOS AS ORDEN, A.DCTPOS AS TIPO, CASE WHEN A.FNCDPR = '00' THEN 'Normal' WHEN A.FNCDPR = '01' THEN 'Urgente' WHEN A.FNCDPR = '02' THEN 'Socorro' WHEN A.FNCDPR = '10' THEN 'Anticipado' END AS SITUACION, A.DDREGI AS APERTURA, B.DCDSRG AS REGIMEN, C.DCDSOP AS OPERACION, G.DCDSCD AS CARGA, H.DCDSCD AS CANAL, D.DCNMCL AS CLIENTE, A.DCREFE AS REFERENCIA, A.DCDSME AS MERCADERIA, P.DCNAVE AS NAVE, P.DDNAVE AS ESTIMADO, I.DDNAVE AS LLEGADA, I.DDTDES AS TERMINO, J.DCDSAB AS TERMINAL, P.PCNMDC AS BL, I.DCNMMA AS MANIFIESTO, I.DCNMDM AS NUMERO, Q.DCDSCD AS AGMARITIMO, S.DCDSCD AS AGCARGA, A.DCDUIDUE AS DUA, CASE WHEN SUBSTR(A.DCTPOS, 1, 1) = 'I' THEN E.DDNUME WHEN SUBSTR(A.DCTPOS, 1, 1) = 'E' THEN F.DDNDUE END AS NUMERACION, E.DDPGDR AS PAGO, E.DMTTDR AS MONTO, K.DDINIA AS SENASA, L.DDFINA AS AFORO, M.DDINIA AS PRESENTACION, N.DDINIA AS LEVANTE, O.DDFINA AS RETIRO FROM LIBORDAG.DORDENES A JOIN LIBORDAG.CREGIMEN B ON A.PNCDRG = B.PNCDRG JOIN LIBORDAG.COPERACI C ON A.PNCDOP = C.PNCDOP JOIN LIBORDAG.DCLIENTE D ON A.DCASCI = D.DCASCI LEFT OUTER JOIN LIBORDAG.DSEGIMP E ON A.PNCDTR = E.PNCDTR LEFT OUTER JOIN LIBORDAG.DSEGEXP F ON A.PNCDTR = F.PNCDTR LEFT OUTER JOIN LIBORDAG.PCODIGOS G ON A.DNTPCA = G.PNCDIN AND G.PCTABL = 'TIPCARGA' LEFT OUTER JOIN LIBORDAG.PCODIGOS H ON A.DCCANA = H.PNCDIN AND H.PCTABL = 'CANAL' LEFT OUTER JOIN LIBORDAG.DVOLANTE I ON A.PNCDTR = I.PNCDTR LEFT OUTER JOIN LIBORDAG.PCODIGOS J ON I.FNCDDP = J.PNCDIN AND J.PCTABL = 'DEPOSITO' LEFT OUTER JOIN LIBORDAG.RACBASOS K ON A.PNCDTR = K.PNCDTR AND K.PNCDAC = 'I14' LEFT OUTER JOIN LIBORDAG.RACBASOS L ON A.PNCDTR = L.PNCDTR AND L.PNCDAC = 'I13' LEFT OUTER JOIN LIBORDAG.RACBASOS M ON A.PNCDTR = M.PNCDTR AND M.PNCDAC = 'I16' LEFT OUTER JOIN LIBORDAG.RACBASOS N ON A.PNCDTR = N.PNCDTR AND N.PNCDAC = 'I12' LEFT OUTER JOIN LIBORDAG.RACBASOS O ON A.PNCDTR = O.PNCDTR AND O.PNCDAC = 'I15' LEFT OUTER JOIN LIBORDAG.DDOCEMB P ON A.PNCDTR = P.PNCDTR LEFT OUTER JOIN LIBORDAG.PCODIGOS Q ON E.DCAGMR = Q.PNCDIN AND Q.PCTABL = 'AGETRAN' LEFT OUTER JOIN LIBORDAG.DAGCARGA R ON A.PNCDTR = R.PNCDTR LEFT OUTER JOIN LIBORDAG.PCODIGOS S ON R.PNCDIN = S.PNCDIN AND S.PCTABL = 'AGECARGA' WHERE A.PNCDCO = 'FZ' AND A.PNCDNG = 'A' AND A.PNDCPL = '1' AND A.PNCDZO = '1' " & _
                     " AND A.DCESTA = 'A' AND A.DCASCI='31172' " & _
                     " AND CHAR(PNNMOS) LIKE '%" & Os & "%' AND A.DCREFE like '%" & Refer & "%' " & _
                     " AND A.DCDSME like '%" & Nave & "%' AND G.DCDSCD LIKE '%" & Canal & "%' AND P.PCNMDC LIKE '%" & Bll & "%' "

            If Aforo.Length > 0 Then
                Aforos = "AND CAST(L.DDFINA AS DATE)= '" & Aforo & "'"
                'Aforos = "AND CAST(L.DDFINA AS DATE)= '2010-10-18' "
                cadena = cadena & Aforos
            End If
            If Retiro.Length > 0 Then
                Retiros = "AND CAST(O.DDFINA AS DATE)= '" & Retiro & "'"
                cadena = cadena & Retiros
            End If

            cadena = cadena & Order
            'Response.write(cadena)

            Recup = TraerDataTableDB2(cadena)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Recup
    End Function


    Public Shared Function TraerDataTable(ByVal strSql As String) As DataTable
        Using CON As SqlConnection = SD.Conexion.GetConnection
            Using myDataAdapter As New SqlDataAdapter(strSql, CON)
                Dim tabla As DataTable
                tabla = New DataTable
                Try
                    myDataAdapter.Fill(tabla)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                Return tabla
            End Using
        End Using
    End Function

    Public Shared Function TraerDataTableDB2(ByVal strSql As String) As DataTable
        Using CON As iDB2Connection = SD.ConexionDB2.GetConnection
            Using myDataAdapter As New iDB2DataAdapter(strSql, CON)
                Dim tabla As DataTable
                tabla = New DataTable
                Try
                    myDataAdapter.Fill(tabla)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                Return tabla
            End Using
        End Using
    End Function

    Public Shared Function TraerLista(ByVal strSql As String) As IList
        Using CON As SqlConnection = SD.Conexion.GetConnection
            Using myDataAdapter As New SqlDataAdapter(strSql, CON)
                Dim tabla As DataTable
                tabla = New DataTable
                Try
                    myDataAdapter.Fill(tabla)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                Return tabla
            End Using
        End Using
    End Function

    'Protected Sub btnBusqueda_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBusqueda.Click
    '    'Llenar_Empleado()
    '    Evaldatos()
    '    Session.Add("OrdSesion", Os)
    '    Session.Add("Referencia", Refer)
    '    Session.Add("Naves", Nave)
    '    Session.Add("Canal", Canal)
    '    Session.Add("BLLs", BLL)
    '    Session.Add("Aforo", FormatAforo)
    '    Session.Add("Retir", FormatRetiro)

    '        Me.DtgRepresentante.DataSource = _GetSamsung(Os, Refer, Nave, Canal, BLL, FormatAforo, FormatRetiro)
    '        Me.DtgRepresentante.DataBind()
    '        Me.GridView1.DataSource = _GetSamsung(Os, Refer, Nave, Canal, BLL, FormatAforo, FormatRetiro)
    '        Me.GridView1.DataBind()
    '        Me.btnReporte.Visible = True
    '        Me.lblReporte.Visible = True
    'End Sub

    Public Sub EvaldatosALL()
        Dim Afor, Retiro, Present, fech1 As Date
        Os = Trim(Me.txtNombEmp.Text)
        Refer = Trim(Me.txtNombRepres.Text)
        Nave = Trim(Me.txtAutoriz.Text)
        Canal = Trim(Me.txtCorreo.Text)
        BLL = Trim(Me.Bl.Text)
        If Me.txtAforo.Text <> "" Then
            If ValidarFecha(txtAforo.Text) = False Then
                '   If Date.TryParse(txtAforo.Text, fech1) = True Then
                FormatAforo = ""
                Me.lblMensaje.Visible = True
                Me.lblMensaje.Text = "Fecha Incorrecta"
                'FormatAforo = CDate(Me.txtAforo.Text).ToString("yyyy-MM-dd").ToString()
            Else
                Aforos = (Me.txtAforo.Text).Trim
                Afor = CType(Aforos, Date)
                FormatAforo = Format(Afor, "yyyy-MM-dd")
            End If
        Else
            FormatAforo = (Me.txtAforo.Text).Trim
            'Me.lblMensaje.Visible = True
            'Me.lblMensaje.Text = "Fecha Incorrecta"
            'Exit Sub
        End If
        'End If

        If Me.txtRetiro.Text <> "" Then
            If ValidarFecha(txtRetiro.Text) = False Then
                Retiros = (Me.txtRetiro.Text).Trim
                Retiro = CType(Retiros, Date)
                FormatRetiro = Format(Retiro, "yyyy-MM-dd")
            Else
                FormatRetiro = ""
                Me.lblMensaje.Visible = True
                Me.lblMensaje.Text = "Fecha Incorrecta"
            End If
        Else
            FormatRetiro = (Me.txtRetiro.Text).Trim
        End If

        'Estabeciendo Session

    End Sub

    Public Sub Evaldatos()
        Dim Afor, Retiro, Numeracion As Date
        Os = Trim(Me.txtNombEmp.Text)
        Refer = Trim(Me.txtNombRepres.Text)
        Nave = Trim(Me.txtAutoriz.Text)
        Canal = Trim(Me.txtCorreo.Text)
        BLL = Trim(Me.Bl.Text)
        TipCanal = Me.DDLCanal.SelectedValue.ToString.Trim
        TipOrdenServicio = Me.DDLTipo.SelectedValue.ToString.Trim
        EstadoOserv = Me.DDLEstado.SelectedValue.ToString.Trim

        If Me.txtAforo.Text <> "" Then
            If ValidarFecha(txtAforo.Text) = False Then
                '   If Date.TryParse(txtAforo.Text, fech1) = True Then
                FormatAforo = ""
                Me.lblMensaje.Visible = True
                Me.lblMensaje.Text = "Fecha Incorrecta"
            Else
                Aforos = (Me.txtAforo.Text).Trim
                Afor = CType(Aforos, Date)
                FormatAforo = Format(Afor, "yyyy-MM-dd")
            End If
        Else
            FormatAforo = (Me.txtAforo.Text).Trim
        End If
        'End If

        If Me.txtRetiro.Text <> "" Then
            If ValidarFecha(txtRetiro.Text) = False Then
                FormatRetiro = ""
                Me.lblMensaje.Visible = True
                Me.lblMensaje.Text = "Fecha Incorrecta"
            Else
                Retiros = (Me.txtRetiro.Text).Trim
                Retiro = CType(Retiros, Date)
                FormatRetiro = Format(Retiro, "yyyy-MM-dd")
            End If
        Else
            FormatRetiro = (Me.txtRetiro.Text).Trim
        End If

        If Me.txtNumeracion.Text <> "" Then
            If ValidarFecha(txtNumeracion.Text) = False Then
                FormatNumeracion = ""
                Me.lblMensaje.Visible = True
                Me.lblMensaje.Text = "Fecha Incorrecta"
            Else
                Numeraciones = (Me.txtNumeracion.Text).Trim
                Numeracion = CType(Numeraciones, Date)
                FormatNumeracion = Format(Numeracion, "yyyy-MM-dd")
            End If
        Else
            FormatNumeracion = (Me.txtNumeracion.Text).Trim
        End If


        'Estabeciendo Session

    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        ' Dim slista1 As List(Of SE.Samsung)
        Dim slistaXstrata As List(Of ENTID.XSTRATA)
        'slista1 = SN.NSamsung._GetSamsung(Session.Item("OrdSesion"), Session.Item("Referencia"), Session.Item("Naves"), Session.Item("Canal"), Session.Item("BLLs"), Session.Item("Aforo"), Session.Item("Retir"), Session.Item("Numerac"), Session.Item("ValCodigoCli"))
        slistaXstrata = SN.NXstrata._ObtieneDatosXtrata(Session.Item("OrdSesion"), Session.Item("Referencia"), Session.Item("Naves"), Session.Item("Canal"), Session.Item("BLLs"), Session.Item("Aforo"), Session.Item("Retir"), Session.Item("Numerac"), Session.Item("ValCodigoCli"), Session.Item("TiposCanal"), Session.Item("TiposOrden"), Session.Item("EstadoOrden"))
        Me.GridView1.PageIndex = e.NewPageIndex        
        'Me.GridView1.DataSource = _GetSamsung(Session.Item("OrdSesion"), Session.Item("Referencia"), Session.Item("Naves"), Session.Item("Canal"), Session.Item("BLLs"), Session.Item("Aforo"), Session.Item("Retir"))
        ' Me.GridView1.DataSource = slista1
        Me.GridView1.DataSource = slistaXstrata
        Me.DtgRepresentante.PageIndex = e.NewPageIndex
        'Me.DtgRepresentante.DataSource = _GetSamsung(Session.Item("OrdSesion"), Session.Item("Referencia"), Session.Item("Naves"), Session.Item("Canal"), Session.Item("BLLs"), Session.Item("Aforo"), Session.Item("Retir"))
        'Me.DtgRepresentante.DataSource = slista1
        Me.DtgRepresentante.DataSource = slistaXstrata
        Me.DtgRepresentante.DataBind()
        Me.GridView1.DataBind()
    End Sub

    
    Protected Sub btnReporte_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnReporte.Click
        Dim style As String = ""
        Dim sb As StringBuilder = New StringBuilder()
        Dim sw As StringWriter = New StringWriter(sb)
        Dim htw As HtmlTextWriter = New HtmlTextWriter(sw)
        Dim pagina As Page = New Page
        Dim grilla As New GridView
        Dim slistaXstrata2 As List(Of ENTID.XSTRATA)
        ' slista2 = SN.NSamsung._GetSamsung(Session.Item("OrdSesion"), Session.Item("Referencia"), Session.Item("Naves"), Session.Item("Canal"), Session.Item("BLLs"), Session.Item("Aforo"), Session.Item("Retir"), Session.Item("Numerac"), Session.Item("ValCodigoCli"))
        slistaXstrata2 = SN.NXstrata._ObtieneDatosXtrata(Session.Item("OrdSesion"), Session.Item("Referencia"), Session.Item("Naves"), Session.Item("Canal"), Session.Item("BLLs"), Session.Item("Aforo"), Session.Item("Retir"), Session.Item("Numerac"), Session.Item("ValCodigoCli"), Session.Item("TiposCanal"), Session.Item("TiposOrden"), Session.Item("EstadoOrden"))
        grilla.EnableViewState = False
        grilla.AllowPaging = False        
        ' grilla.DataSource = slista2
        grilla.DataSource = slistaXstrata2
        grilla.DataBind()

        '---------------HEADERS-------------------------------------------------------

        Dim row As Integer

        '---------------SETEANDO CABECERA GRILLA--------------------------------------
        grilla.HeaderRow.Cells(0).Text = "BL"
        grilla.HeaderRow.Cells(1).Text = "Tipo"
        grilla.HeaderRow.Cells(2).Text = "Situacion"
        grilla.HeaderRow.Cells(3).Text = "Orden"
        grilla.HeaderRow.Cells(4).Text = "Mercaderia"
        grilla.HeaderRow.Cells(5).Text = "Fecha"
        grilla.HeaderRow.Cells(6).Text = "Regimen"
        grilla.HeaderRow.Cells(7).Text = "Operación"
        grilla.HeaderRow.Cells(8).Text = "Vapor"
        grilla.HeaderRow.Cells(9).Text = "Fecha Estimada"
        grilla.HeaderRow.Cells(10).Text = "Fecha Llegada"
        grilla.HeaderRow.Cells(11).Text = "Termino Descarga"
        grilla.HeaderRow.Cells(12).Text = "Almacenes"
        grilla.HeaderRow.Cells(13).Text = "Fecha Ubicación"
        grilla.HeaderRow.Cells(14).Text = "Fecha Visto Bueno"
        grilla.HeaderRow.Cells(15).Text = "Fecha Numeración"
        grilla.HeaderRow.Cells(16).Text = "Fecha Pago"
        grilla.HeaderRow.Cells(17).Text = "Tipo Bulto"
        grilla.HeaderRow.Cells(18).Text = "Canal"
        grilla.HeaderRow.Cells(19).Text = "Fecha Aforo"
        grilla.HeaderRow.Cells(20).Text = "Fecha Presentación"
        grilla.HeaderRow.Cells(21).Text = "Fecha Levante"
        grilla.HeaderRow.Cells(22).Text = "Fecha Retiro"
        grilla.HeaderRow.Cells(23).Text = "NIT"
        grilla.HeaderRow.Cells(24).Text = "DAM"
        grilla.HeaderRow.Cells(25).Text = "Obervaciones"
        grilla.HeaderRow.Cells(26).Text = "Nro. Manifiesto"
        grilla.HeaderRow.Cells(27).Text = "Referencia"
        grilla.HeaderRow.Cells(28).Text = "Fecha BL"
        grilla.HeaderRow.Cells(29).Text = "Nombre Cliente"
        grilla.HeaderRow.Cells(30).Text = "Carga"
        grilla.HeaderRow.Cells(31).Text = "Liquidador"


        grilla.HeaderRow.BackColor = Drawing.Color.FromArgb(93, 123, 157)
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

        'grilla.Columns(0).Visible = False
        Dim form = New HtmlForm
        pagina.EnableEventValidation = False
        pagina.DesignerInitialize()
        pagina.Controls.Add(form)
        form.Controls.Add(grilla)
        pagina.RenderControl(htw)
        Response.Clear()
        Response.Buffer = True
        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("Content-Disposition", "attachment;filename=Importacion.xls")
        Response.Charset = "UTF-8"
        Response.ContentEncoding = Encoding.Default
        Response.Write(style)
        Dim Titulo As String = "Sup.Importacion Samsung "
        HttpContext.Current.Response.Write(Titulo)
        Response.Write(sb.ToString())
        Response.End()

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

    Public Sub RecorreGrilla()

        Dim conta As Integer
        CapturaCampos = Session.Item("EnvioDatos")        
        If CapturaCampos IsNot Nothing Then
            If CapturaCampos.Count <> Nothing Then
                For conta = 0 To (CapturaCampos.Count - 1)
                    Me.DtgRepresentante.Columns(CapturaCampos.Item(conta)).Visible = False
                    Me.GridView1.Columns(CapturaCampos.Item(conta)).Visible = False
                Next
            End If
        End If      
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Nombrecli As String = ""
        Me.lblMensaje.Visible = False

        Nombrecli = SN.NSamsung._NombreClientes(Session.Item("ValCodigoCli").ToString.Trim)

        Evaldatos()

        Session.Add("OrdSesion", Os)
        Session.Add("Referencia", Refer)
        Session.Add("Naves", Nave)
        Session.Add("Canal", Canal)
        Session.Add("BLLs", BLL)
        Session.Add("Aforo", FormatAforo)
        Session.Add("Retir", FormatRetiro)
        Session.Add("TiposCanal", TipCanal)
        Session.Add("TiposOrden", TipOrdenServicio)
        Session.Add("EstadoOrden", EstadoOserv)


        lblNombCliente.Text = Nombrecli

        'Me.DtgRepresentante.DataSource = _GetSamsung(Os, Refer, Nave, Canal, BLL, FormatAforo, FormatRetiro)        
        'Me.DtgRepresentante.DataBind()
        'Me.GridView1.DataSource = _GetSamsung(Os, Refer, Nave, Canal, BLL, FormatAforo, FormatRetiro)
        'Me.GridView1.DataBind()
        'Fill_Samsung()
        Fill_Xstrata()

        Me.btnReporte.Visible = True
        Me.lblReporte.Visible = True
        RecorreGrilla()
    End Sub

    Public Sub LlenarCampos()
        Dim contador As Integer
        Dim s As String
        If Me.CheckBoxList1.Items.Count <= 0 Then
            For contador = 0 To 27
                'pintando campos a Chekboxlist
                's = Me.GridView1.RowHeaderColumn(0).ToString()
                ' s = Me.GridView1.Columns(0).HeaderText
                If contador >= 2 Then
                    If Me.DtgRepresentante.Columns(contador).Visible = True Then
                        Me.CheckBoxList1.Items.Add(Me.DtgRepresentante.Columns(contador).HeaderText)
                    Else
                        Me.CheckBoxList1.Items.Add(Me.DtgRepresentante.Columns(contador).HeaderText)
                        Me.CheckBoxList1.Items(contador).Selected = True
                    End If
                Else
                    If Me.GridView1.Columns(contador).Visible = True Then
                        Me.CheckBoxList1.Items.Add(Me.GridView1.Columns(contador).HeaderText)
                    Else
                        Me.CheckBoxList1.Items.Add(Me.GridView1.Columns(contador).HeaderText)
                        Me.CheckBoxList1.Items(contador).Selected = True
                    End If
                End If
            Next
        End If
    End Sub

    Protected Sub ImageButton2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click
        Me.Panel1.Visible = True
        LlenarCampos()
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Me.Panel1.Visible = False
        Me.CheckBoxList1.Items.Clear()
    End Sub
    

    Protected Sub ImageButton3_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton3.Click
        Dim a As Integer
        Dim contador As Integer
        For contador = 0 To CheckBoxList1.Items.Count - 1
            'recorriendo la lista chekboslit
            If CheckBoxList1.Items(contador).Selected = True Then
                a = a + 1
                alcampos.Add(contador)
            End If
        Next
        Session.Add("EnvioDatos", alcampos)
        Response.Redirect("~/Empleado.aspx", True)       
    End Sub



    'Protected Sub DtgRepresentante_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles DtgRepresentante.RowCreated
    '    Dim FECHA As Date

    '    If DataBinder.Eval(e.Row.DataItem, "DDREGI") IsNot Nothing Then
    '        If Date.TryParse(DataBinder.Eval(e.Row.DataItem, "DDREGI").ToString, FECHA) Then
    '            e.Row.Cells(1).Text = Format(FECHA, "dd/MM/yyyy")
    '        End If
    '    End If
    'End Sub

   
End Class
