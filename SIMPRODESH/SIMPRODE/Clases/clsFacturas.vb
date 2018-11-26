Imports System.Data
Imports System.Data.SqlClient

Public Class clsFacturas

    Public Shared Function funGetFacturaDS(ByVal nparSuc_Id As Integer,
                                            ByVal nparTipo_Id As Integer) As DataSet
        '-- Carga datos de facturas
        Dim Parametros As New List(Of SqlParameter)
        Parametros.Add(New SqlParameter("@suc_id", nparSuc_Id))
        Parametros.Add(New SqlParameter("@tipo_id", nparTipo_Id))
        '--
        Dim ds As DataSet
        '--
        strSQL = "SELECT * FROM Factura_Encabezado WHERE Suc_Id = @suc_id and Tipo_Id = @tipo_id"
        '--
        ds = clsData.ExecuteQueryDs(strSQL, Parametros)
        Return ds
        '--
    End Function
End Class

