Imports Microsoft.VisualBasic
Imports System.Web
Public Class Librerias


    Public Shared Function Encriptar(ByVal password As String) As String
        Dim provider As New System.Security.Cryptography.SHA1CryptoServiceProvider
        Dim bytes As Byte() = System.Text.Encoding.UTF8.GetBytes(password)
        Dim inArray As Byte() = provider.ComputeHash(bytes)
        provider.Clear()
        Return Convert.ToBase64String(inArray)

        'Dim provider As New Security.Cryptography.SHA1CryptoServiceProvider
        'Dim bytes As Byte() = System.Text.Encoding.UTF8.GetBytes(password)
        'Dim inArray As Byte() = provider.ComputeHash(bytes)
        'provider.Clear()
        'Return Convert.ToBase64String(inArray)

    End Function


    'Public Shared Function Qransa() As Boolean
    '    Dim LoadRuta As New Qransa.QRansa
    '    Dim Success As Boolean
    '    Success = LoadRuta.MapDrive("I", "\\QRANSA\RANSAWEB\AFI")
    '    Return Success
    'End Function
End Class
