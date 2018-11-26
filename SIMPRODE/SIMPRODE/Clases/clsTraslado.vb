Imports System.Data
Imports System.Data.SqlClient

Public Class clsTraslado

    Public Shared Sub funGetTraslado(ByVal nparDocumento As Integer)

        '-- Ejecutamos SP para actualizar saldo de los debitos dentro de una transaccion
        If DBConnGlobal.State = ConnectionState.Open Then
        Else
            DBConnGlobal = New SqlConnection(funConexion())
            DBConnGlobal.Open()
        End If

        Dim cmd As SqlCommand = New SqlCommand("sp_Traslado", DBConnGlobal)

        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@documento", nparDocumento)

        cmd.Connection = DBConnGlobal
        cmd.Transaction = transaccionGlobal
        cmd.ExecuteNonQuery()
        DBConnGlobal.Close()
        '--

    End Sub


    Public Shared Sub funGetTrasladoSIN(ByVal nparDocumento As Integer)

        '-- Ejecutamos SP para actualizar saldo de los debitos dentro de una transaccion
        If DBConnGlobal.State = ConnectionState.Open Then
        Else
            DBConnGlobal = New SqlConnection(funConexion())
            DBConnGlobal.Open()
        End If

        Dim cmd As SqlCommand = New SqlCommand("sp_Traslado_SIN", DBConnGlobal)

        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@documento", nparDocumento)

        cmd.Connection = DBConnGlobal
        cmd.Transaction = transaccionGlobal
        cmd.ExecuteNonQuery()
        DBConnGlobal.Close()
        '--

    End Sub

    Public Shared Sub funGetTrasladoEntrada(ByVal nparDocumento As Integer)

        '-- Ejecutamos SP para actualizar saldo de los debitos dentro de una transaccion
        If DBConnGlobal.State = ConnectionState.Open Then
        Else
            DBConnGlobal = New SqlConnection(funConexion())
            DBConnGlobal.Open()
        End If

        Dim cmd As SqlCommand = New SqlCommand("sp_Traslado_Entrada", DBConnGlobal)

        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@documento", nparDocumento)

        cmd.Connection = DBConnGlobal
        cmd.Transaction = transaccionGlobal
        cmd.ExecuteNonQuery()
        DBConnGlobal.Close()
        '--

    End Sub

    Public Shared Sub funGetTrasladoLocal(ByVal nparDocumento As Integer)

        '-- Ejecutamos SP para actualizar saldo de los debitos dentro de una transaccion
        If DBConnGlobal.State = ConnectionState.Open Then
        Else
            DBConnGlobal = New SqlConnection(funConexion())
            DBConnGlobal.Open()
        End If

        Dim cmd As SqlCommand = New SqlCommand("sp_Traslado_Local", DBConnGlobal)

        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@documento", nparDocumento)

        cmd.Connection = DBConnGlobal
        cmd.Transaction = transaccionGlobal
        cmd.ExecuteNonQuery()
        DBConnGlobal.Close()
        '--

    End Sub
    'Public Shared Sub funAplicaSaldo(ByVal nparTransaction As Integer,
    '                                    ByVal nparTransactionAplica As Integer,
    '                                    ByVal nparTramoUnico As Integer)

    '    '-- Ejecutamos SP para actualizar saldo de los debitos dentro de una transaccion
    '    Dim cmd As SqlCommand = New SqlCommand("spRecCxcSaldoUpdate", DBConnGlobal)

    '    cmd.CommandType = CommandType.StoredProcedure

    '    cmd.Parameters.AddWithValue("@Transaction", nparTransaction)
    '    cmd.Parameters.AddWithValue("@TransactionAplica", nparTransactionAplica)
    '    cmd.Parameters.AddWithValue("@TramoUnico", nparTramoUnico)

    '    cmd.Connection = DBConnGlobal
    '    cmd.Transaction = transaccionGlobal
    '    cmd.ExecuteNonQuery()
    '    '--
    'End Sub



End Class
