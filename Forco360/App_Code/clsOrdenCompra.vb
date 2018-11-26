Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Public Class clsOrdenCompra
    Public Shared strSQL As String
    Public Shared Function funGetLista_CompraDetalle(ByVal nparNumero As Integer) As DataTable
        '-- GB (29-12-2016): Para listar compras locales del F360.
        Dim Parametros As New List(Of SqlParameter)
        Dim dt As New DataTable
        '--
        strSQL = "SELECT * FROM vw_GB_OC_Detalle ORDER BY nRecno"
        dt = clsData.ExecuteQuery(strSQL, Parametros)
        Return dt
    End Function

    Public Shared Function funGetCombo_OCL_Estado() As DataTable
        '-- GB (29-12-2016): Para listar el estado de las compras.
        Dim Parametros As New List(Of SqlParameter)
        '--
        Dim dt As New DataTable
        '-- 
        strSQL = "SELECT * FROM vw_GB_LD_Compra_Tipo"
        '--
        dt = clsData.ExecuteQuery(strSQL, Parametros)
        '--
        Return dt
        '--
    End Function

    Public Shared Function funGetLista_Estado_Solicitud_Pago() As DataTable
        '-- GB (06-01-2017): Estado de solicitud de pago.
        Dim Parametros As New List(Of SqlParameter)
        '--
        Dim dt As New DataTable
        '-- 
        strSQL = "SELECT * FROM vw_GB_Pago_Forco_Status"
        '--
        dt = clsData.ExecuteQuery(strSQL, Parametros)
        '--
        Return dt
        '--
    End Function

    Public Shared Function funGetLista_Estado_Solicitud_Compra() As DataTable
        '-- GB (06-01-2017): Estado de solicitud de pago.
        Dim Parametros As New List(Of SqlParameter)
        '--
        Dim dt As New DataTable
        '-- 
        strSQL = "SELECT * FROM vw_GB_OC_Forco_Status"
        '--
        dt = clsData.ExecuteQuery(strSQL, Parametros)
        '--
        Return dt
        '--
    End Function

    Public Shared Function funGetLista_Orden_Compra_LD(ByVal nparProvee As Integer,
                                                    ByVal nparEstado As Integer,
                                                    ByVal dparFecha1 As Date,
                                                    ByVal dparFecha2 As Date) As DataTable
        '-- 
        Dim Parametros As New List(Of SqlParameter)
        Parametros.Add(New SqlParameter("@proveedor", nparProvee))
        Parametros.Add(New SqlParameter("@estado", nparEstado))
        Parametros.Add(New SqlParameter("@fecha1", dparFecha1))
        Parametros.Add(New SqlParameter("@fecha2", dparFecha2))
        '--
        Dim dt As New DataTable
        '-- Cuando se usa directamente el SQL, el parametro fecha se pasa como DATE.
        strSQL = "SELECT * FROM vw_GB_CL_Encabezado " &
                    " WHERE (Prov_Id = @proveedor OR @proveedor = 0) " &
                    " AND (nCompra_Status = @estado OR @estado = '0') " &
                    " AND (Orden_Fecha_Crea BETWEEN @fecha1 AND @fecha2) " &
                    " AND nPago_Status <=2" &
                    " ORDER BY Orden_Id"
        '-- 
        dt = clsData.ExecuteQuery(strSQL, Parametros)
        '--
        Return dt
        '--
    End Function

    Public Shared Function funGetLista_Orden_Compra_Solicitud_Pago_LD(ByVal nparProvee As Integer,
                                                    ByVal nparEstado As Integer,
                                                    ByVal dparFecha1 As Date,
                                                    ByVal dparFecha2 As Date) As DataTable
        '-- GB (06-01-2017): Filtrar encabezado de orden de compra con solicitudes de pagos, donde departamento = 20 (Suministros)
        Dim Parametros As New List(Of SqlParameter)
        Parametros.Add(New SqlParameter("@proveedor", nparProvee))
        Parametros.Add(New SqlParameter("@estado", nparEstado))
        Parametros.Add(New SqlParameter("@fecha1", dparFecha1))
        Parametros.Add(New SqlParameter("@fecha2", dparFecha2))
        '--
        Dim dt As New DataTable
        '-- Cuando se usa directamente el SQL, el parametro fecha se pasa como DATE.
        strSQL = "SELECT * FROM vw_GB_CL_Encabezado_OC_Auto " &
                    " WHERE (Prov_Id = @proveedor OR @proveedor = 0) " &
                    " AND (nPago_Status = @estado OR @estado = 0) " &
                    " AND (Orden_Fecha_Crea BETWEEN @fecha1 AND @fecha2) " &
                    " ORDER BY Orden_Id"
        '-- 
        dt = clsData.ExecuteQuery(strSQL, Parametros)
        '--
        Return dt
        '--
    End Function

    Public Shared Function funGetLista_Orden_Compra_Detalle_LD(ByVal nparOrden As Integer) As DataTable
        '-- GB (30-12-2016): Para listar el detalle de articulos.
        Dim Parametros As New List(Of SqlParameter)
        Parametros.Add(New SqlParameter("@orden", nparOrden))
        Dim dt As New DataTable
        '--
        strSQL = "SELECT * FROM vw_GB_CL_Detalle" &
                    " WHERE CAST(Orden_Id AS INTEGER) = @orden " &
                    " ORDER BY Detalle_Id"
        '--
        dt = clsData.ExecuteQuery(strSQL, Parametros)
        Return dt
    End Function

    Public Shared Function funGetLista_Orden_Compra_Picture_LD(ByVal nparOrden As Integer) As DataTable
        '-- GB (30-12-2016): Para listar el detalle de articulos.
        Dim Parametros As New List(Of SqlParameter)
        Parametros.Add(New SqlParameter("@orden", nparOrden))
        Dim dt As New DataTable
        '--
        strSQL = "SELECT * FROM Image_Details " &
                    " WHERE nOrden = @orden " &
                    "ORDER BY ImageId"
        '--
        dt = clsData.ExecuteQuery(strSQL, Parametros)
        Return dt
    End Function

    Public Shared Function funGet_Imagen(ByVal nparOrden As Integer,
                                                 ByVal nparCodigo As Integer) As DataSet
        '-- GB (05-01-201): Filtra la imagen
        Dim Parametros As New List(Of SqlParameter)
        Parametros.Add(New SqlParameter("@orden", nparOrden))
        Parametros.Add(New SqlParameter("@codigo", nparCodigo))
        Dim ds As New DataSet
        '--
        strSQL = "SELECT * FROM Image_Details" &
                    " WHERE nOrden = @orden " &
                    " AND ImageId = @codigo "
        '--
        ds = clsData.ExecuteQueryDs(strSQL, Parametros)
        Return ds
    End Function
End Class
