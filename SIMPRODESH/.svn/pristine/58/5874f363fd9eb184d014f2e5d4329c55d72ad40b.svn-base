Imports System.Data
Imports System.Data.SqlClient

Public Class clsLocaliza

    Public Shared Function funListaLocaliza() As DataSet
        '--
        Dim ds As DataSet
        '--
        strSQL = "SELECT CONVERT(BIT, 0) AS optSelection ,  " &
        "LOCALIZACION As POSICION " &
        "FROM dbo.vw_GB_Articulo_Posicion " &
        "GROUP BY LOCALIZACION ORDER BY LOCALIZACION"
        '--
        ds = clsData.ExecuteQueryDs(strSQL)
        Return ds
        '--
    End Function

End Class
