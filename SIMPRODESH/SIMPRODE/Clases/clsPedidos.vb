Imports System.Data
Imports System.Data.SqlClient
Public Class clsPedidos
    Public Shared Function funRepPedidos(ByVal parDate1 As String,
                                            ByVal parDate2 As String) As DataSet
        '--
        Dim ds As New DataSet
        '--
        Dim oLayer As Component.Data.SQL.Layer.PrimitiveTable = Nothing
        Component.Data.SQL.Layer.PrimitiveConnection.connectionString = funConexion()
        oLayer = New Component.Data.SQL.Layer.PrimitiveTable()
        '--
        oLayer.AddParameterInput("@date1", parDate1, 10)
        oLayer.AddParameterInput("@date2", parDate2, 10)        '--
        ds = oLayer.ExecuteDataSet(String.Empty, "sp_RepPedidoBarCode", "Pedidos")
        '--
        Return ds
    End Function

    Public Shared Function funRepDespachosLista(ByVal parSucursal As Integer,
                                                    ByVal parDate1 As String,
                                                    ByVal parDate2 As String) As DataSet
        '--
        Dim ds As New DataSet
        '--
        Dim oLayer As Component.Data.SQL.Layer.PrimitiveTable = Nothing
        Component.Data.SQL.Layer.PrimitiveConnection.connectionString = funConexion()
        oLayer = New Component.Data.SQL.Layer.PrimitiveTable()
        '--
        oLayer.AddParameterInput("@sucursal", parSucursal)
        oLayer.AddParameterInput("@date1", parDate1, 10)
        oLayer.AddParameterInput("@date2", parDate2, 10)        '--
        ds = oLayer.ExecuteDataSet(String.Empty, "sp_RepDespachoLista", "Despachos")
        '--
        Return ds
    End Function

    Public Shared Function funDespacho_BarCode(ByVal parSucursal As Integer,
                                          ByVal parPedido As Integer) As DataSet
        '--
        Dim ds As New DataSet
        '--
        Dim oLayer As Component.Data.SQL.Layer.PrimitiveTable = Nothing
        Component.Data.SQL.Layer.PrimitiveConnection.connectionString = funConexion()
        oLayer = New Component.Data.SQL.Layer.PrimitiveTable()
        '--
        oLayer.AddParameterInput("@sucursal", parSucursal)
        oLayer.AddParameterInput("@pedido", parPedido)        '--
        ds = oLayer.ExecuteDataSet(String.Empty, "sp_RepDespacho_BarCode", "Pedidos")
        '--
        Return ds
    End Function

    Public Shared Function funGetPedidoDS(ByVal cparSucPedido As String) As DataSet
        '-- 
        Dim Parametros As New List(Of SqlParameter)
        Parametros.Add(New SqlParameter("@sucpedido", cparSucPedido))
        '--
        Dim ds As DataSet
        '--
        strSQL = "SELECT  * FROM    dbo.Pedido_Encabezado " &
                    "WHERE CAST(Suc_Id AS VARCHAR) +'' + CAST(Pedido_Id AS VARCHAR)  = @sucpedido "
        '--
        ds = clsData.ExecuteQueryDs(strSQL, Parametros)
        Return ds
        '--
    End Function
End Class
