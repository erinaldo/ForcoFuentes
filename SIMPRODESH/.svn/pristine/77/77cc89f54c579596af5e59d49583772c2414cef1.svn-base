Imports System.Data
Imports System.Windows.Forms

Module modPrint

    Function funMakeFileName(ByVal strNombre As String)
        Dim strFileName As String
        strFileName = strUser & "_" & Microsoft.VisualBasic.DateAndTime.Timer & "_" & strNombre
        Return strFileName
    End Function

    Function funPrintConSp(ByVal Reporte As String,
                        ByVal lstParametros As List(Of String))
        '-- @GB: 15-08-2010
        '-- Imprime reportes basados en stored procedures, pasando el nombre del reporte y los parametros.
        '-- La lista de parametros son asigandos en la rutina desde donde se llama la funciÓn.
        '-- Los parametros para rotulos (empresa, fechas, etc), se deben agregar en el SP, y deben de reasignarse
        '--  a formulas en el reporte, para evitar problemas al momento de cambiar de origen de datos. 
        '-- 
        Dim strCnxConfianza As String = ""
        Dim f As New frmReportes
        Dim r As New CrystalDecisions.CrystalReports.Engine.ReportDocument

        r.Load(Application.StartupPath & "\Reportes\" & Reporte)
        '--
        Dim tbCurrent As CrystalDecisions.CrystalReports.Engine.Table
        Dim tliCurrent As CrystalDecisions.Shared.TableLogOnInfo
        '-- Obtenemos la configuración actual de origen de datos del reportes
        For Each tbCurrent In r.Database.Tables
            tliCurrent = tbCurrent.LogOnInfo
            With tliCurrent.ConnectionInfo
                .ServerName = strServidor
                .DatabaseName = strBaseDatos
                If strCnxConfianza.ToLower = "true" Then
                    .IntegratedSecurity = True
                Else
                    .UserID = strUserSql
                    .Password = strKey
                End If
            End With
            '-- Aplicamos la nueva configuracion de origen de datos
            tbCurrent.ApplyLogOnInfo(tliCurrent)
        Next tbCurrent
        '--
        r.VerifyDatabase()
        '-- Agregamos los parametros
        For i As Integer = 0 To lstParametros.Count - 1
            r.SetParameterValue(i, lstParametros(i))
        Next
        '-- View Reports
        f.CrystalReportViewer1.ReportSource = r
        f.WindowState = FormWindowState.Maximized
        f.ShowDialog()
        '--
        Return True
    End Function

    Function funImprimirXml_New(ByVal ds As DataSet,
                         ByVal Reporte As String,
                         Optional ByVal strFecDesdeHasta As String = "",
                         Optional ByVal strTituloReporte As String = "",
                         Optional ByVal SubReporte As Boolean = False,
                         Optional ByVal RepDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument = Nothing,
                         Optional ByVal bMostrar As Boolean = True)

        Dim f As New frmReportes
        '-- funSetEmpresaDataset(ds, strFecDesdeHasta, strTituloReporte)

        'strSQL = Application.StartupPath & "\DatosXML\" & funMakeFileName(Reporte & ".xml")
        strSQL = My.Computer.FileSystem.SpecialDirectories.Temp.ToString & "\" & funMakeFileName(Reporte & ".xml")
        ds.WriteXml(strSQL, XmlWriteMode.WriteSchema)
        RepDoc.Database.Tables(0).Location = strSQL

        If SubReporte = True Then
            RepDoc.Subreports(0).Database.Tables(0).Location = strSQL
        End If

        f.CrystalReportViewer1.ReportSource = RepDoc
        f.WindowState = FormWindowState.Maximized
        'f.crvReportes.PrintReport()
        If bMostrar Then
            f.ShowDialog()
        End If
        Return True
    End Function

    Public Sub funPrintXml(ByVal ds As DataSet,
                             ByVal Reporte As String,
                             Optional ByVal strFecDesdeHasta As String = "",
                             Optional ByVal strTituloReporte As String = "",
                             Optional ByVal SubReporte As Boolean = False)
        '-- 11-09-2010: Función para imprimir con archivos Xml
        Dim f As New frmReportes
        Dim r As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        '--
        r.FileName = Application.StartupPath & "\Reportes\" & Reporte
        strSQL = Application.StartupPath & "\DatosXML\" & funMakeFileName(Reporte & ".xml")
        ds.WriteXml(strSQL, XmlWriteMode.WriteSchema)
        r.Database.Tables(0).Location = strSQL
        '--
        If SubReporte = True Then
            r.Subreports(0).Database.Tables(0).Location = strSQL
        End If
        '--
        f.CrystalReportViewer1.ReportSource = r
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub


End Module

