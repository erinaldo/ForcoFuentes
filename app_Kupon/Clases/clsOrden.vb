Imports System.Data
Imports System.Data.SqlClient

Public Class clsOrden
    Public Shared Function funGetListaReceta(ByVal nparReceta As Integer,
                                            ByVal nparOrden As Integer,
                                            ByVal nparCantidad As Integer) As DataSet
        '-- 
        Dim ds As New DataSet
        '--
        Dim oLayer As Component.Data.SQL.Layer.PrimitiveTable = Nothing
        Component.Data.SQL.Layer.PrimitiveConnection.connectionString = funConexion()
        oLayer = New Component.Data.SQL.Layer.PrimitiveTable()
        '--
        oLayer.AddParameterInput("@receta", nparReceta)
        oLayer.AddParameterInput("@orden", nparOrden)
        oLayer.AddParameterInput("@cantidad", nparCantidad)
        '--
        ds = oLayer.ExecuteDataSet(String.Empty, "sp_RecetaCargaDetalle", "Saldos")
        '--
        Return ds
    End Function

End Class
