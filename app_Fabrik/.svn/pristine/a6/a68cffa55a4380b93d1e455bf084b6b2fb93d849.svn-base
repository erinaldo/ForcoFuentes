Imports System.Data
Imports System.Data.SqlClient

Public Class clsLote

    Public Shared Function funNuevoLote(ByVal nparEmpresa As Integer, ByVal nparProducto As Integer) As Integer
        '-- Numero consecutivo del lote
        Dim Parametros As New List(Of SqlParameter)
        Parametros.Add(New SqlParameter("@empresa", nparEmpresa))
        Parametros.Add(New SqlParameter("@producto", nparProducto))
        '--
        strSQL = "SELECT ISNULL(MAX(nLote), 0) + 1 " & _
                    "FROM Inv_ProductoLote " & _
                    "WHERE nEmpresa = @empresa " & _
                    "AND nCode = @producto"
        '--
        Dim vnNextLote As Integer = clsData.ExecuteScalar(strSQL, Parametros)
        Return vnNextLote
    End Function

    Public Shared Function funVerSaldoLoteActual(ByVal nparEmpresa As Integer, ByVal nparProducto As Integer) As Integer
        '-- Numero consecutivo del lote
        Dim Parametros As New List(Of SqlParameter)
        Parametros.Add(New SqlParameter("@empresa", nparEmpresa))
        Parametros.Add(New SqlParameter("@producto", nparProducto))
        '--
        strSQL = "SELECT ISNULL(SUM(nSaldo), 0) " & _
                    "FROM v_Rep_Existencia_Lote " & _
                    "WHERE nEmpresa = @empresa " & _
                    "AND nCode = @producto"
        '--
        Dim vnSumaSaldoActual As Integer = clsData.ExecuteScalar(strSQL, Parametros)
        Return vnSumaSaldoActual
    End Function

    Public Shared Function funGetDataLoteDs(ByVal nparEmpresa As Integer, _
                                               ByVal nparCode As Integer, _
                                               ByVal nparLote As Integer) As DataSet
        '-- Cargar datos del lote
        Dim Parametros As New List(Of SqlParameter)
        Parametros.Add(New SqlParameter("@empresa", nparEmpresa))
        Parametros.Add(New SqlParameter("@code", nparCode))
        Parametros.Add(New SqlParameter("@lote", nparLote))
        '--
        Dim ds As New DataSet
        '-- 
        strSQL = "SELECT * FROM Inv_ProductoLote " & _
                    "WHERE nEmpresa = @empresa " & _
                    "AND nCode = @code " & _
                    "AND nLote = @lote"
        '--
        ds = clsData.ExecuteQueryDs(strSQL, Parametros)
        Return ds
        '--
    End Function

    Public Shared Function funGetListProductoLote(ByVal nparEmpresa As Integer, _
                                                    ByVal nparProducto As Integer) As DataSet
        '-- Listado de lotes registrados
        Dim ds As New DataSet
        '--
        Dim oLayer As Component.Data.SQL.Layer.PrimitiveTable = Nothing
        Component.Data.SQL.Layer.PrimitiveConnection.connectionString = funConexion()
        oLayer = New Component.Data.SQL.Layer.PrimitiveTable()
        '--
        oLayer.AddParameterInput("@empresa", nparEmpresa)
        oLayer.AddParameterInput("@producto", nparProducto)
        '--
        ds = oLayer.ExecuteDataSet(String.Empty, "spGetListProductoLote", "Saldos")
        '--
        Return ds
    End Function

    Public Shared Function funGetListProductoLoteDetalleDs(ByVal nparEmpresa As Integer, _
                                              ByVal nparCode As Integer, _
                                              ByVal nparLote As Integer) As DataSet
        '-- Listado de registros en Inv_ProductoLote_Detalle
        Dim Parametros As New List(Of SqlParameter)
        Parametros.Add(New SqlParameter("@empresa", nparEmpresa))
        Parametros.Add(New SqlParameter("@code", nparCode))
        Parametros.Add(New SqlParameter("@lote", nparLote))
        '--
        Dim ds As New DataSet
        '-- 
        strSQL = "SELECT * FROM Inv_ProductoLote_Detalle " & _
                    "WHERE nEmpresa = @empresa " & _
                    "AND nCode = @code " & _
                    "AND nLote = @lote"
        '--
        ds = clsData.ExecuteQueryDs(strSQL, Parametros)
        Return ds
        '--
    End Function

    Public Shared Function funNuevoProductoLoteDetalle(ByVal nparEmpresa As Integer, _
                                                      ByVal nparConcepto As Integer, _
                                                      ByVal nparProducto As Integer, _
                                                      ByVal nparLote As Integer) As Integer
        '-- Nuevo numero consecutivo en la tabla Inv_ProductoLote_Detalle
        Dim Parametros As New List(Of SqlParameter)
        Parametros.Add(New SqlParameter("@empresa", nparEmpresa))
        Parametros.Add(New SqlParameter("@concepto", nparConcepto))
        Parametros.Add(New SqlParameter("@producto", nparProducto))
        Parametros.Add(New SqlParameter("@Lote", nparLote))
        '--
        strSQL = "SELECT ISNULL(MAX(nLote), 0) + 1 " & _
                    "FROM Inv_ProductoLote_Detalle " & _
                    "WHERE nEmpresa = @empresa " & _
                    "AND nConcepto = @concepto " & _
                    "AND nCode = @producto " & _
                    "AND nLote = @lote"
        '--
        Dim vnProductoLoteDetalleNext As Integer = clsData.ExecuteScalar(strSQL, Parametros)
        Return vnProductoLoteDetalleNext
    End Function

    Public Shared Function funGetDataProductoLoteDetalleDs(ByVal nparEmpresa As Integer, _
                                              ByVal nparConcepto As Integer, _
                                              ByVal nparProducto As Integer, _
                                              ByVal nparLote As Integer, _
                                              ByVal nparNext As Integer) As DataSet
        '-- Traer datos del registro de Inv_ProductoLote_Detalle
        Dim Parametros As New List(Of SqlParameter)
        Parametros.Add(New SqlParameter("@empresa", nparEmpresa))
        Parametros.Add(New SqlParameter("@concepto", nparConcepto))
        Parametros.Add(New SqlParameter("@producto", nparProducto))
        Parametros.Add(New SqlParameter("@lote", nparLote))
        Parametros.Add(New SqlParameter("@next", nparNext))
        Dim ds As New DataSet
        '-- Filtra el regitro
        strSQL = "SELECT * " & _
                    "FROM Inv_ProductoLote_Detalle " & _
                    "WHERE nEmpresa = @empresa " & _
                    "AND nConcepto = @concepto " & _
                    "AND nCode = @producto " & _
                    "AND nLote = @lote " & _
                    "AND nConsecutivo = @next"
        '--
        ds = clsData.ExecuteQueryDs(strSQL, Parametros)
        Return ds
        '--
    End Function
End Class
