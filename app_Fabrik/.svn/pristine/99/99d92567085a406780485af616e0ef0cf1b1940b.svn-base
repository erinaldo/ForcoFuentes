Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmReceta_Detalle
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
    Dim vnYear, vnPrograma, vnSubPrograma, vnActividad, vnDependencia As Integer
    Dim vnNewStatus As Integer = 1
    Dim vcProducto As String

    Private Sub frmReceta_Detalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        bolInicio = True
        funCargaCombos()
        '--
        If nTipo = 1 Then
            funUpdateGrid()
            '-- Obtenemos el nuevo numero de movimiento de inventario
            Me.lblNumero.Text = funNuevoReceta()
            vnNumero = funNuevoReceta()
            '-- Obtener el tipo de movimiento
        Else
            funCargaData()
            '-- Me.lkProveedor.EditValue = vnProveedor
            funUpdateGrid()
            'Me.txtData.Enabled = False
            Me.bbSave.Enabled = False
            Me.bbAdd.Enabled = False
            Me.bbEdit.Enabled = False
            '-- 
            'Me.txtData.Enabled = False
            Me.lkProducto.EditValue = vcProducto
            Me.lkProducto.Enabled = False
            '--
        End If
        bolInicio = False
    End Sub

    Private Sub funCargaCombos()
        '-- Combo Conceptos no reservados
        strSQL = "SELECT strClave AS nCodigo, strData AS strDescripcion " &
                    " FROM Inv_Producto " &
                    " WHERE nFamilia2 = 6"
        '--
        funCargarlue(Me.lkProducto, strSQL)
        '--
    End Sub

    Private Function funDesactivar()
        Me.bbSave.Enabled = False
        Me.bbAdd.Enabled = False
        Me.bbEdit.Enabled = False
        Me.gcDetalle.Enabled = False
        Return True
    End Function

    Private Sub funUpdateGrid()
        '--
        strSQL = "SELECT * FROM vw_GB_Receta_Detalle " &
                    "WHERE nNumero = " & Me.vnNumero & " " &
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
        funSetColumna(gvDetalle, "nArticulo", "Id.", funIndice(), 80, 1)
        funSetColumna(gvDetalle, "strClave", "Código", funIndice(), 100, 1)
        funSetColumna(gvDetalle, "strData", "Descripción", funIndice(), 300, 1)
        funSetColumna(gvDetalle, "nCantidad", "Cantidad", funIndice(), 100, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
        funSetColumna(gvDetalle, "nExistencia", "Existencia", funIndice(), 100, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
        funSetColumna(gvDetalle, "nCosto", "Costo", funIndice(), 100, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
        '--
    End Sub

    Private Sub funCargaData()
        '-- GB-2012-01-12: Filtramos el registro de la cabezera
        strSQL = "SELECT * FROM vw_GB_Receta_Open " &
                    "WHERE nNumero = " & Me.vnNumero & " " &
                    "AND nEmpresa = " & intEmpresa & " " &
                    "ORDER BY nNumero"
        '-- Cargamos el DS
        ds = funFillDataSet(strSQL)
        '-- Verificamos si existen registros
        If ds.Tables("Tabla").Rows.Count >= 1 Then
            '-- Cargamos datos
            Me.lblNumero.Text = funNull2Val(ds.Tables("Tabla").Rows(0)("nNumero"))
            'Me.txtData.Text = ds.Tables("Tabla").Rows(0)("strData").ToString
            vcProducto = ds.Tables("Tabla").Rows(0)("strClave").ToString
            '-- 
        Else
            MsgBox("No Existen Registros ... !!!", MsgBoxStyle.Critical, "Información")
        End If
        '--
    End Sub

    Private Sub bbSave_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbSave.ItemClick
        If Validar() = True Then
            If MessageBox.Show("¿ Desea Grabar los datos ahora ...?", "ATENCION !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = MsgBoxResult.Yes Then
                Guardar()
                '-- 19092017
                Guardar2()
            End If
        End If
    End Sub

    Private Function Validar() As Boolean
        '--
        If Me.lkProducto.EditValue = 0 Then
            Me.lkProducto.Focus()
            MsgBox("Falta Descripción !!!", MsgBoxStyle.Critical, "Atención !!!")
            Return False
        ElseIf Me.gvDetalle.RowCount = 0 Then
            MsgBox("Falta detalle de Productos   !!!", MsgBoxStyle.Critical, "Atención !!!")
            Me.gcDetalle.Focus()
            Return False
        End If
        '--
        Return True
    End Function

    Private Sub bClose_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bClose.ItemClick
        Me.Close()
    End Sub

    Private Sub frmReceta_Data_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub bbEdit_Click(sender As Object, e As EventArgs) Handles bbEdit.Click
        subEdit()
    End Sub

    Private Sub bbAdd_Click(sender As Object, e As EventArgs) Handles bbAdd.Click
        subAdd()
    End Sub

    Private Sub subAdd()
        Dim f As New frmBuscar
        f.barText.Caption = "Agregando Producto"
        f.nTransaction = 1
        f.nTipo = nTipo '-- 1:Agregando documento, 2:Editando documento
        f.ShowDialog()
        '--
        If bolFound = True Then
            nTipoMovGrid = 1
            funCargaGrid()
        End If
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
                Dim f As New frmBuscar
                f.barText.Caption = "Editanto Producto"
                '-- Esto lo hago porque la variable publica me guarda el ultimo valor del vnCode que guardo en el grid
                vnCode = .GetFocusedRowCellValue(.Columns("nArticulo"))
                f.lblCode.Text = .GetFocusedRowCellValue(.Columns("nArticulo"))
                f.lblClave.Text = .GetFocusedRowCellValue(.Columns("strClave"))
                f.lblData.Text = .GetFocusedRowCellValue(.Columns("strData"))
                f.cbCantidad.Value = funNull2Val(.GetFocusedRowCellValue(.Columns("nCantidad")))
                f.nTransaction = 2
                f.nTipo = nTipo '-- 1:Agregando documento, 2:Editando documento
                f.ShowDialog()
                If bolFound = True Then
                    nTipoMovGrid = 2
                    funCargaGrid()
                End If
            End If
        End With
    End Sub

    Private Sub funCargaGrid()
        '-- 22/07/2009: Agregando al grid detalle
        '-- Dim vnPercentDescuento, vnImporte, vnMontoDescuento, vnMontoSinIva, vnMontoIva As Double
        '-- MsgBox(vnCode)
        With Me.gvDetalle
            For i = 0 To Me.gvDetalle.RowCount - 1
                If vnCode = Me.gvDetalle.GetRowCellValue(i, "nArticulo") And nTipoMovGrid = 1 Then
                    MsgBox("Este producto ya esta en la Receta !!!", MsgBoxStyle.Information, "Atención")
                    Exit Sub
                End If
            Next
            If nTipoMovGrid = 1 Then
                .AddNewRow()
            End If
            .SetFocusedRowCellValue(.Columns("nArticulo"), vnCode)
            .SetFocusedRowCellValue(.Columns("strClave"), vcCode)
            .SetFocusedRowCellValue(.Columns("strData"), vcData)
            .SetFocusedRowCellValue(.Columns("nCantidad"), funNull2Val(vnCantidad))
            '--
            .UpdateCurrentRow()
        End With
        If Me.gvDetalle.RowCount > 0 Then
            Dim nRecords As Integer
            nRecords = Me.gvDetalle.RowCount
            'Me.barRecord.Caption = "Registros : " & nRecords
        End If
    End Sub

    Private Sub Guardar()
        '--
        AbrirConexionGlobal()
        Try
            '-- GB-2012-01-09: Multiples conexiones, renumera codigo
            If nTipo = 1 Then
                vnNumero = funNuevoReceta()
            End If
            '-- Datos de la transacción
            strSQL = "SELECT * FROM Pro_Receta " &
                       "WHERE nNumero = " & Me.vnNumero & " " &
                       "AND nEmpresa = " & intEmpresa & " " &
                       "ORDER BY nNumero"
            '--
            Dim dsAgregar As DataSet = funFillDataSet(strSQL)
            If dsAgregar.Tables("Tabla").Rows.Count = 0 Then
                vnNumero = funNuevoReceta()
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
                    funAddCampo("nNumero", vnNumero, vnNumero)
                    funAddCampo("strClave", lkProducto.EditValue, 0)
                    funAddCampo("strData", lkProducto.Text, "")
                    '-- Datos del registro
                    funAddCampo("strUserAdd", strUser, "")
                    funAddCampo("strUserUpdate", strUser, "")
                    funAddCampo("dtmUpdate", Format(varToday, "s"), "")
                    '--
                Else
                    funAddCampo("strData", lkProducto.Text, .Item("strData").ToString)
                    funAddCampo("strUserUpdate", strUser, .Item("strUserUpdate").ToString)
                    funAddCampo("dtmUpdate", Format(varToday, "s"), .Item("dtmUpdate").ToString)
                End If
                '-- Filtro para Llave 
                strLlave = " nEmpresa = " & intEmpresa & " " &
                            "AND nNumero = " & vnNumero
                '--
                funParametrosGrabacionTransaccion("Pro_Receta", strLlave, intTipoRegistro, vnRecno)
                '-- Grabamos el Detalle del Movimiento
                funGrabarDetalle()
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
            funAddCampo("nNumero", vnNumero, vnNumero)
            funAddCampo("nArticulo", Me.gvDetalle.GetDataRow(i)("nArticulo"), 0)
            funAddCampo("strClave", Me.gvDetalle.GetDataRow(i)("strClave").ToString, "")
            funAddCampo("strData", Me.gvDetalle.GetDataRow(i)("strData").ToString, "")
            funAddCampo("nCantidad", Me.gvDetalle.GetDataRow(i)("nCantidad"), 0)
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
                        "AND nNumero = " & vnNumero & " " &
                        "AND nArticulo = " & Me.gvDetalle.GetDataRow(i)("nArticulo")
            '--
            funParametrosGrabacionTransaccion("Pro_Receta_Detalle", strLlave, nTipoD, nRecno, , 0)
            '--
        Next
        Return True
    End Function

    Dim intEmpresa2 As Integer = 2
    Private Sub Guardar2()
        '--
        AbrirConexionGlobal()
        Try
            '-- GB-2012-01-09: Multiples conexiones, renumera codigo
            If nTipo = 1 Then
                vnNumero = funNuevoReceta()
            End If
            '-- Datos de la transacción
            strSQL = "SELECT * FROM Pro_Receta " &
                       "WHERE nNumero = " & Me.vnNumero & " " &
                       "AND nEmpresa = " & intEmpresa2 & " " &
                       "ORDER BY nNumero"
            '--
            Dim dsAgregar As DataSet = funFillDataSet(strSQL)
            If dsAgregar.Tables("Tabla").Rows.Count = 0 Then
                vnNumero = funNuevoReceta()
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
                    funAddCampo("nNumero", vnNumero, vnNumero)
                    funAddCampo("strClave", lkProducto.EditValue, 0)
                    funAddCampo("strData", Me.lkProducto.Text, "")
                    '-- Datos del registro
                    funAddCampo("strUserAdd", strUser, "")
                    funAddCampo("strUserUpdate", strUser, "")
                    funAddCampo("dtmUpdate", Format(varToday, "s"), "")
                    '--
                Else
                    funAddCampo("strData", Me.lkProducto.Text, .Item("strData").ToString)
                    funAddCampo("strUserUpdate", strUser, .Item("strUserUpdate").ToString)
                    funAddCampo("dtmUpdate", Format(varToday, "s"), .Item("dtmUpdate").ToString)
                End If
                '-- Filtro para Llave 
                strLlave = " nEmpresa = " & intEmpresa2 & " " &
                            "AND nNumero = " & vnNumero
                '--
                funParametrosGrabacionTransaccion("Pro_Receta", strLlave, intTipoRegistro, vnRecno)
                '-- Grabamos el Detalle del Movimiento
                funGrabarDetalle2()
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
            funAddCampo("nNumero", vnNumero, vnNumero)
            funAddCampo("nArticulo", Me.gvDetalle.GetDataRow(i)("nArticulo"), 0)
            funAddCampo("strClave", Me.gvDetalle.GetDataRow(i)("strClave").ToString, "")
            funAddCampo("strData", Me.gvDetalle.GetDataRow(i)("strData").ToString, "")
            funAddCampo("nCantidad", Me.gvDetalle.GetDataRow(i)("nCantidad"), 0)
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
                        "AND nNumero = " & vnNumero & " " &
                        "AND nArticulo = " & Me.gvDetalle.GetDataRow(i)("nArticulo")
            '--
            funParametrosGrabacionTransaccion("Pro_Receta_Detalle", strLlave, nTipoD, nRecno, , 0)
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

End Class