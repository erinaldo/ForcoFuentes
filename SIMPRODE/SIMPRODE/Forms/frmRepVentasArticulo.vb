Imports System.IO
Imports OfficeOpenXml
Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmRepVentasArticulo

    Dim ds As New DataSet
    Dim nTipoMovGrid As Integer
    Dim i As Integer
    Dim vclArticulo As String
    Dim strChekados As String
    Dim strChekados2 As String
    '--
    Dim r As Integer
    Dim dtListaArticulos As DataTable
    Dim strFiltroDataTable As String
    Dim f As FolderBrowserDialog

    Dim dsReporte As DataSet

    Dim FilePath As String

    Private Sub frmRepVentasArticulo_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub frmRepVentasArticulo_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        funUpdateGrid()
        funUpdateGrid_Suc()
    End Sub

    Private Function funUpdateGrid_Suc()
        Try
            ds = clsSucursal.funListaSucursal()
            Me.gcLista2.DataSource = ds.Tables(0)
            '--
            funDxGrid(Me.gvLista2, 1, False, False, False, 0, False, False, False)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return True
    End Function

    Private Sub bbAdd_Click(sender As System.Object, e As System.EventArgs) Handles bbAdd.Click
        subAdd()
    End Sub

    Private Sub subAdd()
        Dim f As New frmRepSeekArticulo
        f.barText.Text = "Agregando Articulo"
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
                If vnProveedor = Me.gvDetalle.GetRowCellValue(i, "Articulo_Id") And nTipoMovGrid = 1 Then
                    MsgBox("Este articulo ya esta seleccionado !!!", MsgBoxStyle.Information, "Atención")
                    Exit Sub
                End If
            Next
            If nTipoMovGrid = 1 Then
                .AddNewRow()
            End If
            .SetFocusedRowCellValue(.Columns("Articulo_Id"), vcArticulo)
            .SetFocusedRowCellValue(.Columns("Articulo_Nombre"), vpcClave)
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
            dsHead = clsProducto.funGetProductoDS(vcArticulo)
            '--
            If dsHead.Tables(0).Rows.Count >= 1 Then
                '-- Asignamos un datarow
                dr = dsHead.Tables(0).Rows(0)
                '-- Iniciamos enlaze
                vpcClave = dr("Articulo_Nombre").ToString
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
        dtListaArticulos = New DataTable
        If dtListaArticulos.Rows.Count >= 0 Then
            '-- Convierte datatable a dataset
            '-- ds.Merge(dtListaArticulos)
            '-- Carga procedimiento almacenado, para lograr hacer el split
            ds = clsArticulo.funGetArticuloFromExcel(Trim(strFiltroDataTable))

        Else
            '-- Carga normal
            strSQL = "SELECT * FROM Articulo_Info WHERE Articulo_Id = '" & vclArticulo & "'"
            '--
            ds = funFillDataSet(strSQL)
            '--
        End If
        '--
        '--Me.gcDetalle.DataSource = funFillDataSet(strSQL).Tables(0)
        Me.gcDetalle.DataSource = ds.Tables(0)
        '--
        GridViewStyle(Me.gvDetalle)
        funOcultarTodasLasColumnas(Me.gvDetalle)
        indice = 0
        '--
        funSetColumna(gvDetalle, "Articulo_Id", "ID", funIndice(), 60, 1)
        funSetColumna(gvDetalle, "Articulo_Nombre", "Articulo", funIndice(), 400, 1)
        '--
    End Sub

    Private Sub bbRefresh_Click(sender As Object, e As EventArgs) Handles bbRefresh.Click
        funProcesaChekados()
        funProcesaChekados2()
        If funValidar() = True Then
            funUpdateGrid2()
        End If
    End Sub

    Private Function funValidar() As Boolean
        If Trim(strChekados).Length = 0 Then
            Me.gcDetalle.Focus()
            MsgBox("Falta seleccionar el Articulo !!!", MsgBoxStyle.Critical, "Atención !!!")
            Return False
        ElseIf Me.cbDollar.Value = 0 Then
            Me.cbDollar.Focus()
            MsgBox("Falta el tipo de cambio !!!", MsgBoxStyle.Critical, "Atención !!!")
            Return False
        End If
        Return True
    End Function

    Private Function funProcesaChekados()
        strChekados = ""
        Dim nCambios As Integer = 0
        With Me.gvDetalle
            For i As Integer = 0 To .RowCount - 1
                strChekados += IIf(nCambios > 0, ",", "")
                strChekados += .GetDataRow(i)("Articulo_Id").ToString
                nCambios += 1
            Next
            If Trim(strChekados).Length > 0 Then
                strChekados = IIf(Mid(strChekados, Len(strChekados), 1) = ",", Mid(strChekados, 1, Len(strChekados) - 1), strChekados)
            End If
        End With
        Return True
    End Function

    Private Function funProcesaChekados2()
        strChekados2 = ""
        Dim nCambios2 As Integer = 0
        With Me.gvLista2
            For i As Integer = 0 To .RowCount - 1
                If Convert.ToBoolean(.GetDataRow(i)("optSelection")) = True Then
                    strChekados2 += IIf(nCambios2 > 0, ",", "")
                    strChekados2 += .GetDataRow(i)("Suc_Id").ToString
                    nCambios2 += 1
                End If
            Next
            If Trim(strChekados2).Length > 0 Then
                strChekados2 = IIf(Mid(strChekados2, Len(strChekados2), 1) = ",", Mid(strChekados2, 1, Len(strChekados2) - 1), strChekados2)
            End If
        End With
        Return True
    End Function

    Private Sub bClose_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bClose.ItemClick
        Me.Close()
    End Sub

    Private Sub bbExcel_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbExcel.ItemClick
        If Me.gvDetalle2.RowCount = 0 Then
            MsgBox("No Existen Registros ... !!!", MsgBoxStyle.Critical, "Información")
            Exit Sub
        End If
        Try
            FilePath = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
            Dim strFileName As String = FilePath & "\RepVentasPorArticulo.xlsx"
            Me.gcDetalle2.ExportToXlsx(strFileName)
            System.Diagnostics.Process.Start(strFileName)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub gcDetalle_KeyDown(sender As Object, e As KeyEventArgs) Handles gcDetalle.KeyDown
        If (e.KeyCode = Keys.Delete) Then
            funDeleteRow()
        End If
    End Sub
    Private Sub bbDelete_Click(sender As Object, e As EventArgs) Handles bbDelete.Click
        funDeleteRow()
    End Sub

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

    Private Sub bbImport_Click(sender As Object, e As EventArgs) Handles bbImport.Click
        Dim openFileDialog1 As New OpenFileDialog()
        openFileDialog1.Filter = "Excel File (*.xlsx)|*.xlsx"
        openFileDialog1.FilterIndex = 1

        If openFileDialog1.ShowDialog() = DialogResult.OK Then
            Try
                Using pck = New ExcelPackage()
                    Using stream = File.OpenRead(openFileDialog1.FileName)
                        pck.Load(stream)
                    End Using

                    Dim ws As ExcelWorksheet = pck.Workbook.Worksheets.First()
                    '-- DataGridView1.DataSource = WorksheetToDataTable(ws)
                    dtListaArticulos = WorksheetToDataTable(ws)
                    funCargaDatosComma()
                End Using
            Catch ex As Exception
                MsgBox("Import failed. Original error: " & ex.Message)
            End Try
        End If
        If dtListaArticulos.Rows.Count > 0 Then
            funUpdateGrid()
        End If
    End Sub

    Private Function WorksheetToDataTable(ByVal ws As ExcelWorksheet, Optional ByVal hasHeader As Boolean = True) As DataTable
        Dim dt As DataTable = New DataTable(ws.Name)
        Dim totalCols As Integer = ws.Dimension.[End].Column
        Dim totalRows As Integer = ws.Dimension.[End].Row
        Dim startRow As Integer = If(hasHeader, 2, 1)
        Dim wsRow As ExcelRange
        Dim dr As DataRow

        For Each firstRowCell In ws.Cells(1, 1, 1, totalCols)
            dt.Columns.Add(If(hasHeader, firstRowCell.Text, String.Format("Column {0}", firstRowCell.Start.Column)))
        Next
        For rowNum As Integer = startRow To totalRows
            wsRow = ws.Cells(rowNum, 1, rowNum, totalCols)
            dr = dt.NewRow()
            For Each cell In wsRow
                dr(cell.Start.Column - 1) = cell.Text
            Next
            dt.Rows.Add(dr)
        Next

        Return dt
    End Function

    Private Sub funCargaDatosComma()
        For Each dr As DataRow In dtListaArticulos.Rows
            '-- Obtenemos el nombre de la primer columna
            Dim nameColumnFirst As String = dr.Table.Columns(0).ColumnName
            '-- Separamos el datatable en un string separado por comas
            strFiltroDataTable = strFiltroDataTable + "," + Convert.ToString(dr(nameColumnFirst))
        Next
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
            funSetColumna(gvDetalle2, "ARTICULO", "ARTICULO", funIndice(), 150, 1)
            funSetColumna(gvDetalle2, "ITEM", "ITEM", funIndice(), 90, 1)
            funSetColumna(gvDetalle2, "U.C.PROVEEDOR", "U.C.PROVEEDOR", funIndice(), 90, 1)
            funSetColumna(gvDetalle2, "U.C.FECHA", "U.C.FECHA", funIndice(), 90, 1, , , "d", 0, , DevExpress.Utils.FormatType.DateTime)
            funSetColumna(gvDetalle2, "U.C.UNIDAD", "U.C.UNIDAD", funIndice(), 100, 1, , , "n0", 0, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle2, "VENTA UNIDAD", "VENTA UNIDAD", funIndice(), 100, 1, , , "n0", 0, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle2, "COSTO TOTAL", "COSTO TOTAL", funIndice(), 100, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle2, "VALOR VENTAS", "VALOR VENTAS", funIndice(), 100, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle2, "MARGEN UTILIDAD", "MARGEN UTILIDAD", funIndice(), 100, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle2, "% MARGEN UTILIDAD", "% MARGEN UTILIDAD", funIndice(), 100, 1, , , "P", 3, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle2, "COSTO_ACTUAL", "COSTO_ACTUAL", funIndice(), 100, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle2, "DEPARTAMENTO", "DEPARTAMENTO", funIndice(), 100, 1)
            funSetColumna(gvDetalle2, "CATEGORIA", "CATEGORIA", funIndice(), 100, 1)
            funSetColumna(gvDetalle2, "SUB-CATEGORIA", "SUB-CATEGORI", funIndice(), 100, 1)
            funSetColumna(gvDetalle2, "FILTRO DE FECHA", "FILTRO DE FECHA", funIndice(), 100, 1)
            '--
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        '--
    End Sub

    Private Sub funCargaData2()
        '-- Procesamos el SP, para cargar datos
        Dim CMD As New SqlCommand("sp_RepVentasDetalleArticulo")
        '--
        Dim nDollar As Double = Me.cbDollar.Value.ToString
        Dim strRango1 As String = funFechaSql(Me.dtpDesde1.Value.Date, True)
        Dim strRango2 As String = funFechaSql(Me.dtpHasta1.Value.Date, True)
        Dim strChekadosFull As String = Trim(strChekados.ToString)
        Dim strChekadosFull_2 As String = Trim(strChekados2.ToString)

        '-- Cargar con timeout
        CMD.Parameters.Add("@dollar", SqlDbType.Decimal).Value = nDollar
        CMD.Parameters.Add("@date1", SqlDbType.NVarChar, 11).Value = strRango1
        CMD.Parameters.Add("@date2", SqlDbType.NVarChar, 11).Value = strRango2
        CMD.Parameters.Add("@ids", SqlDbType.NVarChar, 500000).Value = strChekadosFull
        CMD.Parameters.Add("@ids2", SqlDbType.NVarChar, 3000).Value = strChekadosFull_2
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

    Private Sub bbClear_Click(sender As Object, e As EventArgs) Handles bbClear.Click
        Me.gcDetalle2.DataSource = Nothing
    End Sub

    Private Sub bbAdd2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bbAdd2.Click
        With Me.gvLista2
            For i As Integer = 0 To .RowCount - 1
                .SetRowCellValue(i, "optSelection", True)
            Next
        End With
    End Sub

    Private Sub bbDelete2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bbDelete2.Click
        With Me.gvLista2
            For i As Integer = 0 To .RowCount - 1
                .SetRowCellValue(i, "optSelection", False)
            Next
        End With
    End Sub

    Private Sub gvLista2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gvLista2.Click
        With Me.gvLista2
            If .FocusedColumn.Name = "colOpt1" Then
                .SetFocusedValue(Not Convert.ToBoolean(.GetFocusedRowCellValue("optSelection")))
            End If
        End With
    End Sub

    Private Sub repositoryItemCheckEdit2_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RepositoryItemCheckEdit2.EditValueChanged
        gvLista2.PostEditor()

        ' The UpdateCurrentRow method call is optional for CheckEditor.
        ' Don't call it for Text editors!
        ' gridView1.UpdateCurrentRow();   

        ' TEST:
        'Console.WriteLine(gvLista.GetDataRow(gvLista.FocusedRowHandle)(gvLista.FocusedColumn.FieldName))
    End Sub
End Class