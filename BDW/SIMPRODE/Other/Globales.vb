Module Globales
#Region "Variables Globales"
    Public Conexion As New OleDb.OleDbConnection
    Public Conexion2 As New OleDb.OleDbConnection
    Public promocion As Short
    Public idart As String
    Public codigoart As String
    Public codigo As String
    Public nombreart As String
    Public codclient As String
    Public nomclient As String
    Public empresa As String
    Public inicioempresa As String
    Public descuento As String
    Public promociones As String
    Public listapr As String
    Public tipo As Integer
    Public filtros As String
    Public conexionRH As Boolean
    Public conexionEKO As Boolean
#End Region
#Region "VariablesPermisos"
    Public permdescuentos As Boolean = False
    Public permpromocion As Boolean = False
    Public permlistpreci As Boolean = False
    Public ManejoUsuario As Boolean = False
    Public muestracostos As Boolean = False
    Public consuexistenci As Boolean = False
#End Region
#Region "Funciones y Procedimientos"
    Public Function com(ByRef tira As String) As String
        com = "'" & tira & "'"
    End Function
    Public Function por(ByRef tira As String) As String
        por = "'%" & tira & "%'"
    End Function
    Public Sub abrirconexion()
        Try
            If Conexion.State = ConnectionState.Open Then
                Conexion.Close()
            Else
                Conexion.ConnectionString = "File name=" & Application.StartupPath & "\Udl\SIMPRODE.udl"
                Conexion.Open()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Public Sub abrirconexion2()
        Try
            Conexion2.ConnectionString = "File name=" & Application.StartupPath & "\Udl\SIMPRODE2.udl"
            Conexion2.Open()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Public Sub cerrarconexion()
        Conexion.Close()
        Conexion.Dispose()
        Conexion2.Close()
        Conexion2.Dispose()
    End Sub
    Public Sub llama_despliegue()
        Dim clsNew As New Showprint
        clsNew.ShowFrm()
    End Sub

#End Region
#Region "Variables Necesarias para PrintReport"
    Public rutareporte As String
    Public rutaVentas As String
    Public rutainventario As String
    Public rutanomina As String
    Public rutaCxC As String
    Public rutaConta As String
    Public rutaproduccion As String
    Public vcompania As String
    Public Vnomcia As String
    Public vusuario As String
    Public comandoledb, comandoledb1, comandoledb2, comandoledb3, comandoledb4 As New OleDb.OleDbCommand
    Public Caccesos As OleDb.OleDbDataReader
    Public Ccias As OleDb.OleDbDataReader
    Public Cbodegas As OleDb.OleDbDataReader
    Public Vbodega As String
    Public Vbodcomp1 As String
    Public Vbodcomp2 As String
    Public Especial As Boolean
    Public Sql As String
    Public Comentarios As String
    Public Vformula As String = ""
    Public rutaRH As String
#End Region
End Module
