Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Public Class clsEmpleado
    Public Shared strSQL As String

    Public Shared Function funGetEmpleadoPortienda(ByVal cparUsuario As String) As DataSet
        '-- Traer listado de empleados por tienda
        Dim ds As New DataSet
        '--
        Dim oLayer As Component.Data.SQL.Layer.PrimitiveTable = Nothing
        Component.Data.SQL.Layer.PrimitiveConnection.connectionString = clsForcoHelper.funConexion()
        oLayer = New Component.Data.SQL.Layer.PrimitiveTable()
        '--
        oLayer.AddParameterInput("@usuario", cparUsuario, 50)
        '--
        ds = oLayer.ExecuteDataSet(String.Empty, "sp_GB_ListaEmpleadoPorTienda_Activo", "Empleados")
        '--
        Return ds
    End Function


End Class
