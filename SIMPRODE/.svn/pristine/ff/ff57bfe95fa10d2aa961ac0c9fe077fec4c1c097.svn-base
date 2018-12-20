Imports System.Data.OleDb
Public Class frmConsultaClienteNom

    Private Sub dgvArt_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvcliente.CellContentClick

    End Sub
    Public Sub cargacliente()
        Dim sqlcomando As New OleDb.OleDbCommand
        Dim sqlstring As String
        Try
            abrirconexion()
            sqlstring = " select c.Cliente_Id 'Cliente', c.Cliente_Nombre 'Nombre' from dbo.Cliente c (nolock)  where c.Cliente_Nombre like " + por(txtNomClient.Text) + " order by c.Cliente_Nombre"
            sqlcomando.CommandText = sqlstring
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            Dim dt As New DataTable
            dt.Load(sqlcomando.ExecuteReader)
            dgvcliente.DataSource = dt
            txtNomClient.Focus()
            cerrarconexion()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cerrarconexion()
        End Try
    End Sub

    Private Sub txtNomClient_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNomClient.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            cargacliente()
        End If
    End Sub

    Private Sub dgvcliente_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvcliente.CellDoubleClick
        Dim i As Integer
        i = dgvcliente.CurrentRow.Index
        codclient = dgvcliente.Item(0, i).Value()
        nomclient = dgvcliente.Item(1, i).Value()
        Close()
    End Sub

    Private Sub dgvcliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvcliente.KeyPress
    End Sub
    Protected Overloads Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, keyData As System.Windows.Forms.Keys) As Boolean
        '
        ' Si el control DataGridView no tiene el foco, 
        ' se abandonamos el procedimiento, llamando al metodo base
        '
        If (Not dgvcliente.Focused) Then
            Return MyBase.ProcessCmdKey(msg, keyData)
        End If

        '
        ' Si la tecla presionada es distinta al ENTER, 
        ' se abandonamos el procedimiento, llamando al metodo base
        '
        If keyData <> Keys.Enter Then
            Return MyBase.ProcessCmdKey(msg, keyData)
        End If
        Dim row As DataGridViewRow = dgvcliente.CurrentRow
        Dim i As Integer
        i = dgvcliente.CurrentRow.Index
        codclient = dgvcliente.Item(0, i).Value()
        nomclient = dgvcliente.Item(1, i).Value()
        Close()
        Return True
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
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
                For i = 0 To dgvcliente.SelectedRows.Count - 1
                    command.CommandText = _
                    "Insert into dbo.PV_Lista_Precios_Clientes(Cliente_Id,ListaP_Id,Emp_Id,Cliente_Fec_Actualizacion,Cliente_Estado) values(" & com(dgvcliente.SelectedRows(i).Cells(0).Value.ToString()) & "," & Convert.ToInt16(listapr) & "," & Convert.ToInt16(empresa) & ",GETDATE(),'A')"
                    command.ExecuteNonQuery()
                Next
                transaction.Commit()
                cerrarconexion()
                connection.Close()
                connection.Dispose()
                Close()
            Catch ex As Exception
                MessageBox.Show("El Cliente ya existe en la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                cerrarconexion()
                connection.Close()
                connection.Dispose()
            End Try
        End Using
    End Sub

    Private Sub txtNomClient_TextChanged(sender As Object, e As EventArgs) Handles txtNomClient.TextChanged
        dgvcliente.DataSource = vbNullString
        dgvcliente.Rows.Clear()
    End Sub

    Private Sub frmConsultaClienteNom_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class