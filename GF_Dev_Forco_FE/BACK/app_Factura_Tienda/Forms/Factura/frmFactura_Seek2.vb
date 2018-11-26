Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmFactura_Seek2
    Dim ds As New DataSet
    Dim fila As Integer
    Dim GridCol As Integer
    Public nTransaction As Integer
    Shadows focus As Object
    Dim bolTipoBusqueda As Boolean
    Public nTipo As Integer '-- Para saber que esta agregando o editando una entrada

    Private Sub frmFactura_Seek2_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        '--
        If e.KeyData = Keys.Return And Me.txtNombre.Focused Then
            If Len(Trim(Me.txtNombre.Text)) >= 1 Then
                bolTipoBusqueda = True
                funUpdateGrid()
            Else
                bolTipoBusqueda = False
                funUpdateGrid()
            End If
        ElseIf e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
        '--
    End Sub

    Private Sub frmFactura_Seek2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        '--
        bolFound = False
        '--
        bolTipoBusqueda = False
        funUpdateGrid()
        bolTipoBusqueda = True
        If Me.nTransaction = 1 Then
            'Me.cbCantidad.Value = 0
            Me.cbPrecio.Value = 0
            Me.cbDescuento.Value = 0
            Me.cbIva.Value = 0
            Me.txtNombre.Focus()
        Else
            '--
            If nTipo = 1 Then '-- Si esta agregando el documento y editando el producto
                Me.gcProducto.Enabled = False
                Me.txtNombre.Enabled = False
                Me.bbAceptar.Enabled = True
            Else
                Me.gcProducto.Enabled = False
                Me.txtNombre.Enabled = False
                Me.bbAceptar.Enabled = False
                'Me.cbCantidad.Enabled = False
                Me.cbDescuento.Enabled = False
                Me.cbIva.Enabled = False
                Me.cbPrecio.Enabled = False
            End If
            '--
        End If
    End Sub

    Private Function funUpdateGrid() As Boolean
        '--
        If bolTipoBusqueda = True Then
            '-- Busca el contenido de textbox
            'strSQL = "SELECT * FROM v_Inv_Gv_ProductoBodegaConSaldo "
            strSQL = "SELECT * FROM v_Inv_Gv_ProductoBodegaSinSaldo "
            strSQL += "WHERE (strData LIKE '%" & Me.txtNombre.Text & "%' OR strClave LIKE '%" & Me.txtNombre.Text & "%')"
            'strSQL += " AND nFamilia2 IN (2,4,6,8)"
            strSQL += "WHERE nEmpresa = 1"
            strSQL += " ORDER BY strClave"
        Else
            '-- Cuando carga por default
            'strSQL = "SELECT TOP 100 * FROM v_Inv_Gv_ProductoBodegaConSaldo "
            strSQL = "SELECT TOP 100 * FROM v_Inv_Gv_ProductoBodegaSinSaldo "
            'strSQL += "WHERE nFamilia2 IN (2,4,6,8)"
            strSQL += "WHERE nEmpresa = 1"
            strSQL += " ORDER BY strClave"
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
        funSetColumna(Me.gvProducto, "strClave", "Código", funIndice(), 80, 1)
        funSetColumna(Me.gvProducto, "strData", "Producto", funIndice(), 190, 1)
        funSetColumna(Me.gvProducto, "strMedida", "U.Medida", funIndice(), 80, 1)
        funSetColumna(Me.gvProducto, "nSaldo", "Existencia", funIndice(), 80, 1, , , , 3, , DevExpress.Utils.FormatType.Numeric)
        funSetColumna(Me.gvProducto, "mPrecio_Venta2", "P.Fanquicia", funIndice(), 100, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
        '--
        Return True
    End Function

    Private Sub bbAceptar_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbAceptar.ItemClick
        '--
        If Len(Trim(Me.lblCode.Text)) = 0 Then
            Me.txtNombre.Focus()
            MsgBox("Debe seleccionar un producto !!!", MsgBoxStyle.Critical, "Atención !!!")
            Exit Sub
        ElseIf Me.cbCantidad.Value <= 0 Then
            MsgBox("La Cantidad no puede menor o igul a Cero !!!", MsgBoxStyle.Critical, "Atención !!!")
            Me.cbCantidad.Focus()
            Exit Sub
        ElseIf Me.cbPrecio.Value <= 0 Then
            MsgBox("El Precio Unitario no puede menor o igul a Cero !!!", MsgBoxStyle.Critical, "Atención !!!")
            Me.cbPrecio.Focus()
            Exit Sub
        End If
        '-- Esto lo hago porque la variable publica me guarda el ultimo valor del vnCode que guardo en el grid del forms padre
        vnCode = LTrim(Me.lblCode.Text)
        vcCode = LTrim(Me.lblClave.Text)
        vcData = LTrim(Me.lblData.Text)
        vnCantidad = funNull2Val(Me.cbCantidad.Value)
        vnPrecioUnitario = funNull2Val(Me.cbPrecio.Value)
        vnDescuento = funNull2Val(Me.cbDescuento.Value)
        vnIva = funNull2Val(Me.cbIva.Value)
        '--
        bolFound = True
        Me.Close()
        '--
    End Sub

    Private Sub gvProducto_Click(sender As System.Object, e As System.EventArgs) Handles gvProducto.Click
        '--
        If Me.gvProducto.RowCount = 0 Then
            Exit Sub
        End If
        Me.lblCode.Text = Me.gvProducto.GetFocusedRowCellValue("nCode")
        Me.lblClave.Text = Me.gvProducto.GetFocusedRowCellValue("strClave")
        Me.lblData.Text = Me.gvProducto.GetFocusedRowCellValue("strData")
        vnCode = Me.gvProducto.GetFocusedRowCellValue("nCode")
        '-- 17-11-2017
        cbPrecio.Value = Me.gvProducto.GetFocusedRowCellValue("mPrecio_Venta2")
        '--
    End Sub

    Private Sub bbClose_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbClose.ItemClick
        '-- Poner en false porque de lo contrario actualiza
        bolFound = False
        Me.Close()
        '--
    End Sub

    Private Sub bbItem_Click(sender As System.Object, e As System.EventArgs) Handles bbItem.Click
        Dim f As New frmProducto_Data
        f.barText.Caption = "Agregando Registro ..."
        f.nTipo = 1
        f.ShowDialog()
        Me.bolTipoBusqueda = False
    End Sub
End Class