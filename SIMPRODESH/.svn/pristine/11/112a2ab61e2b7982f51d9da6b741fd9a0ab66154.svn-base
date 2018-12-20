Imports System.Data
Imports System.Data.SqlClient

Public Class clsDepartamento

    Public Shared Function funListaDepartamento() As DataSet
        '--
        Dim ds As DataSet
        '--
        strSQL = "SELECT  CONVERT(BIT, 0) AS optSelection , " & _
                    "Depto_Id, " & _
                    "Depto_Nombre " & _
                    "FROM dbo.Departamento"
        '--
        ds = clsData.ExecuteQueryDs(strSQL)
        Return ds
        '--
    End Function

End Class
