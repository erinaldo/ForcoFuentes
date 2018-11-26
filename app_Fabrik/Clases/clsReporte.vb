Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class clsReporte
    Public Shared Function funListaConceptosDs() As DataSet
        '-- Carga Conceptos
        Dim ds As DataSet
        '--
        strSQL = "SELECT *, CONVERT(bit,0) AS optSelection " & _
                    " FROM Inv_Concepto"
        '--
        ds = clsData.ExecuteQueryDs(strSQL)
        Return ds
        '--
    End Function

    Public Shared Function funGetDataRepMovDetalle(ByVal nparEmpresa As Integer, _
                                                    ByVal cparDesde As String, _
                                                    ByVal cparHasta As String, _
                                                    ByVal cparConcepto As String) As DataSet
        '-- 11-09-2010: Traer datos el reporte RepMovDetalle, filtro seleccion multiple
        Dim ds As New DataSet
        '--
        Dim oLayer As Component.Data.SQL.Layer.PrimitiveTable = Nothing
        Component.Data.SQL.Layer.PrimitiveConnection.connectionString = funConexion()
        oLayer = New Component.Data.SQL.Layer.PrimitiveTable()
        '--
        oLayer.AddParameterInput("@empresa", nparEmpresa)
        oLayer.AddParameterInput("@fecha1", cparDesde, 10)
        oLayer.AddParameterInput("@fecha2", cparHasta, 10)
        oLayer.AddParameterInput("@concepto", cparConcepto, 20)
        '--
        ds = oLayer.ExecuteDataSet(String.Empty, "spCxcRepMovDetalle", "Tramos")
        '--
        Return ds
    End Function
End Class
