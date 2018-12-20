Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Windows
Imports CrystalDecisions.Shared

Public Class Frm_exportreport
    Dim Reporte As New ReportDocument
    Dim nombrearchivo As String
    Dim crConnectionInfo As New ConnectionInfo()
    Dim crtableLogoninfos As New TableLogOnInfos()
    Dim crtableLogoninfo As New TableLogOnInfo()
    Dim CrTables As Tables
    Dim CrTable As Table
    Public I As Short
    Public Localiza As String
    Private exportPath As String
    Private myDiskFileDestinationOptions As DiskFileDestinationOptions
    Private myExportOptions As ExportOptions
    Private selectedNoFormat As Boolean = False
    Public FormatoExport As New ExportFormatType

    Private Sub Frm_printreport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        abrirconexion()
        Cargacombo()
        esconde_campos()
    End Sub
    Private Sub ConfigureCrystalReports()
        Reporte.Load(rutareporte)
        Reporte.Database.Dispose()
        Reporte.Database.Tables.Dispose()
        With crConnectionInfo
            .ServerName = Conexion.DataSource.ToString
            .DatabaseName = Conexion.Database.ToString
            .UserID = "UserReport"
            .Password = "rep1014usr"
        End With
        CrTables = Reporte.Database.Tables
        For Each Me.CrTable In CrTables
            crtableLogoninfo = CrTable.LogOnInfo
            crtableLogoninfo.ConnectionInfo = crConnectionInfo
            CrTable.ApplyLogOnInfo(crtableLogoninfo)
            CrTable.Location = Conexion.Database.ToString & ".dbo." & CrTable.Location.Substring(CrTable.Location.LastIndexOf(".") + 1)
        Next
        Reporte.SummaryInfo.ReportTitle = Vnomcia
        Reporte.SummaryInfo.ReportComments = Comentarios
        If Vformula <> "" Then
            Reporte.RecordSelectionFormula = Vformula
        End If
    End Sub
    Public Sub ExportSetup()
        exportPath = "C:\ExportadosCrystal\"

        If Not System.IO.Directory.Exists(exportPath) Then
            System.IO.Directory.CreateDirectory(exportPath)
        End If
        myDiskFileDestinationOptions = New DiskFileDestinationOptions()
        myExportOptions = Reporte.ExportOptions
        myExportOptions.ExportDestinationType = ExportDestinationType.DiskFile
        myExportOptions.FormatOptions = Nothing
    End Sub
    Public Sub ExportSelection()
        ConfigureExportToXLSRecord()
    End Sub

    Public Sub ExportCompletion()
        Try
            If selectedNoFormat Then
                message.Text = ConsMensajes.FORMAT_NOT_SUPPORTED
            Else
                Reporte.Export()
                message.Text = ConsMensajes.SUCCESS
            End If
        Catch ex As Exception
            message.Text = ConsMensajes.FAILURE & ex.Message
        End Try

        message.Visible = True
        selectedNoFormat = False
    End Sub

    Public Sub ConfigureExportToXLSRecord()
        If nombrearchivo.Length = 0 Or nombrearchivo.ToString = "*.xls" Then
            nombrearchivo = "ExcelRecord.xls"
        Else
            If Not (nombrearchivo.ToString.EndsWith(".xls")) Then
                nombrearchivo = nombrearchivo.ToString & ".xls"
            End If
        End If
        myExportOptions.ExportFormatType = ExportFormatType.ExcelRecord
        myDiskFileDestinationOptions.DiskFileName = exportPath & nombrearchivo.ToString
        myExportOptions.DestinationOptions = myDiskFileDestinationOptions
    End Sub
    Public Sub ExportRun()
        Dim archivoejecuta As String
        archivoejecuta = exportPath & nombrearchivo.ToString
        System.Diagnostics.Process.Start(archivoejecuta)
    End Sub

    Private Sub b_generatodo_Click(sender As Object, e As EventArgs) Handles b_generatodo.Click
        muestra_campos()
        Vbodega = ""
        comandoledb4.CommandText = "Select Bodega_Id,Bodega_Nombre from dbo.Bodega order by bodega_id asc"
        comandoledb4.CommandType = CommandType.Text
        comandoledb4.Connection = Conexion
        Cbodegas = comandoledb4.ExecuteReader
        If Cbodegas.HasRows Then
            comandoledb2.CommandText = "[DBO].[CREA_EXISCEDI_TEMP]"
            comandoledb2.Connection = Conexion
            comandoledb2.CommandTimeout = 300
            comandoledb2.CommandType = CommandType.StoredProcedure
            comandoledb2.ExecuteNonQuery()

            Do While Cbodegas.Read()
                Vbodega = Cbodegas.Item(0).ToString
                comandoledb.CommandText = "[DBO].[CREA_VIEW_COMPARATIENDAS]"
                comandoledb.Connection = Conexion
                comandoledb.CommandType = CommandType.StoredProcedure
                comandoledb.Parameters.Add(New OleDb.OleDbParameter("bodega", Vbodega))
                comandoledb.ExecuteNonQuery()
                Txtbodega.Text = Cbodegas.Item(0).ToString
                txtnombre.Text = Cbodegas.Item(1).ToString
                rutareporte = rutainventario & "Reporte Comparativo CEDI-TIENDA.rpt"
                nombrearchivo = Cbodegas.Item(0).ToString + "-" + Cbodegas.Item(1).ToString + " " + Date.Today.Day.ToString + "-" + Date.Today.Month.ToString + "-" + Date.Today.Year.ToString + ".xls"
                message.Text = "Generando...."
                ConfigureCrystalReports()
                ExportSetup()
                ExportSelection()
                ExportCompletion()
                ExportRun()
                Reporte.Close()
                comandoledb.Parameters.Clear()
                'If MsgBox("Desea Continuar ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.No Then
                '    Exit Do
                'End If
            Loop
        Else
            MsgBox("No Hay bodegas para mostrar", MsgBoxStyle.Critical, "Información")
        End If
        Cbodegas.Close()
        MsgBox("Reportes Generados", MsgBoxStyle.Information, "Información")
        esconde_campos()
    End Sub

    Private Sub Cargacombo()
        cmb_bodegas.Items.Clear()
        comandoledb4.CommandText = "Select Bodega_Id,Bodega_Nombre from dbo.Bodega order by bodega_id asc"
        comandoledb4.CommandType = CommandType.Text
        comandoledb4.Connection = Conexion
        Cbodegas = comandoledb4.ExecuteReader
        Do While Cbodegas.Read()
            cmb_bodegas.Items.Add(Cbodegas.Item(0).ToString & "-" & Cbodegas.Item(1).ToString)
        Loop
        Cbodegas.Close()

    End Sub

    Private Sub b_genera_Click(sender As Object, e As EventArgs) Handles b_genera.Click
        muestra_campos()
        Dim separador As String = "-"
        Dim matriz() As String = cmb_bodegas.SelectedItem.ToString.Split(separador.ToCharArray)
        Vbodega = matriz(0).ToString
        comandoledb2.CommandText = "[DBO].[CREA_EXISCEDI_TEMP]"
        comandoledb2.Connection = Conexion
        comandoledb2.CommandTimeout = 300
        comandoledb2.CommandType = CommandType.StoredProcedure
        comandoledb2.ExecuteNonQuery()

        comandoledb.CommandText = "[DBO].[CREA_VIEW_COMPARATIENDAS]"
        comandoledb.Connection = Conexion
        comandoledb.CommandType = CommandType.StoredProcedure
        comandoledb.Parameters.Add(New OleDb.OleDbParameter("bodega", Vbodega))
        comandoledb.ExecuteNonQuery()
        Txtbodega.Text = matriz(0).ToString
        txtnombre.Text = matriz(1).ToString
        rutareporte = rutainventario & "Reporte Comparativo CEDI-TIENDA.rpt"
        nombrearchivo = matriz(0).ToString + "-" + matriz(1).ToString + " " + Date.Today.Day.ToString + "-" + Date.Today.Month.ToString + "-" + Date.Today.Year.ToString + ".xls"
        message.Text = "Generando...."
        ConfigureCrystalReports()
        ExportSetup()
        ExportSelection()
        ExportCompletion()
        ExportRun()
        Reporte.Close()
        comandoledb.Parameters.Clear()
        MsgBox("Reportes Generado", MsgBoxStyle.Information, "Información")
        esconde_campos()
    End Sub

    Private Sub esconde_campos()
        Txtbodega.Hide()
        txtnombre.Hide()
        Label2.Hide()
    End Sub

    Private Sub muestra_campos()
        Txtbodega.Show()
        txtnombre.Show()
        Label2.Show()

    End Sub
End Class