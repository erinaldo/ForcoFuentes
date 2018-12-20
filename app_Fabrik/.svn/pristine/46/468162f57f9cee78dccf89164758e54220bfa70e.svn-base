Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmRepCompras_Open
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
        strSQL = "SELECT * FROM vw_GB_Compras " &
                    "WHERE CAST(dtmFechaDoc AS DATE) Between '" & strRango1 & "' " &
                    " AND '" & strRango2 & "' " &
                    " AND nEmpresa = " & intEmpresa &
                    " ORDER BY nNumero"
        '--
        ds = funFillDataSet(strSQL)
        '--
        Me.gcOrdenes.DataSource = funFillDataSet(strSQL).Tables(0)
        '--
        GridViewStyle(Me.GridView1)
        funOcultarTodasLasColumnas(Me.GridView1)
        indice = 0
        '--
        funSetColumna(GridView1, "nNumero", "No.", funIndice(), 60, 1)
        funSetColumna(GridView1, "dtmFechaDoc", "Fecha", funIndice(), 80, 1)
        funSetColumna(GridView1, "strClave", "Cod.", funIndice(), 90, 1)
        funSetColumna(GridView1, "strData", "Descripción", funIndice(), 200, 1)
        funSetColumna(GridView1, "nCantidad", "Cantidad.", funIndice(), 70, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
        funSetColumna(GridView1, "nPUnitario", "P.Unitario", funIndice(), 80, 1, , , "n4", 3, , DevExpress.Utils.FormatType.Numeric)
        funSetColumna(GridView1, "nSubTotal", "Sub-Total", funIndice(), 90, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
        funSetColumna(GridView1, "nMontoDescuento", "Monto Descto.", funIndice(), 90, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
        funSetColumna(GridView1, "nTotalSinIva", "Total Sin  Iva", funIndice(), 90, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
        funSetColumna(GridView1, "nMontoIva", "Impuesto", funIndice(), 80, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
        funSetColumna(GridView1, "nGranTotal", "Total", funIndice(), 100, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
        Return True
    End Function

    Private Sub frmRepVentas_Open_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            Dim strFileName As String = FilePath & "\RepCompras.xlsx"
            Me.gcOrdenes.ExportToXlsx(strFileName)
            System.Diagnostics.Process.Start(strFileName)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class