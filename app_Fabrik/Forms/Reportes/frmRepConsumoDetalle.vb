Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmRepConsumoDetalle

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
            Me.dtpDesde.MinDate = "01/01/1753"
            Me.dtpDesde.MaxDate = "31/12/9998"
            Me.dtpHasta.MinDate = "01/01/1753"
            Me.dtpHasta.MaxDate = "31/12/9998"
            Me.dtpDesde.MaxDate = SGA.Rutinas.Fecha
            Me.dtpHasta.MaxDate = SGA.Rutinas.Fecha
            '--
            funCargaCombos()
            '--
            Me.lkEmpresa.EditValue = intEmpresa
            Me.lkEmpresa.Enabled = False
            Me.lkTipoSalida.EditValue = 11
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
        '-- Empresa
        strSQL = clsCombos.funGetLkEmpresaAll()
        funCargarlue(Me.lkEmpresa, strSQL)
        '-- Dependencia
        strSQL = clsCombos.funGetLkDependenciaAll()
        funCargarlue(Me.lkDep, strSQL)
        '-- Tipo de consumo 11,12 (salida, complemento)
        strSQL = clsCombos.funGetLkTipoConceptoSalida()
        funCargarlue(Me.lkTipoSalida, strSQL)
        '--
        Return True
    End Function

    Private Sub bPrint_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bPrint.ItemClick
        If Len(Trim(Me.txtSalida.Text)) = 0 Then
            If Validar() = True Then
                Me.Cursor = Cursors.WaitCursor
                '-- Proceso de impresion
                Dim lstParametros As New List(Of String)
                lstParametros.Add(intEmpresa.ToString)
                lstParametros.Add(Me.dtpDesde.Value.Date)
                lstParametros.Add(Me.dtpHasta.Value.Date)
                lstParametros.Add(Me.lkDep.EditValue.ToString)
                lstParametros.Add(strUser.ToString)
                lstParametros.Add(Me.lkTipoSalida.EditValue.ToString)
                '--
                funPrintConSp("repConsumoDetalleDep.rpt", lstParametros)
                Me.Cursor = Cursors.Default
            End If
        Else
            subPrint()
        End If
    End Sub

    Private Sub subPrint()
        Me.Cursor = Cursors.WaitCursor
        '--
        Dim localvnCode As Integer
        '--
        strSQL = "SELECT nNumero FROM Inv_Movto_Inventario " & _
                    " WHERE strReferencia = '" & Me.txtSalida.Text & "' " & _
                    "AND nConcepto = " & Me.lkTipoSalida.EditValue & " " & _
                    "AND nEmpresa = " & intEmpresa
        '--
        localvnCode = funGetValor(strSQL)
        '--
        Dim lstParametros As New List(Of String)
        '-- GB-2012-01-12: Debe de ir en orden a los parametros del SP
        lstParametros.Add(intEmpresa)
        lstParametros.Add(localvnCode.ToString)
        lstParametros.Add(Me.lkTipoSalida.EditValue.ToString)
        lstParametros.Add(strUser)
        '--
        funPrintConSp("repSolComp2.rpt", lstParametros)
        Me.Cursor = Cursors.Default
    End Sub
End Class