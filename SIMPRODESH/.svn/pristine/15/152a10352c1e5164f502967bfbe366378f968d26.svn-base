Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmRepFormasPago
    '--
    Dim ds As New DataSet
    Dim dsReporte As DataSet
    Dim FilePath As String

    Private Sub frmRepFormasPago_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub bbExcel_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbExcel.ItemClick
        If Me.gvDetalle2.RowCount = 0 Then
            MsgBox("No Existen Registros ... !!!", MsgBoxStyle.Critical, "Información")
            Exit Sub
        End If
        Try
            FilePath = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
            Dim strFileName As String = FilePath & "\repFormaPago.xlsx"
            Me.gcDetalle2.ExportToXlsx(strFileName)
            System.Diagnostics.Process.Start(strFileName)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Function funValidar() As Boolean
        If Me.cbDollar.Value = 0 Then
            Me.cbDollar.Focus()
            MsgBox("Falta el tipo de cambio !!!", MsgBoxStyle.Critical, "Atención !!!")
            Return False
        End If
        Return True
    End Function

    Private Sub bbRefresh_Click(sender As Object, e As EventArgs) Handles bbRefresh.Click
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
            With gvDetalle2
                .OptionsCustomization.AllowGroup = False
                .OptionsView.ShowGroupPanel = False
                .OptionsSelection.MultiSelect = True
                .OptionsView.EnableAppearanceOddRow = True

                .OptionsView.ColumnAutoWidth = False
                '.Appearance.OddRow.BackColor = Color.SkyBlue
                .Appearance.OddRow.BackColor = Color.FromArgb(227, 241, 254)
                .OptionsBehavior.Editable = False
                .OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
                .BestFitColumns()
            End With
            'Me.gvDetalle2.PopulateColumns()
            'Me.gvDetalle2.BestFitColumns()
            '--
            'GridViewStyle(Me.gvDetalle2)
            'funOcultarTodasLasColumnas(Me.gvDetalle2)
            'indice = 0
            '--
            'funSetColumna(gvDetalle2, "SUC_NOMBRE", "ID_TIENDA", funIndice(), 80, 1)
            'funSetColumna(gvDetalle2, "CLIENTE", "CLIENTE", funIndice(), 80, 1)
            'funSetColumna(gvDetalle2, "CLIENTE_NOMBRE", "CLIENTE_NOMBRE", funIndice(), 150, 1)
            'funSetColumna(gvDetalle2, "ARTICULO", "ARTICULO", funIndice(), 80, 1)
            'funSetColumna(gvDetalle2, "ARTICULO_NOMBRE", "ARTICULO_NOMBRE", funIndice(), 150, 1)
            'funSetColumna(gvDetalle2, "UNIDADES", "UNIDADES", funIndice(), 100, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
            'funSetColumna(gvDetalle2, "VENTA_TOTAL", "VENTA TOTAL", funIndice(), 80, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
            '--
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        '--
    End Sub

    Private Sub funCargaData2()
        '-- Procesamos el SP, para cargar datos
        '--
        Dim CMD As New SqlCommand("sp_RepFormaDePago")
        '--
        Dim strRango1 As String = funFechaSql(Me.dtpDesde1.Value.Date, True)
        Dim strRango2 As String = funFechaSql(Me.dtpHasta1.Value.Date, True)

        '-- Cargar con timeout
        CMD.Parameters.Add("@fecha1", SqlDbType.NVarChar, 11).Value = strRango1
        CMD.Parameters.Add("@fecha2", SqlDbType.NVarChar, 11).Value = strRango2
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
            adapter.SelectCommand.CommandTimeout = 100
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

    
End Class