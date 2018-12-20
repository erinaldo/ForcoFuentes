Imports System.Data
Imports System.Data.SqlClient

Public Class clsProducto

    Public Shared Function funGetProductoBodegaDS(ByVal nParEmpresa As Integer,
                                                  ByVal nParProducto As Integer) As DataSet
        '-- Carga recibo
        Dim Parametros As New List(Of SqlParameter)
        Parametros.Add(New SqlParameter("@empresa", nParEmpresa))
        Parametros.Add(New SqlParameter("@producto", nParProducto))
        '--
        Dim ds As DataSet
        '--
        strSQL = "SELECT nPrecio, dtmupdate" & _
                    " FROM dbo.Inv_ProductoBodega" & _
                    " WHERE nEmpresa = @empresa" & _
                    " AND nCode = @producto"
        '--
        ds = clsData.ExecuteQueryDs(strSQL, Parametros)
        Return ds
        '--
    End Function

    Public Shared Function funGetProductoDS(ByVal nParEmpresa As Integer,
                                                 ByVal nParProducto As Integer) As DataSet
        '-- Carga datos de un producto
        Dim Parametros As New List(Of SqlParameter)
        Parametros.Add(New SqlParameter("@empresa", nParEmpresa))
        Parametros.Add(New SqlParameter("@producto", nParProducto))
        '--
        Dim ds As DataSet
        '--
        strSQL = "SELECT * FROM v_Inv_Gv_ProductoBodega" & _
                    " WHERE nEmpresa = @empresa" & _
                    " AND nCode = @producto"
        '--
        ds = clsData.ExecuteQueryDs(strSQL, Parametros)
        Return ds
        '--
    End Function

    Public Shared Function funGetListProductoSaldoBodega(ByVal nparEmpresa As Integer, _
                                                       ByVal cparProducto As String) As DataSet
        '--
        '-- Traer el detalle productos con filtro like de v_Inv_Gv_ProductoBodegaConSaldo
        Dim ds As New DataSet
        '--
        Dim oLayer As Component.Data.SQL.Layer.PrimitiveTable = Nothing
        Component.Data.SQL.Layer.PrimitiveConnection.connectionString = funConexion()
        oLayer = New Component.Data.SQL.Layer.PrimitiveTable()
        '--
        oLayer.AddParameterInput("@empresa", nparEmpresa)
        oLayer.AddParameterInput("@producto", cparProducto, 100)
        '--
        ds = oLayer.ExecuteDataSet(String.Empty, "spGetListProductoBodegaSaldo", "Saldos")
        '--
        Return ds
    End Function

    Public Shared Function funGetListProductoSaldoBodega2(ByVal nparEmpresa As Integer) As DataSet
        '--
        '-- Traer los 100 primeros registros sin ningun filtro de v_Inv_Gv_ProductoBodegaConSaldo
        Dim ds As New DataSet
        '--
        Dim oLayer As Component.Data.SQL.Layer.PrimitiveTable = Nothing
        Component.Data.SQL.Layer.PrimitiveConnection.connectionString = funConexion()
        oLayer = New Component.Data.SQL.Layer.PrimitiveTable()
        '--
        oLayer.AddParameterInput("@empresa", nparEmpresa)
        '--
        ds = oLayer.ExecuteDataSet(String.Empty, "spGetListProductoBodegaSaldo2", "Saldos")
        '--
        Return ds
    End Function

    Public Shared Function funGetProductoConSaldo(ByVal nparEmpresa As Integer, _
                                                      ByVal nparProducto As Integer) As DataSet
        '--
        '-- Traer los datos del producto con saldo
        Dim ds As New DataSet
        '--
        Dim oLayer As Component.Data.SQL.Layer.PrimitiveTable = Nothing
        Component.Data.SQL.Layer.PrimitiveConnection.connectionString = funConexion()
        oLayer = New Component.Data.SQL.Layer.PrimitiveTable()
        '--
        oLayer.AddParameterInput("@empresa", nparEmpresa)
        oLayer.AddParameterInput("@producto", nparProducto)
        '--
        ds = oLayer.ExecuteDataSet(String.Empty, "spGetProductoConSaldo", "Saldos")
        '--
        Return ds
    End Function

   

End Class
