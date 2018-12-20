Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmKupon_Open
    Dim ds As New DataSet
    Shadows focus As Object
    Dim fila As Integer
    '-- Reporte
    Dim strFormula As String

    Private Sub bbClose_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbClose.ItemClick
        Me.Close()
    End Sub

    Private Sub frmKupon_Open_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        funUpdateGrid()
    End Sub

    Private Function funUpdateGrid() As Boolean
        '--
        strSQL = "SELECT * FROM Inv_TarjetasRegalo WHERE nAplicado = 1 ORDER BY nRecno"
        '--
        ds = funFillDataSet(strSQL)
        '--
        Me.gcConcepto.DataSource = funFillDataSet(strSQL).Tables(0)
        '--
        GridViewStyle(Me.GridView1)
        funOcultarTodasLasColumnas(Me.GridView1)
        indice = 0
        '--
        funSetColumna(Me.GridView1, "nRecno", "ID", funIndice(), 90, 1)
        funSetColumna(Me.GridView1, "BarCode", "Concepto", funIndice(), 90, 1)
        funSetColumna(Me.GridView1, "dtmUpdate", "Fecha +", funIndice(), 150, 1, , , "d")
        funSetColumna(Me.GridView1, "strHostName", "Pc +", funIndice(), 150, 1)
        '-- Numero de Registros
        Me.barText.Caption = "Registros: " & ds.Tables("Tabla").Rows.Count
        Return True
    End Function

    Private Function funRegistroActual()
        Me.gcConcepto.Focus()
        If Me.GridView1.RowCount > 0 Then
            focus = Me.GridView1.FocusedValue()
            fila = Me.GridView1.FocusedRowHandle
        End If
        funUpdateGrid()
        If Me.GridView1.RowCount > fila Then
            Me.GridView1.FocusedRowHandle = fila
            Me.GridView1.SetFocusedValue(focus)
        End If
        Return True
    End Function

    Private Sub bbAdd_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbAdd.ItemClick
        Dim f As New frmKupon_Data
        f.barText.Caption = "Agregando Registro ..."
        f.nTipo = 1
        f.ShowDialog()
        funRegistroActual()
    End Sub

    Private Sub bbEdit_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbEdit.ItemClick
        If Me.GridView1.RowCount = 0 Then
            Exit Sub
        End If
        'Dim f As New frmConcepto_Data
        'f.barText.Caption = "Editando Registro ..."
        'f.nTipo = 2
        'f.vnCodigo = funNull2Val(Me.GridView1.GetFocusedRowCellValue("nCode"))
        'f.vnRecno = funNull2Val(Me.GridView1.GetFocusedRowCellValue("nRecno"))
        'f.ShowDialog()
        funRegistroActual()
    End Sub


End Class