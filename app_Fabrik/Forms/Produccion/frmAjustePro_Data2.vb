Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmPrecio
    Dim varToday As Date
    Dim ds As New DataSet
    Dim bolInicio As Boolean
    Dim i As Integer
    Dim nTipoMovGrid As Integer
    Dim r As Integer
    Dim intTipoRegistro As Integer
    Public vnRecno, nTipo, vnNumero, vnConcepto, vnTipoMovimiento As Integer
    Dim intEmpresa2 As Integer
    Dim intConcepto2 As Integer
    Dim vnTipoMovimiento2 As Integer

    Private Sub frmInvAjuste_Data2_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
                subKardex()
        End Select
    End Sub

    Private Sub frmInvAjuste_Data2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        '-- Titulo
        Me.Text = strTitulo
        bolInicio = True
        If nTipo = 1 Then
            funCargaCombos()
            funUpdateGrid()
            Me.lkConcepto.EditValue = vnTipoAjuste
            '-- GB-2012-06-18: Obtenemos el nuevo numero de movimiento de inventario
            Me.lblNumero.Text = funNuevoMovInventario(Me.lkConcepto.EditValue)
            '-- GB-2012-06-18: Asignamos el valor a la variable del nuevo numero de movimiento de inventario
            vnNumero = funNuevoMovInventario(Me.lkConcepto.EditValue)
            'GB-2012-04-26: Buscar tipo de movimiento
            funGetTipoMovimiento()
        Else
            funCargaCombos()
            funCargaData()
            Me.lkConcepto.EditValue = vnConcepto
            funUpdateGrid()
            Me.lkConcepto.Enabled = False
            Me.txtNotas.Enabled = False
            Me.txtReferencia.Enabled = False
            Me.bbSave.Enabled = False
            Me.bbAdd.Enabled = False
            Me.bbEdit.Enabled = False
            Me.dtpFecha.Enabled = False
        End If
        bolInicio = False
    End Sub

    Private Function funDesactivar()
        Me.bbSave.Enabled = False
        Me.bbAdd.Enabled = False
        Me.bbEdit.Enabled = False
        Me.txtNotas.Enabled = False
        Me.gcDetalle.Enabled = False
        Return True
    End Function

    Private Sub funCargaCombos()
        '-- Combo Conceptos no reservados
        strSQL = "SELECT nCode AS nCodigo, strData AS strDescripcion " & _
                    " FROM Inv_Concepto " & _
                    " WHERE bitReservado = 0"
        '--
        funCargarlue(Me.lkConcepto, strSQL)
        '--
    End Sub

    Private Sub funUpdateGrid()
        '--
        strSQL = "SELECT * " & _
                    "FROM Inv_Movto_Inventario_Detalle " & _
                    "WHERE nNumero = " & Me.vnNumero & " " & _
                    "AND nConcepto = " & CDbl(Me.lkConcepto.EditValue) & " " & _
                    "AND nEmpresa = " & intEmpresa & " " & _
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
        funSetColumna(gvDetalle, "nCode", "No.", funIndice(), 70, 1)
        funSetColumna(gvDetalle, "strClave", "Cod.", funIndice(), 90, 1)
        funSetColumna(gvDetalle, "strData", "Descripción", funIndice(), 250, 1)
        funSetColumna(gvDetalle, "nCantidad", "Cant1", funIndice(), 100, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
        funSetColumna(gvDetalle, "nPUnitario", "P.Unitario", funIndice(), 100, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
        funSetColumna(gvDetalle, "nSubTotal", "Sub-Total", funIndice(), 100, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
        '--
    End Sub

    Private Sub funCargaData()
        '-- GB-2012-01-12: Filtramos el registro de la cabezera
        strSQL = "SELECT * FROM Inv_Movto_Inventario " & _
                    "WHERE nNumero = " & Me.vnNumero & " " & _
                    "AND nConcepto = " & Me.vnConcepto & " " & _
                    "AND nEmpresa = " & intEmpresa & " " & _
                    "ORDER BY nNumero"
        '-- Cargamos el DS
        ds = funFillDataSet(strSQL)
        '-- Verificamos si existen registros
        If ds.Tables("Tabla").Rows.Count >= 1 Then
            '-- Cargamos datos
            Me.dtpFecha.Value = ds.Tables("Tabla").Rows(0)("dtmFechaDoc").ToString
            Me.vnConcepto = funNull2Val(ds.Tables("Tabla").Rows(0)("nConcepto"))
            Me.lblNumero.Text = funNull2Val(ds.Tables("Tabla").Rows(0)("nNumero"))
            Me.txtReferencia.Text = ds.Tables("Tabla").Rows(0)("strReferencia").ToString
            Me.txtNotas.Text = ds.Tables("Tabla").Rows(0)("strNota").ToString
        Else
            MsgBox("No Existen Registros ... !!!", MsgBoxStyle.Critical, "Información")
        End If
        '--
    End Sub

    Private Sub funCargaGrid()
        '-- 22/07/2009: Agregando al grid detalle
        With Me.gvDetalle
            For i = 0 To Me.gvDetalle.RowCount - 1
                If vnCode = Me.gvDetalle.GetRowCellValue(i, "nCode") And nTipoMovGrid = 1 Then
                    MsgBox("Este producto ya fue registrado !!!", MsgBoxStyle.Information, "Atención")
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
            .UpdateCurrentRow()
        End With
        If Me.gvDetalle.RowCount > 0 Then
            Dim nRecords As Integer
            nRecords = Me.gvDetalle.RowCount
            '-- Me.barRecord.Caption = "Registros : " & nRecords
        End If

    End Sub

    Private Sub lkConcepto_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles lkConcepto.EditValueChanged
        If Me.bolInicio = False Then
            '-- Obtenemos el nuevo numero de movimiento de inventario
            Me.lblNumero.Text = funNuevoMovInventario(Me.lkConcepto.EditValue)
            vnNumero = funNuevoMovInventario(Me.lkConcepto.EditValue)
            '-- Obtener el tipo de movimiento
            funGetTipoMovimiento()
        End If
    End Sub

    Private Function funGetTipoMovimiento()
        '-- Tomado del proyecto PHOENIX
        '-- Obtenemos el tipo de movimiento del concepto
        strSQL = "SELECT nTipoConcepto " & _
                    " FROM Inv_Concepto " & _
                    " WHERE nCode = " & CDbl(Me.lkConcepto.EditValue)
        '-- 1:Entrada, 2:Salida
        vnTipoMovimiento = funGetValor(strSQL)
        Return True
    End Function

    Private Sub bbSave_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbSave.ItemClick
        If Validar() = True Then
            If MessageBox.Show("¿ Desea Grabar los datos ahora ...?", "ATENCION !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = MsgBoxResult.Yes Then
                Guardar()
                intEmpresa2 = 2
                intConcepto2 = 13
                vnTipoMovimiento2 = 1
                Guardar2()
            End If
        End If
    End Sub

    Private Sub Guardar2()
        '--
        AbrirConexionGlobal()
        Try
            '-- GB-2017-07-22: Esto debe generar una entrada en la empresa 2
            If nTipo = 1 Then
                vnNumero = funNuevoMovInventarioPorEmpresa(intConcepto2, intEmpresa2)
            End If
            '-- Datos de la transacción
            strSQL = "SELECT * FROM Inv_Movto_Inventario " &
                       "WHERE nNumero = " & Me.vnNumero & " " &
                       "AND nConcepto = " & intConcepto2 & " " &
                       "AND nEmpresa = " & intEmpresa2 & " " &
                       "ORDER BY nNumero"
            '--
            Dim dsAgregar As DataSet = funFillDataSet(strSQL)
            If dsAgregar.Tables("Tabla").Rows.Count = 0 Then
                'vnNumero = funNuevoMovInventario(Me.lkConcepto.EditValue)
                vnNumero = funNuevoMovInventarioPorEmpresa(intConcepto2, intEmpresa2)
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
                    funAddCampo("nEmpresa", intEmpresa2, 0)
                    funAddCampo("nConcepto", intConcepto2, 0)
                    funAddCampo("nNumero", vnNumero, vnNumero)
                    funAddCampo("nTipoMovto", vnTipoMovimiento2, 0)
                    funAddCampo("dtmFechaDoc", funFechaSql(Me.dtpFecha.Value.Date), "")
                    funAddCampo("strReferencia", Trim(Me.txtReferencia.Text), "")
                    funAddCampo("strNota", Trim(Me.txtNotas.Text), "")
                    '-- Datos del registro
                    funAddCampo("strUserAdd", strUser, "")
                    funAddCampo("strUserUpdate", strUser, "")
                    funAddCampo("dtmUpdate", Format(varToday, "s"), "")
                    '-- 2012-19-01
                    funAddCampo("nOrigenDestino", intConcepto2, 0)
                    funAddCampo("strOrigenDestino", "INSUMOS ENTRADA", "")
                Else
                    funAddCampo("dtmFechaDoc", funFechaSql(Me.dtpFecha.Value.Date), .Item("dtmFechaDoc").ToString)
                    funAddCampo("strReferencia", Trim(Me.txtReferencia.Text), .Item("strReferencia").ToString)
                    funAddCampo("strNota", Trim(Me.txtNotas.Text), .Item("strNota").ToString)
                    funAddCampo("strUserUpdate", strUser, .Item("strUserUpdate").ToString)
                    funAddCampo("dtmUpdate", Format(varToday, "s"), .Item("dtmUpdate").ToString)
                End If
                '-- Filtro para Llave 
                strLlave = " nEmpresa = " & intEmpresa2 & " " &
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
            funAddCampo("nEmpresa", intEmpresa2, intEmpresa2)
            funAddCampo("nConcepto", intConcepto2, 0)
            funAddCampo("nNumero", vnNumero, vnNumero)
            funAddCampo("nCode", Me.gvDetalle.GetDataRow(i)("nCode"), 0)
            funAddCampo("strClave", Me.gvDetalle.GetDataRow(i)("strClave").ToString, "")
            funAddCampo("nTipoMovto", vnTipoMovimiento2, 0) '-- 1:Entrada, 2:Salida
            funAddCampo("strData", Me.gvDetalle.GetDataRow(i)("strData").ToString, "")
            funAddCampo("nCantidad", Me.gvDetalle.GetDataRow(i)("nCantidad"), 0)
            funAddCampo("nPUnitario", Me.gvDetalle.GetDataRow(i)("nPUnitario"), 0)
            funAddCampo("nSubTotal", Me.gvDetalle.GetDataRow(i)("nSubTotal"), 0)
            '-- Grabamos el total
            Dim vnGranTotal As Double
            vnGranTotal = CDbl(Me.gvDetalle.GetDataRow(i)("nCantidad")) * CDbl(Me.gvDetalle.GetDataRow(i)("nPUnitario"))
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
            strLlave = " nEmpresa = " & intEmpresa2 & " " &
                        "AND nConcepto = " & intConcepto2 & " " &
                        "AND nNumero = " & vnNumero & " " &
                        "AND nCode = " & Me.gvDetalle.GetDataRow(i)("nCode")
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
                        "WHERE nEmpresa  = " & intEmpresa2 & " " &
                        "AND nConcepto = " & intConcepto2 & " " &
                        "AND nNumero = " & vnNumero & " " &
                        "AND nCode = " & funNull2Val(Me.gvDetalle.GetDataRow(i)("nCode"))
            '--
            vnRecnoMI = funGetValorTransaccion(strSQL)
            nRecno = vnRecnoMI
            '--
            funAddCampo("nEmpresa", intEmpresa2, 0)
            funAddCampo("nConcepto", intConcepto2, 0)
            funAddCampo("nNumero", vnNumero, 0)
            funAddCampo("nCode", Me.gvDetalle.GetDataRow(i)("nCode"), 0)
            funAddCampo("nTipoMovto", vnTipoMovimiento2, 0)
            funAddCampo("dtmFechaDoc", funFechaSql(Me.dtpFecha.Value.Date), "")
            funAddCampo("nCantidad", Me.gvDetalle.GetDataRow(i)("nCantidad"), 0)
            funAddCampo("nPUnitario", Me.gvDetalle.GetDataRow(i)("nPUnitario"), 0)
            funAddCampo("nSubTotal", Me.gvDetalle.GetDataRow(i)("nSubTotal"), 0)
            '-- Grabamos el total
            Dim vnGranTotal As Double
            vnGranTotal = CDbl(Me.gvDetalle.GetDataRow(i)("nCantidad")) * CDbl(Me.gvDetalle.GetDataRow(i)("nPUnitario"))
            funAddCampo("nGranTotal", vnGranTotal, 0)
            '-- 2012-19-01
            funAddCampo("nOrigenDestino", intConcepto2, 0)
            funAddCampo("strOrigenDestino", "INSUMOS ENTRADA", "")
            funAddCampo("strReferencia", Trim(Me.txtReferencia.Text), "")
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
            strLlave = " nEmpresa = " & intEmpresa2 & " " &
                        "AND nConcepto = " & intConcepto2 & " " &
                        "AND nNumero = " & vnNumero & " " &
                        "AND nCode = " & Me.gvDetalle.GetDataRow(i)("nCode")
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
                            " WHERE b.nCode = " & funNull2Val(Me.gvDetalle.GetDataRow(i)("nCode")) &
                            " AND b.nEmpresa = " & intEmpresa2 &
                            " AND b.nTipoMovto = 1) " &
                            " WHERE nCode = " & funNull2Val(Me.gvDetalle.GetDataRow(i)("nCode")) &
                            " AND nEmpresa = " & intEmpresa2
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
            ElseIf vnTipoMovimiento = 2 Then
                '-- 2:Salida, actualizamos la cantidades
                strSQL = "UPDATE Inv_ProductoBodega " &
                            "SET nSalida = (SELECT ISNULL(SUM(b.nCantidad),0) " &
                            "FROM Inv_Movto_Inventario_Detalle AS b " &
                            " WHERE b.nCode = " & funNull2Val(Me.gvDetalle.GetDataRow(i)("nCode")) &
                            " AND b.nEmpresa = " & intEmpresa2 &
                            " AND b.nTipoMovto = 2) " &
                            " WHERE nCode = " & funNull2Val(Me.gvDetalle.GetDataRow(i)("nCode")) &
                            " AND nEmpresa = " & intEmpresa2
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
                vnNumero = funNuevoMovInventario(Me.lkConcepto.EditValue)
            End If
            '-- Datos de la transacción
            strSQL = "SELECT * FROM Inv_Movto_Inventario " &
                       "WHERE nNumero = " & Me.vnNumero & " " &
                       "AND nConcepto = " & Me.lkConcepto.EditValue & " " &
                       "AND nEmpresa = " & intEmpresa & " " &
                       "ORDER BY nNumero"
            '--
            Dim dsAgregar As DataSet = funFillDataSet(strSQL)
            If dsAgregar.Tables("Tabla").Rows.Count = 0 Then
                vnNumero = funNuevoMovInventario(Me.lkConcepto.EditValue)
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
                    funAddCampo("nConcepto", Me.lkConcepto.EditValue, 0)
                    funAddCampo("nNumero", vnNumero, vnNumero)
                    funAddCampo("nTipoMovto", vnTipoMovimiento, 0)
                    funAddCampo("dtmFechaDoc", funFechaSql(Me.dtpFecha.Value.Date), "")
                    funAddCampo("strReferencia", Trim(Me.txtReferencia.Text), "")
                    funAddCampo("strNota", Trim(Me.txtNotas.Text), "")
                    '-- Datos del registro
                    funAddCampo("strUserAdd", strUser, "")
                    funAddCampo("strUserUpdate", strUser, "")
                    funAddCampo("dtmUpdate", Format(varToday, "s"), "")
                    '-- 2012-19-01
                    funAddCampo("nOrigenDestino", Me.lkConcepto.EditValue, 0)
                    funAddCampo("strOrigenDestino", Me.lkConcepto.Text, "")
                Else
                    funAddCampo("dtmFechaDoc", funFechaSql(Me.dtpFecha.Value.Date), .Item("dtmFechaDoc").ToString)
                    funAddCampo("strReferencia", Trim(Me.txtReferencia.Text), .Item("strReferencia").ToString)
                    funAddCampo("strNota", Trim(Me.txtNotas.Text), .Item("strNota").ToString)
                    funAddCampo("strUserUpdate", strUser, .Item("strUserUpdate").ToString)
                    funAddCampo("dtmUpdate", Format(varToday, "s"), .Item("dtmUpdate").ToString)
                End If
                '-- Filtro para Llave 
                strLlave = " nEmpresa = " & intEmpresa & " " &
                            "AND nConcepto = " & Me.lkConcepto.EditValue & " " &
                            "AND nNumero = " & vnNumero
                '--
                funParametrosGrabacionTransaccion("Inv_Movto_Inventario", strLlave, intTipoRegistro, vnRecno)
                '-- Grabamos el Detalle del Movimiento
                funGrabarDetalle()
                '-- Grabamos el Mestro del Inventario
                funSaveMasterInventario()
                '-- Grabamos Existencia
                funSaveSaldoPorBodega()
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
            funAddCampo("nConcepto", Me.lkConcepto.EditValue, 0)
            funAddCampo("nNumero", vnNumero, vnNumero)
            funAddCampo("nCode", Me.gvDetalle.GetDataRow(i)("nCode"), 0)
            funAddCampo("strClave", Me.gvDetalle.GetDataRow(i)("strClave").ToString, "")
            funAddCampo("nTipoMovto", vnTipoMovimiento, 0) '-- 1:Entrada, 2:Salida
            funAddCampo("strData", Me.gvDetalle.GetDataRow(i)("strData").ToString, "")
            funAddCampo("nCantidad", Me.gvDetalle.GetDataRow(i)("nCantidad"), 0)
            funAddCampo("nPUnitario", Me.gvDetalle.GetDataRow(i)("nPUnitario"), 0)
            funAddCampo("nSubTotal", Me.gvDetalle.GetDataRow(i)("nSubTotal"), 0)
            '-- Grabamos el total
            Dim vnGranTotal As Double
            vnGranTotal = CDbl(Me.gvDetalle.GetDataRow(i)("nCantidad")) * CDbl(Me.gvDetalle.GetDataRow(i)("nPUnitario"))
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
            strLlave = " nEmpresa = " & intEmpresa & " " &
                        "AND nConcepto = " & CDbl(Me.lkConcepto.EditValue) & " " &
                        "AND nNumero = " & vnNumero & " " &
                        "AND nCode = " & Me.gvDetalle.GetDataRow(i)("nCode")
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
            strSQL = "SELECT nRecno FROM Inv_Master_Inventario " &
                        "WHERE nEmpresa  = " & intEmpresa & " " &
                        "AND nConcepto = " & CDbl(Me.lkConcepto.EditValue) & " " &
                        "AND nNumero = " & vnNumero & " " &
                        "AND nCode = " & funNull2Val(Me.gvDetalle.GetDataRow(i)("nCode"))
            '--
            vnRecnoMI = funGetValorTransaccion(strSQL)
            nRecno = vnRecnoMI
            '--
            funAddCampo("nEmpresa", intEmpresa, 0)
            funAddCampo("nConcepto", Me.lkConcepto.EditValue, 0)
            funAddCampo("nNumero", vnNumero, 0)
            funAddCampo("nCode", Me.gvDetalle.GetDataRow(i)("nCode"), 0)
            funAddCampo("nTipoMovto", vnTipoMovimiento, 0)
            funAddCampo("dtmFechaDoc", funFechaSql(Me.dtpFecha.Value.Date), "")
            funAddCampo("nCantidad", Me.gvDetalle.GetDataRow(i)("nCantidad"), 0)
            funAddCampo("nPUnitario", Me.gvDetalle.GetDataRow(i)("nPUnitario"), 0)
            funAddCampo("nSubTotal", Me.gvDetalle.GetDataRow(i)("nSubTotal"), 0)
            '-- Grabamos el total
            Dim vnGranTotal As Double
            vnGranTotal = CDbl(Me.gvDetalle.GetDataRow(i)("nCantidad")) * CDbl(Me.gvDetalle.GetDataRow(i)("nPUnitario"))
            funAddCampo("nGranTotal", vnGranTotal, 0)
            '-- 2012-19-01
            funAddCampo("nOrigenDestino", Me.lkConcepto.EditValue, 0)
            funAddCampo("strOrigenDestino", Me.lkConcepto.Text, "")
            funAddCampo("strReferencia", Trim(Me.txtReferencia.Text), "")
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
            strLlave = " nEmpresa = " & intEmpresa & " " &
                        "AND nConcepto = " & CDbl(Me.lkConcepto.EditValue) & " " &
                        "AND nNumero = " & vnNumero & " " &
                        "AND nCode = " & Me.gvDetalle.GetDataRow(i)("nCode")
            '--
            funParametrosGrabacionTransaccion("Inv_Master_Inventario", strLlave, nTipoD, nRecno, , 0)
        Next
        Return True
    End Function

    Function funSaveSaldoPorBodega()
        '-- Tomado del proyecto PHOENIX
        '-- Recorremos el Grid y Actualizamos por cada producto
        For i = 0 To Me.gvDetalle.RowCount - 1
            '-- Segun el timpo de movimiento procedemos a actualizar
            If vnTipoMovimiento = 1 Then
                '-- 1:Entrada, actualizamos las cantidades
                strSQL = "UPDATE Inv_ProductoBodega " &
                            "SET nEntrada = (SELECT ISNULL(SUM(b.nCantidad),0) " &
                            " FROM Inv_Movto_Inventario_Detalle AS b " &
                            " WHERE b.nCode = " & funNull2Val(Me.gvDetalle.GetDataRow(i)("nCode")) &
                            " AND b.nEmpresa = " & intEmpresa &
                            " AND b.nTipoMovto = 1) " &
                            " WHERE nCode = " & funNull2Val(Me.gvDetalle.GetDataRow(i)("nCode")) &
                            " AND nEmpresa = " & intEmpresa
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
            ElseIf vnTipoMovimiento = 2 Then
                '-- 2:Salida, actualizamos la cantidades
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


    Private Function Validar() As Boolean
        If Me.lkConcepto.EditValue = 0 Then
            Me.lkConcepto.Focus()
            Me.lkConcepto.SelectAll()
            MsgBox("Falta Concepto !!!", MsgBoxStyle.Critical, "Atención !!!")
            Return False
        ElseIf Len(Trim(Me.txtReferencia.Text)) = 0 Then
            Me.txtReferencia.Focus()
            MsgBox("Falta No. de Referencia !!!", MsgBoxStyle.Critical, "Atención !!!")
            Return False
        ElseIf Me.gvDetalle.RowCount = 0 Then
            MsgBox("Falta detalle de Productos   !!!", MsgBoxStyle.Critical, "Atención !!!")
            Me.gcDetalle.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub bbAdd_Click(sender As System.Object, e As System.EventArgs) Handles bbAdd.Click
        subAdd()
    End Sub

    Private Sub subAdd()
        Dim f As New frmAjustePro_Seek2
        f.barText.Caption = "Agregando Producto"
        f.nTransaction = 1
        f.nTipo = nTipo '-- 1: Agregando documento, 2: Editando Documento
        f.ShowDialog()
        '--
        If bolFound = True Then
            nTipoMovGrid = 1
            funCargaGrid()
        End If
        '--
    End Sub

    Private Sub bbEdit_Click(sender As System.Object, e As System.EventArgs) Handles bbEdit.Click
        subEdit()
    End Sub

    Private Sub subEdit()
        With Me.gvDetalle
            If .RowCount > 0 Then
                Dim f As New frmAjustePro_Seek2
                f.barText.Caption = "Editanto Producto"
                vnCode = .GetFocusedRowCellValue(.Columns("nCode"))
                f.lblCode.Text = .GetFocusedRowCellValue(.Columns("nCode"))
                f.lblCodigo.Text = .GetFocusedRowCellValue(.Columns("strClave"))
                f.lblProducto.Text = .GetFocusedRowCellValue(.Columns("strData"))
                f.cbCantidad.Value = funNull2Val(.GetFocusedRowCellValue(.Columns("nCantidad")))
                f.cbPrecio.Value = funNull2Val(.GetFocusedRowCellValue(.Columns("nPUnitario")))
                f.nTransaction = 2
                f.nTipo = nTipo '-- 1: Agregando documento, 2: Editando Documento
                f.ShowDialog()
                If bolFound = True Then
                    nTipoMovGrid = 2
                    funCargaGrid()
                End If
            End If
        End With
    End Sub

    Private Sub bbClose_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbClose.ItemClick
        Me.Close()
    End Sub

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

    Private Sub bbKardex_Click(sender As System.Object, e As System.EventArgs) Handles bbKardex.Click
        subKardex()
    End Sub

    Private Sub subKardex()
        With Me.gvDetalle
            If .RowCount > 0 Then
                Dim f As New frmKardexOpen
                f.nCode = funNull2Val(.GetFocusedRowCellValue(.Columns("nCode")))
                f.ShowDialog()
            End If
        End With
    End Sub

    Private Sub gcDetalle_DoubleClick(sender As System.Object, e As System.EventArgs) Handles gcDetalle.DoubleClick
        '--
        subEdit()
        '--
    End Sub
End Class