Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmRepSaldo2
    Dim bolInicio As Boolean

    Private Sub frmRepSaldo2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        bolInicio = True
        funIniVar()
        bolInicio = False
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
        '-- Segmento
        strSQL = clsCombos.funGetLkSegmentoConMov()
        funCargarlue(Me.lkSegmento1, strSQL)
        '-- Familias
        strSQL = clsCombos.funGetLkFamiliaFull()
        funCargarlue(Me.lkFamilia2, strSQL)
        '-- Clase
        strSQL = clsCombos.funGetLkClaseFull()
        funCargarlue(Me.lkClase3, strSQL)
        '-- Articulo
        strSQL = clsCombos.funGetLkArticuloFull()
        funCargarlue(Me.lkArticulo4, strSQL)
        '--
        Me.lkSegmento1.EditValue = 0
        Me.lkFamilia2.EditValue = 0
        Me.lkClase3.EditValue = 0
        Me.lkArticulo4.EditValue = 0
        '--
        Me.lkFamilia2.Enabled = False
        Me.lkClase3.Enabled = False
        Me.lkArticulo4.Enabled = False
        '--
    End Sub

    Private Sub funCargaCombosTwo()
        '-- Clase
        strSQL = clsCombos.funGetLkClaseFull()
        funCargarlue(Me.lkClase3, strSQL)
        '-- Articulo
        strSQL = clsCombos.funGetLkArticuloFull()
        funCargarlue(Me.lkArticulo4, strSQL)
        '--
        Me.lkClase3.EditValue = 0
        Me.lkArticulo4.EditValue = 0
        '--
        Me.lkClase3.Enabled = False
        Me.lkArticulo4.Enabled = False
        '--
    End Sub

    Private Sub funCargaCombosThree()
        '-- Articulo
        strSQL = clsCombos.funGetLkArticuloFull()
        funCargarlue(Me.lkArticulo4, strSQL)
        '--
        Me.lkArticulo4.EditValue = 0
        '--
        Me.lkArticulo4.Enabled = False
        '--
    End Sub
    Private Sub lkSegmento1_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles lkSegmento1.EditValueChanged
        If Me.bolInicio = False Then
            '-- 
            If Me.lkSegmento1.EditValue = 0 Then
                '-- Selecciono TODOS, cargar todos los combos
                funCargaCombosOne()
            Else
                '-- Familias con movimientos
                strSQL = clsCombos.funGetLkFamiliaConMov(Me.lkSegmento1.EditValue)
                funCargarlue(Me.lkFamilia2, strSQL)
                Me.lkFamilia2.Enabled = True
            End If
        End If
    End Sub

    Private Sub lkFamilia2_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles lkFamilia2.EditValueChanged
        If Me.bolInicio = False Then
            '-- 
            If Me.lkFamilia2.EditValue = 0 Then
                '-- Selecciono TODOS, cargar todos los combos
                funCargaCombosTwo()
            Else
                '-- Familias con movimientos
                strSQL = clsCombos.funGetLkClaseConMov(Me.lkSegmento1.EditValue, lkFamilia2.EditValue)
                funCargarlue(Me.lkClase3, strSQL)
                Me.lkClase3.Enabled = True
            End If
        End If
    End Sub

    Private Sub lkClase3_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles lkClase3.EditValueChanged
        If Me.bolInicio = False Then
            '-- 
            If Me.lkClase3.EditValue = 0 Then
                '-- Selecciono TODOS, cargar todos los combos
                funCargaCombosThree()
            Else
                '-- Familias con movimientos
                strSQL = clsCombos.funGetLkArticuloConMov(Me.lkSegmento1.EditValue, lkFamilia2.EditValue, lkClase3.EditValue)
                funCargarlue(Me.lkArticulo4, strSQL)
                Me.lkArticulo4.Enabled = True
            End If
        End If
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
            lstParametros.Add(intEmpresa.ToString)
            lstParametros.Add(Me.lkSegmento1.EditValue.ToString)
            lstParametros.Add(Me.lkFamilia2.EditValue.ToString)
            lstParametros.Add(Me.lkClase3.EditValue.ToString)
            lstParametros.Add(Me.lkArticulo4.EditValue.ToString)
            lstParametros.Add(Me.dtpDesde.Value.Date)
            lstParametros.Add(Me.dtpHasta.Value.Date)
            lstParametros.Add(strUser.ToString)
            '--
            funPrintConSp("repSaldos.rpt", lstParametros)
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Function Validar() As Boolean
        '-- 
        If Len(Trim(Me.lkSegmento1.Text)) = 0 Then
            Me.lkSegmento1.Focus()
            MsgBox("Falta seleccionar el segmento !!!", MsgBoxStyle.Critical, "Atención !!!")
            Return False
        End If
        Return True
    End Function

End Class