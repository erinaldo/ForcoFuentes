Imports System.IO
Imports OfficeOpenXml
Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmCompro_Open

    Dim ds As New DataSet
    Dim ds2 As New DataSet

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

    Public vnArticulo As String
    Public vnSucursal As String

    Shadows focus As Object
    Dim fila As Integer

    Private Sub bClose_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bClose.ItemClick
        Me.Close()
    End Sub

    Private Sub frmCompro_Open_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        funCargaData
    End Sub
    Private Sub funCargaData()
        If funValidar() = True Then
            funUpdateGrid()
            funUpdateGrid2()
        End If
    End Sub
    Private Function funValidar() As Boolean
        If Len(Trim(vnArticulo)) = 0 Then
            MsgBox("Falta el Artículo !!!", MsgBoxStyle.Critical, "Atención !!!")
            Return False
        End If
        Return True
    End Function

    Private Function funUpdateGrid() As Boolean
        '--
        strSQL = "SELECT * FROM Inv_Cola_Comprometido_Histo " &
                    "WHERE Articulo_Id = '" & Trim(vnArticulo) & "' " &
                    " AND Suc_Id = '" & Trim(vnSucursal) & "' " &
                    " ORDER BY Cola_Fecha DESC"
        '--
        ds = funFillDataSet(strSQL)
        '--
        Me.gcDetalle.DataSource = funFillDataSet(strSQL).Tables(0)
        '--
        GridViewStyle(Me.gvDetalle)
        funOcultarTodasLasColumnas(Me.gvDetalle)
        indice = 0
        '--
        funSetColumna(Me.gvDetalle, "Suc_id", "Suc_Id", funIndice(), 60, 1)
        funSetColumna(Me.gvDetalle, "Articulo_id", "Articulo_Id", funIndice(), 80, 1)
        funSetColumna(Me.gvDetalle, "Documento_tipo", "Documento_tipo", funIndice(), 80, 1)
        funSetColumna(Me.gvDetalle, "Documento_id", "Documento_id", funIndice(), 80, 1)
        funSetColumna(Me.gvDetalle, "Cola_Fecha", "Cola_Fecha", funIndice(), 80, 1)
        funSetColumna(Me.gvDetalle, "Cola_Cantidad", "Cola_Cantidad", funIndice(), 80, 1, , , "n0", 3, , DevExpress.Utils.FormatType.Numeric)
        Return True
    End Function

    Private Function funUpdateGrid2() As Boolean
        '--
        strSQL = "SELECT * FROM Inv_Cola_Transito_Histo " &
                    "WHERE Articulo_Id = '" & Trim(vnArticulo) & "' " &
                    " AND Suc_Id = '" & Trim(vnSucursal) & "' " &
                    " ORDER BY Cola_Fecha DESC"
        '--
        ds2 = funFillDataSet(strSQL)
        '--
        Me.gcDetalle2.DataSource = funFillDataSet(strSQL).Tables(0)
        '--
        GridViewStyle(Me.gvDetalle2)
        funOcultarTodasLasColumnas(Me.gvDetalle2)
        indice = 0
        '--
        funSetColumna(Me.gvDetalle2, "Suc_id", "Suc_Id", funIndice(), 60, 1)
        funSetColumna(Me.gvDetalle2, "Articulo_id", "Articulo_Id", funIndice(), 80, 1)
        funSetColumna(Me.gvDetalle2, "Documento_tipo", "Documento_tipo", funIndice(), 80, 1)
        funSetColumna(Me.gvDetalle2, "Documento_id", "Documento_id", funIndice(), 80, 1)
        funSetColumna(Me.gvDetalle2, "Cola_Fecha", "Cola_Fecha", funIndice(), 80, 1)
        funSetColumna(Me.gvDetalle2, "Cola_Cantidad", "Cola_Cantidad", funIndice(), 80, 1, , , "n0", 3, , DevExpress.Utils.FormatType.Numeric)
        Return True
    End Function

End Class