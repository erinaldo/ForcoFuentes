Imports System.Data.OleDb
Imports System.IO
Public Class frmImagenes
    Dim Fmatriz() As String
    Dim Vruta As String
    Dim varchivo As String
    Private Sub txtCodArt_TextChanged(sender As Object, e As EventArgs) Handles txtCodArt.TextChanged
        txtdesc.Clear()
        Ptb_Fotos.ImageLocation = ""
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        cargar()
    End Sub

    Private Sub cargar()
        If String.IsNullOrEmpty(txtCodArt.Text) = False Then
            Try
                Dim sqlcomando As New OleDb.OleDbCommand
                Dim sqlstring As String
                Dim i As Integer
                abrirconexion()
                sqlstring = "select  a.Articulo_Id Articulo,a.Articulo_Nombre Descripcion from dbo.Articulo a  (nolock) where a.Articulo_Id=" + com(txtCodArt.Text)
                sqlcomando.CommandText = sqlstring
                sqlcomando.CommandType = CommandType.Text
                sqlcomando.Connection = Conexion
                Dim dt As New DataTable
                dt.Load(sqlcomando.ExecuteReader)
                If dt.Rows.Count > 0 Then
                    For i = 0 To dt.Rows.Count - 1
                        txtdesc.Text = dt.Rows(i)("Descripcion")
                    Next
                    cargarimagen(txtCodArt.Text)
                    txtCodArt.Focus()
                Else
                    sqlstring = "select a.Articulo_Id Articulo,a.Articulo_Nombre Descripcion from dbo.articulo a (nolock), dbo.Articulo_Equivalente e (nolock) where a.Articulo_Id= e.Articulo_Id and e.Equivalente_Id=" + com(txtCodArt.Text)
                    sqlcomando.CommandText = sqlstring
                    sqlcomando.CommandType = CommandType.Text
                    sqlcomando.Connection = Conexion
                    Dim dt2 As New DataTable
                    dt2.Load(sqlcomando.ExecuteReader)
                    If dt2.Rows.Count > 0 Then
                        For i = 0 To dt2.Rows.Count - 1
                            txtCodArt.Text = dt2.Rows(i)("Articulo")
                            txtdesc.Text = dt2.Rows(i)("Descripcion")
                        Next
                        cargarimagen(txtCodArt.Text)
                        txtCodArt.Focus()
                    Else
                        txtCodArt.Clear()
                        txtdesc.Clear()
                        MessageBox.Show("El articulo no existe en la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        txtCodArt.Focus()
                    End If

                End If
                cerrarconexion()
                btnExam.Enabled = True
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                cerrarconexion()

            End Try
        Else
            MessageBox.Show("Digite algun dato a buscar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Public Sub cargarimagen(ByRef id As String)
        Dim Carticulo_imagen As OleDb.OleDbDataReader
        Try
            Dim sqlcomando1 As New OleDb.OleDbCommand
            sqlcomando1.CommandText = "Select articulo,ruta,archivo from articulo_imagenes_mm where articulo=" & com(id)
            sqlcomando1.CommandType = CommandType.Text
            sqlcomando1.Connection = Conexion
            Carticulo_imagen = sqlcomando1.ExecuteReader
            If Carticulo_imagen.HasRows Then
                Carticulo_imagen.Read()
                Ptb_Fotos.ImageLocation = Carticulo_imagen.Item("ruta") + Carticulo_imagen.Item("archivo")
                Ptb_Fotos.Refresh()
            Else
                Ptb_Fotos.ImageLocation = ""
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub txtdesc_TextChanged(sender As Object, e As EventArgs) Handles txtdesc.TextChanged

    End Sub

    Private Sub txtCodArt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodArt.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            btnBuscar.Focus()
        End If
    End Sub

    Private Sub txtdesc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtdesc.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            btnBuscar.Focus()
        End If
    End Sub

    Private Sub frmImagenes_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.F1 Then
            Dim vent As New frmConsultaArticulosDesc
            vent.ShowDialog()
            txtCodArt.Text = codigoart
            txtdesc.Text = nombreart
            btnBuscar.Focus()
            If String.IsNullOrEmpty(txtCodArt.Text) = False Then
                cargarimagen(txtCodArt.Text)
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim vent As New frmConsultaArticulosDesc
        vent.ShowDialog()
        txtCodArt.Text = codigoart
        txtdesc.Text = nombreart
        btnBuscar.Focus()
        If String.IsNullOrEmpty(txtCodArt.Text) = False Then
            cargarimagen(txtCodArt.Text)
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles Ptb_Fotos.Click

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnExam.Click
        Try
            btnGuardar.Enabled = True
            Ofd_foto.Title = "Abrir Imagen"
            Ofd_foto.InitialDirectory = Application.StartupPath & "Fotos\"
            Ofd_foto.Filter = "Archivos de Imagen (*.jpg)|*.jpg"
            If (Ofd_foto.ShowDialog()) = Windows.Forms.DialogResult.OK Then
                Fmatriz = Ofd_foto.FileName.Split("\")
                Vruta = ""
                varchivo = Fmatriz(Fmatriz.GetUpperBound(0)).ToString
                For I = Fmatriz.GetLowerBound(0) To Fmatriz.GetUpperBound(0) - 1
                    If I = 0 Then
                        Vruta = Fmatriz(I).ToString
                    Else
                        Vruta = Vruta + "\" + Fmatriz(I).ToString
                    End If
                Next
                Vruta = Vruta + "\"
                Ptb_Fotos.ImageLocation = Ofd_foto.FileName
                Ptb_Fotos.Refresh()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub frmImagenes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnExam.Enabled = False
        btnGuardar.Enabled = False
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            abrirconexion()
            Dim Carticulo_imagenes As OleDb.OleDbDataReader
            comandoledb.CommandText = "Select articulo,ruta,archivo from articulo_imagenes_mm where articulo=" & com(txtCodArt.Text)
            comandoledb.CommandType = CommandType.Text
            comandoledb.Connection = Conexion
            Carticulo_imagenes = comandoledb.ExecuteReader
            If Carticulo_imagenes.HasRows Then
                Carticulo_imagenes.Close()
                comandoledb.CommandText = "Update articulo_imagenes_mm set ruta=" & com(Vruta) & ", archivo=" & com(varchivo) & " where articulo=" & com(txtCodArt.Text)
                comandoledb.CommandType = CommandType.Text
                comandoledb.Connection = Conexion
                comandoledb.ExecuteNonQuery()
            Else
                Carticulo_imagenes.Close()
                comandoledb.CommandText = "Insert into articulo_imagenes_mm values (" & com(txtCodArt.Text) & "," & com(Vruta) & "," & com(varchivo) & ")"
                comandoledb.CommandType = CommandType.Text
                comandoledb.Connection = Conexion
                comandoledb.ExecuteNonQuery()
            End If
            MessageBox.Show("Imagen Guardada Correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cargarimagen(txtCodArt.Text)
            Carticulo_imagenes.Close()
            btnExam.Enabled = False
            btnGuardar.Enabled = False
            cerrarconexion()
        Catch ex As Exception
            cerrarconexion()
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim resultado As DialogResult
        resultado = MessageBox.Show("Desea Continuar la eliminacion de esta foto ", "Informacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
        If resultado = Windows.Forms.DialogResult.OK Then
            abrirconexion()
            Dim cadenaconexion As String
            cadenaconexion = Conexion.ConnectionString
            Using connection As New OleDbConnection(cadenaconexion)
                Dim command As New OleDbCommand()
                Dim transaction As OleDbTransaction
                command.Connection = connection
                Try
                    connection.Open()
                    transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted)
                    command.Connection = connection
                    command.Transaction = transaction
                    command.CommandText = _
                            " delete from dbo.articulo_imagenes_mm  where articulo=" & com(txtCodArt.Text)
                    command.ExecuteNonQuery()
                    transaction.Commit()
                    cerrarconexion()
                    MessageBox.Show("Transacción realizada con exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtCodArt.Clear()
                    txtdesc.Clear()
                    Ptb_Fotos.ImageLocation = ""
                    connection.Close()
                    connection.Dispose()
                Catch ex As Exception
                    MessageBox.Show("Error al eliminar los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    transaction.Rollback()
                    cerrarconexion()
                    connection.Close()
                    connection.Dispose()
                End Try
                ' The connection is automatically closed when the 
                ' code exits the Using block. 
            End Using
        Else
            txtCodArt.Clear()
            txtdesc.Clear()
            Ptb_Fotos.ImageLocation = ""
        End If
    End Sub
End Class