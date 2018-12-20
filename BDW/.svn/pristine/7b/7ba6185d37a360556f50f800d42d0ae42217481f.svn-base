Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmDespacho_Alista
    Dim ds As New DataSet
    Dim vnBloque As Integer
    Dim vnNumero As Integer
    Dim intTipoRegistro As Integer
    Public nTipo As Integer
    Public vnRecno As Integer
    Dim vn_Sucursal As Integer
    Dim vn_Pedido As Integer
    Dim bolClose As Boolean

    Private Sub bClose_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bClose.ItemClick
        bolClose = True
        Me.Close()
    End Sub

    Private Sub frmDespacho_Alista_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
        '--
    End Sub

    Private Sub frmDespacho_Alista_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        funIniVar()
        funNuevoNumero()
        Me.txtNumero.Text = vnNumero
        '--
        txtCodeBar.Select()
    End Sub

    Private Function funIniVar()
        '--
        Try
            '--
            funCargaCombos()
            Me.lkAlistador.EditValue = 1
            '--
        Catch ex As Exception
            MsgBox("Se ha producido el siguiente error: " + ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            '-- Apagar botones
        End Try
        '--
        Return True
    End Function

    Private Function funCargaCombos()
        '-- Cargar Alistadores
        strSQL = "SELECT nCodigo AS nCodigo, strData AS strDescripcion FROM GB_Alistadores ORDER BY strData"
        '--
        funCargarLue(Me.lkAlistador, strSQL)
        '--
        Return True
    End Function

    Private Sub bbAdd_Click(sender As Object, e As EventArgs)
        'funCargaGrid()
    End Sub

    Private Sub txtCodeBar_LostFocus(sender As Object, e As EventArgs) Handles txtCodeBar.LostFocus
        If Len(Trim(Me.txtCodeBar.Text)) > 0 Then
            funCargarDatos()
        End If
    End Sub

    Private Function funCargarDatos()
        Try
            ds = clsPedidos.funGetInvDespachoDS(Me.txtCodeBar.Text)
            '--
            If ds.Tables(0).Rows.Count > 0 Then
                With ds.Tables(0).Rows(0)
                    vn_Sucursal = .Item("Suc_Id")
                    vn_Pedido = .Item("Pedido_Id")
                End With
                '-- verfiicar si ya existe el pedido
                ds = clsPedidos.funGetPedidoAsignadosDS(Me.txtCodeBar.Text)
                If ds.Tables(0).Rows.Count > 0 Then
                    MsgBox("Este pedido ya fue asignado!", MsgBoxStyle.Critical, "Atención!")
                    Me.txtCodeBar.Text = ""
                    txtCodeBar.Select()
                Else
                    '-- Guardamos el registro
                    funGuardar()
                    funUpdateGrid()
                    Me.txtCodeBar.Text = ""
                    txtCodeBar.Select()
                End If
                Return True
            Else
                Return False
            End If
            '--
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return True
    End Function

    Private Function funGuardar() As Boolean
        AbrirConexionGlobal()
        Try
            '-- Datos de la transacción
            strSQL = "SELECT * FROM GB_Pedidos WHERE nNumero = " & Me.txtCodeBar.Text
            '--
            Dim dsAgregar As DataSet = funFillDataSet(strSQL)
            '--
            If dsAgregar.Tables("Tabla").Rows.Count = 0 Then
                funNuevoNumero()
                dsAgregar.Tables("Tabla").Rows.Add()
            End If
            '--
            With dsAgregar.Tables("Tabla").Rows(0)
                '-- Tomamos el nRecno
                Dim vnRecno = funNull2Val(.Item("nRecno"))
                '-- Tipo de Accion para Guardar: 1:Add, 2:Update
                intTipoRegistro = IIf(funNull2Val(.Item("nRecno")) = 0, 1, 2)
                '--
                If intTipoRegistro = 1 Then
                    '-- Agregando
                    funAddCampo("nNumero", vnNumero, 0)
                    funAddCampo("nSuc_Id", vn_Sucursal, 0)
                    funAddCampo("nPedido_Id", vn_Pedido, 0)
                    funAddCampo("dtmFecha_Asigna", Format(Me.dtmFecha.Value, "s"), "")
                    funAddCampo("nAlistador", Me.lkAlistador.EditValue, 0)
                    funAddCampo("strAlistador", Me.lkAlistador.Text, 0)
                    funAddCampo("strUserAdd", strUser, "")
                    funAddCampo("strUserUpdate", strUser, "")
                End If
                '-- Definimos la llave
                strLlave = " nNumero = " & vnNumero
                '-- Pasamos los parametros de grabación
                funParametrosGrabacionTransaccion("GB_Pedidos", strLlave, intTipoRegistro, vnRecno)
                '--
                transaccionGlobal.Commit()
                DBConnGlobal.Close()
            End With
        Catch ex As Exception
            LimpiarCampos()
            transaccionGlobal.Rollback()
            DBConnGlobal.Close()
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Function
        End Try
    End Function

    Private Function funNuevoNumero()
        '--
        strSQL = "SELECT ISNULL(MAX(nNumero), 0) + 1 FROM GB_Pedidos"
        '--
        vnNumero = funGetValor(strSQL)
        Return True
    End Function

    Private Function Validar() As Boolean
        If Len(Trim(Me.txtCodeBar.Text)) = 0 Then
            MsgBox("Falta Codigo !!!", MsgBoxStyle.Critical, "Atención !!!")
            txtCodeBar.Select()
            Return False
        End If
        Return True
    End Function

    Private Function funUpdateGrid() As Boolean
        '--
        strSQL = "SELECT * FROM GB_Pedidos ORDER BY nPedido_Id"
        '--
        ds = funFillDataSet(strSQL)
        '--
        Me.gcDetalle.DataSource = funFillDataSet(strSQL).Tables(0)
        '--
        GridViewStyle(Me.gvDetalle)
        funOcultarTodasLasColumnas(Me.gvDetalle)
        indice = 0
        '--
        funSetColumna(Me.gvDetalle, "nNumero", "No.", funIndice(), 90, 1)
        funSetColumna(Me.gvDetalle, "cSucPedido", "Codigo_Barra", funIndice(), 90, 1)
        funSetColumna(Me.gvDetalle, "dtmFecha_Asigna", "Fecha +", funIndice(), 150, 1, , , "d")
        funSetColumna(Me.gvDetalle, "strAlistador", "Alistador", funIndice(), 250, 1)
        '-- 
        Return True
    End Function

    Private Sub txtCodeBar_TextChanged(sender As Object, e As EventArgs)

    End Sub
End Class