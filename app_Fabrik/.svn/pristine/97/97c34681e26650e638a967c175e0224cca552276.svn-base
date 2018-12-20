Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmFacturaEx_Open
    Dim ds As New DataSet
    'Dim focus As Object
    Dim fila As Integer
    Dim GridCol As Integer
    Dim vnNumeroOrden As Integer
    Dim strNumeroOrden As String
    Dim nStatusOrden As Integer
    Shadows focus As Object
    Dim vnConcepto As Integer = 9

    Private Sub btnSalir_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnSalir.ItemClick
        Me.Close()
    End Sub

    Private Sub frmFactura_Open_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        funUpdateGrid()
    End Sub

    Private Sub btnNuevo_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnNuevo.ItemClick
        'Dim f As New frmCompra_Data
        Dim f As New frmFacturaEx_Data
        f.txtStatus.Caption = "Agregando Factura Express"
        f.nTipo = 1
        f.vnRecno = 0
        f.ShowDialog()
        RegistroActual()
    End Sub

    Private Sub btnEditar_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnEditar.ItemClick
        If Me.GridView1.RowCount = 0 Then
            Exit Sub
        End If
        Dim f As New frmFacturaEx_Data
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

    Private Sub bbAnular_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
        'Me.gcOrdenes.Focus()
        'If Me.GridView1.RowCount > 0 Then
        '    nStatusOrden = funNull2Val(Me.GridView1.GetFocusedRowCellValue("nStatus"))
        '    vnNumeroOrden = funNull2Val(Me.GridView1.GetFocusedRowCellValue("nOrden"))
        '    strNumeroOrden = Format(vnNumeroOrden, "000000")
        '    If Me.nStatusOrden > 1 And Me.nStatusOrden < 4 Then '-- 2: Parcial, 3: Entregada
        '        MsgBox("Estimado Usuario: Esta Orden tiene movimientos !!!", MsgBoxStyle.Information, "Atención !!!")
        '        Exit Sub
        '    ElseIf Me.nStatusOrden = 4 Then '-- 4:Anulada
        '        MsgBox("Estimado Usuario: Esta Orden ya fue Anulada !!!", MsgBoxStyle.Information, "Atención !!!")
        '        Exit Sub
        '    End If
        '    If MessageBox.Show("¿Está seguro que desea anular la Orden N°: " & strNumeroOrden & " ?", "Confirmar anulación de la Orden N°: " & strNumeroOrden, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
        '        funAnularOrden()
        '        RegistroActual()
        '    End If
        'End If
    End Sub
    Private Function funUpdateGrid() As Boolean
        Dim strRango1 As String = funFechaSql(Me.dtpInicio.Value.Date, True)
        Dim strRango2 As String = funFechaSql(Me.dtpFinal.Value.Date, True)
        Dim vnExpress As Integer = 1
        '--
        'strSQL = "SELECT * FROM v_Inv_Gv_Movto_Inventario " &
        '            "WHERE CAST(dtmFechaDoc AS DATE) Between '" & strRango1 & "' " &
        '            " AND '" & strRango2 & "' " &
        '            " AND nEmpresa = " & intEmpresa &
        '            " AND nConcepto = " & vnConcepto &
        '            " AND nExpress = " & vnExpress &
        '            " ORDER BY nNumero"

        strSQL = "SELECT * FROM vw_GB_Facturas " &
                    "WHERE CAST(FECHA AS DATE) Between '" & strRango1 & "' " &
                    " AND '" & strRango2 & "' " &
                    " AND EMPRESA = " & intEmpresa &
                    " AND CONCEPTO = " & vnConcepto &
                    " AND EXPRESS = " & vnExpress &
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
        'funSetColumna(Me.GridView1, "dtmFechaDoc", "Fecha", funIndice(), 80, 1)
        'funSetColumna(Me.GridView1, "nNumero", "No. Factura", funIndice(), 80, 1)
        'funSetColumna(Me.GridView1, "strReferencia", "Fef.", funIndice(), 80, 1)
        'funSetColumna(Me.GridView1, "strConceptoInvCorto", "Concepto", funIndice(), 80, 1)
        'funSetColumna(Me.GridView1, "strOrigenDestino", "Cliente", funIndice(), 300, 1)
        'funSetColumna(Me.GridView1, "dtmUpdate", "F.Mod", funIndice(), 80, 1)
        'funSetColumna(Me.GridView1, "strUserUpdate", "User +", funIndice(), 70, 1)
        'funSetColumna(Me.GridView1, "strHostName", "Pc +", funIndice(), 70, 1)
        funSetColumna(GridView1, "FACTURA", "FACTURA", funIndice(), 60, 1)
        funSetColumna(GridView1, "FECHA", "FECHA", funIndice(), 80, 1)
        funSetColumna(GridView1, "TIPOVENTA", "T.VENTA", funIndice(), 80, 1)
        funSetColumna(GridView1, "TIPOFACTURA", "T.FACTURA", funIndice(), 80, 1)
        funSetColumna(GridView1, "CLIENTE", "CLIENTE", funIndice(), 200, 1)
        funSetColumna(GridView1, "SUB_TOTAL", "SUB_TOTAL", funIndice(), 90, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
        funSetColumna(GridView1, "DESCUENTO", "DESCUENTO", funIndice(), 90, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
        funSetColumna(GridView1, "IVA", "IVA", funIndice(), 90, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
        funSetColumna(GridView1, "TOTAL", "TOTAL", funIndice(), 100, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
        '-- Numero de Registros
        '-- Me.barText.Caption = "Registros: " & ds.Tables("Tabla").Rows.Count
        Return True
    End Function

    'Private Function funAnularOrden() As Boolean
    '    AbrirConexionGlobal()
    '    Dim strObservaciones As String = ""
    '    Dim f As New frmObservaciones
    '    f.ShowDialog()
    '    If f.Cancelar = True Then
    '        MsgBox("La Anulación ha sido Cancelada !!!", MsgBoxStyle.Information, "Atencion")
    '        Return False
    '    End If
    '    strObservaciones = f.meObservaciones.Text
    '    Try
    '        strSQL = "UPDATE BAS_Ordenes SET nStatus = 4" & _
    '                    ", strUserAnula = '" & strUser & "'" & _
    '                    ", dtmAnula = '" & Format(CDate(funFechaServer()), "s") & "'" & _
    '                    ", strNotaAnula = '" & strObservaciones & "'" & _
    '                    "WHERE nOrden = " & vnNumeroOrden & " " & _
    '                    "AND nEmpresa = " & intEmpresa
    '        '--
    '        funRunSQLTransaccion(strSQL)
    '        transaccionGlobal.Commit()
    '    Catch ex As Exception
    '        LimpiarCampos()
    '        transaccionGlobal.Rollback()
    '        DBConnGlobal.Close()
    '        MsgBox(ex.Message, MsgBoxStyle.Critical)
    '        Exit Function
    '    End Try
    '    DBConnGlobal.Close()
    'End Function

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
        lstParametros.Add(Me.GridView1.GetFocusedRowCellValue("FACTURA").ToString)
        lstParametros.Add(Me.GridView1.GetFocusedRowCellValue("CONCEPTO").ToString)
        lstParametros.Add(strUser)
        '--
        funPrintConSp("Factura_SH_V1.rpt", lstParametros)
        Me.Cursor = Cursors.Default
    End Sub
End Class