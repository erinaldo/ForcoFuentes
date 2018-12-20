Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmRepKardex
    Dim vnProducto As Integer

    Private Sub bClose_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bClose.ItemClick
        Me.Close()
    End Sub

    Private Function Validar() As Boolean
        '-- Cuando es por empleado
        If Len(Trim(Me.lkProducto.EditValue)) = 0 Then
            Me.lkProducto.Focus()
            MsgBox("Falta seleccionar el Producto !!!", MsgBoxStyle.Critical, "Atención !!!")
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
            'Me.lkEmpresa.EditValue = intEmpresa
            'Me.lkEmpresa.Enabled = False
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
        'strSQL = clsCombos.funGetLkEmpresas()
        'funCargarlue(Me.lkEmpresa, strSQL)
        '-- Carga proveedor
        strSQL = clsCombos.funGetProductoConMov(intEmpresa)
        funCargarlue(Me.lkProducto, strSQL)
        Return True
    End Function

    Private Sub bPrint_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bPrint.ItemClick
        If Validar() = True Then
            Me.Cursor = Cursors.WaitCursor
            '-- Buscamos el codigo del producto
            strSQL = "SELECT nCode FROM Inv_Producto " & _
                        " WHERE strClave = '" & Me.lkProducto.EditValue.ToString & "' "
            '--
            vnProducto = funGetValor(strSQL)
            '--
            Dim lstParametros As New List(Of String)
            '-- 
            lstParametros.Add(intEmpresa)
            lstParametros.Add(vnProducto.ToString)
            lstParametros.Add(strUser.ToString)
            lstParametros.Add(Me.dtpDesde.Value.Date)
            lstParametros.Add(Me.dtpHasta.Value.Date)
            '--
            funPrintConSp("repKardex.rpt", lstParametros)
            Me.Cursor = Cursors.Default
        End If
    End Sub


End Class