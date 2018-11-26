Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmRepMargen_Open

    Dim ds As New DataSet
    'Dim focus As Object
    Dim fila As Integer
    Dim GridCol As Integer
    Dim vnNumeroOrden As Integer
    Dim strNumeroOrden As String
    Dim nStatusOrden As Integer
    Dim vnConcepto As Integer = vnTipoAjuste
    Shadows focus As Object
    Dim FilePath As String

    Private Sub btnSalir_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnSalir.ItemClick
        Me.Close()
    End Sub

    Private Function funUpdateGrid() As Boolean
        '--
        Dim strRango1 As String = funFechaSql(Me.dtpInicio.Value.Date, True)
        Dim strRango2 As String = funFechaSql(Me.dtpFinal.Value.Date, True)
        '--
        'strSQL = "SELECT 'PLANTA PRODUCCION - SH' 'EMPRESA', " &
        '            "SUM(ncantidad) 'CANTIDAD_VENDIDA'," &
        '            "SUM(costototal) 'COSTO_TOTAL'," &
        '            "SUM(ValorVenta) 'VALOR_VENTAS'," &
        '            "SUM(MargenUtilidad) 'MARGEN_UTILIDAD'," &
        '            "(SUM(MargenUtilidad) / SUM(ValorVenta)) * 100 '%_UTILIDAD'" &
        '            "From dbo.vw_GB_Ventas_Margen " &
        '            "WHERE CAST(dtmFechaDoc As Date) Between '" & strRango1 & "' " &
        '            " AND '" & strRango2 & "' " &
        '            " AND nEmpresa = " & intEmpresa
        '--
        strSQL = "SELECT  CASE WHEN nExpress = 0 THEN 'Fanquicia' " &
                    "ELSE 'Express' " &
                    "END AS 'CLIENTE', " &
                    "SUM(nCantidad) 'CANTIDAD_VENDIDA', " &
                    "SUM(CostoTotal) 'COSTO_TOTAL', " &
                    "SUM(ValorVenta) 'VALOR_VENTAS', " &
                    "SUM(MargenUtilidad) 'MARGEN_UTILIDAD', " &
                    "(SUM(MargenUtilidad) / SUM(ValorVenta) ) * 100 '%_UTILIDAD' " &
                    "From dbo.vw_GB_Ventas_Margen " &
                    "WHERE CAST(dtmFechaDoc As Date) Between '" & strRango1 & "' " &
                    "AND '" & strRango2 & "' " &
                    "AND nEmpresa = " & intEmpresa &
                    " GROUP BY nExpress"
        '--
        ds = funFillDataSet(strSQL)
        '--
        Me.gcOrdenes.DataSource = funFillDataSet(strSQL).Tables(0)
        '--
        GridViewStyle(Me.GridView1)
        funOcultarTodasLasColumnas(Me.GridView1)
        indice = 0
        '--
        'funSetColumna(GridView1, "EMPRESA", "EMPRESA", funIndice(), 200, 1)
        'funSetColumna(GridView1, "CANTIDAD_VENDIDA", "CANTIDAD_VENDIDA", funIndice(), 150, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
        'funSetColumna(GridView1, "COSTO_TOTAL", "COSTO_TOTAL", funIndice(), 150, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
        'funSetColumna(GridView1, "VALOR_VENTAS", "VALOR_VENTAS", funIndice(), 150, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
        'funSetColumna(GridView1, "MARGEN_UTILIDAD", "MARGEN_UTILIDAD", funIndice(), 150, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
        'funSetColumna(GridView1, "%_UTILIDAD", "%_UTILIDAD", funIndice(), 150, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)

        funSetColumna(GridView1, "CLIENTE", "EMPRESA", funIndice(), 200, 1)
        funSetColumna(GridView1, "CANTIDAD_VENDIDA", "CANTIDAD_VENDIDA", funIndice(), 150, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
        funSetColumna(GridView1, "COSTO_TOTAL", "COSTO_TOTAL", funIndice(), 150, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
        funSetColumna(GridView1, "VALOR_VENTAS", "VALOR_VENTAS", funIndice(), 150, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
        funSetColumna(GridView1, "MARGEN_UTILIDAD", "MARGEN_UTILIDAD", funIndice(), 150, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
        funSetColumna(GridView1, "%_UTILIDAD", "%_UTILIDAD", funIndice(), 150, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)

        Return True
    End Function

    Private Sub frmRepMargen_Open_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        funUpdateGrid()
    End Sub

    Private Sub bbProceso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bbProceso.Click
        '--
        funUpdateGrid()
        '--
    End Sub

    Private Sub btnExcel_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExcel.ItemClick
        If Me.GridView1.RowCount = 0 Then
            MsgBox("No Existen Registros ... !!!", MsgBoxStyle.Critical, "Información")
            Exit Sub
        End If
        Try
            FilePath = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
            Dim strFileName As String = FilePath & "\RepVentas.xlsx"
            Me.gcOrdenes.ExportToXlsx(strFileName)
            System.Diagnostics.Process.Start(strFileName)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class