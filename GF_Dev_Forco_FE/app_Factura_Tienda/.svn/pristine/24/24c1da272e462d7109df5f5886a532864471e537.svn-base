Imports System
Imports System.Windows.Forms

Namespace sysMHCP
    Friend NotInheritable Class Program
        Private Sub New()
        End Sub
        <STAThread()> _
        Shared Sub Main()
            '--
            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            '-- Skin DevExpress
            funMain()
            '-- Si es la pc de desarrollo actualiza
            Dim strDeveloper As String = SystemInformation.ComputerName
            If strDeveloper <> "DEVONE" Then
                '-- Verificamos la version de la aplicación
                'funVersion()
            End If
            '--
            Dim f As New frmLogin
            f.ShowDialog()
            'bolLogin = True
            If bolLogin = True Then
                '-- Todo bien en frmLogin
                '-- Aplica Configuracion para Cuentas por Cobrar
                '-- subConfiguraParametros()
                Application.Run(New frmMain())
            Else
                Application.Exit()
            End If
        End Sub

        'Shared Function funVersion()
        '    '-- Proceso de actualizacion de version
        '    'Dim verssion As String
        '    Dim ConnectionFile As New System.IO.StreamReader(Application.StartupPath & "\server.ini")

        '    strServidor = ConnectionFile.ReadLine.ToString()
        '    strUserSql = ConnectionFile.ReadLine.ToString()
        '    strKey = ConnectionFile.ReadLine.ToString()
        '    strBaseDatos = ConnectionFile.ReadLine.ToString()
        '    'verssion = ConnectionFile.ReadLine.ToString()

        '    ConnectionFile.Close()

        '    'strSQL = "SELECT strVersion FROM Gen_Version"
        '    'Dim vcVersion As String = funGetValor(strSQL)

        '    'If verssion <> vcVersion Then
        '    '    Dim ConnectionFile1 As New System.IO.StreamWriter(Application.StartupPath & "\Server.ini")
        '    '    '--
        '    '    ConnectionFile1.WriteLine(strServidor)
        '    '    ConnectionFile1.WriteLine(strUserSql)
        '    '    ConnectionFile1.WriteLine(strKey)
        '    '    ConnectionFile1.WriteLine(strBaseDatos)
        '    '    ConnectionFile1.WriteLine(Mid(verssion, 1, 6) & (CDbl(Mid(verssion, 7)) + 1))
        '    '    ConnectionFile1.Close()
        '    '    Dim rutaApp As String = Application.StartupPath & "\" & "sysUpdater.exe"
        '    '    Diagnostics.Process.Start(rutaApp)
        '    'End If

        '    Return True

        'End Function
    End Class

End Namespace