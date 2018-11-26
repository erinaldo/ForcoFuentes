Imports System.Data
Imports System.Data.SqlClient

Public Class clsProveedor

    Public Shared Function funGetProveedorDS(ByVal nParProveedor As Integer) As DataSet
        '-- Carga datos de un proveedor
        Dim Parametros As New List(Of SqlParameter)
        Parametros.Add(New SqlParameter("@proveedor", nParProveedor))
        '--
        Dim ds As DataSet
        '--
        strSQL = "SELECT * FROM vw_GB_ProveedorConMovto WHERE Prov_Id = @proveedor"
        '--
        ds = clsData.ExecuteQueryDs(strSQL, Parametros)
        Return ds
        '--
    End Function

    Public Shared Function funGetProveedor_Con_Compras_DS() As DataSet
        '-- Carga datos de un proveedor con compras
        Dim Parametros As New List(Of SqlParameter)
        '--
        Dim ds As DataSet
        '--
        strSQL = "SELECT * FROM vw_GB_Proveedor_Con_Compras ORDER BY Prov_Nombre"
        '--
        ds = clsData.ExecuteQueryDs(strSQL, Parametros)
        Return ds
        '--
    End Function


End Class

