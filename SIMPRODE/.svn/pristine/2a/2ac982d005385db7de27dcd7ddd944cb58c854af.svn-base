Imports System
Imports System.Data
Imports System.Data.SqlClient


Public Class frmRepCostoSucCon

    Dim i As Integer
    Dim dsReporte As DataSet

    Private Sub frmRepCostoSucCon_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
        '--
        Select Case e.KeyCode
            Case Keys.F1
                subDetalle()
            Case Keys.F2
                '-- subEdit()
            Case Keys.F3
                '-- subKardex()
        End Select
    End Sub

    Private Sub bbRefresh_Click(sender As Object, e As EventArgs)
        funUpdateGrid()
    End Sub

    Private Sub funUpdateGrid()
        '--
        Try
            '-- Carga datos
            Me.Cursor = Cursors.WaitCursor
            Me.gcDetalle.DataSource = Nothing
            funCargaData()
            Me.Cursor = Cursors.Default
            '--
            Me.gcDetalle.DataSource = dsReporte.Tables(0)
            '--
            GridViewStyle(Me.gvDetalle)
            funOcultarTodasLasColumnas(Me.gvDetalle)
            indice = 0
            '--
            funFormatGv_for_Sucursal(Me.gvDetalle)
            'funSetColumna(gvDetalle, "SUC_ID", "CODIGO", funIndice(), 90, 1)
            'funSetColumna(gvDetalle, "SUC_NOMBRE", "TIENDA", funIndice(), 200, 1)
            'funSetColumna(gvDetalle, "TOTAL_UNIDADES", "TOTAL UNIDADES", funIndice(), 120, 1, , , "n0", 3, , DevExpress.Utils.FormatType.Numeric)
            'funSetColumna(gvDetalle, "TOTAL_COSTO", "TOTAL DE COSTO", funIndice(), 120, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
            'funSetColumna(gvDetalle, "COSTO_PROMEDIO", "COSTO PROMEDIO", funIndice(), 120, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
            '--
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        '--
    End Sub
    Public Sub funFormatGv_for_Sucursal(ByVal oGridView As DevExpress.XtraGrid.Views.Grid.GridView)
        '--
        funSetColumna(gvDetalle, "SUC_ID", "CODIGO", funIndice(), 90, 1)
        funSetColumna(gvDetalle, "SUC_NOMBRE", "TIENDA", funIndice(), 200, 1)
        funSetColumna(gvDetalle, "TOTAL_UNIDADES", "TOTAL UNIDADES", funIndice(), 120, 1, , , "n0", 3, , DevExpress.Utils.FormatType.Numeric)
        funSetColumna(gvDetalle, "TOTAL_COSTO", "TOTAL DE COSTO", funIndice(), 120, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
        funSetColumna(gvDetalle, "COSTO_PROMEDIO", "COSTO PROMEDIO", funIndice(), 120, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)

        oGridView.Columns("FORMATO_NOMBRE").Group()
        oGridView.Columns("FORMATO_NOMBRE").Caption = "Formato"
        '-- Totales
        oGridView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "TOTAL_UNIDADES", oGridView.Columns("TOTAL_UNIDADES"), "{0:n0}")
        oGridView.Columns("TOTAL_UNIDADES").SummaryItem.FieldName = "TOTAL_UNIDADES"
        oGridView.Columns("TOTAL_UNIDADES").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        oGridView.Columns("TOTAL_UNIDADES").SummaryItem.DisplayFormat = "{0:n0}"
        '-- 
        oGridView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "TOTAL_COSTO", oGridView.Columns("TOTAL_COSTO"), "{0:n2}")
        oGridView.Columns("TOTAL_COSTO").SummaryItem.FieldName = "TOTAL_COSTO"
        oGridView.Columns("TOTAL_COSTO").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        oGridView.Columns("TOTAL_COSTO").SummaryItem.DisplayFormat = "{0:n2}"

    End Sub
    Private Sub funCargaData()
        '-- Procesamos el SP, para cargar datos
        Dim CMD As New SqlCommand("sp_RepValorInvSucCon")
        '--
        Dim strRango1 As String = funFechaSql(Me.dtpDesde1.Value.Date, True)
        '-- Cargar con timeout
        CMD.Parameters.Add("@fechaCorte", SqlDbType.NVarChar, 11).Value = strRango1
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
    Private Sub bClose_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bClose.ItemClick
        Me.Close()
    End Sub

    Dim FilePath As String
    Private Sub bbExcel_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbExcel.ItemClick
        Try
            FilePath = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
            Dim strFileName As String = FilePath & "\repInvValorSucCon.xlsx"
            Me.gcDetalle.ExportToXlsx(strFileName)
            System.Diagnostics.Process.Start(strFileName)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub bbRefresh_Click_1(sender As Object, e As EventArgs) Handles bbRefresh.Click
        funUpdateGrid()
    End Sub

    Private Sub bbDetalle_Click(sender As Object, e As EventArgs) Handles bbDetalle.Click
        subDetalle()
    End Sub

    Private Sub subDetalle()
        With Me.gvDetalle
            If .RowCount > 0 Then
                Dim f As New frmRepCostoSucConDet
                f.nCode = funNull2Val(.GetFocusedRowCellValue(.Columns("SUC_ID")))
                f.dtmCorte = Me.dtpDesde1.Value.Date
                f.ShowDialog()
            End If
        End With
    End Sub

End Class