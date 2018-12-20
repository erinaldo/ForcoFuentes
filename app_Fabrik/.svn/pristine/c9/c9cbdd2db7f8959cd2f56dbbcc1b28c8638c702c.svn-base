Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmRepExistencias
    Dim bolInicio As Boolean

    Private Sub frmRepSaldo2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
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
            'HabilitarControles(GroupControl1, False)
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
        Me.lkFamiliaAux.EditValue = 0
        '--
    End Sub

    Private Sub bbClose_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbClose.ItemClick
        Me.Close()
    End Sub

    Private Sub bbPrint_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbPrint.ItemClick
        If Validar() = True Then
            Me.Cursor = Cursors.WaitCursor
            '-- Proceso de impresion
            '-- @empresa int, @segmento INT, @familia INT, @clase INT, @articulo INT,@fecha1 DATETIME,@fecha2 DATETIME
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
            lstParametros.Add(0)
            lstParametros.Add(0)
            lstParametros.Add(0)
            lstParametros.Add(0)
            lstParametros.Add(0)
            If Me.optOpcion.SelectedIndex = 0 Then
                funPrintConSp("repExistencias2.rpt", lstParametros)
            Else
                funPrintConSp("repExistencias4.rpt", lstParametros)
            End If
            Me.Cursor = Cursors.Default
            End If
    End Sub

    Private Function Validar() As Boolean
        '-- 
        If Len(Trim(Me.lkFamiliaAux.Text)) = 0 Then
            Me.lkFamiliaAux.Focus()
            MsgBox("Falta seleccionar familia !!!", MsgBoxStyle.Critical, "Atención !!!")
            Return False
        End If
        Return True
    End Function

End Class