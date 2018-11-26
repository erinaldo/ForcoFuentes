Imports System
Imports System.Data
Imports System.Data.SqlClient


Public Class frmRepProveedor2

    Dim ds As New DataSet
    Dim nTipoMovGrid As Integer
    Dim i As Integer
    Dim vnlProveedor As Integer
    Dim strChekados As String
    Dim dsReporte As DataSet
    Dim strCommonColumnName As String

    Dim FilePath As String

    Private Sub frmRepProveedor2_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
        '--
        Select Case e.KeyCode
            Case Keys.F1
                subAdd()
            Case Keys.F2
                funDeleteRow()
            Case Keys.F3
                '-- subKardex()
        End Select
    End Sub

    Private Sub frmRepProveedor2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        funUpdateGrid()
    End Sub

    Private Sub bbAdd_Click(sender As System.Object, e As System.EventArgs) Handles bbAdd.Click
        subAdd()
    End Sub

    Private Sub subAdd()
        Dim f As New frmRepSeekProveedor
        f.barText.Text = "Agregando Proveedor"
        f.ShowDialog()
        '--
        If bolFound = True Then
            nTipoMovGrid = 1
            funCargaData()
            funCargaGrid()
        End If
        '--
    End Sub

    Private Sub funCargaGrid()
        '-- 
        With Me.gvDetalle
            For i = 0 To Me.gvDetalle.RowCount - 1
                If vnProveedor = Me.gvDetalle.GetRowCellValue(i, "Prov_Id") And nTipoMovGrid = 1 Then
                    MsgBox("Este proveedor ya esta seleccionado !!!", MsgBoxStyle.Information, "Atención")
                    Exit Sub
                End If
            Next
            If nTipoMovGrid = 1 Then
                .AddNewRow()
            End If
            .SetFocusedRowCellValue(.Columns("Prov_Id"), vnProveedor)
            .SetFocusedRowCellValue(.Columns("Prov_Nombre"), vpcClave)
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
            dsHead = clsProveedor.funGetProveedorDS(vnProveedor)
            '--
            If dsHead.Tables(0).Rows.Count >= 1 Then
                '-- Asignamos un datarow
                dr = dsHead.Tables(0).Rows(0)
                '-- Iniciamos enlaze
                vpcClave = dr("Prov_Nombre").ToString
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
                   "FROM vw_GB_ProveedorConMovto " & _
                   "WHERE Prov_Id = " & vnlProveedor & " " & _
                   "ORDER BY Prov_Nombre"

        ds = funFillDataSet(strSQL)
        '--
        Me.gcDetalle.DataSource = funFillDataSet(strSQL).Tables(0)
        '--
        GridViewStyle(Me.gvDetalle)
        funOcultarTodasLasColumnas(Me.gvDetalle)
        indice = 0
        '--
        funSetColumna(gvDetalle, "Prov_Id", "No.", funIndice(), 60, 1)
        funSetColumna(gvDetalle, "Prov_Nombre", "Nombre", funIndice(), 400, 1)
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

    Private Function funImprimir()
        '--
        Dim lstParametros As New List(Of String)
        '--
        lstParametros.Add(Me.cbDollar.Value.ToString)
        lstParametros.Add(Me.dtpDesde1.Value.Date)
        lstParametros.Add(Me.dtpHasta1.Value.Date)
        lstParametros.Add(Me.dtpDesde2.Value.Date)
        lstParametros.Add(Me.dtpHasta2.Value.Date)
        lstParametros.Add(Me.strChekados.ToString)
        funPrintConSp("repComprasProveedor-v1.rpt", lstParametros)
        '--
        Return True
    End Function

    Private Function funProcesaChekados()
        strChekados = ""
        Dim nCambios As Integer = 0
        With Me.gvDetalle
            For i As Integer = 0 To .RowCount - 1
                strChekados += IIf(nCambios > 0, ",", "")
                strChekados += .GetDataRow(i)("Prov_Id").ToString
                nCambios += 1
            Next
            If Trim(strChekados).Length > 0 Then
                strChekados = IIf(Mid(strChekados, Len(strChekados), 1) = ",", Mid(strChekados, 1, Len(strChekados) - 1), strChekados)
            End If
        End With
        Return True
    End Function

    Private Function funValidar() As Boolean
        If Trim(strChekados).Length = 0 Then
            Me.gcDetalle.Focus()
            MsgBox("Falta seleccionar el proveedor !!!", MsgBoxStyle.Critical, "Atención !!!")
            Return False
        ElseIf Me.cbDollar.Value = 0 Then
            Me.cbDollar.Focus()
            MsgBox("Falta el tipo de cambio !!!", MsgBoxStyle.Critical, "Atención !!!")
            Return False
        End If
        Return True
    End Function

    Private Sub bClose_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bClose.ItemClick
        Me.Close()
    End Sub

    Private Sub bbDelete_Click(sender As Object, e As EventArgs) Handles bbDelete.Click
        funDeleteRow()
    End Sub

    Dim r As Integer
    Private Sub funDeleteRow()
        '-- Borrar una fila del gridview
        If Me.gvDetalle.FocusedRowHandle >= 0 Then
            r = Me.gvDetalle.FocusedRowHandle
            If Me.gvDetalle.IsRowSelected(r) Then
                If (MessageBox.Show("¿Desea eliminar la fila?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes) Then
                    Me.gvDetalle.DeleteRow(r)
                End If
            End If
        End If
    End Sub

    Private Sub gcDetalle_KeyDown(sender As Object, e As KeyEventArgs) Handles gcDetalle.KeyDown
        If (e.KeyCode = Keys.Delete) Then
            funDeleteRow()
        End If
    End Sub

    Private Sub bbRefresh_Click(sender As Object, e As EventArgs) Handles bbRefresh.Click
        funProcesaChekados()
        If funValidar() = True Then
            funUpdateGrid2()
        End If
    End Sub

    Private Sub funUpdateGrid2()
        '--
        Try
            '-- Carga datos
            Me.Cursor = Cursors.WaitCursor
            Me.gcDetalle2.DataSource = Nothing
            funCargaData2()
            Me.Cursor = Cursors.Default
            '--
            Me.gcDetalle2.DataSource = dsReporte.Tables(0)
            '--
            GridViewStyle(Me.gvDetalle2)
            funOcultarTodasLasColumnas(Me.gvDetalle2)
            indice = 0
            '--
            funSetColumna(gvDetalle2, "COD.", "COD.", funIndice(), 90, 1)
            funSetColumna(gvDetalle2, "ARTICULO", "ARTICULO", funIndice(), 120, 1)
            funSetColumna(gvDetalle2, "ITEM", "ITEM", funIndice(), 90, 1)
            funSetColumna(gvDetalle2, "U.C.PROVEEDOR", "U.C.PROVEEDOR", funIndice(), 90, 1)
            funSetColumna(gvDetalle2, "U.F.COMPRA", "U.F.COMPRA", funIndice(), 90, 1, , , "d", 0, , DevExpress.Utils.FormatType.DateTime)
            funSetColumna(gvDetalle2, "UXB", "UXB", funIndice(), 80, 1, , , "n0", 0, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle2, "C.ACTIVO", "C.ACTIVO", funIndice(), 80, 1)
            funSetColumna(gvDetalle2, "C.BULTO", "C.BULTO", funIndice(), 80, 1, , , "n0", 0, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle2, "C.UNIDAD", "C.UNIDAD", funIndice(), 80, 1, , , "n0", 0, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle2, "U.E.BULTO", "U.E.BULTO", funIndice(), 80, 1, , , "n0", 0, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle2, "U.E.UNIDAD", "U.E.UNIDAD", funIndice(), 80, 1, , , "n0", 0, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle2, "VENTA BULTO", "VENTA BULTO", funIndice(), 100, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle2, "VENTA UNIDAD", "VENTA UNIDAD", funIndice(), 100, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle2, "VALOR VENTAS", "VALOR VENTAS", funIndice(), 100, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle2, "MARGEN UTILIDAD", "MARGEN UTILIDAD", funIndice(), 100, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle2, "% MARGEN UTILIDAD", "% MARGEN UTILIDAD", funIndice(), 80, 1, , , "P", 3, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle2, "S.BULTO", "S.BULTO", funIndice(), 80, 1, , , "n0", 0, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle2, "S.UNIDAD", "S.UNIDAD", funIndice(), 80, 1, , , "n0", 0, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle2, "CEDI BULTO", "CEDI BULTO", funIndice(), 80, 1, , , "n0", 0, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle2, "CEDI UNIDAD", "CEDI UNIDAD", funIndice(), 80, 1, , , "n0", 0, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle2, "COSTO", "COSTO", funIndice(), 80, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle2, "MAYOR", "MAYOR", funIndice(), 80, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle2, "DETALLE", "DETALLE", funIndice(), 80, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle2, "COSTO $", "COSTO $", funIndice(), 80, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle2, "PESO", "PESO", funIndice(), 80, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle2, "M3", "M3", funIndice(), 80, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle2, "DEPARTAMENTO", "DEPARTAMENTO", funIndice(), 90, 1)
            funSetColumna(gvDetalle2, "FECHA COMPARATIVO", "FECHAS COMPRAS", funIndice(), 90, 1)
            funSetColumna(gvDetalle2, "FECHA MARGEN", "FECHAS VENTAS", funIndice(), 90, 1)
            '--
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        '--
    End Sub

    Private Sub funCargaData2()
        '-- Procesamos el SP, para cargar datos
        Dim CMD As New SqlCommand("sp_RepComprasSaldosMargenProvee")
        '--
        Dim nDollar As Double = Me.cbDollar.Value.ToString
        Dim strChekadosFull As String = Trim(strChekados.ToString)

        Dim dtmRango1 As DateTime
        Dim dtmRango2 As DateTime
        Dim dtmMargen1 As DateTime
        Dim dtmMargen2 As DateTime

        dtmRango1 = Me.dtpDesde1.Value.Date
        dtmRango2 = Me.dtpHasta1.Value.Date
        dtmMargen1 = Me.dtpDesde2.Value.Date
        dtmMargen2 = Me.dtpHasta2.Value.Date

        '-- Cargar con timeout
        CMD.Parameters.Add("@dollar", SqlDbType.Decimal).Value = nDollar
        CMD.Parameters.Add("@date1", SqlDbType.Date).Value = dtmRango1
        CMD.Parameters.Add("@date2", SqlDbType.Date).Value = dtmRango2
        CMD.Parameters.Add("@datemargen1", SqlDbType.Date).Value = dtmMargen1
        CMD.Parameters.Add("@datemargen2", SqlDbType.Date).Value = dtmMargen2
        CMD.Parameters.Add("@ids", SqlDbType.NVarChar, 3000).Value = strChekadosFull
        '--
        dsReporte = ExecuteCMD(CMD)
        '-- 02-09-2016: Validar si no existen registros, verificar otros problemas
        If dsReporte.Tables(0).Rows.Count = 0 Then
            MsgBox("No existen registros!!!")
            Exit Sub
        End If
        '-
    End Sub

    Function ExecuteCMD(ByRef CMD As SqlCommand) As DataSet
        '--
        Dim connectionString As String = funConexion()
        Dim ds As New DataSet()
        Try
            Dim connection As New SqlConnection(connectionString)
            CMD.Connection = connection
            'Assume that it's a stored procedure command type if there is no space in the command text. Example: "sp_Select_Customer" vs. "select * from Customers"
            If CMD.CommandText.Contains(" ") Then
                CMD.CommandType = CommandType.Text
            Else
                CMD.CommandType = CommandType.StoredProcedure
            End If
            Dim adapter As New SqlDataAdapter(CMD)
            adapter.SelectCommand.CommandTimeout = 900
            'fill the dataset
            adapter.Fill(ds)
            connection.Close()
        Catch ex As Exception
            ' The connection failed. Display an error message.
            Throw New Exception("Database Error: " & ex.Message)
        End Try
        Return ds
    End Function

    Private Sub bbExcel_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbExcel.ItemClick
        If Me.gvDetalle2.RowCount = 0 Then
            MsgBox("No Existen Registros ... !!!", MsgBoxStyle.Critical, "Información")
            Exit Sub
        End If
        Try
            FilePath = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
            Dim strFileName As String = FilePath & "\RepProveedor.xlsx"
            Me.gcDetalle2.ExportToXlsx(strFileName)
            System.Diagnostics.Process.Start(strFileName)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub bbClear_Click(sender As Object, e As EventArgs) Handles bbClear.Click
        Me.gcDetalle2.DataSource = Nothing
    End Sub
End Class