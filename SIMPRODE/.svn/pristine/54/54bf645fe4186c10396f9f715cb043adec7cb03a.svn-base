Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmRepFacturasNC
    '--
    Dim ds As New DataSet

    Private Sub frmRepFacturasNC_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmRepFacturasNC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        funIniVar()
    End Sub
    Private Function funIniVar()
        '--
        Try
            '--
            funCargaCombos()
            Me.lkSucursal.EditValue = 1
            '--
        Catch ex As Exception
            MsgBox("Se ha producido el siguiente error: " + ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            '-- Apagar botones
        End Try
        '--
        Return True
    End Function

    Private Function funCargaCombos()
        '-- Cargar Empresa
        strSQL = "SELECT Suc_Id AS nCodigo, Suc_Nombre AS strDescripcion FROM vw_GB_Sucursales ORDER BY nCodigo"
        '--
        funCargarLue(Me.lkSucursal, strSQL)
        '-- Carga Proveedores
        strSQL = "SELECT Tipo_Id AS nCodigo, Tipo_Nombre AS strDescripcion FROM Tipo_Documento WHERE Tipo_Id >= 3 and Tipo_Id <= 4 ORDER BY nCodigo"
        '--
        funCargarLue(Me.lkTipo, strSQL)
        '--
        Return True
    End Function

    Private Function funValidar() As Boolean
        If Len(Trim(Me.lkSucursal.Text)) = 0 Then
            Me.lkSucursal.Focus()
            MsgBox("Falta la sucursal!", MsgBoxStyle.Critical, "Atención !!!")
            Return False
        ElseIf Len(Trim(Me.lkTipo.Text)) = 0 Then
            Me.lkTipo.Focus()
            MsgBox("Falta el tipo!", MsgBoxStyle.Critical, "Atención !!!")
            Return False
        End If
        Return True
    End Function

    Private Sub bbRefresh_Click(sender As Object, e As EventArgs) Handles bbRefresh.Click
        If funValidar() = True Then
            funUpdateGrid()
        End If
    End Sub

    Private Function funUpdateGrid() As Boolean
        '--
        strSQL = "SELECT * FROM vw_GB_Factura_Cliente " &
                    " WHERE Suc_Id = " & lkSucursal.EditValue &
                    " AND Tipo_Id = " & lkTipo.EditValue

        '--
        ds = funFillDataSet(strSQL)
        '--
        Me.gcDetalle.DataSource = funFillDataSet(strSQL).Tables(0)
        '--
        GridViewStyle(Me.gvDetalle)
        funOcultarTodasLasColumnas(Me.gvDetalle)
        indice = 0
        '--
        funSetColumna(gvDetalle, "Factura_Id", "Factura_Id", funIndice(), 80, 1)
        funSetColumna(gvDetalle, "Factura_Fecha", "Factura_Fecha", funIndice(), 90, 1, , , "d", 0, , DevExpress.Utils.FormatType.DateTime)
        funSetColumna(gvDetalle, "Factura_Total", "Total", funIndice(), 120, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
        funSetColumna(gvDetalle, "Cliente_Nombre", "Cliente", funIndice(), 300, 1)
        Return True
    End Function

    Private Sub bClose_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bClose.ItemClick
        Me.Close()
    End Sub

    Dim vn_Factura_Id
    Private Sub bPrint_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bPrint.ItemClick
        funGetArticulo()
        If Validar() = True Then
            Me.Cursor = Cursors.WaitCursor
            Dim lstParametros As New List(Of String)
            lstParametros.Add(Me.lkSucursal.EditValue.ToString)
            lstParametros.Add(Me.vn_Factura_Id.ToString)
            lstParametros.Add(Me.lkTipo.EditValue.ToString)
            '--
            If Me.lkTipo.EditValue = 3 Then
                If Me.optOpcion.SelectedIndex = 0 Then
                    funPrintConSp("Factura_mm_nc.rpt", lstParametros)
                Else
                    funPrintConSp("Factura_mm_nc2.rpt", lstParametros)
                End If
            Else
                If Me.optOpcion.SelectedIndex = 0 Then
                    funPrintConSp("Factura_mm_fac.rpt", lstParametros)
                Else
                    funPrintConSp("Factura_mm_fac2.rpt", lstParametros)
                End If
            End If
            Me.Cursor = Cursors.Default
        End If
    End Sub
    Private Sub funGetArticulo()
        With Me.gvDetalle
            If .FocusedRowHandle >= 0 Then
                vn_Factura_Id = funNull2Val(.GetFocusedRowCellValue("Factura_Id"))
            Else
                MsgBox("Debe seleccionar un Registro !!!", MsgBoxStyle.Information, "Atención !!!")
            End If
        End With
    End Sub

    Private Function Validar() As Boolean
        '-- Cuando es por empleado
        If Len(Trim(Me.lkSucursal.Text)) = 0 Then
            Me.lkSucursal.Focus()
            MsgBox("Falta seleccionar la tienda !!!", MsgBoxStyle.Critical, "Atención !")
            Return False
        ElseIf Len(Trim(Me.lkTipo.Text)) = 0 Then
            Me.lkSucursal.Focus()
            MsgBox("Falta seleccionar el tipo!!!", MsgBoxStyle.Critical, "Atención !")
            Return False
        ElseIf Len(vn_Factura_Id) = 0 Then
            Me.lkSucursal.Focus()
            MsgBox("Falta seleccionar el Artículo!", MsgBoxStyle.Critical, "Atención !")
            Return False
        End If
        Return True
    End Function
End Class