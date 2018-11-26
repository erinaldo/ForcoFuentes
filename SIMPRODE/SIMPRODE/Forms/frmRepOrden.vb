Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmRepOrden
    '--
    Dim ds As New DataSet
    Dim dsReporte As DataSet
    Dim FilePath As String

    Private Sub frmRepOrden_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmRepOrden_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'funIniVar()
    End Sub

    Private Sub bbExcel_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbExcel.ItemClick
        If Me.gvDetalle2.RowCount = 0 Then
            MsgBox("No Existen Registros ... !!!", MsgBoxStyle.Critical, "Información")
            Exit Sub
        End If
        Try
            FilePath = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
            Dim strFileName As String = FilePath & "\RepComprasVrsCedi.xlsx"
            Me.gcDetalle2.ExportToXlsx(strFileName)
            System.Diagnostics.Process.Start(strFileName)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub bbRefresh_Click(sender As Object, e As EventArgs) Handles bbRefresh.Click
        funUpdateGrid2()
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
            funSetColumna(gvDetalle2, "PROVEEDOR", "PROVEEDOR", funIndice(), 90, 1)
            funSetColumna(gvDetalle2, "FECHA", "FECHA", funIndice(), 80, 1, , , "d", 0, , DevExpress.Utils.FormatType.DateTime,)
            funSetColumna(gvDetalle2, "ORDEN", "ORDEN", funIndice(), 70, 1)
            funSetColumna(gvDetalle2, "ESTADO", "ESTADO", funIndice(), 80, 1)
            funSetColumna(gvDetalle2, "ARTICULO_ID", "ARTICULO_ID", funIndice(), 80, 1)
            funSetColumna(gvDetalle2, "ARTICULO_NOMBRE", "ARTICULO_NOMBRE", funIndice(), 200, 1)
            funSetColumna(gvDetalle2, "UND_COMPRA", "UNIDAD_COMPRA", funIndice(), 100, 1, , , "n0", 3, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle2, "UND_CEDI", "UNIDAD_CEDI", funIndice(), 100, 1, , , "n0", 3, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle2, "POSICIONES", "POSICIONES", funIndice(), 80, 1)
            funSetColumna(gvDetalle2, "USUARIO", "USUARIO", funIndice(), 120, 1)
            '--
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        '--
    End Sub
    Dim strRango1 As String
    Dim strRango2 As String
    Dim strOrdenes As String

    Private Sub funCargaData2()
        Dim strProcedimiento As String = ""
        '-- Procesamos el SP, para cargar datos
        If chkOrden.Checked = True Then
            strProcedimiento = "sp_RepCompraVrsCediOrden"
            '--
            strOrdenes = Trim(txtOrden.Text)
        Else
            strProcedimiento = "sp_RepCompraVrsCedi"
            '--
            strRango1 = funFechaSql(Me.dtpDesde1.Value.Date, True)
            strRango2 = funFechaSql(Me.dtpHasta1.Value.Date, True)
        End If
        '--        
        Dim CMD As New SqlCommand(strProcedimiento)
        If chkOrden.Checked = True Then
            CMD.Parameters.Add("@ids", SqlDbType.NVarChar, 3000).Value = strOrdenes
        Else
            CMD.Parameters.Add("@date1", SqlDbType.NVarChar, 11).Value = strRango1
            CMD.Parameters.Add("@date2", SqlDbType.NVarChar, 11).Value = strRango2
        End If
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

    Private Sub chkOrden_CheckedChanged(sender As Object, e As EventArgs) Handles chkOrden.CheckedChanged
        If chkOrden.Checked = True Then
            Me.txtOrden.Enabled = True
            Me.dtpDesde1.Enabled = False
            Me.dtpHasta1.Enabled = False
            Me.txtOrden.Focus()
        Else
            Me.txtOrden.Enabled = False
            Me.dtpDesde1.Enabled = True
            Me.dtpHasta1.Enabled = True
            Me.dtpDesde1.Focus()
        End If
    End Sub
End Class