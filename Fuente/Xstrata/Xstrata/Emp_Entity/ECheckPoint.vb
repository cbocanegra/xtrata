Public Class ECheckPoint
    Private _CODIGO As String = ""
    Private _DESCRIPCION As String = ""
    Private _FECHA As String = ""


    Public Property CODIGO() As String
        Get
            Return _CODIGO.Trim
        End Get
        Set(ByVal value As String)
            If value = "" Then
                _CODIGO = ""
            Else
                _CODIGO = value.Trim.ToUpper
            End If
        End Set
    End Property

    Public Property DESCRIPCION() As String
        Get
            Return _DESCRIPCION.Trim
        End Get
        Set(ByVal value As String)
            If value = "" Then
                _DESCRIPCION = ""
            Else
                _DESCRIPCION = value.Trim.ToUpper
            End If
        End Set
    End Property

    Public Property FECHA() As String
        Get
            Return _FECHA.Trim
        End Get
        Set(ByVal value As String)
            If value = "" Then
                _FECHA = ""
            Else
                _FECHA = value.Trim.ToUpper
            End If
        End Set
    End Property
End Class
