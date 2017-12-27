Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Text
Imports System.Data.Common
Imports BE = Emp_Entidad
Imports IBM.Data.DB2.iSeries

Public Class DAduanas
    Public Shared Function FillCabeceraAduana(ByVal Oserv As String) As List(Of BE.DUAA)

        'Dim Sql As String
        'Sql = " SELECT A.TPSRVA,RTRIM(B.TCMTSR)AS TCMTSR,A.NORDSR,RTRIM(A.REFRNC)AS REFRNC,A.VALMRC,A.VALFLT," & _
        '        "A.VALSEG, A.IMPCIF, A.VALADV, A.VALSBT, A.VALIGV, " & _
        '        " A.VALIPM, A.FFACTU, A.FACTUR FROM DUAA A " & _
        '        " LEFT OUTER JOIN RZZK65 B ON A.TPSRVA=B.TPSRVA AND A.CCMPN=B.CCMPN " & _
        '        " ORDER BY A.NORDSR DESC "

        Dim NomSp As String = ""
        NomSp = "DESCASA.AGENCIAS_SP_CABECERA_DUAA"
        Dim Lisquery As List(Of BE.DUAA) = New List(Of BE.DUAA)
        Dim cmd As iDB2DataReader


        Using cn As iDB2Connection = ConexionDB2.GetConnection()
            Using command As New iDB2Command(NomSp, cn)
                command.CommandType = CommandType.StoredProcedure '--CInt(op.Substring(3))                
                command.Parameters.Add("IN_OS", iDB2DbType.iDB2VarChar, 15).Value = Oserv
                cmd = command.ExecuteReader
                While (cmd.Read())
                    Dim CabAduana As BE.DUAA = New BE.DUAA()
                    CabAduana.TPSRVA = Convert.ToString(cmd("TPSRVA"))                   
                    CabAduana.TCMTSR = Convert.ToString(cmd("TCMTSR"))
                    CabAduana.NORDSR = Convert.ToInt64(cmd("NORDSR"))
                    CabAduana.REFRNC = Convert.ToString(cmd("REFRNC"))
                    CabAduana.VALMRC = Convert.ToDecimal(cmd("VALMRC"))
                    CabAduana.VALFLT = Convert.ToDecimal(cmd("VALFLT"))
                    CabAduana.VALSEG = Convert.ToDecimal(cmd("VALSEG"))
                    CabAduana.IMPCIF = Convert.ToDecimal(cmd("IMPCIF"))
                    CabAduana.VALADV = Convert.ToDecimal(cmd("VALADV"))
                    CabAduana.VALSBT = Convert.ToDecimal(cmd("VALSBT"))
                    CabAduana.VALIGV = Convert.ToDecimal(cmd("VALIGV"))
                    CabAduana.VALIPM = Convert.ToDecimal(cmd("VALIPM"))
                    CabAduana.FFACTU = Convert.ToInt64(cmd("FFACTU"))
                    CabAduana.FACTUR = Convert.ToString(cmd("FACTUR"))

                    Lisquery.Add(CabAduana)
                End While
            End Using
        End Using
        Return Lisquery

    End Function

    Public Shared Function FillDetalleDUA(ByVal NroOrdenServicio As String) As List(Of BE.DUAA1)
        'Dim sql As String
        'sql = " SELECT TPSRVA,NORDSR,NSERIE,PARTID,NMRFCT,NMITFC,NMRODC,NMITOC,VALMRC,VALFLT," & _
        '            " VALSEG,VALGAS,VALFOB,IMPCIF,VALADP,VALMOR,VALADV, VALSBT, VALDES, VALISC, VALIGV, VALIPM, " & _
        '            " VALICP,VALRNP FROM DUAA1 WHERE NORDSR=" & Detalle.NORDSR


        Dim NomSp As String = ""
        NomSp = "DESCASA.AGENCIAS_SP_DETALLE_DUAA"
        Dim Lisquery As List(Of BE.DUAA1) = New List(Of BE.DUAA1)
        Dim cmd As iDB2DataReader


        'cmd = DB2Helper.ExecuteReader(Conexion.EnlaceDB2, CommandType.Text, sql)

        Using cn As iDB2Connection = ConexionDB2.GetConnection()
            Using command As New iDB2Command(NomSp, cn)
                command.CommandType = CommandType.StoredProcedure '--CInt(op.Substring(3))                
                command.Parameters.Add("IN_OS", iDB2DbType.iDB2VarChar, 15).Value = NroOrdenServicio.ToString.Trim
                cmd = command.ExecuteReader

                While (cmd.Read())

                    Dim DetAduana As BE.DUAA1 = New BE.DUAA1()
                    DetAduana.TPSRVA = Convert.ToString(cmd("TPSRVA"))
                    DetAduana.NORDSR = Convert.ToString(cmd("NORDSR"))
                    DetAduana.NSERIE = Convert.ToInt64(cmd("NSERIE"))
                    DetAduana.PARTID = Convert.ToString(cmd("PARTID"))
                    DetAduana.NMRFCT = Convert.ToString(cmd("NMRFCT"))
                    DetAduana.NMITFC = Convert.ToInt64(cmd("NMITFC"))
                    DetAduana.NMRODC = Convert.ToString(cmd("NMRODC"))
                    DetAduana.NMITOC = Convert.ToInt64(cmd("NMITOC"))
                    DetAduana.VALMRC = Convert.ToDecimal(cmd("VALMRC"))
                    DetAduana.VALFLT = Convert.ToDecimal(cmd("VALFLT"))
                    DetAduana.VALSEG = Convert.ToDecimal(cmd("VALSEG"))
                    DetAduana.VALFOB = Convert.ToDecimal(cmd("VALFOB"))
                    DetAduana.IMPCIF = Convert.ToDecimal(cmd("IMPCIF"))
                    DetAduana.VALADP = Convert.ToDecimal(cmd("VALADP"))
                    DetAduana.VALMOR = Convert.ToDecimal(cmd("VALMOR"))
                    DetAduana.VALADV = Convert.ToDecimal(cmd("VALADV"))
                    DetAduana.VALSBT = Convert.ToDecimal(cmd("VALSBT"))
                    DetAduana.VALDES = Convert.ToDecimal(cmd("VALDES"))
                    DetAduana.VALISC = Convert.ToDecimal(cmd("VALISC"))
                    DetAduana.VALIGV = Convert.ToDecimal(cmd("VALIGV"))
                    DetAduana.VALIPM = Convert.ToDecimal(cmd("VALIPM"))
                    DetAduana.VALICP = Convert.ToDecimal(cmd("VALICP"))
                    DetAduana.VALRNP = Convert.ToDecimal(cmd("VALRNP"))
                    'DetAduana.VALGAS = Convert.ToDecimal(cmd("VALGAS"))

                    Lisquery.Add(DetAduana)
                End While
            End Using
        End Using
        Return Lisquery

    End Function

    
End Class
