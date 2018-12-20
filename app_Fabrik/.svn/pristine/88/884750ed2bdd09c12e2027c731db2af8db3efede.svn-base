Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmRepPrecios

    Private Sub bClose_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bClose.ItemClick
        Me.Close()
    End Sub

    Private Function Validar() As Boolean
        '-- Cuando es por empleado
        If Len(Trim(Me.lkEmpresa.Text)) = 0 Then
            Me.lkEmpresa.Focus()
            MsgBox("Falta seleccionar el Programa !!!", MsgBoxStyle.Critical, "Atención !!!")
            Return False
        End If
        Return True
    End Function

    Private Sub frmRepRetraso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        funIniVar()
    End Sub

    Private Function funIniVar()
        '--
        Try
            '--
            funCargaCombos()
            '--
            Me.lkEmpresa.EditValue = intEmpresa
            Me.lkEmpresa.Enabled = False
            '--
        Catch ex As Exception
            MsgBox("Se ha producido el siguiente error: " + ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            '-- Apagar botones
            HabilitarControles(GroupControl1, False)
            Me.bPrint.Enabled = False
        End Try
        '--
        Return True
    End Function

    Private Function funCargaCombos()
        '-- Emrpesas
        strSQL = clsCombos.funGetLkEmpresas()
        funCargarlue(Me.lkEmpresa, strSQL)
        '-- Carga proveedor
        strSQL = clsCombos.funGetLkFamiliaAuxAll()
        funCargarlue(Me.lkFamilia, strSQL)
        Return True
    End Function

    Private Sub bPrint_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bPrint.ItemClick
        If Validar() = True Then
            Me.Cursor = Cursors.WaitCursor
            '-- Proceso de impresion
            Dim lstParametros As New List(Of String)
            lstParametros.Add(intEmpresa.ToString)
            lstParametros.Add(Me.lkFamilia.EditValue.ToString)
            lstParametros.Add(strUser.ToString)
            '--
            funPrintConSp("repPrecios.rpt", lstParametros)
            '--
            Me.Cursor = Cursors.Default
        End If
    End Sub
End Class