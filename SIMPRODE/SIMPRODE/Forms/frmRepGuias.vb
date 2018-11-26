Imports System.IO
Imports OfficeOpenXml
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class frmRepGuias

    Dim ds As New DataSet
    Dim nTipoMovGrid As Integer
    Dim i As Integer
    Dim strChekados2 As String
    Dim strFiltroDataTable As String
    '--
    Dim dtListaArticulos As DataTable
    Dim dsReporte As DataSet

    Dim FilePath As String

    Private Sub frmRepGuias_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
        '--
    End Sub

    Private Sub frmRepGuias_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
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
        strProcedimiento = "sp_RepGuiasCosto"
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
            funSetColumna(gvDetalle2, "Guia_id", "No. GUIA", funIndice(), 100, 1)
            funSetColumna(gvDetalle2, "Suc_Destino", "SUC_ID", funIndice(), 100, 1)
            funSetColumna(gvDetalle2, "Suc_Nombre", "SUC_NOMBRE", funIndice(), 100, 1)
            funSetColumna(gvDetalle2, "Guia_Fec_Crea", "FECHA", funIndice(), 90, 1, , , "d", 0, , DevExpress.Utils.FormatType.DateTime)
            funSetColumna(gvDetalle2, "Det_Cantidad", "CANTIDAD_ITEM", funIndice(), 100, 1, , , "n2", 0, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle2, "Desp_Total", "MONTO_TOTAL", funIndice(), 100, 1, , , "n2", 0, , DevExpress.Utils.FormatType.Numeric)
            '--
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        '--
    End Sub

End Class


