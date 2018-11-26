Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmRepSearchItemNo
    Dim ds As New DataSet
    Dim fila As Integer
    Dim GridCol As Integer
    Dim bolTipoBusqueda As Boolean
    Shadows focus As Object

    Private Sub frmRepSearchItemNo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub frmRepSearchItemNo_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
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
                        "FROM v_Inv_Gv_ProductoBodegaSinSaldo "
            '--
            strSQL += "WHERE (strData LIKE '%" & Me.txtNombre.Text & "%' OR strClave LIKE '%" & Me.txtNombre.Text & "%')"
            '--
            strSQL += " AND nEmpresa = " & intEmpresa
            '--
            strSQL += " ORDER BY strData "
        Else
            '-- Cuando carga por default
            strSQL = "SELECT TOP 100 * FROM v_Inv_Gv_ProductoBodegaSinSaldo " & _
                        "WHERE nEmpresa = " & intEmpresa & _
                        "ORDER BY strData"
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
        funSetColumna(Me.gvProducto, "strClave", "Código", funIndice(), 100, 1)
        funSetColumna(Me.gvProducto, "strData", "Producto", funIndice(), 300, 1)
        funSetColumna(Me.gvProducto, "strMedida", "U.Medida", funIndice(), 100, 1)
        'funSetColumna(Me.gvProducto, "nSaldo", "Saldo", funIndice(), 100, 1, , , , 3, , DevExpress.Utils.FormatType.Numeric)
        Return True
    End Function

    Private Sub bbClose_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbClose.ItemClick
        Me.Close()
    End Sub

    Private Sub bbAceptar_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbAceptar.ItemClick
        With Me.gvProducto
            If .FocusedRowHandle >= 0 Then
                vnProducto = funNull2Val(.GetFocusedRowCellValue("nCode"))
                bolFound = True
                Me.Close()
            Else
                MsgBox("Debe seleccionar un Registro !!!", MsgBoxStyle.Information, "Atención !!!")
            End If
        End With
    End Sub
End Class