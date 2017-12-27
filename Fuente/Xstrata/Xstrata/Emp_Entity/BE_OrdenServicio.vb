Public Class BE_OrdenServicio
    Private mPNNMOS As String = ""
    Private mPCNMDC As String = ""
    Private mPNCDTR As String = ""
    Private mTCMPCL As String = ""
    Private mDCDSME As String = ""
    Private mTAMANO As String = ""
    Private mDCNAVE As String = ""
    Private mDDNAVE As String = ""
    Private mDCDUIDUE As String = ""
    Private mDCDICT As String = ""
    Private mDDDESP As String = ""
    Private mCODALMA As String = ""
    Private mDVENC As String = ""
    Private mDCNMBK As String = ""
    Private mDINGME As String = ""
    Private mDCAGNV As String = ""
    Private mDDCANA As String = ""
    Private mDNCANA As String = ""
    Private mDCOBSE As String = ""
    Private mDDSALN As String = ""
    Private mDDVNRE As String = ""
    Private mDDENBL As String = ""
    Private mDLUGME As String = ""
    Private mSESTRG As String = ""
    Private mDDIF As Integer = 0
    Private mRAT As String = ""
    Private mDUA As String = ""
    Private mDDREGI As String = ""
    Private mDCREFE As String = ""
    Private mDCTPOS As String = ""

    Private mPNCDRG As String = ""
    Private mFNCDAD As String = ""
    Private mFNCDPR As String = ""
    Private mDCASCI As String = ""
    Private mPNCDOP As String = ""
    Private mDCPREC As String = ""
    Private mDCVIGE As String = ""
    Private mDDVNDE As String = ""
    Private mDNCAM As String = ""

    Private mDNTRAN As String = ""
    Private mDCCONT As String = ""
    Private mDNFPAG As String = ""
    Private mDNTPCA As String = ""
    Private mSENVAS As String = ""

    Public Property PNNMOS() As String
        Get
            Return mPNNMOS
        End Get
        Set(ByVal value As String)
            If mPNNMOS = value Then
                Return
            End If
            mPNNMOS = value
        End Set
    End Property

    Public Property PNCDTR() As String
        Get
            Return mPNCDTR
        End Get
        Set(ByVal value As String)
            If mPNCDTR = value Then
                Return
            End If
            mPNCDTR = value
        End Set
    End Property

    Public Property PCNMDC() As String
        Get
            Return mPCNMDC
        End Get
        Set(ByVal value As String)
            If mPCNMDC = value Then
                Return
            End If
            mPCNMDC = value
        End Set
    End Property

    Public Property RAT() As String
        Get
            Return mRAT
        End Get
        Set(ByVal value As String)
            If mRAT = value Then
                Return
            End If
            mRAT = value
        End Set
    End Property

    Public Property TCMPCL() As String
        Get
            Return mTCMPCL
        End Get
        Set(ByVal value As String)
            If mTCMPCL = value Then
                Return
            End If
            mTCMPCL = value
        End Set
    End Property
    Public Property DCDSME() As String
        Get
            Return mDCDSME
        End Get
        Set(ByVal value As String)
            If mDCDSME = value Then
                Return
            End If
            mDCDSME = value
        End Set
    End Property
    Public Property TAMANO() As String
        Get
            Return mTAMANO
        End Get
        Set(ByVal value As String)
            If mTAMANO = value Then
                Return
            End If
            mTAMANO = value
        End Set
    End Property
    Public Property DCNAVE() As String
        Get
            Return mDCNAVE
        End Get
        Set(ByVal value As String)
            If mDCNAVE = value Then
                Return
            End If
            mDCNAVE = value
        End Set
    End Property
    Public Property DDNAVE() As String
        Get
            Return mDDNAVE
        End Get
        Set(ByVal value As String)
            If mDDNAVE = value Then
                Return
            End If
            mDDNAVE = value
        End Set
    End Property
    Public Property DCDUIDUE() As String
        Get
            Return mDCDUIDUE
        End Get
        Set(ByVal value As String)
            If mDCDUIDUE = value Then
                Return
            End If
            mDCDUIDUE = value
        End Set
    End Property

    Public Property DCDICT() As String
        Get
            Return mDCDICT
        End Get
        Set(ByVal value As String)
            If mDCDICT = value Then
                Return
            End If
            mDCDICT = value
        End Set
    End Property

    Public Property DDDESP() As String
        Get
            Return mDDDESP
        End Get
        Set(ByVal value As String)
            If mDDDESP = value Then
                Return
            End If
            mDDDESP = value
        End Set
    End Property
    Public Property CODALMA() As String
        Get
            Return mCODALMA
        End Get
        Set(ByVal value As String)
            If mCODALMA = value Then
                Return
            End If
            mCODALMA = value
        End Set
    End Property

    Public Property DVENC() As String
        Get
            Return mDVENC
        End Get
        Set(ByVal value As String)
            If mDVENC = value Then
                Return
            End If
            mDVENC = value
        End Set
    End Property

    Public Property DCNMBK() As String
        Get
            Return mDCNMBK
        End Get
        Set(ByVal value As String)
            If mDCNMBK = value Then
                Return
            End If
            mDCNMBK = value
        End Set
    End Property
    Public Property DINGME() As String
        Get
            Return mDINGME
        End Get
        Set(ByVal value As String)
            If mDINGME = value Then
                Return
            End If
            mDINGME = value
        End Set
    End Property
    Public Property DCAGNV() As String
        Get
            Return mDCAGNV
        End Get
        Set(ByVal value As String)
            If mDCAGNV = value Then
                Return
            End If
            mDCAGNV = value
        End Set
    End Property
    Public Property DDCANA() As String
        Get
            Return mDDCANA
        End Get
        Set(ByVal value As String)
            If mDDCANA = value Then
                Return
            End If
            mDDCANA = value
        End Set
    End Property

    Public Property DNCANA() As String
        Get
            Return mDNCANA
        End Get
        Set(ByVal value As String)
            If mDNCANA = value Then
                Return
            End If
            mDNCANA = value
        End Set
    End Property

    Public Property DCOBSE() As String
        Get
            Return mDCOBSE
        End Get
        Set(ByVal value As String)
            If mDCOBSE = value Then
                Return
            End If
            mDCOBSE = value
        End Set
    End Property

    Public Property DDSALN() As String
        Get
            Return mDDSALN
        End Get
        Set(ByVal value As String)
            If mDDSALN = value Then
                Return
            End If
            mDDSALN = value
        End Set
    End Property
    Public Property DDVNRE() As String
        Get
            Return mDDVNRE
        End Get
        Set(ByVal value As String)
            If mDDVNRE = value Then
                Return
            End If
            mDDVNRE = value
        End Set
    End Property

    Public Property DDENBL() As String
        Get
            Return mDDENBL
        End Get
        Set(ByVal value As String)
            If mDDENBL = value Then
                Return
            End If
            mDDENBL = value
        End Set
    End Property

    Public Property DLUGME() As String
        Get
            Return mDLUGME
        End Get
        Set(ByVal value As String)
            If mDLUGME = value Then
                Return
            End If
            mDLUGME = value
        End Set
    End Property

    Public Property DDIF() As Integer
        Get
            Return mDDIF
        End Get
        Set(ByVal value As Integer)
            If mDDIF = value Then
                Return
            End If
            mDDIF = value
        End Set
    End Property

    Public Property SESTRG() As String
        Get
            Return mSESTRG
        End Get
        Set(ByVal value As String)
            If mSESTRG = value Then
                Return
            End If
            mSESTRG = value
        End Set
    End Property

    Public Property DUA() As String
        Get
            Return mDUA
        End Get
        Set(ByVal value As String)
            If mDUA = value Then
                Return
            End If
            mDUA = value
        End Set
    End Property

    Public Property DDREGI() As String
        Get
            Return mDDREGI
        End Get
        Set(ByVal value As String)
            If mDDREGI = value Then
                Return
            End If
            mDDREGI = value
        End Set
    End Property
    Public Property DCREFE() As String
        Get
            Return mDCREFE
        End Get
        Set(ByVal value As String)
            If mDCREFE = value Then
                Return
            End If
            mDCREFE = value
        End Set
    End Property
    Public Property DCTPOS() As String
        Get
            Return mDCTPOS
        End Get
        Set(ByVal value As String)
            If mDCTPOS = value Then
                Return
            End If
            mDCTPOS = value
        End Set
    End Property
    Public Property PNCDRG() As String
        Get
            Return mPNCDRG
        End Get
        Set(ByVal value As String)
            If mPNCDRG = value Then
                Return
            End If
            mPNCDRG = value
        End Set
    End Property

    Public Property FNCDAD() As String
        Get
            Return mFNCDAD
        End Get
        Set(ByVal value As String)
            If mFNCDAD = value Then
                Return
            End If
            mFNCDAD = value
        End Set
    End Property

    Public Property FNCDPR() As String
        Get
            Return mFNCDPR
        End Get
        Set(ByVal value As String)
            If mFNCDPR = value Then
                Return
            End If
            mFNCDPR = value
        End Set
    End Property
    Public Property DCASCI() As String
        Get
            Return mDCASCI
        End Get
        Set(ByVal value As String)
            If mDCASCI = value Then
                Return
            End If
            mDCASCI = value
        End Set
    End Property
    Public Property PNCDOP() As String
        Get
            Return mPNCDOP
        End Get
        Set(ByVal value As String)
            If mPNCDOP = value Then
                Return
            End If
            mPNCDOP = value
        End Set
    End Property
    Public Property DCPREC() As String
        Get
            Return mDCPREC
        End Get
        Set(ByVal value As String)
            If mDCPREC = value Then
                Return
            End If
            mDCPREC = value
        End Set
    End Property
    Public Property DCVIGE() As String
        Get
            Return mDCVIGE
        End Get
        Set(ByVal value As String)
            If mDCVIGE = value Then
                Return
            End If
            mDCVIGE = value
        End Set
    End Property

    Public Property DDVNDE() As String
        Get
            Return mDDVNDE
        End Get
        Set(ByVal value As String)
            If mDDVNDE = value Then
                Return
            End If
            mDDVNDE = value
        End Set
    End Property

    Public Property DNCAM() As String
        Get
            Return mDNCAM
        End Get
        Set(ByVal value As String)
            If mDNCAM = value Then
                Return
            End If
            mDNCAM = value
        End Set
    End Property

    Public Property DNTRAN() As String
        Get
            Return mDNTRAN
        End Get
        Set(ByVal value As String)
            If mDNTRAN = value Then
                Return
            End If
            mDNTRAN = value
        End Set
    End Property
    Public Property DCCONT() As String
        Get
            Return mDCCONT
        End Get
        Set(ByVal value As String)
            If mDCCONT = value Then
                Return
            End If
            mDCCONT = value
        End Set
    End Property

    Public Property DNFPAG() As String
        Get
            Return mDNFPAG
        End Get
        Set(ByVal value As String)
            If mDNFPAG = value Then
                Return
            End If
            mDNFPAG = value
        End Set
    End Property

    Public Property DNTPCA() As String
        Get
            Return mDNTPCA
        End Get
        Set(ByVal value As String)
            If mDNTPCA = value Then
                Return
            End If
            mDNTPCA = value
        End Set
    End Property

    Public Property SENVAS() As String
        Get
            Return mSENVAS
        End Get
        Set(ByVal value As String)
            If mSENVAS = value Then
                Return
            End If
            mSENVAS = value
        End Set
    End Property
End Class
