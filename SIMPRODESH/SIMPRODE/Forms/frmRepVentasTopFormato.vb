Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmRepVentasTopFormato
    '--
    Dim ds As DataSet
    Dim dsReporte As DataSet
    Dim FilePath As String

    Private Sub frmRepVentasTopFormato_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmRepVentasTopFormato_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        funIniVar()
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
        '-- Carga Proveedores
        strSQL = "SELECT Prov_Id AS nCodigo, Prov_Nombre AS strDescripcion FROM vw_GB_Proveedor_Con_Compras ORDER BY Prov_Nombre"
        '--
        funCargarLue(Me.lkProveedor, strSQL)
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
            If Me.optOpcion.SelectedIndex = 0 Then
                funSetColumna(gvDetalle, "ARTICULO", "ARTICULO", funIndice(), 80, 1)
                funSetColumna(gvDetalle, "ARTICULO_NOMBRE", "ARTICULO_NOMBRE", funIndice(), 300, 1)
                funSetColumna(gvDetalle, "TOTAL_UNIDADES", "TOTAL_UNIDADES", funIndice(), 100, 1, , , "n0", 0, , DevExpress.Utils.FormatType.Numeric)
                funSetColumna(gvDetalle, "SUC_NOMBRE", "PUNTOS DE VENTAS", funIndice(), 700, 1)
            ElseIf Me.optOpcion.SelectedIndex = 1 Then
                funSetColumna(gvDetalle, "ARTICULO", "ARTICULO", funIndice(), 80, 1)
                funSetColumna(gvDetalle, "ARTICULO_NOMBRE", "ARTICULO_NOMBRE", funIndice(), 200, 1)
                funSetColumna(gvDetalle, "VENTA_TOTAL", "VENTA_TOTAL", funIndice(), 150, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
                funSetColumna(gvDetalle, "UTILIDAD_TOTAL", "UTILIDAD_TOTAL", funIndice(), 150, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
                funSetColumna(gvDetalle, "SUC_NOMBRE", "SUC_NOMBRE", funIndice(), 500, 1)
            ElseIf Me.optOpcion.SelectedIndex = 2 Then
                '--
                funSetColumna(gvDetalle, "SUC", "SUC", funIndice(), 80, 1)
                funSetColumna(gvDetalle, "SUC_NOMBRE", "SUC_NOMBRE", funIndice(), 120, 1)
                funSetColumna(gvDetalle, "ARTICULO", "ARTICULO", funIndice(), 80, 1)
                funSetColumna(gvDetalle, "ARTICULO_NOMBRE", "ARTICULO_NOMBRE", funIndice(), 300, 1)
                funSetColumna(gvDetalle, "UNIDADES", "UNIDADES", funIndice(), 100, 1, , , "n0", 0, , DevExpress.Utils.FormatType.Numeric)
                With gvDetalle
                    .GroupSummary.Clear()
                    .Columns("TIENDA").Group()
                    .Columns("TIENDA").Caption = "TIENDA"
                    .GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "UNIDADES", .Columns("UNIDADES"), "{0:n2}")
                    .Columns("UNIDADES").SummaryItem.FieldName = "UNIDADES"
                    .Columns("UNIDADES").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    .Columns("UNIDADES").SummaryItem.DisplayFormat = "{0:n2}"
                    .OptionsView.ShowFooter = True
                    .ExpandAllGroups()
                End With
            ElseIf Me.optOpcion.SelectedIndex = 3 Then
                '--
                funSetColumna(gvDetalle, "SUC", "SUC", funIndice(), 80, 1)
                funSetColumna(gvDetalle, "SUC_NOMBRE", "SUC_NOMBRE", funIndice(), 120, 1)
                funSetColumna(gvDetalle, "ARTICULO", "ARTICULO", funIndice(), 80, 1)
                funSetColumna(gvDetalle, "ARTICULO_NOMBRE", "ARTICULO_NOMBRE", funIndice(), 300, 1)
                funSetColumna(gvDetalle, "VENTA_TOTAL", "VENTA_TOTAL", funIndice(), 100, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
                funSetColumna(gvDetalle, "UTILIDAD_TOTAL", "UTILIDAD_TOTAL", funIndice(), 150, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
                With gvDetalle
                    .Columns("TIENDA").Group()
                    .Columns("TIENDA").Caption = "TIENDA"
                    '-- Total Ventas
                    .GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "VENTA_TOTAL", .Columns("VENTA_TOTAL"), "{0:n2}")
                    .Columns("VENTA_TOTAL").SummaryItem.FieldName = "VENTA_TOTAL"
                    .Columns("VENTA_TOTAL").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    .Columns("VENTA_TOTAL").SummaryItem.DisplayFormat = "{0:n2}"
                    '-- Utilidad Ventas
                    .GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "UTILIDAD_TOTAL", .Columns("UTILIDAD_TOTAL"), "{0:n2}")
                    .Columns("UTILIDAD_TOTAL").SummaryItem.FieldName = "UTILIDAD_TOTAL"
                    .Columns("UTILIDAD_TOTAL").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    .Columns("UTILIDAD_TOTAL").SummaryItem.DisplayFormat = "{0:n2}"
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

    Private Sub funCargaData()
        Dim strProcedimiento As String = ""
        '-- Procesamos el SP, para cargar datos
        If Me.optOpcion.SelectedIndex = 0 Then
            strProcedimiento = "sp_RepVentasTopFormato2"
        ElseIf Me.optOpcion.SelectedIndex = 1 Then
            strProcedimiento = "sp_RepVentasTopFormatoMonto2"
        ElseIf Me.optOpcion.SelectedIndex = 2 Then
            strProcedimiento = "sp_RepVentasTopFormatoSuc2"
        ElseIf Me.optOpcion.SelectedIndex = 3 Then
            strProcedimiento = "sp_RepVentasTopFormatoMontoSuc2"
        End If
        '--
        Dim CMD As New SqlCommand(strProcedimiento)
        '--
        Dim strRango1 As String = funFechaSql(Me.dtpDesde1.Value.Date, True)
        Dim strRango2 As String = funFechaSql(Me.dtpHasta1.Value.Date, True)
        Dim nFormato As Integer = Me.lkFormato.EditValue
        Dim nTop As Integer = Me.nTop.Value
        Dim nProveedor As Integer = Me.lkProveedor.EditValue

        '-- Cargar con timeout
        CMD.Parameters.Add("@date1", SqlDbType.NVarChar, 11).Value = strRango1
        CMD.Parameters.Add("@date2", SqlDbType.NVarChar, 11).Value = strRango2
        CMD.Parameters.Add("@formato", SqlDbType.Int).Value = nFormato
        CMD.Parameters.Add("@top", SqlDbType.Int).Value = nTop
        CMD.Parameters.Add("@proveedor", SqlDbType.Int).Value = nProveedor
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

    Private Sub optOpcion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles optOpcion.SelectedIndexChanged
        Me.gcDetalle.DataSource = Nothing
        Me.gvDetalle.Columns.Clear()
    End Sub


End Class