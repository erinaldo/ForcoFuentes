Imports System.Data.OleDb
Imports System.IO
Public Class frmListaPrecio
    Dim ruta_archivo As String
    Private Sub dgvArticulo_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub
    Private Sub frmListaPrecio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarlista(Convert.ToInt16(inicioempresa))
    End Sub
    Public Sub articulosexistentes()
        Dim c_articulo As OleDb.OleDbDataReader
        Dim sqlcomando As New OleDb.OleDbCommand
        Dim sqlstring As String

        Try
            abrirconexion()
            sqlstring = "select a.Articulo_Nombre from dbo.Articulo a (nolock) where a.Articulo_Id=" + com(txtCodigoArt.Text)
            sqlcomando.CommandText = sqlstring
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            c_articulo = sqlcomando.ExecuteReader
            If c_articulo.HasRows = True Then
                While c_articulo.Read
                    idart = txtCodigoArt.Text
                    txtDescArt.Text = c_articulo.Item("Articulo_Nombre").ToString()
                End While
                cerrarconexion()
                txtPrecio.Focus()
            Else
                c_articulo.Close()
                sqlstring = "select a.Articulo_Nombre, a.Articulo_Id from dbo.articulo a (nolock), dbo.Articulo_Equivalente e (nolock) where a.Articulo_Id= e.Articulo_Id and e.Equivalente_Id=" + com(txtCodigoArt.Text)
                sqlcomando.CommandText = sqlstring
                sqlcomando.CommandType = CommandType.Text
                sqlcomando.Connection = Conexion
                c_articulo = sqlcomando.ExecuteReader
                If c_articulo.HasRows = True Then
                    While c_articulo.Read
                        idart = c_articulo.Item("Articulo_ID").ToString()
                        txtCodigoArt.Text = idart.ToString()
                        txtDescArt.Text = c_articulo.Item("Articulo_Nombre").ToString()
                    End While
                    txtPrecio.Focus()
                Else
                    txtDescArt.Clear()
                    txtCodigoArt.Clear()
                    MessageBox.Show("El articulo no existe en la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtCodigoArt.Focus()
                End If
                cerrarconexion()
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cerrarconexion()

        End Try
    End Sub
    Private Sub txtCodigoArt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigoArt.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            articulosexistentes()

        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Back) Or e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Delete) Then
            txtDescArt.Clear()
            txtPrecio.Clear()

        End If
    End Sub
    Private Sub cargarlista(ByRef empresa As Short)
        Dim sqlcomando As New OleDb.OleDbCommand
        Dim sqlstring As String

        Try
            abrirconexion()
            sqlstring = "select p.ListaP_Id,p.ListaP_Nombre from dbo.PV_Lista_Precios_Encabezado p (nolock) where p.Emp_Id=" + com(empresa)
            sqlcomando.CommandText = sqlstring
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            Dim dt As New DataTable
            dt.Load(sqlcomando.ExecuteReader)
            cbListasPrecio.DataSource = dt
            cbListasPrecio.ValueMember = dt.Columns("ListaP_Id").ToString()
            cbListasPrecio.DisplayMember = dt.Columns("ListaP_Nombre").ToString()
            cerrarconexion()
        Catch ex As Exception
            cerrarconexion()
            MessageBox.Show(ex.Message)
        End Try

    End Sub
   
    
    Public Sub cargargrid(ByRef pro As Short)
        Dim sqlcomando As New OleDb.OleDbCommand
        Dim sqlstring As String
        Try
            abrirconexion()
            sqlstring = " select a.Articulo_Id 'Articulo', a.Articulo_Nombre 'Nombre', p.Detalle_Precio 'Precio' from dbo.Articulo a (nolock), dbo.PV_Lista_Precios_Detalle p (nolock) where a.Articulo_Id = p.Articulo_Id And p.ListaP_Id = " + com(pro) + " order by a.Articulo_Nombre"
            sqlcomando.CommandText = sqlstring
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            Dim dt As New DataTable
            dt.Load(sqlcomando.ExecuteReader)
            dgvArticulo.DataSource = dt
            cerrarconexion()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cerrarconexion()
        End Try
    End Sub
    Public Sub cargargridin(ByRef pro As Short)
        Dim sqlcomando As New OleDb.OleDbCommand
        Dim sqlstring As String
        Try
            abrirconexion()
            sqlstring = " select a.Articulo_Id 'Articulo', a.Articulo_Nombre 'Nombre', p.Detalle_Precio 'Precio' from dbo.Articulo a (nolock), dbo.PV_Lista_Precios_Detalle p (nolock) where a.Articulo_Id = p.Articulo_Id And p.ListaP_Id = " + com(pro) + " order by p.Consecutivo desc"
            sqlcomando.CommandText = sqlstring
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            Dim dt As New DataTable
            dt.Load(sqlcomando.ExecuteReader)
            dgvArticulo.DataSource = dt
            cerrarconexion()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cerrarconexion()
        End Try
    End Sub
    Public Sub cargargridclientes(ByRef pro As Short)
        Dim sqlcomando As New OleDb.OleDbCommand
        Dim sqlstring As String
        Try
            abrirconexion()
            sqlstring = " select c.Cliente_Id 'Cliente', c.Cliente_Nombre 'Nombre' from dbo.Cliente c (nolock), dbo.PV_Lista_Precios_Clientes p (nolock) where c.Cliente_Id = p.Cliente_Id And p.ListaP_Id = " + com(pro) + " order by c.Cliente_Nombre"
            sqlcomando.CommandText = sqlstring
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            Dim dt As New DataTable
            dt.Load(sqlcomando.ExecuteReader)
            dgvClientes.DataSource = dt
            cerrarconexion()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cerrarconexion()
        End Try
    End Sub
    Public Sub cargargridclientesin(ByRef pro As Short)
        Dim sqlcomando As New OleDb.OleDbCommand
        Dim sqlstring As String
        Try
            abrirconexion()
            sqlstring = " select c.Cliente_Id 'Cliente', c.Cliente_Nombre 'Nombre' from dbo.Cliente c (nolock), dbo.PV_Lista_Precios_Clientes p (nolock) where c.Cliente_Id = p.Cliente_Id And p.ListaP_Id = " + com(pro) + " order by p.Consecutivo"
            sqlcomando.CommandText = sqlstring
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            Dim dt As New DataTable
            dt.Load(sqlcomando.ExecuteReader)
            dgvClientes.DataSource = dt
            cerrarconexion()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cerrarconexion()
        End Try
    End Sub
    Public Sub Clientesexistentes()
        Dim c_cliente As OleDb.OleDbDataReader
        Dim sqlcomando As New OleDb.OleDbCommand
        Dim sqlstring As String

        Try
            abrirconexion()
            sqlstring = "select c.Cliente_Nombre from dbo.Cliente c (nolock) where c.Cliente_Id=" + com(txtCodClient.Text)
            sqlcomando.CommandText = sqlstring
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            c_cliente = sqlcomando.ExecuteReader
            If c_cliente.HasRows = True Then
                While c_cliente.Read
                    idart = txtCodClient.Text
                    txtNomClient.Text = c_cliente.Item("Cliente_Nombre").ToString()
                End While
                cerrarconexion()
                btnAddCliente.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cerrarconexion()

        End Try
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        cargargrid(Convert.ToInt16(cbListasPrecio.SelectedValue))
        txtCodigoArt.ReadOnly = False
        txtCodClient.ReadOnly = False
        txtCodigoArt.Clear()
        txtCodClient.Clear()
        txtDescArt.Clear()
        txtPrecio.Clear()
        txtNomClient.Clear()

        cargargridclientes(Convert.ToInt16(cbListasPrecio.SelectedValue))
        btnAdd.Enabled = True
    End Sub
    Private Sub txtCodigoArt_KeyUp(sender As Object, e As KeyEventArgs) Handles txtCodigoArt.KeyUp
        Try
            If e.KeyCode = Keys.F1 Then
                If cbListasPrecio.Items.Count = 0 Then
                    MessageBox.Show("Por favor seleccione una empresa y una lista de precio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
                Dim vent As New frmConsultaArticulosDesc
                vent.ShowDialog()
                txtCodigoArt.Text = codigoart
                txtDescArt.Text = nombreart
                txtPrecio.Focus()
            End If
            If e.KeyCode = Keys.F3 Then
                Dim vent As New frmConsultaPorCategoriavb
                Visible = False
                Try
                    tipo = 3
                    empresa = inicioempresa.ToString()
                    listapr = cbListasPrecio.SelectedValue.ToString()
                Catch ex As Exception
                    MessageBox.Show("Por favor seleccione una empresa y una lista de precio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Visible = True
                    Return
                End Try
                vent.ShowDialog()
                Visible = True
                cargargrid(Convert.ToInt16(cbListasPrecio.SelectedValue))
            End If
            If e.KeyCode = Keys.F2 Then
                Dim vent As New frmConsultaPorDepartamento
                Visible = False
                Try
                    tipo = 3
                    empresa = inicioempresa.ToString()
                    promociones = cbListasPrecio.SelectedValue.ToString()
                Catch ex As Exception
                    MessageBox.Show("Por favor seleccione una empresa y una lista de precio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Visible = True
                    Return
                End Try
                vent.ShowDialog()
                Visible = True
                cargargrid(Convert.ToInt16(cbListasPrecio.SelectedValue))
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtPrecio_KeyUp(sender As Object, e As KeyEventArgs) Handles txtPrecio.KeyUp
        Try
            If e.KeyCode = Keys.F1 Then
                If cbListasPrecio.Items.Count = 0 Then
                    MessageBox.Show("Por favor seleccione una empresa y una lista de precio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
                Dim vent As New frmConsultaArticulosDesc
                vent.ShowDialog()
                txtCodigoArt.Text = codigoart
                txtDescArt.Text = nombreart
                txtPrecio.Focus()
            End If
            If e.KeyCode = Keys.F3 Then
                Dim vent As New frmConsultaPorCategoriavb
                Visible = False
                Try
                    tipo = 3
                    empresa = inicioempresa.ToString()
                    listapr = cbListasPrecio.SelectedValue.ToString()
                Catch ex As Exception
                    MessageBox.Show("Por favor seleccione una empresa y una lista de precio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Visible = True
                    Return
                End Try
                vent.ShowDialog()
                Visible = True
                cargargrid(Convert.ToInt16(cbListasPrecio.SelectedValue))
            End If
            If e.KeyCode = Keys.F2 Then
                Dim vent As New frmConsultaPorDepartamento
                Visible = False
                Try
                    tipo = 3
                    empresa = inicioempresa.ToString()
                    promociones = cbListasPrecio.SelectedValue.ToString()
                Catch ex As Exception
                    MessageBox.Show("Por favor seleccione una empresa y una lista de precio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Visible = True
                    Return
                End Try
                vent.ShowDialog()
                Visible = True
                cargargrid(Convert.ToInt16(cbListasPrecio.SelectedValue))
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnAdd_KeyUp(sender As Object, e As KeyEventArgs) Handles btnAdd.KeyUp
        Try
            If e.KeyCode = Keys.F1 Then
                If cbListasPrecio.Items.Count = 0 Then
                    MessageBox.Show("Por favor seleccione una empresa y una lista de precio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
                Dim vent As New frmConsultaArticulosDesc
                vent.ShowDialog()
                txtCodigoArt.Text = codigoart
                txtDescArt.Text = nombreart
                txtPrecio.Focus()
            End If
            If e.KeyCode = Keys.F3 Then
                Dim vent As New frmConsultaPorCategoriavb
                Visible = False
                Try
                    tipo = 3
                    empresa = inicioempresa.ToString()
                    listapr = cbListasPrecio.SelectedValue.ToString()
                Catch ex As Exception
                    MessageBox.Show("Por favor seleccione una empresa y una lista de precio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Visible = True
                    Return
                End Try
                vent.ShowDialog()
                Visible = True
                cargargridin(Convert.ToInt16(cbListasPrecio.SelectedValue))
            End If
            If e.KeyCode = Keys.F2 Then
                Dim vent As New frmConsultaPorDepartamento
                Visible = False
                Try
                    tipo = 3
                    empresa = inicioempresa.ToString()
                    promociones = cbListasPrecio.SelectedValue.ToString()
                Catch ex As Exception
                    MessageBox.Show("Por favor seleccione una empresa y una lista de precio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Visible = True
                    Return
                End Try
                vent.ShowDialog()
                Visible = True
                cargargridin(Convert.ToInt16(cbListasPrecio.SelectedValue))
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        If cbListasPrecio.Items.Count = 0 Then
            MessageBox.Show("Por favor seleccione una empresa y una lista de precio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
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
                If String.IsNullOrEmpty(txtCodigoArt.Text) = False And String.IsNullOrEmpty(txtPrecio.Text) = False Then
                    connection.Open()
                    transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted)
                    command.Connection = connection
                    command.Transaction = transaction
                    ' Execute the commands.
                    command.CommandText = _
                    "Insert into dbo.PV_Lista_Precios_Detalle(Articulo_Id,ListaP_Id,Emp_Id,Detalle_Fec_Actualizacion,Detalle_Precio) values(" & com(txtCodigoArt.Text) & "," & Convert.ToInt16(cbListasPrecio.SelectedValue.ToString()) & "," & Convert.ToInt16(inicioempresa.ToString()) & ",GETDATE()," & Convert.ToDecimal(txtPrecio.Text) & ")"
                    command.ExecuteNonQuery()
                    transaction.Commit()
                    cerrarconexion()
                    cargargridin(Convert.ToInt16(cbListasPrecio.SelectedValue))
                    txtCodigoArt.Clear()
                    txtCodigoArt.Focus()
                    txtDescArt.Clear()
                    txtPrecio.Clear()
                    connection.Close()
                    connection.Dispose()
                Else
                    MessageBox.Show("Por favor complete todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    cerrarconexion()
                    connection.Close()
                    connection.Dispose()
                End If
            Catch ex As Exception
                MessageBox.Show("El articulo ya existe en la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                cerrarconexion()
                connection.Close()
                connection.Dispose()
            End Try
        End Using
    End Sub
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim i As Integer
        Dim resultado As DialogResult
        resultado = MessageBox.Show("Desea Continuar la eliminacion de los articulos seleccionados ", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
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
                    For i = 0 To dgvArticulo.SelectedRows.Count - 1
                        command.CommandText = _
                            " delete from dbo.PV_Lista_Precios_Detalle   where Emp_Id= " & Convert.ToInt16(inicioempresa) & " and ListaP_Id= " & Convert.ToInt16(cbListasPrecio.SelectedValue) & " and Articulo_id= " & com(dgvArticulo.SelectedRows(i).Cells(0).Value.ToString())
                        command.ExecuteNonQuery()
                    Next
                    transaction.Commit()
                    cerrarconexion()
                    MessageBox.Show("Transacción realizada con exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    cargargrid(Convert.ToInt16(cbListasPrecio.SelectedValue))
                    txtCodigoArt.Clear()
                    txtCodigoArt.Focus()
                    txtCodigoArt.ReadOnly = False
                    txtDescArt.Clear()
                    txtPrecio.Clear()
                    connection.Close()
                    connection.Dispose()
                    btnEliminar.Enabled = False
                    btnmodifica.Enabled = False
                    btnAdd.Enabled = True
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
            txtCodigoArt.Clear()
            txtDescArt.Clear()
            txtPrecio.Clear()
            txtCodigoArt.Focus()
            txtCodigoArt.ReadOnly = False
            btnAdd.Enabled = True
        End If
    End Sub
    Private Sub txtPrecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecio.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            btnAdd.Focus()
        End If
    End Sub
    Private Sub dgvArticulo_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvArticulo.CellClick

        Dim i As Integer
        i = dgvArticulo.CurrentRow.Index
        txtCodigoArt.ReadOnly = True
        txtDescArt.ReadOnly = True
        txtCodigoArt.Text = dgvArticulo.Item(0, i).Value
        txtDescArt.Text = dgvArticulo.Item(1, i).Value
        txtPrecio.Text = dgvArticulo.Item(2, i).Value
        btnEliminar.Enabled = True
        btnmodifica.Enabled = True
        btnAdd.Enabled = False

    End Sub
    Private Sub txtCodClient_TextChanged(sender As Object, e As EventArgs) Handles txtCodClient.TextChanged

    End Sub
    Private Sub txtCodClient_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodClient.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            Clientesexistentes()

        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Back) Or e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Delete) Then
            txtNomClient.Clear()

        End If
    End Sub
    Private Sub btnAddCliente_Click(sender As Object, e As EventArgs) Handles btnAddCliente.Click
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
                If String.IsNullOrEmpty(txtCodClient.Text) = False Then
                    connection.Open()
                    transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted)
                    command.Connection = connection
                    command.Transaction = transaction
                    ' Execute the commands.
                    command.CommandText = _
                    "Insert into dbo.PV_Lista_Precios_Clientes(Cliente_Id,ListaP_Id,Emp_Id,Cliente_Fec_Actualizacion,Cliente_Estado) values(" & com(txtCodClient.Text) & "," & Convert.ToInt16(cbListasPrecio.SelectedValue.ToString()) & "," & Convert.ToInt16(inicioempresa.ToString()) & ",GETDATE(),'A')"
                    command.ExecuteNonQuery()
                    transaction.Commit()
                    cerrarconexion()
                    cargargridclientesin(Convert.ToInt16(cbListasPrecio.SelectedValue))
                    txtCodClient.Clear()
                    txtNomClient.Clear()
                    txtCodClient.Focus()
                    connection.Close()
                    connection.Dispose()
                Else
                    MessageBox.Show("Por favoir digite los datos requeridos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    transaction.Rollback()
                    cerrarconexion()
                    connection.Close()
                    connection.Dispose()
                End If
            Catch ex As Exception
                MessageBox.Show("El Cliente ya existe en la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                cerrarconexion()
                connection.Close()
                connection.Dispose()
            End Try
        End Using
    End Sub
    Private Sub btnELimCliente_Click(sender As Object, e As EventArgs) Handles btnELimCliente.Click
        Dim resultado As DialogResult
        resultado = MessageBox.Show("Desea eliminar todos los clientes seleccionados", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
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
                    For i = 0 To dgvClientes.SelectedRows.Count - 1
                        command.CommandText = _
                            " delete from dbo.PV_Lista_Precios_Clientes   where Emp_Id= " & Convert.ToInt16(inicioempresa) & " and ListaP_Id= " & Convert.ToInt16(cbListasPrecio.SelectedValue) & " and Cliente_Id= " & com(dgvClientes.SelectedRows(i).Cells(0).Value.ToString())
                        command.ExecuteNonQuery()
                    Next
                    transaction.Commit()
                    cerrarconexion()
                    MessageBox.Show("Transacción realizada con exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    cargargridclientes(Convert.ToInt16(cbListasPrecio.SelectedValue))
                    txtCodClient.Clear()
                    txtNomClient.Clear()
                    txtCodClient.Focus()
                    connection.Close()
                    connection.Dispose()
                    btnEliminar.Enabled = False
                    btnAdd.Enabled = True
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
            txtCodClient.Clear()
            txtNomClient.Clear()
            txtCodClient.Focus()
            btnAdd.Enabled = True
        End If
    End Sub
    Private Sub dgvClientes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvClientes.CellClick
        btnELimCliente.Enabled = True
        btnAddCliente.Enabled = False
    End Sub
    Private Sub txtCodClient_KeyUp(sender As Object, e As KeyEventArgs) Handles txtCodClient.KeyUp
        Try
            If e.KeyCode = Keys.F1 Then
                Dim vent As New frmConsultaClienteNom
                listapr = cbListasPrecio.SelectedValue.ToString()
                empresa = inicioempresa.ToString()
                vent.ShowDialog()
                txtCodClient.Text = codclient
                txtNomClient.Text = nomclient
                cargargridclientesin(cbListasPrecio.SelectedValue.ToString())
                btnAddCliente.Focus()
                btnAdd.Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnAddCliente_KeyUp(sender As Object, e As KeyEventArgs) Handles btnAddCliente.KeyUp
        Try
            If e.KeyCode = Keys.F1 Then

                Dim vent As New frmConsultaClienteNom
                vent.ShowDialog()
                txtCodClient.Text = codclient
                txtNomClient.Text = nomclient
                btnAddCliente.Focus()
                btnAdd.Enabled = True
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtCodigoArt_TextChanged(sender As Object, e As EventArgs) Handles txtCodigoArt.TextChanged
        txtDescArt.Clear()
        btnEliminar.Enabled = False
        btnmodifica.Enabled = False
        btnAdd.Enabled = True
        txtPrecio.Clear()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If cbListasPrecio.Items.Count = 0 Then
            MessageBox.Show("Por favor seleccione una empresa y una lista de precio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Dim vent As New frmConsultaArticulosDesc
        vent.ShowDialog()
        txtCodigoArt.Text = codigoart
        txtDescArt.Text = nombreart
        txtPrecio.Focus()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim vent As New frmConsultaPorDepartamento
        Visible = False
        Try
            tipo = 3
            empresa = inicioempresa.ToString()
            listapr = cbListasPrecio.SelectedValue.ToString()

        Catch ex As Exception
            MessageBox.Show("Por favor seleccione una empresa y una lista de precio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Visible = True
            Return
        End Try
        vent.ShowDialog()
        Visible = True
        cargargridin(Convert.ToInt16(cbListasPrecio.SelectedValue))
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim vent As New frmConsultaPorCategoriavb
        Visible = False
        Try
            tipo = 3
            empresa = inicioempresa.ToString()
            listapr = cbListasPrecio.SelectedValue.ToString()
        Catch ex As Exception
            MessageBox.Show("Por favor seleccione una empresa y una lista de precio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Visible = True
            Return
        End Try
        vent.ShowDialog()
        Visible = True
        cargargridin(Convert.ToInt16(cbListasPrecio.SelectedValue))


    End Sub
    Private Sub ModificarPrecio()
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
                If String.IsNullOrEmpty(txtCodigoArt.Text) = False And String.IsNullOrEmpty(txtPrecio.Text) = False Then
                    connection.Open()
                    transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted)
                    command.Connection = connection
                    command.Transaction = transaction
                    ' Execute the commands.
                    command.CommandText = _
                    " Update dbo.PV_Lista_Precios_Detalle set Detalle_Precio=" & com(txtPrecio.Text) & ", Detalle_Fec_Actualizacion=GETDATE() where Articulo_Id=" & com(txtCodigoArt.Text) & " and Emp_Id=" & com(inicioempresa.ToString()) & " and ListaP_Id= " & com(cbListasPrecio.SelectedValue.ToString())
                    command.ExecuteNonQuery()
                    transaction.Commit()
                    cerrarconexion()
                    cargargridin(Convert.ToInt16(cbListasPrecio.SelectedValue))
                    txtCodigoArt.Clear()
                    txtCodigoArt.Focus()
                    txtDescArt.Clear()
                    txtPrecio.Clear()
                    txtCodigoArt.ReadOnly = False
                    connection.Close()
                    connection.Dispose()
                Else
                    MessageBox.Show("Por favor complete todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    cerrarconexion()
                    connection.Close()
                    connection.Dispose()
                End If
            Catch ex As Exception
                MessageBox.Show("El articulo ya existe en la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                cerrarconexion()
                connection.Close()
                connection.Dispose()
            End Try
        End Using
        btnAdd.Enabled = True
        btnmodifica.Enabled = False
        btnEliminar.Enabled = False
    End Sub
    Private Sub btnmodifica_Click(sender As Object, e As EventArgs) Handles btnmodifica.Click
        ModificarPrecio()
    End Sub
    Private Sub btnCargarExcel_Click(sender As Object, e As EventArgs) Handles btnCargarExcel.Click
        Dim Dialogo_carga As New OpenFileDialog()
        Dim h As Integer
        Dim m As Integer = 0
        Dim n As Integer = 0
        Try
            If cbListasPrecio.Items.Count = 0 Then
                MessageBox.Show("Por favor seleccione una empresa y una lista de precios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                abrirconexion()
                Dialogo_carga.InitialDirectory = CurDir()
                Dialogo_carga.Filter = "xls files (*.xls)|*.xls| xlsx files (*.xlsx)|*.xlsx"
                Dialogo_carga.FilterIndex = 2
                Dialogo_carga.RestoreDirectory = True
                If Dialogo_carga.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    ruta_archivo = Dialogo_carga.FileName
                    Dim Cnx_Excel As String = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source='" & ruta_archivo & " '; " & "Extended Properties=Excel 8.0;"
                    Dim Conexion_excel As New System.Data.OleDb.OleDbConnection(Cnx_Excel)
                    Conexion_excel.Open()
                    Dim Cmd_excel As New System.Data.OleDb.OleDbCommand("Select cstr(Articulo) as articulo,cstr(Precio) as Precio  From [Articulos$]", Conexion_excel)
                    Dim DR_cargadatos As OleDbDataReader = Cmd_excel.ExecuteReader
                    Do While DR_cargadatos.Read()
                        If String.IsNullOrEmpty(DR_cargadatos.GetString(0)) = False And String.IsNullOrEmpty(DR_cargadatos.GetString(1)) = False Then
                            n = 0
                            Dim sqlcomando As New OleDb.OleDbCommand
                            Dim sqlstring As String
                            sqlstring = " select p.Articulo_Id 'Articulo' from dbo.PV_Lista_Precios_Detalle p (nolock) where  p.ListaP_Id = " + com(cbListasPrecio.SelectedValue.ToString())
                            sqlcomando.CommandText = sqlstring
                            sqlcomando.CommandType = CommandType.Text
                            sqlcomando.Connection = Conexion
                            Dim dt As New DataTable
                            dt.Load(sqlcomando.ExecuteReader)
                            For h = 0 To dt.Rows.Count - 1
                                If (dt.Rows(h)("Articulo").ToString() = DR_cargadatos.GetString(0).ToString()) Then
                                    m += 1
                                    n += 1
                                End If
                            Next
                            If n = 0 Then
                                comandoledb2.CommandText = _
"Insert into dbo.PV_Lista_Precios_Detalle(Articulo_Id,ListaP_Id,Emp_Id,Detalle_Fec_Actualizacion,Detalle_Precio) values( " & com(DR_cargadatos.GetString(0)) & "," & Convert.ToInt16(cbListasPrecio.SelectedValue.ToString()) & "," & Convert.ToInt16(inicioempresa.ToString()) & ",GETDATE()," & Convert.ToDecimal(DR_cargadatos.GetString(1)) & ")"
                                comandoledb2.CommandType = CommandType.Text
                                comandoledb2.Connection = Conexion
                                comandoledb2.ExecuteNonQuery()
                            End If
                        End If
                    Loop

                    DR_cargadatos.Close()
                    Conexion_excel.Close()
                    Conexion_excel.Dispose()
                    If m > 0 Then
                        If m = 1 Then
                            MessageBox.Show(m.ToString() + " articulo existía en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Else
                            MessageBox.Show(m.ToString() + " articulos existían en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If
                    MsgBox("Datos Cargados Exitosamente", MsgBoxStyle.Information, "Información")
                    cerrarconexion()
                    cargargridin(Convert.ToInt16(cbListasPrecio.SelectedValue))
                End If
                cerrarconexion()
            End If
        Catch ex As OleDbException
            Dim er As OleDbError
            For Each er In ex.Errors
                MsgBox(er.Message)
            Next

            cerrarconexion()
        Catch ex2 As System.InvalidOperationException
            MsgBox(ex2.Message)
            cerrarconexion()
        End Try
    End Sub
    Private Sub btncargarclientes_Click(sender As Object, e As EventArgs) Handles btncargarclientes.Click
        Dim Dialogo_carga As New OpenFileDialog()
        Dim h As Integer
        Dim m As Integer = 0
        Dim n As Integer = 0
        Try
            If cbListasPrecio.Items.Count = 0 Then
                MessageBox.Show("Por favor seleccione una empresa y una lista de precios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                abrirconexion()
                Dialogo_carga.InitialDirectory = CurDir()
                Dialogo_carga.Filter = "xls files (*.xls)|*.xls| xlsx files (*.xlsx)|*.xlsx"
                Dialogo_carga.FilterIndex = 2
                Dialogo_carga.RestoreDirectory = True
                If Dialogo_carga.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    ruta_archivo = Dialogo_carga.FileName
                    Dim Cnx_Excel As String = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source='" & ruta_archivo & " '; " & "Extended Properties=Excel 8.0;"
                    Dim Conexion_excel As New System.Data.OleDb.OleDbConnection(Cnx_Excel)
                    Conexion_excel.Open()
                    Dim Cmd_excel As New System.Data.OleDb.OleDbCommand("Select cstr(Cliente) as Cliente From [Clientes$]", Conexion_excel)
                    Dim DR_cargadatos As OleDbDataReader = Cmd_excel.ExecuteReader
                    Do While DR_cargadatos.Read()
                        If String.IsNullOrEmpty(DR_cargadatos.GetString(0)) = False Then
                            n = 0
                            Dim sqlcomando As New OleDb.OleDbCommand
                            Dim sqlstring As String
                            sqlstring = " select p.Cliente_Id 'Cliente' from dbo.PV_Lista_Precios_Clientes p (nolock) where p.ListaP_Id = " + com(cbListasPrecio.SelectedValue.ToString())
                            sqlcomando.CommandText = sqlstring
                            sqlcomando.CommandType = CommandType.Text
                            sqlcomando.Connection = Conexion
                            Dim dt As New DataTable
                            dt.Load(sqlcomando.ExecuteReader)
                            For h = 0 To dt.Rows.Count - 1
                                If (dt.Rows(h)("Cliente").ToString() = DR_cargadatos.GetString(0).ToString()) Then
                                    m += 1
                                    n += 1
                                End If
                            Next
                            If n = 0 Then
                                comandoledb2.CommandText = _
"Insert into dbo.PV_Lista_Precios_Clientes(Cliente_Id,ListaP_Id,Emp_Id,Cliente_Fec_Actualizacion,Cliente_Estado) values(" & com(DR_cargadatos.GetString(0).ToString()) & "," & Convert.ToInt16(cbListasPrecio.SelectedValue.ToString()) & "," & Convert.ToInt16(inicioempresa.ToString()) & ",GETDATE(),'A')"
                                comandoledb2.CommandType = CommandType.Text
                                comandoledb2.Connection = Conexion
                                comandoledb2.ExecuteNonQuery()
                            End If
                        End If
                    Loop

                    DR_cargadatos.Close()
                    Conexion_excel.Close()
                    If m > 0 Then
                        If m = 1 Then
                            MessageBox.Show(m.ToString() + " cliente existía en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Else
                            MessageBox.Show(m.ToString() + " clientes existían en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If
                    MsgBox("Datos Cargados Exitosamente", MsgBoxStyle.Information, "Información")
                    cerrarconexion()
                    cargargridclientesin(cbListasPrecio.SelectedValue.ToString())
                End If
                cerrarconexion()
            End If
        Catch ex As OleDbException
            Dim er As OleDbError
            For Each er In ex.Errors
                MsgBox(er.Message)
            Next
            cerrarconexion()
        Catch ex2 As System.InvalidOperationException
            MsgBox(ex2.Message)
            cerrarconexion()
        End Try
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim vent As New frmConsultaClienteNom
        If cbListasPrecio.Items.Count = 0 Then
            MessageBox.Show("Por favor seleccione una empresa y una lista de precio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else

            listapr = cbListasPrecio.SelectedValue.ToString()
            empresa = inicioempresa.ToString()
            vent.ShowDialog()
            txtCodClient.Text = codclient
            txtNomClient.Text = nomclient
            cargargridclientesin(cbListasPrecio.SelectedValue.ToString())
            btnAdd.Enabled = True
            btnAddCliente.Focus()
        End If
    End Sub
    Private Sub Button5_KeyUp(sender As Object, e As KeyEventArgs) Handles Button5.KeyUp
        Try
            If e.KeyCode = Keys.F1 Then
                Dim vent As New frmConsultaClienteNom
                listapr = cbListasPrecio.SelectedValue.ToString()
                empresa = inicioempresa.ToString()
                vent.ShowDialog()
                txtCodClient.Text = codclient
                txtNomClient.Text = nomclient
                cargargridclientesin(cbListasPrecio.SelectedValue.ToString())
                btnAddCliente.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbEmpresa_MouseClick(sender As Object, e As MouseEventArgs)
        Dim sqlcomando As New OleDb.OleDbCommand
        Dim sqlstring As String

        Try
            abrirconexion()
            sqlstring = "select p.ListaP_Id,p.ListaP_Nombre from dbo.PV_Lista_Precios_Encabezado p (nolock) where p.Emp_Id=" + com(empresa)
            sqlcomando.CommandText = sqlstring
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            Dim dt As New DataTable
            dt.Load(sqlcomando.ExecuteReader)
            cbListasPrecio.DataSource = dt
            cbListasPrecio.ValueMember = dt.Columns("ListaP_Id").ToString()
            cbListasPrecio.DisplayMember = dt.Columns("ListaP_Nombre").ToString()
            cerrarconexion()
        Catch ex As Exception
            cerrarconexion()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class