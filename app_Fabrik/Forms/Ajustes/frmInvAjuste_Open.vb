Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmInvAjuste_Open
    Dim ds As New DataSet
    'Dim focus As Object
    Dim fila As Integer
    Dim GridCol As Integer
    Dim vnNumeroOrden As Integer
    Dim strNumeroOrden As String
    Dim nStatusOrden As Integer
    Dim vnConcepto As Integer = vnTipoAjuste
    Shadows focus As Object


    Private Sub btnSalir_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnSalir.ItemClick
        Me.Close()
    End Sub

    Private Function funUpdateGrid() As Boolean
        '--
        Dim strRango1 As String = funFechaSql(Me.dtpInicio.Value.Date, True)
        Dim strRango2 As String = funFechaSql(Me.dtpFinal.Value.Date, True)
        '--
        strSQL = "SELECT * FROM v_Inv_Gv_Movto_Inventario " &
                    "WHERE CAST(dtmFechaDoc AS DATE) Between '" & strRango1 & "' " &
                    " AND '" & strRango2 & "' " &
                    " AND nEmpresa = " & intEmpresa &
                    " AND bitReservado = 0 " &
                    " AND nConcepto = " & vnConcepto &
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
        funSetColumna(Me.GridView1, "nNumero", "No.", funIndice(), 60, 1)
        funSetColumna(Me.GridView1, "strReferencia", "Ref.", funIndice(), 70, 1)
        funSetColumna(Me.GridView1, "dtmFechaDoc", "Fecha", funIndice(), 80, 1)
        funSetColumna(Me.GridView1, "strConceptoInvCorto", "Concepto", funIndice(), 80, 1)
        funSetColumna(Me.GridView1, "strConceptoInv", "Descripción", funIndice(), 200, 1)
        funSetColumna(Me.GridView1, "strStatus", "Status", funIndice(), 80, 1)
        funSetColumna(Me.GridView1, "strUserAdd", "User.Reg", funIndice(), 80, 1)
        funSetColumna(Me.GridView1, "strUserUpdate", "User.Mod", funIndice(), 80, 1)
        funSetColumna(Me.GridView1, "dtmAdd", "F.Reg.", funIndice(), 80, 1)
        funSetColumna(Me.GridView1, "dtmUpdate", "F.Mod.", funIndice(), 80, 1, , , "d")
        funSetColumna(Me.GridView1, "strHostName", "Pc.Reg", funIndice(), 90, 1)
        '-- Numero de Registros
        '-- Me.barText.Caption = "Registros: " & ds.Tables("Tabla").Rows.Count
        Return True
    End Function

    Private Sub frmOrden_Open_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        funUpdateGrid()
    End Sub

    Private Sub btnNuevo_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnNuevo.ItemClick
        Dim f As New frmInvAjuste_Data2
        f.txtStatus.Caption = "Agregando Orden de Entrega"
        f.nTipo = 1
        f.vnRecno = 0
        f.ShowDialog()
        RegistroActual()
    End Sub

    Private Sub btnEditar_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnEditar.ItemClick
        '--
        If Me.GridView1.RowCount = 0 Then
            Exit Sub
        End If
        Dim f As New frmInvAjuste_Data2
        f.txtStatus.Caption = "Editando Registro ..."
        f.nTipo = 2
        f.vnNumero = funNull2Val(Me.GridView1.GetFocusedRowCellValue("nNumero"))
        f.vnRecno = funNull2Val(Me.GridView1.GetFocusedRowCellValue("nRecno"))
        f.vnConcepto = funNull2Val(Me.GridView1.GetFocusedRowCellValue("nConcepto"))
        f.vnTipoMovimiento = funNull2Val(Me.GridView1.GetFocusedRowCellValue("nTipoMovto"))
        f.ShowDialog()
        funRegistroActual()
        '--
    End Sub

    Private Sub RegistroActual()
        '--
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
        '--
    End Sub

    Private Sub bbProceso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bbProceso.Click
        '--
        funUpdateGrid()
        '--
    End Sub

    Private Sub funRegistroActual()
        '--
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
        '--
    End Sub

    Private Sub bbPrint_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbPrint.ItemClick
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
        funPrintConSp("repMovtoGeneral.rpt", lstParametros)
        Me.Cursor = Cursors.Default
    End Sub
End Class