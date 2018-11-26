Imports System.Data
Imports System.Data.SqlClient

Public Class clsUnidad


    Public Shared Function funGetUnidadDs(ByVal nparCode As Integer) As DataSet
        '-- 
        Dim Parametros As New List(Of SqlParameter)
        Parametros.Add(New SqlParameter("@code", nparCode))
        '--
        Dim ds As New DataSet
        '-- 
        strSQL = "SELECT * FROM v_Inv_Producto " &
                    "WHERE nCode = @code "
        '--
        ds = clsData.ExecuteQueryDs(strSQL, Parametros)
        Return ds
        '--
    End Function

End Class
