Imports Microsoft.VisualBasic


Public Class PageCRM
    Inherits System.Web.UI.Page

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)


        'If Not HttpContext.Current.User.Identity.IsAuthenticated Then
        'FormsAuthentication.RedirectToLoginPage()
        'End If

        MyBase.OnLoad(e)
    End Sub
End Class
