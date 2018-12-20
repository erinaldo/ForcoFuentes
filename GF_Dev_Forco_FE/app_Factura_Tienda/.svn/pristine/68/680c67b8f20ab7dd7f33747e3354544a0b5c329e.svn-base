Imports System.Data
Imports System.Data.SqlClient

Public Class clsFactura

    Public Shared Sub funGetFacturaElectronica_Tienda(ByVal nparSucursar As Integer,
                                               ByVal nparCaja As Integer,
                                               ByVal nparFactura As Integer,
                                               ByVal nparCliente As Integer)

        '-- Crear claves de factura electronica
        'If DBConnGlobal.State = ConnectionState.Open Then
        'Else
        'DBConnGlobal = New SqlConnection(funConexion())
        'DBConnGlobal.Open()
        'End If

        DBConnGlobal = New SqlConnection(funConexion())
        DBConnGlobal.Open()


        Dim cmd As SqlCommand = New SqlCommand("sp_Factura_Electronica_Crear", DBConnGlobal)

        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@sucursal", nparSucursar)
        cmd.Parameters.AddWithValue("@caja", nparCaja)
        cmd.Parameters.AddWithValue("@factura", nparFactura)
        cmd.Parameters.AddWithValue("@cliente", nparCliente)

        cmd.Connection = DBConnGlobal
        cmd.Transaction = transaccionGlobal
        cmd.ExecuteNonQuery()
        DBConnGlobal.Close()
        '--
    End Sub

End Class
