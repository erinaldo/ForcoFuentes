Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Public Class clsSuministros
    Public Shared strSQL As String

    Public Shared Function funGetLista_CL_Encabezado() As DataTable
        '-- CLE: Compras locales suministros, solo el Depto_Id = 20
        Dim Parametros As New List(Of SqlParameter)
        '-- Parametros.Add(New SqlParameter("@depto", nparDepto))
        '--
        Dim dt As New DataTable
        '-- 
        strSQL = "SELECT TOP(50) * FROM vw_GB_CL_Encabezado"
        dt = clsData.ExecuteQuery(strSQL, Parametros)
        '--
        Return dt
        '--
    End Function


End Class
