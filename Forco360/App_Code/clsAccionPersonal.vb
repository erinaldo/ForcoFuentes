Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Public Class clsAccionPersonal
    Public Shared strSQL As String

    Public Shared Function funGetLista_AccionPersonal() As DataTable
        '-- Listado de Acciones de Personal
        Dim Parametros As New List(Of SqlParameter)
        Dim dt As New DataTable
        '--
        strSQL = "SELECT * FROM vw_Accion_Personal_Browse ORDER BY nCode"
        dt = clsData.ExecuteQuery(strSQL, Parametros)
        Return dt
    End Function

    Public Shared Function funConsecutivo() As Integer
        '-- Calcula el numero consecutivo
        strSQL = "SELECT ISNULL(MAX(nCode), 0) + 1 FROM RH_AccionPersonal"
        '--
        Dim nNumero As Integer = clsForcoHelper.funGetValor(strSQL)
        Return nNumero
        '--
    End Function

    Public Shared Function funGetCombo_Accion_Personal() As DataTable
        '-- Listado de Acciones de Personal
        Dim Parametros As New List(Of SqlParameter)
        Dim dt As New DataTable
        '-- 
        strSQL = "SELECT * FROM CAT_Accion_Personal"
        '--
        dt = clsData.ExecuteQuery(strSQL, Parametros)
        '--
        Return dt
        '--
    End Function

    Public Shared Function funGetCombo_Status() As DataTable
        '-- Listado de Status
        Dim Parametros As New List(Of SqlParameter)
        Dim dt As New DataTable
        '-- 
        strSQL = "SELECT * FROM CAT_Accion_Personal_Status"
        '--
        dt = clsData.ExecuteQuery(strSQL, Parametros)
        '--
        Return dt
        '--
    End Function

    Public Shared Function funGetCombo_Status_Nuevo() As DataTable
        '-- Listado de Status
        Dim Parametros As New List(Of SqlParameter)
        Dim dt As New DataTable
        '-- 
        strSQL = "SELECT * FROM CAT_Accion_Personal_Status WHERE nCode > 1"
        '--
        dt = clsData.ExecuteQuery(strSQL, Parametros)
        '--
        Return dt
        '--
    End Function

    Public Shared Function funGetCombo_Accion_Personal_SubTipo(ByVal nparAccion As Integer) As DataTable
        '-- Listado de Sub Tipo
        Dim Parametros As New List(Of SqlParameter)
        Parametros.Add(New SqlParameter("@accion", nparAccion))
        '--
        Dim dt As New DataTable
        '-- 
        strSQL = "SELECT * FROM CAT_Accion_Personal_Sub_Tipo WHERE nCode_Accion = @accion"
        '--
        dt = clsData.ExecuteQuery(strSQL, Parametros)
        '--
        Return dt
        '--
    End Function

    Public Shared Function funGetCombo_Accion_Personal_SubTipo_All() As DataTable
        '-- Listado de Acciones de Personal
        Dim Parametros As New List(Of SqlParameter)
        '--
        Dim dt As New DataTable
        '-- 
        strSQL = "SELECT * FROM CAT_Accion_Personal_Sub_Tipo"
        '--
        dt = clsData.ExecuteQuery(strSQL, Parametros)
        '--
        Return dt
        '--
    End Function

End Class
