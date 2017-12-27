Imports System.Data
Imports IBM.Data.DB2.iSeries
Imports System.Configuration

Public Class ConexionDB2
    Public Shared Function GetConnection() As iDB2Connection

        ' Obtiene la cadena de conexion desde el archivo de configuracion
        ' CONECTANDOME POR EL WEBCONFIG
        'Dim connectionString As String = ConfigurationManager.ConnectionStrings("Agencia").ConnectionString
        Dim ConnectionString As String = "DataSource=RANSA; UserID=APPNETWARR;Password=TWR92RAR; DataCompression=True; DefaultCollection=DC@RNSLIB; Pooling=true "
        ' Creando un nuevo objeto Conexion
        Dim connection As New iDB2Connection(connectionString)
        ' Abre la conneccion, and retorna este
        connection.Open()
        Return connection

    End Function



    Public Shared Function Open(ByVal Cpnia As String, ByVal Srv As String) As iDB2Connection
        Dim ConnectionString As String = ""

        If Cpnia = "" And Srv = "" Then Cpnia = "LZ"

        If Srv = "RANSA01" Then
            ConnectionString = "DataSource=RANSA01; UserID=appdb2;Password=appdb2; DataCompression=True; DefaultCollection=DC@DESLIB; Pooling=true "
        Else
            Select Case Cpnia
                Case "LZ"
                    ConnectionString = "DataSource=RANSA; UserID=APPNETWARR;Password=TWR92RAR; DataCompression=True; DefaultCollection=DC@RNSLIB; Pooling=true "
                Case "AM"
                    ConnectionString = "DataSource=RANSA; UserID=APPNETWARR;Password=TWR92RAR; DataCompression=True; DefaultCollection=DC@ALMAPER; Pooling=true "
                Case "FZ"
                    ConnectionString = "DataSource=RANSA; UserID=APPNETWARR;Password=TWR92RAR; DataCompression=True; DefaultCollection=DC@RNSLIB; Pooling=true "
                Case "CM"
                    ConnectionString = "DataSource=RANSA; UserID=APPNETWARR;Password=TWR92RAR; DataCompression=True; DefaultCollection=DC@MODULOS; Pooling=true "
            End Select
        End If

        Dim connection As New iDB2Connection(ConnectionString)
        connection.Open()
        Return connection
    End Function


    Public Shared Function Open_Descasa(ByVal Cpnia As String, ByVal Srv As String) As iDB2Connection
        Dim ConnectionString As String = ""
        If Cpnia = "" And Srv = "" Then
            Cpnia = "LZ"
        End If
        If Srv = "RANSA01" Then
            ConnectionString = "DataSource=RANSA01; UserID=appdb2;Password=appdb2; DataCompression=True; DefaultCollection=DC@DESLIB; Pooling=true "
        Else
            ConnectionString = "DataSource=RANSA; UserID=APPNETWARR;Password=TWR92RAR; DataCompression=True; DefaultCollection=DESCASA; Pooling=true "
        End If

        Dim connection As New iDB2Connection(ConnectionString)
        connection.Open()
        Return connection
    End Function

    Public Shared Function Close(ByRef connection As iDB2Connection) As String
        connection.Close()
        Return "0"
    End Function

End Class
