Imports System.Data
Imports System.Data.SqlClient

Public Class clsCategoriaSub
    Public Shared Function funListaCategoriaSubDS(ByVal nparCategoria As String) As DataSet
        '-- Carga datos de un proveedor
        Dim Parametros As New List(Of SqlParameter)
        Parametros.Add(New SqlParameter("@categoria", nparCategoria))
        '--
        Dim ds As DataSet
        '--
        strSQL = "SELECT *, CONVERT(bit,0) AS optSelection FROM SubCategoria_Articulo WHERE Categoria_Id = @categoria"
        '--
        ds = clsData.ExecuteQueryDs(strSQL, Parametros)
        Return ds
        '--
    End Function


    Public Shared Function funListaSubCategorias() As DataSet
        '--
        Dim ds As DataSet
        '--
        strSQL = "SELECT  CONVERT(BIT, 0) AS optSelection ," & _
                        " ca.Categoria_Nombre Categoria ," & _
                        " sc.SubCategoria_Nombre AS CategoriaSub ," & _
                        " CAST(ca.Categoria_Id AS VARCHAR(10)) + '' " & _
                        " + CAST(sc.SubCategoria_Id AS VARCHAR(10)) AS CodigoUnico " & _
                        " FROM    dbo.Categoria_Articulo ca " & _
                        " INNER JOIN dbo.SubCategoria_Articulo sc ON ca.Emp_Id = sc.Emp_Id" & _
                        " AND ca.Categoria_Id = sc.Categoria_Id " & _
                        " ORDER BY ca.Categoria_Id ," & _
                        " sc.SubCategoria_Nombre"
        '--
        ds = clsData.ExecuteQueryDs(strSQL)
        Return ds
        '--
    End Function

End Class
