Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Net


Module modRutinas

    Public strUser As String
    Public strSQL As String
    Public strQuery As String
    '--
    Public DBConnGlobal As SqlConnection
    Public transaccionGlobal As SqlTransaction
    '-- Conexión a la Base de Datos
    Public strConexion As String = ""
    Public strServidor As String = ""
    Public strBaseDatos As String = ""
    Public strUserSql As String = ""
    Public strKey As String = ""
    Public strCnxConfianza As String = ""


    Function funFechaSql(ByVal Fecha As String,
              Optional ByVal bSoloFecha As Boolean = False) As String
        'Devuelve un string de Fecha en el formato yyyymmdd
        Dim strResultado As String = ""
        If IsDate(Fecha) Then
            strResultado = CDate(Fecha).Year &
                            Format(CDate(Fecha).Month, "00") &
                            Format(CDate(Fecha).Day, "00")
            If bSoloFecha = False Then
                strResultado += Space(1) &
                            Format(CDate(Fecha).Hour, "00") & ":" &
                            Format(CDate(Fecha).Minute, "00") & ":" &
                            Format(CDate(Fecha).Second, "00") & "." &
                            Format(CDate(Fecha).Millisecond, "000")
            End If
        End If
        Return strResultado
    End Function


    Public Function funConexion() As String
        '--
        If Len(Trim(strConexion)) = 0 Then
            '--
            strServidor = "192.168.0.11"
            strUserSql = "sa"
            strKey = "M28y05b07"
            strBaseDatos = "FORCO_APPS"
            strConexion = "server=" & strServidor & ";Initial Catalog=" & strBaseDatos & ";User Id=" & strUserSql & ";Password=" & strKey & ";"
            '--
        End If
        '--
        Return strConexion
    End Function

End Module
