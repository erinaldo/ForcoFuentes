Imports System.Data

Partial Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Sub LogOut()
        Session.Clear()
        Session.Abandon()
        'delete the users auth cookie and sign out
        FormsAuthentication.SignOut()
        'redirect the user to their referring page
        Response.Redirect(Request.UrlReferrer.ToString())
    End Sub
    Private Sub AutenticarUsuario()
        Try
            Dim authenticated As Boolean = True
            Dim redirectURL As String = ""
            Dim usuario As String = Me.Login1.UserName.ToString.Trim
            Dim passwordIngresado As String = Me.Login1.Password.ToString.Trim
            '-- Logical Data
            authenticated = clsSeguridad.funComprobarUsuario(usuario, passwordIngresado)
            '--
            If authenticated Then
                Dim dtUsuario As DataTable = clsSeguridad.funGetUsuarioInformacion(usuario)
                Dim usuarioDB As String
                '--
                If dtUsuario.Rows.Count > 0 And dtUsuario.Rows(0).Item("nForco") > 0 Then
                    usuarioDB = dtUsuario.Rows(0).Item("Usuario_Login").ToString
                    Dim encryptedTicket As String
                    Dim authTicket As FormsAuthenticationTicket
                    Dim authCookie As HttpCookie
                    ' roles = ObtenerRolesUsuario(usuario)
                    authTicket = New FormsAuthenticationTicket(1, usuarioDB, Now, DateAdd(DateInterval.Minute, 60, Now), False, "")
                    Session("NombreUsuario") = usuarioDB
                    encryptedTicket = FormsAuthentication.Encrypt(authTicket)
                    authCookie = New HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket)
                    Response.Cookies.Add(authCookie)
                    redirectURL = FormsAuthentication.GetRedirectUrl(usuarioDB, False)
                    '--                    
                Else
                    Response.Redirect("frmAccessDenied.aspx")
                End If
                '--
                Response.Redirect("frmBienvenida.aspx")
            Else
                Me.Login1.FailureText = "El usuario no existe o la contraseña digitada es incorrecta."
            End If
            '--
        Catch ex As Exception
            Me.Login1.FailureText = "El usuario no existe o la contraseña digitada es incorrecta."
        End Try
    End Sub

    Protected Sub Login1_Authenticate(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.AuthenticateEventArgs)
        'Me.AutenticarUsuario()
    End Sub

    Protected Sub LoginButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.AutenticarUsuario()
    End Sub
End Class
