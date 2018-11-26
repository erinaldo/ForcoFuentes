Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmReceta_Seek
    Dim ds As New DataSet
    Dim fila As Integer
    Dim GridCol As Integer
    Public nTransaction As Integer
    Shadows focus As Object
    Dim bolTipoBusqueda As Boolean
    Public nTipo As Integer '-- Para saber que esta agregando o editando una entrada
    Dim bolInicio As Boolean

    Private Sub frmInvCompra_Seek2_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub frmInvCompra_Seek2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        '--
        bolFound = False
        bolInicio = True
        '--
        Me.cbCantidad2.Enabled = False
        Me.cbPrecio2.Enabled = False
        '--
        funCargaCombos()
        Me.lkMedida.EditValue = 1
        '--
        bolTipoBusqueda = False
        funUpdateGrid()
        bolTipoBusqueda = True
        If Me.nTransaction = 1 Then
            Me.cbCantidad.Value = 0
            Me.cbPrecio.Value = 0
            Me.cbDescuento.Value = 0
            Me.cbIva.Value = 13
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
                Me.cbCantidad.Enabled = False
                Me.cbDescuento.Enabled = False
                Me.cbIva.Enabled = False
                Me.cbPrecio.Enabled = False
            End If
            '--
        End If
        '--
        bolInicio = False
    End Sub

    Private Sub funCargaCombos()
        '-- Combo Unidades de Medida
        strSQL = "SELECT nCode AS nCodigo, strData AS strDescripcion FROM Cat_Medida"
        '--
        funCargarlue(Me.lkMedida, strSQL)
        '--
    End Sub

    Private Function funUpdateGrid() As Boolean
        '--
        If bolTipoBusqueda = True Then
            '-- Busca el contenido de textbox
            strSQL = "SELECT * FROM v_Inv_Producto "
            strSQL += "WHERE (strData LIKE '%" & Me.txtNombre.Text & "%' OR strClave LIKE '%" & Me.txtNombre.Text & "%')"
            strSQL += " AND nFamilia2 <> 6"
            strSQL += " ORDER BY strData "
        Else
            '-- Cuando carga por default
            strSQL = "SELECT TOP 100 * FROM v_Inv_Producto"
            strSQL += " WHERE nFamilia2 <> 6"
            strSQL += " ORDER BY strData "

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
            MsgBox("El Precio de compra no puede menor o igul a Cero !!!", MsgBoxStyle.Critical, "Atención !!!")
            Me.cbPrecio.Focus()
            Exit Sub
        End If
        '-- Esto lo hago porque la variable publica me guarda el ultimo valor del vnCode que guardo en el grid del forms padre
        vnCode = LTrim(Me.lblCode.Text)
        vcCode = LTrim(Me.lblClave.Text)
        vcData = LTrim(Me.lblData.Text)
        'vnCantidad = funNull2Val(Me.cbCantidad.Value)
        'vnPrecioUnitario = funNull2Val(Me.cbPrecio.Value)
        'vnDescuento = funNull2Val(Me.cbDescuento.Value)
        'vnIva = funNull2Val(Me.cbIva.Value)
        'vnCantidad2 = CDbl(Me.lblCantidad2.Text)
        '-- 20-07-2017
        vnCantidad = cbCantidad2.Value
        vnPrecioUnitario = cbPrecio2.Value
        vnDescuento = funNull2Val(Me.cbDescuento.Value)
        vnIva = funNull2Val(Me.cbIva.Value)
        '--
        bolFound = True
        Me.Close()
        '--
    End Sub
    Dim vnUnidad2 As Double

    Private Sub gvProducto_Click(sender As System.Object, e As System.EventArgs) Handles gvProducto.Click
        '--
        If Me.gvProducto.RowCount = 0 Then
            Exit Sub
        End If
        Me.lblCode.Text = Me.gvProducto.GetFocusedRowCellValue("nCode")
        Me.lblClave.Text = Me.gvProducto.GetFocusedRowCellValue("strClave")
        Me.lblData.Text = Me.gvProducto.GetFocusedRowCellValue("strData")
        Me.lblUnidad1.Text = Me.gvProducto.GetFocusedRowCellValue("strMedida")
        Me.lblUnidad2.Text = Me.gvProducto.GetFocusedRowCellValue("strMedida")
        '--
        Me.cbCantidad2.Value = 0
        Me.cbCantidad.Value = 0
        Me.cbPrecio.Value = 0
        Me.cbDescuento.Value = 0
        Me.cbPrecio2.Value = 0
        '--
        vnCode = Me.gvProducto.GetFocusedRowCellValue("nCode")
        '--
    End Sub
    Private Sub funCalculoUnidades()
        '--
        If Me.lkMedida.EditValue = 1 Then
            vnUnidad2 = 1
        ElseIf Me.lkMedida.EditValue = 2 Then
            vnUnidad2 = 1000
        ElseIf Me.lkMedida.EditValue = 3 Then
            vnUnidad2 = 1000
        ElseIf Me.lkMedida.EditValue = 4 Then
            vnUnidad2 = 3785.41
        ElseIf Me.lkMedida.EditValue = 5 Then
            vnUnidad2 = 1
        End If
        '--        
        Me.cbCantidad2.Value = cbCantidad.Value * vnUnidad2
        '--
    End Sub
    Private Sub cbCantidad_EditValueChanged(sender As Object, e As EventArgs) Handles cbCantidad.EditValueChanged
        If Me.cbCantidad.Value > 0 Then
            funCalculoUnidades()
        End If
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

    Private Sub lkMedida_EditValueChanged(sender As Object, e As EventArgs) Handles lkMedida.EditValueChanged
        If Me.bolInicio = False Then
            Me.cbCantidad.Value = 0
            Me.cbCantidad2.Value = 0
            Me.cbPrecio.Value = 0
            Me.cbPrecio2.Value = 0
        End If
    End Sub

    Private Sub cbPrecio_EditValueChanged(sender As Object, e As EventArgs) Handles cbPrecio.EditValueChanged
        If Me.cbPrecio.Value > 0 Then
            funCalculoPrecio()
        End If
    End Sub

    Private Sub funCalculoPrecio()
        '--
        Me.cbPrecio2.Value = (cbPrecio.Value * Me.cbCantidad.Value) / Me.cbCantidad2.Value
        '--
    End Sub
End Class