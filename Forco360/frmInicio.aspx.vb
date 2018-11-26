
Partial Class frmInicio

    Inherits PageCRM

#Region "Eventos"

#Region "Page"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            'Metodo
            'CType(Me.Master, MasterCRM3).ObtenerValidacionUsuario = User.Identity.Name
            CType(Me.Master, MasterCRM3).PageTitle = "Bienvenido(a) al CRM Alpiste"

        End If

    End Sub

#End Region

#End Region

End Class
