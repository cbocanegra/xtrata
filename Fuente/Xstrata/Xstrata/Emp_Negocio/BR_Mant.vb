Imports System
Imports System.Data
Imports BE = Emp_Entity
Imports DAT = Emp_Datos


Public Class BR_Mant
    Public Shared Function GetTable(ByVal Tabla As String, Optional ByVal Param As String = "") As DataTable
        GetTable = DAT.DA_Mant.GetTable(Tabla, Param)
    End Function

    Public Shared Function LlenaComboCliente(ByVal Cpnia As String, ByVal Serv As String, ByVal Texto As String) As DataTable
        LlenaComboCliente = DAT.DA_Mant.LlenaComboCliente(Cpnia, Serv, Texto)
    End Function

End Class
