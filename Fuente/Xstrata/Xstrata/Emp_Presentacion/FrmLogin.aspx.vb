Imports WsIngreso
Imports System.Xml
Imports System.Xml.Xsl
Imports System.Data
Imports System.IO
Imports BE = Emp_Entidad
Imports Librerias
Imports NEG = Emp_Negocio
Imports Dat = Emp_Datos

Partial Class FrmLogin
    Inherits System.Web.UI.Page

    Dim Cpnia, Div, Planta, Libreria, FlgAccion, Codigocliente As String
    Dim slistaAccesos As List(Of BE.E_ValidarAcceso)
    Dim strmensaje As String
    Dim Semaforo As String
    Dim CodZona As String = ""

    Protected Sub LoginButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginButton.Click
        Dim valida As New WsIngreso.wsIngreso
        Dim Ingreso As New BE.E_Ingreso
        Dim EncriptClave As String = ""
        Dim Result As String = ""
        'Dim PRUEBA As String = ""


        ''VALIDAR EN EL BOTN ACEPTAR QUE EL COMO ESTE CARGADO SI NO MANDAR MENSAJE QUE NO EXSITE ZONA Y NO DEJARLO ENTRAR


        If CbZona.Items.Count = 0 Then
            ' XtraMessageBox.Show("El usuario no tiene zona asignada...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Label1.Visible = True
            Label1.Text = "El usuario no tiene zona asignada...!!!"
            'Me.Cursor = Cursors.Arrow
            UserName.Focus()
            Exit Sub
        End If


        If UserName.Text = "" Then
            UserNameLabel.Visible = True
            Exit Sub
        ElseIf Password.Text = "" Then
            PasswordLabel.Visible = True
            Exit Sub
        End If


        Session.Remove("ValCpnia")
        Session.Remove("ValDiv")
        Session.Remove("ValPlanta")
        Session.Remove("ValLibreria")
        Session.Remove("ValFlgAccion")
        Session.Remove("ValUsuario")
        Session.Remove("ValClave")


        Ingreso.Usuario = UserName.Text.ToString.Trim
        Ingreso.Contrasena = Password.Text.ToString.Trim
        EncriptClave = Encriptar(Password.Text.ToString.Trim)

        Try
            'Result = valida.ValidarAccesos(UserName.Text.ToString.Trim.ToUpper, EncriptClave, 2)
            'Dim dst As New DataSet
            'Dim objReader As New StringReader(Result)
            'dst.ReadXml(objReader)
            'Cpnia = dst.Tables(0).Rows(0).Item("Compania")
            'Div = dst.Tables(0).Rows(0).Item("Division")
            'Planta = dst.Tables(0).Rows(0).Item("Planta")
            'Libreria = dst.Tables(0).Rows(0).Item("Libreria")
            'FlgAccion = dst.Tables(0).Rows(0).Item("FlagProc")
            'Codigocliente = dst.Tables(0).Rows(0).Item("CodCliente")


            slistaAccesos = NEG.NXstrata._ValidaDatosAccesos(UserName.Text.ToString.Trim.ToUpper, EncriptClave, 2)

            If slistaAccesos.Count > 0 Then
                Cpnia = slistaAccesos.Item(0).CCMPN
                Div = slistaAccesos.Item(0).CDVSN
                Planta = slistaAccesos.Item(0).CPLNDV
                Libreria = slistaAccesos.Item(0).CLBRCM
                FlgAccion = slistaAccesos.Item(0).STADO
                Codigocliente = slistaAccesos.Item(0).CCLNT
            End If


            If FlgAccion = "1" Then
                'cargamos variables de sesion
                Session.Add("ValCpnia", Cpnia)
                Session.Add("ValDiv", Div)
                Session.Add("ValPlanta", Planta)
                Session.Add("ValLibreria", Libreria)
                Session.Add("ValFlgAccion", FlgAccion)
                Session.Add("ValUsuario", Ingreso.Usuario.ToUpper())
                Session.Add("ValClave", Ingreso.Contrasena())
                Session.Add("ValCodigoCli", Codigocliente)

                FormsAuthentication.RedirectFromLoginPage(Ingreso.Usuario.ToUpper, False)
            Else
                Limpiar()
                Label1.Visible = True
                Label1.Text = "Conexion Errada"
                Exit Sub
            End If
        Catch ex As Exception
            Result = ex.Message
        End Try

    End Sub

    Sub Limpiar()
        'My.Settings.Usuario = ""
        'My.Settings.Acceso = ""
        'My.Settings.Descripcion = ""
        'My.Settings.Compania = ""
        'My.Settings.Sociedad = ""
        'My.Settings.TipoUsuario = ""
        'My.Settings.EMAdmin = ""
        'My.Settings.Contrasena = ""
        'My.Settings.Libreria = ""

        Session.Remove("Usuario")
        Session.Remove("Pasword")
        Session.Remove("Sociedad")
        Session.Remove("Usuario")
        Session.Remove("Descripcion")
        Session.Remove("Compania")
        Session.Remove("TipoUsuario")
        Session.Remove("Conexion")

        UserName.Text = vbNullString
        Password.Text = vbNullString
        UserName.Focus()
        'KtxtPassword.Focus()
    End Sub

   
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ValUsuario As String = ""

        If Not Page.IsPostBack Then
            UserName.Attributes.Add("onblur", "setTimeout('__doPostBack(\'Label1\',\'\')', 0);")
            MostrarDeshabilitarControles()
            Me.CbZona.Visible = False
            Me.lblZona.Visible = False
        Else
            If Not String.IsNullOrEmpty(UserName.Text) Then

                ValUsuario = Dat.DOrdenServ.ValidarTipoUsuarios(UserName.Text.Trim)

                If ValUsuario.Length >= 2 Then
                    If ValUsuario.Substring(0, 2) = "FZ" Then
                        CbZona.Items.Clear()
                        CargarZona(UserName.Text.Trim)

                        If Dat.DOrdenServ.Usuario_Numeros_Zona(UserName.Text.Trim) = 1 Then
                            Label1.Visible = False
                            MostrarDeshabilitarControles()
                        Else
                            MostrarControles()
                        End If

                        Semaforo = 1
                    Else
                        If ValUsuario.Substring(3, 1) = "S" Then
                            CargarZona(UserName.Text.Trim)
                        End If
                        Semaforo = 0
                    End If
                End If

                Password.Focus()
                ' Me.Label1.Visible = True
                '  Me.Label1.Text = "Hice LostFocus"
            End If
            End If
    End Sub


    Public Sub CargarZona(ByVal Usuario As String)
        'zonas = 
        If CbZona.Items.Count = 0 Then
            With Me.CbZona
                .DataTextField = "ZONA"
                .DataValueField = "CODZONA"
                .DataSource = Dat.DOrdenServ.Zona(Usuario)
                .DataBind()
                CodZona = CbZona.SelectedValue
                Session.Add("SesionCodZona", CodZona)
                ' .SelectedIndex = -1
            End With
        End If
    End Sub

    Public Sub MostrarDeshabilitarControles()
        Me.lblZona.Visible = True
        Me.CbZona.Visible = True
        Me.CbZona.Enabled = False
        'Me.CbZona.Width = False
    End Sub

    Public Sub MostrarControles()
        Me.lblZona.Visible = True
        Me.CbZona.Visible = True
    End Sub
End Class
