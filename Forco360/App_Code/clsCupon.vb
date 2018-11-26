Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic


Public Class clsCupon
    Public Shared strSQL As String

    Public Shared Function funGetLista_Cupones() As DataTable
        '-- Listado de Cupones
        Dim Parametros As New List(Of SqlParameter)
        Dim dt As New DataTable
        '--
        strSQL = "SELECT * FROM vw_GB_Cupon_Browse ORDER BY nNumero"
        dt = clsData.ExecuteQuery(strSQL, Parametros)
        Return dt
    End Function

    Public Shared Function funGetLista_CuponesDetalle(ByVal nparNumero As Integer) As DataTable
        '-- Listado de Sub Tipo
        Dim Parametros As New List(Of SqlParameter)
        Parametros.Add(New SqlParameter("@numero", nparNumero))
        '--
        Dim dt As New DataTable
        '-- 
        strSQL = "SELECT * FROM vw_GB_Cupon_Lista WHERE nNumero = @numero"
        '--
        dt = clsData.ExecuteQuery(strSQL, Parametros)
        '--
        Return dt
        '--
    End Function

    Public Shared Function funConsecutivo() As Integer
        '-- Calcula el numero consecutivo
        strSQL = "SELECT ISNULL(MAX(nNumero), 0) + 1 FROM RH_Cupon"
        '--
        Dim nNumero As Integer = clsForcoHelper.funGetValor(strSQL)
        Return nNumero
        '--
    End Function

    Public Shared Function funGetCombo_Cupon_Tipo() As DataTable
        '-- Listado de tipos de cupones
        Dim Parametros As New List(Of SqlParameter)
        Dim dt As New DataTable
        '-- 
        strSQL = "SELECT * FROM CAT_Cupon_Tipo"
        '--
        dt = clsData.ExecuteQuery(strSQL, Parametros)
        '--
        Return dt
        '--
    End Function

    Public Shared Function funGetCombo_Cupon_Concepto() As DataTable
        '-- Listado de tipos de conceptos
        Dim Parametros As New List(Of SqlParameter)
        Dim dt As New DataTable
        '-- 
        strSQL = "SELECT * FROM CAT_Cupon_Concepto"
        '--
        dt = clsData.ExecuteQuery(strSQL, Parametros)
        '--
        Return dt
        '--
    End Function

End Class
