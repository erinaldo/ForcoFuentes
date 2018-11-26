Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Public Class clsTienda
    Public Shared strSQL As String

    Public Shared Function funGetLista_Tienda_MC() As DataTable
        '-- Listado de Acciones de Personal
        Dim Parametros As New List(Of SqlParameter)
        Dim dt As New DataTable
        '--
        strSQL = "SELECT * FROM vw_GB_Cat_Tienda ORDER BY Suc_Nombre"
        dt = clsData.ExecuteQuery(strSQL, Parametros)
        Return dt
    End Function


    Public Shared Function funGetLista_Tienda_Full() As DataTable
        '-- Listado de Acciones de Personal
        Dim Parametros As New List(Of SqlParameter)
        Dim dt As New DataTable
        '--
        strSQL = "SELECT * FROM vw_GB_Cat_Tienda_Full ORDER BY Suc_Nombre"
        dt = clsData.ExecuteQuery(strSQL, Parametros)
        Return dt
    End Function
End Class
