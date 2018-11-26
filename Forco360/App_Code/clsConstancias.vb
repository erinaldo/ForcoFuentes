Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Public Class clsConstancias
    Public Shared strSQL As String

    Public Shared Function funGetLista_Constancia() As DataTable
        '-- Listado Constancias
        Dim Parametros As New List(Of SqlParameter)
        Dim dt As New DataTable
        '--
        strSQL = "SELECT * FROM vw_GB_Constancia_Browse ORDER BY nCode"
        dt = clsData.ExecuteQuery(strSQL, Parametros)
        Return dt
    End Function


End Class
