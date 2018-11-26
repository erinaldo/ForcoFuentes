Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmReceta_Open
    Dim ds As New DataSet
    Shadows focus As Object
    Dim fila As Integer
    '-- Reporte
    Dim strFormula As String
    Dim bolTipoBusqueda As Boolean
    Dim vnlCodigo As Integer

    Private Sub frmReceta_Open_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        bolTipoBusqueda = False
        funUpdateGrid()
        bolTipoBusqueda = True
    End Sub

    Private Sub bbClose_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbClose.ItemClick
        Me.Close()
    End Sub

    Private Sub bbAdd_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbAdd.ItemClick
        Dim f As New frmReceta_Detalle
        f.barText.Caption = "Agregando Registro ..."
        f.nTipo = 1
        f.ShowDialog()
        Me.bolTipoBusqueda = False
        funRegistroActual()
    End Sub

    Private Function funUpdateGrid() As Boolean
        '--
        If bolTipoBusqueda = True Then
            '--
            strSQL = "SELECT * FROM vw_GB_Receta_Open "
            strSQL += "WHERE (strData LIKE '%" & Me.txtNombre.Text & "%' OR strClave LIKE '%" & Me.txtNombre.Text & "%')"
            strSQL += " AND nEmpresa = " & intEmpresa
            strSQL += " ORDER BY strData "
        Else
            strSQL = "SELECT TOP 100 * FROM vw_GB_Receta_Open "
            strSQL += "WHERE nEmpresa = " & intEmpresa
            strSQL += " ORDER BY nNumero"
        End If
        '--
        ds = funFillDataSet(strSQL)
        '--
        Me.gcProducto.DataSource = funFillDataSet(strSQL).Tables(0)
        '--
        GridViewStyle(Me.GridView1)
        funOcultarTodasLasColumnas(Me.GridView1)
        indice = 0
        '--
        funSetColumna(Me.GridView1, "nNumero", "Código", funIndice(), 50, 1)
        funSetColumna(Me.GridView1, "strData", "Descripción", funIndice(), 400, 1)
        funSetColumna(Me.GridView1, "strClave", "Cod.", funIndice(), 50, 1)
        funSetColumna(Me.GridView1, "strProducto", "Artículo", funIndice(), 200, 1)
        funSetColumna(Me.GridView1, "dtmAdd", "F.Reg", funIndice(), 80, 1)
        '-- Numero de Registros
        Me.barText.Caption = "Registros: " & ds.Tables("Tabla").Rows.Count
        Return True
    End Function

    Private Sub frmReceta_Open_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyData = Keys.Return And Me.txtNombre.Focused Then
            If Len(Trim(Me.txtNombre.Text)) >= 1 Then
                bolTipoBusqueda = True
                funUpdateGrid()
            Else
                bolTipoBusqueda = False
                funUpdateGrid()
            End If
        End If
    End Sub

    Private Function funRegistroActual()
        Me.gcProducto.Focus()
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

    Private Sub bbEdit_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbEdit.ItemClick
        If Me.GridView1.RowCount = 0 Then
            Exit Sub
        End If
        Dim f As New frmReceta_Detalle
        f.barText.Caption = "Editando Registro ..."
        f.nTipo = 2
        f.vnNumero = funNull2Val(Me.GridView1.GetFocusedRowCellValue("nNumero"))
        f.vnRecno = funNull2Val(Me.GridView1.GetFocusedRowCellValue("nRecno"))
        f.ShowDialog()
        Me.bolTipoBusqueda = False
        funRegistroActual()
    End Sub


    Private Sub bbExcel_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbExcel.ItemClick
        Try
            Dim strFileName As String = Application.StartupPath & "\repProductos.xls"
            Me.gcProducto.ExportToXls(strFileName)
            System.Diagnostics.Process.Start(strFileName)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub bbProceso_Click(sender As System.Object, e As System.EventArgs) Handles bbProceso.Click
        bolTipoBusqueda = False
        funUpdateGrid()
    End Sub

    Private Sub bbDelete_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbDelete.ItemClick
        If Me.GridView1.RowCount = 0 Then
            Exit Sub
        End If
        vnlCodigo = funNull2Val(Me.GridView1.GetFocusedRowCellValue("nNumero"))

    End Sub

    Private Sub bbDetalle_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbDetalle.ItemClick
        If Me.GridView1.RowCount = 0 Then
            Exit Sub
        End If
        Dim f As New frmReceta_Detalle
        'f.barText.Caption = "Editando Registro ..."
        f.nTipo = 2
        f.vnNumero = funNull2Val(Me.GridView1.GetFocusedRowCellValue("nNumero"))
        f.vnRecno = funNull2Val(Me.GridView1.GetFocusedRowCellValue("nRecno"))
        f.ShowDialog()
        Me.bolTipoBusqueda = False
        funRegistroActual()
    End Sub
End Class