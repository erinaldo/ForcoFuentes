Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Public Class clsUsuario
    Public Shared strSQL As String

    Public Shared Function funGet_Usuario_Id(ByVal cparUsuario As String) As DataSet
        '-- GB (10-01-2017): Obtiene el ID del usuario.
        Dim Parametros As New List(Of SqlParameter)
        Parametros.Add(New SqlParameter("@usuario", cparUsuario))
        '--
        Dim ds As New DataSet
        '-- 
        strSQL = "SELECT * FROM vw_GB_Usuarios WHERE Usuario_Login = @usuario"
        '--
        ds = clsData.ExecuteQueryDs(strSQL, Parametros)
        '--
        Return ds
        '--
    End Function

End Class
