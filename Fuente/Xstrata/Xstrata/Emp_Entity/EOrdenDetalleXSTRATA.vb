Public Class EOrdenDetalleXSTRATA

    Private _NSERIE As String = ""
    Private _NMRODC As String = ""
    Private _NMITOC As String = ""
    Private _VALADV As String = ""
    Private _VALIGV As String = ""
    Private _VALIPM As String = ""
    Private _VALRNP As String = ""
    Private _VALGAS As String = ""
    Private _VALTRA As String = ""
    Private _VALCOM As String = ""



    Public Property NSERIE() As String
        Get
            Return _NSERIE.Trim
        End Get
        Set(ByVal value As String)
            If value = "" Then
                _NSERIE = ""
            Else
                _NSERIE = value.Trim.ToUpper
            End If
        End Set
    End Property

    Public Property NMRODC() As String
        Get
            Return _NMRODC.Trim
        End Get
        Set(ByVal value As String)
            If value = "" Then
                _NMRODC = ""
            Else
                _NMRODC = value.Trim.ToUpper
            End If
        End Set
    End Property

    Public Property NMITOC() As String
        Get
            Return _NMITOC.Trim
        End Get
        Set(ByVal value As String)
            If value = "" Then
                _NMITOC = ""
            Else
                _NMITOC = value.Trim.ToUpper
            End If
        End Set
    End Property

    Public Property VALADV() As String
        Get
            Return _VALADV.Trim
        End Get
        Set(ByVal value As String)
            If value = "" Then
                _VALADV = ""
            Else
                _VALADV = value.Trim.ToUpper
            End If
        End Set
    End Property

    Public Property VALIGV() As String
        Get
            Return _VALIGV.Trim
        End Get
        Set(ByVal value As String)
            If value = "" Then
                _VALIGV = ""
            Else
                _VALIGV = value.Trim.ToUpper
            End If
        End Set
    End Property

    Public Property VALIPM() As String
        Get
            Return _VALIPM.Trim
        End Get
        Set(ByVal value As String)
            If value = "" Then
                _VALIPM = ""
            Else
                _VALIPM = value.Trim.ToUpper
            End If
        End Set
    End Property


    Public Property VALRNP() As String
        Get
            Return _VALRNP.Trim
        End Get
        Set(ByVal value As String)
            If value = "" Then
                _VALRNP = ""
            Else
                _VALRNP = value.Trim.ToUpper
            End If
        End Set
    End Property

    Public Property VALGAS() As String
        Get
            Return _VALGAS.Trim
        End Get
        Set(ByVal value As String)
            If value = "" Then
                _VALGAS = ""
            Else
                _VALGAS = value.Trim.ToUpper
            End If
        End Set
    End Property

    Public Property VALTRA() As String
        Get
            Return _VALTRA.Trim
        End Get
        Set(ByVal value As String)
            If value = "" Then
                _VALTRA = ""
            Else
                _VALTRA = value.Trim.ToUpper
            End If
        End Set
    End Property

    Public Property VALCOM() As String
        Get
            Return _VALCOM.Trim
        End Get
        Set(ByVal value As String)
            If value = "" Then
                _VALCOM = ""
            Else
                _VALCOM = value.Trim.ToUpper
            End If
        End Set
    End Property
End Class
