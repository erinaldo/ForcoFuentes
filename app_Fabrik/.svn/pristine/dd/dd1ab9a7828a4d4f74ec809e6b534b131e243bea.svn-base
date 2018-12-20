Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmEmpresa_Data
    Dim ds As New DataSet
    Dim intTipoRegistro As Integer
    Public nTipo As Integer
    Public vnRecno As Integer
    Public vnCodigo As Integer

    Private Sub bbClose_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbClose.ItemClick
        Me.Close()
    End Sub

    Private Sub frmEmpresa_Data_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmEmpresa_Data_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If nTipo = 1 Then
            funNuevoNumero()
        Else
            Me.lblCodigo.Text = vnCodigo
            funCargaData()
        End If
    End Sub

    Private Sub bbSave_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbSave.ItemClick
        If Validar() = True Then
            If MessageBox.Show("¿ Desea Grabar los datos ...?", "Atención !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = MsgBoxResult.Yes Then
                funGuardar()
            End If
        End If
    End Sub

    Private Function funNuevoNumero()
        '--
        strSQL = "SELECT ISNULL(MAX(NCODE), 0) + 1 " & _
                    "FROM Gen_Empresas"
        '--
        Me.lblCodigo.Text = funGetValor(strSQL)
        vnCodigo = funGetValor(strSQL)
        Return True
    End Function

    Private Function Validar() As Boolean
        If Len(Trim(Me.lblCodigo.Text)) = 0 Then
            Me.lblCodigo.Focus()
            MsgBox("Falta Codigo !!!", MsgBoxStyle.Critical, "Atención !!!")
        ElseIf Len(Trim(Me.txtData.Text)) = 0 Then
            Me.txtData.Focus()
            MsgBox("Falta Descripción !!!", MsgBoxStyle.Critical, "Atención !!!")
            Return False
        ElseIf Len(Trim(Me.txtCorto.Text)) = 0 Then
            Me.txtCorto.Focus()
            MsgBox("Falta Iniciales !!!", MsgBoxStyle.Critical, "Atención !!!")
            Return False
        End If
        Return True
    End Function

    Private Function funGuardar() As Boolean
        AbrirConexionGlobal()
        Try
            '-- Datos de la transacción
            strSQL = "SELECT * FROM Gen_Empresas " & _
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
                '-- Tomamos el nRecno
                Dim vnRecno = funNull2Val(.Item("NRECNO"))
                '-- Tipo de Accion para Guardar: 1:Add, 2:Update
                intTipoRegistro = IIf(funNull2Val(.Item("nRecno")) = 0, 1, 2)
                '--
                If intTipoRegistro = 1 Then
                    '-- Agregando
                    funAddCampo("NCODE", vnCodigo, vnCodigo)
                    funAddCampo("STRNOMBRE", Trim(Me.txtData.Text), "")
                    funAddCampo("STRCORTO", Trim(Me.txtCorto.Text), "")
                Else
                    '-- Editando
                    funAddCampo("STRNOMBRE", Trim(Me.txtData.Text), .Item("STRNOMBRE").ToString)
                    funAddCampo("STRCORTO", Trim(Me.txtCorto.Text), .Item("STRCORTO").ToString)
                End If
                '-- Definimos la llave
                strLlave = " NCODE = " & vnCodigo
                '-- Pasamos los parametros de grabación
                funParametrosGrabacionTransaccion("Gen_Empresas", strLlave, intTipoRegistro, vnRecno)
                '-- Grabamos en la tabla de tablas
                funSaveTablaDeTablas()
                '-- Grabamos los registro existentes para la tabla nueva
                If nTipo = 1 Then
                    funSaveRecordTablaDeTablas()
                End If
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

    Function funSaveTablaDeTablas()
        '-- 
        strSQL = "SELECT COUNT(*) FROM TablaDeTablas WHERE nCodTbl = 1 AND nId >= 1 AND nEmpresa = 1"
        '--
        Dim nEmpresas As Integer = Val(funGetValor(strSQL))
        '--
        For i As Integer = 1 To nEmpresas
            funAddCampo("NCODTBL", 1, 0)
            funAddCampo("NID", Me.vnCodigo, 0)
            funAddCampo("NEMPRESA", i, 0)
            funAddCampo("STRDESCRIPCION", Me.txtData.Text, DBNull.Value.ToString)
            funAddCampo("STRCONCEPTO", Me.txtCorto.Text, DBNull.Value.ToString)
            funAddCampo("NESTATUS", 1, 0)
            Dim strCondicion As String = "NID=" & vnCodigo & " AND NCODTBL = " & 1 & " AND NEMPRESA = " & i
            funParametrosGrabacionTransaccion("TABLADETABLAS", strCondicion, Me.nTipo, , , 0)
        Next
        '--
        Return True
    End Function

    Function funSaveRecordTablaDeTablas()
        '-- Limpiamos la tabla temporal
        strSQL = "DELETE FROM TmpTT"
        funRunSQLTransaccion(strSQL)
        '-- Insertamos registros para la nueva empresa
        strSQL = "INSERT INTO TmpTT(nCodTbl, nID, strDescripcion, nEmpresa, " & _
                    "strConcepto, NESTATUS) " & _
                    "SELECT nCodTbl, nID, strDescripcion, nEmpresa, " & _
                    "strConcepto, NESTATUS " & _
                    "FROM TablaDeTablas  " & _
                    "WHERE nCodTbl > 1 " & _
                    " AND nEmpresa = 1"
        '--
        funRunSQLTransaccion(strSQL)
        '-- Actualizamos al nuevo codigo de empresa
        strSQL = "UPDATE TmpTT SET nEmpresa= " & vnCodigo
        funRunSQLTransaccion(strSQL)
        '-- Insertamos en la tabla de tablas y obtenemos el catalogo para la nueva empresa
        strSQL = "INSERT INTO TablaDeTablas(nCodTbl, nID, strDescripcion, nEmpresa, " & _
                           "strConcepto, NESTATUS) " & _
                           "SELECT nCodTbl, nID, strDescripcion, nEmpresa, " & _
                           "strConcepto, NESTATUS " & _
                           "FROM TmpTT"
        '--
        funRunSQLTransaccion(strSQL)
        '-- Limpiamos la tabla temporal
        strSQL = "DELETE FROM TmpTT"
        funRunSQLTransaccion(strSQL)
        Return True
    End Function

    Private Function funCargaData()
        '-- Filtramos el registro
        strSQL = "SELECT * " & _
                    "FROM Gen_Empresas " & _
                    "WHERE NCODE = " & vnCodigo
        '-- Cargamos el DS
        ds = funFillDataSet(strSQL)
        '-- Verificamos si existen registros
        If ds.Tables("Tabla").Rows.Count >= 1 Then
            '-- Cargamos datos
            Me.txtData.Text = ds.Tables("Tabla").Rows(0)("STRNOMBRE").ToString
            Me.txtCorto.Text = ds.Tables("Tabla").Rows(0)("STRCORTO").ToString
        Else
            MsgBox("No Existen Registros ... !!!", MsgBoxStyle.Critical, "Información")
        End If
        Return True
    End Function

End Class