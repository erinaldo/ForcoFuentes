Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base

Module modFormato

    Public Sub funFormatGv_for_GetListProductoBodegaSaldo(ByVal oGridView As DevExpress.XtraGrid.Views.Grid.GridView)
        '--
        funSetColumna(oGridView, "strClave", "Código", funIndice(), 100, 1)
        funSetColumna(oGridView, "strData", "Producto", funIndice(), 300, 1)
        funSetColumna(oGridView, "strMedida", "U.Medida", funIndice(), 100, 1)
        funSetColumna(oGridView, "nSaldo", "Saldo", funIndice(), 100, 1, 0, , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
    End Sub

    Public Sub funFormatGv_for_GetListProductoLote(ByVal oGridView As DevExpress.XtraGrid.Views.Grid.GridView)
        '--
        funSetColumna(oGridView, "strClave", "Código", funIndice(), 100, 1)
        funSetColumna(oGridView, "nLote", "Lote", funIndice(), 100, 1)
        funSetColumna(oGridView, "dtmVence", "F.Vence", funIndice(), 100, 1)
        funSetColumna(oGridView, "nSaldo", "Saldo", funIndice(), 100, 1, 0, , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
    End Sub

    Public Sub funFormatGv_for_GetListLoteDetalle(ByVal oGridView As DevExpress.XtraGrid.Views.Grid.GridView)
        '-- Lote detalle
        funSetColumna(oGridView, "nLote", "Lote", funIndice(), 80, 1)
        funSetColumna(oGridView, "nCantidad", "Cantidad", funIndice(), 100, 1, 0, , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
    End Sub

    Public Sub funFormatGv_for_GetListLoteDetalleHistoria(ByVal oGridView As DevExpress.XtraGrid.Views.Grid.GridView)
        '-- Lote detalle
        funSetColumna(oGridView, "dtmAdd", "Fecha Reg.", funIndice(), 100, 1)
        funSetColumna(oGridView, "nLote", "Lote", funIndice(), 80, 1)
        funSetColumna(oGridView, "nConsecutivo", "No.", funIndice(), 50, 1)
        funSetColumna(oGridView, "nCantidad", "Cantidad", funIndice(), 100, 1, 0, , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
    End Sub
End Module
