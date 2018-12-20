Imports System.IO
Imports OfficeOpenXml
Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmComprometidos

    Dim ds As New DataSet
    Dim nTipoMovGrid As Integer
    Dim i As Integer
    Dim vclArticulo As String
    Dim strChekados As String
    '--
    Dim r As Integer
    Dim dtListaArticulos As DataTable
    Dim strFiltroDataTable As String
    Dim f As FolderBrowserDialog

    Dim dsReporte As DataSet

    Dim FilePath As String

    Shadows focus As Object
    Dim fila As Integer


    Private Sub bClose_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bClose.ItemClick
        Me.Close()
    End Sub

    Private Sub frmComprometidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.txtCodigo.Focus()
    End Sub

    Private Sub bbItem_Click(sender As Object, e As EventArgs) Handles bbItem.Click
        If funValidar() = True Then
            funUpdateGrid()
        End If
    End Sub
    Private Function funValidar() As Boolean
        If Len(Trim(Me.txtCodigo.Text)) = 0 Then
            Me.txtCodigo.Focus()
            MsgBox("Falta el Artículo !!!", MsgBoxStyle.Critical, "Atención !!!")
            Return False
        End If
        Return True
    End Function

    Private Function funUpdateGrid() As Boolean
        '--
        strSQL = "SELECT * FROM vw_GB_Compro_Transito " &
                    "WHERE Articulo_Id = '" & Trim(Me.txtCodigo.Text) & "' " &
                    " ORDER BY Suc_Id"
        '--
        ds = funFillDataSet(strSQL)
        '--
        Me.gcDetalle.DataSource = funFillDataSet(strSQL).Tables(0)
        '--
        GridViewStyle(Me.gvDetalle)
        funOcultarTodasLasColumnas(Me.gvDetalle)
        indice = 0
        '--
        funSetColumna(Me.gvDetalle, "Suc_Id", "Suc_Id", funIndice(), 70, 1)
        funSetColumna(Me.gvDetalle, "Sucursal_Nombre", "Suc_Nombre", funIndice(), 120, 1)
        funSetColumna(Me.gvDetalle, "Articulo_Id", "Articulo_Id", funIndice(), 80, 1)
        funSetColumna(Me.gvDetalle, "Articulo_Nombre", "Articulo_Nombre", funIndice(), 300, 1)
        funSetColumna(Me.gvDetalle, "Existencia", "Existencia", funIndice(), 80, 1, , , "n0", 3, , DevExpress.Utils.FormatType.Numeric)
        funSetColumna(Me.gvDetalle, "Comprometido", "Comprometido", funIndice(), 80, 1, , , "n0", 3, , DevExpress.Utils.FormatType.Numeric)
        funSetColumna(Me.gvDetalle, "Transito", "Transito", funIndice(), 80, 1, , , "n0", 3, , DevExpress.Utils.FormatType.Numeric)
        Return True
    End Function

    Private Sub bbComprometido_Click(sender As Object, e As EventArgs) Handles bbComprometido.Click
        If Me.gvDetalle.RowCount = 0 Then
            Exit Sub
        End If
        Dim f As New frmCompro_Open2
        f.vnArticulo = Me.gvDetalle.GetFocusedRowCellValue("Articulo_Id")
        f.vnSucursal = funNull2Val(Me.gvDetalle.GetFocusedRowCellValue("Suc_Id"))
        f.ShowDialog()
        funRegistroActual()
    End Sub

    Private Function funRegistroActual()
        Me.gcDetalle.Focus()
        If Me.gvDetalle.RowCount > 0 Then
            Focus = Me.gvDetalle.FocusedValue()
            fila = Me.gvDetalle.FocusedRowHandle
        End If
        funUpdateGrid()
        If Me.gvDetalle.RowCount > fila Then
            Me.gvDetalle.FocusedRowHandle = fila
            Me.gvDetalle.SetFocusedValue(Focus)
        End If
        Return True
    End Function

    Private Sub bbTransito_Click(sender As Object, e As EventArgs)

    End Sub
End Class