Public Class frmGenerarVistaReportesfp

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
            sqlcomando.CommandText = "IF object_id('vistaFactura') IS NOT NULL " & _
                                          " DROP VIEW dbo.vistaFactura "
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            sqlcomando.ExecuteNonQuery()

            sqlcomando.CommandText = " CREATE VIEW dbo.vistaFactura" & _
                                     " AS SELECT " + com(Format(Dtp_desde.Value, "dd/MM/yyyy")) + " 'Desde'," + com(Format(Dtp_hasta.Value, "dd/MM/yyyy")) + " 'Hasta'"
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            sqlcomando.ExecuteNonQuery()


            sqlcomando.CommandText = "IF object_id('vistaDolares') IS NOT NULL " & _
                                         " DROP VIEW dbo.vistaDolares "
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            sqlcomando.ExecuteNonQuery()

            sqlcomando.CommandText = " CREATE VIEW dbo.vistaDolares " & _
                                     " AS SELECT " + com(Format(Dtp_desde2.Value, "dd/MM/yyyy")) + " 'Desde'," + com(Format(Dtp_Hasta2.Value, "dd/MM/yyyy")) + " 'Hasta'"
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            sqlcomando.ExecuteNonQuery()

            sqlcomando.CommandText = "IF object_id('VistaFacturaFP') IS NOT NULL " & _
                                       " DROP VIEW dbo.VistaFacturaFP"
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            sqlcomando.ExecuteNonQuery()
            'Facturas
            sqlcomando.CommandText = "CREATE VIEW dbo.VistaFacturaFP" & _
        " AS SELECT Factura_Id " & _
        ", Suc_Id         " & _
        ", Caja_Id   " & _
        ", Tipodoc_Id   " & _
        ", Factura_Exento        " & _
        ", Factura_Exento_Bruto           " & _
        ", Factura_Descuento_Exento          " & _
        ", Factura_Gravado          " & _
        ", Factura_Gravado_Bruto          " & _
        ", Factura_Descuento_Gravado          " & _
        ", Factura_Impuesto          " & _
        ", Factura_Subtotal          " & _
        ", Factura_Total         " & _
        ", Factura_FP_Efectivo          " & _
        ", Factura_FP_Tarjeta          " & _
        ", Factura_FP_Cheque          " & _
        ", Factura_FP_NotaCredito          " & _
        ", Factura_FP_Cupon          " & _
         ", Factura_redondeo          " & _
        ", Factura_Fecha          " & _
        "    FROM                        " & _
     " Factura_Encabezado" & _
     "       WHERE  " & _
     " factura_fecha >= " + com(Format(Dtp_desde.Value, "MM/dd/yyyy")) & _
     " AND factura_fecha <= " + com(Format(Dtp_hasta.Value, "MM/dd/yyyy"))
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            sqlcomando.ExecuteNonQuery()
            'Dolares
            sqlcomando.CommandText = "IF object_id('VistaDolaresFP') IS NOT NULL " & _
                                         " DROP VIEW dbo.VistaDolaresFP "
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            sqlcomando.ExecuteNonQuery()

            sqlcomando.CommandText = "CREATE VIEW dbo.VistaDolaresFP" & _
            " AS SELECT Suc_Id " & _
            " ,Factura_Id " & _
            " ,Caja_Id " & _
            " ,Moneda_Id " & _
            " ,Pago_Fecha" & _
            " ,Pago_Total" & _
            " ,Pago_Total_Moneda" & _
            " ,Pago_Total_Tipo_Cambio" & _
            " FROM dbo.Factura_Forma_Pago (NOLOCK)" & _
            " WHERE Moneda_id=2" & _
             " and Pago_Fecha>=" + com(Format(Dtp_desde2.Value, "MM/dd/yyyy")) + "AND Pago_Fecha<=" + com(Format(Dtp_Hasta2.Value, "MM/dd/yyyy"))
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
