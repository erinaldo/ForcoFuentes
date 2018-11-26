Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Public Class clsData
    Private Shared mConnection As SqlConnection = Nothing
    Private Shared mTransaction As SqlTransaction = Nothing

    Public Sub New()
    End Sub

    Public Shared ReadOnly Property Connection() As SqlConnection
        Get
            Return mConnection
        End Get
    End Property

    Private Shared Sub OpenConnection()
        If mConnection Is Nothing Then
            mConnection = New SqlConnection(clsForcoHelper.funConexion())
            mConnection.Open()
        ElseIf mConnection.State = ConnectionState.Closed Then
            mConnection.Open()
        End If
    End Sub

    Private Shared Sub CloseConnection()
        If mConnection IsNot Nothing Then
            mConnection.Close()
        End If
    End Sub

    Public Shared Sub BeginTransaction()
        OpenConnection()
        mTransaction = mConnection.BeginTransaction()
    End Sub

    Public Shared Sub CommitTransaction()
        mTransaction.Commit()
        CloseConnection()
    End Sub

    Public Shared Sub RollbackTransaction()
        mTransaction.Rollback()
        CloseConnection()
    End Sub

    Public Shared Function ExecuteQuery(ByVal sqlText As String, Optional ByVal Parametros As IList(Of SqlParameter) = Nothing) As DataTable
        Dim ds As New DataSet
        Dim adapter As SqlDataAdapter
        Try
            OpenConnection()
            Dim comando As SqlCommand
            If mTransaction Is Nothing Then
                comando = New SqlCommand(sqlText, Connection)
            Else
                comando = New SqlCommand(sqlText, Connection, mTransaction)
            End If
            If Parametros IsNot Nothing Then
                For Each param As SqlParameter In Parametros
                    comando.Parameters.Add(param)
                Next
            End If
            adapter = New SqlDataAdapter(comando)
            adapter.Fill(ds)
        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Critical)
            MsgBox(ex.StackTrace)
        End Try
        Return ds.Tables(0)
        ds.Dispose()
    End Function

    Public Shared Sub ExecuteNonQuery(ByVal sqlText As String, Optional ByVal Parametros As IList(Of SqlParameter) = Nothing)
        Try
            OpenConnection()
            Dim comando As SqlCommand
            If mTransaction Is Nothing Then
                comando = New SqlCommand(sqlText, Connection)
            Else
                comando = New SqlCommand(sqlText, Connection, mTransaction)
            End If
            If Parametros IsNot Nothing Then
                For Each param As SqlParameter In Parametros
                    comando.Parameters.Add(param)
                Next
            End If
            comando.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Throw
        End Try
    End Sub

    Public Shared Function ExecuteScalar(ByVal sqlText As String, Optional ByVal Parametros As IList(Of SqlParameter) = Nothing)
        Try
            OpenConnection()
            Dim comando As SqlCommand
            If mTransaction Is Nothing Then
                comando = New SqlCommand(sqlText, Connection)
            Else
                comando = New SqlCommand(sqlText, Connection, mTransaction)
            End If
            If Parametros IsNot Nothing Then
                For Each param As SqlParameter In Parametros
                    comando.Parameters.Add(param)
                Next
            End If
            Return comando.ExecuteScalar()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Throw
        End Try
    End Function

    Public Shared Function ExecuteQueryDs(ByVal sqlText As String, Optional ByVal Parametros As IList(Of SqlParameter) = Nothing) As DataSet
        Try
            OpenConnection()
            Dim comando As SqlCommand
            If mTransaction Is Nothing Then
                comando = New SqlCommand(sqlText, Connection)
            Else
                comando = New SqlCommand(sqlText, Connection, mTransaction)
            End If
            If Parametros IsNot Nothing Then
                For Each param As SqlParameter In Parametros
                    comando.Parameters.Add(param)
                Next
            End If
            Dim adapter As New SqlDataAdapter(comando)
            Dim ds As New DataSet
            adapter.Fill(ds, "Tabla")
            Return ds
        Catch ex As Exception
            MsgBox("No tiene acceso al Servidor, Consulte con el Administrador !!!", MsgBoxStyle.Information, "Atención !!!")
            MsgBox(ex.StackTrace)

            Throw
        End Try
    End Function

End Class
