Public Class EClientes
    Private _CODCLIENTE As Integer
    Private _NOMBRECLIENTE As String

    Public Property CODCLIENTE() As Integer
        Get
            Return _CODCLIENTE
        End Get
        Set(ByVal value As Integer)
            _CODCLIENTE = value
        End Set
    End Property

    Public Property NOMBRECLIENTE() As String
        Get
            Return _NOMBRECLIENTE.Trim
        End Get
        Set(ByVal value As String)
            _NOMBRECLIENTE = value.Trim.ToUpper
        End Set
    End Property

End Class
