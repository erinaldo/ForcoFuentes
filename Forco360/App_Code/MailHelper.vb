Imports Microsoft.VisualBasic
Imports System.Net.Mail
Imports System.Web
Imports System.IO

Public Class MailHelper



    Public Shared Sub SendMailMassage(ByVal username As String, ByVal recepient As String, ByVal subject As String, ByVal descripcion As String, ByVal template As String, ByVal url_Pendiente As String)

        Dim mMailMeesage As New MailMessage()

        Try

            Dim body As String = String.Empty
            Dim reader As StreamReader = New StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplate/" + template))

            body = reader.ReadToEnd
            body = body.Replace("{UserName}", username)
            body = body.Replace("{Description}", descripcion + "</br>")
            body = body.Replace("{ver_pendientes}", url_Pendiente)
            reader.Close()
            mMailMeesage.To.Add(New MailAddress(recepient))


            mMailMeesage.Subject = subject
            mMailMeesage.Body = body
            mMailMeesage.IsBodyHtml = True
            mMailMeesage.Priority = MailPriority.High
            mMailMeesage.From = New MailAddress("noreply@alpiste.co.cr")


            Dim SmtpMail As New SmtpClient()
            Dim basicAuthenticationInfo As New System.Net.NetworkCredential("noreply@alpiste.co.cr", "Crmalpiste123")
            'SmtpMail.Host = "smtp.gmail.com"
            SmtpMail.Host = "smtp.office365.com"
            SmtpMail.UseDefaultCredentials = True
            SmtpMail.Credentials = basicAuthenticationInfo
            SmtpMail.Port = 587
            SmtpMail.EnableSsl = True
            SmtpMail.Send(mMailMeesage)


        Catch ex As Exception

        End Try

    End Sub

    

End Class
