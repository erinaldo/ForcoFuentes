Imports System.Data
Imports System.Data.SqlClient

Public Class clsComplementos
    Public Shared Function funGetComplemento(ByVal nparEmpresa As Integer, _
                                                    ByVal nparYear As Integer, _
                                                    ByVal nparDependencia As Integer, _
                                                    ByVal nparConcepto As Integer, _
                                                    ByVal cparBimestre As String) As DataSet
        '-- 12-11-2012: Traer datos del complemento
        Dim ds As New DataSet
        '--
        Dim oLayer As Component.Data.SQL.Layer.PrimitiveTable = Nothing
        Component.Data.SQL.Layer.PrimitiveConnection.connectionString = funConexion()
        oLayer = New Component.Data.SQL.Layer.PrimitiveTable()
        '--
        oLayer.AddParameterInput("@nEmpresa", nparEmpresa)
        oLayer.AddParameterInput("@nYear", nparYear)
        oLayer.AddParameterInput("@nDependencia", nparDependencia)
        oLayer.AddParameterInput("@nConcepto", nparConcepto)
        oLayer.AddParameterInput("@cBimestre", cparBimestre, 3)
        '--
        ds = oLayer.ExecuteDataSet(String.Empty, "spGetComplemento", "Complemento")
        '--
        Return ds
    End Function

    Public Shared Function funGetListRocFacturacion(ByVal nparEmpresa As Integer, _
                                                    ByVal cparUsuario As String, _
                                                    ByVal nparYear As Integer, _
                                                    ByVal nparMes As Integer) As DataSet
        '-- 24-09-2010: Traer lista de facturas registradas
        Dim ds As New DataSet
        '--
        Dim oLayer As Component.Data.SQL.Layer.PrimitiveTable = Nothing
        Component.Data.SQL.Layer.PrimitiveConnection.connectionString = funConexion()
        oLayer = New Component.Data.SQL.Layer.PrimitiveTable()
        '--
        oLayer.AddParameterInput("@empresa", nparEmpresa)
        oLayer.AddParameterInput("@userprint", cparUsuario, 90)
        oLayer.AddParameterInput("@annio", nparYear)
        oLayer.AddParameterInput("@mes", nparMes)
        '--
        ds = oLayer.ExecuteDataSet(String.Empty, "spCxcListRocFacturacion", "Facturacion")
        '--
        Return ds
    End Function
End Class
