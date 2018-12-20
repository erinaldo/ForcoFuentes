Imports System.IO
Imports OfficeOpenXml
Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmAnalisis

    Dim ds As New DataSet
    Dim nTipoMovGrid As Integer
    Dim i As Integer
    Dim vclArticulo As String
    Dim strChekados As String
    '--
    Dim r As Integer
    Dim dtListaArticulos As DataTable
    Dim strFiltroDataTable As String
    Dim f As FolderBrowserDialog

    Dim dsReporte As DataSet

    Dim FilePath As String

    Shadows focus As Object
    Dim fila As Integer


    Private Sub bClose_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bClose.ItemClick
        Me.Close()
    End Sub

    Private Sub frmComprometidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.txtCodigo.Focus()
    End Sub

    Private Sub bbItem_Click(sender As Object, e As EventArgs) Handles bbItem.Click
        If funValidar() = True Then
            funUpdateGrid()
        End If
    End Sub
    Private Function funValidar() As Boolean
        If Len(Trim(Me.txtCodigo.Text)) = 0 Then
            Me.txtCodigo.Focus()
            MsgBox("Falta el Artículo !!!", MsgBoxStyle.Critical, "Atención !!!")
            Return False
        End If
        Return True
    End Function

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
            funSetColumna(gvDetalle, "SUC_ID", "SUC_ID", funIndice(), 60, 1)
            funSetColumna(gvDetalle, "SUC_NOMBRE", "SUC_NOMBRE", funIndice(), 150, 1)
            funSetColumna(gvDetalle, "CANTIDAD", "CANTIDAD", funIndice(), 90, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle, "PRECIO_TOTAL", "PRECIO_TOTAL", funIndice(), 120, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle, "COSTO_TOTAL", "COSTO_TOTAL", funIndice(), 120, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle, "MARGEN_UTILIDAD", "MARGEN_UTILIDAD", funIndice(), 120, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle, "PROMEDIO_MENSUAL", "PROMEDIO_MENSUAL", funIndice(), 120, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
            '--
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        '--
    End Sub

    Private Sub funCargaData()
        '-- Procesamos el SP, para cargar datos
        Dim strProcedimiento As String = ""
        '-- 
        strProcedimiento = "sp_RepAnalisis"
        '--
        Dim CMD As New SqlCommand(strProcedimiento)
        '--
        Dim strRango1 As String = funFechaSql(Me.dtpDesde1.Value.Date, True)
        Dim strRango2 As String = funFechaSql(Me.dtpHasta1.Value.Date, True)
        Dim strArticulo As String = Trim(txtCodigo.Text)
        '-- Cargar con timeout
        CMD.Parameters.Add("@date1", SqlDbType.NVarChar, 11).Value = strRango1
        CMD.Parameters.Add("@date2", SqlDbType.NVarChar, 11).Value = strRango2
        CMD.Parameters.Add("@articulo", SqlDbType.NVarChar, 50).Value = strArticulo
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

End Class