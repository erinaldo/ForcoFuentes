Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmRepCierre

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
        strSQL = "SELECT * FROM dbo.vw_GB_Venta_Express " &
                    "WHERE CAST(dtmFechaDoc As Date) Between '" & strRango1 & "' " &
                    "AND '" & strRango2 & "' " &
                    "AND nEmpresa = " & intEmpresa
        '--
        ds = funFillDataSet(strSQL)
        '--
        Me.gcOrdenes.DataSource = funFillDataSet(strSQL).Tables(0)
        '--
        GridViewStyle(Me.GridView1)
        funOcultarTodasLasColumnas(Me.GridView1)
        indice = 0
        '--
        funSetColumna(GridView1, "dtmFechaDoc", "FECHA", funIndice(), 100, 1)
        funSetColumna(GridView1, "VentaTotal", "VENTAS", funIndice(), 150, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
        '--
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
        'If Me.GridView1.RowCount = 0 Then
        '    MsgBox("No Existen Registros ... !!!", MsgBoxStyle.Critical, "Información")
        '    Exit Sub
        'End If
        'Try
        '    FilePath = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
        '    Dim strFileName As String = FilePath & "\RepVentas.xlsx"
        '    Me.gcOrdenes.ExportToXlsx(strFileName)
        '    System.Diagnostics.Process.Start(strFileName)
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
        subPrint()
    End Sub


    Private Sub subPrint()
        '-- Esta pantalla era de compras
        Me.Cursor = Cursors.WaitCursor
        '--funProcesoPrint()
        Dim lstParametros As New List(Of String)
        '-- 
        lstParametros.Add(intEmpresa)
        lstParametros.Add(Me.GridView1.GetFocusedRowCellValue("dtmFechaDoc").ToString)
        '--
        funPrintConSp("repCierre_V1.rpt", lstParametros)
        Me.Cursor = Cursors.Default
    End Sub
End Class