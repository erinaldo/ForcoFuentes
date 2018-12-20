Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmKupon_Data
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

    Private Sub frmKupon_Data_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'funCargaCombos()
        'Me.lkTipo.EditValue = 0
        'If nTipo = 1 Then
        '    'funNuevoNumero()
        'Else
        '    Me.lblCodigo.Text = vnCodigo
        '    funCargaData()
        'End If
    End Sub

    Private Function funNuevoNumero()
        '--
        strSQL = "SELECT ISNULL(MAX(nCode), 0) + 1 " &
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
        If Len(Trim(Me.txtCupon.Text)) = 0 Then
            Me.lblCodigo.Focus()
            MsgBox("Falta Codigo !!!", MsgBoxStyle.Critical, "Atención !!!")
            Return False
        End If
        Return True
    End Function

    Private Function funGuardar() As Boolean
        AbrirConexionGlobal()
        Try
            '--
            varToday = funFechaServer()
            '--
            strSQL = "UPDATE Inv_Tarjetasregalo " &
                            "SET nAplicado = 1 " &
                            ", dtmUpdate = '" & Format(CDate(funFechaServer()), "s") & "'" &
                            ", strHostName = '" & System.Net.Dns.GetHostName & "' WHERE nRecno = " & Val(Me.lblCodigo.Text)
            '--
            funRunSQLTransaccion(strSQL)
            '--
            transaccionGlobal.Commit()
        Catch ex As Exception
            LimpiarCampos()
            transaccionGlobal.Rollback()
            DBConnGlobal.Close()
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Function
        End Try
        DBConnGlobal.Close()
        Me.Close()
        '--
    End Function

    Private Sub txtCupon_LostFocus(sender As Object, e As EventArgs) Handles txtCupon.LostFocus
        If Len(Trim(Me.txtCupon.Text)) > 0 Then
            funCargarDatos()
        End If
    End Sub

    Dim vnAplicado As Integer

    Private Function funCargarDatos()



        Try
            ds = clsCupon.funGetCuponDS(Me.txtCupon.Text)
            '--
            If ds.Tables(0).Rows.Count > 0 Then
                With ds.Tables(0).Rows(0)
                    Me.lblCodigo.Text = .Item("nRecno")
                    vnAplicado = .Item("nAplicado")
                    If Me.vnAplicado = 1 Then
                        Me.lblAlerta.Visible = True
                    End If
                End With
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

    Private Sub bbAdd_Click(sender As Object, e As EventArgs) Handles bbAdd.Click
        If Len(Trim(Me.txtCupon.Text)) > 0 Then
            Dim retorna As Boolean
            retorna = funCargarDatos()
            If retorna = False Then
                MsgBox("No se ha encontrado la Tarjeta de Regalo.")
            End If


        End If
    End Sub


End Class
