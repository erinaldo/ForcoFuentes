Public Class frmConsultaArticulo
    Public tipo As Integer
    Public art As String
    Public filtro As Integer
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        ProgressBar1.Value = 0
        Try
            BackgroundWorker1.RunWorkerAsync()
            Timer1.Start()

            BackgroundWorker1.CancelAsync()
      
        Catch ex As Exception

        End Try

    End Sub
    Private Sub consultadearticuloporcodigo()
        Dim sqlcomando As New OleDb.OleDbCommand
        Dim sqlstring As String
        Try
            sqlstring = "select a.Articulo_Id,a.Articulo_Nombre,convert(int,ux.UXB),convert(int,vu.UXI),case when (select d.porcentaje from dbo.articulo_impuesto (nolock) d where d.Articulo_Id=a.Articulo_Id ) = 0.13 then 'NO' else 'SI'end  Excepto from dbo.Articulo a (nolock), dbo.vista_uinterna vu (nolock), dbo.vista_uxb ux (nolock) where a.Articulo_Id=vu.Articulo_Id and a.Articulo_Id=ux.Articulo_Id and a.Articulo_Id=" + com(txtCodArt.Text)
            sqlcomando.CommandText = sqlstring
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            Dim dt As New DataTable
            dt.Load(sqlcomando.ExecuteReader)
            dgvArticulo.DataSource = dt
            txtCodArt.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub consultadearticulopordesc()
        Dim sqlcomando As New OleDb.OleDbCommand
        Dim sqlstring As String
        Try
            sqlstring = " select a.Articulo_Id,a.Articulo_Nombre,ux.UXB,vu.UXI,case when (select d.porcentaje from dbo.articulo_impuesto (nolock) d where d.Articulo_Id=a.Articulo_Id ) = 0.13 then 'NO' else 'SI'end  Excento from dbo.Articulo a (nolock), dbo.vista_uinterna vu (nolock), dbo.vista_uxb ux (nolock) where a.Articulo_Id=vu.Articulo_Id and a.Articulo_Id=ux.Articulo_Id and a.Articulo_Nombre like" + por(txtDescArt.Text)
            sqlcomando.CommandText = sqlstring
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            Dim dt As New DataTable
            dt.Load(sqlcomando.ExecuteReader)
            dgvArticulo.DataSource = dt

            txtDescArt.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub muestraequivalencias(ByRef id As String)
        Dim sqlcomando As New OleDb.OleDbCommand
        Dim sqlstring As String
        Try
            sqlstring = "select e.Equivalente_Id 'Codigos Equivalentes' from dbo.Articulo_Equivalente e (nolock) where e.Articulo_Id= " + com(id)
            sqlcomando.CommandText = sqlstring
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            Dim dt As New DataTable
            dt.Load(sqlcomando.ExecuteReader)
            dgvEquivalente.DataSource = dt
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub muestraprecios(ByRef id As String)
        tipo = 1
        Dim i As Integer
        Dim h As Integer
        Dim r As Integer
        Dim sqlcomando As New OleDb.OleDbCommand
        Dim sqlstring As String
        Try
            sqlstring = _
"select (select p.Parametro_Valor from Parametro_Generales p where p.Parametro_Nombre='Precio1_name'),       " & _
"case when (select d.porcentaje from dbo.articulo_impuesto d (nolock) where d.Articulo_Id=a.Articulo_Id ) = 0.13 then " & _
"convert(decimal(10,0),ax.AxS_Precio1 * 1.13) else convert(decimal(10,0),ax.AxS_Precio1 )end,        " & _
"(select p.Parametro_Valor from Parametro_Generales p where p.Parametro_Nombre='Precio2_name'),              " & _
"case when (select d.porcentaje from dbo.articulo_impuesto d (nolock) where d.Articulo_Id=a.Articulo_Id ) = 0.13 then " & _
"convert(decimal(10,0),ax.AxS_Precio2 * 1.13) else convert(decimal(10,0),ax.AxS_Precio2) end,        " & _
"(select p.Parametro_Valor from Parametro_Generales p where p.Parametro_Nombre='Precio3_name'),              " & _
"case when (select d.porcentaje from dbo.articulo_impuesto d (nolock) where d.Articulo_Id=a.Articulo_Id ) = 0.13 then " & _
"convert(decimal(10,0),ax.AxS_Precio3 * 1.13) else convert(decimal(10,0),ax.AxS_Precio3)end ,        " & _
"(select p.Parametro_Valor from Parametro_Generales p where p.Parametro_Nombre='Precio4_name'),              " & _
"case when (select d.porcentaje from dbo.articulo_impuesto d (nolock) where d.Articulo_Id=a.Articulo_Id ) = 0.13 then " & _
"convert(decimal(10,0),ax.AxS_Precio4 * 1.13) else convert(decimal(10,0),ax.AxS_Precio4) end,        " & _
"(select p.Parametro_Valor from Parametro_Generales p where p.Parametro_Nombre='Precio5_name'),              " & _
"case when (select d.porcentaje from dbo.articulo_impuesto d (nolock) where d.Articulo_Id=a.Articulo_Id ) = 0.13 then " & _
"convert(decimal(10,0),ax.AxS_Precio5 * 1.13) else convert(decimal(10,0),ax.AxS_Precio5) end,        " & _
"(select p.Parametro_Valor from Parametro_Generales p where p.Parametro_Nombre='Precio6_name'),              " & _
"case when (select d.porcentaje from dbo.articulo_impuesto d (nolock) where d.Articulo_Id=a.Articulo_Id ) = 0.13 then " & _
"convert(decimal(10,0),ax.AxS_Precio6 * 1.13) else convert(decimal(10,0),ax.AxS_Precio6) end         " & _
"from Articulo a (nolock), Articulo_x_Sucursal ax where a.Articulo_Id = " + com(id) + " and ax.Articulo_Id=a.Articulo_Id and ax.Suc_Id = 1001"
            sqlcomando.CommandText = sqlstring
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            Dim dt As New DataTable
            dt.Load(sqlcomando.ExecuteReader)
            dgvprecio.Rows.Clear()
            h = 0
            r = 0
            For i = 0 To dt.Columns.Count - 1
                If Not dt.Columns.Count = h Then
                    If Not Convert.ToInt32(dt.Rows(0)(h + 1)) = 0 Then
                        dgvprecio.Rows.Add()
                        dgvprecio.Rows(r).Cells(0).Value = dt.Rows(0)(h).ToString()
                        h += 1
                        dgvprecio.Rows(r).Cells(1).Value = dt.Rows(0)(h).ToString()
                        h += 1
                        r = r + 1
                    Else
                        h += 2
                    End If
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub muestrapreciosxsucursal(ByRef id As String)
        Dim sqlcomando As New OleDb.OleDbCommand
        Dim sqlstring As String
        Try
            sqlstring = _
"select a.Suc_Id 'Sucursal', b.Bodega_Nombre 'Nombre', " & _
"case when (select d.porcentaje from dbo.articulo_impuesto d (nolock) where d.Articulo_Id=a.Articulo_Id ) = 0.13 then   " & _
"convert(decimal(10,0),a.AxS_Precio1 *1.13) else convert(decimal(10,0),a.AxS_Precio1) end,                     " & _
"case when (select d.porcentaje from dbo.articulo_impuesto d (nolock) where d.Articulo_Id=a.Articulo_Id ) = 0.13 then   " & _
"convert(decimal(10,0),a.AxS_Precio2 *1.13) else convert(decimal(10,0),a.AxS_Precio2) end,                     " & _
"case when (select d.porcentaje from dbo.articulo_impuesto d (nolock) where d.Articulo_Id=a.Articulo_Id ) = 0.13 then   " & _
"convert(decimal(10,0),a.AxS_Precio3 *1.13) else convert(decimal(10,0),a.AxS_Precio3) end,                     " & _
"case when (select d.porcentaje from dbo.articulo_impuesto d (nolock) where d.Articulo_Id=a.Articulo_Id ) = 0.13 then   " & _
"convert(decimal(10,0),a.AxS_Precio4 *1.13) else convert(decimal(10,0),a.AxS_Precio4) end,                     " & _
"case when (select d.porcentaje from dbo.articulo_impuesto d (nolock) where d.Articulo_Id=a.Articulo_Id ) = 0.13 then   " & _
"convert(decimal(10,0),a.AxS_Precio5 *1.13) else convert(decimal(10,0),a.AxS_Precio5) end,                     " & _
"case when (select d.porcentaje from dbo.articulo_impuesto d (nolock) where d.Articulo_Id=a.Articulo_Id ) = 0.13 then   " & _
"convert(decimal(10,0),a.AxS_Precio6 *1.13) else convert(decimal(10,0),a.AxS_Precio6) end                      " & _
"from Articulo_X_Sucursal a (nolock), Bodega b (nolock) where a.Suc_Id = b.Bodega_Id And a.Articulo_Id = " + com(id) + "order by a.Suc_id"
            sqlcomando.CommandText = sqlstring
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            Dim dt As New DataTable
            dt.Load(sqlcomando.ExecuteReader)
            dgvpreciosucursal.DataSource = dt
            renombrarColumnas()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub renombrarColumnas()
        Dim sqlcomando As New OleDb.OleDbCommand
        Dim sqlstring As String
        Dim c_nomcolums As OleDb.OleDbDataReader
        Dim i As Integer
        Try
            sqlstring = "select * from  vista_nomcolumnas_precios (nolock) "
            sqlcomando.CommandText = sqlstring
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            c_nomcolums = sqlcomando.ExecuteReader
            If c_nomcolums.HasRows = True Then
                i = 2
                While c_nomcolums.Read
                    dgvpreciosucursal.Columns(i).HeaderText = c_nomcolums.Item("Parametro_Valor").ToString()
                    i += 1
                End While
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub verventas(ByRef id As String)
        Dim sqlcomando As New OleDb.OleDbCommand
        Dim sqlstring As String
        Try
            If bodega1.Checked = False Then
                sqlstring = "SELECT convert(VARCHAR, b.Bodega_Id) Bodega, b.Bodega_Nombre Nombre, convert(VARCHAR,fd.Caja_id) Caja, convert(VARCHAR,fd.Factura_id) Factura, convert(VARCHAR,fd.Detalle_Fecha) Fecha, convert(INT, fd.Detalle_Cantidad) Cantidad, convert(INT, (fd.Detalle_Precio_Unitario-fd.detalle_descuento_monto) * fd.Detalle_Cantidad) 'Precio Total' " & _
                            " FROM Factura_Detalle fd (NOLOCK), Bodega b (NOLOCK)                                                                                                                                                                                                                                 " & _
                            " where b.Bodega_Id = fd.Suc_Id And fd.Articulo_Id = " + com(id) + " and fd.Detalle_Fecha >= " + com(Format(DateTimePicker5.Value.Date, "MM/dd/yyyy")) + " and fd.Detalle_Fecha <= " + com(Format(DateTimePicker6.Value.Date.AddDays(1), "MM/dd/yyyy")) & _
                            " UNION SELECT 'Total' 'Total', '', '', '', '', convert(int,sum(fd.Detalle_Cantidad)), convert(INT, sum((fd.Detalle_Precio_Unitario-fd.detalle_descuento_monto) * fd.Detalle_Cantidad)) FROM Factura_Detalle fd (NOLOCK) WHERE fd.Articulo_Id = " + com(id) + "and fd.Detalle_Fecha >= " + com(Format(DateTimePicker5.Value.Date, "MM/dd/yyyy")) + " and fd.Detalle_Fecha <= " + com(Format(DateTimePicker6.Value.Date.AddDays(1), "MM/dd/yyyy")) & _
                            " ORDER BY   1"
                sqlcomando.CommandText = sqlstring
                sqlcomando.CommandType = CommandType.Text
                sqlcomando.Connection = Conexion
                Dim dt As New DataTable
                dt.Load(sqlcomando.ExecuteReader)
                dgvVentas.DataSource = dt
                dgvVentas.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dgvVentas.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Else
                sqlstring = "SELECT convert(VARCHAR, b.Bodega_Id) Bodega, b.Bodega_Nombre Nombre, convert(VARCHAR,fd.Caja_id) Caja, convert(VARCHAR,fd.Factura_id) Factura, convert(VARCHAR,fd.Detalle_Fecha) Fecha, convert(INT, fd.Detalle_Cantidad) Cantidad, convert(INT, (fd.Detalle_Precio_Unitario-fd.detalle_descuento_monto) * fd.Detalle_Cantidad) 'Precio Total' " & _
                            " FROM Factura_Detalle fd (NOLOCK), Bodega b (NOLOCK)                                                                                                                                                                                                                                 " & _
                            " where b.Bodega_Id = fd.Suc_Id and fd.Suc_Id= " + com(cbbodega1.SelectedValue) + " And fd.Articulo_Id = " + com(id) + " and fd.Detalle_Fecha >= " + com(Format(DateTimePicker5.Value.Date, "MM/dd/yyyy")) + " and fd.Detalle_Fecha <= " + com(Format(DateTimePicker6.Value.Date.AddDays(1), "MM/dd/yyyy")) & _
                            " UNION SELECT 'Total' 'Total', '', '', '', '', convert(int,sum(fd.Detalle_Cantidad)), convert(INT, sum((fd.Detalle_Precio_Unitario-fd.detalle_descuento_monto) * fd.Detalle_Cantidad)) FROM Factura_Detalle fd (NOLOCK) WHERE fd.Suc_Id= " + com(cbbodega1.SelectedValue) + " And fd.Articulo_Id = " + com(id) + "and fd.Detalle_Fecha >= " + com(Format(DateTimePicker5.Value.Date, "MM/dd/yyyy")) + " and fd.Detalle_Fecha <= " + com(Format(DateTimePicker6.Value.Date.AddDays(1), "MM/dd/yyyy")) & _
                            " ORDER BY   1"
                sqlcomando.CommandText = sqlstring
                sqlcomando.CommandType = CommandType.Text
                sqlcomando.Connection = Conexion
                Dim dt As New DataTable
                dt.Load(sqlcomando.ExecuteReader)
                dgvVentas.DataSource = dt
                dgvVentas.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dgvVentas.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub txtCodArt_TextChanged(sender As Object, e As EventArgs) Handles txtCodArt.TextChanged
        txtDescArt.Clear()
        dgvArticulo.DataSource = vbNullString
        dgvArticulo.Rows.Clear()
        dgvEquivalente.DataSource = vbNullString
        dgvEquivalente.Rows.Clear()
        dgvExistencias.DataSource = vbNullString
        dgvExistencias.Rows.Clear()
        dgvprecio.DataSource = vbNullString
        dgvprecio.Rows.Clear()
        dgvpreciosucursal.DataSource = vbNullString
        dgvpreciosucursal.Rows.Clear()
        dgvVentas.DataSource = vbNullString
        dgvVentas.Rows.Clear()
        dgvCompras.DataSource = vbNullString
        dgvCompras.Rows.Clear()
        dgvMovimientos.DataSource = vbNullString
        dgvMovimientos.Rows.Clear()
        Ptb_Fotos.ImageLocation = ""
    End Sub
    Private Sub txtDescArt_TextChanged(sender As Object, e As EventArgs) Handles txtDescArt.TextChanged
        txtCodArt.Clear()
        dgvArticulo.DataSource = vbNullString
        dgvArticulo.Rows.Clear()
        dgvEquivalente.DataSource = vbNullString
        dgvEquivalente.Rows.Clear()
        dgvExistencias.DataSource = vbNullString
        dgvExistencias.Rows.Clear()
        dgvprecio.DataSource = vbNullString
        dgvprecio.Rows.Clear()
        dgvpreciosucursal.DataSource = vbNullString
        dgvpreciosucursal.Rows.Clear()
        dgvVentas.DataSource = vbNullString
        dgvVentas.Rows.Clear()
        Ptb_Fotos.ImageLocation = ""
    End Sub
    Private Sub txtCodArt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodArt.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            btnBuscar.Focus()
        End If
    End Sub
    Private Sub txtDescArt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDescArt.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            btnBuscar.Focus()
        End If
    End Sub
    Private Sub muestraexistencias(ByRef id As String)
        Dim sqlcomando As New OleDb.OleDbCommand
        Dim sqlstring As String
        Try
            sqlstring = "SELECT convert(VARCHAR,e.Bodega) Bodega , substring(convert(VARCHAR, e.Bodega), 1, 3), e.Descripcion, e.Localización, e.Bultos, e.Unidades FROM existencias_articulos e (NOLOCK) WHERE e.Articulo = " + com(id) & _
                        " UNION SELECT 'Total','Total','','', sum(h.Bultos),sum(h.Unidades) FROM existencias_articulos h (NOLOCK) WHERE h.Articulo = " + com(id) + " ORDER BY 2,3,4"
            sqlcomando.CommandText = sqlstring
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            Dim dt As New DataTable
            dt.Load(sqlcomando.ExecuteReader)
            dgvExistencias.DataSource = dt
            dgvExistencias.Columns(1).Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub muestramovimientos(ByRef id As String)
        Dim sqlcomando As New OleDb.OleDbCommand
        Dim sqlstring As String
        Try
            If Bodegas.Checked = False Then
                sqlstring = "select eh.Bodega_id Bodega, b.Bodega_Nombre Nombre, eh.Documento_id #Documento, eh.Cola_Fecha Fecha, " & _
                                      " case eh.Documento_Tipo when 'DES' then 'Despacho' when 'DEV' then 'Devolucion' when 'EXT' then 'Entrada Exterior' " & _
                                      " when 'FAC' then 'Venta' when 'LOC' then 'Entrada Local' when 'MIN' then 'Movimiento de Inventario' when 'MTR' then 'Traslado de Mercadería' " & _
                                      " when 'PED' then 'Pedido' else 'Otro' end 'Tipo Movimiento', eh.Cola_Cantidad Cantidad " & _
                                      " from Inv_Cola_Existencias_Histo eh (NOLOCK), Bodega b (NOLOCK) " & _
                                      " where b.Bodega_Id = eh.Bodega_id And eh.Articulo_id= " + com(id) + " and eh.Cola_Fecha >=" + com(Format(DateTimePicker1.Value.Date, "MM/dd/yyyy")) + " and eh.Cola_Fecha <= " + com(Format(DateTimePicker2.Value.Date, "MM/dd/yyyy")) + " order by 4 desc "
                sqlcomando.CommandText = sqlstring
                sqlcomando.CommandType = CommandType.Text
                sqlcomando.Connection = Conexion
                Dim dt As New DataTable
                dt.Load(sqlcomando.ExecuteReader)
                dgvMovimientos.DataSource = dt
            Else
                sqlstring = "select eh.Bodega_id Bodega, b.Bodega_Nombre Nombre, eh.Documento_id #Documento, eh.Cola_Fecha Fecha, " & _
                                      " case eh.Documento_Tipo when 'DES' then 'Despacho' when 'DEV' then 'Devolucion' when 'EXT' then 'Entrada Exterior' " & _
                                      " when 'FAC' then 'Venta' when 'LOC' then 'Entrada Local' when 'MIN' then 'Movimiento de Inventario' when 'MTR' then 'Traslado de Mercadería' " & _
                                      " when 'PED' then 'Pedido' else 'Otro' end 'Tipo Movimiento', eh.Cola_Cantidad Cantidad " & _
                                      " from Inv_Cola_Existencias_Histo eh (NOLOCK), Bodega b (NOLOCK) " & _
                                      " where b.Bodega_Id = eh.Bodega_id And  b.Bodega_id=" + com(cbbodega.SelectedValue.ToString) + " And eh.Articulo_id= " + com(id) + " and eh.Cola_Fecha >=" + com(Format(DateTimePicker1.Value.Date, "MM/dd/yyyy")) + " and eh.Cola_Fecha <= " + com(Format(DateTimePicker2.Value.Date, "MM/dd/yyyy")) + " order by 4 desc "
                sqlcomando.CommandText = sqlstring
                sqlcomando.CommandType = CommandType.Text
                sqlcomando.Connection = Conexion
                Dim dt As New DataTable
                dt.Load(sqlcomando.ExecuteReader)
                dgvMovimientos.DataSource = dt
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub mostrarcompras(ByRef id As String)
        Dim sqlcomando As New OleDb.OleDbCommand
        Dim sqlstring As String
        Try
            sqlstring = "SELECT vc.Bodega, vc.Nombre, vc.Documento, convert(varchar,vc.fecha) 'Fecha', vc.Cantidad FROM vista_compras vc where vc.Articulo_Id=" + com(id) + " and vc.Fecha >= " + com(Format(DateTimePicker3.Value.Date, "MM/dd/yyyy")) + "and vc.Fecha <= " + com(Format(DateTimePicker4.Value.Date, "MM/dd/yyyy")) & _
                        "union Select 'Total','','','',convert(int,sum(vc.Cantidad)) FROM vista_compras vc where vc.Articulo_Id=" + com(id) + " and vc.Fecha >= " + com(Format(DateTimePicker3.Value.Date, "MM/dd/yyyy")) + "and vc.Fecha <= " + com(Format(DateTimePicker4.Value.Date, "MM/dd/yyyy")) + "order by 4 desc "
            sqlcomando.CommandText = sqlstring
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            Dim dt As New DataTable
            dt.Load(sqlcomando.ExecuteReader)
            dgvCompras.DataSource = dt
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub dgvArticulo_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvArticulo.CellClick
        Ptb_Fotos.ImageLocation = ""
        Dim i As Integer
        i = dgvArticulo.CurrentRow.Index
        art = dgvArticulo.Item(0, i).Value
        cargardatos(art)
       
    End Sub

    Private Sub cargardatos(ByRef art As String)
        Try

            muestraequivalencias(art)
            muestraprecios(art)
            muestraexistencias(art)
            muestrapreciosxsucursal(art)
            cargarlistadeprecios(art)
            cargarpromociones(art)
            cargardescuentos(art)
            dgvprecio.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvpreciosucursal.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvpreciosucursal.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvpreciosucursal.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvpreciosucursal.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvpreciosucursal.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvpreciosucursal.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvExistencias.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvExistencias.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            cargarimagen(art)

        Catch ex As Exception

        End Try
    End Sub
    Private Sub frmConsultaArticulo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        abrirconexion()
        cargarbodegas()
        tipo = 0
        cbbodega.Visible = False
        Label8.Visible = False
        cbbodega1.Visible = False
        Label9.Visible = False
    End Sub
    Private Sub cargarlistadeprecios(ByRef id As String)
        Dim sqlcomando As New OleDb.OleDbCommand
        Dim sqlstring As String
        Try
            If ckactivas.Checked = False Then
                sqlstring = _
           "SELECT p.ListaP_Id 'Lista', p.ListaP_Nombre 'Nombre', p.ListaP_Desde 'Fecha Inicio', p.ListaP_Hasta 'Fecha Fin',p.ListaP_Activa 'Activa' FROM PV_Lista_Precios_Encabezado p, PV_Lista_Precios_Detalle l " & _
           " WHERE l.ListaP_Id = p.ListaP_Id And l.Articulo_Id=" + com(id)
                sqlcomando.CommandText = sqlstring
                sqlcomando.CommandType = CommandType.Text
                sqlcomando.Connection = Conexion
                Dim dt As New DataTable
                dt.Load(sqlcomando.ExecuteReader)
                Dgvlistaprecios.DataSource = dt
            Else
                sqlstring = _
           "SELECT p.ListaP_Id 'Lista', p.ListaP_Nombre 'Nombre', p.ListaP_Desde 'Fecha Inicio', p.ListaP_Hasta 'Fecha Fin',p.ListaP_Activa 'Activa' FROM PV_Lista_Precios_Encabezado p, PV_Lista_Precios_Detalle l " & _
           " WHERE l.ListaP_Id = p.ListaP_Id and p.listaP_activa=1 And l.Articulo_Id=" + com(id)
                sqlcomando.CommandText = sqlstring
                sqlcomando.CommandType = CommandType.Text
                sqlcomando.Connection = Conexion
                Dim dt As New DataTable
                dt.Load(sqlcomando.ExecuteReader)
                Dgvlistaprecios.DataSource = dt
            End If
           
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub cargarpromociones(ByRef id As String)
        Dim sqlcomando As New OleDb.OleDbCommand
        Dim sqlstring As String
        Try
            If ckactivas.Checked = False Then
                sqlstring = _
                "SELECT p.Promocion_Id 'Promocion',p.Promocion_Nombre 'Nombre', p.Promocion_Activa 'Activa' FROM Promocion_Volumen p, Promocion_Volumen_Articulo v " & _
                "WHERE p.Promocion_Id = v.Promocion_Id And v.Articulo_Id = " + com(id)
                sqlcomando.CommandText = sqlstring
                sqlcomando.CommandType = CommandType.Text
                sqlcomando.Connection = Conexion
                Dim dt As New DataTable
                dt.Load(sqlcomando.ExecuteReader)
                dgvpromociones.DataSource = dt
            Else
                sqlstring = _
 "SELECT p.Promocion_Id 'Promocion',p.Promocion_Nombre 'Nombre', p.Promocion_Activa 'Activa' FROM Promocion_Volumen p, Promocion_Volumen_Articulo v " & _
 "WHERE p.Promocion_Id = v.Promocion_Id and p.Promocion_Activa=1 And v.Articulo_Id = " + com(id)
                sqlcomando.CommandText = sqlstring
                sqlcomando.CommandType = CommandType.Text
                sqlcomando.Connection = Conexion
                Dim dt As New DataTable
                dt.Load(sqlcomando.ExecuteReader)
                dgvpromociones.DataSource = dt
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub cargardescuentos(ByRef id As String)
        Dim sqlcomando As New OleDb.OleDbCommand
        Dim sqlstring As String
        Try
            If ckactivas.Checked = False Then
                sqlstring = _
                "SELECT d.Descuento_Id 'Descuento',d.Descuento_Nombre 'Nombre', d.Descuento_Fecha_Inicio 'Fecha Inicio', d.Descuento_Fecha_Final 'Fecha Fin' FROM Descuento_Venta d, Descuento_Venta_Articulo v" & _
                " WHERE d.Descuento_Id = v.Descuento_Id And v.Articulo_Id=" + com(id)
                sqlcomando.CommandText = sqlstring
                sqlcomando.CommandType = CommandType.Text
                sqlcomando.Connection = Conexion
                Dim dt As New DataTable
                dt.Load(sqlcomando.ExecuteReader)
                dgvDescuentos.DataSource = dt
            Else
                sqlstring = _
                "SELECT d.Descuento_Id 'Descuento',d.Descuento_Nombre 'Nombre', d.Descuento_Fecha_Inicio 'Fecha Inicio', d.Descuento_Fecha_Final 'Fecha Fin' FROM Descuento_Venta d, Descuento_Venta_Articulo v" & _
                " WHERE d.Descuento_Id = v.Descuento_Id and d.Descuento_Fecha_Inicio <= GetDate() and d.Descuento_Fecha_Final>=GetDate() And v.Articulo_Id=" + com(id)
                sqlcomando.CommandText = sqlstring
                sqlcomando.CommandType = CommandType.Text
                sqlcomando.Connection = Conexion
                Dim dt As New DataTable
                dt.Load(sqlcomando.ExecuteReader)
                dgvDescuentos.DataSource = dt
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cargarbodegas()
        Try
            Dim sqlcomando1 As New OleDb.OleDbCommand
            sqlcomando1.CommandText = "Select Bodega_Id 'Bodega', Bodega_Nombre 'Nombre' from Bodega (NOLOCK) order by bodega_nombre"
            sqlcomando1.CommandType = CommandType.Text
            sqlcomando1.Connection = Conexion
            Dim dt As New DataTable
            dt.Load(sqlcomando1.ExecuteReader)
            cbbodega.DataSource = dt
            cbbodega.ValueMember = dt.Columns("Bodega").ToString()
            cbbodega.DisplayMember = dt.Columns("Nombre").ToString()
            cbbodega1.DataSource = dt
            cbbodega1.ValueMember = dt.Columns("Bodega").ToString()
            cbbodega1.DisplayMember = dt.Columns("Nombre").ToString()

        Catch ex As Exception

        End Try
    End Sub
    Private Sub frmConsultaArticulo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        cerrarconexion()
    End Sub
    Private Sub dgvArticulo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvArticulo.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then

        End If
    End Sub
    Protected Overloads Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, keyData As System.Windows.Forms.Keys) As Boolean
        '
        ' Si el control DataGridView no tiene el foco, 
        ' se abandonamos el procedimiento, llamando al metodo base
        '
        If (Not dgvArticulo.Focused) Then
            Return MyBase.ProcessCmdKey(msg, keyData)
        End If

        '
        ' Si la tecla presionada es distinta al ENTER, 
        ' se abandonamos el procedimiento, llamando al metodo base
        '
        If keyData <> Keys.Enter Then
            Return MyBase.ProcessCmdKey(msg, keyData)
        End If
        Dim row As DataGridViewRow = dgvArticulo.CurrentRow
        Dim i As Integer
        i = dgvArticulo.CurrentRow.Index
        muestraequivalencias(dgvArticulo.Item(0, i).Value)
        muestraprecios(dgvArticulo.Item(0, i).Value)
        muestraexistencias(dgvArticulo.Item(0, i).Value)
        muestrapreciosxsucursal(dgvArticulo.Item(0, i).Value)
        Return True
    End Function
    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Not String.IsNullOrEmpty(txtCodArt.Text) Then
            ProgressBar1.Increment(50)
        ElseIf Not String.IsNullOrEmpty(txtDescArt.Text) Then
            ProgressBar1.Increment(3)
        End If
    End Sub
    Private Sub ProgressBar1_Click(sender As Object, e As EventArgs) Handles ProgressBar1.Click
        ProgressBar1.Maximum = 100
    End Sub
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        If String.IsNullOrEmpty(txtCodArt.Text) = False Then
            'consultadearticuloporcodigo()
            Dim sqlcomando As New OleDb.OleDbCommand
            Dim sqlstring As String
            Try
                '08-03-2017: Se agrego comprometido
                'sqlstring = "select a.Articulo_Id Articulo, a.Articulo_Nombre Nombre,convert(int,ux.UXB)UXB,convert(int,vu.UXI) UXI,case when (select d.porcentaje from dbo.articulo_impuesto d (nolock) where d.Articulo_Id=a.Articulo_Id ) = 0.13 then 'NO' else 'SI'end  Excento, (select top 1 convert(decimal(10,2),b.AxS_Costo_Actual)Costo from dbo.Articulo_x_Sucursal b (nolock) where b.articulo_id = a.articulo_id group by b.axs_costo_actual)as Costo from  dbo.Articulo a (nolock), dbo.vista_uinterna vu (nolock), dbo.vista_uxb ux (nolock) where a.Articulo_Id=vu.Articulo_Id and a.Articulo_Id=ux.Articulo_Id and a.Articulo_Id=" + com(txtCodArt.Text)
                sqlstring = "select a.Articulo_Id Articulo, a.Articulo_Nombre Nombre,convert(int,ux.UXB)UXB,convert(int,vu.UXI) UXI,case when (select d.porcentaje from dbo.articulo_impuesto d (nolock) where d.Articulo_Id=a.Articulo_Id ) = 0.13 then 'NO' else 'SI'end  Excento, (select top 1 convert(decimal(10,2),b.AxS_Costo_Actual)Costo from dbo.Articulo_x_Sucursal b (nolock) where b.articulo_id = a.articulo_id group by b.axs_costo_actual)as Costo, (SELECT convert(int,SUM(ab.AxB_Comprometido)) FROM dbo.Articulo_x_Bodega ab WHERE a.Articulo_Id = ab.Articulo_Id AND ab.Suc_Id = 1001) AS Comprometido from  dbo.Articulo a (nolock), dbo.vista_uinterna vu (nolock), dbo.vista_uxb ux (nolock) where a.Articulo_Id=vu.Articulo_Id and a.Articulo_Id=ux.Articulo_Id and a.Articulo_Id=" + com(txtCodArt.Text)
                sqlcomando.CommandText = sqlstring
                sqlcomando.CommandType = CommandType.Text
                sqlcomando.Connection = Conexion
                Dim dt As New DataTable
                dt.Load(sqlcomando.ExecuteReader)
                If dt.Rows.Count > 0 Then
                    art = dt.Rows(0)("Articulo").ToString
                    e.Result = dt
                Else
                    Dim sqlcomando2 As New OleDb.OleDbCommand
                    Dim sqlstring2 As String
                    Try
                        sqlstring2 = "select a.Articulo_Id Articulo, a.Articulo_Nombre Nombre,convert(int,ux.UXB) UXB,convert(int,vu.UXI) UXI,case when (select d.porcentaje from dbo.articulo_impuesto d (nolock) where d.Articulo_Id=a.Articulo_Id ) = 0.13 then 'NO' else 'SI'end  Excento ,(select top 1 convert(decimal(10,2),b.AxS_Costo_Actual)COSTO from dbo.Articulo_x_Sucursal b (nolock)where b.articulo_id = a.articulo_id group by b.axs_costo_actual)as Costo from dbo.Articulo a (nolock), dbo.vista_uinterna vu (nolock),  dbo.vista_uxb ux (nolock), dbo.Articulo_Equivalente e (nolock) where a.Articulo_Id=vu.Articulo_Id and a.Articulo_Id=ux.Articulo_Id and a.Articulo_Id= e.Articulo_Id  and e.Equivalente_Id=" + com(txtCodArt.Text)
                        sqlcomando2.CommandText = sqlstring2
                        sqlcomando2.CommandType = CommandType.Text
                        sqlcomando2.Connection = Conexion
                        Dim dt2 As New DataTable
                        dt2.Load(sqlcomando2.ExecuteReader)
                        art = dt2.Rows(0)("Articulo").ToString
                        e.Result = dt2
                    Catch ex As Exception
                        MessageBox.Show("Codigo de articulo incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        ElseIf String.IsNullOrEmpty(txtDescArt.Text) = False Then
            'consultadearticulopordesc()
            Dim sqlcomando As New OleDb.OleDbCommand
            Dim sqlstring As String
            Try
                sqlstring = " select a.Articulo_Id Articulo,a.Articulo_Nombre Nombre,convert(int,ux.UXB) UXB,convert(int,vu.UXI) UXI,case when (select d.porcentaje from dbo.articulo_impuesto d (nolock) where d.Articulo_Id=a.Articulo_Id ) = 0.13 then 'NO'  else 'SI'end  Excento ,(select top 1 convert(decimal(10,2),b.AxS_Costo_Actual)COSTO from dbo.Articulo_x_Sucursal b (nolock) where b.articulo_id = a.articulo_id group by b.axs_costo_actual)as Costo from dbo.Articulo a (nolock),  dbo.vista_uinterna vu (nolock),  dbo.vista_uxb ux (nolock) where a.Articulo_Id=vu.Articulo_Id  and a.Articulo_Id=ux.Articulo_Id and a.Articulo_Nombre like" + por(txtDescArt.Text)
                sqlcomando.CommandText = sqlstring
                sqlcomando.CommandType = CommandType.Text
                sqlcomando.Connection = Conexion
                Dim dt As New DataTable
                dt.Load(sqlcomando.ExecuteReader)
                e.Result = dt



            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Else
            MessageBox.Show("Por favor digite algun dato a buscar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted

        Try
            dgvArticulo.DataSource = e.Result
            dgvArticulo.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvArticulo.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvArticulo.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvArticulo.Columns(5).Visible = muestracostos
            If String.IsNullOrEmpty(txtCodArt.Text) = False Then
                cargardatos(art)
            End If
            If Not String.IsNullOrEmpty(txtCodArt.Text) Then
                txtCodArt.Focus()
            ElseIf Not String.IsNullOrEmpty(txtDescArt.Text) Then
                txtDescArt.Focus()
            End If
        Catch ex As Exception

        End Try


    End Sub
    Private Sub dgvExistencias_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvExistencias.CellContentClick

    End Sub
    Private Sub btnvermov_Click(sender As Object, e As EventArgs) Handles btnvermov.Click
        If Not art = "" Then
            If (DateTimePicker1.Value > DateTimePicker2.Value) Then
                MessageBox.Show("La fecha de Inicio debe ser menor a la de fin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                muestramovimientos(art)
                dgvMovimientos.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dgvMovimientos.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
        Else
            MessageBox.Show("Seleccione un articulo por favor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Not art = "" Then
            If (DateTimePicker5.Value > DateTimePicker6.Value) Then
                MessageBox.Show("La fecha de Inicio debe ser menor a la de fin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                verventas(art)
                dgvVentas.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dgvVentas.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dgvVentas.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
        Else
            MessageBox.Show("Seleccione un articulo por favor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not art = "" Then
            If (DateTimePicker3.Value > DateTimePicker4.Value) Then
                MessageBox.Show("La fecha de Inicio debe ser menor a la de fin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                mostrarcompras(art)
                dgvCompras.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dgvCompras.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
        Else
            MessageBox.Show("Seleccione un articulo por favor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                Ptb_Fotos.Image = Image.FromFile(Carticulo_imagen.Item("ruta") + Carticulo_imagen.Item("archivo"))
                Ptb_Fotos.ImageLocation = Carticulo_imagen.Item("ruta") + Carticulo_imagen.Item("archivo")
                Ptb_Fotos.Refresh()
            Else
                Ptb_Fotos.ImageLocation = ""
            End If
        Catch ex As Exception

        End Try

    End Sub


    Private Sub Ptb_Fotos_Click(sender As Object, e As EventArgs) Handles Ptb_Fotos.Click
        Dim vent As New frmZoomImagen
        codigo = Ptb_Fotos.ImageLocation
        vent.Show()
    End Sub


    Private Sub Bodegas_CheckedChanged(sender As Object, e As EventArgs) Handles Bodegas.CheckedChanged
        If Bodegas.Checked = True Then
            cbbodega.Visible = True
            Label8.Visible = True
            filtro = 1
        Else
            cbbodega.Visible = False
            Label8.Visible = False
            filtro = 2
        End If

    End Sub

    Private Sub bodega1_CheckedChanged(sender As Object, e As EventArgs) Handles bodega1.CheckedChanged
        If bodega1.Checked = True Then
            cbbodega1.Visible = True
            Label9.Visible = True
            filtro = 1
        Else
            cbbodega1.Visible = False
            Label9.Visible = False
            filtro = 2
        End If
    End Sub

    Private Sub ckactivas_CheckedChanged(sender As Object, e As EventArgs) Handles ckactivas.CheckedChanged
        cargarlistadeprecios(art)
        cargarpromociones(art)
        cargardescuentos(art)
    End Sub

    Private Sub dgvArticulo_MouseClick(sender As Object, e As MouseEventArgs) Handles dgvArticulo.MouseClick

    End Sub

    Private Sub dgvArticulo_MouseDown(sender As Object, e As MouseEventArgs) Handles dgvArticulo.MouseDown
        If e.Button = System.Windows.Forms.MouseButtons.Right Then
            Dim st As String
            Dim i As Integer
            i = dgvArticulo.CurrentRow.Index
            Dim h As Integer
            h = dgvArticulo.CurrentCell.ColumnIndex
            st = dgvArticulo.Item(h, i).Value
            Clipboard.SetText(st)

        End If
    End Sub
End Class