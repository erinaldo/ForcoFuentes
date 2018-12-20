Imports System.Data
Imports System.Data.SqlClient

Public Class clsCategoria
    Public Shared Function funGetCategoriaDS(ByVal nparCategoria As String) As DataSet
        '-- Carga datos de un proveedor
        Dim Parametros As New List(Of SqlParameter)
        Parametros.Add(New SqlParameter("@categoria", nparCategoria))
        '--
        Dim ds As DataSet
        '--
        strSQL = "SELECT * FROM Categoria_Articulo WHERE Categoria_Id = @categoria"
        '--
        ds = clsData.ExecuteQueryDs(strSQL, Parametros)
        Return ds
        '--
    End Function

    Public Shared Function funListaCategoria() As DataSet
        '--
        Dim ds As DataSet
        '--
        strSQL = "SELECT  CONVERT(BIT, 0) AS optSelection , " & _
                    "Categoria_Id, " & _
                    "Categoria_Nombre " & _
                    "FROM vw_GB_Categoria_Con_Mov"
        '--
        ds = clsData.ExecuteQueryDs(strSQL)
        Return ds
        '--
    End Function

End Class
