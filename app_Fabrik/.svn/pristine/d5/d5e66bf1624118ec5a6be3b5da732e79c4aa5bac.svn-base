Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmOrden_Open
    Dim ds As New DataSet
    'Dim focus As Object
    Dim fila As Integer
    Dim GridCol As Integer
    Dim vnNumeroOrden As Integer
    Dim strNumeroOrden As String
    Dim nStatusOrden As Integer
    Shadows focus As Object
    Dim vnConcepto As Integer = vnTipoSalida

    Private Sub btnSalir_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnSalir.ItemClick
        Me.Close()
    End Sub

    Private Function funUpdateGrid() As Boolean
        '--
        Dim strRango1 As String = funFechaSql(Me.dtpInicio.Value.Date, True)
        Dim strRango2 As String = funFechaSql(Me.dtpFinal.Value.Date, True)
        '--
        strSQL = "SELECT * FROM vw_Orden_Open " &
                    "WHERE CAST(dtmFecha AS DATE) Between '" & strRango1 & "' " &
                    " AND '" & strRango2 & "' " &
                    " AND nEmpresa = " & intEmpresa & " " &
                    " ORDER BY nOrden"
        '--
        ds = funFillDataSet(strSQL)
        '--
        Me.gcOrdenes.DataSource = funFillDataSet(strSQL).Tables(0)
        '--
        GridViewStyle(Me.GridView1)
        funOcultarTodasLasColumnas(Me.GridView1)
        indice = 0
        '--
        funSetColumna(Me.GridView1, "dtmFecha", "Fecha", funIndice(), 80, 1)
        funSetColumna(Me.GridView1, "nOrden", "No.", funIndice(), 80, 1)
        funSetColumna(Me.GridView1, "strData", "Concepto", funIndice(), 300, 1)
        funSetColumna(Me.GridView1, "nCantidad", "Paletas", funIndice(), 100, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
        funSetColumna(Me.GridView1, "nCostoTotal", "Costo Total", funIndice(), 100, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
        funSetColumna(Me.GridView1, "nCostoPorPaleta", "Costo x Paleta", funIndice(), 100, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
        '-- Numero de Registros
        '-- Me.barText.Caption = "Registros: " & ds.Tables("Tabla").Rows.Count
        Return True
    End Function

    Private Sub frmOrden_Open_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        funUpdateGrid()
    End Sub

    Private Sub btnNuevo_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnNuevo.ItemClick
        'Dim f As New frmCompra_Data
        Dim f As New frmOrden_Data
        f.txtStatus.Caption = "Agregando Orden de Producción"
        f.nTipo = 1
        f.vnRecno = 0
        f.ShowDialog()
        RegistroActual()
    End Sub

    Private Sub btnEditar_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnEditar.ItemClick
        If Me.GridView1.RowCount = 0 Then
            Exit Sub
        End If
        Dim f As New frmOrden_Data
        f.txtStatus.Caption = "Editando Registro ..."
        f.nTipo = 2
        f.vnNumero = funNull2Val(Me.GridView1.GetFocusedRowCellValue("nOrden"))
        f.vnRecno = funNull2Val(Me.GridView1.GetFocusedRowCellValue("nRecno"))
        f.vnReceta = funNull2Val(Me.GridView1.GetFocusedRowCellValue("nReceta"))
        'f.vnTipoMovimiento = funNull2Val(Me.GridView1.GetFocusedRowCellValue("nTipoMovto"))
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

    Private Sub btnPrint_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnPrint.ItemClick
        subPrint()
    End Sub

    Private Sub subPrint()
        Me.Cursor = Cursors.WaitCursor
        '--funProcesoPrint()
        Dim lstParametros As New List(Of String)
        '-- GB-2012-01-12: Debe de ir en orden a los parametros del SP
        lstParametros.Add(intEmpresa)
        lstParametros.Add(Me.GridView1.GetFocusedRowCellValue("nNumero").ToString)
        lstParametros.Add(Me.GridView1.GetFocusedRowCellValue("nConcepto").ToString)
        lstParametros.Add(strUser)
        '--
        'funPrintConSp("repOrdenEntrada.rpt", lstParametros)
        funPrintConSp("repSolComp2.rpt", lstParametros)
        Me.Cursor = Cursors.Default
    End Sub
End Class