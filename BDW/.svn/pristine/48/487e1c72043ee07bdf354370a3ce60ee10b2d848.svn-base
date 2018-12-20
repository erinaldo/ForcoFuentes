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

    Public Shared Function funRepDespachosLista(ByVal parSucursal As Integer) As DataSet
        '--
        Dim ds As New DataSet
        '--
        Dim oLayer As Component.Data.SQL.Layer.PrimitiveTable = Nothing
        Component.Data.SQL.Layer.PrimitiveConnection.connectionString = funConexion()
        oLayer = New Component.Data.SQL.Layer.PrimitiveTable()
        '--
        oLayer.AddParameterInput("@sucursal", parSucursal)
        ds = oLayer.ExecuteDataSet(String.Empty, "sp_RepDespachoLista", "Despachos")
        '--
        Return ds
    End Function

    Public Shared Function funRepDespachosListaRe(ByVal parSucursal As Integer) As DataSet
        '--
        Dim ds As New DataSet
        '--
        Dim oLayer As Component.Data.SQL.Layer.PrimitiveTable = Nothing
        Component.Data.SQL.Layer.PrimitiveConnection.connectionString = funConexion()
        oLayer = New Component.Data.SQL.Layer.PrimitiveTable()
        '--
        oLayer.AddParameterInput("@sucursal", parSucursal)
        ds = oLayer.ExecuteDataSet(String.Empty, "sp_RepDespachoListaRe", "Despachos")
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


    Public Shared Function funDespacho_BarCodeRe(ByVal parSucursal As Integer,
                                                    ByVal parPedido As Integer,
                                                    ByVal parSubPedido As Integer) As DataSet
        '--
        Dim ds As New DataSet
        '--
        Dim oLayer As Component.Data.SQL.Layer.PrimitiveTable = Nothing
        Component.Data.SQL.Layer.PrimitiveConnection.connectionString = funConexion()
        oLayer = New Component.Data.SQL.Layer.PrimitiveTable()
        '--
        oLayer.AddParameterInput("@sucursal", parSucursal)
        oLayer.AddParameterInput("@pedido", parPedido)
        oLayer.AddParameterInput("@subpedido", parSubPedido)
        '--
        ds = oLayer.ExecuteDataSet(String.Empty, "sp_RepDespacho_BarCode_Re", "Pedidos")
        '--
        Return ds
    End Function

    Public Shared Function funGetInvDespachoDS(ByVal cparSucPedido As String) As DataSet
        '-- 
        Dim Parametros As New List(Of SqlParameter)
        Parametros.Add(New SqlParameter("@sucpedido", cparSucPedido))
        '--
        Dim ds As DataSet
        '--
        strSQL = "SELECT * FROM dbo.Inv_Despacho_Encabezado " &
                    "WHERE CAST(Suc_Id AS VARCHAR) +'' + CAST(Pedido_Id AS VARCHAR)  = @sucpedido "
        '--
        ds = clsData.ExecuteQueryDs(strSQL, Parametros)
        Return ds
        '--
    End Function

    Public Shared Function funGetPedidoAsignadosDS(ByVal cparSucPedido As String) As DataSet
        '-- 
        Dim Parametros As New List(Of SqlParameter)
        Parametros.Add(New SqlParameter("@sucpedido", cparSucPedido))
        '--
        Dim ds As DataSet
        '--
        strSQL = "SELECT  * FROM dbo.GB_Pedidos " &
                    "WHERE cSucPedido  = @sucpedido "
        '--
        ds = clsData.ExecuteQueryDs(strSQL, Parametros)
        Return ds
        '--
    End Function

    Public Shared Function funNextProcesoPedidos(ByVal Emp_id As Integer,
                                     ByVal CEDI_id As Integer,
                                     ByVal Suc_id As Integer,
                                     ByVal Pedido_id As Integer,
                                     ByVal Usuario_id As Integer,
                                     ByVal Ap_Transp As Boolean)

        Dim DBConn As SqlConnection
        DBConn = New SqlConnection(funConexion())

        Dim cmd As SqlCommand = New SqlCommand("INV_Despacho_PickingList_Ubicacion", DBConn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim _Emp_id As New SqlParameter("@Emp_id", SqlDbType.SmallInt)
        _Emp_id.Value = Emp_id
        cmd.Parameters.Add(_Emp_id)

        Dim _CEDI_id As New SqlParameter("@CEDI_id", SqlDbType.SmallInt)
        _CEDI_id.Value = CEDI_id
        cmd.Parameters.Add(_CEDI_id)

        Dim _Suc_id As New SqlParameter("@Suc_id", SqlDbType.SmallInt)
        _Suc_id.Value = Suc_id
        cmd.Parameters.Add(_Suc_id)

        Dim _Pedido_id As New SqlParameter("@Pedido_id", SqlDbType.Int)
        _Pedido_id.Value = Pedido_id
        cmd.Parameters.Add(_Pedido_id)

        Dim _Usuario_id As New SqlParameter("@Usuario_id", SqlDbType.Int)
        _Usuario_id.Value = Usuario_id
        cmd.Parameters.Add(_Usuario_id)

        Dim _Ap_Transp As New SqlParameter("@Ap_Transp", SqlDbType.Bit)
        _Ap_Transp.Value = Ap_Transp
        cmd.Parameters.Add(_Ap_Transp)

        cmd.Connection = DBConn
        DBConn.Open()
        cmd.ExecuteNonQuery()

        Return True
    End Function

End Class
