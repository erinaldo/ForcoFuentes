Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmRepPrecios
    '--
    Dim ds As DataSet
    Dim dsReporte As DataSet
    Dim FilePath As String

    Private Sub frmRepPrecios_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmRepPrecios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        funIniVar()
    End Sub
    Private Function funIniVar()
        '--
        Try
            '--
            funCargaTineda1()
            Me.lkTienda1.EditValue = 1
            '--
        Catch ex As Exception
            MsgBox("Se ha producido el siguiente error: " + ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            '-- Apagar botones
        End Try
        '--
        Return True
    End Function

    Private Function funCargaTineda1()
        '-- Cargar Tienda 1
        strSQL = "SELECT Suc_Id AS nCodigo, Suc_Nombre AS strDescripcion FROM Sucursal ORDER BY nCodigo"
        '--
        funCargarLue(Me.lkTienda1, strSQL)
        '-- 
        Return True
    End Function
    Private Function funCargaTineda2()
        '-- Cargar Tienda 1
        strSQL = "SELECT Suc_Id AS nCodigo, Suc_Nombre AS strDescripcion FROM Sucursal " &
                    "WHERE Suc_id <> " & vnTienda1 &
                    " ORDER BY nCodigo"
        '--
        funCargarLue(Me.lkTienda2, strSQL)
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
        If Len(Trim(Me.lkTienda1.Text)) = 0 Then
            Me.lkTienda1.Focus()
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
            funSetColumna(gvDetalle, "ARTICULO", "ARTICULO", funIndice(), 80, 1)
            funSetColumna(gvDetalle, "NOMBRE", "ARTICULO_NOMBRE", funIndice(), 300, 1)
            funSetColumna(gvDetalle, "PRECIO_TIENDA_1", "PRECIO_TIENDA_1", funIndice(), 120, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle, "PRECIO_TIENDA_2", "PRECIO_TIENDA_2", funIndice(), 120, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle, "DIFERENCIA", "DIFERENCIA", funIndice(), 120, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
            '--
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        '--
    End Sub

    Private Sub funCargaData()
        '--
        Dim strProcedimiento As String = ""
        '-- Procesamos el SP, para cargar datos
        If Me.optOpcion.SelectedIndex = 0 Then
            strProcedimiento = "sp_RepPrecios"
        ElseIf Me.optOpcion.SelectedIndex = 1 Then
            strProcedimiento = "sp_RepPrecios"
        End If
        '--
        Dim CMD As New SqlCommand(strProcedimiento)
        '--
        Dim nTienda1 As Integer = lkTienda1.EditValue
        Dim nTienda2 As Integer = lkTienda2.EditValue
        Dim nReporte As Integer = Me.optOpcion.SelectedIndex + 1
        '-- Cargar con timeout
        CMD.Parameters.Add("@tienda1", SqlDbType.Int).Value = nTienda1
        CMD.Parameters.Add("@tienda2", SqlDbType.Int).Value = nTienda2
        CMD.Parameters.Add("@reporte", SqlDbType.Int).Value = nReporte
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

    Dim vnTienda1 As Integer
    Private Sub lkTienda1_EditValueChanged(sender As Object, e As EventArgs) Handles lkTienda1.EditValueChanged
        If lkTienda1.EditValue > 0 Then
            funClearGrid()
            vnTienda1 = lkTienda1.EditValue
            funCargaTineda2()
        End If
    End Sub
    Private Function funClearGrid()
        Me.gcDetalle.DataSource = Nothing
        Me.gvDetalle.Columns.Clear()
    End Function

    Private Sub lkTienda2_EditValueChanged(sender As Object, e As EventArgs) Handles lkTienda2.EditValueChanged
        funClearGrid()
    End Sub
End Class