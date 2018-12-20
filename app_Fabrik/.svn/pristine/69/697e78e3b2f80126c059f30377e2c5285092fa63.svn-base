Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmOpenRecalculaStock
    Dim ds As New DataSet
    Shadows focus As Object
    Dim fila As Integer

    Private Sub bbClose_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbClose.ItemClick
        Me.Close()
    End Sub

    Private Sub frmOpenRecalculaStock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'funLimpiaDatos()
        'funUpdateExistencia()
        funUpdateGrid()
    End Sub

    Private Function funUpdateGrid() As Boolean
        '--
        strSQL = "SELECT * FROM v_Rep_Existencia " & _
                    "WHERE nEmpresa = " & intEmpresa & " " & _
                    "AND nSaldo <> 0" & " " & _
                    "ORDER BY nCode"
        '--
        ds = funFillDataSet(strSQL)
        '--
        Me.gcStock.DataSource = funFillDataSet(strSQL).Tables(0)
        '--
        GridViewStyle(Me.gvStock)
        funOcultarTodasLasColumnas(Me.gvStock)
        indice = 0
        '--
        funSetColumna(Me.gvStock, "strClave", "Clave", funIndice(), 120, 1)
        funSetColumna(Me.gvStock, "strData", "Descripción", funIndice(), 300, 1)
        funSetColumna(Me.gvStock, "nEntrada", "Entradas", funIndice(), 70, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
        funSetColumna(Me.gvStock, "nSalida", "Salidas", funIndice(), 70, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
        funSetColumna(Me.gvStock, "nSaldo", "Saldo", funIndice(), 70, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
        funSetColumna(Me.gvStock, "nM3_Entrada", "Entrada", funIndice(), 70, 1, , , "n3", 3, , DevExpress.Utils.FormatType.Numeric)
        funSetColumna(Me.gvStock, "nM3_Salida", "Salida", funIndice(), 70, 1, , , "n3", 3, , DevExpress.Utils.FormatType.Numeric)
        funSetColumna(Me.gvStock, "nM3_Saldo", "Saldo", funIndice(), 70, 1, , , "n3", 3, , DevExpress.Utils.FormatType.Numeric)
        funSetColumna(Me.gvStock, "nPt_Entrada", "Entrada", funIndice(), 80, 1, , , "n3", 3, , DevExpress.Utils.FormatType.Numeric)
        funSetColumna(Me.gvStock, "nPt_Salida", "Salida", funIndice(), 80, 1, , , "n3", 3, , DevExpress.Utils.FormatType.Numeric)
        funSetColumna(Me.gvStock, "nPt_Saldo", "Saldo", funIndice(), 80, 1, , , "n3", 3, , DevExpress.Utils.FormatType.Numeric)
        '-- Numero de Registros
        Me.barText.Caption = "Registros: " & ds.Tables("Tabla").Rows.Count
        '-- Ttoales
        With Me.gvStock
            '-- Numero de Bultos
            .GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "nSaldo", .Columns("nSaldo"), "{0:n2}")
            .Columns("nSaldo").SummaryItem.FieldName = "nSaldo"
            .Columns("nSaldo").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("nSaldo").SummaryItem.DisplayFormat = "{0:n2}"
            '-- Numero de Piezas
            .GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "nM3_Saldo", .Columns("nM3_Saldo"), "{0:n3}")
            .Columns("nM3_Saldo").SummaryItem.FieldName = "nM3_Saldo"
            .Columns("nM3_Saldo").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("nM3_Saldo").SummaryItem.DisplayFormat = "{0:n3}"
            '-- Metros Cubicos
            .GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "nPt_Saldo", .Columns("nPt_Saldo"), "{0:n3}")
            .Columns("nPt_Saldo").SummaryItem.FieldName = "nPt_Saldo"
            .Columns("nPt_Saldo").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("nPt_Saldo").SummaryItem.DisplayFormat = "{0:n3}"
            '--
            .OptionsView.ShowFooter = True
        End With
        Return True
    End Function

    Private Sub bbAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bbAgregar.Click
        funLimpiaDatos()
        funUpdateExistencia()
        funUpdateGrid()
    End Sub

    Private Function funLimpiaDatos()
        '-- Ponemos en cero todos los productos
        strSQL = "UPDATE Inv_ProductoBodega " & _
                    "SET nEntrada = 0, nSalida = 0" & _
                    " WHERE nEmpresa = " & intEmpresa
        '--
        funRunSQL(strSQL)
        '--
        Return True
    End Function

    Private Function funUpdateExistencia()
        '-- Actualizamos las entradas
        strSQL = "UPDATE Inv_ProductoBodega " & _
                    "SET nEntrada = ISNULL(pv.nSumCantidad,0)" & _
                    "FROM dbo.Inv_ProductoBodega AS p " & _
                    "INNER JOIN v_Inv_Movimiento_Sum AS pv " & _
                    "ON p.nCode = pv.nCode " & _
                    "AND pv.nTipoMovto = 1 " & _
                    "AND pv.nEmpresa = " & intEmpresa & _
                    "AND p.nEmpresa = " & intEmpresa
        '--
        funRunSQL(strSQL)
        '-- Actualizamos las salidas
        strSQL = "UPDATE Inv_ProductoBodega " & _
                    "SET nSalida = ISNULL(pv.nSumCantidad,0)" & _
                    "FROM dbo.Inv_ProductoBodega AS p " & _
                    "INNER JOIN v_Inv_Movimiento_Sum AS pv " & _
                    "ON p.nCode = pv.nCode " & _
                    "AND pv.nTipoMovto = 2 " & _
                    "AND pv.nEmpresa = " & intEmpresa & _
                    "AND p.nEmpresa = " & intEmpresa
        '--
        funRunSQL(strSQL)
        '--
        Return True
    End Function
End Class