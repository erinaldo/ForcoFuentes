Imports System.IO
Imports OfficeOpenXml
Imports System.Data.SqlClient

Public Class frmRepCategoriaSub2
    '--
    Dim ds As New DataSet
    Dim i As Integer
    Dim strChekados As String
    Dim dsReporte As DataSet

    Dim FilePath As String

    Private Sub frmRepCategoriaSub2_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmRepCategoriaSub2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        funUpdateGrid()
    End Sub

    Private Function funUpdateGrid()
        Try
            ds = clsCategoriaSub.funListaSubCategorias()
            Me.gcLista.DataSource = ds.Tables(0)
            '--
            funDxGrid(Me.gvLista, 1, False, False, False, 0, False, False, False)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return True
    End Function

    Private Sub gvLista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gvLista.Click
        With Me.gvLista
            If .FocusedColumn.Name = "colOpt" Then
                .SetFocusedValue(Not Convert.ToBoolean(.GetFocusedRowCellValue("optSelection")))
            End If
        End With
    End Sub

    Private Sub repositoryItemCheckEdit1_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RepositoryItemCheckEdit1.EditValueChanged
        gvLista.PostEditor()

        ' The UpdateCurrentRow method call is optional for CheckEditor.
        ' Don't call it for Text editors!
        ' gridView1.UpdateCurrentRow();   

        ' TEST:
        'Console.WriteLine(gvLista.GetDataRow(gvLista.FocusedRowHandle)(gvLista.FocusedColumn.FieldName))
    End Sub

    Private Sub bbAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bbAdd.Click
        With Me.gvLista
            For i As Integer = 0 To .RowCount - 1
                .SetRowCellValue(i, "optSelection", True)
            Next
        End With
    End Sub

    Private Sub bbDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bbDelete.Click
        With Me.gvLista
            For i As Integer = 0 To .RowCount - 1
                .SetRowCellValue(i, "optSelection", False)
            Next
        End With
    End Sub

    Private Sub bbPrint_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbPrint.ItemClick
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
        funPrintConSp("repComprasCategoriaSub2-v1.rpt", lstParametros)
        '--
        Return True
    End Function

    Dim f As FolderBrowserDialog

    Private Sub bbExcel_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbExcel.ItemClick
        If Me.gvDetalle2.RowCount = 0 Then
            MsgBox("No Existen Registros ... !!!", MsgBoxStyle.Critical, "Información")
            Exit Sub
        End If
        Try
            FilePath = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
            Dim strFileName As String = FilePath & "\RepCategoria.xlsx"
            Me.gcDetalle2.ExportToXlsx(strFileName)
            System.Diagnostics.Process.Start(strFileName)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Function funProcesaChekados()
        strChekados = ""
        Dim nCambios As Integer = 0
        With Me.gvLista
            For i As Integer = 0 To .RowCount - 1
                If Convert.ToBoolean(.GetDataRow(i)("optSelection")) = True Then
                    strChekados += IIf(nCambios > 0, ",", "")
                    strChekados += .GetDataRow(i)("CodigoUnico").ToString
                    nCambios += 1
                End If
            Next
            If Trim(strChekados).Length > 0 Then
                strChekados = IIf(Mid(strChekados, Len(strChekados), 1) = ",", Mid(strChekados, 1, Len(strChekados) - 1), strChekados)
            End If
        End With
        Return True
    End Function

    Private Function funValidar() As Boolean
        If Trim(strChekados).Length = 0 Then
            Me.gvLista.Focus()
            MsgBox("Falta seleccionar la Categoria !!!", MsgBoxStyle.Critical, "Atención !!!")
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
            funSetColumna(gvDetalle2, "CATEGORIA", "CATEGORIA", funIndice(), 90, 1)
            funSetColumna(gvDetalle2, "SUB-CATEGORIA", "SUB-CATEGORIA", funIndice(), 90, 1)
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
        Dim CMD As New SqlCommand("sp_RepComprasSaldosMargenCategoriaSub2")
        '--
        Dim nDollar As Double = Me.cbDollar.Value.ToString
        Dim strRango1 As String = funFechaSql(Me.dtpDesde1.Value.Date, True)
        Dim strRango2 As String = funFechaSql(Me.dtpHasta1.Value.Date, True)
        Dim strMargen1 As String = funFechaSql(Me.dtpDesde2.Value.Date, True)
        Dim strMargen2 As String = funFechaSql(Me.dtpHasta2.Value.Date, True)
        Dim strChekadosFull As String = Trim(strChekados.ToString)

        '-- Cargar con timeout
        CMD.Parameters.Add("@dollar", SqlDbType.Decimal).Value = nDollar
        CMD.Parameters.Add("@date1", SqlDbType.NVarChar, 11).Value = strRango1
        CMD.Parameters.Add("@date2", SqlDbType.NVarChar, 11).Value = strRango2
        CMD.Parameters.Add("@datemargen1", SqlDbType.NVarChar, 11).Value = strMargen1
        CMD.Parameters.Add("@datemargen2", SqlDbType.NVarChar, 11).Value = strMargen2
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

    Private Sub bbClear_Click(sender As Object, e As EventArgs) Handles bbClear.Click
        Me.gcDetalle2.DataSource = Nothing
    End Sub

End Class