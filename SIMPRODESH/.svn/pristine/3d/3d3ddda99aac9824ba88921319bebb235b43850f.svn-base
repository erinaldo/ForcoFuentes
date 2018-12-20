Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmRepSeekProveedor
    Dim ds As New DataSet
    Dim fila As Integer
    Dim GridCol As Integer
    Dim bolTipoBusqueda As Boolean
    Shadows focus As Object

    Private Sub frmRepSearchItem_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub frmRepSearchItem_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        '--
        bolFound = False
        bolTipoBusqueda = False
        funUpdateGrid()
        bolTipoBusqueda = True
        '--
    End Sub

    Private Function funUpdateGrid() As Boolean
        '-- 
        If bolTipoBusqueda = True Then
            '-- Busca el contenido de textbox
            strSQL = "SELECT * " & _
                        "FROM vw_GB_ProveedorConMovto "
            '--
            strSQL += "WHERE (Prov_Nombre LIKE '%" & Me.txtNombre.Text & "%' OR Prov_Id LIKE '%" & Me.txtNombre.Text & "%')"
            '--
            strSQL += " ORDER BY Prov_Nombre "
        Else
            '-- Cuando carga por default
            strSQL = "SELECT TOP 100 * FROM vw_GB_ProveedorConMovto " & _
                        "ORDER BY Prov_Nombre"
        End If
        '--
        ds = funFillDataSet(strSQL)
        '--
        Me.gcProducto.DataSource = ds.Tables(0)
        '--
        GridViewStyle(Me.gvProducto)
        funOcultarTodasLasColumnas(Me.gvProducto)
        '--
        indice = 0
        '--
        funSetColumna(Me.gvProducto, "Prov_Id", "Código", funIndice(), 100, 1)
        funSetColumna(Me.gvProducto, "Prov_Nombre", "Producto", funIndice(), 300, 1)
        Return True
    End Function

    Private Sub bbClose_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbClose.ItemClick
        Me.Close()
    End Sub

    Private Sub bbAceptar_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbAceptar.ItemClick
        With Me.gvProducto
            If .FocusedRowHandle >= 0 Then
                vnProveedor = funNull2Val(.GetFocusedRowCellValue("Prov_Id"))
                bolFound = True
                Me.Close()
            Else
                MsgBox("Debe seleccionar un Registro !!!", MsgBoxStyle.Information, "Atención !!!")
            End If
        End With
    End Sub
End Class