Imports System
Imports System.Data
Imports System.Data.SqlClient


Public Class frmRepInvAltaRota

    Dim i As Integer
    Dim dsReporte As DataSet

    Private Sub frmRepInvAltaRota_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
        '--
        Select Case e.KeyCode
            Case Keys.F1
                '-- subTest()
            Case Keys.F2
                '-- subEdit()
            Case Keys.F3
                '-- subKardex()
        End Select
    End Sub

    Private Sub bbRefresh_Click(sender As Object, e As EventArgs) Handles bbRefresh.Click
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
            funSetColumna(gvDetalle, "PROVEEDOR", "PROVEEDOR", funIndice(), 100, 1)
            funSetColumna(gvDetalle, "DEPARTAMENTO", "DEPTO", funIndice(), 100, 1)
            funSetColumna(gvDetalle, "CATEGORIA", "CAT", funIndice(), 100, 1)
            funSetColumna(gvDetalle, "ID", "COD.", funIndice(), 90, 1)
            funSetColumna(gvDetalle, "NOMBRE", "NOMBRE DE ARTICULO", funIndice(), 250, 1)
            funSetColumna(gvDetalle, "ULTIMA_FECHA_COMPRA", "FECHA ULTIMA COMPRA", funIndice(), 90, 1, , , "d", 0, , DevExpress.Utils.FormatType.DateTime)
            funSetColumna(gvDetalle, "ULTIMA_UND_COMPRADAS", "ULTIMA COMPRA UNIDADES", funIndice(), 100, 1, , , "n0", 3, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle, "VENTAS_UNIDADES", "VENTAS EN UNIDADES", funIndice(), 100, 1, , , "n0", 3, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle, "PORCENTAJE", "% VENTAS/COMPRAS", funIndice(), 100, 1, , , "P", 3, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle, "PROM_VTA_DIA", "PROM VENTA UNIDADES", funIndice(), 100, 1, , , "n0", 3, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle, "FECHA_PROYECTADA", "F.PROY.ULTIMA.VENTA", funIndice(), 100, 1)
            '--
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        '--
    End Sub

    Private Sub funCargaData()
        '-- Procesamos el SP, para cargar datos
        Dim CMD As New SqlCommand("sp_RepVentaAltoConsumoDate")
        '--
        Dim strRango1 As String = funFechaSql(Me.dtpDesde1.Value.Date, True)
        Dim strRango2 As String = funFechaSql(Me.dtpHasta1.Value.Date, True)
        '-- Cargar con timeout
        CMD.Parameters.Add("@date1", SqlDbType.NVarChar, 11).Value = strRango1
        CMD.Parameters.Add("@date2", SqlDbType.NVarChar, 11).Value = strRango2
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
            '-- FilePath &= "\Sample\Test\"
            Dim strFileName As String = FilePath & "\repInvAltaRotacion.xlsx"
            Me.gcDetalle.ExportToXlsx(strFileName)
            System.Diagnostics.Process.Start(strFileName)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class