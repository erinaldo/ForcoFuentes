Public Class frmGenerarVistaReportesFormaPago

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
            sqlcomando.CommandText = "IF object_id('vistafechafactura') IS NOT NULL " & _
                                          " DROP VIEW dbo.vistafechafactura "
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            sqlcomando.ExecuteNonQuery()

            sqlcomando.CommandText = " CREATE VIEW dbo.vistafechafactura " & _
                                     " AS SELECT " + com(Format(Dtp_desde.Value, "dd/MM/yyyy")) + " 'Desde'," + com(Format(Dtp_hasta.Value, "dd/MM/yyyy")) + " 'Hasta'"
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            sqlcomando.ExecuteNonQuery()


            sqlcomando.CommandText = "IF object_id('VistaFormaPago') IS NOT NULL " & _
                                       " DROP VIEW dbo.VistaFormaPago "
            sqlcomando.CommandType = CommandType.Text
            sqlcomando.Connection = Conexion
            sqlcomando.ExecuteNonQuery()
            'Ventas Forma pago 
            sqlcomando.CommandText = _
                "CREATE VIEW dbo.VistaFormaPago" & _
        " AS SELECT suc_id" & _
        ", Tipo_id " & _
        ", pago_fecha AS 'Fecha'" & _
        ", Pago_Total AS 'MONTO'" & _
           " FROM" & _
     "  dbo.Factura_Forma_Pago (NOLOCK)" & _
     " WHERE " & _
     " pago_fecha between " + com(Format(Dtp_desde.Value, "yyyy/MM/dd")) & _
     " and " + com(Format(Dtp_hasta.Value.AddDays(1), "yyyy/MM/dd")) & _
     " UNION " & _
     " SELECT suc_id " & _
      " , tipo_id = 7 " & _
      " , factura_Fecha AS 'Fecha'" & _
      " , Factura_Total AS 'Monto'" & _
           "  FROM " & _
     " dbo.Factura_encabezado (NOLOCK) " & _
     " WHERE" & _
     " TipoDoc_id=3 " & _
     " and factura_fecha between " + com(Format(Dtp_desde.Value, "yyyy/MM/dd")) & _
     " and " + com(Format(Dtp_hasta.Value.AddDays(1), "yyyy/MM/dd")) & _
      " UNION " & _
     " SELECT suc_id " & _
      " , tipo_id = 8 " & _
      " , factura_Fecha AS 'Fecha'" & _
      " , Factura_Total AS 'Monto'" & _
            "  FROM " & _
     " dbo.Factura_encabezado (NOLOCK) " & _
     " WHERE" & _
     " TipoDoc_id=4 " & _
    " and factura_fecha between " + com(Format(Dtp_desde.Value, "yyyy/MM/dd")) & _
     "and " + com(Format(Dtp_hasta.Value.AddDays(1), "yyyy/MM/dd")) & _
     " UNION " & _
     " SELECT suc_id " & _
      " , tipo_id = 9 " & _
      " , retiro_fecha AS 'Fecha'" & _
       " , Retiro_Efectivo AS 'Monto' " & _
           "FROM " & _
     " dbo.caja_cierre_retiro (NOLOCK) " & _
     " WHERE" & _
     " retiro_tipo='D'" & _
     " and retiro_estado='DE' " & _
     " and retiro_fecha between " + com(Format(Dtp_desde.Value, "yyyy/MM/dd")) & _
     " and " + com(Format(Dtp_hasta.Value.AddDays(1), "yyyy/MM/dd")) & _
     " UNION " & _
      " SELECT suc_id" & _
        ", Tipo_id= 11 " & _
        ", Devolucion_Fecha AS 'Fecha'" & _
        ", Devolucion_Total AS 'Monto'" & _
           " FROM" & _
     "  dbo.Factura_Devolucion (NOLOCK)" & _
     " WHERE " & _
     "Devolucion_Efectivo =1 " & _
     " and Devolucion_Fecha between" + com(Format(Dtp_desde.Value, "yyyy/MM/dd")) & _
     " and " + com(Format(Dtp_hasta.Value.AddDays(1), "yyyy/MM/dd")) & _
    " UNION " & _
     " SELECT suc_id " & _
      " , tipo_id = 12 " & _
      " , retiro_fecha AS 'Fecha'" & _
       " , Retiro_MonedaExt AS 'Monto' " & _
           "FROM " & _
     " dbo.caja_cierre_retiro (NOLOCK) " & _
     " WHERE" & _
     " Retiro_MonedaExt>1" & _
     " and retiro_fecha between " + com(Format(Dtp_desde.Value, "yyyy/MM/dd")) & _
     " and " + com(Format(Dtp_hasta.Value.AddDays(1), "yyyy/MM/dd"))
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