
Partial Class frmAccessDenied

    Inherits System.Web.UI.Page

#Region "Eventos"

#Region "Page"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            lblAccessDenied.Text = "Acceso Denegado"
            lblMensajeUsuario.Text = "El usuario " & User.Identity.Name & " no tiene permisos para ingresar a este link por favor contacte al administrador para poder ingresar"

            Dim indications As String = "Intente <a href='javascript:location.reload();'>refrescar</a> su página en unos minutos. Si el problema persiste, por favor contacte a su Administrador de Sistemas."

            Me.lblIndications.Text = indications

        End If

    End Sub

#End Region

#End Region

End Class
