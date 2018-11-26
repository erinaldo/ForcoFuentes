Imports System.Data
Imports System.Data.SqlClient

Public Class clsArticulo
    Public Shared Function funGetArticuloFromExcel(ByVal parIds As String) As DataSet
        '--
        '-- Carga lista de articulos from excel
        Dim ds As New DataSet
        '--
        Dim oLayer As Component.Data.SQL.Layer.PrimitiveTable = Nothing
        Component.Data.SQL.Layer.PrimitiveConnection.connectionString = funConexion()
        oLayer = New Component.Data.SQL.Layer.PrimitiveTable()
        '--
        oLayer.AddParameterInput("@ids", parIds, 90000)
        '--
        ds = oLayer.ExecuteDataSet(String.Empty, "sp_RepGetArticuloFromExcel", "Comparativo")
        '--
        Return ds
    End Function

End Class

