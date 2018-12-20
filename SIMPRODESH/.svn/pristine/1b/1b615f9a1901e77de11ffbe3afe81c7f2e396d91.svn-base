Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmRepCostoSuc

    Dim i As Integer
    Dim dsReporte As DataSet

    Private Sub frmRepCostoSuc_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
            funSetColumna(gvDetalle, "ARTICULO", "CODIGO", funIndice(), 90, 1)
            funSetColumna(gvDetalle, "ARTICULO_NOMBRE", "NOMBRE DE ARTICULO", funIndice(), 150, 1)
            funSetColumna(gvDetalle, "EXISTE_ACTUAL", "EXIST.ACTUAL", funIndice(), 90, 1, , , "n0", 3, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle, "ENTRADAS", "ENTRADAS", funIndice(), 80, 1, , , "n0", 3, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle, "SALIDAS", "SALIDAS", funIndice(), 80, 1, , , "n0", 3, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle, "EXISTE_CORTE", "EXIST.AL.CORTE", funIndice(), 90, 1, , , "n0", 3, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle, "COSTO_UNITARIO_ACTUAL", "COSTO.UNIT", funIndice(), 90, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle, "COSTO_TOTAL_CORTE", "COSTO.TOTAL", funIndice(), 90, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle, "PMAYOR", "MAYOR", funIndice(), 80, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle, "PDETALLE", "MAYOR", funIndice(), 80, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle, "FECHA_CORTE", "FECHA.DE.CORTE", funIndice(), 80, 1)
            '--
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        '--
    End Sub

    Private Sub funCargaData()
        '-- Procesamos el SP, para cargar datos
        Dim CMD As New SqlCommand("sp_RepValorInvSucArt")
        '--
        Dim nTienda As Integer = Me.lkTienda.EditValue
        Dim strRango1 As String = funFechaSql(Me.dtpDesde1.Value.Date, True)
        '-- Cargar con timeout
        CMD.Parameters.Add("@suc_id", SqlDbType.Int).Value = nTienda
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
            Dim strFileName As String = FilePath & "\repInvValorSuc.xlsx"
            Me.gcDetalle.ExportToXlsx(strFileName)
            System.Diagnostics.Process.Start(strFileName)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub bbRefresh_Click_1(sender As Object, e As EventArgs) Handles bbRefresh.Click
        funUpdateGrid()
    End Sub

    Private Sub frmRepCostoSuc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        funCargaCombos()
    End Sub

    Private Function funCargaCombos()
        '-- Cargar Empresa
        strSQL = "SELECT SUC_ID AS nCodigo, SUC_NOMBRE AS strDescripcion " & _
                    " FROM Sucursal " & _
                    " ORDER BY SUC_NOMBRE"
        '--
        funCargarLue(Me.lkTienda, strSQL)
        '--
        Return True
    End Function
End Class