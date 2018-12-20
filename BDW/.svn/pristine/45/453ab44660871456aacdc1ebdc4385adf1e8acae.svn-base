Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Windows
Imports CrystalDecisions.Shared

Public Class Frm_printreport
    Dim Reporte As New ReportDocument
    Dim crtableLogoninfos As New TableLogOnInfos()
    Dim crtableLogoninfo As New TableLogOnInfo()
    Dim crConnectionInfo As New ConnectionInfo()
    Dim CrTables As Tables
    Dim CrTable As Table
    Public Localiza As String
    Private exportPath As String
    Private myDiskFileDestinationOptions As DiskFileDestinationOptions
    Private myExportOptions As ExportOptions
    Private selectedNoFormat As Boolean = False
    Public FormatoExport As New ExportFormatType

    Private Sub Frm_printreport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'abrirconexion()
        ConfigureCrystalReports()
    End Sub

    'Private Sub ConfigureCrystalReports()

    '    Try
    '        exportTypesList.DataSource = System.Enum.GetValues(GetType(ExportFormatType))
    '        Reporte.Load(rutareporte)
    '        Reporte.Database.Dispose()
    '        With crConnectionInfo
    '            .ServerName = Conexion.DataSource.ToString
    '            .DatabaseName = Conexion.Database.ToString
    '            .UserID = "UserReport"
    '            .Password = "rep1014usr"
    '        End With
    '        CrTables = Reporte.Database.Tables
    '        For Each Me.CrTable In CrTables
    '            crtableLogoninfo = CrTable.LogOnInfo
    '            crtableLogoninfo.ConnectionInfo = crConnectionInfo
    '            CrTable.ApplyLogOnInfo(crtableLogoninfo)
    '            CrTable.Location = Conexion.Database.ToString & ".dbo." & CrTable.Location.Substring(CrTable.Location.LastIndexOf(".") + 1)
    '        Next
    '        Reporte.SummaryInfo.ReportTitle = Vnomcia
    '        Reporte.SummaryInfo.ReportComments = Comentarios
    '        If Vformula <> "" Then
    '            Reporte.RecordSelectionFormula = Vformula
    '        End If
    '        Visor_Reporte.ReportSource = Reporte
    '        Visor_Reporte.Cursor = Windows.Forms.Cursors.Arrow

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub

    Private Sub ConfigureCrystalReports()

        Try
            exportTypesList.DataSource = System.Enum.GetValues(GetType(ExportFormatType))
            Reporte.Load(rutareporte)
            Reporte.Database.Dispose()
            With crConnectionInfo
                If conexionRH = True Then
                    abrirconexion2()
                    .ServerName = Conexion2.DataSource.ToString
                    .DatabaseName = Conexion2.Database.ToString
                Else
                    abrirconexion()
                    .ServerName = Conexion.DataSource.ToString
                    .DatabaseName = Conexion.Database.ToString
                End If
                .UserID = "UserReport"
                .Password = "rep1014usr"
            End With
            conexionRH = False
            CrTables = Reporte.Database.Tables
            For Each Me.CrTable In CrTables
                crtableLogoninfo = CrTable.LogOnInfo
                crtableLogoninfo.ConnectionInfo = crConnectionInfo
                CrTable.ApplyLogOnInfo(crtableLogoninfo)
                CrTable.Location = Conexion.Database.ToString & ".dbo." & CrTable.Location.Substring(CrTable.Location.LastIndexOf(".") + 1)
            Next
            '--
            Reporte.SummaryInfo.ReportTitle = Vnomcia
            Reporte.SummaryInfo.ReportComments = Comentarios
            If Vformula <> "" Then
                Reporte.RecordSelectionFormula = Vformula
            End If
            Visor_Reporte.ReportSource = Reporte
            Visor_Reporte.Cursor = Windows.Forms.Cursors.Arrow

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
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
        Select Case exportTypesList.SelectedIndex

            Case ExportFormatType.NoFormat
                selectedNoFormat = True
            Case ExportFormatType.CrystalReport
                ConfigureExportToRpt()
            Case ExportFormatType.RichText
                ConfigureExportToRtf()
            Case ExportFormatType.WordForWindows
                selectedNoFormat = True
            Case ExportFormatType.Excel
                ConfigureExportToXls()
            Case ExportFormatType.PortableDocFormat
                ConfigureExportToPdf()
            Case ExportFormatType.HTML32
                ConfigureExportToHtml32()
            Case ExportFormatType.HTML40
                ConfigureExportToHtml40()
            Case ExportFormatType.ExcelRecord
                ConfigureExportToXLSRecord()
        End Select
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

    Public Sub ConfigureExportToRpt()
        If Txtarchivo.Text.Length = 0 Or Txtarchivo.Text = "*.rpt" Then
            Txtarchivo.Text = "Report.rpt"
        Else
            If Not (Txtarchivo.Text.EndsWith(".rpt")) Then
                Txtarchivo.Text = Txtarchivo.Text & ".rpt"
            End If
        End If
        myExportOptions.ExportFormatType = ExportFormatType.CrystalReport
        myDiskFileDestinationOptions.DiskFileName = exportPath & Txtarchivo.Text
        myExportOptions.DestinationOptions = myDiskFileDestinationOptions
    End Sub

    Public Sub ConfigureExportToRtf()
        If Txtarchivo.Text.Length = 0 Or Txtarchivo.Text = "*.rtf" Then
            Txtarchivo.Text = "RichTextFormat.rtf"
        Else
            If Not (Txtarchivo.Text.EndsWith(".rtf")) Then
                Txtarchivo.Text = Txtarchivo.Text & ".rtf"
            End If
        End If
        myExportOptions.ExportFormatType = ExportFormatType.RichText
        myDiskFileDestinationOptions.DiskFileName = exportPath & Txtarchivo.Text
        myExportOptions.DestinationOptions = myDiskFileDestinationOptions
    End Sub

    Public Sub ConfigureExportToDoc()
        If Txtarchivo.Text.Length = 0 Or Txtarchivo.Text = "*.doc" Then
            Txtarchivo.Text = "Word.doc"
        Else
            If Not (Txtarchivo.Text.EndsWith(".doc")) Then
                Txtarchivo.Text = Txtarchivo.Text & ".doc"
            End If
        End If
        myExportOptions.ExportFormatType = ExportFormatType.WordForWindows
        myDiskFileDestinationOptions.DiskFileName = exportPath & Txtarchivo.Text
        myExportOptions.DestinationOptions = myDiskFileDestinationOptions
    End Sub

    Public Sub ConfigureExportToXls()
        If Txtarchivo.Text.Length = 0 Or Txtarchivo.Text = "*.xls" Then
            Txtarchivo.Text = "Excel.xls"
        Else
            If Not (Txtarchivo.Text.EndsWith(".xls")) Then
                Txtarchivo.Text = Txtarchivo.Text & ".xls"
            End If
        End If
        myExportOptions.ExportFormatType = ExportFormatType.Excel
        myDiskFileDestinationOptions.DiskFileName = exportPath & Txtarchivo.Text
        myExportOptions.DestinationOptions = myDiskFileDestinationOptions
    End Sub

    Public Sub ConfigureExportToPdf()
        If Txtarchivo.Text.Length = 0 Or Txtarchivo.Text = "*.pdf" Then
            Txtarchivo.Text = "PortableDoc.pdf"
        Else
            If Not (Txtarchivo.Text.EndsWith(".pdf")) Then
                Txtarchivo.Text = Txtarchivo.Text & ".pdf"
            End If
        End If
        myExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat
        myDiskFileDestinationOptions.DiskFileName = exportPath & Txtarchivo.Text
        myExportOptions.DestinationOptions = myDiskFileDestinationOptions
    End Sub

    Public Sub ConfigureExportToHtml32()
        If Txtarchivo.Text.Length = 0 Or Txtarchivo.Text = "*.html" Then
            Txtarchivo.Text = "html32.html"
        Else
            If Not (Txtarchivo.Text.EndsWith(".html")) Then
                Txtarchivo.Text = Txtarchivo.Text & ".html"
            End If
        End If
        myExportOptions.ExportFormatType = ExportFormatType.HTML32
        Dim html32FormatOptions As HTMLFormatOptions = New HTMLFormatOptions()
        html32FormatOptions.HTMLBaseFolderName = exportPath & "Html32Folder"
        html32FormatOptions.HTMLFileName = Txtarchivo.Text
        html32FormatOptions.HTMLEnableSeparatedPages = False
        html32FormatOptions.HTMLHasPageNavigator = False
        myExportOptions.FormatOptions = html32FormatOptions
    End Sub

    Public Sub ConfigureExportToHtml40()
        If Txtarchivo.Text.Length = 0 Or Txtarchivo.Text = "*.html" Then
            Txtarchivo.Text = "html40.html"
        Else
            If Not (Txtarchivo.Text.EndsWith(".html")) Then
                Txtarchivo.Text = Txtarchivo.Text & ".html"
            End If
        End If
        myExportOptions.ExportFormatType = ExportFormatType.HTML40
        Dim html40FormatOptions As HTMLFormatOptions = New HTMLFormatOptions()
        html40FormatOptions.HTMLBaseFolderName = exportPath & "Html40Folder"
        html40FormatOptions.HTMLFileName = Txtarchivo.Text
        html40FormatOptions.HTMLEnableSeparatedPages = True
        html40FormatOptions.HTMLHasPageNavigator = True
        html40FormatOptions.FirstPageNumber = 1
        html40FormatOptions.LastPageNumber = 3
        myExportOptions.FormatOptions = html40FormatOptions
    End Sub
    Public Sub ConfigureExportToXLSRecord()
        If Txtarchivo.Text.Length = 0 Or Txtarchivo.Text = "*.xls" Then
            Txtarchivo.Text = "ExcelRecord.xls"
        Else
            If Not (Txtarchivo.Text.EndsWith(".xls")) Then
                Txtarchivo.Text = Txtarchivo.Text & ".xls"
            End If
        End If
        myExportOptions.ExportFormatType = ExportFormatType.ExcelRecord
        myDiskFileDestinationOptions.DiskFileName = exportPath & Txtarchivo.Text
        myExportOptions.DestinationOptions = myDiskFileDestinationOptions
    End Sub
    Public Sub ExportRun()
        Dim archivoejecuta As String
        archivoejecuta = exportPath & Txtarchivo.Text
        System.Diagnostics.Process.Start(archivoejecuta)
    End Sub

    Private Sub exportByType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exportByType.Click
        ExportSetup()
        ExportSelection()
        ExportCompletion()
        ExportRun()
    End Sub

    Private Sub exportTypesList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exportTypesList.SelectedIndexChanged
    End Sub

    Private Sub exportTypesList_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles exportTypesList.SelectedValueChanged
        Select Case exportTypesList.SelectedIndex

            Case ExportFormatType.CrystalReport
                Txtarchivo.Text = "*.rpt"
            Case ExportFormatType.RichText
                Txtarchivo.Text = "*.rtf"
            Case ExportFormatType.WordForWindows
                Txtarchivo.Text = "*.doc"
            Case ExportFormatType.Excel
                Txtarchivo.Text = "*.xls"
            Case ExportFormatType.PortableDocFormat
                Txtarchivo.Text = "*.pdf"
            Case ExportFormatType.HTML32
                Txtarchivo.Text = "*.html"
            Case ExportFormatType.HTML40
                Txtarchivo.Text = "*.html"
            Case ExportFormatType.ExcelRecord
                Txtarchivo.Text = "*.xls"
        End Select

    End Sub

    Private Sub Frm_printreport_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        cerrarconexion()
    End Sub
End Class