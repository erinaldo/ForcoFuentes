Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Public Class clsProveedor
    Public Shared strSQL As String
    Public Shared Function funGetLista_Proveedor_Local() As DataTable
        '-- Listado de Sub Tipo
        Dim Parametros As New List(Of SqlParameter)
        '--
        Dim dt As New DataTable
        '-- 
        strSQL = "SELECT * FROM vw_GB_Proveedor_Local ORDER BY Prov_Nombre"
        '--
        dt = clsData.ExecuteQuery(strSQL, Parametros)
        '--
        Return dt
        '--
    End Function

    Public Shared Function funGetLista_OC_Proveedor() As DataTable
        '-- Listado de proveedores con ordenes de compras locales en LD
        Dim Parametros As New List(Of SqlParameter)
        '--
        Dim dt As New DataTable
        '-- 
        strSQL = "SELECT * FROM vw_GB_Proveedor ORDER BY Prov_Nombre"
        '--
        dt = clsData.ExecuteQuery(strSQL, Parametros)
        '--
        Return dt
        '--
    End Function

End Class
