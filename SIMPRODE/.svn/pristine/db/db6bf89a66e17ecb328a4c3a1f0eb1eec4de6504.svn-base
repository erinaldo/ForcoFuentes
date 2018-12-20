Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmRepVentasAll
    '--
    Dim ds As DataSet
    Dim dsReporte As DataSet
    Dim FilePath As String
    Dim dtmFecha As Date

    Private Sub frmRepVentasAll_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmRepVentasAll_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        funIniVar()
        dtmFecha = Now
        Me.dtpFecha.Value = dtmFecha.AddDays(-1)
        funUpdateGrid()
    End Sub
    Private Function funIniVar()
        '--
        Try
            '--
            funCargaCombos()
            Me.lkFormato.EditValue = 1
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
        strSQL = "SELECT nCodigo AS nCodigo, strData AS strDescripcion FROM GB_Formato ORDER BY nCodigo"
        '--
        funCargarLue(Me.lkFormato, strSQL)
        '--
        Return True
    End Function

    Private Sub bbExcel_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbExcel.ItemClick
        If Me.gvDetalle.RowCount = 0 Then
            MsgBox("No Existen Registros ... !!!", MsgBoxStyle.Critical, "Información")
            Exit Sub
        End If
        Try
            FilePath = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
            Dim strFileName As String = FilePath & "\RepVetntasTopFormato.xlsx"
            Me.gcDetalle.ExportToXlsx(strFileName)
            System.Diagnostics.Process.Start(strFileName)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Function funValidar() As Boolean
        If Len(Trim(Me.lkFormato.Text)) = 0 Then
            Me.lkFormato.Focus()
            MsgBox("Falta el formato!!!", MsgBoxStyle.Critical, "Atención !!!")
            Return False
        End If
        Return True
    End Function

    Private Sub bbRefresh_Click(sender As Object, e As EventArgs) Handles bbRefresh.Click
        If funValidar() = True Then
            funUpdateGrid()
        End If
    End Sub

    Private Sub funUpdateGrid()
        '--
        Try
            '-- Carga datos
            Me.Cursor = Cursors.WaitCursor
            Me.gcDetalle.DataSource = Nothing
            Me.gvDetalle.Columns.Clear()
            funCargaData()
            Me.Cursor = Cursors.Default
            '--
            Me.gcDetalle.DataSource = dsReporte.Tables(0)
            '--
            GridViewStyle(Me.gvDetalle)
            funOcultarTodasLasColumnas(Me.gvDetalle)
            indice = 0
            '--
            funSetColumna(gvDetalle, "SUC_ID", "SUC_ID", funIndice(), 80, 1)
            funSetColumna(gvDetalle, "SUC_NOMBRE", "SUC_NOMBRE", funIndice(), 120, 1)
            funSetColumna(gvDetalle, "FECHA", "FECHA", funIndice(), 150, 1, , , "d", 0, , DevExpress.Utils.FormatType.DateTime,)
            funSetColumna(gvDetalle, "UNIDADES", "UNIDADES", funIndice(), 100, 1, , , "n0", 0, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle, "SUB-TOTAL", "SUB-TOTAL", funIndice(), 100, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle, "DESCUENTO", "DESCUENTO", funIndice(), 100, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle, "IMPUESTO", "IMPUESTO", funIndice(), 100, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle, "TOTAL", "TOTAL", funIndice(), 100, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle, "STATUS", "STATUS", funIndice(), 120, 1)
            With gvDetalle
                '--
                .GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "UNIDADES", .Columns("UNIDADES"), "{0:n2}")
                .Columns("UNIDADES").SummaryItem.FieldName = "UNIDADES"
                .Columns("UNIDADES").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                .Columns("UNIDADES").SummaryItem.DisplayFormat = "{0:n2}"
                '--               
                .GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "SUB-TOTAL", .Columns("SUB-TOTAL"), "{0:n2}")
                .Columns("SUB-TOTAL").SummaryItem.FieldName = "SUB-TOTAL"
                .Columns("SUB-TOTAL").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                .Columns("SUB-TOTAL").SummaryItem.DisplayFormat = "{0:n2}"
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
                .GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "TOTAL", .Columns("TOTAL"), "{0:n2}")
                .Columns("TOTAL").SummaryItem.FieldName = "TOTAL"
                .Columns("TOTAL").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                .Columns("TOTAL").SummaryItem.DisplayFormat = "{0:n2}"
                '--               
                .OptionsView.ShowFooter = True
                .ExpandAllGroups()
            End With
            '--
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        '--
    End Sub

    Private Sub funCargaData()
        Dim strProcedimiento As String = ""
        '-- Procesamos el SP, para cargar datos
        strProcedimiento = "sp_RepVentasConsolFormato"
        '--
        Dim CMD As New SqlCommand(strProcedimiento)
        '--
        Dim nFormato As Integer = Me.lkFormato.EditValue
        Dim strRango1 As String = funFechaSql(Me.dtpFecha.Value.Date, True)
        '-- Cargar con timeout
        CMD.Parameters.Add("@formato", SqlDbType.Int).Value = nFormato
        CMD.Parameters.Add("@fecha", SqlDbType.NVarChar, 11).Value = strRango1
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

    Private Sub optOpcion_SelectedIndexChanged(sender As Object, e As EventArgs)
        Me.gcDetalle.DataSource = Nothing
        Me.gvDetalle.Columns.Clear()
    End Sub

    Private Sub lkFormato_EditValueChanged(sender As Object, e As EventArgs) Handles lkFormato.EditValueChanged
        Me.gcDetalle.DataSource = Nothing
    End Sub
End Class