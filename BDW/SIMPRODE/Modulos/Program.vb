Imports System
Imports System.Windows.Forms

Namespace SIMPRODE
    Friend NotInheritable Class Program
        Private Sub New()
        End Sub
        <STAThread()>
        Shared Sub Main()
            '--
            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            '-- Primero carga splahs
            Dim f1 As New frmSplash
            f1.ShowDialog()
            '-- Cargamos el menu
            Dim f2 As New frmLogin
            f2.ShowDialog()
            If bolLogin = True Then
                '-- 
                Application.Run(New frmMain())
            Else
                Application.Exit()
            End If
        End Sub

    End Class

End Namespace