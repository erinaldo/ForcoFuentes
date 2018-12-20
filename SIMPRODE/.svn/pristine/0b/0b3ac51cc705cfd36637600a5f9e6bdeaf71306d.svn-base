Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmRepCostoSucConArt
    Public nCode As Integer
    Public dtmCorte As Date
    Dim dsReporte As DataSet

    Private Sub frmRepCostoSucConDet_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        funUpdateGrid()
    End Sub

    Private Function funUpdateGrid()
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
            funSetColumna(gvDetalle, "ARTICULO", "COD.", funIndice(), 90, 1)
            funSetColumna(gvDetalle, "Articulo_Nombre", "ARTICULO", funIndice(), 150, 1)
            funSetColumna(gvDetalle, "EXI_ACTUAL", "EXIST.ACTUAL", funIndice(), 80, 1, , , "n0", 3, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle, "ENTRADAS", "ENTRADAS", funIndice(), 70, 1, , , "n0", 3, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle, "SALIDAS", "SALIDAS", funIndice(), 70, 1, , , "n0", 3, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle, "EXI_AL_CORTE", "EXIST.AL.CORTE", funIndice(), 80, 1, , , "n0", 3, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle, "COSTO_TOTAL_CORTE", "COSTO.TOTAL", funIndice(), 80, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
            funSetColumna(gvDetalle, "COSTO_PROMEDIO", "COSTO.PROMEDIO", funIndice(), 80, 1, , , "n2", 3, , DevExpress.Utils.FormatType.Numeric)
            '--
            With gvDetalle
                '-- Existencia
                .GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "EXI_AL_CORTE", .Columns("EXI_AL_CORTE"), "{0:n2}")
                .Columns("EXI_AL_CORTE").SummaryItem.FieldName = "EXI_AL_CORTE"
                .Columns("EXI_AL_CORTE").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                .Columns("EXI_AL_CORTE").SummaryItem.DisplayFormat = "{0:n0}"
                .OptionsView.ShowFooter = True

                '-- Suma Montos
                .GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "COSTO_TOTAL_CORTE", .Columns("COSTO_TOTAL_CORTE"), "{0:n2}")
                .Columns("COSTO_TOTAL_CORTE").SummaryItem.FieldName = "COSTO_TOTAL_CORTE"
                .Columns("COSTO_TOTAL_CORTE").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                .Columns("COSTO_TOTAL_CORTE").SummaryItem.DisplayFormat = "{0:n2}"
                .OptionsView.ShowFooter = True
            End With
            '--
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        '--
        Return True
    End Function

    Private Sub bbClose_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbClose.ItemClick
        Me.Close()
    End Sub

    Private Sub funCargaData()
        '-- Procesamos el SP, para cargar datos
        Dim CMD As New SqlCommand("sp_RepValorInvDetalle")
        '--
        Dim nTienda As Integer = nCode
        Dim strRango1 As String = funFechaSql(dtmCorte, True)
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
End Class