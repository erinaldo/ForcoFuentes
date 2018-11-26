Imports System.Data
Imports System.Data.SqlClient

Public Class clsKardex

    Public Shared Function funGetKardex(ByVal nparEmpresa As Integer, _
                                            ByVal nparCode As Integer) As DataSet
        '-- 2012-01-19: Traer listado de movimientos de un producto
        Dim ds As New DataSet
        '--
        Dim oLayer As Component.Data.SQL.Layer.PrimitiveTable = Nothing
        Component.Data.SQL.Layer.PrimitiveConnection.connectionString = funConexion()
        oLayer = New Component.Data.SQL.Layer.PrimitiveTable()
        '--
        oLayer.AddParameterInput("@nEmpresa", nparEmpresa)
        oLayer.AddParameterInput("@nCode", nparCode)
        oLayer.AddParameterInput("@usuario", strUser, 100)
        ds = oLayer.ExecuteDataSet(String.Empty, "spKardexItem", "Kardex")
        '--
        Return ds
    End Function

End Class
