Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmInvAjuste_Seek2
    Dim ds As New DataSet
    Public nTransaction As Integer
    Shadows focus As Object
    Dim bolTipoBusqueda As Boolean
    Public nTipo As Integer

    Private Sub frmInvAjuste_Seek2_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub frmInvAjuste_Seek2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        '--
        bolFound = False
        '--
        bolTipoBusqueda = False
        funUpdateGrid()
        bolTipoBusqueda = True
        If Me.nTransaction = 1 Then
            Me.cbCantidad.Value = 0
            Me.cbCantidad2.Value = 0
            Me.cbPrecio.Value = 0
            Me.txtNombre.Focus()
        Else
            If nTipo = 1 Then
                gcProducto.Enabled = False
                Me.txtNombre.Enabled = False
                Me.bbAceptar.Enabled = True
            Else
                gcProducto.Enabled = False
                Me.txtNombre.Enabled = False
                Me.bbAceptar.Enabled = False
                Me.cbCantidad.Enabled = False
                Me.cbPrecio.Enabled = False
            End If
        End If
        '--
    End Sub

    Private Function funUpdateGrid() As Boolean
        '--
        If bolTipoBusqueda = True Then
            '-- Busca el contenido de textbox
            strSQL = "SELECT * " & _
                        "FROM v_Inv_Producto "
            '--
            strSQL += "WHERE (strData LIKE '%" & Me.txtNombre.Text & "%' OR strClave LIKE '%" & Me.txtNombre.Text & "%')"
            '--
            strSQL += " ORDER BY strData "
        Else
            '-- Cuando carga por default
            strSQL = "SELECT TOP 100 * FROM v_Inv_Producto ORDER BY strData"
        End If
        '--
        ds = funFillDataSet(strSQL)
        '--
        Me.gcProducto.DataSource = ds.Tables(0)
        '--
        GridViewStyle(Me.GridView1)
        funOcultarTodasLasColumnas(Me.GridView1)
        '--
        indice = 0
        '--
        funSetColumna(Me.GridView1, "strClave", "Código", funIndice(), 100, 1)
        funSetColumna(Me.GridView1, "strData", "Producto", funIndice(), 300, 1)
        funSetColumna(Me.GridView1, "strMedida", "U.Medida", funIndice(), 100, 1)
        '--
        Return True
    End Function

    Private Sub gcProducto_Click(sender As System.Object, e As System.EventArgs) Handles gcProducto.Click
        '--
        If Me.GridView1.RowCount = 0 Then
            Exit Sub
        End If
        Me.lblCode.Text = Me.GridView1.GetFocusedRowCellValue("nCode")
        Me.lblCodigo.Text = Me.GridView1.GetFocusedRowCellValue("strClave")
        Me.lblProducto.Text = Me.GridView1.GetFocusedRowCellValue("strData")
        Me.lblUnidad1.Text = Me.GridView1.GetFocusedRowCellValue("strMedida")
        vnCode = Me.GridView1.GetFocusedRowCellValue("nCode")
        '--
    End Sub

    Private Sub bbAceptar_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbAceptar.ItemClick
        '--
        If Len(Trim(Me.lblCodigo.Text)) = 0 Then
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
        vnCode = LTrim(Me.lblCode.Text)
        vcCode = LTrim(Me.lblCodigo.Text)
        vcData = LTrim(Me.lblProducto.Text)
        vnCantidad = funNull2Val(Me.cbCantidad.Value)
        vnCantidad2 = funNull2Val(Me.cbCantidad2.Value)
        vnPrecioUnitario = funNull2Val(Me.cbPrecio.Value)
        '--
        bolFound = True
        Me.Close()
        '--
    End Sub

    Private Sub bbClose_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbClose.ItemClick
        '-- Poner en false porque de lo contrario actualiza
        bolFound = False
        Me.Close()
        '--
    End Sub

    Private Sub cbCantidad_EditValueChanged(sender As Object, e As EventArgs) Handles cbCantidad.EditValueChanged
        funCalculoUnidades()
    End Sub

    Dim vnUnidad2 As Double

    Private Sub funCalculoUnidades()
        '--
        If Me.lblUnidad1.Text = "Und" Then
            'Me.lblUnidad2.Text = "Und"
            vnUnidad2 = 1
        ElseIf Me.lblUnidad1.Text = "Kg" Then
            'Me.lblUnidad2.Text = "Gr"
            vnUnidad2 = 1000
        ElseIf Me.lblUnidad1.Text = "Lt" Then
            'Me.lblUnidad2.Text = "Ml"
            vnUnidad2 = 1000
        ElseIf Me.lblUnidad1.Text = "Gl" Then
            'Me.lblUnidad2.Text = "Ml"
            vnUnidad2 = 3785.41
        ElseIf Me.lblUnidad1.Text = "Gr" Then
            'Me.lblUnidad2.Text = "Gr"
            vnUnidad2 = 1
        End If
        '--
        cbCantidad2.Value = cbCantidad.Value * vnUnidad2
        '--
    End Sub

    Private Sub cbCantidad2_EditValueChanged(sender As Object, e As EventArgs) Handles cbCantidad2.EditValueChanged
        funCalculoUnidades2()
    End Sub

    Dim vnUnidad3 As Double
    Private Sub funCalculoUnidades2()
        '--
        If Me.lblUnidad1.Text = "Und" Then
            'Me.lblUnidad2.Text = "Und"
            vnUnidad3 = 1
        ElseIf Me.lblUnidad1.Text = "Kg" Then
            'Me.lblUnidad2.Text = "Gr"
            vnUnidad3 = 1000
        ElseIf Me.lblUnidad1.Text = "Lt" Then
            'Me.lblUnidad2.Text = "Ml"
            vnUnidad3 = 1000
        ElseIf Me.lblUnidad1.Text = "Gl" Then
            'Me.lblUnidad2.Text = "Ml"
            vnUnidad3 = 3785.41
        ElseIf Me.lblUnidad1.Text = "Gr" Then
            'Me.lblUnidad2.Text = "Gr"
            vnUnidad3 = 1
        End If
        '--
        If vnUnidad3 > 0 Then
            cbCantidad.Value = cbCantidad2.Value / vnUnidad3
        End If
        '--
    End Sub
End Class