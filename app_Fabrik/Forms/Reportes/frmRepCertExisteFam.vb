Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmRepCertExisteFam
    Dim bolInicio As Boolean

    Private Sub frmRepCertExisteFam_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub bClose_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bClose.ItemClick
        Me.Close()
    End Sub

    Private Sub frmRepCertExisteFam_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        bolInicio = True
        funIniVar()
        bolInicio = False
    End Sub

    Private Function funIniVar()
        '--
        Try
            '--
            funCargaCombosOne()
            '--
        Catch ex As Exception
            MsgBox("Se ha producido el siguiente error: " + ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            '-- Apagar botones
            HabilitarControles(GroupControl1, False)
            Me.bbPrint.Enabled = False
        End Try
        '--
        Return True
    End Function

    Private Sub funCargaCombosOne()
        '-- Familia Auxiliar
        strSQL = clsCombos.funGetLkFamiliaAuxAll()
        funCargarlue(Me.lkFamiliaAux, strSQL)
        '--
    End Sub

    Private Sub bbPrint_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbPrint.ItemClick
        If Validar() = True Then
            Me.Cursor = Cursors.WaitCursor
            Dim lstParametros As New List(Of String)
            '--
            lstParametros.Add(intEmpresa.ToString)
            lstParametros.Add(0)
            lstParametros.Add(0)
            lstParametros.Add(0)
            lstParametros.Add(0)
            lstParametros.Add(Me.dtpDesde.Value.Date)
            lstParametros.Add(strUser.ToString)
            lstParametros.Add(Me.lkFamiliaAux.EditValue.ToString)
            lstParametros.Add(Me.txtDestino1.Text.ToString)
            lstParametros.Add(Me.txtDestino2.Text.ToString)
            lstParametros.Add(Me.txtRemite1.Text.ToString)
            lstParametros.Add(Me.txtRemite2.Text.ToString)
            lstParametros.Add(Me.txtCrono.Text.ToString)
            funPrintConSp("repCertExisteFam.rpt", lstParametros)
        '--
        Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Function Validar() As Boolean
        '-- 
        If Len(Trim(Me.lkFamiliaAux.Text)) = 0 Then
            Me.lkFamiliaAux.Focus()
            MsgBox("Falta seleccionar la familia !!!", MsgBoxStyle.Critical, "Atención !!!")
            Return False
        End If
        Return True
    End Function
End Class