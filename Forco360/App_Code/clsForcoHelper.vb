Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

Public Class clsForcoHelper
    '--
    Public Shared strUser As String
    Public Shared strSQL As String
    Public Shared strQuery As String
    '--
    Public Shared arrCampos As New ArrayList
    Public Shared arrTipos As New ArrayList
    Public Shared arrValorAnterior As New ArrayList
    Public Shared arrValorActual As New ArrayList
    '-- 
    Public Shared DBConnGlobal As SqlConnection
    Public Shared transaccionGlobal As SqlTransaction
    '--
    Public Shared strConexion As String = ""
    Public Shared strServidor As String = ""
    Public Shared strBaseDatos As String = ""
    Public Shared strUserSql As String = ""
    Public Shared strKey As String = ""
    Public Shared strCnxConfianza As String = ""
    '-- 

    Public Shared Function funFechaServer() As Date
        Dim strSQL As String = "SELECT GETDATE()"
        Dim db As New SqlConnection(funConexion())
        Dim cmd As New SqlCommand(strSQL, db)
        db.Open()
        funFechaServer = Convert.ToDateTime(cmd.ExecuteScalar)
        db.Close()
    End Function

    Public Shared Function GetComputerName() As String
        Dim ComputerName As String
        ComputerName = System.Net.Dns.GetHostName
        Return ComputerName
    End Function

    Public Shared Function funNull2Val(ByVal strValor As Object) As Double
        If IsDBNull(strValor) Then
            Return 0
        Else
            Dim strTemp = Trim(Convert.ToString(strValor))
            If IsNumeric(strTemp) Then
                Return CDbl(strTemp)
            Else
                Return 0
            End If
        End If
    End Function

    Public Shared Function funFechaSql(ByVal Fecha As String, Optional ByVal bSoloFecha As Boolean = False) As String
        'Devuelve un string de Fecha en el formato yyyymmdd
        Dim strResultado As String = ""
        If IsDate(Fecha) Then
            strResultado = CDate(Fecha).Year & _
                            Format(CDate(Fecha).Month, "00") & _
                            Format(CDate(Fecha).Day, "00")
            If bSoloFecha = False Then
                strResultado += Space(1) & _
                            Format(CDate(Fecha).Hour, "00") & ":" & _
                            Format(CDate(Fecha).Minute, "00") & ":" & _
                            Format(CDate(Fecha).Second, "00") & "." & _
                            Format(CDate(Fecha).Millisecond, "000")
            End If
        End If
        Return strResultado
    End Function

    Public Shared Function funGetValor(ByVal strQuery As String) As String
        '--
        Dim db As New SqlConnection(funConexion())
        Dim cmd As New SqlCommand(strQuery, db)
        '--
        db.Open()
        funGetValor = cmd.ExecuteScalar
        db.Close()
        '--
    End Function

    Public Shared Function funFillDataSet(ByVal strSql As String) As DataSet
        Dim ds As New DataSet()
        Dim DBConn As New SqlConnection(funConexion())
        Dim DBCommand As New SqlDataAdapter(strSql, DBConn)
        DBCommand.SelectCommand.CommandType = CommandType.Text
        DBCommand.Fill(ds, "Tabla")
        DBConn.Close()
        Return ds
    End Function

    Public Shared Function funRunSQLTransaccion(ByVal strSQL As String) As Boolean
        Dim cmd As New SqlCommand(strSQL, DBConnGlobal)
        cmd.Connection = DBConnGlobal
        cmd.Transaction = transaccionGlobal
        cmd.ExecuteNonQuery()
        Return True
    End Function

    Public Shared Function funAddCampo(ByVal strCampo As String, ByVal strValorActual As String, Optional ByVal strValorAnterior As String = "") As Boolean
        '-- Obtiene el valor actual y anterior de un campo
        arrCampos.Add(strCampo)
        'arrTipos.Add(xTipo)
        arrValorAnterior.Add(strValorAnterior)
        arrValorActual.Add(strValorActual)
        '--
        Return True
    End Function

    Public Shared Function funParametrosGrabacionTransaccion(ByVal strTabla As String, _
                                                             ByVal strCampoLlave As String, _
                                                             ByVal nTipo As Integer, _
                                                             Optional ByVal nRecno As Integer = 0, _
                                                             Optional ByVal nCabecera As Integer = 0, _
                                                             Optional ByVal nPista As Integer = 1) As Boolean

        'nTipo = 1-Nuevo, 2-Edición
        Dim I As Integer
        Dim nCambios As Integer
        Dim strSQL As String = ""
        If nTipo = 1 Then
            nCambios = 1
            strSQL = "INSERT INTO " & strTabla & "("
            For I = 0 To arrCampos.Count - 1
                strSQL += IIf(I >= 1, ",", "")
                strSQL += arrCampos(I)
            Next
            strSQL += ") VALUES ("
            For I = 0 To arrCampos.Count - 1
                strSQL += IIf(I >= 1, ",", "")
                strSQL += "'" & Trim(arrValorActual(I)) & "'"
            Next
            strSQL += ") "
            '-- Debug.Print(strSQL)
        Else
            nCambios = 0
            strSQL = "UPDATE " & strTabla & " SET "
            For I = 0 To arrCampos.Count - 1
                If arrValorActual(I) <> arrValorAnterior(I) Then
                    strSQL += IIf(nCambios >= 1, ",", "")
                    strSQL += arrCampos(I) & " = '" & Trim(arrValorActual(I)) & "'"
                    nCambios += 1
                End If
            Next

            'If nRecno <> 0 Then
            '    strSQL += " WHERE " & strCampoLlave & " = " & nRecno
            'Else
            strSQL += " WHERE " & strCampoLlave
            'End If
            '-- Debug.Print(strSQL)
        End If

        If nCambios = 0 Then 'NO HAY NINGUN CAMBIO
        Else
            funRunSQLTransaccion(strSQL)
            '-- Temporalmente
            'If nPista = 1 Then ' Solo graba pista cuando es 1
            '    If nTipo = 2 Then
            '        For I = 0 To arrCampos.Count - 1
            '            funSetTrace(strTabla, nRecno, arrCampos(I), Mid(arrValorAnterior(I), 1, 150), Mid(arrValorActual(I), 1, 150), nCabecera)
            '        Next
            '    End If
            'End If
        End If

        arrCampos.Clear()
        arrValorAnterior.Clear()
        arrValorActual.Clear()
        Return True
    End Function

    Public Shared Function funSetTrace(ByVal strTable As String, _
                                       ByVal strKey As String, _
                                       ByVal strField As String, _
                                       ByVal strOldValue As String, _
                                       ByVal strNewValue As String, _
                                       Optional ByVal nCabecera As Integer = 0) As Boolean

        'actualiza la pista de auditoría
        If strOldValue <> strNewValue Then
            Dim strSQL = "INSERT INTO TRACE(nTraceRecNo, strUsuario, strTabla, strCampo, " & _
                         "strValorAnterior, strValorActual, nCabecera) VALUES ( '" & _
                strKey & "', '" & _
                strUser & "', '" & _
                strTable & "', '" & _
                strField & "', '" & _
                strOldValue & "', '" & _
                strNewValue & "', '" & _
                nCabecera & "')"

            'If IsNothing(DBConnGlobal) Then
            '    DBConnGlobal = New SqlConnection(funConexion())
            '    DBConnGlobal.Open()
            'End If
            Try
                If DBConnGlobal.State = ConnectionState.Open Then
                Else
                    DBConnGlobal = New SqlConnection(funConexion())
                    DBConnGlobal.Open()
                End If
            Catch ex As Exception
                DBConnGlobal = New SqlConnection(funConexion())
                DBConnGlobal.Open()
            End Try

            Dim cmd As New SqlCommand(strSQL, DBConnGlobal)
            cmd.Connection = DBConnGlobal
            cmd.Transaction = transaccionGlobal
            cmd.ExecuteNonQuery()
            funSetTrace = True
        End If
    End Function

    Public Shared Sub LimpiarCampos()
        arrCampos.Clear()
        arrValorAnterior.Clear()
        arrValorActual.Clear()
    End Sub

    Public Shared Function funConexion() As String
        '--
        If Len(Trim(strConexion)) = 0 Then
            '-- SERVER DB FORCODC
            strServidor = "FORCODC"
            strUserSql = "sa"
            strKey = "M28y05b07"
            strBaseDatos = "FORCO360"
            strConexion = "server=" & strServidor & ";Initial Catalog=" & strBaseDatos & ";User Id=" & strUserSql & ";Password=" & strKey & ";"
            '-- SERVER LOCAL
            'strServidor = "DESKTOP-68988NE"
            'strUserSql = "sa"
            'strKey = "1"
            'strBaseDatos = "FORCO360"
            'strConexion = "server=" & strServidor & ";Initial Catalog=" & strBaseDatos & ";User Id=" & strUserSql & ";Password=" & strKey & ";"
        End If
        '--
        Return strConexion
    End Function

    Public Shared Sub AbrirConexionGlobal()
        DBConnGlobal = New SqlConnection(funConexion())
        DBConnGlobal.Open()
        transaccionGlobal = DBConnGlobal.BeginTransaction
    End Sub

End Class
