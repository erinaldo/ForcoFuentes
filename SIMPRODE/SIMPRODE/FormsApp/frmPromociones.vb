Imports System.Data.OleDb
Imports System.IO
Public Class frmPromociones
    Dim ruta_archivo As String
    Private Sub frmPromociones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarpromociones(Convert.ToInt16(inicioempresa))
    End Sub
    Private Sub cargarpromociones(ByRef empresa As Short)
        Dim sqlcomando As New OleDb.OleDbCommand
        Dim sqlstring As String

        Try
            abrirconexion()
            sqlstring = "select p.Promocion_Id,p.Promocion_Nombre from dbo.Promocion_Volumen (nolock) p where p.Emp_Id=" + com(empresa)
            sqlcomando.CommandText = sqlstring
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            Dim dt As New DataTable
            dt.Load(sqlcomando.ExecuteReader)
            cbPromociones.DataSource = dt
            cbPromociones.ValueMember = dt.Columns("Promocion_Id").ToString()
            cbPromociones.DisplayMember = dt.Columns("Promocion_Nombre").ToString()
            cerrarconexion()
        Catch ex As Exception
            cerrarconexion()
            MessageBox.Show(ex.Message)
        End Try

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
                btnAdd.Focus()
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
                    btnAdd.Focus()
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
    Public Sub cargargrid(ByRef pro As Short)
        Dim sqlcomando As New OleDb.OleDbCommand
        Dim sqlstring As String
        Try
            abrirconexion()
            sqlstring = "select a.Articulo_Id 'Articulo', a.Articulo_Nombre 'Nombre' from dbo.Articulo a, dbo.Promocion_Volumen_Articulo p where a.Articulo_Id = p.Articulo_Id And p.Promocion_Id = " + com(pro) + " order by a.Articulo_Nombre"
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
            sqlstring = "select a.Articulo_Id 'Articulo', a.Articulo_Nombre 'Nombre' from dbo.Articulo a, dbo.Promocion_Volumen_Articulo p where a.Articulo_Id = p.Articulo_Id And p.Promocion_Id = " + com(pro) + " order by p.Consecutivo desc"
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
    Private Sub cargargridsucursales()
        Dim sqlcomando As New OleDb.OleDbCommand
        Dim sqlstring As String
        Try
            abrirconexion()
            sqlstring = "select vs.Suc_ID Sucursal, b.Bodega_Nombre Nombre from dbo.Promocion_Volumen_Sucursal vs, dbo.Bodega b where vs.Suc_ID=b.Bodega_Id and vs.Promocion_ID=" + com(cbPromociones.SelectedValue)
            sqlcomando.CommandText = sqlstring
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            Dim dt As New DataTable
            dt.Load(sqlcomando.ExecuteReader)
            dgvSucursales.DataSource = dt
            cerrarconexion()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cerrarconexion()
        End Try
    End Sub
    Private Sub cargarpreciosxcantidad()
        Dim sqlcomando As New OleDb.OleDbCommand
        Dim sqlstring As String
        Dim i As Integer
        Dim sqlcomando2 As New OleDb.OleDbCommand
        Dim sqlstring2 As String
        Dim h As Integer
        Try
            abrirconexion()
            dgvPrecios.Rows.Clear()
            sqlcomando.Parameters.Clear()
            sqlstring = "select Rango_Id Rango, convert(int,Rango_Cantidad_Minima) 'Cantidad Mínima', convert(int,Rango_Cantidad_Maxima) 'Cantidad Máxima', Rango_Precio 'Precio' from dbo.Promocion_Volumen_Rangos where Promocion_Id=" + com(cbPromociones.SelectedValue)
            sqlcomando.CommandText = sqlstring
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            Dim dt As New DataTable
            dt.Rows.Clear()
            dt.Load(sqlcomando.ExecuteReader)
            sqlstring2 = "select p.Parametro_Nombre,p.Parametro_Valor from Parametro_Generales p where p.Parametro_Nombre='Precio1_name' or p.Parametro_Nombre='Precio2_name' or p.Parametro_Nombre='Precio3_name' or p.Parametro_Nombre='Precio4_name' or p.Parametro_Nombre='Precio5_name' or p.Parametro_Nombre='Precio6_name'"
            sqlcomando2.CommandText = sqlstring2
            sqlcomando2.CommandType = CommandType.Text
            sqlcomando2.Connection = Conexion
            Dim dt2 As New DataTable
            dt2.Load(sqlcomando2.ExecuteReader)
            For i = 0 To dt.Rows.Count - 1
                dgvPrecios.Rows.Add()
                dgvPrecios.Rows(i).Cells(0).Value = dt.Rows(i)("Rango")
                dgvPrecios.Rows(i).Cells(1).Value = dt.Rows(i)("Cantidad Mínima")
                dgvPrecios.Rows(i).Cells(2).Value = dt.Rows(i)("Cantidad Máxima")
                If dt.Rows(i)("Precio") = 1 Then
                    For h = 0 To dt2.Rows.Count - 1
                        If dt2.Rows(h)("Parametro_Nombre") = "Precio1_name" Then
                            dgvPrecios.Rows(i).Cells(3).Value = dt2.Rows(h)("Parametro_Valor")
                        End If
                    Next
                End If
                If dt.Rows(i)("Precio") = 2 Then
                    For h = 0 To dt2.Rows.Count - 1
                        If dt2.Rows(h)("Parametro_Nombre") = "Precio2_name" Then
                            dgvPrecios.Rows(i).Cells(3).Value = dt2.Rows(h)("Parametro_Valor")
                        End If
                    Next
                End If
                If dt.Rows(i)("Precio") = 3 Then
                    For h = 0 To dt2.Rows.Count - 1
                        If dt2.Rows(h)("Parametro_Nombre") = "Precio3_name" Then
                            dgvPrecios.Rows(i).Cells(3).Value = dt2.Rows(h)("Parametro_Valor")
                        End If
                    Next
                End If
                If dt.Rows(i)("Precio") = 4 Then
                    For h = 0 To dt2.Rows.Count - 1
                        If dt2.Rows(h)("Parametro_Nombre") = "Precio4_name" Then
                            dgvPrecios.Rows(i).Cells(3).Value = dt2.Rows(h)("Parametro_Valor")
                        End If
                    Next
                End If
                If dt.Rows(i)("Precio") = 5 Then
                    For h = 0 To dt2.Rows.Count - 1
                        If dt2.Rows(h)("Parametro_Nombre") = "Precio5_name" Then
                            dgvPrecios.Rows(i).Cells(3).Value = dt2.Rows(h)("Parametro_Valor")
                        End If
                    Next
                End If
                If dt.Rows(i)("Precio") = 6 Then
                    For h = 0 To dt2.Rows.Count - 1
                        If dt2.Rows(h)("Parametro_Nombre") = "Precio6_name" Then
                            dgvPrecios.Rows(i).Cells(3).Value = dt2.Rows(h)("Parametro_Valor")
                        End If
                    Next
                End If
            Next

            cerrarconexion()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cerrarconexion()
        End Try
    End Sub
    Private Sub promocionactiva()
        Dim sqlcomando As New OleDb.OleDbCommand
        Dim sqlstring As String
        Dim i As Integer
        Try
            abrirconexion()
            sqlstring = "select  Promocion_Activa from dbo.Promocion_Volumen where Promocion_Id=" + com(cbPromociones.SelectedValue)
            sqlcomando.CommandText = sqlstring
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            Dim dt As New DataTable
            dt.Load(sqlcomando.ExecuteReader)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows(i)("Promocion_Activa") = True Then
                    ckActiva.Checked = True
                Else
                    ckActiva.Checked = False
                End If
            Next
            cerrarconexion()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cerrarconexion()
        End Try
    End Sub
    Private Sub tipocliente()
        Dim sqlcomando As New OleDb.OleDbCommand
        Dim sqlstring As String
        Dim i As Integer
        Try
            abrirconexion()
            sqlstring = "select c.Tipo_Nombre from dbo.Promocion_Volumen v, dbo.Tipo_Cliente c where v.Promocion_Tipo_Cliente=c.Tipo_Id and v.Promocion_Id=" + com(cbPromociones.SelectedValue)
            sqlcomando.CommandText = sqlstring
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            Dim dt As New DataTable
            dt.Load(sqlcomando.ExecuteReader)
            For i = 0 To dt.Rows.Count - 1
                txtTipClient.Text = dt.Rows(i)("Tipo_Nombre")
            Next
            cerrarconexion()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cerrarconexion()
        End Try
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        cargargrid(Convert.ToInt16(cbPromociones.SelectedValue))
        cargarpreciosxcantidad()
        promocionactiva()
        tipocliente()
        cargargridsucursales()
        dgvPrecios.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvPrecios.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub
    Private Sub txtCodigoArt_KeyUp(sender As Object, e As KeyEventArgs)

        Try
            If e.KeyCode = Keys.F1 Then
                If cbPromociones.Items.Count = 0 Then
                    MessageBox.Show("Por favor seleccione una empresa y una promocion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
                Dim vent As New frmConsultaArticulosDesc
                vent.ShowDialog()
                txtCodigoArt.Text = codigoart
                txtDescArt.Text = nombreart
            End If
            If e.KeyCode = Keys.F2 Then
                Dim vent As New frmConsultaPorCategoriavb
                Visible = False
                Try
                    tipo = 2
                    empresa = inicioempresa.ToString()
                    promociones = cbPromociones.SelectedValue.ToString()
                Catch ex As Exception
                    MessageBox.Show("Por favor seleccione una empresa y una promocion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Visible = True
                    Return
                End Try
                vent.ShowDialog()
                Visible = True
                cargargrid(Convert.ToInt16(cbPromociones.SelectedValue))
            End If
            If e.KeyCode = Keys.F3 Then
                Dim vent As New frmConsultaPorDepartamento
                Visible = False
                Try
                    tipo = 2
                    empresa = inicioempresa.ToString()
                    promociones = cbPromociones.SelectedValue.ToString()
                Catch ex As Exception
                    MessageBox.Show("Por favor seleccione una empresa y una promocion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Visible = True
                    Return
                End Try
                vent.ShowDialog()
                Visible = True
                cargargrid(Convert.ToInt16(cbPromociones.SelectedValue))
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub frmPromociones_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        Try
            If e.KeyCode = Keys.F1 Then
                If cbPromociones.Items.Count = 0 Then
                    MessageBox.Show("Por favor seleccione una empresa y una promocion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
                Dim vent As New frmConsultaArticulosDesc
                vent.ShowDialog()
                txtCodigoArt.Text = codigoart
                txtDescArt.Text = nombreart
                btnAdd.Focus()
            End If
            If e.KeyCode = Keys.F3 Then
                Dim vent As New frmConsultaPorCategoriavb
                Visible = False
                Try
                    tipo = 2
                    empresa = inicioempresa.ToString()
                    descuento = cbPromociones.SelectedValue.ToString()
                Catch ex As Exception
                    MessageBox.Show("Por favor seleccione una empresa y un descuento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Visible = True
                    Return
                End Try
                vent.ShowDialog()
                Visible = True
                cargargrid(Convert.ToInt16(cbPromociones.SelectedValue))
            End If
            If e.KeyCode = Keys.F2 Then
                Dim vent As New frmConsultaPorDepartamento
                Visible = False
                Try
                    tipo = 2
                    empresa = inicioempresa.ToString()
                    descuento = cbPromociones.SelectedValue.ToString()
                Catch ex As Exception
                    MessageBox.Show("Por favor seleccione una empresa y un descuento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Visible = True
                    Return
                End Try
                vent.ShowDialog()
                Visible = True
                cargargrid(Convert.ToInt16(cbPromociones.SelectedValue))
            End If



        Catch ex As Exception

        End Try
    End Sub
    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles Button1.Click
        If cbPromociones.Items.Count = 0 Then
            MessageBox.Show("Por favor seleccione una empresa y una promocion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Dim vent As New frmConsultaArticulosDesc
        vent.ShowDialog()
        txtCodigoArt.Text = codigoart
        txtDescArt.Text = nombreart
        btnAdd.Focus()
    End Sub
    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        Dim vent As New frmConsultaPorDepartamento
        Visible = False
        Try
            tipo = 2
            empresa = inicioempresa.ToString()
            promociones = cbPromociones.SelectedValue.ToString()
        Catch ex As Exception
            MessageBox.Show("Por favor seleccione una empresa y una promocion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Visible = True
            Return
        End Try
        vent.ShowDialog()
        Visible = True
        cargargridin(Convert.ToInt16(cbPromociones.SelectedValue))
    End Sub
    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        Dim vent As New frmConsultaPorCategoriavb
        Visible = False
        Try
            tipo = 2
            empresa = inicioempresa.ToString()
            promociones = cbPromociones.SelectedValue.ToString()
        Catch ex As Exception
            MessageBox.Show("Por favor seleccione una empresa y una promocion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Visible = True
            Return
        End Try
        vent.ShowDialog()
        Visible = True
        cargargridin(Convert.ToInt16(cbPromociones.SelectedValue))
    End Sub
    Private Sub btnCargarExcel_Click_1(sender As Object, e As EventArgs) Handles btnCargarExcel.Click
        Dim Dialogo_carga As New OpenFileDialog()
        Dim h As Integer
        Dim m As Integer = 0
        Dim n As Integer = 0
        Try
            If cbPromociones.Items.Count = 0 Then
                MessageBox.Show("Por favor seleccione una empresa y una promocion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                    Dim Cmd_excel As New System.Data.OleDb.OleDbCommand("Select cstr(Articulo) as articulo From [Articulos$]", Conexion_excel)
                    Dim DR_cargadatos As OleDbDataReader = Cmd_excel.ExecuteReader
                    Do While DR_cargadatos.Read()
                        If String.IsNullOrEmpty(DR_cargadatos.GetString(0)) = False Then
                            n = 0
                            Dim sqlcomando As New OleDb.OleDbCommand
                            Dim sqlstring As String
                            sqlstring = "select p.Articulo_Id 'Articulo' from dbo.Promocion_Volumen_Articulo p (nolock) where p.Promocion_Id = " + com(cbPromociones.SelectedValue.ToString())
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
        "INSERT INTO dbo.Promocion_Volumen_Articulo(Articulo_Id,Promocion_Id,Emp_Id,Promocion_Fec_Actualizacion) VALUES ( " & com(DR_cargadatos.GetString(0)) & "," & Convert.ToInt16(cbPromociones.SelectedValue.ToString()) & "," & Convert.ToInt16(inicioempresa.ToString()) & ",GETDATE())"
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
                            MessageBox.Show(m.ToString() + " articulo existía en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Else
                            MessageBox.Show(m.ToString() + " articulos existían en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If
                    MsgBox("Datos Cargados Exitosamente", MsgBoxStyle.Information, "Información")
                    cerrarconexion()
                    cargargridin(Convert.ToInt16(cbPromociones.SelectedValue))
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
    Private Sub btnAdd_Click_1(sender As Object, e As EventArgs) Handles btnAdd.Click
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
                If String.IsNullOrEmpty(txtCodigoArt.Text) = False Then
                    connection.Open()
                    transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted)
                    command.Connection = connection
                    command.Transaction = transaction
                    ' Execute the commands.
                    command.CommandText = _
                    "Insert into dbo.Promocion_Volumen_Articulo(Articulo_Id,Promocion_Id,Emp_Id,Promocion_Fec_Actualizacion) values(" & com(txtCodigoArt.Text) & "," & Convert.ToInt16(cbPromociones.SelectedValue.ToString()) & "," & Convert.ToInt16(inicioempresa.ToString()) & ",GETDATE())"
                    command.ExecuteNonQuery()
                    transaction.Commit()
                    cerrarconexion()
                    cargargridin(Convert.ToInt16(cbPromociones.SelectedValue))
                    txtCodigoArt.Clear()
                    txtCodigoArt.Focus()
                    txtDescArt.Clear()
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
                transaction.Rollback()
                cerrarconexion()
                connection.Close()
                connection.Dispose()
            End Try
        End Using


    End Sub
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
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
                            " delete from dbo.Promocion_Volumen_Articulo   where Emp_Id= " & Convert.ToInt16(inicioempresa) & " and Promocion_Id= " & Convert.ToInt16(cbPromociones.SelectedValue) & " and Articulo_id= " & com(dgvArticulo.SelectedRows(i).Cells(0).Value.ToString())
                        command.ExecuteNonQuery()
                    Next
                    transaction.Commit()
                    cerrarconexion()
                    MessageBox.Show("Transacción realizada con exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    cargargrid(Convert.ToInt16(cbPromociones.SelectedValue))
                    txtCodigoArt.Clear()
                    txtCodigoArt.Focus()
                    txtDescArt.Clear()
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
            txtCodigoArt.Clear()
            txtDescArt.Clear()
            txtCodigoArt.Focus()
        End If
    End Sub
    Private Sub txtCodigoArt_TextChanged_1(sender As Object, e As EventArgs) Handles txtCodigoArt.TextChanged
        txtDescArt.Clear()
        btnAdd.Enabled = True
        btnEliminar.Enabled = False
    End Sub
    Private Sub txtCodigoArt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigoArt.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            articulosexistentes()

        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Back) Or e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Delete) Then
            txtDescArt.Clear()

        End If

    End Sub

    Private Sub txtDescArt_TextChanged(sender As Object, e As EventArgs) Handles txtDescArt.TextChanged

    End Sub

    Private Sub dgvArticulo_CellClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles dgvArticulo.CellClick

        Dim i As Integer
        i = dgvArticulo.CurrentRow.Index
        btnEliminar.Enabled = True
        btnAdd.Enabled = False
    End Sub
End Class