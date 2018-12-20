Imports System
Imports System.Data
Imports System.Data.SqlClient


Public Class frmRepExiste_Localiza
    '--
    Dim ds As New DataSet
    Dim i As Integer
    Dim strChekados As String
    Dim dsReporte As DataSet

    Dim FilePath As String

    Private Sub frmRepExiste_Localiza_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmRepExiste_Localiza_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        funUpdateGrid()
    End Sub

    Private Function funUpdateGrid()
        Try
            ds = clsLocaliza.funListaLocaliza()
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

    Private Sub bbExcel_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbExcel.ItemClick
        If Me.gvDetalle2.RowCount = 0 Then
            MsgBox("No Existen Registros ... !!!", MsgBoxStyle.Critical, "Información")
            Exit Sub
        End If
        Try
            FilePath = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
            Dim strFileName As String = FilePath & "\RepExistenciaLocalizacion.xlsx"
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
                    strChekados += .GetDataRow(i)("POSICION").ToString
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
            MsgBox("Falta seleccionar la Departamento !!!", MsgBoxStyle.Critical, "Atención !!!")
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
            Me.gvDetalle2.Columns.Clear()
            funCargaData2()
            Me.Cursor = Cursors.Default
            '--
            Me.gcDetalle2.DataSource = dsReporte.Tables(0)
            '--
            GridViewStyle(Me.gvDetalle2)
            funOcultarTodasLasColumnas(Me.gvDetalle2)
            indice = 0
            '--
            funSetColumna(gvDetalle2, "LOCALIZACION", "LOCALIZACION", funIndice(), 90, 1)
            funSetColumna(gvDetalle2, "ITEM", "ITEM", funIndice(), 90, 1)
            funSetColumna(gvDetalle2, "ARTICULO_ID", "ARTICULO_ID", funIndice(), 90, 1)
            funSetColumna(gvDetalle2, "DESCRIPCION", "DESCRIPCION", funIndice(), 200, 1)
            funSetColumna(gvDetalle2, "UND_BULTOS", "UND_BULTOS", funIndice(), 80, 1, , , "n0", 0, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle2, "UND_EXISTENCIA", "UND_EXISTENCIA", funIndice(), 80, 1, , , "n0", 0, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle2, "UND_COMPROMETIDO", "UND_COMPROMETIDO", funIndice(), 80, 1, , , "n0", 0, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle2, "COD_BARRA", "COD_BARRA", funIndice(), 150, 1)
            funSetColumna(gvDetalle2, "UF_COMPRA", "UF_COMPRA", funIndice(), 90, 1, , , "d", 0, , DevExpress.Utils.FormatType.DateTime)
            funSetColumna(gvDetalle2, "PROVEEDOR", "PROVEEDOR", funIndice(), 90, 1)
            '--
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        '--
    End Sub

    Private Sub funCargaData2()
        '-- Procesamos el SP, para cargar datos
        Dim CMD As New SqlCommand("sp_RepExistencia_Localiza_2")
        '--
        Dim strChekadosFull As String = Trim(strChekados.ToString)

        '-- Cargar con timeout
        CMD.Parameters.Add("@ids", SqlDbType.NVarChar, 30000).Value = strChekadosFull
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