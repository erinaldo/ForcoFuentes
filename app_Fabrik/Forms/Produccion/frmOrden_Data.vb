Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmOrden_Data
    Dim varToday As Date
    Dim ds As New DataSet
    Dim bolInicio As Boolean
    Dim i As Integer
    Dim nTipoMovGrid As Integer
    Dim r As Integer
    Dim intTipoRegistro As Integer
    Public vnRecno, nTipo, vnNumero, vnReceta As Integer

    Private Sub frmOrden_Data_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
        '--
        Select Case e.KeyCode
            Case Keys.F1
                'subAdd()
            Case Keys.F2
                'subEdit()
            Case Keys.F3
                'subKardex()
        End Select
    End Sub
    Private Sub funInivar()
        Me.cbCantidad.Value = 0
    End Sub

    Private Sub frmOrden_Data_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        bolInicio = True
        funInivar()
        If nTipo = 1 Then
            funCargaCombos()
            Me.lkReceta.EditValue = vnTipoAjuste
            Me.lblNumero.Text = funNuevoOrden(intEmpresa)
            vnNumero = funNuevoOrden(intEmpresa)
        Else
            funCargaCombos()
            funCargaData()
            Me.lblNumero.Text = vnNumero
            Me.lkReceta.EditValue = vnReceta
            'funUpdateGrid()
            Me.lkReceta.Enabled = False
            Me.txtNotas.Enabled = False
            Me.bbSave.Enabled = False
            Me.bbAdd.Enabled = False
            Me.dtpFecha.Enabled = False
            Me.cbCantidad.Enabled = False
        End If
        bolInicio = False
    End Sub

    Private Sub funCargaData()
        '-- GB-2012-01-12: Filtramos el registro de la cabezera
        strSQL = "SELECT * FROM Orden " &
                    "WHERE nOrden = " & Me.vnNumero & " " &
                    "AND nReceta = " & Me.vnReceta & " " &
                    "AND nEmpresa = " & intEmpresa & " " &
                    "ORDER BY nOrden"
        '-- Cargamos el DS
        ds = funFillDataSet(strSQL)
        '-- Verificamos si existen registros
        If ds.Tables("Tabla").Rows.Count >= 1 Then
            '-- Cargamos datos
            Me.dtpFecha.Value = ds.Tables("Tabla").Rows(0)("dtmFecha").ToString
            Me.cbCantidad.Value = funNull2Val(ds.Tables("Tabla").Rows(0)("nCantidad"))
            Me.lblCostoTotal.Text = ds.Tables("Tabla").Rows(0)("nCostoTotal").ToString
            Me.lblCostoUnitario.Text = ds.Tables("Tabla").Rows(0)("nCostoPorPaleta").ToString
            Me.lblPaletas.Text = ds.Tables("Tabla").Rows(0)("nCantidad").ToString
            Me.txtNotas.Text = ds.Tables("Tabla").Rows(0)("strNotas").ToString
            '--
        Else
            MsgBox("No Existen Registros ... !!!", MsgBoxStyle.Critical, "Información")
        End If
        '--
    End Sub

    Private Function funDesactivar()
        Me.bbSave.Enabled = False
        Me.bbAdd.Enabled = False
        Me.txtNotas.Enabled = False
        Me.gcDetalle.Enabled = False
        Return True
    End Function

    Private Sub funCargaCombos()
        '-- Combo Conceptos no reservados
        strSQL = "SELECT nNumero AS nCodigo, strData AS strDescripcion FROM Pro_Receta " &
                    "WHERE nEmpresa = " & intEmpresa
        '--
        funCargarlue(Me.lkReceta, strSQL)
        '--
    End Sub

    Private Sub bbAdd_Click(sender As Object, e As EventArgs) Handles bbAdd.Click
        funUpdateGrid()
        funCalculoTotalProducto()
    End Sub

    Private Sub funUpdateGrid()
        '-- Cargar datos de la receta
        ds = clsOrden.funGetListaReceta(Me.lkReceta.EditValue, Me.lblNumero.Text, Me.cbCantidad.Value, intEmpresa)
        '-- 
        Me.gcDetalle.DataSource = ds.Tables(0)
        '--
        GridViewStyle(Me.gvDetalle)
        funOcultarTodasLasColumnas(Me.gvDetalle)
        indice = 0
        '--
        funSetColumna(gvDetalle, "ARTICULO_INTERNO", "Codigo", funIndice(), 100, 1)
        funSetColumna(gvDetalle, "ARTICULO_NOMBRE", "Artículo", funIndice(), 150, 1)
        funSetColumna(gvDetalle, "PALETAS_A_FABRICAR", "Paletas Producir", funIndice(), 100, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
        funSetColumna(gvDetalle, "CANTIDAD_INSUMO_X_PALETA", "Insumo x Paleta", funIndice(), 100, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
        funSetColumna(gvDetalle, "CANTIDAD_INSUMO_TOTAL", "Insumo Total", funIndice(), 100, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
        funSetColumna(gvDetalle, "PCOSTO_UNIDAD", "Costo x Paleta", funIndice(), 100, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
        funSetColumna(gvDetalle, "COSTO_INSUMO_TOTAL", "Costo Total", funIndice(), 100, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
        funSetColumna(gvDetalle, "EXISTENCIA", "Existencia", funIndice(), 100, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
        '--
    End Sub

    Private Sub funCalculoTotalProducto()
        '-- Calculamos el SubTotal del Grid
        If Me.gvDetalle.RowCount = 0 Then
            Me.lblCostoTotal.Text = 0
            Exit Sub
        End If
        Dim vnSumCostoTotal As Double
        For i = 0 To Me.gvDetalle.RowCount - 1
            vnSumCostoTotal += funNull2Val(Me.gvDetalle.GetDataRow(i)("COSTO_INSUMO_TOTAL"))
        Next
        '--
        Me.lblCostoTotal.Text = vnSumCostoTotal.ToString("n2")
        Me.lblPaletas.Text = Me.cbCantidad.Value
        Dim vnCostoPromedio As Double
        vnCostoPromedio = vnSumCostoTotal / Me.cbCantidad.Value
        Me.lblCostoUnitario.Text = vnCostoPromedio.ToString("n2")
        '--
    End Sub

    Private Sub bbClose_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbClose.ItemClick
        Me.Close()
    End Sub
    Dim intempresa2 As Integer
    Dim intConcepto2 As Integer
    Dim vnTipoMovimiento2 As Integer

    Dim intempresa3 As Integer
    Dim intConcepto3 As Integer
    Dim vnTipoMovimiento3 As Integer
    Private Sub bbSave_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbSave.ItemClick
        If Validar() = True Then
            If MessageBox.Show("¿ Desea Grabar los datos ahora ...?", "ATENCION !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = MsgBoxResult.Yes Then
                Guardar()
                '-- Movimiento de salida de insumos de la empresa 2
                intempresa2 = 2
                intConcepto2 = 14
                vnTipoMovimiento2 = 2
                Guardar2()
                '-- Insertando el producto terminado en la empresa 1
                intempresa3 = 1
                intConcepto3 = 15
                vnTipoMovimiento3 = 1
                Guardar3()
            End If
        End If
    End Sub

    Private Function Validar() As Boolean
        If Me.lkReceta.EditValue = 0 Then
            Me.lkReceta.Focus()
            Me.lkReceta.SelectAll()
            MsgBox("Falta Concepto !!!", MsgBoxStyle.Critical, "Atención !!!")
            Return False
        ElseIf Me.gvDetalle.RowCount = 0 Then
            MsgBox("Falta detalle de Productos   !!!", MsgBoxStyle.Critical, "Atención !!!")
            Me.gcDetalle.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub Guardar3()
        '--
        AbrirConexionGlobal()
        Try
            '-- GB-2017-07-28: Insertamos el producto terminado
            If nTipo = 1 Then
                vnNumero = funNuevoMovInventarioPorEmpresa(intConcepto3, intempresa3)
            End If
            '-- Datos de la transacción
            strSQL = "SELECT * FROM Inv_Movto_Inventario " &
                       "WHERE nNumero = " & Me.vnNumero & " " &
                       "AND nConcepto = " & intConcepto3 & " " &
                       "AND nEmpresa = " & intempresa3 & " " &
                       "ORDER BY nNumero"
            '--
            Dim dsAgregar As DataSet = funFillDataSet(strSQL)
            If dsAgregar.Tables("Tabla").Rows.Count = 0 Then
                'vnNumero = funNuevoMovInventario(Me.lkConcepto.EditValue)
                vnNumero = funNuevoMovInventarioPorEmpresa(intConcepto3, intempresa3)
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
                    funAddCampo("nEmpresa", intempresa3, 0)
                    funAddCampo("nConcepto", intConcepto3, 0)
                    funAddCampo("nNumero", vnNumero, vnNumero)
                    funAddCampo("nTipoMovto", vnTipoMovimiento3, 0)
                    funAddCampo("dtmFechaDoc", funFechaSql(Me.dtpFecha.Value.Date), "")
                    funAddCampo("strReferencia", Me.lblNumero.Text, "")
                    funAddCampo("strNota", "OP No. :" + Me.lblNumero.Text, "")
                    '-- Datos del registro
                    funAddCampo("strUserAdd", strUser, "")
                    funAddCampo("strUserUpdate", strUser, "")
                    funAddCampo("dtmUpdate", Format(varToday, "s"), "")
                    '-- 2012-19-01
                    funAddCampo("nOrigenDestino", 15, 0)
                    funAddCampo("strOrigenDestino", "ENTRADA P. TERMINADO", "")
                Else
                    funAddCampo("dtmFechaDoc", funFechaSql(Me.dtpFecha.Value.Date), .Item("dtmFechaDoc").ToString)
                    'funAddCampo("strReferencia", Trim(Me.txtReferencia.Text), .Item("strReferencia").ToString)
                    'funAddCampo("strNota", Trim(Me.txtNotas.Text), .Item("strNota").ToString)
                    funAddCampo("strUserUpdate", strUser, .Item("strUserUpdate").ToString)
                    funAddCampo("dtmUpdate", Format(varToday, "s"), .Item("dtmUpdate").ToString)
                End If
                '-- Filtro para Llave 
                strLlave = " nEmpresa = " & intempresa3 & " " &
                            "AND nConcepto = " & intConcepto3 & " " &
                            "AND nNumero = " & vnNumero
                '--
                funParametrosGrabacionTransaccion("Inv_Movto_Inventario", strLlave, intTipoRegistro, vnRecno)
                '-- Grabamos el Detalle del Movimiento
                funGrabarDetalle3()
                '-- Grabamos el Mestro del Inventario
                funSaveMasterInventario3()
                '-- Grabamos Existencia
                funSaveSaldoPorBodega3()
                '-- Probando si podemos guardar aqui los otros movimientos

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

    Function funGrabarDetalle3()
        '-- Tomado del proyecto PROINCO
        Dim dsDetalle As New DataSet
        '--
        varToday = funFechaServer() '-- Fechas, horas, minutos y segundos
        '--
        funAddCampo("nEmpresa", intempresa3, intempresa3)
        funAddCampo("nConcepto", intConcepto3, 0)
        funAddCampo("nNumero", vnNumero, vnNumero)
        funAddCampo("nCode", Me.lblCodigo.Text, 0)
        funAddCampo("strClave", Me.lblClave.Text, "")
        funAddCampo("nTipoMovto", vnTipoMovimiento3, 0) '-- 1:Entrada, 2:Salida
        funAddCampo("strData", Me.lblData.Text, "")
        funAddCampo("nCantidad", Me.cbCantidad.Value, 0)
        funAddCampo("nPUnitario", CDbl(Me.lblCostoUnitario.Text), 0)
        funAddCampo("nSubTotal", CDbl(Me.lblCostoTotal.Text), 0)
        '-- Grabamos el total
        Dim vnGranTotal As Double
        vnGranTotal = CDbl(Me.lblCostoTotal.Text)
        funAddCampo("nGranTotal", vnGranTotal, 0)
        '-- 
        funAddCampo("strUserAdd", strUser, "")
        funAddCampo("strUserUpdate", strUser, "")
        funAddCampo("dtmUpdate", Format(varToday, "s"), "")
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
        strLlave = " nEmpresa = " & intempresa3 & " " &
                    "AND nConcepto = " & intConcepto3 & " " &
                    "AND nNumero = " & vnNumero & " " &
                    "AND nCode = " & CDbl(Me.lblCodigo.Text)
        '--
        funParametrosGrabacionTransaccion("Inv_Movto_Inventario_Detalle", strLlave, nTipoD, nRecno, , 0)
        '--
        Return True
    End Function

    Function funSaveMasterInventario3()
        '-- Para producto terminado
        varToday = funFechaServer() '-- Fechas, horas, minutos y segundos
        '-- Seleccionamos el Recno del Registro de la tabla Master_Inventario
        Dim nTipoD, nRecno, vnRecnoMI As Integer
        '--
        strSQL = "SELECT nRecno FROM Inv_Master_Inventario " &
                    "WHERE nEmpresa  = " & intempresa3 & " " &
                    "AND nConcepto = " & intConcepto3 & " " &
                    "AND nNumero = " & vnNumero & " " &
                    "AND nCode = " & CDbl(Me.lblCodigo.Text)
        '--
        vnRecnoMI = funGetValorTransaccion(strSQL)
        nRecno = vnRecnoMI
        '--
        funAddCampo("nEmpresa", intempresa3, 0)
        funAddCampo("nConcepto", intConcepto3, 0)
        funAddCampo("nNumero", vnNumero, 0)
        funAddCampo("nCode", Me.lblCodigo.Text, 0)
        funAddCampo("nTipoMovto", vnTipoMovimiento3, 0)
        funAddCampo("dtmFechaDoc", funFechaSql(Me.dtpFecha.Value.Date), "")
        funAddCampo("nCantidad", Me.cbCantidad.Value, 0)
        funAddCampo("nPUnitario", CDbl(Me.lblCostoUnitario.Text), 0)
        funAddCampo("nSubTotal", CDbl(Me.lblCostoTotal.Text), 0)
        '-- Grabamos el total
        Dim vnGranTotal As Double
        vnGranTotal = CDbl(Me.lblCostoTotal.Text)
        funAddCampo("nGranTotal", vnGranTotal, 0)
        '-- 2012-19-01
        funAddCampo("nOrigenDestino", intConcepto3, 0)
        funAddCampo("strOrigenDestino", "ENTRADA P. TERMINADO", "")
        funAddCampo("strReferencia", "OP No. :" + Me.lblNumero.Text, "")
        '-- Grabamos los datos del usuario
        funAddCampo("strUserAdd", strUser, "")
        funAddCampo("strUserUpdate", strUser, "")
        funAddCampo("dtmUpdate", Format(varToday, "s"), "")
        '--        
        If nRecno = 0 Then
            nTipoD = 1
        Else
            nTipoD = 2
            nRecno = funNull2Val(("nRecno"))
        End If
        '-- 
        strLlave = " nEmpresa = " & intempresa2 & " " &
                    "AND nConcepto = " & intConcepto2 & " " &
                    "AND nNumero = " & vnNumero & " " &
                    "AND nCode = " & CDbl(Me.lblCodigo.Text)
        '--
        funParametrosGrabacionTransaccion("Inv_Master_Inventario", strLlave, nTipoD, nRecno, , 0)

        Return True
    End Function

    Function funSaveSaldoPorBodega3()
        '-- Actualizamos el saldo del producto terminado
        If vnTipoMovimiento3 = 1 Then
            '-- 1:Entrada, actualizamos las cantidades
            strSQL = "UPDATE Inv_ProductoBodega " &
                            "SET nEntrada = (SELECT ISNULL(SUM(b.nCantidad),0) " &
                            " FROM Inv_Movto_Inventario_Detalle AS b " &
                            " WHERE b.nCode = " & CDbl(Me.lblCodigo.Text) &
                            " AND b.nEmpresa = " & intempresa3 &
                            " AND b.nTipoMovto = 1) " &
                            " WHERE nCode = " & CDbl(Me.lblCodigo.Text) &
                            " AND nEmpresa = " & intempresa3
            '--
            funRunSQLTransaccion(strSQL)
            '-- 2012-06-19: Se omite actualizacion de precio
            '-- 2012-01-29: Actualizamos el precio por empresa
            'strSQL = "UPDATE Inv_ProductoBodega " & _
            '            " SET nPrecio = " & funNull2Val(Me.gvDetalle.GetDataRow(i)("nGranTotal")) / funNull2Val(Me.gvDetalle.GetDataRow(i)("nCantidad")) & _
            '            ", strUserUpdate = '" & strUser & "'" & _
            '            ", dtmUpdate = '" & Format(CDate(funFechaServer()), "s") & "'" & _
            '            " WHERE nCode = " & funNull2Val(Me.gvDetalle.GetDataRow(i)("nCode")) & _
            '            " AND nEmpresa = " & intEmpresa
            ''--
            'funRunSQLTransaccion(strSQL)
            '--
        ElseIf vnTipoMovimiento3 = 2 Then
            '-- 2:Salida, actualizamos la cantidades
            strSQL = "UPDATE Inv_ProductoBodega " &
                            "SET nSalida = (SELECT ISNULL(SUM(b.nCantidad),0) " &
                            "FROM Inv_Movto_Inventario_Detalle AS b " &
                            " WHERE b.nCode = " & CDbl(Me.lblCodigo.Text) &
                            " AND b.nEmpresa = " & intempresa3 &
                            " AND b.nTipoMovto = 2) " &
                            " WHERE nCode = " & CDbl(Me.lblCodigo.Text) &
                            " AND nEmpresa = " & intempresa3
            '--
            funRunSQLTransaccion(strSQL)
                '--
            End If
        '--
        Return True
    End Function

    Private Sub Guardar2()
        '--
        AbrirConexionGlobal()
        Try
            '-- GB-2017-07-22: Esto debe generar salida de la empresa 2
            If nTipo = 1 Then
                vnNumero = funNuevoMovInventarioPorEmpresa(intConcepto2, intempresa2)
            End If
            '-- Datos de la transacción
            strSQL = "SELECT * FROM Inv_Movto_Inventario " &
                       "WHERE nNumero = " & Me.vnNumero & " " &
                       "AND nConcepto = " & intConcepto2 & " " &
                       "AND nEmpresa = " & intempresa2 & " " &
                       "ORDER BY nNumero"
            '--
            Dim dsAgregar As DataSet = funFillDataSet(strSQL)
            If dsAgregar.Tables("Tabla").Rows.Count = 0 Then
                'vnNumero = funNuevoMovInventario(Me.lkConcepto.EditValue)
                vnNumero = funNuevoMovInventarioPorEmpresa(intConcepto2, intempresa2)
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
                    funAddCampo("nEmpresa", intempresa2, 0)
                    funAddCampo("nConcepto", intConcepto2, 0)
                    funAddCampo("nNumero", vnNumero, vnNumero)
                    funAddCampo("nTipoMovto", vnTipoMovimiento2, 0)
                    funAddCampo("dtmFechaDoc", funFechaSql(Me.dtpFecha.Value.Date), "")
                    funAddCampo("strReferencia", vnNumero, "")
                    funAddCampo("strNota", "OP No. :" + Me.lblNumero.Text, "")
                    '-- Datos del registro
                    funAddCampo("strUserAdd", strUser, "")
                    funAddCampo("strUserUpdate", strUser, "")
                    funAddCampo("dtmUpdate", Format(varToday, "s"), "")
                    '-- 2012-19-01
                    funAddCampo("nOrigenDestino", 14, 0)
                    funAddCampo("strOrigenDestino", "INSUMOS SALIDA", "")
                Else
                    funAddCampo("dtmFechaDoc", funFechaSql(Me.dtpFecha.Value.Date), .Item("dtmFechaDoc").ToString)
                    'funAddCampo("strReferencia", Trim(Me.txtReferencia.Text), .Item("strReferencia").ToString)
                    'funAddCampo("strNota", Trim(Me.txtNotas.Text), .Item("strNota").ToString)
                    funAddCampo("strUserUpdate", strUser, .Item("strUserUpdate").ToString)
                    funAddCampo("dtmUpdate", Format(varToday, "s"), .Item("dtmUpdate").ToString)
                End If
                '-- Filtro para Llave 
                strLlave = " nEmpresa = " & intempresa2 & " " &
                            "AND nConcepto = " & intConcepto2 & " " &
                            "AND nNumero = " & vnNumero
                '--
                funParametrosGrabacionTransaccion("Inv_Movto_Inventario", strLlave, intTipoRegistro, vnRecno)
                '-- Grabamos el Detalle del Movimiento
                funGrabarDetalle2()
                '-- Grabamos el Mestro del Inventario
                funSaveMasterInventario2()
                '-- Grabamos Existencia
                funSaveSaldoPorBodega2()
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

    Function funGrabarDetalle2()
        '-- Tomado del proyecto PROINCO
        Dim dsDetalle As New DataSet
        '--
        For i = 0 To Me.gvDetalle.RowCount - 1
            varToday = funFechaServer() '-- Fechas, horas, minutos y segundos
            '--
            funAddCampo("nEmpresa", intempresa2, intempresa2)
            funAddCampo("nConcepto", intConcepto2, 0)
            funAddCampo("nNumero", vnNumero, vnNumero)
            funAddCampo("nCode", Me.gvDetalle.GetDataRow(i)("ARTICULO_ID"), 0)
            funAddCampo("strClave", Me.gvDetalle.GetDataRow(i)("ARTICULO_INTERNO").ToString, "")
            funAddCampo("nTipoMovto", vnTipoMovimiento2, 0) '-- 1:Entrada, 2:Salida
            funAddCampo("strData", Me.gvDetalle.GetDataRow(i)("ARTICULO_NOMBRE").ToString, "")
            funAddCampo("nCantidad", Me.gvDetalle.GetDataRow(i)("CANTIDAD_INSUMO_TOTAL"), 0)
            funAddCampo("nPUnitario", Me.gvDetalle.GetDataRow(i)("PCOSTO_UNIDAD"), 0)
            funAddCampo("nSubTotal", Me.gvDetalle.GetDataRow(i)("COSTO_INSUMO_TOTAL"), 0)
            '-- Grabamos el total
            Dim vnGranTotal As Double
            vnGranTotal = CDbl(Me.gvDetalle.GetDataRow(i)("CANTIDAD_INSUMO_TOTAL")) * CDbl(Me.gvDetalle.GetDataRow(i)("PCOSTO_UNIDAD"))
            funAddCampo("nGranTotal", vnGranTotal, 0)
            '-- 
            funAddCampo("strUserAdd", strUser, "")
            funAddCampo("strUserUpdate", strUser, "")
            funAddCampo("dtmUpdate", Format(varToday, "s"), "")
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
            strLlave = " nEmpresa = " & intempresa2 & " " &
                        "AND nConcepto = " & intConcepto2 & " " &
                        "AND nNumero = " & vnNumero & " " &
                        "AND nCode = " & Me.gvDetalle.GetDataRow(i)("ARTICULO_ID")
            '--
            funParametrosGrabacionTransaccion("Inv_Movto_Inventario_Detalle", strLlave, nTipoD, nRecno, , 0)
            '--
        Next
        Return True

    End Function

    Function funSaveMasterInventario2()
        '-- Tomado del proyecto PHOENIX
        For i = 0 To Me.gvDetalle.RowCount - 1
            varToday = funFechaServer() '-- Fechas, horas, minutos y segundos
            '-- Seleccionamos el Recno del Registro de la tabla Master_Inventario
            Dim nTipoD, nRecno, vnRecnoMI As Integer
            '--
            strSQL = "SELECT nRecno FROM Inv_Master_Inventario " &
                        "WHERE nEmpresa  = " & intempresa2 & " " &
                        "AND nConcepto = " & intConcepto2 & " " &
                        "AND nNumero = " & vnNumero & " " &
                        "AND nCode = " & funNull2Val(Me.gvDetalle.GetDataRow(i)("ARTICULO_ID"))
            '--
            vnRecnoMI = funGetValorTransaccion(strSQL)
            nRecno = vnRecnoMI
            '--
            funAddCampo("nEmpresa", intempresa2, 0)
            funAddCampo("nConcepto", intConcepto2, 0)
            funAddCampo("nNumero", vnNumero, 0)
            funAddCampo("nCode", Me.gvDetalle.GetDataRow(i)("ARTICULO_ID"), 0)
            funAddCampo("nTipoMovto", vnTipoMovimiento2, 0)
            funAddCampo("dtmFechaDoc", funFechaSql(Me.dtpFecha.Value.Date), "")
            '--
            funAddCampo("nCantidad", Me.gvDetalle.GetDataRow(i)("CANTIDAD_INSUMO_TOTAL"), 0)
            funAddCampo("nPUnitario", Me.gvDetalle.GetDataRow(i)("PCOSTO_UNIDAD"), 0)
            funAddCampo("nSubTotal", Me.gvDetalle.GetDataRow(i)("COSTO_INSUMO_TOTAL"), 0)
            '-- Grabamos el total
            Dim vnGranTotal As Double
            vnGranTotal = CDbl(Me.gvDetalle.GetDataRow(i)("CANTIDAD_INSUMO_TOTAL")) * CDbl(Me.gvDetalle.GetDataRow(i)("PCOSTO_UNIDAD"))
            funAddCampo("nGranTotal", vnGranTotal, 0)
            '--
            'funAddCampo("nCantidad", Me.gvDetalle.GetDataRow(i)("nCantidad"), 0)
            'funAddCampo("nPUnitario", Me.gvDetalle.GetDataRow(i)("nPUnitario"), 0)
            'funAddCampo("nSubTotal", Me.gvDetalle.GetDataRow(i)("nSubTotal"), 0)
            '-- Grabamos el total
            'Dim vnGranTotal As Double
            'vnGranTotal = CDbl(Me.gvDetalle.GetDataRow(i)("nCantidad")) * CDbl(Me.gvDetalle.GetDataRow(i)("nPUnitario"))
            'funAddCampo("nGranTotal", vnGranTotal, 0)
            '-- 2012-19-01
            funAddCampo("nOrigenDestino", intConcepto2, 0)
            funAddCampo("strOrigenDestino", "INSUMOS SALIDA", "")
            funAddCampo("strReferencia", "OP No. :" + Me.lblNumero.Text, "")
            '-- Grabamos los datos del usuario
            funAddCampo("strUserAdd", strUser, "")
            funAddCampo("strUserUpdate", strUser, "")
            funAddCampo("dtmUpdate", Format(varToday, "s"), "")
            '--        
            If nRecno = 0 Then
                nTipoD = 1
            Else
                nTipoD = 2
                nRecno = funNull2Val(("nRecno"))
            End If
            '-- 
            strLlave = " nEmpresa = " & intempresa2 & " " &
                        "AND nConcepto = " & intConcepto2 & " " &
                        "AND nNumero = " & vnNumero & " " &
                        "AND nCode = " & Me.gvDetalle.GetDataRow(i)("ARTICULO_ID")
            '--
            funParametrosGrabacionTransaccion("Inv_Master_Inventario", strLlave, nTipoD, nRecno, , 0)
        Next
        Return True
    End Function

    Function funSaveSaldoPorBodega2()
        '-- Tomado del proyecto PHOENIX
        '-- Recorremos el Grid y Actualizamos por cada producto
        For i = 0 To Me.gvDetalle.RowCount - 1
            '-- Segun el timpo de movimiento procedemos a actualizar
            If vnTipoMovimiento2 = 1 Then
                '-- 1:Entrada, actualizamos las cantidades
                strSQL = "UPDATE Inv_ProductoBodega " &
                            "SET nEntrada = (SELECT ISNULL(SUM(b.nCantidad),0) " &
                            " FROM Inv_Movto_Inventario_Detalle AS b " &
                            " WHERE b.nCode = " & funNull2Val(Me.gvDetalle.GetDataRow(i)("ARTICULO_ID")) &
                            " AND b.nEmpresa = " & intempresa2 &
                            " AND b.nTipoMovto = 1) " &
                            " WHERE nCode = " & funNull2Val(Me.gvDetalle.GetDataRow(i)("ARTICULO_ID")) &
                            " AND nEmpresa = " & intempresa2
                '--
                funRunSQLTransaccion(strSQL)
                '-- 2012-06-19: Se omite actualizacion de precio
                '-- 2012-01-29: Actualizamos el precio por empresa
                'strSQL = "UPDATE Inv_ProductoBodega " & _
                '            " SET nPrecio = " & funNull2Val(Me.gvDetalle.GetDataRow(i)("nGranTotal")) / funNull2Val(Me.gvDetalle.GetDataRow(i)("nCantidad")) & _
                '            ", strUserUpdate = '" & strUser & "'" & _
                '            ", dtmUpdate = '" & Format(CDate(funFechaServer()), "s") & "'" & _
                '            " WHERE nCode = " & funNull2Val(Me.gvDetalle.GetDataRow(i)("nCode")) & _
                '            " AND nEmpresa = " & intEmpresa
                ''--
                'funRunSQLTransaccion(strSQL)
                '--
            ElseIf vnTipoMovimiento2 = 2 Then
                '-- 2:Salida, actualizamos la cantidades
                strSQL = "UPDATE Inv_ProductoBodega " &
                            "SET nSalida = (SELECT ISNULL(SUM(b.nCantidad),0) " &
                            "FROM Inv_Movto_Inventario_Detalle AS b " &
                            " WHERE b.nCode = " & funNull2Val(Me.gvDetalle.GetDataRow(i)("ARTICULO_ID")) &
                            " AND b.nEmpresa = " & intempresa2 &
                            " AND b.nTipoMovto = 2) " &
                            " WHERE nCode = " & funNull2Val(Me.gvDetalle.GetDataRow(i)("ARTICULO_ID")) &
                            " AND nEmpresa = " & intempresa2
                '--
                funRunSQLTransaccion(strSQL)
                '--
            End If
            '--
        Next
        Return True
    End Function

    Private Sub Guardar()
        '--
        AbrirConexionGlobal()
        Try
            '-- GB-2012-01-09: Multiples conexiones, renumera codigo
            If nTipo = 1 Then
                vnNumero = funNuevoOrden(intEmpresa)
            End If
            '-- Datos de la transacción
            strSQL = "SELECT * FROM Orden " &
                       "WHERE nOrden = " & Me.vnNumero & " " &
                       "AND nReceta = " & Me.lkReceta.EditValue & " " &
                       "AND nEmpresa = " & intEmpresa & " " &
                       "ORDER BY nOrden"
            '--
            Dim dsAgregar As DataSet = funFillDataSet(strSQL)
            If dsAgregar.Tables("Tabla").Rows.Count = 0 Then
                vnNumero = funNuevoOrden(intEmpresa)
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
                    funAddCampo("nReceta", Me.lkReceta.EditValue, 0)
                    funAddCampo("nOrden", vnNumero, vnNumero)
                    funAddCampo("dtmFecha", funFechaSql(Me.dtpFecha.Value.Date), "")
                    funAddCampo("strNotas", Trim(Me.txtNotas.Text), "")
                    '--
                    funAddCampo("nCantidad", CDbl(Me.lblPaletas.Text), 0)
                    funAddCampo("nCostoTotal", CDbl(Me.lblCostoTotal.Text), 0)
                    funAddCampo("nCostoPorPaleta", CDbl(Me.lblCostoUnitario.Text), 0)
                    '--                     
                    funAddCampo("strUserAdd", strUser, "")
                    funAddCampo("strUserUpdate", strUser, "")
                    funAddCampo("dtmUpdate", Format(varToday, "s"), "")
                    '--
                Else
                    funAddCampo("dtmFechaDoc", funFechaSql(Me.dtpFecha.Value.Date), .Item("dtmFechaDoc").ToString)
                    'funAddCampo("strReferencia", Trim(Me.txtReferencia.Text), .Item("strReferencia").ToString)
                    funAddCampo("strNota", Trim(Me.txtNotas.Text), .Item("strNota").ToString)
                    funAddCampo("strUserUpdate", strUser, .Item("strUserUpdate").ToString)
                    funAddCampo("dtmUpdate", Format(varToday, "s"), .Item("dtmUpdate").ToString)
                End If
                '-- Filtro para Llave 
                strLlave = " nEmpresa = " & intEmpresa & " " &
                            "AND nReceta = " & Me.lkReceta.EditValue & " " &
                            "AND nOrden = " & vnNumero
                '--
                funParametrosGrabacionTransaccion("Orden", strLlave, intTipoRegistro, vnRecno)
                '-- Grabamos el Detalle del Movimiento
                funGrabarDetalle()
                '-- Grabamos el Mestro del Inventario
                'funSaveMasterInventario()
                '-- Grabamos Existencia
                'funSaveSaldoPorBodega()
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

    Function funGrabarDetalle()
        '-- Tomado del proyecto PROINCO
        Dim dsDetalle As New DataSet
        '--
        For i = 0 To Me.gvDetalle.RowCount - 1
            varToday = funFechaServer() '-- Fechas, horas, minutos y segundos
            '--
            funAddCampo("nEmpresa", intEmpresa, intEmpresa)
            funAddCampo("nReceta", Me.lkReceta.EditValue, 0)
            funAddCampo("nOrden", vnNumero, vnNumero)
            funAddCampo("nArticulo", Me.gvDetalle.GetDataRow(i)("ARTICULO_ID"), 0)
            funAddCampo("ARTICULO_INTERNO", Me.gvDetalle.GetDataRow(i)("ARTICULO_INTERNO"), 0)
            funAddCampo("ARTICULO_NOMBRE", Me.gvDetalle.GetDataRow(i)("ARTICULO_NOMBRE").ToString, "")
            funAddCampo("CANTIDAD_INSUMO_X_RECETA", Me.gvDetalle.GetDataRow(i)("CANTIDAD_INSUMO_X_RECETA"), 0)
            funAddCampo("PALETAS_A_FABRICAR", Me.gvDetalle.GetDataRow(i)("PALETAS_A_FABRICAR"), 0)
            funAddCampo("CANTIDAD_INSUMO_X_PALETA", Me.gvDetalle.GetDataRow(i)("CANTIDAD_INSUMO_X_PALETA"), 0)
            funAddCampo("CANTIDAD_INSUMO_TOTAL", Me.gvDetalle.GetDataRow(i)("CANTIDAD_INSUMO_TOTAL"), 0)
            funAddCampo("PCOSTO_UNIDAD", Me.gvDetalle.GetDataRow(i)("PCOSTO_UNIDAD"), 0)
            funAddCampo("COSTO_INSUMO_TOTAL", Me.gvDetalle.GetDataRow(i)("COSTO_INSUMO_TOTAL"), 0)
            '-- 
            funAddCampo("strUserAdd", strUser, "")
            funAddCampo("strUserUpdate", strUser, "")
            funAddCampo("dtmUpdate", Format(varToday, "s"), "")
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
                        "AND nReceta = " & CDbl(Me.lkReceta.EditValue) & " " &
                        "AND nOrden = " & vnNumero & " " &
                        "AND nArticulo = " & Me.gvDetalle.GetDataRow(i)("ARTICULO_ID")
            '--
            funParametrosGrabacionTransaccion("Orden_Detalle", strLlave, nTipoD, nRecno, , 0)
            '--
        Next
        Return True

    End Function

    Private Sub lkReceta_EditValueChanged(sender As Object, e As EventArgs) Handles lkReceta.EditValueChanged
        If Me.bolInicio = False Then
            funDataExpress()
        End If
    End Sub
    Private Sub funDataExpress()
        '--
        strSQL = "SELECT strClave " &
                    " FROM Pro_Receta " &
                    " WHERE nNumero = " & CDbl(Me.lkReceta.EditValue)
        '--
        Me.lblClave.Text = funGetValor(strSQL)
        '-- 
        strSQL = "SELECT strData " &
                   " FROM Inv_Producto " &
                   " WHERE strClave = '" & Me.lblClave.Text & "'"
        '--
        Me.lblData.Text = funGetValor(strSQL)
        '--
        strSQL = "SELECT nCode " &
                  " FROM Inv_Producto " &
                  " WHERE strClave = '" & Me.lblClave.Text & "'"
        '--
        Me.lblCodigo.Text = funGetValor(strSQL)
        '--
    End Sub
End Class