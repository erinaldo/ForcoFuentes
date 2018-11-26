Imports System.Data.OleDb
Public Class frmManejoUsuarios
    Public tipo As Integer
    Private Sub frmManejoUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarusuariosgrid()

        GroupBox1.Enabled = False

    End Sub
    Public Sub cargarusuariosgrid()
        Dim sqlcomando As New OleDb.OleDbCommand
        Dim sqlstring As String
        Try
            abrirconexion()
            sqlstring = " select s.Usuario_Id 'Usuario', s.Usuario_Nombre 'Nombre', s.Usuario_Login 'Login',u.UsuarioPassword 'Password' from Seg_Usuario s (nolock),Usuario_mym u (nolock) where u.Usuario_Id=s.Usuario_Id order by s.Usuario_Nombre "
            sqlcomando.CommandText = sqlstring
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            Dim dt As New DataTable
            dt.Load(sqlcomando.ExecuteReader)
            dgvUsuarios.DataSource = dt
            cerrarconexion()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cerrarconexion()
        End Try
    End Sub
    Public Sub cargarusuarioscombo()

        Dim sqlcomando As New OleDb.OleDbCommand
        Dim sqlstring As String

        Try
            abrirconexion()
            sqlstring = "  select s.Usuario_Id, s.Usuario_Nombre from Seg_Usuario s (nolock) where s.Usuario_Id not in (select u.Usuario_Id from Usuario_MYM u) order by s.Usuario_Nombre"
            sqlcomando.CommandText = sqlstring
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            Dim dt As New DataTable
            dt.Load(sqlcomando.ExecuteReader)
            cb_usuarios.DataSource = dt

            cb_usuarios.ValueMember = dt.Columns("Usuario_Id").ToString()
            cb_usuarios.DisplayMember = dt.Columns("Usuario_Nombre").ToString()
            cerrarconexion()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cerrarconexion()
        End Try

    End Sub
    Public Sub cargarusuarioscombomodifica()

        Dim sqlcomando As New OleDb.OleDbCommand
        Dim sqlstring As String

        Try
            abrirconexion()
            sqlstring = "  select s.Usuario_Id, s.Usuario_Nombre from Seg_Usuario s (nolock) "
            sqlcomando.CommandText = sqlstring
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            Dim dt As New DataTable
            dt.Load(sqlcomando.ExecuteReader)
            cb_usuarios.DataSource = dt

            cb_usuarios.ValueMember = dt.Columns("Usuario_Id").ToString()
            cb_usuarios.DisplayMember = dt.Columns("Usuario_Nombre").ToString()
            cerrarconexion()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cerrarconexion()
        End Try

    End Sub
    Private Sub dgvUsuarios_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvUsuarios.CellFormatting
        If dgvUsuarios.Columns(e.ColumnIndex).Index.Equals(3) Then

            If (Not e.Value Is Nothing) Then
                e.Value = New String(CChar("*"), e.Value.ToString.Length)

            End If

        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnnuevo.Click
        btnmodifica.Enabled = False
        GroupBox1.Enabled = True
        btnnuevo.Enabled = False
        btnelimina.Enabled = False
        cb_usuarios.Enabled = True
        cargarusuarioscombo()
        tipo = 1

    End Sub
    Private Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        If tipo = 1 Then
            abrirconexion()
            Dim cadenaconexion As String
            cadenaconexion = Conexion.ConnectionString
            Using connection As New OleDbConnection(cadenaconexion)
                Dim command As New OleDbCommand()
                Dim transaction As OleDbTransaction

                ' Set the Connection to the new OleDbConnection.
                command.Connection = connection

                ' Open the connection and execute the transaction. 
                Try
                    If String.IsNullOrEmpty(txtpass.Text) = False And String.IsNullOrEmpty(txtpass2.Text) = False Then
                        If txtpass.Text = txtpass2.Text Then
                            connection.Open()
                            transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted)
                            command.Connection = connection
                            command.Transaction = transaction
                            ' Execute the commands.
                            command.CommandText = _
                            "Insert into dbo.Usuario_MYM(Usuario_Id, UsuarioPassword) values(" & com(cb_usuarios.SelectedValue.ToString()) & ", hashbytes('md5', " & com(txtpass.Text) & "))"
                            command.ExecuteNonQuery()
                            transaction.Commit()
                            cerrarconexion()
                            cargarusuariosgrid()
                            txtpass.Clear()
                            cb_usuarios.Focus()
                            txtpass2.Clear()
                            connection.Close()
                            connection.Dispose()
                            GroupBox1.Enabled = False
                            btnmodifica.Enabled = True
                            btnnuevo.Enabled = True
                            btnelimina.Enabled = True
                            cb_usuarios.SelectedValue = -1

                        Else
                            MessageBox.Show("Las contraseñas digitadas en ambos campos deben ser iguales", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            txtpass.Clear()
                            txtpass2.Clear()
                            txtpass.Focus()
                            connection.Close()
                            connection.Dispose()
                        End If
                    Else
                        MessageBox.Show("Por favor complete todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        cb_usuarios.Focus()
                        connection.Close()
                        connection.Dispose()
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                    transaction.Rollback()
                    cerrarconexion()
                    connection.Close()
                    connection.Dispose()
                End Try
            End Using
        ElseIf tipo = 2 Then
            abrirconexion()
            Dim cadenaconexion As String
            cadenaconexion = Conexion.ConnectionString
            Using connection As New OleDbConnection(cadenaconexion)
                Dim command As New OleDbCommand()
                Dim transaction As OleDbTransaction

                ' Set the Connection to the new OleDbConnection.
                command.Connection = connection

                ' Open the connection and execute the transaction. 
                Try
                    If String.IsNullOrEmpty(txtpass.Text) = False Or String.IsNullOrEmpty(txtpass2.Text) = False Then
                        If txtpass.Text = txtpass2.Text Then
                            connection.Open()
                            transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted)
                            command.Connection = connection
                            command.Transaction = transaction
                            ' Execute the commands.
                            command.CommandText = _
                            "Update  dbo.Usuario_MYM  set UsuarioPassword= hashbytes('md5', " & com(txtpass.Text) & ") where Usuario_Id=" & com(cb_usuarios.SelectedValue)
                            command.ExecuteNonQuery()
                            transaction.Commit()
                            cerrarconexion()
                            cargarusuariosgrid()
                            txtpass.Clear()
                            txtpass.Focus()
                            txtpass2.Clear()
                            connection.Close()
                            connection.Dispose()
                            GroupBox1.Enabled = False
                            btnmodifica.Enabled = True
                            btnnuevo.Enabled = True
                            btnelimina.Enabled = True
                            cb_usuarios.SelectedValue = -1

                        Else
                            MessageBox.Show("Las contraseñas digitadas en ambos campos deben ser iguales", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            txtpass.Clear()
                            txtpass2.Clear()
                            txtpass.Focus()
                            connection.Close()
                            connection.Dispose()
                        End If
                    Else
                        MessageBox.Show("Por favor complete todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        cb_usuarios.Focus()
                        connection.Close()
                        connection.Dispose()
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                    transaction.Rollback()
                    cerrarconexion()
                    connection.Close()
                    connection.Dispose()
                End Try
            End Using


        End If
    End Sub
    Private Sub btnmodifica_Click(sender As Object, e As EventArgs) Handles btnmodifica.Click

        If dgvUsuarios.Rows.Count > 0 Then
            btnmodifica.Enabled = False
            btnelimina.Enabled = False
            GroupBox1.Enabled = True
            btnnuevo.Enabled = False
            cb_usuarios.Enabled = False
            cargarusuarioscombomodifica()
            Dim i As Integer
            i = dgvUsuarios.CurrentRow.Index
            cb_usuarios.SelectedValue = dgvUsuarios.Item(0, i).Value
            txtpass.Text = dgvUsuarios.Item(3, i).Value
            txtpass2.Text = dgvUsuarios.Item(3, i).Value
            tipo = 2
        Else
            MessageBox.Show("No se tienen datos para modificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        cerrarconexion()
        GroupBox1.Enabled = False
        cb_usuarios.SelectedValue = -1
        txtpass.Clear()
        txtpass2.Clear()
        btnmodifica.Enabled = True
        btnnuevo.Enabled = True
        btnelimina.Enabled = True

    End Sub
    Private Sub btnelimina_Click(sender As Object, e As EventArgs) Handles btnelimina.Click
        Dim i As Integer
        Dim resultado As DialogResult
        i = dgvUsuarios.CurrentRow.Index
        resultado = MessageBox.Show("Desea Continuar la Eliminacion del Usuario: " + dgvUsuarios.Item(1, i).Value, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
        If resultado = Windows.Forms.DialogResult.OK Then
            abrirconexion()
            Dim cadenaconexion As String
            cadenaconexion = Conexion.ConnectionString
            Using connection As New OleDbConnection(cadenaconexion)
                Dim command As New OleDbCommand()
                Dim transaction As OleDbTransaction

                ' Set the Connection to the new OleDbConnection.
                command.Connection = connection

                ' Open the connection and execute the transaction. 
                Try
                    connection.Open()
                    transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted)
                    command.Connection = connection
                    command.Transaction = transaction
                    ' Execute the commands.
                    command.CommandText = _
                    "Delete from  dbo.Usuario_MYM where Usuario_Id=" & com(dgvUsuarios.Item(0, i).Value)
                    command.ExecuteNonQuery()
                    transaction.Commit()
                    cerrarconexion()
                    cargarusuariosgrid()
                    connection.Close()
                    connection.Dispose()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                    transaction.Rollback()
                    cerrarconexion()
                    connection.Close()
                    connection.Dispose()
                End Try
            End Using
        End If
    End Sub
End Class