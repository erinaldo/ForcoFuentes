Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Public Class clsProyectos
    Public Shared strSQL As String

    Public Shared Function funGetLista_PR_Detalle() As DataTable
        '-- Listado de conceptos de un proyecto
        Dim Parametros As New List(Of SqlParameter)
        '-- Parametros.Add(New SqlParameter("@depto", nparDepto))
        '--
        Dim dt As New DataTable
        '-- 
        strSQL = "SELECT TOP(50) * FROM PRY_Solicitud_Detalle"
        dt = clsData.ExecuteQuery(strSQL, Parametros)
        '--
        Return dt
        '--
    End Function


    Public Shared Function funGetCombo_PR_Estado() As DataTable
        '-- Estado de un proyecto
        Dim Parametros As New List(Of SqlParameter)
        '--
        Dim dt As New DataTable
        '-- 
        strSQL = "SELECT * FROM CAT_Proy_Status"
        '--
        dt = clsData.ExecuteQuery(strSQL, Parametros)
        '--
        Return dt
        '--
    End Function

    Public Shared Function funGetLista_Estado_Proyectos_Todos() As DataTable
        '-- Estados y Todos para OPEN.
        Dim Parametros As New List(Of SqlParameter)
        '--
        Dim dt As New DataTable
        '-- 
        strSQL = "SELECT * FROM vw_GB_Proyecto_Estado"
        '--
        dt = clsData.ExecuteQuery(strSQL, Parametros)
        '--
        Return dt
        '--
    End Function

    Public Shared Function funGetLista_PR_Proyecto() As DataTable
        '-- Lista de tipos de proyectos
        Dim Parametros As New List(Of SqlParameter)
        Dim dt As New DataTable
        '--
        strSQL = "SELECT * FROM CAT_Proy_Tipo ORDER BY nCode"
        dt = clsData.ExecuteQuery(strSQL, Parametros)
        Return dt
    End Function

    Public Shared Function funGetLista_Proyecto_All() As DataTable
        '-- Lista de tipos de proyectos
        Dim Parametros As New List(Of SqlParameter)
        Dim dt As New DataTable
        '--
        strSQL = "SELECT * FROM vw_GB_Proyectos_Tipo_All ORDER BY nCode"
        dt = clsData.ExecuteQuery(strSQL, Parametros)
        Return dt
    End Function

    Public Shared Function funGetLista_PR_Concepto() As DataTable
        '-- Listad de conceptos de proyectos
        Dim Parametros As New List(Of SqlParameter)
        Dim dt As New DataTable
        '--
        strSQL = "SELECT * FROM CAT_Proy_Concepto ORDER BY nCode"
        dt = clsData.ExecuteQuery(strSQL, Parametros)
        Return dt
    End Function

    Public Shared Function funGetLista_Proyectos_Open(ByVal nparProyecto As Integer,
                                                  ByVal nparEstado As Integer,
                                                  ByVal dparFecha1 As Date,
                                                  ByVal dparFecha2 As Date) As DataTable
        '-- 
        Dim Parametros As New List(Of SqlParameter)
        Parametros.Add(New SqlParameter("@proyecto", nparProyecto))
        Parametros.Add(New SqlParameter("@estado", nparEstado))
        Parametros.Add(New SqlParameter("@fecha1", dparFecha1))
        Parametros.Add(New SqlParameter("@fecha2", dparFecha2))
        '--
        Dim dt As New DataTable
        '-- Cuando se usa directamente el SQL, el parametro fecha se pasa como DATE.
        strSQL = "SELECT * FROM vw_GB_Proyecto_Open " &
                    " WHERE (nTipo = @proyecto OR @proyecto = 0) " &
                    " AND (nStatus = @estado OR @estado = '0') " &
                    " AND (dtmFecha BETWEEN @fecha1 AND @fecha2) " &
                    " AND nStatus <=3" &
                    " ORDER BY nNumero"
        '-- 
        dt = clsData.ExecuteQuery(strSQL, Parametros)
        '--
        Return dt
        '--
    End Function

End Class
