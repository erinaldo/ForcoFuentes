Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmRepVentasBajo50
    '--
    Dim ds As New DataSet
    Dim i As Integer
    Dim strChekados As String
    Dim dsReporte As DataSet
    Dim strChekados2 As String

    Dim FilePath As String

    Private Sub frmRepVentasBajo50_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmRepVentasBajo50_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        funUpdateGrid_Depto()
        funUpdateGrid_Suc()
    End Sub

    Private Function funUpdateGrid_Depto()
        Try
            ds = clsDepartamento.funListaDepartamento()
            Me.gcLista.DataSource = ds.Tables(0)
            '--
            funDxGrid(Me.gvLista, 1, False, False, False, 0, False, False, False)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return True
    End Function

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

    Private Sub gvLista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gvLista.Click
        With Me.gvLista
            If .FocusedColumn.Name = "colOpt" Then
                .SetFocusedValue(Not Convert.ToBoolean(.GetFocusedRowCellValue("optSelection")))
            End If
        End With
    End Sub

    Private Sub gvLista2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gvLista2.Click
        With Me.gvLista2
            If .FocusedColumn.Name = "colOpt1" Then
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

    Private Sub repositoryItemCheckEdit2_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RepositoryItemCheckEdit2.EditValueChanged
        gvLista2.PostEditor()

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

    Private Sub bbExcel_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbExcel.ItemClick
        If Me.gvDetalle2.RowCount = 0 Then
            MsgBox("No Existen Registros ... !!!", MsgBoxStyle.Critical, "Información")
            Exit Sub
        End If
        Try
            FilePath = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
            Dim strFileName As String = FilePath & "\RepVentasDetalle.xlsx"
            Me.gcDetalle2.ExportToXlsx(strFileName)
            System.Diagnostics.Process.Start(strFileName)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub bbClear_Click(sender As Object, e As EventArgs) Handles bbClear.Click
        Me.gcDetalle2.DataSource = Nothing
    End Sub

    Private Sub bClose_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bClose.ItemClick
        Me.Close()
    End Sub

    Private Sub bbConsultar_Click(sender As Object, e As EventArgs) Handles bbConsultar.Click
        funProcesaChekados()
        funProcesaChekados2()
        If funValidar() = True Then
            funUpdateGrid_Datos()
        End If
    End Sub

    Private Function funProcesaChekados()
        strChekados = ""
        Dim nCambios As Integer = 0
        With Me.gvLista
            For i As Integer = 0 To .RowCount - 1
                If Convert.ToBoolean(.GetDataRow(i)("optSelection")) = True Then
                    strChekados += IIf(nCambios > 0, ",", "")
                    strChekados += .GetDataRow(i)("Depto_Id").ToString
                    nCambios += 1
                End If
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

    Private Function funValidar() As Boolean
        If Trim(strChekados).Length = 0 Then
            Me.gvLista.Focus()
            MsgBox("Falta seleccionar la Departamento!", MsgBoxStyle.Critical, "Atención !!!")
            Return False
        ElseIf Trim(strChekados2).Length = 0 Then
            Me.gvLista2.Focus()
            MsgBox("Falta seleccionar la Tienda!", MsgBoxStyle.Critical, "Atención !!!")
            Return False
        ElseIf Me.nIndicador.Value = 0 Then
            Me.nIndicador.Focus()
            MsgBox("Falta el Indicador !", MsgBoxStyle.Critical, "Atención !!!")
            Return False
        End If
        Return True
    End Function

    Private Sub funUpdateGrid_Datos()
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
        Dim CMD As New SqlCommand("sp_RepVentasDetalle")
        '--
        Dim nIndicador As Double = Me.nIndicador.Value.ToString
        Dim strRango1 As String = funFechaSql(Me.dtpDesde1.Value.Date, True)
        Dim strRango2 As String = funFechaSql(Me.dtpHasta1.Value.Date, True)
        Dim strChekadosFull_1 As String = Trim(strChekados.ToString)
        Dim strChekadosFull_2 As String = Trim(strChekados2.ToString)

        '-- Cargar con timeout
        CMD.Parameters.Add("@indicadorr", SqlDbType.Decimal).Value = nIndicador
        CMD.Parameters.Add("@date1", SqlDbType.NVarChar, 11).Value = strRango1
        CMD.Parameters.Add("@date2", SqlDbType.NVarChar, 11).Value = strRango2
        CMD.Parameters.Add("@ids", SqlDbType.NVarChar, 3000).Value = strChekadosFull_1
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


End Class
