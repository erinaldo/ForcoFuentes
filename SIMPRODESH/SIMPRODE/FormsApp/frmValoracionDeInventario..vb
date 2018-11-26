Public Class frmValoracionDeInventario

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Close()
    End Sub

    Private Sub frmValoracionDeInventario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarbodegas()
    End Sub
    Private Sub cargarbodegas()
        Try
            abrirconexion()
            Dim sqlcomando1 As New OleDb.OleDbCommand
            sqlcomando1.CommandText = "Select Bodega_Id 'Bodega', Bodega_Nombre 'Nombre' from Bodega (NOLOCK) order by bodega_nombre"
            sqlcomando1.CommandType = CommandType.Text
            sqlcomando1.Connection = Conexion
            Dim dt As New DataTable
            dt.Load(sqlcomando1.ExecuteReader)
            cbbodega.DataSource = dt
            cbbodega.ValueMember = dt.Columns("Bodega").ToString()
            cbbodega.DisplayMember = dt.Columns("Nombre").ToString()
            cerrarconexion()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cerrarconexion()
        End Try
    End Sub

    Private Sub btnaceptar_Click(sender As Object, e As EventArgs) Handles btnaceptar.Click
        Dim sqlcomando As New OleDb.OleDbCommand
        Dim sqlstring As String
        Try
            abrirconexion()
            'creacion de vistas 
            sqlcomando.CommandText = "IF object_id('VistaValoracionDeInventario ') IS NOT NULL " & _
                                          " DROP VIEW dbo.VistaValoracionDeInventario  "
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            sqlcomando.ExecuteNonQuery()

            sqlcomando.CommandText = _
        "        CREATE VIEW dbo.VistaValoracionDeInventario " & _
        "    AS SELECT a.articulo_id 'Articulo'," + com(cbbodega.SelectedValue) + " 'Sucursal'" & _
        ", isnull((SELECT sum(ic.cola_cantidad)              " & _
        "    FROM                                         " & _
        "    inv_cola_existencias_histo ic(NOLOCK)           " & _
        "    WHERE                                         " & _
        "            ic.cola_cantidad LIKE '%-%'              " & _
        "            AND a.Articulo_Id = ic.Articulo_id      " & _
        "            AND ic.Cola_Fecha<=" + com(Format(dtpfecha.Value, "MM/dd/yyyy")) & _
        "            AND ic.bodega_Id=" + com(cbbodega.SelectedValue) & _
        "    GROUP BY                                        " & _
        "            ic.articulo_id), 0) 'Salidas'           " & _
        ", isnull((SELECT sum(ic.cola_cantidad)              " & _
        "    FROM                                          " & _
        "    inv_cola_existencias_histo ic(NOLOCK)           " & _
        "    WHERE                                         " & _
        "            ic.cola_cantidad NOT LIKE '%-%'          " & _
        "            AND a.Articulo_Id = ic.Articulo_id      " & _
        "            AND ic.Cola_Fecha<=" + com(Format(dtpfecha.Value, "MM/dd/yyyy")) & _
        "            AND ic.bodega_Id=" + com(cbbodega.SelectedValue) & _
        "    GROUP BY                                        " & _
        "            ic.articulo_id), 0) 'Entradas'          " & _
        "    FROM                                          " & _
        "    Articulo a(NOLOCK)                              "

            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            sqlcomando.ExecuteNonQuery()
            cerrarconexion()
            rutareporte = rutainventario & "ReporteValoracionInventarioDepartamentoFechaCorte.rpt"
            llama_despliegue()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cerrarconexion()
        End Try
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class