Imports System.Data
Imports System.Data.SqlClient

Public Class clsProducto

    Public Shared Function funGetProductoDS(ByVal cparProducto As String) As DataSet
        '-- Carga datos de un proveedor
        Dim Parametros As New List(Of SqlParameter)
        Parametros.Add(New SqlParameter("@producto", cparProducto))
        '--
        Dim ds As DataSet
        '--
        strSQL = "SELECT * FROM Articulo WHERE Articulo_Id = @producto"
        '--
        ds = clsData.ExecuteQueryDs(strSQL, Parametros)
        Return ds
        '--
    End Function


End Class

