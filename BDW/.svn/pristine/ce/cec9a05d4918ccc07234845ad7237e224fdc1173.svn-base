Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Neodynamic.WinControls.BarcodeProfessional


Public Class frmDespachos
    Dim ds As New DataSet
    Dim vn_Pedido As Integer
    Dim vn_Sucursal As Integer

    Private Sub frmPedidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        funInivar()
    End Sub
    Private Sub funInivar()
        Me.bbPrint.Enabled = False
        '--
        BarcodeProfessional.LicenseOwner = "Logical Data Technology-Standard Edition-Developer License"
        BarcodeProfessional.LicenseKey = "YH4NZRUPCQQLSS2FNQ3M59ZUNCX28SLHRNBDSAMGLLM26MMNYHDQ"
        '--
        funCargaCombos()
        Me.lkFormato.EditValue = 1
        '--
    End Sub

    Private Function funCargaCombos()
        '-- Formato
        strSQL = "SELECT nCodigo AS nCodigo, strData AS strDescripcion FROM GB_Formato WHERE nCodigo IN(1,2,3) ORDER BY nCodigo"
        '--
        funCargarLue(Me.lkFormato, strSQL)
        '--
        Return True
    End Function

    Private Sub lkFormato_EditValueChanged(sender As Object, e As EventArgs) Handles lkFormato.EditValueChanged
        funCargaSucursal()
        Me.gcDetalle.DataSource = Nothing
    End Sub

    Private Function funCargaSucursal()
        If Me.lkFormato.EditValue = 1 Then
            strSQL = "SELECT 0 AS nCodigo, 'Todos' AS strDescripcion"
            strSQL += " UNION SELECT Suc_Id AS nCodigo, Suc_Nombre AS strDescripcion FROM vw_GB_Suc_Con_Pedido WHERE Suc_Nombre LIKE '%MM%' ORDER BY nCodigo"
        ElseIf Me.lkFormato.EditValue = 2 Then
            strSQL = "SELECT 0 AS nCodigo, 'Todos' AS strDescripcion"
            strSQL += " UNION SELECT Suc_Id AS nCodigo, Suc_Nombre AS strDescripcion FROM vw_GB_Suc_Con_Pedido WHERE Suc_Nombre LIKE '%MC%' ORDER BY nCodigo"
        ElseIf Me.lkFormato.EditValue = 3 Then
            strSQL = "SELECT 0 AS nCodigo, 'Todos' AS strDescripcion"
            strSQL += " UNION SELECT Suc_Id AS nCodigo, Suc_Nombre AS strDescripcion FROM vw_GB_Suc_Con_Pedido WHERE Suc_Nombre LIKE '%SHOPPERS%' ORDER BY nCodigo"
        Else
            strSQL = "SELECT 0 AS nCodigo, 'Todos' AS strDescripcion"
            strSQL += " UNION SELECT Suc_Id AS nCodigo, Suc_Nombre AS strDescripcion FROM vw_GB_Suc_Con_Pedido WHERE Suc_Nombre LIKE '%Todos%' ORDER BY nCodigo"
        End If
        '-- 27-04-2017: Se usa cdbl() cuando es un valor que viene de una tabla como smallint
        funCargarLue(Me.lkSucursal, strSQL)
        '--
        lkSucursal.EditValue = CDbl(1)
        '--
        '--
        Return True
    End Function

    Private Sub bbPrint_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbPrint.ItemClick
        '-- Tomamos el pedido
        funGetPedido()
        '-- Dividimos el pedido y lo movemos a preparacion
        If bolMovePedido = True Then
            '--
            clsPedidos.funNextProcesoPedidos(1, 1001, vn_Sucursal, vn_Pedido, nUserCode, 0)
            '--
            funPrint()
        End If
        '--
    End Sub

    Private Sub bbClose_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbClose.ItemClick
        Me.Close()
    End Sub

    Private Sub bbRefresh_Click(sender As Object, e As EventArgs) Handles bbRefresh.Click
        If funValidar() = True Then
            funUpdateGrid()
        End If
    End Sub

    Private Function funValidar() As Boolean
        If Len(Trim(Me.lkSucursal.Text)) = 0 Then
            Me.lkSucursal.Focus()
            MsgBox("Falta la Sucursal!", MsgBoxStyle.Critical, "Atención !!!")
            Return False
        End If
        Return True
    End Function

    Private Function funUpdateGrid() As Boolean
        '-- Carga datos        
        Me.bbPrint.Enabled = True
        '--
        Me.Cursor = Cursors.WaitCursor
        '--
        Me.gcDetalle.DataSource = Nothing
        ds = clsPedidos.funRepDespachosLista(lkSucursal.EditValue)
        '-- 
        Me.Cursor = Cursors.Default
        '--
        If ds.Tables(0).Rows.Count = 0 Then
            Me.bbPrint.Enabled = False
            MsgBox("No existen registros!!!")
            Return False
        End If
        '--
        Me.gcDetalle.DataSource = ds.Tables(0)
        '--
        GridViewStyle(Me.gvDetalle)
        funOcultarTodasLasColumnas(Me.gvDetalle)
        indice = 0
        '--
        funSetColumna(gvDetalle, "Sucursal", "Sucursal", funIndice(), 150, 1)
        funSetColumna(gvDetalle, "Pedido", "Pedido", funIndice(), 90, 1)
        funSetColumna(gvDetalle, "Fecha", "Fecha", funIndice(), 90, 1, , , "d", 0, , DevExpress.Utils.FormatType.DateTime)
        funSetColumna(gvDetalle, "Estado", "Estado", funIndice(), 80, 1)
        funSetColumna(gvDetalle, "Lineas", "Lineas", funIndice(), 80, 1)
        Return True
    End Function
    Private Sub funGetPedido()
        With Me.gvDetalle
            If .FocusedRowHandle >= 0 Then
                vn_Sucursal = funNull2Val(.GetFocusedRowCellValue("Suc_Id"))
                vn_Pedido = funNull2Val(.GetFocusedRowCellValue("Pedido"))
            Else
                MsgBox("Debe seleccionar un Registro !!!", MsgBoxStyle.Information, "Atención !!!")
            End If
        End With
    End Sub
    Private Function funPrint()
        '--
        Dim dsReporte As DataSet
        '--
        dsReporte = clsPedidos.funDespacho_BarCode(vn_Sucursal, vn_Pedido)
        '--
        If dsReporte.Tables(0).Rows.Count = 0 Then
            MsgBox("No existen registros!!!")
            Return False
        End If
        'Create an instance of Barcode Professional
        Dim bcp As New Neodynamic.WinControls.BarcodeProfessional.BarcodeProfessional()
        'Barcode settings
        bcp.Symbology = Neodynamic.WinControls.BarcodeProfessional.Symbology.Code39
        bcp.Extended = True
        bcp.AddChecksum = False
        bcp.BarHeight = 0.4F
        bcp.QuietZoneWidth = 0
        '--
        Dim row As DataRow
        'Update Customers DataTable with barcode image
        For Each row In dsReporte.Tables(0).Rows
            'Set the value to encode
            bcp.Code = row("Suc_Id").ToString() + "" + row("Pedido").ToString()
            'Generate the barcode image and store it into the Barcode Column
            row("Barcode") = bcp.GetBarcodeImage(System.Drawing.Imaging.ImageFormat.Png)
        Next
        '-- Reporte
        'funPrintXml(dsReporte, "Pedido_Ticket_v3_1.rpt")
        funPrintXml(dsReporte, "Pedido_Ticket_v5.rpt")
        '--
        Return True
    End Function

    Private Sub lkSucursal_EditValueChanged(sender As Object, e As EventArgs) Handles lkSucursal.EditValueChanged
        Me.bbPrint.Enabled = False
        Me.gcDetalle.DataSource = Nothing
    End Sub

End Class