Public Class Showprint
    Sub ShowFrm()
        Dim frmNew As Frm_printreport
        frmNew = New Frm_printreport
        frmNew.Show()
        frmNew.WindowState = FormWindowState.Normal
        frmNew.BringToFront()
    End Sub
End Class
