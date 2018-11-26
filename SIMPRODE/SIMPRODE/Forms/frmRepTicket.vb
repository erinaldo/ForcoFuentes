Imports System.IO
Imports OfficeOpenXml
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class frmRepTicket

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

    Private Sub frmRepTicket_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
        '--
    End Sub

    Private Sub frmRepTicket_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        funUpdateGrid_Suc()
    End Sub

    Private Function funUpdateGrid_Suc()
        Try
            ds = clsSucursal.funListaSucursal_Shoppers()
            Me.gcLista2.DataSource = ds.Tables(0)
            '--
            funDxGrid(Me.gvLista2, 1, False, False, False, 0, False, False, False)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return True
    End Function

    Private Sub bbRefresh_Click(sender As Object, e As EventArgs) Handles bbRefresh.Click
        funProcesaChekados2()
        If funValidar() = True Then
            funUpdateGrid()
        End If
    End Sub

    Private Function funValidar() As Boolean
        If Trim(strChekados2).Length = 0 Then
            Me.gcDetalle2.Focus()
            MsgBox("Falta seleccionar la tienda !", MsgBoxStyle.Critical, "Atención !!!")
            Return False
        End If
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
    Private Sub funCargaDatosComma()
        For Each dr As DataRow In dtListaArticulos.Rows
            '-- Obtenemos el nombre de la primer columna
            Dim nameColumnFirst As String = dr.Table.Columns(0).ColumnName
            '-- Separamos el datatable en un string separado por comas
            strFiltroDataTable = strFiltroDataTable + "," + Convert.ToString(dr(nameColumnFirst))
        Next
    End Sub

    Private Sub funCargaData()
        '-- Procesamos el SP, para cargar datos
        Dim strProcedimiento As String = ""
        '-- 
        If Me.optOpcion.SelectedIndex = 0 Then
            strProcedimiento = "sp_RepTicket"
        ElseIf Me.optOpcion.SelectedIndex = 1 Then
            strProcedimiento = "sp_RepTicket_Detalle"
        ElseIf Me.optOpcion.SelectedIndex = 2 Then
            strProcedimiento = "sp_RepTicket_Consolidado"
        End If
        '--
        Dim CMD As New SqlCommand(strProcedimiento)
        '--
        Dim strRango1 As String = funFechaSql(Me.dtpDesde1.Value.Date, True)
        Dim strRango2 As String = funFechaSql(Me.dtpHasta1.Value.Date, True)
        Dim strChekadosFull As String = Trim(strChekados2.ToString)
        '-- Cargar con timeout
        CMD.Parameters.Add("@date1", SqlDbType.NVarChar, 11).Value = strRango1
        CMD.Parameters.Add("@date2", SqlDbType.NVarChar, 11).Value = strRango2
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

    Private Sub bClose_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bClose.ItemClick
        Me.Close()
    End Sub

    Private Sub bbClear_Click(sender As Object, e As EventArgs) Handles bbClear.Click
        Me.gcDetalle2.DataSource = Nothing
    End Sub

    Private Sub bbExcel_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbExcel.ItemClick
        If Me.gvDetalle2.RowCount = 0 Then
            MsgBox("No Existen Registros ... !!!", MsgBoxStyle.Critical, "Información")
            Exit Sub
        End If
        Try
            FilePath = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
            Dim strFileName As String = FilePath & "\RepTicket.xlsx"
            Me.gcDetalle2.ExportToXlsx(strFileName)
            System.Diagnostics.Process.Start(strFileName)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub gvDetalle2_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles gvDetalle2.CustomSummaryCalculate
        '--
        'If DirectCast(e.Item, DevExpress.XtraGrid.GridSummaryItem).FieldName.CompareTo("") = 0 Then
        'Dim totalMarks As Double = Convert.ToDouble(gcTotalMarks.SummaryItem.SummaryValue)
        'Dim marksObtained As Double = Convert.ToDouble(gcMarksObtained.SummaryItem.SummaryValue)
        'If totalMarks <> 0 Then
        'e.TotalValue = marksObtained / totalMarks * 100
        'Else
        'e.TotalValue = 0
        'End If
        'End If
        '--
        '-- Calculamos el margen total de utilidad, para no promediar el % de margen de utilidad
        '-- Poner como CUSTOM la fila de la suma del margen de utilidad
        '-- .Columns("% MARGEN UTILIDAD").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom
        If e.IsTotalSummary Then
            Dim view As GridView = TryCast(sender, GridView)
            Dim decMargenUtilidad As Decimal = Convert.ToDecimal(view.Columns("MARGEN_UTILIDAD").SummaryItem.SummaryValue)
            Dim decVentas As Decimal = Convert.ToDecimal(view.Columns("VENTA_NETA").SummaryItem.SummaryValue)
            Dim decPerdent As Decimal = Convert.ToDecimal(view.Columns("% MARGEN UTILIDAD").SummaryItem.SummaryValue)
            e.TotalValue = (decMargenUtilidad / decVentas)
            e.TotalValueReady = True
        End If
        '--
    End Sub

    Private Sub funUpdateGrid()
        '--
        Try
            '-- Carga datos
            Me.Cursor = Cursors.WaitCursor
            Me.gcDetalle2.DataSource = Nothing
            '-- Limpia columnas del grid, para pintar nuevas columnas
            Me.gvDetalle2.Columns.Clear()
            '--
            funCargaData()
            Me.Cursor = Cursors.Default
            '--
            Me.gcDetalle2.DataSource = dsReporte.Tables(0)
            '--
            GridViewStyle(Me.gvDetalle2)
            funOcultarTodasLasColumnas(Me.gvDetalle2)
            indice = 0
            '--
            If Me.optOpcion.SelectedIndex = 0 Then
                '-- Encabezado
                funSetColumna(gvDetalle2, "TIENDA", "TIENDA", funIndice(), 100, 1)
                funSetColumna(gvDetalle2, "FECHA", "FECHA", funIndice(), 90, 1, , , "d", 0, , DevExpress.Utils.FormatType.DateTime)
                funSetColumna(gvDetalle2, "FACTURA", "FACTURA", funIndice(), 70, 1)
                funSetColumna(gvDetalle2, "COSTO_TOTAL", "COSTO_TOTAL", funIndice(), 100, 1, , , "n2", 0, , DevExpress.Utils.FormatType.Numeric)
                funSetColumna(gvDetalle2, "VENTA_BRUTA", "VENTA_BRUTA", funIndice(), 90, 1, , , "n2", 0, , DevExpress.Utils.FormatType.Numeric)
                funSetColumna(gvDetalle2, "DESCUENTO", "DESCUENTO", funIndice(), 100, 1, , , "n2", 0, , DevExpress.Utils.FormatType.Numeric)
                funSetColumna(gvDetalle2, "IMPUESTO", "IMPUESTO", funIndice(), 100, 1, , , "n2", 0, , DevExpress.Utils.FormatType.Numeric)
                funSetColumna(gvDetalle2, "SERVICIOS", "SERVICIOS", funIndice(), 100, 1, , , "n2", 0, , DevExpress.Utils.FormatType.Numeric)
                funSetColumna(gvDetalle2, "VENTA_NETA", "VENTA_NETA", funIndice(), 100, 1, , , "n2", 0, , DevExpress.Utils.FormatType.Numeric)
                funSetColumna(gvDetalle2, "MARGEN_UTILIDAD", "MARGEN_UTILIDAD", funIndice(), 110, 1, , , "n2", 0, , DevExpress.Utils.FormatType.Numeric)
                funSetColumna(gvDetalle2, "% MARGEN UTILIDAD", "% MARGEN UTILIDAD", funIndice(), 100, 1, , , "P", 3, , DevExpress.Utils.FormatType.Numeric)
                With gvDetalle2
                    .GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "COSTO_TOTAL", .Columns("COSTO_TOTAL"), "{0:n2}")
                    .Columns("COSTO_TOTAL").SummaryItem.FieldName = "COSTO_TOTAL"
                    .Columns("COSTO_TOTAL").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    .Columns("COSTO_TOTAL").SummaryItem.DisplayFormat = "{0:n2}"
                    '--
                    .GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "VENTA_BRUTA", .Columns("VENTA_BRUTA"), "{0:n2}")
                    .Columns("VENTA_BRUTA").SummaryItem.FieldName = "VENTA_BRUTA"
                    .Columns("VENTA_BRUTA").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    .Columns("VENTA_BRUTA").SummaryItem.DisplayFormat = "{0:n2}"
                    '--
                    .GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "DESCUENTO", .Columns("DESCUENTO"), "{0:n2}")
                    .Columns("DESCUENTO").SummaryItem.FieldName = "DESCUENTO"
                    .Columns("DESCUENTO").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    .Columns("DESCUENTO").SummaryItem.DisplayFormat = "{0:n2}"

                    '--               
                    .GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "IMPUESTO", .Columns("IMPUESTO"), "{0:n2}")
                    .Columns("IMPUESTO").SummaryItem.FieldName = "IMPUESTO"
                    .Columns("IMPUESTO").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    .Columns("IMPUESTO").SummaryItem.DisplayFormat = "{0:n2}"
                    '--
                    .GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "SERVICIOS", .Columns("SERVICIOS"), "{0:n2}")
                    .Columns("SERVICIOS").SummaryItem.FieldName = "SERVICIOS"
                    .Columns("SERVICIOS").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    .Columns("SERVICIOS").SummaryItem.DisplayFormat = "{0:n2}"
                    '--
                    .GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "VENTA_NETA", .Columns("VENTA_NETA"), "{0:n2}")
                    .Columns("VENTA_NETA").SummaryItem.FieldName = "VENTA_NETA"
                    .Columns("VENTA_NETA").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    .Columns("VENTA_NETA").SummaryItem.DisplayFormat = "{0:n2}"
                    '--              
                    .GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "MARGEN_UTILIDAD", .Columns("MARGEN_UTILIDAD"), "{0:n2}")
                    .Columns("MARGEN_UTILIDAD").SummaryItem.FieldName = "MARGEN_UTILIDAD"
                    .Columns("MARGEN_UTILIDAD").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    .Columns("MARGEN_UTILIDAD").SummaryItem.DisplayFormat = "{0:n2}"
                    '--              
                    .GroupSummary.Add(DevExpress.Data.SummaryItemType.Custom, "% MARGEN UTILIDAD", .Columns("% MARGEN UTILIDAD"), "{0:n2}")
                    .Columns("% MARGEN UTILIDAD").SummaryItem.FieldName = "% MARGEN UTILIDAD"
                    .Columns("% MARGEN UTILIDAD").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom
                    .Columns("% MARGEN UTILIDAD").SummaryItem.DisplayFormat = "{0:P}"
                    '--          
                    .OptionsView.ShowFooter = True
                    .ExpandAllGroups()
                End With
            ElseIf Me.optOpcion.SelectedIndex = 1 Then
                '-- Detalle
                funSetColumna(gvDetalle2, "TIENDA", "TIENDA", funIndice(), 100, 1)
                funSetColumna(gvDetalle2, "FECHA", "FECHA", funIndice(), 90, 1, , , "d", 0, , DevExpress.Utils.FormatType.DateTime)
                funSetColumna(gvDetalle2, "FACTURA", "FACTURA", funIndice(), 70, 1)
                funSetColumna(gvDetalle2, "ARTICULO", "ARTICULO", funIndice(), 90, 1)
                funSetColumna(gvDetalle2, "ARTICULO_NOMBRE", "Articulo_Nombre", funIndice(), 200, 1)
                funSetColumna(gvDetalle2, "UNIDADES", "UNIDADES", funIndice(), 80, 1, , , "n0", 0, , DevExpress.Utils.FormatType.Numeric)
                funSetColumna(gvDetalle2, "PRECIO_UNITARIO", "PRECIO_UNITARIO", funIndice(), 100, 1, , , "n2", 0, , DevExpress.Utils.FormatType.Numeric)
                funSetColumna(gvDetalle2, "DESCUENTO", "DESCUENTO", funIndice(), 100, 1, , , "n2", 0, , DevExpress.Utils.FormatType.Numeric)
                funSetColumna(gvDetalle2, "VENTA_NETA", "VENTA_NETA", funIndice(), 100, 1, , , "n2", 0, , DevExpress.Utils.FormatType.Numeric)
                funSetColumna(gvDetalle2, "COSTO_TOTAL", "COSTO_TOTAL", funIndice(), 100, 1, , , "n2", 0, , DevExpress.Utils.FormatType.Numeric)
                funSetColumna(gvDetalle2, "MARGEN_UTILIDAD", "MARGEN_UTILIDAD", funIndice(), 110, 1, , , "n2", 0, , DevExpress.Utils.FormatType.Numeric)
                funSetColumna(gvDetalle2, "% MARGEN UTILIDAD", "% MARGEN UTILIDAD", funIndice(), 100, 1, , , "P", 3, , DevExpress.Utils.FormatType.Numeric)
                With gvDetalle2
                    '--
                    .GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "UNIDADES", .Columns("UNIDADES"), "{0:n2}")
                    .Columns("UNIDADES").SummaryItem.FieldName = "UNIDADES"
                    .Columns("UNIDADES").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    .Columns("UNIDADES").SummaryItem.DisplayFormat = "{0:n2}"
                    '--               
                    .GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "DESCUENTO", .Columns("DESCUENTO"), "{0:n2}")
                    .Columns("DESCUENTO").SummaryItem.FieldName = "DESCUENTO"
                    .Columns("DESCUENTO").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    .Columns("DESCUENTO").SummaryItem.DisplayFormat = "{0:n2}"
                    '--
                    .GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "VENTA_NETA", .Columns("VENTA_NETA"), "{0:n2}")
                    .Columns("VENTA_NETA").SummaryItem.FieldName = "VENTA_NETA"
                    .Columns("VENTA_NETA").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    .Columns("VENTA_NETA").SummaryItem.DisplayFormat = "{0:n2}"
                    '--              
                    .GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "COSTO_TOTAL", .Columns("COSTO_TOTAL"), "{0:n2}")
                    .Columns("COSTO_TOTAL").SummaryItem.FieldName = "COSTO_TOTAL"
                    .Columns("COSTO_TOTAL").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    .Columns("COSTO_TOTAL").SummaryItem.DisplayFormat = "{0:n2}"
                    '--              
                    .GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "MARGEN_UTILIDAD", .Columns("MARGEN_UTILIDAD"), "{0:n2}")
                    .Columns("MARGEN_UTILIDAD").SummaryItem.FieldName = "MARGEN_UTILIDAD"
                    .Columns("MARGEN_UTILIDAD").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    .Columns("MARGEN_UTILIDAD").SummaryItem.DisplayFormat = "{0:n2}"
                    '--
                    .GroupSummary.Add(DevExpress.Data.SummaryItemType.Custom, "% MARGEN UTILIDAD", .Columns("% MARGEN UTILIDAD"), "{0:n2}")
                    .Columns("% MARGEN UTILIDAD").SummaryItem.FieldName = "% MARGEN UTILIDAD"
                    .Columns("% MARGEN UTILIDAD").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom
                    .Columns("% MARGEN UTILIDAD").SummaryItem.DisplayFormat = "{0:P}"
                    '--  
                    .OptionsView.ShowFooter = True
                    .ExpandAllGroups()
                End With
            ElseIf Me.optOpcion.SelectedIndex = 2 Then
                funSetColumna(gvDetalle2, "ARTICULO", "ARTICULO", funIndice(), 90, 1)
                funSetColumna(gvDetalle2, "ARTICULO_NOMBRE", "ARTICULO_NOMBRE", funIndice(), 300, 1)
                funSetColumna(gvDetalle2, "UNIDADES", "UNIDADES", funIndice(), 80, 1, , , "n0", 0, , DevExpress.Utils.FormatType.Numeric)
                funSetColumna(gvDetalle2, "VENTA_NETA", "VENTA_NETA", funIndice(), 100, 1, , , "n2", 0, , DevExpress.Utils.FormatType.Numeric)
                funSetColumna(gvDetalle2, "COSTO_TOTAL", "COSTO_TOTAL", funIndice(), 100, 1, , , "n2", 0, , DevExpress.Utils.FormatType.Numeric)
                funSetColumna(gvDetalle2, "MARGEN_UTILIDAD", "MARGEN_UTILIDAD", funIndice(), 110, 1, , , "n2", 0, , DevExpress.Utils.FormatType.Numeric)
                funSetColumna(gvDetalle2, "% MARGEN UTILIDAD", "% MARGEN UTILIDAD", funIndice(), 100, 1, , , "P", 3, , DevExpress.Utils.FormatType.Numeric)
                With gvDetalle2
                    '--
                    .GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "UNIDADES", .Columns("UNIDADES"), "{0:n2}")
                    .Columns("UNIDADES").SummaryItem.FieldName = "UNIDADES"
                    .Columns("UNIDADES").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    .Columns("UNIDADES").SummaryItem.DisplayFormat = "{0:n2}"
                    '--               
                    .GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "VENTA_NETA", .Columns("VENTA_NETA"), "{0:n2}")
                    .Columns("VENTA_NETA").SummaryItem.FieldName = "VENTA_NETA"
                    .Columns("VENTA_NETA").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    .Columns("VENTA_NETA").SummaryItem.DisplayFormat = "{0:n2}"
                    '--              
                    '--              
                    .GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "COSTO_TOTAL", .Columns("COSTO_TOTAL"), "{0:n2}")
                    .Columns("COSTO_TOTAL").SummaryItem.FieldName = "COSTO_TOTAL"
                    .Columns("COSTO_TOTAL").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    .Columns("COSTO_TOTAL").SummaryItem.DisplayFormat = "{0:n2}"
                    '--              
                    .GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "MARGEN_UTILIDAD", .Columns("MARGEN_UTILIDAD"), "{0:n2}")
                    .Columns("MARGEN_UTILIDAD").SummaryItem.FieldName = "MARGEN_UTILIDAD"
                    .Columns("MARGEN_UTILIDAD").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    .Columns("MARGEN_UTILIDAD").SummaryItem.DisplayFormat = "{0:n2}"
                    '--        
                    .GroupSummary.Add(DevExpress.Data.SummaryItemType.Custom, "% MARGEN UTILIDAD", .Columns("% MARGEN UTILIDAD"), "{0:n2}")
                    .Columns("% MARGEN UTILIDAD").SummaryItem.FieldName = "% MARGEN UTILIDAD"
                    .Columns("% MARGEN UTILIDAD").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom
                    .Columns("% MARGEN UTILIDAD").SummaryItem.DisplayFormat = "{0:P}"
                    '--
                    .OptionsView.ShowFooter = True
                    .ExpandAllGroups()
                End With
            End If
            '--
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        '--
    End Sub
End Class


