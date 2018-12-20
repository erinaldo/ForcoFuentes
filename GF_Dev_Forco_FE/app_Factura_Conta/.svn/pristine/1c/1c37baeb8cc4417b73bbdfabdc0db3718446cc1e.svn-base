Imports System.Data
Imports System.Data.SqlClient

Public Class clsFactura

    Public Shared Sub funGetFacturaElectronica(ByVal nparRazon As Integer, ByVal nparFactura As Integer)

        '-- Crear claves de factura electronica
        If DBConnGlobal.State = ConnectionState.Open Then
        Else
            DBConnGlobal = New SqlConnection(funConexion())
            DBConnGlobal.Open()
        End If

        Dim cmd As SqlCommand = New SqlCommand("sp_FacturaElectronica", DBConnGlobal)

        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@razon", nparRazon)
        cmd.Parameters.AddWithValue("@factura", nparFactura)

        cmd.Connection = DBConnGlobal
        cmd.Transaction = transaccionGlobal
        cmd.ExecuteNonQuery()
        DBConnGlobal.Close()
        '--
    End Sub

End Class
