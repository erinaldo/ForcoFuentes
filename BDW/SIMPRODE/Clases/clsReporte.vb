Imports System.Data
Imports System.Data.SqlClient

Public Class clsReporte
    Public Shared Function funGetReporteCategoria(ByVal parDollar As Double, _
                                                    ByVal parDate1 As String, _
                                                    ByVal parDate2 As String, _
                                                    ByVal parDateMargen1 As String, _
                                                    ByVal parDateMargen2 As String,
                                                    ByVal parIds As String) As DataSet
        '--
        '-- Traer reporte de categoria
        Dim ds As New DataSet
        '--
        Dim oLayer As Component.Data.SQL.Layer.PrimitiveTable = Nothing
        Component.Data.SQL.Layer.PrimitiveConnection.connectionString = funConexion()
        oLayer = New Component.Data.SQL.Layer.PrimitiveTable()
        '--
        oLayer.AddParameterInput("@dollar", parDollar)
        oLayer.AddParameterInput("@date1", parDate1, 10)
        oLayer.AddParameterInput("@date2", parDate2, 10)
        oLayer.AddParameterInput("@datemargen1", parDateMargen1, 10)
        oLayer.AddParameterInput("@datemargen2", parDateMargen2, 10)
        oLayer.AddParameterInput("@ids", parIds, 250)
        '--
        ds = oLayer.ExecuteDataSet(String.Empty, "sp_RepComprasSaldosMargenCategoria", "Comparativo")
        '--
        Return ds
    End Function

    Public Shared Function funGetReporteDepartamento(ByVal parDollar As Double, _
                                                  ByVal parDate1 As String, _
                                                  ByVal parDate2 As String, _
                                                  ByVal parDateMargen1 As String, _
                                                  ByVal parDateMargen2 As String,
                                                  ByVal parIds As String) As DataSet
        '--
        Dim ds As DataSet = Nothing
        ds = New DataSet
        '--
        Dim oLayer As Component.Data.SQL.Layer.PrimitiveTable = Nothing
        Component.Data.SQL.Layer.PrimitiveConnection.connectionString = funConexion()
        oLayer = New Component.Data.SQL.Layer.PrimitiveTable()
        oLayer.AddParameterInput("@dollar", parDollar)
        oLayer.AddParameterInput("@date1", parDate1, 10)
        oLayer.AddParameterInput("@date2", parDate2, 10)
        oLayer.AddParameterInput("@datemargen1", parDateMargen1, 10)
        oLayer.AddParameterInput("@datemargen2", parDateMargen2, 10)
        oLayer.AddParameterInput("@ids", parIds, 250)
        '--
        ds = oLayer.ExecuteDataSet(String.Empty, "sp_RepComprasSaldosMargenDepto", "Comparativo")
        '--
        Return ds
    End Function

End Class

