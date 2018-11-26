Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Public Class clsSeguridad
    Public Shared strSQL As String

    Public Shared Function funComprobarUsuario(ByVal cparUsuario As String, ByVal cparContrasena As String) As Boolean
        '-- Valida Usuario
        Try
            Dim Parametros As New List(Of SqlParameter)
            Parametros.Add(New SqlParameter("@usuario", cparUsuario))
            Parametros.Add(New SqlParameter("@contrasena", cparContrasena))
            '--
            Dim dt As New DataTable
            '-- 
            strSQL = "SELECT s.Usuario_Id, s.Usuario_Nombre, CASE WHEN u.UsuarioPassword = (SELECT hashbytes('md5', cast(@contrasena as VARCHAR))) " & _
                        " AND s.Usuario_Login = @usuario THEN 'Bien' END 'Seguro' " & _
                        " FROM Seg_Usuario s (nolock), Usuario_MYM u (nolock) WHERE s.Usuario_Id = u.Usuario_Id AND s.Usuario_Login = @usuario"
            '--
            dt = clsData.ExecuteQuery(strSQL, Parametros)
            '--
            If dt.Rows.Count > 0 And dt.Rows(0).Item("Seguro").ToString = "Bien" Then
                Return True
            Else
                Return False
            End If
            '--
        Catch ex As Exception
            Return False
        End Try
        '--
    End Function

    Public Shared Function funGetUsuarioInformacion(ByVal cparUsuario As String) As DataTable
        '--
        Dim Parametros As New List(Of SqlParameter)
        Parametros.Add(New SqlParameter("@usuario", cparUsuario))
        '--
        Dim dt As DataTable
        '--
        strSQL = "SELECT * FROM vw_GB_Usuarios WHERE Usuario_Login = @usuario"
        '--"
        dt = clsData.ExecuteQuery(strSQL, Parametros)
        '--
        Return dt
        '--
    End Function

End Class
