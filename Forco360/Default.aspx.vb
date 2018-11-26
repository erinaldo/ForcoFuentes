
Partial Class _Default

    Inherits PageCRM

#Region "Funciones Generales"

    Private Sub InitialInformation()

        'Response.Redirect("~/frmBuscarCliente.aspx")
        Response.Redirect("~/frmBienvenida.aspx")

    End Sub

#End Region

#Region "Eventos"

#Region "Page"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack Then

            Me.InitialInformation()

        End If

    End Sub

#End Region

#End Region

End Class
