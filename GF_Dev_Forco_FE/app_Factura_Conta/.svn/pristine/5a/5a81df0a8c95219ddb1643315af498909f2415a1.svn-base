Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Math

Public Class frmFactura_Data
    Dim varToday As Date
    Dim ds As New DataSet
    Dim bolInicio As Boolean
    Dim i As Integer
    Dim nTipoMovGrid As Integer
    Dim r As Integer
    Dim intTipoRegistro As Integer
    Public vnOrden As Integer '- Numero de Orden para nuevos numeros y busqueda
    Public vnRecno, nTipo, vnNumero, vnConcepto, vnTipoMovimiento As Integer
    Dim vnProveedor As Integer
    Public vcRazon_Social As String
    Dim vnTotalMercanciaGravada As Double
    Dim vnTotalMercanciaExentas As Double
    Dim vnTotalVenta As Double
    Dim vnTotalVentaNeta As Double
    Dim vnTotalImpuesto As Double
    Dim vnTotalComprobante As Double
    Dim vnTotalDescuento As Double
    '--
    Dim vnTotalServGravados As Double
    Dim vnTotalServExentos As Double


    Private Sub frmFactura_Data_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        bolInicio = True
        If nTipo = 1 Then
            funCargaCombos()
            funUpdateGrid()
            Me.lkConcepto.EditValue = 9
            Me.lkVenta.EditValue = 2
            'Me.lkClienteTipo.EditValue = 2
            '-- Obtenemos el nuevo numero de movimiento de inventario
            'Me.lblNumero.Text = funNuevoMovInventario(Me.lkConcepto.EditValue)
            'vnNumero = funNuevoMovInventario(Me.lkConcepto.EditValue)
            '-- Obtener el tipo de movimiento
            funGetTipoMovimiento()
        Else
            funCargaCombos()
            funCargaData()
            Me.lkConcepto.EditValue = vnConcepto
            Me.lkCliente.EditValue = vnProveedor
            funUpdateGrid()
            Me.lkConcepto.Enabled = False
            'Me.txtNotas.Enabled = False
            'Me.txtReferencia.Enabled = False
            Me.bbSave.Enabled = False
            Me.bbAdd.Enabled = False
            Me.bbEdit.Enabled = False
            Me.dtpFecha.Enabled = False
            '-- 
            'Me.txtReferencia.Enabled = False
            'Me.txtFactura.Enabled = False
            'Me.dtpOrden.Enabled = False
            'Me.dtpFactura.Enabled = False
            Me.lkCliente.Enabled = False
            'Me.dtpRecibe.Enabled = False
            'Me.txtRecibido.Enabled = False
            'Me.txtAutorizado.Enabled = False
            '-- Me.cbDescuento.Enabled = False
            funCalculoTotalProducto()
        End If
        bolInicio = False
    End Sub

    Private Sub funCargaCombos()
        '-- Combo Conceptos no reservados
        strSQL = "SELECT nCode AS nCodigo, strData AS strDescripcion " &
                    " FROM Inv_Concepto " &
                    " WHERE nCode = 9"
        '--
        funCargarlue(Me.lkConcepto, strSQL)

        '-- Combo Sociedad
        strSQL = "SELECT nRazon AS nCodigo, Razon_Nombre AS strDescripcion " &
                    " FROM GB_Sociedad_FE"
        '--
        funCargarlue(Me.lkRazon, strSQL)

        '-- Combo Proveedores
        strSQL = "SELECT nPersona AS nCodigo, strFullName AS strDescripcion " &
                    " FROM Gen_Cliente_Venta"
        '--
        funCargarlue(Me.lkCliente, strSQL)

        '-- Tipo de Venta Credito o Contado
        strSQL = "SELECT nCode AS nCodigo, strData AS strDescripcion " &
                    " FROM Cat_Venta_Tipo"
        '--
        funCargarlue(Me.lkVenta, strSQL)

        '-- Tipo de Cliente
        strSQL = "SELECT nCode AS nCodigo, strData AS strDescripcion " &
                    " FROM CAT_Cliente_Precio"
        '--
        'funCargarlue(Me.lkClienteTipo, strSQL)
        '--
    End Sub

    Private Function funDesactivar()
        Me.bbSave.Enabled = False
        Me.bbAdd.Enabled = False
        Me.bbEdit.Enabled = False
        'Me.txtNotas.Enabled = False
        Me.gcDetalle.Enabled = False
        Return True
    End Function

    Private Sub lkRazon_EditValueChanged(sender As Object, e As EventArgs) Handles lkRazon.EditValueChanged
        If Me.bolInicio = False Then
            Me.lblNumero.Text = funNuevoMovInventario(Me.lkConcepto.EditValue, Me.lkRazon.EditValue)
        End If
    End Sub

    Private Sub lkCliente_EditValueChanged(sender As Object, e As EventArgs) Handles lkCliente.EditValueChanged
        If Me.bolInicio = False Then
            funCarga_Cliente()
        End If
    End Sub

    Private Sub funCarga_Cliente()
        '-- 
        strSQL = "SELECT * FROM Gen_Cliente_Venta " &
                    "WHERE nPersona = " & Me.lkCliente.EditValue & " " &
                    "ORDER BY nPersona"
        '-- Cargamos el DS
        ds = funFillDataSet(strSQL)
        '-- Verificamos si existen registros
        If ds.Tables("Tabla").Rows.Count >= 1 Then
            '-- Cargamos datos
            Me.lblCedula.Text = ds.Tables("Tabla").Rows(0)("strCedula").ToString
            Me.lblTelefono.Text = ds.Tables("Tabla").Rows(0)("strTelefono").ToString
            Me.lblCorreo.Text = ds.Tables("Tabla").Rows(0)("strCorreo").ToString
            Me.lblDireccion.Text = ds.Tables("Tabla").Rows(0)("strDomicilio").ToString
        Else
            MsgBox("No Existen Registros ... !!!", MsgBoxStyle.Critical, "Información")
        End If
        '--
    End Sub


    Private Sub funUpdateGrid()
        '--
        strSQL = "SELECT * " &
                    "FROM Inv_Movto_Inventario_Detalle " &
                    "WHERE nNumero = " & Me.vnNumero & " " &
                    "AND nConcepto = " & CDbl(Me.lkConcepto.EditValue) & " " &
                    "AND nEmpresa = " & intEmpresa & " " &
                    "ORDER BY nRecno"
        '--
        ds = funFillDataSet(strSQL)
        '--
        Me.gcDetalle.DataSource = funFillDataSet(strSQL).Tables(0)
        '--
        GridViewStyle(Me.gvDetalle)
        funOcultarTodasLasColumnas(Me.gvDetalle)
        indice = 0
        '--
        '-- funSetColumna(gvDetalle, "nCode", "No.", funIndice(), 50, 1)
        funSetColumna(gvDetalle, "strClave", "Cod.", funIndice(), 90, 1)
        funSetColumna(gvDetalle, "strData", "Descripción", funIndice(), 200, 1)
        funSetColumna(gvDetalle, "nCantidad", "Cantidad.", funIndice(), 70, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
        funSetColumna(gvDetalle, "nPUnitario", "P.Unitario", funIndice(), 80, 1, , , "n4", 3, , DevExpress.Utils.FormatType.Numeric)
        funSetColumna(gvDetalle, "nSubTotal", "Sub-Total", funIndice(), 90, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
        funSetColumna(gvDetalle, "nMontoDescuento", "Monto Descto.", funIndice(), 90, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
        funSetColumna(gvDetalle, "nTotalSinIva", "Total Sin  Iva", funIndice(), 90, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
        funSetColumna(gvDetalle, "nMontoIva", "IVA", funIndice(), 80, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
        funSetColumna(gvDetalle, "nGranTotal", "Total", funIndice(), 120, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
        '--
    End Sub


    Private Sub funCargaData()
        '-- GB-2012-01-12: Filtramos el registro de la cabezera
        strSQL = "SELECT * FROM Inv_Movto_Inventario " &
                    "WHERE nNumero = " & Me.vnNumero & " " &
                    "AND nConcepto = " & Me.vnConcepto & " " &
                    "AND nEmpresa = " & intEmpresa & " " &
                    "ORDER BY nNumero"
        '-- Cargamos el DS
        ds = funFillDataSet(strSQL)
        '-- Verificamos si existen registros
        If ds.Tables("Tabla").Rows.Count >= 1 Then
            '-- Cargamos datos
            Me.dtpFecha.Value = ds.Tables("Tabla").Rows(0)("dtmFechaDoc").ToString
            Me.vnConcepto = funNull2Val(ds.Tables("Tabla").Rows(0)("nConcepto"))
            Me.lblNumero.Text = funNull2Val(ds.Tables("Tabla").Rows(0)("nNumero"))
            'Me.txtReferencia.Text = ds.Tables("Tabla").Rows(0)("strReferencia").ToString
            'Me.txtNotas.Text = ds.Tables("Tabla").Rows(0)("strNota").ToString
            '-- 
            'Me.txtReferencia.Text = ds.Tables("Tabla").Rows(0)("strOrden").ToString
            'Me.txtFactura.Text = ds.Tables("Tabla").Rows(0)("strFactura").ToString
            'Me.dtpOrden.Value = ds.Tables("Tabla").Rows(0)("dtmOrden").ToString
            'Me.dtpFactura.Value = ds.Tables("Tabla").Rows(0)("dtmFactura").ToString
            vnProveedor = CInt(funNull2Val(ds.Tables("Tabla").Rows(0)("nOrigenDestino")))
            '-- 2012-02-21 Agregamos: strPersonaRecibe, strPersonaAutoriza, dtmRecibido
            'Me.dtpRecibe.Value = ds.Tables("Tabla").Rows(0)("dtmRecibido").ToString
            'Me.txtRecibido.Text = ds.Tables("Tabla").Rows(0)("strPersonaRecibe").ToString
            'Me.txtAutorizado.Text = ds.Tables("Tabla").Rows(0)("strPersonaAutoriza").ToString
        Else
            MsgBox("No Existen Registros ... !!!", MsgBoxStyle.Critical, "Información")
        End If
        '--
    End Sub

    Private Function funGetTipoMovimiento()
        '-- Tomado del proyecto PHOENIX
        '-- Obtenemos el tipo de movimiento del concepto
        strSQL = "SELECT nTipoConcepto " &
                    " FROM Inv_Concepto " &
                    " WHERE nCode = " & CDbl(Me.lkConcepto.EditValue)
        '-- 1:Entrada, 2:Salida
        vnTipoMovimiento = funGetValor(strSQL)
        Return True
    End Function

    Private Sub bClose_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bClose.ItemClick
        Me.Close()
    End Sub

    Private Sub frmFactura_Data_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
        '--
        Select Case e.KeyCode
            Case Keys.F1
                subAdd()
            Case Keys.F2
                subEdit()
            Case Keys.F3
                'subKardex()
        End Select
    End Sub

    Private Sub bbAdd_Click(sender As System.Object, e As System.EventArgs) Handles bbAdd.Click
        '- Constar lineas
        If gvDetalle.RowCount >= 500 Then
            MsgBox("No puede agregar mas lineas a este documento, el limite es 500 !!!", MsgBoxStyle.Information, "Atención !!!")
        Else
            subAdd()
        End If

    End Sub

    Private Sub subAdd()
        Dim f As New frmFactura_Seek2
        f.barText.Caption = "Agregando Artículo"
        f.nTransaction = 1
        f.nTipo = nTipo '-- 1: Agregando documento, 2: Editando Documento
        vnTipoCliente = 2
        f.ShowDialog()
        '--
        If bolFound = True Then
            nTipoMovGrid = 1
            funCargaGrid()
            funCalculoTotalProducto()
        End If
        '--
    End Sub

    Private Sub bbEdit_Click(sender As System.Object, e As System.EventArgs) Handles bbEdit.Click
        '--
        subEdit()
        '--
    End Sub

    Private Sub gcDetalle_DoubleClick(sender As System.Object, e As System.EventArgs) Handles gcDetalle.DoubleClick
        '--
        subEdit()
        '--
    End Sub

    Private Sub subEdit()
        With Me.gvDetalle
            If .RowCount > 0 Then
                Dim f As New frmFactura_Seek2
                f.barText.Caption = "Editanto Producto"
                '-- Esto lo hago porque la variable publica me guarda el ultimo valor del vnCode que guardo en el grid
                vnCode = .GetFocusedRowCellValue(.Columns("nCode"))
                f.lblCode.Text = .GetFocusedRowCellValue(.Columns("nCode"))
                f.lblClave.Text = .GetFocusedRowCellValue(.Columns("strClave"))
                f.lblData.Text = .GetFocusedRowCellValue(.Columns("strData"))
                f.cbCantidad.Value = funNull2Val(.GetFocusedRowCellValue(.Columns("nCantidad")))
                f.cbPrecio.Value = funNull2Val(.GetFocusedRowCellValue(.Columns("nPUnitario")))
                f.cbIva.Value = funNull2Val(.GetFocusedRowCellValue(.Columns("nPerIva")))
                f.cbDescuento.Value = funNull2Val(.GetFocusedRowCellValue(.Columns("nPerDescuento")))
                f.nTransaction = 2
                f.nTipo = nTipo '-- 1: Agregando documento, 2: Editando Documento
                f.ShowDialog()
                If bolFound = True Then
                    nTipoMovGrid = 2
                    funCargaGrid()
                    funCalculoTotalProducto()
                End If
            End If
        End With
    End Sub

    Private Sub funCargaGrid()
        '-- 22/07/2009: Agregando al grid detalle
        Dim vnPercentDescuento, vnImporte, vnMontoDescuento, vnMontoSinIva, vnMontoIva As Double
        '-- MsgBox(vnCode)
        With Me.gvDetalle
            For i = 0 To Me.gvDetalle.RowCount - 1
                If vnCode = Me.gvDetalle.GetRowCellValue(i, "nCode") And nTipoMovGrid = 1 Then
                    MsgBox("Este producto ya esta en la Orden de Entrada !!!", MsgBoxStyle.Information, "Atención")
                    Exit Sub
                End If
            Next
            If nTipoMovGrid = 1 Then
                .AddNewRow()
            End If
            .SetFocusedRowCellValue(.Columns("nCode"), vnCode)
            .SetFocusedRowCellValue(.Columns("strClave"), vcCode)
            .SetFocusedRowCellValue(.Columns("strData"), vcData)
            .SetFocusedRowCellValue(.Columns("nCantidad"), funNull2Val(vnCantidad))
            .SetFocusedRowCellValue(.Columns("nPUnitario"), funNull2Val(vnPrecioUnitario))
            .SetFocusedRowCellValue(.Columns("nSubTotal"), funNull2Val(vnCantidad) * funNull2Val(vnPrecioUnitario))
            If vnDescuento > 0 Then
                vnPercentDescuento = funNull2Val(vnDescuento) / 100
                vnImporte = funNull2Val(vnCantidad) * funNull2Val(vnPrecioUnitario)
                vnMontoDescuento = vnImporte * vnPercentDescuento
                vnMontoSinIva = vnImporte - vnMontoDescuento
                .SetFocusedRowCellValue(.Columns("nPerDescuento"), vnDescuento)
                .SetFocusedRowCellValue(.Columns("nMontoDescuento"), vnMontoDescuento)
                .SetFocusedRowCellValue(.Columns("nTotalSinIva"), vnMontoSinIva)
            Else
                vnPercentDescuento = 0
                vnImporte = funNull2Val(vnCantidad) * funNull2Val(vnPrecioUnitario)
                vnMontoDescuento = vnImporte * vnPercentDescuento
                vnMontoSinIva = vnImporte - vnMontoDescuento
                .SetFocusedRowCellValue(.Columns("nPerDescuento"), vnDescuento)
                .SetFocusedRowCellValue(.Columns("nMontoDescuento"), vnMontoDescuento)
                .SetFocusedRowCellValue(.Columns("nTotalSinIva"), vnMontoSinIva)
            End If
            If vnIva = 0 Then '-- Si es Exento
                vnMontoIva = 0
                .SetFocusedRowCellValue(.Columns("nMontoIva"), vnMontoIva)
            Else
                vnMontoIva = Round(vnMontoSinIva * 0.13, 2)
                .SetFocusedRowCellValue(.Columns("nMontoIva"), vnMontoIva)
            End If
            .SetFocusedRowCellValue(.Columns("nGranTotal"), vnMontoSinIva + vnMontoIva)
            .SetFocusedRowCellValue(.Columns("nPerIva"), vnIva)
            '--
            .UpdateCurrentRow()
        End With
        If Me.gvDetalle.RowCount > 0 Then
            Dim nRecords As Integer
            nRecords = Me.gvDetalle.RowCount
            'Me.barRecord.Caption = "Registros : " & nRecords
        End If
    End Sub

    Private Function funCalcularTotalFinal()
        If Val(Me.lblTotal.Text) > 0 Then
            Me.lblTotalNeto.Text = (CDbl(Me.lblTotal.Text) + CDbl(Me.lblTax.Text)).ToString("n2")
        End If
        Return True
    End Function

    Private Sub bbSave_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbSave.ItemClick
        If Validar() = True Then
            If MessageBox.Show("¿ Desea Grabar los datos ahora ...?", "ATENCION !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = MsgBoxResult.Yes Then
                Guardar()
                '-- Luego de guardar generamos la FE
                clsFactura.funGetFacturaElectronica(Me.lkRazon.EditValue, vnNumero)
            End If
        End If
    End Sub

    Private Function Validar() As Boolean
        If Me.lkConcepto.EditValue = 0 Then
            Me.lkConcepto.Focus()
            Me.lkConcepto.SelectAll()
            MsgBox("Falta Concepto !!!", MsgBoxStyle.Critical, "Atención !!!")
            Return False
        ElseIf Me.lkRazon.EditValue = 0 Then
            Me.lkRazon.Focus()
            Me.lkRazon.SelectAll()
            MsgBox("Falta Sociedad !!!", MsgBoxStyle.Critical, "Atención !!!")
            Return False
        ElseIf Me.gvDetalle.RowCount = 0 Then
            MsgBox("Falta detalle de Productos   !!!", MsgBoxStyle.Critical, "Atención !!!")
            Me.gcDetalle.Focus()
            Return False
        ElseIf Me.lkCliente.EditValue = 0 Then
            Me.lkCliente.Focus()
            Me.lkCliente.SelectAll()
            MsgBox("Falta Receptor !!!", MsgBoxStyle.Critical, "Atención !!!")
            Return False
        ElseIf Me.cbDollar.Value = 0 Then
            Me.cbDollar.Focus()
            Me.cbDollar.SelectAll()
            MsgBox("Falta Tipo de Cambio !!!", MsgBoxStyle.Critical, "Atención !!!")
            Return False
        End If
        Return True
    End Function

    Dim vnTotalGravado, vnTotalExento As Double
    Private Sub funCalculoTotalProducto()
        '-- Calculamos el SubTotal del Grid
        If Me.gvDetalle.RowCount = 0 Then
            Me.lblSubTotal.Text = 0
            Me.lblDescuento.Text = 0
            Me.lblTotal.Text = 0
            Me.lblTax.Text = 0
            Me.lblTotalNeto.Text = 0
            Exit Sub
        End If
        Dim vnsumTotal, vnSumDescuento, vnSumSubTotal, vnSumIva, vnSumGranTotal, vnSumGravada, vnSumExenta, vnSumServGravada, vnSumServExento As Double
        '--
        vnTotalMercanciaGravada = 0
        vnTotalMercanciaExentas = 0
        vnTotalServGravados = 0
        vnTotalServExentos = 0
        vnTotalVenta = 0
        vnTotalDescuento = 0
        vnTotalVentaNeta = 0
        vnTotalImpuesto = 0
        vnTotalComprobante = 0
        '-- 
        vnTotalServGravados = 0
        '--
        For i = 0 To Me.gvDetalle.RowCount - 1
            vnSumSubTotal += funNull2Val(Me.gvDetalle.GetDataRow(i)("nSubTotal"))
            vnSumDescuento += funNull2Val(Me.gvDetalle.GetDataRow(i)("nMontoDescuento"))
            vnsumTotal += funNull2Val(Me.gvDetalle.GetDataRow(i)("nTotalSinIva"))
            vnSumIva += funNull2Val(Me.gvDetalle.GetDataRow(i)("nMontoIva"))
            vnSumGranTotal += funNull2Val(Me.gvDetalle.GetDataRow(i)("nGranTotal"))
            '-- sumamos totales
            If vnVentasServicios = 1 Then
                If funNull2Val(Me.gvDetalle.GetDataRow(i)("nMontoIva")) > 0 Then
                    vnSumServGravada += funNull2Val(Me.gvDetalle.GetDataRow(i)("nSubTotal"))
                Else
                    vnSumServExento += funNull2Val(Me.gvDetalle.GetDataRow(i)("nSubTotal"))
                End If
            Else
                If funNull2Val(Me.gvDetalle.GetDataRow(i)("nMontoIva")) > 0 Then
                    vnSumGravada += funNull2Val(Me.gvDetalle.GetDataRow(i)("nSubTotal"))
                Else
                    vnSumExenta += funNull2Val(Me.gvDetalle.GetDataRow(i)("nSubTotal"))
                End If
            End If
        Next
        '--
        Me.lblSubTotal.Text = vnSumSubTotal.ToString("n2")
        Me.lblDescuento.Text = vnSumDescuento.ToString("n2")
        Me.lblTotal.Text = vnsumTotal.ToString("n2")
        Me.lblTax.Text = vnSumIva.ToString("n2")
        Me.lblTotalNeto.Text = vnSumGranTotal.ToString("n2")
        '--
        vnTotalMercanciaGravada = vnSumGravada
        vnTotalMercanciaExentas = vnSumExenta
        '--
        vnTotalServGravados = vnSumServGravada
        vnTotalServExentos = vnSumServExento
        '-- Nuevo
        vnTotalGravado = vnTotalMercanciaGravada + vnTotalServGravados
        vnTotalExento = vnTotalMercanciaExentas + vnTotalServExentos
        '--
        'vnTotalVenta = vnTotalMercanciaGravada + vnTotalMercanciaExentas
        vnTotalVenta = vnTotalGravado + vnTotalExento
        vnTotalDescuento = vnSumDescuento
        'vnTotalVentaNeta = (vnTotalMercanciaGravada + vnTotalMercanciaExentas) - vnTotalDescuento
        vnTotalVentaNeta = vnTotalVenta - vnTotalDescuento
        '--
        vnTotalImpuesto = vnSumIva
        '--
        '--vnTotalComprobante = (vnTotalMercanciaGravada + vnTotalMercanciaExentas) - vnTotalDescuento + vnTotalImpuesto
        vnTotalComprobante = vnTotalVentaNeta + vnTotalImpuesto

    End Sub
    Dim vnVentasServicios As Integer = 1
    Private Sub Guardar()
        '--
        AbrirConexionGlobal()
        Try
            '-- GB-2012-01-09: Multiples conexiones, renumera codigo
            If nTipo = 1 Then
                vnNumero = funNuevoMovInventario(Me.lkConcepto.EditValue, Me.lkRazon.EditValue)
            End If
            '-- Datos de la transacción
            strSQL = "SELECT * FROM Inv_Movto_Inventario " &
                       "WHERE nEmpresa = " & intEmpresa & " " &
                       "AND nRazon = " & Me.lkRazon.EditValue & " " &
                       "AND nConcepto = " & Me.lkConcepto.EditValue & " " &
                       "AND nNumero = " & vnNumero & " " &
                       "ORDER BY nNumero"
            '--
            Dim dsAgregar As DataSet = funFillDataSet(strSQL)
            If dsAgregar.Tables("Tabla").Rows.Count = 0 Then
                vnNumero = funNuevoMovInventario(Me.lkConcepto.EditValue, Me.lkRazon.EditValue)
                dsAgregar.Tables("Tabla").Rows.Add()
            End If
            '--
            With dsAgregar.Tables("Tabla").Rows(0)
                '-- Fecha del Servidor
                varToday = funFechaServer()
                '-- Tomamos el nRecno
                Dim vnRecno = funNull2Val(.Item("nRecno"))
                '-- Tipo de Accion para Guardar: 1:Add, 2:Update
                intTipoRegistro = IIf(funNull2Val(.Item("nRecno")) = 0, 1, 2)
                '--
                If intTipoRegistro = 1 Then
                    '-- Insertando
                    funAddCampo("nEmpresa", intEmpresa, 0)
                    funAddCampo("nRazon", Me.lkRazon.EditValue, 0)
                    funAddCampo("nConcepto", Me.lkConcepto.EditValue, 0)
                    funAddCampo("nNumero", vnNumero, vnNumero)
                    funAddCampo("nTipoMovto", vnTipoMovimiento, 0)
                    funAddCampo("nTipoVenta", Me.lkVenta.EditValue, 0)
                    funAddCampo("dtmFechaDoc", funFechaSql(Me.dtpFecha.Value.Date), "")
                    funAddCampo("nOrigenDestino", Me.lkCliente.EditValue, 0)
                    funAddCampo("strOrigenDestino", Me.lkCliente.Text, "")
                    '-- Datos del registro
                    funAddCampo("strUserAdd", strUser, "")
                    funAddCampo("strUserUpdate", strUser, "")
                    funAddCampo("dtmUpdate", funFechaSql(varToday), "")
                    '-- 
                    funAddCampo("nSub_Total", CDbl(Me.lblSubTotal.Text), 0)
                    funAddCampo("nDescuento", CDbl(Me.lblDescuento.Text), 0)
                    funAddCampo("nTotal", CDbl(Me.lblTotal.Text), 0)
                    funAddCampo("nImpuesto", CDbl(Me.lblTax.Text), 0)
                    funAddCampo("nTotal_Neto", CDbl(Me.lblTotalNeto.Text), 0)
                    '-- Totales
                    If vnVentasServicios = 1 Then
                        funAddCampo("nTotalMercancia_Gravada", 0, 0)
                        funAddCampo("nTotalMercancia_Exentas", 0, 0)
                        funAddCampo("TotalServGravados", vnTotalServGravados, 0)
                        funAddCampo("TotalServExentos", vnTotalServExentos, 0)
                        funAddCampo("nTotal_Gravado", vnTotalGravado, 0)
                        funAddCampo("nTotal_Exento", vnTotalExento, 0)
                        funAddCampo("nTotal_Venta", vnTotalVenta, 0)
                        funAddCampo("nTotal_Descuentos", vnDescuento, 0)
                        funAddCampo("nTotal_Venta_Neta", vnTotalVentaNeta, 0)
                        funAddCampo("nTotal_Impuesto", Round(vnTotalImpuesto, 2), 0)
                        funAddCampo("nTotal_Comprobante", vnTotalComprobante, 0)
                    Else
                        funAddCampo("nTotalMercancia_Gravada", vnTotalMercanciaGravada, 0)
                        funAddCampo("nTotalMercancia_Exentas", vnTotalMercanciaExentas, 0)
                        funAddCampo("TotalServGravados", 0, 0)
                        funAddCampo("TotalServExentos", 0, 0)
                        funAddCampo("nTotal_Gravado", vnTotalGravado, 0)
                        funAddCampo("nTotal_Exento", vnTotalExento, 0)
                        funAddCampo("nTotal_Venta", vnTotalVenta, 0)
                        funAddCampo("nTotal_Descuentos", vnDescuento, 0)
                        funAddCampo("nTotal_Venta_Neta", vnTotalVentaNeta, 0)
                        funAddCampo("nTotal_Impuesto", Round(vnTotalImpuesto, 2), 0)
                        funAddCampo("nTotal_Comprobante", vnTotalComprobante, 0)
                    End If
                    '--
                    funAddCampo("nTipo_Cambio", Me.cbDollar.Value, 0)
                    '--
                Else
                    funAddCampo("dtmFechaDoc", funFechaSql(Me.dtpFecha.Value.Date), .Item("dtmFechaDoc").ToString)
                    funAddCampo("strUserUpdate", strUser, .Item("strUserUpdate").ToString)
                    funAddCampo("dtmUpdate", funFechaSql(varToday), .Item("dtmUpdate").ToString)
                    '--
                End If
                '-- Filtro para Llave 
                strLlave = " nEmpresa = " & intEmpresa & " " &
                            "AND nConcepto = " & Me.lkConcepto.EditValue & " " &
                            "AND nRazon = " & Me.lkRazon.EditValue & " " &
                            "AND nNumero = " & vnNumero
                '--
                funParametrosGrabacionTransaccion("Inv_Movto_Inventario", strLlave, intTipoRegistro, vnRecno)
                '-- Grabamos el Detalle del Movimiento
                funGrabarDetalle()
                '-- Grabamos el Mestro del Inventario
                funSaveMasterInventario()
                '-- Grabamos Existencia
                funSaveSaldoPorBodega()
                '-- Grabamos Control Factura Electronica
                funSaveControlFE()
                '--
                transaccionGlobal.Commit()
            End With
        Catch ex As Exception
            LimpiarCampos()
            transaccionGlobal.Rollback()
            DBConnGlobal.Close()
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
        DBConnGlobal.Close()
        Me.Close()
        '--
    End Sub

    Function funSaveControlFE()
        '-- Grabamos datos para la factura electronica
        'If nTipo = 1 Then
        '    vnNumero = funNuevoMovInventario(Me.lkConcepto.EditValue, Me.lkRazon.EditValue)
        'End If
        '-- Datos de la transacción
        Dim vnTipoDoc_Id As Integer = 1
        Dim vnCaja_Id As Integer = 1
        Dim vnSuc_Id As Integer
        '-- Buscamos datos importantes
        vnSuc_Id = funBuscaSucursal(Me.lkRazon.EditValue)
        vcRazon_Social = funBuscaRazon(Me.lkRazon.EditValue)
        '--
        strSQL = "SELECT * FROM GB_Control_FE " &
                   "WHERE nEmpresa = " & intEmpresa & " " &
                   "And nRazon = " & Me.lkRazon.EditValue & " " &
                   "And TipoDoc_Id = " & vnTipoDoc_Id & " " &
                   "And Suc_Id = " & vnSuc_Id & " " &
                   "And Caja_Id = " & vnCaja_Id & " " &
                   "And Factura_Id = " & vnNumero & " " &
                   "ORDER BY nConsecutivo"
        '--
        Dim dsAgregar As DataSet = funFillDataSet(strSQL)
        If dsAgregar.Tables("Tabla").Rows.Count = 0 Then
            '-- creamos nuevo numero de factura y factura electronica
            'vnNumero = funNuevoMovInventario(Me.lkConcepto.EditValue, Me.lkRazon.EditValue)            
            dsAgregar.Tables("Tabla").Rows.Add()
        End If
        '--
        With dsAgregar.Tables("Tabla").Rows(0)
            '-- Fecha del Servidor
            varToday = funFechaServer()
            '-- Tomamos el nRecno
            Dim vnRecno = funNull2Val(.Item("nRecno"))
            '-- Tipo de Accion para Guardar: 1:Add, 2:Update
            intTipoRegistro = IIf(funNull2Val(.Item("nRecno")) = 0, 1, 2)
            '--
            If intTipoRegistro = 1 Then
                '-- Insertando
                funAddCampo("nConsecutivo", 0, 0)
                funAddCampo("nEmpresa", intEmpresa, 0)
                funAddCampo("nRazon", Me.lkRazon.EditValue, 0)
                funAddCampo("TipoDoc_Id", vnTipoDoc_Id, 0)
                funAddCampo("Suc_Id", vnSuc_Id, 0)
                funAddCampo("Caja_Id", vnCaja_Id, 0)
                funAddCampo("Factura_Id", vnNumero, 0)
                funAddCampo("Fecha_Factura", funFechaSql(Me.dtpFecha.Value.Date), "")
                funAddCampo("Suc_Id_FE", vnSuc_Id, "")
                funAddCampo("Razon_Id", vcRazon_Social, "")
            Else
                funAddCampo("dtmFechaDoc", funFechaSql(Me.dtpFecha.Value.Date), .Item("dtmFechaDoc").ToString)
                funAddCampo("strUserUpdate", strUser, .Item("strUserUpdate").ToString)
                funAddCampo("dtmUpdate", funFechaSql(varToday), .Item("dtmUpdate").ToString)
            End If
            '-- Filtro para Llave 
            strLlave = "nEmpresa = " & intEmpresa & " " &
                        "And nRazon = " & Me.lkRazon.EditValue & " " &
                        "And TipoDoc_Id = " & vnTipoDoc_Id & " " &
                        "And Suc_Id = " & vnSuc_Id & " " &
                        "And Caja_Id = " & vnCaja_Id & " " &
                        "And Factura_Id = " & vnNumero
            '--
            funParametrosGrabacionTransaccion("GB_Control_FE", strLlave, intTipoRegistro, vnRecno)
            '--
        End With
        Return True
    End Function

    Function funGrabarDetalle()
        '-- Tomado del proyecto PROINCO
        Dim dsDetalle As New DataSet
        '--
        For i = 0 To Me.gvDetalle.RowCount - 1
            varToday = funFechaServer() '-- Fechas, horas, minutos y segundos
            '--
            funAddCampo("nEmpresa", intEmpresa, intEmpresa)
            funAddCampo("nRazon", Me.lkRazon.EditValue, 0)
            funAddCampo("nConcepto", Me.lkConcepto.EditValue, 0)
            funAddCampo("nNumero", vnNumero, vnNumero)
            funAddCampo("nCode", Me.gvDetalle.GetDataRow(i)("nCode"), 0)
            funAddCampo("strClave", Me.gvDetalle.GetDataRow(i)("strClave").ToString, "")
            funAddCampo("nTipoMovto", vnTipoMovimiento, 0) '-- 1:Entrada, 2:Salida
            funAddCampo("strData", Me.gvDetalle.GetDataRow(i)("strData").ToString, "")
            funAddCampo("nCantidad", Me.gvDetalle.GetDataRow(i)("nCantidad"), 0)
            funAddCampo("nPUnitario", Me.gvDetalle.GetDataRow(i)("nPUnitario"), 0)
            funAddCampo("nSubTotal", Me.gvDetalle.GetDataRow(i)("nSubTotal"), 0)
            funAddCampo("nMontoDescuento", Me.gvDetalle.GetDataRow(i)("nMontoDescuento"), 0)
            funAddCampo("nMontoIva", Me.gvDetalle.GetDataRow(i)("nMontoIva"), 0)
            funAddCampo("nTotalSinIva", Me.gvDetalle.GetDataRow(i)("nTotalSinIva"), 0)
            funAddCampo("nGranTotal", Me.gvDetalle.GetDataRow(i)("nGranTotal"), 0)
            funAddCampo("nPerDescuento", Me.gvDetalle.GetDataRow(i)("nPerDescuento"), 0)
            funAddCampo("nPerIva", Me.gvDetalle.GetDataRow(i)("nPerIva"), 0)
            '-- 
            funAddCampo("strUserAdd", strUser, "")
            funAddCampo("strUserUpdate", strUser, "")
            funAddCampo("dtmUpdate", funFechaSql(varToday), "")
            '--
            '--
            Dim nTipoD As Integer
            Dim nRecno As Integer
            '--
            If funNull2Val(("nRecno")) = 0 Then
                nTipoD = 1
            Else
                nTipoD = 2
                nRecno = funNull2Val(("nRecno"))
            End If
            '-- 
            strLlave = " nEmpresa = " & intEmpresa & " " &
                        "And nConcepto = " & CDbl(Me.lkConcepto.EditValue) & " " &
                        "And nRazon = " & Me.lkRazon.EditValue & " " &
                        "And nNumero = " & vnNumero & " " &
                        "And nCode = " & Me.gvDetalle.GetDataRow(i)("nCode")
            '--
            funParametrosGrabacionTransaccion("Inv_Movto_Inventario_Detalle", strLlave, nTipoD, nRecno, , 0)
            '--
        Next
        Return True
    End Function

    Function funSaveMasterInventario()
        '-- Tomado del proyecto PHOENIX
        For i = 0 To Me.gvDetalle.RowCount - 1
            varToday = funFechaServer() '-- Fechas, horas, minutos y segundos
            '-- Seleccionamos el Recno del Registro de la tabla Master_Inventario
            Dim nTipoD, nRecno, vnRecnoMI As Integer
            '--
            strSQL = "Select nRecno FROM Inv_Master_Inventario " &
                        "WHERE nEmpresa  = " & intEmpresa & " " &
                        "And nConcepto = " & CDbl(Me.lkConcepto.EditValue) & " " &
                        "And nNumero = " & vnNumero & " " &
                        "And nCode = " & funNull2Val(Me.gvDetalle.GetDataRow(i)("nCode"))
            '--
            vnRecnoMI = funGetValorTransaccion(strSQL)
            nRecno = vnRecnoMI
            '--
            funAddCampo("nEmpresa", intEmpresa, 0)
            funAddCampo("nRazon", Me.lkRazon.EditValue, 0)
            funAddCampo("nConcepto", Me.lkConcepto.EditValue, 0)
            funAddCampo("nNumero", vnNumero, 0)
            funAddCampo("nCode", Me.gvDetalle.GetDataRow(i)("nCode"), 0)
            funAddCampo("nTipoMovto", vnTipoMovimiento, 0)
            funAddCampo("dtmFechaDoc", funFechaSql(Me.dtpFecha.Value.Date), "")
            '--
            funAddCampo("nCantidad", Me.gvDetalle.GetDataRow(i)("nCantidad"), 0)
            funAddCampo("nPUnitario", Me.gvDetalle.GetDataRow(i)("nPUnitario"), 0)
            funAddCampo("nSubTotal", Me.gvDetalle.GetDataRow(i)("nSubTotal"), 0)
            funAddCampo("nMontoDescuento", Me.gvDetalle.GetDataRow(i)("nMontoDescuento"), 0)
            funAddCampo("nMontoIva", Me.gvDetalle.GetDataRow(i)("nMontoIva"), 0)
            funAddCampo("nTotalSinIva", Me.gvDetalle.GetDataRow(i)("nTotalSinIva"), 0)
            funAddCampo("nGranTotal", Me.gvDetalle.GetDataRow(i)("nGranTotal"), 0)
            funAddCampo("nPerDescuento", Me.gvDetalle.GetDataRow(i)("nPerDescuento"), 0)
            funAddCampo("nPerIva", Me.gvDetalle.GetDataRow(i)("nPerIva"), 0)
            '-- 2012-01-12
            'funAddCampo("strOrden", Trim(Me.txtReferencia.Text), "")
            'funAddCampo("strFactura", Trim(Me.txtFactura.Text), "")
            'funAddCampo("dtmOrden", funFechaSql(Me.dtpOrden.Value.Date), "")
            'funAddCampo("dtmFactura", funFechaSql(Me.dtpFactura.Value.Date), "")
            '-- 2012-19-01: Cuando es una compra que ponga al proveedor
            funAddCampo("nOrigenDestino", Me.lkCliente.EditValue, 0)
            funAddCampo("strOrigenDestino", Me.lkCliente.Text, "")
            'funAddCampo("strReferencia", Trim(Me.txtReferencia.Text), "")
            '-- Grabamos los datos del usuario
            funAddCampo("strUserAdd", strUser, "")
            funAddCampo("strUserUpdate", strUser, "")
            funAddCampo("dtmUpdate", funFechaSql(varToday), "")
            '--        
            If nRecno = 0 Then
                nTipoD = 1
            Else
                nTipoD = 2
                nRecno = funNull2Val(("nRecno"))
            End If
            '-- 
            strLlave = " nEmpresa = " & intEmpresa & " " &
                        "And nConcepto = " & CDbl(Me.lkConcepto.EditValue) & " " &
                        "And nRazon = " & Me.lkRazon.EditValue & " " &
                        "And nNumero = " & vnNumero & " " &
                        "And nCode = " & Me.gvDetalle.GetDataRow(i)("nCode")
            '--
            funParametrosGrabacionTransaccion("Inv_Master_Inventario", strLlave, nTipoD, nRecno, , 0)
        Next
        Return True
    End Function

    Function funSaveSaldoPorBodega()
        '-- Tomado del proyecto PHOENIX, recorremos el Grid y Actualizamos por cada producto
        For i = 0 To Me.gvDetalle.RowCount - 1
            '-- Movimiento de Entrada
            If vnTipoMovimiento = 1 Then
                '-- 1:Entrada
                strSQL = "UPDATE Inv_ProductoBodega " &
                            "Set nEntrada = (Select ISNULL(SUM(b.nCantidad),0) " &
                            " FROM Inv_Movto_Inventario_Detalle As b " &
                            " WHERE b.nCode = " & funNull2Val(Me.gvDetalle.GetDataRow(i)("nCode")) &
                            " And b.nEmpresa = " & intEmpresa &
                            " And b.nTipoMovto = 1) " &
                            " WHERE nCode = " & funNull2Val(Me.gvDetalle.GetDataRow(i)("nCode")) &
                            " And nEmpresa = " & intEmpresa
                '--
                funRunSQLTransaccion(strSQL)
                '-- 2012-01-29: Actualizamos el precio por empresa, podriamos guardar el precio anterior antes de guardar
                strSQL = "UPDATE Inv_ProductoBodega " &
                            " Set nPrecio = " & funNull2Val(Me.gvDetalle.GetDataRow(i)("nGranTotal")) / funNull2Val(Me.gvDetalle.GetDataRow(i)("nCantidad")) &
                            ", strUserUpdate = '" & strUser & "'" &
                            ", dtmUpdate = '" & Format(CDate(funFechaServer()), "s") & "'" &
                            " WHERE nCode = " & funNull2Val(Me.gvDetalle.GetDataRow(i)("nCode")) &
                            " AND nEmpresa = " & intEmpresa
                '--
                funRunSQLTransaccion(strSQL)
                '--
            ElseIf vnTipoMovimiento = 2 Then
                '-- 29062017: Movimiento de salida
                strSQL = "UPDATE Inv_ProductoBodega " &
                            "SET nSalida = (SELECT ISNULL(SUM(b.nCantidad),0) " &
                            "FROM Inv_Movto_Inventario_Detalle AS b " &
                            " WHERE b.nCode = " & funNull2Val(Me.gvDetalle.GetDataRow(i)("nCode")) &
                            " AND b.nEmpresa = " & intEmpresa &
                            " AND b.nTipoMovto = 2) " &
                            " WHERE nCode = " & funNull2Val(Me.gvDetalle.GetDataRow(i)("nCode")) &
                            " AND nEmpresa = " & intEmpresa
                '--
                funRunSQLTransaccion(strSQL)
                '--
            End If
            '--
        Next
        Return True
    End Function


    Private Sub gvDetalle_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles gvDetalle.KeyDown
        '-- Borrar una linea, solo cuando esta agregando
        If (e.KeyCode = Keys.Delete) And nTipo = 1 Then
            If Me.gvDetalle.FocusedRowHandle >= 0 Then
                r = Me.gvDetalle.FocusedRowHandle
                If Me.gvDetalle.IsRowSelected(r) Then
                    If (MessageBox.Show("¿Desea eliminar la Fila ?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes) Then
                        Me.gvDetalle.DeleteRow(r)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        'Me.txtRecibido.Focus()
    End Sub

    Private Sub bbProveedor_Click(sender As System.Object, e As System.EventArgs)
        Dim f As New frmProveedor_Data
        f.barText.Caption = "Agregando Registro ..."
        f.nTipo = 1
        f.ShowDialog()
    End Sub

End Class