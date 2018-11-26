Public Class frmLogin

    Private Sub btncancelar_Click(sender As Object, e As EventArgs) Handles btncancelar.Click
        Application.Exit()

    End Sub
    Dim rol As String

    Public Seguridad As New Seguridad.EncriptarClave

    Private Sub btnaceptar_Click(sender As Object, e As EventArgs) Handles btnaceptar.Click
        iniciarsesion()

    End Sub
    Public Sub iniciarsesion()
        Dim c_usuario As OleDb.OleDbDataReader
        Dim sqlcomando As New OleDb.OleDbCommand
        Dim sqlstring As String
        Dim login As Integer
        Dim usuario As Short
        Try
            abrirconexion()
            sqlstring = "select s.Usuario_Id,s.Usuario_Nombre,CASE  WHEN u.UsuarioPassword =(SELECT hashbytes('md5', '" & txtContraseña.Text & "')) AND s.Usuario_Login='" & txtUsuario.Text & "' THEN 'Bien' END 'Seguro' from Seg_Usuario s (nolock), Usuario_MYM u (nolock) where s.Usuario_Id=u.Usuario_Id and s.Usuario_Login=" & com(txtUsuario.Text)
            sqlcomando.CommandText = sqlstring
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            c_usuario = sqlcomando.ExecuteReader
            If c_usuario.HasRows = True Then
                While c_usuario.Read
                    If "Bien" = c_usuario.Item("Seguro").ToString() Then
                        Dim frm As New frmPrincipal
                        usuario = c_usuario.Item("Usuario_Id")
                        frm._usuario = c_usuario.Item("Usuario_Nombre").ToString()
                        cargarpermisos(usuario)
                        inicioempresa = cbEmpresa.SelectedValue
                        '-- Usuario publico
                        strUser = Me.txtUsuario.Text
                        Visible = False
                        login += 1
                        frm.Show()
                        Return
                    End If
                End While
                cerrarconexion()

            End If
            If (login = 0) Then
                MessageBox.Show("Por favor digite un Usuario y Contraseña validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtContraseña.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cerrarconexion()

        End Try
    End Sub
    Public Sub cargarpermisos(ByRef usuario As Short)
        Dim c_permisos As OleDb.OleDbDataReader
        Dim c_permisosseguridad As OleDb.OleDbDataReader
        Dim sqlcomando As New OleDb.OleDbCommand
        Dim sqlstring As String
        Dim sqlcomando2 As New OleDb.OleDbCommand
        Dim sqlstring2 As String
        Dim sqlcomando3 As New OleDb.OleDbCommand
        Dim sqlstring3 As String
        Dim sqlcomando4 As New OleDb.OleDbCommand
        Dim sqlstring4 As String
        Try
            sqlstring = "select Modulo_Id,Menu_Id,Opcion_Id from Seg_Menu_Opciones_x_Usuario (nolock) where Usuario_Id=" & usuario
            sqlcomando.CommandText = sqlstring
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            c_permisos = sqlcomando.ExecuteReader
            If c_permisos.HasRows = True Then
                While c_permisos.Read
                    If c_permisos.Item("Modulo_Id").ToString() = "1" And c_permisos.Item("Menu_Id").ToString() = "115" And c_permisos.Item("Opcion_Id").ToString() = "4" Then
                        permdescuentos = True
                    End If
                    If c_permisos.Item("Modulo_Id") = 1 And c_permisos.Item("Menu_Id") = 122 And c_permisos.Item("Opcion_Id") = 1 Then
                        permpromocion = True
                    End If
                    If c_permisos.Item("Modulo_Id") = 1 And c_permisos.Item("Menu_Id") = 93 And c_permisos.Item("Opcion_Id") = 1 Then
                        permlistpreci = True
                    End If
                End While
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Try
            sqlstring2 = "select Rol_Id from Seg_Usuario (nolock) where Usuario_Id=" & usuario
            sqlcomando2.CommandText = sqlstring2
            sqlcomando2.CommandType = CommandType.Text
            sqlcomando2.Connection = Conexion
            c_permisosseguridad = sqlcomando2.ExecuteReader
            If c_permisosseguridad.HasRows = True Then
                While c_permisosseguridad.Read
                    If c_permisosseguridad.Item("Rol_Id").ToString() = "2" Then
                        ManejoUsuario = True
                    End If
                    rol = c_permisosseguridad.Item("Rol_Id").ToString()
                End While
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Try
            sqlstring3 = "select Usuario_Muestra_Costos from Seg_Usuario (nolock) where Usuario_Id=" & usuario
            sqlcomando3.CommandText = sqlstring3
            sqlcomando3.CommandType = CommandType.Text
            sqlcomando3.Connection = Conexion
            c_permisosseguridad = sqlcomando3.ExecuteReader
            If c_permisosseguridad.HasRows = True Then
                While c_permisosseguridad.Read
                    If c_permisosseguridad.Item("Usuario_Muestra_Costos") = True Then
                        muestracostos = True
                    End If
                End While
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Try
            sqlstring4 = "select s.Menu_Id, s.Modulo_Id from Seg_Menu_x_Rol s (nolock) where s. Rol_Id=" & com(rol)
            sqlcomando4.CommandText = sqlstring4
            sqlcomando4.CommandType = CommandType.Text
            sqlcomando4.Connection = Conexion
            c_permisosseguridad = sqlcomando4.ExecuteReader
            If c_permisosseguridad.HasRows = True Then
                While c_permisosseguridad.Read
                    If c_permisosseguridad.Item("Menu_Id") = 43 And c_permisosseguridad.Item("Modulo_Id") = 3 Then
                        consuexistenci = True
                    End If
                End While
                cerrarconexion()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cerrarconexion()
        End Try
    End Sub
    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '--
        Application.EnableVisualStyles()
        '-- Skin DevExpress
        funDevExpress()
        '--
        'Me.Cursor = Cursors.WaitCursor
        '-- Para el modelo de conexion configurada
        'funGetVariablesConexion()
        '--
        'If funCheckConexion() = 0 Then
        'Using f As New frmConexion
        'f.ShowDialog()
        'End Using
        'If funCheckConexion() = 0 Then
        'Me.Close()
        'End If
        'End If
        '--
        'Me.Cursor = Cursors.Default
        '--
        cargarempresa()
        limpiar()
        '-- En desarrollo no digitar cuenta
        If GetComputerName() = "DEVELOPER" Then
            txtUsuario.Text = "gbetanco"
            txtContraseña.Text = "sheridan@2016"
        End If
        'txtContraseña.Clear()
        'txtUsuario.Clear()

    End Sub
    Private Sub limpiar()
        permdescuentos = False
        permlistpreci = False
        permpromocion = False
        muestracostos = False
        ManejoUsuario = False
        consuexistenci = False
    End Sub
    Private Sub cargarempresa()

        Dim sqlcomando As New OleDb.OleDbCommand
        Dim sqlstring As String

        Try
            abrirconexion()
            sqlstring = "select e.Emp_Id,e.Emp_Nombre from dbo.Empresa e (nolock)"
            sqlcomando.CommandText = sqlstring
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            Dim dt As New DataTable
            dt.Load(sqlcomando.ExecuteReader)
            cbEmpresa.DataSource = dt
            cbEmpresa.ValueMember = dt.Columns("Emp_Id").ToString()
            cbEmpresa.DisplayMember = dt.Columns("Emp_Nombre").ToString()

            cerrarconexion()
            'cargarpromociones(Convert.ToInt16(inicioempresa))
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cerrarconexion()
        End Try

    End Sub
    Private Sub txtContraseña_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContraseña.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            iniciarsesion()
        End If
    End Sub

    Function funDevExpress()
        DevExpress.UserSkins.OfficeSkins.Register()
        DevExpress.UserSkins.BonusSkins.Register()
        Return True
    End Function

End Class
