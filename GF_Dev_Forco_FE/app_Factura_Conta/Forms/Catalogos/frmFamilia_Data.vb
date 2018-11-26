Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmFamilia_Data
    Dim ds As New DataSet
    Dim intTipoRegistro As Integer
    Public nTipo As Integer
    Public vnRecno As Integer
    Public vnCodigo As Integer
    Dim varToday As Date

    Private Sub bbClose_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbClose.ItemClick
        Me.Close()
    End Sub

    Private Sub frmFamilia_Data_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmFamilia_Data_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If nTipo = 1 Then
            funNuevoNumero()
        Else
            Me.lblCodigo.Text = vnCodigo
            funCargaData()
        End If
    End Sub

    Private Function funNuevoNumero()
        '--
        strSQL = "SELECT ISNULL(MAX(nCode), 0) + 1 " & _
                    "FROM Cat_Familia2 " & _
                    "WHERE nYN <> 2"
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
        ElseIf Len(Trim(Me.txtData.Text)) = 0 Then
            Me.txtData.Focus()
            MsgBox("Falta Descripción !!!", MsgBoxStyle.Critical, "Atención !!!")
            Return False
        End If
        Return True
    End Function

    Private Function funGuardar() As Boolean
        AbrirConexionGlobal()
        Try
            '-- Datos de la transacción
            strSQL = "SELECT * FROM Cat_Familia2 " & _
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
                    funAddCampo("strData", Trim(Me.txtData.Text), "")
                    funAddCampo("strUserAdd", strUser, "")
                    funAddCampo("strUserUpdate", strUser, "")
                Else
                    '-- Editando
                    funAddCampo("strData", Trim(Me.txtData.Text), .Item("strData").ToString)
                    funAddCampo("dtmUpdate", Format(varToday, "s"), .Item("dtmUpdate").ToString)
                    funAddCampo("strUserUpdate", strUser, .Item("strUserUpdate").ToString)
                End If
                '-- Definimos la llave
                strLlave = " nCode = " & vnCodigo
                '-- Pasamos los parametros de grabación
                funParametrosGrabacionTransaccion("Cat_Familia2", strLlave, intTipoRegistro, vnRecno)
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
        strSQL = "SELECT * " & _
                    "FROM Cat_Familia2 " & _
                    "WHERE nCode = " & Me.vnCodigo
        '-- Cargamos el DS
        ds = funFillDataSet(strSQL)
        '-- Verificamos si existen registros
        If ds.Tables("Tabla").Rows.Count >= 1 Then
            '-- Cargamos datos
            Me.txtData.Text = ds.Tables("Tabla").Rows(0)("strData").ToString
            '--
        Else
            MsgBox("No Existen Registros ... !!!", MsgBoxStyle.Critical, "Información")
        End If
        Return True
    End Function

End Class