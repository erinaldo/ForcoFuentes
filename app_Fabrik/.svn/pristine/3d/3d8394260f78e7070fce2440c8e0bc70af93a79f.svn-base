Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmRepCertExisteItemNo
    Dim ds As New DataSet
    Dim nTipoMovGrid As Integer
    Dim i As Integer
    Dim vnNumero As Integer
    Dim strChekados As String

    Private Sub frmRepCertExisteItemNo_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmRepCertExisteItemNo_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        funUpdateGrid()
    End Sub

    Private Sub bbAdd_Click(sender As System.Object, e As System.EventArgs) Handles bbAdd.Click
        subAdd()
    End Sub

    Private Sub subAdd()
        Dim f As New frmRepSearchItemNo
        f.barText.Text = "Agregando Producto"
        f.ShowDialog()
        '--
        If bolFound = True Then
            nTipoMovGrid = 1
            funCargaData()
            funCargaGrid()
        End If
        '--
    End Sub

    Private Sub bbClose_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbClose.ItemClick
        Me.Close()
    End Sub

    Private Sub funCargaGrid()
        '-- 
        With Me.gvDetalle
            For i = 0 To Me.gvDetalle.RowCount - 1
                If vnProducto = Me.gvDetalle.GetRowCellValue(i, "nCode") And nTipoMovGrid = 1 Then
                    MsgBox("Este producto ya esta seleccionado !!!", MsgBoxStyle.Information, "Atención")
                    Exit Sub
                End If
            Next
            If nTipoMovGrid = 1 Then
                .AddNewRow()
            End If
            .SetFocusedRowCellValue(.Columns("nCode"), vnProducto)
            .SetFocusedRowCellValue(.Columns("strClave"), vpcClave)
            .SetFocusedRowCellValue(.Columns("strData"), vpcData)
            .SetFocusedRowCellValue(.Columns("nCantidad"), funNull2Val(vpnSaldo))
            '--
            .UpdateCurrentRow()
        End With
        If Me.gvDetalle.RowCount > 0 Then
            Dim nRecords As Integer
            nRecords = Me.gvDetalle.RowCount
        End If
    End Sub

    Public vpcClave As String
    Public vpcData As String
    Public vpnSaldo As Double

    Private Function funCargaData()
        '-- Cargamos data
        Try
            '--
            Dim dsHead As New DataSet
            Dim dr As DataRow
            '-- Le pasamos el codigo del producto que viene del formulario frmRepSearchItem
            dsHead = clsProducto.funGetProductoDS(intEmpresa, vnProducto)
            '--
            If dsHead.Tables(0).Rows.Count >= 1 Then
                '-- Asignamos un datarow
                dr = dsHead.Tables(0).Rows(0)
                '-- Iniciamos enlaze
                vpcClave = dr("strClave").ToString
                vpcData = dr("strData").ToString
                vpnSaldo = dr("nSaldo")
                '--
            End If
            '--
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return True
    End Function

    Private Sub funUpdateGrid()
        '--
        strSQL = "SELECT * " & _
                    "FROM Inv_Movto_Inventario_Detalle " & _
                    "WHERE nNumero = " & Me.vnNumero & " " & _
                    "ORDER BY nRecno"
        '--
        ds = funFillDataSet(strSQL)
        '--
        Me.gcDetalle.DataSource = funFillDataSet(strSQL).Tables(0)
        '--
        GridViewStyle(Me.gvDetalle)
        funOcultarTodasLasColumnas(Me.gvDetalle)
        indice = 0
        '--
        funSetColumna(gvDetalle, "nCode", "No.", funIndice(), 60, 1)
        funSetColumna(gvDetalle, "strClave", "Cod.", funIndice(), 100, 1)
        funSetColumna(gvDetalle, "strData", "Descripción", funIndice(), 400, 1)
        funSetColumna(gvDetalle, "nCantidad", "Saldo", funIndice(), 100, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
        '--
    End Sub

    Private Sub bbPrint_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbPrint.ItemClick
        funProcesaChekados()
        If funValidar() = True Then
            Me.Cursor = Cursors.WaitCursor
            funImprimir()
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Function funValidar() As Boolean
        If Len(Trim(Me.txtCrono.Text)) = 0 Then
            Me.txtDestino1.Focus()
            MsgBox("Falta cronológico !!!", MsgBoxStyle.Critical, "Atención !!!")
            Return False
        ElseIf Len(Trim(Me.txtDestino1.Text)) = 0 Then
            Me.txtDestino1.Focus()
            MsgBox("Falta destino !!!", MsgBoxStyle.Critical, "Atención !!!")
            Return False
        ElseIf Len(Trim(Me.txtRemite1.Text)) = 0 Then
            Me.txtDestino1.Focus()
            MsgBox("Falta remitente !!!", MsgBoxStyle.Critical, "Atención !!!")
            Return False
        ElseIf Trim(strChekados).Length = 0 Then
            Me.gcDetalle.Focus()
            MsgBox("Falta seleccionar el producto !!!", MsgBoxStyle.Critical, "Atención !!!")
            Return False
        End If
        Return True
    End Function

    Private Function funImprimir()
        '--
        Dim lstParametros As New List(Of String)
        '--
        lstParametros.Add(intEmpresa.ToString)
        lstParametros.Add(Me.strChekados.ToString)
        lstParametros.Add(strUser.ToString)
        lstParametros.Add(Me.dtpDesde.Value.Date)
        lstParametros.Add(Me.txtDestino1.Text.ToString)
        lstParametros.Add(Me.txtDestino2.Text.ToString)
        lstParametros.Add(Me.txtRemite1.Text.ToString)
        lstParametros.Add(Me.txtRemite2.Text.ToString)
        lstParametros.Add(Me.txtCrono.Text.ToString)
        funPrintConSp("repCertExisteItemNo.rpt", lstParametros)
        '--
        Return True
    End Function

    'Private Function funImprimir()
    '    '--
    '    Me.tsCa rgando.Visible = True
    '    Dim strDesde As String = Me.dtpFecha1.Value.Date
    '    Dim strHasta As String = Me.dtpFecha2.Value.Date
    '    '--
    '    Dim dsReporte As New DataSet
    '    dsReporte = clsReporte.funGetDataRepMovDetalle(intEmpresa, strDesde, strHasta, strChekados)
    '    If dsReporte.Tables(0).Rows.Count > 0 Then
    '        '-- Cargamos los datos
    '        funPrintXml(dsReporte, "repMovDetalleConsol.rpt")
    '        Me.tsCargando.Visible = False
    '    Else
    '        Me.tsCargando.Visible = False
    '        MsgBox("No existen datos !!!", MsgBoxStyle.Information, "Atención !!!")
    '    End If
    '    Return True
    '    '--
    'End Function

    Private Function funProcesaChekados()
        strChekados = ""
        Dim nCambios As Integer = 0
        With Me.gvDetalle
            For i As Integer = 0 To .RowCount - 1
                strChekados += IIf(nCambios > 0, ",", "")
                strChekados += .GetDataRow(i)("nCode").ToString
                nCambios += 1
            Next
            If Trim(strChekados).Length > 0 Then
                strChekados = IIf(Mid(strChekados, Len(strChekados), 1) = ",", Mid(strChekados, 1, Len(strChekados) - 1), strChekados)
            End If
        End With
        Return True
    End Function

End Class