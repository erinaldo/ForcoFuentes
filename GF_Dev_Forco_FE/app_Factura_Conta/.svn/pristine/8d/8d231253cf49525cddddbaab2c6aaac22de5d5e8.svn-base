Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmProducto_Data
    Dim ds As New DataSet
    Public nTipo, vnRecno, vnCodigo As Integer
    Dim intTipoRegistro, vnSegmento, vnFamilia, vnClase, vnArticulo, vnStatus, vnGrupo, vnRenglon, vnPistaMov, vnSecuencia, vnMedida, vnFamiliaAux As Integer
    Dim varToday As Date
    Dim bolInicio As Boolean
    Dim vnVence As Integer
    Dim vnGrupoInterno As Integer '-- Para buscar el codigo real del grupo de productos en el Cat_GrupoRenglon

    Private Sub bbClose_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbClose.ItemClick
        Me.Close()
    End Sub


    Private Sub frmProducto_Data_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmProducto_Data_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        bolInicio = True
        varToday = funFechaServer()
        If nTipo = 1 Then
            funCargaCombos()
            funNuevoNumero()
            Me.lblCode.Text = vnCodigo
            Me.lkMedida.EditValue = 1
            Me.lkStatus.EditValue = 1
            Me.vnPistaMov = 0
            'Me.cbVenta1.Value = 0
            'Me.cbCosto.Value = 0
            'Me.dtpOrden.Value = Now
            Me.txtCodigo.Focus()
        Else
            'Me.lblClave.Text = vnCodigo
            funCargaCombos()
            funCargaData()
            funCargaDataBodega()
            'funCargaFamilia()
            'funCargaClase()
            'funCargaArticulo()
            'funCargaRenglon()
            funCargaProductoBodega()
            '-- funLockData()
            'Me.lkSegmento1.EditValue = vnSegmento
            'Me.lkFamilia2.EditValue = vnFamilia
            'Me.lkClase3.EditValue = vnClase
            'Me.lkArticulo4.EditValue = vnArticulo
            Me.lkStatus.EditValue = vnStatus
            Me.lkMedida.EditValue = vnMedida
            'Me.lkGrupo.EditValue = vnGrupoInterno
            'Me.lkRenglon.EditValue = vnRenglon
            Me.lkFamiliaAux.EditValue = vnFamiliaAux
            '-- Bloquear combos
            'funCombosLock()
            Me.txtCodigo.Enabled = False
        End If
        bolInicio = False
    End Sub

    Private Function funCargaProductoBodega()
        '-- 
        strSQL = "SELECT * " & _
                    " FROM v_Inv_Gv_ProductoBodega " & _
                    "WHERE nCode = " & Me.vnCodigo
        '-- Cargamos el DS
        ds = funFillDataSet(strSQL)
        '-- Verificamos si existen registros
        If ds.Tables("Tabla").Rows.Count >= 1 Then
            '--
            Me.gcBodega.DataSource = funFillDataSet(strSQL).Tables(0)
            '--
            GridViewStyle(Me.gvBodega)
            funOcultarTodasLasColumnas(Me.gvBodega)
            indice = 0
            '--
            funSetColumna(Me.gvBodega, "strEmpresa", "Sucursal", funIndice(), 400, 1)
            '-- Piezas
            funSetColumna(Me.gvBodega, "nEntrada", "Entrada", funIndice(), 80, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(Me.gvBodega, "nSalida", "Salida", funIndice(), 80, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(Me.gvBodega, "nSaldo", "Saldo", funIndice(), 80, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
            '--
            funSetColumna(Me.gvBodega, "strUserUpdate", "Usuario +", funIndice(), 100, 1)
            funSetColumna(Me.gvBodega, "dtmUpdate", "F. Ultima +", funIndice(), 100, 1)
        End If
        Return True
    End Function

    Private Sub funCargaCombos()
        '-- Combo Tipo Inventario
        'funCargarlue(Me.lkSegmento1, "SELECT nCode AS nCodigo, strEspanol AS strDescripcion FROM Cat_Segmento")
        '-- Combo Producto Status
        funCargarComboDX(Me.lkStatus, funGetTablaDeTablas(110), True)
        '-- Unidades de Medidad
        '-- funCargarComboDX(Me.lkMedida, funGetTablaDeTablas(114), False)
        funCargarlue(Me.lkMedida, "SELECT nCode AS nCodigo, strData AS strDescripcion FROM Cat_Medida")
        '-- Combo de Grupo
        'funCargarlue(Me.lkGrupo, "SELECT nCode AS nCodigo, strData AS strDescripcion FROM Cat_Grupo")
        '-- Carga Familia Auxiliar
        funCargarlue(Me.lkFamiliaAux, "SELECT nCode AS nCodigo, strData AS strDescripcion FROM Cat_Familia2")
    End Sub

    Private Function funNuevoNumero()
        '--
        strSQL = "SELECT ISNULL(MAX(nCode), 0) + 1 " & _
                    "FROM Inv_Producto"
        '--
        vnCodigo = funGetValor(strSQL)
        Return True
    End Function

    Private Function funCargaData()
        '-- Filtramos el registro
        strSQL = "SELECT * FROM Inv_Producto " & _
                    "WHERE nCode = " & Me.vnCodigo
        '-- Cargamos el DS
        ds = funFillDataSet(strSQL)
        '-- Verificamos si existen registros
        If ds.Tables("Tabla").Rows.Count >= 1 Then
            '-- Cargamos datos
            Me.lblCode.Text = funNull2Val(ds.Tables("Tabla").Rows(0)("nCode"))
            Me.txtCodigo.Text = ds.Tables("Tabla").Rows(0)("strClave").ToString
            Me.txtData.Text = ds.Tables("Tabla").Rows(0)("strData").ToString
            'Me.dtpFecha.Value = ds.Tables("Tabla").Rows(0)("dtmAlta").ToString
            vnSegmento = funNull2Val(ds.Tables("Tabla").Rows(0)("nG1Segmento"))
            vnFamilia = funNull2Val(ds.Tables("Tabla").Rows(0)("nG2Familia"))
            vnClase = funNull2Val(ds.Tables("Tabla").Rows(0)("nG3Clase"))
            vnArticulo = funNull2Val(ds.Tables("Tabla").Rows(0)("nG4Articulo"))
            vnStatus = funNull2Val(ds.Tables("Tabla").Rows(0)("nStatus"))
            vnMedida = funNull2Val(ds.Tables("Tabla").Rows(0)("nMedida"))
            '-- Precios
            'Me.cbVenta1.Value = funNull2Val(ds.Tables("Tabla").Rows(0)("mPrecio_Venta1"))
            'Me.cbVenta2.Value = funNull2Val(ds.Tables("Tabla").Rows(0)("mPrecio_Venta2"))
            'Me.cbVenta3.Value = funNull2Val(ds.Tables("Tabla").Rows(0)("mPrecio_Venta3"))
            'Me.cbVenta4.Value = funNull2Val(ds.Tables("Tabla").Rows(0)("mPrecio_Venta4"))
            'Me.cbCosto.Value = funNull2Val(ds.Tables("Tabla").Rows(0)("mPrecio_Costo"))
            '-- 2012-02-21: Obtener el GrupoId en la tabla de Cat_Grupo que el grupo que tiene el catalogo de productos
            vnGrupo = funNull2Val(ds.Tables("Tabla").Rows(0)("nGrupo"))
            '--
            strSQL = "SELECT nCode FROM Cat_Grupo " & _
                        " WHERE nGrupoID = " & vnGrupo
            '--
            vnGrupoInterno = funGetValor(strSQL)
            '--
            vnRenglon = funNull2Val(ds.Tables("Tabla").Rows(0)("nRenglon"))
            vnFamiliaAux = funNull2Val(ds.Tables("Tabla").Rows(0)("nFamilia2"))
            '-- Var. para pista de movimiento de inventario
            vnPistaMov = funNull2Val(ds.Tables("Tabla").Rows(0)("nPistaMov"))
            vnVence = funNull2Val(ds.Tables("Tabla").Rows(0)("nVence"))
            'If vnVence = 1 Then
            '    Me.ckCaducidad.CheckState = CheckState.Unchecked
            'Else
            '    ckCaducidad.CheckState = CheckState.Checked
            'End If
        Else
            MsgBox("No Existen Registros ... !!!", MsgBoxStyle.Critical, "Información")
        End If
        Return True
    End Function

    Private Function funCargaDataBodega()
        '-- Ultimos movimientos
        Try
            '--
            Dim dsHead As New DataSet
            Dim dr As DataRow
            Dim vnPrecioActual As Double
            '--
            dsHead = clsProducto.funGetProductoBodegaDS(intEmpresa, vnCodigo)
            '--
            If dsHead.Tables(0).Rows.Count >= 1 Then
                '-- Asignamos un datarow
                dr = dsHead.Tables(0).Rows(0)
                '-- Iniciamos enlaze
                vnPrecioActual = dr("nPrecio")
                'Me.lblUltimoPrecio.Text = vnPrecioActual.ToString("2")
                'Me.dtpLastUpdate.Value = dr("dtmUpdate").ToString
            End If
            '--
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return True
    End Function

    Private Sub bbSave_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbSave.ItemClick
        If Validar() = True Then
            If MessageBox.Show("¿ Desea Grabar los datos ...?", "Atención !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = MsgBoxResult.Yes Then
                funGuardar()
            End If
        End If
    End Sub

    Private Function Validar() As Boolean
        If Me.lkStatus.EditValue = 0 Then
            Me.lkStatus.Focus()
            Me.lkStatus.SelectAll()
            MsgBox("Falta Status !!!", MsgBoxStyle.Critical, "Atención !!!")
            Return False
        ElseIf Me.lkMedida.EditValue = 0 Then
            Me.lkMedida.Focus()
            Me.lkMedida.SelectAll()
            MsgBox("Falta Unidad de Medida !!!", MsgBoxStyle.Critical, "Atención !!!")
            Return False
        ElseIf Me.lkFamiliaAux.EditValue = 0 Then
            Me.lkFamiliaAux.Focus()
            Me.lkFamiliaAux.SelectAll()
            MsgBox("Falta Familia Auxiliar !!!", MsgBoxStyle.Critical, "Atención !!!")
            Return False
        ElseIf Len(Trim(Me.txtData.Text)) = 0 Then
            Me.txtData.Focus()
            MsgBox("Falta Nombre del Artículo !!!", MsgBoxStyle.Critical, "Atención !!!")
            Return False
        ElseIf Len(Trim(Me.txtCodigo.Text)) = 0 Then
            Me.txtData.Focus()
            MsgBox("Falta Código del Artículo !!!", MsgBoxStyle.Critical, "Atención !!!")
            Return False
        End If
        '-- Si esta insertando registro, verificamos ya esta registrada la Clave
        If nTipo = 1 Then
            '--
            strSQL = "SELECT strClave FROM Inv_Producto WHERE strClave = '" & Trim(Me.txtCodigo.Text) & "'"
            '--
            If funGetValor(strSQL) <> "" Then
                Me.txtCodigo.Focus()
                MsgBox("El código clave ya existe !!!", MsgBoxStyle.Critical, "Atención !!!")
                Return False
            End If
        End If

        Return True
    End Function

    Private Function funGuardar() As Boolean
        AbrirConexionGlobal()
        Try
            '-- Datos de la transacción
            funSaveProducto()
            funSaveProductoBodega()
            '--
            transaccionGlobal.Commit()
            DBConnGlobal.Close()

        Catch ex As Exception
            LimpiarCampos()
            transaccionGlobal.Rollback()
            DBConnGlobal.Close()
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Function
        End Try
        Me.bbSave.Enabled = False
        Me.Close()
    End Function

    Function funSaveProducto()
        '-- GB-2012-01-12: Multiples conexiones, renumera codigo
        If nTipo = 1 Then
            funNuevoNumero()
        End If
        '-- Datos de la transacción
        strSQL = "SELECT * FROM Inv_Producto WHERE nCode = " & vnCodigo
        '--
        Dim dsAgregar As DataSet = funFillDataSet(strSQL)
        '--
        If dsAgregar.Tables("Tabla").Rows.Count = 0 Then
            funNuevoNumero()
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
                funAddCampo("nCode", vnCodigo, vnCodigo)
                funAddCampo("strClave", Trim(Me.txtCodigo.Text), "")
                funAddCampo("strData", Trim(Me.txtData.Text), "")
                'funAddCampo("dtmAlta", funFechaSql(Me.dtpFecha.Value.Date, True), "")
                funAddCampo("nStatus", Me.lkStatus.EditValue, 0)
                funAddCampo("strUserAdd", strUser, "")
                funAddCampo("strUserUpdate", strUser, "")
                funAddCampo("dtmUpdate", funFechaSql(varToday), "")
                funAddCampo("nMedida", Me.lkMedida.EditValue, 0)
                funAddCampo("nFamilia2", Me.lkFamiliaAux.EditValue, 0)
                '-- Precios
                'funAddCampo("mPrecio_Costo", Me.cbCosto.Value, 0)
                'funAddCampo("mPrecio_Venta1", Me.cbVenta1.Value, 0)
                'funAddCampo("mPrecio_Venta2", Me.cbVenta2.Value, 0)
                'funAddCampo("mPrecio_Venta3", Me.cbVenta3.Value, 0)
                'funAddCampo("mPrecio_Venta4", Me.cbVenta4.Value, 0)
                '-- 
                'If ckCaducidad.CheckState = CheckState.Checked Then
                '    funAddCampo("nVence", 2, 0)
                'Else
                '    funAddCampo("nVence", 1, 0)
                'End If

            Else
                '-- 23-04-2010
                funAddCampo("strData", Trim(Me.txtData.Text), .Item("strData").ToString)
                funAddCampo("nStatus", Me.lkStatus.EditValue, funNull2Val(.Item("nStatus")))
                funAddCampo("dtmUpdate", funFechaSql(varToday), .Item("dtmUpdate").ToString)
                funAddCampo("strUserUpdate", strUser, .Item("strUserUpdate").ToString)
                funAddCampo("nMedida", Me.lkMedida.EditValue, funNull2Val(.Item("nMedida")))
                funAddCampo("nFamilia2", Me.lkFamiliaAux.EditValue, funNull2Val(.Item("nFamilia2")))
                '-- Precios
                'funAddCampo("mPrecio_Costo", Me.cbCosto.Value, funNull2Val(.Item("mPrecio_Costo")))
                'funAddCampo("mPrecio_Venta1", Me.cbVenta1.Value, funNull2Val(.Item("mPrecio_Venta1")))
                'funAddCampo("mPrecio_Venta2", Me.cbVenta2.Value, funNull2Val(.Item("mPrecio_Venta2")))
                'funAddCampo("mPrecio_Venta3", Me.cbVenta3.Value, funNull2Val(.Item("mPrecio_Venta3")))
                'funAddCampo("mPrecio_Venta4", Me.cbVenta4.Value, funNull2Val(.Item("mPrecio_Venta4")))
                '-- 
                'If ckCaducidad.CheckState = CheckState.Checked Then
                '    funAddCampo("nVence", 2, funNull2Val(.Item("nVence")))
                'Else
                '    funAddCampo("nVence", 1, funNull2Val(.Item("nVence")))
                'End If
                '--
            End If
            '-- Definimos la llave
            strLlave = " nCode = " & vnCodigo & " " &
                        "AND strClave = '" & Trim(Me.txtCodigo.Text) & "'"
            '-- Pasamos los parametros de grabación
            funParametrosGrabacionTransaccion("Inv_Producto", strLlave, intTipoRegistro, vnRecno)
        End With

        Return True
    End Function

    Function funSaveProductoBodega()
        '-- 
        strSQL = "SELECT COUNT(*) FROM TablaDeTablas WHERE nCodTbl = 1 AND nId >= 1 AND nEmpresa = 1"
        '--
        Dim nEmpresas As Integer = Val(funGetValor(strSQL))
        For i As Integer = 1 To nEmpresas
            If intTipoRegistro = 1 Then
                funAddCampo("nEmpresa", i, 0)
                funAddCampo("nCode", vnCodigo, vnCodigo)
                funAddCampo("strClave", Trim(Me.txtCodigo.Text), "")
                '-- funAddCampo("nMedida", Me.lkMedida.EditValue, 0)
                funAddCampo("nStatus", Me.lkStatus.EditValue, 0)
                funAddCampo("strUserAdd", strUser, "")
                funAddCampo("dtmUpdate", funFechaSql(varToday), "")
                funAddCampo("strUserUpdate", strUser, "")
            Else
                'funAddCampo("strClave", Trim(Me.lblClave.Text), "")
                '-- 2012-02-17: Verificar cuando quitamos este campo
                '-- funAddCampo("nMedida", Me.lkMedida.EditValue, 0)
                funAddCampo("nStatus", Me.lkStatus.EditValue, 0)
                funAddCampo("dtmUpdate", funFechaSql(varToday), "")
                funAddCampo("strUserUpdate", strUser, "")
            End If
            '-- Definimos la llave
            strLlave = " nEmpresa = " & intEmpresa & " AND nCode = " & vnCodigo
            '-- Pasamos los parametros de grabación
            funParametrosGrabacionTransaccion("Inv_ProductoBodega", strLlave, intTipoRegistro, vnRecno)
        Next
        Return True
    End Function

    '-- Valida Combos

    Private Sub bPrint(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Me.Cursor = Cursors.WaitCursor
        '--funProcesoPrint()
        Dim lstParametros As New List(Of String)
        '-- GB-2012-01-12: Debe de ir en orden a los parametros del SP
        lstParametros.Add(intEmpresa)
        'lstParametros.Add(Me.lblCode.Text.ToString)
        lstParametros.Add(strUser.ToString)
        '--
        funPrintConSp("repKardex.rpt", lstParametros)
        Me.Cursor = Cursors.Default
    End Sub
End Class