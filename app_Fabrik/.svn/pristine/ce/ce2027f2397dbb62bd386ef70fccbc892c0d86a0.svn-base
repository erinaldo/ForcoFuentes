Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmRepEntrada2

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
        '-- Cargar Empresa
        strSQL = "SELECT NCODE AS nCodigo, STRNOMBRE AS strDescripcion " & _
                    " FROM Gen_Empresas " & _
                    " ORDER BY NCODE"
        '--
        funCargarLue(Me.lkEmpresa, strSQL)
        '--
        Return True
    End Function

    Private Sub bPrint_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bPrint.ItemClick
        '--
        If Len(Trim(Me.txtEntrada.Text)) = 0 Then
            If Validar() = True Then
                Me.Cursor = Cursors.WaitCursor
                '-- Proceso de impresion
                Dim lstParametros As New List(Of String)
                lstParametros.Add(intEmpresa.ToString)
                lstParametros.Add(Me.dtpDesde.Value.Date)
                lstParametros.Add(Me.dtpHasta.Value.Date)
                lstParametros.Add(strUser.ToString)
                '--
                funPrintConSp("repEntradaDetalle.rpt", lstParametros)
                Me.Cursor = Cursors.Default
            End If
        Else
            subPrint()
        End If
        '--
    End Sub

    Private Sub subPrint()
        Me.Cursor = Cursors.WaitCursor
        '--
        Dim localvnConcpeto As Integer
        localvnConcpeto = 5
        Dim localvnCode As Integer
        '--
        strSQL = "SELECT nNumero FROM Inv_Movto_Inventario " & _
                    " WHERE strReferencia = '" & Me.txtEntrada.Text & "' " & _
                    "AND nConcepto = " & localvnConcpeto & " " & _
                    "AND nEmpresa = " & intEmpresa
        '--
        localvnCode = funGetValor(strSQL)
        '--
        Dim lstParametros As New List(Of String)
        '-- GB-2012-01-12: Debe de ir en orden a los parametros del SP
        lstParametros.Add(intEmpresa)
        lstParametros.Add(localvnCode.ToString)
        lstParametros.Add(localvnConcpeto.ToString)
        '--
        funPrintConSp("repOrdenEntrada.rpt", lstParametros)
        Me.Cursor = Cursors.Default
    End Sub
End Class