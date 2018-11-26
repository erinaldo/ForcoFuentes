Public Class frmGenerarVistaReportes

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub btn_cerrar_Click(sender As Object, e As EventArgs) Handles btn_cerrar.Click
        Close()
    End Sub

    Private Sub btn_generar_Click(sender As Object, e As EventArgs) Handles btn_generar.Click
        Dim sqlcomando As New OleDb.OleDbCommand
        Dim sqlstring As String
        Try
            abrirconexion()
            'creacion de vistas 
            sqlcomando.CommandText = "IF object_id('vistafechadecompras') IS NOT NULL " & _
                                          " DROP VIEW dbo.vistafechadecompras "
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            sqlcomando.ExecuteNonQuery()

            sqlcomando.CommandText = " CREATE VIEW dbo.vistafechadecompras " & _
                                     " AS SELECT " + com(Format(Dtp_desde.Value, "dd/MM/yyyy")) + " 'Desde'," + com(Format(Dtp_hasta.Value, "dd/MM/yyyy")) + " 'Hasta'"
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            sqlcomando.ExecuteNonQuery()


            sqlcomando.CommandText = "IF object_id('vistafechamargen') IS NOT NULL " & _
                                         " DROP VIEW dbo.vistafechamargen "
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            sqlcomando.ExecuteNonQuery()

            sqlcomando.CommandText = " CREATE VIEW dbo.vistafechamargen " & _
                                     " AS SELECT " + com(Format(Dtp_desde2.Value, "dd/MM/yyyy")) + " 'Desde'," + com(Format(Dtp_Hasta2.Value, "dd/MM/yyyy")) + " 'Hasta'"
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            sqlcomando.ExecuteNonQuery()

            sqlcomando.CommandText = "IF object_id('VistaCompraArticulos') IS NOT NULL " & _
                                       " DROP VIEW dbo.VistaCompraArticulos "
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            sqlcomando.ExecuteNonQuery()
            'compras
            sqlcomando.CommandText = "CREATE VIEW dbo.VistaCompraArticulos" & _
        " AS SELECT b.Articulo_Id 'ARTICULO'" & _
        ", b.Boleta_Id 'DOCUMENTO'         " & _
        ", b.Detalle_Cantidad 'CANTIDAD'   " & _
        ", b.Detalle_Fecha 'FECHA'         " & _
        ", p.Prov_Id 'PROVEEDOR'           " & _
        ", p.Prov_Nombre 'NOMBRE'          " & _
        ", b.bodega_id 'BODEGA'          " & _
        "    FROM                        " & _
     " Boleta_Exterior_Detalle_Hist b (NOLOCK), Orden_Exterior_Encabezado o (NOLOCK), Calculo_Encabezado ce (NOLOCK), Boleta_Exterior_Encabezado_Hist beeh (NOLOCK), Proveedor p (NOLOCK)" & _
     "       WHERE                                                                                                                      " & _
      "       b.Emp_Id=beeh.Emp_Id                                                                                                      " & _
       "   and b.Suc_Id=beeh.Suc_Id                                                                                                     " & _
       "   and b.bodega_Id=beeh.bodega_Id                                                                                                     " & _
     "     and  o.Orden_Id = ce.Orden_Id                                                                                                      " & _
     " AND ce.Calculo_Id = beeh.Calculo_Id                                                                                                  " & _
     " AND beeh.Boleta_Id = b.Boleta_Id                                                                                                     " & _
     " AND p.Prov_Id = o.Prov_Id                                                                                                            " & _
     " AND b.Detalle_Fecha >= " + com(Format(Dtp_desde.Value, "MM/dd/yyyy")) & _
     " AND b.Detalle_Fecha <= " + com(Format(Dtp_hasta.Value, "MM/dd/yyyy")) & _
     "       UNION                                                                                                                      " & _
     " Select bl.Articulo_id 'ARTICULO'                                                                                                     " & _
      "  , bl.Boleta_Id 'DOCUMENTO'                                                                                                        " & _
      "  , bl.Detalle_Cantidad_Scaneo 'CANTIDAD'                                                                                          " & _
      "  , bl.Detalle_Fecha 'FECHA'                                                                                                        " & _
      "  , p.Prov_Id 'PROVEEDOR'                                                                                                           " & _
      "  , p.Prov_Nombre 'NOMBRE'                                                                                                          " & _
      "  , BL.BODEGA_ID 'BODEGA'                                                                                                          " & _
      "      FROM                                                                                                                        " & _
     " Boleta_Local_Detalle_Hist bl (NOLOCK), Proveedor p (NOLOCK), Boleta_Local_Encabezado_Hist be (NOLOCK)                                                          " & _
     "       WHERE                                                                                                                       " & _
     "       bl.Emp_Id=be.Emp_Id                                                                                                        " & _
     " and   bl.Suc_Id=be.Suc_Id                                                                                                      " & _
      " and   bl.bodega_Id=be.bodega_Id                                                                                                      " & _
     " and  p.Prov_Id = be.Prov_Id                                                                                                        " & _
     " AND bl.Boleta_Id = be.Boleta_Id                                                                                                      " & _
     " AND bl.Detalle_Fecha >= " + com(Format(Dtp_desde.Value, "MM/dd/yyyy")) & _
     " AND bl.Detalle_Fecha <= " + com(Format(Dtp_hasta.Value, "MM/dd/yyyy"))
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            sqlcomando.ExecuteNonQuery()
            'ventas
            sqlcomando.CommandText = "IF object_id('VistaMargenVentas') IS NOT NULL " & _
                                         " DROP VIEW dbo.VistaMargenVentas "
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            sqlcomando.ExecuteNonQuery()

            sqlcomando.CommandText = "CREATE VIEW dbo.VistaMargenVentas" & _
            " AS SELECT fd.Articulo_Id " & _
             " , sum((Detalle_Precio_Unitario - Detalle_Descuento_Monto) * Detalle_Cantidad) AS [Precio total]" & _
            " , sum(Detalle_Cantidad * Detalle_Costo_Unitario) AS [Costo Total]" & _
            " FROM dbo.Factura_Detalle  fd (NOLOCK)" & _
            " WHERE fd.Detalle_Fecha>=" + com(Format(Dtp_desde2.Value, "MM/dd/yyyy")) + "AND fd.Detalle_Fecha<=" + com(Format(Dtp_Hasta2.Value, "MM/dd/yyyy")) + "" & _
"            GROUP BY  Articulo_Id"
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            sqlcomando.ExecuteNonQuery()

            sqlcomando.CommandText = "IF object_id('SumaVentaArticulos') IS NOT NULL " & _
                                        " DROP VIEW dbo.SumaVentaArticulos "
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            sqlcomando.ExecuteNonQuery()

            sqlcomando.CommandText = "CREATE VIEW dbo.SumaVentaArticulos " & _
"AS SELECT Articulo_Id 'ARTICULO'" & _
        " , sum(Detalle_Cantidad) 'VENTAS'" & _
            " FROM Factura_Detalle fd (NOLOCK) " & _
    " WHERE fd.Detalle_Fecha>=" + com(Format(Dtp_desde2.Value, "MM/dd/yyyy")) + "AND fd.Detalle_Fecha<=" + com(Format(Dtp_Hasta2.Value, "MM/dd/yyyy")) + "" & _
"            GROUP BY  Articulo_Id"
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            sqlcomando.ExecuteNonQuery()
            MessageBox.Show("Datos Correctamente Creados", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Close()
            cerrarconexion()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            cerrarconexion()
        End Try
    End Sub
End Class