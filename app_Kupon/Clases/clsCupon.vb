Imports System.Data
Imports System.Data.SqlClient

Public Class clsCupon


    Public Shared Function funGetCuponDS(ByVal cparCupon As String) As DataSet
        '-- 
        Dim Parametros As New List(Of SqlParameter)
        Parametros.Add(New SqlParameter("@cupon", cparCupon))
        '--
        Dim ds As DataSet
        '--
        strSQL = "SELECT * FROM dbo.Inv_Tarjetasregalo WHERE BarCode  = @cupon "
        '--
        ds = clsData.ExecuteQueryDs(strSQL, Parametros)
        Return ds
        '--
    End Function


End Class
