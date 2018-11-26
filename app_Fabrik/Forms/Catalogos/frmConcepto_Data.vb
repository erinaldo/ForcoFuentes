Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmConcepto_Data
    Dim ds As New DataSet
    Dim intTipoRegistro As Integer
    Public nTipo As Integer
    Public vnRecno As Integer
    Public vnCodigo As Integer
    Dim varToday As Date

    Private Sub bbClose_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbClose.ItemClick
        Me.Close()
    End Sub

    Private Sub frmConcepto_Data_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmConcepto_Data_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        funCargaCombos()
        Me.lkTipo.EditValue = 0
        If nTipo = 1 Then
            funNuevoNumero()
        Else
            Me.lblCodigo.Text = vnCodigo
            funCargaData()
        End If
    End Sub

    Private Sub funCargaCombos()
        '-- Combo Tipo de Movimiento de Inventario
        funCargarlue(Me.lkTipo, "SELECT nID AS nCodigo, strDescripcion AS strDescripcion FROM TablaDeTablas " & _
                                    "WHERE nCodTbl = 108 AND nEstatus = 1 AND nEmpresa = " & intEmpresa)
        '--
    End Sub

    Private Function funNuevoNumero()
        '--
        strSQL = "SELECT ISNULL(MAX(nCode), 0) + 1 " & _
                    "FROM Inv_Concepto"
        '--
        Me.lblCodigo.Text = funGetValor(strSQL)
        vnCodigo = funGetValor(strSQL)
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
        If Len(Trim(Me.lblCodigo.Text)) = 0 Then
            Me.lblCodigo.Focus()
            MsgBox("Falta Codigo !!!", MsgBoxStyle.Critical, "Atención !!!")
            Return False
        ElseIf Len(Trim(Me.txtConcepto.Text)) = 0 Then
            Me.txtConcepto.Focus()
            MsgBox("Falta Concepto !!!", MsgBoxStyle.Critical, "Atención !!!")
            Return False
        ElseIf Len(Trim(Me.txtData.Text)) = 0 Then
            Me.txtData.Focus()
            MsgBox("Falta Descripción !!!", MsgBoxStyle.Critical, "Atención !!!")
            Return False
        ElseIf Me.lkTipo.EditValue = 0 Then
            Me.lkTipo.Focus()
            Me.lkTipo.SelectAll()
            MsgBox("Falta Tipo !!!", MsgBoxStyle.Critical, "Atención !!!")
            Return False
        End If
        Return True
    End Function

    Private Function funGuardar() As Boolean
        AbrirConexionGlobal()
        Try
            '-- Datos de la transacción
            strSQL = "SELECT * FROM Inv_Concepto " & _
                        "WHERE nCode = " & vnCodigo
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
                    '-- Agregando
                    funAddCampo("nCode", vnCodigo, vnCodigo)
                    funAddCampo("strConcepto", Trim(Me.txtConcepto.Text), "")
                    funAddCampo("strData", Trim(Me.txtData.Text), "")
                    funAddCampo("nTipoConcepto", Me.lkTipo.EditValue, 0)
                    funAddCampo("strUserAdd", strUser, "")
                    funAddCampo("strUserUpdate", strUser, "")
                Else
                    '-- Editando
                    funAddCampo("strConcepto", Trim(Me.txtConcepto.Text), .Item("strConcepto").ToString)
                    funAddCampo("strData", Trim(Me.txtData.Text), .Item("strData").ToString)
                    funAddCampo("nTipoConcepto", Me.lkTipo.EditValue, funNull2Val(.Item("nTipoConcepto")))
                    funAddCampo("dtmUpdate", Format(varToday, "s"), .Item("dtmUpdate").ToString)
                    funAddCampo("strUserUpdate", strUser, .Item("strUserUpdate").ToString)
                End If
                '-- Definimos la llave
                strLlave = " nCode = " & vnCodigo
                '-- Pasamos los parametros de grabación
                funParametrosGrabacionTransaccion("Inv_Concepto", strLlave, intTipoRegistro, vnRecno)
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
        Me.bbSave.Enabled = False
        Me.Close()
    End Function

    Private Function funCargaData()
        '-- Filtramos el registro
        strSQL = "SELECT strConcepto, strData, nTipoConcepto, bitReservado " & _
                    "FROM Inv_Concepto " & _
                    "WHERE nCode = " & Me.vnCodigo
        '-- Cargamos el DS
        ds = funFillDataSet(strSQL)
        '-- Verificamos si existen registros
        If ds.Tables("Tabla").Rows.Count >= 1 Then
            '-- Cargamos datos
            Me.txtConcepto.Text = ds.Tables("Tabla").Rows(0)("strConcepto").ToString
            Me.txtData.Text = ds.Tables("Tabla").Rows(0)("strData").ToString
            '-- Me.vnTipoConcepto = ds.Tables("Tabla").Rows(0)("nTipoConcepto")
            Me.lkTipo.EditValue = CInt(funNull2Val(ds.Tables("Tabla").Rows(0)("nTipoConcepto")))
            '-- GB: 17-04-2010_ -1 = True, 0 = Flase
            Me.chkReserva.Checked = IIf(ds.Tables("Tabla").Rows(0)("bitReservado") = -1, True, False)
        Else
            MsgBox("No Existen Registros ... !!!", MsgBoxStyle.Critical, "Información")
        End If
        Return True
    End Function

    Private Sub lkTipo_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lkTipo.EditValueChanged
        If Me.lkTipo.EditValue = 0 Then Exit Sub
    End Sub

End Class