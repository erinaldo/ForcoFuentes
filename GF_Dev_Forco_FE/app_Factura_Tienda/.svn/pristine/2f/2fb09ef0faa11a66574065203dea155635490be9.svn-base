Imports System.Data
Imports System.Windows.Forms

Module modPrint

    Function funMakeFileName(ByVal strNombre As String)
        Dim strFileName As String
        strFileName = strUser & "_" & Microsoft.VisualBasic.DateAndTime.Timer & "_" & strNombre
        Return strFileName
    End Function

    'Function funCleanTempFiles()
    '    On Error Resume Next
    '    strSQL = Application.StartupPath & "\DatosXML\" & strUser & "*.xml"
    '    Kill(strSQL)
    '    Return True
    'End Function

    Function funPrintConSp(ByVal Reporte As String, _
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
        f.crvReportes.ReportSource = r
        f.ShowDialog()
        '--
        Return True
    End Function

    Public Sub funPrintXml(ByVal ds As DataSet, _
                             ByVal Reporte As String, _
                             Optional ByVal strFecDesdeHasta As String = "", _
                             Optional ByVal strTituloReporte As String = "", _
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
        f.crvReportes.ReportSource = r
        '--f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub

End Module
