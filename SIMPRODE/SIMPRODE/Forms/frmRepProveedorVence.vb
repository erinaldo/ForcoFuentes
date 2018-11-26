Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmRepProveedorVence
    '--
    Dim ds As New DataSet
    Dim dsReporte As DataSet
    Dim FilePath As String

    Private Sub frmRepArticuloNoDespacho_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
            Dim strFileName As String = FilePath & "\repProveedorVence.xlsx"
            Me.gcDetalle2.ExportToXlsx(strFileName)
            System.Diagnostics.Process.Start(strFileName)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Function funValidar() As Boolean
        Dim vnDollar As Integer = 1
        If vnDollar = 0 Then
            dtpDesde1.Focus()
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
            '--
            GridViewStyle(Me.gvDetalle2)
            funOcultarTodasLasColumnas(Me.gvDetalle2)
            indice = 0
            '--
            funSetColumna(gvDetalle2, "ORDEN", "ORDEN", funIndice(), 90, 1)
            funSetColumna(gvDetalle2, "FECHA", "FECHA", funIndice(), 90, 1, , , "d", 0, , DevExpress.Utils.FormatType.DateTime)
            funSetColumna(gvDetalle2, "PROVEEDOR", "PROVEEDOR", funIndice(), 150, 1)
            funSetColumna(gvDetalle2, "ARTICULO_ID", "ARTICULO_ID", funIndice(), 80, 1)
            funSetColumna(gvDetalle2, "ARTICULO_NOMBRE", "ARTICULO_NOMBRE", funIndice(), 300, 1)
            funSetColumna(gvDetalle2, "CANTIDAD", "CANTIDAD", funIndice(), 150, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
            With gvDetalle2
                .Columns("ORDEN").Group()
                .Columns("ORDEN").Caption = "ORDEN"
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

    Private Sub funCargaData2()
        '-- Procesamos el SP, para cargar datos
        '--
        Dim CMD As New SqlCommand("sp_RepComprasVence")
        '--
        Dim strRango1 As String = funFechaSql(Me.dtpDesde1.Value.Date, True)
        Dim strRango2 As String = funFechaSql(Me.dtpHasta1.Value.Date, True)
        Dim nSucursal As Integer = Me.lkSucursal.EditValue
        '-- Cargar con timeout
        CMD.Parameters.Add("@date1", SqlDbType.NVarChar, 11).Value = strRango1
        CMD.Parameters.Add("@date2", SqlDbType.NVarChar, 11).Value = strRango2
        CMD.Parameters.Add("@sucursal", SqlDbType.Int).Value = nSucursal
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

    Private Sub frmRepProveedorVence_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        funCargaCombos()
    End Sub

    Private Function funCargaCombos()
        '-- Cargar Empresa
        strSQL = "SELECT 0 AS nCodigo, 'Seleccionar Sucursal' AS strDescripcion"
        strSQL += " UNION SELECT Suc_Id AS nCodigo, Suc_Nombre AS strDescripcion FROM Sucursal WHERE Suc_Id IN(1100, 1001) ORDER BY nCodigo"
        '-- strSQL = "SELECT Suc_Id AS nCodigo, Suc_Nombre AS strDescripcion FROM Sucursal WHERE Suc_Id IN(1100, 1001) ORDER BY nCodigo"
        '--
        funCargarLue(Me.lkSucursal, strSQL)
        '--
        Me.lkSucursal.EditValue = CDbl(1)
        Return True
    End Function
End Class