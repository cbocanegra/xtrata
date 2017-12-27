Imports System
Imports System.Data
Imports BE = Empleado.Entidad
Imports BD = Emp_Datos
Public Class SEmpleado
    Public Shared Function FillEmp() As List(Of BE.Empleado)
        Dim Lisquery As List(Of BE.Empleado) = New List(Of BE.Empleado)
        Lisquery = BD.DEmpleado.FillEmpleado()
        Return Lisquery
    End Function

    Public Shared Function FillEmpCat() As List(Of BE.Empleado)
        Dim Lisquery As List(Of BE.Empleado) = New List(Of BE.Empleado)
        Lisquery = BD.DEmpleado.FillEmpleadoCat()
        Return Lisquery
    End Function

End Class
