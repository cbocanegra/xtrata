Public Class EConsultaCosto
    Private _CCODCOS As String = ""
    Private _CDESCOS As String = ""
    Private _NVALORI As String = ""

    Public Property NVALORI() As String
        Get
            Return _NVALORI.Trim
        End Get
        Set(ByVal value As String)
            _NVALORI = value.Trim.ToUpper
        End Set
    End Property

    Public Property CCODCOS() As String
        Get
            Return _CCODCOS.Trim
        End Get
        Set(ByVal value As String)
            _CCODCOS = value.Trim.ToUpper
        End Set
    End Property

    Public Property CDESCOS() As String
        Get
            Return _CDESCOS.Trim
        End Get
        Set(ByVal value As String)
            _CDESCOS = value.Trim.ToUpper
        End Set
    End Property
End Class
