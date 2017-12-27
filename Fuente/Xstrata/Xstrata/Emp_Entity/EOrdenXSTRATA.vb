Public Class EOrdenXSTRATA
    Private _PNCDCO As String = ""
    Private _PNCDNG As String = ""
    Private _PNCDZO As String = ""
    Private _PNDCPL As String = ""
    Private _PNNMOS As String = "" '
    Private _PNCDRG As String = ""
    Private _PNCDOP As String = ""
    Private _DCASCI As String = ""
    Private _DCTPOS As String = ""
    Private _DDREGI As String = "" '
    Private _DCREFE As String = ""
    Private _DCDSME As String = "" '
    Private _TCMPCL As String = ""
    Private _DCDSRG As String = "" '
    Private _DCDSOP As String = ""
    Private _PNDCTR As String = ""


    Private _DESPAC As String = ""
    Private _DCNMCL As String = ""
    Private _DCNAVE As String = ""
    Private _DDNAVE As String = ""
    Private _DDTDES As String = ""
    Private _DCDSAB As String = ""
    Private _DCCANA As String = ""
    Private _DCOBSE As String = ""
    Private _DDNUME As String = ""
    Private _DDPGDR As String = ""
    Private _DDSENA As String = ""
    Private _DDAFOR As String = ""
    Private _DDPRES As String = ""
    Private _DDLEVA As String = ""
    Private _DDRETI As String = ""

    Private _DOSENA As String = ""
    Private _DDINSP As String = ""
    Private _DCNMRM As String = ""
    Private _DDCREC As String = ""
    Private _DDTREC As String = ""

    Private _NRUC As String = ""
    Private _LIQUIDADOR As String = ""
    Private _DDANUM As String = ""
    Private _DDETLG As String = ""

    Private _DDOBVL As String = ""
    Private _DDAFPR As String = ""
    Private _DDOBDT As String = ""
    Private _DDRETI1 As String = ""
    Private _DCINDD As String = ""
    Private _VDDFINA As String = ""
    Private _DCOBSE1 As String = ""
    Private _FECHABL As String = ""
    Private _TCMPRO As String = ""
    Private _DCCTRL As String = ""
    Private _DCDUIDUE As String = ""
    Private _DDRDDC As String = ""
    Private _DDCRDP As String = ""
    Private _DDOEMB As String = ""
    Private _DNSBRE As String = ""

    Private _DNDSLB As String = ""

    Private _PCNMDC As String = ""
    Private _TZNFCC As String = ""
    Private _DCMOTI As String = ""


    Public Property PNCDCO() As String
        Get
            Return _PNCDCO.Trim
        End Get
        Set(ByVal value As String)
            _PNCDCO = value.Trim.ToUpper
        End Set
    End Property

    Public Property PNCDNG() As String
        Get
            Return _PNCDNG.Trim
        End Get
        Set(ByVal value As String)
            _PNCDNG = value.Trim.ToUpper
        End Set
    End Property

    Public Property PNCDZO() As String
        Get
            Return _PNCDZO.Trim
        End Get
        Set(ByVal value As String)
            _PNCDZO = value.Trim.ToUpper
        End Set
    End Property

    Public Property PNDCPL() As String
        Get
            Return _PNDCPL.Trim
        End Get
        Set(ByVal value As String)
            _PNDCPL = value.Trim.ToUpper
        End Set
    End Property

    Public Property PNNMOS() As String
        Get
            Return _PNNMOS.Trim
        End Get
        Set(ByVal value As String)
            _PNNMOS = value.Trim.ToUpper
        End Set
    End Property

    Public Property PNCDRG() As String
        Get
            Return _PNCDRG.Trim
        End Get
        Set(ByVal value As String)
            _PNCDRG = value.Trim.ToUpper
        End Set
    End Property

    Public Property PNCDOP() As String
        Get
            Return _PNCDOP.Trim
        End Get
        Set(ByVal value As String)
            _PNCDOP = value.Trim.ToUpper
        End Set
    End Property

    Public Property DCASCI() As String
        Get
            Return _DCASCI.Trim
        End Get
        Set(ByVal value As String)
            _DCASCI = value.Trim.ToUpper
        End Set
    End Property

    Public Property DCTPOS() As String
        Get
            Return _DCTPOS.Trim
        End Get
        Set(ByVal value As String)
            _DCTPOS = value.Trim.ToUpper
        End Set
    End Property

    Public Property DDREGI() As String
        Get
            Return _DDREGI.Trim
        End Get
        Set(ByVal value As String)
            _DDREGI = value.Trim.ToUpper
        End Set
    End Property

    Public Property DCREFE() As String
        Get
            Return _DCREFE.Trim
        End Get
        Set(ByVal value As String)
            _DCREFE = value.Trim.ToUpper
        End Set
    End Property

    Public Property DCDSME() As String
        Get
            Return _DCDSME.Trim
        End Get
        Set(ByVal value As String)
            _DCDSME = value.Trim.ToUpper
        End Set
    End Property

    Public Property TCMPCL() As String
        Get
            Return _TCMPCL.Trim
        End Get
        Set(ByVal value As String)
            _TCMPCL = value.Trim.ToUpper
        End Set
    End Property

    Public Property DCDSRG() As String
        Get
            Return _DCDSRG.Trim
        End Get
        Set(ByVal value As String)
            _DCDSRG = value.Trim.ToUpper
        End Set
    End Property
    Public Property DCDSOP() As String
        Get
            Return _DCDSOP.Trim
        End Get
        Set(ByVal value As String)
            _DCDSOP = value.Trim.ToUpper
        End Set
    End Property

    Public Property PNDCTR() As String
        Get
            Return _PNDCTR.Trim
        End Get
        Set(ByVal value As String)
            _PNDCTR = value.Trim.ToUpper
        End Set
    End Property

    Public Property DESPAC() As String
        Get
            Return _DESPAC.Trim
        End Get
        Set(ByVal value As String)
            _DESPAC = value.Trim.ToUpper
        End Set
    End Property

    Public Property DCNMCL() As String
        Get
            Return _DCNMCL.Trim
        End Get
        Set(ByVal value As String)
            _DCNMCL = value.Trim.ToUpper
        End Set
    End Property


    Public Property DCNAVE() As String
        Get
            Return _DCNAVE.Trim
        End Get
        Set(ByVal value As String)
            _DCNAVE = value.Trim.ToUpper
        End Set
    End Property
    Public Property DDNAVE() As String
        Get
            Return _DDNAVE.Trim
        End Get
        Set(ByVal value As String)
            If value = "" Then
                _DDNAVE = ""
            Else
                _DDNAVE = value.Trim.ToUpper
            End If
        End Set
    End Property

    Public Property DDTDES() As String
        Get
            Return _DDTDES.Trim
        End Get
        Set(ByVal value As String)
            If value = "" Then
                _DDTDES = ""
            Else
                _DDTDES = value.Trim.ToUpper
            End If
        End Set
    End Property

    Public Property DCDSAB() As String
        Get
            Return _DCDSAB.Trim
        End Get
        Set(ByVal value As String)
            _DCDSAB = value.Trim.ToUpper
        End Set
    End Property

    Public Property DCCANA() As String
        Get
            Return _DCCANA.Trim
        End Get
        Set(ByVal value As String)
            _DCCANA = value.Trim.ToUpper
        End Set
    End Property

    Public Property DCOBSE() As String
        Get
            Return _DCOBSE.Trim
        End Get
        Set(ByVal value As String)
            _DCOBSE = value.Trim.ToUpper
        End Set
    End Property

    Public Property DDNUME() As String
        Get
            Return _DDNUME.Trim
        End Get
        Set(ByVal value As String)
            If value = "" Then
                _DDNUME = ""
            Else
                _DDNUME = value.Trim.ToUpper
            End If
        End Set
    End Property

    Public Property DDPGDR() As String
        Get
            Return _DDPGDR.Trim
        End Get
        Set(ByVal value As String)
            If value = "" Then
                _DDPGDR = ""
            Else
                _DDPGDR = value.Trim.ToUpper
            End If
        End Set
    End Property

    Public Property DDSENA() As String
        Get
            Return _DDSENA.Trim
        End Get
        Set(ByVal value As String)
            _DDSENA = value.Trim.ToUpper
        End Set
    End Property

    Public Property DDAFOR() As String
        Get
            Return _DDAFOR.Trim
        End Get
        Set(ByVal value As String)
            If value = "" Then
                _DDAFOR = ""
            Else
                _DDAFOR = value.Trim.ToUpper
            End If
        End Set
    End Property

    Public Property DDPRES() As String
        Get
            Return _DDPRES.Trim
        End Get
        Set(ByVal value As String)
            If value = "" Then
                _DDPRES = ""
            Else
                _DDPRES = value.Trim.ToUpper
            End If
        End Set
    End Property

    Public Property DDLEVA() As String
        Get
            Return _DDLEVA.Trim
        End Get
        Set(ByVal value As String)
            If value = "" Then
                _DDLEVA = ""
            Else
                _DDLEVA = value.Trim.ToUpper
            End If
        End Set
    End Property

    Public Property DDRETI() As String
        Get
            Return _DDRETI.Trim
        End Get
        Set(ByVal value As String)
            If value = "" Then
                _DDRETI = ""
            Else
                _DDRETI = value.Trim.ToUpper
            End If
        End Set
    End Property

    Public Property DOSENA() As String
        Get
            Return _DOSENA.Trim
        End Get
        Set(ByVal value As String)
            _DOSENA = value.Trim.ToUpper
        End Set
    End Property

    Public Property DDINSP() As String
        Get
            Return _DDINSP.Trim
        End Get
        Set(ByVal value As String)
            _DDINSP = value.Trim.ToUpper
        End Set
    End Property

    Public Property DCNMRM() As String
        Get
            Return _DCNMRM.Trim
        End Get
        Set(ByVal value As String)
            _DCNMRM = value.Trim.ToUpper
        End Set
    End Property

    Public Property DDCREC() As String
        Get
            Return _DDCREC.Trim
        End Get
        Set(ByVal value As String)
            _DDCREC = value.Trim.ToUpper
        End Set
    End Property

    Public Property DDTREC() As String
        Get
            Return _DDTREC.Trim
        End Get
        Set(ByVal value As String)
            If value = "" Then
                _DDTREC = ""
            Else
                _DDTREC = value.Trim.ToUpper
            End If
        End Set
    End Property

    Public Property NRUC() As String
        Get
            Return _NRUC.Trim
        End Get
        Set(ByVal value As String)
            _NRUC = value.Trim.ToUpper
        End Set
    End Property

    Public Property LIQUIDADOR() As String
        Get
            Return _LIQUIDADOR.Trim
        End Get
        Set(ByVal value As String)
            _LIQUIDADOR = value.Trim.ToUpper
        End Set
    End Property

    Public Property DDANUM() As String
        Get
            Return _DDANUM.Trim
        End Get
        Set(ByVal value As String)
            If value = "" Then
                _DDANUM = ""
            Else
                _DDANUM = value.Trim.ToUpper
            End If
        End Set
    End Property

    Public Property DDETLG() As String
        Get
            Return _DDETLG.Trim
        End Get
        Set(ByVal value As String)
            If value = "" Then
                _DDETLG = ""
            Else
                _DDETLG = value.Trim.ToUpper
            End If

        End Set
    End Property

    Public Property DDOBVL() As String
        Get
            Return _DDOBVL.Trim
        End Get
        Set(ByVal value As String)
            If value = "" Then
                _DDOBVL = ""
            Else
                _DDOBVL = value.Trim.ToUpper
            End If
        End Set
    End Property

    Public Property DDAFPR() As String
        Get
            Return _DDAFPR.Trim
        End Get
        Set(ByVal value As String)
            If value = "" Then
                _DDAFPR = ""
            Else
                _DDAFPR = value.Trim.ToUpper
            End If
        End Set
    End Property
    Public Property DDOBDT() As String
        Get
            Return _DDOBDT.Trim
        End Get
        Set(ByVal value As String)
            _DDOBDT = value.Trim.ToUpper
        End Set
    End Property

    Public Property DDRETI1() As String
        Get
            Return _DDRETI1.Trim
        End Get
        Set(ByVal value As String)
            _DDRETI1 = value.Trim.ToUpper
        End Set
    End Property

    Public Property DCINDD() As String
        Get
            Return _DCINDD.Trim
        End Get
        Set(ByVal value As String)
            _DCINDD = value.Trim.ToUpper
        End Set
    End Property
    Public Property VDDFINA() As String
        Get
            Return _VDDFINA.Trim
        End Get
        Set(ByVal value As String)
            If value = "" Then
                _VDDFINA = ""
            Else
                _VDDFINA = value.Trim.ToUpper
            End If
        End Set
    End Property
    Public Property DCOBSE1() As String
        Get
            Return _DCOBSE1.Trim
        End Get
        Set(ByVal value As String)
            _DCOBSE1 = value.Trim.ToUpper
        End Set
    End Property

    Public Property FECHABL() As String
        Get
            Return _FECHABL.Trim
        End Get
        Set(ByVal value As String)
            _FECHABL = value.Trim.ToUpper
        End Set
    End Property

    Public Property TCMPRO() As String
        Get
            Return _TCMPRO.Trim
        End Get
        Set(ByVal value As String)
            _TCMPRO = value.Trim.ToUpper
        End Set
    End Property

    Public Property DCCTRL() As String
        Get
            Return _DCCTRL.Trim
        End Get
        Set(ByVal value As String)
            _DCCTRL = value.Trim.ToUpper
        End Set
    End Property

    Public Property DCDUIDUE() As String
        Get
            Return _DCDUIDUE.Trim
        End Get
        Set(ByVal value As String)
            _DCDUIDUE = value.Trim.ToUpper
        End Set
    End Property

    Public Property DDRDDC() As String
        Get
            Return _DDRDDC.Trim
        End Get
        Set(ByVal value As String)
            If value = "" Then
                _DDRDDC = ""
            Else
                _DDRDDC = value.Trim.ToUpper
            End If

        End Set
    End Property

    Public Property DDCRDP() As String
        Get
            Return _DDCRDP.Trim
        End Get
        Set(ByVal value As String)
            If value = "" Then
                _DDCRDP = ""
            Else
                _DDCRDP = value.Trim.ToUpper
            End If
        End Set
    End Property

    Public Property DDOEMB() As String
        Get
            Return _DDOEMB.Trim
        End Get
        Set(ByVal value As String)
            If value = "" Then
                _DDOEMB = ""
            Else
                _DDOEMB = value.Trim.ToUpper
            End If
        End Set
    End Property

    Public Property DNSBRE() As String
        Get
            Return _DNSBRE.Trim
        End Get
        Set(ByVal value As String)
            If value = "" Then
                _DNSBRE = ""
            Else
                _DNSBRE = value.Trim.ToUpper
            End If
        End Set
    End Property

    Public Property DNDSLB() As String
        Get
            Return _DNDSLB.Trim
        End Get
        Set(ByVal value As String)
            If value = "" Then
                _DNDSLB = ""
            Else
                _DNDSLB = value.Trim.ToUpper
            End If
        End Set
    End Property

    Public Property PCNMDC() As String
        Get
            Return _PCNMDC.Trim
        End Get
        Set(ByVal value As String)
            _PCNMDC = value.Trim.ToUpper
        End Set
    End Property
    Public Property TZNFCC() As String
        Get
            Return _TZNFCC.Trim
        End Get
        Set(ByVal value As String)
            _TZNFCC = value.Trim.ToUpper
        End Set
    End Property

    Public Property DCMOTI() As String
        Get
            Return _DCMOTI.Trim
        End Get
        Set(ByVal value As String)
            _DCMOTI = value.Trim.ToUpper
        End Set
    End Property
End Class

