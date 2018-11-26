Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Public Class clsArticulos
    Public Shared strSQL As String


    Public Shared Function funGetLista_Articulos(ByVal nparDepto As Integer) As DataTable
        '-- Listado de Sub Tipo
        Dim Parametros As New List(Of SqlParameter)
        Parametros.Add(New SqlParameter("@depto", nparDepto))
        '--
        Dim dt As New DataTable
        '-- 
        strSQL = "SELECT * FROM Articulo_Info WHERE Depto_Id = @depto"
        '--
        dt = clsData.ExecuteQuery(strSQL, Parametros)
        '--
        Return dt
        '--
    End Function

   
End Class
