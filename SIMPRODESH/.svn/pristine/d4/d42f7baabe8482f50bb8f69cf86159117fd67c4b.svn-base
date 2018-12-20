Public Class frmConsultaArticulosDesc

    Private Sub frmConsultaArticulosDesc_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Sub cargaarticulo()
        Dim sqlcomando As New OleDb.OleDbCommand
        Dim sqlstring As String
        Try
            abrirconexion()
            sqlstring = "select a.Articulo_Id 'Articulo', a.Articulo_Nombre 'Nombre' from dbo.Articulo a (nolock)  where a.Articulo_Nombre like " + por(txtNomArt.Text) + " order by a.Articulo_Nombre"
            sqlcomando.CommandText = sqlstring
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            Dim dt As New DataTable
            dt.Load(sqlcomando.ExecuteReader)
            dgvArt.DataSource = dt
            txtNomArt.Focus()
            cerrarconexion()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cerrarconexion()
        End Try
    End Sub

    Private Sub txtNomArt_TextChanged(sender As Object, e As EventArgs) Handles txtNomArt.TextChanged
        dgvArt.DataSource = vbNullString
        dgvArt.Rows.Clear()
    End Sub

    Private Sub dgvArt_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvArt.CellDoubleClick
        Dim i As Integer
        i = dgvArt.CurrentRow.Index
        codigoart = dgvArt.Item(0, i).Value()
        nombreart = dgvArt.Item(1, i).Value()
        Close()
    End Sub

    Private Sub dgvArt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvArt.KeyPress
    End Sub
    Protected Overloads Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, keyData As System.Windows.Forms.Keys) As Boolean
        '
        ' Si el control DataGridView no tiene el foco, 
        ' se abandonamos el procedimiento, llamando al metodo base
        '
        If (Not dgvArt.Focused) Then
            Return MyBase.ProcessCmdKey(msg, keyData)
        End If

        '
        ' Si la tecla presionada es distinta al ENTER, 
        ' se abandonamos el procedimiento, llamando al metodo base
        '
        If keyData <> Keys.Enter Then
            Return MyBase.ProcessCmdKey(msg, keyData)
        End If
        Dim row As DataGridViewRow = dgvArt.CurrentRow
        Dim i As Integer
        i = dgvArt.CurrentRow.Index
        codigoart = dgvArt.Item(0, i).Value()
        nombreart = dgvArt.Item(1, i).Value()
        Close()
        Return True
    End Function

    Private Sub txtNomArt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNomArt.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            cargaarticulo()
        End If

    End Sub

    Private Sub dgvArt_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvArt.CellContentClick

    End Sub
End Class