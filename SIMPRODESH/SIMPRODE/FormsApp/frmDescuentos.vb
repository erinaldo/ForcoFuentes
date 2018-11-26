Imports System.Data.OleDb
Imports System.IO
Public Class frmDescuentos
    Dim ruta_archivo As String
    Private Sub frmDescuentos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargardescuentos(Convert.ToInt16(inicioempresa))
    End Sub
    
    Private Sub cargardescuentos(ByRef empresa As Short)
        Dim sqlcomando As New OleDb.OleDbCommand
        Dim sqlstring As String

        Try
            abrirconexion()
            sqlstring = "select v.Descuento_Id, v.Descuento_Nombre  from dbo.Descuento_Venta v (nolock) where v.Emp_Id=" + com(empresa)
            sqlcomando.CommandText = sqlstring
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            Dim dt As New DataTable
            dt.Load(sqlcomando.ExecuteReader)
            cbDescuentos.DataSource = dt
            cbDescuentos.ValueMember = dt.Columns("Descuento_Id").ToString()
            cbDescuentos.DisplayMember = dt.Columns("Descuento_Nombre").ToString()
            
            cerrarconexion()
        Catch ex As Exception
            cerrarconexion()
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Public Sub articulosexistentes()
        Try
            Dim c_articulo As OleDb.OleDbDataReader
            Dim sqlcomando As New OleDb.OleDbCommand
            Dim sqlstring As String


            abrirconexion()
            sqlstring = "select a.Articulo_Nombre from dbo.Articulo a  (nolock) where a.Articulo_Id=" + com(txtCodigoArt.Text)
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
    Public Sub cargargrid(ByRef desc As Short)
        Dim sqlcomando As New OleDb.OleDbCommand
        Dim sqlstring As String
        Try
            abrirconexion()
            sqlstring = "select a.Articulo_Id 'Articulo', a.Articulo_Nombre 'Nombre' from dbo.Articulo a (nolock), dbo.Descuento_Venta_Articulo v (nolock) where v.Articulo_Id=a.Articulo_Id and v.Descuento_Id= " + com(desc) + " order by a.Articulo_Nombre"
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
    Public Sub cargargridin(ByRef desc As Short)
        Dim sqlcomando As New OleDb.OleDbCommand
        Dim sqlstring As String
        Try
            abrirconexion()
            sqlstring = "select a.Articulo_Id 'Articulo', a.Articulo_Nombre 'Nombre' from dbo.Articulo a (nolock), dbo.Descuento_Venta_Articulo v (nolock) where v.Emp_Id = 1 AND v.Articulo_Id=a.Articulo_Id and v.Descuento_Id= " + com(desc) + " order by v.Consecutivo desc "
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
            sqlstring = "select vs.Suc_ID Sucursal, b.Bodega_Nombre Nombre from dbo.Descuento_Venta_Sucursal vs, dbo.Bodega b where vs.Suc_ID=b.Bodega_Id and vs.Descuento_ID=" + com(cbDescuentos.SelectedValue)
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
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        cargargrid(Convert.ToInt16(cbDescuentos.SelectedValue))
        cargargridcantidades()
        cargarfechas()
        cargarhoras()
        cargardias()
        cargargridsucursales()
        dgvRangos.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvRangos.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvRangos.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Private Sub frmDescuentos_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        Try
            If e.KeyCode = Keys.F1 Then
                If cbDescuentos.Items.Count = 0 Then
                    MessageBox.Show("Por favor seleccione una empresa y un descuento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                    tipo = 1
                    empresa = inicioempresa.ToString()
                    descuento = cbDescuentos.SelectedValue.ToString()
                Catch ex As Exception
                    MessageBox.Show("Por favor seleccione una empresa y un descuento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Visible = True
                    Return
                End Try
                vent.ShowDialog()
                Visible = True
                cargargridin(Convert.ToInt16(cbDescuentos.SelectedValue))
            End If
            If e.KeyCode = Keys.F2 Then
                Dim vent As New frmConsultaPorDepartamento
                Visible = False
                Try
                    tipo = 1
                    empresa = inicioempresa.ToString()
                    descuento = cbDescuentos.SelectedValue.ToString()
                Catch ex As Exception
                    MessageBox.Show("Por favor seleccione una empresa y un descuento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Visible = True
                    Return
                End Try
                vent.ShowDialog()
                Visible = True
                cargargridin(Convert.ToInt16(cbDescuentos.SelectedValue))
            End If



        Catch ex As Exception

        End Try
    End Sub

    Private Sub cargargridcantidades()
        Dim sqlcomando As New OleDb.OleDbCommand
        Dim sqlstring As String
        Try
            abrirconexion()
            sqlstring = "select vr.Rango_Id Rango, convert(int,vr.Rango_Cantidad_Minima) 'Cantidad Mínima', convert(int,vr.Rango_Cantidad_Maxima) 'Rango Máximo', Convert(varchar(10),Convert(decimal(10,0),vr.Rango_Porcentaje_Descuento))+'%' 'Porcentaje Descuento'  from dbo.Descuento_Venta_Rangos vr (NoLock) where vr.Descuento_Id=" + com(cbDescuentos.SelectedValue) + "order by vr.Rango_Id"
            sqlcomando.CommandText = sqlstring
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            Dim dt As New DataTable
            dt.Load(sqlcomando.ExecuteReader)
            dgvRangos.DataSource = dt
            cerrarconexion()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cerrarconexion()
        End Try
    End Sub
    Private Sub cargarfechas()
        Dim sqlcomando As New OleDb.OleDbCommand
        Dim sqlstring As String
        Dim i As Integer
        Try
            abrirconexion()
            sqlstring = "select dv.Descuento_Fecha_Inicio 'FechaInicio', dv.Descuento_Fecha_Final 'FechaFin'" & _
                        "from dbo.Descuento_Venta dv where dv.Descuento_Id=" + com(cbDescuentos.SelectedValue) + "order by dv.descuento_Id"
            sqlcomando.CommandText = sqlstring
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            Dim dt As New DataTable
            dt.Load(sqlcomando.ExecuteReader)
            For i = 0 To dt.Rows.Count - 1
                dtInicio.Value = dt.Rows(i)("FechaInicio")
                dtFin.Value = dt.Rows(i)("FechaFin")
            Next
            cerrarconexion()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cerrarconexion()
        End Try
    End Sub
    Private Sub cargarhoras()
        Dim sqlcomando As New OleDb.OleDbCommand
        Dim sqlstring As String
        Dim i As Integer
        Try
            abrirconexion()
            sqlstring = "select dv.Descuento_Hora_Inicio 'HoraInicio', dv.Descuento_Hora_Final 'HoraFin'" & _
                        "from dbo.Descuento_Venta dv where dv.Descuento_Id=" + com(cbDescuentos.SelectedValue) + "order by dv.descuento_Id"
            sqlcomando.CommandText = sqlstring
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            Dim dt As New DataTable
            dt.Load(sqlcomando.ExecuteReader)
            For i = 0 To dt.Rows.Count - 1
                dthorain.Value = dt.Rows(i)("HoraInicio")
                dthorafin.Value = dt.Rows(i)("HoraFin")
            Next
            cerrarconexion()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cerrarconexion()
        End Try
    End Sub
    Private Sub cargardias()
        Dim sqlcomando As New OleDb.OleDbCommand
        Dim sqlstring As String
        Dim i As Integer
        Try
            abrirconexion()
            sqlstring = "select dv.Descuento_Dia1,dv.Descuento_Dia2,dv.Descuento_Dia3,dv.Descuento_Dia4,dv.Descuento_Dia5,dv.Descuento_Dia6,dv.Descuento_Dia7" & _
                        " from dbo.Descuento_Venta dv where dv.Descuento_Id= " + com(cbDescuentos.SelectedValue) + "order by dv.descuento_Id"
            sqlcomando.CommandText = sqlstring
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            Dim dt As New DataTable
            dt.Load(sqlcomando.ExecuteReader)
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows(i)("Descuento_Dia7") = True Then
                    ckDomingo.Checked = True
                Else
                    ckDomingo.Checked = False
                End If
                If dt.Rows(i)("Descuento_Dia1") = True Then
                    ckLunes.Checked = True
                Else
                    ckLunes.Checked = False
                End If
                If dt.Rows(i)("Descuento_Dia2") = True Then
                    ckMartes.Checked = True
                Else
                    ckMartes.Checked = False
                End If
                If dt.Rows(i)("Descuento_Dia3") = True Then
                    ckMiercoles.Checked = True
                Else
                    ckMiercoles.Checked = False
                End If
                If dt.Rows(i)("Descuento_Dia4") = True Then
                    ckJueves.Checked = True
                Else
                    ckJueves.Checked = False
                End If
                If dt.Rows(i)("Descuento_Dia5") = True Then
                    ckViernes.Checked = True
                Else
                    ckViernes.Checked = False
                End If
                If dt.Rows(i)("Descuento_Dia6") = True Then
                    ckSabado.Checked = True
                Else
                    ckSabado.Checked = False
                End If
            Next
            cerrarconexion()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cerrarconexion()
        End Try
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If cbDescuentos.Items.Count = 0 Then
            MessageBox.Show("Por favor seleccione una empresa y un descuento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Dim vent As New frmConsultaArticulosDesc
        vent.ShowDialog()
        txtCodigoArt.Text = codigoart
        txtDescArt.Text = nombreart
        btnAdd.Focus()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim vent As New frmConsultaPorDepartamento
        Visible = False
        Try
            tipo = 1
            empresa = inicioempresa.ToString()
            descuento = cbDescuentos.SelectedValue.ToString()
        Catch ex As Exception
            MessageBox.Show("Por favor seleccione una empresa y un descuento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Visible = True
            Return
        End Try
        vent.ShowDialog()
        Visible = True
        cargargridin(Convert.ToInt16(cbDescuentos.SelectedValue))
    End Sub
    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        If cbDescuentos.Items.Count = 0 Then
            MessageBox.Show("Por favor seleccione una empresa y un descuento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Dim vent As New frmConsultaPorCategoriavb
        Visible = False
        Try
            tipo = 1
            empresa = inicioempresa.ToString()
            descuento = cbDescuentos.SelectedValue.ToString()
        Catch ex As Exception
            MessageBox.Show("Por favor seleccione una empresa y un descuento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Visible = True
            Return
        End Try
        vent.ShowDialog()
        Visible = True
        cargargridin(Convert.ToInt16(cbDescuentos.SelectedValue))
    End Sub
    Private Sub btnCargarExcel_Click_1(sender As Object, e As EventArgs) Handles btnCargarExcel.Click
        Dim Dialogo_carga As New OpenFileDialog()
        Dim h As Integer
        Dim m As Integer = 0
        Dim n As Integer = 0
        Try
            If cbDescuentos.Items.Count = 0 Then
                MessageBox.Show("Por favor seleccione una empresa y un descuento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                        n = 0
                        If String.IsNullOrEmpty(DR_cargadatos.GetString(0)) = False Then
                            Dim sqlcomando As New OleDb.OleDbCommand
                            Dim sqlstring As String
                            sqlstring = "select v.Articulo_Id 'Articulo' from dbo.Descuento_Venta_Articulo v (nolock) where v.Descuento_Id= " + com(cbDescuentos.SelectedValue.ToString())
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
            "Insert into dbo.Descuento_Venta_Articulo(Articulo_Id,Descuento_Id,Emp_Id,Descuento_Fec_Actualizacion) values( " & com(DR_cargadatos.GetString(0)) & "," & Convert.ToInt16(cbDescuentos.SelectedValue.ToString()) & "," & Convert.ToInt16(inicioempresa.ToString()) & ",GETDATE())"
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
                    cargargridin(Convert.ToInt16(cbDescuentos.SelectedValue))
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
                    "Insert into dbo.Descuento_Venta_Articulo(Articulo_Id,Descuento_Id,Emp_Id,Descuento_Fec_Actualizacion) values(" & com(txtCodigoArt.Text) & "," & Convert.ToInt16(cbDescuentos.SelectedValue.ToString()) & "," & Convert.ToInt16(inicioempresa.ToString()) & ",GETDATE())"
                    command.ExecuteNonQuery()
                    transaction.Commit()
                    cerrarconexion()
                    cargargridin(Convert.ToInt16(cbDescuentos.SelectedValue))
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
    Private Sub btnEliminar_Click_1(sender As Object, e As EventArgs) Handles btnEliminar.Click
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
                            " delete from dbo.Descuento_Venta_Articulo   where Emp_Id= " & Convert.ToInt16(inicioempresa) & " and Descuento_Id= " & Convert.ToInt16(cbDescuentos.SelectedValue) & " and Articulo_id= " & com(dgvArticulo.SelectedRows(i).Cells(0).Value.ToString())
                        command.ExecuteNonQuery()
                    Next
                    transaction.Commit()
                    cerrarconexion()
                    MessageBox.Show("Transacción realizada con exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    cargargrid(Convert.ToInt16(cbDescuentos.SelectedValue))
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

    Private Sub txtCodigoArt_KeyPress_1(sender As Object, e As KeyPressEventArgs) Handles txtCodigoArt.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            articulosexistentes()

        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Back) Or e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Delete) Then
            txtDescArt.Clear()

        End If
    End Sub

    Private Sub dgvArticulo_CellClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles dgvArticulo.CellClick
        Dim i As Integer
        i = dgvArticulo.CurrentRow.Index
        btnEliminar.Enabled = True
        btnAdd.Enabled = False
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class