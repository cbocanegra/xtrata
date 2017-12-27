Public Class EZonas

    Private _CODZONA As String = ""
    Private _ZONA As String = ""

    Public Property CODZONA() As String
        Get
            Return _CODZONA.Trim
        End Get
        Set(ByVal value As String)
            _CODZONA = value.Trim.ToUpper
        End Set
    End Property

    Public Property ZONA() As String
        Get
            Return _ZONA.Trim
        End Get
        Set(ByVal value As String)
            _ZONA = value.Trim.ToUpper
        End Set
    End Property

End Class
