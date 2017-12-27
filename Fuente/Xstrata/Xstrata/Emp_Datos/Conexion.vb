Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class Conexion
    Public Shared Function GetConnection() As SqlConnection
        'Dim ConnectionString As String = ConfigurationManager.AppSettings("DataBase").ToString
        ''My.Settings.Acceso()
        Dim ConnectionString As String = "Data Source=.;Initial Catalog=MarketPERU;uid=sa;pwd=sa"
        Dim Conectado As New SqlConnection(ConnectionString)
        Conectado.Open()
        Return Conectado

    End Function
End Class
