Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmFactura_Open
    Dim ds As New DataSet
    'Dim focus As Object
    Dim fila As Integer
    Dim GridCol As Integer
    Dim vnNumeroOrden As Integer
    Dim strNumeroOrden As String
    Dim nStatusOrden As Integer
    Shadows focus As Object
    Dim vnConcepto As Integer = 9
    Dim FilePath As String

    Private Sub btnSalir_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnSalir.ItemClick
        Me.Close()
    End Sub

    Private Sub frmFactura_Open_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        funUpdateGrid()
    End Sub

    Private Sub btnNuevo_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnNuevo.ItemClick
        'Dim f As New frmCompra_Data
        Dim f As New frmFactura_Data
        f.txtStatus.Caption = "Agregando Factura"
        f.nTipo = 1
        f.vnRecno = 0
        f.ShowDialog()
        RegistroActual()
    End Sub

    Private Sub btnEditar_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnEditar.ItemClick
        If Me.GridView1.RowCount = 0 Then
            Exit Sub
        End If
        Dim f As New frmFactura_Data
        f.txtStatus.Caption = "Editando Registro ..."
        f.nTipo = 2
        f.vnNumero = funNull2Val(Me.GridView1.GetFocusedRowCellValue("nNumero"))
        f.vnRecno = funNull2Val(Me.GridView1.GetFocusedRowCellValue("nRecno"))
        f.vnConcepto = funNull2Val(Me.GridView1.GetFocusedRowCellValue("nConcepto"))
        f.vnTipoMovimiento = funNull2Val(Me.GridView1.GetFocusedRowCellValue("nTipoMovto"))
        f.ShowDialog()
        funRegistroActual()
    End Sub

    Private Sub RegistroActual()
        Me.gcOrdenes.Focus()
        If Me.GridView1.RowCount > 0 Then
            focus = Me.GridView1.FocusedValue()
            fila = Me.GridView1.FocusedRowHandle
        End If
        funUpdateGrid()
        If Me.GridView1.RowCount > fila Then
            Me.GridView1.FocusedRowHandle = fila
            Me.GridView1.SetFocusedValue(focus)
        End If
    End Sub

    Private Sub bbProceso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bbProceso.Click
        funUpdateGrid()
    End Sub

    Private Sub funRegistroActual()
        Me.gcOrdenes.Focus()
        If Me.GridView1.RowCount > 0 Then
            focus = Me.GridView1.FocusedValue()
            fila = Me.GridView1.FocusedRowHandle
        End If
        funUpdateGrid()
        If Me.GridView1.RowCount > fila Then
            Me.GridView1.FocusedRowHandle = fila
            Me.GridView1.SetFocusedValue(focus)
        End If
    End Sub

    Private Function funUpdateGrid() As Boolean
        Dim strRango1 As String = funFechaSql(Me.dtpInicio.Value.Date, True)
        Dim strRango2 As String = funFechaSql(Me.dtpFinal.Value.Date, True)
        '--
        strSQL = "SELECT * FROM vw_GB_Facturas2 " &
                    "WHERE CAST(FECHA AS DATE) Between '" & strRango1 & "' " &
                    " AND '" & strRango2 & "' " &
                    " AND EMPRESA = " & intEmpresa &
                    " AND CONCEPTO = " & vnConcepto &
                    " ORDER BY FACTURA"
        '--
        ds = funFillDataSet(strSQL)
        '--
        Me.gcOrdenes.DataSource = funFillDataSet(strSQL).Tables(0)
        '--
        GridViewStyle(Me.GridView1)
        funOcultarTodasLasColumnas(Me.GridView1)
        indice = 0
        '--
        funSetColumna(GridView1, "FACTURA", "FACTURA", funIndice(), 60, 1)
        funSetColumna(GridView1, "FECHA", "FECHA", funIndice(), 80, 1)
        funSetColumna(GridView1, "TIPOVENTA", "T.VENTA", funIndice(), 80, 1)
        funSetColumna(GridView1, "SOCIEDAD", "SOCIEDAD", funIndice(), 200, 1)
        funSetColumna(GridView1, "CLIENTE", "RECEPTOR", funIndice(), 200, 1)
        funSetColumna(GridView1, "SUB_TOTAL", "SUB_TOTAL", funIndice(), 90, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
        funSetColumna(GridView1, "DESCUENTO", "DESCUENTO", funIndice(), 90, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
        funSetColumna(GridView1, "IVA", "IVA", funIndice(), 90, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
        funSetColumna(GridView1, "TOTAL", "TOTAL", funIndice(), 100, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
        funSetColumna(GridView1, "CONSECUTIVO", "CONSECUTIVO", funIndice(), 150, 1)
        funSetColumna(GridView1, "CLAVE", "CLAVE", funIndice(), 320, 1)
        funSetColumna(GridView1, "RECEPCION", "RECEPCION", funIndice(), 80, 1)
        funSetColumna(GridView1, "ESTADO_RECEPCION", "ESTADO_RECEPCION", funIndice(), 80, 1)
        '--
        Return True
    End Function

    Private Sub btnPrint_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnPrint.ItemClick
        subPrint()
    End Sub

    Private Sub subPrint()
        '-- Esta pantalla era de compras
        Me.Cursor = Cursors.WaitCursor
        '--funProcesoPrint()
        Dim lstParametros As New List(Of String)
        '-- 
        lstParametros.Add(intEmpresa)
        lstParametros.Add(Me.GridView1.GetFocusedRowCellValue("RAZON").ToString)
        lstParametros.Add(Me.GridView1.GetFocusedRowCellValue("CONCEPTO").ToString)
        lstParametros.Add(Me.GridView1.GetFocusedRowCellValue("FACTURA").ToString)
        '--
        funPrintConSp("repFacturaFE.rpt", lstParametros)
        Me.Cursor = Cursors.Default
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