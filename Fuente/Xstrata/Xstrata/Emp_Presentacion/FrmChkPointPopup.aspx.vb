Imports Entidad = Emp_Entity
Imports Datos = Emp_Datos
Imports Emp_Negocio


Partial Class FrmChkPointPopup
    Inherits System.Web.UI.Page

    Dim ValorCodigo As String = ""
    Dim ValorDecripcion As String = ""
    Dim ValorFecha As String = ""
    Dim DatoSessionPNCDTR As String = ""
    Dim DatosSesionPNNMOS As String = ""
    Dim DatosSesionPNCDZO As String = ""
    Dim fecha As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ValorCodigo = Request.QueryString("VCodigo").ToString.Trim
            Session.Add("SesionVcodigo", ValorCodigo)
            ValorDecripcion = Request.QueryString("VDescripcion").ToString.Trim
            ValorFecha = Request.QueryString("DFecha").ToString.Trim
            DatoSessionPNCDTR = Session.Item("DatosPNDCTR").ToString.Trim
            DatosSesionPNNMOS = Session.Item("DatosPNNMOS").ToString.Trim
            DatosSesionPNCDZO = Session.Item("DatosPNCDZO").ToString.Trim

            lblOrdenServicio.Text = ValorCodigo
            txtCodigo.Text = ValorCodigo
            txtDescripcion.Text = ValorDecripcion
            txtFecha.Text = ValorFecha
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

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim Negocio As New NOrdenXTRATA
        Dim fecha, codigo, cadena As String
        Dim i As Integer

        If Session.Item("DatosPNDCTR").ToString.Trim <> "" Then
            If Session.Item("SesionVcodigo").ToString.Trim = "108" Or Session.Item("SesionVcodigo").ToString.Trim = "109" Or Session.Item("SesionVcodigo").ToString.Trim = "107" Or Session.Item("SesionVcodigo").ToString.Trim = "152" Then
                fecha = FormatoFecha(txtFecha.Text.ToString.Trim)
            ElseIf Session.Item("SesionVcodigo").ToString.Trim = "116" Or Session.Item("SesionVcodigo").ToString.Trim = "117" Or Session.Item("SesionVcodigo").ToString.Trim = "121" Or Session.Item("SesionVcodigo").ToString.Trim = "122" Or Session.Item("SesionVcodigo").ToString.Trim = "123" Or Session.Item("SesionVcodigo").ToString.Trim = "124" Or Session.Item("SesionVcodigo").ToString.Trim = "150" Or Session.Item("SesionVcodigo").ToString.Trim = "151" Then
                fecha = FormatoFecha(txtFecha.Text.ToString.Trim) & " " & FormatoHora(horaactual, txtFecha.Text.ToString.Trim)
            End If
        End If

        cadena = Negocio.CheckPoint_Update(Session.Item("DatosPNNMOS").ToString.Trim, Session.Item("DatosPNCDZO").ToString.Trim, Session.Item("DatosPNDCTR").ToString.Trim, txtCodigo.Text, fecha)
        'cadena = "OK"
        If cadena <> "OK" Then
            'MessageBox.Show(cadena & "CheckPoint " & codigo, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Label1.Visible = True
            Me.Label1.Text = cadena & "CheckPoint" & ValorCodigo
            Exit Sub

        Else
            Me.Label1.Visible = True
            Me.Label1.Text = "Se actualizo correctamente..!!!"
        End If
       
    End Sub
End Class
